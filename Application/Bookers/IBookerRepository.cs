using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Bookers
{
    public interface IBookerRepository
    {
         Task<Guid> CreateBookerAsync(Booker booker, CancellationToken cancellationToken);
    }
}