using TennisClub.AppCore.model.impl;

namespace TennisClub.Infrastructure.interfaces
{
    interface IChildService<TK>
    {
       void SetChildToGroup(Child child, Group group);
    }
}
