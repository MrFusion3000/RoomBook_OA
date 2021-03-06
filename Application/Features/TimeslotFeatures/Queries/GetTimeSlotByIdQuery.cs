using Application.Interfaces;
using Application.Shared.DTO;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TimeslotFeatures.Queries;
public class GetTimeSlotByIdQuery : IRequest<TimeSlotDto>
{
    public Guid ID { get; set; }
    public class GetTimeSlotByIdQueryHandler : IRequestHandler<GetTimeSlotByIdQuery, TimeSlotDto>
    {
        public GetTimeSlotByIdQueryHandler(ITimeSlotRepository timeSlotRepository)
        {
            TimeSlotRepository = timeSlotRepository;
        }

        public ITimeSlotRepository TimeSlotRepository { get; }

        public async Task<TimeSlotDto> Handle(GetTimeSlotByIdQuery query, CancellationToken cancellationToken)
        {
            //var timeSlot = Context.TimeSlots.FirstOrDefault(a => a.ID == query.ID);
            //if (timeSlot == null) return null;
            //return await Task.FromResult(timeSlot);

            return await TimeSlotRepository.GetTimeSlotByIdAsync(query, cancellationToken);
        }
    }
}