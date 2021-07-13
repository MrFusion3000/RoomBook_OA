using System;
using System.Collections.Generic;
using Domain.Common;
using Domain.Entities;

namespace Domain.Interfaces
{
    interface IBooker : IDataEntitybase
    {
        string Name { get; set; }

        List<TimeSlot> TimeSlots { get; }

    }
}