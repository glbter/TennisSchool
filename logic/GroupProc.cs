using System.Configuration;
using System.Collections.Specialized;
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
        private IChildProcGrouper childProc;
        private readonly int maxChildren;
        private readonly int maxAgeInterval;
        public GroupProc(DaoObject dao)
        {
            this.dao = dao;
            this.childProc = new ChildProc(dao);
            this.maxChildren = Convert.ToInt32(
                ConfigurationManager.AppSettings.Get("maxAmountOfChildrenInGroup"));
            this.maxAgeInterval = Convert.ToInt32(
                ConfigurationManager.AppSettings.Get("maxChildrenAgeIntervalInGroup"));
        }

        public void AddChildToGroup(Child child)
        {
            CachedGroup group = dao.CachedGroupDao
                .GroupsByDayOfWeek(child.PreferableDay)
                .Find(it => it.Group.GameLevel == child.GameLevel 
                            && WillAgeAllowAddChild(it, child));

            if(group == null)
            {
                Group grp = new Group(child.GameLevel, child.PreferableDay);
                group = new CachedGroup(grp)
                {
                    MinAge = child.Age,
                    MaxAge = child.Age
                };
                group = childProc.SetChildToGroup(child, group);
                dao.CachedGroupDao.Create(group);
            } 
            else
            {
                group = ChangeAgeInterval(group, child);
                group = childProc.SetChildToGroup(child, group);

                if (group.ChildrenAmount != maxChildren)
                {
                    // store in 'cache' table
                    dao.CachedGroupDao.Update(group);
                }
                else
                {
                    // delete from 'cache', store in ordinary
                    dao.CachedGroupDao.Delete(group);
                    dao.GroupDao.Create(group.Group);
                }
            }
        }

        private bool WillAgeAllowAddChild(CachedGroup group, Child child)
        {
            int age = child.Age;
            return (age >= group.MinAge && age <= group.MaxAge)
                || age - group.MinAge <= maxAgeInterval
                || group.MaxAge - age <= maxAgeInterval;
            
        }

        private CachedGroup ChangeAgeInterval(CachedGroup group, Child child)
        {
            int chAge = child.Age;
            if (group.MinAge > chAge)
            {
                group.MinAge = chAge;
            }
            else if (group.MaxAge < chAge)
            {
                group.MaxAge = chAge;
            }
            return group;
        }
    }
}
