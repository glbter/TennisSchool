using System;
using System.Collections.Generic;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;
using TennisClub.Data.model;

namespace TennisClub.Data.dao.interfaces
{
    public interface IGroupRepository : IRepository<GroupInDb, GroupInDb, Guid>
    {
        public GroupInDb FindVacantGroup(DayOfWeek day, GameLevel gameLevel,
            Func<int, bool> amountRuleChecker, Func<int, int, bool> ageRuleChecker);

        public IList<GroupInDb> FindAllByDayAndGameLevel(DayOfWeek day, GameLevel gameLevel);

        public IList<GroupInDb> FindAllByDay(DayOfWeek day);

        public IList<GroupInDb> FindAllByGameLevel(GameLevel gameLevel);
    }
}
