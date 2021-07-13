using System;
using System.Threading;
using System.Threading.Tasks;
using Persistance.Interfaces;
using Domain.Entities;
using MediatR;

namespace Persistance.Features.BookerFeatures.Commands
{
    public class CreateBookerCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public DateTime CreatedUTC { get; set; }

        public class CreateBookerCommandHandler : IRequestHandler<CreateBookerCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public CreateBookerCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(CreateBookerCommand command, CancellationToken cancellationToken)
            {
                var Booker = new Booker()
                {
                    Name = command.Name,
                    CreatedUTC = command.CreatedUTC
                };
                _context.Bookers.Add(Booker);
                await _context.SaveChangesAsync();
                return Booker.ID;
            }
        }
    }
}