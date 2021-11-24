using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Mapster;
using Application.Interfaces;
using Application.Shared.DTO;
using Domain.Entities;


namespace Application.Features.RoomFeatures.Queries
{
    public class GetRoomByIdAndTimeslotsBySpecDateQuery : IRequest<RoomDto>
    {
        public Guid Id { get; init; }
        public DateTime QueryDateTime { get; set; }
        public class GetRoomByIdAndTimeslotsBySpecDateTimeQueryHandler : IRequestHandler<GetRoomByIdAndTimeslotsBySpecDateQuery, RoomDto>
        {
            public GetRoomByIdAndTimeslotsBySpecDateTimeQueryHandler(IRoomRepository roomRepository)
            {
                RoomRepository = roomRepository;
            }

            public IRoomRepository RoomRepository { get; }

            public async Task<RoomDto> Handle(GetRoomByIdAndTimeslotsBySpecDateQuery query, CancellationToken cancellationToken)
            {
                return await RoomRepository.GetRoomByIdAndTimeSlotsBySpecDateAsync(query, cancellationToken);
            }
        }
    }
}