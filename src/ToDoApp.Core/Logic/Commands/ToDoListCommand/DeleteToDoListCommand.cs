using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Logic.Commands.ToDoListCommand
{
    public class DeleteToDoListCommand : IRequest
    {
        public int Id { get; set; }
    }
}
