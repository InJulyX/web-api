using System.Collections.Generic;
using Web.Common;
using Web.Model.Database;

namespace Web.Repository.impl
{
    public class SysUserRoleRepository : ISysUserRoleRepository
    {
        public SysUserRole GetSysUserRole(SysUserRole sysUserRole)
        {
            using var db = SqlSugarHelper.GetInstance();

            var result = db.Queryable<SysUserRole>()
                .WhereIF(sysUserRole.UserId > 0, syu => syu.UserId == sysUserRole.UserId)
                .WhereIF(sysUserRole.RoleId > 0, syu => syu.RoleId == sysUserRole.RoleId)
                .First();
            return result;
        }


        public List<SysUserRole> GetSysUserRoleList(SysUserRole sysUserRole)
        {
            using var db = SqlSugarHelper.GetInstance();

            var result = db.Queryable<SysUserRole>()
                .WhereIF(sysUserRole.UserId > 0, syu => syu.UserId == sysUserRole.UserId)
                .WhereIF(sysUserRole.RoleId > 0, syu => syu.RoleId == sysUserRole.RoleId)
                .ToList();
            return result;
        }

        public int Insert(SysUserRole sysUserRole)
        {
            var db = SqlSugarHelper.GetInstance();
            var result = db.Insertable(sysUserRole)
                .ExecuteCommand();
            return result;
        }

        public int InsertBatch(List<SysUserRole> sysUserRoles)
        {
            var db = SqlSugarHelper.GetInstance();
            var result = db.Insertable(sysUserRoles)
                .ExecuteCommand();
            return result;
        }

        public List<long> GetSysRoleIdListByUserId(long userId)
        {
            var db = SqlSugarHelper.GetInstance();
            var result = db.Queryable<SysUserRole>()
                .Where(u => u.UserId == userId)
                .Select(it => it.RoleId)
                .ToList();
            return result;
        }
    }
}