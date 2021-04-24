using System;
using System.ComponentModel.DataAnnotations;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.Data.model
{
    public class ChildInDb : IBaseId<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Guid GroupId { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public DayOfWeek PreferableDay { get; set; }
        [Required]
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