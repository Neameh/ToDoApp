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
            var List = await _dbContext.ToDoLists.FindAsync(request.listId);
            if (List == null)
            {
                throw new NotFoundException("List Not Found");
            }
            // ==========
            var toDoItem = _dbContext.ToDoItems.FirstOrDefault(x=>x.ToDoListId == request.listId && x.ToDoItemId == request.Id);
            if (toDoItem == null)
            {
                throw new NotFoundException("ToDoItem Not Found");
            }
            var result = new ToDoItemDTO
            {
                Title = toDoItem.Title,
                Description = toDoItem.Description,
                Id = toDoItem.ToDoItemId
            };
            return result;
        }
    }
}
