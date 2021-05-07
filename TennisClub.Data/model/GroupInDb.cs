using System;
using System.ComponentModel.DataAnnotations;
using TennisClub.AppCore.Model.impl;
using TennisClub.AppCore.Model.interfaces;

namespace TennisClub.Data.Model
{
    public class GroupInDb : IBaseId<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public GameLevel GameLevel { get; set; }
        [Required]
        public DayOfWeek LessonsDay { get; set; }
        [Required]
        public int ChildrenAmount { get; set; }

        public GroupInDb(GameLevel gameLevel, DayOfWeek lessonsDay, Guid id)
        {
            this.Id = id;
            this.GameLevel = gameLevel;
            this.LessonsDay = lessonsDay;
            this.ChildrenAmount = 0;
        }

        public GroupInDb() { }
    }
}