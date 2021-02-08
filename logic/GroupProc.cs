using Lab1.dao;
using Lab1.model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Lab1.logic
{
    public class GroupProc
    {
        private DaoObject _dao;
        public GroupProc(DaoObject dao)
        {
            this._dao = dao;
        }

        public void AddChildToGroup(Child child)
        {
            Group group = _dao.GroupDao.GetAll()
                .Find(it => it.GameLevel == child.GameLevel
                   && it.LessonsDay == child.PreferableDay
                   && IsCapacityAllow(it, 5)
                   && WillAgeAllow(it, child.Age, 3));

            if(group == null)
            {
                group = new Group(child.GameLevel, child.PreferableDay);
                _dao.GroupDao.Create(group);
            } 
            child.GroupId = group.Id;
            _dao.ChildDao.Create(child);
        }

        
        private bool IsCapacityAllow(Group group, int maxCapacity)
        {
            return GetAllChildren(group).Count() <= maxCapacity
                ;
        }

        private bool WillAgeAllow(Group group, int age, int maxAgeInterval)
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
