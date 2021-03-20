using System;
using System.ComponentModel.DataAnnotations;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.Data.model
{
    public class GroupInDb
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public GameLevel GameLevel { get; set; }
        [Required]
        public DayOfWeek LessonsDay { get; set; }

        public GroupInDb(GameLevel gameLevel, DayOfWeek lessonsDay, Guid id)
        {
            this.Id = id;
            this.GameLevel = gameLevel;
            this.LessonsDay = lessonsDay;
        }

        public GroupInDb() { }
    }
}