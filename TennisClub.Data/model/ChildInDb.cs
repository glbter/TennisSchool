using System;
using System.ComponentModel.DataAnnotations;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.Data.model
{
    public class ChildInDb
    {
        [Key]
        public Guid Id { get; }
        [Required]
        public string FirstName { get; }
        [Required]
        public string LastName { get; }
        [Required]
        public Guid GroupId { get; set; }
        [Required]
        public DateTime Birthday { get; }
        [Required]
        public DayOfWeek PreferableDay { get; }
        [Required]
        public GameLevel GameLevel { get; }

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