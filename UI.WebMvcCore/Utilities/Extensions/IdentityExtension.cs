using System.Linq;
using System.Security.Claims;

namespace UI.WebMvcCore.Utilities.Extensions
{
    public static class IdentityExtension
    {
        public static string GetId(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(claim =>
                claim.Type == ClaimTypes.NameIdentifier)?.Value;
        }

        //// *** CALL LIKE THIS ***
        //[Authorize] [HttpPost]
        //public ActionResult Create(CreateModel model)
        //{ var userId = this.User.GetId();    ...    }
    }
}