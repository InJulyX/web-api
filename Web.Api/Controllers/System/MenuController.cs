using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web.Model;
using Web.Model.Database;
using Web.Repository;
using Web.Service;

namespace Web.Api.Controllers.System
{
    [Route("/system/menu")]
    public class MenuController : BaseController
    {
        private readonly ISysMenuRepository _sysMenuRepository;
        private readonly ISysMenuService _sysMenuService;
        private readonly ISysUserRepository _sysUserRepository;
        private readonly ISysUserRoleRepository _sysUserRoleRepository;

        public MenuController(ISysMenuService sysMenuService, ISysMenuRepository sysMenuRepository,
            ISysUserRepository sysUserRepository, ISysUserRoleRepository sysUserRoleRepository)
        {
            _sysMenuService = sysMenuService;
            _sysMenuRepository = sysMenuRepository;
            _sysUserRepository = sysUserRepository;
            _sysUserRoleRepository = sysUserRoleRepository;
        }

        /// <summary>
        ///     查询菜单列表
        /// </summary>
        /// <param name="sysMenu"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        public AjaxResult<IEnumerable<SysMenu>> List(SysMenu sysMenu)
        {
            var s1 = _sysMenuService.GetSysMenuList(sysMenu);
            return AjaxResult<IEnumerable<SysMenu>>.Success(s1);
        }

        /// <summary>
        ///     添加菜单
        /// </summary>
        /// <param name="sysMenu"></param>
        /// <returns></returns>
        [HttpPost]
        [Log("菜单管理", "添加菜单")]
        public AjaxResult<object> AddSysMenu([FromBody] SysMenu sysMenu)
        {
            return _sysMenuService.AddSysMenu(sysMenu);
        }

        /// <summary>
        ///     根据ID查询菜单详细
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{menuId}")]
        public AjaxResult<SysMenu> GetSysMenu(long menuId)
        {
            var result = _sysMenuService.GetSysMenuByMenuId(menuId);
            return AjaxResult<SysMenu>.Success(result);
        }

        /// <summary>
        ///     删除菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{menuId}")]
        [Log("菜单管理", "删除菜单")]
        public AjaxResult<object> DeleteSysMenu(long menuId)
        {
            _sysMenuService.DeleteSysMenuByMenuId(menuId);

            return AjaxResult<object>.Success();
        }

        /// <summary>
        ///     更新菜单
        /// </summary>
        /// <param name="sysMenu"></param>
        /// <returns></returns>
        [HttpPut]
        [Log("菜单管理", "更新菜单")]
        public AjaxResult<object> UpdateSysMenu([FromBody] SysMenu sysMenu)
        {
            _sysMenuService.UpdateSysMenu(sysMenu);
            return AjaxResult<object>.Success();
        }

        [HttpGet]
        [Route("treeSelect")]
        public AjaxResult<object> GetTreeSelect()
        {
            // var s1 = _sysMenuService.GetMenuTreeByUserId(GetUserId());
            // var s2 = _sysMenuService.BuildMenus(s1);
            var s3 = _sysMenuService.BuildSysMenuTreeSelect();
            return AjaxResult<object>.Success(s3);
        }

        [HttpGet]
        [Route("roleMenuTreeSelect/{id:long}")]
        public AjaxResult<object> GetRoleMenuTree(long id)
        {
            var userId = GetUserId();
            var checkedKeys = _sysMenuRepository.GetSysMenuListByRoleIds(id);
            // var roleIds = _sysUserRoleRepository.GetSysRoleIdListByUserId(userId);
            var s2 = _sysMenuService.GetMenuTreeByUserId(userId);
            // var menus = _sysMenuService.BuildMenus(s2);
            var menus = _sysMenuService.BuildSysMenuTreeSelect();
            var data = new Dictionary<string, object>
            {
                {"checkedKeys", checkedKeys},
                {"menus", menus}
            };
            return AjaxResult<object>.Success(data);
        }
    }
}