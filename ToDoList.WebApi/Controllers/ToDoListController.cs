using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoList.Data.Entities;
using ToDoList.Services.Models;
using ToDoList.Services.Services;
using ToDoList.Services.User;

namespace ToDoList.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListServices todoService;
        public ToDoListController(IToDoListServices todoService)
        {
            this.todoService = todoService;
        }



        
        [HttpGet]
        public IActionResult GetAll([FromQuery] SearchToDoListModel model)
        {
            return Ok(todoService.GetToDoLists(new ClaimsPrincipalWrapper(User), model));
        }


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            return Ok(todoService.GetToDoList(new ClaimsPrincipalWrapper(User), id));
        }


        [HttpPost]

        public IActionResult CreateToDoList([FromBody]CreateToDoListModel model)
        {
            ToDoListModel create = todoService.Create(new ClaimsPrincipalWrapper(User) , model);
            return Created("api/v1/todolist",create);
        }


        [HttpPut("{id}")]

        public IActionResult UpdateToDoList(int id , EditToDoListModel model)
        {
            model.Id = id;

            return Ok(todoService.Update(new ClaimsPrincipalWrapper(User) , model));
        }


        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            return Ok(todoService.Delete(new ClaimsPrincipalWrapper(User), id));
        }

    } 
}