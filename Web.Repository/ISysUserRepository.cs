using System.Collections.Generic;
using Web.Model.Database;

namespace Web.Repository
{
    public interface ISysUserRepository
    {
        /// <summary>
        ///     用户查询
        /// </summary>
        /// <param name="sysUser"></param>
        /// <returns></returns>
        SysUser GetUser(SysUser sysUser);

        /// <summary>
        ///     添加用户并返回用户ID
        /// </summary>
        /// <param name="sysUser"></param>
        /// <returns></returns>
        long InsertSysUserReturnId(SysUser sysUser);

        /// <summary>
        ///     分页查询用户列表
        /// </summary>
        /// <param name="sysUser"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        IEnumerable<SysUser> GetSysUserListToPage(SysUser sysUser, ref int count);
    }
}