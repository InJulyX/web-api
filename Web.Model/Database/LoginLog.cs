using System;
using SqlSugar;

namespace Web.Model.Database
{
    [SugarTable("login_log")]
    public class LoginLog : BaseModel
    {
        /// <summary>
        ///     自增ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "id")]
        public long? Id { get; set; }

        /// <summary>
        ///     用户名
        /// </summary>
        [SugarColumn(ColumnName = "username")]
        public string Username { get; set; }

        /// <summary>
        ///     客户端IP
        /// </summary>
        [SugarColumn(ColumnName = "client_ip")]
        public string ClientIp { get; set; }

        /// <summary>
        ///     登录状态
        /// </summary>
        [SugarColumn(ColumnName = "status")]
        public int? Status { get; set; }

        /// <summary>
        ///     操作信息
        /// </summary>
        [SugarColumn(ColumnName = "msg")]
        public string Msg { get; set; }

        /// <summary>
        ///     客户端操作系统
        /// </summary>
        [SugarColumn(ColumnName = "os")]
        public string Os { get; set; }

        /// <summary>
        ///     客户端浏览器
        /// </summary>
        [SugarColumn(ColumnName = "browser")]
        public string Browser { get; set; }

        /// <summary>
        ///     客户端浏览器版本
        /// </summary>
        [SugarColumn(ColumnName = "browser_version")]
        public string BrowserVersion { get; set; }

        /// <summary>
        ///     登录时间
        /// </summary>
        [SugarColumn(ColumnName = "login_time")]
        public DateTime? LoginTime { get; set; }
    }
}