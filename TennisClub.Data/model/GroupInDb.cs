using System;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.Data.model
{
    class GroupInDb : IGroup<Guid>
    {
        public Guid Id { get; } = new Guid();
        public GameLevel GameLevel { get; }
        public DayOfWeek LessonsDay { get; }

        public GroupInDb(GameLevel gameLevel, DayOfWeek lessonsDay)
        {
            this.GameLevel = gameLevel;
            this.LessonsDay = lessonsDay;
        }
    }
}