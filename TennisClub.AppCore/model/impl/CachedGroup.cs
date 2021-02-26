using System;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.AppCore.model.impl
{
    public class CachedGroup : ICachedGroup
    {
        public Guid Id { get; }
        public IGroup Group { get; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int ChildrenAmount { get; set; }

        public CachedGroup(Group group)
        {
            ChildrenAmount = 0;
            Id = group.Id;
            Group = group;
        }

        public CachedGroup(GameLevel gameLevel, DayOfWeek lessonsDay)
        {
            ChildrenAmount = 0;
            Group group = new Group(gameLevel, lessonsDay);
            Id = group.Id;
            Group = group;
        }
    }
}
