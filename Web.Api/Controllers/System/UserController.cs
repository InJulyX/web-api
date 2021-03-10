using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Model;
using Web.Model.Database;
using Web.Repository;

namespace Web.Api.Controllers.System
{
    [Route("/system/user")]
    public class UserController : BaseController
    {
        private readonly ILogger<UserController> _logger;
        private readonly ISysRoleRepository _sysRoleRepository;
        private readonly ISysUserRepository _sysUserRepository;
        private readonly ISysUserRoleRepository _sysUserRoleRepository;

        public UserController(ILogger<UserController> logger, ISysUserRepository sysUserRepository,
            ISysRoleRepository sysRoleRepository, ISysUserRoleRepository sysUserRoleRepository)
        {
            _logger = logger;
            _sysUserRepository = sysUserRepository;
            _sysRoleRepository = sysRoleRepository;
            _sysUserRoleRepository = sysUserRoleRepository;
        }

        [Route("list")]
        [HttpGet]
        public AjaxResult<object> GetSysUserList(int pageNum, int pageSize, SysUser sysUser)
        {
            var total = 0;
            var s1 = _sysUserRepository.GetUserList(pageNum, pageSize, sysUser, ref total);
            return AjaxResult<object>.Success(total, s1);
        }

        [Route("{userId}")]
        [HttpGet]
        public AjaxResult<object> GetInfo(long userId)
        {
            var sysUser = _sysUserRepository.GetSysUserById(userId);
            var data = new Dictionary<string, object>();
            var sysRoleList = _sysRoleRepository.GetSysRoleList();
            var sysRoleIds = _sysUserRoleRepository.GetSysRoleIdListByUserId(userId);
            data.Add("user", sysUser);
            data.Add("roles", sysRoleList);
            data.Add("roleIds", sysRoleIds);
            return AjaxResult<object>.Success(data);
        }

        [HttpGet]
        public AjaxResult<object> GetRoleList()
        {
            var roleList = _sysRoleRepository.GetSysRoleList();
            return AjaxResult<object>.Success(roleList);
        }

        [HttpPost]
        public AjaxResult<object> AddSysUser([FromBody] SysUser sysUser)
        {
            var userId = _sysUserRepository.InsertToResultId(sysUser);
            var sysUserRoleList = sysUser.RoleIds
                .Select(variable => new SysUserRole {UserId = userId, RoleId = variable}).ToList();

            _sysUserRoleRepository.InsertBatch(sysUserRoleList);

            return AjaxResult<object>.Success();
        }
    }
}