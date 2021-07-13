using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace 简单的信息隐藏程序
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //var names = System.Text.Encoding.Default.EncodingName;
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Login());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            


           
            
        }
    }
}
