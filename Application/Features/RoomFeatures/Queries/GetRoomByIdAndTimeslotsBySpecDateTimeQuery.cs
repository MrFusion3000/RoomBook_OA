using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Application.Features.RoomFeatures.Queries
{
    public class GetRoomByIdAndTimeslotsBySpecDateTimeQuery : IRequest<Room>
    {
        public Guid Id { get; init; }
        public DateTime QueryDateTime { get; set; }
        public class GetRoomByIdAndTimeslotsBySpecDateTimeQueryHandler : IRequestHandler<GetRoomByIdAndTimeslotsBySpecDateTimeQuery, Room>
        {
            private readonly IApplicationDbContext _context;
            public GetRoomByIdAndTimeslotsBySpecDateTimeQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Room> Handle(GetRoomByIdAndTimeslotsBySpecDateTimeQuery query, CancellationToken cancellationToken)
            {
                // TODO dtToday should be sent in the query as a parameter instead to allow any date
                var dtToday = query.QueryDateTime;
                //var room = _context.Rooms
                //    .Include(a => a.TimeSlots.Where(t => t.TimeSlotStart > dtToday))
                //    .FirstOrDefault(a => a.ID == query.Id);

                // försök 1
                var room = _context.Rooms
                    .Include(a => a.TimeSlots)
                        //.Where(t => t.TimeSlotStart > dtToday))
                    // TODO how to include Booker?
                    //.ThenInclude(t => t.Booker)
                    //.AsNoTracking()
                    .FirstOrDefault(a => a.ID == query.Id);

                //försök 2
                //var room = this._context.Rooms.AsQueryable();
                //room = _context.Rooms.Include(p => p.TimeSlots.Select(c => c.Booker));


                if (room == null) return null;

                return await Task.FromResult(room);
            }
        }
    }

    //Parent parent = _context.Parent.Include(p => p.Children.Grandchild).FirstOrDefault();

}