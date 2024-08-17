using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;

namespace ToDoApp.Application.Logic.Queries.ToDoListQuery
{
    public class GetToDoListByIdQuery : IRequest<ToDoListDTO>
    {
        public int Id { get; set; }
    }
}
