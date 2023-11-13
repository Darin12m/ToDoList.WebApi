using System.ComponentModel.DataAnnotations;

namespace ToDoList.WebApi.Models
{
    public class LoginModel
    {



        [Required]
        

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } =string.Empty;
    }
}
