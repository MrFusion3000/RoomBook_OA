using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBook.Domain
{
    public class Schedule : ISchedule
    {
        public int ID { get; set; }
        public List<TimeSlot> TimeSlots { get; set; }
        public DateTime CreatedUTC { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        Guid IDataEntitybase.ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

            //Could be loop
            TimeSlot timeSlot1 = (TimeSlot)TimeSlot.Create(1, tSlot, tSlot.AddMinutes(14), "SCRUM Daily standup", false, 1);
            TimeSlot timeSlot2 = (TimeSlot)TimeSlot.Create(2, tSlot.AddMinutes(15), tSlot.AddMinutes(29), "Planning meeting", false, 1);
            TimeSlot timeSlot3 = (TimeSlot)TimeSlot.Create(3, tSlot.AddMinutes(30), tSlot.AddMinutes(44), "Free slot", true, 0);
            TimeSlot timeSlot4 = (TimeSlot)TimeSlot.Create(4, tSlot.AddMinutes(45), tSlot.AddMinutes(59), "Free slot", true, 0);
            TimeSlot timeSlot5 = (TimeSlot)TimeSlot.Create(5, tSlot.AddMinutes(60), tSlot.AddMinutes(74), "Free slot", true, 0);
            TimeSlot timeSlot6 = (TimeSlot)TimeSlot.Create(6, tSlot.AddMinutes(75), tSlot.AddMinutes(89), "Free slot", true, 0);

            timeSlots.Add(timeSlot1);
            timeSlots.Add(timeSlot2);
            timeSlots.Add(timeSlot3);
            timeSlots.Add(timeSlot4);
            timeSlots.Add(timeSlot5);
            timeSlots.Add(timeSlot6);

            return timeSlots;
        }
    }
}
