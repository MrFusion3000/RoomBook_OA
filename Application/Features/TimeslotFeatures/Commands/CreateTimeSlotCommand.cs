using Application.Interfaces;
using Application.Shared.DTO;
using Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TimeslotFeatures.Commands;
public class CreateTimeSlotCommand : IRequest<Guid>
{
    public TimeSlotDto TimeSlot { get; set; }

    public class CreateTimeSlotCommandHandler : IRequestHandler<CreateTimeSlotCommand, Guid>
    {
        public CreateTimeSlotCommandHandler(ITimeSlotRepository timeSlotRepository)
        {
            TimeSlotRepository = timeSlotRepository;
        }

        public ITimeSlotRepository TimeSlotRepository { get; }

        public async Task<Guid> Handle(CreateTimeSlotCommand command, CancellationToken cancellationToken)
        {
            var timeslot = command.TimeSlot.Adapt<TimeSlot>();

            return await TimeSlotRepository.CreateTimeSlotAsync(timeslot, cancellationToken);
        }
    }
}