using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using Application.Interfaces;
using Application.Features.RoomFeatures.Queries;
using Application.Shared.DTO;
using Domain.Entities;
using Mapster;

namespace Persistance.Repositories.Rooms
{
    internal class RoomRepository : IRoomRepository
    {
        public RoomRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        public async Task<Guid> CreateRoomAsync(Room room, CancellationToken cancellationToken)
        {
            Context.Rooms.Add(room);
            await Context.SaveChangesAsync();
            return room.ID;
        }

        public async Task<Guid> DeleteRoomAsync(Room room, CancellationToken cancellationToken)
        {
            room = await Context.Rooms.Where(a => a.ID == room.ID).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (room == null) return default;
            Context.Rooms.Remove(room);
            return room.ID;
        }

        public async Task<Guid> UpdateRoomAsync(Room room, CancellationToken cancellationToken)
        {
            room = Context.Rooms.FirstOrDefault(a => a.ID == room.ID);

            await Context.SaveChangesAsync();
            return room.ID;
        }

        public async Task<RoomDto> GetRoomByIdAsync(GetRoomByIdQuery query, CancellationToken cancellationToken)
        {
            //var room = Context.Rooms
            //    .FirstOrDefault(a => a.ID == query.Id);

            //var roomDto = room.Adapt<RoomDto>();

            //return await Task.FromResult(roomDto);

            // TODO dtToday should be sent in the query as a parameter instead to allow any date
            var dtToday = DateTime.UtcNow;

            // TODO query should extract only necessary fields and data
            var room = Context.Rooms
                .Include(a => a.TimeSlots
                    .Where(t => t.TimeSlotStart > dtToday))
                .ThenInclude(t => t.Booker)
                .FirstOrDefault(a => a.ID == query.Id);

            if (room == null) return null;

            var chosenRoom = room.Adapt<Room, RoomDto>();

            return await Task.FromResult(chosenRoom);
        }

        public async Task<List<RoomDto>> GetAllRoomsAsync(GetAllRoomsQuery query, CancellationToken cancellationToken)
        {
            var RoomList = await Context.Rooms.ToListAsync(cancellationToken: cancellationToken);
            var roomList = RoomList.Adapt<List<RoomDto>>();
            //if (roomList == null)
            //{
            //    return null;
            //}
            //return roomList.AsReadOnly();

            return await Task.FromResult(roomList);
        }

        public async Task<RoomDto> GetRoomByIdAndTimeSlotsBySpecDateTime(GetRoomByIdAndTimeslotsBySpecDateTimeQuery query, CancellationToken cancellationToken)
        {
            //dtToday is sent in the query as a parameter to allow any date
            var dtToday = query.QueryDateTime;

            var room = Context.Rooms
                .Include(a => a.TimeSlots
                    .Where(t => t.TimeSlotStart > dtToday))
                .ThenInclude(t => t.Booker)
                .FirstOrDefault(a => a.ID == query.Id);

            if (room == null) return null;

            var chosenRoom = room.Adapt<Room, RoomDto>();

            return await Task.FromResult(chosenRoom);
        }
    }
}
