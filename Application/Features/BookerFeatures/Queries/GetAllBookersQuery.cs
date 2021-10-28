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
    public class GetAllBookersQuery : IRequest<List<BookerDtoIn>>
    {

        public class GetAllBookersQueryHandler : IRequestHandler<GetAllBookersQuery, List<BookerDtoIn>>
        {
            public IBookerRepository BookerRepository { get; }

            public GetAllBookersQueryHandler(IBookerRepository bookerRepository)
            {
                BookerRepository = bookerRepository;
            }

            public async Task<List<BookerDtoIn>> Handle(GetAllBookersQuery query, CancellationToken cancellationToken)
            {
                return await BookerRepository.GetAllBookersAsync(query, cancellationToken);

            }
        }
    }
}