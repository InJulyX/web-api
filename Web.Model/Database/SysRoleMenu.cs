using SqlSugar;

namespace Web.Model.Database
{
    [SugarTable("sys_role_menu")]
    public class SysRoleMenu
    {
        [SugarColumn(IsPrimaryKey = true, ColumnName = "role_id")]
        public long? RoleId { get; set; }

        [SugarColumn(IsPrimaryKey = true, ColumnName = "menu_id")]
        public long? MenuId { get; set; }
    }
}