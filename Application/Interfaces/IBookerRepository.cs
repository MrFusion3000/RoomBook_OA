using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.BookerFeatures.Queries;
using Application.Shared.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
public interface IBookerRepository
{
    Task<Guid> CreateBookerAsync(Booker booker, CancellationToken cancellationToken);
    Task<Guid> DeleteBookerAsync(Booker booker, CancellationToken cancellationToken);
    Task<Guid> UpdateBookerAsync(Booker booker, CancellationToken cancellationToken);

    Task<Booker> GetBookerByIdAsync(GetBookerByIdQuery query, CancellationToken cancellationToken);
    Task<List<Booker>> GetAllBookersAsync(GetAllBookersQuery query, CancellationToken cancellationToken);

    //List<BookerDto> BookerById { get; }
}
}