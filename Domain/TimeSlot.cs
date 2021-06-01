﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomBook.Domain
{
    public class TimeSlot : ITimeSlot
    {
        Guid ID { get; set; }
        public DateTime TimeSlotStart { get; set; }
        public DateTime TimeSlotEnd { get; set; }
        public string Title { get; set; }
        public bool IsVacant { get; set; }
        public int BookerId { get; set; }
        public DateTime CreatedUTC { get; set; }
        Guid IDataEntitybase.ID { get; set; }

        public static ITimeSlot Create(Guid id, DateTime timeSlotStart, DateTime timeSlotEnd, string title, bool isVacant, int bookerId)
        {
            return new TimeSlot()
            {
                ID = id,
                TimeSlotStart = timeSlotStart,
                TimeSlotEnd = timeSlotEnd,
                Title = title,
                IsVacant = isVacant,
                BookerId = bookerId
            };
        }
    }
}
