using System;
using System.Collections.Generic;

namespace Application.Shared.DTO
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        //public int AnyVacantSlot { get; set; }
        //public TimeSlot FirstVacantTimeSlot { get; set; }

        //Navigation properties
        public List<TimeSlotDto> TimeSlots { get; set; }
        //public BookerDto Booker { get; set; }

    }
}