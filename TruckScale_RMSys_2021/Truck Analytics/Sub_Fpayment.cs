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
    public partial class Sub_Fpayment : Form
    {
        public Sub_Fpayment()
        {
            InitializeComponent();
        }

        // Log
        string Msg = "";
        string Log_OldValue = "-";
        string Log_NewValue = "-";

        int PaySeting_ID = 0;
        int TombonId = 0;
        int id_countCheck = 0;
        int C_count = 0;

        private void chk_PaynewSet_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_PaynewSet.Checked == true)
            {
                txt_PaydocRef.Clear(); txt_PaydocRef.BackColor = Color.Tomato;
                txt_PaypriceFac.Clear(); txt_PaypriceFac.BackColor = Color.Tomato;
                chk_PayacctiveDate.Checked = false;
                tb_analyze.Enabled = false;
                Load_PriceSTD_Product();
            }

            else
            {
                txt_PaydocRef.BackColor = Color.White;
                txt_PaypriceFac.BackColor = Color.White;
                chk_newVisual.Checked = false;
                tb_analyze.Enabled = true;
            }
        }

        private void cb_Payproduct_True_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear_Data();

            cb_PayvendorGroup.Text = "-- เลือกกลุ่ม --";
            cb_visualPay.Text = "-- เลือกประเภท --";
            cb_labPay.Text = "-- เลือกประเภท --";
            //Load_VendorSettingGroup();
            // Load_Price_Starch();

            //Load_Lab_Starch();
            //Load_LabGroup();

            ////UpdateLabSP();

            //Load_Visual();
            //Load_VisualGroup();

            ////UpdateVisualSP();  
            ///
            try
            {
                if (cb_Payproduct_True.SelectedValue.ToString() == "RM-004")
                {
                    chk_excludeMoist.Enabled = true;
                }
                else { chk_excludeMoist.Enabled = false; }


                Load_VendorGroup();
            }
            catch { }
        }

        private void cb_PayvendorGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear_Data();
            Load_VendorSettingGroup();
            // Load_Price_Starch();

            //MessageBox.Show(PaySeting_ID.ToString());

            Load_LabGroup();
            Load_VisualGroup();
        }

        private void Load_VendorGroup()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();
                SqlCommand cmd = new SqlCommand(" Select [VendorGroupID], ([VendorGroupID]+':'+ [VendorGroupName]) AS 'VendorGroupName' From  [dbo].[V_VendorGroup2] WHERE [ProductID]='" + cb_Payproduct_True.SelectedValue.ToString().Trim() + "' AND [VendorGroup_Status] =1 ", con);
                DataSet ds = new DataSet();
                //ds.Clear();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                //Load product tab weight scale Setup
                cb_PayvendorGroup.DataSource = ds.Tables[0];
                cb_PayvendorGroup.DisplayMember = "VendorGroupName";
                cb_PayvendorGroup.ValueMember = "VendorGroupID";
                con.Close();
            }
            catch { }
        }

        private void Clear_Data()
        {
            txt_PaydocRef.Clear();
            chk_PayacctiveDate.Checked = false;
            txt_PaypriceFac.Clear();
            dtg_visualStarch.DataSource = null;
            dtg_labStarch.DataSource = null;
            txt_optionalVisual.Clear();
        }

        private void Load_VendorSettingGroup()
        {
            try
            {

                //MessageBox.Show(cb_PayvendorGroup.SelectedValue.ToString());

                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                //dtg_vendorStarch.DataSource = null;
                con.Open();
                string sql1 = "SELECT [PaysetID],[VendorGroupName],[ProductID],[UnitName] ,[PriceFac] ,[DateActive],[StDate],[EdDate],[DocAppNo],[PriceFac],[OptionalVisual],[OptionalVisualStatus],[ExcludeMoistStatus] FROM  [dbo].[V_PaymentSettingGroup] WHERE [ProductID] = '" + cb_Payproduct_True.SelectedValue.ToString() + "' AND [VendorGroupID]='" + cb_PayvendorGroup.SelectedValue.ToString() + "'  ";

                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {

                    PaySeting_ID = Convert.ToInt16(DR1["PaysetID"].ToString());
                    cb_PayvendorGroup.Text = DR1["VendorGroupName"].ToString();
                    cb_Payproduct_True.SelectedValue = DR1["ProductID"].ToString();
                    cb_PayunitPrice.Text = DR1["UnitName"].ToString();
                    txt_PaypriceFac.Text = DR1["PriceFac"].ToString();
                    txt_optionalVisual.Text = DR1["OptionalVisual"].ToString();

                    if (DR1["DateActive"].ToString() == "True")
                    {
                        chk_PayacctiveDate.Checked = true;
                    }
                    else { chk_PayacctiveDate.Checked = false; }


                    if (DR1["OptionalVisualStatus"].ToString() == "True")
                    {
                        chk_optionalVisual.Checked = true;
                    }
                    else { chk_optionalVisual.Checked = false; }

                    if (DR1["ExcludeMoistStatus"].ToString() == "True")
                    {
                        chk_excludeMoist.Checked = true;
                    }
                    else { chk_excludeMoist.Checked = false; }

                    txt_PaydocRef.Text = DR1["DocAppNo"].ToString();

                    chk_newVisual.Enabled = true;

                    txt_PaydocRef.BackColor = Color.Snow;
                    //chk_PaynewSet.Enabled = false;
                }
                DR1.Close();
                con.Close();
            }
            catch
            {
                PaySeting_ID = 0;
                txt_PaypriceFac.Clear();
                txt_PaydocRef.Clear();

                chk_PaynewSet.Enabled = true;
                chk_newVisual.Enabled = false;
                //PaySeting_ID = 0;
                txt_PaydocRef.Text = "ยังไม่ได้สร้างกลุ่มซื้อ";
                txt_PaydocRef.BackColor = Color.Khaki;
            }

        }

        private void Load_LabGroup()
        {

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("SELECT [LabID],(Trim(CONVERT(char,[LabID]))+':'+[LabName]) AS 'LabName'   FROM  [dbo].[TB_LabName]  WHERE  [ProductID] = '" + cb_Payproduct_True.SelectedValue.ToString() + "'  AND [LabActive]=1  AND  [LabtypeID]=1 ", con);

            //SELECT  [VisualType] ,[VisualName]  FROM  [dbo].[TB_VISUALTYPE] WHERE [VisualProductID]='RM-004' AND [VisualopServ]=0 AND [VisualTypeActive]=1
            DataSet ds = new DataSet();
            //ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            //Load product tab weight scale Setup
            cb_labPay.DataSource = ds.Tables[0];
            cb_labPay.DisplayMember = "LabName";
            cb_labPay.ValueMember = "LabID";



            //chk_newvisual.Checked = false;
        }

        private void Load_VisualGroup()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

                SqlCommand cmd = new SqlCommand("SELECT [LabID],(Trim(CONVERT(char,[LabID]))+':'+[LabName]) AS 'LabName' FROM  [dbo].[TB_LabName]  WHERE [ProductID] = '" + cb_Payproduct_True.SelectedValue.ToString() + "' AND [LabActive]=1  AND  [LabtypeID]=2 ", con);

                //SELECT  [VisualType] ,[VisualName]  FROM  [dbo].[TB_VISUALTYPE] WHERE [VisualProductID]='RM-004' AND [VisualopServ]=0 AND [VisualTypeActive]=1
                DataSet ds = new DataSet();
                //ds.Clear();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                //Load product tab weight scale Setup
                cb_visualPay.DataSource = ds.Tables[0];
                cb_visualPay.DisplayMember = "LabName";
                cb_visualPay.ValueMember = "LabID";

            }
            catch { }
        }

        private void chk_PayacctiveDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_PayacctiveDate.Checked == true)
            {
                dtp_stDate.Enabled = true; dtp_edDate.Enabled = true;
            }
            else
            {
                dtp_stDate.Enabled = false; dtp_edDate.Enabled = false;
            }
        }

        private void btn_setVendor_Click(object sender, EventArgs e)
        {
            F_VendorGrup Fdg = new F_VendorGrup();
            Fdg.ShowDialog();
            Load_VendorGroup();
        }

        private void btn_save_paySetting_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            int Active_date = 0;
            int OptionalVisual = 0;
            int OptionalVisualStatus = 0;
            int ExcludeMoistStatus = 0;

            string stDate = dtp_stDate.Value.Month.ToString() + "-" + dtp_stDate.Value.Day.ToString() + "-" + dtp_stDate.Value.Year.ToString();
            string edDate = dtp_edDate.Value.Month.ToString() + "-" + dtp_edDate.Value.Day.ToString() + "-" + dtp_edDate.Value.Year.ToString();

            if (chk_optionalVisual.Checked == true) { OptionalVisualStatus = 1; }
            if (chk_excludeMoist.Checked == true) { ExcludeMoistStatus = 1; }
            if (chk_PayacctiveDate.Checked == true) { Active_date = 1; }


            if (chk_PaynewSet.Checked == true && cb_PayvendorGroup.SelectedValue.ToString() != "")
            {
                Load_CountSaveCheck();


                con.Open();

                string sql = "Insert Into  [dbo].[TB_PaymentSetting] ([ProductID],[DocAppNo],[DateActive],[StDate],[EdDate],[UnitID],[VendorGroupID],[PriceFac],[OptionalVisual],[OptionalVisualStatus],[ExcludeMoistStatus]) Values('" + cb_Payproduct_True.SelectedValue.ToString() + "', '" + txt_PaydocRef.Text.Trim() + "', " + Active_date + ",'" + stDate + "','" + edDate + "'," + cb_PayunitPrice.SelectedValue.ToString() + ",'" + cb_PayvendorGroup.SelectedValue.ToString() + "','" + txt_PaypriceFac.Text.Trim() + "'," + txt_optionalVisual.Text.Trim() + "," + OptionalVisualStatus + "," + ExcludeMoistStatus + " )";

                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();

                con.Open();
                string sql5 = "SELECT MaX([PaysetID]) AS NewID FROM  [dbo].[TB_PaymentSetting] ";
                SqlCommand CM5 = new SqlCommand(sql5, con);
                SqlDataReader DR5 = CM5.ExecuteReader();
                DR5.Read();
                {
                    PaySeting_ID = Convert.ToInt16(DR5["NewID"].ToString());
                }
                DR5.Close();
                con.Close();

                MessageBox.Show("บันทึกสำเร็จ", "รายงานการบันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //else { MessageBox.Show("ไม่สามารถบันทึกรายการนี้ได้เนื่องจากมีรายการแบบนี้ได้บันทึกไปแล้ว", "บันทึกผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                Msg = "Insert New Record in TB_PaymentSetting!";
                Log_NewValue = "ProductID = " + cb_Payproduct_True.SelectedValue.ToString() +
                    "," + "DocAppNo = " + txt_PaydocRef.Text.Trim() +
                    "," + "DateActive = " + Active_date.ToString() +
                    "," + "StDate = " + stDate.ToString() +
                    "," + "EdDate = " + edDate.ToString() +
                    "," + "UnitID = " + cb_PayunitPrice.SelectedValue.ToString() +
                    "," + "VendorGroupID = " + cb_PayvendorGroup.SelectedValue.ToString() +
                    "," + "PriceFac = " + txt_PaypriceFac.Text.Trim() +
                    "," + "OptionalVisual = " + txt_optionalVisual.Text.Trim() +
                    "," + "OptionalVisualStatus = " + OptionalVisualStatus.ToString() +
                    "," + "ExcludeMoistStatus = " + ExcludeMoistStatus.ToString();
                Log_OldValue = "=";

                chk_PaynewSet.Checked = false;
                txt_PaydocRef.BackColor = Color.Snow;
                txt_PaypriceFac.BackColor = Color.Snow;

            }

            else
            {
                if (cb_PayvendorGroup.SelectedValue.ToString() != "")
                {
                    con.Open();

                    string sql = "Update  [dbo].[TB_PaymentSetting]  Set [DocAppNo]='" + txt_PaydocRef.Text.Trim() + "',[DateActive]= " + Active_date + ",[StDate]= '" + stDate + "',[EdDate] = '" + edDate + "',[UnitID]=" + cb_PayunitPrice.SelectedValue.ToString() + ",[VendorGroupID] = '" + cb_PayvendorGroup.SelectedValue.ToString() + "',[PriceFac]=" + txt_PaypriceFac.Text.Trim() + ",[OptionalVisual] =" + OptionalVisual + ",[OptionalVisualStatus]=" + OptionalVisualStatus + ",[ExcludeMoistStatus]=" + ExcludeMoistStatus + " WHERE [VendorGroupID]= '" + cb_PayvendorGroup.SelectedValue.ToString() + "' AND [ProductID] ='" + cb_Payproduct_True.SelectedValue.ToString() + "' ";
                    SqlCommand CM2 = new SqlCommand(sql, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    con.Close();

                    Msg = "Update to Record in TB_PaymentSetting!";
                    Log_OldValue = "," + "DocAppNo = " + txt_PaydocRef.Text.Trim() +
                        "," + "DateActive = " + Active_date.ToString() +
                        "," + "StDate = " + stDate.ToString() +
                        "," + "EdDate = " + edDate.ToString() +
                        "," + "UnitID = " + cb_PayunitPrice.SelectedValue.ToString() +
                        "," + "PriceFac = " + txt_PaypriceFac.Text.Trim() +
                        "," + "OptionalVisual = " + txt_optionalVisual.Text.Trim() +
                        "," + "OptionalVisualStatus = " + OptionalVisualStatus.ToString() +
                        "," + "ExcludeMoistStatus = " + ExcludeMoistStatus.ToString() +
                        "," + "WHERE  ProductID = " + cb_Payproduct_True.SelectedValue.ToString() + "and VendorGroupID =" + cb_PayvendorGroup.SelectedValue.ToString();

                    Log_NewValue = "-";
                }
            }


            Class_Log CL = new Class_Log();
            CL.tbname = Msg;
            CL.oldvalue = Log_OldValue;
            CL.newvalue = Log_NewValue;
            CL.Save_log();

            Clear_Data();
            Load_VendorSettingGroup();
        }

        private void Load_CountSaveCheck()
        {
            try
            {

                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                //dtg_vendorStarch.DataSource = null;
                con.Open();
                string sql1 = "SELECT Count(PaysetID)AS CountCheck FROM [dbo].[PaymentSetting] WHERE [ProductID] = '" + cb_Payproduct_True.SelectedValue.ToString() + "' AND [VendorGroupID]='" + cb_PayvendorGroup.SelectedValue.ToString() + "'  ";

                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    id_countCheck = Convert.ToInt16(DR1["CountCheck"].ToString());
                }
                DR1.Close();
                con.Close();
            }
            catch { }

        }

        private void Load_PriceSTD_Product()
        {
            try
            {

                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                //dtg_vendorStarch.DataSource = null;
                con.Open();
                string sql1 = "Select  [Price] From  [dbo].[TB_Products]  WHERE [ProductID]='" + cb_Payproduct_True.SelectedValue.ToString() + "'";

                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    txt_PaypriceFac.Text = DR1["Price"].ToString().Trim();
                }
                DR1.Close();
                con.Close();




            }
            catch { txt_PaypriceFac.BackColor = Color.Red; }

        }

        private void chk_optionalVisual_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_optionalVisual.Checked == true)
            {
                txt_optionalVisual.Enabled = true;
            }
            else { txt_optionalVisual.Enabled = false; }
        }
        private void Check_Dill_Data()
        {

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql4 = "Select Count([LabID]) AS 'C_count' FROM  [dbo].[TB_LabName]  WHERE [ProductID] = '" + cb_Payproduct_True.SelectedValue.ToString().Trim() + "' AND [LabActive]=1 AND  [LabtypeID]=2 AND [Dilldata] =1 AND [LabPayment]=1 AND [LabID]=" + cb_visualPay.SelectedValue.ToString() + "";
            SqlCommand CM = new SqlCommand(sql4, con);
            SqlDataReader DR = CM.ExecuteReader();
            DR.Read();
            {
                C_count = Convert.ToUInt16(DR["C_count"].ToString());
            }
            DR.Close();
            con.Close();

        }

        private void chk_newVisual_CheckedChanged(object sender, EventArgs e)
        {

            if (chk_newVisual.Checked == true)
            {
                SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
                con1.ConnectionString = Program.pathdb_Weight;
                //dtg_vendorStarch.DataSource = null;

                SqlConnection con2 = new SqlConnection(Program.pathdb_Weight);
                con2.ConnectionString = Program.pathdb_Weight;
                //dtg_vendorStarch.DataSource = null;                                       

                string sql1 = "";

                Check_Dill_Data();


                if (C_count == 0)
                {
                    sql1 = "SELECT [ValueVisualNo]  FROM  [dbo].[TB_Valuevisual]  Where [LabID]= " + cb_visualPay.SelectedValue.ToString().Trim() + "";
                    con1.Open();
                    con2.Open();
                    SqlCommand CM1 = new SqlCommand(sql1, con1);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    while (DR1.Read())
                    {

                        String VSValueID = DR1["ValueVisualNo"].ToString();
                        if (con2.State == ConnectionState.Open)
                        {
                            con2.Close();
                        }

                        con2.Open();
                        string sql = "Insert Into  [dbo].[TB_VisualRange] ([ValueVisualNo],[Value],[ValueActive],[PaysetID],[LabID]) Values(" + VSValueID + ",0,0, " + PaySeting_ID + "," + cb_visualPay.SelectedValue.ToString() + ")";
                        SqlCommand CM2 = new SqlCommand(sql, con2);
                        SqlDataReader DR2 = CM2.ExecuteReader();
                        con2.Close();
                    }
                    DR1.Close();


                    dtg_visualStarch.DataSource = null;

                    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                    con.ConnectionString = Program.pathdb_Weight;
                    SqlDataAdapter dtAdapter = new SqlDataAdapter();
                    con.Open();

                    string sql3 = "SELECT [idVSRNo] AS 'รหัส',[ValueName]  AS 'ชื่อวิเคราะห์',[ValueLab]  AS 'ค่าที่ได้ WH',[StatusLab]  AS 'สถานะ-WH',[ValueSP]  AS 'ค่าที่ได้ SP',[StatusSP] AS 'สถานะ-SP' FROM  [dbo].[V_VisualSP] Where [LabID]=" + cb_visualPay.SelectedValue.ToString() + "  AND [PaysetID]=" + PaySeting_ID + " ";
                    SqlDataAdapter da = new SqlDataAdapter(sql3, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "g_vt");
                    dtg_visualStarch.DataSource = ds.Tables["g_vt"];
                    con.Close();

                }

                else
                {
                    //SELECT [VVDeNo] AS 'รหัสค่า',[Vmin]  AS 'ค่าเริ่มต้น',[Vmax]  AS 'ค่าสิ้นสุด',[VSelect]  AS 'ค่าที่นำไปยืนยัน' FROM  [dbo].[TB_ValueVisualDetail] Where [LabID]=36
                    sql1 = "SELECT [VVDeNo]  FROM  [dbo].[TB_ValueVisualDetail]  Where [LabID]= " + cb_visualPay.SelectedValue.ToString().Trim() + "";
                    con1.Open();

                    con2.Open();
                    SqlCommand CM1 = new SqlCommand(sql1, con1);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    while (DR1.Read())
                    {

                        String VSValueID = DR1["VVDeNo"].ToString();
                        if (con2.State == ConnectionState.Open)
                        {
                            con2.Close();
                        }

                        con2.Open();
                        string sql = "Insert Into  [dbo].[TB_VisualRange] ([ValueVisualNo],[Value],[ValueActive],[PaysetID],[LabID]) Values(" + VSValueID + ",0,0, " + PaySeting_ID + "," + cb_visualPay.SelectedValue.ToString() + ")";
                        SqlCommand CM2 = new SqlCommand(sql, con2);
                        SqlDataReader DR2 = CM2.ExecuteReader();
                        con2.Close();
                    }
                    DR1.Close();


                    dtg_visualStarch.DataSource = null;

                    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                    con.ConnectionString = Program.pathdb_Weight;
                    SqlDataAdapter dtAdapter = new SqlDataAdapter();
                    con.Open();

                    string sql3 = "SELECT [idVSRNo] AS 'รหัส',[ValueName]  AS 'ชื่อวิเคราะห์',[ValueLab]  AS 'ค่าที่ได้ WH',[StatusLab]  AS 'สถานะ-WH',[ValueSP]  AS 'ค่าที่ได้ SP',[StatusSP] AS 'สถานะ-SP' FROM  [dbo].[V_VisualSP] Where [LabID]=" + cb_visualPay.SelectedValue.ToString() + "  AND [PaysetID]=" + PaySeting_ID + " ";
                    SqlDataAdapter da = new SqlDataAdapter(sql3, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "g_vt");
                    dtg_visualStarch.DataSource = ds.Tables["g_vt"];
                    con.Close();
                }


                //con.Close();             


                if (dtg_visualStarch.RowCount > 0)
                {
                    chk_newVisual.Enabled = false;
                }
                else
                {

                    chk_newVisual.Checked = false;
                    Load_VSC();
                }

                dtg_visualStarch.Columns[4].DefaultCellStyle.BackColor = Color.LightGreen;
                dtg_visualStarch.Columns[5].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void Load_VSC()
        {
            C_count = 0;
            Check_Dill_Data();

            dtg_visualStarch.DataSource = null;

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql = "";


            if (C_count == 0)
            {
                sql = "SELECT [idVSRNo] AS 'รหัส',[ValueName]  AS 'ชื่อวิเคราะห์',[ValueLab]  AS 'ค่าที่ได้ WH',[StatusLab]  AS 'สถานะ-WH',[ValueSP]  AS 'ค่าที่ได้ SP',[StatusSP] AS 'สถานะ-SP' FROM  [dbo].[V_VisualSP] Where [LabID]=" + cb_visualPay.SelectedValue.ToString() + "  AND [PaysetID]=" + PaySeting_ID + " ";
            }
            else
            {
                sql = "SELECT [idVSRNo] AS 'รหัส',[Vmin]  AS 'ค่าต่ำ-WH',[Vmax]  AS 'ค่าสูง-WH',[VSelect]  AS 'ค่าที่ได้',[ValueSP]  AS 'ค่าที่ได้ SP',[StatusSP] AS 'สถานะ-SP' FROM  [dbo].[V_VisualSP_DillData] Where [LabID]=" + cb_visualPay.SelectedValue.ToString() + "  AND [PaysetID]=" + PaySeting_ID + " ";
            }


            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "g_vt");
            dtg_visualStarch.DataSource = ds.Tables["g_vt"];
            con.Close();


            if (dtg_visualStarch.RowCount > 0)
            { chk_newVisual.Enabled = false; dtg_visualStarch.Columns[0].Width = 0; }

            else if (PaySeting_ID != 0)
            { chk_newVisual.Enabled = true; chk_newVisual.Checked = false; }

            chk_allvisualQA.Checked = false;

            if (C_count == 0)
            {
                dtg_visualStarch.Columns[1].DefaultCellStyle.BackColor = Color.Turquoise;
                dtg_visualStarch.Columns[2].DefaultCellStyle.BackColor = Color.Violet;
                dtg_visualStarch.Columns[3].DefaultCellStyle.BackColor = Color.Violet;
                dtg_visualStarch.Columns[4].DefaultCellStyle.BackColor = Color.LightGreen;
                dtg_visualStarch.Columns[5].DefaultCellStyle.BackColor = Color.LightGreen;
            }
            else
            {
                dtg_visualStarch.Columns[1].DefaultCellStyle.BackColor = Color.Violet;
                dtg_visualStarch.Columns[2].DefaultCellStyle.BackColor = Color.Violet;
                dtg_visualStarch.Columns[3].DefaultCellStyle.BackColor = Color.Violet;
                dtg_visualStarch.Columns[4].DefaultCellStyle.BackColor = Color.LightGreen;
                dtg_visualStarch.Columns[5].DefaultCellStyle.BackColor = Color.LightGreen;
            }


        }

        private void cb_visualPay_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Load_VSC();
            }
            catch { }
        }

        private void chk_allvisualQA_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            //Check_Dill_Data();

            if (chk_allvisualQA.Checked == true)
            {
                for (int i = 0; i < dtg_visualStarch.RowCount; i++)
                {
                    try
                    {
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }

                        con.Open();

                        int sts = 0;

                        //string sql = "SELECT [idVSRNo] AS 'รหัส',[ValueName]  AS 'ชื่อวิเคราะห์',[ValueLab]  AS 'ค่าที่ได้ WH',[StatusLab]  AS 'สถานะ-WH',[ValueSP]  AS 'ค่าที่ได้ SP',[StatusSP] AS 'สถานะ-SP' FROM  [dbo].[V_VisualSP] Where [LabID]=" + cb_visualPay.SelectedValue.ToString() + "  AND [PaysetID]=" + PaySeting_ID + " ";

                        string sql = "";
                        if (C_count == 0)
                        {
                            if (dtg_visualStarch.Rows[i].Cells[3].Value.ToString().Trim() == "True") { sts = 1; }
                            sql = "Update  [dbo].[TB_VisualRange] Set [Value]=" + dtg_visualStarch.Rows[i].Cells[2].Value.ToString().Trim() + ",[ValueActive]=" + sts + " WHERE [idVSRNo]=" + dtg_visualStarch.Rows[i].Cells[0].Value.ToString() + "";
                        }

                        else
                        {
                            sts = 1;
                            sql = "Update  [dbo].[TB_VisualRange] Set [Value]=" + dtg_visualStarch.Rows[i].Cells[3].Value.ToString().Trim() + ",[ValueActive]=" + sts + " WHERE [idVSRNo]=" + dtg_visualStarch.Rows[i].Cells[0].Value.ToString() + "";

                        }


                        SqlCommand CM2 = new SqlCommand(sql, con);
                        SqlDataReader DR2 = CM2.ExecuteReader();

                    }

                    catch
                    {

                    }

                }

                con.Close();
                Load_Visual();
                //chk_allvisualQA.Checked = false;
            }
        }

        private void btn_saveOptionSP_Click(object sender, EventArgs e)
        {
            if (PaySeting_ID != 0)
            {
                if (chk_optionalVisual.Checked == true)
                { txt_optionalVisual.Enabled = true; }
                else { txt_optionalVisual.Enabled = false; }

                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

                int OptionalStatus = 0;
                if (chk_optionalVisual.Checked == true)
                { OptionalStatus = 1; }

                int ExcludeMoistStatus = 0;
                if (chk_excludeMoist.Checked == true)
                { ExcludeMoistStatus = 1; }

                con.Open();
                string sql = "Update  [dbo].[TB_PaymentSetting]  Set [OptionalVisualStatus]=" + OptionalStatus + ",[OptionalVisual]= '" + txt_optionalVisual.Text.Trim() + "',[ExcludeMoistStatus]=" + ExcludeMoistStatus + " WHERE [VendorGroupID]= '" + cb_PayvendorGroup.SelectedValue.ToString() + "' AND [ProductID] ='" + cb_Payproduct_True.SelectedValue.ToString() + "' AND PaysetID =" + PaySeting_ID + "  ";
                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();


                Msg = "Change PaymentSetting in Option Payment!";
                Log_OldValue = "OptionalVisualStatus =" + OptionalStatus +
                    "" + "OptionalVisual = " + txt_optionalVisual.Text.Trim() +
                    "" + "ExcludeMoistStatus = " + ExcludeMoistStatus +
                    "" + "VendorGroupID = " + cb_PayvendorGroup.SelectedValue.ToString() +
                    "" + "ProductID = " + cb_Payproduct_True.SelectedValue.ToString() +
                    "" + "PaysetID = " + PaySeting_ID;

                Log_NewValue = "";

                Class_Log CL = new Class_Log();
                CL.tbname = Msg;
                CL.oldvalue = Log_OldValue;
                CL.newvalue = Log_NewValue;
                CL.Save_log();
            }
        }

        private void Load_Visual()
        {
            try
            {
                if (PaySeting_ID != 0)
                {

                    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                    con.ConnectionString = Program.pathdb_Weight;
                    SqlDataAdapter dtAdapter = new SqlDataAdapter();
                    con.Open();

                    //string sql = "SELECT [idVSRNo] AS 'รหัส',[ValueName]  AS 'ชื่อวิเคราะห์',[ValueLab]  AS 'ค่าที่ได้ WH',[StatusLab]  AS 'สถานะ-WH',[ValueSP]  AS 'ค่าที่ได้ SP',[StatusSP] AS 'สถานะ-SP' FROM  [dbo].[V_VisualSP] Where [LabID]=" + cb_visualPay.SelectedValue.ToString() + "  AND [PaysetID]=" + PaySeting_ID + " ";
                    string sql = "";
                    if (C_count == 0)
                    {
                        sql = "SELECT [idVSRNo] AS 'รหัส',[ValueName]  AS 'ชื่อวิเคราะห์',[ValueLab]  AS 'ค่าที่ได้ WH',[StatusLab]  AS 'สถานะ-WH',[ValueSP]  AS 'ค่าที่ได้ SP',[StatusSP] AS 'สถานะ-SP' FROM  [dbo].[V_VisualSP] Where [LabID]=" + cb_visualPay.SelectedValue.ToString() + "  AND [PaysetID]=" + PaySeting_ID + " ";
                    }
                    else
                    {
                        sql = "SELECT [idVSRNo] AS 'รหัส',[Vmin]  AS 'ค่าต่ำ-WH',[Vmax]  AS 'ค่าสูง-WH',[VSelect]  AS 'ค่าที่ได้',[ValueSP]  AS 'ค่าที่ได้ SP',[StatusSP] AS 'สถานะ-SP' FROM  [dbo].[V_VisualSP_DillData] Where [LabID]=" + cb_visualPay.SelectedValue.ToString() + "  AND [PaysetID]=" + PaySeting_ID + " ";
                    }

                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "g_v");
                    dtg_visualStarch.DataSource = ds.Tables["g_v"];
                    con.Close();

                    dtg_visualStarch.Columns[0].Width = 0;

                    if (dtg_visualStarch.RowCount > 0)
                    { chk_newVisual.Enabled = false; }
                    else { chk_newVisual.Enabled = true; chk_newVisual.Checked = false; }

                    dtg_visualStarch.Columns[4].DefaultCellStyle.BackColor = Color.LightGreen;
                    dtg_visualStarch.Columns[5].DefaultCellStyle.BackColor = Color.LightGreen;
                }

                else
                { dtg_visualStarch.DataSource = null; }
            }
            catch { }
        }

        private void txt_searchName_TextChanged(object sender, EventArgs e)
        {
            Initialize_SearchVendor_ComboBox();
        }

        private DataTable GetDataSource_Vendor()
        {
            DataTable dtSource = new DataTable();

            DataColumn Vendor_No = new DataColumn("Vendor_No");
            Vendor_No.DataType = System.Type.GetType("System.String");
            dtSource.Columns.Add(Vendor_No);

            DataColumn Names = new DataColumn("Names");
            Names.DataType = System.Type.GetType("System.String");
            dtSource.Columns.Add(Names);

            DataColumn Address = new DataColumn("Address");
            Address.DataType = System.Type.GetType("System.String");
            dtSource.Columns.Add(Address);

            DataColumn TambonName = new DataColumn("TambonName");
            TambonName.DataType = System.Type.GetType("System.String");
            dtSource.Columns.Add(TambonName);

            DataColumn AmphurName = new DataColumn("AmphurName");
            AmphurName.DataType = System.Type.GetType("System.String");
            dtSource.Columns.Add(AmphurName);

            DataColumn ProvinceName = new DataColumn("ProvinceName");
            ProvinceName.DataType = System.Type.GetType("System.String");
            dtSource.Columns.Add(ProvinceName);

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql = "SELECT Trim([Vendor_No])  AS 'รหัสผู้ขาย',Trim([Names]) AS 'ชื่อผู้ขาย',Trim([Address]) AS 'ที่อยู่',Trim ([TambonName]) AS 'ตำบล',Trim([AmphurName]) AS 'อำเภอ',Trim([ProvinceName]) AS 'จังหวัด' FROM [dbo].[V_Vendor] Where [Names] like '%" + txt_searchName.Text.Trim() + "%'";

            SqlCommand CM1 = new SqlCommand(sql, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            while (DR1.Read())
            {
                DataRow row = dtSource.NewRow();
                row[Vendor_No] = DR1["รหัสผู้ขาย"].ToString();
                row[Names] = DR1["ชื่อผู้ขาย"].ToString();
                row[Address] = DR1["ที่อยู่"].ToString();
                row[TambonName] = DR1["ตำบล"].ToString();
                row[AmphurName] = DR1["อำเภอ"].ToString();
                row[ProvinceName] = DR1["จังหวัด"].ToString();
                dtSource.Rows.Add(row);
            }
            DR1.Close();

            con.Close();
            return dtSource;
        }

        private void Initialize_SearchVendor_ComboBox()
        {
            mtCo_searchName.Clear();
            mtCo_searchName.SourceDataString = new string[6] { "Vendor_No", "Names", "Address", "TambonName", "AmphurName", "ProvinceName" };
            mtCo_searchName.ColumnWidth = new string[6] { "80", "220", "280", "80", "80", "100" };
            mtCo_searchName.DataSource = GetDataSource_Vendor();
            btn_SearchVendorCard.ForeColor = Color.Blue;
        }


        private void Load_Owner() //ประเภทแหล่งสินค้า ไร่ /ลาน /สมาคม เป็นต้น
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand(" Select [OwnerID],[OwnerName]  From [dbo].[TB_OwnerProductType] ", con);
            DataSet ds = new DataSet();
            //ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            //Load product tab weight scale Setup
            cbo_typeSorucRM.DataSource = ds.Tables[0];
            cbo_typeSorucRM.DisplayMember = "OwnerName";
            cbo_typeSorucRM.ValueMember = "OwnerID";
        }

        private void Load_SearchNew_Record()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql1 = "Select * From   [dbo].[V_Vendor] Where [Vendor_No] ='" + mtCo_searchName.SelectedItem.Value.ToString() + "' ";

            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                txt_idVendor.Text = DR1["Vendor_No"].ToString();
                txt_name.Text = DR1["Names"].ToString();
                txt_address.Text = DR1["Address"].ToString();
                TombonId = Convert.ToInt32(DR1["TombonId"].ToString());
                txt_nameContach.Text = DR1["Contact"].ToString();
                txt_mobileNo.Text = DR1["Phone_No"].ToString();
                txt_email.Text = DR1["Email"].ToString();
                txt_lineID.Text = DR1["Line_ID"].ToString();
                txt_latitude.Text = DR1["Lat_RM_Addr"].ToString();
                txt_longitude.Text = DR1["Long_RM_Addr"].ToString();
                txt_taxNo.Text = DR1["VAT_Registration_No"].ToString();
                txt_branchName.Text = DR1["Bank_Branch_No"].ToString();
                txt_bankNo.Text = DR1["Bank_Account_No"].ToString();
                cb_Vendorbank.SelectedValue = DR1["Bank_Code"].ToString();

                try
                {
                    cbo_typeSorucRM.SelectedValue = DR1["OwnerID"].ToString();
                }
                catch { }

                cbo_tambon.Text = DR1["TambonName"].ToString();
                cbo_amphor.Text = DR1["AmphurName"].ToString();
                cbo_porvice.Text = DR1["ProvinceName"].ToString();
            }
            DR1.Close();
            con.Close();
        }

        private void Search_Type()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            cbo_tambon.SelectedValue = TombonId;

            string sql = "SELECT [AmphurId],[ProvinceId],[ZipCode] FROM [dbo].[V_Address] Where [TombonId]=" + TombonId + "";

            SqlCommand CM1 = new SqlCommand(sql, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                cbo_amphor.SelectedValue = DR1["AmphurId"].ToString().Trim();
                cbo_porvice.SelectedValue = DR1["ProvinceId"].ToString().Trim();
                txt_zipcode.Text = DR1["ZipCode"].ToString().Trim();
            }
            DR1.Close();

            con.Close();
        }

        private void btn_SearchVendorCard_Click(object sender, EventArgs e)
        {
            Load_Owner();
            Load_SearchNew_Record();
            Load_VendorGroup();
            Search_Type();
        }

        private void chk_searchAddress_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void txt_searchAddress_TextChanged(object sender, EventArgs e)
        {
            Initialize_SearchAddress_ComboBox();
        }

        private void Initialize_SearchAddress_ComboBox()
        {

            mtCo_searchAddress.Clear();
            mtCo_searchAddress.SourceDataString = new string[5] { "TombonId", "TambonName", "AmphurName", "ProvinceName", "ZipCode" };
            mtCo_searchAddress.ColumnWidth = new string[5] { "80", "150", "180", "200", "120" };
            mtCo_searchAddress.DataSource = GetDataAddress_Vendors();

            btn_searchAddress.ForeColor = Color.Blue;
        }

        private void btn_searchAddress_Click(object sender, EventArgs e)
        {
            tbc_address.SelectedIndex = 0;
            TombonId = Convert.ToInt32(mtCo_searchAddress.SelectedItem.Value.ToString());
            Search_Type();
        }

        private void btn_saveVendor_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string Bank_Code = "000";
                int Tambon_ID = 1;
                int Owner_ID = 1;

                if (cbo_tambon.SelectedValue != null)
                {
                    Tambon_ID = Convert.ToInt32(cbo_tambon.SelectedValue.ToString());
                }

                if (cb_Vendorbank.SelectedValue != null)
                {
                    Bank_Code = cb_Vendorbank.SelectedValue.ToString();
                }

                if (cbo_typeSorucRM.SelectedValue != null)
                {
                    Owner_ID = Convert.ToInt32(cbo_typeSorucRM.SelectedValue.ToString());
                }

                //string sql = "";
                if (checkBox2.Checked == true)  // INsert in to card
                {
                    //sql = "Insert Into [dbo].[Vendor] ([Vendor_No],[Names],[Address],[VAT_Registration_No],[Phone_No],[Email],[Line_ID],[Contact],[OwnerID]) Values ('" + cb_product_Lab.SelectedValue.ToString() + "')";

                    //SqlCommand CM2 = new SqlCommand(sql, con);
                    //SqlDataReader DR2 = CM2.ExecuteReader();

                    //MessageBox.Show("เพิ่มข้อมูลสำเร็จ+++", "ผลการบันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Cler_Data();
                }

                else  //update vendor card
                {

                    string sql = "UPDATE [dbo].[Vendor] SET [Names] = '" + txt_name.Text.Trim() + "' ,[Address] ='" + txt_address.Text.Trim() + "' ,[TombonId] =" + TombonId.ToString().Trim() + ",[Phone_No] = '" + txt_mobileNo.Text.Trim() + "' ,[Email] = '" + txt_email.Text.Trim() + "' ,[Line_ID] = '" + txt_lineID.Text.Trim() + "' ,[Contact] ='" + txt_nameContach.Text.Trim() + "' ,[OwnerID] = " + Owner_ID + ", [Lat_RM_Addr]='" + txt_latitude.Text.Trim() + "' ,[Long_RM_Addr]='" + txt_longitude.Text.Trim() + "',[Bank_Code] = '" + Bank_Code + "',[Bank_Branch_No] ='" + txt_branchName.Text.Trim() + "',[Bank_Account_No] ='" + txt_bankNo.Text.Trim() + "',[VAT_Registration_No]='" + txt_taxNo.Text.Trim() + "' WHERE [Vendor_No] ='" + txt_idVendor.Text.Trim() + "'";

                    SqlCommand CM2 = new SqlCommand(sql, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    con.Close();

                    MessageBox.Show("ปรับปรุงข้อมูลสำเร็จ+++", "ผลการบันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    Msg = "Update to Record in Vendor Card!";
                    Log_OldValue = "Names = " + txt_name.Text.Trim() +
                        "," + "Address = " + txt_address.Text.Trim() +
                        "," + "TombonId = " + TombonId.ToString() +
                        "," + "Phone_No = " + txt_mobileNo.Text.Trim() +
                        "," + "Email = " + txt_email.Text.Trim() +
                        "," + "Line_ID = " + txt_lineID.Text.Trim() +
                        "," + "Contact = " + txt_nameContach.Text.Trim() +
                        "," + "OwnerID = " + Owner_ID.ToString() +
                        "," + "Lat_RM_Addr = " + txt_latitude.Text.Trim() +
                        "," + "Long_RM_Addr = " + txt_longitude.Text.Trim() +
                        "," + "Bank_Code = " + Bank_Code.ToString().Trim() +
                        "," + "Bank_Branch_No = " + txt_branchName.Text.Trim() +
                        "," + "Bank_Account_No = " + txt_bankNo.Text.Trim() +
                        "," + "VAT_Registration_No = " + txt_taxNo.Text.Trim() +
                        "," + " WHERE Vendor_No = " + txt_idVendor.Text.Trim();

                    Log_NewValue = "-";
                    Class_Log CL = new Class_Log();
                    CL.oldvalue = Log_OldValue;
                    CL.newvalue = Log_NewValue;
                    CL.Save_log();

                    Cler_Data();
                }
            }
            catch (Exception ex)

            {

                MessageBox.Show(ex.ToString(), "Error Save/Update Vendor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_googleMap_Click(object sender, EventArgs e)
        {
            string URL_MAP = "https://www.google.co.th/maps/@" + txt_latitude.Text.Trim() + "," + txt_longitude.Text.Trim() + ".15z";

            System.Diagnostics.Process.Start("https://www.google.co.th/maps/@" + txt_latitude.Text.Trim() + "," + txt_longitude.Text.Trim() + ".15z");

            //https://www.google.co.th/maps/@13.7237436,100.5183629,15z
        }

        private DataTable GetDataAddress_Vendors()
        {
            DataTable dtSource = new DataTable();

            DataColumn TombonId = new DataColumn("TombonId");
            TombonId.DataType = System.Type.GetType("System.String");
            dtSource.Columns.Add(TombonId);

            DataColumn TambonName = new DataColumn("TambonName");
            TambonName.DataType = System.Type.GetType("System.String");
            dtSource.Columns.Add(TambonName);

            DataColumn AmphurName = new DataColumn("AmphurName");
            AmphurName.DataType = System.Type.GetType("System.String");
            dtSource.Columns.Add(AmphurName);

            DataColumn ProvinceName = new DataColumn("ProvinceName");
            ProvinceName.DataType = System.Type.GetType("System.String");
            dtSource.Columns.Add(ProvinceName);

            DataColumn ZipCode = new DataColumn("ZipCode");
            ZipCode.DataType = System.Type.GetType("System.String");
            dtSource.Columns.Add(ZipCode);

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql = "";

            if (rdo_tambon.Checked == true)
            {
                sql = "SELECT [TombonId]  AS 'รหัสตำบล',Trim([TambonName]) AS 'ชื่อตำบล/แขวง',Trim([AmphurName]) AS 'ชื่ออำเภอ/เขต',Trim ([ProvinceName]) AS 'ชื่อจังหวัด',Trim([ZipCode]) AS 'รหัสไปรษณีย์' FROM [dbo].[V_Address] Where [TambonName] like '%" + txt_searchAddress.Text.Trim() + "%'";
            }

            if (rdo_amphor.Checked == true)
            {
                sql = "SELECT [TombonId]  AS 'รหัสตำบล',Trim([TambonName]) AS 'ชื่อตำบล/แขวง',Trim([AmphurName]) AS 'ชื่ออำเภอ/เขต',Trim ([ProvinceName]) AS 'ชื่อจังหวัด',Trim([ZipCode]) AS 'รหัสไปรษณีย์' FROM [dbo].[V_Address] Where [AmphurName] like '%" + txt_searchAddress.Text.Trim() + "%'";
            }

            if (rdo_provice.Checked == true)
            {
                sql = "SELECT [TombonId]  AS 'รหัสตำบล',Trim([TambonName]) AS 'ชื่อตำบล/แขวง',Trim([AmphurName]) AS 'ชื่ออำเภอ/เขต',Trim ([ProvinceName]) AS 'ชื่อจังหวัด',Trim([ZipCode]) AS 'รหัสไปรษณีย์' FROM [dbo].[V_Address] Where [ProvinceName] like '%" + txt_searchAddress.Text.Trim() + "%'";
            }

            SqlCommand CM1 = new SqlCommand(sql, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            while (DR1.Read())
            {
                DataRow row = dtSource.NewRow();
                row[TombonId] = DR1["รหัสตำบล"].ToString();
                row[TambonName] = DR1["ชื่อตำบล/แขวง"].ToString();
                row[AmphurName] = DR1["ชื่ออำเภอ/เขต"].ToString();
                row[ProvinceName] = DR1["ชื่อจังหวัด"].ToString();
                row[ZipCode] = DR1["รหัสไปรษณีย์"].ToString();
                dtSource.Rows.Add(row);
            }
            DR1.Close();

            con.Close();
            return dtSource;

        }


        private void dtg_visualStarch_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.dtg_visualStarch.Rows[e.RowIndex].Cells[1].ReadOnly = true;
            this.dtg_visualStarch.Rows[e.RowIndex].Cells[2].ReadOnly = true;
            this.dtg_visualStarch.Rows[e.RowIndex].Cells[3].ReadOnly = true;
        }

        private void dtg_visualStarch_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            int Active_visual = 0;

            double Value_SP = 0;

            Value_SP = Convert.ToDouble(dtg_visualStarch.Rows[e.RowIndex].Cells[4].Value.ToString().Trim());


            int VSActive = 0;
            if (dtg_visualStarch.Rows[e.RowIndex].Cells[5].Value.ToString().Trim() == "True")
            {
                VSActive = 1;
            }
            con.Open();
            string sql = "Update  [dbo].[TB_VisualRange] Set [Value]=" + Value_SP + ", [ValueActive]=" + VSActive + " WHERE [idVSRNo]=" + dtg_visualStarch.Rows[e.RowIndex].Cells[0].Value.ToString() + "";
            SqlCommand CM2 = new SqlCommand(sql, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();

            Msg = "Update DataLab in TypeVisual!";
            Log_OldValue = "Value = " + Value_SP.ToString() +
                    "," + "ValueActive = " + VSActive.ToString() +
                    "," + "Where idSTRNo = " + dtg_visualStarch.Rows[e.RowIndex].Cells[0].Value.ToString();
            Log_NewValue = "-";

            Class_Log CL = new Class_Log();
            CL.tbname = Msg;
            CL.oldvalue = Log_OldValue;
            CL.newvalue = Log_NewValue;
            CL.Save_log();

            Load_Visual();
        }

        private void Cler_Data()
        {
            txt_idVendor.Clear();
            txt_name.Clear();
            txt_address.Clear();
            txt_zipcode.Clear();
            txt_nameContach.Clear();
            txt_mobileNo.Clear();
            txt_email.Clear();
            txt_latitude.Clear();
            txt_longitude.Clear();
            txt_lineID.Clear();
            cbo_typeSorucRM.Text = "ไม่ระบุ";

            cbo_tambon.Text = "";
            cbo_amphor.Text = "";
            cbo_porvice.Text = "";

            txt_taxNo.Clear();
            cb_Vendorbank.SelectedValue = "000";
            txt_branchName.Clear();
            txt_bankNo.Clear();
        }

        private void cb_labPay_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Lab();
        }

        private void dtg_labStarch_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.dtg_labStarch.Rows[e.RowIndex].Cells[1].ReadOnly = true;
            this.dtg_labStarch.Rows[e.RowIndex].Cells[2].ReadOnly = true;
            this.dtg_labStarch.Rows[e.RowIndex].Cells[3].ReadOnly = true;
            this.dtg_labStarch.Rows[e.RowIndex].Cells[4].ReadOnly = true;
            this.dtg_labStarch.Rows[e.RowIndex].Cells[9].ReadOnly = true;
        }

        private void dtg_labStarch_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            int Active_price = 0;

            try
            {

                if (dtg_labStarch.Rows[e.RowIndex].Cells[8].Value.ToString() == "True")

                { Active_price = 1; }

                con.Open();
                string sql = "Update  [dbo].[TB_StarchRange] Set [MinSP] =" + dtg_labStarch.Rows[e.RowIndex].Cells[5].Value.ToString().Trim() + ",[MaxSP] =" + dtg_labStarch.Rows[e.RowIndex].Cells[6].Value.ToString().Trim() + ",[Value] =" + dtg_labStarch.Rows[e.RowIndex].Cells[7].Value.ToString().Trim() + ",[ValueActive] =" + Active_price + " WHERE [idSTRNo]=" + dtg_labStarch.Rows[e.RowIndex].Cells[9].Value.ToString() + "";
                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();

                Msg = "Update to Record in TB_StarchRange!";
                Log_OldValue = "MinSP = " + dtg_labStarch.Rows[e.RowIndex].Cells[5].Value.ToString().Trim() +
                        "," + "MaxSP = " + dtg_labStarch.Rows[e.RowIndex].Cells[6].Value.ToString().Trim() +
                        "," + "Value = " + dtg_labStarch.Rows[e.RowIndex].Cells[7].Value.ToString().Trim() +
                        "," + "ValueActive = " + Active_price.ToString() +
                        "," + "Where idSTRNo = " + dtg_labStarch.Rows[e.RowIndex].Cells[9].Value.ToString();
                Log_NewValue = "-";

                Class_Log CL = new Class_Log();
                CL.tbname = Msg;
                CL.oldvalue = Log_OldValue;
                CL.newvalue = Log_NewValue;
                CL.Save_log();
            }
            catch
            {


            }
        }

        private void Load_Lab()
        {
            try
            {
                if (PaySeting_ID != 0)
                {
                    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                    con.ConnectionString = Program.pathdb_Weight;
                    SqlDataAdapter dtAdapter = new SqlDataAdapter();
                    con.Open();

                    dtg_labStarch.DataSource = null;

                    // string sql = "SELECT [idSTRNo] AS 'รหัส',[Min] AS 'ค่าเริ่ม QA',[Max] AS 'ค่าสิ้นสุด QA', [ValueLab] AS 'ค่าที่ได้ QA', [StatusLab] AS 'สถานะ QA',[MinSP] AS 'ค่าเริ่ม SP', [MaxSP] AS 'ค่าสิ้นสุด SP' ,[ValueSP] AS 'ค่าที่ได้ SP', [StatusSP] AS 'สถานะ SP' FROM  [dbo].[V_LabSP] WHERE [LabID]=" + cb_labPay.SelectedValue.ToString() + "  AND [PaysetID] = " + PaySeting_ID + "";

                    //string sql = "SELECT [LOGID] AS 'รหัส',  [Min] AS 'ค่าเริ่ม QA',[Max] AS 'ค่าสิ้นสุด QA',[Rate] AS 'ค่าที่ได้ QA', [DeductActive] AS 'สถานะ QA','' AS 'ค่าเริ่ม SP', '' AS 'ค่าสิ้นสุด SP' ,'' AS 'ค่าที่ได้ SP', '' AS 'สถานะ SP','' AS 'idSTRNo' FROM [dbo].[TB_ValueLab] Where[LabID] =" + cb_labPay.SelectedValue.ToString() + " AND [DeductActive]=1";


                    string sql = " SELECT [LOGID] AS 'รหัส',  [Min] AS 'ค่าเริ่ม QA',[Max] AS 'ค่าสิ้นสุด QA',[Rate] AS 'ค่าที่ได้ QA', [DeductActive] AS 'สถานะ QA',(Select[MinSP] From[dbo].[TB_StarchRange] Where[dbo].[TB_StarchRange].[PaysetID] = " + PaySeting_ID + " AND[dbo].[TB_StarchRange].[ValueVisualNo] = [dbo].[TB_ValueLab].[LOGID] ) AS 'ค่าเริ่ม SP', (Select[MaxSP] From[dbo].[TB_StarchRange] Where[dbo].[TB_StarchRange].[PaysetID] = " + PaySeting_ID + " AND[dbo].[TB_StarchRange].[ValueVisualNo] = [dbo].[TB_ValueLab].[LOGID] ) AS 'ค่าสิ้นสุด SP',(Select[Value] From[dbo].[TB_StarchRange] Where[dbo].[TB_StarchRange].[PaysetID] = " + PaySeting_ID + " AND[dbo].[TB_StarchRange].[ValueVisualNo] = [dbo].[TB_ValueLab].[LOGID] ) AS 'ค่าที่ได้ SP',(Select[ValueActive] From[dbo].[TB_StarchRange] Where[dbo].[TB_StarchRange].[PaysetID] = " + PaySeting_ID + " AND[dbo].[TB_StarchRange].[ValueVisualNo] = [dbo].[TB_ValueLab].[LOGID] ) AS 'สถานะ SP',(Select [idSTRNo] From[dbo].[TB_StarchRange] Where[dbo].[TB_StarchRange].[PaysetID] =" + PaySeting_ID + "   AND [dbo].[TB_StarchRange].[ValueVisualNo] = [dbo].[TB_ValueLab].[LOGID] ) AS 'idSTRNo'  FROM [dbo].[TB_ValueLab] Where [LabID] = " + cb_labPay.SelectedValue.ToString().Trim() + "AND[DeductActive] = 1";


                    //string sql = "SELECT [idSTRNo] AS 'รหัส',[Min] AS 'ค่าเริ่ม QA',[Max] AS 'ค่าสิ้นสุด QA', [ValueLab] AS 'ค่าที่ได้ QA', [StatusLab] AS 'สถานะ QA',[MinSP] AS 'ค่าเริ่ม SP', [MaxSP] AS 'ค่าสิ้นสุด SP' ,[ValueSP] AS 'ค่าที่ได้ SP', [StatusSP] AS 'สถานะ SP' FROM  [dbo].[V_LabSP] WHERE [LabID]=" + cb_labPay.SelectedValue.ToString() + "  AND [PaysetID] = " + PaySeting_ID + "";

                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "g_vst");
                    dtg_labStarch.DataSource = ds.Tables["g_vst"];
                    con.Close();

                    dtg_labStarch.Columns[0].DefaultCellStyle.BackColor = Color.Violet;
                    dtg_labStarch.Columns[1].DefaultCellStyle.BackColor = Color.Violet;
                    dtg_labStarch.Columns[2].DefaultCellStyle.BackColor = Color.Violet;
                    dtg_labStarch.Columns[3].DefaultCellStyle.BackColor = Color.Violet;
                    dtg_labStarch.Columns[4].DefaultCellStyle.BackColor = Color.Violet;
                    dtg_labStarch.Columns[5].DefaultCellStyle.BackColor = Color.LightGreen;
                    dtg_labStarch.Columns[6].DefaultCellStyle.BackColor = Color.LightGreen;
                    dtg_labStarch.Columns[7].DefaultCellStyle.BackColor = Color.LightGreen;
                    dtg_labStarch.Columns[8].DefaultCellStyle.BackColor = Color.LightGreen;


                    dtg_labStarch.Columns[0].Width = 60;
                    dtg_labStarch.Columns[9].Width = 0;
                }

                else
                { dtg_labStarch.DataSource = null; }
            }
            catch { }
        }

        private void Sub_Fpayment_Load(object sender, EventArgs e)
        {
            Load_Product();
            Load_VendorGroup();
            Load_VendorSettingGroup();
            Load_UnitType();
            Load_VisualGroup();
            
            Load_Owner();
            Load_Tambon();
            Load_Amphor();
            Load_Provice();
            Load_Permission();
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
                if (DR1["ID_Menu"].ToString().Trim() == "88") //ความปลอดภัย   9
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True")
                    { /* add menu nornallyk */

                        (tab_menu.TabPages[0] as TabPage).Enabled = true;
                    }
                }

                if (DR1["ID_Menu"].ToString().Trim() == "89") //ความปลอดภัย   9
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


        private void Load_Product()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                //Product 
                SqlCommand cmd = new SqlCommand("Select [ProductID],[ProductID] +':'+ [ProductName] AS 'ProductName' From  [dbo].[TB_Products]  Where [StatusActive] =1", con);


                DataSet ds3 = new DataSet();
                //ds.Clear();
                SqlDataAdapter da3 = new SqlDataAdapter();
                da3.SelectCommand = cmd;
                da3.Fill(ds3);
                //Load product tab payment Setup
                cb_Payproduct_True.DataSource = ds3.Tables[0];
                cb_Payproduct_True.DisplayMember = "ProductName";
                cb_Payproduct_True.ValueMember = "ProductID";
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

        private void Load_UnitType()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                //Product 
                SqlCommand cmd = new SqlCommand("Select [UnitID],[UnitName]  From  [dbo].[TB_Units] ", con);
                DataSet ds = new DataSet();
                //ds.Clear();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);

                //Load product tab weight scale Setup
                cb_PayunitPrice.DataSource = ds.Tables[0];
                cb_PayunitPrice.DisplayMember = "UnitName";
                cb_PayunitPrice.ValueMember = "UnitID";

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

        private void Load_Tambon()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            SqlCommand cmd = new SqlCommand(" Select [TombonId],[TambonName]  From [dbo].[TamBon] ORder by [TambonName]", con);
            DataSet ds = new DataSet();
            //ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            //Load product tab weight scale Setup
            cbo_tambon.DataSource = ds.Tables[0];
            cbo_tambon.DisplayMember = "TambonName";
            cbo_tambon.ValueMember = "TombonId";
            con.Close();
        }

        private void Load_Amphor()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            SqlCommand cmd = new SqlCommand(" Select [AmphurId],[AmphurName]  From [dbo].[Amphur]  ORder by [AmphurName]", con);
            DataSet ds = new DataSet();
            //ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            //Load product tab weight scale Setup
            cbo_amphor.DataSource = ds.Tables[0];
            cbo_amphor.DisplayMember = "AmphurName";
            cbo_amphor.ValueMember = "AmphurId";
            con.Close();
        }

        private void Load_Provice()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            SqlCommand cmd = new SqlCommand(" Select [ProvinceId],[ProvinceName]  From [dbo].[Province]  ORder by [ProvinceName]", con);
            DataSet ds = new DataSet();
            //ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            //Load product tab weight scale Setup
            cbo_porvice.DataSource = ds.Tables[0];
            cbo_porvice.DisplayMember = "ProvinceName";
            cbo_porvice.ValueMember = "ProvinceId";
            con.Close();
        }


    }
}
