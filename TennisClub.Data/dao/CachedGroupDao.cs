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
        public void Delete(T group)
        {
            Entities.RemoveAll(it => group.Id.Equals(it.Id));
        }

        public void Update(T group)
        {
            Delete(group);
            Create(group);
        }

        public List<T> GroupsByDayOfWeek(DayOfWeek dayOfWeek)
        {
            return GetAll().FindAll(it => it.Group.LessonsDay == dayOfWeek);
        }

        public List<T> GroupsByGameLevel(GameLevel level)
        {
            return GetAll().FindAll(it => it.Group.GameLevel == level);
        }
    }
}
