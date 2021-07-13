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
using lib_1;
namespace 简单的哈希界面程序
{
    public partial class FileHash : Form
    {
        public FileHash()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string temp = openFileDialog1.FileName;
                textBox1.Text = temp;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = string.Copy(textBox1.Text);
            Stream expectedSteam = new FileStream(path,FileMode.Open);//将Path该文件读取为流格式
            //byte[] expectedBytes = new byte[expectedSteam.Length];
            //expectedSteam.Read(expectedBytes, 0, expectedBytes.Length);//读取该流文件字节，保存到对象中，为测试比对做准备
            byte[] bin_ = HashHelper.HashData(expectedSteam, "md5");
            string bin_str = HashHelper.ByteArrayToHexString(bin_);
            textBox2.Text = bin_str;

            byte[] bin_2 = HashHelper.HashData(expectedSteam, "sha1");
            string bin_str_2 = HashHelper.ByteArrayToHexString(bin_2);
            textBox3.Text = bin_str_2;
            expectedSteam.Close();




        }

        private void md5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var temp = (ToolStripItem)sender;
            //temp.Text = "adfadfs";
            //temp.ImageIndex = 0;

            //Image img_1 = new Image()
            string temp_2;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                temp_2 =  openFileDialog1.FileName;
                textBox1.Text = temp_2;
                Image imgs = Image.FromFile(temp_2);
                
                temp.Image = imgs;


            }
        }

        
    }
}
