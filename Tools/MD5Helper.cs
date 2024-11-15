using System;
using System.Security.Cryptography;
using System.Text;
namespace Common
{
    public static class MD5Helper
    {
        /// <summary>
        /// 生成字符串的 MD5 哈希值
        /// </summary>
        /// <param name="input">要加密的字符串</param>
        /// <returns>MD5 哈希后的字符串</returns>
        public static string GetMd5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                // 将输入字符串转换为字节数组并计算哈希
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

                // 将字节数组转换为 16 进制字符串
                StringBuilder sb = new StringBuilder();
                foreach (byte b in data)
                {
                    sb.Append(b.ToString("x2")); // 格式化为两位小写十六进制
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// 验证输入的字符串和给定的 MD5 哈希值是否匹配
        /// </summary>
        /// <param name="input">要验证的字符串</param>
        /// <param name="hash">给定的 MD5 哈希值</param>
        /// <returns>是否匹配</returns>
        public static bool VerifyMd5Hash(string input, string hash)
        {
            string hashOfInput = GetMd5Hash(input);

            // 比较两个哈希值
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashOfInput, hash) == 0;
        }
    }
}
