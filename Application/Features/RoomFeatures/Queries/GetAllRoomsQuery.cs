using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Application.Features.RoomFeatures.Queries
{
    public class GetAllRoomsQuery : IRequest<IEnumerable<Room>>
    {

        public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, IEnumerable<Room>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllRoomsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Room>> Handle(GetAllRoomsQuery query, CancellationToken cancellationToken)
            {
                var roomList = await _context.Rooms.ToListAsync(cancellationToken: cancellationToken);
                if (roomList == null)
                {
                    return null;
                }
                return roomList.AsReadOnly();
            }
        }
    }
}