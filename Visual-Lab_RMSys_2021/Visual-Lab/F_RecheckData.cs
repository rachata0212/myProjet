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

namespace Visual_Lab
{
    public partial class F_RecheckData : Form
    {
        public F_RecheckData()
        {
            InitializeComponent();
        }

        public string Ticket_Code ="";
        public string Simple_code = "";
        
        private void F_RecheckData_Load(object sender, EventArgs e)
        {
            Load_Data();

            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();      
            
            dtg_recheck.DataSource = null;  

                con.Open();
            // string sql = "Select * From [dbo].[V_InuptLab] ";
            ///string sql1 = "SELECT [VisualIndex] AS 'ลำดับข้อมูล',[VisualType] AS 'รหัสค่า' ,[Value1] AS 'ค่าที่บันทึก' ,[TicketCodeIn] AS 'รหัสตั๋วชั่ง',[SimpleCode] AS 'รหัสตัวอย่าง' ,[Remark] AS 'หมายเหตุ' ,[VSActive] AS 'สถานะ' FROM [SapthipNewDB].[dbo].[TB_VISUAL1] WHERE [SimpleCode] = '" + Simple_code + "' ";         

            string sql1 = "SELECT [VisualIndex] AS 'ลำดับ',[LabID] AS 'รหัสประเภท' ,(Select [LabName] From [dbo].[TB_LabName] Where [dbo].[TB_LabName].[LabID]= [dbo].[TB_VisualData].[LabID]) AS 'ชื่อประเภท',[ValueName] AS 'ค่าที่บันทึก' ,[TicketCodeIn] AS 'รหัสตั๋วชั่ง',[SimpleCode] AS 'รหัสตัวอย่าง' ,[Remark] AS 'หมายเหตุ' ,[VSActive] AS 'สถานะ' FROM [SapthipNewDB].[dbo].[TB_VisualData] WHERE [SimpleCode] = '" + Simple_code + "' ";


            SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "g_weight");
            dtg_recheck.DataSource = ds1.Tables["g_weight"];
            con.Close();

            dtg_recheck.Columns[0].Width = 80;
            dtg_recheck.Columns[1].Width = 100;
            dtg_recheck.Columns[2].Width = 140;
            dtg_recheck.Columns[3].Width = 160;
            dtg_recheck.Columns[5].Width = 250;
            dtg_recheck.Columns[7].Width = 80;

            dtg_recheck.ClearSelection();

        }

        private void Load_Data()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pahtdb);
                con.ConnectionString = Program.pahtdb;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                lbl_detail.Text = "เลขที่บัตรชั่ง: " + Ticket_Code + " เลขที่ตัวอย่าง: " + Simple_code;


                string sql1 = "Select [ProductName],[Plate1],[TruckTypeName],[QueueNo] From [V_InuptLab] Where [TicketCodeIn]='" + Ticket_Code + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    lbl_detail.Text += "รายการชั่งคิวที่:" + DR1["QueueNo"].ToString().Trim() + " ชื่อสินค้า:" + DR1["ProductName"].ToString().Trim() + " ประเภทรถ: " + DR1["TruckTypeName"].ToString().Trim() + " ทะเบียน:" + DR1["Plate1"].ToString().Trim();
                    //[QueueNo] v[proc_no]
                }
                DR1.Close();

                con.Close();

                dtg_recheck.Focus();
            }
            catch { }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtg_recheck_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex ==7)
            {
                int sts = 1;

                if (dtg_recheck.Rows[e.RowIndex].Cells[7].Value.ToString() == "False")
                {
                    sts = 0;
                }

                SqlConnection con = new SqlConnection(Program.pahtdb);
                con.ConnectionString = Program.pahtdb;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();
                
                string sql1 = "Update [TB_VisualData] Set [VSActive] =" + sts + " WHERE [VisualIndex]= " + dtg_recheck.Rows[e.RowIndex].Cells[0].Value.ToString() + "";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                con.Close();
            }
        }
    }
}
