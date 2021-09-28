using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Bookers;

namespace Persistance.Features.BookerFeatures.Queries
{
    public class GetAllBookersQuery : IRequest<IEnumerable<Booker>>
    {

        public class GetAllBookersQueryHandler : IRequestHandler<GetAllBookersQuery, IEnumerable<Booker>>
        {
            private readonly IBookerRepository _bookerRepository;
            public GetAllBookersQueryHandler(IBookerRepository bookerRepository)
            {
                _bookerRepository = bookerRepository;
            }
            public async Task<IEnumerable<Booker>> Handle(GetAllBookersQuery query, CancellationToken cancellationToken)
            {
                var BookerList = await _bookerRepository.Bookers.ToListAsync(cancellationToken: cancellationToken);
                if (BookerList == null)
                {
                    return null;
                }
                return BookerList.AsReadOnly();
            }
        }
    }
}