using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs.ToDoItem;

namespace ToDoApp.Application.Logic.Queries.ToDoItemQuery
{
    public class GetAllToDoItemQuery : IRequest<List<ToDoItemDTO>>
    {
        public int listId { get; set; }
        public int Id { get; set; }
    
    }
}
