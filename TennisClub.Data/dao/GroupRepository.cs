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

            var found_group = _dbContext.GroupDbSet
                .Select(group =>  new
                {
                    Group = group,
                    Count = _dbContext.ChildDbSet.Count(
                        ch => ch.GroupId == group.Id),
                    Children = _dbContext.ChildDbSet
                        .Where(ch => ch.GroupId == group.Id)
                        .Select(ch => ch.Birthday)
                        .ToList()
                })
                .Where(it => it.Group.LessonsDay == day
                             && it.Group.GameLevel == gameLevel)
                .ToList()
                .FirstOrDefault(it => amountRuleChecker(it.Count)
                                      && ageRuleChecker(
                                          (int) (today - it.Children.Min()).TotalHours / 24 / 365,
                                          (int) (today - it.Children.Max()).TotalHours / 24 / 365)
                )
                ?.Group;
            return found_group;
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
        
        
        public override void Create(GroupInDb entity)
        {
            _dbContext.GroupDbSet.Add(entity);
        }

        public override void Update(GroupInDb entity)
        {
            _dbContext.GroupDbSet.Remove(entity);
            _dbContext.GroupDbSet.Add(entity);
        }

        public override void Delete(GroupInDb entity)
        {
            _dbContext.GroupDbSet.Remove(entity);
        }

        public override void Delete(Guid id)
        {
            _dbContext.GroupDbSet.Remove(new GroupInDb(){ Id = id});
        }

        public override GroupInDb FindById(Guid id)
        {
            return _dbContext.GroupDbSet.Find(id);
        }
        
    }
}