using Lab1.dao;
using Lab1.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.logic
{
    class ChildPipeline
    {
        private IChildProc childProc;
        private IGroupProc groupProc;

        public ChildPipeline(DaoObject dao, Int32 maxAmountChildrenGroup, Int32 maxAgeIntervalGroup)
        {
            groupProc = new GroupProc(dao, maxAmountChildrenGroup, maxAgeIntervalGroup);
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
