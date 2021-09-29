using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;

namespace Application.Features.BookerFeatures.Commands
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
                var booker = _context.Bookers.FirstOrDefault(a => a.ID == command.ID);

                if (booker == null)
                {
                    return default;
                }
                else
                {
                    booker.Name = command.Name;
                    booker.CreatedUTC = command.CreatedUTC;

                    await _context.SaveChangesAsync();
                    return booker.ID;
                }
            }
        }
    }
}