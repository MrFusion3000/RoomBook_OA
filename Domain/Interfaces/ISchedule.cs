using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces;
public interface ISchedule //: IDataEntitybase
{
    public List<TimeSlot> TimeSlots { get; set; }

    //static readonly ISchedule Create;
}