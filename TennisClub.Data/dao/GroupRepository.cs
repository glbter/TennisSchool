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
        private readonly DateToYearsMapper _dateMapper;
        public GroupRepository(PostgresDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dateMapper = new DateToYearsMapper();
        }

        public override IList<GroupInDb> FindAll()
        {
            return _dbContext.GroupDbSet.ToList();
        }

        public GroupInDb FindVacantGroup(
            DayOfWeek day, 
            GameLevel gameLevel, 
            Func<int, bool> amountRuleChecker, 
            Func<int, int, bool> ageRuleChecker)
        {
            DateTime today = DateTime.Now;

            var group =  _dbContext.GroupDbSet
                .Select(group => new {
                    Group = group,
                    Count = _dbContext.ChildDbSet.Count(
                        ch => ch.GroupId == group.Id),
                    MinAge = _dbContext.ChildDbSet
                        .Where(ch => ch.GroupId == group.Id)
                        .Select(ch => ch.Birthday - today)
                        .Min(),
                    MaxAge = _dbContext.ChildDbSet
                        .Where(ch => ch.GroupId == group.Id)
                        .Select(ch =>  ch.Birthday - today)
                        .Max()
                })
                .Where(it => it.Group.LessonsDay == day 
                             && it.Group.GameLevel == gameLevel)
                .FirstOrDefault(it => amountRuleChecker(it.Count)
                                      && ageRuleChecker(
                                          (int) it.MinAge.TotalHours * 365,
                                          (int) it.MaxAge.TotalHours * 365)
                )
                ?.Group;
            return group;
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
        
        public IList<GroupInDb> FindAllByGameLevel(GameLevel gameLevel)
        {
            return _dbContext.GroupDbSet
                .Where(it => it.GameLevel == gameLevel)
                .ToList();
        }
    }
}