using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistance.Interfaces;

namespace Persistance.Features.RoomFeatures.Commands
{
    public class UpdateRoomCommand : IRequest<Guid>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Placement { get; set; }
        public DateTime CreatedUTC { get; set; }

        public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public UpdateRoomCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(UpdateRoomCommand command, CancellationToken cancellationToken)
            {
                var room = _context.Rooms.FirstOrDefault(a => a.ID == command.ID);

                if (room == null)
                {
                    return default;
                }
                else
                {
                    room.Name = command.Name;
                    room.Placement = command.Placement;
                    room.CreatedUTC = command.CreatedUTC;

                    await _context.SaveChangesAsync();
                    return room.ID;
                }
            }
        }
    }
}