using System.Security.Claims;
using System.Xml.Linq;
using ToDoList.Services.User;

namespace ToDoList.WebApi
{
    public class ClaimsPrincipalWrapper
        : ICurrentUser
    {

        public ClaimsPrincipalWrapper(ClaimsPrincipal principal)
        {
            var idClaim = principal.FindFirst(ClaimTypes.NameIdentifier);
            if (idClaim != null)
            {
                Id = int.Parse(idClaim.Value);
            }

            var nameClaim = principal.FindFirst(ClaimTypes.Name);
            if (nameClaim != null)
            {
                UserName = nameClaim.Value;
            }
        }
        public int Id { get ; private set; }
        public string UserName { get; private set; } = string.Empty;


    }
}
