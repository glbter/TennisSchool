using System;
using TennisClub.AppCore.Model.interfaces;

namespace TennisClub.AppCore.Model.impl
{
    public class Group : IBaseId<Guid>
    {
        public Guid Id { get; }
        public GameLevel GameLevel { get; }
        public DayOfWeek LessonsDay { get; set; }
        public int ChildrenAmount { get; set; }

        public Group(GameLevel gameLevel, DayOfWeek lessonsDay, Guid id = new Guid())
        {
            this.Id = (id == Guid.Empty) ? Guid.NewGuid() : id;
            this.GameLevel = gameLevel;
            this.LessonsDay = lessonsDay;
        }
    }
}
