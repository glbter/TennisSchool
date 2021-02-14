using Lab1.dao;
using Lab1.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.logic
{
    public interface IChildProcGrouper
    {
        public CachedGroup SetChildToGroup(Child child, CachedGroup group);
    }
}
