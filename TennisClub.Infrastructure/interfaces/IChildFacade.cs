using System;
using System.Collections.Generic;
using TennisClub.AppCore.Model.impl;

namespace TennisClub.Infrastructure.Interfaces
{
    public interface IChildFacade
    {
        public List<Group> AddChild(Child child);
        public bool AddChildWithChosenGroup(Child child, Group group);
        public Child FindChild(Guid id);
        public List<Child> GetAll();
    }
}
