﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //Could be loop
            TimeSlot timeSlot1 = (TimeSlot)TimeSlot.Create(Guid.NewGuid(), tSlot, tSlot.AddMinutes(14), "SCRUM Daily standup", false, 1, DateTime.Now);
            TimeSlot timeSlot2 = (TimeSlot)TimeSlot.Create(Guid.NewGuid(), tSlot.AddMinutes(15), tSlot.AddMinutes(29), "Planning meeting", false, 1, DateTime.Now);
            TimeSlot timeSlot3 = (TimeSlot)TimeSlot.Create(Guid.NewGuid(), tSlot.AddMinutes(30), tSlot.AddMinutes(44), "Free slot", true, 0, DateTime.Now);
            TimeSlot timeSlot4 = (TimeSlot)TimeSlot.Create(Guid.NewGuid(), tSlot.AddMinutes(45), tSlot.AddMinutes(59), "Free slot", true, 0, DateTime.Now);
            TimeSlot timeSlot5 = (TimeSlot)TimeSlot.Create(Guid.NewGuid(), tSlot.AddMinutes(60), tSlot.AddMinutes(74), "Free slot", true, 0, DateTime.Now);
            TimeSlot timeSlot6 = (TimeSlot)TimeSlot.Create(Guid.NewGuid(), tSlot.AddMinutes(75), tSlot.AddMinutes(89), "Free slot", true, 0, DateTime.Now);

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