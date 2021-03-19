using System.Collections.Generic;
using SqlSugar;
using Web.Common;
using Web.Model.Database;

namespace Web.Repository.impl
{
    public class SysUserRepository : ISysUserRepository
    {
        /// <summary>
        ///     用户查询
        /// </summary>
        /// <param name="sysUser"></param>
        /// <returns></returns>
        public SysUser GetUser(SysUser sysUser)
        {
            using var db = SqlSugarHelper.GetInstance();

            var result = db.Queryable<SysUser>()
                    .WhereIF(sysUser.Id != null, u => u.Id == sysUser.Id)
                    .WhereIF(sysUser.Username != null, u => u.Username == sysUser.Username)
                    .WhereIF(sysUser.Password != null, u => u.Password == sysUser.Password)
                    .IgnoreColumns(it => new {it.Password})
                    .First()
                ;
            return result;
        }

        /// <summary>
        ///     添加用户并返回用户ID
        /// </summary>
        /// <param name="sysUser"></param>
        /// <returns></returns>
        public long InsertSysUserReturnId(SysUser sysUser)
        {
            var db = SqlSugarHelper.GetInstance();
            var rows = db.Insertable(sysUser)
                .IgnoreColumns(true)
                .ExecuteReturnBigIdentity();
            return rows;
        }

        /// <summary>
        ///     分页查询用户列表
        /// </summary>
        /// <param name="sysUser"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IEnumerable<SysUser> GetSysUserListToPage(SysUser sysUser, ref int count)
        {
            var db = SqlSugarHelper.GetInstance();
            var result = db.Queryable<SysUser>()
                .WhereIF(sysUser.Id == null, it => it.Id > 0)
                .OrderBy(it => it.CreateTime, OrderByType.Desc)
                .ToPageList(sysUser.PageNum, sysUser.PageSize, ref count);
            return result;
        }
    }
}