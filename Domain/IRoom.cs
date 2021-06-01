﻿using System;
using System.Collections.Generic;

namespace RoomBook.Domain
{
    public interface IRoom : IDataEntitybase
    {
        string Name { get; set; }
        int Placement { get; set; }
        List<Schedule> Schedules { get; set; }

    }
}