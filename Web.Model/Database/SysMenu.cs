using System;
using System.Collections.Generic;
using SqlSugar;

namespace Web.Model.Database
{
    [SugarTable("sys_menu")]
    public class SysMenu
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true, ColumnName = "menu_id")]
        public long? MenuId { get; set; }

        [SugarColumn(ColumnName = "menu_name")]
        public string MenuName { get; set; }

        [SugarColumn(ColumnName = "parent_id")]
        public long? ParentId { get; set; }

        [SugarColumn(ColumnName = "order_num")]
        public int? OrderNum { get; set; }

        [SugarColumn(ColumnName = "path")] public string Path { get; set; }

        [SugarColumn(ColumnName = "component")]
        public string Component { get; set; }

        [SugarColumn(ColumnName = "is_frame")] public string IsFrame { get; set; }
        [SugarColumn(ColumnName = "is_cache")] public string IsCache { get; set; }

        [SugarColumn(ColumnName = "menu_type")]
        public string MenuType { get; set; }

        [SugarColumn(ColumnName = "perms")] public string Perms { get; set; }
        [SugarColumn(ColumnName = "icon")] public string Icon { get; set; }

        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        [SugarColumn(ColumnName = "status")] public int? Status { get; set; }

        [SugarColumn(IsIgnore = true)] public List<SysMenu> Children { get; set; } = new();
        [SugarColumn(IsIgnore = true)] public Dictionary<string, object> Params { get; set; }
        [SugarColumn(ColumnName = "visible")] public string Visible { get; set; }
    }
}