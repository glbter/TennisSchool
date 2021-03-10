using System;
using System.Collections.Generic;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.Data.dao.interfaces
{
    public interface ICachedGroupDao<T, in TK> : IDao<T, TK>
    {
        public List<T> GroupsByGameLevel(GameLevel level);
        public List<T> GroupsByDayOfWeek(DayOfWeek dayOfWeek);
    }
}
