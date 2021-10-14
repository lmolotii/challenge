using System;
using System.Collections.Generic;
using System.Linq;
using Profile.Challenges.UnitTesting.Logic;

namespace Profile.Challenges.UnitTesting.Models
{
 public sealed class Recurrence
    {
        public Recurrence()
        {
        }
        
        public Recurrence(DateTime startDate, TimeSpan duration)
        {
            StartDate = startDate;
            Duration = duration;
            EndDate = StartDate.Add(duration);
        }
        
        public Recurrence(int interval, Weekday daysOfWeek, DateTime startDate, DateTime? endDate, TimeSpan duration) 
            : this(startDate, duration)
        {
            Interval = interval;
            DaysOfWeek = daysOfWeek;
            EndDate = endDate?.Date ?? endDate;
        }

        public int Interval { get; }
        
        public Weekday DaysOfWeek { get; }

        public DateTime StartDate { get; }
        
        public DateTime? EndDate { get; }

        public TimeSpan Duration { get; }

        public IEnumerable<CalendarEvent> GenerateCalendarEvents(Ulid availabilitySlotId, DateTime rangeStart, DateTime rangeEnd)
        {
            var events = new List<CalendarEvent>();
            DateTime currentDate = StartDate;

            var applicableDays = DaysOfWeek.ToDaysOfWeek();
            int currentWeek = 0;
            if (EndDate == null || EndDate == default(DateTime))
                return new List<CalendarEvent>();
            
            while (currentDate <= EndDate)
            {
                if (currentWeek % Interval == 0 && applicableDays.Contains(currentDate.DayOfWeek) && currentDate >= rangeStart && currentDate <= rangeEnd)
                    events.Add(CalendarEvent.CreateAvailabilitySlot(null, currentDate, Duration, availabilitySlotId));
                    
                currentDate = currentDate.AddDays(1);

                if (currentDate.DayOfWeek == DayOfWeek.Sunday)
                    currentWeek++;
            }

            return events;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            var other = (Recurrence)obj;
            
            return DaysOfWeek == other.DaysOfWeek &&
                   Interval == other.Interval &&
                   EndDate == other.EndDate &&
                   StartDate == other.StartDate &&
                   Duration == other.Duration;
        }

        public override int GetHashCode()
        {
            return 235428945 ^ DaysOfWeek.GetHashCode() + 
                   Interval.GetHashCode() + 
                   EndDate.GetHashCode() +
                   StartDate.GetHashCode() +
                   Duration.GetHashCode();
        }
    }
}