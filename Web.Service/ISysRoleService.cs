using System;
using System.Collections.Generic;
using Web.Model.Database;

namespace Web.Service
{
    public interface ISysRoleService
    {
        /// <summary>
        ///     根据用户ID查询角色列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<string> GetSysRoleNameByUserId(long userId);


        /// <summary>
        ///     分页查询角色列表
        /// </summary>
        /// <param name="sysRole"></param>
        /// <returns></returns>
        Tuple<int, IEnumerable<SysRole>> GetSysRoleListToPage(SysRole sysRole);
    }
}