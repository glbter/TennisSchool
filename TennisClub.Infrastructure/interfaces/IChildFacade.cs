using System;
using System.Collections.Generic;
using System.Text;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.Infrastructure.interfaces
{
    public interface IChildFacade
    {
        public List<Group> AddChild(Child child);
        public bool AddChildWithChosenGroup(Child child, Group group);
        public Child FindChild(Guid id);
        public List<Child> GetAll();
    }
}
