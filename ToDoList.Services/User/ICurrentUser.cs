using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Services.User
{
    public interface ICurrentUser
    {
        public int Id { get;  }

        public string UserName { get;  }
    }
}
