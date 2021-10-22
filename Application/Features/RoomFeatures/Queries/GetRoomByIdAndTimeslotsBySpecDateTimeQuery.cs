//using System;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using MediatR;
//using Mapster;
//using Application.Interfaces;
//using Application.Shared.DTO;
//using Domain.Entities;


//namespace Application.Features.RoomFeatures.Queries
//{
//    public class GetRoomByIdAndTimeslotsBySpecDateTimeQuery : IRequest<RoomDto>
//    {
//        public Guid Id { get; init; }
//        public DateTime QueryDateTime { get; set; }
//        public class GetRoomByIdAndTimeslotsBySpecDateTimeQueryHandler : IRequestHandler<GetRoomByIdAndTimeslotsBySpecDateTimeQuery, RoomDto>
//        {
//            public GetRoomByIdAndTimeslotsBySpecDateTimeQueryHandler(IRoomRepository roomRepository)
//            {
//                RoomRepository = roomRepository;
//            }

//            public IRoomRepository RoomRepository { get; }

//            public async Task<RoomDto> Handle(GetRoomByIdAndTimeslotsBySpecDateTimeQuery query, CancellationToken cancellationToken)
//            {
//                //dtToday is sent in the query as a parameter to allow any date
//                //var dtToday = query.QueryDateTime;

//                //var room = Context.Rooms
//                //    .Include(a => a.TimeSlots
//                //        .Where(t => t.TimeSlotStart > dtToday))
//                //    .ThenInclude(t => t.Booker)
//                //    .FirstOrDefault(a => a.ID == query.Id);

//                //if (room == null) return null;

//                //var chosenRoom = room.Adapt<Room, RoomDto>();

//                //return await Task.FromResult(chosenRoom);
//                return await RoomRepository.GetRoomByIdAndTimeSlotsBySpecDateTime(query, cancellationToken);
//            }
//        }
//    }
//}