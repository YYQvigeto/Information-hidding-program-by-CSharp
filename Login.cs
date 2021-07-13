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

namespace 简单的信息隐藏程序
{
    

    public partial class Login : Form
    {
        //添加一个用户类
        public User user;



        public Login()
        {
            InitializeComponent();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text_1 = textBox1.Text.Trim();
            string text_2 = textBox2.Text.Trim();
            if (text_1.Equals("") != true && text_2.Equals("") != true)
            {
                string path = ".\\user\\" + text_1;
                if (File.Exists(path) == true)
                {
                    //Directory.CreateDirectory(path);
                    var res_1 = lib_1.HashHelper.HashStrings(text_2, "md5");
                    var res_2 = lib_1.HashHelper.ByteArrayToHexString(res_1);   //密码对应的哈希值

                    var reader = new StreamReader(path);
                    var hash_str = reader.ReadToEnd();

                    //对比hash值
                    if (res_2.Equals(hash_str))
                    {
                        this.user = new User(text_1, res_2);  //存储用户信息

                        MessageBox.Show("登录成功！","消息");

                        Form2_Menu form2 = new Form2_Menu(this);
                        form2.Show();
                        this.Hide();



                    }
                    else
                    {
                        MessageBox.Show("登录失败！", "消息");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if(textBox1.Text)
            string text_1 = textBox1.Text.Trim();
            string text_2 = textBox2.Text.Trim();
            if (text_1.Equals("") != true && text_2.Equals("") != true)
            {
                //textBox1.Text = "12312";
                //检测目录.\\user\\是否存在
                //if(Directory.Exists())
                string path = ".\\user\\";
                if(Directory.Exists(path) != true)
                {
                    Directory.CreateDirectory(path);
                    

                }
                string path_2 = path + text_1;
                var res_1 = lib_1.HashHelper.HashStrings(text_2, "md5");
                var res_2 = lib_1.HashHelper.ByteArrayToHexString(res_1);   //密码对应的哈希值

                //创建文件，名字是用户名，密码是哈希值
                //FileStream streams = new FileStream(path_2, FileMode.Create,FileAccess.Write);
                var writer = new StreamWriter(path_2, false, Encoding.Default);
                //new StreamWriter()
                writer.Write(res_2);

                writer.Flush();
                writer.Close();

                MessageBox.Show("注册成功！","消息");


            }
        }
    }

    public class User
    {
        public string userName;
        public string password_hash;

        public User(string userName, string password_hash)
        {
            this.userName = userName;
            this.password_hash = password_hash;

        }


    }




}
