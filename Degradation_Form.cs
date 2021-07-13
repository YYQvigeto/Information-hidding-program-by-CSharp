using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 简单的信息隐藏程序
{
    public partial class Degradation_Form : Form
    {
        int flag_1 = 4;  //降质程度

        public Degradation_Form()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            var temp = trackBar1.Value;
            flag_1 = temp;
            textBox1.Text = flag_1.ToString();

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
                    var img_2 = Image.FromFile(txt_str);
                    panel2.BackgroundImage = img_2;
                    openBox1.Text = img_str;
                    openBox2.Text = txt_str;



                }




            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = "";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
                saveBox1.Text = path;
                //var img = Image.FromFile(img_str);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var key_str = lib_1.Img_Degrade.Degrade_process(openBox1.Text, openBox2.Text, saveBox1.Text, flag_1);

                //将返回字符串，写入密钥文件中，文件名为 隐写后图像的md5数值
                //密钥保存，将隐写后的图像求md5 哈希值，并对他创建同名文件，并存储嵌入数据数量。
                var hash_str = lib_1.HashHelper.HashFile(saveBox1.Text, "md5");
                FileInfo save_img = new FileInfo(saveBox1.Text);
                var directory_path = save_img.DirectoryName; //隐写后的图片所在目录
                directory_path += "\\" + hash_str;

                StreamWriter writer = new StreamWriter(directory_path, false, Encoding.Default);
                writer.Write(key_str);
                writer.Close();

                saveBox2.Text = directory_path;
                var img_2 = Image.FromFile(saveBox1.Text);
                panel3.BackgroundImage = img_2;

                MessageBox.Show("图像降质成功！", "消息");
            }
            catch(Exception ex)
            {
                MessageBox.Show("图像降质失败："+ ex.Message, "消息");
            }


            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string img_str = "";
            string txt_str = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img_str = openFileDialog1.FileName;
                var img = Image.FromFile(img_str);
                panel4.BackgroundImage = img;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txt_str = openFileDialog1.FileName;
                    
                    openBox3.Text = img_str;
                    openBox4.Text = txt_str;



                }




            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string path = "";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
                saveBox3.Text = path;
                //var img = Image.FromFile(img_str);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader reader = new StreamReader(openBox4.Text, Encoding.Default);
                var keys = reader.ReadToEnd();
                reader.Close();

                lib_1.Img_Degrade.Degrade_converse(openBox3.Text, saveBox3.Text, keys);

                var img = Image.FromFile(saveBox3.Text);

                panel5.BackgroundImage = img;
                MessageBox.Show("图像提取成功！", "消息");
            }
            catch(Exception ex)
            {
                MessageBox.Show("图像提取失败："+ ex.Message, "消息");
            }
            
        }
    }
}
