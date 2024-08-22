using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs.ToDoItem;

namespace ToDoApp.Application.Logic.Queries.ToDoItemQuery
{
    public class GetToDoItemByIdQuery : IRequest<ToDoItemDTO>
    {
        public int Id { get; set; }
        public int listId { get; set; }
    }
}
