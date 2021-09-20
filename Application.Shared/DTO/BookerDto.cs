using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Application.Shared.DTO
{
    public class BookerDto
    {
        public BookerDto()
        {
            this.TimeSlots = new List<TimeSlotDto>();
        }

        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedUTC { get; set; }

        //Navigation properties
        public virtual List<TimeSlotDto> TimeSlots { get; private set; }

    }
}
