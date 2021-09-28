using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Bookers.Commands
{
    public class UpdateBookerCommand : IRequest<Guid>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedUTC { get; set; }

        public class UpdateBookerCommandHandler : IRequestHandler<UpdateBookerCommand, Guid>
        {
            private readonly IBookerRepository _bookerRepository;

            public UpdateBookerCommandHandler(IBookerRepository bookerRepository)
            {
                _bookerRepository = bookerRepository;
            }
            public async Task<Guid> Handle(UpdateBookerCommand command, CancellationToken cancellationToken)
            {
                var Booker = _bookerRepository.Bookers.FirstOrDefault(a => a.ID == command.ID);

                if (Booker == null)
                {
                    return default;
                }
                else
                {
                    Booker.Name = command.Name;
                    Booker.CreatedUTC = command.CreatedUTC;

                    await _bookerRepository.SaveChangesAsync();
                    return Booker.ID;
                }
            }
        }
    }
}