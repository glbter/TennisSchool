using System;
using TennisClub.AppCore.model.impl;

namespace TennisClub.AppCore.model.interfaces
{
    public interface IGroup<out TK> : IBaseId<TK>
    {
        public GameLevel GameLevel { get; }
        public DayOfWeek LessonsDay { get; }
    }
}