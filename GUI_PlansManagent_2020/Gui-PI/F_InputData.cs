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
using System.IO;
using System.Globalization;

namespace Gui_PI
{
    public partial class F_InputData : Form
    {
        public F_InputData()
        {
            InitializeComponent();
        }

        int id_save = 0;
        int e_RowIndex ;
        int e_ColIndex;
        public int STS_edit = 0;
        private void F_InputData_Load(object sender, EventArgs e)
        {           
            Load_ConnecDB();
      
            Load_PLCName();         
            timer1.Enabled = true;
        }

        private void Load_DTG_RecordTime_1()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pahtdb);
                con.ConnectionString = Program.pahtdb;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
               
                
                string Date = dtp_history.Value.Month + "-" + dtp_history.Value.Day + "-" + dtp_history.Value.Year;

                con.Open();
                string sql3 = "Select  [DT_Value],[DT_Status]  FROM [dbo].[TB_DataTransection]  Where [Tag_no] =" + dtg_Rectime.Rows[e_RowIndex].Cells[29].Value.ToString().Trim() + " AND [DT_Time] ='" + dtg_Rectime.Columns[e_ColIndex].HeaderText.Trim() + "' AND DT_TimeStamp Between'" + Date + " 00:00:00' AND '" + Date + " 23:59:59'";
                SqlCommand CM3 = new SqlCommand(sql3, con);
                SqlDataReader DR3 = CM3.ExecuteReader();
                DR3.Read();
                {
                    if (this.dtg_Rectime.Rows[e_RowIndex].Cells[e_ColIndex].Style.BackColor != Color.Black)
                    {
                        dtg_Rectime.Rows[e_RowIndex].Cells[e_ColIndex].Value = DR3["DT_Value"].ToString();

                        if (DR3["DT_Status"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[e_RowIndex].Cells[e_ColIndex].Style.BackColor = Color.LightGreen;
                        }

                        else {

                            this.dtg_Rectime.Rows[e_RowIndex].Cells[e_ColIndex].Style.BackColor = Color.Orange;
                            this.dtg_Rectime.Rows[e_RowIndex].Cells[e_ColIndex].ReadOnly = false;

                        }
                    }

                }

                DR3.Close();
                con.Close();
            }

            catch { }

            dtg_Rectime.ClearSelection();
        }
        

        private void Load_DTG_RecordTime()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pahtdb);
                con.ConnectionString = Program.pahtdb;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

                SqlConnection con1 = new SqlConnection(Program.pahtdb);
                con1.ConnectionString = Program.pahtdb;
                SqlDataAdapter dtAdapter1 = new SqlDataAdapter();
                //prot_form
                dtg_Rectime.DataSource = null;

                if (cbo_PLC.SelectedValue.ToString().Trim() != "System.Data.DataRowView")
                {
                    con.Open();
                    string sql1 = "SELECT 	[RTS_no] AS 'Index',[Tag_ID] AS 'Tag ID',[Tag_Name] AS 'Tag Name',[Tag_Address] AS 'Tag Address',[Unit_Name] AS 'Unit','' AS '00:00','' AS '01:00','' AS '02:00','' AS '03:00','' AS '04:00','' AS '05:00','' AS '06:00','' AS '07:00','' AS '08:00','' AS '09:00','' AS '10:00','' AS '11:00','' AS '12:00','' AS '13:00','' AS '14:00','' AS '15:00','' AS '16:00','' AS '17:00','' AS '18:00','' AS '19:00','' AS '20:00','' AS '21:00','' AS '22:00','' AS '23:00',[Tag_no] FROM [dbo].[V_TagRecordSetup] Where [PLC_no]=" + cbo_PLC.SelectedValue.ToString().Trim() + " AND [RTS_Status] =1 Order by [Tag_ID] ";

                    SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1, "g_rectime");
                    dtg_Rectime.DataSource = ds1.Tables["g_rectime"];
                    con.Close();

                    dtg_Rectime.Columns[0].Width = 70;
                    dtg_Rectime.Columns[1].Width = 80;
                    dtg_Rectime.Columns[2].Width = 140;
                    dtg_Rectime.Columns[3].Width = 160;
                    dtg_Rectime.Columns[4].Width = 80;

                    dtg_Rectime.Columns[5].Width = 60;  //0.00
                    dtg_Rectime.Columns[6].Width = 60;
                    dtg_Rectime.Columns[7].Width = 60;
                    dtg_Rectime.Columns[8].Width = 60;
                    dtg_Rectime.Columns[9].Width = 60;
                    dtg_Rectime.Columns[10].Width = 60;
                    dtg_Rectime.Columns[11].Width = 60;
                    dtg_Rectime.Columns[12].Width = 60;
                    dtg_Rectime.Columns[13].Width = 60;
                    dtg_Rectime.Columns[14].Width = 60;
                    dtg_Rectime.Columns[15].Width = 60;  //10.00
                    dtg_Rectime.Columns[16].Width = 60;
                    dtg_Rectime.Columns[17].Width = 60;
                    dtg_Rectime.Columns[18].Width = 60;
                    dtg_Rectime.Columns[19].Width = 60;
                    dtg_Rectime.Columns[20].Width = 60;
                    dtg_Rectime.Columns[21].Width = 60;
                    dtg_Rectime.Columns[22].Width = 60;
                    dtg_Rectime.Columns[23].Width = 60;
                    dtg_Rectime.Columns[24].Width = 60;
                    dtg_Rectime.Columns[25].Width = 60;
                    dtg_Rectime.Columns[26].Width = 60;
                    dtg_Rectime.Columns[27].Width = 60;
                    dtg_Rectime.Columns[28].Width = 60;
                    dtg_Rectime.Columns[29].Width = 100;
                }

                //this.dtg_Rectime.Columns[6].DefaultCellStyle.BackColor = Color.Green;   //color on Column
                //  this.dtg_Rectime.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;     // color on Cell

                for (int i = 0; i < dtg_Rectime.RowCount; i++)
                {
                    con.Open();
                    string sql2 = "Select *  FROM [dbo].[V_TagRecordSetup]  Where [Tag_ID] ='" + dtg_Rectime.Rows[i].Cells[1].Value.ToString().Trim() + "' AND  [PLC_no]=" + cbo_PLC.SelectedValue.ToString().Trim()+ "";
                    SqlCommand CM2 = new SqlCommand(sql2, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    DR2.Read();
                    {
                        //Time_00 

                        if (DR2["Time_00"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[5].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[5].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[5].Style.BackColor = Color.Black; }

                        if (DR2["Time_01"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[6].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[6].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[6].Style.BackColor = Color.Black; }

                        if (DR2["Time_02"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[7].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[7].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[7].Style.BackColor = Color.Black; }

                        if (DR2["Time_03"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[8].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[8].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[8].Style.BackColor = Color.Black; }

                        if (DR2["Time_04"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[9].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[9].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[9].Style.BackColor = Color.Black; }

                        if (DR2["Time_05"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[10].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[10].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[10].Style.BackColor = Color.Black; }

                        if (DR2["Time_06"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[11].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[11].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[11].Style.BackColor = Color.Black; }

                        if (DR2["Time_07"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[12].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[12].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[12].Style.BackColor = Color.Black; }

                        if (DR2["Time_08"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[13].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[13].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[13].Style.BackColor = Color.Black; }

                        if (DR2["Time_09"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[14].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[14].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[14].Style.BackColor = Color.Black; }

                        if (DR2["Time_10"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[15].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[15].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[15].Style.BackColor = Color.Black; }

                        if (DR2["Time_11"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[16].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[16].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[16].Style.BackColor = Color.Black; }

                        if (DR2["Time_12"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[17].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[17].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[17].Style.BackColor = Color.Black; }

                        if (DR2["Time_13"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[18].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[18].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[18].Style.BackColor = Color.Black; }

                        if (DR2["Time_14"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[19].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[19].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[19].Style.BackColor = Color.Black; }

                        if (DR2["Time_15"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[20].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[20].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[20].Style.BackColor = Color.Black; }

                        if (DR2["Time_16"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[21].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[21].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[21].Style.BackColor = Color.Black; }

                        if (DR2["Time_17"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[22].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[22].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[22].Style.BackColor = Color.Black; }

                        if (DR2["Time_18"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[23].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[23].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[23].Style.BackColor = Color.Black; }

                        if (DR2["Time_19"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[24].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[24].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[24].Style.BackColor = Color.Black; }

                        if (DR2["Time_20"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[25].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[25].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[25].Style.BackColor = Color.Black; }

                        if (DR2["Time_21"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[26].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[26].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[26].Style.BackColor = Color.Black; }

                        if (DR2["Time_22"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[27].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[27].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[27].Style.BackColor = Color.Black; }

                        if (DR2["Time_23"].ToString() == "True")
                        {
                            this.dtg_Rectime.Rows[i].Cells[28].Style.BackColor = Color.LemonChiffon;
                        }
                        else { this.dtg_Rectime.Rows[i].Cells[28].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[28].Style.BackColor = Color.Black; }


                        //if (DR2["Time_22"].ToString() == "True")
                        //{
                        //    this.dtg_Rectime.Rows[i].Cells[29].Style.BackColor = Color.LightGreen;
                        //}
                        //else { this.dtg_Rectime.Rows[i].Cells[29].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[29].Style.BackColor = Color.Black; }


                        //if (DR2["Time_23"].ToString() == "True")
                        //{
                        //    this.dtg_Rectime.Rows[i].Cells[30].Style.BackColor = Color.LightGreen;
                        //}
                        //else { this.dtg_Rectime.Rows[i].Cells[30].ReadOnly = true; this.dtg_Rectime.Rows[i].Cells[30].Style.BackColor = Color.Black; }

                        string Date = dtp_history.Value.Month + "-" + dtp_history.Value.Day + "-" + dtp_history.Value.Year;




                        for (int x = 0; x < dtg_Rectime.ColumnCount; x++)
                        {
                            //AND  DT_TimeStamp Between'05-14-2021 00:00:00' AND '05-14-2021 23:59:59'

                           this.dtg_Rectime.Columns[x].SortMode = DataGridViewColumnSortMode.NotSortable;

                            con1.Open();
                            string sql3 = "Select  [DT_Value],[DT_Status]  FROM [dbo].[TB_DataTransection]  Where [Tag_no] ='" + dtg_Rectime.Rows[i].Cells[29].Value.ToString().Trim() + "' AND [DT_Time] ='" + dtg_Rectime.Columns[x].HeaderText.Trim() + "' AND DT_TimeStamp Between'"+ Date + " 00:00:00' AND '"+ Date + " 23:59:59'";
                            SqlCommand CM3 = new SqlCommand(sql3, con1);
                            SqlDataReader DR3 = CM3.ExecuteReader();
                            DR3.Read();
                            {
                                if (x >= 5)
                                {
                                    try
                                    {
                                        if (this.dtg_Rectime.Rows[i].Cells[x].Style.BackColor != Color.Black)
                                        {
                                            dtg_Rectime.Rows[i].Cells[x].Value = DR3["DT_Value"].ToString();

                                            if (DR3["DT_Status"].ToString() == "True")
                                            {
                                                this.dtg_Rectime.Rows[i].Cells[x].Style.BackColor = Color.LightGreen;
                                                this.dtg_Rectime.Rows[i].Cells[x].ReadOnly = true;

                                            }

                                            else {

                                                this.dtg_Rectime.Rows[i].Cells[x].Style.BackColor = Color.Orange;
                                                this.dtg_Rectime.Rows[i].Cells[x].ReadOnly = false; }
                                        }
                                    }
                                    catch { }
                                }
                            }
                            DR3.Close();
                            con1.Close();
                        }
                    }
                    DR2.Close();
                    con.Close();
                }

                if (chk_detail.Checked == true)
                {
                    dtg_Rectime.Columns[0].Width = 0;
                    dtg_Rectime.Columns[1].Width = 0;
                    dtg_Rectime.Columns[2].Width = 0;

                    dtg_Rectime.Columns[0].HeaderText = "";
                    dtg_Rectime.Columns[1].HeaderText = "";
                    dtg_Rectime.Columns[2].HeaderText = "";
                }
                else
                {
                    dtg_Rectime.Columns[0].Width = 70;
                    dtg_Rectime.Columns[1].Width = 80;
                    dtg_Rectime.Columns[2].Width = 140;

                    dtg_Rectime.Columns[0].HeaderText = "Index";
                    dtg_Rectime.Columns[1].HeaderText = "Tag ID";
                    dtg_Rectime.Columns[2].HeaderText = "Tag Name";

                }

            }
            catch { }

            //dataGridView1.Columns["MyColumn"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtg_Rectime.ClearSelection();
        }

        private void Load_Value()
        {


        }
                     

        private void Load_ConnecDB()
        {

            StreamReader sw = new StreamReader(Application.StartupPath + "\\cnDB.dll");
            string connecpovider = sw.ReadToEnd();

            try
            {
                Program.CN = new SqlConnection();
                Program.CN.ConnectionString = connecpovider;
                Program.pahtdb = connecpovider;
            }
            catch
            {
                //MessageBox.Show("Is Not Connection to Database..", "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();

                DialogResult answer;
                answer = MessageBox.Show("Database Navision Is't Connect!! Pls. check CN1.dll in Debug Folder!! ", "Connection to Databas Failed", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (answer == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }
        private void Load_PLCName()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            try
            {
                //Product 
                //cbo_status.DataSource = null;
                SqlCommand cmd = new SqlCommand("Select [PLC_no],[PLC_Name]  From .[dbo].[TB_PLC] ", con);
                DataSet ds = new DataSet();
                //ds.Clear();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();
                //Load product tab weight scale Setup
                cbo_PLC.DataSource = ds.Tables[0];
                cbo_PLC.DisplayMember = "PLC_Name";
                cbo_PLC.ValueMember = "PLC_no";
                cbo_PLC.Text = "-- Select PLC --";
            }

            catch { }

        }

        private void cbo_PLC_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DTG_RecordTime();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txt_RecCratedate.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void chk_detail_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_detail.Checked == true)
            {
                dtg_Rectime.Columns[0].Width = 0;
                dtg_Rectime.Columns[1].Width = 0;
                dtg_Rectime.Columns[2].Width = 0;

                dtg_Rectime.Columns[0].HeaderText = "";
                dtg_Rectime.Columns[1].HeaderText = "";
                dtg_Rectime.Columns[2].HeaderText = "";
            }
            else {

                dtg_Rectime.Columns[0].Width = 70;
                dtg_Rectime.Columns[1].Width = 160;
                dtg_Rectime.Columns[2].Width = 140;

                dtg_Rectime.Columns[0].HeaderText = "Index";
                dtg_Rectime.Columns[1].HeaderText = "Tag ID";
                dtg_Rectime.Columns[2].HeaderText = "Tag Name";

            }
        }

        private void btn_RecordSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            //con.Open();

            DateTime dt_c = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")));

            string F_date = "";          

            if (STS_edit == 1)
            {
                F_date = dtp_history.Value.ToString("MM-dd-yyyy");              
                id_save = 1;
            }

            else { F_date = dtp_history.Value.ToString("MM-dd-yyyy"); }

            for (int i = 0; i < dtg_Rectime.RowCount; i++)
            {

                for (int x = 5; x < 29; x++)
                {
                    if (dtg_Rectime.Rows[i].Cells[x].Style.BackColor == Color.Orange)
                    {
                        string sql2 = "Update [TB_DataTransection] Set  [DT_Value]= '" + dtg_Rectime.Rows[i].Cells[x].Value.ToString().Trim() + "',[DT_Status]=1 Where [Tag_no]=" + dtg_Rectime.Rows[i].Cells[29].Value.ToString().Trim() + " AND  [DT_Time]= '" + dtg_Rectime.Columns[x].HeaderText.ToString().Trim() + "' AND CONVERT(varchar, [DT_TimeStamp], 110) ='" + F_date + "'";

                        con.Open();
                        SqlCommand CM2 = new SqlCommand(sql2, con);
                        SqlDataReader DR2 = CM2.ExecuteReader();
                        con.Close();
                    }
                }
            }



            Load_DTG_RecordTime();
            //Load_DTG_RecordTime_1();
            btn_RecordSave.Enabled = false;
            btn_RecordSave.BackColor = Color.DarkGray;
        }

        private void Save_Recoad()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            //con.Open();
            string sql2 = "";

            DateTime dt_c = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")));

            string F_date = "";
            string F_time = "";

            if (STS_edit == 1)
            {
                F_date = dtp_history.Value.ToString("MM-dd-yyyy");
                F_time = dtg_Rectime.Columns[e_ColIndex].HeaderText.ToString().Trim() + ":00:00";
                id_save = 1;
            }

            else { F_date = dtp_history.Value.ToString("MM-dd-yyyy"); F_time = DateTime.Now.ToString("HH:mm:ss"); }

            string st_time = dtg_Rectime.Columns[e_ColIndex].HeaderText.ToString().Trim();
            int startIndex = 0;
            int endIndex = st_time.Length - 3;
            string title = st_time.Substring(startIndex, endIndex);

            string ed_time = title + ":59";

            if (dtg_Rectime.Rows[e_RowIndex].Cells[e_ColIndex].Value.ToString().Trim() != "")
            {
                try
                {

                    if (id_save == 1)
                    {
                        con.Open();

                        string sql3 = "Select Count([DT_Value]) AS 'Items_C'  FROM [dbo].[TB_DataTransection]  Where [Tag_no]=" + dtg_Rectime.Rows[e_RowIndex].Cells[29].Value.ToString().Trim() + " AND  [DT_Time]= '" + dtg_Rectime.Columns[e_ColIndex].HeaderText.ToString().Trim() + "' AND CONVERT(varchar, [DT_TimeStamp], 110) ='" + F_date + "' ";

                        //string sql3 = "Select Count([DT_Value]) AS 'Items_C'  FROM [dbo].[TB_DataTransection]  Where [Tag_no]=" + dtg_Rectime.Rows[e_RowIndex].Cells[29].Value.ToString().Trim() + " AND  [DT_Time]= '" + dtg_Rectime.Columns[e_ColIndex].HeaderText.ToString().Trim() + "' AND [DT_TimeStamp] Between '" + F_date + " " + st_time + ":00.000' AND '" + F_date + " " + ed_time + ":59.000'";


                        SqlCommand CM3 = new SqlCommand(sql3, con);
                        SqlDataReader DR3 = CM3.ExecuteReader();
                        DR3.Read();
                        {
                            if (Convert.ToInt16(DR3["Items_C"].ToString()) != 0)
                            {

                                sql2 = "Update [TB_DataTransection] Set  [DT_Value]= '" + dtg_Rectime.Rows[e_RowIndex].Cells[e_ColIndex].Value.ToString().Trim() + "',[DT_Status]=0 Where [Tag_no]=" + dtg_Rectime.Rows[e_RowIndex].Cells[29].Value.ToString().Trim() + " AND  [DT_Time]= '" + dtg_Rectime.Columns[e_ColIndex].HeaderText.ToString().Trim() + "' AND CONVERT(varchar, [DT_TimeStamp], 110) ='" + F_date + "' ";

                            }

                            else
                            {
                                sql2 = "Insert Into [TB_DataTransection] ([Tag_no],[DT_Value],[DT_TimeStamp],[DT_Time]) Values(" + dtg_Rectime.Rows[e_RowIndex].Cells[29].Value.ToString().Trim() + ",'" + dtg_Rectime.Rows[e_RowIndex].Cells[e_ColIndex].Value.ToString().Trim() + "', '" + Convert.ToString(F_date + " " + F_time) + "','" + dtg_Rectime.Columns[e_ColIndex].HeaderText.ToString().Trim() + "')";

                                this.dtg_Rectime.Rows[e_RowIndex].Cells[e_ColIndex].Style.BackColor = Color.Orange;
                            }
                        }
                        DR3.Close();
                        con.Close();
                    }

                    if (id_save == 2)  //confirm status
                    {
                        sql2 = "Update [TB_DataTransection] Set [DT_Status]=1  Where [Tag_no]=" + dtg_Rectime.Rows[e_RowIndex].Cells[29].Value.ToString().Trim() + " AND  [DT_Time]= '" + dtg_Rectime.Columns[e_ColIndex].HeaderText.ToString().Trim() + "' ";

                    }

                    con.Open();
                    SqlCommand CM2 = new SqlCommand(sql2, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    con.Close();
                    

                    if (id_save == 1)  //Save log
                    {
                        string sql1 = "INSERT INTO [dbo].[TB_Log]([Date_log],[Time_log],[User_change],[TagNo_change],[Value_change])VALUES('" + DateTime.Now.ToString("MM-dd-yyyy") + "', '" + DateTime.Now.ToString("HH:mm:ss") + "', '" + Program.user_id + "','" + dtg_Rectime.Rows[e_RowIndex].Cells[29].Value.ToString().Trim() + "', '" + dtg_Rectime.Rows[e_RowIndex].Cells[e_ColIndex].Value.ToString().Trim() + "')";

                        con.Open();
                        SqlCommand CM1 = new SqlCommand(sql1, con);
                        SqlDataReader DR1 = CM1.ExecuteReader();
                        con.Close();
                    }

                }
                catch
                {
                    MessageBox.Show("ประเภท/รูปแบบข้อมูล ไม่ถูกต้อง กรุณาใส่ข้อมูลที่ถูกต้องอีกครั้ง", "ใส่ประเภท/รูปแบบข้อมุลผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtg_Rectime.Rows[e_RowIndex].Cells[e_ColIndex].Value = "";
                }


            }
        }



        private void dtg_Rectime_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dtg_Rectime.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor != Color.LightGreen)
            {
                btn_RecordSave.Enabled = true;
                btn_RecordSave.BackColor = Color.DodgerBlue;
                e_RowIndex = e.RowIndex;
                e_ColIndex = e.ColumnIndex;
                id_save = 1;
                Save_Recoad();
                Load_DTG_RecordTime_1();
            }

        }

        private void dtg_Rectime_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            e_ColIndex = e.ColumnIndex;
            e_RowIndex = e.RowIndex;
            try
            {

                if (dtg_Rectime.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "" && this.dtg_Rectime.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor != Color.LightGreen)
                {
                    btn_RecordSave.Enabled = true; btn_RecordSave.BackColor = Color.DodgerBlue;
                }
                else { btn_RecordSave.Enabled = false; btn_RecordSave.BackColor = Color.DarkGray; }

            }
            catch { }


            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                // Right cliclk.
                //MessageBox.Show(e.RowIndex.ToString());
                if (STS_edit == 1)
                {
                    ContextMenu tsmiContext = new ContextMenu();
                    MenuItem Item1 = new MenuItem();

                    Item1.Text = "Unlock Edit Data!";
                    hndPass = dtg_Rectime.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    tsmiContext.MenuItems.Add(Item1);
                    e_ColIndex = e.ColumnIndex;
                    e_RowIndex = e.RowIndex;
                    Item1.Click += new EventHandler(Item1_Click);
                    tsmiContext.Show(menuStrip1, menuStrip1.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)));
                }
            }

        }

        string hndPass;
        void Item1_Click(object sender, EventArgs e)
        {
            MenuItem mID = (MenuItem)sender;

            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            String F_date = dtp_history.Value.ToString("MM-dd-yyyy");
            
            DialogResult answer;
            answer = MessageBox.Show("คุณต้องการแก้ไขข้อมูลนี้ " + hndPass.Trim() + " ใช่หรือไม่", "ยืนยันการยกเลิกใช้งานโปรแกรม!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (answer == DialogResult.OK)
            {

                string sql2 = "Update [TB_DataTransection] Set [DT_Status]=0  Where [Tag_no]=" + dtg_Rectime.Rows[e_RowIndex].Cells[29].Value.ToString().Trim() + " AND  [DT_Time]= '" + dtg_Rectime.Columns[e_ColIndex].HeaderText.ToString().Trim() + "'  AND CONVERT(varchar, [DT_TimeStamp], 110) ='" + F_date + "'";

                con.Open();
                SqlCommand CM2 = new SqlCommand(sql2, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();

                Load_DTG_RecordTime_1();

            }
        }

        private void dtp_history_ValueChanged(object sender, EventArgs e)
        {
            Load_DTG_RecordTime();
        }
    }
}
