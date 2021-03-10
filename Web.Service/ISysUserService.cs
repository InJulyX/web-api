using Web.Model.Database;

namespace Web.Service
{
    public interface ISysUserService
    {
        /// <summary>
        ///     根据用户名查询用户信息
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        SysUser GetSysUserByUserName(string username);

        /// <summary>
        ///     根据用户ID查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SysUser GetSysUserByUserId(long? id);

        /// <summary>
        ///     根据用户名密码查询用户信息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        SysUser Login(string username, string password);
    }
}