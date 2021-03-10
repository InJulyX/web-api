using System;
using System.Collections.Generic;
using SqlSugar;
using Web.Common;
using Web.Model.Database;

namespace Web.Repository.impl
{
    public class SysMenuRepository : ISysMenuRepository
    {
        public List<SysMenu> GetSysMenuListByUserId(long? userId)
        {
            var db = SqlSugarHelper.GetInstance();

            var result = db.Queryable<SysMenu, SysRoleMenu, SysUserRole, SysUser>((sm, srm, sur, su) =>
                    new JoinQueryInfos(
                        JoinType.Left, sm.MenuId == srm.MenuId,
                        JoinType.Left, srm.RoleId == sur.RoleId,
                        JoinType.Left, sur.UserId == su.Id
                    ))
                .Where((sm, srm, sur, su) => su.Id == userId)
                .GroupBy(sm => sm.MenuId)
                .OrderBy(sm => sm.OrderNum)
                .ToList();
            return result;
        }

        public IEnumerable<SysMenu> GetSysMenuList(SysMenu sysMenu)
        {
            using var db = SqlSugarHelper.GetInstance();

            var result = db.Queryable<SysMenu>()
                .WhereIF(sysMenu.MenuId > 0, m => m.MenuId == sysMenu.MenuId)
                .WhereIF(!string.IsNullOrEmpty(sysMenu.MenuName), m => m.MenuName == sysMenu.MenuName)
                .OrderBy(it => it.OrderNum)
                .ToList();
            return result;
        }

        public List<SysMenu> GetSysMenuList()
        {
            var db = SqlSugarHelper.GetInstance();
            return db.Queryable<SysMenu>()
                .ToList();
        }

        public int Insert(SysMenu sysMenu)
        {
            var db = SqlSugarHelper.GetInstance();
            var rows = db.Insertable(sysMenu)
                .IgnoreColumns(it => new {it.MenuId, it.CreateTime})
                .ExecuteCommand();
            return rows;
        }

        public long InsertReturnId(SysMenu sysMenu)
        {
            var db = SqlSugarHelper.GetInstance();
            var rows = db.Insertable(sysMenu)
                .IgnoreColumns(it => new {it.MenuId, it.CreateTime})
                .ExecuteReturnBigIdentity();
            return rows;
        }

        public int Update(SysMenu sysMenu)
        {
            var db = SqlSugarHelper.GetInstance();
            var rows = db.Updateable(sysMenu)
                .IgnoreColumns(it => new {it.CreateTime, it.CreateBy})
                .IgnoreColumns(true)
                .ExecuteCommand();
            return rows;
        }

        public List<int> GetSysMenuListByRoleIds(long roleId)
        {
            var db = SqlSugarHelper.GetInstance();
            const string sql =
                "SELECT sm.menu_id FROM sys_menu sm LEFT JOIN sys_role_menu srm ON sm.menu_id=srm.menu_id WHERE srm.role_id=@roleId AND sm.menu_id NOT IN (SELECT sm.parent_id FROM sys_menu sm INNER  JOIN sys_role_menu srm ON sm.menu_id=srm.menu_id AND srm.role_id=@roleId) ORDER BY sm.parent_id,sm.order_num";
            // var result = db.Ado.GetInt(sql, new {roleId});
            // var result= db.Ado.GetDataSetAll(sql, new {roleId});
            var result = db.Ado.SqlQuery<int>(sql, new {roleId});
            return result;
        }

        public IEnumerable<long> GetSysMenuListByRoleIds(IEnumerable<long> ids)
        {
            throw new NotImplementedException();
        }

        public int Delete(SysMenu sysMenu)
        {
            var db = SqlSugarHelper.GetInstance();
            var result = db.Deleteable(sysMenu)
                .ExecuteCommand();
            return result;
        }

        public SysMenu GetSysMenu(SysMenu sysMenu)
        {
            var db = SqlSugarHelper.GetInstance();
            var result = db.Queryable<SysMenu>()
                .WhereIF(sysMenu.MenuId != null, it => it.MenuId == sysMenu.MenuId)
                .WhereIF(!string.IsNullOrEmpty(sysMenu.MenuName), it => it.MenuName == sysMenu.MenuName)
                .WhereIF(sysMenu.Status != null, it => it.Status == sysMenu.Status)
                .First();
            return result;
        }

        /// <summary>
        ///     查询菜单是否存在
        /// </summary>
        /// <param name="sysMenu"></param>
        /// <returns></returns>
        public bool IsExist(SysMenu sysMenu)
        {
            var db = SqlSugarHelper.GetInstance();
            var result = db.Queryable<SysMenu>()
                .WhereIF(sysMenu.MenuId != null, it => it.MenuId != sysMenu.MenuId)
                .Where(it => it.ParentId == sysMenu.ParentId)
                .Where(it => it.MenuName == sysMenu.MenuName)
                .Where(it => it.OrderNum == sysMenu.OrderNum)
                .Any();
            return result;
        }

        /// <summary>
        ///     根据用户ID查询权限列表(未去重)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<string> GetPermissionListByUserId(long? id)
        {
            var db = SqlSugarHelper.GetInstance();
            var result =
                db.Queryable<SysUserRole, SysRoleMenu, SysMenu>
                    ((sur, srm, sm) => new JoinQueryInfos(
                        JoinType.Left, sur.RoleId == srm.RoleId,
                        JoinType.Left, srm.MenuId == sm.MenuId
                    ))
                    .Where(sur => sur.UserId == id)
                    .Select((sur, srm, sm) => sm.Perms)
                    .ToList();
            return result;
        }
    }
}