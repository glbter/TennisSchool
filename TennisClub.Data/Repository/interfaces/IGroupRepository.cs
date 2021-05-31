using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TennisClub.AppCore.Model.impl;
using TennisClub.Data.Model;

namespace TennisClub.Data.Repository.interfaces
{
    public interface IGroupRepository : IRepository<GroupInDb, GroupInDb, Guid>
    {
        public List<GroupInDb> FindVacantGroups(List<DayOfWeek> days, GameLevel gameLevel,
            int lessThan, Func<int, int, bool> ageRuleChecker);

        public Task<List<GroupInDb>> FindVacantGroupsAsync(List<DayOfWeek> days, GameLevel gameLevel,
            int childrenAmount, Func<int, int, bool> ageRuleChecker);
        
        public IList<GroupInDb> FindAllByDayAndGameLevel(DayOfWeek day, GameLevel gameLevel);

        public IList<GroupInDb> FindAllByDay(DayOfWeek day);

        public IList<GroupInDb> FindAllByGameLevel(GameLevel gameLevel);
    }
}
