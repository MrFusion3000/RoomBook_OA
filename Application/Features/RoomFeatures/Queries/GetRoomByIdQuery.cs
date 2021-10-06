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
    public class GetRoomByIdQuery : IRequest<RoomDto>
    {
        public Guid Id { get; init; }
        public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, RoomDto>
        {
            private readonly IApplicationDbContext _context;
            public GetRoomByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<RoomDto> Handle(GetRoomByIdQuery query, CancellationToken cancellationToken)
            {
                // TODO dtToday should be sent in the query as a parameter instead to allow any date
                var dtToday = DateTime.UtcNow;

                // försök 1
                var room = _context.Rooms
                    .Include(a => a.TimeSlots)
                        //.Where(t => t.TimeSlotStart > dtToday))
                    // TODO how to include Booker?
                    .ThenInclude(t => t.Booker)
                    //.AsNoTracking()
                    .FirstOrDefault(a => a.ID == query.Id);

                if (room == null) return null;

                
                var chosenRoom = room.Adapt<RoomDto>();


                return await Task.FromResult(chosenRoom);
            }
        }
    }
}