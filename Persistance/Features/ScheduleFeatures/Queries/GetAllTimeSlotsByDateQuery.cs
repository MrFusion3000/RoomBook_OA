﻿using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Persistance.Interfaces;

namespace Persistance.Features.ScheduleFeatures.Queries
{
    public class GetAllTimeSlotsByDateQuery : IRequest<IEnumerable<TimeSlot>>
    {
        public DateTime Today { get; init; }
        public Guid ThisRoomId { get; init; }
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
                var thisRoomId = query.ThisRoomId;
                var presentTime = query.Today.TimeOfDay;
                var timeSlotsList = await _context.TimeSlots
                    .Where(t => t.TimeSlotStart.Date == today)
                    .Where(t => t.TimeSlotStart.TimeOfDay >= presentTime)
                    //.Where(t => t.RoomId == thisRoomId)
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