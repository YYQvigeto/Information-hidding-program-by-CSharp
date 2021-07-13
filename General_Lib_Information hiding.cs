using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace lib_1
{
    /// <summary>
    /// 图像处理的一些公用方法
    /// </summary>
    class General_Lib_Information_hiding
    {
        /// <summary>
        /// 读取文件，返回二进制字符串
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>二进制字符串</returns>
        public static string get_binStr_from_file(string path)
        {
            string temp = "";
            byte[] temp_2 = System.IO.File.ReadAllBytes(path);
            foreach (byte i in temp_2)
            {
                string binary = Convert.ToString(i, 2).PadLeft(8, '0');
                temp += binary;
            }


            return temp;
        }


        /// <summary>
        /// 二进制字符串转换成byte数组
        /// </summary>
        /// <param name="strings">二进制字符串</param>
        /// <returns>byte数组</returns>
        public static byte[] from_binStr_toBytes(string strings)
        {
            byte[] temp;
            //temp = new byte[]
            int n_1 = strings.Length % 8;
            if (n_1 != 0)
            {
                throw new Exception("二进制字符串不是8的倍数！");
                //return null;
            }
            int n_2 = (int)(strings.Length / 8);
            temp = new byte[n_2];

            int i = 0;
            for (i = 0; i < n_2; i++)
            {
                string tempStr = strings.Substring(i * 8, 8);
                byte tempByte = Convert.ToByte(tempStr, 2);
                temp[i] = tempByte;


            }

            return temp;
        }


        /// <summary>
        /// 将单通道mat类，转换成二维array
        /// </summary>
        /// <param name="img_mat">单通道mat</param>
        /// <returns>返回二维float数组</returns>
        public static float[,] OneChanel_return_array(Mat img_mat)
        {
            int channels = img_mat.Channels();
            if(channels != 1)
            {
                throw new Exception("通道不为单通道");
            }

            var size = img_mat.Size();
            float[,] result= new float[img_mat.Height,img_mat.Width];

            int i = 0, j = 0;
            for(i = 0;i < img_mat.Height; i++)
            {
                for(j = 0; j < img_mat.Width; j++)
                {
                    result[i,j] = img_mat.Get<float>(j,i);
                }
            }


            




            return result;
        }














    }
}
