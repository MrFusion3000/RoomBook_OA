using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Shared.DTO;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.BookerFeatures.Queries
{
    public class GetAllBookersQuery : IRequest<IEnumerable<BookerDto>>
    {

        public class GetAllBookersQueryHandler : IRequestHandler<GetAllBookersQuery, IEnumerable<BookerDto>>
        {
            public GetAllBookersQueryHandler(IBookerRepository bookerRepository)
            {
                BookerRepository = bookerRepository;
            }

            public IBookerRepository BookerRepository { get; }

            public async Task<IEnumerable<BookerDto>> Handle(GetAllBookersQuery query, CancellationToken cancellationToken)
            {
                return await BookerRepository.GetAllBookersAsync(query, cancellationToken);

            }
        }
    }
}