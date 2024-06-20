using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace BotafeMVC.Web.Filters
{
    public class CheckPermissions : Attribute, IAuthorizationFilter
    {
        private readonly string _permission;

        public CheckPermissions(string permission)
        {
            _permission = permission;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            
            var isAuthenticated = context.HttpContext.User.Claims.Any(c =>  c.Value == _permission);

            if(!isAuthenticated)
            {
                context.Result = new RedirectResult("~/Identity/Account/AccessDenied");
            }
        }
    }
}
