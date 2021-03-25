using System;
using TennisClub.AppCore.model.impl;

namespace TennisClub.WpfDesktop.model
{
    public class ChildWpf
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public DayOfWeek LessonsDay { get; set; }
        public GameLevel GameLevel { get; set; }
        
        public ChildWpf(string name, string lastName, GameLevel gameLevel, DayOfWeek lessonsDay, DateTime birthday = new DateTime(), Guid id = new Guid())
        {
            Id = id;
            Name = name;
            LastName = lastName;
            this.GameLevel = gameLevel;
            this.LessonsDay = lessonsDay;
            this.Birthday = birthday;
        }
    }
}