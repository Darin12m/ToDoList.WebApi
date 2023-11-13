using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data.Entities;
using ToDoList.Data.Repository;
using ToDoList.Services.Exceptions;
using ToDoList.Services.Models;
using ToDoList.Services.User;

namespace ToDoList.Services.Services
{
    public class ToDoListServices : IToDoListServices
    {
        private readonly IToDoListRepository todolistRepository;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public ToDoListServices(IToDoListRepository todolistRepository, IMapper mapper
            , IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.todolistRepository = todolistRepository;
            this.userRepository = userRepository;
        }

        public ToDoListModel Create(ICurrentUser currentUser, CreateToDoListModel createToDoListModel)
        {
            var user = userRepository.GetById(currentUser.Id);
            var todolist = new ToDoLists
            {
                Description = createToDoListModel.Description,
                Title = createToDoListModel.Title,
                User = user
                
            };

            if (user != null) 
            { 
               user.ToDoList.Add(todolist);
            }
           
            todolistRepository.Create(todolist);

            return mapper.Map<ToDoListModel>(todolist);

        }

        public ToDoListModel Delete(ICurrentUser currentUser, int id)
        {
            var entity = todolistRepository.GetById(id);
            if(entity == null)
            {
                throw new NotFoundException();
            }
            todolistRepository.Remove(entity);
            return mapper.Map<ToDoListModel>(entity);
        }

        public ToDoListModel GetToDoList(ICurrentUser currentUser, int id)
        {
            var todolist = todolistRepository.GetById(id);
            if(todolist == null)
            {
                throw new NotFoundException("No such Id.");
            }

            return mapper.Map<ToDoListModel>(todolist);
        }

       

        public ToDoListModel Update(ICurrentUser currentUser, EditToDoListModel editToDoListModel)
        {
            var entity = todolistRepository.GetById(editToDoListModel.Id);
            if (entity == null)
            {
                throw new NotFoundException();
            }
           
            entity.Title = editToDoListModel.Title;
            entity.Description = editToDoListModel.Description;
            todolistRepository.Update(entity);
            return mapper.Map<ToDoListModel>(entity);
        }

        public IEnumerable<ToDoListModel> GetToDoLists(ICurrentUser currentUser, SearchToDoListModel searchToDoListModel)
        {
            IEnumerable<Data.Entities.ToDoLists> notes = todolistRepository.GetTasks(currentUser.Id, searchToDoListModel.Title, searchToDoListModel.Description);
            return notes.Select(x => mapper.Map<ToDoListModel>(x));
        }
    }
}
