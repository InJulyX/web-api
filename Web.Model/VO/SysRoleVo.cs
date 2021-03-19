using System.Collections.Generic;

namespace Web.Model.VO
{
    public class SysRoleVo
    {
        /// <summary>
        ///     角色ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///     角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        ///     角色字符串
        /// </summary>
        public string RoleStr { get; set; }

        /// <summary>
        ///     角色状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        ///     拥有的菜单权限ID列表
        /// </summary>
        public List<long> MenuIds { get; set; }

        public bool MenuCheckStrictly { get; set; }
    }
}