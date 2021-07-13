using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistance.Interfaces;

namespace Persistance.Features.BookerFeatures.Commands
{
    public class UpdateBookerCommand : IRequest<Guid>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedUTC { get; set; }

        public class UpdateBookerCommandHandler : IRequestHandler<UpdateBookerCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public UpdateBookerCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(UpdateBookerCommand command, CancellationToken cancellationToken)
            {
                var Booker = _context.Bookers.FirstOrDefault(a => a.ID == command.ID);

                if (Booker == null)
                {
                    return default;
                }
                else
                {
                    Booker.Name = command.Name;
                    Booker.CreatedUTC = command.CreatedUTC;

                    await _context.SaveChangesAsync();
                    return Booker.ID;
                }
            }
        }
    }
}