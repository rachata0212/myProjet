using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Visual_Lab
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
            Application.Run(new F_Visual());
        }

        static public SqlConnection CN;
        static public string pahtdb = null;
        static public string user_login = "";
        static public int user_id = 0;
        static public string Sourc_Imagefile = "";
        static public string Dis_Imagefile = "";

        static public string MachineName = null;
        static public string LocalIpAddress = null;

        static public string img1_paht="";
        static public string img2_paht="";
        static public string img3_paht="";
        static public string img4_paht="";

    }
}
