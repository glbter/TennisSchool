using System;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.AppCore.model.impl
{
    public class Group : IBaseId<Guid>
    {
        public Guid Id { get; }
        public GameLevel GameLevel { get; }
        public DayOfWeek LessonsDay { get; }

        public Group(GameLevel gameLevel, DayOfWeek lessonsDay, Guid id = new Guid())
        {
            this.Id = (id == Guid.Empty) ? Guid.NewGuid() : id;
            this.GameLevel = gameLevel;
            this.LessonsDay = lessonsDay;
        }
    }
}
