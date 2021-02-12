using Lab1.dao;
using Lab1.model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Lab1.logic
{
    public class GroupProc : IGroupProc
    {
        private DaoObject _dao;
        private Int32 _maxChildren;
        private Int32 _maxAgeInterval;
        public GroupProc(DaoObject dao, Int32 maxAmountChildrenGroup, Int32 maxAgeIntervalGroup)
        {
            this._dao = dao;
            this._maxChildren = maxAmountChildrenGroup;
            this._maxAgeInterval = maxAgeIntervalGroup;
        }

        public void AddChildToGroup(Child child)
        {
            Group group = _dao.GroupDao.GetAll()
                .Find(it => it.GameLevel == child.GameLevel
                   && it.LessonsDay == child.PreferableDay
                   && IsCapacityAllowAddChild(it, _maxChildren)
                   && WillAgeAllowAddChild(it, child.Age, _maxAgeInterval));

            if(group == null)
            {
                group = new Group(child.GameLevel, child.PreferableDay);
                _dao.GroupDao.Create(group);
            } 
            child.GroupId = group.Id;
            _dao.ChildDao.Create(child);
        }

        
        private bool IsCapacityAllowAddChild(Group group, int maxCapacity)
        {
            return GetAllChildren(group).Count() <= maxCapacity;
        }

        private bool WillAgeAllowAddChild(Group group, int age, int maxAgeInterval)
        {
            int min = MinAge(group);
            int max = MaxAge(group);

            return (age >= min && age <= max)
                || age - min <= maxAgeInterval
                || max - age <= maxAgeInterval;
            
        }
        
        private int MaxAge(Group group)
        {
           return GetAllChildren(group).Max(it => it.Age);
        }

        private int MinAge(Group group)
        {
            return GetAllChildren(group).Min(it => it.Age);
        }

        private List<Child> GetAllChildren(Group group)
        {
            return _dao.ChildDao.GetAll()
                .FindAll(it => it.GroupId == group.Id);
        }
    }
}
