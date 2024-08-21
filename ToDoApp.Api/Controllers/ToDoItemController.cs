using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.DTOs.ToDoItem;
using ToDoApp.Application.Logic.Commands.ToDoItemCommand;
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
                    ToDoListId = listId
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
        public async Task<ActionResult<ToDoItemDTO>> Update(int listId, ToDoItemDTO request)
        {
            try
            {
                var command = new UpdateToDoItemCommand
                {
                    Id = request.Id,
                    listId = listId,
                    Title = request.Title,
                    Description = request.Description
                };
                var result =await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
