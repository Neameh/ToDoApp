using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.DTOs
{
    public class ToDoListDTO
    {
        public ToDoListDTO()
        {
            Title = "";
            Description = "";
               
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
