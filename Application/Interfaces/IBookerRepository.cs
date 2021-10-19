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

    Task<BookerDto> GetBookerByIdAsync(GetBookerByIdQuery query, CancellationToken cancellationToken);
    Task<List<BookerDto>> GetAllBookersAsync(GetAllBookersQuery query, CancellationToken cancellationToken);
}
}