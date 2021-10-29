using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Application.Interfaces;
using Application.Shared.DTO;

namespace Application.Features.RoomFeatures.Queries
{
    public class GetRoomByIdQuery : IRequest<RoomDto>
    {
        public Guid Id { get; init; }
        public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, RoomDto>
        {
            public GetRoomByIdQueryHandler(IRoomRepository roomRepository)
            {
                RoomRepository = roomRepository;
            }

            public IRoomRepository RoomRepository { get; }

            public async Task<RoomDto> Handle(GetRoomByIdQuery query, CancellationToken cancellationToken)
            {
                return await RoomRepository.GetRoomByIdAsync(query, cancellationToken);
            }
        }
    }
}