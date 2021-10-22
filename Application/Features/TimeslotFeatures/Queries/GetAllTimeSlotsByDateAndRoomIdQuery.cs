//using Domain.Entities;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using Application.Interfaces;
//using Application.Shared.DTO;

//namespace Application.Features.TimeslotFeatures.Queries
//{
//    public class GetAllTimeSlotsByDateAndRoomIdQuery : IRequest<IEnumerable<TimeSlotDto>>
//    {
//        public DateTime Today { get; init; }
//        public Guid ThisRoomId { get; init; }
//        //public DateTime PresentTime { get; set; } = DateTime.Now;

//        public class GetAllTimeSlotsByDateAndRoomIdQueryHandler : IRequestHandler<GetAllTimeSlotsByDateAndRoomIdQuery, IEnumerable<TimeSlotDto>>
//        {
//            public GetAllTimeSlotsByDateAndRoomIdQueryHandler(ITimeSlotRepository timeSlotRepository)
//            {
//                TimeSlotRepository = timeSlotRepository;
//            }

//            public ITimeSlotRepository TimeSlotRepository { get; }

//            public async Task<IEnumerable<TimeSlotDto>> Handle(GetAllTimeSlotsByDateAndRoomIdQuery query, CancellationToken cancellationToken)
//            {
//                //var today = query.Today.Date;
//                //var thisRoomId = query.ThisRoomId;
//                //var presentTime = query.Today.TimeOfDay;
//                //var timeSlotsList = await _context.TimeSlots
//                //    .Where(t => t.TimeSlotStart.Date == today)
//                //    .Where(t => t.TimeSlotStart.TimeOfDay >= presentTime)
//                //    .Where(t => t.RoomId == thisRoomId)
//                //    .ToListAsync(cancellationToken);

//                //if (timeSlotsList == null)
//                //{
//                //    return null;
//                //}
//                //return timeSlotsList.AsReadOnly();

//                return await TimeSlotRepository.GetAllTimeSlotsByDateAndRoomIdAsync(query, cancellationToken);

//            }
//        }
//    }
//}