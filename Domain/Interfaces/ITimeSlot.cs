using System;

namespace Domain.Interfaces;
public interface ITimeSlot
{
    public DateTime TimeSlotStart { get; set; }
    public DateTime TimeSlotEnd { get; set; }
    public string Title { get; set; }
    public bool IsVacant { get; set; }
    public Guid BookerId { get; set; }
    public Guid RoomId { get; set; }

    static readonly ITimeSlot Create;
}