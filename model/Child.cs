using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.model
{
    public class Child : Base
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Group Group { get; set; }
        private Guid _groupId;
        public int Age 
        {
            get => (int) _birthday.Subtract(new DateTime()).TotalDays / 365; 
        }
        private DateTime _birthday;
        public List<DayOfWeek> PreferableDays { get; private set; }
        public GameLevel GameLevel { get; private set; }


        public Child(string firstName, string lastName, 
            GameLevel gameLevel, List<DayOfWeek> preferableDays, DateTime birthday )
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.GameLevel = gameLevel;
            this.PreferableDays = preferableDays;
            this._birthday = birthday;
        }
    }
}
