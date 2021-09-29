using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.TimeslotFeatures.Commands
{
    public class CreateTimeSlotCommand : IRequest<Guid>
    {
        public TimeSlot TimeSlot { get; set; }

        public class CreateTimeSlotCommandHandler : IRequestHandler<CreateTimeSlotCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public CreateTimeSlotCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(CreateTimeSlotCommand command, CancellationToken cancellationToken)
            {
                var timeslot = new TimeSlot
                {
                    TimeSlotStart = command.TimeSlot.TimeSlotStart,
                    TimeSlotEnd = command.TimeSlot.TimeSlotEnd,
                    Title = command.TimeSlot.Title,
                    IsVacant = command.TimeSlot.IsVacant,
                    BookerId = command.TimeSlot.BookerId,
                    CreatedUTC = command.TimeSlot.CreatedUTC,
                    RoomId = command.TimeSlot.RoomId
                };
                _context.TimeSlots.Add(timeslot);
                await _context.SaveChangesAsync();
                return timeslot.ID;
            }
        }
    }
}