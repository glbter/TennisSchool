using System;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.AppCore.model.impl
{
    public class Group : IBaseId<Guid>
    {
        public Guid Id { get; set; }
        public GameLevel GameLevel { get; set; }
        public DayOfWeek LessonsDay { get; set; }

        public Group(GameLevel gameLevel, DayOfWeek lessonsDay, Guid id = new Guid())
        {
            this.Id = (id == Guid.Empty) ? Guid.NewGuid() : id;
            this.GameLevel = gameLevel;
            this.LessonsDay = lessonsDay;
        }
        
        public Group(){ }
    }
}
