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
namespace 简单的信息隐藏程序
{
    public partial class DB_connect : Form
    {
        Login login;
        DCT_Form dCT_Form;
        public DB_connect()
        {
            InitializeComponent();
        }
        public DB_connect(Login login,DCT_Form temp)
        {
            InitializeComponent();
            this.login = login;
            this.dCT_Form = temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Equals("") != true && textBox2.Text.Equals("") != true && textBox3.Text.Equals("") != true)
            {
                string IP_ = textBox1.Text.Trim();
                string port_ = textBox2.Text.Trim();
                string userName_ = textBox3.Text.Trim();
                string password_ = textBox4.Text.Trim();

                string connetStr = "server=" + IP_ + ";port=" + port_ + ";user=" + userName_ + ";password=" + password_ + ";";
                //String connetStr_2 = "server=172.16.0.129;port=3306;user=yuqian;password=zqhzqhhh99;";
                MySqlConnection conn = new MySqlConnection(connetStr);
                try
                {
                    conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句
                    Console.WriteLine("已经建立连接");
                    //在这里使用代码对数据库进行增删查改
                    conn.Close();
                    this.dCT_Form.conn = conn;
                    this.dCT_Form.flag_conn = 1;

                    MessageBox.Show("连接测试成功");

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("连接测试失败!!!");
                }
                finally
                {
                    conn.Close();
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = this.dCT_Form.conn;
            try
            {
                
                conn.Open();
                Console.WriteLine("已经建立连接");
                MySqlCommand cmd = new MySqlCommand("CREATE DATABASE DCT;", conn);
                cmd.ExecuteNonQuery();

                string createTable = "use DCT;CREATE TABLE "+ "DCT_"+ this.login.user.userName +" (Numbers VarChar(20),FileName VarChar(100) ,Hash_str VarChar(100))";
                cmd = new MySqlCommand(createTable, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("创建成功");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("连接数据库失败!!!");
            }
            finally
            {
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = this.dCT_Form.conn;
            try
            {

                conn.Open();
                Console.WriteLine("已经建立连接");

                string createTable = "use DCT;CREATE TABLE " + "DCT_" + this.login.user.userName + " (Numbers VarChar(20),FileName VarChar(100) ,Hash_str VarChar(100))";
                MySqlCommand cmd = new MySqlCommand(createTable, conn);
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("连接数据库失败!!!");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
