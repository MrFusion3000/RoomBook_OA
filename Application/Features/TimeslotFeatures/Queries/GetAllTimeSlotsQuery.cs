using Application.Interfaces;
using Application.Shared.DTO;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TimeslotFeatures.Queries;
public class GetAllTimeSlotsQuery : IRequest<IEnumerable<TimeSlotDto>>
{
    public class GetAllTimeSlotsQueryHandler : IRequestHandler<GetAllTimeSlotsQuery, IEnumerable<TimeSlotDto>>
    {
        public GetAllTimeSlotsQueryHandler(ITimeSlotRepository timeSlotRepository)
        {
            TimeSlotRepository = timeSlotRepository;
        }

        public ITimeSlotRepository TimeSlotRepository { get; }

        public async Task<IEnumerable<TimeSlotDto>> Handle(GetAllTimeSlotsQuery query, CancellationToken cancellationToken)
        {
            //var timeSlotsList = await _context.TimeSlots.ToListAsync(cancellationToken: cancellationToken);
            //if (timeSlotsList == null)
            //{
            //    return null;
            //}
            //return timeSlotsList.AsReadOnly();
            return await TimeSlotRepository.GetAllTimeSlotsAsync(query, cancellationToken);
        }
    }
}