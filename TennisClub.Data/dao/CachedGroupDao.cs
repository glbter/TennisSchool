using System;
using System.Collections.Generic;
using TennisClub.Data.dao.interfaces;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.Data.dao
{
    class CachedGroupDao<T> : Dao<T>, ICachedGroupDao<T>
        where T : ICachedGroup
    {
        public void Delete(T group)
        {
            entities.RemoveAll(it => group.Id == it.Id);
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
