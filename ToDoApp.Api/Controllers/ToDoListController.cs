using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.Logic.Commands.ToDoListCommand;
using ToDoApp.Application.Logic.Queries.ToDoListQuery;
using ToDoApp.Domain.Models;

namespace ToDoApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoListController : Controller
    {
        private readonly IMediator _mediator;
        public ToDoListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ToDoListDTO>> Create(AddToDoListCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<ToDoListDTO>>> GetAll()
        {
            try
            {
                var result = await _mediator.Send(new GetToDoListQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoListDTO>> GetById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetToDoListByIdQuery()
                {
                    Id = id
                });
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteToDoListCommand()
                {
                    Id = id
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
