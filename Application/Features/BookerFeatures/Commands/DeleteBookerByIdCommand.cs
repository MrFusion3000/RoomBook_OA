using Application.Interfaces;
using Application.Shared.DTO;
using Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.BookerFeatures.Commands
{
    public class DeleteBookerByIdCommand : IRequest<Guid>
    {
        public Guid ID { get; set; }

        public class DeleteBookerByIdCommandHandler : IRequestHandler<DeleteBookerByIdCommand, Guid>
        {
            public DeleteBookerByIdCommandHandler(IBookerRepository bookerRepository)
            {
                BookerRepository = bookerRepository;
            }

            public IBookerRepository BookerRepository { get; }

            public async Task<Guid> Handle(DeleteBookerByIdCommand command, CancellationToken cancellationToken)
            {
                var booker = command.Adapt<Booker>();
                //var booker = await Context.DeleteBookerAsync(Bookers.Where(a => a.ID == booker.ID).FirstOrDefaultAsync(cancellationToken: cancellationToken));
                //if (booker == null) return default;
                //Context.Bookers.Remove(booker);

                return await BookerRepository.DeleteBookerAsync(booker, cancellationToken);
            }
        }
    }
}