using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistance.Interfaces;

namespace Persistance.Features.ScheduleFeatures.Commands
{
    public class UpdateTimeSlotCommand : IRequest<Guid>
    {
        public Guid ID { get; set; }
        public DateTime TimeSlotStart { get; set; }
        public DateTime TimeSlotEnd { get; set; }
        public string Title { get; set; }
        public bool IsVacant { get; set; }
        public Guid BookerId { get; set; }
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
                var timeSlot = _context.TimeSlots.FirstOrDefault(a => a.ID == command.ID);

                if (timeSlot == null)
                {
                    return default;
                }
                else
                {
                    timeSlot.TimeSlotStart = command.TimeSlotStart;
                    timeSlot.TimeSlotEnd = command.TimeSlotEnd;
                    timeSlot.Title = command.Title;
                    timeSlot.IsVacant = command.IsVacant;
                    timeSlot.BookerId = command.BookerId;
                    timeSlot.CreatedUTC = command.CreatedUTC;
                    await _context.SaveChangesAsync();
                    return timeSlot.ID;
                }
            }
        }
    }
}