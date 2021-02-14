using Lab1.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.dao
{
    public interface ICachedGroupDao : IDao<CachedGroup>, IDaoUpdate<CachedGroup>, IDaoDelete<CachedGroup>
    {
        public List<CachedGroup> GroupsByGameLevel(GameLevel level);
        public List<CachedGroup> GroupsByDayOfWeek(DayOfWeek dayOfWeek);
    }
}
