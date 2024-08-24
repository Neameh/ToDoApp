using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs.ToDoItem;
using ToDoApp.Domain.Exceptions;
using ToDoApp.Infrastructure;

namespace ToDoApp.Application.Logic.Queries.ToDoItemQuery
{
    public class GetToDoItemByIdQueryHandler : IRequestHandler<GetToDoItemByIdQuery, ToDoItemDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        public GetToDoItemByIdQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ToDoItemDTO> Handle(GetToDoItemByIdQuery request, CancellationToken cancellationToken)
        {

            var toDoItem = await _dbContext.ToDoItems.FindAsync(request.Id);
            if (toDoItem == null)
            {
                throw new NotFoundException("ToDoItem Not Found");
            }
            var result = new ToDoItemDTO
            {
                Title = toDoItem.Title,
                Description = toDoItem.Description,
                Id = toDoItem.ToDoItemId,
                IsCompleted=toDoItem.IsCompleted,
            };
            return result;
        }
    }
}
