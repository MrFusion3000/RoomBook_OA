using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.TimeslotFeatures.Queries;
using Application.Shared.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITimeSlotRepository
    {
        Task<Guid> CreateTimeSlotAsync(TimeSlot timeSlot, CancellationToken cancellationToken);
        Task<Guid> DeleteTimeSlotAsync(TimeSlot timeSlot, CancellationToken cancellationToken);
        Task<Guid> UpdateTimeSlotAsync(TimeSlot timeSlot, CancellationToken cancellationToken);

        Task<TimeSlotDto> GetTimeSlotByIdAsync(GetTimeSlotByIdQuery query, CancellationToken cancellationToken);
        //GetAllTimeSlots

    }
}