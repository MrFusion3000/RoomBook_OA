//using System;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;
//using Application.Features.RoomFeatures.Queries;
//using Application.Shared.DTO;
//using Domain.Entities;

//namespace Application.Interfaces
//{
//    public interface IRoomRepository
//    {
//        Task<Guid> CreateRoomAsync(Room room, CancellationToken cancellationToken);
//        Task<Guid> DeleteRoomAsync(Room room, CancellationToken cancellationToken);
//        Task<Guid> UpdateRoomAsync(Room room, CancellationToken cancellationToken);

//        Task<RoomDto> GetRoomByIdAsync(GetRoomByIdQuery query, CancellationToken cancellationToken);
//        Task<List<RoomDto>> GetAllRoomsAsync(GetAllRoomsQuery query, CancellationToken cancellationToken);
//        Task<RoomDto> GetRoomByIdAndTimeSlotsBySpecDateTime(GetRoomByIdAndTimeslotsBySpecDateTimeQuery query, CancellationToken cancellationToken);

//    }
//}