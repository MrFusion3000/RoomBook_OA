using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ScheduleFeatures.Queries
{
    public class GetTimeSlotByIdQuery : IRequest<TimeSlot>
    {
        public Guid ID { get; set; }
        public class GetTimeSlotByIdQueryHandler : IRequestHandler<GetTimeSlotByIdQuery, TimeSlot>
        {
            private readonly IApplicationDbContext _context;
            public GetTimeSlotByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<TimeSlot> Handle(GetTimeSlotByIdQuery query, CancellationToken cancellationToken)
            {
                var timeSlot = _context.TimeSlots.Where(a => a.ID == query.ID).FirstOrDefault();
                if (timeSlot == null) return null;
                return timeSlot;
            }
        }
    }
}