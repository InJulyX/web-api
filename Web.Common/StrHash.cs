using System;
using System.Security.Cryptography;
using System.Text;

namespace Web.Common
{
    public static class StrHash
    {
        /// <summary>
        ///     生成32位小写MD5
        /// </summary>
        /// <param name="str">MD5字符串</param>
        /// <returns></returns>
        public static string GetMd5Hash32(string str)
        {
            var sb = new StringBuilder();
            using var md5 = new MD5CryptoServiceProvider();
            var data = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            foreach (var t in data) sb.Append(t.ToString("X2"));

            return sb.ToString();
        }

        /// <summary>
        ///     生成随机字符串
        /// </summary>
        /// <param name="length">字符串长度</param>
        /// <returns></returns>
        public static string GenerateRandomNumber(int length)
        {
            char[] constant =
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u',
                'v', 'w', 'x', 'y', 'z',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U',
                'V', 'W', 'X', 'Y', 'Z'
            };
            var newRandom = new StringBuilder(62);
            var rd = new Random();
            for (var i = 0; i < length; i++) newRandom.Append(constant[rd.Next(62)]);

            return newRandom.ToString();
        }
    }
}