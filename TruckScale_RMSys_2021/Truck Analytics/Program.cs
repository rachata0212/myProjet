using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using GemBox.Spreadsheet;
using System.Globalization;

namespace Truck_Analytics
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
            // Application.Run(new Form1());
            // Set license key to use GemBox.Spreadsheet in Free mode.
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            Application.Run(new F_Mainmenu());

          // Application.Run(new F_Login());

        }
                       
        static public SqlConnection CN;
        static public string DB_Name = null;       
        static public string pathdb_Weight = null;    //SQL 225  DB-SapthipNewDB
        static public string pathdb14_NAV = null;
        static public string pathdb14_TruckScale = null;       
        

        static public string user_login = "";
        static public int user_id = 0;
        static public string user_name = "";
        static public int uid_verifiled = 0;

        static public string MachineName = null;
        static public string LocalIpAddress = null; 
        static public int refresh_Data = 30;
        //for Truck Scale
        static public string PortName = "";
        static public string BaudRate = "";
        static public int DataBit = 0;
        static public string Parity = "";
        static public string StopBit = "";
        static public int StartSelect_Char = 0;
        static public int EndSelect_Chare = 0;
        static public int Selectline = 1;
        static public int PrintFormateNo = 0;
        static public string TruckScaleName = "";

        static public string Date_Now = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
        static public string Time_Now = DateTime.Now.ToString("HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));

    }
}
