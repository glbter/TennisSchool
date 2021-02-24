using System;
using System.Configuration;
using TennisClub.AppCore.interfaces;
using TennisClub.AppCore.model.impl;
using TennisClub.Data.dao;


namespace TennisClub.Infrastructure.services
{
    public class GroupService
    {
        private readonly DaoObject dao;
        private readonly IPairValidator<Child, CachedGroup> isAgeAllowAddChildValidator;
        private readonly ChildService childService;
        private readonly int maxChildren;
        public GroupService(DaoObject dao)
        {
            this.dao = dao;
            this.childService = new ChildService(dao);
            this.maxChildren = Convert.ToInt32(
                ConfigurationManager.AppSettings.Get("maxAmountOfChildrenInGroup"));
        }

        public void AddChildToGroup(Child child)
        {
            CachedGroup group = (CachedGroup)dao.CachedGroupDao
                .GroupsByDayOfWeek(child.PreferableDay)
                .Find(it => it.Group.GameLevel == child.GameLevel
                            && isAgeAllowAddChildValidator.Validate(child, (CachedGroup)it));

            if (group == null)
            {
                Group grp = new Group(child.GameLevel, child.PreferableDay);
                group = new CachedGroup(grp)
                {
                    MinAge = child.Age,
                    MaxAge = child.Age
                };
                group = (CachedGroup)childService.SetChildToGroup(child, group);
                dao.CachedGroupDao.Create(group);
            }
            else
            {
                group = ChangeAgeInterval(group, child);
                group = (CachedGroup)childService.SetChildToGroup(child, group);

                if (group.ChildrenAmount != maxChildren)
                {
                    // store in 'cache' table
                    dao.CachedGroupDao.Update(group);
                }
                else
                {
                    // delete from 'cache', store in ordinary
                    dao.CachedGroupDao.Delete(group);
                    dao.GroupDao.Create((Group)group.Group);
                }
            }
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
