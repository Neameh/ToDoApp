using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.DTOs.ToDoItem;
using ToDoApp.Application.Mappers;
using ToDoApp.Domain.Exceptions;
using ToDoApp.Domain.Models;
using ToDoApp.Infrastructure;

namespace ToDoApp.Application.Logic.Commands.ToDoItemCommand
{
    public class AddToDoItemCommandHandler : IRequestHandler<AddToDoItemCommand, ToDoItemDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        public AddToDoItemCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ToDoItemDTO> Handle(AddToDoItemCommand request, CancellationToken cancellationToken)
        {
            // Get the list that I should add the ToDoItem to it.
            var toDoList = await _dbContext.ToDoLists.FindAsync(request.ToDoListId);
            // Check if it is null
            if (toDoList == null)
            {
                throw new NotFoundException("List Not Found");
            }
            // Create new ToDoItem object
            var entity = new ToDoItem();
            // Check if the ToDoListId in the chosen list equal to requset.ToDoListId
            if (toDoList.ToDoListId == request.ToDoListId)
            {
                entity.Title = request.Title;
                entity.Description = request.Description;
                entity.ToDoListId = request.ToDoListId;
                entity.IsCompleted = request.IsCompleted;
            }
            await _dbContext.ToDoItems.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity.ToToDoItemDTO();
        }
    }
}
