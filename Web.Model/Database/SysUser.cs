using System;
using System.Collections.Generic;
using SqlSugar;

namespace Web.Model.Database
{
    [SugarTable("sys_user")]
    public class SysUser
    {
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public long? Id { get; set; }

        [SugarColumn(ColumnName = "username")] public string Username { get; set; }
        [SugarColumn(ColumnName = "password")] public string Password { get; set; }

        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        [SugarColumn(ColumnName = "email")] public string Email { get; set; }

        [SugarColumn(ColumnName = "nick_name")]
        public string NickName { get; set; }

        [SugarColumn(ColumnName = "status")] public string Status { get; set; }

        [SugarColumn(ColumnName = "phone_number")]
        public string PhoneNumber { get; set; }

        [SugarColumn(ColumnName = "remark")] public string Remark { get; set; }
        [SugarColumn(IsIgnore = true)] public List<long> RoleIds { get; set; }
    }
}