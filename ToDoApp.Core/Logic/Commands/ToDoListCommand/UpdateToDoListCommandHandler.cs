using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;
using ToDoApp.Domain.Exceptions;
using ToDoApp.Infrastructure;

namespace ToDoApp.Application.Logic.Commands.ToDoListCommand
{
    public class UpdateToDoListCommandHandler : IRequestHandler<UpdateToDoListCommand, ToDoListDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        public UpdateToDoListCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ToDoListDTO> Handle(UpdateToDoListCommand request, CancellationToken cancellationToken)
        {
            // Check if the entity is found in the database or not.
            var entity = await _dbContext.ToDoLists.FindAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException("ToDoList Not Found");
            }

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.ToDoListId = request.Id;
            await _dbContext.SaveChangesAsync();

            var toDoListUpdated = new ToDoListDTO();
            toDoListUpdated.Title = entity.Title;
            toDoListUpdated.Description = entity.Description;
            toDoListUpdated.Id = entity.ToDoListId;

            return toDoListUpdated;
        }


    }
}
