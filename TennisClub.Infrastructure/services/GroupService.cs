using System;
using System.Configuration;
using TennisClub.AppCore.interfaces;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.validators;
using TennisClub.Data.dao;


namespace TennisClub.Infrastructure.services
{
    public class GroupService
    {
        private readonly DaoObject dao;
        private readonly IPairValidator<Child, CachedGroup> isAgeAllowAddChildValidator;
        private readonly ChildService childService;
        private readonly int maxChildren;
        private readonly Predicate<CachedGroup> isNewGroup;
        private readonly Predicate<CachedGroup> isFullGroup;
        public GroupService(DaoObject dao)
        {
            this.dao = dao;
            this.childService = new ChildService(dao);
            this.maxChildren = Convert.ToInt32(
                ConfigurationManager.AppSettings.Get("maxAmountOfChildrenInGroup"));
            this.isAgeAllowAddChildValidator = 
                (IPairValidator<Child, CachedGroup>) new IsAgeAllowAddChildValidator();
            this.isFullGroup = (CachedGroup group) => group.ChildrenAmount == maxChildren;
            this.isNewGroup =  (CachedGroup group) => group.ChildrenAmount == 0;
    }

        public void AddChildToGroup(Child child)
        {
            CachedGroup group = (CachedGroup)dao.CachedGroupDao
                .GroupsByDayOfWeek(child.PreferableDay)
                .Find(it => it.Group.GameLevel == child.GameLevel
                            && isAgeAllowAddChildValidator.Validate(child, (CachedGroup)it));

            group ??= new CachedGroup(child.GameLevel, child.PreferableDay)
                {
                    MinAge = child.Age,
                    MaxAge = child.Age
                };
            this.ChangeAgeInterval(group, child);
            this.AddGroupToDb(group, dao);
            childService.SetChildToGroup(child, group);
        }

        private void ChangeAgeInterval(CachedGroup group, Child child)
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
        }

        private void AddGroupToDb(CachedGroup group, DaoObject dao)
        {
            if (isNewGroup.Invoke(group)) 
                dao.CachedGroupDao.Create(group);
            else
            {
                if (isFullGroup.Invoke(group))
                {
                    // delete from 'cache', store in ordinary
                    dao.CachedGroupDao.Delete(group);
                    dao.GroupDao.Create((Group)group.Group);
                }
                // store in 'cache' table
                else 
                    dao.CachedGroupDao.Update(group);
            }
        }
    }
}
