using System;
using System.ComponentModel.DataAnnotations;
using TennisClub.AppCore.Model.interfaces;

namespace TennisClub.Data.Model
{
    public class ChildChosenDaysEntity : IBaseId<Guid>
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