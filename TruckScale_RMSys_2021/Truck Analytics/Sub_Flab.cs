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
    public partial class Sub_Flab : Form
    {
        public Sub_Flab()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tb_ctl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_TypeLab();
        }

        int lab_id = 0;
        int visual_id = 0;
        int visualDetail_id = 0;
        int id_typechange = 0;
        int id_Observ = 0;

        string Msg = "";
        string Log_NewValue = "";
        string Log_OldValue = "";
        
        //private void Save_Log()
        //{
        //    string date = Program.Date_Now + ' ' + Program.Time_Now;

        //    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
        //    con.ConnectionString = Program.pathdb_Weight;
        //    SqlDataAdapter dtAdapter = new SqlDataAdapter();
        //    con.Open();

        //    string sql = "Insert Into [TB_Log] ([LogDateTime],[Username],[TableName],[OldValue],[NewValue],[MachineName],[LocalIpAddress]) Values('" + date + "', '" + Program.user_login + "', '" + Table_Name + "','" + Log_NewValue + "', '" + Log_OldValue + "', '" + Program.MachineName + "', '" + Program.LocalIpAddress + "')";
        //    SqlCommand CM2 = new SqlCommand(sql, con);
        //    SqlDataReader DR2 = CM2.ExecuteReader();
        //    con.Close();
        //}

        private void Load_Lab()
        {
            //SqlConnection CN = new SqlConnection();
            //CN.ConnectionString = "server=192.168.111.225;initial catalog=SapthipNewDB;uid=truck_scale; pwd=pass@2020;";
            //CN.Open();
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
                                 

            // string sql = "Select * From [dbo].[V_InuptLab] ";
            string sql = " SELECT [TicketCodeIn] AS 'รหัสชั่ง',[WeightDate] AS 'วันที่ชั้ง',[TruckTypeName] AS 'ประเภทรถ',[ProductName] AS 'สินค้า',[InboundWeight] AS 'น้ำหนักเข้า',[OutboundWeight] AS 'น้ำหนักออก',[GrossWeight] AS 'น้ำหนักสุทธิ' FROM [dbo].[V_InuptLab]";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "g_v");
            gv_lab.DataSource = ds.Tables["g_v"];
            con.Close();
        }

        private void F_LabSetting_Load(object sender, EventArgs e)
        {
            Load_Product();
            Load_Labtype();
            Load_FileConfig();
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
                if (DR1["ID_Menu"].ToString().Trim() == "84") //ความปลอดภัย   9
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True")
                    { /* add menu nornallyk */

                        (tab_menu.TabPages[0] as TabPage).Enabled = true;
                    }
                }

                if (DR1["ID_Menu"].ToString().Trim() == "85") //ความปลอดภัย   9
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True")
                    { /* add menu nornallyk */

                        (tab_menu.TabPages[1] as TabPage).Enabled = true;
                    }
                }

                if (DR1["ID_Menu"].ToString().Trim() == "86") //ความปลอดภัย   9
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True")
                    { /* add menu nornallyk */

                        (tab_menu.TabPages[2] as TabPage).Enabled = true;
                    }
                }

                if (DR1["ID_Menu"].ToString().Trim() == "87") //ความปลอดภัย   9
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True")
                    { /* add menu nornallyk */

                        (tab_menu.TabPages[3] as TabPage).Enabled = true;
                    }
                }

            }


            DR1.Close();
            con1.Close();

        }
        
        private void Load_Lab_Setting()
        {
            try
            {
                txt_LabsourceFileVisual.Clear();
                txt_LabdiscFileVisual.Clear();
                txt_LabsourceCSV.Clear();
                txt_LabdiscCSV.Clear();
                txt_LabnameStarch.Clear();
                txt_LabvalueStarch.Clear();
                txt_LabnameVA.Clear();
                txt_LabvalueVA.Clear();
                txt_Density.Clear();
                txt_acceptLoss.Clear();
                txt_qtyproduct.Clear();

                chk_density.Checked = false;
                chk_importAuto.Checked = false;

                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                //dtg_vendorStarch.DataSource = null;
                con.Open();

                string sql1 = "SELECT * FROM  [dbo].[TB_LabSetting] WHERE [LabProductID]= '" + cb_product.SelectedValue.ToString() + "' ";

                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    txt_LabsourceFileVisual.Text = DR1["LabSourcepathVisual"].ToString();
                    txt_LabdiscFileVisual.Text = DR1["LabDispathVisual"].ToString();
                    txt_LabsourceCSV.Text = DR1["LabSourcepathCSV"].ToString();
                    txt_LabdiscCSV.Text = DR1["LabDispathCSV"].ToString();
                    txt_LabnameStarch.Text = DR1["ColNameStarchNo"].ToString();
                    txt_LabvalueStarch.Text = DR1["ColValueStarchNo"].ToString();
                    txt_LabnameVA.Text = DR1["ColNameVANo"].ToString();
                    txt_LabvalueVA.Text = DR1["ColValueVANo"].ToString();
                    txt_Density.Text = DR1["ValueDensity"].ToString();
                    txt_acceptLoss.Text = DR1["ValidDensity"].ToString();
                    txt_qtyproduct.Text = DR1["Qtyethanal"].ToString();

                    if (DR1["LabCalAvgOrMax"].ToString() == "True")
                    {
                        rdo_Labavg.Checked = true;
                    }
                    else { rdo_Labmaxmin.Checked = false; }

                    if (DR1["ActiveDensity"].ToString() == "True")
                    {
                        chk_density.Checked = true;
                    }
                    else { chk_density.Checked = false; }

                    if (DR1["LabSourchStarch"].ToString() == "True")
                    {
                        chk_sourevisualStarch.Checked = true;
                    }
                    else { chk_sourevisualStarch.Checked = false; }


                    if (DR1["LabMoveAuto"].ToString() == "True")
                    {
                        chk_importAuto.Checked = true;
                    }
                    else { chk_importAuto.Checked = false; }


                    if (DR1["ShowInsertDen"].ToString() == "True")
                    {
                        chk_insertDen.Checked = true;
                    }
                    else { chk_insertDen.Checked = false; }
                }
                DR1.Close();
                con.Close();
            }
            catch { }
        }

        private void Load_FileConfig()
        {
            //  StreamReader sw = new StreamReader(Application.StartupPath + "\\config.dll");
            string filename = Application.StartupPath + "\\config.dll";


            if (System.IO.File.Exists(filename))
            {
                System.IO.StreamReader StrRer = new System.IO.StreamReader(filename);

                List<string> listStr = new List<string>();

                while (!StrRer.EndOfStream)
                {
                    listStr.Add(StrRer.ReadLine());
                }

                txt_LabsourceCSV.Text = listStr[0].ToString();
                txt_LabdiscCSV.Text = listStr[1].ToString();
                //txt_scalefileDll.Text = listStr[3].ToString();

                StrRer.Close();
            }


        }
        private void Load_Product()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            
            SqlCommand cmd = new SqlCommand("Select [ProductID],Trim([ProductID] +':'+ [ProductName]) AS 'ProductName' From [dbo].[TB_Products] Where [StatusActive] =1", con);
            DataSet ds = new DataSet();
            //ds.Clear();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                // cb_section.DisplayMember = "nameSection_th" + "(" + "nameSection_eng" +")";
                //string name= "nameSection_th" + "(" + "nameSection_eng" + ")";

                cb_product.DisplayMember = "ProductName";
                cb_product.ValueMember = "ProductID";
                cb_product.DataSource = ds.Tables[0];

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

        private void Load_Labtype()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();


            SqlCommand cmd = new SqlCommand("Select LabtypeID,LabtypeName From [dbo].[TB_LabType]", con);
            DataSet ds = new DataSet();
            //ds.Clear();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                // cb_section.DisplayMember = "nameSection_th" + "(" + "nameSection_eng" +")";
                //string name= "nameSection_th" + "(" + "nameSection_eng" + ")";

                cb_labtype.DisplayMember = "LabtypeName";
                cb_labtype.ValueMember = "LabtypeID";
                cb_labtype.DataSource = ds.Tables[0];

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


        private void Load_TypeLab()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
       

            cb_typelabvisual.Text = "";

             try
            {
                if (tab_menu.SelectedIndex == 1)
                {
                    cb_typelabvisual.Enabled = false;

                    con.Open();

                    string sql1 = "SELECT  [LabID] AS 'รหัส',[LabName] AS 'ประเภทวิเคราะห์',[LabNameTH] AS 'คำอธิบาย',[LabActive] AS 'สถานะใช้งาน',[LabOpserv] AS 'เป็นขัอสังเกต',[DisctPrice] AS 'หักราคา/นน.',[Dilldata] AS 'มีเงื่อนไขตัดน้ำหนัก',[LabPayment] AS 'มีเงื่อนไขหักราคา',[LabInStock] AS 'นับสต๊อก' FROM  [dbo].[TB_LabName] WHERE [ProductID]='" + cb_product.SelectedValue.ToString().Trim() + "' AND [LabtypeID]=2";


                    //string sql1 = "SELECT  * FROM  [dbo].[TB_LabName] WHERE [ProductID]='" + cb_product.SelectedValue.ToString().Trim() + "' AND [LabtypeID]=2";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1, "g_vt");
                    dtg_visualtype.DataSource = ds1.Tables["g_vt"];

                    try
                    {
                        dtg_visualtype.Columns[0].Width = 60;
                        dtg_visualtype.Columns[3].Width = 100;
                        dtg_visualtype.Columns[4].Width = 100;
                        dtg_visualtype.Columns[5].Width = 100;
                        dtg_visualtype.Columns[6].Width = 140;
                        dtg_visualtype.Columns[7].Width = 120;
                        dtg_visualtype.Columns[8].Width = 100;
                 

                        dtg_visualtype.ClearSelection();
                    }

                    catch {  }
                    con.Close();

                    string sql2 = "SELECT  [LabID] AS 'รหัส',[LabName] AS 'ประเภทวิเคราะห์',[LabNameTH] AS 'คำอธิบาย',[LabActive] AS 'สถานะใช้งาน',[LabOpserv] AS 'เป็นขัอสังเกต',[DisctPrice] AS 'หักราคา/นน.',[Dilldata] AS 'มีเงื่อนไขตัดน้ำหนัก',[LabPayment] AS 'มีเงื่อนไขหักราคา',[LabInStock] AS 'นับสต๊อก' FROM  [dbo].[TB_LabName] WHERE [ProductID]='" + cb_product.SelectedValue.ToString().Trim() + "' AND [LabtypeID]=1";

                    con.Open();
                    SqlDataAdapter da2 = new SqlDataAdapter(sql2, con);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2, "g_vl");
                    dtg_labtype.DataSource = ds2.Tables["g_vl"];


                    //if (dtg_labtype.RowCount != 0)
                    //{
                    try
                    {
                        dtg_labtype.Columns[0].Width = 60;
                        dtg_labtype.Columns[3].Width = 100;
                        dtg_labtype.Columns[4].Width = 100;
                        dtg_labtype.Columns[5].Width = 100;
                        dtg_labtype.Columns[6].Width = 140;
                        dtg_labtype.Columns[7].Width = 120;
                        dtg_labtype.Columns[8].Width = 100;
                    }
                    catch { }
                    //}
                    con.Close();

                    dtg_labtype.ClearSelection();

                }

                if (tab_menu.SelectedIndex == 2)  //load type room lab
                {
                    cb_typelabtool.Enabled = true;
                    cb_typelabtool.DataSource = null;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select [LabID],Convert(Varchar(2),[LabID]) + ': '+[LabName] AS 'LabName' From [dbo].[TB_LabName] Where [ProductID]='" + cb_product.SelectedValue.ToString().Trim() + "' AND [LabActive]=1 AND [LabtypeID]=1", con);
                    DataSet ds2 = new DataSet();
                    //ds.Clear();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds2);

                    cb_typelabtool.DisplayMember = "LabName";
                    cb_typelabtool.ValueMember = "LabID";
                    cb_typelabtool.DataSource = ds2.Tables[0];
                }       
                               
                if (tab_menu.SelectedIndex == 3)  //load type visual lab
                {
                    cb_typelabvisual.Enabled = true;
                    cb_typelabvisual.DataSource = null;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select [LabID],Convert(Varchar(2),[LabID]) + ': '+[LabName] AS 'LabName' From [dbo].[TB_LabName] Where [ProductID]='" + cb_product.SelectedValue.ToString().Trim() + "' AND [LabActive]=1 AND [LabtypeID]=2", con);
                    DataSet ds1 = new DataSet();
                    //ds.Clear();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds1);
                   
                    cb_typelabvisual.DisplayMember = "LabName";
                    cb_typelabvisual.ValueMember = "LabID";
                    cb_typelabvisual.DataSource = ds1.Tables[0];
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        private void cb_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_TypeLab();
            Load_Lab_Setting();

            if (cb_typelabvisual.Text == "")
            {
                gv_lab.DataSource = null;
                gv_visual.DataSource = null;
              
            }
        }       

        private void Load_DTGVisual()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
   

            string sql = "";
            gv_visual.DataSource = null;
            gv_lab.DataSource = null;
            //try
            //{
            if (tab_menu.SelectedIndex == 1 && cb_typelabvisual.SelectedValue != null)
            {

            }

            if (tab_menu.SelectedIndex == 3 && cb_typelabvisual.SelectedValue != null)
            {
                con.Open();
                sql = "SELECT [ValueVisualNo] AS 'รหัสค่า',[ValueName]  AS 'ชื่อวิเคราะห์',[Value1]  AS 'ค่าที่ได้', [VisualShowRemark] AS 'แสดงที่หมายเหตุุ',[VisualActive] AS 'สถานะใช้งาน',[Alert_VS] AS 'แจ้งเตือน' FROM [dbo].[V_VisualSetting] Where [LabID]=" + cb_typelabvisual.SelectedValue.ToString().Trim() + "";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "g_v");
                gv_visual.DataSource = ds.Tables["g_v"];
                con.Close();

                try
                {
                    gv_visual.Columns[0].Width = 80;
                }
                catch { }
                    
            }


        }

        private void Load_DTGVisual_Detail()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            

            string sql = "";
            gv_visualDetail.DataSource = null;
       
            //try
            //{
            if (tab_menu.SelectedIndex == 1 && cb_typelabvisual.SelectedValue != null)
            {

            }

            if (tab_menu.SelectedIndex == 3 && cb_typelabvisual.SelectedValue != null)
            {
                con.Open();
                sql = "SELECT [VVDeNo] AS 'รหัสค่า',[Vmin]  AS 'ค่าเริ่มต้น',[Vmax]  AS 'ค่าสิ้นสุด',[VSelect]  AS 'ค่าที่นำไปยืนยัน' FROM  [dbo].[TB_ValueVisualDetail] Where [LabID]=" + cb_typelabvisual.SelectedValue.ToString().Trim() + "";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "g_vdetail");
                gv_visualDetail.DataSource = ds.Tables["g_vdetail"];
                con.Close();

                Check_Dill_Data();
            }


        }

        private void Check_Dill_Data()
        {
            int C_count = 0;
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            
            string sql4 = "Select Count([LabID]) AS 'C_count' FROM  [dbo].[TB_LabName]  WHERE [ProductID] = '" + cb_product.SelectedValue.ToString().ToString() + "' AND [LabActive]=1 AND  [LabID]="+ cb_typelabvisual.SelectedValue.ToString().Trim() + " AND [Dilldata] =1";
            SqlCommand CM = new SqlCommand(sql4, con);
            SqlDataReader DR = CM.ExecuteReader();
            DR.Read();
            {
                C_count = Convert.ToUInt16(DR["C_count"].ToString());
            }
            DR.Close();
            con.Close();

            if (C_count == 0)
            {
                cb_value_detail.Enabled = false;

            }
            else { cb_value_detail.Enabled = true; }
        }
                
        private void gv_visual_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                idupdate = 1;
                ch_labvisualNew.Checked = false;
                visual_id =Convert.ToInt16(gv_visual.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                txt_visualName.Text = gv_visual.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                txt_visualValue1.Text = gv_visual.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                //txt_stValue.Text = gv_visual.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();

                if (gv_visual.Rows[e.RowIndex].Cells[3].Value.ToString() == "True")
                {
                    chk_isShow_remark.Checked = true;
                }
                else {
                    chk_isShow_remark.Checked = false;
                }


                if (gv_visual.Rows[e.RowIndex].Cells[4].Value.ToString() == "True")
                {
                    chk_statusVisual.Checked = true;
                }
                else
                {
                    chk_statusVisual.Checked = false;
                }

                if (gv_visual.Rows[e.RowIndex].Cells[5].Value.ToString() == "True")
                {
                    chk_visualAlert.Checked = true;
                }
                else
                {
                    chk_visualAlert.Checked = false;
                }

            }
            catch { }
        }

        private void gv_lab_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                lab_id=Convert.ToInt16(gv_lab.Rows[e.RowIndex].Cells[0].Value.ToString());
                txt_labMin.Text = gv_lab.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_labMax.Text = gv_lab.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_labNet.Text = gv_lab.Rows[e.RowIndex].Cells[3].Value.ToString();

                if (gv_lab.Rows[e.RowIndex].Cells[4].Value.ToString() == "True")
                {
                    chk_statusTool.Checked = true;
                }
                else
                {
                    chk_statusTool.Checked = false;
                }

                if (gv_lab.Rows[e.RowIndex].Cells[5].Value.ToString() == "True")
                {
                    chk_labAlert.Checked = true;
                }
                else
                {
                    chk_labAlert.Checked = false;
                }

                //chk_statusTool.Checked = false;

            }

            catch { }
        
        }

        private void F_LabSetting_ResizeEnd(object sender, EventArgs e)
        {
           
        }
        private void F_LabSetting_Resize(object sender, EventArgs e)
        {
           
        }


        int idupdate = 0;
        private void btn_save_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
       

            int i = 0;
            int x = 0;
            int c = 0;

            if (chk_statusVisual.Checked == true)
            { i = 1; }

            if (chk_isShow_remark.Checked == true)
            { x = 1; }

            if (chk_visualAlert.Checked == true)
            { c = 1; }

            if (tab_menu.SelectedIndex == 3)
            {

                if (idupdate == 1)
                {
                    if (ch_labvisualNew.Checked == true)  // addnew record
                    {
                        con.Open();
                        string sql = "Insert Into [TB_Valuevisual] ([ValueName], [Value1],[LabID],[VisualActive],[VisualShowRemark],[Alert_VS]) Values('" + txt_visualName.Text + "','" + txt_visualValue1.Text + "', '" + cb_typelabvisual.SelectedValue.ToString().Trim() + "', " + i + "," + x + "," + c + ")";
                        SqlCommand CM2 = new SqlCommand(sql, con);
                        SqlDataReader DR2 = CM2.ExecuteReader();
                        con.Close();

                        Msg = "TB_ValueVisual";
                        Log_NewValue = "ValueName = " + txt_visualName.Text +
                              "," + "Value1 = " + txt_visualValue1.Text +
                              "," + "LabDensity = " + cb_typelabvisual.SelectedValue.ToString().Trim() +
                              "," + "LabID = " + i.ToString() +
                              "," + "VisualActive = " + x.ToString() +
                              "," + "VisualShowRemark = " + c.ToString();

                        Log_OldValue = "-";
                        Class_Log CL = new Class_Log();
                        CL.tbname = Msg;
                        CL.oldvalue = Log_OldValue;
                        CL.newvalue = Log_NewValue;
                        CL.Save_log();
                    }

                    else  // edit
                    {
                        con.Open();
                        string sql = "Update [TB_Valuevisual]  Set [ValueName]='" + txt_visualName.Text.Trim() + "',[Value1]='" + txt_visualValue1.Text.Trim() + "',[VisualActive]=" + i + ",[VisualShowRemark]=" + x + ",[Alert_VS]=" + c + " WHERE [ValueVisualNo]= " + visual_id + " ";
                        SqlCommand CM2 = new SqlCommand(sql, con);
                        SqlDataReader DR2 = CM2.ExecuteReader();
                        con.Close();

                        Msg = "TB_Valuevisual";
                        Log_OldValue = "ValueName =" + txt_visualName.Text +
                                "," + "Value1 = " + txt_visualValue1.Text +
                                "," + "VisualActive = " + i.ToString() +
                                "," + "VisualShowRemark = " + x.ToString() +
                                "," + "Alert_VS = " + c.ToString() +
                                "," + "Where ValueVisualNo = " + visual_id.ToString();

                        Log_NewValue = "-";
                        Class_Log CL = new Class_Log();
                        CL.tbname = Msg;
                        CL.oldvalue = Log_OldValue;
                        CL.newvalue = Log_NewValue;
                        CL.Save_log();
                    }
                }

                if (idupdate == 2)
                {

                    if (cb_value_detail.Checked == true)  // addnew record
                    {
                        con.Open();
                        string sql = "Insert Into [TB_ValueVisualDetail] ([Vmin], [Vmax], [VSelect], [LabID]) Values(" + txt_stValue.Text.Trim() + "," + txt_edValue.Text.Trim() + "," + txt_useValue.Text.Trim() + ", '" + cb_typelabvisual.SelectedValue.ToString().Trim() + "')";
                        SqlCommand CM2 = new SqlCommand(sql, con);
                        SqlDataReader DR2 = CM2.ExecuteReader();
                        con.Close();

                        Msg = "TB_ValueVisualDetail";
                        Log_NewValue = "Vmin =" + txt_stValue.Text +
                                "," + "Vmax = " + txt_edValue.Text +
                                "," + "VSelect = " + txt_useValue.Text +
                                "," + "LabID = " + cb_typelabvisual.SelectedValue.ToString().Trim();                         

                        Log_OldValue = "-";
                        Class_Log CL = new Class_Log();
                        CL.tbname = Msg;
                        CL.oldvalue = Log_OldValue;
                        CL.newvalue = Log_NewValue;
                        CL.Save_log();


                    }

                    else  // edit
                    {

                        con.Open();
                        string sql = "Update TB_ValueVisualDetail  Set [Vmin]=" + txt_stValue.Text.Trim() + ",[Vmax]=" + txt_edValue.Text.Trim() + ",[VSelect]=" + txt_useValue.Text.Trim() + ",[LabID]=" + cb_typelabvisual.SelectedValue.ToString().Trim() + " WHERE [VVDeNo]= " + visualDetail_id + " ";
                        SqlCommand CM2 = new SqlCommand(sql, con);
                        SqlDataReader DR2 = CM2.ExecuteReader();
                        con.Close();

                    
                        Msg = "TB_ValueVisualDetail";
                        Log_OldValue = "Vmin =" + txt_stValue.Text +
                                "," + "Vmax = " + txt_edValue.Text +
                                "," + "VSelect = " + txt_useValue.Text +
                                "," + "LabID = " + cb_typelabvisual.SelectedValue.ToString().Trim()+
                                "," + "Where  VVDeNo= " + visualDetail_id.ToString() ;

                      Log_NewValue = "-";
                        Class_Log CL = new Class_Log();
                        CL.tbname = Msg;
                        CL.oldvalue = Log_OldValue;
                        CL.newvalue = Log_NewValue;
                        CL.Save_log();

                    }
                }
                                                                                                                                  
            }

            Load_DTGVisual();
            Load_DTGVisual_Detail();
        }

        private void ch_visualNew_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_labvisualNew.Checked == true)
            {
                idupdate = 1;
                visual_id = 0;
                txt_visualValue1.Clear();
            }
         
        }

        private void ch_labNew_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_labtoolNew.Checked == true)
            {
                lab_id = 0;             
                txt_labMin.Clear();
                txt_labMax.Clear();
                txt_labNet.Clear();
            }
        }

        private void cb_typelabtool_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_labMin.Clear();
            txt_labMax.Clear();
            txt_labNet.Clear();
            Load_DTGlabtool();
        }

        private void Load_DTGlabtool()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            if (tab_menu.SelectedIndex == 2 && cb_typelabtool.SelectedValue != null)
            {
                string sql = " SELECT [LOGID] AS 'รหัส',  [Min] AS 'ค่าต่ำสุด',[Max] AS 'ค่าสูงสุด',[Rate] AS 'ค่าผลลัพธ์', [DeductActive] AS 'สถานะใช้งาน',[Alert_Lab] AS 'แจ้งเตือน' FROM  [dbo].[TB_ValueLab] Where [LabID] =" + cb_typelabtool.SelectedValue.ToString().Trim() + "";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "g_l");
                gv_lab.DataSource = ds.Tables["g_l"];
                con.Close();

                //txt_labName.Text = cb_typelabtool.Text;

            }
        }

        private void btn_save_toolType_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            int i = 0;
            int c = 0;
            if (chk_statusTool.Checked == true)
            { i = 1; }

            if (chk_labAlert.Checked == true)
            { c = 1; }

            if (ch_labtoolNew.Checked == true)
            {
                string sql = "Insert Into [TB_ValueLab] ([Min], [Max],[Rate],[LabID],[Alert_Lab]) Values(" + txt_labMin.Text + ", " + txt_labMax.Text + ", " + txt_labNet.Text + ", " + cb_typelabtool.SelectedValue.ToString().Trim() + "," + c + ")";
                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();
                
                Msg = "TB_ValueLab";
                Log_NewValue = "Min =" + txt_labMin.Text +
                        "," + "Max = " + txt_labMax.Text +
                        "," + "Rate = " + txt_labNet.Text +
                        "," + "LabID = " + cb_typelabtool.SelectedValue.ToString().Trim() +
                        "," + "Alert_Lab" + c.ToString();

                Log_OldValue = "-";
                Class_Log CL = new Class_Log();
                CL.tbname = Msg;
                CL.oldvalue = Log_OldValue;
                CL.newvalue = Log_NewValue;
                CL.Save_log();


            }
            else
            {
                string sql = "Update [TB_ValueLab]  Set Min=" + txt_labMin.Text.Trim() + ",Max=" + txt_labMax.Text.Trim() + ",Rate=" + txt_labNet.Text + " ,LabID=" + cb_typelabtool.SelectedValue.ToString().Trim() + " ,DeductActive=" + i + ",[Alert_Lab]=" + c + " WHERE [LOGID]= " + lab_id + " ";
                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();

                Msg = "TB_ValueLab";            
                Log_OldValue = "Min =" + txt_labMin.Text +
                        "," + "Max = " + txt_labMax.Text +
                        "," + "Rate = " + txt_labNet.Text +
                        "," + "DeductActive = " + cb_typelabtool.SelectedValue.ToString().Trim() +
                        "," + "Alert_Lab" + c.ToString()+
                        "," + " WHERE LOGID=" + lab_id.ToString();

                Log_NewValue = "-";
                Class_Log CL = new Class_Log();
                CL.tbname = Msg;
                CL.oldvalue = Log_OldValue;
                CL.newvalue = Log_NewValue;
                CL.Save_log();
            }

            Load_DTGlabtool();
        }

        private void btn_saveLabtype_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();         


            if (chk_labtypeNew.Checked == true)
            {
                con.Open();
                string sql = "Insert Into [TB_LabName] ([LabName],[LabNameTH], ) Values('" + txt_nameType.Text.Trim() + "','" + txt_nameTypeRemark.Text.Trim() + "')";
                    SqlCommand CM2 = new SqlCommand(sql, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    con.Close();

                 
                Msg = "TB_LabName";
                Log_NewValue = "LabName =" + txt_nameType.Text +
                        "," + "LabNameTH = " + txt_nameTypeRemark.Text;

                Log_OldValue = "-";
                Class_Log CL = new Class_Log();
                CL.tbname = Msg;
                CL.oldvalue = Log_OldValue;
                CL.newvalue = Log_NewValue;
                CL.Save_log();

                txt_nameType.Enabled = false; txt_nameTypeRemark.Enabled = false;
                Load_Labtype(); 
            }

            
       
        }

        private void cb_typelabvisual_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_visualName.Clear();
            chk_labtypeNew.Checked = false;
            Load_DTGVisual();
            Load_DTGVisual_Detail();
        }

        private void dtg_visualtype_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dtg_labtype_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void chk_labtypeNew_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_labtypeNew.Checked == true)
            {
                txt_nameType.Clear(); txt_nameTypeRemark.Clear();
                txt_nameType.Enabled = true; txt_nameTypeRemark.Enabled = true;
                btn_saveLabtype.Enabled = true;
            }

            else { txt_nameType.Enabled = false; txt_nameTypeRemark.Enabled = false; btn_saveLabtype.Enabled = false; }
        }

        private void cb_labtype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gv_visualDetail_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                idupdate = 2;
                visualDetail_id = Convert.ToInt16(gv_visualDetail.Rows[e.RowIndex].Cells[0].Value.ToString());
                txt_stValue.Text = gv_visualDetail.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_edValue.Text = gv_visualDetail.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_useValue.Text = gv_visualDetail.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_stValue.Enabled = true; txt_edValue.Enabled = true; txt_useValue.Enabled = true;
            }
        }

        private void cb_value_detail_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_value_detail.Checked == true)
            {
                idupdate = 2;
                txt_stValue.Clear(); txt_edValue.Clear(); txt_useValue.Clear();
                txt_stValue.Enabled = true; txt_edValue.Enabled = true; txt_useValue.Enabled = true;
            }
        }

        private void dtg_visualtype_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            int Value = 0;
            String Text = "";
            int Filed_Type = 0;
            string Filed_Name = "";

            visual_id =Convert.ToInt16(dtg_visualtype.Rows[e.RowIndex].Cells[0].Value.ToString());


            if (e.ColumnIndex != 1 || e.ColumnIndex != 2)
            {
                if (dtg_visualtype.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "True")
                {
                    Value = 1;
                }
                else { Value = 0; }
            }

            else
            {
                Text = dtg_visualtype.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim();
            }

            //MessageBox.Show(dtg_visualtype.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            //MessageBox.Show(e.RowIndex.ToString() + ": "+ e.ColumnIndex.ToString());

            if (e.ColumnIndex == 1)
            {
                Filed_Name = "LabName";  //ชื่อ lab ภาษาอังกฤษ
                Filed_Type = 1;
            }


            if (e.ColumnIndex == 2)
            {
                Filed_Name = "LabNameTH";  //ชื่อ lab ภาษาไทย
                Filed_Type = 1;
            }

            if (e.ColumnIndex == 3)
            {
                Filed_Name = "LabActive";  //สถานะ
                Filed_Type = 2;  
            }

            if (e.ColumnIndex == 4)
            {
                Filed_Name = "LabOpserv";  //แสดงที่หมายเหตุ
                Filed_Type = 2;
            }

            if (e.ColumnIndex == 5)
            {
                Filed_Name = "DisctPrice"; //หักตัดเงิน หรือ นน.สินค้า
                Filed_Type = 2;
            }

            if (e.ColumnIndex == 6)
            {
                Filed_Name = "Dilldata";  //มีเงิื่อนการหักไขเพิ่ม
                Filed_Type = 2;
            }

            if (e.ColumnIndex == 7)
            {
                Filed_Name = "LabPayment";  //แสดงการหัเพิ่มที่หน้าทำจ่าย
                Filed_Type = 2;
            }

            if (e.ColumnIndex == 8)
            {
                Filed_Name = "LabInStock";   //ผลวิคะราะห์ มีผลคำนนวน นน.คงคลัง
                Filed_Type = 2;
            }

            con.Open();

            string sql = "";
            if (Filed_Type == 1)
            {
                sql = "Update [TB_LabName] Set [" + Filed_Name + "] ='" + Text + "' WHERE [LabID]= " + visual_id + " ";
            }
            else {
                sql = "Update [TB_LabName] Set [" + Filed_Name + "] =" + Value + " WHERE [LabID]= " + visual_id + " ";
            }
         
            SqlCommand CM2 = new SqlCommand(sql, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();

            //MessageBox.Show(sql);
            Value = 0;

            Msg = "TB_LabName";
            Log_OldValue = "Filed_Name = " + Filed_Name.ToString() +
                    "," + "WHERE LabID = " + visual_id.ToString();

            Log_NewValue = "-";
            Class_Log CL = new Class_Log();
            CL.tbname = Msg;
            CL.oldvalue = Log_OldValue;
            CL.newvalue = Log_NewValue;
            CL.Save_log();

        }

        private void cb_labtype_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = cb_labtype.SelectedIndex;
        }

        private void dtg_labtype_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            int Value = 0;
            String Text = "";
            int Filed_Type = 0;
            string Filed_Name = "";

            if (e.ColumnIndex != 1 || e.ColumnIndex != 2)
            {
                if (dtg_visualtype.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "True")
                {
                    Value = 1;
                }
                else { Value = 0; }
            }

            else
            {
                Text = dtg_visualtype.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim();
            }

            if (e.ColumnIndex == 1)
            {
                Filed_Name = "LabName";  //ชื่อ lab ภาษาอังกฤษ
                Filed_Type = 1;
            }


            if (e.ColumnIndex == 2)
            {
                Filed_Name = "LabNameTH";  //ชื่อ lab ภาษาไทย
                Filed_Type = 1;
            }

            if (e.ColumnIndex == 3)
            {
                Filed_Name = "LabActive";  //สถานะ
                Filed_Type = 2;
            }

            if (e.ColumnIndex == 4)
            {
                Filed_Name = "LabOpserv";  //แสดงที่หมายเหตุ
                Filed_Type = 2;
            }

            if (e.ColumnIndex == 5)
            {
                Filed_Name = "DisctPrice"; //หักตัดเงิน หรือ นน.สินค้า
                Filed_Type = 2;
            }

            if (e.ColumnIndex == 6)
            {
                Filed_Name = "Dilldata";  //มีเงิื่อนการหักไขเพิ่ม
                Filed_Type = 2;
            }

            if (e.ColumnIndex == 7)
            {
                Filed_Name = "LabPayment";  //แสดงการหัเพิ่มที่หน้าทำจ่าย
                Filed_Type = 2;
            }

            if (e.ColumnIndex == 8)
            {
                Filed_Name = "LabInStock";   //ผลวิคะราะห์ มีผลคำนนวน นน.คงคลัง
                Filed_Type = 2;
            }

            con.Open();

            string sql = "";
            if (Filed_Type == 1)
            {
                sql = "Update [TB_LabName] Set [" + Filed_Name + "] ='" + Text + " WHERE [LabID]= " + visual_id + " ";
            }
            else
            {
                sql = "Update [TB_LabName] Set [" + Filed_Name + "] =" + Value + " WHERE [LabID]= " + visual_id + " ";
            }

            SqlCommand CM2 = new SqlCommand(sql, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();

            Value = 0;           

            Msg = "TB_LabName";
            Log_OldValue = "Filed_Name =" + Filed_Name.ToString() +
                    "," + "WHERE LabID = " + visual_id.ToString();

            Log_NewValue = "-";
            Class_Log CL = new Class_Log();
            CL.tbname = Msg;
            CL.oldvalue = Log_OldValue;
            CL.newvalue = Log_NewValue;
            CL.Save_log();

        }

        private void btn_des_Click(object sender, EventArgs e)
        {
            F_Des FD = new F_Des();
            FD.ShowDialog();
        }

        private void chk_density_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_density.Checked == true)
            {
                txt_Density.Enabled = true; txt_acceptLoss.Enabled = true; txt_qtyproduct.Enabled = true;
            }
            else { txt_Density.Enabled = false; txt_acceptLoss.Enabled = false; txt_qtyproduct.Enabled = false; }
        }

        private void btn_LabsourceFileVisual_Click(object sender, EventArgs e)
        {
            string dummyFileName = "ไฟล์จากต้นปลายทาง!!";

            SaveFileDialog sf = new SaveFileDialog();
            // Feed the dummy name to the save dialog
            sf.FileName = dummyFileName;

            if (sf.ShowDialog() == DialogResult.OK)
            {
                // Now here's our save folder
                string savePath = Path.GetDirectoryName(sf.FileName);
                txt_LabsourceFileVisual.Text = savePath;
                // Do whatever
            }
        }

        private void btn_LabdiscFileVisual_Click(object sender, EventArgs e)
        {
            string dummyFileName = "ไฟล์ย้ายปลายทาง!!";

            SaveFileDialog sf = new SaveFileDialog();
            // Feed the dummy name to the save dialog
            sf.FileName = dummyFileName;

            if (sf.ShowDialog() == DialogResult.OK)
            {
                // Now here's our save folder
                string savePath = Path.GetDirectoryName(sf.FileName);
                txt_LabdiscFileVisual.Text = savePath;
                // Do whatever
            }
        }

        private void btn_LabsourcCSV_Click(object sender, EventArgs e)
        {
            string dummyFileName = "ไฟล์จากต้นปลายทาง!!";

            SaveFileDialog sf = new SaveFileDialog();
            // Feed the dummy name to the save dialog
            sf.FileName = dummyFileName;

            if (sf.ShowDialog() == DialogResult.OK)
            {
                // Now here's our save folder
                string savePath = Path.GetDirectoryName(sf.FileName);
                txt_LabsourceCSV.Text = savePath;
                // Do whatever
            }
        }

        private void btn_LabdesCSV_Click(object sender, EventArgs e)
        {
            string dummyFileName = "ไฟล์จากต้นปลายทาง!!";

            SaveFileDialog sf = new SaveFileDialog();
            // Feed the dummy name to the save dialog
            sf.FileName = dummyFileName;

            if (sf.ShowDialog() == DialogResult.OK)
            {
                // Now here's our save folder
                string savePath = Path.GetDirectoryName(sf.FileName);
                txt_LabdiscCSV.Text = savePath;
                // Do whatever
            }
        }

        private void btn_save_labsetting_Click(object sender, EventArgs e)
        {
            Update_LabSetting();
        }

        private void Update_LabSetting()
        {

            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

                int LabCalAvgOrMax = 2;
                int Status_Density = 0;
                int LabSourchStarch = 0;
                int LabMoveAuto = 0;
                int SPApprovVisual = 0;
                int InsertDen = 0;

                if (rdo_Labavg.Checked == true)
                { LabCalAvgOrMax = 1; }
                if (rdo_Labmaxmin.Checked == true)
                { LabCalAvgOrMax = 0; }
                if (chk_density.Checked == true)
                { Status_Density = 1; }
                if (chk_sourevisualStarch.Checked == true)
                { LabSourchStarch = 1; }
                if (chk_importAuto.Checked == true)
                { LabMoveAuto = 1; }
                if (chk_SPappvisual.Checked == true)
                { SPApprovVisual = 1; }
                if (chk_insertDen.Checked == true)
                { InsertDen = 1; }


                int Items_Check = 0;

                con.Open();
                string sql6 = "SELECT Count([LabProductID]) AS 'Items_Check'  FROM  [dbo].[TB_LabSetting] WHERE [LabProductID]='" + cb_product.SelectedValue.ToString() + "'";
                SqlCommand CM6 = new SqlCommand(sql6, con);
                SqlDataReader DR6 = CM6.ExecuteReader();

                DR6.Read();
                {
                    Items_Check = Convert.ToInt16(DR6["Items_Check"].ToString().Trim());
                }
                DR6.Close();
                con.Close();

                if (Items_Check == 0)
                {
                    con.Open();
                    string sql = "Insert Into  [dbo].[TB_LabSetting] ([LabProductID]) Values ('" + cb_product.SelectedValue.ToString() + "')";
                    SqlCommand CM = new SqlCommand(sql, con);
                    SqlDataReader DR = CM.ExecuteReader();
                    con.Close();

                    Msg = "TB_LabSetting";
                    Log_NewValue = "LabProductID = " + cb_product.SelectedValue.ToString();
                    Log_OldValue = "-";


                }
                string sql1 = "";

                con.Open();

                if (chk_density.Checked == true)
                {

                    sql1 = "Update  [dbo].[TB_LabSetting] Set [LabCalAvgOrMax]=" + LabCalAvgOrMax + ",[LabSourcepathVisual]='" + txt_LabsourceFileVisual.Text.Trim() + "',[LabDispathVisual]='" + txt_LabdiscFileVisual.Text.Trim() + "',[LabSourcepathCSV]='" + txt_LabsourceCSV.Text.Trim() + "',[LabDispathCSV]='" + txt_LabdiscCSV.Text.Trim() + "',[ColNameStarchNo]='" + txt_LabnameStarch.Text.Trim() + "',[ColValueStarchNo]=" + txt_LabvalueStarch.Text.Trim() + ",[ColNameVANo]='" + txt_LabnameVA.Text.Trim() + "',[ColValueVANo]=" + txt_LabvalueVA.Text.Trim() + ",[ActiveDensity] = " + Status_Density + ",[ShowInsertDen] = " + InsertDen + ",[ValueDensity]=" + txt_Density.Text.Trim() + ",[ValidDensity]=" + txt_acceptLoss.Text + ",[Qtyethanal]=" + txt_qtyproduct.Text + ",[LabSourchStarch] = " + LabSourchStarch + ",[LabMoveAuto] = " + LabMoveAuto + "  WHERE [LabProductID]='" + cb_product.SelectedValue.ToString() + "'";

                    Msg = "Update to Record in Lab Setting (Option Density)!";

                    Log_OldValue = "LabCalAvgOrMax = " + LabCalAvgOrMax.ToString() +
                        "," + "LabSourcepathVisual = " + txt_LabsourceFileVisual.Text.Trim() +
                        "," + "LabDispathVisual = " + txt_LabdiscFileVisual.Text.Trim() +
                        "," + "LabSourcepathCSV = " + txt_LabsourceCSV.Text.Trim() +
                        "," + "LabDispathCSV = " + txt_LabdiscCSV.Text.Trim() +
                        "," + "ColNameStarchNo = " + txt_LabnameStarch.Text.Trim() +
                        "," + "ColValueStarchNo = " + txt_LabvalueStarch.Text.Trim() +
                        "," + "ColNameVANo = " + txt_LabnameVA.Text.Trim() +
                        "," + "ColValueVANo = " + txt_LabvalueVA.Text.Trim() +
                        "," + "ActiveDensity = " + Status_Density.ToString() +
                        "," + "ValueDensity = " + txt_Density.Text.Trim() +
                        "," + "ValidDensity = " + txt_acceptLoss.Text.Trim() +
                        "," + "Qtyethanal =" + txt_qtyproduct.Text.Trim() +
                        "," + "LabSourchStarch = " + LabSourchStarch.ToString() +
                        "," + "LabMoveAuto = " + LabMoveAuto.ToString() +
                        "," + "WHERE LabProductID = " + cb_product.SelectedValue.ToString();

                    Log_NewValue = "-";

                }
                else
                {
                    sql1 = "Update  [dbo].[TB_LabSetting] Set [LabCalAvgOrMax]=" + LabCalAvgOrMax + ",[LabSourcepathVisual]='" + txt_LabsourceFileVisual.Text.Trim() + "',[LabDispathVisual]='" + txt_LabdiscFileVisual.Text.Trim() + "',[LabSourcepathCSV]='" + txt_LabsourceCSV.Text.Trim() + "',[LabDispathCSV]='" + txt_LabdiscCSV.Text.Trim() + "',[ColNameStarchNo]='" + txt_LabnameStarch.Text.Trim() + "',[ColValueStarchNo]=" + txt_LabvalueStarch.Text.Trim() + ",[ColNameVANo]='" + txt_LabnameVA.Text.Trim() + "',[ColValueVANo]=" + txt_LabvalueVA.Text.Trim() + ",[ActiveDensity] = " + Status_Density + ",[ShowInsertDen] = " + InsertDen + ",[LabSourchStarch] = " + LabSourchStarch + ",[LabMoveAuto] = " + LabMoveAuto + ",[SPApprovVisual]=" + SPApprovVisual + "  WHERE [LabProductID]='" + cb_product.SelectedValue.ToString() + "'";

                    Msg = "Update to Record in Lab Setting!";
                    Log_OldValue = "LabCalAvgOrMax = " + LabCalAvgOrMax.ToString() +
                            "," + "LabSourcepathVisual = " + txt_LabsourceFileVisual.Text.Trim() +
                            "," + "LabDispathVisual = " + txt_LabdiscFileVisual.Text.Trim() +
                            "," + "LabSourcepathCSV = " + txt_LabsourceCSV.Text.Trim() +
                            "," + "LabDispathCSV = " + txt_LabdiscCSV.Text.Trim() +
                            "," + "ColNameStarchNo = " + txt_LabnameStarch.Text.Trim() +
                            "," + "ColValueStarchNo = " + txt_LabvalueStarch.Text.Trim() +
                            "," + "ColNameVANo = " + txt_LabnameVA.Text.Trim() +
                            "," + "ColValueVANo = " + txt_LabvalueVA.Text.Trim() +
                            "," + "ActiveDensity = " + Status_Density.ToString() +
                            "," + "SPApprovVisual = " + SPApprovVisual.ToString() +
                            "," + "LabSourchStarch = " + LabSourchStarch.ToString() +
                            "," + "LabMoveAuto = " + LabMoveAuto.ToString() +
                            "," + "WHERE LabProductID = " + cb_product.SelectedValue.ToString();
                    Log_NewValue = "-";

                }

                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                con.Close();

                MessageBox.Show("บันทึกสำเร็จ", "รายงานการบันทึก", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Class_Log CL = new Class_Log();
                CL.tbname = Msg;
                CL.oldvalue = Log_OldValue;
                CL.newvalue = Log_NewValue;
                CL.Save_log();
            }
            catch { }
        }

        private void chk_sourceDefualt_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_sourceDefualt.Checked == true)
            {
                txt_LabsourceFileVisual.Text = @"..\pic_temp\";
            }

            else
            {
                string dummyFileName = "ไฟล์จากต้นปลายทาง!!";

                SaveFileDialog sf = new SaveFileDialog();
                // Feed the dummy name to the save dialog
                sf.FileName = dummyFileName;

                if (sf.ShowDialog() == DialogResult.OK)
                {
                    // Now here's our save folder
                    string savePath = Path.GetDirectoryName(sf.FileName);
                    txt_LabsourceFileVisual.Text = savePath;
                    // Do whatever
                }
            }
        }
    }
}
