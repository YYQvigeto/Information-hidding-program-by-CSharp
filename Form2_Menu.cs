using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 简单的哈希界面程序;
namespace 简单的信息隐藏程序
{
    public partial class Form2_Menu : Form
    {
        Login login;
        Boolean flag_relogin = false;  //标志是否是重新登陆


        public Form2_Menu()
        {
            InitializeComponent();
        }
        public Form2_Menu(Login temp)
        {
            InitializeComponent();
            login = temp;
        }

        private void Form2_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(flag_relogin == true)
            {
                this.login.Show();

            }
            else
            {
                login.Close();
            }
        }

        private void 哈希工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringHash strhash = new StringHash();

            strhash.Show();

        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("开发者杨语谦\n学号 8003118128\n班级 信息安全184班\n版本 1.0.0","关于");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LSB_Form lSB_Form = new LSB_Form();
            lSB_Form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var degradation_form = new Degradation_Form();
            degradation_form.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DCT_Form temp = new DCT_Form(login);
            temp.Show();
        }

        private void 重新登陆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag_relogin = true;
            this.Close();
        }
    }
}
