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
        public class GetBookerByIdQuery : IRequest<BookerDtoIn>
        {
        public Guid Id { get; set; }
        public class GetBookerByIdQueryHandler : IRequestHandler<GetBookerByIdQuery, BookerDtoIn>
        {
            private readonly IBookerRepository BookerRepository;

            public GetBookerByIdQueryHandler(IBookerRepository bookerRepository)
            {
                BookerRepository = bookerRepository;
            }

            public async Task<BookerDtoIn> Handle(GetBookerByIdQuery query, CancellationToken cancellationToken)
            {
                return await BookerRepository.GetBookerByIdAsync(query, cancellationToken);
            }
        }
    }
    }