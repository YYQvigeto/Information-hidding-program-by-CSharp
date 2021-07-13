using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_1
{
    /// <summary>
    /// 这是混沌系统主类，作用：基于密钥，来产生混沌的伪随机二进制字符串，即"0101010"之类的。
    /// </summary>
    class Chaos_Generate
    {

        /// <summary>
        /// 用户掌握X1（密钥），结果产生二进制字符串，原理为 X_n+1 = A * sin(X_n-X_B)^2
        /// </summary>
        /// <param name="A"></param>
        /// <param name="X_B"></param>
        /// <param name="X_1">密钥</param>
        /// <param name="number">二进制字符串长度</param>
        /// <returns></returns>
        public static string Generate_StrBin(int A,int X_B,int X_1,int number)
        {
            string res = "";
            double temp = X_1;

            for(int i = 0; i < number; i++)
            {
                temp = A * Math.Pow(Math.Sin(temp - X_B),2);
                if(temp >= A * 2 / 3)
                {
                    res += '1';
                }
                else
                {
                    res += '0';
                }

            }


            return res;
            
        }

        /// <summary>
        /// 使用md5的hash的十六进制字符串作为密钥，产生基于混沌系统的伪随机二进制字符串
        /// </summary>
        /// <param name="HashStr">32长度的md5 十六进制字符串</param>
        /// <param name="max_dct">待处理图像的dct矩阵个数  (最多)</param>
        /// <returns>伪随机二进制字符串</returns>
        public static string Using_HashStr_toGenerate(string HashStr , int max_dct)
        {
            //string res = "";

            int A = Math.Abs( Convert.ToInt32(HashStr.Substring(0, 8),16)) % 100;
            if(A < 10)
            {
                A += 10;
            }

            int X_B = Math.Abs(Convert.ToInt32(HashStr.Substring(8, 8), 16)) % 100;
            if(X_B < 10)
            {
                X_B += 10;
            }
            int X_1 = Math.Abs(Convert.ToInt32(HashStr.Substring(16, 8), 16)) % 100;
            if(X_1 < 10)
            {
                X_1 += 10;
            }
            int number = Math.Abs(Convert.ToInt32(HashStr.Substring(24, 8), 16));
            number = number % max_dct;
            if(number < (int)(0.5 * max_dct))
            {
                number = (int)(0.7 * max_dct);
            }
            var bin_str = Generate_StrBin(A, X_B, X_1, number);






            return bin_str;

        }





    }
}
