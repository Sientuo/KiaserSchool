using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KiaserMid
{
    public class MD5Helper
    {
        /// <summary>
        /// MD5字符串加密  --32位
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string GetMD5X2(string txt)
        {
            using (MD5 mi = MD5.Create())
            {
                byte[] buffer = Encoding.Default.GetBytes(txt);
                //开始加密
                byte[] newBuffer = mi.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < newBuffer.Length; i++)
                {
                    sb.Append(newBuffer[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        
        public static string GetMd5(string ConvertString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            var byt = md5.ComputeHash(Encoding.Default.GetBytes(ConvertString));
            string t2 = BitConverter.ToString(byt, 4, 8);
            t2 = t2.Replace("-", "");
            t2 = t2.ToLower();
            return t2;
        }
    }
}
