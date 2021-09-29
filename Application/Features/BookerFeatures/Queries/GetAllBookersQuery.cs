using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.BookerFeatures.Queries
{
    public class GetAllBookersQuery : IRequest<IEnumerable<Booker>>
    {

        public class GetAllBookersQueryHandler : IRequestHandler<GetAllBookersQuery, IEnumerable<Booker>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllBookersQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Booker>> Handle(GetAllBookersQuery query, CancellationToken cancellationToken)
            {
                var BookerList = await _context.Bookers.ToListAsync(cancellationToken: cancellationToken);
                if (BookerList == null)
                {
                    return null;
                }
                return BookerList.AsReadOnly();
            }
        }
    }
}