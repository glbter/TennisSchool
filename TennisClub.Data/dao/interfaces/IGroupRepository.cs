using System;
using System.Collections.Generic;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;
using TennisClub.Data.model;

namespace TennisClub.Data.dao.interfaces
{
    public interface IGroupRepository : IRepository<GroupInDb, GroupInDb, Guid>
    {
        public List<GroupInDb> FindVacantGroups(List<DayOfWeek> days, GameLevel gameLevel,
            int lessThan, Func<int, int, bool> ageRuleChecker);

        public IList<GroupInDb> FindAllByDayAndGameLevel(DayOfWeek day, GameLevel gameLevel);

        public IList<GroupInDb> FindAllByDay(DayOfWeek day);

        public IList<GroupInDb> FindAllByGameLevel(GameLevel gameLevel);
    }
}
