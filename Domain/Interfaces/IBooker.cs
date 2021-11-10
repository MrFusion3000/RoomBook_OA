using Domain.Common;
using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces;
interface IBooker : IDataEntitybase
{
    string Name { get; set; }

    List<TimeSlot> TimeSlots { get; }
}