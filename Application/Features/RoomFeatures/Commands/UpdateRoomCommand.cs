using Application.Interfaces;
using Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RoomFeatures.Commands;

public class UpdateRoomCommand : IRequest<Guid>
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public int Placement { get; set; }
    public DateTime CreatedUTC { get; set; }

    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, Guid>
    {
        public UpdateRoomCommandHandler(IRoomRepository roomRepository)
        {
            RoomRepository = roomRepository;
        }

        public IRoomRepository RoomRepository { get; }

        public async Task<Guid> Handle(UpdateRoomCommand command, CancellationToken cancellationToken)
        {
            //NOTE: Could be vital to check existance and Vacant if another user books the timeslot just before you
            //var room = command.Adapt<Room>();
            //var room = _context.Rooms.FirstOrDefault(a => a.ID == command.ID);

            var room = command.Adapt<Room>();

            if (room == null) return default;

            return await RoomRepository.UpdateRoomAsync(room, cancellationToken);

        }
    }
}