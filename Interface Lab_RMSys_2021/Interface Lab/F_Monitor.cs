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

namespace Interface_Lab
{
    public partial class F_Monitor : Form
    {
        public F_Monitor()
        {
            InitializeComponent();
        }      

        private void F_Monitor_Load(object sender, EventArgs e)
        {
            this.Location = Screen.AllScreens[1].WorkingArea.Location;
            System.Drawing.Rectangle rect = Screen.GetWorkingArea(this);
            this.MaximizedBounds = Screen.GetWorkingArea(this);
            this.WindowState = FormWindowState.Maximized;
            timer1.Enabled = true;
            
            Adjust_sizeForm();
            txt_ticketNo.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            DateTime dt = DateTime.Now;
            txt_datetime.Text ="วัน:"+ dt.ToString("dddd, dd MMMM yyyy", new System.Globalization.CultureInfo("th-TH")) + " เวลา:" + dt.ToString("HH:mm:ss");

            Load_DataPurchase();
            Update_Data();

        }

        private void Update_Data()
        {
            //F_Increditor fic = new F_Increditor();

            if (dtg_detail.RowCount != Program.countItem_update)
            {
                txt_ticketNo.Text = Program.ticket_No;
                Load_DTG_LabInterface();
                //MessageBox.Show(Program.countItem_update.ToString());
            }
        }


        private void Adjust_sizeForm()
        {
            int widths = this.Width;
            int adjust = widths - 760;

            // 760  
            pnl_left.Width = adjust/2;
            pnl_right.Width = adjust / 2;

        }

        private void Load_DTG_LabInterface()
        {
            if (txt_ticketNo.Text != "-")
            {
                SqlConnection con = new SqlConnection(Program.pahtdb);
                con.ConnectionString = Program.pahtdb;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql = "SELECT [LOGID] AS 'เลขที่', [SimpleCode] AS 'เลขที่ตัวอย่าง',[LabTypeName] AS 'ประเภทการวิเคราะห์',[ValueLab] AS 'ผลการวิเคราะห์' ,[LabTypeNameTH] AS 'หมายเหตุ'  FROM [SapthipNewDB].[dbo].[V_DataLab]  Where [LabCode]='" + Program.sample_code+ "'";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "g_v");
                dtg_detail.DataSource = ds.Tables["g_v"];
                con.Close();

                int width = dtg_detail.Width;

                dtg_detail.Columns[0].Width = (width * 10) / 100;
                dtg_detail.Columns[1].Width = (width * 20) / 100;
                dtg_detail.Columns[2].Width = (width * 20) / 100;
                dtg_detail.Columns[3].Width = (width * 10) / 100;

                dtg_detail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dtg_detail.Columns[3].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void Load_DataPurchase()
        {
            if (txt_ticketNo.Text !="-") {

                SqlConnection con = new SqlConnection(Program.pahtdb);
                con.ConnectionString = Program.pahtdb;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql1 = "Select [VendorName],[Plate1],[TruckTypeName] From [V_InuptLab] Where [TicketCodeIn]='" + txt_ticketNo.Text + "' AND  [proc_type]='L+WH'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    // count = Convert.ToInt16(DR1["countidqua"].ToString().Trim());               
                    txt_vendorName.Text = DR1["vendorName"].ToString().Trim();
                    txt_plateNo.Text = DR1["Plate1"].ToString().Trim();
                    txt_truckType.Text = DR1["TruckTypeName"].ToString().Trim();
                }
                DR1.Close();
                con.Close();
            }
        }
    }
}
