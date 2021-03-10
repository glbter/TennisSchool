using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.WpfDesktop.model
{
    class Child : IBaseId<int>
    {
        public int Id { get; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public DayOfWeek LessonsDay { get; set; }
        public GameLevel GameLevel { get; set; }
        public Child(int id, string name, string lastName, GameLevel gameLevel, DayOfWeek lessonsDay, DateTime bitrth)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            this.GameLevel = gameLevel;
            this.LessonsDay = lessonsDay;
            this.Birthday = Birthday;
        }
    }
}
