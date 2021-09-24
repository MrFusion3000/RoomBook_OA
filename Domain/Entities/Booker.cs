using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Booker : IBooker
    {
        public Booker()
        {
            this.TimeSlots = new List<TimeSlot>();
        }

        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedUTC { get; set; }

        //Navigation properties
        public List<TimeSlot> TimeSlots { get; }

        public static Booker Create(string name)
        {
            return new Booker()
            {
                ID = Guid.NewGuid(),
                Name = name,
                CreatedUTC = DateTime.UtcNow
            };
        }
    }
}
