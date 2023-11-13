using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data.Entities;

namespace ToDoList.Data.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        public User? GetByUsername(string username);
    }
}
