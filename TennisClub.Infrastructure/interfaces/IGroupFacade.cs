using System;
using System.Collections.Generic;
using TennisClub.AppCore.Model.impl;

namespace TennisClub.Infrastructure.Interfaces
{
    public interface IGroupFacade
    {
        public Group FindGroup(Guid id);
        public List<Group> GetAll();
    }
}