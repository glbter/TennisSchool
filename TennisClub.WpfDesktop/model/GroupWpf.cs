using System;
using TennisClub.AppCore.model.impl;

namespace TennisClub.WpfDesktop.model
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