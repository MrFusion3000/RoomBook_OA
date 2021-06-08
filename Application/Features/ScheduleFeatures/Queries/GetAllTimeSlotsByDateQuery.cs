using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ScheduleFeatures.Queries
{
    public class GetAllTimeSlotsByDateQuery : IRequest<IEnumerable<TimeSlot>>
    {
        public DateTime Today { get; set; }
        public class GetAllTimeSlotsByDateQueryHandler : IRequestHandler<GetAllTimeSlotsByDateQuery, IEnumerable<TimeSlot>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllTimeSlotsByDateQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<TimeSlot>> Handle(GetAllTimeSlotsByDateQuery query, CancellationToken cancellationToken)
            {
                var timeSlotsList = await _context.TimeSlots
                    .Where(t => t.TimeSlotStart.Date == (DateTime.Today))
                    .ToListAsync();

                if (timeSlotsList == null)
                {
                    return null;
                }
                return timeSlotsList.AsReadOnly();
            }
        }
    }
}