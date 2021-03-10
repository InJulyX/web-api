using System;
using SqlSugar;

namespace Web.Model.Database
{
    [SugarTable("opera_log")]
    public class OperaLog : BaseModel
    {
        /// <summary>
        ///     自增ID
        /// </summary>
        [SugarColumn(ColumnName = "id", IsIdentity = true, IsPrimaryKey = true)]
        public long Id { get; set; }

        /// <summary>
        ///     用户ID
        /// </summary>
        [SugarColumn(ColumnName = "user_id")]
        public long UserId { get; set; }

        /// <summary>
        ///     用户名
        /// </summary>
        [SugarColumn(ColumnName = "username")]
        public string Username { get; set; }

        /// <summary>
        ///     请求地址
        /// </summary>
        [SugarColumn(ColumnName = "path")]
        public string Path { get; set; }

        /// <summary>
        /// HTTP请求方式
        /// </summary>
        [SugarColumn(ColumnName = "method")]
        public string Method { get; set; }

        /// <summary>
        /// 功能模块
        /// </summary>
        [SugarColumn(ColumnName = "module")]
        public string Module { get; set; }

        /// <summary>
        ///     客户端IP地址
        /// </summary>
        [SugarColumn(ColumnName = "client_ip")]
        public string ClientIp { get; set; }

        /// <summary>
        /// 请求参数
        /// </summary>
        [SugarColumn(ColumnName = "params")]
        public string Params { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        [SugarColumn(ColumnName = "type")]
        public string Type { get; set; }
    }
}