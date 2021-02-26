using System;
using TennisClub.AppCore.interfaces;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;
using TennisClub.AppCore.validators;
using TennisClub.Data.dao;
using TennisClub.Infrastructure.services;

namespace TennisClub.Infrastructure.pipelines
{
    public class ChildPipeline
    {
        private readonly Predicate<IChild> _isNotAdult;
        private readonly GroupService _groupService;

        public ChildPipeline(DaoObject dao)
        {
            _groupService = new GroupService(dao);
            _isNotAdult = child => child.Age < 18;
        }

        public bool AddChild(Child child)
        {
            if (!_isNotAdult.Invoke(child)) return false;
            _groupService.AddChildToGroup(child);
            return true;
        }
    }
}
