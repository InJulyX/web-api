using System;
using System.Collections.Generic;
using Web.Model.Database;
using Web.Model.VO;

namespace Web.Service
{
    public interface ISysUserService
    {
        /// <summary>
        ///     根据用户ID查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SysUserVo GetSysUserByUserId(long id);

        /// <summary>
        ///     根据用户名密码查询用户信息
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        SysUserVo Login(string username, string password);

        /// <summary>
        ///     分页查询用户列表
        /// </summary>
        /// <param name="sysUser"></param>
        /// <returns></returns>
        Tuple<int, IEnumerable<SysUserVo>> GetSysUserListToPage(SysUser sysUser);
    }
}