using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.DTOs.ToDoItem;
using ToDoApp.Application.Logic.Commands.ToDoItemCommand;
using ToDoApp.Application.Logic.Queries.ToDoItemQuery;
using ToDoApp.Domain.Models;

namespace ToDoApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoItemController : Controller
    {
        private readonly IMediator _mediator;
        public ToDoItemController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("{listId}")]
        public async Task<ActionResult<ToDoItemDTO>> Create(int listId, ToDoItemRequestDTO request)
        {
            try
            {
                var command = new AddToDoItemCommand
                {
                    Title = request.Title,
                    Description = request.Description,
                    ToDoListId = listId,
                    IsCompleted = request.IsCompleted
                };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        public async Task<ActionResult<ToDoItemDTO>> Update(ToDoItemDTO request)
        {
            try
            {
                var command = new UpdateToDoItemCommand
                {
                    Id = request.Id,
                    Title = request.Title,
                    Description = request.Description,
                    IsCompleted = request.IsCompleted
                };
                var result =await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("GetAll/{listId}")]
        public async Task<ActionResult<List<ToDoItemDTO>>> GetAll(int listId)
        {
            try
            {
                var command = new GetAllToDoItemQuery
                {
                    listId = listId,
                };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<ToDoItemDTO>> GetById(int id)
        {
            try
            {
                var command = new GetToDoItemByIdQuery
                {
                    Id = id,
                };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteToDoItemCommand
                {
                    Id = id
                });
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
