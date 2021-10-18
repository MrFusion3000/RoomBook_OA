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

        public async Task<Guid> DeleteTimeSlotAsync(TimeSlot timeSlot, CancellationToken cancellationToken)
        {
            Context.TimeSlots.Remove(timeSlot);
            await Context.SaveChangesAsync();
            return timeSlot.ID;
        }

        public async Task<Guid> UpdateTimeSlotAsync(TimeSlot timeSlot, CancellationToken cancellationToken)
        {
            timeSlot = Context.TimeSlots.FirstOrDefault(a => a.ID == timeSlot.ID);

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
    }
}
