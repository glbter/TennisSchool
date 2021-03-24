using System;
using TennisClub.AppCore.model.impl;

namespace TennisClub.WpfUi.model
{
    public class ChildWpf
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DayOfWeek LessonsDay { get; set; }
        public GameLevel GameLevel { get; set; }
        
        public ChildWpf(Guid id, string name, string lastName, GameLevel gameLevel, DayOfWeek lessonsDay, int age)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            this.GameLevel = gameLevel;
            this.LessonsDay = lessonsDay;
            this.Age = age;
        }
    }
}