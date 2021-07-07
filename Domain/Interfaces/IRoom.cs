using System;
using System.Collections.Generic;
using Domain.Common;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRoom : IDataEntitybase
    {
        string Name { get; set; }
        int Placement { get; set; }
        List<Schedule> Schedules { get; set; }

    }
}