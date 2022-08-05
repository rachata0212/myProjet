using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SaleOrder
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
            Application.Run(new Frmmain());
        }

        static public string lablecompany = "";
        //static public string lablecompany = "";
        static public string lablefrom = "";
        static public string urldb = "";
        static public SqlConnection CN;
        static public int idstatus = 0;
        static public string idsavelate = "";
        static public decimal unitstock = 0;


        static public string userid = "";
        static public string logins = "";
        static public string names = "";
        static public string empID = "";
        static public string iddept = "";
        static public string idbranch = "";
        static public int showtime = 0;
        static public string email = "";
        //static public string idit = "";
        //static public string dates = DateTime.Now.ToShortDateString();
        //static public string times = DateTime.Now.ToShortTimeString();
        //static public string strdatetime = dates + " " + times;
        //static public string Logfrom = "";
        //static public string Logidtype = "";  

        //for Truck Scale
        static public string comport = "";
        static public string baudrate = "";
        static public int databit = 0;
        static public string parity = "";
        static public string stopbit = "";
        static public int stkeychar = 0;
        static public int UnitKeyRecive = 0;
        static public int Selectline = 0;
    }
}