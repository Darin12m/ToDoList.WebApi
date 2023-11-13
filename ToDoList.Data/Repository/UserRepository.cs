using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data.Databse;
using ToDoList.Data.Entities;

namespace ToDoList.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ToDoListDbContext dbContext) 
            : base(dbContext)
        {
        }

        public User? GetByUsername(string username)
        {
            return dbContext.Users?.FirstOrDefault(x => x.UserName == username);
        }
    }
}
