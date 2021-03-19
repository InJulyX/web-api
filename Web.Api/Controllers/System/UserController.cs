using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Model;
using Web.Model.Database;
using Web.Model.VO;
using Web.Repository;
using Web.Service;

namespace Web.Api.Controllers.System
{
    [Route("/system/user")]
    public class UserController : BaseController
    {
        private readonly ILogger<UserController> _logger;
        private readonly ISysRoleRepository _sysRoleRepository;
        private readonly ISysUserRepository _sysUserRepository;
        private readonly ISysUserRoleRepository _sysUserRoleRepository;
        private readonly ISysUserService _sysUserService;

        public UserController(ILogger<UserController> logger, ISysUserRepository sysUserRepository,
            ISysRoleRepository sysRoleRepository, ISysUserRoleRepository sysUserRoleRepository,
            ISysUserService sysUserService)
        {
            _logger = logger;
            _sysUserRepository = sysUserRepository;
            _sysRoleRepository = sysRoleRepository;
            _sysUserRoleRepository = sysUserRoleRepository;
            _sysUserService = sysUserService;
        }

        [Route("list")]
        [HttpGet]
        public AjaxResult<IEnumerable<SysUserVo>> GetSysUserListToPage(SysUser sysUser)
        {
            var (item1, item2) = _sysUserService.GetSysUserListToPage(sysUser);
            return AjaxResult<IEnumerable<SysUserVo>>.Success(item1, item2);
        }

        [Route("{userId}")]
        [HttpGet]
        public AjaxResult<object> GetInfo(long userId)
        {
            var sysUser = _sysUserService.GetSysUserByUserId(userId);
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
            var userId = _sysUserRepository.InsertSysUserReturnId(sysUser);
            var sysUserRoleList = sysUser.RoleIds
                .Select(variable => new SysUserRole {UserId = userId, RoleId = variable}).ToList();

            _sysUserRoleRepository.InsertBatch(sysUserRoleList);

            return AjaxResult<object>.Success();
        }
    }
}