using System;
using System.Collections.Generic;
using System.Text;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.Infrastructure.interfaces
{
    interface IGroupService
    {
        public void AddChildToGroup(Child child);
    }
}
