//using MediatR;
//using System;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Application.Features.Bookers.Commands
//{
//    public class DeleteBookerByIdCommand : IRequest<Guid>
//    {
//        public Guid ID { get; set; }

//        public class DeleteBookerByIdCommandHandler : IRequestHandler<DeleteBookerByIdCommand, Guid>
//        {
//            private readonly IBookerRepository _bookerRepository;

//            public DeleteBookerByIdCommandHandler(IBookerRepository bookerRepository)
//            {
//                _bookerRepository = bookerRepository;
//            }

//            public async Task<Guid> Handle(DeleteBookerByIdCommand command, CancellationToken cancellationToken)
//            {
//                var booker = await _bookerRepository.DeleteBookerAsync(Bookers.Where(a => a.ID == booker.ID).FirstOrDefaultAsync(cancellationToken: cancellationToken));
//                if (booker == null) return default;
//                _applicationDbContext.Bookers.Remove(booker);

//                return await _bookerRepository.DeleteBookerAsync(booker, cancellationToken);
//            }
//        }
//    }
//}