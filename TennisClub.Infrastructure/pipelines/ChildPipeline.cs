using System;
using TennisClub.AppCore.interfaces;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;
using TennisClub.AppCore.validators;
using TennisClub.Data.dao;
using TennisClub.Infrastructure.interfaces;
using TennisClub.Infrastructure.services;

namespace TennisClub.Infrastructure.pipelines
{
    public class ChildPipeline : IChildPipeline
    {
        private readonly Predicate<Child> isNotAdult;
        private readonly GroupService groupService;

        public ChildPipeline(UnitOfWork dao)
        {
            groupService = new GroupService(dao);
            isNotAdult = child => child.Age < 18;
        }

        public bool AddChild(Child child)
        {
            if (!isNotAdult.Invoke(child)) return false;
            groupService.AddChildToGroup(child);
            return true;
        }
    }
}
