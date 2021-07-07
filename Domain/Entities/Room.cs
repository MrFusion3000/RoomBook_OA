using System;
using System.Collections.Generic;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Room : IRoom
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<Schedule> Schedules { get; set; }

        // Floor + Room Number (i.e. Floor 1, Room 1: 101, Floor 2, Room 4: 204)
        public int Placement { get; set; }
        public DateTime CreatedUTC { get; set; }
    }
}
