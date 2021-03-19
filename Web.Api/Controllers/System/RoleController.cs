using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Web.Model;
using Web.Model.Database;
using Web.Model.VO;
using Web.Repository;
using Web.Service;

namespace Web.Api.Controllers.System
{
    [Route("/system/role")]
    public class RoleController : BaseController
    {
        private readonly ISysRoleMenuRepository _sysRoleMenuRepository;
        private readonly ISysRoleRepository _sysRoleRepository;
        private readonly ISysRoleService _sysRoleService;

        public RoleController(ISysRoleRepository sysRoleRepository, ISysRoleMenuRepository sysRoleMenuRepository,
            ISysRoleService sysRoleService)
        {
            _sysRoleRepository = sysRoleRepository;
            _sysRoleMenuRepository = sysRoleMenuRepository;
            _sysRoleService = sysRoleService;
        }

        /// <summary>
        ///     分页查询角落列表
        /// </summary>
        /// <param name="sysRole"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        public AjaxResult<IEnumerable<SysRole>> GetSysRoleListToPage(SysRole sysRole)
        {
            var (item1, item2) = _sysRoleService.GetSysRoleListToPage(sysRole);
            return AjaxResult<IEnumerable<SysRole>>.Success(item1, item2);
        }

        /// <summary>
        ///     查询角色详细
        /// </summary>
        /// <param name="sysRoleId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{sysRoleId}")]
        public AjaxResult<SysRoleVo> GetSysRole(long sysRoleId)
        {
            var data = _sysRoleService.GetSysRoleById(sysRoleId);
            return AjaxResult<SysRoleVo>.Success(data);
        }

        [HttpPut]
        public AjaxResult<object> UpdateRole([FromBody] SysRole sysRole)
        {
            var s1 = _sysRoleRepository.Update(sysRole);
            var s2 = _sysRoleMenuRepository.DeleteByRoleId(sysRole.Id);
            var sysRoleMenuList = sysRole.MenuIds
                .Select(variable => new SysRoleMenu {RoleId = sysRole.Id, MenuId = variable}).ToList();

            var s3 = _sysRoleMenuRepository.InsertBatch(sysRoleMenuList);
            return AjaxResult<object>.Success(s3);
        }

        [HttpPost]
        public AjaxResult<object> AddSysRole([FromBody] SysRole sysRole)
        {
            var roleId = _sysRoleRepository.InsertToResultId(sysRole);
            var sysRoleMenuList = sysRole.MenuIds
                .Select(variable => new SysRoleMenu {RoleId = roleId, MenuId = variable}).ToList();

            var s2 = _sysRoleMenuRepository.InsertBatch(sysRoleMenuList);
            return AjaxResult<object>.Success(s2);
        }

        [HttpDelete]
        [Route("{roleId}")]
        [HasPermission("system:role:remove")]
        public AjaxResult<object> DeleteSysRole(long roleId)
        {
            var s1 = _sysRoleMenuRepository.DeleteByRoleId(roleId);
            var s2 = _sysRoleRepository.DeleteByRoleId(roleId);
            return AjaxResult<object>.Success();
        }
    }
}