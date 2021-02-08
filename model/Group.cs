using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.model
{
    public class Group : Base
    {
        public GameLevel GameLevel { get; private set; }
        public DayOfWeek LessonsDay { get; private set; }
        public int MinAge { get; }
        public int MaxAge { get; }
        public List<Child> Children { get; }

        public Group(GameLevel gameLevel, DayOfWeek lessonsDay)
        {
            this.GameLevel = gameLevel;
            this.LessonsDay = lessonsDay;
        }
    }
}
