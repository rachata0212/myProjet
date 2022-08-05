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
    public partial class Sub_Fregister : Form
    {
        public Sub_Fregister()
        {
            InitializeComponent();
        }

        int id_ProcessRegister = 0;
        // Log
        string Msg = "";
        string Log_OldValue = "-";
        string Log_NewValue = "-";

        int e_RowIndex = 0;
        int e_ColIndex = 0;
        int ID_OverStep = 0;

        private void cbo_product_register_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_ProcessRegister = 1;
            Load_DTGProcess();
            Load_RegiterSetup();
            Load_OverStep();
            Load_ProcessType();
        }

        private void Load_ProcessType()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select prot_id,Trim(prot_form) as 'prot_form' From  [dbo].[TB_ProcessType] ", con);

            DataSet ds1 = new DataSet();
            //ds.Clear();
            SqlDataAdapter da1 = new SqlDataAdapter();
            da1.SelectCommand = cmd;
            da1.Fill(ds1);
            //Load product tab weight scale Setup
            cbo_registerType.DataSource = ds1.Tables[0];
            cbo_registerType.DisplayMember = "prot_form";
            cbo_registerType.ValueMember = "prot_id";

        }

        private void Load_RegiterExample()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * From  [dbo].[TB_Ticket_Exam] ", con);

            DataSet ds1 = new DataSet();
            //ds.Clear();
            SqlDataAdapter da1 = new SqlDataAdapter();
            da1.SelectCommand = cmd;
            da1.Fill(ds1);
            //Load product tab weight scale Setup
            cbo_typeTicket_register.DataSource = ds1.Tables[0];
            cbo_typeTicket_register.DisplayMember = "Exam_Name";
            cbo_typeTicket_register.ValueMember = "Exam_ID";

        }

        private void Load_RegiterSetup()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                int ID_Exam = 0;

                Load_RegiterExample();

                Load_Cler_QRCODE();

                string sql6 = "SELECT * FROM [dbo].[TB_RegisterSetup] WHERE [Reg_ProductID] = '" + cbo_product_register.SelectedValue.ToString() + "'";
                SqlCommand CM6 = new SqlCommand(sql6, con);
                SqlDataReader DR6 = CM6.ExecuteReader();

                DR6.Read();
                {
                    ID_Exam = Convert.ToInt16(DR6["Exam_ID"].ToString().Trim());

                    if (DR6["Reg_BackDate"].ToString().Trim() == "True")
                    {
                        tg_registBackDate.Checked = true;
                    }
                    else { tg_registBackDate.Checked = false; }


                    if (DR6["Reg_SearchHistory"].ToString().Trim() == "True")
                    {
                        tg_registSearchHistory.Checked = true;
                    }
                    else { tg_registSearchHistory.Checked = false; }


                    if (DR6["Reg_chkRmk1"].ToString().Trim() == "True")
                    {
                        tg_regRmk1.Checked = true;
                        txt_regRmk1.Enabled = true;
                        lbl_countRegrmk1.Text = txt_regRmk1.TextLength.ToString();
                    }
                    else { tg_regRmk1.Checked = false; txt_regRmk1.Enabled = false; }


                    if (DR6["Reg_chkRmk2"].ToString().Trim() == "True")
                    {
                        tg_regRmk2.Checked = true;
                        txt_regRmk2.Enabled = true;
                        lbl_countRegrmk2.Text = txt_regRmk2.TextLength.ToString();
                    }
                    else { tg_regRmk2.Checked = false; txt_regRmk2.Enabled = false; }


                    if (DR6["Reg_chkRmk3"].ToString().Trim() == "True")
                    {
                        tg_regRmk3.Checked = true;
                        txt_regRmk3.Enabled = true;
                        lbl_countRegrmk3.Text = txt_regRmk3.TextLength.ToString();
                    }
                    else { tg_regRmk3.Checked = false; txt_regRmk3.Enabled = false; }


                    if (DR6["Reg_chkRmk4"].ToString().Trim() == "True")
                    {
                        tg_regRmk4.Checked = true;
                        txt_regRmk4.Enabled = true;
                        lbl_countRegrmk4.Text = txt_regRmk4.TextLength.ToString();
                    }
                    else { tg_regRmk4.Checked = false; txt_regRmk4.Enabled = false; }


                    if (DR6["Reg_chkRmk5"].ToString().Trim() == "True")
                    {
                        tg_regRmk5.Checked = true;
                        txt_regRmk5.Enabled = true;
                        lbl_countRegrmk5.Text = txt_regRmk5.TextLength.ToString();
                    }
                    else { tg_regRmk5.Checked = false; txt_regRmk5.Enabled = false; }

                    cbo_typeTicket_register.SelectedValue = DR6["Exam_ID"].ToString().Trim();


                    txt_regRmk1.Text = DR6["Reg_Rmk1"].ToString().Trim();
                    txt_regRmk2.Text = DR6["Reg_Rmk2"].ToString().Trim();
                    txt_regRmk3.Text = DR6["Reg_Rmk3"].ToString().Trim();
                    txt_regRmk4.Text = DR6["Reg_Rmk4"].ToString().Trim();
                    txt_regRmk5.Text = DR6["Reg_Rmk5"].ToString().Trim();

                }
                DR6.Close();
                con.Close();

                cbo_typeTicket_register.SelectedValue = ID_Exam;

            }
            catch {
                Load_Cler_QRCODE();
            }



        }

        private void Load_DTGProcess()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                dtg_registerProcess.DataSource = null;

                string sql1 = "";
                if (id_ProcessRegister == 0)
                {
                    sql1 = "SELECT [proc_no] AS 'รหัส',[proc_lelvel] AS 'ขั้นตอน',[proc_name] AS 'ลำดับงาน',[prot_id] AS 'ประเภท',[prot_form] AS 'ชื่อประเภท',[proc_atMode] AS 'นอกเวลา(Auto)',[prot_description] AS 'คำอธิบายประเภท' FROM  [dbo].[V_Process]";
                }

                else { sql1 = "SELECT [proc_no] AS 'รหัส',[proc_lelvel] AS 'ขั้นตอน',[proc_name] AS 'ลำดับงาน',[prot_id] AS 'ประเภท',[prot_form] AS 'ชื่อประเภท',[proc_atMode] AS 'นอกเวลา(Auto)',[prot_description] AS 'คำอธิบายประเภท' FROM  [dbo].[V_Process] Where [item_no]='" + cbo_product_register.SelectedValue.ToString().Trim() + "'"; }
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "v_process");
                dtg_registerProcess.DataSource = ds1.Tables["v_process"];
                con.Close();
                                     
                //dtg_registerProcess.Columns[2].Width = 200;

                txt_OverStepID.Clear();
                txt_OverStepName.Clear();
                txt_vencusNo_OverStep.Clear();
                txt_vencusName.Clear();
                chk_overStep.Checked = false;
                chk_StsActiveOverStep.Checked = false;
                dtg_OverStep.DataSource = null;
                ID_OverStep = 0;

                Adjust_Dtg_NormalProcess();

            }
            catch { }
        }

        private void Adjust_Dtg_NormalProcess()
        {

            dtg_registerProcess.Columns[5].DefaultCellStyle.BackColor = Color.LightGreen;
            dtg_registerProcess.Columns[0].ReadOnly = true;
            dtg_registerProcess.Columns[1].ReadOnly = true;
            dtg_registerProcess.Columns[2].ReadOnly = true;
            dtg_registerProcess.Columns[3].ReadOnly = true;
            dtg_registerProcess.Columns[4].ReadOnly = true;
            dtg_registerProcess.Columns[6].ReadOnly = true;

            if (chk_showOverprocess.Checked == true)
            {
                gb_process.Dock = DockStyle.Left;
                gb_overprocess.Visible = true;
                gb_overprocess.Dock = DockStyle.Fill;                

                dtg_registerProcess.Columns[0].Width = 80;
                dtg_registerProcess.Columns[1].Width = 80;
                dtg_registerProcess.Columns[2].Width = 120;
                dtg_registerProcess.Columns[3].Width = 80;
                dtg_registerProcess.Columns[4].Width = 130;
                dtg_registerProcess.Columns[5].Width = 120;
            }

            else
            {
                gb_process.Dock = DockStyle.Fill;
                gb_overprocess.Visible = false;

                dtg_registerProcess.Columns[0].Width = 80;
                dtg_registerProcess.Columns[1].Width = 80;
                dtg_registerProcess.Columns[2].Width = 120;
                dtg_registerProcess.Columns[3].Width = 80;
                dtg_registerProcess.Columns[4].Width = 130;
                dtg_registerProcess.Columns[5].Width = 120;
            }
        }
                   

        private void btn_SetupregisterSave_Click(object sender, EventArgs e)
        {
            Save_RegisterSetup();
        }

        private void Save_RegisterSetup()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            int STS_RollBackDate = 0;
            int STS_SearchHistory = 0;
            int STS_Rmk1 = 0;
            int STS_Rmk2 = 0;
            int STS_Rmk3 = 0;
            int STS_Rmk4 = 0;
            int STS_Rmk5 = 0;

            int Count_Reg = 0;

            string sql6 = "SELECT Count([Reg_ProductID]) AS 'Reg_ProductID' FROM [dbo].[TB_RegisterSetup] WHERE [Reg_ProductID]= '" + cbo_product_register.SelectedValue.ToString() + "'";
            SqlCommand CM6 = new SqlCommand(sql6, con);
            SqlDataReader DR6 = CM6.ExecuteReader();

            DR6.Read();
            {
                Count_Reg = Convert.ToInt16(DR6["Reg_ProductID"].ToString().Trim());
            }
            DR6.Close();
            con.Close();


            string sql = "";
            if (tg_registBackDate.Checked == true)
            {
                STS_RollBackDate = 1;
            }

            if (tg_registSearchHistory.Checked == true)
            {
                STS_SearchHistory = 1;
            }

            if (tg_regRmk1.Checked == true)
            { STS_Rmk1 = 1; }

            if (tg_regRmk2.Checked == true)
            { STS_Rmk2 = 1; }

            if (tg_regRmk3.Checked == true)
            { STS_Rmk3 = 1; }

            if (tg_regRmk4.Checked == true)
            { STS_Rmk4 = 1; }

            if (tg_regRmk5.Checked == true)
            { STS_Rmk5 = 1; }

            if (Count_Reg == 0)  // insert into
            {
                sql = "Insert into [dbo].[TB_RegisterSetup] ([Reg_BackDate],[Exam_ID],[Reg_ProductID],[Reg_Searchhistory],[Reg_chkRmk1],[Reg_chkRmk2],[Reg_chkRmk3],[Reg_chkRmk4],[Reg_chkRmk5],[Reg_Rmk1],[Reg_Rmk2],[Reg_Rmk3],[Reg_Rmk4],[Reg_Rmk5]) Values (" + STS_RollBackDate + "," + cbo_typeTicket_register.SelectedValue.ToString() + ",'" + cbo_product_register.SelectedValue.ToString() + "'," + STS_SearchHistory + "," + STS_Rmk1 + "," + STS_Rmk2 + "," + STS_Rmk3 + "," + STS_Rmk4 + "," + STS_Rmk5 + ",'" + txt_regRmk1.Text.Trim() + "','" + txt_regRmk2.Text.Trim() + "','" + txt_regRmk3.Text.Trim() + "','" + txt_regRmk4.Text.Trim() + "','" + txt_regRmk5.Text.Trim() + "')";

                Msg = "Insert New Visual type Name on Ticket!";
                Log_NewValue = "Reg_BackDate = " + STS_RollBackDate.ToString() +
                    "," + "Exam_ID = " + cbo_typeTicket_register.SelectedValue.ToString() +
                    "," + "Reg_ProductID = " + cbo_product_register.SelectedValue.ToString() +
                    "," + "Reg_Searchhistory = " + STS_SearchHistory.ToString() +
                    "," + "Reg_chkRmk1 = " + STS_Rmk1.ToString() +
                    "," + "Reg_chkRmk2 = " + STS_Rmk2.ToString() +
                    "," + "Reg_chkRmk3 = " + STS_Rmk3.ToString() +
                    "," + "Reg_chkRmk4 = " + STS_Rmk4.ToString() +
                    "," + "Reg_chkRmk5 = " + STS_Rmk5.ToString() +
                    "," + "Reg_Rmk1 = " + txt_regRmk1.Text.Trim() +
                    "," + "Reg_Rmk2 = " + txt_regRmk2.Text.Trim() +
                    "," + "Reg_Rmk3 = " + txt_regRmk3.Text.Trim() +
                    "," + "Reg_Rmk4 = " + txt_regRmk4.Text.Trim() +
                    "," + "Reg_Rmk5 = " + txt_regRmk5.Text.Trim();
                Log_OldValue = "-";
            }

            // update
            else
            {
                sql = "Update [dbo].[TB_RegisterSetup] Set [Reg_BackDate]=" + STS_RollBackDate + ",[Exam_ID]=" + cbo_typeTicket_register.SelectedValue.ToString() + ",[Reg_Searchhistory]=" + STS_SearchHistory + ",[Reg_chkRmk1]=" + STS_Rmk1 + ",[Reg_chkRmk2]=" + STS_Rmk2 + ",[Reg_chkRmk3]=" + STS_Rmk3 + ",[Reg_chkRmk4]=" + STS_Rmk4 + ",[Reg_chkRmk5]=" + STS_Rmk5 + ",[Reg_Rmk1]='" + txt_regRmk1.Text.Trim() + "',[Reg_Rmk2]='" + txt_regRmk2.Text.Trim() + "',[Reg_Rmk3]='" + txt_regRmk3.Text.Trim() + "',[Reg_Rmk4]='" + txt_regRmk4.Text.Trim() + "',[Reg_Rmk5]='" + txt_regRmk5.Text.Trim() + "' WHERE [Reg_ProductID]='" + cbo_product_register.SelectedValue.ToString() + "'";

                Msg = "Update New Visual type Name on Ticket!";
                Log_OldValue = "Reg_BackDate = " + STS_RollBackDate.ToString() +
                     "," + "Exam_ID = " + cbo_typeTicket_register.SelectedValue.ToString() +
                     "," + "Reg_Searchhistory = " + STS_SearchHistory.ToString() +
                     "," + "Reg_chkRmk1 = " + STS_Rmk1.ToString() +
                     "," + "Reg_chkRmk2 = " + STS_Rmk2.ToString() +
                     "," + "Reg_chkRmk3 = " + STS_Rmk3.ToString() +
                     "," + "Reg_chkRmk4 = " + STS_Rmk4.ToString() +
                     "," + "Reg_chkRmk5 = " + STS_Rmk5.ToString() +
                     "," + "Reg_Rmk1 = " + txt_regRmk1.Text.Trim() +
                     "," + "Reg_Rmk2 = " + txt_regRmk2.Text.Trim() +
                     "," + "Reg_Rmk3 = " + txt_regRmk3.Text.Trim() +
                     "," + "Reg_Rmk4 = " + txt_regRmk4.Text.Trim() +
                     "," + "Reg_Rmk5 = " + txt_regRmk5.Text.Trim() +
                     "," + "Where Reg_ProductID = " + cbo_product_register.SelectedValue.ToString();
                Log_NewValue = "-";
            }

            con.Open();
            SqlCommand CM2 = new SqlCommand(sql, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();

            Class_Log CL = new Class_Log();
            CL.tbname = Msg;
            CL.oldvalue = Log_OldValue;
            CL.newvalue = Log_NewValue;
            CL.Save_log();

            Load_Cler_QRCODE();
        }

        private void cbo_registerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Process();
        }

        private void Load_Process()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();
                string sql1 = "Select prot_description From [dbo].[TB_ProcessType] Where [prot_id]='" + cbo_registerType.SelectedValue.ToString().Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                DR1.Read();
                {
                    lbl_registerDescription.Text = DR1["prot_description"].ToString();
                }
                DR1.Close();
                con.Close();
            }
            catch { }

        }

        private void btn_FlowregisterSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            string sql = "";

            if (rdo_registerNew.Checked == true)
            {
                con.Open();
                sql = "INSERT INTO [dbo].[TB_Process]([proc_name],[proc_lelvel],[proc_type],[item_no]) VALUES('" + txt_register_Name.Text + "'," + cbo_registerLevel.Text.Trim() + ",'" + cbo_registerType.SelectedValue.ToString() + "','" + cbo_product_register.SelectedValue.ToString() + "')";

                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();

                Msg = "Insert New Record in Flow Process!";
                Log_NewValue = "proc_name = " + txt_register_Name.Text.Trim() +
                        "," + "proc_lelvel = " + cbo_registerLevel.Text.Trim() +
                        "," + "proc_type = " + cbo_registerType.SelectedValue.ToString() +
                        "," + "item_no = " + cbo_product_register.SelectedValue.ToString();
                Log_OldValue = "-";

                Load_DTGProcess();

            }

            if (rdo_registerEdit.Checked == true)
            {

                con.Open();
                sql = "Update [dbo].[TB_Process] Set [proc_lelvel] = " + cbo_registerLevel.Text + ",[proc_name]='" + txt_register_Name.Text + "',[proc_type]='" + cbo_registerType.SelectedValue.ToString().Trim() + "' Where [proc_no] = " + dtg_registerProcess.Rows[e_RowIndex].Cells[0].Value.ToString().Trim() + "";

                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();

                Msg = "Update to Record in Flow Process!";
                Log_OldValue = "proc_name = " + txt_register_Name.Text.Trim() +
                        "," + "proc_lelvel = " + cbo_registerLevel.Text.Trim() +
                        "," + "proc_type = " + cbo_registerType.SelectedValue.ToString() +
                        "," + "Where proc_no = " + dtg_registerProcess.Rows[e_RowIndex].Cells[0].Value.ToString().Trim();
                Log_NewValue = "-";

                Load_DTGProcess();

                //}                
            }

            Class_Log CL = new Class_Log();
            CL.tbname = Msg;
            CL.oldvalue = Log_OldValue;
            CL.newvalue = Log_NewValue;
            CL.Save_log();

        }

        private void btn_vencusFind_Click(object sender, EventArgs e)
        {
            F_Search f_sarch = new F_Search();   //Search  Vendor in Navision   
            f_sarch.id_findType = 3;   //search type          
            f_sarch.ShowDialog();

            //return value          
            txt_vencusNo_OverStep.Text = f_sarch.id_value;
            txt_vencusName.Text = f_sarch.name_value;
            Load_OverStep();
        }

        private void btn_saveOverStep_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            int Sts_Active_OverStep = 0;
            if (chk_StsActiveOverStep.Checked == true)
            {
                Sts_Active_OverStep = 1;
            }

            string sql = "";

            if (chk_overStep.Checked == true)
            {

                sql = "INSERT INTO [dbo].[TB_OverProcess] ([proc_no],[venOrCus_No],[OverPro_Status]) VALUES(" + txt_OverStepID.Text.Trim() + ",'" + txt_vencusNo_OverStep.Text.Trim() + "'," + Sts_Active_OverStep + ")";

                Msg = "Insert New Record in Over Flow Process!";
                Log_NewValue = "proc_no = " + txt_OverStepID.Text.Trim() +
                       "," + "venOrCus_No = " + txt_vencusNo_OverStep.Text.Trim() +
                       "," + "OverPro_Status = " + Sts_Active_OverStep.ToString();
                Log_OldValue = "-";
            }

            else
            {
                sql = "Update [dbo].[TB_OverProcess] Set [OverPro_Status]=" + Sts_Active_OverStep + " Where [OverPro_no]=" + ID_OverStep + "";

                Msg = "Update to Record in Over Flow Process!";
                Log_OldValue = "OverPro_Status = " + Sts_Active_OverStep.ToString() +
                       "," + "Where OverPro_no = " + ID_OverStep.ToString();
                Log_NewValue = "-";
            }

            SqlCommand CM2 = new SqlCommand(sql, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();

            Class_Log CL = new Class_Log();
            CL.tbname = Msg;
            CL.oldvalue = Log_OldValue;
            CL.newvalue = Log_NewValue;
            CL.Save_log();

            MessageBox.Show("บันทึกสำเร็จ++", "บันทึกข้อมูล!!", MessageBoxButtons.OK, MessageBoxIcon.Information);


            Load_OverStep();
        }

        private void Load_OverStep()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                dtg_OverStep.DataSource = null;

                string sql = "SELECT [OverPro_no] AS 'ลำดับ',[proc_no] AS 'ลำดับที่ข้าม',[proc_name] AS 'ชื่อขั้นตอนที่ข้าม', [OverPro_Status] AS 'สถานะใช้งาน'  FROM [dbo].[V_OverStep] Where [venOrCus_No] = '" + txt_vencusNo_OverStep.Text.Trim() + "' AND [item_no] = '" + cbo_product_register.SelectedValue.ToString() + "'";

                SqlDataAdapter da1 = new SqlDataAdapter(sql, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_overstep");
                dtg_OverStep.DataSource = ds1.Tables["g_overstep"];
                con.Close();

                dtg_OverStep.Columns[0].Width = 80;
                dtg_OverStep.Columns[1].Width = 150;

                txt_OverStepID.Clear();
                txt_OverStepName.Clear();
                chk_StsActiveOverStep.Checked = false;
            }
            catch { }
        }

        private void dtg_registerProcess_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                rdo_registerEdit.Checked = true;
                e_RowIndex = e.RowIndex;
                cbo_registerLevel.Text = dtg_registerProcess.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                txt_register_Name.Text = dtg_registerProcess.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                cbo_registerType.Text = dtg_registerProcess.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();

                if (chk_overStep.Checked == true)
                {
                    txt_OverStepID.Text = dtg_registerProcess.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                    txt_OverStepName.Text = txt_register_Name.Text;
                }
            }
        }

        private void dtg_OverStep_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID_OverStep = Convert.ToInt16(dtg_OverStep.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
            txt_OverStepID.Text = dtg_OverStep.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            txt_OverStepName.Text = dtg_OverStep.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();


            if (dtg_OverStep.Rows[e.RowIndex].Cells[3].Value.ToString().Trim() == "True")
            {
                chk_StsActiveOverStep.Checked = true;
            }
            else { chk_StsActiveOverStep.Checked = false; }
        }

        private void Sub_Fregister_Load(object sender, EventArgs e)
        {
            gb_process.Dock = DockStyle.Fill;
            Load_LoadProduct();
            Load_Permission();

        }

        private void Load_LoadProduct()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {

                SqlCommand cmd = new SqlCommand("Select [ProductID],[ProductID] +':'+ [ProductName] AS 'ProductName' From  [dbo].[TB_Products]  Where [StatusActive] =1", con);

                DataSet ds6 = new DataSet();
                //ds.Clear();
                SqlDataAdapter da6 = new SqlDataAdapter();
                da6.SelectCommand = cmd;
                da6.Fill(ds6);
                cbo_product_register.DataSource = ds6.Tables[0];
                cbo_product_register.DisplayMember = "ProductName";
                cbo_product_register.ValueMember = "ProductID";
            }
            catch { }
        }

        private void Load_Permission()
        {
            foreach (TabPage tab in tab_menu.TabPages)
            {
                tab.Enabled = false;
            }        
            
            SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
            con1.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter1 = new SqlDataAdapter();
            con1.Open();

            string sql1 = "SELECT [ID_Menu],[Status_Active] FROM  [dbo].[V_Permission] WHERE User_AD ='" + Program.user_login + "' AND Status_Use =1 AND ID_Menutype = 6 ";
            SqlCommand CM1 = new SqlCommand(sql1, con1);
            SqlDataReader DR1 = CM1.ExecuteReader();

            while (DR1.Read())
            {
                if (DR1["ID_Menu"].ToString().Trim() == "71") //ความปลอดภัย   9
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True")
                    { /* add menu nornallyk */

                        (tab_menu.TabPages[0] as TabPage).Enabled = true;
                    }
                }

                if (DR1["ID_Menu"].ToString().Trim() == "72") //ความปลอดภัย   9
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True")
                    { /* add menu nornallyk */

                        (tab_menu.TabPages[1] as TabPage).Enabled = true;
                    }
                }
            }

            DR1.Close();
            con1.Close();
        }

        private void Load_Cler_QRCODE()
        {
            tg_registBackDate.Checked = false;
            tg_registSearchHistory.Checked = false;
            tg_regRmk1.Checked = false;
            tg_regRmk2.Checked = false;
            tg_regRmk3.Checked = false;
            tg_regRmk4.Checked = false;
            tg_regRmk5.Checked = false;

            txt_regRmk1.Clear();
            txt_regRmk2.Clear();
            txt_regRmk3.Clear();
            txt_regRmk4.Clear();
            txt_regRmk5.Clear();

            lbl_countRegrmk1.Text = "...";
            lbl_countRegrmk2.Text = "...";
            lbl_countRegrmk3.Text = "...";
            lbl_countRegrmk4.Text = "...";
            lbl_countRegrmk5.Text = "...";
        }

        private void chk_showOverprocess_CheckedChanged(object sender, EventArgs e)
        {
            Adjust_Dtg_NormalProcess();     
        }


        private void CLEAR_CHK()
        {
            chk_00.Checked = false;
            chk_01.Checked = false;
            chk_02.Checked = false;
            chk_03.Checked = false;
            chk_04.Checked = false;
            chk_05.Checked = false;
            chk_06.Checked = false;
            chk_07.Checked = false;
            chk_08.Checked = false;
            chk_09.Checked = false;
            chk_10.Checked = false;
            chk_11.Checked = false;
            chk_12.Checked = false;
            chk_13.Checked = false;
            chk_14.Checked = false;
            chk_15.Checked = false;
            chk_16.Checked = false;
            chk_17.Checked = false;
            chk_18.Checked = false;
            chk_19.Checked = false;
            chk_20.Checked = false;
            chk_21.Checked = false;
            chk_22.Checked = false;
            chk_23.Checked = false;
        }


        private void chk_8hour_CheckedChanged(object sender, EventArgs e)
        {
            CLEAR_CHK();

            if (chk_8hour.Checked == true)
            {
                chk_08.Checked = true;
                chk_09.Checked = true;
                chk_10.Checked = true;
                chk_11.Checked = true;
                chk_13.Checked = true;
                chk_14.Checked = true;
                chk_15.Checked = true;
                chk_16.Checked = true;
                chk_17.Checked = true;
            }

            else
            {
                chk_08.Checked = false;
                chk_09.Checked = false;
                chk_10.Checked = false;
                chk_11.Checked = false;
                chk_13.Checked = false;
                chk_14.Checked = false;
                chk_15.Checked = false;
                chk_16.Checked = false;
                chk_17.Checked = false;
            }


            Save_Overtime();


        }

        private void chk_12hour_CheckedChanged(object sender, EventArgs e)
        {
            CLEAR_CHK();

            if (chk_12hour.Checked == true)
            {
                chk_07.Checked = true;
                chk_08.Checked = true;
                chk_09.Checked = true;
                chk_10.Checked = true;
                chk_11.Checked = true;
                chk_12.Checked = true;
                chk_13.Checked = true;
                chk_14.Checked = true;
                chk_15.Checked = true;
                chk_16.Checked = true;
                chk_17.Checked = true;
                chk_18.Checked = true;
            }
            else
            {
                chk_07.Checked = false;
                chk_08.Checked = false;
                chk_09.Checked = false;
                chk_10.Checked = false;
                chk_11.Checked = false;
                chk_12.Checked = false;
                chk_13.Checked = false;
                chk_14.Checked = false;
                chk_15.Checked = false;
                chk_16.Checked = false;
                chk_17.Checked = false;
                chk_18.Checked = false;
            }

            Save_Overtime();
        }

        private void chk_16hour_CheckedChanged(object sender, EventArgs e)
        {
            CLEAR_CHK();

            if (chk_16hour.Checked == true)
            {
                chk_07.Checked = true;
                chk_08.Checked = true;
                chk_09.Checked = true;
                chk_10.Checked = true;
                chk_11.Checked = true;
                chk_12.Checked = true;
                chk_13.Checked = true;
                chk_14.Checked = true;
                chk_15.Checked = true;
                chk_16.Checked = true;
                chk_17.Checked = true;
                chk_18.Checked = true;
                chk_19.Checked = true;
                chk_20.Checked = true;
                chk_21.Checked = true;
                chk_22.Checked = true;
            }
            else
            {
                chk_07.Checked = false;
                chk_08.Checked = false;
                chk_09.Checked = false;
                chk_10.Checked = false;
                chk_11.Checked = false;
                chk_12.Checked = false;
                chk_13.Checked = false;
                chk_14.Checked = false;
                chk_15.Checked = false;
                chk_16.Checked = false;
                chk_17.Checked = false;
                chk_18.Checked = false;
                chk_19.Checked = false;
                chk_20.Checked = false;
                chk_21.Checked = false;
                chk_22.Checked = false;
            }

            Save_Overtime();
        }

        private void chk_24hour_CheckedChanged(object sender, EventArgs e)
        {
            CLEAR_CHK();

            if (chk_24hour.Checked == true)
            {
                chk_00.Checked = true;
                chk_01.Checked = true;
                chk_02.Checked = true;
                chk_03.Checked = true;
                chk_04.Checked = true;
                chk_05.Checked = true;
                chk_06.Checked = true;
                chk_07.Checked = true;
                chk_08.Checked = true;
                chk_09.Checked = true;
                chk_10.Checked = true;
                chk_11.Checked = true;
                chk_12.Checked = true;
                chk_13.Checked = true;
                chk_14.Checked = true;
                chk_15.Checked = true;
                chk_16.Checked = true;
                chk_17.Checked = true;
                chk_18.Checked = true;
                chk_19.Checked = true;
                chk_20.Checked = true;
                chk_21.Checked = true;
                chk_22.Checked = true;
                chk_23.Checked = true;
            }
            else
            {
                chk_00.Checked = false;
                chk_01.Checked = false;
                chk_02.Checked = false;
                chk_03.Checked = false;
                chk_04.Checked = false;
                chk_05.Checked = false;
                chk_06.Checked = false;
                chk_07.Checked = false;
                chk_08.Checked = false;
                chk_09.Checked = false;
                chk_10.Checked = false;
                chk_11.Checked = false;
                chk_12.Checked = false;
                chk_13.Checked = false;
                chk_14.Checked = false;
                chk_15.Checked = false;
                chk_16.Checked = false;
                chk_17.Checked = false;
                chk_18.Checked = false;
                chk_19.Checked = false;
                chk_20.Checked = false;
                chk_21.Checked = false;
                chk_22.Checked = false;
                chk_23.Checked = false;
            }

            Save_Overtime();
        }

        private void Save_Overtime()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            int STS_00 = 0;
            int STS_01 = 0;
            int STS_02 = 0;
            int STS_03 = 0;
            int STS_04 = 0;
            int STS_05 = 0;
            int STS_06 = 0;
            int STS_07 = 0;
            int STS_08 = 0;
            int STS_09 = 0;
            int STS_10 = 0;
            int STS_11 = 0;
            int STS_12 = 0;
            int STS_13 = 0;
            int STS_14 = 0;
            int STS_15 = 0;
            int STS_16 = 0;
            int STS_17 = 0;
            int STS_18 = 0;
            int STS_19 = 0;
            int STS_20 = 0;
            int STS_21 = 0;
            int STS_22 = 0;
            int STS_23 = 0;
            
           
            if (chk_00.Checked == true)
            {
                STS_00 = 1;
            }

            if (chk_01.Checked == true)
            {
                STS_01 = 1;
            }
            if (chk_02.Checked == true)
            {
                STS_02 = 1;
            }

            if (chk_03.Checked == true)
            {
                STS_03 = 1;
            }

            if (chk_04.Checked == true)
            {
                STS_04 = 1;
            }

            if (chk_05.Checked == true)
            {
                STS_05 = 1;
            }

            if (chk_06.Checked == true)
            {
                STS_06 = 1;
            }

            if (chk_07.Checked == true)
            {
                STS_07 = 1;
            }


            if (chk_08.Checked == true)
            {
                STS_08 = 1;
            }

            if (chk_09.Checked == true)
            {
                STS_09 = 1;
            }

            if (chk_10.Checked == true)
            {
                STS_10 = 1;
            }

            if (chk_11.Checked == true)
            {
                STS_11 = 1;
            }

            if (chk_12.Checked == true)
            {
                STS_12 = 1;
            }

            if (chk_13.Checked == true)
            {
                STS_13 = 1;
            }

            if (chk_14.Checked == true)
            {
                STS_14 = 1;
            }

            if (chk_15.Checked == true)
            {
                STS_15 = 1;
            }

            if (chk_16.Checked == true)
            {
                STS_16 = 1;
            }

            if (chk_17.Checked == true)
            {
                STS_17 = 1;
            }

            if (chk_18.Checked == true)
            {
                STS_18 = 1;
            }

            if (chk_19.Checked == true)
            {
                STS_19 = 1;
            }

            if (chk_20.Checked == true)
            {
                STS_20 = 1;
            }

            if (chk_21.Checked == true)
            {
                STS_21 = 1;
            }

            if (chk_22.Checked == true)
            {
                STS_22 = 1;
            }

            if (chk_23.Checked == true)
            {
                STS_23 = 1;
            }

           
                string sql = "Update [dbo].[TB_AutoTime] Set A_00=" + STS_00 + ",A_01=" + STS_01 + ",A_02=" + STS_02 + ",A_03=" + STS_03 + ",A_04=" + STS_04 + ",A_05=" + STS_05+ ",A_06=" + STS_06 + ",A_07=" + STS_07 + ",A_08=" + STS_08 + ",A_09=" + STS_09 + ",A_10=" + STS_10 + ",A_11=" + STS_11 + ",A_12=" + STS_12 + ",A_13=" + STS_13 + ",A_14=" + STS_14 + ",A_15=" + STS_15 + ",A_16=" + STS_16 + ",A_17=" + STS_17 + ",A_18=" + STS_18 + ",A_19=" + STS_19 + ",A_20=" + STS_20 + ",A_21=" + STS_21 + ",A_22=" + STS_22 + ",A_23=" + STS_23 + " Where [atMode_id]= 1";

                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();   
          
            con.Close();
        }


        int STS_T = 0;
        string Name_tiem = "";

        private void CHK_UpdateTime()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql = "Update [dbo].[TB_AutoTime] Set " + Name_tiem + "=" + STS_T + " Where [atMode_id]= 1";

            SqlCommand CM2 = new SqlCommand(sql, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();
        }

        private void chk_00_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_00";

            if (chk_00.Checked == true)
            {
                STS_T = 1;
                chk_00.ForeColor = Color.Red;              
            }
            else { STS_T = 0; chk_00.ForeColor = Color.Black; }


            CHK_UpdateTime();
        }

        private void chk_01_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_01";

            if (chk_01.Checked == true)
            {
                STS_T = 1;
                chk_01.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_01.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_02_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_02";

            if (chk_02.Checked == true)
            {
                STS_T = 1;
                chk_02.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_02.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_03_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_03";

            if (chk_03.Checked == true)
            {
                STS_T = 1;
                chk_03.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_03.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_04_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_04";

            if (chk_04.Checked == true)
            {
                STS_T = 1;
                chk_04.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_04.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_05_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_05";

            if (chk_05.Checked == true)
            {
                STS_T = 1;
                chk_05.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_05.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_06_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_06";

            if (chk_06.Checked == true)
            {
                STS_T = 1;
                chk_06.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_06.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_07_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_07";

            if (chk_07.Checked == true)
            {
                STS_T = 1;
                chk_07.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_07.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_08_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_08";

            if (chk_08.Checked == true)
            {
                STS_T = 1;
                chk_08.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_08.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_09_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_09";

            if (chk_09.Checked == true)
            {
                STS_T = 1;
                chk_09.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_09.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_10_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_10";

            if (chk_10.Checked == true)
            {
                STS_T = 1;
                chk_10.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_10.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_11_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_11";

            if (chk_11.Checked == true)
            {
                STS_T = 1;
                chk_11.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_11.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_12_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_12";

            if (chk_12.Checked == true)
            {
                STS_T = 1;
                chk_12.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_12.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_13_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_13";

            if (chk_13.Checked == true)
            {
                STS_T = 1;
                chk_13.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_13.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_14_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_14";

            if (chk_14.Checked == true)
            {
                STS_T = 1;
                chk_14.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_14.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_15_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_15";

            if (chk_15.Checked == true)
            {
                STS_T = 1;
                chk_15.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_15.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_16_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_16";

            if (chk_16.Checked == true)
            {
                STS_T = 1;
                chk_16.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_16.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_17_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_17";

            if (chk_17.Checked == true)
            {
                STS_T = 1;
                chk_17.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_17.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_18_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_18";

            if (chk_18.Checked == true)
            {
                STS_T = 1;
                chk_18.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_18.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_19_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_19";

            if (chk_19.Checked == true)
            {
                STS_T = 1;
                chk_19.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_19.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_20_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_20";

            if (chk_20.Checked == true)
            {
                STS_T = 1;
                chk_20.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_20.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_21_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_21";

            if (chk_21.Checked == true)
            {
                STS_T = 1;
                chk_21.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_21.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_22_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_22";

            if (chk_22.Checked == true)
            {
                STS_T = 1;
                chk_22.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_22.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void chk_23_CheckedChanged(object sender, EventArgs e)
        {
            Name_tiem = "A_23";

            if (chk_23.Checked == true)
            {
                STS_T = 1;
                chk_23.ForeColor = Color.Red;
            }
            else { STS_T = 0; chk_23.ForeColor = Color.Black; }

            CHK_UpdateTime();
        }

        private void dtg_registerProcess_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int STS = 0;

            if (dtg_registerProcess.Rows[e.RowIndex].Cells[5].Value.ToString() == "True")
            {
                STS = 1;
            }

            if (e.RowIndex > -1)
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql = "Update [dbo].[TB_Process] Set [proc_atMode]=" + STS + " Where [proc_no]="+dtg_registerProcess.Rows[e.RowIndex].Cells[0].Value.ToString()+"";

                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();
            }
        }

        private void Load_TimeAutoSetup()
        {           
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();     

                string sql6 = "SELECT * FROM [dbo].[TB_AutoTime]";
                SqlCommand CM6 = new SqlCommand(sql6, con);
                SqlDataReader DR6 = CM6.ExecuteReader();

                DR6.Read();
            {
                if (DR6["A_00"].ToString().Trim() == "True")
                {
                    chk_00.Checked = true;
                }
                else { chk_00.Checked = false; }


                if (DR6["A_01"].ToString().Trim() == "True")
                {
                    chk_01.Checked = true;
                }
                else { chk_01.Checked = false; }


                if (DR6["A_02"].ToString().Trim() == "True")
                {
                    chk_02.Checked = true;

                }
                else { chk_02.Checked = false; }


                if (DR6["A_03"].ToString().Trim() == "True")
                {
                    chk_03.Checked = true;

                }
                else { chk_03.Checked = false; }


                if (DR6["A_04"].ToString().Trim() == "True")
                {
                    chk_04.Checked = true;
                }
                else { chk_04.Checked = false; }


                if (DR6["A_05"].ToString().Trim() == "True")
                {
                    chk_05.Checked = true;

                }
                else { chk_05.Checked = false; }


                if (DR6["A_06"].ToString().Trim() == "True")
                {
                    chk_06.Checked = true;
                }
                else { chk_06.Checked = false; }

                if (DR6["A_07"].ToString().Trim() == "True")
                {
                    chk_07.Checked = true;
                }
                else { chk_07.Checked = false; }

                if (DR6["A_08"].ToString().Trim() == "True")
                {
                    chk_08.Checked = true;
                }
                else { chk_08.Checked = false; }

                if (DR6["A_09"].ToString().Trim() == "True")
                {
                    chk_09.Checked = true;
                }
                else { chk_09.Checked = false; }

                if (DR6["A_10"].ToString().Trim() == "True")
                {
                    chk_10.Checked = true;
                }
                else { chk_10.Checked = false; }

                if (DR6["A_11"].ToString().Trim() == "True")
                {
                    chk_11.Checked = true;
                }
                else { chk_11.Checked = false; }

                if (DR6["A_12"].ToString().Trim() == "True")
                {
                    chk_12.Checked = true;
                }
                else { chk_12.Checked = false; }

                if (DR6["A_13"].ToString().Trim() == "True")
                {
                    chk_13.Checked = true;
                }
                else { chk_13.Checked = false; }

                if (DR6["A_14"].ToString().Trim() == "True")
                {
                    chk_14.Checked = true;
                }
                else { chk_14.Checked = false; }

                if (DR6["A_15"].ToString().Trim() == "True")
                {
                    chk_15.Checked = true;
                }
                else { chk_15.Checked = false; }

                if (DR6["A_16"].ToString().Trim() == "True")
                {
                    chk_16.Checked = true;
                }
                else { chk_16.Checked = false; }

                if (DR6["A_17"].ToString().Trim() == "True")
                {
                    chk_17.Checked = true;
                }
                else { chk_17.Checked = false; }

                if (DR6["A_18"].ToString().Trim() == "True")
                {
                    chk_18.Checked = true;
                }
                else { chk_18.Checked = false; }


                if (DR6["A_19"].ToString().Trim() == "True")
                {
                    chk_19.Checked = true;
                }
                else { chk_19.Checked = false; }

                if (DR6["A_20"].ToString().Trim() == "True")
                {
                    chk_20.Checked = true;
                }
                else { chk_20.Checked = false; }


                if (DR6["A_21"].ToString().Trim() == "True")
                {
                    chk_21.Checked = true;
                }
                else { chk_21.Checked = false; }

                if (DR6["A_22"].ToString().Trim() == "True")
                {
                    chk_22.Checked = true;
                }
                else { chk_22.Checked = false; }


                if (DR6["A_23"].ToString().Trim() == "True")
                {
                    chk_23.Checked = true;
                }
                else { chk_23.Checked = false; }

            }
                DR6.Close();
                con.Close();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                Load_TimeAutoSetup();
            }
        }

        private void cbo_typeTicket_register_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tg_registBackDate_CheckedChanged(object sender, EventArgs e)
        {
            if (tg_registBackDate.Checked == true)
            {
                label7.ForeColor = Color.DarkBlue;
            }
            else { label7.ForeColor = Color.DimGray; }
        }

        private void tg_registSearchHistory_CheckedChanged(object sender, EventArgs e)
        {
            if (tg_registSearchHistory.Checked == true)
            {
                label8.ForeColor = Color.IndianRed;
            }
            else { label8.ForeColor = Color.DimGray; }
        }

        private void tg_regRmk1_CheckedChanged(object sender, EventArgs e)
        {
            if (tg_regRmk1.Checked == true)
            {
                txt_regRmk1.Enabled = true; label2.ForeColor = Color.Black;
            }
            else { txt_regRmk1.Enabled = false; label2.ForeColor = Color.DimGray; }
        }

        private void tg_regRmk2_CheckedChanged(object sender, EventArgs e)
        {
            if (tg_regRmk2.Checked == true)
            {
                txt_regRmk2.Enabled = true; label3.ForeColor = Color.Black;
            }
            else { txt_regRmk2.Enabled = false; label3.ForeColor = Color.DimGray; }
        }

        private void tg_regRmk3_CheckedChanged(object sender, EventArgs e)
        {
            if (tg_regRmk3.Checked == true)
            {
                txt_regRmk3.Enabled = true; label4.ForeColor = Color.Black;
            }
            else { txt_regRmk3.Enabled = false; label4.ForeColor = Color.DimGray; }
        }

        private void tg_regRmk4_CheckedChanged(object sender, EventArgs e)
        {
            if (tg_regRmk4.Checked == true)
            {
                txt_regRmk4.Enabled = true; label5.ForeColor = Color.Black;
            }
            else { txt_regRmk4.Enabled = false; label5.ForeColor = Color.DimGray; }
        }

        private void tg_regRmk5_CheckedChanged(object sender, EventArgs e)
        {
            if (tg_regRmk5.Checked == true)
            {
                txt_regRmk5.Enabled = true; label6.ForeColor = Color.Black;
            }
            else { txt_regRmk5.Enabled = false; label6.ForeColor = Color.DimGray; }
        }
    }


}
