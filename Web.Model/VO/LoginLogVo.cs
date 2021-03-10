using System;

namespace Web.Model.VO
{
    public class LoginLogVo
    {
        /// <summary>
        ///     日志ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///     用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     客户端IP
        /// </summary>
        public string ClientIp { get; set; }

        /// <summary>
        ///     客户端浏览器
        /// </summary>
        public string Browser { get; set; }

        /// <summary>
        ///     客户端浏览器版本
        /// </summary>
        public string BrowserVersion { get; set; }

        /// <summary>
        ///     登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }

        /// <summary>
        ///     登录信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        ///     登录状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        ///     客户端系统
        /// </summary>
        public string Os { get; set; }
    }
}