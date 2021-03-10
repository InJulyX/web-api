using System.Collections.Generic;
using Web.Model.Database;

namespace Web.Repository
{
    public interface ISysUserRepository
    {
        SysUser GetUser(SysUser sysUser);
        IEnumerable<SysUser> GetUserList(int pageNum, int pageSize, SysUser sysUser, ref int total);
        int Insert(SysUser sysUser);
        long InsertToResultId(SysUser sysUser);
        SysUser GetSysUserById(long id);
    }
}