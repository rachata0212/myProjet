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
    public partial class F_DataLab : Form
    {
        public F_DataLab()
        {
            InitializeComponent();
        }

        public string ticket_code = "";
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void F_DataLab_Load(object sender, EventArgs e)
        {
            txt_ticketCode.Text = ticket_code;
            Load_TypeLab();

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql1 = "SELECT [LOGID] AS 'เลขที่',[SimpleCode] AS 'รหัสตัวอย่าง',[LabNameTH] AS 'ประเภทการวิเคราะห์',[ValueLab] AS 'ผลวิเคราะห์',[CreateDate] AS 'วันที่วิเคราะห์',[CreateBy] AS 'ผู้บันทึก',[InActive] AS 'สถานะใช้งาน' FROM  [dbo].[V_DataLab] WHERE TicketCodeIn ='" + txt_ticketCode.Text.Trim()+"'";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "g_l");
            dtg_labview.DataSource = ds1.Tables["g_l"];
            con.Close();

            dtg_labview.Columns[0].Width = 80;
            dtg_labview.Columns[1].Width = 200;
            dtg_labview.Columns[2].Width = 100;
            dtg_labview.Columns[3].Width = 100;
            dtg_labview.Columns[4].Width = 150;
            dtg_labview.Columns[5].Width = 100;
            dtg_labview.Columns[6].Width = 80;
            //dtg_labview.Columns[7].Width = 200;

            
        }

        private void Load_TypeLab()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            //SqlConnection CN = new SqlConnection();
            //CN.ConnectionString = "server=192.168.111.225;initial catalog=HR_MNT;uid=hr_sync; pwd=hr@2021;";
            //CN.Open();

            SqlCommand cmd = new SqlCommand("Select DISTINCT [LabNameTH] From  [dbo].[V_DataLab] WHERE [TicketCodeIn]='" + txt_ticketCode.Text.Trim() + "'", con);
            DataSet ds = new DataSet();
            //ds.Clear();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                // cb_section.DisplayMember = "nameSection_th" + "(" + "nameSection_eng" +")";
                //string name= "nameSection_th" + "(" + "nameSection_eng" + ")";

                cb_typelab.DisplayMember = "LabNameTH";
                cb_typelab.ValueMember = "LabNameTH";
                cb_typelab.DataSource = ds.Tables[0];
                cb_typelab.SelectedIndex = -1; cb_typelab.Text = "-- Select --";
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

        private void cb_typelab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_typelab.Text !="")
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql1 = "SELECT [LOGID] AS 'เลขที่' ,[SimpleCode] AS 'รหัสตัวอย่าง',[LabNameTH] AS 'ประเภทการวิเคราะห์',[ValueLab] AS 'ผลวิเคราะห์',[CreateDate] AS 'วันที่วิเคราะห์',[CreateBy] AS 'ผู้บันทึก',[InActive] AS 'สถานะใช้งาน' FROM  [dbo].[V_DataLab] WHERE TicketCodeIn ='" + txt_ticketCode.Text.Trim() + "' AND [LabNameTH]='" + cb_typelab.SelectedValue.ToString().Trim() + "'";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_l");
                dtg_labview.DataSource = ds1.Tables["g_l"];
                con.Close();

                dtg_labview.Columns[0].Width = 80;
                dtg_labview.Columns[1].Width = 200;
                dtg_labview.Columns[2].Width = 100;
                dtg_labview.Columns[3].Width = 100;
                dtg_labview.Columns[4].Width = 150;
                dtg_labview.Columns[5].Width = 100;
                dtg_labview.Columns[6].Width = 80;
                //dtg_labview.Columns[7].Width = 200;
            }
        }

        private void btn_saveconfirm_Click(object sender, EventArgs e)
        {

        }

        private void dtg_labview_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int sts_active = 0;
            if (dtg_labview.Rows[e.RowIndex].Cells[6].Value.ToString() == "True")
            { sts_active = 1; }

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql = "Update [TB_LabData] Set [InActive]=" + sts_active + " WHERE [LOGID]= "+dtg_labview.Rows[e.RowIndex].Cells[0].Value.ToString() +"";
            SqlCommand CM2 = new SqlCommand(sql, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();
        }
    }
}
