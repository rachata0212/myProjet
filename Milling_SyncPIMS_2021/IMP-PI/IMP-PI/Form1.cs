using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace IMP_PI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Type_day;  //line 1
        int Unit_day;  //line 2
        string Time_sync;  //line 3
        string Sourc_DB;
        int Sync_day;

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            Load_ConnecDB();
            Load_DLLconfig();
            Load_Log();

            if (Type_day == 0)  //before  or after
            {
                Unit_day = Unit_day * -1;
            }

            DateTime dt = DateTime.Now.AddDays(Unit_day);
            Sync_day = dt.Day;

            //test date
            DateTime dt_nextsync = DateTime.Now.AddDays(1);
            txt_dateNext.Text = dt_nextsync.ToShortDateString() + " " + Time_sync.ToString() + ":00:00";
        }

        private void Load_Log()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.cn_dbConfig);
                con.ConnectionString = Program.cn_dbConfig;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                //prot_form
                dtg_log.DataSource = null;
                string sql1 = "Select TOP 100 * From [TB_LogMilling] Order by Id_log Desc";

                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "log");
                dtg_log.DataSource = ds1.Tables["log"];
                con.Close();
                dtg_log.ClearSelection();              

            }
            catch { }
        }

        private void Load_DLLconfig()
        {
            try
            {
                string filename = Application.StartupPath + "\\config.dll";

                if (System.IO.File.Exists(filename))
                {
                    System.IO.StreamReader StrRer = new System.IO.StreamReader(filename);

                    List<string> listStr = new List<string>();

                    while (!StrRer.EndOfStream)
                    {
                        listStr.Add(StrRer.ReadLine());
                    }

                    Sourc_DB = listStr[0].ToString();
                    Type_day = Convert.ToInt16(listStr[1].ToString()); 
                    Unit_day = Convert.ToInt16(listStr[2].ToString());
                    Time_sync = listStr[3].ToString();                    
                    StrRer.Close();
                }
            }
            catch { }
        }
        private void btn_setup_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();
            F2.ShowDialog();
                   
            Load_ConnecDB();
            Load_DLLconfig();
            Load_Log();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")) + ' ' + DateTime.Now.ToString("HH:mm:ss");
            txt_dateNow.Text = date;

            int ss = DateTime.Now.Second;
            int tt = ss % 2;
            if (tt == 0)
            {
                txt_1.BackColor = Color.Red;
                txt_3.BackColor = Color.Red;
                txt_5.BackColor = Color.Blue;
                txt_2.BackColor = Color.White;
                txt_4.BackColor = Color.White;
            }
            else
            {
                txt_2.BackColor = Color.Green;
                txt_4.BackColor = Color.Green;
                txt_1.BackColor = Color.White;
                txt_3.BackColor = Color.White;
                txt_5.BackColor = Color.White;
            }

            if (txt_dateNow.Text.Trim() == txt_dateNext.Text.Trim())
            {
                Sync_Data();

                DateTime dt_nextsync = DateTime.Now.AddDays(1);
                txt_dateNext.Text = dt_nextsync.ToShortDateString() + " " + Time_sync.ToString() + ":00:00";

                DateTime dt = DateTime.Now.AddDays(Unit_day);
                Sync_day = dt.Day;
            }

        }

        private void Load_ConnecDB()
        {
            string filename = Application.StartupPath + "\\cnDB.dll";

            if (System.IO.File.Exists(filename))
            {
                System.IO.StreamReader StrRer = new System.IO.StreamReader(filename);

                List<string> listStr = new List<string>();

                while (!StrRer.EndOfStream)
                {
                    listStr.Add(StrRer.ReadLine());
                }

                string cn_dbConfig = listStr[0].ToString();
                string cn_sysncPI = listStr[1].ToString();
                StrRer.Close();

                Program.cn_config = new SqlConnection();
                Program.cn_config.ConnectionString = cn_dbConfig;
                Program.cn_dbConfig = cn_dbConfig;

                Program.cn_pi = new SqlConnection();
                Program.cn_pi.ConnectionString = cn_dbConfig;
                Program.cn_sysncPI = cn_sysncPI;
            }
        }

        private void Sync_Data()
        {           

            SqlConnection con1 = new SqlConnection(Program.cn_dbConfig);
            con1.ConnectionString = Program.cn_dbConfig;
            SqlDataAdapter dtAdapter1 = new SqlDataAdapter();

            SqlConnection con2 = new SqlConnection(Program.cn_sysncPI);
            con2.ConnectionString = Program.cn_sysncPI;
            SqlDataAdapter dtAdapter2 = new SqlDataAdapter();

            string date1 = DateTime.Now.ToString("MM/yyyy", CultureInfo.CreateSpecificCulture("en-US"));
            string date_sync = Sync_day.ToString() + "/" + date1;
            string date2 = DateTime.Now.ToString("MM-dd-yyyy", CultureInfo.CreateSpecificCulture("en-US")) + ' ' + DateTime.Now.ToString("HH:mm:ss");
            int SEQ_Milling=0;
            int ID_Milling=0;
            string Name_Pro="";
            string ID_ProSource ="";
            int Gweith_Source=0;
            string ID_ProDis ="";
            int Gweight_Dis=0;
            string Status_Name = "Save Completed" ;
            int Tag_no = 0;

            //Get data last Save
            string path = @"" + Sourc_DB;
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path);
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            string query = "SELECT SEQ,ID,Gcode,GName,AccWgt FROM Prod2 Where WDate="+"#" + date_sync + "#" +"";
            cmd.CommandText = query;
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SEQ_Milling =Convert.ToInt16(reader["SEQ"].ToString());
                ID_Milling = Convert.ToInt16(reader["ID"].ToString());
                Name_Pro = reader["GName"].ToString();
                ID_ProSource = reader["Gcode"].ToString();
                Gweith_Source = Convert.ToInt32(reader["AccWgt"].ToString());
                Gweight_Dis = Convert.ToInt32(reader["AccWgt"].ToString());
            }

            con.Close();
         
            if (ID_ProSource.Trim() != "")
            {
                // Get ID product macth from milling to PIMS
                con1.Open();
                string sql1 = "Select [IDPro_PIMS]  FROM [dbo].[TB_ProductMilling]  Where [IDPro_Milling]='" + ID_ProSource.Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con1);
                SqlDataReader DR1 = CM1.ExecuteReader();
                DR1.Read();
                {
                    ID_ProDis = DR1["IDPro_PIMS"].ToString().Trim();
                }
                DR1.Close();
                con1.Close();

                //Select Tag No from Data PI setup                
                con2.Open();
                string sql2 = "Select [Tag_no] FROM [dbo].[V_TagRecordSetup]  Where [Tag_Name]='" + ID_ProDis.Trim() + "'";
                SqlCommand CM2 = new SqlCommand(sql2, con2);
                SqlDataReader DR2 = CM2.ExecuteReader();
                DR2.Read();
                {
                    Tag_no = Convert.ToInt16(DR2["Tag_no"].ToString().Trim());
                }
                DR2.Close();
                con2.Close();
            }


            if (Tag_no != 0)
            {
                //Save Data to PIMS
                con2.Open();
                string sql3 = "Insert Into [TB_DataTransection] ([Tag_no],[DT_Value],[DT_TimeStamp],[DT_Time],[DT_Status]) Values(" + Tag_no + ", '" + Gweight_Dis + "', '" + date2 + "','" + Time_sync.ToString() + ":00" + "',1)";
                con1.Open();
                SqlCommand CM3 = new SqlCommand(sql3, con2);
                SqlDataReader DR3 = CM3.ExecuteReader();
                con2.Close();

                //Save Log
                con2.Open();
                string sql4 = "Insert Into [TB_LogMilling] ([Datetime_Save],[SEQ_Milling],[ID_Milling],[Name_Pro],[ID_ProSource],[Gweith_Source],[ID_ProDis],[Gweight_Dis],[Status_Name]) Values('" + date2 + "', " + SEQ_Milling + ", " + ID_Milling + ", '" + Name_Pro.Trim() + "', '" + ID_ProSource.Trim() + "', " + Gweith_Source + ", '" + ID_ProDis.Trim() + "', " + Gweight_Dis + ", '" + Status_Name + "')";
              
                SqlCommand CM4 = new SqlCommand(sql4, con2);
                SqlDataReader DR4 = CM4.ExecuteReader();
                con2.Close();
            }

            Load_Log();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;            
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            Form3 f3 = new Form3();
            f3.ShowDialog();

            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (f3.Status_Confirm != 1)
                    e.Cancel = true;
            }

        }
    }
}
