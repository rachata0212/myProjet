using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Interface_Lab
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
            Application.Run(new F_Increditor());
        }



        static public SqlConnection CN;
        static public string pahtdb = null;
        static public string user_login = "";
        static public int user_id = 0;

        static public string MachineName = null;
        static public string LocalIpAddress = null;

        //for Truck Scale
       
        static public int ScaleNo = 0;
        static public string ScaleName = "";
        static public string PortName = "";
        static public string BaudRate = "";
        static public int DataBit = 0;
        static public string Parity = "";
        static public string StopBit = "";
        static public int StartSelect_Char = 3;
        static public int EndSelect_Chare = 10;

        static public int countItem_update = 0;
        static public string ticket_No = "";
        static public string sample_code = "";
    }
}
