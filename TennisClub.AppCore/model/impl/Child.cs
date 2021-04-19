using System;
using System.Collections.Generic;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.AppCore.model.impl
{
    public class Child : IBaseId<Guid>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public Guid GroupId { get; set; }
        public int Age => DateTime.Today.Subtract(Birthday).Days / 365;

        public DateTime Birthday { get; set; }
        public DayOfWeek LessonsDay { get; set;}
        public List<DayOfWeek> PreferableDays { get; set; }
        public GameLevel GameLevel { get; set;}

        public Child(string firstName, string lastName, 
            GameLevel gameLevel, DayOfWeek lessonsDay, DateTime birthday, Guid id = new Guid())
        {
            this.Id = (id == Guid.Empty) ? Guid.NewGuid() : id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.GameLevel = gameLevel;
            this.LessonsDay = lessonsDay;
            this.Birthday = birthday;
        }

        public Child()
        {
        }
    }
}
