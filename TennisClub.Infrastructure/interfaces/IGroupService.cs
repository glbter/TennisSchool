using System.Collections.Generic;
using TennisClub.AppCore.Model.impl;

namespace TennisClub.Infrastructure.Interfaces
{
    public interface IGroupService
    {
        public void AddChildToGroup(Child child, Group group);
        public List<Group> TryAddChildToGroup(Child child);
    }
}
