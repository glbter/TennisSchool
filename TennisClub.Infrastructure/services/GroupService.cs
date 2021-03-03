using System;
using System.Configuration;
using TennisClub.AppCore.interfaces;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;
using TennisClub.AppCore.validators;
using TennisClub.Data.dao;
using TennisClub.Infrastructure.interfaces;

namespace TennisClub.Infrastructure.services
{
    public class GroupService<TK> : IGroupService<TK>
    {
        private readonly DaoObject dao;
        private readonly IPairValidator<IChild<TK>, ICachedGroup<TK>> isAgeAllowAddChildValidator;
        private readonly IChildService<TK> childService;
        private readonly Predicate<CachedGroup> isNewGroup;
        private readonly Predicate<CachedGroup> isFullGroup;
        public GroupService(DaoObject dao)
        {
            this.dao = dao;
            this.childService = new ChildService<TK>(dao); 
            int maxChildren = Convert.ToInt32(
                ConfigurationManager.AppSettings["maxAmountOfChildrenInGroup"] ?? "5");
            this.isAgeAllowAddChildValidator = new IsAgeAllowAddChildValidator<TK>();
            this.isFullGroup = (CachedGroup group) => group.ChildrenAmount == maxChildren;
            this.isNewGroup =  (CachedGroup group) => group.ChildrenAmount == 0;
    }

        public void AddChildToGroup(IChild<TK> child)
        {
            CachedGroup group = dao.CachedGroupDao
                .GroupsByDayOfWeek(child.PreferableDay)
                .Find(it => it.Group.GameLevel == child.GameLevel
                            && isAgeAllowAddChildValidator.Validate(child, (ICachedGroup<TK>) it));

            group ??= new CachedGroup(child.GameLevel, child.PreferableDay)
                {
                    MinAge = child.Age,
                    MaxAge = child.Age
                };
            this.ChangeAgeInterval(group, child);
            this.AddGroupToDb(group, dao);
            childService.SetChildToGroup(child, (ICachedGroup<TK>) group);
        }

        private void ChangeAgeInterval(CachedGroup group, IChild<TK> child)
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
