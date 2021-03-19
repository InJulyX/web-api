using System.Collections.Generic;
using Web.Model;
using Web.Model.Database;
using Web.Model.VO;

namespace Web.Service
{
    public interface ISysMenuService
    {
        IEnumerable<RouterVO> BuildMenus(IEnumerable<SysMenu> sysMenuList);

        /// <summary>
        ///     根据用户ID查询菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<SysMenu> GetMenuTreeByUserId(long? userId);

        IEnumerable<SysMenu> GetSysMenuList(SysMenu sysMenu);
        IEnumerable<TreeSelect> BuildSysMenuTreeSelect();

        AjaxResult<object> GetRoleMenuTree(long id);

        /// <summary>
        ///     根据菜单ID删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteSysMenuByMenuId(long id);

        /// <summary>
        ///     添加系统菜单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        AjaxResult<object> AddSysMenu(SysMenu data);

        /// <summary>
        ///     根据菜单ID查询菜单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SysMenu GetSysMenuByMenuId(long id);

        /// <summary>
        ///     更新菜单信息
        /// </summary>
        /// <param name="sysMenu"></param>
        /// <returns></returns>
        int UpdateSysMenu(SysMenu sysMenu);

        /// <summary>
        ///     查询去重后的用户权限列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<string> GetPermissionListByUserId(long userId);
    }
}