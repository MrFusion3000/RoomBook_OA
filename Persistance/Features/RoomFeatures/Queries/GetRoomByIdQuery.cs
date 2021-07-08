using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Persistance.Interfaces;

namespace Persistance.Features.RoomFeatures.Queries
{
    public class GetRoomByIdQuery : IRequest<Room>
    {
        public Guid ID { get; set; }
        public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, Room>
        {
            private readonly IApplicationDbContext _context;
            public GetRoomByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Room> Handle(GetRoomByIdQuery query, CancellationToken cancellationToken)
            {
                var Room = _context.Rooms.FirstOrDefault(a => a.ID == query.ID);
                if (Room == null) return null;
                return await Task.FromResult(Room);
            }
        }
    }
}