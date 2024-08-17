using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Domain.Models
{
    public class ToDoItem
    {
        public ToDoItem()
        {
            Title = "";
            Description = "";
        }
        public int ToDoItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public ToDoList ToDoList { get; set; }
        public int ToDoListId { get; set; }
        public int UserId { get; set; }
    }
}
