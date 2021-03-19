using System;
using System.Collections.Generic;
using Web.Model.Database;
using Web.Model.VO;

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

        /// <summary>
        ///     根据ID查询
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        SysRoleVo GetSysRoleById(long roleId);
    }
}