using System;
using TennisClub.AppCore.Model.impl;
using TennisClub.Data.Model;

namespace TennisClub.Infrastructure.Mappers
{
    public class ToChildDayMapper
    {
        public ChildChosenDaysEntity Map(Child child, DayOfWeek day)
        {
            return new ChildChosenDaysEntity(child.Id, day);
        }
    }
}