//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using Application.Interfaces;
//using Domain.Entities;
//using Mapster;
//using MediatR;

//namespace Application.Features.RoomFeatures.Commands
//{
//    public class DeleteRoomByIdCommand : IRequest<Guid>
//    {
//        public Guid ID { get; set; }
//        public class DeleteRoomByIdCommandHandler : IRequestHandler<DeleteRoomByIdCommand, Guid>
//        {
//            public DeleteRoomByIdCommandHandler(IRoomRepository roomRepository)
//            {
//                RoomRepository = roomRepository;
//            }

//            public IRoomRepository RoomRepository { get; }

//            public async Task<Guid> Handle(DeleteRoomByIdCommand command, CancellationToken cancellationToken)
//            {
//                var room = command.Adapt<Room>();

//                //var room = await Context.Room.Where(a => a.ID == command.ID).FirstOrDefaultAsync(cancellationToken: cancellationToken);
//                //if (room == null) return default;
//                //Context.Room.Remove(room);
//                //await Context.SaveChangesAsync();
//                //return room.ID;

//                return await RoomRepository.DeleteRoomAsync(room, cancellationToken);
//            }
//        }
//    }
//}