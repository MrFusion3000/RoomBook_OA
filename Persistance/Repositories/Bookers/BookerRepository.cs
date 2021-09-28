using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Interfaces;
using Application.Bookers;


namespace Persistance.Repositories.Bookers
{
    public class BookerRepository : IBookerRepository
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public BookerRepository(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        
        public async Task<Guid> CreateBookerAsync(Booker booker, CancellationToken cancellationToken)
        {
            _applicationDbContext.Bookers.Add(booker);
            await _applicationDbContext.SaveChangesAsync();
            return booker.ID;
        }

        public async Task<Guid> DeleteBookerAsync(Booker booker, CancellationToken cancellationToken)
        {
            booker = await _applicationDbContext.Bookers.Where(a => a.ID == booker.ID).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (booker == null) return default;
            _applicationDbContext.Bookers.Remove(booker);

            await _applicationDbContext.SaveChangesAsync();

            return booker.ID;
        }

        public async Task<Guid> UpdateBookerAsync(Booker booker, CancellationToken cancellationToken)
        {
            booker = await _applicationDbContext.Bookers.Where(a => a.ID == booker.ID).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (booker == null) return default;
            _applicationDbContext.Bookers.Update(booker);

            await _applicationDbContext.SaveChangesAsync();

            return booker.ID;
        }
    }
}