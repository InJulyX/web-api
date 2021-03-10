using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Web.Repository;
using Web.Service;

namespace Web.Api.Controllers
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionAuthorizationRequirement>
    {
        private readonly ISysMenuRepository _sysMenuRepository;
        private readonly ISysMenuService _sysMenuService;

        public PermissionAuthorizationHandler(ISysMenuRepository sysMenuRepository, ISysMenuService sysMenuService)
        {
            _sysMenuRepository = sysMenuRepository;
            _sysMenuService = sysMenuService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            PermissionAuthorizationRequirement requirement)
        {
            var userId = Convert.ToInt64(context.User.Claims.FirstOrDefault(o => o.Type == "user_id")?.Value);
            var permissionList = _sysMenuService.GetPermissionListByUserId(userId);
            if (permissionList.Contains(requirement.Name)) context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}