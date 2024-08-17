using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Domain.Models
{
    public class ToDoList
    {
        public ToDoList()
        {
            Title = "";
            Description = "";
        }
        public int ToDoListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<ToDoItem> ToDoItems { get; set; }
    }
}
