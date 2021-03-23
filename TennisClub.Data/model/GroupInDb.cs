using System;
using TennisClub.AppCore.model.impl;

namespace TennisClub.Data.model
{
    public class GroupInDb
    {
        public Guid Id { get; set; }
        public GameLevel GameLevel { get; set; }
        public DayOfWeek LessonsDay { get; set; }

        public GroupInDb(GameLevel gameLevel, DayOfWeek lessonsDay, Guid id)
        {
            this.Id = id;
            this.GameLevel = gameLevel;
            this.LessonsDay = lessonsDay;
        }

        public GroupInDb() { }
    }
}