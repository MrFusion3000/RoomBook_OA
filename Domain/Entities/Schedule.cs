using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Schedule : ISchedule
    {
        public int ID { get; set; }
        public List<TimeSlot> TimeSlots { get; set; }
        public DateTime CreatedUTC { get; set; }
        Guid IDataEntitybase.ID { get; set; }

        public static Schedule Create(int id)
        {
            return new Schedule()
            {
                ID = id,
                TimeSlots = new()
            };
        }

        public static List<TimeSlot> InitiateSchedule(List<TimeSlot> timeSlots)
        {
            DateTime tSlot = DateTime.Today.AddHours(6);

            return timeSlots;
        }
    }
}
