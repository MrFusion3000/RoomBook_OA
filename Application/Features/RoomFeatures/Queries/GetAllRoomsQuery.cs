//using Domain.Entities;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using Application.Interfaces;
//using Application.Shared.DTO;

//namespace Application.Features.RoomFeatures.Queries
//{
//    public class GetAllRoomsQuery : IRequest<IEnumerable<RoomDto>>
//    {

//        public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, IEnumerable<RoomDto>>
//        {
//            public GetAllRoomsQueryHandler(IRoomRepository roomRepository)
//            {
//                RoomRepository = roomRepository;
//            }

//            public IRoomRepository RoomRepository { get; }

//            public async Task<IEnumerable<RoomDto>> Handle(GetAllRoomsQuery query, CancellationToken cancellationToken)
//            {
//                //var roomList = await _context.Rooms.ToListAsync(cancellationToken: cancellationToken);
//                //if (roomList == null)
//                //{
//                //    return null;
//                //}
//                //return roomList.AsReadOnly();

//                return await RoomRepository.GetAllRoomsAsync(query, cancellationToken);

//            }
//        }
//    }
//}