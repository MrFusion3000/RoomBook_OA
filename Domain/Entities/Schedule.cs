using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Interfaces;

namespace Domain.Entities
{
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
}
