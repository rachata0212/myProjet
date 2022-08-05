using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Truck_Analytics
{
    public partial class Sub_Flog : Form
    {
        public Sub_Flog()
        {
            InitializeComponent();
        }

        int id_view = 0;

        private void Sub_Flog_Load(object sender, EventArgs e)
        {
            id_view = 0;
            Load_DateHistory();
            Load_UserHistory();
            Load_History();
        }

        private void Load_History()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                DateTime dt = new DateTime();
                dt = Convert.ToDateTime(cb_histryDate.Text);

                string date = dt.ToString("yyyy-MM-dd");

                string sql1 = "";

                sql1 = "SELECT Top(100)[AutoRun] AS 'ลำดับ' ,CONVERT(varchar,[LogDateTime],3) AS 'วันที่'  ,CONVERT(varchar,[LogDateTime],8)  AS 'เวลา' ,[Username] AS 'ผู้ใช้งาน' ,[TableName] AS 'แหล่งที่เก็บข้อมูล',[OldValue] AS 'ข้อมูลเก่า',[NewValue] AS 'ข้อมูลใหม่',[MachineName] AS 'ชื่อเครื่องที่ใช้งาน',[LocalIpAddress] AS 'เลขไอพีแอดเดส' FROM  [dbo].[TB_Log] Order by  [AutoRun] Desc";

                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_histroy");
                dtg_History.DataSource = ds1.Tables["g_histroy"];
                con.Close();

                dtg_History.Columns[0].Width = 100;
                dtg_History.Columns[1].Width = 100;   // วันที่
                dtg_History.Columns[2].Width = 100;   // เวลา

            }

            catch { }
        }

        private void Load_UserHistory()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                //Product 
                SqlCommand cmd = new SqlCommand("Select DISTINCT [Username] From  [dbo].[TB_Log] ", con);
                DataSet ds = new DataSet();
                //ds.Clear();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);

                //Load product tab weight scale Setup
                cb_historyUser.DataSource = ds.Tables[0];
                cb_historyUser.DisplayMember = "Username";
                cb_historyUser.ValueMember = "Username";

                con.Close();
                con.Dispose();
            }
            catch
            {

            }


        }

        private void Load_DateHistory()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                //Product 
                SqlCommand cmd = new SqlCommand("Select DISTINCT CONVERT(varchar,[LogDateTime],3) AS [LogDateTimes]  From  [dbo].[TB_Log] ", con);
                DataSet ds = new DataSet();
                //ds.Clear();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);

                //Load product tab weight scale Setup
                cb_histryDate.DataSource = ds.Tables[0];
                cb_histryDate.DisplayMember = "LogDateTimes";
                cb_histryDate.ValueMember = "LogDateTimes";

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

        }

        private void cb_histryDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_view = 1;   //filter date  and userName
            Load_History();
        }

        private void cb_historyUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_view = 2;  //fileter date only
            Load_History();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {

            }
        }
    }
}
