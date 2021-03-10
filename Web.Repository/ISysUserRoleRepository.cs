using System.Collections.Generic;
using Web.Model.Database;

namespace Web.Repository
{
    public interface ISysUserRoleRepository
    {
        SysUserRole GetSysUserRole(SysUserRole sysUserRole);
        List<SysUserRole> GetSysUserRoleList(SysUserRole sysUserRole);

        int Insert(SysUserRole sysUserRole);
        int InsertBatch(List<SysUserRole> sysUserRoles);
        List<long> GetSysRoleIdListByUserId(long userId);
    }
}