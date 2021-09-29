using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IBookerRepository
    {
         Task<Guid> CreateBookerAsync(Booker booker, CancellationToken cancellationToken);
         Task<Guid> DeleteBookerAsync(Booker booker, CancellationToken cancellationToken);
         Task<Guid> UpdateBookerAsync(Booker booker, CancellationToken cancellationToken);

    }
}