using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Logic.Commands.ToDoItemCommand
{
    public class DeleteToDoItemCommand : IRequest
    {
        public int Id { get; set; }
        public int listId { get; set; }
    }
}
