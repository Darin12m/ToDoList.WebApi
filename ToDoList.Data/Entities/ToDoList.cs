using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Data.Entities
{
    public class ToDoLists
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set;} 

        public bool IsDone { get; set; }

        public User? User { get; set; }
    }
}
