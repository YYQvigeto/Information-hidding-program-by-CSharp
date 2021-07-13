using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace 简单的信息隐藏程序
{
    public partial class LSB_Form : Form
    {


        int flag_1 = 0;   //图层提取标志，如果 1为r，2为green，3为b
        //string lsb_insert_key = "";//存储process返回的值
        public LSB_Form()
        {
            InitializeComponent();
            //openFileDialog1.InitialDirectory = ".\\";
            //saveFileDialog1.InitialDirectory = ".\\";

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                flag_1 = 1;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                flag_1 = 2;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                flag_1 = 3;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string img_str = "";
            string txt_str = "";
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img_str = openFileDialog1.FileName;
                var img = Image.FromFile(img_str);
                panel1.BackgroundImage = img;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txt_str = openFileDialog1.FileName;
                    openBox1.Text = img_str;
                    openBox2.Text = txt_str;



                }




            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = "";
            
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
                saveBox1.Text = path;
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (flag_1 != 0)
                {
                    var bin_str = lib_1.LSB_Process.get_binStr_from_file(openBox2.Text);
                    string temp_str = lib_1.LSB_Process.lsb_process(openBox1.Text, saveBox1.Text, bin_str, flag_1);
                    var img = Image.FromFile(saveBox1.Text);
                    panel2.BackgroundImage = img;


                    //密钥保存，将隐写后的图像求md5 哈希值，并对他创建同名文件，并存储嵌入数据数量。
                    var hash_str = lib_1.HashHelper.HashFile(saveBox1.Text, "md5");
                    FileInfo save_img = new FileInfo(saveBox1.Text);
                    var directory_path = save_img.DirectoryName; //隐写后的图片所在目录
                    directory_path += "\\" + hash_str;

                    StreamWriter writer = new StreamWriter(directory_path, false, Encoding.Default);
                    writer.Write(temp_str);
                    writer.Close();

                    saveBox2.Text = directory_path;

                    MessageBox.Show("隐写成功！", "消息");


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("隐写失败:"+ex.Message, "消息");
            }

            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string img_str = "";
            string txt_str = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img_str = openFileDialog1.FileName;
                var img = Image.FromFile(img_str);
                panel3.BackgroundImage = img;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txt_str = openFileDialog1.FileName;
                    openBox3.Text = img_str;
                    openBox4.Text = txt_str;



                }




            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string path = "";
            //string path_2 = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
                saveBox3.Text = path;
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {


            try
            {
                StreamReader reader = new StreamReader(openBox4.Text, Encoding.Default);
                var strss = reader.ReadToEnd();
                var array_str = strss.Split('-');
                //lsb提取
                lib_1.LSB_Process.lsb_converse(openBox3.Text, saveBox3.Text, Convert.ToInt32(array_str[0]), Convert.ToInt32(array_str[1]));
                MessageBox.Show("提取成功！", "消息");
            }
            catch(Exception ex)
            {
                MessageBox.Show("提取失败:" + ex.Message, "消息");
            }
            
            

        }
    }
}
