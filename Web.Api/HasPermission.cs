using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Api
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class HasPermission : Attribute, IAsyncAuthorizationFilter
    {
        public HasPermission(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var authorizationService = context.HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();
            var authorizationResult = await authorizationService.AuthorizeAsync(context.HttpContext.User, null,
                new PermissionAuthorizationRequirement(Name));
            if (!authorizationResult.Succeeded) context.Result = new ForbidResult();
        }
    }
}