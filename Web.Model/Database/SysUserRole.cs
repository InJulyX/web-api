using SqlSugar;

namespace Web.Model.Database
{
    [SugarTable("sys_user_role")]
    public class SysUserRole
    {
        [SugarColumn(IsPrimaryKey = true, ColumnName = "user_id")]
        public long UserId { get; set; }

        [SugarColumn(IsPrimaryKey = true, ColumnName = "role_id")]
        public long RoleId { get; set; }
    }
}