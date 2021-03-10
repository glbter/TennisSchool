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
    public class ChildPipeline<TK> : IChildPipeline<TK>
    {
        private readonly Predicate<IChild<TK>> isNotAdult;
        private readonly GroupService<TK> groupService;

        public ChildPipeline(UnitOfWork dao)
        {
            groupService = new GroupService<TK>(dao);
            isNotAdult = child => child.Age < 18;
        }

        public bool AddChild(IChild<TK> child)
        {
            if (!isNotAdult.Invoke(child)) return false;
            groupService.AddChildToGroup(child);
            return true;
        }
    }
}
