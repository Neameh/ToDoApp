using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;
using ToDoApp.Domain.Exceptions;
using ToDoApp.Infrastructure;

namespace ToDoApp.Application.Logic.Queries.ToDoListQuery
{
    public class GetToDoListByIdQueryHandler : IRequestHandler<GetToDoListByIdQuery, ToDoListDTO>
    {
        private readonly ApplicationDbContext _dbCobtext;
        public GetToDoListByIdQueryHandler(ApplicationDbContext dbContext)
        {
            _dbCobtext = dbContext;
        }

        public async Task<ToDoListDTO> Handle(GetToDoListByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _dbCobtext.ToDoLists.FindAsync(request.Id);
                if (result == null)
                {
                    throw new DomainException("ToDoList is not found");
                }
                return new ToDoListDTO
                {
                    Id = result.ToDoListId,
                    Title=result.Title,
                    Description=result.Description,
                };
            }
            catch (Exception)
            {

                throw new DomainException("There is an error");
            }
        }
    }
}
