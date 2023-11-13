using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Services.Models;

namespace ToDoList.Services.Services
{
    public interface IUserServices
    {
        RegisterResult Register ( string username, string password);

        string Login(string username, string password);
    }
}
