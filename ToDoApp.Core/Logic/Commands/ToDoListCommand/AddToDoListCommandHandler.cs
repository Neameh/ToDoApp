using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;
using ToDoApp.Domain.Models;
using ToDoApp.Infrastructure;

namespace ToDoApp.Application.Logic.Commands.ToDoListCommand
{
    public class AddToDoListCommandHandler : IRequestHandler<AddToDoListCommand, ToDoListDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        public AddToDoListCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // Result
        // Exception Flow
        public async Task<ToDoListDTO> Handle(AddToDoListCommand request, CancellationToken cancellationToken)
        {

            var entity = new ToDoList();

            entity.Title = request.Title;
            entity.Description = request.Description;

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return new ToDoListDTO
            {
                Id = entity.ToDoListId,
                Title = entity.Title,
                Description = entity.Description
            };

        }
    }
}
