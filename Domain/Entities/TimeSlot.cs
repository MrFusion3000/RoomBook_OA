using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class TimeSlot : BaseEntity, IDataEntitybase, ITimeSlot
    {
        //public Guid ID { get; set; }
        public DateTime TimeSlotStart { get; set; }
        public DateTime TimeSlotEnd { get; set; }
        public string Title { get; set; }
        public bool IsVacant { get; set; }
        //public DateTime CreatedUTC { get; set; }
        public DateTime? UpdatedUTC { get; set; }
        public Guid RoomId { get; set; }

        //Navigation properties
        public Guid BookerId { get; set; }
        public Booker Booker { get; set; }

        public static ITimeSlot Create(Guid id, DateTime timeSlotStart, DateTime timeSlotEnd, string title, bool isVacant, DateTime createdUTC, DateTime? updatedUTC, Guid roomId, Guid bookerId)
        {
            return new TimeSlot()
            {
                ID = id,
                TimeSlotStart = timeSlotStart,
                TimeSlotEnd = timeSlotEnd,
                Title = title,
                IsVacant = isVacant,
                CreatedUTC = createdUTC,
                UpdatedUTC = updatedUTC,
                RoomId = roomId,
                BookerId = bookerId
            };
        }
    }
}
