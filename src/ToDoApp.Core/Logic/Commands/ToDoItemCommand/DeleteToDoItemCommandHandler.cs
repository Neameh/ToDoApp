using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Exceptions;
using ToDoApp.Infrastructure;

namespace ToDoApp.Application.Logic.Commands.ToDoItemCommand
{
    public class DeleteToDoItemCommandHandler : IRequestHandler<DeleteToDoItemCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        public DeleteToDoItemCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
        {
            var List = await _dbContext.ToDoLists.FindAsync(request.listId);
            if (List == null)
            {
                throw new NotFoundException("");
            }
            // Why it should not be await
            var toDoItem =  _dbContext.ToDoItems.FirstOrDefault(x=>x.ToDoListId ==request.listId && x.ToDoItemId == request.Id);
            if (toDoItem == null)
            {
                throw new NotFoundException("To Do Item Not Found");
            }
            _dbContext.ToDoItems.Remove(toDoItem);
            await  _dbContext.SaveChangesAsync();
        }
    }
}
