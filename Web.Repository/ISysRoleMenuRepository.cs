using System.Collections.Generic;
using Web.Model.Database;

namespace Web.Repository
{
    public interface ISysRoleMenuRepository
    {
        int DeleteByRoleId(long roleId);
        int DeleteByMenuId(long menuId);

        /// <summary>
        ///     批量插入角色菜单数据
        /// </summary>
        /// <param name="sysRoleMenuList"></param>
        /// <returns></returns>
        int InsertBatch(List<SysRoleMenu> sysRoleMenuList);

        /// <summary>
        ///     插入角色菜单数据
        /// </summary>
        /// <param name="sysRoleMenu"></param>
        /// <returns></returns>
        int Insert(SysRoleMenu sysRoleMenu);

        int Delete(SysRoleMenu data);
    }
}