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
        public int ChildrenAmount { get; set; } = 0;
        public CachedGroup(Group group)
        {
            Id = group.Id;
        }
    }
}
