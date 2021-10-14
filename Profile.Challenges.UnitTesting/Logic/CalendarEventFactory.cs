using System;
using System.Collections.Generic;
using System.Linq;
using Profile.Challenges.UnitTesting.Models;

namespace Profile.Challenges.UnitTesting.Logic
{
    public sealed class CalendarEventFactory
    {
        public IEnumerable<CalendarEvent> GenerateEventsFromSlots(IEnumerable<AvailabilitySlotModel> slots, DateTime rangeStart, DateTime rangeEnd)
        {
            var listOfEvents = new List<CalendarEvent>();
            var iteratedSlots = new List<AvailabilitySlotModel>();
            iteratedSlots.AddRange(slots);

            var recurrentSlots = new List<AvailabilitySlotModel>(iteratedSlots);
            foreach (var recurrentSlot in recurrentSlots)
            {
                var excludedSlots = iteratedSlots.Where(t => t.RecurrentSlotId == recurrentSlot.Id && t.Status == SlotStatus.Deleted).ToList();
                var recurrentEvents = recurrentSlot.Recurrence.GenerateCalendarEvents(recurrentSlot.Id, rangeStart, rangeEnd);
                
                foreach (var @event in recurrentEvents)
                {
                    // Find the deleted slot from the sequence.
                    AvailabilitySlotModel? slotToExclude = excludedSlots.FirstOrDefault(t =>
                        t.Recurrence.StartDate.Year == @event.Date.Year &&
                        t.Recurrence.StartDate.Month == @event.Date.Month &&
                        t.Recurrence.StartDate.Day == @event.Date.Day);
                    if (slotToExclude != null)
                    {
                        // If deleted slot is found, we need to exclude it from result sequence.
                        iteratedSlots.Remove(slotToExclude);
                        continue;
                    }
                    
                    listOfEvents.Add(@event);
                }
                
                // recurrent slot is already processed, so no need to have it inside the sequence. 
                iteratedSlots.Remove(recurrentSlot);
            }
            
            for (var i = 0; i < iteratedSlots.Count; i++)
            {
                var slot = iteratedSlots[i];
                if (slot.Status == SlotStatus.Deleted)
                {
                    continue;
                }

                var @event = new CalendarEvent(slot.Id, slot.Recurrence.StartDate, slot.Recurrence.Duration, slot.RecurrentSlotId);
                listOfEvents.Add(@event);
            }

            return listOfEvents;
        }
    }
}