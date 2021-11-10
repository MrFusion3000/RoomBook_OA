using Application.Interfaces;
using Application.Shared.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TimeslotFeatures.Queries;
public class GetAllTimeSlotsByDateQuery : IRequest<IEnumerable<TimeSlotDto>>
{
    public DateTime Today { get; init; }
    public Guid ThisRoomId { get; init; }
    //public DateTime PresentTime { get; set; } = DateTime.Now;

    public class GetAllTimeSlotsByDateQueryHandler : IRequestHandler<GetAllTimeSlotsByDateQuery, IEnumerable<TimeSlotDto>>
    {
        public GetAllTimeSlotsByDateQueryHandler(ITimeSlotRepository timeSlotRepository)
        {
            TimeSlotRepository = timeSlotRepository;
        }

        public ITimeSlotRepository TimeSlotRepository { get; }

        public async Task<IEnumerable<TimeSlotDto>> Handle(GetAllTimeSlotsByDateQuery query, CancellationToken cancellationToken)
        {
            //var today = query.Today.Date;
            //var thisRoomId = query.ThisRoomId;
            //var presentTime = query.Today.TimeOfDay;
            //var timeSlotsList = await _context.TimeSlots
            //    .Where(t => t.TimeSlotStart.Date == today)
            //    .Where(t => t.TimeSlotStart.TimeOfDay >= presentTime)
            //    //.Where(t => t.RoomId == thisRoomId)
            //    .ToListAsync(cancellationToken);

            //if (timeSlotsList == null)
            //{
            //    return null;
            //}
            //return timeSlotsList.AsReadOnly();
            return await TimeSlotRepository.GetAllTimeSlotsByDateAsync(query, cancellationToken);

        }
    }
}