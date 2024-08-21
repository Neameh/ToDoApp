using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.DTOs.ToDoList;
using ToDoApp.Domain.Models;

namespace ToDoApp.Application.Logic.Queries.ToDoListQuery
{
    public class GetToDoListQuery : IRequest<List<ToDoListDTO>>
    {
    }
}
