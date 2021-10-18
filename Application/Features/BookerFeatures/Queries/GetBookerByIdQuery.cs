using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Shared.DTO;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

//using Mapster;

namespace Application.Features.BookerFeatures.Queries
{
public class GetBookerByIdQuery : IRequest<BookerDto>
{
    public Guid Id { get; init; }
    public class GetBookerByIdQueryHandler : IRequestHandler<GetBookerByIdQuery, BookerDto>
    {
        public GetBookerByIdQueryHandler(IBookerRepository bookerRepository)
        {
            BookerRepository = bookerRepository;
        }

        public IBookerRepository BookerRepository { get; }

        public async Task<BookerDto> Handle(GetBookerByIdQuery query, CancellationToken cancellationToken)
        {              

            //var dtToday = DateTime.UtcNow;

            //var booker = BookerRepository.Bookers
            //    .Include(a => a.TimeSlots.Where(t => t.TimeSlotStart > dtToday))
            //    .FirstOrDefault(a => a.ID == query.Id);

            //var bookerDto = booker.Adapt<IEnumerable<BookerDto>>;               

            //if (booker == null) return null;
            return await BookerRepository.GetBookerByIdAsync(query, cancellationToken);
        }
    }
}
}