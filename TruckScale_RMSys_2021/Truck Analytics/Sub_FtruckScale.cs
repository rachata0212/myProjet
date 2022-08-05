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

namespace Truck_Analytics
{
    public partial class Sub_FtruckScale : Form
    {
        public Sub_FtruckScale()
        {
            InitializeComponent();
        }

        // Log
        string Msg = "";
        string Log_OldValue = "-";
        string Log_NewValue = "-";

        int id_search = 0;
        int id_services = 0;
        int sts_chnage = 0;
        int sts_dup = 0;
        int Id_Map = 0;

        int PrintAT_No = 0;
        string id_CustomerAuto = "";
        string id_ProductAuto = "";
        string id_ZoneAuto = "";
        int id_editPrintAuto = 0;

        int items_CountDB = 0;
        int items_CountNAV = 0;
        string LabtypeID = "";
        string id_update;


        // IO file Dll
        string value_line1 = "";
        string value_line2 = "";
        string value_line3 = "";
        string value_line4 = "";
        string value_line5 = "";
        string value_line6 = "";

        private void Sub_FtruckScale_Load(object sender, EventArgs e)
        {
            Load_LoadProduct();
            Load_TruckScale_Config();          
            Load_TruckType();    
            Load_LoadTruckScaleUse();
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
                if (DR1["ID_Menu"].ToString().Trim() == "73") //ความปลอดภัย   9
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True")
                    { /* add menu nornallyk */

                        (tab_menu.TabPages[0] as TabPage).Enabled = true;
                    }
                }

                if (DR1["ID_Menu"].ToString().Trim() == "74") //ความปลอดภัย   9
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True")
                    { /* add menu nornallyk */

                        (tab_menu.TabPages[1] as TabPage).Enabled = true;
                    }
                }

                if (DR1["ID_Menu"].ToString().Trim() == "75") //ความปลอดภัย   9
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True")
                    { /* add menu nornallyk */

                        (tab_menu.TabPages[2] as TabPage).Enabled = true;
                    }
                }

                if (DR1["ID_Menu"].ToString().Trim() == "76") //ความปลอดภัย   9
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True")
                    { /* add menu nornallyk */

                        (tab_menu.TabPages[3] as TabPage).Enabled = true;
                    }
                }

                if (DR1["ID_Menu"].ToString().Trim() == "77") //ความปลอดภัย   9
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True")
                    { /* add menu nornallyk */

                        (tab_menu.TabPages[4] as TabPage).Enabled = true;
                    }
                }

                if (DR1["ID_Menu"].ToString().Trim() == "78") //ความปลอดภัย   9
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True")
                    { /* add menu nornallyk */

                        (tab_menu.TabPages[5] as TabPage).Enabled = true;
                    }
                }

                if (DR1["ID_Menu"].ToString().Trim() == "79") //ความปลอดภัย   9
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True")
                    { /* add menu nornallyk */

                        (tab_menu.TabPages[6] as TabPage).Enabled = true;
                    }
                }
               
            }

            DR1.Close();
            con1.Close();
        }


        private void Load_allScaleConfig()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            //string sql1 = "SELECT [ScaleCode] AS 'No', [ScaleFormat] AS 'Scale List',[PortName], [BaudRate], [DataBit], [Parity], [StopBit], [StartAscii], [EndAscii], [PrintingNo],[EditWeight_In] AS 'Edit_Win',[EditWeight_Out] AS 'Edit_WOut',[Remark] FROM  [dbo].[TB_Scale]";

            string sql1 = "SELECT [ScaleCode] AS 'No', [ScaleFormat] AS 'Scale List',[PortName], [BaudRate], [DataBit], [Parity], [StopBit], [StartAscii], [EndAscii], [PrintingNo],[Remark] FROM  [dbo].[TB_Scale]";


            SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "g_scale");
            dtg_scaleDetail.DataSource = ds1.Tables["g_scale"];
            con.Close();

        
        }
               
        private void Load_TruckScale_Config()
        {
            if (txt_scalefileDll.Text != "")
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql6 = "SELECT *  FROM  [dbo].[TB_Scale] Where [ScaleFormat] ='" + txt_scalefileDll.Text + "'";
                SqlCommand CM6 = new SqlCommand(sql6, con);
                SqlDataReader DR6 = CM6.ExecuteReader();

                DR6.Read();
                {
                    txt_scaleNo.Text = DR6["ScaleCode"].ToString().Trim();
                    cbo_comport.Text = DR6["PortName"].ToString().Trim();
                    cbo_baudrate.Text = DR6["BaudRate"].ToString().Trim();
                    cbo_databit.Text = DR6["DataBit"].ToString().Trim();
                    cbo_parity.Text = DR6["Parity"].ToString().Trim();
                    cbo_stopbit.Text = DR6["StopBit"].ToString().Trim();
                    txt_startCharator.Text = DR6["StartAscii"].ToString().Trim();
                    txt_endCharator.Text = DR6["EndAscii"].ToString().Trim();
                    cbo_formatprint.Text = DR6["PrintingNo"].ToString().Trim();
                }
                DR6.Close();
                con.Close();
            }

        }

        private void Load_WeightScaleSetting()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                //dtg_vendorStarch.DataSource = null;
                con.Open();
                string sql1 = "SELECT * FROM  [dbo].[V_WeightSeting] WHERE [WeightProductID] = '" + cb_productDoc.SelectedValue.ToString() + "' ";

                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                int PrintID = 0;
                int id_regisForm = 0;
                string PrintEthForm;
                string PrintTruckIn;
                string PrintTruckOut;
                string PrintAuto;
                string PrintValueLab1;
                string PrintValueLab2;
                string PrintValueLab3;
                string PrintValueLab4;
                string ShowRemark;

                DR1.Read();
                {
                    PrintID = Convert.ToInt16(DR1["PrintformID"].ToString());
                    id_regisForm = Convert.ToInt16(DR1["id_regisForm"].ToString());
                    PrintEthForm = DR1["PrintEthFormat"].ToString();
                    PrintTruckIn = DR1["PrintTruckIN"].ToString();
                    PrintTruckOut = DR1["PrintTruckOut"].ToString();
                    PrintAuto = DR1["PrintAuto"].ToString();
                    PrintValueLab1 = DR1["PrintValueLab1"].ToString();
                    PrintValueLab2 = DR1["PrintValueLab2"].ToString();
                    PrintValueLab3 = DR1["PrintValueLab3"].ToString();
                    PrintValueLab4 = DR1["PrintValueLab4"].ToString();
                    ShowRemark = DR1["ShowRemark"].ToString();
                }
                DR1.Close();
                con.Close();

                if (PrintID == 1) { rdo_formPrint1.Checked = true; }

                if (PrintID == 2) { rdo_formPrint2.Checked = true; }

                if (PrintID == 3) { rdo_formPrint3.Checked = true; }

                if (PrintID == 4) { rdo_formPrint4.Checked = true; }

                if (PrintID == 5) { rdo_formPrint5.Checked = true; }

                if (PrintID == 6) { rdo_formPrint6.Checked = true; }


                if (id_regisForm == 1) { rdo_registerForm1.Checked = true; }

                if (id_regisForm == 2) { rdo_registerForm2.Checked = true; }

                if (id_regisForm == 3) { rdo_registerForm3.Checked = true; }

                if (id_regisForm == 4) { rdo_registerForm4.Checked = true; }


                if (PrintTruckIn == "True")
                {
                    chk_printTruckIn.Checked = true;
                }
                else { chk_printTruckIn.Checked = false; }

                if (PrintTruckOut == "True")
                {
                    chk_printTruckOut.Checked = true;
                }
                else { chk_printTruckOut.Checked = false; }

                if (PrintAuto == "True")
                { chk_printAuto.Checked = true; }
                else { chk_printAuto.Checked = false; }

                if (PrintEthForm == "True")
                { chk_printOrtherFomat.Checked = true; }
                else { chk_printOrtherFomat.Checked = false; }

                if (PrintValueLab1 == "True")
                { chk_labview1.Checked = true; }
                else { chk_labview1.Checked = false; }

                if (PrintValueLab2 == "True")
                { chk_labview2.Checked = true; }
                else { chk_labview2.Checked = false; }

                if (PrintValueLab3 == "True")
                { chk_labview3.Checked = true; }
                else { chk_labview3.Checked = false; }

                if (PrintValueLab4 == "True")
                { chk_labview4.Checked = true; }
                else { chk_labview4.Checked = false; }
                
                if (ShowRemark == "True")
                { chk_showRemark.Checked = true; }
                else { chk_showRemark.Checked = false; }

                btn_saveWeightScale.ForeColor = Color.Red;
            }
            catch
            {
                rdo_formPrint1.Checked = false;
                rdo_formPrint2.Checked = false;
                rdo_formPrint3.Checked = false;
                rdo_formPrint4.Checked = false;
                rdo_formPrint5.Checked = false;
                rdo_formPrint6.Checked = false;
                chk_printAuto.Checked = false;
                chk_printTruckIn.Checked = false;
                chk_printTruckOut.Checked = false;
                chk_labview1.Checked = false;
                chk_labview2.Checked = false;
                chk_labview3.Checked = false;
                chk_labview4.Checked = false;
                chk_printOrtherFomat.Checked = false;
            }
        }

        private void Load_TruckType()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                //Product 
                SqlCommand cmd = new SqlCommand("Select [TruckTypeID],[TruckTypeName]  From  [dbo].[TB_TruckType] ", con);
                DataSet ds = new DataSet();
                //ds.Clear();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);


                //Load product tab weight scale Setup
                cb_truckTypeService.DataSource = ds.Tables[0];
                cb_truckTypeService.DisplayMember = "TruckTypeName";
                cb_truckTypeService.ValueMember = "TruckTypeID";

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

        private void Load_LoadTruckScaleUse()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                //Product 
                SqlCommand cmd = new SqlCommand("SELECT [ScaleCode],[ScaleFormat] FROM [SapthipNewDB].[dbo].[TB_Scale]", con);

                DataSet ds1 = new DataSet();
                //ds.Clear();
                SqlDataAdapter da1 = new SqlDataAdapter();
                da1.SelectCommand = cmd;
                da1.Fill(ds1);
                //Load product tab weight scale Setup
                cbo_useconfig.DataSource = ds1.Tables[0];
                cbo_useconfig.DisplayMember = "ScaleFormat";
                cbo_useconfig.ValueMember = "ScaleCode";            
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


        private void Load_LoadProduct()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                //Product 
                SqlCommand cmd = new SqlCommand("Select [ProductID],[ProductID] +':'+ [ProductName] AS 'ProductName' From  [dbo].[TB_Products]  Where [StatusActive] =1", con);

                DataSet ds1 = new DataSet();
                //ds.Clear();
                SqlDataAdapter da1 = new SqlDataAdapter();
                da1.SelectCommand = cmd;
                da1.Fill(ds1);
                //Load product tab weight scale Setup
                cb_productService.DataSource = ds1.Tables[0];
                cb_productService.DisplayMember = "ProductName";
                cb_productService.ValueMember = "ProductID";

                DataSet ds2 = new DataSet();
                //ds.Clear();
                SqlDataAdapter da2 = new SqlDataAdapter();
                da2.SelectCommand = cmd;
                da2.Fill(ds2);
                //Load product tab weight scale Setup
                cb_productDoc.DataSource = ds2.Tables[0];
                cb_productDoc.DisplayMember = "ProductName";
                cb_productDoc.ValueMember = "ProductID";
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

        private void btn_saveWeightConfig_Click(object sender, EventArgs e)
        {
            Update_WeightScale();
        }

        private void Update_WeightScale()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            int PrintID = 0;
            int ID_RegisterForm = 0;
            int PrintTruckIN = 0;
            int PrintTruckOut = 0;
            int PrintAuto = 0;
            int PrintValueLab1 = 0;
            int PrintValueLab2 = 0;
            int PrintValueLab3 = 0;
            int PrintValueLab4 = 0;
            int PrintEtcFormat = 0;
            int ShowRemark = 0;

            //check id print form   
            if (rdo_formPrint1.Checked == true) { PrintID = 1; }
            if (rdo_formPrint2.Checked == true) { PrintID = 2; }
            if (rdo_formPrint3.Checked == true) { PrintID = 3; }
            if (rdo_formPrint4.Checked == true) { PrintID = 4; }
            if (rdo_formPrint5.Checked == true) { PrintID = 5; }
            if (rdo_formPrint6.Checked == true) { PrintID = 6; }


            if (rdo_registerForm1.Checked == true) { ID_RegisterForm = 1; }
            if (rdo_registerForm2.Checked == true) { ID_RegisterForm = 2; }
            if (rdo_registerForm3.Checked == true) { ID_RegisterForm = 3; }
            if (rdo_registerForm4.Checked == true) { ID_RegisterForm = 4; }

            if (chk_printTruckIn.Checked == true) { PrintTruckIN = 1; }
            if (chk_printTruckOut.Checked == true) { PrintTruckOut = 1; }
            if (chk_printAuto.Checked == true) { PrintAuto = 1; }
            if (chk_labview1.Checked == true) { PrintValueLab1 = 1; }
            if (chk_labview2.Checked == true) { PrintValueLab2 = 1; }
            if (chk_labview3.Checked == true) { PrintValueLab3 = 1; }
            if (chk_labview4.Checked == true) { PrintValueLab4 = 1; }
            if (chk_printOrtherFomat.Checked == true) { PrintEtcFormat = 1; }
            if (chk_showRemark.Checked == true) { ShowRemark = 1; }

            con.Open();

            int CheckItems = 0;
            string sql5 = "SELECT Count([WeightProductID]) AS 'CheckItems' FROM  [dbo].[TB_WeightscaleSetting] Where  [WeightProductID]='" + cb_productDoc.SelectedValue.ToString() + "'";
            SqlCommand CM5 = new SqlCommand(sql5, con);
            SqlDataReader DR5 = CM5.ExecuteReader();
            DR5.Read();
            {
                CheckItems = Convert.ToInt16(DR5["CheckItems"].ToString());
            }
            DR5.Close();
            con.Close();

            string sql1 = "";
            if (CheckItems == 0)
            {
                con.Open();
                sql1 = "Insert Into  [dbo].[TB_WeightscaleSetting] ([WeightProductID],[Id_menu]) Values ('" + cb_productDoc.SelectedValue.ToString() + "',16)";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                con.Close();

                Msg = "Insert New Record in Weight Scele Setting!";
                Log_NewValue = "WeightProductID = " + cb_productDoc.SelectedValue.ToString() +
                         "," + "Id_menu = 16 ";

                Log_OldValue = "-";

            }

            else
            {
                con.Open();
                sql1 = "Update  [dbo].[TB_WeightscaleSetting] Set [PrintformID]=" + PrintID + ",[PrintTruckIN]=" + PrintTruckIN + ",[PrintTruckOut]=" + PrintTruckOut + ",[PrintAuto]=" + PrintAuto + ",[PrintValueLab1]=" + PrintValueLab1 + ",[PrintValueLab2]=" + PrintValueLab2 + ",[PrintValueLab3]=" + PrintValueLab3 + ",[PrintValueLab4]=" + PrintValueLab4 + ",[id_regisForm]=" + ID_RegisterForm + ",[PrintEthFormat] = " + PrintEtcFormat + ",[ShowRemark] = " + ShowRemark + " WHERE [WeightProductID]='" + cb_productDoc.SelectedValue.ToString() + "'";
                SqlCommand CM2 = new SqlCommand(sql1, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();

                Msg = "Update to Record in Weight Scele Setting!";
                Log_OldValue = "PrintformID = " + PrintID.ToString() +
                         "," + "PrintTruckIN = " + PrintTruckIN.ToString() +
                         "," + "PrintTruckOut = " + PrintTruckOut.ToString() +
                         "," + "PrintAuto = " + PrintAuto.ToString() +
                         "," + "PrintValueLab1 = " + PrintValueLab1.ToString() +
                         "," + "PrintValueLab2 = " + PrintValueLab2.ToString() +
                         "," + "PrintValueLab3 = " + PrintValueLab3.ToString() +
                         "," + "PrintValueLab4 = " + PrintValueLab4.ToString() +
                         "," + "id_regisForm = " + ID_RegisterForm.ToString() +
                         "," + "PrintEthFormat = " + PrintEtcFormat.ToString() +
                         "," + " WHERE WeightProductID = " + cb_productService.SelectedValue.ToString();

                Log_NewValue = "-";
            }

            Class_Log CL = new Class_Log();
            CL.tbname = Msg;
            CL.oldvalue = Log_OldValue;
            CL.newvalue = Log_NewValue;
            CL.Save_log();

            MessageBox.Show("บันทึกสำเร็จ", "รายงานการบันทึก", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private void LoadMapping_Databank()
        {
            try
            {
                if (cb_productService.SelectedIndex > -1)
                {
                    dtg_mapping.DataSource = null;
                    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                    con.ConnectionString = Program.pathdb_Weight;
                    SqlDataAdapter dtAdapter = new SqlDataAdapter();
                    con.Open();
                    string sql = "";

                    if (id_search == 0)
                    {
                        sql = "SELECT [Id_Map] AS 'รหัส',[Vendor_No] AS 'รหัสผู้จ่าย',[Vendor_Name] AS 'ชื่อผู้จ่าย',[Bank_Name] AS 'ธนาคาร',[Customer_No] AS 'รหัสผู้รับ',[Customer_Name] AS 'ชื่อผู้รับ' FROM [dbo].[V_VenMapCus] Where [Product_ID]='" + cb_productService.SelectedValue.ToString().Trim() + "' Order by Id_Map Desc";
                    }

                    if (id_search == 1)
                    {
                        sql = "SELECT [Id_Map] AS 'รหัส',[Vendor_No] AS 'รหัสผู้จ่าย',[Vendor_Name] AS 'ชื่อผู้จ่าย',[Bank_Name] AS 'ธนาคาร',[Customer_No] AS 'รหัสผู้รับ',[Customer_Name] AS 'ชื่อผู้รับ' FROM [dbo].[V_VenMapCus] Where [Product_ID]='" + cb_productService.SelectedValue.ToString().Trim() + "' AND [Vendor_No] Like '%" + txt_vendorNo.Text.Trim() + "%' Order by Id_Map Desc";
                    }

                    if (id_search == 2)
                    {
                        sql = "SELECT [Id_Map] AS 'รหัส',[Vendor_No] AS 'รหัสผู้จ่าย',[Vendor_Name] AS 'ชื่อผู้จ่าย',[Bank_Name] AS 'ธนาคาร',[Customer_No] AS 'รหัสผู้รับ',[Customer_Name] AS 'ชื่อผู้รับ' FROM [dbo].[V_VenMapCus] Where [Product_ID]='" + cb_productService.SelectedValue.ToString().Trim() + "' AND [Vendor_Name] Like '%" + txt_nameVendor.Text.Trim() + "%' Order by Id_Map Desc";
                    }

                    if (id_search == 3)
                    {
                        sql = "SELECT [Id_Map] AS 'รหัส',[Vendor_No] AS 'รหัสผู้จ่าย',[Vendor_Name] AS 'ชื่อผู้จ่าย',[Bank_Name] AS 'ธนาคาร',[Customer_No] AS 'รหัสผู้รับ',[Customer_Name] AS 'ชื่อผู้รับ' FROM [dbo].[V_VenMapCus] Where [Product_ID]='" + cb_productService.SelectedValue.ToString().Trim() + "' AND [Customer_No] Like '%" + txt_customerNo.Text.Trim() + "%' Order by Id_Map Desc";
                    }

                    if (id_search == 4)
                    {
                        sql = "SELECT [Id_Map] AS 'รหัส',[Vendor_No] AS 'รหัสผู้จ่าย',[Vendor_Name] AS 'ชื่อผู้จ่าย',[Bank_Name] AS 'ธนาคาร',[Customer_No] AS 'รหัสผู้รับ',[Customer_Name] AS 'ชื่อผู้รับ' FROM [dbo].[V_VenMapCus] Where [Product_ID]='" + cb_productService.SelectedValue.ToString().Trim() + "' AND [Customer_Name] Like '%" + txt_nameCustomer.Text.Trim() + "%' Order by Id_Map Desc";
                    }

                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "g_s");
                    dtg_mapping.DataSource = ds.Tables["g_s"];
                    con.Close();

                    dtg_mapping.Columns[0].Width = 100;
                    dtg_mapping.Columns[1].Width = 120;
                    dtg_mapping.Columns[3].Width = 180;
                    dtg_mapping.Columns[4].Width = 120;

                    //tool_sts_countItems.Text = "Total: " + dtg_mapping.RowCount.ToString() + "Items";

                }
            }

            catch
            {
                cb_productService.Text = "-- กรุณาเลือกสินค้า --";          
            }
        }

        private void chk_nonService_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_nonService.Checked == true)
            {
                chk_haveService.Checked = false;
            }
        }

        private void chk_haveService_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_haveService.Checked == true && chk_newService.Checked == false)
            {
                chk_nonService.Checked = false;
            }

            if (chk_haveService.Checked == true && chk_newService.Checked == true)
            {
                chk_nonService.Checked = false;
                txt_serviceName.Clear();
                txt_weightPrice.Clear();
                txt_loadPrice.Clear();
                txt_remarkVat.Clear();
                txt_valueVat.Clear();
                rdo_includeVat.Checked = true;
            }
        }

        private void btn_saveServiceConfig_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            int sts_service = 0;
            int include_vat = 0;
            int weight_price = 0;
            int load_price = 0;
            int vat = 0;

            if (txt_weightPrice.Text.Trim() != "")
            { weight_price = Convert.ToInt16(txt_weightPrice.Text.Trim()); }

            if (txt_loadPrice.Text.Trim() != "")
            { load_price = Convert.ToInt16(txt_loadPrice.Text.Trim()); }


            if (txt_valueVat.Text.Trim() != "")
            { vat = Convert.ToInt16(txt_valueVat.Text.Trim()); }
            string sql = "";

            if (chk_haveService.Checked == true) { sts_service = 1; }
            if (rdo_includeVat.Checked == true) { include_vat = 1; }

            if (chk_nonService.Checked == true)
            {
                sql = "Insert Into [TB_Services] ([ServiceName],[ServiceStatus],[WeightPrice],[LoadPrice],[WeightProductID],[TruckTypeID],[IncludeVat],[VatUnit],[Remark]) Values('" + cb_truckTypeService.Text + "',0, 0, 0,'" + cb_productService.SelectedValue.ToString() + "'," + cb_truckTypeService.SelectedValue.ToString() + ",0,0,'ไม่มีค่าบริการ' )";

                Msg = "Insert New Record in Service Charge!";
                Log_NewValue = "ServiceName = " + cb_truckTypeService.Text.Trim() +
                    "," + "ServiceStatus = 0" +
                    "," + "WeightPrice = 0" +
                    "," + "LoadPrice = 0" +
                    "," + "WeightProductID = " + cb_productService.SelectedValue.ToString() +
                    "," + "TruckTypeID = " + cb_truckTypeService.SelectedValue.ToString() +
                    "," + "IncludeVat = 0" +
                    "," + "VatUnit = 0 " +
                    "," + "Remark = ไม่มีค่าบริการ";
                Log_OldValue = "-";
            }


            if (chk_haveService.Checked == true)
            {
                sql = "Insert Into [TB_Services] ([ServiceName],[ServiceStatus],[WeightPrice],[LoadPrice],[WeightProductID],[TruckTypeID],[IncludeVat],[VatUnit],[Remark]) Values('" + txt_serviceName.Text.Trim() + "'," + sts_service + ", " + weight_price + ", " + load_price + ",'" + cb_productService.SelectedValue.ToString() + "'," + cb_truckTypeService.SelectedValue.ToString() + "," + include_vat + "," + vat + ",'" + txt_remarkVat.Text.Trim() + "' )";

                Msg = "Update to Record in Service Charge! (Not Service Charge)";
                Log_NewValue = "ServiceName = " + txt_serviceName.Text.Trim() +
                   "," + "ServiceStatus = " + sts_service.ToString() +
                   "," + "WeightPrice = " + weight_price.ToString() +
                   "," + "LoadPrice = " + load_price.ToString() +
                   "," + "WeightProductID = " + cb_productService.SelectedValue.ToString() +
                   "," + "TruckTypeID = " + include_vat.ToString() +
                   "," + "IncludeVat = " + vat.ToString() +
                   "," + "VatUnit = " + cb_truckTypeService.Text.Trim() +
                   "," + "Remark= " + txt_remarkVat.Text.Trim();
                Log_OldValue = "-";
            }

            if (id_services != 0)
            {

                sql = "Update  [dbo].[TB_Services] Set [ServiceName]='" + txt_serviceName.Text.Trim() + "',[ServiceStatus]=" + sts_service + ",[WeightPrice]=" + weight_price + ",[LoadPrice]=" + load_price + ",[WeightProductID]='" + cb_productService.SelectedValue.ToString() + "',[TruckTypeID]=" + cb_truckTypeService.SelectedValue.ToString() + ",[IncludeVat]=" + include_vat + ",[VatUnit]=" + vat + ",[Remark]='" + txt_remarkVat.Text.Trim() + "' WHERE [ServiceID]=" + id_services + "";

                Msg = "Update to Record in Service Charge! (Free Service Charge)";
                Log_OldValue = sql;


            }


            //string sql2 = "Update [TB_Services] Set [ServiceStatus]=" + sts_service + ",[WeightPrice]=" + txt_weightPrice.Text.Trim() + ",[LoadPrice]=" + txt_loadPrice.Text.Trim() + ",[WeightProductID]=" + cb_proService.SelectedValue.ToString() + ",[TruckTypeID]=" + cb_truckTypeService.SelectedValue.ToString() + ",[IncludeVat]=" + include_vat + ",[VatUnit]=" + txt_valueVat.Text.Trim() + ",[Remark]='" + txt_remarkVat.Text.Trim() + " WHERE [ServiceID]=" + id_services + "";

            SqlCommand CM2 = new SqlCommand(sql, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();

            Class_Log CL = new Class_Log();
            CL.tbname = Msg;
            CL.oldvalue = Log_OldValue;
            CL.newvalue = Log_NewValue;
            CL.Save_log();

            Load_Service();
        }

        private void rdo_searchService_CheckedChanged(object sender, EventArgs e)
        {
            txt_nameCustomer.BackColor = Color.White;
            txt_nameVendor.BackColor = Color.White;


            if (rdo_searchService.Checked == true)
            {
                sts_chnage = 0;
                id_search = 0;
                txt_nameCustomer.Clear();
                txt_customerNo.Clear();
                txt_nameVendor.Clear();
                txt_vendorNo.Clear();
                txt_nameCustomer.ReadOnly = false;
                txt_vendorName.ReadOnly = false;
                txt_vendorNo.ReadOnly = false;
                txt_customerNo.ReadOnly = false;

                txt_nameCustomer.BackColor = Color.PowderBlue;
                txt_nameVendor.BackColor = Color.PowderBlue;
                txt_customerNo.BackColor = Color.WhiteSmoke;
                txt_vendorNo.BackColor = Color.WhiteSmoke;

                btn_searchVendor.Enabled = true;
                btn_searchCustomer.Enabled = true;
            }

        }

        private void rdo_onlineService_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_onlineService.Checked == true)
            {
                txt_nameCustomer.BackColor = Color.LightGreen;
                txt_nameVendor.BackColor = Color.LightGreen;
                btn_searchCustomer.Enabled = true;
                btn_searchVendor.Enabled = true;

                sts_chnage = 0;
                id_search = 0;

                txt_vendorNo.ReadOnly = false;
                txt_customerNo.ReadOnly = false;
                txt_nameCustomer.Clear();
                txt_customerNo.Clear();
                txt_nameVendor.Clear();
                txt_vendorNo.Clear();
            }
        }

        private void rdo_offlineService_CheckedChanged(object sender, EventArgs e)
        {

            if (rdo_offlineService.Checked == true)
            {
                txt_nameCustomer.BackColor = Color.Khaki;
                txt_nameVendor.BackColor = Color.Khaki;
                btn_searchCustomer.Enabled = true;
                btn_searchVendor.Enabled = true;

                sts_chnage = 0;
                id_search = 0;

                txt_vendorNo.ReadOnly = false;
                txt_customerNo.ReadOnly = false;
                txt_nameCustomer.Clear();
                txt_customerNo.Clear();
                txt_nameVendor.Clear();
                txt_vendorNo.Clear();
            }
        }

        private void btn_searchVendor_Click(object sender, EventArgs e)
        {
            F_Search f_sarch = new F_Search();   //Search  Vendor in Navision        

            if (rdo_onlineService.Checked == true)
            {
                f_sarch.id_findType = 13;   //search type
            }

            if (rdo_offlineService.Checked == true)
            {
                f_sarch.id_findType = 3;   //search type
            }


            f_sarch.ShowDialog();

            //return value          
            txt_vendorNo.Text = f_sarch.id_value;
            txt_nameVendor.Text = f_sarch.name_value;
            cb_bank.SelectedValue = f_sarch.id_bankcode.Trim();
        }

        private void btn_searchCustomer_Click(object sender, EventArgs e)
        {
            F_Search f_sarch = new F_Search();   //Search  Vendor in Navision        

            if (rdo_onlineService.Checked == true)
            {
                f_sarch.id_findType = 13;   //search type
            }

            if (rdo_offlineService.Checked == true)
            {
                f_sarch.id_findType = 3;   //search type
            }


            f_sarch.ShowDialog();

            //return value          
            txt_vendorNo.Text = f_sarch.id_value;
            txt_nameVendor.Text = f_sarch.name_value;
            cb_bank.SelectedValue = f_sarch.id_bankcode.Trim();
        }

        private void btn_saveVenmapCus_Click(object sender, EventArgs e)
        {
            Check_DuplicateMapping();

            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();
                string sql = "";

                if (rdo_onlineService.Checked == true)
                {

                    if (sts_chnage == 0) //เพิ่มใหม่
                    {
                        if (sts_dup == 0)
                        {
                            sql = "INSERT INTO [dbo].[Ven_Map_Cus]([Vendor_No],[Vendor_Name],[Customer_No],[Customer_Name],[Product_ID],[Bank_Code]) VALUES('" + txt_vendorNo.Text.Trim() + "','" + txt_nameVendor.Text.Trim() + "','" + txt_customerNo.Text.Trim() + "','" + txt_nameCustomer.Text.Trim() + "','" + cb_productService.SelectedValue.ToString().Trim() + "','" + cb_bank.SelectedValue.ToString().Trim() + "')";

                            SqlCommand CM2 = new SqlCommand(sql, con);
                            SqlDataReader DR2 = CM2.ExecuteReader();

                            Msg = "Insert New Record in Vendor!(Online Data)";
                            Log_NewValue = "Vendor_No = " + txt_vendorNo.Text.Trim() +
                                "," + "Vendor_Name = " + txt_nameVendor.Text.Trim() +
                                "," + "Customer_No = " + txt_customerNo.Text.Trim() +
                                "," + "Customer_Name = " + txt_nameCustomer.Text.Trim() +
                                "," + "Product_ID = " + cb_productService.SelectedValue.ToString().Trim() +
                                "," + "Bank_Code = " + cb_bank.SelectedValue.ToString().Trim();
                            Log_OldValue = "-";
                        }

                        else
                        {
                            MessageBox.Show("ข้อมูลชุดนี้ได้ถูกบันทึกแล้ว", "บันทึกข้อมูลซ้ำ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                }

                if (rdo_offlineService.Checked == true)
                {
                    if (sts_dup == 0)
                    {
                        sql = "INSERT INTO [dbo].[Ven_Map_Cus]([Vendor_No],[Vendor_Name],[Customer_No],[Customer_Name],[Product_ID]) VALUES('" + txt_vendorNo.Text.Trim() + "','" + txt_nameVendor.Text.Trim() + "','" + txt_customerNo.Text.Trim() + "','" + txt_nameCustomer.Text.Trim() + "','" + cb_productService.SelectedValue.ToString().Trim() + "')";

                        SqlCommand CM2 = new SqlCommand(sql, con);
                        SqlDataReader DR2 = CM2.ExecuteReader();

                        Msg = "Insert New Record in Vendor!(Offline Data)";
                        Log_NewValue = "Vendor_No = " + txt_vendorNo.Text.Trim() +
                                "," + "Vendor_Name = " + txt_nameVendor.Text.Trim() +
                                "," + "Customer_No = " + txt_customerNo.Text.Trim() +
                                "," + "Customer_Name = " + txt_nameCustomer.Text.Trim() +
                                "," + "Product_ID = " + cb_productService.SelectedValue.ToString().Trim();
                        Log_OldValue = "-";

                        MessageBox.Show("บันทึกสำเร็จ", "บันทึกข้อมูลสำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        MessageBox.Show("ข้อมูลชุดนี้ได้ถูกบันทึกแล้ว", "บันทึกข้อมูลซ้ำ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        sts_dup = 0;
                    }

                }

                if (sts_chnage == 1) //ปรับ
                {
                    sql = "Update [dbo].[Ven_Map_Cus] Set [Vendor_No] = '" + txt_vendorNo.Text.Trim() + "',[Vendor_Name]='" + txt_nameVendor.Text.Trim() + "',[Customer_No]='" + txt_customerNo.Text.Trim() + "',[Customer_Name] = '" + txt_nameCustomer.Text.Trim() + "',[Product_ID]='" + cb_productService.SelectedValue.ToString().Trim() + "' Where [Id_Map] = " + Id_Map + "";

                    SqlCommand CM2 = new SqlCommand(sql, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                }


                Class_Log CL = new Class_Log();
                CL.tbname = Msg;
                CL.oldvalue = Log_OldValue;
                CL.newvalue = Log_NewValue;
                CL.Save_log();

                txt_vendorNo.Clear();
                txt_nameVendor.Clear();
                txt_customerNo.Clear();
                txt_nameCustomer.Clear();

                id_search = 0;
                LoadMapping_Databank();
            }

            catch
            { }
        }

        private void Check_DuplicateMapping()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            string sql1 = "Select COUNT([Id_Map]) as'Check_dup' from [dbo].[Ven_Map_Cus] Where [Vendor_No]='" + txt_vendorNo.Text.Trim() + "' AND [Product_ID]='" + cb_productService.SelectedValue.ToString().Trim() + "'";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();
            DR1.Read();
            {
                sts_dup = Convert.ToInt16(DR1["Check_dup"].ToString());
            }
            DR1.Close();
            con.Close();

        }

        private void chk_newService_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_newService.Checked == true)
            {
                id_services = 0;
            }
        }

        private void dtg_service_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id_services = Convert.ToInt16(dtg_service.Rows[e.RowIndex].Cells[0].Value.ToString());
                txt_serviceName.Text = dtg_service.Rows[e.RowIndex].Cells[1].Value.ToString();
                cb_productService.Text = dtg_service.Rows[e.RowIndex].Cells[2].Value.ToString();
                cb_truckTypeService.Text = dtg_service.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_weightPrice.Text = dtg_service.Rows[e.RowIndex].Cells[4].Value.ToString();
                txt_loadPrice.Text = dtg_service.Rows[e.RowIndex].Cells[5].Value.ToString();
                txt_remarkVat.Text = dtg_service.Rows[e.RowIndex].Cells[9].Value.ToString();
                cb_truckTypeService.SelectedValue = dtg_service.Rows[e.RowIndex].Cells[10].Value.ToString();

                if (dtg_service.Rows[e.RowIndex].Cells[6].Value.ToString() == "True")
                { rdo_includeVat.Checked = true; rdo_excludeVat.Checked = false; }
                else { rdo_includeVat.Checked = false; rdo_excludeVat.Checked = true; }

                if (dtg_service.Rows[e.RowIndex].Cells[8].Value.ToString() == "True")
                { chk_haveService.Checked = true; chk_nonService.Checked = false; }
                else { chk_nonService.Checked = true; chk_haveService.Checked = false; }

                txt_valueVat.Text = dtg_service.Rows[e.RowIndex].Cells[7].Value.ToString();

                chk_newService.Checked = false;
            }
        }

        private void dtg_mapping_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    sts_chnage = 1;
                    rdo_onlineService.Checked = false;
                    rdo_searchService.Checked = false;
                    id_search = 3;
                    Id_Map = Convert.ToInt16(dtg_mapping.Rows[e.RowIndex].Cells[0].Value.ToString());
                    txt_vendorNo.Text = dtg_mapping.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                    txt_nameVendor.Text = dtg_mapping.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                    txt_customerNo.Text = dtg_mapping.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                    txt_nameCustomer.Text = dtg_mapping.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();

                    cb_bank.Text = dtg_mapping.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                    btn_searchVendor.Enabled = true;
                    btn_searchCustomer.Enabled = true;

                }
            }
            catch { }
        }

        private void btn_saveWeightScale_Click(object sender, EventArgs e)
        {
            //new insert
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql = "";
            if (chk_newInterface.Checked == true)
            {
                sql = "Insert Into [TB_Scale] ([ScaleFormat],[PortName],[BaudRate],[DataBit],[Parity],[StopBit],[StartAscii],[EndAscii],[PrintingNo],[WeightSize],[ToledoFormat],[Intervals],[AllowActive],[Remark],[EditWeight_In],[EditWeight_Out]) Values('" + txt_scalefileDll.Text.Trim() + "', '" + cbo_comport.Text.Trim() + "'," + cbo_baudrate.Text.Trim() + ", " + cbo_databit.Text.Trim() + ", '" + cbo_parity.Text.Trim() + "','" + cbo_stopbit.Text.Trim() + "'," + txt_startCharator.Text.Trim() + "," + txt_endCharator.Text.Trim() + "," + cbo_formatprint.Text.Trim() + ",0,0,0,0,'" + txt_remarkScale.Text.Trim() + "',0,0)";

                Msg = "Insert New Record in Print Auto Type!";
                Log_NewValue = "CreateDate = " + DateTime.Now.ToShortDateString() +
                    "," + "ScaleFormat = " + txt_scalefileDll.Text.ToString() +
                    "," + "PortName = " + cbo_comport.Text.Trim() +
                    "," + "BaudRate = " + cbo_baudrate.Text.Trim() +
                    "," + "DataBit = " + cbo_databit.Text.Trim() +
                    "," + "Parity = " + cbo_parity.Text.Trim() +
                    "," + "StopBit = " + cbo_stopbit.Text.Trim();
                Log_OldValue = "-";

            }

            else
            {
                sql = "Update [TB_Scale] SET [ScaleFormat] = '" + txt_scalefileDll.Text.Trim() + "' ,[PortName]='" + cbo_comport.Text.Trim() + "',[BaudRate]='" + cbo_baudrate.Text.Trim() + "',[DataBit]= '" + cbo_databit.Text.Trim() + "',[Parity]= " + cbo_parity.Text.Trim() + ",[StopBit]='" + cbo_stopbit.Text.Trim() + "',[StartAscii]='" + txt_startCharator.Text.Trim() + "',[EndAscii]='" + txt_endCharator.Text.Trim() + "',[PrintingNo]='" + cbo_formatprint.Text.Trim() + "',[Remark]='" + txt_remarkScale.Text.Trim() + "' WHERE [ScaleCode]  = " + txt_scaleNo.Text.Trim() + "";

                Msg = "Update to Record in Print Auto Type!";

                Log_OldValue = "Update_Date = " + DateTime.Now.ToShortDateString() +
                     "," + "ScaleFormat = " + txt_scalefileDll.Text.ToString() +
                    "," + "PortName = " + cbo_comport.Text.Trim() +
                    "," + "BaudRate = " + cbo_baudrate.Text.Trim() +
                    "," + "DataBit = " + cbo_databit.Text.Trim() +
                    "," + "Parity = " + cbo_parity.Text.Trim() +
                    "," + "StopBit = " + cbo_stopbit.Text.Trim() +
                "," + "WHERE ScaleCode = " + txt_scaleNo.Text.Trim();
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
          
            Clear_TxtScale();
        }

        private void Clear_TxtScale()
        {
            txt_scaleNo.Clear();
            txt_scalefileDll.Clear();
            txt_startCharator.Clear();
            txt_endCharator.Clear();
            txt_remarkScale.Clear();
            
            cbo_baudrate.Text = "";
            cbo_comport.Text = "";
            cbo_formatprint.Text = "";
            cbo_databit.Text = "";
            cbo_parity.Text = "";
            cbo_stopbit.Text = "";
           
        }


        private void dtg_scaleDetail_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                btn_saveWeightScale.ForeColor = Color.Red;
                txt_scaleNo.Text = dtg_scaleDetail.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_scalefileDll.Text = dtg_scaleDetail.Rows[e.RowIndex].Cells[1].Value.ToString();               
                cbo_comport.Text = dtg_scaleDetail.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbo_baudrate.Text = dtg_scaleDetail.Rows[e.RowIndex].Cells[3].Value.ToString();
                cbo_databit.Text = dtg_scaleDetail.Rows[e.RowIndex].Cells[4].Value.ToString();
                cbo_parity.Text = dtg_scaleDetail.Rows[e.RowIndex].Cells[5].Value.ToString();
                cbo_stopbit.Text = dtg_scaleDetail.Rows[e.RowIndex].Cells[6].Value.ToString();
                cbo_formatprint.Text = dtg_scaleDetail.Rows[e.RowIndex].Cells[9].Value.ToString();
                txt_startCharator.Text = dtg_scaleDetail.Rows[e.RowIndex].Cells[7].Value.ToString();
                txt_endCharator.Text = dtg_scaleDetail.Rows[e.RowIndex].Cells[8].Value.ToString();
                txt_remarkScale.Text = dtg_scaleDetail.Rows[e.RowIndex].Cells[10].Value.ToString().Trim();

                //cbo_useconfig.Text= txt_scaleNo.Text = dtg_scaleDetail.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();

            }
        }

        private void bnt_printAT_Save_Click(object sender, EventArgs e)
        {
            string date = Program.Date_Now + ' ' + Program.Time_Now;
            int id_Active = 0;

            if (chk__printAT_statusActive.Checked == true) { id_Active = 1; }

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            int Check_PurSale = 0;
           
            //ซื้อ= 0  ขาย=1

            if (cb_typeAuto.SelectedIndex == 0)
            {
                Check_PurSale = 0;
           
            }

            if (cb_typeAuto.SelectedIndex == 1)
            {
                Check_PurSale = 1;
             
            }

            string sql = "";
            if (chh_newAuto.Checked==true)
            {

                sql = "Insert Into [TB_PrintAuto] ( [CreateDate],[ID_Barcode],[Ven_Cus_ID],[NO_Zone],[ProductID],[ActiveStatus],[Plate1],[PurSale]) Values('" + date + "', '" + txt_printAT_barcode.Text + "', '" + id_CustomerAuto + "','" + id_ZoneAuto + "', '" + id_ProductAuto + "', " + id_Active + ",'" + txt_printAT_plate1.Text + "'," + Check_PurSale + ")";

                Msg = "Insert New Record in Print Auto Type!";
                Log_NewValue = "CreateDate = " + date.ToString() +
                    "," + "ID_Barcode = " + txt_printAT_barcode.Text.ToString() +
                    "," + "CustomerID = " + id_CustomerAuto.ToString() +
                    "," + "NO_Zone = " + id_ZoneAuto.ToString() +
                    "," + "ProductID = " + id_ProductAuto.ToString() +
                    "," + "ActiveStatus = " + id_Active.ToString() +
                    "," + "Plate1 = " + txt_printAT_plate1.Text.Trim();
                Log_OldValue = "-";

            }

            if (chh_newAuto.Checked == false)
            {
                sql = "Update [TB_PrintAuto] SET [ID_Barcode] = '" + txt_printAT_barcode.Text.Trim() + "' ,[Ven_Cus_ID]='" + id_CustomerAuto + "',[NO_Zone]='" + id_ZoneAuto.Trim() + "',[ProductID]= '" + id_ProductAuto + "',[ActiveStatus]= " + id_Active + ",[Plate1]='" + txt_printAT_plate1.Text.Trim() + "',[PurSale]=" + Check_PurSale + " WHERE [PrintAT_No]  = " + PrintAT_No + "";

                Msg = "Update to Record in Print Auto Type!";

                Log_OldValue = "CreateDate = " + date.ToString() +
                     "," + "ID_Barcode = " + txt_printAT_barcode.Text.ToString() +
                     "," + "CustomerID = " + id_CustomerAuto.ToString() +
                     "," + "NO_Zone = " + id_ZoneAuto.ToString() +
                     "," + "ProductID = " + id_ProductAuto.ToString() +
                     "," + "ActiveStatus = " + id_Active.ToString() +
                     "," + "Plate1 = " + txt_printAT_plate1.Text.Trim() +
                "," + "WHERE PrintAT_No = " + PrintAT_No.ToString();
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

            Load_DataPrintAutoPur();
            Load_DataPrintAutoSale();
            Clear_TxTAutoPrint();
        }

        private void Load_DataPrintAutoSale()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            dtg_printAT_dataSale.DataSource = null;
            string sql1 = "SELECT [PrintAT_No] AS 'รหัส',[CreateDate] AS 'วันที่สร้าง',[ID_Barcode] AS 'รหัสบัตร',[Plate1] AS 'ทะเบียน' ,[NO_Zone] AS 'รหัสที่เก็บ' ,[Name_Zone] AS 'ชื่อสถานที่เก็บ',[Ven_Cus_ID] AS 'รหัสผู้ซื้อ',[CustomerName] AS 'ชื่อผู้ซื้อ',[ProductID] AS 'รหัสสินค้า' ,[ProductName] AS 'ชื่อสินค้า' ,[ActiveStatus] AS 'เปิดใช้งาน'  FROM  [dbo].[V_PrintAuto_Sale]";

            SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "g_auto");
            dtg_printAT_dataSale.DataSource = ds1.Tables["g_auto"];

            //dtg_printAT_dataSale.Columns[0].Width = 100;

            con.Close();
        }


        private void Load_DataPrintAutoPur()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            dtg_printAT_dataPur.DataSource = null;
            string sql1 = "SELECT [PrintAT_No] AS 'รหัส',[CreateDate] AS 'วันที่สร้าง',[ID_Barcode] AS 'รหัสบัตร',[Plate1] AS 'ทะเบียน' ,[NO_Zone] AS 'รหัสที่เก็บ' ,[Name_Zone] AS 'ชื่อสถานที่เก็บ',[Ven_Cus_ID] AS 'รหัสผู้ขาย',[VendorName] AS 'ชื่อผู้ขาย',[ProductID] AS 'รหัสสินค้า' ,[ProductName] AS 'ชื่อสินค้า' ,[ActiveStatus] AS 'เปิดใช้งาน'  FROM  [dbo].[V_PrintAuto_Pur]";

            SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "g_auto");
            dtg_printAT_dataPur.DataSource = ds1.Tables["g_auto"];

            //dtg_printAT_dataPur.Columns[0].Width = 100;

            con.Close();
        }

        private void Clear_TxTAutoPrint()
        {
            PrintAT_No = 0;
            id_CustomerAuto = "";
            id_ProductAuto = "";
            id_ZoneAuto = "";
            id_editPrintAuto = 0;
            txt_printAT_barcode.Clear();
            txt_printAT_barcodeExam.Clear();
            txt_printAT_plate1.Clear();
            txt_printAT_nameLocation.Clear();
            txt_printAT_nameCustomer.Clear();
            txt_printAT_nameProduct.Clear();
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            F_ReportCRT frpc = new F_ReportCRT();
            frpc.PrintformID = 6;

            if (cb_typeAuto.SelectedIndex == 0)
            {
                frpc.id_typeJob = 1;
            }

            if (cb_typeAuto.SelectedIndex == 1)
            {
                frpc.id_typeJob = 2;
            }

            frpc.id_product = id_ProductAuto;
            frpc.id_ticket = PrintAT_No.ToString();
            frpc.ShowDialog();
        }

        private void btn_printAT_searchCustomer_Click(object sender, EventArgs e)
        {
            F_Search fnd = new F_Search();

            if (cb_typeAuto.SelectedIndex == 0)//ค้นหาซื้อ
            {
                fnd.id_findType = 3;
            }

            if (cb_typeAuto.SelectedIndex == 1) //ค้นหาขาย
            {
                fnd.id_findType = 4;
            }
            fnd.ShowDialog();
            id_CustomerAuto = fnd.id_value;
            txt_printAT_nameCustomer.Text = id_CustomerAuto + ":" + fnd.name_value;
        }

        private void btn__printAT_searchProduct_Click(object sender, EventArgs e)
        {
            F_Search fnd = new F_Search();
            fnd.id_findType = 11;
            fnd.ShowDialog();
            if (fnd.id_value != "")
            {
                id_ProductAuto = fnd.id_value;
                txt_printAT_nameProduct.Text = id_ProductAuto + ":" + fnd.name_value;
            }
        }

        private void btn_printAT_searchLocation_Click(object sender, EventArgs e)
        {
            F_Search fnd = new F_Search();   //ค้นหาจุดลงสินค้า
            fnd.id_findType = 10;
            fnd.id_product = id_ProductAuto;
            fnd.id_vendor = id_CustomerAuto;
            fnd.ShowDialog();

            if (fnd.id_value.Trim() != "")
            {
                id_ZoneAuto = fnd.id_value.Trim();
                txt_printAT_nameLocation.Text = id_ZoneAuto + ":" + fnd.name_value;
            }
        }

        private void chk__printAT_statusActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tb_truckScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SC_width = this.Width;
            int Split_width = SC_width / 4;

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                if (tab_menu.SelectedIndex == 0)  // Service
                {

                    int PrintformID = 0;

                    con.Open();
                    string sql1 = "SELECT * FROM  [dbo].[TB_WeightscaleSetting] WHERE [WeightProductID] = '" + cb_productService.SelectedValue.ToString() + "'";

                    SqlCommand CM1 = new SqlCommand(sql1, con);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    {

                        PrintformID = Convert.ToInt16(DR1["PrintformID"].ToString());

                        if (DR1["PrintTruckIN"].ToString() == "True")
                        {
                            chk_printTruckIn.Checked = true;
                        }

                        if (DR1["PrintTruckOut"].ToString() == "True")
                        {
                            chk_printTruckOut.Checked = true;
                        }

                        if (DR1["PrintAuto"].ToString() == "True")
                        {
                            chk_printAuto.Checked = true;
                        }


                        if (DR1["PrintValueLab1"].ToString() == "True")
                        {
                            chk_labview1.Checked = true;
                        }


                        if (DR1["PrintValueLab2"].ToString() == "True")
                        {
                            chk_labview2.Checked = true;
                        }


                        if (DR1["PrintValueLab3"].ToString() == "True")
                        {
                            chk_labview3.Checked = true;
                        }


                        if (DR1["PrintValueLab4"].ToString() == "True")
                        {
                            chk_labview4.Checked = true;
                        }

                        if (DR1["PrintEthFormat"].ToString() == "True")
                        {
                            chk_printOrtherFomat.Checked = true;
                        }

                        if (DR1["ShowRemark"].ToString() == "True")
                        {
                            chk_showRemark.Checked = true;
                        }

                    }
                    DR1.Close();
                    con.Close();


                    if (PrintformID == 1) { rdo_formPrint1.Checked = true; }

                    if (PrintformID == 2) { rdo_formPrint2.Checked = true; }

                    if (PrintformID == 3) { rdo_formPrint3.Checked = true; }

                    if (PrintformID == 4) { rdo_formPrint4.Checked = true; }

                    if (PrintformID == 5) { rdo_formPrint5.Checked = true; }

                    if (PrintformID == 6) { rdo_formPrint6.Checked = true; }
                }

                if (tab_menu.SelectedIndex == 1)  // Service
                {         
                    Load_Bank();
                    LoadMapping_Databank();
                    Load_Service();

                    dtg_service.ClearSelection();
                }


                if (tab_menu.SelectedIndex == 2)  // Truck Scal config
                {
                    

                    string filename = Application.StartupPath + "\\config.dll";

                    //   string strPath = "Test.txt";
                    if (System.IO.File.Exists(filename))
                    {
                        System.IO.StreamReader StrRer = new System.IO.StreamReader(filename);

                        List<string> listStr = new List<string>();

                        while (!StrRer.EndOfStream)
                        {
                            listStr.Add(StrRer.ReadLine());
                        }

                        value_line1 = listStr[0].ToString().Trim();
                        value_line2 = listStr[1].ToString().Trim();
                        value_line3 = listStr[2].ToString().Trim();
                        value_line4 = listStr[3].ToString().Trim();
                        value_line5 = listStr[4].ToString().Trim();
                        value_line6 = listStr[5].ToString().Trim();

                        StrRer.Close();
                        StrRer.Dispose();

                        cbo_useconfig.Text = listStr[3].ToString().Trim();
                        txt_noExamTicket.Text = listStr[5].ToString().Trim();                       
                      
                    }

                    Load_ScaleConfigName();
                }


                if (tab_menu.SelectedIndex == 3)  // Auto Print Config
                {
                    txt_printAT_Createdate.Text = DateTime.Now.ToShortDateString();                 

                    dtg_printAT_dataSale.ClearSelection();
                }


                if (tab_menu.SelectedIndex == 4)  // Sync Update Product Card
                {

                    gb_productNAV.Width = Split_width * 1;

                    btn_updateDataProduct.Enabled = false;
                    Load_Product_Database();
                    //pn_newProduct.Width = 700;
                    dtg_productNAV.ClearSelection();
                    dtg_productTruck.ClearSelection();

                }

                if (tab_menu.SelectedIndex == 5)  // Sync Update Customer Card
                {
                    gb_customerNAV.Width = Split_width * 1;

                    btn_updateDataCusmer.Enabled = false;
                    Load_Customer_Database();
                    dtg_customerNAV.ClearSelection();
                    dtg_customerTruck.ClearSelection();
                }


                if (tab_menu.SelectedIndex == 6)  // Sync Update Vendor Card
                {
                    gb_vendorNAV.Width = Split_width * 1;

                    btn_updateDataVendor.Enabled = false;
                    Load_Vendor_Database();
                    dtg_vendorNAV.ClearSelection();
                    dtg_vendorTruck.ClearSelection();
                }
            }

            catch
            { }

        }

        private void Load_Vendor_Database()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                dtg_vendorTruck.DataSource = null;

                string sql1 = "SELECT  [Vendor_No] AS 'รหัส',[Names] AS 'ชื่อ',[Address] AS 'ที่อยู่',[TambonName] AS 'ตำบล/แขวง',[AmphurName] AS 'อำเภอ/เขต',[ProvinceName] AS 'จังหวัด',[ZipCode] AS 'ไปรษณีย์',[Contact] AS 'ชื่อผู้ติดต่อ',[Phone_No] AS 'เบอร์โทร' FROM  [dbo].[V_Vendor] WHERE [Vendor_No] <> '01' AND  [Vendor_No] <> '02' AND [Vendor_No] <> 'AP01-0001' AND  [Vendor_No] <> 'AP01-0002'  ORDER BY [Vendor_No] Desc";

                //string sql1 = "SELECT * FROM  [dbo].[V_Vendor] WHERE [Vendor_No] <> '01' AND [Vendor_No] <> '02' AND [Vendor_No] <> 'AP01-0001' AND [Vendor_No] <> 'AP01-0002' ORDER BY [Vendor_No] Desc";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_vendorTruck");
                dtg_vendorTruck.DataSource = ds1.Tables["g_vendorTruck"];
                con.Close();


                items_CountDB = dtg_vendorTruck.RowCount;
                lbl_countDBTruck_Vendor.Text = "จำนวน: " + dtg_vendorTruck.RowCount.ToString() + " ข้อมูล";

                dtg_vendorTruck.Columns[0].Width = 100;
                dtg_vendorTruck.Columns[1].Width = 180;
                dtg_vendorTruck.Columns[2].Width = 240;
                dtg_vendorTruck.Columns[7].Width = 100;

            }
            catch { }


        }


        private void Load_Customer_Database()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                dtg_customerTruck.DataSource = null;

                string sql1 = "SELECT [CustomerID] AS 'รหัส' ,[CustomerName] AS 'ชื่อ',[Address] AS 'ที่อยู่',[TambonName] AS 'ตำบล/แขวง',[AmphurName] 'อำเภอ/เขต' ,[ProvinceName] 'จังหวัด' ,[ZipCode] AS 'ไปรษณีย์' ,[Phone] AS 'เบอร์โทร'  FROM  [dbo].[V_Customer]  Where CustomerID <> '01' ORDER BY [CustomerID]";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_customer");
                dtg_customerTruck.DataSource = ds1.Tables["g_customer"];
                con.Close();

                dtg_customerTruck.Columns[0].Width = 120;
                dtg_customerTruck.Columns[1].Width = 180;
                dtg_customerTruck.Columns[2].Width = 240;

                items_CountDB = dtg_customerTruck.RowCount;
                lbl_countDBTruck_Customer.Text = "จำนวน: " + dtg_customerTruck.RowCount.ToString() + " ข้อมูล";

                if (dtg_customerNAV.RowCount != dtg_customerTruck.RowCount)
                {
                    btn_updateDataCusmer.Enabled = true;
                }

                else { btn_updateDataCusmer.Enabled = false; }

            }
            catch { }


        }

        private void Load_Service()
        {

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql1 = "SELECT [ServiceID] AS 'รหัส',[ServiceName] AS 'ชื่อการบริการ',[ProductName] AS 'ชื่อสินค้า',[TruckTypeName] AS 'ประเภทรถ',[WeightPrice] AS 'ค่าชั่งสินค้า',[LoadPrice] AS 'ค่าลงสินค้า',[IncludeVat] AS 'แยก/รวมภาษี',[VatUnit] AS 'ภาษีมูลค่าเพิ่ม',[ServiceStatus] AS 'มี/ไม่มีค่าบริการ',[Remark] AS 'คำอธิบาย',[TruckTypeID]  FROM  [dbo].[V_Service]";

            SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "g_service");
            dtg_service.DataSource = ds1.Tables["g_service"];
            con.Close();

            dtg_service.Columns[0].Width = 80;
            dtg_service.Columns[1].Width = 200;
            dtg_service.Columns[3].Width = 100;
            dtg_service.Columns[4].Width = 100;
            dtg_service.Columns[5].Width = 100;
            dtg_service.Columns[6].Width = 120;
            dtg_service.Columns[7].Width = 120;
            dtg_service.Columns[8].Width = 120;
            dtg_service.Columns[10].Width = 0;

        }

        private void Load_Bank()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                //Product 
                SqlCommand cmd = new SqlCommand("Select [Bank_Code],[Bank_Name]  From [dbo].[TB_Bank] ", con);
                DataSet ds = new DataSet();
                //ds.Clear();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);

                //Load product tab weight scale Setup
                cb_bank.DataSource = ds.Tables[0];
                cb_bank.DisplayMember = "Bank_Name";
                cb_bank.ValueMember = "Bank_Code";

                cb_bank.DataSource = ds.Tables[0];
                cb_bank.DisplayMember = "Bank_Name";
                cb_bank.ValueMember = "Bank_Code";


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

        private void Load_Product_NAV()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb14_NAV);
                con.ConnectionString = Program.pathdb14_NAV;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                dtg_productNAV.DataSource = null;

                string sql1 = "SELECT [No_],[Description] FROM [Sapthip_LIVE].[dbo].[Sapthip LIVE$Item] WHERE [Item Category Code] like '%IRM%' AND  [No_] <>'RM-013'  OR [No_]= 'FG-001' ORDER BY [No_] ";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_product");
                dtg_productNAV.DataSource = ds1.Tables["g_product"];
                con.Close();

                dtg_productNAV.Columns[0].Width = 120;
                items_CountNAV = dtg_productNAV.RowCount;
                lbl_countDBNAV_Product.Text = "จำนวน: " + dtg_productNAV.RowCount.ToString() + " ข้อมูล";
            }
            catch { }


        }


        private void btn_checkDataProduct_Click(object sender, EventArgs e)
        {
            gb_productNAV.Visible = true;

            Load_Product_NAV();
            int item_NotDup = 0;

            if (items_CountDB != items_CountNAV)
            {
                for (int A = 0; A < dtg_productNAV.RowCount; A++)
                {
                    for (int B = 0; B < dtg_productTruck.RowCount; B++)
                    {
                        if (dtg_productNAV.Rows[A].Cells[0].Value.ToString().Trim() != dtg_productTruck.Rows[B].Cells[0].Value.ToString().ToString())
                        {
                            dtg_productNAV.Rows[A].DefaultCellStyle.ForeColor = Color.Red;
                        }
                        else
                        {

                            dtg_productNAV.Rows[A].DefaultCellStyle.ForeColor = Color.Green;
                            item_NotDup++;
                            B = dtg_productTruck.RowCount;
                        }

                    }
                }

            }

            else
            {
                lbl_MSGdataUpdate_Product.Text = "จำนวนข้อมูลตรงกับระบบนวิวชั่น";
                lbl_MSGdataUpdate_Product.ForeColor = Color.Green;
            }

            if ((items_CountNAV - item_NotDup) != 0)
            {
                lbl_MSGdataUpdate_Product.Text = "ข้อมูลตรง: " + item_NotDup.ToString() + " ปรับปรุง: " + Convert.ToString(items_CountNAV - item_NotDup) + " ข้อมูล";
                lbl_MSGdataUpdate_Product.ForeColor = Color.Red;
                btn_updateDataProduct.Enabled = true;
            }
            else
            {
                lbl_MSGdataUpdate_Product.Text = "มีข้อมูลที่ตรงจำนวน: " + item_NotDup.ToString() + " ข้อมูล";
                lbl_MSGdataUpdate_Product.ForeColor = Color.Green;
                btn_updateDataProduct.Enabled = false;
            }
        }

        private void btn_updateDataProduct_Click(object sender, EventArgs e)
        {
            DialogResult answer;
            answer = MessageBox.Show("คุณต้องการปรับปรุงข้อมูลสินค้าใช่หรือไม่", "ยืนยันการปรับปรุงข้อมูลสินค้า!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (answer == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                //con.Open();


                for (int A = 0; A < dtg_productNAV.RowCount; A++)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    if (dtg_productNAV.Rows[A].DefaultCellStyle.ForeColor == Color.Red)
                    {


                        con.Open();
                        string sql1 = "Insert Into  [dbo].[TB_Products] ([ProductID],[ProductName]) Values('" + dtg_productNAV.Rows[A].Cells[0].Value.ToString().Trim() + "', '" + dtg_productNAV.Rows[A].Cells[1].Value.ToString().Trim() + "')";
                        SqlCommand CM1 = new SqlCommand(sql1, con);
                        SqlDataReader DR1 = CM1.ExecuteReader();
                        con.Close();

                        Msg = "Insert to New Products!";
                        Log_NewValue = "ProductID = " + dtg_productNAV.Rows[A].Cells[0].Value.ToString().Trim() +
                                "," + "ProductName = " + dtg_productNAV.Rows[A].Cells[1].Value.ToString().Trim();
                        Log_OldValue = "-";
                    }

                    else
                    {
                        con.Open();
                        string sql1 = "Update  [dbo].[TB_Products] Set [ProductName]= '" + dtg_productNAV.Rows[A].Cells[1].Value.ToString().Trim() + "' WHERE [ProductID]='" + dtg_productNAV.Rows[A].Cells[0].Value.ToString().Trim() + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, con);
                        SqlDataReader DR1 = CM1.ExecuteReader();
                        con.Close();

                        Msg = "Update to Products!";
                        Log_OldValue = "ProductName = " + dtg_productNAV.Rows[A].Cells[1].Value.ToString().Trim() +
                                "," + "Where ProductID = " + dtg_productNAV.Rows[A].Cells[0].Value.ToString().Trim();
                        Log_NewValue = "-";
                    }

                }

                MessageBox.Show("ปรับปรุงข้อมูลสำเร็จ", "รายงานการปรับปรุงข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Class_Log CL = new Class_Log();
                CL.tbname = "Update to Record in Product Card Online!";
                CL.oldvalue = Log_OldValue;
                CL.newvalue = Log_NewValue;
                CL.Save_log();

                Load_Product_Database();
            }
        }

        private void chk_newProduct_CheckedChanged(object sender, EventArgs e)
        {

            if (chk_newProduct.Checked == true)
            {
                txt_productName.Enabled = true;
                txt_productID.Enabled = true;
                txt_productName.Clear();
                txt_productID.Clear();
                txt_productID.Focus();
            }
            else
            {
                txt_productName.Enabled = false;
                txt_productID.Enabled = false;
            }
        }

        private void btn_saveProduct_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            if (chk_newProduct.Checked == true) //new
            {
                try
                {
                    con.Open();
                    string sql = "Insert Into  [dbo].[TB_Products] ([ProductID],[ProductName]) Values('" + txt_productID.Text.ToString() + "', '" + txt_productName.Text.Trim() + "')";
                    SqlCommand CM2 = new SqlCommand(sql, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    con.Close();

                    MessageBox.Show("เพิ่มข้อมูลสำเร็จ!", "การเพิ่มข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Msg = "Insert New Record in Product Card!";
                    Log_NewValue = "ProductID = " + txt_productID.Text.Trim() +
                            "," + "ProductName = " + txt_productName.Text.ToString();

                    Log_OldValue = "-";

                    Class_Log CL = new Class_Log();
                    CL.tbname = Msg;
                    CL.oldvalue = Log_OldValue;
                    CL.newvalue = Log_NewValue;
                    CL.Save_log();

                    txt_productID.Clear();
                    txt_productName.Clear();
                    Load_Product_Database();

                }
                catch
                {
                    MessageBox.Show("รหัสสินค้าซ้ำ กรุณาตรวจสอบรหัส!", "การเพิ่มข้อมูลผิพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            Load_Product_Database();
        }

        private void dtg_productTruck_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            //update
            int StatusActive = 0;
            if (dtg_productTruck.Rows[e.RowIndex].Cells[3].Value.ToString() == "True")
            { StatusActive = 1; }

            try
            {
                con.Open();
                string sql1 = "Update  [dbo].[TB_Products] Set [ProductName]= '" + dtg_productTruck.Rows[e.RowIndex].Cells[1].Value.ToString() + "',[Price] =" + dtg_productTruck.Rows[e.RowIndex].Cells[2].Value.ToString() + ",[StatusActive] =" + StatusActive + ",[HeaderBill_NameCode]='" + dtg_productTruck.Rows[e.RowIndex].Cells[4].Value.ToString() + "',[HeaderBill_NameCodeCus]='" + dtg_productTruck.Rows[e.RowIndex].Cells[5].Value.ToString() + "'  WHERE [ProductID]='" + dtg_productTruck.Rows[e.RowIndex].Cells[0].Value.ToString().Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                con.Close();
                Load_Product_Database();
            }
            catch { }
        }

        private void Load_Product_Database()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                dtg_productTruck.DataSource = null;

                string sql1 = "SELECT [ProductID] AS 'รหัสสินค้า',[ProductName] AS 'ชื่อสินค้า',[Price] AS 'ราคา',[StatusActive] AS 'สถานะใช้งาน',[HeaderBill_NameCode] AS 'หัวบิลซื้อ',[HeaderBill_NameCodeCus] AS 'หัวบิลขาย'  FROM  [dbo].[TB_Products] ORDER BY [ProductID]";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_product");
                dtg_productTruck.DataSource = ds1.Tables["g_product"];
                con.Close();

                dtg_productTruck.Columns[0].Width = 120;
                items_CountDB = dtg_productTruck.RowCount;
                lbl_countDBTruck_Product.Text = "จำนวน: " + dtg_productTruck.RowCount.ToString() + " ข้อมูล";
            }
            catch { }
        }

        private void btn_saveCus_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            if (chk_newCus.Checked == true)
            {
                try
                {
                    con.Open();
                    string sql = "Insert Into  [dbo].[TB_Customers] ([CustomerID],[CustomerName],[TombonId]) Values('" + txt_cusID.Text.Trim() + "', '" + txt_cusName.Text.Trim() + "',1)";

                    SqlCommand CM2 = new SqlCommand(sql, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    con.Close();

                    MessageBox.Show("เพิ่มข้อมูลสำเร็จ!", "การเพิ่มข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Msg = "Insert New Record in Customer Card!";
                    Log_NewValue = "CustomerID = " + txt_cusID.Text.Trim() +
                        "," + "CustomerName = " + txt_cusName.Text.ToString();
                    Log_OldValue = "-";

                    txt_cusID.Clear();
                    txt_cusName.Clear();
                    Load_Customer_Database();
                }

                catch
                {
                    MessageBox.Show("รหัสผู้ซื้อซ้ำ กรุณาตรวจสอบรหัส!", "การเพิ่มข้อมูลผิพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //update
            else
            {
                con.Open();
                string sql1 = "Update  [dbo].[TB_Customers] Set [CustomerName]= '" + txt_searchCus.Text.Trim() + "' WHERE [CustomerID]='" + id_update + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                con.Close();

                MessageBox.Show("ปรับปรุงข้อมูลสำเร็จ!", "การแก้ไขข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Msg = "Update to Record in Customer Card!";
                Log_OldValue = "CustomerName = " + txt_searchCus.Text.Trim() +
                     "," + "WHERE CustomerID = " + id_update.ToString();
                Log_NewValue = "-";

                txt_searchCus.Clear();
                Load_Customer_Database();
            }

            Class_Log CL = new Class_Log();
            CL.tbname = Msg;
            CL.oldvalue = Log_OldValue;
            CL.newvalue = Log_NewValue;
            CL.Save_log();

        }

        private void Load_Customer_NAV()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(Program.pathdb14_NAV);
                con1.ConnectionString = Program.pathdb14_NAV;
                SqlDataAdapter dtAdapter1 = new SqlDataAdapter();

                SqlConnection con2 = new SqlConnection(Program.pathdb_Weight);
                con2.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter2 = new SqlDataAdapter();

                dtg_customerNAV.DataSource = null;

                con1.Open();
                string sql1 = "SELECT [No_] ,[Name],[Address],[Address 2],[City],[County] ,[Post Code] ,[Contact],[Phone No_],'' AS 'TambonID' FROM [Sapthip_LIVE].[dbo].[Sapthip LIVE$Customer] where No_ like 'AR01%' OR No_ like 'AR02%' ORDER BY [No_] ";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_customer");
                dtg_customerNAV.DataSource = ds1.Tables["g_customer"];
                con1.Close();

                dtg_customerNAV.Columns[0].Width = 20;
                this.dtg_customerNAV.Columns[2].Visible = false;
                this.dtg_customerNAV.Columns[3].Visible = false;
                this.dtg_customerNAV.Columns[4].Visible = false;
                this.dtg_customerNAV.Columns[5].Visible = false;
                this.dtg_customerNAV.Columns[6].Visible = false;
                this.dtg_customerNAV.Columns[7].Visible = false;
                this.dtg_customerNAV.Columns[8].Visible = false;
                this.dtg_customerNAV.Columns[9].Visible = false;
                                           
                lbl_countDBNAV_Customer.Text = "จำนวน: " + dtg_customerNAV.RowCount.ToString() + " ข้อมูล";               

            }
            catch { }


        }


        private void btn_checkDataCustomer_Click(object sender, EventArgs e)
        {
            gb_customerNAV.Visible = true;

            Load_Customer_NAV();

            int item_NotDup = 0;

            if (items_CountDB != items_CountNAV)
            {
                for (int A = 0; A < dtg_customerNAV.RowCount; A++)
                {
                    for (int B = 0; B < dtg_customerTruck.RowCount; B++)
                    {

                        if (dtg_customerNAV.Rows[A].Cells[0].Value.ToString().Trim() != dtg_customerTruck.Rows[B].Cells[0].Value.ToString().ToString())
                        {
                            dtg_customerNAV.Rows[A].DefaultCellStyle.ForeColor = Color.Red;
                        }
                        else
                        {

                            dtg_customerNAV.Rows[A].DefaultCellStyle.ForeColor = Color.Green;
                            item_NotDup++;
                            B = dtg_customerTruck.RowCount;
                        }

                    }
                }

            }


            items_CountNAV = dtg_customerNAV.RowCount;
            item_NotDup = dtg_customerTruck.RowCount;

            if ((items_CountNAV - item_NotDup) != 0)
            {
                lbl_MSGdataUpdate_Customer.Text = "ข้อมูลตรง: " + item_NotDup.ToString() + " ปรับปรุง: " + Convert.ToString(items_CountNAV - item_NotDup) + " ข้อมูล";
                lbl_MSGdataUpdate_Customer.ForeColor = Color.Red;
                lbl_MSGdataUpdate_Customer.Enabled = true;
                btn_updateDataCusmer.Enabled = true;
            }
            else
            {
                lbl_MSGdataUpdate_Customer.Text = "มีข้อมูลที่ตรงจำนวน: " + item_NotDup.ToString() + " ข้อมูล";
                lbl_MSGdataUpdate_Customer.ForeColor = Color.Green;
                btn_updateDataCusmer.Enabled = false;
            }

            gb_customerNAV.Visible = true;
        }

        private void btn_updateDataCusmer_Click(object sender, EventArgs e)
        {
            DialogResult answer;
            answer = MessageBox.Show("คุณต้องการปรับปรุงข้อมูลผู้ขายใช่หรือไม่", "ยืนยันการปรับปรุงข้อมูลลูกค้า!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (answer == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                //con.Open();
                int TambonID = 1;

                for (int A = 0; A < dtg_customerNAV.RowCount; A++)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    if (dtg_customerNAV.Rows[A].Cells[9].Value.ToString().Trim() != "")
                    {
                        TambonID = Convert.ToInt32(dtg_customerNAV.Rows[A].Cells[9].Value.ToString().Trim());
                    }

                    if (dtg_customerNAV.Rows[A].DefaultCellStyle.ForeColor == Color.Red)
                    {


                        con.Open();
                        string sql1 = "Insert Into  [dbo].[TB_Customers] ([CustomerID],[CustomerName],[Address],[Phone],[TombonId]) Values('" + dtg_customerNAV.Rows[A].Cells[0].Value.ToString().Trim() + "', '" + dtg_customerNAV.Rows[A].Cells[1].Value.ToString().Trim() + "','" + dtg_customerNAV.Rows[A].Cells[2].Value.ToString().Trim() + "','" + dtg_customerNAV.Rows[A].Cells[8].Value.ToString().Trim() + "'," + TambonID + ")";
                        SqlCommand CM1 = new SqlCommand(sql1, con);
                        SqlDataReader DR1 = CM1.ExecuteReader();
                        con.Close();

                        Msg = "Insert to New Customer!";
                        Log_NewValue = "CustomerID = " + dtg_customerNAV.Rows[A].Cells[0].Value.ToString().Trim() +
                            "," + "CustomerName = " + dtg_customerNAV.Rows[A].Cells[1].Value.ToString().Trim() +
                            "," + "Address = " + dtg_customerNAV.Rows[A].Cells[2].Value.ToString().Trim() +
                            "," + "Phone = " + dtg_customerNAV.Rows[A].Cells[8].Value.ToString().Trim() +
                            "," + "TombonId = " + TambonID.ToString();
                        Log_OldValue = "-";
                    }

                    else
                    {
                        con.Open();
                        string sql1 = "Update  [dbo].[TB_Customers] Set [CustomerName]= '" + dtg_customerNAV.Rows[A].Cells[1].Value.ToString().Trim() + "',[Address]= '" + dtg_customerNAV.Rows[A].Cells[2].Value.ToString().Trim() + "',[Phone]= '" + dtg_customerNAV.Rows[A].Cells[8].Value.ToString().Trim() + "',[TombonId]= " + TambonID + " WHERE [CustomerID]='" + dtg_customerNAV.Rows[A].Cells[0].Value.ToString().Trim() + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, con);
                        SqlDataReader DR1 = CM1.ExecuteReader();
                        con.Close();

                        Msg = "Update to Customer!";
                        Log_OldValue = "CustomerName = " + dtg_customerNAV.Rows[A].Cells[1].Value.ToString().Trim() +
                          "," + "Address = " + dtg_customerNAV.Rows[A].Cells[2].Value.ToString().Trim() +
                          "," + "Phone = " + dtg_customerNAV.Rows[A].Cells[8].Value.ToString().Trim() +
                          "," + "TombonId = " + TambonID.ToString() +
                          "," + "Where CustomerID= " + dtg_customerNAV.Rows[A].Cells[0].Value.ToString().Trim();

                        Log_NewValue = "-";

                    }

                }

                MessageBox.Show("ปรับปรุงข้อมูลสำเร็จ", "รายงานการปรับปรุงข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Class_Log CL = new Class_Log();
                CL.tbname = "Update to Data in Customer Card Online!";
                CL.oldvalue = Log_OldValue;
                CL.newvalue = Log_NewValue;
                CL.Save_log();

                Load_Customer_Database();

                lbl_MSGdataUpdate_Customer.Text = "มีข้อมูลที่ตรงจำนวน: " + dtg_customerTruck.RowCount.ToString() + " ข้อมูล";
                lbl_MSGdataUpdate_Customer.ForeColor = Color.Green;

            }
        }

        private void btn_cusSearchClear_Click(object sender, EventArgs e)
        {
            txt_searchCus.Clear();
        }

        private void chk_newCus_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_newCus.Checked == true)
            {
                txt_cusName.Clear();
                txt_cusID.Clear();
                txt_cusID.Focus();
                pn_newCus.Width = 485;
                txt_searchCus.Enabled = false;
                txt_searchCus.Clear();
            }
            else { pn_newCus.Width = 95; txt_searchCus.Enabled = true; }
        }

        private void dtg_customerTruck_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                id_update = dtg_customerTruck.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_searchCus.Text = dtg_customerTruck.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch { }
        }

        private void Load_Vendor_NAV()
        {
            //try
            //{
            SqlConnection con1 = new SqlConnection(Program.pathdb14_NAV);
            con1.ConnectionString = Program.pathdb14_NAV;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            SqlConnection con2 = new SqlConnection(Program.pathdb_Weight);
            con2.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter2 = new SqlDataAdapter();

            dtg_vendorNAV.DataSource = null;
            con1.Open();
            string sql1 = "SELECT [No_],[Name],[Address] ,[TamBon],[AmPhur],[Province] ,[Post_Code],[Mobile No_],'' AS [TombonId]  FROM [Sapthip_LIVE].[dbo].[Sapthip LIVE$Vendor]  WHERE [No_] <> 'AP01-0001' AND [No_] <> 'AP01-0002' AND [No_] like 'AP01%' OR [No_] like 'AP02%' ORDER BY [No_] Desc ";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "g_vendor");
            dtg_vendorNAV.DataSource = ds1.Tables["g_vendor"];
            con1.Close();

            dtg_vendorNAV.Columns[0].Width = 20;

            this.dtg_vendorNAV.Columns[2].Visible = false;
            this.dtg_vendorNAV.Columns[3].Visible = false;
            this.dtg_vendorNAV.Columns[4].Visible = false;
            this.dtg_vendorNAV.Columns[5].Visible = false;
            this.dtg_vendorNAV.Columns[6].Visible = false;
            this.dtg_vendorNAV.Columns[7].Visible = false;
            //this.dtg_vendorNAV.Columns[8].Visible = false;
            dtg_vendorNAV.Columns[8].Width = 0;

            // search word and split            //

            //catch { }
            lbl_countDBNAV_vendor.Text = "จำนวน: " + dtg_vendorNAV.RowCount.ToString() + " ข้อมูล";

        }

        private void btn_checkDataVendor_Click(object sender, EventArgs e)
        {
            gb_vendorNAV.Visible = true;

            Load_Vendor_NAV();

            int item_NotDup = 0;

            if (items_CountDB != items_CountNAV)
            {
                for (int A = 0; A < dtg_vendorNAV.RowCount; A++)
                {
                    for (int B = 0; B < dtg_vendorTruck.RowCount; B++)
                    {
                        //if (dtg_vendorNAV.Rows[A].Cells[0].Value.ToString().Trim() == "AP01-1848" )
                        //{
                        //    if (dtg_vendorTruck.Rows[B].Cells[0].Value.ToString().ToString().Trim() == "AP01-1848")
                        //    {
                        //        string xx = "";
                        //    }
                        //}

                        if (dtg_vendorNAV.Rows[A].Cells[0].Value.ToString().Trim() != dtg_vendorTruck.Rows[B].Cells[0].Value.ToString().ToString().Trim())
                        {
                            dtg_vendorNAV.Rows[A].DefaultCellStyle.ForeColor = Color.Red;
                        }
                        else
                        {

                            dtg_vendorNAV.Rows[A].DefaultCellStyle.ForeColor = Color.Green;
                            item_NotDup++;
                            B = dtg_vendorTruck.RowCount;
                        }

                    }
                }

            }


            items_CountNAV = dtg_vendorNAV.RowCount;
            item_NotDup = dtg_vendorTruck.RowCount;

            if ((items_CountNAV - item_NotDup) != 0)
            {
                lbl_MSGdataUpdate_Vendor.Text = "ข้อมูลตรง: " + item_NotDup.ToString() + " ปรับปรุง: " + Convert.ToString(items_CountNAV - item_NotDup) + " ข้อมูล";
                lbl_MSGdataUpdate_Vendor.ForeColor = Color.Red;
                btn_updateDataVendor.Enabled = true;

            }
            else
            {
                lbl_MSGdataUpdate_Vendor.Text = "มีข้อมูลที่ตรงจำนวน: " + item_NotDup.ToString() + " ข้อมูล";
                lbl_MSGdataUpdate_Vendor.ForeColor = Color.Green;
            }
        }

        private void btn_updateDataVendor_Click(object sender, EventArgs e)
        {
            DialogResult answer;
            answer = MessageBox.Show("คุณต้องการปรับปรุงข้อมูลผู้ขายใช่หรือไม่", "ยืนยันการปรับปรุงข้อมูลผู้ขาย!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (answer == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                //con.Open();


                for (int A = 0; A < dtg_vendorNAV.RowCount; A++)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }


                    if (dtg_vendorNAV.Rows[A].DefaultCellStyle.ForeColor == Color.Red)
                    {

                        string text1 = dtg_vendorNAV.Rows[A].Cells[3].Value.ToString().Trim() + "xx";
                        string text2 = text1;
                        string data1 = getBetween(text2, "ต.", "xx");
                        dtg_vendorNAV.Rows[A].Cells[4].Value = data1;

                        int TombonId = 0;


                        if (dtg_vendorNAV.Rows[A].Cells[4].Value.ToString() == "")
                        {
                            string text3 = dtg_vendorNAV.Rows[A].Cells[3].Value.ToString().Trim() + "xx";
                            string text4 = text1;
                            string data2 = getBetween(text2, "แขวง", "xx");
                            dtg_vendorNAV.Rows[A].Cells[4].Value = data2;
                        }

                        try
                        {
                            con.Open();
                            string sql2 = "SELECT [TombonId] FROM  [dbo].[TamBon]  Where [TambonName] like '%" + dtg_vendorNAV.Rows[A].Cells[4].Value.ToString().Trim() + "%'";

                            SqlCommand CM2 = new SqlCommand(sql2, con);
                            SqlDataReader DR2 = CM2.ExecuteReader();

                            DR2.Read();
                            {
                                TombonId = Convert.ToInt32(DR2["TombonId"].ToString());
                            }
                            DR2.Close();
                            con.Close();


                        }
                        catch
                        { con.Close(); }

                        dtg_vendorNAV.Rows[A].Cells[8].Value = TombonId.ToString();

                        con.Open();
                        string sql1 = "Insert Into  [dbo].[Vendor] ([Vendor_No],[Names],[TombonId]) Values('" + dtg_vendorNAV.Rows[A].Cells[0].Value.ToString().Trim() + "', '" + dtg_vendorNAV.Rows[A].Cells[1].Value.ToString().Trim() + "','" + TombonId + "')";
                        SqlCommand CM1 = new SqlCommand(sql1, con);
                        SqlDataReader DR1 = CM1.ExecuteReader();
                        con.Close();

                        Msg = "Insert to New Vendor!";
                        Log_NewValue = "Vendor_No = " + dtg_vendorNAV.Rows[A].Cells[0].Value.ToString().Trim() +
                                "," + "Names = " + dtg_vendorNAV.Rows[A].Cells[1].Value.ToString().Trim() +
                                "," + "TombonId = " + TombonId.ToString();
                        Log_OldValue = "-";

                    }

                    else
                    {
                        con.Open();
                        string sql1 = "Update  [dbo].[Vendor] Set [Names]= '" + dtg_vendorNAV.Rows[A].Cells[1].Value.ToString().Trim() + "' WHERE [Vendor_No]='" + dtg_vendorNAV.Rows[A].Cells[0].Value.ToString().Trim() + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, con);
                        SqlDataReader DR1 = CM1.ExecuteReader();
                        con.Close();

                        Msg = "Update to TB_Products!";
                        Log_OldValue = "Names = " + dtg_vendorNAV.Rows[A].Cells[1].Value.ToString().Trim() +
                                "," + "Where Vendor_No = " + dtg_vendorNAV.Rows[A].Cells[0].Value.ToString().Trim();
                        Log_NewValue = "-";

                    }

                }

                MessageBox.Show("ปรับปรุงข้อมูลสำเร็จ", "รายงานการปรับปรุงข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Class_Log CL = new Class_Log();
                CL.tbname = "Update to Record in Vendor Card Online!";
                CL.oldvalue = Log_OldValue;
                CL.newvalue = Log_NewValue;
                CL.Save_log();



                Load_Vendor_Database();


            }
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            const int kNotFound = -1;

            var startIdx = strSource.IndexOf(strStart);
            if (startIdx != kNotFound)
            {
                startIdx += strStart.Length;
                var endIdx = strSource.IndexOf(strEnd, startIdx);
                if (endIdx > startIdx)
                {
                    return strSource.Substring(startIdx, endIdx - startIdx);
                }
            }
            return String.Empty;
        }

        private void btn_vendorSearchClear_Click(object sender, EventArgs e)
        {
            txt_searchVendor.Clear();
        }

        private void chk_newVendor_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_newVendor.Checked == true)
            {
                txt_vendorName.Clear();
                txt_vendorID.Clear();
                txt_vendorID.Focus();
                pn_newVendor.Width = 485;
                txt_searchVendor.Enabled = false;
                txt_searchVendor.Clear();
            }
            else { pn_newVendor.Width = 95; txt_searchVendor.Enabled = true; }
        }

        private void btn_saveVendor_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            if (chk_newVendor.Checked == true) //insert
            {
                try
                {

                    con.Open();
                    string sql = "Insert Into  [dbo].[Vendor] ([Vendor_No],[Names],[TombonId]) Values('" + txt_vendorID.Text.Trim() + "', '" + txt_vendorName.Text.Trim() + "', 1 )";

                    SqlCommand CM2 = new SqlCommand(sql, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    con.Close();

                    MessageBox.Show("เพิ่มข้อมูลสำเร็จ!", "การเพิ่มข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Msg = "Insert New Record in Vendor Card!";
                    Log_NewValue = "Vendor_No = " + txt_vendorID.Text.Trim() +
                            "," + "Names = " + txt_vendorName.Text.Trim() +
                            "," + "TombonId = 1";
                    Log_OldValue = "-";

                    txt_vendorID.Clear();
                    txt_vendorName.Clear();
                    Load_Vendor_Database();
                }
                catch { MessageBox.Show("รหัสผู้ขายซ้ำ กรุณาตรวจสอบรหัส!", "การเพิ่มข้อมูลผิพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error); }


            }

            //update
            else
            {
                con.Open();
                string sql1 = "Update  [dbo].[Vendor] Set [Names]= '" + txt_searchVendor.Text.Trim() + "' WHERE [Vendor_No]='" + id_update + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                con.Close();

                MessageBox.Show("ปรับปรุงข้อมูลสำเร็จ!", "การแก้ไขข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Msg = "Update to Record in Vendor Card!";
                Log_OldValue = "Names = " + txt_searchVendor.Text.Trim() +
                        "," + "WHERE Vendor_No = " + id_update.ToString();
                Log_NewValue = "-";

                txt_searchVendor.Clear();
                Load_Vendor_Database();
            }

            Class_Log CL = new Class_Log();
            CL.tbname = Msg;
            CL.oldvalue = Log_OldValue;
            CL.newvalue = Log_NewValue;
            CL.Save_log();
        }

        private void btn_venderDetail_Click(object sender, EventArgs e)
        {
            F_VendorDetail VDD = new F_VendorDetail();
            VDD.ShowDialog();
        }

        private void dtg_vendorTruck_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                id_update = dtg_vendorTruck.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_searchVendor.Text = dtg_vendorTruck.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch { }
        }

        private void cb_truckTypeService_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_productDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_WeightScaleSetting();
        }

        private void cb_productService_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_search = 0;
            LoadMapping_Databank();
        }

        private void rdo_registerForm1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dtg_scaleDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10 || e.ColumnIndex == 11)
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

                int Sts = 0;
                string sql = "";

                if (e.ColumnIndex == 10)
                {
                    if (dtg_scaleDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "True")
                    {
                        Sts = 1;
                    }

                    sql = "Update [dbo].[TB_Scale] Set [EditWeight_In]= " + Sts + " WHERE [ScaleCode]=" + dtg_scaleDetail.Rows[e.RowIndex].Cells[0].Value.ToString() + "";
                }

                if (e.ColumnIndex == 11)
                {
                    if (dtg_scaleDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "True")
                    {
                        Sts = 1;
                    }

                    sql = "Update [dbo].[TB_Scale] Set [EditWeight_Out]= " + Sts + " WHERE [ScaleCode]=" + dtg_scaleDetail.Rows[e.RowIndex].Cells[0].Value.ToString() + "";
                }


                con.Open();

                SqlCommand CM1 = new SqlCommand(sql, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                con.Close();
            }
        }

        private void cbo_useconfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_useconfig.Text != "System.Data.DataRowView" && tab_menu.SelectedIndex ==2)
            {
                //Load_FileDLL();

                //SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                //con.ConnectionString = Program.pathdb_Weight;
                //SqlDataAdapter dtAdapter = new SqlDataAdapter();
                //con.Open();

                //string sql6 = "SELECT [Remark],[EditWeight_In],[EditWeight_Out]  FROM  [dbo].[TB_Scale] Where [ScaleFormat] ='" + cbo_useconfig.Text + "'";
                //SqlCommand CM6 = new SqlCommand(sql6, con);
                //SqlDataReader DR6 = CM6.ExecuteReader();

                //DR6.Read();
                //{
                //    label12.Text = "คำอธิบาย: " + DR6["Remark"].ToString().Trim();

                //    if (DR6["EditWeight_In"].ToString().Trim() == "True")
                //    {
                //        chk_alltruckIn.Checked = true;
                //    }
                //    else { chk_alltruckIn.Checked = false; }

                //    if (DR6["EditWeight_Out"].ToString().Trim() == "True")
                //    {
                //        chk_alltruckOut.Checked = true;
                //    }
                //    else { chk_alltruckOut.Checked = false; }
                //}
                //DR6.Close();
                //con.Close();

                value_line4 = cbo_useconfig.Text.Trim();     
                Save_FileDLL();

            }
        }

        private void Save_FileDLL()
        {
            //try
            //{
         
                
                string path = Application.StartupPath + "\\config.dll";

            //if (System.IO.File.Exists(path))
            //{
            //    System.IO.StreamReader StrRer = new System.IO.StreamReader(path);

            //    List<string> listStr = new List<string>();

            //    while (!StrRer.EndOfStream)
            //    {
            //        listStr.Add(StrRer.ReadLine());
            //    }

            //    value_line1 = listStr[0].ToString().Trim();
            //    value_line2 = listStr[1].ToString().Trim();
            //    value_line3 = listStr[2].ToString().Trim();
            //    value_line4 = listStr[3].ToString().Trim();
            //    value_line5 = listStr[4].ToString().Trim();
            //    value_line6 = listStr[5].ToString().Trim();
            //    StrRer.Close();
            //    StrRer.ReadToEnd();
            //}

            //    value_line4 = cbo_useconfig.Text.Trim();
            //    value_line6 = txt_noExamTicket.Text.Trim();


            string[] lines = { value_line1, value_line2, value_line3, value_line4, value_line5, value_line6 };
            File.WriteAllLines(path, lines);


            //}
            //catch { }
        }

        private void chk_newInterface_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_newInterface.Checked == true)
            {
                txt_scalefileDll.ReadOnly = false;
                txt_scaleNo.ReadOnly = false;
            }

           else
            {
                txt_scalefileDll.ReadOnly = true;
                txt_scaleNo.ReadOnly = true;
            }
        }

        private void dtg_printAT_data_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {                            
                PrintAT_No =Convert.ToInt16(dtg_printAT_dataSale.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                txt_printAT_Createdate.Text = dtg_printAT_dataSale.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                txt_printAT_barcode.Text = dtg_printAT_dataSale.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                txt_printAT_plate1.Text = dtg_printAT_dataSale.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                id_ZoneAuto = dtg_printAT_dataSale.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                txt_printAT_nameLocation.Text= dtg_printAT_dataSale.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
                id_CustomerAuto = dtg_printAT_dataSale.Rows[e.RowIndex].Cells[6].Value.ToString().Trim();
                txt_printAT_nameCustomer.Text = dtg_printAT_dataSale.Rows[e.RowIndex].Cells[7].Value.ToString().Trim();
                txt_printAT_barcodeExam.Text = "*" + txt_printAT_barcode.Text.Trim() + "*";
                id_ProductAuto= dtg_printAT_dataSale.Rows[e.RowIndex].Cells[8].Value.ToString().Trim();
                txt_printAT_nameProduct.Text = dtg_printAT_dataSale.Rows[e.RowIndex].Cells[9].Value.ToString().Trim();

                if (dtg_printAT_dataSale.Rows[e.RowIndex].Cells[10].Value.ToString().Trim() == "True")
                {
                    chk__printAT_statusActive.Checked = true;
                }
                else { chk__printAT_statusActive.Checked = false; }

            }
        }

        private void label85_Click(object sender, EventArgs e)
        {

        }

        private void chh_newAuto_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void cb_typeAuto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_typeAuto.SelectedIndex == 0)
            {
                tcb_auto.SelectedIndex = 0;
                lbl_name.Text = "ชื่อผู้ขายสินค้า:";
                Load_DataPrintAutoPur();
            }
            if (cb_typeAuto.SelectedIndex == 1)
            {
                tcb_auto.SelectedIndex = 1;
                lbl_name.Text = "ชื่อผู้ซื้อสินค้า:";
                Load_DataPrintAutoSale();
            }
        }

        private void txt_printAT_barcode_TextChanged(object sender, EventArgs e)
        {
            txt_printAT_barcodeExam.Text = "*" + txt_printAT_barcode.Text.Trim() + "*";
        }

        private void dtg_printAT_dataPur_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {              
                PrintAT_No = Convert.ToInt16(dtg_printAT_dataPur.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                txt_printAT_Createdate.Text = dtg_printAT_dataPur.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                txt_printAT_barcode.Text = dtg_printAT_dataPur.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                txt_printAT_plate1.Text = dtg_printAT_dataPur.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                id_ZoneAuto = dtg_printAT_dataPur.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                txt_printAT_nameLocation.Text = dtg_printAT_dataPur.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
                id_CustomerAuto = dtg_printAT_dataPur.Rows[e.RowIndex].Cells[6].Value.ToString().Trim();
                txt_printAT_nameCustomer.Text = dtg_printAT_dataPur.Rows[e.RowIndex].Cells[7].Value.ToString().Trim();
                txt_printAT_barcodeExam.Text = "*" + txt_printAT_barcode.Text.Trim() + "*";
                id_ProductAuto = dtg_printAT_dataPur.Rows[e.RowIndex].Cells[8].Value.ToString().Trim();
                txt_printAT_nameProduct.Text = dtg_printAT_dataPur.Rows[e.RowIndex].Cells[9].Value.ToString().Trim();

                if (dtg_printAT_dataPur.Rows[e.RowIndex].Cells[10].Value.ToString().Trim() == "True")
                {
                    chk__printAT_statusActive.Checked = true;
                }
                else { chk__printAT_statusActive.Checked = false; }

            }
        }

        private void btn_saveServiceAuto_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            string sql = "Update [dbo].[TB_TruckType] Set [TruckCapacity]= " + txt_weightAutoMin.Text + " WHERE [TruckTypeID]=1 "; 
            con.Open();
            SqlCommand CM = new SqlCommand(sql, con);
            SqlDataReader DR = CM.ExecuteReader();
            con.Close();

            string sql1 = "Update [dbo].[TB_TruckType] Set [TruckCapacity]= " + txt_weightAutoMax.Text + " WHERE [TruckTypeID]=2 ";
            con.Open();
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();
            con.Close();

            MessageBox.Show("บันทึกสำเร็จ", "รายงานการบันทึก", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        

        private void txt_weightAutoMin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int weight = Convert.ToInt32(txt_weightAutoMin.Text);
                weight += 1;
                txt_weightAutoMax.Text = weight.ToString();
            }
            catch { txt_weightAutoMax.Text = "Error!"; }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();
                string sql2 = "SELECT [TruckTypeID],[TruckCapacity] FROM  [dbo].[TB_TruckType] ";

                SqlCommand CM2 = new SqlCommand(sql2, con);
                SqlDataReader DR2 = CM2.ExecuteReader();

               while (DR2.Read())
                {
                    if (DR2["TruckTypeID"].ToString() == "1")
                    {
                       txt_weightAutoMin.Text= DR2["TruckCapacity"].ToString();
                    }

                    if (DR2["TruckTypeID"].ToString() == "2")
                    {
                        txt_weightAutoMax.Text = DR2["TruckCapacity"].ToString();
                    }

                }
                DR2.Close();
                con.Close();

            }
        }

        private void tcb_auto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcb_auto.SelectedIndex == 0)
            {
                cb_typeAuto.SelectedIndex = 0;
            }
            if (tcb_auto.SelectedIndex == 1)
            {
                cb_typeAuto.SelectedIndex = 1;
            }
        }

        private void tbc_setData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbc_setData.SelectedIndex == 0)
            {
             
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql6 = "SELECT [EditWeight_In],[EditWeight_Out]  FROM  [dbo].[TB_Scale] Where [ScaleFormat] ='" + cbo_useconfig.Text + "'";
                SqlCommand CM6 = new SqlCommand(sql6, con);
                SqlDataReader DR6 = CM6.ExecuteReader();

                DR6.Read();
                {
                    if (DR6["EditWeight_In"].ToString().Trim() == "True")
                    {
                        chk_alltruckIn.Checked = true;
                    }
                    else { chk_alltruckIn.Checked = false; }

                    if (DR6["EditWeight_Out"].ToString().Trim() == "True")
                    {
                        chk_alltruckOut.Checked = true;
                    }
                    else { chk_alltruckOut.Checked = false; }
                }
                DR6.Close();
                con.Close();


                string filename = Application.StartupPath + "\\config.dll";

                //   string strPath = "Test.txt";
                if (System.IO.File.Exists(filename))
                {
                    System.IO.StreamReader StrRer = new System.IO.StreamReader(filename);

                    List<string> listStr = new List<string>();

                    while (!StrRer.EndOfStream)
                    {
                        listStr.Add(StrRer.ReadLine());
                    }

                    value_line1 = listStr[0].ToString().Trim();
                    value_line2 = listStr[1].ToString().Trim();
                    value_line3 = listStr[2].ToString().Trim();
                    value_line4 = listStr[3].ToString().Trim();
                    value_line5 = listStr[4].ToString().Trim();
                    value_line6 = listStr[5].ToString().Trim();

                    cbo_useconfig.Text = listStr[3].ToString().Trim();
                    txt_noExamTicket.Text = listStr[5].ToString().Trim();
                    StrRer.Close();
                    StrRer.Dispose();
                }
            }

            if (tbc_setData.SelectedIndex == 1)
            {
                Load_allScaleConfig();

                dtg_scaleDetail.Columns[0].Width = 70;
                dtg_scaleDetail.Columns[1].Width = 150;
                dtg_scaleDetail.Columns[2].Width = 80;
                dtg_scaleDetail.Columns[3].Width = 80;
                dtg_scaleDetail.Columns[4].Width = 80;
                dtg_scaleDetail.Columns[5].Width = 70;
                dtg_scaleDetail.Columns[6].Width = 80;
                dtg_scaleDetail.Columns[7].Width = 80;
                dtg_scaleDetail.Columns[8].Width = 80;
                dtg_scaleDetail.Columns[9].Width = 80;          
                dtg_scaleDetail.ClearSelection();

            }


        }

        private void Load_ScaleConfigName()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                //Product 
                SqlCommand cmd = new SqlCommand("Select [ScaleFormat] From  [dbo].[TB_Scale] ", con);
                DataSet ds1 = new DataSet();
                //ds.Clear();
                SqlDataAdapter da1 = new SqlDataAdapter();
                da1.SelectCommand = cmd;
                da1.Fill(ds1);
                //Load product tab weight scale Setup
                cbo_useconfig.DataSource = ds1.Tables[0];
                cbo_useconfig.DisplayMember = "ScaleFormat";
                cbo_useconfig.ValueMember = "ScaleFormat";
              
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

        private void chk_alltruckIn_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            int sts_tIn = 0;

            if (chk_alltruckIn.Checked == true)
            { sts_tIn = 1; }

            con.Open();
            string sql = "Update [TB_Scale] Set [EditWeight_In] =" + sts_tIn + " Where [ScaleFormat] = '" + cbo_useconfig.Text + "'";
            SqlCommand CM2 = new SqlCommand(sql, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();
        }

        private void chk_alltruckOut_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            int sts_tOut = 0;

            if (chk_alltruckOut.Checked == true)
            { sts_tOut = 1; }

            con.Open();
            string sql = "Update [TB_Scale] Set [EditWeight_Out] =" + sts_tOut + " Where [ScaleFormat] = '" + cbo_useconfig.Text + "'";
            SqlCommand CM2 = new SqlCommand(sql, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();
        }

        private void txt_noExamTicket_TextChanged(object sender, EventArgs e)
        {
            lbl_noticket.Text = txt_noExamTicket.Text + "YYMMDD-XXX";
            value_line6 = txt_noExamTicket.Text.Trim();
            Save_FileDLL();
        }

       
    }
}
