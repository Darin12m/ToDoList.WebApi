using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data.Entities;
using ToDoList.Services.Models;

namespace ToDoList.Services.Mapping
{
    public class ToDoListMap : Profile
    {
        public ToDoListMap() 
        {
            CreateMap<ToDoLists, ToDoListModel>();
        }

    }
}
