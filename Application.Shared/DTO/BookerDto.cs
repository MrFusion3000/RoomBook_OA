using System;

namespace Application.Shared.DTO;
public class BookerDto
{
    //public BookerDto()
    //{
    //    this.TimeSlots = new List<TimeSlotDto>();
    //}

    public Guid ID { get; set; }
    public string Name { get; set; }
    public DateTime CreatedUTC { get; set; }

    //Navigation properties
    //public List<TimeSlotDto> TimeSlots { get; private set; }

}