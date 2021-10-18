using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Interfaces;
using Persistance.Context;
using Application.Features.BookerFeatures.Queries;
using Application.Shared.DTO;
using Mapster;

namespace Persistance.Repositories.Bookers
{
    public class BookerRepository : IBookerRepository
    {
        private readonly ApplicationDbContext Context;

        public BookerRepository(ApplicationDbContext context)
        {
            Context = context;
        }
        
        public async Task<Guid> CreateBookerAsync(Booker booker, CancellationToken cancellationToken)
        {
            Context.Bookers.Add(booker);
            await Context.SaveChangesAsync();
            return booker.ID;
        }

        public async Task<Guid> DeleteBookerAsync(Booker booker, CancellationToken cancellationToken)
        {
            booker = await Context.Bookers.Where(a => a.ID == booker.ID).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (booker == null) return default;
            Context.Bookers.Remove(booker);

            await Context.SaveChangesAsync();

            return booker.ID;
        }

        public async Task<Guid> UpdateBookerAsync(Booker booker, CancellationToken cancellationToken)
        {
            booker = await Context.Bookers.Where(a => a.ID == booker.ID).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (booker == null) return default;
            Context.Bookers.Update(booker);

            await Context.SaveChangesAsync();

            return booker.ID;
        }

        public async Task<BookerDto> GetBookerByIdAsync(GetBookerByIdQuery query, CancellationToken cancellationToken)
        {
            var booker = Context.Bookers
                    //.Include(a => a.TimeSlots.Where(t => t.TimeSlotStart > dtToday))
                    .FirstOrDefault(a => a.ID == query.Id);

            if (booker == null) return default;

            var bookerDto = booker.Adapt<BookerDto>();               

            return await Task.FromResult(bookerDto);
        }

        public async Task<List<BookerDto>> GetAllBookersAsync(GetAllBookersQuery query, CancellationToken cancellationToken)
        {
            var BookerList = await Context.Bookers.ToListAsync(cancellationToken: cancellationToken);
            var bookerList = BookerList.Adapt<List<BookerDto>>();

            if (BookerList == null)
            {
                return null;
            }

            return await Task.FromResult(bookerList);
        }
    }
}