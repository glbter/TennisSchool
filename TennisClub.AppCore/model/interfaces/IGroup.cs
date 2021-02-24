using System;
using TennisClub.AppCore.model.impl;

namespace TennisClub.AppCore.model.interfaces
{
    public interface IGroup : IBaseId
    {
        public GameLevel GameLevel { get; }
        public DayOfWeek LessonsDay { get; }
    }
}