using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

//using Mapster;

namespace Application.Features.BookerFeatures.Queries
{
    public class GetBookerByIdQuery : IRequest<Booker>
    {
        public Guid Id { get; init; }
        public class GetBookerByIdQueryHandler : IRequestHandler<GetBookerByIdQuery, Booker>
        {
            private readonly IApplicationDbContext _context;
            public GetBookerByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Booker> Handle(GetBookerByIdQuery query, CancellationToken cancellationToken)
            {
                var dtToday = DateTime.UtcNow;
                var booker = _context.Bookers
                    .Include(a => a.TimeSlots.Where(t => t.TimeSlotStart > dtToday))
                    .FirstOrDefault(a => a.ID == query.Id);

                //var bookerDto = booker.Adapt<IEnumerable<BookerDto>>;

                
                
                //var Booker = _context.Bookers
                //.Include(a => a.TimeSlots.Where(t => t.TimeSlotStart > dtToday))
                //.Include(b => b.TimeSlots).FirstOrDefaultAsync()
                //.FirstOrDefault(a => a.ID == query.Id);
                if (booker == null) return null;
                return await Task.FromResult(booker);
            }
        }
    }

    //Parent parent = _context.Parent.Include(p => p.Children.Grandchild).FirstOrDefault();

}