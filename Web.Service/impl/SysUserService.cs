using System;
using System.Collections.Generic;
using AutoMapper;
using Web.Common;
using Web.Model.Database;
using Web.Model.VO;
using Web.Repository;

namespace Web.Service.impl
{
    public class SysUserService : ISysUserService
    {
        private readonly IMapper _mapper;
        private readonly ISysUserRepository _sysUserRepository;

        public SysUserService(ISysUserRepository sysUserRepository, IMapper mapper)
        {
            _sysUserRepository = sysUserRepository;
            _mapper = mapper;
        }

        /// <summary>
        ///     根据用户ID查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysUserVo GetSysUserByUserId(long id)
        {
            var sysUser = _sysUserRepository.GetUser(new SysUser {Id = id});
            return _mapper.Map<SysUserVo>(sysUser);
        }

        /// <summary>
        ///     根据用户名密码查询用户信息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public SysUserVo Login(string username, string password)
        {
            var sysUser = new SysUser
            {
                Username = username,
                Password = StrHash.GetMd5Hash32(password)
            };
            var data = _sysUserRepository.GetUser(sysUser);
            return _mapper.Map<SysUserVo>(data);
        }

        /// <summary>
        ///     分页查询用户列表
        /// </summary>
        /// <param name="sysUser"></param>
        /// <returns></returns>
        public Tuple<int, IEnumerable<SysUserVo>> GetSysUserListToPage(SysUser sysUser)
        {
            var count = 0;
            var data = _sysUserRepository.GetSysUserListToPage(sysUser, ref count);
            return new Tuple<int, IEnumerable<SysUserVo>>(count, _mapper.Map<IEnumerable<SysUserVo>>(data));
        }
    }
}