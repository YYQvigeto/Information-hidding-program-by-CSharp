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
    /// 基于混沌系统的dct水印类
    /// </summary>
    class DCT_WaterMark
    {
        /// <summary>
        /// dct嵌入主函数
        /// </summary>
        /// <param name="path_1">载体</param>
        /// <param name="path_2">嵌入后保存在哪里</param>
        /// <param name="binStr">二进制字符串</param>
        /// <returns>返回嵌入长度</returns>
        public static string DCT_process(string path_1,string path_2,string binStr)
        {
            //string res = "";
            Mat FistMat = new Mat(path_1, ImreadModes.Color);
            if (FistMat.Channels() < 3)
            {
                throw new Exception("通道必须大于等于三");
            }

            Mat temp = new Mat();
            /*
            Mat temp2 = FistMat[10,15,10,15];
            索引器返回的是引用，大小为5
            */
            
            FistMat.ConvertTo(temp, MatType.CV_32FC3);
            var matArrays = temp.Split();
            
            var number = DCT_process_OneChannel(matArrays[0], binStr);  //返回实际嵌入数据


            //调试
            /*
            var Little_img_2 = matArrays[0][0, 8, 8, 16];
            var array_2 = General_Lib_Information_hiding.OneChanel_return_array(Little_img_2);
            */




            if (number < binStr.Length)
            {
                var binStr_2 = binStr.Substring(number);
                var number_2 = DCT_process_OneChannel(matArrays[1], binStr_2);
                if(number_2 < binStr_2.Length)
                {
                    var binStr_3 = binStr_2.Substring(number_2);
                    var number_3 = DCT_process_OneChannel(matArrays[2], binStr_3);
                    if(number_3 < binStr_3.Length)
                    {
                        throw new Exception("二进制字符串过长");

                    }
                }
            }
            Mat res_img = new Mat();

            Cv2.Merge(matArrays, res_img);
            res_img.ImWrite(path_2);



            return binStr.Length.ToString();
        }



        /// <summary>
        /// 将二进制字符串嵌入单通道Mat，结果返回实际嵌入的数量
        /// </summary>
        /// <param name="img">单通道浮点数float Mat</param>
        /// <param name="binStr">二进制字符串</param>
        /// <returns>返回实际嵌入的数据</returns>
        public static int DCT_process_OneChannel(Mat img,string binStr)
        {
            int number = 0;  //嵌入数量，或者待嵌入坐标
            int y_1 = 0, x_1 = 0; //待嵌入 8*8矩阵的左上坐标
            int n = 8;   //决定是8*8矩阵

            int img_height = img.Height;    //图像高度
            int img_width = img.Width;      //图像宽度
            if(img_height < n || img_width < n)
            {
                throw new Exception("图像高或宽太小了，小于"+n.ToString());
            }
            
            while(number < binStr.Length)
            {
                /*
                if(number == 63*64-1)
                {
                    System.Console.WriteLine(binStr[number]);
                }*/


                Mat Little_img = img[y_1, y_1 + 8, x_1, x_1 + 8];
                var dct_img = Little_img.Dct();
                // 对比(4,1) 和(3,2)坐标的dct系数，如果当前嵌入的是1则，需要前者大于后者~~
                float number_1 = dct_img.Get<float>(4,1);
                float number_2 = dct_img.Get<float>(3,2);
                int a = 20;
                if(binStr[number] == '1')
                {
                    if(number_1 >= number_2)
                    {
                        if (Math.Abs(number_2 - number_1) <= a)    //添加一个厥值，防止提取过程中出问题
                        {
                            if (number_1 >= number_2)
                            {
                                number_1 += a;
                            }
                            else
                            {
                                number_2 += a;
                            }
                            dct_img.Set<float>(4, 1, number_1);
                            dct_img.Set<float>(3, 2, number_2);
                        }
                        

                    }
                    else
                    {
                        if(Math.Abs(number_2 - number_1) <= a)    //添加一个厥值，防止提取过程中出问题
                        {
                            if(number_1 >= number_2)
                            {
                                number_1 += a;
                            }
                            else
                            {
                                number_2 += a;
                            }
                        }
                        dct_img.Set<float>(4, 1, number_2);
                        dct_img.Set<float>(3, 2, number_1);
                    }
                }
                else
                {
                    if (number_1 >= number_2)
                    {
                        if (Math.Abs(number_2 - number_1) <= a)    //添加一个厥值，防止提取过程中出问题
                        {
                            if (number_1 >= number_2)
                            {
                                number_1 += a;
                            }
                            else
                            {
                                number_2 += a;
                            }
                        }
                        dct_img.Set<float>(4, 1, number_2);
                        dct_img.Set<float>(3, 2, number_1);
                    }
                    else
                    {
                        if (Math.Abs(number_2 - number_1) <= a)    //添加一个厥值，防止提取过程中出问题
                        {
                            if (number_1 >= number_2)
                            {
                                number_1 += a;
                            }
                            else
                            {
                                number_2 += a;
                            }
                            dct_img.Set<float>(4, 1, number_1);
                            dct_img.Set<float>(3, 2, number_2);
                        }
                    }

                }

                var idct_img = dct_img.Idct();
                idct_img = Mat_round(idct_img);


                img[y_1, y_1 + 8, x_1, x_1 + 8] = idct_img;

                /*调试的
                Mat Little_img_2 = img[y_1, y_1 + 8, x_1, x_1 + 8];
                var dct_img_2 = Little_img.Dct();
                var array_2 = General_Lib_Information_hiding.OneChanel_return_array(Little_img_2);
                var dct_2 = General_Lib_Information_hiding.OneChanel_return_array(dct_img_2);
                float number_1_1 = dct_img_2.Get<float>(4, 1);
                float number_2_2 = dct_img_2.Get<float>(3, 2);
                */


                number++;

                //待嵌入矩阵坐标改变
                x_1 += 8;
                if((x_1 + 8) > img_width)
                {
                    x_1 = 0;
                    y_1 += 8;
                    if(y_1 + 8 > img_height)
                    {
                        return number;
                    }
                }
                

            }


            return number;
            
        }


        /// <summary>
        /// dct提取主函数
        /// </summary>
        /// <param name="path_1">待提取图片地址</param>
        /// <param name="number">二进制字符串水印长度</param>
        /// <returns>二进制字符串形式的水印</returns>
        public static string DCT_converse(string path_1,int number)
        {
            string res = "";
            Mat FistMat = new Mat(path_1, ImreadModes.Color);
            if (FistMat.Channels() < 3)
            {
                throw new Exception("通道必须大于等于三");
            }

            Mat temp = new Mat();
            /*
            Mat temp2 = FistMat[10,15,10,15];
            索引器返回的是引用，大小为5
            */

            FistMat.ConvertTo(temp, MatType.CV_32FC3);
            var matArrays = temp.Split();  //三通道分离出来的浮点数mat

            string str_1 = DCT_converse_OneChannel(matArrays[0], number);
            res += str_1;

            if(str_1.Length < number)
            {
                var number_2 = number - str_1.Length;
                string str_2 = DCT_converse_OneChannel(matArrays[1], number_2);
                res += str_2;
                if (str_2.Length < number_2)
                {
                    var number_3 = number_2 - str_2.Length;
                    var str_3 = DCT_converse_OneChannel(matArrays[2], number_3);
                    res += str_3;
                    if (str_3.Length < number_3)
                    {
                        throw new Exception("传入的水印数量过大，无法提取");

                    }
                }
            }


            return res;
        }
        /// <summary>
        /// 处理单通道图像，尽量提取出来
        /// </summary>
        /// <param name="img">float浮点数mat单通道</param>
        /// <param name="bin_length">尽量提出的二进制字符的长度</param>
        /// <returns>返回实际提取出来的二进制字符串</returns>
        public static string DCT_converse_OneChannel(Mat img,int bin_length)
        {
            string res = "";
            int number = 0;  //嵌入数量，或者待嵌入坐标
            int y_1 = 0, x_1 = 0; //待嵌入 8*8矩阵的左上坐标
            int n = 8;   //决定是8*8矩阵

            int img_height = img.Height;    //图像高度
            int img_width = img.Width;      //图像宽度
            if (img_height < n || img_width < n)
            {
                throw new Exception("图像高或宽太小了，小于" + n.ToString());
            }

            while (number < bin_length)
            {
                Mat Little_img = img[y_1, y_1 + 8, x_1, x_1 + 8];
                var dct_img = Little_img.Dct();
                // 对比(4,1) 和(3,2)坐标的dct系数，如果前者大于后者，为'1'，反之为'0'
                float number_1 = dct_img.Get<float>(4, 1);
                float number_2 = dct_img.Get<float>(3, 2);

                if(number_1 >= number_2)
                {
                    res += '1';
                }
                else
                {
                    res += '0';

                }

                number++;

                /*
                Mat Little_img_2 = img[y_1, y_1 + 8, x_1, x_1 + 8];
                var dct_img_2 = Little_img.Dct();
                var array_2 = General_Lib_Information_hiding.OneChanel_return_array(Little_img_2);
                float number_1_1 = dct_img_2.Get<float>(4, 1);
                float number_2_2 = dct_img_2.Get<float>(3, 2);
                */








                //待提取矩阵坐标改变
                x_1 += 8;
                if ((x_1 + 8) > img_width)
                {
                    x_1 = 0;
                    y_1 += 8;
                    if (y_1 + 8 > img_height)
                    {
                        return res;
                    }
                }
                
            }


                return res;
        }



        /// <summary>
        /// 传入单通道 float mat，对它每个元素进行四舍五入
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static Mat Mat_round(Mat temp)
        {
            int height = temp.Rows;
            int width = temp.Cols;
            for(int i = 0;i < height; i++)
            {
                for(int j = 0;j < width; j++)
                {
                    var temp_number = temp.Get<float>(j, i);
                    temp_number = (float)Math.Round(temp_number);
                    temp.Set<float>(j, i, temp_number);

                }
            }
            var arrays = General_Lib_Information_hiding.OneChanel_return_array(temp);




            return temp;
        }


        /// <summary>
        /// 创建license文件，并返回它对应的md5 hash的十六进制字符串
        /// </summary>
        /// <param name="temp">用户信息</param>
        /// <param name="file_name">存储地址</param>
        /// <returns>十六进制字符串</returns>
        public static string Create_License(string temp,string file_name)
        {
            //string res = "";
            var file_1 = new FileStream(file_name, FileMode.Create, FileAccess.Write);
            //var UTF_file_1 = new BinaryWriter(file_1, Encoding.GetEncoding("gb2312")); //使用utf-8格式进行写入
            //UTF_file_1.Write(temp);
            var bytess = System.Text.Encoding.UTF8.GetBytes(temp);   //utf-8格式写入
            file_1.Write(bytess,0,bytess.Length);

            //UTF_file_1.Close();
            file_1.Close();

            var temp_2 = HashHelper.HashFile(file_name, "md5");
            int Hex_bin_length = temp_2.Length;

            //Chaos_Generate.Using_HashStr_toGenerate(temp_2);





            return temp_2;
        }


        /// <summary>
        /// 传入三通道mat，返回dct 8*8矩阵的个数
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static int Max_dct(Mat temp)
        {
            //int n = 0;
            var x = temp.Width / 8;
            var y = temp.Height / 8;

            int x_1 = (int)x;
            int y_1 = (int)y;
            int n = (int)x_1 * y_1 * 3;


            return n;
        }


        /// <summary>
        /// 对比两串二进制字符串，返回对比正确率
        /// </summary>
        /// <param name="temp_1"></param>
        /// <param name="temp_2"></param>
        /// <returns></returns>
        public static double rate_accuracy(string temp_1,string temp_2)
        {
            double res = 0;
            if(temp_1.Length != temp_2.Length)
            {
                throw new Exception("两个字符串长度不一致");

            }
            int n = 0;
            for(int i = 0; i < temp_1.Length; i++)
            {
                if(temp_1[i] == temp_2[i])
                {
                    n++;
                }

            }
            res = n * 1.0 / temp_1.Length;




            return res;
        }








    }
}
