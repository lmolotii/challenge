using System;

namespace Profile.Challenges.UnitTesting.Models
{
    public class AvailabilitySlotModel
    {
        public AvailabilitySlotModel()
        {
            Location = string.Empty;
            Status = SlotStatus.Default;
            Recurrence = new Recurrence(DateTime.Today, TimeSpan.Zero);
        }
        
        public AvailabilitySlotModel(Ulid id, string? location, Recurrence recurrence, SlotStatus status = SlotStatus.Default , Ulid? recurrentSlotId = null)
        {
            Location = location;
            Recurrence = recurrence;
            RecurrentSlotId = recurrentSlotId;
            Status = status;
        }

        public Ulid Id { get; set; }

        public Ulid? RecurrentSlotId { get; set; }
        
        public SlotStatus Status { get; set; }
        
        public string? Location { get; set; }

        public Recurrence Recurrence { get; set; }
    }
}