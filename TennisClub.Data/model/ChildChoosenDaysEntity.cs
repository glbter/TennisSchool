using System;
using System.ComponentModel.DataAnnotations;

namespace TennisClub.Data.model
{
    public class ChildChosenDaysEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid ChildId { get; set; }
        [Required]
        public DayOfWeek ChosenDay { get; set; }

        public ChildChosenDaysEntity(Guid childId, DayOfWeek chosenDay)
        {
            Id = Guid.NewGuid();
            ChildId = childId;
            ChosenDay = chosenDay;
        }
        
        public ChildChosenDaysEntity() {}
    }
}