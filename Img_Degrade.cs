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
    /// 图像降质方法类，将秘密图像嵌入载体图像中，其中通道数一样，并且载体总像素数量要大于秘密图像
    /// </summary>
    class Img_Degrade
    {
        /// <summary>
        /// 图像降质函数
        /// </summary>
        /// <param name="path_1">载体图像</param>
        /// <param name="path_2">秘密图像</param>
        /// <param name="target">生成图像需要保存的地址</param>
        /// <param name="n_">降质程度，1-8，越小隐藏数据越少，建议为4</param>
        /// <returns>密钥-秘密图像高度-宽度</returns>
        public static string Degrade_process(string path_1,string path_2,string target, int n_ = 4)
        {
            

            Mat FistMat = new Mat(path_1, ImreadModes.Color);
            Mat SecondMat = new Mat(path_2, ImreadModes.Color);
            if(FistMat.Channels() <3 || SecondMat.Channels() <3)
            {
                throw new Exception("图形通道必须是3通道以上");
            }
            if(FistMat.Height * FistMat.Width < SecondMat.Height * SecondMat.Width)
            {
                throw new Exception("载体过小");
            }



            var FistIndexer = FistMat.GetGenericIndexer<Vec3b>();
            var SecondIndexer = SecondMat.GetGenericIndexer<Vec3b>();
            int n = n_;      //决定降质程度  数值越低，秘密信息越隐蔽，但是提取不好看

            int number = 0; //已经嵌入的像素数量 待嵌入的像素索引(0--length-1)
            int x_1 = 0, y_1 = 0;   //载体图像的待嵌入坐标像素
            int x_2 = 0, y_2 = 0;   //秘密图像的待嵌入坐标图像

            while(number < SecondMat.Height * SecondMat.Width)
            {

                


                var temp_array_1 = get_index(number,FistMat.Height,FistMat.Width);
                x_1 = temp_array_1[1];
                y_1 = temp_array_1[0];

                var temp_array_2 = get_index(number, SecondMat.Height, SecondMat.Width);
                x_2 = temp_array_2[1];
                y_2 = temp_array_2[0];

                
                var ZaiTi_valuess = FistIndexer[y_1, x_1];
                var valuess = SecondIndexer[y_2, x_2];


                byte B_value = valuess.Item0;          //暂时保存秘密像素的信息
                byte G_value = valuess.Item1;
                byte R_value = valuess.Item2;

                // 将秘密像素的前n位提取，并和载体像素的后n位像素替换
                
                int temp_B = (int)(B_value / Math.Pow(2, 8-n));
                int temp_G = (int)(G_value / Math.Pow(2, 8-n));
                int temp_R = (int)(R_value / Math.Pow(2, 8-n));

                
                ZaiTi_valuess.Item0 = (byte)(ZaiTi_valuess.Item0 - ZaiTi_valuess.Item0 % (int)Math.Pow(2, n) + temp_B);
                ZaiTi_valuess.Item1 = (byte)(ZaiTi_valuess.Item1 - ZaiTi_valuess.Item1 % (int)Math.Pow(2, n) + temp_G);
                ZaiTi_valuess.Item2 = (byte)(ZaiTi_valuess.Item2 - ZaiTi_valuess.Item2 % (int)Math.Pow(2, n) + temp_R);
                
                FistIndexer[y_1, x_1] = ZaiTi_valuess;


                number++;
            }
            //System.Console.ReadLine();
            FistMat.ImWrite(target);
            return (n.ToString()+"-"+SecondMat.Height.ToString() + "-" + SecondMat.Width.ToString());
        }


        /// <summary>
        /// 从图片中提取出秘密信息，图像降质反操作
        /// </summary>
        /// <param name="path_1">待提取载体图片</param>
        /// <param name="path_2">提取出来的秘密图片保存地址</param>
        /// <param name="keyss">密钥：降质程度-秘密图像高度-宽度</param>
        /// <returns></returns>
        public static string Degrade_converse(string path_1, string path_2, string keyss)
        {
            var key_array = keyss.Split('-');
            int n = Convert.ToInt32(key_array[0]);   //降质数值
            int height = Convert.ToInt32(key_array[1]); //秘密图像高度
            int width = Convert.ToInt32(key_array[2]); //宽度

            Mat new_img = new Mat(height,width,MatType.CV_8UC3);
            Mat old_img = new Mat(path_1, ImreadModes.Color);

            // 此方法只支持 3通道以及以上的图像
            if(old_img.Channels() < 3)
            {
                throw new Exception("图像通道小于3");
            }
            var new_indexer = new_img.GetGenericIndexer<Vec3b>();
            var old_indexer = old_img.GetGenericIndexer<Vec3b>();

            int number = 0; //已经提取的像素数量 待提取的像素索引(0--length-1)
            int x_1 = 0, y_1 = 0;   //载体图像的待提取坐标像素
            int x_2 = 0, y_2 = 0;   //秘密图像的待存储坐标图像

            while (number < height * width)
            {

                


                var temp_array_1 = get_index(number, old_img.Height, old_img.Width);
                x_1 = temp_array_1[1];
                y_1 = temp_array_1[0];

                var temp_array_2 = get_index(number, new_img.Height, new_img.Width);
                x_2 = temp_array_2[1];
                y_2 = temp_array_2[0];

                var valuess = new_indexer[y_2, x_2];
                var ZaiTi_valuess = old_indexer[y_1, x_1];

                int temp_B = (int)(ZaiTi_valuess.Item0 % Math.Pow(2, n));
                int temp_G = (int)(ZaiTi_valuess.Item1 % Math.Pow(2, n));
                int temp_R = (int)(ZaiTi_valuess.Item2 % Math.Pow(2, n));

                valuess.Item0 = (byte)(temp_B * Math.Pow(2,8-n));
                valuess.Item1 = (byte)(temp_G * Math.Pow(2, 8 - n));
                valuess.Item2 = (byte)(temp_R * Math.Pow(2, 8 - n));

                new_indexer[y_2, x_2] = valuess;

                number++;

            }

            new_img.ImWrite(path_2);
            return null;
        }

        /// <summary>
        /// 传入像素的索引，获取在图像中坐标
        /// </summary>
        /// <param name="n">索引（0-length-1）</param>
        /// <param name="height">图像的高度</param>
        /// <param name="width">图像的宽度</param>
        /// <returns>数组,y,x</returns>
        public static int[] get_index(int n ,int height,int width)
        {
            int[] res = new int[2];
            int numbers = n + 1;   //第几个
            int temp_x = numbers % width;
            int temp_y = 0;
            if(temp_x == 0)
            {
                temp_x = width;
                temp_y = (int)(numbers / width);

            }
            else
            {
                temp_y = (int)((numbers - temp_x) / width)+1;

            }

            res[0] = temp_y - 1;
            res[1] = temp_x - 1;




            return res;

        }





    }
}
