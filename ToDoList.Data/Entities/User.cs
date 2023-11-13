using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Data.Entities
{
    public class User
    {

        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public virtual ICollection<ToDoLists> ToDoList { get; set; } = new List<ToDoLists>();

    }
}
