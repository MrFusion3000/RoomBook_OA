//using System;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using Application.Interfaces;
//using Domain.Entities;
//using Mapster;
//using MediatR;

//namespace Application.Features.TimeslotFeatures.Commands
//{
//    public class UpdateTimeSlotCommand : IRequest<Guid>
//    {
//        public Guid ID { get; set; }
//        public DateTime TimeSlotStart { get; set; }
//        public DateTime TimeSlotEnd { get; set; }
//        public string Title { get; set; }
//        public bool IsVacant { get; set; }
//        public Guid BookerId { get; set; }
//        public DateTime CreatedUTC { get; set; }
//        public DateTime UpdatedUTC { get; set; }

//        public class UpdateTimeSlotCommandHandler : IRequestHandler<UpdateTimeSlotCommand, Guid>
//        {
//            public UpdateTimeSlotCommandHandler(ITimeSlotRepository timeSlotRepository)
//            {
//                TimeSlotRepository = timeSlotRepository;
//            }

//            public ITimeSlotRepository TimeSlotRepository { get; }

//            public async Task<Guid> Handle(UpdateTimeSlotCommand command, CancellationToken cancellationToken)
//            {
//                var timeSlot = command.Adapt<TimeSlot>();

//                if (timeSlot == null)
//                {
//                    return default;
//                }
//                else
//                {
//                    return await TimeSlotRepository.UpdateTimeSlotAsync(command, cancellationToken);

//                }

//                #region
//                //*** Flytta
//                //var timeSlot = Context.TimeSlots.FirstOrDefault(a => a.ID == command.ID);

//                //if (timeSlot == null)
//                //{
//                //    return default;
//                //}
//                //else
//                //{                    
//                //    timeSlot.Title = command.Title;
//                //    timeSlot.IsVacant = command.IsVacant;
//                //    timeSlot.UpdatedUTC = command.UpdatedUTC;
//                //    timeSlot.BookerId = command.BookerId;

//                //    await Context.SaveChangesAsync();
//                //    return timeSlot.ID;
//                //}
//                //***
//                #endregion
//            }
//        }
//    }
//}