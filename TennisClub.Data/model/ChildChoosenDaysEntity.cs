using System;

namespace TennisClub.Data.model
{
    public class ChildChosenDaysEntity
    {
        public Guid Id { get; set; }
        public Guid ChildId { get; set; }
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