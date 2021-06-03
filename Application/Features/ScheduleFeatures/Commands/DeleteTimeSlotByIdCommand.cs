using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ScheduleFeatures.Commands
{
    public class DeleteTimeSlotByIdCommand : IRequest<Guid>
    {
        public Guid ID { get; set; }
        public class DeleteTimeSlotByIdCommandHandler : IRequestHandler<DeleteTimeSlotByIdCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public DeleteTimeSlotByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(DeleteTimeSlotByIdCommand command, CancellationToken cancellationToken)
            {
                var timeSlot = await _context.TimeSlots.Where(a => a.ID == command.ID).FirstOrDefaultAsync();
                if (timeSlot == null) return default;
                _context.TimeSlots.Remove(timeSlot);
                await _context.SaveChangesAsync();
                return timeSlot.ID;
            }
        }
    }
}