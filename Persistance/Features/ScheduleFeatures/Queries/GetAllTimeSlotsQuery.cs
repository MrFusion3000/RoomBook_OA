using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Persistance.Features.ScheduleFeatures.Queries
{
    public class GetAllTimeSlotsQuery : IRequest<IEnumerable<TimeSlot>>
    {

        public class GetAllTimeSlotsQueryHandler : IRequestHandler<GetAllTimeSlotsQuery, IEnumerable<TimeSlot>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllTimeSlotsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<TimeSlot>> Handle(GetAllTimeSlotsQuery query, CancellationToken cancellationToken)
            {
                var timeSlotsList = await _context.TimeSlots.ToListAsync(cancellationToken: cancellationToken);
                if (timeSlotsList == null)
                {
                    return null;
                }
                return timeSlotsList.AsReadOnly();
            }
        }
    }
}