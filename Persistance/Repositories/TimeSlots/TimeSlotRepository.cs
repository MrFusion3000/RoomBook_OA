﻿using Application.Features.TimeslotFeatures.Commands;
using Application.Features.TimeslotFeatures.Queries;
using Application.Interfaces;
using Application.Shared.DTO;
using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistance.Repositories.TimeSlots
{
    internal class TimeSlotRepository : ITimeSlotRepository
    {
        public TimeSlotRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        public async Task<Guid> CreateTimeSlotAsync(TimeSlot timeSlot, CancellationToken cancellationToken)
        {
            Context.TimeSlots.Add(timeSlot);

            await Context.SaveChangesAsync();
            return timeSlot.ID;
        }

        public async Task<Guid> DeleteTimeSlotAsync(DeleteTimeSlotByIdCommand command, CancellationToken cancellationToken)
        {
            var timeSlot = await Context.TimeSlots.Where(a => a.ID == command.ID).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (timeSlot == null) return default;
            Context.TimeSlots.Remove(timeSlot);
            await Context.SaveChangesAsync();
            return timeSlot.ID;
        }

        public async Task<Guid> UpdateTimeSlotAsync(UpdateTimeSlotCommand command, CancellationToken cancellationToken)
        {
            var timeSlot = Context.TimeSlots.FirstOrDefault(a => a.ID == command.ID);

            await Context.SaveChangesAsync();
            return timeSlot.ID;
        }

        public async Task<TimeSlotDto> GetTimeSlotByIdAsync(GetTimeSlotByIdQuery query, CancellationToken cancellationToken)
        {
            // TODO dtToday should be sent in the query as a parameter instead to allow any date
            var dtToday = DateTime.UtcNow;

            // TODO query should extract only necessary fields and data
            var timeSlot = Context.TimeSlots
                .FirstOrDefault(a => a.ID == query.ID);

            if (timeSlot == null) return null;

            var chosenTimeSlot = timeSlot.Adapt<TimeSlotDto>();

            return await Task.FromResult(chosenTimeSlot);
        }

        public async Task<List<TimeSlotDto>> GetAllTimeSlotsAsync(GetAllTimeSlotsQuery query, CancellationToken cancellationToken)
        {
            var TimeSlotsList = await Context.TimeSlots.ToListAsync(cancellationToken: cancellationToken);
            var timeSlotsList = TimeSlotsList.Adapt<List<TimeSlotDto>>();

            if (timeSlotsList == null)
            {
                return null;
            }

            return await Task.FromResult(timeSlotsList);
        }

        public async Task<IEnumerable<TimeSlotDto>> GetAllTimeSlotsByDateAndRoomIdAsync(GetAllTimeSlotsByDateAndRoomIdQuery query, CancellationToken cancellationToken)
        {
            var today = query.Today.Date;
            var thisRoomId = query.ThisRoomId;
            var presentTime = query.Today.TimeOfDay;
            var timeSlotsList = await Context.TimeSlots
                .Where(t => t.TimeSlotStart.Date == today)
                .Where(t => t.TimeSlotStart.TimeOfDay >= presentTime)
                .Where(t => t.RoomId == thisRoomId)
                .ToListAsync(cancellationToken);

            if (timeSlotsList == null)
            {
                return null;
            }

            var timeSlotsListDto = timeSlotsList.Adapt<IEnumerable<TimeSlotDto>>();

            return await Task.FromResult(timeSlotsListDto);
        }

        public async Task<IEnumerable<TimeSlotDto>> GetAllTimeSlotsByDateAsync(GetAllTimeSlotsByDateQuery query, CancellationToken cancellationToken)
        {
            var today = query.Today.Date;
            var thisRoomId = query.ThisRoomId;
            var presentTime = query.Today.TimeOfDay;
            var timeSlotsList = await Context.TimeSlots
                .Where(t => t.TimeSlotStart.Date == today)
                .Where(t => t.TimeSlotStart.TimeOfDay >= presentTime)
                //.Where(t => t.RoomId == thisRoomId)
                .ToListAsync(cancellationToken);

            if (timeSlotsList == null)
            {
                return null;
            }

            var timeSlotsListDto = timeSlotsList.Adapt<IEnumerable<TimeSlotDto>>();

            return await Task.FromResult(timeSlotsListDto);
        }

    }
}
