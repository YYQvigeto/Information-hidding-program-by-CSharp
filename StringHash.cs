using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lib_1;
namespace 简单的哈希界面程序
{



    public partial class StringHash : Form
    {
        private int flag = 0; 
        /*
         0 无操作
         1 md5
         2 sha-1
         */

        public StringHash()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                flag = 1;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                flag = 2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string temp = string.Copy(textBox1.Text);
            //HashHelper hash_1 = new HashHelper();
            
            if(flag == 1)
            {
                var res = HashHelper.HashStrings(temp, "md5");
                var str_bin = HashHelper.ByteArrayToHexString(res);
                textBox2.Text = str_bin;

            }
            if(flag == 2)
            {
                var res = HashHelper.HashStrings(temp, "sha1");
                var str_bin = HashHelper.ByteArrayToHexString(res);
                textBox2.Text = str_bin;

            }
            

        }

        private void 文件哈希ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileHash dialog = new FileHash();
            dialog.ShowDialog();
        }
    }
}
