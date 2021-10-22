//using System;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using MediatR;
//using Application.Interfaces;
//using Mapster;
//using Domain.Entities;

//namespace Application.Features.RoomFeatures.Commands
//{
//    public class UpdateRoomCommand : IRequest<Guid>
//    {
//        public Guid ID { get; set; }
//        public string Name { get; set; }
//        public int Placement { get; set; }
//        public DateTime CreatedUTC { get; set; }

//        public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, Guid>
//        {
//            public UpdateRoomCommandHandler(IRoomRepository roomRepository)
//            {
//                RoomRepository = roomRepository;
//            }

//            public IRoomRepository RoomRepository { get; }

//            public async Task<Guid> Handle(UpdateRoomCommand command, CancellationToken cancellationToken)
//            {
//                //var room = command.Adapt<Room>();
//                //var room = _context.Rooms.FirstOrDefault(a => a.ID == command.ID);

//                var room = command.Adapt<Room>();

//                if (room == null)
//                {
//                    return default;
//                }
//                else
//                {
//                    //room.Name = command.Name;
//                    //room.Placement = command.Placement;
//                    //room.CreatedUTC = command.CreatedUTC;

//                    //await _context.SaveChangesAsync();
//                    //return await room.ID;
//                    return await RoomRepository.UpdateRoomAsync(room, cancellationToken);

//                }
//            }
//        }
//    }
//}