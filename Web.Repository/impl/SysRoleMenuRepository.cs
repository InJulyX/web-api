using System.Collections.Generic;
using Web.Common;
using Web.Model.Database;

namespace Web.Repository.impl
{
    public class SysRoleMenuRepository : ISysRoleMenuRepository
    {
        public int DeleteByRoleId(long roleId)
        {
            var db = SqlSugarHelper.GetInstance();
            var rows = db.Deleteable<SysRoleMenu>()
                .Where(it => it.RoleId == roleId)
                .ExecuteCommand();
            return rows;
        }

        /// <summary>
        ///     批量插入角色菜单数据
        /// </summary>
        /// <param name="sysRoleMenuList"></param>
        /// <returns></returns>
        public int InsertBatch(List<SysRoleMenu> sysRoleMenuList)
        {
            var db = SqlSugarHelper.GetInstance();
            var rows = db.Insertable(sysRoleMenuList).ExecuteCommand();

            return rows;
        }

        /// <summary>
        ///     插入角色菜单数据
        /// </summary>
        /// <param name="sysRoleMenu"></param>
        /// <returns></returns>
        public int Insert(SysRoleMenu sysRoleMenu)
        {
            var db = SqlSugarHelper.GetInstance();
            return
                db.Insertable(sysRoleMenu).ExecuteCommand();
        }

        public int DeleteByMenuId(long menuId)
        {
            var db = SqlSugarHelper.GetInstance();
            var result = db.Deleteable<SysRoleMenu>()
                .Where(it => it.MenuId == menuId)
                .ExecuteCommand();
            return result;
        }

        public int Delete(SysRoleMenu data)
        {
            if (data.RoleId == null && data.MenuId == null) return 0;

            var db = SqlSugarHelper.GetInstance();
            var sql = db.Deleteable<SysRoleMenu>();
            if (data.RoleId != null) sql.Where(it => it.RoleId == data.RoleId);

            if (data.MenuId != null) sql.Where(it => it.MenuId == data.MenuId);

            return sql.ExecuteCommand();
        }
    }
}