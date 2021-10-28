using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.TimeslotFeatures.Commands;
using Application.Features.TimeslotFeatures.Queries;
using Application.Shared.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITimeSlotRepository
    {
        Task<Guid> CreateTimeSlotAsync(TimeSlot timeSlot, CancellationToken cancellationToken);
        Task<Guid> DeleteTimeSlotAsync(TimeSlot timeSlot, CancellationToken cancellationToken);
        Task<Guid> UpdateTimeSlotAsync(TimeSlotDto timeSlotDto, CancellationToken cancellationToken);

        Task<TimeSlotDto> GetTimeSlotByIdAsync(GetTimeSlotByIdQuery query, CancellationToken cancellationToken);
        Task<List<TimeSlotDto>> GetAllTimeSlotsAsync(GetAllTimeSlotsQuery query, CancellationToken cancellationToken);

        //Obsolete as GetAllTimeSlots can be modified to take TodayDateTime and RoomId = none(all) or given(specified)
        Task<IEnumerable<TimeSlotDto>> GetAllTimeSlotsByDateAndRoomIdAsync(GetAllTimeSlotsByDateAndRoomIdQuery query, CancellationToken cancellationToken);
        Task<IEnumerable<TimeSlotDto>> GetAllTimeSlotsByDateAsync(GetAllTimeSlotsByDateQuery query, CancellationToken cancellationToken);

    }
}