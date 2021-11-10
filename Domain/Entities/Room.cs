using Domain.Common;
using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Domain.Entities;
public class Room : BaseEntity, IRoom //IDataEntitybase,
{
    //[Required]
    public string Name { get; set; }
    public int Placement { get; set; }

    //Navigation properties
    public List<TimeSlot> TimeSlots { get; set; }

    public static IRoom Create(Guid id, string name, DateTime createdUTC, int placement)
    {
        return new Room()
        {
            ID = id,
            Name = name,
            CreatedUTC = createdUTC,
            Placement = placement
        };
    }
}