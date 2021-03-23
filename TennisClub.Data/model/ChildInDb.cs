using System;
using TennisClub.AppCore.model.impl;

namespace TennisClub.Data.model
{
    public class ChildInDb
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid GroupId { get; set; }
        public DateTime Birthday { get; set; }
        public DayOfWeek PreferableDay { get; set; }
        public GameLevel GameLevel { get; set; }

        public ChildInDb(string firstName, string lastName, 
            GameLevel gameLevel, DayOfWeek preferableDay, DateTime birthday, Guid groupId, Guid id)
        {
            this.Id = (id == Guid.Empty) ? Guid.NewGuid() : id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.GameLevel = gameLevel;
            this.PreferableDay = preferableDay;
            this.Birthday = birthday;
            this.GroupId = groupId;
        }
        
        public ChildInDb(){}
    }
}