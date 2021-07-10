using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Domain.Common;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class TimeSlot : ITimeSlot
    {
        public Guid ID { get; set; }
        public DateTime TimeSlotStart { get; set; }
        public DateTime TimeSlotEnd { get; set; }
        public string Title { get; set; }
        public bool IsVacant { get; set; }
        public int BookerId { get; set; }
        public DateTime CreatedUTC { get; set; }
        
        public Guid RoomId { get; set; }
        public Room Room { get; set; }

        public static ITimeSlot Create(Guid id, DateTime timeSlotStart, DateTime timeSlotEnd, string title, bool isVacant, int bookerId, DateTime createdUTC, Guid roomId)
        {
            return new TimeSlot()
            {
                ID = id,
                TimeSlotStart = timeSlotStart,
                TimeSlotEnd = timeSlotEnd,
                Title = title,
                IsVacant = isVacant,
                BookerId = bookerId,
                CreatedUTC = createdUTC,
                RoomId = roomId
            };
        }
    }
}
