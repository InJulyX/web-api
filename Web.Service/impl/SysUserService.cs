using Web.Common;
using Web.Model.Database;
using Web.Repository;

namespace Web.Service.impl
{
    public class SysUserService : ISysUserService
    {
        private readonly ISysUserRepository _sysUserRepository;

        public SysUserService(ISysUserRepository sysUserRepository)
        {
            _sysUserRepository = sysUserRepository;
        }

        /// <summary>
        ///     根据用户名查询用户信息
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public SysUser GetSysUserByUserName(string username)
        {
            return _sysUserRepository.GetUser(new SysUser {Username = username});
        }

        /// <summary>
        ///     根据用户ID查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysUser GetSysUserByUserId(long? id)
        {
            return _sysUserRepository.GetUser(new SysUser {Id = id});
        }

        /// <summary>
        ///     根据用户名密码查询用户信息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public SysUser Login(string username, string password)
        {
            return _sysUserRepository.GetUser(new SysUser
            {
                Username = username,
                Password = StrHash.GetMd5Hash32(password)
            });
        }
    }
}