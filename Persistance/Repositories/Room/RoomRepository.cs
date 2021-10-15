using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features
{
    internal class RoomRepository : IRoomRepository
    {
        public Task<Guid> CreateRoomAsync(Room room, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> DeleteRoomAsync(Room room, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateRoomAsync(Room room, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
