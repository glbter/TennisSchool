using System;
using System.Collections.Generic;
using System.Text;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.Infrastructure.interfaces
{
    public interface IChildFacade
    {
        public bool AddChild(Child child);
    }
}
