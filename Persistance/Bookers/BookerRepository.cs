using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Bookers;
using Persistance.Interfaces;

namespace Persistance.Bookers
{
    public class BookerRepository
    :IBookerRepository
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public BookerRepository(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        
        public async Task<Guid> CreateBookerAsync(Domain.Entities.Booker booker, CancellationToken cancellationToken)
        {
            _applicationDbContext.Bookers.Add(booker);
            await _applicationDbContext.SaveChangesAsync();
            return booker.ID;
        }
    }
}