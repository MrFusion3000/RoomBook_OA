using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Mapster;
using MediatR;


namespace Application.Features.BookerFeatures.Commands
{
    public class CreateBookerCommand : IRequest<Guid>
    {
        // TODO This has no check for if the Booker exists under another  ID
        // Should the Booker have a separate UserId aside from the Guid ID in db?

        //Guid is created in Db
        private string Name { get; set; }
        private DateTime CreatedUTC { get; }

        public class CreateBookerCommandHandler : IRequestHandler<CreateBookerCommand, Guid>
        {
            private readonly IBookerRepository _bookerRepository;

            public CreateBookerCommandHandler(IBookerRepository bookerRepository)
            {
                _bookerRepository = bookerRepository;          
            }

            public async Task<Guid> Handle(CreateBookerCommand command, CancellationToken cancellationToken)
            {
                //var booker = command.Adapt<Booker>();
                var booker = new Booker()
                {
                    Name = command.Name,
                    CreatedUTC = command.CreatedUTC
                };
               return await _bookerRepository.CreateBookerAsync(booker, cancellationToken);

            }
        }
    }
}