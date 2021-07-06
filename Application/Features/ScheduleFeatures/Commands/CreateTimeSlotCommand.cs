﻿using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ScheduleFeatures.Commands
{
    public class CreateTimeSlotCommand : IRequest<Guid>
    {
        public DateTime TimeSlotStart { get; set; }
        public DateTime TimeSlotEnd { get; set; }
        public string Title { get; set; }
        public bool IsVacant { get; set; }
        public int BookerId { get; set; }
        public DateTime CreatedUTC { get; set; }
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
                    TimeSlotStart = command.TimeSlotStart,
                    TimeSlotEnd = command.TimeSlotEnd,
                    Title = command.Title,
                    IsVacant = command.IsVacant,
                    BookerId = command.BookerId,
                    CreatedUTC = command.CreatedUTC
                };
                _context.TimeSlots.Add(timeslot);
                await _context.SaveChangesAsync();
                return timeslot.ID;
            }
        }
    }
}