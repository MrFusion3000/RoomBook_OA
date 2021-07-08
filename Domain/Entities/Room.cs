using System;
using System.Collections.Generic;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Room : IRoom
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedUTC { get; set; }
        public int Placement { get; set; }
        public List<TimeSlot> TimeSlots { get; set; }

        public static IRoom Create(Guid id, string name, DateTime createdUTC, List<TimeSlot> timeSlots, int placement)
        {
            return new Room()
            {
                ID = id,
                Name = name,
                CreatedUTC = createdUTC,
                TimeSlots = timeSlots,
                Placement = placement
            };
        }
    }
}
