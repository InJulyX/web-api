namespace Web.Model.VO
{
    public class OperaLogVo
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
        ///     HTTP请求方式
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        ///     请求功能模块
        /// </summary>
        public string Module { get; set; }

        /// <summary>
        ///     请求路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        ///     请求参数
        /// </summary>
        public string Params { get; set; }

        /// <summary>
        ///     操作类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     操作时间
        /// </summary>
        public string CreateTime { get; set; }
    }
}