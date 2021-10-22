//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using Application.Interfaces;
//using Domain.Entities;
//using Mapster;
//using MediatR;

//namespace Application.Features.RoomFeatures.Commands
//{
//    public class CreateRoomCommand : IRequest<Guid>
//    {
//        public string Name { get; set; }
//        public int Placement { get; set; }
//        public DateTime CreatedUTC { get; set; }

//        public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Guid>
//        {
//            public CreateRoomCommandHandler(IRoomRepository roomRepository)
//            {
//                RoomRepository = roomRepository;
//            }

//            public IRoomRepository RoomRepository { get; }

//            public async Task<Guid> Handle(CreateRoomCommand command, CancellationToken cancellationToken)
//            {
//                var room = command.Adapt<Room>();

//                room.ID = Guid.NewGuid();

//                return await RoomRepository.CreateRoomAsync(room, cancellationToken);

//            }
//        }
//    }
//}