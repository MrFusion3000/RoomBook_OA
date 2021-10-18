using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RoomFeatures.Commands
{
    public class DeleteRoomByIdCommand : IRequest<Guid>
    {
        public Guid ID { get; set; }
        public class DeleteRoomByIdCommandHandler : IRequestHandler<DeleteRoomByIdCommand, Guid>
        {
            public DeleteRoomByIdCommandHandler(IRoomRepository roomRepository)
            {
                RoomRepository = roomRepository;
            }

            public IRoomRepository RoomRepository { get; }

            public async Task<Guid> Handle(DeleteRoomByIdCommand command, CancellationToken cancellationToken)
            {
                var room = await _context.Room.Where(a => a.ID == command.ID).FirstOrDefaultAsync(cancellationToken: cancellationToken);
                if (room == null) return default;
                _context.Room.Remove(room);
                await _context.SaveChangesAsync();
                return room.ID;
            }
        }
    }
}