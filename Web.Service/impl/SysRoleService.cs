using System;
using System.Collections.Generic;
using Web.Model.Database;
using Web.Repository;

namespace Web.Service.impl
{
    public class SysRoleService : ISysRoleService
    {
        private readonly ISysRoleRepository _sysRoleRepository;

        public SysRoleService(ISysRoleRepository sysRoleRepository)
        {
            _sysRoleRepository = sysRoleRepository;
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
    }
}