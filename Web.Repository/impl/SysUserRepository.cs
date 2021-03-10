using System.Collections.Generic;
using Web.Common;
using Web.Model.Database;

namespace Web.Repository.impl
{
    public class SysUserRepository : ISysUserRepository
    {
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

        public IEnumerable<SysUser> GetUserList(int pageNum, int pageSize, SysUser sysUser, ref int total)
        {
            var db = SqlSugarHelper.GetInstance();
            var result = db.Queryable<SysUser>()
                .IgnoreColumns(it => new {it.Password})
                .ToPageList(pageNum, pageSize, ref total);
            return result;
        }

        public int Insert(SysUser sysUser)
        {
            var db = SqlSugarHelper.GetInstance();
            var rows = db.Insertable(sysUser)
                .IgnoreColumns(true)
                .ExecuteCommand();
            return rows;
        }

        public long InsertToResultId(SysUser sysUser)
        {
            var db = SqlSugarHelper.GetInstance();
            var rows = db.Insertable(sysUser)
                .IgnoreColumns(true)
                .ExecuteReturnBigIdentity();
            return rows;
        }

        public SysUser GetSysUserById(long id)
        {
            var db = SqlSugarHelper.GetInstance();
            var result = db.Queryable<SysUser>()
                .Where(it => it.Id == id)
                .First();
            return result;
        }
    }
}