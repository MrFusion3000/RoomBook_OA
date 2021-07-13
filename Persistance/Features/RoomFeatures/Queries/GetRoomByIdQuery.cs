using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Persistance.Interfaces;

namespace Persistance.Features.RoomFeatures.Queries
{
    public class GetRoomByIdQuery : IRequest<Room>
    {
        public Guid Id { get; init; }
        public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, Room>
        {
            private readonly IApplicationDbContext _context;
            public GetRoomByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Room> Handle(GetRoomByIdQuery query, CancellationToken cancellationToken)
            {
                var dtToday = DateTime.UtcNow;
                //var room = _context.Rooms
                //    .Include(a => a.TimeSlots.Where(t => t.TimeSlotStart > dtToday))
                //    .FirstOrDefault(a => a.ID == query.Id);
                var room = _context.Rooms
                    .Include(a => a.TimeSlots
                        .Where(t => t.TimeSlotStart > dtToday))
                    //.Include(b => b.)
                    .FirstOrDefault(a => a.ID == query.Id);


                if (room == null) return null;

                return await Task.FromResult(room);
            }
        }
    }

    //Parent parent = _context.Parent.Include(p => p.Children.Grandchild).FirstOrDefault();

}