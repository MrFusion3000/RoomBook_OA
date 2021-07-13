using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Persistance.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Features.BookerFeatures.Commands
{
    public class DeleteBookerByIdCommand : IRequest<Guid>
    {
        public Guid ID { get; set; }
        public class DeleteBookerByIdCommandHandler : IRequestHandler<DeleteBookerByIdCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public DeleteBookerByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(DeleteBookerByIdCommand command, CancellationToken cancellationToken)
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