using System;
using System.Collections.Generic;
using TennisClub.AppCore.model.impl;
using TennisClub.Data.model;

namespace TennisClub.Data.dao.interfaces
{
    public interface IGroupRepository : IRepository<GroupInDb, GroupInDb, Guid>
    {
        GroupInDb FindVacantGroup(DayOfWeek day, GameLevel gameLevel,
            Func<int, bool> amountRuleChecker, Func<int, int, bool> ageRuleChecker);

        IList<GroupInDb> FindAllByDayAndGameLevel(DayOfWeek day, GameLevel gameLevel);

        IList<GroupInDb> FindAllByDay(DayOfWeek day);

        IList<GroupInDb> FindAllByGameLevel(GameLevel gameLevel);
    }
}
