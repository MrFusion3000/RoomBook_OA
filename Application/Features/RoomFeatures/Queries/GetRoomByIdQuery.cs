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

                // TODO query should extract only necessary fields and data
                var room = _context.Rooms
                    .Include(a => a.TimeSlots)
                        //.Where(t => t.TimeSlotStart > dtToday))
                    .ThenInclude(t => t.Booker)
                    .FirstOrDefault(a => a.ID == query.Id);

                if (room == null) return null;

                MapsterMapster.MapsterSetter();
            
                var chosenRoom = room.Adapt<Room, RoomDto>();


                return await Task.FromResult(chosenRoom);
            }
        }
    }
}