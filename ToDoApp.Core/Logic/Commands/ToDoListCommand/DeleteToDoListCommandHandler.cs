using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Exceptions;
using ToDoApp.Infrastructure;

namespace ToDoApp.Application.Logic.Commands.ToDoListCommand
{
    public class DeleteToDoListCommandHandler : IRequestHandler<DeleteToDoListCommand>
    {
        private ApplicationDbContext _dbContext;
        public DeleteToDoListCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteToDoListCommand request, CancellationToken cancellationToken)
        {

            var toDoList = await _dbContext.ToDoLists.FindAsync(request.Id);
            if (toDoList == null) { throw new NotFoundException("ToDoList Not Found"); }
            _dbContext.ToDoLists.Remove(toDoList);
            await _dbContext.SaveChangesAsync();
        }
    }
}
