using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Bookers.Commands
{
    public class CreateBookerCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public DateTime CreatedUTC { get; set; }

        public class CreateBookerCommandHandler : IRequestHandler<CreateBookerCommand, Guid>
        {
            private readonly IBookerRepository _bookerRepository;

            public CreateBookerCommandHandler(IBookerRepository bookerRepository)
            {
                _bookerRepository = bookerRepository;
          
            }
            public async Task<Guid> Handle(CreateBookerCommand command, CancellationToken cancellationToken)
            {
                var booker = new Domain.Entities.Booker()
                {
                    Name = command.Name,
                    CreatedUTC = command.CreatedUTC
                };
               return await _bookerRepository.CreateBookerAsync(booker, cancellationToken);

            }
        }
    }
}