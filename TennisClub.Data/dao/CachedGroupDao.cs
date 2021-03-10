using System;
using System.Collections.Generic;
using TennisClub.Data.dao.interfaces;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.Data.dao
{
    class CachedGroupDao<T, TK> : Dao<T, TK>, ICachedGroupDao<T, TK>
        where T : ICachedGroup<TK>
    {
        public List<T> GroupsByDayOfWeek(DayOfWeek dayOfWeek)
        {
            return FindAll().FindAll(it => it.Group.LessonsDay == dayOfWeek);
        }

        public List<T> GroupsByGameLevel(GameLevel level)
        {
            return FindAll().FindAll(it => it.Group.GameLevel == level);
        }
    }
}
