using System;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.Infrastructure.model
{
    public class ChildDomain : IBaseId<Guid>
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public Guid GroupId { get; set; }
        public int Age => DateTime.Today.Subtract(Birthday).Days / 365;
        public DateTime Birthday { get; }
        public DayOfWeek PreferableDay { get; }
        public GameLevel GameLevel { get; }

        public ChildDomain(string firstName, string lastName, 
            GameLevel gameLevel, DayOfWeek preferableDay, DateTime birthday, Guid id = new Guid())
        {
            this.Id = (id == Guid.Empty) ? Guid.NewGuid() : id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.GameLevel = gameLevel;
            this.PreferableDay = preferableDay;
            this.Birthday = birthday;
        }
    }
}