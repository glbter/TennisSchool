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
        private readonly DaoObject dao;
        private readonly Int32 maxChildren;
        private readonly Int32 maxAgeInterval;
        public GroupProc(DaoObject dao, Int32 maxAmountChildrenGroup, Int32 maxAgeIntervalGroup)
        {
            this.dao = dao;
            this.maxChildren = maxAmountChildrenGroup;
            this.maxAgeInterval = maxAgeIntervalGroup;
        }

        public void AddChildToGroup(Child child)
        {
            Group group = dao.GroupDao.GetAll()
                .Find(it => it.GameLevel == child.GameLevel
                   && it.LessonsDay == child.PreferableDay
                   && IsCapacityAllowAddChild(it, maxChildren)
                   && WillAgeAllowAddChild(it, child.Age, maxAgeInterval));

            if(group == null)
            {
                group = new Group(child.GameLevel, child.PreferableDay);
                dao.GroupDao.Create(group);
            } 
            child.GroupId = group.Id;
            dao.ChildDao.Create(child);
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
            return dao.ChildDao.GetAll()
                .FindAll(it => it.GroupId == group.Id);
        }
    }
}
