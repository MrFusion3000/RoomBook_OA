using Application.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoomBook_OA_UI.Helpers.Extensions;

public static class TimeSlotDtoExtensions
{
    /// <summary>
    /// Get the first free timeslot of the day
    /// </summary>
    /// <param name="timeSlots"></param>
    /// <param name="dtToday"></param>
    /// <returns></returns>
    public static TimeSlotDto GetFirstVacant(this IEnumerable<TimeSlotDto> timeSlots, DateTime dtToday)
    {
        return timeSlots.Where(f => f.TimeSlotStart > dtToday).FirstOrDefault(f => f.IsVacant);
    }

    public static List<TimeSlotDto> GetAllCurrentTimeSlots(this IEnumerable<TimeSlotDto> timeSlots, DateTime dtToday)
    {
        return timeSlots.Where(f => f.TimeSlotStart > dtToday).ToList();
    }
}