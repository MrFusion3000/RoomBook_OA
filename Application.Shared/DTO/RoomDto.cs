using System;
using System.Collections.Generic;

namespace Application.Shared.DTO
{
    public class RoomDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Placement { get; set; }
        public DateTime CreatedUTC { get; set; }

        //Navigation properties
        public List<TimeSlotDto> TimeSlots { get; set; }
    }
}