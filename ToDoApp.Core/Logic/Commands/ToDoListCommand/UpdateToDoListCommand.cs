using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;

namespace ToDoApp.Application.Logic.Commands.ToDoListCommand
{
    public class UpdateToDoListCommand : IRequest<ToDoListDTO>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
