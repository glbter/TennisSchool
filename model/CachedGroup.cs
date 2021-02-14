using Lab1.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.dao
{
    public class CachedGroup : IBaseId
    {
        public Guid Id { get; }
        public Group Group { get; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int ChildrenAmount { get; set; } = 0;
        public CachedGroup(Group group)
        {
            Id = group.Id;
        }
    }
}
