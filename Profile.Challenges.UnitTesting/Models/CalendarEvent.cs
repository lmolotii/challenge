using System;

namespace Profile.Challenges.UnitTesting.Models
{
    public class CalendarEvent
    {
        public CalendarEvent(Ulid? id, DateTime date, TimeSpan duration, Ulid? eventId, string? title = null)
        {
            Id = id;
            Title = title;
            Duration = duration;
            Date = date;
            EventId = eventId;
        }
        public Ulid? Id { get; set; }
        public string? Title { get; set; }
        
        public Ulid? EventId { get; set; }
        
        public DateTime Date { get; private set; }
        
        public TimeSpan Duration { get;  private set; }
        
        
        public static CalendarEvent CreateAvailabilitySlot(Ulid? id, DateTime date, TimeSpan duration, Ulid? eventId = null, string? title = null)
        {
            return new CalendarEvent(id, date, duration, eventId, title);
        }
    }
}