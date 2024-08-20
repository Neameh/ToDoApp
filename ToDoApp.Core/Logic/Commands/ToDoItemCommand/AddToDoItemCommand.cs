using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.DTOs.ToDoItem;

namespace ToDoApp.Application.Logic.Commands.ToDoItemCommand
{
    public class AddToDoItemCommand : IRequest<ToDoItemDTO>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public int ToDoListId { get; set; }
    }
}
