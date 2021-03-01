using System;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.AppCore.model.impl
{
    public class Group : IGroup<Guid>
    {
        public Guid Id { get; } = new Guid();
        public GameLevel GameLevel { get; }
        public DayOfWeek LessonsDay { get; }

        public Group(GameLevel gameLevel, DayOfWeek lessonsDay)
        {
            this.GameLevel = gameLevel;
            this.LessonsDay = lessonsDay;
        }
    }
}
