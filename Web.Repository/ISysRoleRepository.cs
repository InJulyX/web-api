using System.Collections.Generic;
using Web.Model.Database;

namespace Web.Repository
{
    public interface ISysRoleRepository
    {
        List<SysRole> GetSysRoleList();
        List<string> GetSysRoleNameByUserId(long? userId);
        List<SysRole> GetSysRoleList(int pageNum, int pageSize, SysRole sysRole);
        SysRole GetSysRoleById(long id);
        int Update(SysRole sysRole);
        int Insert(SysRole sysRole);
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
    }
}