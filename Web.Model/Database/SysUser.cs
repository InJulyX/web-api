using System;
using System.Collections.Generic;
using SqlSugar;

namespace Web.Model.Database
{
    [SugarTable("sys_user")]
    public class SysUser : BaseModel
    {
        /// <summary>
        ///     自增ID
        /// </summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public long? Id { get; set; }

        /// <summary>
        ///     用户名
        /// </summary>
        [SugarColumn(ColumnName = "username")]
        public string Username { get; set; }

        /// <summary>
        ///     密码
        /// </summary>
        [SugarColumn(ColumnName = "password")]
        public string Password { get; set; }

        /// <summary>
        ///     创建时间
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        ///     email
        /// </summary>
        [SugarColumn(ColumnName = "email")]
        public string Email { get; set; }

        /// <summary>
        ///     别名
        /// </summary>
        [SugarColumn(ColumnName = "nick_name")]
        public string NickName { get; set; }

        /// <summary>
        ///     状态
        /// </summary>
        [SugarColumn(ColumnName = "status")]
        public string Status { get; set; }

        /// <summary>
        ///     手机号码
        /// </summary>
        [SugarColumn(ColumnName = "phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        ///     备注
        /// </summary>
        [SugarColumn(ColumnName = "remark")]
        public string Remark { get; set; }

        /// <summary>
        ///     角色ID列表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<long> RoleIds { get; set; }
    }
}