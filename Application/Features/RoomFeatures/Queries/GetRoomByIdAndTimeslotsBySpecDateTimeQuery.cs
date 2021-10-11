using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Mapster;
using Application.Interfaces;
using Application.Shared.DTO;
using Domain.Entities;


namespace Application.Features.RoomFeatures.Queries
{
    public class GetRoomByIdAndTimeslotsBySpecDateTimeQuery : IRequest<RoomDto>
    {
        public Guid Id { get; init; }
        public DateTime QueryDateTime { get; set; }
        public class GetRoomByIdAndTimeslotsBySpecDateTimeQueryHandler : IRequestHandler<GetRoomByIdAndTimeslotsBySpecDateTimeQuery, RoomDto>
        {
            private readonly IApplicationDbContext _context;
            public GetRoomByIdAndTimeslotsBySpecDateTimeQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<RoomDto> Handle(GetRoomByIdAndTimeslotsBySpecDateTimeQuery query, CancellationToken cancellationToken)
            {
                // TODO dtToday should be sent in the query as a parameter instead to allow any date
                var dtToday = query.QueryDateTime;


                // försök 1
                var room = _context.Rooms
                    .Include(a => a.TimeSlots
                        .Where(t => t.TimeSlotStart > dtToday))
                    // TODO how to include Booker?
                    .ThenInclude(t => t.Booker)
                    //.AsNoTracking()
                    .FirstOrDefault(a => a.ID == query.Id);

                //försök 2
                //var room = this._context.Rooms.AsQueryable();
                //room = _context.Rooms.Include(p => p.TimeSlots.Select(c => c.Booker));


                if (room == null) return null;

                MapsterMapster.MapsterSetter();

                var chosenRoom = room.Adapt<Room, RoomDto>();

                return await Task.FromResult(chosenRoom);
            }
        }
    }
}