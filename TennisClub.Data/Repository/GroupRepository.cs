﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TennisClub.AppCore.Model.impl;
using TennisClub.Data.Context;
using TennisClub.Data.Model;
using TennisClub.Data.Repository.interfaces;

namespace TennisClub.Data.Repository
{
    public class GroupRepository : GenericRepository<GroupInDb, GroupInDb, Guid>, IGroupRepository
    {
        private readonly TennisClubContext _dbContext;
        public GroupRepository(TennisClubContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override IList<GroupInDb> FindAll()
        {
            return _dbContext.GroupDbSet.ToList();
        }

        public override async Task<IList<GroupInDb>> FindAllAsync()
        {
            return await _dbContext.GroupDbSet.ToListAsync();
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
        
        public async Task<List<GroupInDb>> FindVacantGroupsAsync(
            List<DayOfWeek> days, 
            GameLevel gameLevel, 
            int childrenAmount, 
            Func<int, int, bool> ageRuleChecker)
        {
            DateTime today = DateTime.Now;

            var groups = await _dbContext.GroupDbSet
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
                .ToListAsync();
            
            var filteredGroups = groups
                .Where(it => ageRuleChecker(
                    (int) (today - it.Children.Min()).TotalHours / 24 / 365,
                    (int) (today - it.Children.Max()).TotalHours / 24 / 365)
                )
                .Select(it => it.Group)
                .ToList();
            
            filteredGroups.Sort((x, y) => x.ChildrenAmount.CompareTo(y.ChildrenAmount));
            filteredGroups = filteredGroups.Distinct(new GroupComparer())
                .ToList();
            return filteredGroups;
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