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
    /// LSB嵌入方法类
    /// </summary>
    class LSB_Process
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
        /// lsb信息隐藏，传入源图片地址、目的地址，二进制字符串和模式信息 进行信息隐藏。
        /// </summary>
        /// <param name="img_path">图片源地址</param>
        /// <param name="target_path">图片目的地之</param>
        /// <param name="bin_str">二进制字符串</param>
        /// <param name="mod_set">模式设置：1为在R图层上嵌入，2为在G图层上嵌入，3在B图层上嵌入。</param>
        /// <returns>嵌入长度-模式</returns>

        public static string lsb_process(string img_path, string target_path, string bin_str, int mod_set)
        {



            Mat FistMat = new Mat(img_path, ImreadModes.Color);//读取图片,颜色为彩色
            var indexer = FistMat.GetGenericIndexer<Vec3b>();  //便于像素操作 之后访问indexer来修改像素值
            var array_mat = FistMat.Split();
            

            //Mat temp = new Mat(FistMat, new Rect(0, 0, 10, 15));




            int number = 0;  //已经嵌入的二进制数量
            int wait_x = 0, wait_y = 0;   //待嵌入坐标
            //int sert_number = 0; //待嵌入坐标的已经嵌入的数据  
            while (number < bin_str.Length)
            {

                //indexer[y,x]
                var temp_vec = indexer[wait_y, wait_x];

                //具体嵌入操作
                if (mod_set == 1)
                {
                    byte temp_number = temp_vec.Item2;
                    if (bin_str[number] == '0')
                    {
                        //System.Console.WriteLine('0');
                        temp_number = (byte)(temp_number / 2);
                        temp_number = (byte)(temp_number * 2);

                        //System.Console.WriteLine(temp_number);

                        temp_vec.Item2 = temp_number;
                    }
                    else
                    {
                        temp_number = (byte)(temp_number / 2);
                        temp_number = (byte)(temp_number * 2 + 1);

                        //System.Console.WriteLine(temp_number);

                        temp_vec.Item2 = temp_number;
                    }
                }
                else if (mod_set == 2)
                {
                    byte temp_number = temp_vec.Item1;
                    if (bin_str[number] == '0')
                    {
                        //System.Console.WriteLine('0');
                        temp_number = (byte)(temp_number / 2);
                        temp_number = (byte)(temp_number * 2);

                        //System.Console.WriteLine(temp_number);

                        temp_vec.Item1 = temp_number;
                    }
                    else
                    {
                        temp_number = (byte)(temp_number / 2);
                        temp_number = (byte)(temp_number * 2 + 1);

                        // System.Console.WriteLine(temp_number);

                        temp_vec.Item1 = temp_number;
                    }

                }
                else
                {
                    byte temp_number = temp_vec.Item0;

                    if (bin_str[number] == '0')
                    {
                        //System.Console.WriteLine('0');
                        temp_number = (byte)(temp_number / 2);
                        temp_number = (byte)(temp_number * 2);

                        //System.Console.WriteLine(temp_number);

                        temp_vec.Item0 = temp_number;
                    }
                    else
                    {
                        temp_number = (byte)(temp_number / 2);
                        temp_number = (byte)(temp_number * 2 + 1);

                        // System.Console.WriteLine(temp_number);

                        temp_vec.Item0 = temp_number;
                    }

                }



                indexer[wait_y, wait_x] = temp_vec;
                //FistMat.Set<Vec3b>(wait_y,wait_x,temp_vec);

                number++;
                wait_x++;
                if (wait_x >= FistMat.Width)
                {
                    wait_x = 0;
                    wait_y++;
                    if (wait_y >= FistMat.Height)
                    {
                        if (number == FistMat.Width * FistMat.Height)
                        {

                        }
                        else
                        {
                            throw new Exception("图像嵌入过界了，数据过多。");
                        }

                    }
                }
            }

            Cv2.ImWrite(target_path, FistMat);


            //System.Console.WriteLine(bin_str);
            //System.Console.ReadLine();
            //return;
            string result = "";
            result = result + bin_str.Length.ToString() + "-" + mod_set.ToString();
            return result;

        }

        /// <summary>
        /// lsb信息提取，传入待提取图片地址，提取的数据保存地址，待提取的数据长度，模式。
        /// </summary>
        /// <param name="img_path">图片地址</param>
        /// <param name="file_path">保存地址</param>
        /// <param name="length">待提取数据长度</param>
        /// <param name="mod_set">模式,具体解释请看lsb_process</param>
        public static void lsb_converse(string img_path, string file_path, int length, int mod_set)
        {
            Mat FistMat = new Mat(img_path, ImreadModes.Color);//读取图片,颜色为彩色
            var indexer = FistMat.GetGenericIndexer<Vec3b>();  //便于像素操作 之后访问indexer来修改像素值


            //Mat temp = new Mat(FistMat, new Rect(0, 0, 10, 15));

            int number = 0;  //已经提取的二进制数量
            int wait_x = 0, wait_y = 0;   //待提取数据坐标
            //int sert_number = 0; //待嵌入坐标的已经嵌入的数据
            string all_str = "";  // 将提取出来的二进制形式字符串保存到这里
            while (number < length)
            {
                var temp_vec = indexer[wait_y, wait_x];
                //具体嵌入操作
                if (mod_set == 1)
                {
                    byte temp_number = temp_vec.Item2;
                    byte number_last = (byte)(temp_number % 2);
                    if (number_last == 0)
                    {
                        all_str = all_str + "0";
                    }
                    else if (number_last == 1)
                    {
                        all_str = all_str + "1";
                    }

                }
                else if (mod_set == 2)
                {
                    byte temp_number = temp_vec.Item1;
                    byte number_last = (byte)(temp_number % 2);
                    if (number_last == 0)
                    {
                        all_str = all_str + "0";
                    }
                    else if (number_last == 1)
                    {
                        all_str = all_str + "1";
                    }

                }
                else
                {
                    byte temp_number = temp_vec.Item0;
                    byte number_last = (byte)(temp_number % 2);
                    if (number_last == 0)
                    {
                        all_str = all_str + "0";
                    }
                    else if (number_last == 1)
                    {
                        all_str = all_str + "1";
                    }



                }

                number++;
                wait_x++;
                if (wait_x >= FistMat.Width)
                {
                    wait_x = 0;
                    wait_y++;
                    if (wait_y >= FistMat.Height)
                    {
                        if (number == FistMat.Width * FistMat.Height)
                        {

                        }
                        else
                        {
                            throw new Exception("图像提取过界了。");
                        }

                    }
                }



            }


            //System.Console.WriteLine(all_str);
            // 二进制字符串转换成byte数组，写入文件
            var file_ = new FileStream(file_path, FileMode.Create, FileAccess.Write);
            //File.WriteAllBytes()
            var bytess = from_binStr_toBytes(all_str);
            file_.Write(bytess, 0, bytess.Length);
            file_.Close();


            //return;
        }

        /// <summary>
        /// 对密钥进行解密，传入加密返回的字符串
        /// </summary>
        /// <param name="mod_set"></param>
        /// <returns>返回list int</returns>
        public static int[] lsb_decrype(string mod_set)
        {
            //List<int> temp = new List<int>();
            var temp_2 = mod_set.Split('-');
            int[] temp_int = new int[2];
            temp_int[0] = Convert.ToInt32(temp_2[0]);
            temp_int[1] = Convert.ToInt32(temp_2[1]);



            return temp_int;
        }
    }
}
