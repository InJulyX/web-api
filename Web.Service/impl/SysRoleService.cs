using System;
using System.Collections.Generic;
using AutoMapper;
using Web.Model.Database;
using Web.Model.VO;
using Web.Repository;

namespace Web.Service.impl
{
    public class SysRoleService : ISysRoleService
    {
        private readonly IMapper _mapper;
        private readonly ISysRoleRepository _sysRoleRepository;

        public SysRoleService(ISysRoleRepository sysRoleRepository, IMapper mapper)
        {
            _sysRoleRepository = sysRoleRepository;
            _mapper = mapper;
        }

        /// <summary>
        ///     根据用户ID查询角色列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<string> GetSysRoleNameByUserId(long userId)
        {
            return _sysRoleRepository.GetSysRoleNameListByUserId(userId);
        }

        /// <summary>
        ///     分页查询角色列表
        /// </summary>
        /// <param name="sysRole"></param>
        /// <returns></returns>
        public Tuple<int, IEnumerable<SysRole>> GetSysRoleListToPage(SysRole sysRole)
        {
            var count = 0;
            var data = _sysRoleRepository.GetSysRoleListToPage(sysRole, ref count);
            var result = new Tuple<int, IEnumerable<SysRole>>(count, data);
            return result;
        }

        /// <summary>
        ///     根据ID查询
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public SysRoleVo GetSysRoleById(long roleId)
        {
            var data = _sysRoleRepository.GetSysRole(new SysRole {Id = roleId});
            return _mapper.Map<SysRoleVo>(data);
        }
    }
}