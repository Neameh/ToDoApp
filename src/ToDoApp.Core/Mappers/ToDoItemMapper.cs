using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs.ToDoItem;
using ToDoApp.Domain.Models;

namespace ToDoApp.Application.Mappers
{
    // Extension Method for Mapping
    public static class ToDoItemMapper
    {
        public static ToDoItemDTO ToToDoItemDTO(this ToDoItem ToDoItem)
        {
            return new ToDoItemDTO
            {
                Id = ToDoItem.ToDoItemId,
                Title = ToDoItem.Title,
                Description = ToDoItem.Description,
                IsCompleted=ToDoItem.IsCompleted,

            };
        }
        public static ToDoItemRequestDTO ToToDoItemRequestDTO(this ToDoItem ToDoItem)
        {
            return new ToDoItemRequestDTO
            {
                Title = ToDoItem.Title,
                Description = ToDoItem.Description,
                IsCompleted = ToDoItem.IsCompleted,
            };
        }
    }
}
