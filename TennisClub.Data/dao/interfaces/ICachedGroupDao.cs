using System;
using System.Collections.Generic;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.Data.dao.interfaces
{
    public interface ICachedGroupDao<T> : IDao<T>, IDaoUpdate<T>, IDaoDelete<T>
    {
        public List<T> GroupsByGameLevel(GameLevel level);
        public List<T> GroupsByDayOfWeek(DayOfWeek dayOfWeek);
    }
}
