using System;

namespace TennisClub.Data.mappers
{
    public class DateToYearsMapper
    {
        public int Map(DateTime date)
        {
            return DateTime.Today.Subtract(date).Days / 365;
        }
    }
}