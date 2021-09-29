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
            private readonly IApplicationDbContext _context;
            public DeleteRoomByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(DeleteRoomByIdCommand command, CancellationToken cancellationToken)
            {
                var timeSlot = await _context.TimeSlots.Where(a => a.ID == command.ID).FirstOrDefaultAsync(cancellationToken: cancellationToken);
                if (timeSlot == null) return default;
                _context.TimeSlots.Remove(timeSlot);
                await _context.SaveChangesAsync();
                return timeSlot.ID;
            }
        }
    }
}