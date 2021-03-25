using System;
using System.Collections.Generic;
using System.Text;
using TennisClub.AppCore.model.interfaces;
using TennisClub.AppCore.model.impl;

namespace TennisClub.Infrastructure.interfaces
{
    public interface IChildService
    {
        public void SetChildToGroup(Child child, Group group);
    }
}
