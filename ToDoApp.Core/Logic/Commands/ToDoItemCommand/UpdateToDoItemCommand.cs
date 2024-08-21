using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs.ToDoItem;
using ToDoApp.Domain.Models;

namespace ToDoApp.Application.Logic.Commands.ToDoItemCommand
{
    public class UpdateToDoItemCommand :IRequest<ToDoItemDTO>
    {
        public int Id { get; set; }
        public int listId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
