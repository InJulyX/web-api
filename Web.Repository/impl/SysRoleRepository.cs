using System.Collections.Generic;
using SqlSugar;
using Web.Common;
using Web.Model.Database;

namespace Web.Repository.impl
{
    public class SysRoleRepository : ISysRoleRepository
    {
        public List<SysRole> GetSysRoleList()
        {
            var db = SqlSugarHelper.GetInstance();
            var result = db.Queryable<SysRole>()
                .ToList();
            return result;
        }

        public int Update(SysRole sysRole)
        {
            var db = SqlSugarHelper.GetInstance();
            var rows = db.Updateable(sysRole)
                .IgnoreColumns(it => new {it.CreateTime})
                .IgnoreColumns(true)
                .ExecuteCommand();
            return rows;
        }

        public long InsertToResultId(SysRole sysRole)
        {
            var db = SqlSugarHelper.GetInstance();
            var rows = db.Insertable(sysRole)
                .IgnoreColumns(true)
                .ExecuteReturnBigIdentity();
            return rows;
        }

        public int DeleteByRoleId(long roleId)
        {
            var db = SqlSugarHelper.GetInstance();
            var rows = db.Deleteable<SysRole>()
                .Where(it => it.Id == roleId)
                .ExecuteCommand();
            return rows;
        }

        public IEnumerable<string> GetSysRoleNameListByUserId(long userId)
        {
            var db = SqlSugarHelper.GetInstance();

            var result = db.Queryable<SysRole, SysUserRole, SysUser>((sr, sur, su) => new JoinQueryInfos(
                    JoinType.Left, sr.Id == sur.RoleId,
                    JoinType.Left, sur.UserId == su.Id
                ))
                .Where((sr, sur, su) => su.Id == userId)
                .Select(sr => sr.RoleStr)
                .ToList();
            return result;
        }

        /// <summary>
        ///     分页查询角色列表
        /// </summary>
        /// <param name="sysRole"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IEnumerable<SysRole> GetSysRoleListToPage(SysRole sysRole, ref int count)
        {
            var db = SqlSugarHelper.GetInstance();
            return db.Queryable<SysRole>()
                .Where(it => it.Id > 0)
                .ToPageList(sysRole.PageNum, sysRole.PageSize, ref count);
        }

        /// <summary>
        ///     单条查询
        /// </summary>
        /// <param name="sysRole"></param>
        /// <returns></returns>
        public SysRole GetSysRole(SysRole sysRole)
        {
            var db = SqlSugarHelper.GetInstance();
            var result = db.Queryable<SysRole>()
                .WhereIF(sysRole.Id != 0, it => it.Id == sysRole.Id)
                .First();
            return result;
        }
    }
}