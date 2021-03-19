using System;
using System.Collections.Generic;
using SqlSugar;

namespace Web.Model.Database
{
    [SugarTable("sys_role")]
    public class SysRole : BaseModel
    {
        /// <summary>
        ///     主键ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "id")]
        public long Id { get; set; }

        /// <summary>
        ///     角色名称
        /// </summary>
        [SugarColumn(ColumnName = "role_name")]
        public string RoleName { get; set; }

        /// <summary>
        ///     角色字符串
        /// </summary>
        [SugarColumn(ColumnName = "role_str")]
        public string RoleStr { get; set; }

        /// <summary>
        ///     状态
        /// </summary>
        [SugarColumn(ColumnName = "status")]
        public string Status { get; set; }

        /// <summary>
        ///     添加时间
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        [SugarColumn(ColumnName = "menu_check_strictly")]
        public bool MenuCheckStrictly { get; set; }

        /// <summary>
        ///     角色拥有的菜单权限ID
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<long> MenuIds { get; set; }
    }
}