using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces;
public interface IRoom //: IDataEntitybase
{
    string Name { get; set; }
    int Placement { get; set; }

    List<TimeSlot> TimeSlots { get; set; }

    static readonly IRoom Create;
}