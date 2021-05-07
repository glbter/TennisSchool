using System;
using TennisClub.AppCore.Model.impl;

namespace TennisClub.WpfDesktop.Model
{
    public class GroupWpf
    {
        public Guid Id { get; set; }
        public GameLevel GameLevel { get; set; }
        public DayOfWeek LessonsDay { get; set; }

        public GroupWpf(GameLevel gameLevel, DayOfWeek lessonsDay, Guid id = new Guid())
        {
            this.Id = (id == Guid.Empty) ? Guid.NewGuid() : id;
            this.GameLevel = gameLevel;
            this.LessonsDay = lessonsDay;
        }
    }

}