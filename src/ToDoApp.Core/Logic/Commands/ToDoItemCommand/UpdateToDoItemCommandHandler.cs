using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs.ToDoItem;
using ToDoApp.Application.Mappers;
using ToDoApp.Domain.Exceptions;
using ToDoApp.Infrastructure;

namespace ToDoApp.Application.Logic.Commands.ToDoItemCommand
{
    public class UpdateToDoItemCommandHandler : IRequestHandler<UpdateToDoItemCommand, ToDoItemDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        public UpdateToDoItemCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ToDoItemDTO> Handle(UpdateToDoItemCommand request, CancellationToken cancellationToken)
        {

            // Get the ToDoItem from the database
            var entity = await _dbContext.ToDoItems.FindAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException("The ToDoItem Not Found");
            }
            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.ToDoItemId = request.Id;
            entity.IsCompleted = request.IsCompleted;
            await _dbContext.SaveChangesAsync();
            return entity.ToToDoItemDTO();
        }
    }
}
