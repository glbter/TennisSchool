using System;
using System.Collections.Generic;
using System.Text;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.Infrastructure.interfaces
{
    interface IGroupService<TK>
    {
        public void AddChildToGroup(IChild<TK> child);
    }
}
