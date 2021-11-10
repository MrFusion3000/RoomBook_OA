using Application.Interfaces;
using Application.Shared.DTO;
using Mapster;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TimeslotFeatures.Commands;
public class UpdateTimeSlotCommand : IRequest<Guid>
{
    public Guid ID { get; set; }
    public DateTime TimeSlotStart { get; set; }
    public DateTime TimeSlotEnd { get; set; }
    public string Title { get; set; }
    public bool IsVacant { get; set; }
    public Guid BookerId { get; set; }
    public DateTime CreatedUTC { get; set; }
    public DateTime UpdatedUTC { get; set; }
    public Guid RoomId { get; set; }

    public class UpdateTimeSlotCommandHandler : IRequestHandler<UpdateTimeSlotCommand, Guid>
    {
        public UpdateTimeSlotCommandHandler(ITimeSlotRepository timeSlotRepository)
        {
            TimeSlotRepository = timeSlotRepository;
        }

        public ITimeSlotRepository TimeSlotRepository { get; }

        public async Task<Guid> Handle(UpdateTimeSlotCommand command, CancellationToken cancellationToken)
        {
            var timeSlotDto = command.Adapt<TimeSlotDto>();

            if (timeSlotDto == null) return default;

            return await TimeSlotRepository.UpdateTimeSlotAsync(timeSlotDto, cancellationToken);
        }
    }
}