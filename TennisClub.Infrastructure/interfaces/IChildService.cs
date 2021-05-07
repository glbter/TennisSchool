using TennisClub.AppCore.Model.impl;

namespace TennisClub.Infrastructure.Interfaces
{
    public interface IChildService
    {
        public void SetChildToGroup(Child child, Group group);
        public void AddChild(Child child);
    }
}
