using Application.Features.RoomFeatures.Queries;
using Application.Interfaces;
using Application.Shared.DTO;
using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Persistance.Repositories.Rooms;
internal class RoomRepository : IRoomRepository
{
    public ApplicationDbContext Context;

    public RoomRepository(ApplicationDbContext context)
    {
        Context = context;
    }

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
        //var room = roomDto.Adapt<Room>();
        room = Context.Rooms.FirstOrDefault(a => a.ID == room.ID);
        if (room == null) return default;

        await Context.SaveChangesAsync();
        return room.ID;
    }

    public async Task<RoomDto> GetRoomByIdAsync(GetRoomByIdQuery query, CancellationToken cancellationToken)
    {
        var dtToday = DateTime.UtcNow;

        var room = Context.Rooms
            .FirstOrDefault(a => a.ID == query.Id);

        if (room == null) return null;

        var roomDto = room.Adapt<RoomDto>();

        return await Task.FromResult(roomDto);
    }

    public async Task<List<RoomDto>> GetAllRoomsAsync(GetAllRoomsQuery query, CancellationToken cancellationToken)
    {
        var roomList = await Context.Rooms.ToListAsync(cancellationToken: cancellationToken);

        if (roomList == null) return null;

        var roomDtoList = roomList.Adapt<List<RoomDto>>();

        return await Task.FromResult(roomDtoList);
    }

    public async Task<RoomDto> GetRoomByIdAndTimeSlotsBySpecDateAsync(GetRoomByIdAndTimeslotsBySpecDateQuery query, CancellationToken cancellationToken)
    {
        var room = Context.Rooms
            .Include(a => a.TimeSlots
            .Where(t => t.TimeSlotStart > query.QueryDateTime.Date)
            .OrderBy(a => a.TimeSlotStart))
            .ThenInclude(t => t.Booker)
            .FirstOrDefault(a => a.ID == query.Id);

        if (room == null) return null;

        var roomDto = room.Adapt<RoomDto>();

        return await Task.FromResult(roomDto);
    }

    //public async Task<roomDto> GetRoomByIdAndTimeSlotsBySpecDateTimePeriod(query.id, query.startdate, query.enddate)
}