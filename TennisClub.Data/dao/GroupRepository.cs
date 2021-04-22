using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using TennisClub.AppCore.model.impl;
using TennisClub.Data.dao.interfaces;
using TennisClub.Data.model;
using TennisClub.Data.context;
using TennisClub.Data.mappers;

namespace TennisClub.Data.dao
{
    public class GroupRepository : GenericRepository<GroupInDb, GroupInDb, Guid>, IGroupRepository
    {
        private readonly PostgresDbContext _dbContext;
        public GroupRepository(PostgresDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override IList<GroupInDb> FindAll()
        {
            return _dbContext.GroupDbSet.ToList();
        }

        public List<GroupInDb> FindVacantGroups(
            List<DayOfWeek> days, 
            GameLevel gameLevel, 
            int childrenAmount, 
            Func<int, int, bool> ageRuleChecker)
        {
            DateTime today = DateTime.Now;

            var groups = _dbContext.GroupDbSet
                .Select(group => new
                {
                    Group = group,
                    Children = _dbContext.ChildDbSet
                        .Where(ch => ch.GroupId == group.Id)
                        .Select(ch => ch.Birthday)
                        .ToList()
                })
                .Where(it => it.Group.ChildrenAmount < childrenAmount)
                .Where(it =>it.Group.GameLevel == gameLevel)
                .Where(it => days.Contains(it.Group.LessonsDay))
                .ToList()
                .Where(it => ageRuleChecker(
                                          (int) (today - it.Children.Min()).TotalHours / 24 / 365,
                                          (int) (today - it.Children.Max()).TotalHours / 24 / 365)
                )
                .Select(it => it.Group)
                .ToList();
            groups.Sort((x, y) => x.ChildrenAmount.CompareTo(y.ChildrenAmount));
            groups = groups.Distinct(new GroupComparer())
                .ToList();
            return groups;
        }
        
        public IList<GroupInDb> FindAllByDayAndGameLevel(DayOfWeek day, GameLevel gameLevel)
        {
            return _dbContext.GroupDbSet
                .Where(it => it.LessonsDay == day 
                             && it.GameLevel == gameLevel)
                .ToList();
        }
        
        public IList<GroupInDb> FindAllByDay(DayOfWeek day)
        {
            return _dbContext.GroupDbSet
                .Where(it => it.LessonsDay == day)
                .ToList();
        }

        public new void Update(GroupInDb entity)
        {
            var grp = _dbContext.Find<GroupInDb>(entity.Id);
            grp.ChildrenAmount = entity.ChildrenAmount;
            grp.GameLevel = entity.GameLevel;
            grp.LessonsDay = entity.LessonsDay;
            _dbContext.GroupDbSet.Update(grp);
        }

        public IList<GroupInDb> FindAllByGameLevel(GameLevel gameLevel)
        {
            return _dbContext.GroupDbSet
                .Where(it => it.GameLevel == gameLevel)
                .ToList();
        }

        private class GroupComparer : IEqualityComparer<GroupInDb>
        {
            public bool Equals(GroupInDb x, GroupInDb y)
            { 
                // bool equalAge = x.ChildrenAmount.CompareTo(y.ChildrenAmount);
                return x.LessonsDay == y.LessonsDay;
            }

            public int GetHashCode(GroupInDb obj)
            {
                return obj.Id.GetHashCode();
            }
        }
    }
}