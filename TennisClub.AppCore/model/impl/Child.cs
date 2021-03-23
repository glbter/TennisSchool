using System;
using System.Security.Cryptography.X509Certificates;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.AppCore.model.impl
{
    public class Child : IBaseId<Guid>
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public Guid GroupId { get; set; }
        public int Age => DateTime.Today.Subtract(Birthday).Days / 365;

        public DateTime Birthday { get; }
        public DayOfWeek PreferableDay { get; }
        public GameLevel GameLevel { get; }

        public Child(string firstName, string lastName, 
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
