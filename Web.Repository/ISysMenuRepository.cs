using System.Collections.Generic;
using Web.Model.Database;

namespace Web.Repository
{
    public interface ISysMenuRepository
    {
        List<SysMenu> GetSysMenuListByUserId(long? userId);
        IEnumerable<SysMenu> GetSysMenuList(SysMenu sysMenu);
        List<SysMenu> GetSysMenuList();
        int Insert(SysMenu sysMenu);
        long InsertReturnId(SysMenu sysMenu);
        int Update(SysMenu sysMenu);
        List<int> GetSysMenuListByRoleIds(long roleId);
        IEnumerable<long> GetSysMenuListByRoleIds(IEnumerable<long> ids);
        int Delete(SysMenu sysMenu);
        SysMenu GetSysMenu(SysMenu sysMenu);

        /// <summary>
        ///     查询菜单是否存在
        /// </summary>
        /// <param name="sysMenu"></param>
        /// <returns></returns>
        bool IsExist(SysMenu sysMenu);

        /// <summary>
        ///     根据用户ID查询权限列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<string> GetPermissionListByUserId(long? id);
    }
}