using System;
using TennisClub.AppCore.model.impl;

namespace TennisClub.AppCore.model.interfaces
{
    public interface IChild : IBaseId
    {
        public string FirstName { get; }
        public string LastName { get;  }
        public Guid GroupId { get; set; }
        public int Age { get; }
        public DayOfWeek PreferableDay { get; }
        public GameLevel GameLevel { get; }
    }
}