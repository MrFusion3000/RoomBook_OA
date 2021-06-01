using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBook.Domain
{
    public class Room : IRoom
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<Schedule> Schedules { get; set; }

        // Floor + Room Number (i.e. Floor 1, Room 1: 101, Floor 2, Room 4: 204)
        public int Placement { get; set; }
        public DateTime CreatedUTC { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
