﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.model
{
    public class Child : IBaseId
    {
        public Guid Id { get; } = new Guid();
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Guid GroupId { get; set; }
        public int Age 
        {
            get => (int) birthday.Subtract(new DateTime()).TotalDays / 365; 
        }
        private DateTime birthday;
        public DayOfWeek PreferableDay { get; private set; }
        public GameLevel GameLevel { get; private set; }

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