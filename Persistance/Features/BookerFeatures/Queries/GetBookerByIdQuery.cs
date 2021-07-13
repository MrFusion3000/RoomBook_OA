using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Persistance.Interfaces;

namespace Persistance.Features.BookerFeatures.Queries
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
                var Booker = _context.Bookers
                    .Include(a => a.TimeSlots.Where(t => t.TimeSlotStart > dtToday))
                    .FirstOrDefault(a => a.ID == query.Id);
                //var Booker = _context.Bookers
                //.Include(a => a.TimeSlots.Where(t => t.TimeSlotStart > dtToday))
                //.Include(b => b.TimeSlots).FirstOrDefaultAsync()
                //.FirstOrDefault(a => a.ID == query.Id)
                ;
                if (Booker == null) return null;
                return await Task.FromResult(Booker);
            }
        }
    }

    //Parent parent = _context.Parent.Include(p => p.Children.Grandchild).FirstOrDefault();

}