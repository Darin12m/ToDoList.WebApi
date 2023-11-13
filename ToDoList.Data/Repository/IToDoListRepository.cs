using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data.Entities;

namespace ToDoList.Data.Repository
{
    public interface IToDoListRepository : IRepository<ToDoLists>
    {
        public IEnumerable<ToDoLists> GetTasks(int userId , string title , string? description 
            , string orderBy = nameof(ToDoLists.Title) , bool isAsc = true);
       
    }
}
