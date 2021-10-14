using System;
using System.Collections.Generic;
using Profile.Challenges.UnitTesting.Models;

namespace Profile.Challenges.UnitTesting.Logic
{
    public static class WeekdayExtensions
    {
        public static IReadOnlyCollection<DayOfWeek> ToDaysOfWeek(this Weekday weekday)
        {
            var daysOfWeek = new List<DayOfWeek>();
            
            if (weekday == Weekday.None) 
                return daysOfWeek;
            
            if ((weekday & Weekday.Monday) == Weekday.Monday) 
                daysOfWeek.Add(DayOfWeek.Monday);
            if ((weekday & Weekday.Tuesday) == Weekday.Tuesday) 
                daysOfWeek.Add(DayOfWeek.Tuesday);
            if ((weekday & Weekday.Wednesday) == Weekday.Wednesday) 
                daysOfWeek.Add(DayOfWeek.Wednesday);
            if ((weekday & Weekday.Thursday) == Weekday.Thursday) 
                daysOfWeek.Add(DayOfWeek.Thursday);
            if ((weekday & Weekday.Friday) == Weekday.Friday) 
                daysOfWeek.Add(DayOfWeek.Friday);
            if ((weekday & Weekday.Saturday) == Weekday.Saturday) 
                daysOfWeek.Add(DayOfWeek.Saturday);
            if ((weekday & Weekday.Sunday) == Weekday.Sunday) 
                daysOfWeek.Add(DayOfWeek.Sunday);

            return daysOfWeek;
        }
    }
}