using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs.ToDoList;
using ToDoApp.Domain.Models;

namespace ToDoApp.Application.Mappers
{
    public static class ToDoListMapper
    {
        public static ToDoListDTO ToToDoListDTO(this ToDoList ToDoList)
        {
            return new ToDoListDTO
            {
                Id = ToDoList.ToDoListId,
                Title = ToDoList.Title,
                Description = ToDoList.Description
            };
        }
        public static ToDoListRequestDTO ToToDoListRequestDTO(this ToDoList ToDoList)
        {
            return new ToDoListRequestDTO
            {
                Title = ToDoList.Title,
                Description = ToDoList.Description,
            };
        }
    }
}
