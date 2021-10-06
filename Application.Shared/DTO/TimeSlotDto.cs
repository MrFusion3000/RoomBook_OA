using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.Shared.DTO;

namespace Application.Shared.DTO
{
    public class TimeSlotDto
    {
        public Guid ID { get; set; }
        public DateTime TimeSlotStart { get; set; }
        public DateTime TimeSlotEnd { get; set; }
        public string Title { get; set; }
        public bool IsVacant { get; set; }
        public DateTime CreatedUTC { get; set; }
        public Guid RoomId { get; set; }

        //Navigation properties
        public Guid BookerId { get; set; }
        public BookerDto Booker { get; set; }

    }
}
