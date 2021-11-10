using Domain.Common;
using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Domain.Entities;
public class Schedule : IDataEntitybase, ISchedule
{
    public Guid ID { get; set; }
    public Room Room { get; set; }
    public List<TimeSlot> TimeSlots { get; set; }
    public DateTime CreatedUTC { get; set; }

    public static Schedule Create(Guid id)
    {
        return new Schedule()
        {
            ID = id,
            TimeSlots = new()
        };
    }
}