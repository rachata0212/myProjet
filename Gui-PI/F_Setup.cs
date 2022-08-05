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

namespace Gui_PI
{
    public partial class F_Setup : Form
    {
        public F_Setup()
        {
            InitializeComponent();
        }

        int id_plc = 0;
        int id_tag = 0;
        int id_loadTag = 1;
        int id_recTime = 0;
        int id_loadRecord = 1;
        int id_LoadfromRec = 0;
        int e_rowDTG_Rectime;
        DateTime dt_c = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")));
        private void F_Setup_Load(object sender, EventArgs e)
        {
            int w = this.Width / 2;
            int c = lbl_header.Width / 2;
            lbl_header.Location = new System.Drawing.Point(w - c, 20);
          
            Load_DTG_PLC();

            txt_PLCCreatedate.Text = dt_c.ToString("dd/MM/yyyy");

        }

        private void btn_PLCSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            string sql2 = "";

            if (chk_plcNew.Checked == true)
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US")) + ' ' + DateTime.Now.ToString("HH:mm:ss");

                sql2 = "Insert Into [TB_PLC] ([PLC_CreateDate],[PLC_Name],[PLC_EngineNo],[PLC_ModuleNo],[PLC_Remark]) Values('" + date + "', '" + txt_PLCName.Text + "', '" + txt_PLCEngineNo.Text.Trim() + "', '" + txt_PLCModuleNo.Text.Trim() + "','" + txt_PLCRemark.Text.Trim() + "')";
            }

            else
            {
                sql2 = "Update [TB_PLC] Set [PLC_Name]='" + txt_PLCName.Text + "',[PLC_EngineNo]='" + txt_PLCEngineNo.Text.Trim() + "',[PLC_ModuleNo]= '" + txt_PLCModuleNo.Text.Trim() + "',[PLC_Remark]='" + txt_PLCRemark.Text.Trim() + "' Where [PLC_no]=" + id_plc + " ";
            }

            SqlCommand CM2 = new SqlCommand(sql2, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();
            Load_DTG_PLC();
            CLS_ObjectPLC();
            btn_PLCSave.Enabled = false;
        }

        private void CLS_ObjectPLC()
        {
            txt_PLCEngineNo.Clear();
            txt_PLCModuleNo.Clear();
            txt_PLCName.Clear();
            txt_PLCRemark.Clear();
            txt_PLCName.Focus();
        }

        //CLS_ObjectTAG
        private void CLS_ObjectTAG()
        {
            cbo_tagPLCName.Text = "-- Select PLC --";
            cbo_TagUnit.Text = "-- Select Unit Type --";
            txt_tagID.Clear();
            txt_TagName.Clear();
            txt_TagAddress.Clear();
            txt_TagConlrollimit.Clear();
            txt_tagRemark.Clear();
        }
                     

        private void Load_DTG_PLC()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pahtdb);
                con.ConnectionString = Program.pahtdb;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                //prot_form
                dtg_plc.DataSource = null;
                string sql1 = "SELECT * FROM [dbo].[TB_PLC] ";

                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_plc");
                dtg_plc.DataSource = ds1.Tables["g_plc"];

                dtg_plc.Columns[0].Width = 100;
                dtg_plc.Columns[1].Width = 200;
                //dtg_weightPurchase.Columns[2].Width = 80;
                //dtg_weightPurchase.Columns[3].Width = 40;

                con.Close();
            }
            catch { }
        }

        private void Load_DTG_TagAddress()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pahtdb);
                con.ConnectionString = Program.pahtdb;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                //prot_form
                //dtg_tag.DataSource = null;

                string sql1 = "";

                if (id_loadTag == 1)
                {
                    sql1 = "SELECT * FROM [dbo].[V_TagAddress] ";
                }

                if (id_loadTag == 2)
                {
                    sql1 = "SELECT * FROM [dbo].[V_TagAddress] Where [PLC_no]=" + cbo_tagPLCName.SelectedValue.ToString().Trim() + " ";
                }

                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_tag");
                dtg_tag.DataSource = ds1.Tables["g_tag"];

                dtg_tag.Columns[0].Width = 100;
                dtg_tag.Columns[1].Width = 200;
                dtg_tag.Columns[2].Width = 120;
                dtg_tag.Columns[3].Width = 120;
                dtg_tag.Columns[4].Width = 160;
                dtg_tag.Columns[5].Width = 160;
                //dtg_tag.Columns[8].Width = 0;
                dtg_tag.Columns[9].Width = 0;
                dtg_tag.Columns[10].Width = 0;

                con.Close();
            }
            catch { }
        }
               
        private void Load_DTG_RecordTime()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pahtdb);
                con.ConnectionString = Program.pahtdb;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                //prot_form
                //dtg_Rectime.DataSource = null;
                string sql1 = "";

                if (id_loadRecord == 1)
                {
                    sql1 = "SELECT 	[RTS_no] AS 'Index',[PLC_Name] AS 'PLC Name',[Tag_ID] AS 'Tag ID',[Tag_Name] AS 'Tag Name',[Tag_Address] AS 'Tag Address',[Unit_Name] AS 'Unit',[RTS_Status] AS 'Status',[Time_00] AS '00',[Time_01] AS '01',[Time_02] AS '02',[Time_03] AS '03',[Time_04] AS '04',[Time_05] AS '05',[Time_06] AS '06',[Time_07] AS '07',[Time_08] AS '08',[Time_09] AS '09',[Time_10] AS '10',[Time_11] AS '11',[Time_12] AS '12',[Time_13] AS '13',[Time_14] AS '14',[Time_15] AS '15',[Time_16] AS '16',[Time_17] AS '17',[Time_18] AS '18',[Time_19] AS '19',[Time_20] AS '20',[Time_21] AS '21',[Time_22] AS '22',[Time_23] AS '23' FROM [dbo].[V_TagRecordSetup] ";
                }

                if (id_loadRecord == 2)
                {
                    sql1 = "SELECT 	[RTS_no] AS 'Index',[PLC_Name] AS 'PLC Name',[Tag_ID] AS 'Tag ID',[Tag_Name] AS 'Tag Name',[Tag_Address] AS 'Tag Address',[Unit_Name] AS 'Unit',[RTS_Status] AS 'Status',[Time_00] AS '00',[Time_01] AS '01',[Time_02] AS '02',[Time_03] AS '03',[Time_04] AS '04',[Time_05] AS '05',[Time_06] AS '06',[Time_07] AS '07',[Time_08] AS '08',[Time_09] AS '09',[Time_10] AS '10',[Time_11] AS '11',[Time_12] AS '12',[Time_13] AS '13',[Time_14] AS '14',[Time_15] AS '15',[Time_16] AS '16',[Time_17] AS '17',[Time_18] AS '18',[Time_19] AS '19',[Time_20] AS '20',[Time_21] AS '21',[Time_22] AS '22',[Time_23] AS '23' FROM [dbo].[V_TagRecordSetup] Where [PLC_no]=" + cbo_RecPLC.SelectedValue.ToString().Trim() + " ";
                }

                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_rectime");
                dtg_Rectime.DataSource = ds1.Tables["g_rectime"];
                con.Close();

                dtg_Rectime.Columns[0].Width = 70;
                dtg_Rectime.Columns[1].Width = 160;
                dtg_Rectime.Columns[2].Width = 140;
                dtg_Rectime.Columns[3].Width = 160;
                dtg_Rectime.Columns[4].Width = 160;
                dtg_Rectime.Columns[5].Width = 80;
                dtg_Rectime.Columns[6].Width = 90;
                dtg_Rectime.Columns[7].Width = 40;
                dtg_Rectime.Columns[8].Width = 40;
                dtg_Rectime.Columns[9].Width = 40;
                dtg_Rectime.Columns[10].Width = 40;
                dtg_Rectime.Columns[11].Width = 40;
                dtg_Rectime.Columns[12].Width = 40;
                dtg_Rectime.Columns[13].Width = 40;
                dtg_Rectime.Columns[14].Width = 40;
                dtg_Rectime.Columns[15].Width = 40;
                dtg_Rectime.Columns[16].Width = 40;
                dtg_Rectime.Columns[17].Width = 40;
                dtg_Rectime.Columns[18].Width = 40;
                dtg_Rectime.Columns[19].Width = 40;
                dtg_Rectime.Columns[20].Width = 40;
                dtg_Rectime.Columns[21].Width = 40;
                dtg_Rectime.Columns[22].Width = 40;
                dtg_Rectime.Columns[23].Width = 40;
                dtg_Rectime.Columns[24].Width = 40;
                dtg_Rectime.Columns[25].Width = 40;
                dtg_Rectime.Columns[26].Width = 40;
                dtg_Rectime.Columns[27].Width = 40;
                dtg_Rectime.Columns[28].Width = 40;
                dtg_Rectime.Columns[29].Width = 40;
                dtg_Rectime.Columns[30].Width = 40;
                //dtg_Rectime.Columns[31].Width = 40;


                this.dtg_Rectime.Columns[6].DefaultCellStyle.BackColor = Color.Green;
                                                                                                                                       

                for (int i = 0; i < dtg_Rectime.RowCount; i++)
                {
                    if (dtg_Rectime.Rows[i].Cells[7].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[8].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[9].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[10].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[11].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[11].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[12].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[13].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[13].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[14].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[14].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[15].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[15].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[16].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[16].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[17].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[17].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[18].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[18].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[19].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[19].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[20].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[20].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[21].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[21].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[22].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[22].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[23].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[23].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[24].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[24].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[25].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[25].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[26].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[26].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[27].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[27].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[28].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[28].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[29].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[29].Style.BackColor = Color.LightGreen;
                    }
                    if (dtg_Rectime.Rows[i].Cells[30].Value.ToString() == "True")
                    {
                        this.dtg_Rectime.Rows[i].Cells[30].Style.BackColor = Color.LightGreen;
                    }
                }
            }
            catch { }
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
                cbo_tagPLCName.DataSource = ds.Tables[0];
                cbo_tagPLCName.DisplayMember = "PLC_Name";
                cbo_tagPLCName.ValueMember = "PLC_no";
                cbo_tagPLCName.Text = "-- Select PLC --";

                cbo_RecPLC.DataSource = ds.Tables[0];
                cbo_RecPLC.DisplayMember = "PLC_Name";
                cbo_RecPLC.ValueMember = "PLC_no";
                cbo_RecPLC.Text = "-- Select PLC --";
            }

            catch { }

        }

        //Load_TagAddress
        private void Load_CBO_TagAddress()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            try
            {
                //Product 
                //cbo_status.DataSource = null;
                SqlCommand cmd = new SqlCommand("Select [PLC_no],[PLC_Name]  From [dbo].[TB_PLC] ", con);
                DataSet ds = new DataSet();
                //ds.Clear();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();
                //Load product tab weight scale Setup
                cbo_tagPLCName.DataSource = ds.Tables[0];
                cbo_tagPLCName.DisplayMember = "PLC_Name";
                cbo_tagPLCName.ValueMember = "PLC_no";
                cbo_tagPLCName.Text = "-- Select PLC --";
            }

            catch { }

        }

        private void Load_TagUnit()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            try
            {
                //Product 
                //cbo_status.DataSource = null;
                SqlCommand cmd = new SqlCommand("Select [Unit_no],[Unit_Name]  From [dbo].[TB_Unit] ", con);
                DataSet ds = new DataSet();
                //ds.Clear();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);

                //Load product tab weight scale Setup
                cbo_TagUnit.DataSource = ds.Tables[0];
                cbo_TagUnit.DisplayMember = "Unit_Name";
                cbo_TagUnit.ValueMember = "Unit_no";
                cbo_TagUnit.Text = "-- Select Unit Type --";
                con.Close();
            }

            catch { }

        }
                
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                chk_plcNew.Checked = false;
                Load_DTG_PLC();
            }

            if (tabControl1.SelectedIndex == 1)
            {
                chk_TagNew.Checked = false;
                Load_PLCName();
                txt_TagDate.Text = dt_c.ToString("dd/MM/yyyy");
                Load_CBO_TagAddress();
                id_loadTag = 1;
                Load_DTG_TagAddress();
                Load_TagUnit();
                CLS_ObjectTAG();
            }

            if (tabControl1.SelectedIndex == 2)
            {
                chk_RecNew.Checked = false;
                txt_RecCratedate.Text = dt_c.ToString("dd/MM/yyyy");
                Load_PLCName();
                id_loadRecord = 1;
                Load_DTG_RecordTime();
                //Load_CBO_TagAddress();                

            }

            if (tabControl1.SelectedIndex == 3) //log
            {              
                Load_UserLog();
                Load_Log();
            }

        }

        private void Load_UserLog()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            try
            {
                //Product 
                cbo_logUser.DataSource = null;
                SqlCommand cmd = new SqlCommand(" SELECT DISTINCT [User_change], TRIM([U_FullName]) AS 'U_FullName'  FROM[DBInterface_PI].[dbo].[V_log] where[Date_log] = '" + dtp_logDate.Value.ToString("yyyy-MM-dd") + "'", con);
                DataSet ds = new DataSet();
                //ds.Clear();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();
                //Load product tab weight scale Setup
                cbo_logUser.DataSource = ds.Tables[0];
                cbo_logUser.DisplayMember = "U_FullName";
                cbo_logUser.ValueMember = "User_change";
                cbo_logUser.Text = "-- Select User --";
            }

            catch { }

        }

        private void Load_Log()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            //prot_form
            dtg_log.DataSource = null;

            string sql1 = "";

            if (cbo_logUser.SelectedIndex > -1 && txt_logTagName.Text =="")
            {
                sql1 = "SELECT [ID_Log] AS 'ลำดับเหตุการณ์',[Date_log] AS 'วันที่' ,[Time_log] AS 'เวลา',[User_change] AS 'ไอดีผู้ใช้' ,[U_FullName]  AS 'ชื่อผู้ใช้' ,[Tag_Name]  AS 'ชื่อแท็ก' ,[Value_change]  AS 'ค่าที่เปลี่ยน' ,[PLC_Name]  AS 'ชื่อเครื่องจักร' FROM [DBInterface_PI].[dbo].[V_log] WHERE [Date_log] ='"+dtp_logDate.Value.ToString("yyyy-MM-dd")+ "' AND [User_change]='"+cbo_logUser.SelectedValue.ToString().ToString() + "' ORDER BY [ID_Log] DESC ";
            }

            if (cbo_logUser.SelectedIndex > -1 && txt_logTagName.Text != "")
            {
                sql1 = "SELECT [ID_Log] AS 'ลำดับเหตุการณ์',[Date_log] AS 'วันที่' ,[Time_log] AS 'เวลา',[User_change] AS 'ไอดีผู้ใช้' ,[U_FullName]  AS 'ชื่อผู้ใช้' ,[Tag_Name]  AS 'ชื่อแท็ก' ,[Value_change]  AS 'ค่าที่เปลี่ยน' ,[PLC_Name]  AS 'ชื่อเครื่องจักร' FROM [DBInterface_PI].[dbo].[V_log] WHERE [Date_log] ='" + dtp_logDate.Value.ToString("yyyy-MM-dd") + "' AND [User_change]='" + cbo_logUser.SelectedValue.ToString().ToString() + "' AND [Tag_Name] Like '%" + txt_logTagName.Text.Trim() + "%' ORDER BY [ID_Log] DESC ";
            }

            else
            {
                sql1 = "SELECT [ID_Log] AS 'ลำดับเหตุการณ์',[Date_log] AS 'วันที่' ,[Time_log] AS 'เวลา',[User_change] AS 'ไอดีผู้ใช้' ,[U_FullName]  AS 'ชื่อผู้ใช้' ,[Tag_Name]  AS 'ชื่อแท็ก' ,[Value_change]  AS 'ค่าที่เปลี่ยน' ,[PLC_Name]  AS 'ชื่อเครื่องจักร' FROM [DBInterface_PI].[dbo].[V_log] WHERE [Date_log] ='" + dtp_logDate.Value.ToString("yyyy-MM-dd") + "' ORDER BY [ID_Log] DESC";
            }

            SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "g_log");
            dtg_log.DataSource = ds1.Tables["g_log"];

            dtg_log.Columns[0].Width = 130;
            dtg_log.Columns[1].Width = 120;
            dtg_log.Columns[2].Width = 120;
        }


        private void dtg_plc_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                chk_plcNew.Checked = false;
                id_plc = Convert.ToInt16(dtg_plc.Rows[e.RowIndex].Cells[0].Value.ToString());
                txt_PLCName.Text = dtg_plc.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                txt_PLCEngineNo.Text = dtg_plc.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                txt_PLCModuleNo.Text = dtg_plc.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                txt_PLCRemark.Text = dtg_plc.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
                btn_PLCSave.Enabled = true;
            }
        }

        private void btn_TagSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            string sql2 = "";

            if (chk_TagNew.Checked == true)
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US")) + ' ' + DateTime.Now.ToString("HH:mm:ss");

                sql2 = "Insert Into [TB_TagAddress] ([Tag_CreateDate],[Tag_ID],[Tag_Name],[Tag_Address],[Tag_Controllimit],[Tag_Remark],[Unit_no],[PLC_no]) Values('" + date + "', " + txt_tagID.Text.Trim() + ", '" + txt_TagName.Text.Trim() + "', '" + txt_TagAddress.Text.Trim() + "','" + txt_TagConlrollimit.Text.Trim() + "','" + txt_tagRemark.Text.Trim() + "'," + cbo_TagUnit.SelectedValue.ToString() + "," + cbo_tagPLCName.SelectedValue.ToString() + ")";
            }

            else
            {
                sql2 = "Update [TB_TagAddress] Set [Tag_ID]=" + txt_tagID.Text.Trim() + ",[Tag_Name]= '" + txt_TagName.Text.Trim() + "',[Tag_Address]='" + txt_TagAddress.Text.Trim() + "',[Tag_Controllimit]='" + txt_TagConlrollimit.Text.Trim() + "',[Tag_Remark]='" + txt_tagRemark.Text.Trim() + "',[Unit_no]=" + cbo_TagUnit.SelectedValue.ToString() + ",[PLC_no]=" + cbo_tagPLCName.SelectedValue.ToString() + " Where [Tag_no]=" + id_tag + " ";
            }

            SqlCommand CM2 = new SqlCommand(sql2, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();
            Load_DTG_TagAddress();

        }

        private void dtg_tag_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                chk_TagNew.Checked = false;
                id_tag = Convert.ToInt16(dtg_tag.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                txt_tagID.Text = dtg_tag.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                txt_TagName.Text = dtg_tag.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                txt_TagAddress.Text = dtg_tag.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
                txt_tagRemark.Text = dtg_tag.Rows[e.RowIndex].Cells[6].Value.ToString().Trim();
                txt_TagConlrollimit.Text = dtg_tag.Rows[e.RowIndex].Cells[8].Value.ToString().Trim();
              
                cbo_TagUnit.SelectedValue = dtg_tag.Rows[e.RowIndex].Cells[9].Value.ToString().Trim();
                cbo_tagPLCName.SelectedValue = dtg_tag.Rows[e.RowIndex].Cells[10].Value.ToString().Trim();
                btn_TagSave.Enabled = true;
                btn_clear.Enabled = true;
            }

        }

        private void cbo_tagPLCName_SelectedIndexChanged(object sender, EventArgs e)
        {            
                id_loadTag = 2;
                Load_DTG_TagAddress();            
            //CLS_ObjectTAG();
        }

        private void chk_TagNew_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_TagNew.Checked == true)
            {
                btn_TagSave.Enabled = true;
                CLS_ObjectTAG();
                cbo_tagPLCName.Focus();
            }
            else { btn_TagSave.Enabled = false; }
        }

        private void chk_plcNew_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_plcNew.Checked == true)
            {
                btn_PLCSave.Enabled = true;
                CLS_ObjectPLC();
                txt_PLCName.Focus();
            }
            else { btn_PLCSave.Enabled = false; }
        }


        int Check_TagSave = 0;
        private void Load_TagSave()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql1 = "Select Count([Tag_no]) AS 'Check_TagSave'  FROM [dbo].[TB_RecordTimeSetup]  Where [Tag_no] =" + cbo_RecTag.SelectedValue.ToString() + "";

            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();
            DR1.Read();
            {               
                Check_TagSave = Convert.ToInt16(DR1["Check_TagSave"].ToString().Trim());
            }
            DR1.Close();

            con.Close();

        }


        private void btn_RecordSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            string sql2 = "";

            Load_TagSave();

            int Rec_status = 0;
            if (chk_RecStatus.Checked == true) { Rec_status = 1; }


            if (chk_RecNew.Checked == true)
            {
                if (Check_TagSave == 0)
                {
                    sql2 = "Insert Into [TB_RecordTimeSetup] ([Tag_no],[RTS_Status]) Values('" + cbo_RecTag.SelectedValue.ToString() + "', " + Rec_status + ")";
                }

                else { MessageBox.Show("Tag ID นี้ได้ถูกบันทึกในระบบแล้ว","บันทึกผิดพลาด!!",MessageBoxButtons.OK,MessageBoxIcon.Error); }

            }

            else
            {
                sql2 = "Update [TB_RecordTimeSetup] Set [RTS_Status]=" + Rec_status + " Where [RTS_no]=" + id_recTime + " ";
            }

            if (Check_TagSave == 0)
            {
                SqlCommand CM2 = new SqlCommand(sql2, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();

                id_loadTag = 2;
                Load_DTG_RecordTime();
            }
            //CLS_ObjectPLC();
        }

        private void dtg_Rectime_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                e_rowDTG_Rectime = e.RowIndex;
                id_recTime = Convert.ToInt16(dtg_Rectime.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                cbo_RecTag.Text = dtg_Rectime.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                id_LoadfromRec = 2;
                Load_RecordDetail();
            }
        }

        private void dtg_Rectime_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pahtdb);
                con.ConnectionString = Program.pahtdb;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();
                string sql2 = "";
                if (e.ColumnIndex == 6)
                {
                    int STS = 0;
                    if (dtg_Rectime.Rows[e.RowIndex].Cells[6].Value.ToString() == "True") { STS = 1; }
                    sql2 = "Update [TB_RecordTimeSetup] Set [RTS_Status]=" + STS + " Where [RTS_no]=" + id_recTime + " ";
                }


                if (e.ColumnIndex >= 7)
                {
                    int STS = 0;
                    if (dtg_Rectime.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "True") { STS = 1; }

                    sql2 = "Update [TB_RecordTimeSetup] Set [Time_" + dtg_Rectime.Columns[e.ColumnIndex].HeaderText + "]=" + STS + " Where [RTS_no]=" + id_recTime + " ";

                }

                SqlCommand CM2 = new SqlCommand(sql2, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();

                if (dtg_Rectime.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "True")
                {
                    this.dtg_Rectime.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGreen;
                }
                else { this.dtg_Rectime.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White; }

                Load_RecordDetail();
            }
            catch { }
        }

        private void cbo_RecPLC_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            try
            {
                //Product 
                //cbo_status.DataSource = null;
                id_loadRecord = 2;
                Load_DTG_RecordTime();


                SqlCommand cmd = new SqlCommand("Select [Tag_no],[Tag_Name]  From [dbo].[TB_TagAddress] Where [PLC_no]= " + cbo_RecPLC.SelectedValue.ToString().Trim() + "  ", con);
                DataSet ds = new DataSet();
                //ds.Clear();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();
                //Load product tab weight scale Setup
                cbo_RecTag.DataSource = ds.Tables[0];
                cbo_RecTag.DisplayMember = "Tag_Name";
                cbo_RecTag.ValueMember = "Tag_no";
                cbo_RecTag.Text = "-- Select Tag-Name --";
                               
                con.Close();



            }

            catch { }
        }

        private void cbo_RecTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id_LoadfromRec = 1;
                Load_RecordDetail();
            }
            catch { }
        }

        private void chk_RecNew_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_RecNew.Checked == true)
            {
                cbo_RecPLC.Enabled = true; cbo_RecTag.Enabled = true; chk_RecStatus.Enabled = true; btn_RecordSave.Enabled = true;
            }
            else
            {
                cbo_RecTag.Enabled = false; chk_RecStatus.Enabled = false;  btn_RecordSave.Enabled = false;
            }
        }

        private void Load_RecordDetail()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql1 = "";

            if (id_LoadfromRec == 0)

            {
                sql1 = "Select *  FROM [dbo].[V_TagRecordSetup]  Where [PLC_no] =" + cbo_RecPLC.SelectedValue.ToString().Trim() + "";
            }

            if (id_LoadfromRec == 1)
            {
                sql1 = "Select *  FROM [dbo].[V_TagRecordSetup]  Where [Tag_no] =" + cbo_RecTag.SelectedValue.ToString().Trim() + "";
            }
        
            if(id_LoadfromRec == 2)
            {
                sql1= "Select *  FROM [dbo].[V_TagRecordSetup]  Where [RTS_no] =" + id_recTime + "";
            }

            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();
            DR1.Read();
            {
                lbl_Recdetail1.Text = "Tag-Create:" + DR1["Tag_CreateDate"].ToString().Trim() + ", Tag_Controllimit:" + DR1["Tag_Controllimit"].ToString().Trim();
                lbl_Recdetail2.Text = "Tag-Remark:" + DR1["Tag_Remark"].ToString().Trim();
            }
            DR1.Close();

            int st_enable = 0;
            int st_disable = 0;

            for (int i = 0; i < dtg_Rectime.ColumnCount; i++)
            {
                if (i > 6)
                {
                    if (dtg_Rectime.Rows[e_rowDTG_Rectime].Cells[i].Value.ToString() == "True")
                    {
                        st_enable++;
                       // this.dtg_Rectime.Rows[e_rowDTG_Rectime].Cells[i].Style.BackColor = Color.LightGreen;
                    }

                    else { st_disable++; }
                }

            }

            lbl_Recdetail2.Text += ", Enable: " + st_enable.ToString() + " Job, Disable: " + st_disable.ToString() + " Job";


            con.Close();

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            chk_TagNew.Checked = false;
            Load_PLCName();
            txt_TagDate.Text = dt_c.ToString("dd/MM/yyyy");
            Load_CBO_TagAddress();
            id_loadTag = 1;
            Load_DTG_TagAddress();
            Load_TagUnit();
            CLS_ObjectTAG();
        }

        private void btn_clsRecord_Click(object sender, EventArgs e)
        {
            chk_RecNew.Checked = false;
            txt_RecCratedate.Text = dt_c.ToString("dd/MM/yyyy");
            id_loadRecord = 1;
            Load_DTG_RecordTime();
            Load_CBO_TagAddress();
            cbo_RecPLC.Text = "-- Select PLC --";
        }

        private void dtp_logDate_ValueChanged(object sender, EventArgs e)
        {
            Load_Log();
            Load_UserLog();
        }

        private void cb_logUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Log();
        }

        private void txt_logTagName_TextChanged(object sender, EventArgs e)
        {
            Load_Log();
        }

    
    }
}
