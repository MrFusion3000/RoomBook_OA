using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRoomRepository
    {
         Task<Guid> CreateRoomAsync(Room room, CancellationToken cancellationToken);
         Task<Guid> DeleteRoomAsync(Room room, CancellationToken cancellationToken);
         Task<Guid> UpdateRoomAsync(Room room, CancellationToken cancellationToken);

        //GetRoomById
        //GetAllRooms

    }
}