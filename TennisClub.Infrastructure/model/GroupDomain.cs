using System;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.Infrastructure.model
{
    public class GroupDomain : IBaseId<Guid>
    {
        public Guid Id { get; }
        public GameLevel GameLevel { get; }
        public DayOfWeek LessonsDay { get; }

        public GroupDomain(GameLevel gameLevel, DayOfWeek lessonsDay, Guid id = new Guid())
        {
            this.Id = (id == Guid.Empty) ? Guid.NewGuid() : id;
            this.GameLevel = gameLevel;
            this.LessonsDay = lessonsDay;
        }
    }
}