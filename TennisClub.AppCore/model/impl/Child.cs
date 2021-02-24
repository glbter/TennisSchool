using System;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.AppCore.model.impl
{
    public class Child : IChild
    {
        public Guid Id { get; } = new Guid();
        public string FirstName { get; }
        public string LastName { get; }
        public Guid GroupId { get; set; }
        public int Age 
        {
            get => (int) birthday.Subtract(new DateTime()).TotalDays / 365; 
        }
        private DateTime birthday;
        public DayOfWeek PreferableDay { get; }
        public GameLevel GameLevel { get; }

        public Child(string firstName, string lastName, 
            GameLevel gameLevel, DayOfWeek preferableDay, DateTime birthday )
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.GameLevel = gameLevel;
            this.PreferableDay = preferableDay;
            this.birthday = birthday;
        }
    }
}
