using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_1
{

    /// <summary>
    /// Hash辅助类
    /// </summary>
    public class HashHelper
    {
        /// <summary>
        /// 计算文件的 MD5 值
        /// </summary>
        /// <param name="fileName">要计算 MD5 值的文件名和路径</param>
        /// <returns>MD5 值16进制字符串</returns>
        public static string MD5File(string fileName)
        {
            return HashFile(fileName, "md5");
        }

        /// <summary>
        /// 计算文件的 sha1 值
        /// </summary>
        /// <param name="fileName">要计算 sha1 值的文件名和路径</param>
        /// <returns>sha1 值16进制字符串</returns>
        public static string SHA1File(string fileName)
        {
            return HashFile(fileName, "sha1");
        }

        /// <summary>
        /// 计算文件的哈希值
        /// </summary>
        /// <param name="fileName">要计算哈希值的文件名和路径</param>
        /// <param name="algName">算法:sha1,md5</param>
        /// <returns>哈希值16进制字符串</returns>
        public static string HashFile(string fileName, string algName)
        {
            if (!System.IO.File.Exists(fileName))
            {
                return string.Empty;
            }

            System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            byte[] hashBytes = HashData(fs, algName);
            fs.Close();
            return ByteArrayToHexString(hashBytes);
        }

        /// <summary>
        /// 计算哈希值
        /// </summary>
        /// <param name="stream">要计算哈希值的 Stream</param>
        /// <param name="algName">算法:sha1,md5</param>
        /// <returns>哈希值字节数组</returns>
        public static byte[] HashData(System.IO.Stream stream, string algName)
        {
            System.Security.Cryptography.HashAlgorithm algorithm;
            if (algName == null)
            {
                throw new ArgumentNullException("algName 不能为 null");
            }

            if (string.Compare(algName, "sha1", true) == 0)
            {
                algorithm = System.Security.Cryptography.SHA1.Create();
            }
            else
            {
                if (string.Compare(algName, "md5", true) != 0)
                {
                    throw new Exception("algName 只能使用 sha1 或 md5");
                }
                algorithm = System.Security.Cryptography.MD5.Create();
            }

            return algorithm.ComputeHash(stream);
        }

        /// <summary>
        /// 字节数组转换为16进制表示的字符串
        /// </summary>
        public static string ByteArrayToHexString(byte[] buf)
        {
            return BitConverter.ToString(buf).Replace("-", "");
        }
        
        
        
        
        /// <summary>
        /// 将字符串转换成utf-8流，然后使用md5/sha1进行hash
        /// </summary>
        /// <param name="string_temp">要计算哈希值的 string</param>
        /// <param name="algName">算法:sha1,md5</param>
        /// <returns>哈希值字节数组</returns>
        
        public static byte[] HashStrings(string string_temp,string algName)
        {
            //byte[] byte_temp;
            var strToByte = System.Text.Encoding.UTF8.GetBytes(string_temp);
            System.IO.MemoryStream temp_2 = new System.IO.MemoryStream(strToByte);
            var hash_ = HashHelper.HashData(temp_2, algName);
            return hash_;
        }
         


    }






    
}
