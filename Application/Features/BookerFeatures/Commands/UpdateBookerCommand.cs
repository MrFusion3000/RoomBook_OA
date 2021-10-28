using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Shared.DTO;
using Mapster;
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
            public UpdateBookerCommandHandler(IBookerRepository bookerRepository)
            {
                BookerRepository = bookerRepository;
            }

            public IBookerRepository BookerRepository { get; }

            public async Task<Guid> Handle(UpdateBookerCommand command, CancellationToken cancellationToken)
            {
                var bookerDtoIn = command.Adapt<BookerDtoIn>();

                if (bookerDtoIn == null) return default;

                return await BookerRepository.UpdateBookerAsync(bookerDtoIn, cancellationToken);
            }
        }
    }
}