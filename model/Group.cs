using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.model
{
    public class Group : IBaseId
    {
        public Guid Id { get; } = new Guid();
        public GameLevel GameLevel { get; private set; }
        public DayOfWeek LessonsDay { get; private set; }

        public Group(GameLevel gameLevel, DayOfWeek lessonsDay)
        {
            this.GameLevel = gameLevel;
            this.LessonsDay = lessonsDay;
        }
    }
}
