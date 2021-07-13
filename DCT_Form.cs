using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OpenCvSharp;
using System.IO;
namespace 简单的信息隐藏程序
{
    public partial class DCT_Form : Form
    {

        public Login lg_form = null;
        public int flag_conn = 0;  //是否连接了数据库，如果为1则连上了

        public MySqlConnection conn;   //暂存连接测试成功后的conn对象

        public double rate_100 = 0;  //水印正确率

        public DCT_Form()
        {
            InitializeComponent();
        }
        public DCT_Form(Login login)
        {
            InitializeComponent();
            lg_form = login;

        }

        private void 数据库连接设置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DB_connect temp = new DB_connect(lg_form,this);
            temp.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string key_str = textBox1.Text;
            string path;
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
                //var temp_hash = lib_1.DCT_WaterMark.Create_License(key_str,path);
                saveBox1.Text = path;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                string key_str = textBox1.Text;
                string path = saveBox1.Text;
                var temp_hash = lib_1.DCT_WaterMark.Create_License(key_str, path);
                MessageBox.Show("密钥证书创建成功");
            }
            catch(Exception ex)
            {
                MessageBox.Show("密钥证书创建失败："+ex.Message);
            }


            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string key_str = textBox1.Text;
            string path;
            string path_2;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                //var temp_hash = lib_1.DCT_WaterMark.Create_License(key_str,path);
                openBox1.Text = path;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path_2 = openFileDialog1.FileName;
                    openBox2.Text = path_2;

                    var img_ = Image.FromFile(path);
                    panel1.BackgroundImage = img_;


                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveBox2.Text = saveFileDialog1.FileName;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                var temp_hash = lib_1.HashHelper.HashFile(openBox2.Text, "md5");
                Mat img = new Mat(openBox1.Text);

                var max_dct = lib_1.DCT_WaterMark.Max_dct(img);
                var temp_2 = lib_1.Chaos_Generate.Using_HashStr_toGenerate(temp_hash, max_dct);
                var length = temp_2.Length;
                var res_1 = lib_1.DCT_WaterMark.DCT_process(openBox1.Text, saveBox2.Text, temp_2);


                var img_ = Image.FromFile(saveBox2.Text);
                panel2.BackgroundImage = img_;
                //panel1.BackgroundImage = img_;
                MessageBox.Show("DCT嵌入成功");

                //数据存储
                if (flag_conn == 1)
                {
                    //查询 DCT库中的DCT_name 表，中的条目数量，将文件名和md5写入
                    try
                    {
                        conn.Open();
                        string temp_sql = "select count(*) from DCT.DCT_" + this.lg_form.user.userName;

                        MySqlCommand cmd = new MySqlCommand(temp_sql, conn);
                        var obj = cmd.ExecuteScalar();
                        if (obj != null)
                        {
                            int number = Convert.ToInt32(obj.ToString()); //表中的条目数量

                            //获取文件名，不要目录
                            FileInfo fileinfo = new FileInfo(openBox2.Text);
                            var filename = fileinfo.Name;

                            string insert_sql = "insert into DCT.DCT_" + this.lg_form.user.userName + " values('" + (number + 1).ToString() + "','" + filename + "','" + temp_hash + "'   );";
                            cmd = new MySqlCommand(insert_sql, conn);
                            var n = cmd.ExecuteNonQuery();

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("DCT嵌入,数据库过程中失败：" + ex.Message);

                    }
                    finally
                    {
                        conn.Close();
                    }


                }


            }
            catch(Exception ex)
            {
                MessageBox.Show("DCT嵌入失败："+ex.Message);
            }
            

            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string path;
            string path_2;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                //var temp_hash = lib_1.DCT_WaterMark.Create_License(key_str,path);
                openBox3.Text = path;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path_2 = openFileDialog1.FileName;
                    openBox4.Text = path_2;

                    var img_ = Image.FromFile(path);
                    panel3.BackgroundImage = img_;


                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //控制progressbar，逐渐增加
            if(progressBar1.Value < rate_100)
            {
                progressBar1.PerformStep();
                rateBox.Text = progressBar1.Value.ToString();

            }
            else
            {
                rateBox.Text = rate_100.ToString();
                timer1.Stop();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value = 0;
                rateBox.Text = "0";



                var temp_hash = lib_1.HashHelper.HashFile(openBox4.Text, "md5");
                Mat img = new Mat(openBox3.Text);

                var max_dct = lib_1.DCT_WaterMark.Max_dct(img);
                var temp_2 = lib_1.Chaos_Generate.Using_HashStr_toGenerate(temp_hash, max_dct);
                var length = temp_2.Length;

                var res_2 = lib_1.DCT_WaterMark.DCT_converse(openBox3.Text, temp_2.Length);
                var rate = lib_1.DCT_WaterMark.rate_accuracy(temp_2, res_2); //水印正确率

                double rate_2 = (int)(rate * 10000) * 1.0 / 100;
                //rateBox.Text = rate_2.ToString();
                rate_100 = rate_2;

                timer1.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show("DCT水印检测失败：" + ex.Message);
            }
            
            
        }
    }
}
