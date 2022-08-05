using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ShareHD
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
            Application.Run(new Frm_main());
        }

        static public SqlConnection CN;
        static public string urldb = null;
        static public string uid = null;
        static public string uname = "";
        static public int idmeeting = 0;
        static public string namemeeting = "";
        static public string datemeeting = "";
        static public string id_registers="";

    }
}
