using Application.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoomBook_OA_UI.Helpers.Extensions
{
    public static class TimeSlotDtoExtensions
    {
        public static TimeSlotDto GetFirstVacant(this IEnumerable<TimeSlotDto> timeSlots, DateTime dtToday)
        {
            return timeSlots.Where(f => f.TimeSlotStart > dtToday).FirstOrDefault(f => f.IsVacant);
        }
    }
}
