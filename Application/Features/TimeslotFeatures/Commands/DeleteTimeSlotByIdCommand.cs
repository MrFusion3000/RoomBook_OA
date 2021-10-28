using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.TimeslotFeatures.Commands
{
    public class DeleteTimeSlotByIdCommand : IRequest<Guid>
    {
        public Guid ID { get; set; }
        public class DeleteTimeSlotByIdCommandHandler : IRequestHandler<DeleteTimeSlotByIdCommand, Guid>
        {
            public DeleteTimeSlotByIdCommandHandler(ITimeSlotRepository timeSlotRepository)
            {
                TimeSlotRepository = timeSlotRepository;
            }

            public ITimeSlotRepository TimeSlotRepository { get; }

            public async Task<Guid> Handle(DeleteTimeSlotByIdCommand command, CancellationToken cancellationToken)
            {
                var timeSlot = command.Adapt<TimeSlot>();

                if (timeSlot == null) return default;

                //var timeSlot = await _context.TimeSlots.Where(a => a.ID == command.ID).FirstOrDefaultAsync();
                //if (timeSlot == null) return default;
                //_context.TimeSlots.Remove(timeSlot);
                //await _context.SaveChangesAsync();
                //return timeSlot.ID;

                return await TimeSlotRepository.DeleteTimeSlotAsync(timeSlot, cancellationToken);
            }
        }
    }
}