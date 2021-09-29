using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Application.Features.TimeslotFeatures.Commands;
using Application.Features.TimeslotFeatures.Queries;
using Domain.Entities;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TimeSlotController : BaseApiController
    {
        /// <summary>
        /// Creates a New TimeSlot.
        /// </summary>
        /// <param name="timeSlot"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(TimeSlot timeSlot)
        {
            return Ok(await Mediator.Send(new CreateTimeSlotCommand(){TimeSlot = timeSlot}));
        }
        /// <summary>
        /// Gets all TimeSlots.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllTimeSlotsQuery()));
        }
        /// <summary>
        /// Gets all TimeSlots by date.
        /// </summary>
        /// <param name="today"></param>
        /// <returns></returns>
        [HttpGet("GetAllTimeSlotsByDate/{today:datetime}")]
        public async Task<IActionResult> GetAllTimeSlotsByDate(DateTime today)
        {
            return Ok(await Mediator.Send(new GetAllTimeSlotsByDateQuery { Today = today }));
        }
        /// <summary>
        /// Gets all TimeSlots by date.
        /// </summary>
        /// <param name="roomid"></param>
        /// /// <param name="today"></param>
        /// <returns></returns>
        [HttpGet("GetAllTimeSlotsByDateAndRoomId/{roomid:guid},{today:datetime}")]
        public async Task<IActionResult> GetAllTimeSlotsByDateAndRoomId(DateTime today, Guid roomid)
        {
            return Ok(await Mediator.Send(new GetAllTimeSlotsByDateAndRoomIdQuery { Today = today, ThisRoomId = roomid }));
        }
        /// <summary>
        /// Gets TimeSlot Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetTimeSlotByIdQuery { ID = id }));
        }
        /// <summary>
        /// Deletes TimeSlot Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteTimeSlotByIdCommand { ID = id }));
        }
        /// <summary>
        /// Updates the TimeSlot Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(Guid id, UpdateTimeSlotCommand command)
        {
            if (id != command.ID)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
