using Microsoft.AspNetCore.Mvc;
using ToDoList.Services.Services;
using ToDoList.WebApi.Models;

namespace ToDoList.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices userService;

        public UserController(IUserServices userService)
        {
            this.userService = userService;
        }

        [HttpPost("login")] // api/user/login
        public IActionResult Login(LoginModel model)
        {
            return Ok(userService.Login(model.UserName, model.Password));
        }



        [HttpPost("register")]
        public IActionResult Register(RegisterModel model)
        {
            return Ok(userService.Register(model.UserName, model.Password));
        }
    }
}
