using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Services.Models;
using ToDoList.Services.User;

namespace ToDoList.Services.Services
{
    public interface IToDoListServices
    {
        ToDoListModel GetToDoList(ICurrentUser currentUser , int id);

        IEnumerable<ToDoListModel> GetToDoLists(ICurrentUser currentUser, SearchToDoListModel searchToDoListModel);

        ToDoListModel Create(ICurrentUser currentUser, CreateToDoListModel createToDoListModel);

        ToDoListModel Update (ICurrentUser currentUser, EditToDoListModel editToDoListModel);

        ToDoListModel Delete(ICurrentUser currentUser, int id);
    }
}
