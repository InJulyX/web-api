using System;

namespace Web.Model.VO
{
    public class SysUserVo
    {
        /// <summary>
        ///     用户ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///     用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     别名
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        ///     手机号码
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        ///     用户状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        ///     用户创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}