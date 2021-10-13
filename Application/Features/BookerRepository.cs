using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features
{
    internal class BookerRepository : IBookerRepository
    {
        public Task<Guid> CreateBookerAsync(Booker booker, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> DeleteBookerAsync(Booker booker, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateBookerAsync(Booker booker, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
