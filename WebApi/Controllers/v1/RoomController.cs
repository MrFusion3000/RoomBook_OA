
using Application.Features.RoomFeatures.Commands;
using Application.Features.RoomFeatures.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1;

[ApiVersion("1.0")]
public class RoomController : BaseApiController
{
    /// <summary>
    /// Creates a New Room.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateRoomCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    /// <summary>
    /// Deletes a Room based on Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await Mediator.Send(new DeleteRoomByIdCommand { ID = id }));
    }

    /// <summary>
    /// Updates a Room based on Id.   
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("[action]")]
    public async Task<IActionResult> Update(Guid id, UpdateRoomCommand command)
    {
        if (id != command.ID)
        {
            return BadRequest();
        }
        return Ok(await Mediator.Send(command));
    }

    /// <summary>
    /// Gets all Rooms.
    /// </summary>
    /// <returns></returns>
    //[Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetAllRoomsQuery()));
    }

    /// <summary>
    /// Gets a Room by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await Mediator.Send(new GetRoomByIdQuery { Id = id }));
    }

    /// <summary>
    /// Gets Room Entity by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="queryDateTime"></param>
    /// <returns></returns>
    [HttpGet("GetByIdAndDateTime/{id:guid}/{queryDateTime:datetime}")]
    public async Task<IActionResult> GetByIdAndDateTime(Guid id, DateTime queryDateTime)
    {
        return Ok(await Mediator.Send(new GetRoomByIdAndTimeslotsBySpecDateQuery() { QueryDateTime = queryDateTime, Id = id }));
    }
}