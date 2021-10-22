using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Shared.DTO;
using Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.BookerFeatures.Queries
{
        public class GetBookerByIdQuery : IRequest<Booker>
        {
        public Guid Id { get; set; }
        public class GetBookerByIdQueryHandler : IRequestHandler<GetBookerByIdQuery, Booker>
        {
            private readonly IBookerRepository BookerRepository;

            public GetBookerByIdQueryHandler(IBookerRepository bookerRepository)
            {
                BookerRepository = bookerRepository;
            }

            public async Task<Booker> Handle(GetBookerByIdQuery query, CancellationToken cancellationToken)
            {
                var booker = new Booker { ID = query.Id, Name = "Booker T", CreatedUTC = DateTime.Now };

                //var booker = await BookerRepository.GetBookerByIdAsync(query, cancellationToken);


                //var dtToday = DateTime.UtcNow;

                //var booker = _context.Bookers
                //.Include(a => a.TimeSlots.Where(t => t.TimeSlotStart > dtToday))
                //.FirstOrDefault(a => a.ID == query.Id);

                //var bookerDto = booker.Adapt<BookerDto>();

                if (booker == null) return null;
                //return await BookerRepository.GetBookerByIdAsync(query, cancellationToken);
                return await Task.FromResult(booker);

                //return booker; //== null ? null : new Booker();
            }
        }
    }
    }