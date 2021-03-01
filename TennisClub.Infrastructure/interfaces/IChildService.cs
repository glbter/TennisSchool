using System;
using System.Collections.Generic;
using System.Text;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.Infrastructure.interfaces
{
    interface IChildService<TK>
    {
        public void SetChildToGroup(IChild<TK> child, ICachedGroup<TK> group);
    }
}
