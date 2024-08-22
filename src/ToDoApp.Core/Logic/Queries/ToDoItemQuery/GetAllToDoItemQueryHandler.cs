using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs.ToDoItem;
using ToDoApp.Domain.Exceptions;
using ToDoApp.Domain.Models;
using ToDoApp.Infrastructure;

namespace ToDoApp.Application.Logic.Queries.ToDoItemQuery
{
    public class GetAllToDoItemQueryHandler : IRequestHandler<GetAllToDoItemQuery, List<ToDoItemDTO>>
    {
        private readonly ApplicationDbContext _dbContext;
        public GetAllToDoItemQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ToDoItemDTO>> Handle(GetAllToDoItemQuery request, CancellationToken cancellationToken)
        {
            var List = await _dbContext.ToDoLists.FindAsync(request.listId);
            if (List == null)
            {
                throw new NotFoundException("The list Not Found");
            }
            var toDoItemList = await _dbContext.ToDoItems.Where(x => x.ToDoListId == List.ToDoListId).ToListAsync();
            if (toDoItemList == null)
            {
                throw new NotFoundException("There is not ToDoItem List for selected List");
            }
            var result = toDoItemList.Select(x => new ToDoItemDTO
            {
                Id = x.ToDoItemId,
                Title = x.Title,
                Description=x.Description,
            }).ToList();

            return result;

        }


    }
}
