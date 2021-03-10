using System;
using System.Collections.Generic;
using SqlSugar;

namespace Web.Model.Database
{
    [SugarTable("sys_role")]
    public class SysRole : BaseModel
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "id")]
        public long Id { get; set; }

        [SugarColumn(ColumnName = "role_name")]
        public string RoleName { get; set; }

        [SugarColumn(ColumnName = "role_str")] public string RoleStr { get; set; }
        [SugarColumn(ColumnName = "status")] public string Status { get; set; }

        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        [SugarColumn(ColumnName = "menu_check_strictly")]
        public bool MenuCheckStrictly { get; set; }

        [SugarColumn(IsIgnore = true)] public List<long> MenuIds { get; set; }
    }
}