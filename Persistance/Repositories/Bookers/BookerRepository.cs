using Application.Features.BookerFeatures.Queries;
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

namespace Persistance.Repositories.Bookers;
public class BookerRepository : IBookerRepository
{
    private ApplicationDbContext Context;

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

    public async Task<Guid> UpdateBookerAsync(BookerDtoIn bookerDtoIn, CancellationToken cancellationToken)
    {
        //var bookerToUpdate = await Context.Bookers.Where(a => a.ID == booker.ID).FirstOrDefaultAsync(cancellationToken: cancellationToken);            
        //if (bookerToUpdate == null) return default;

        var booker = bookerDtoIn.Adapt<Booker>();

        // No check if ID exists in db(saves a roundtrip to db), and if not a new 'unwanted' booker is created
        Context.Bookers.Update(booker);

        await Context.SaveChangesAsync();

        return bookerDtoIn.ID;
    }

    public async Task<BookerDtoIn> GetBookerByIdAsync(GetBookerByIdQuery query, CancellationToken cancellationToken)
    {
        var booker = Context.Bookers
        //.Include(a => a.TimeSlots.Where(t => t.TimeSlotStart > dtToday))
        .FirstOrDefault(a => a.ID == query.Id);

        if (booker == null) return default;

        var bookerDto = booker.Adapt<BookerDtoIn>();

        return await Task.FromResult(bookerDto);
    }

    public async Task<List<BookerDtoIn>> GetAllBookersAsync(GetAllBookersQuery query, CancellationToken cancellationToken)
    {
        var bookerList = await Context.Bookers.ToListAsync(cancellationToken: cancellationToken);

        if (bookerList == null) return null;

        var bookerDtoList = bookerList.Adapt<List<BookerDtoIn>>();

        return await Task.FromResult(bookerDtoList);
    }
}