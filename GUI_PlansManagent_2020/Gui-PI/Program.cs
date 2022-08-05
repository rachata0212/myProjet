using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gui_PI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new F_Setup());

            Application.Run(new F_Mainpage());
        }

        static public string user_id ;
        static public SqlConnection CN;
        static public string pahtdb = null;
        static public string MachineName;
        static public string LocalIpAddress;
    }
}
