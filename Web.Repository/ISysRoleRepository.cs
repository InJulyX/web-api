using System.Collections.Generic;
using Web.Model.Database;

namespace Web.Repository
{
    public interface ISysRoleRepository
    {
        List<SysRole> GetSysRoleList();
        int Update(SysRole sysRole);
        long InsertToResultId(SysRole sysRole);
        int DeleteByRoleId(long roleId);
        IEnumerable<string> GetSysRoleNameListByUserId(long userId);

        /// <summary>
        ///     分页查询角色列表
        /// </summary>
        /// <param name="sysRole"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        IEnumerable<SysRole> GetSysRoleListToPage(SysRole sysRole, ref int count);

        /// <summary>
        ///     单条查询
        /// </summary>
        /// <param name="sysRole"></param>
        /// <returns></returns>
        SysRole GetSysRole(SysRole sysRole);
    }
}