using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;
using ToDoApp.Domain.Models;

namespace ToDoApp.Application.Logic.Commands.ToDoListCommand
{
    public class AddToDoListCommand : IRequest<ToDoListDTO>
    {
        
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
    