using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Application.Features.BookerFeatures.Commands;
using Application.Features.BookerFeatures.Queries;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class BookerController : BaseApiController
    {
        /// <summary>
        /// Creates a New Booker.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Gets all Bookers.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllBookersQuery()));
        }

        /// <summary>
        /// Gets Booker Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetBookerByIdQuery { Id = id }));
        }

       // /// <summary>
       // /// Deletes Booker Entity based on Id.
       // /// </summary>
       // /// <param name="id"></param>
       // /// <returns></returns>
        //[Authorize]
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    return Ok(await Mediator.Send(new DeleteBookerByIdCommand { ID = id }));
        //}

        /// <summary>
        /// Updates the Booker Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(Guid id, UpdateBookerCommand command)
        {
            if (id != command.ID)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
