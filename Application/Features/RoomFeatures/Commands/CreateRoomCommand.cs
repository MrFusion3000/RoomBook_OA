using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.RoomFeatures.Commands
{
    public class CreateRoomCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public int Placement { get; set; }
        public DateTime CreatedUTC { get; set; }

        public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public CreateRoomCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(CreateRoomCommand command, CancellationToken cancellationToken)
            {
                var room = new Room()
                {
                    Name = command.Name,
                    Placement = command.Placement,
                    CreatedUTC = command.CreatedUTC
                };
                _context.Rooms.Add(room);
                await _context.SaveChangesAsync();
                return room.ID;
            }
        }
    }
}