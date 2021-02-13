using Lab1.dao;
using Lab1.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.logic
{
    class ChildPipeline
    {
        private readonly IChildProc childProc;
        private readonly IGroupProc groupProc;

        public ChildPipeline(DaoObject dao)
        {
            groupProc = new GroupProc(dao);
            childProc = new ChildProc(dao);
        }

        public bool AddChild(Child child)
        {
            if (childProc.IsChild(child))
            {
                groupProc.AddChildToGroup(child);
                return true;
            }
            return false;
        }
    }
}
