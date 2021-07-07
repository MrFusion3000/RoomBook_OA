using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Persistance.Interfaces;

namespace Application.Features.ScheduleFeatures.Queries
{
    public class GetAllTimeSlotsByDateQuery : IRequest<IEnumerable<TimeSlot>>
    {
        public DateTime Today { get; set; }
        //public DateTime PresentTime { get; set; } = DateTime.Now;

        public class GetAllTimeSlotsByDateQueryHandler : IRequestHandler<GetAllTimeSlotsByDateQuery, IEnumerable<TimeSlot>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllTimeSlotsByDateQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<TimeSlot>> Handle(GetAllTimeSlotsByDateQuery query, CancellationToken cancellationToken)
            {
                var today = query.Today.Date;
                var presentTime = query.Today.TimeOfDay;
                var timeSlotsList = await _context.TimeSlots
                    .Where(t => t.TimeSlotStart.Date == today)
                    .Where(t => t.TimeSlotStart.TimeOfDay >= presentTime)
                    .ToListAsync(cancellationToken);

                if (timeSlotsList == null)
                {
                    return null;
                }
                return timeSlotsList.AsReadOnly();
            }
        }
    }
}