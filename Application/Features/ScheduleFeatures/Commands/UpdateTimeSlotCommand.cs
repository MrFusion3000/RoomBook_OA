using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ScheduleFeatures.Commands
{
    public class UpdateTimeSlotCommand : IRequest<Guid>
    {
        public Guid ID { get; set; }
        public DateTime TimeSlotStart { get; set; }
        public DateTime TimeSlotEnd { get; set; }
        public string Title { get; set; }
        public bool IsVacant { get; set; }
        public int BookerId { get; set; }
        public DateTime CreatedUTC { get; set; }
        public class UpdateTimeSlotCommandHandler : IRequestHandler<UpdateTimeSlotCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public UpdateTimeSlotCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(UpdateTimeSlotCommand command, CancellationToken cancellationToken)
            {
                var timeSlot = _context.TimeSlots.Where(a => a.ID == command.ID).FirstOrDefault();

                if (timeSlot == null)
                {
                    return default;
                }
                else
                {
                    timeSlot.TimeSlotStart = command.TimeSlotStart;
                    timeSlot.TimeSlotEnd = command.TimeSlotEnd;
                    timeSlot.Title = command.Title;
                    timeSlot.BookerId = command.BookerId;
                    await _context.SaveChangesAsync();
                    return timeSlot.ID;
                }
            }
        }
    }
}