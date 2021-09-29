using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Application.Features.BookerFeatures.Commands
{
    public class CreateBookerCommand : IRequest<Guid>
    {
        //Guid is created in db
        private string Name { get; set; }
        private DateTime CreatedUTC { get; set; }

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