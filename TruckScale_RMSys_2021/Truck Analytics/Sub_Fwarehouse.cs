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
    public partial class Sub_Fwarehouse : Form
    {
        public Sub_Fwarehouse()
        {
            InitializeComponent();
        }

        int id_change = 0;

        // Log
        string Msg = "";
        string Log_OldValue = "-";
        string Log_NewValue = "-";


        private void chk_storeQA_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_storeQA.Checked == true)
            {
                chk_storeZone.Checked = false;
            }

            else
            {
                txt_storeDescriptoin.Clear();
                txt_storeGrade.Clear();
                txt_storeQA.Clear();
            }

            Load_StoreSetting();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Load_StoreSetting()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql1 = "";
                dtg_storeSetting.DataSource = null;

                if (chk_storeQA.Checked == true)
                {
                    sql1 = "SELECT [QtyCode] AS 'รหัส',[QtyName] AS 'ตัวเลขสูงสุดของช่วง' ,[QtyValue] AS 'เกรดคุณภาพ' ,[QtyRemark] AS 'หมายเหตุ' FROM  [dbo].[TB_Quality]";
                }

                else
                {
                    sql1 = "SELECT [NO_Zone] AS 'รหัสโซน/กลุ่ม' ,[Name_Zone] AS 'ชื่อโซน/กลุ่ม'  ,[UnitINStock] AS 'จำนวนคงคลัง' ,[QtyName] AS 'คุณภาพ' ,[QtyRemark] AS 'หมายเหตุ' FROM  [dbo].[V_LocationZone] WHERE ProductID='" + cb_product_Store.SelectedValue.ToString() + "'";
                }


                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_scale");
                dtg_storeSetting.DataSource = ds1.Tables["g_scale"];
                con.Close();

                if (chk_storeQA.Checked == true)
                {
                    dtg_storeSetting.Columns[0].Width = 100;
                    dtg_storeSetting.Columns[1].Width = 150;
                    dtg_storeSetting.Columns[2].Width = 200;

                }

                else
                {
                    dtg_storeSetting.Columns[0].Width = 150;
                    dtg_storeSetting.Columns[1].Width = 200;
                    dtg_storeSetting.Columns[2].Width = 120;
                    dtg_storeSetting.Columns[3].Width = 100;
                }
            }

            catch { }
        }

        private void chk_storeZone_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_storeZone.Checked == true)
            {
                chk_storeQA.Checked = false;
                txt_qtyZone.Text = "0";
            }

            else
            {
                txt_IDZone.Clear();
                txt_qtyZone.Clear();
            }

            Load_StoreSetting();
        }

        private void btn_searchCusLocation_Click(object sender, EventArgs e)
        {
            F_Search fnd = new F_Search();
            fnd.id_findType = 3;
            fnd.ShowDialog();

            if (fnd.id_value != "")
            {
                txt_VendorNoLocation.Text = fnd.id_value;
                txt_VendorNameLOcation.Text = fnd.name_value;
            }
        }

        private void cb_storeQA_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Save_StoreSetting()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql1 = "";
            dtg_storeSetting.DataSource = null;

            if (chk_storeQA.Checked == true)
            {

                sql1 = "Insert Into  [dbo].[TB_Quality] ([QtyName],[QtyValue],[QtyRemark]) Values('" + txt_storeQA.Text.Trim() + "'," + txt_storeGrade.Text.Trim() + ",'" + txt_storeDescriptoin.Text.Trim() + "') ";

                Msg = "Insert New Record in Quality Setting!";

                Log_NewValue = "QtyName = " + txt_storeQA.Text.Trim() +
                     "," + "QtyValue = " + txt_storeGrade.Text.Trim() +
                     "," + "QtyRemark = " + txt_storeDescriptoin.Text.Trim();
                Log_OldValue = "-";
            }

            if (chk_storeQA.Checked == true)
            {
                sql1 = "Update  [dbo].[TB_Quality] Set [QtyName]='" + txt_storeQA.Text.Trim() + "',[QtyValue]=" + txt_storeGrade.Text.Trim() + ",[QtyRemark]='" + txt_storeDescriptoin.Text.Trim() + "' WHERE [QtyCode]=" + id_change + " ";

                Msg = "Update to Record in Quality Setting!";
                Log_OldValue = "QtyName = " + txt_storeQA.Text.Trim() +
                   "," + "QtyValue = " + txt_storeGrade.Text.Trim() +
                   "," + "QtyRemark = " + txt_storeDescriptoin.Text.Trim() +
                   "," + "Where QtyCode = " + id_change.ToString().Trim();
                Log_NewValue = "-";
            }

            if (chk_storeZone.Checked == true)
            {
                sql1 = "Insert Into  [dbo].[TB_LocationZone] ([NO_Zone],[Name_Zone] ,[UnitINStock],[QtyCode] ,[ProductID]) Values('" + txt_IDZone.Text.Trim() + "','" + txt_nameZone.Text + "'," + txt_qtyZone.Text.Trim() + "," + cb_storeQA.SelectedValue.ToString() + ",'" + cb_product_Store.SelectedValue.ToString() + "')";

                Msg = "Insert New Record in Location Zone!";
                Log_NewValue = "NO_Zone = " + txt_IDZone.Text.Trim() +
                    "," + "Name_Zone = " + txt_nameZone.Text.Trim() +
                    "," + "UnitINStock = " + txt_qtyZone.Text.Trim() +
                    "," + "QtyCode = " + cb_storeQA.Text.Trim() +
                    "," + "ProductID = " + cb_product_Store.SelectedValue.ToString();
                Log_OldValue = "-";
            }

            if (chk_storeZone.Checked == false)
            {
                sql1 = "Update  [dbo].[TB_LocationZone]  Set [Name_Zone]='" + txt_nameZone.Text.Trim() + "',[UnitINStock]=" + txt_qtyZone.Text.Trim() + ",[QtyCode]=" + cb_storeQA.SelectedValue.ToString() + " ,[ProductID]='" + cb_product_Store.SelectedValue.ToString() + "' WHERE  [NO_Zone]=" + txt_IDZone.Text.Trim() + "";

                Msg = "Update to Record in Flow Location Zone!";
                Log_OldValue = "Name_Zone = " + txt_nameZone.Text.Trim() +
                    "," + "UnitINStock = " + txt_qtyZone.Text.Trim() +
                    "," + "QtyCode = " + cb_storeQA.SelectedValue.ToString() +
                    "," + "ProductID = " + cb_product_Store.SelectedValue.ToString() +
                    "," + "Where NO_Zone = " + txt_IDZone.Text.Trim();
                Log_NewValue = sql1;
            }


            SqlCommand CM2 = new SqlCommand(sql1, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();

            Class_Log CL = new Class_Log();
            CL.tbname = Msg;
            CL.oldvalue = Log_OldValue;
            CL.newvalue = Log_NewValue;
            CL.Save_log();

            txt_storeQA.Clear();
            txt_storeGrade.Clear();
            txt_storeDescriptoin.Clear();
            Load_Quality();
            Load_StoreSetting();
        }

        private void Load_Quality()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            SqlCommand cmd = new SqlCommand(" Select [QtyCode],[QtyName]  From  [dbo].[TB_Quality]", con);
            DataSet ds = new DataSet();
            //ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            //Load product tab weight scale Setup
            cb_storeQA.DataSource = ds.Tables[0];
            cb_storeQA.DisplayMember = "QtyName";
            cb_storeQA.ValueMember = "QtyCode";
            con.Close();
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

                DataSet ds2 = new DataSet();
                //ds.Clear();
                SqlDataAdapter da2 = new SqlDataAdapter();
                da2.SelectCommand = cmd;
                da2.Fill(ds2);
                //Load product tab store Setup
                cb_product_Store.DataSource = ds2.Tables[0];
                cb_product_Store.DisplayMember = "ProductName";
                cb_product_Store.ValueMember = "ProductID";
                
                DataSet ds8 = new DataSet();
                //ds.Clear();
                SqlDataAdapter da8 = new SqlDataAdapter();
                da8.SelectCommand = cmd;
                da8.Fill(ds8);
                cbo_product_adjust.DataSource = ds8.Tables[0];
                cbo_product_adjust.DisplayMember = "ProductName";
                cbo_product_adjust.ValueMember = "ProductID";

                DataSet ds9 = new DataSet();
                //ds.Clear();
                SqlDataAdapter da9 = new SqlDataAdapter();
                da9.SelectCommand = cmd;
                da9.Fill(ds9);
                cbo_product_STMovement.DataSource = ds9.Tables[0];
                cbo_product_STMovement.DisplayMember = "ProductName";
                cbo_product_STMovement.ValueMember = "ProductID";

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

        private void btn_saveStore_Click(object sender, EventArgs e)
        {
            Save_StoreSetting();
        }

        private void cbo_product_adjust_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();


                double TotalStock = 0;

                con.Open();
                string sql6 = "Select Sum([UnitINStock]) AS 'TotalStock' From [dbo].[TB_LocationZone]   Where [ProductID] ='" + cbo_product_adjust.SelectedValue.ToString() + "'";
                SqlCommand CM6 = new SqlCommand(sql6, con);
                SqlDataReader DR6 = CM6.ExecuteReader();

                DR6.Read();
                {
                    TotalStock = Convert.ToDouble(DR6["TotalStock"].ToString().Trim());
                }
                DR6.Close();
                con.Close();

                txt_STtotalWeight.Text = TotalStock.ToString("F");


                int Zone = 0;
                con.Open();
                string sql7 = "Select Count([NO_Zone]) AS 'CountZone' From [dbo].[TB_LocationZone]   Where [ProductID] ='" + cbo_product_adjust.SelectedValue.ToString() + "'";
                SqlCommand CM7 = new SqlCommand(sql7, con);
                SqlDataReader DR7 = CM7.ExecuteReader();

                DR7.Read();
                {
                    Zone = Convert.ToInt16(DR7["CountZone"].ToString().Trim());
                }
                DR7.Close();
                con.Close();

                if (Zone > 1)
                {
                    rdo_adjustTranfer.Enabled = true;
                    gb_beforeTranfer.Enabled = true;
                    gb_afterTranfer.Enabled = true;

                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select [NO_Zone], Trim([NO_Zone])+' : '+ Trim([Name_Zone]) AS 'ZoneName' From [dbo].[TB_LocationZone] Where [ProductID] ='" + cbo_product_adjust.SelectedValue.ToString() + "'", con);

                    DataSet ds1 = new DataSet();
                    //ds.Clear();
                    SqlDataAdapter da1 = new SqlDataAdapter();
                    da1.SelectCommand = cmd;
                    da1.Fill(ds1);
                    //Load product tab weight scale Setup
                    cbo_adjustFrmStore.DataSource = ds1.Tables[0];
                    cbo_adjustFrmStore.DisplayMember = "ZoneName";
                    cbo_adjustFrmStore.ValueMember = "NO_Zone";

                    DataSet ds2 = new DataSet();
                    //ds.Clear();
                    SqlDataAdapter da2 = new SqlDataAdapter();
                    da2.SelectCommand = cmd;
                    da2.Fill(ds2);
                    cbo_adjustToStore.DataSource = ds2.Tables[0];
                    cbo_adjustToStore.DisplayMember = "ZoneName";
                    cbo_adjustToStore.ValueMember = "NO_Zone";

                    con.Close();

                }

                else
                {

                    rdo_adjustTranfer.Enabled = false;
                    gb_beforeTranfer.Enabled = false;
                    gb_afterTranfer.Enabled = false;
                    cbo_adjustFrmStore.Text = "";
                    cbo_adjustToStore.Text = "";
                }

            }

            catch { }

        }

        private void rdo_adjustStore_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_adjustStore.Checked == true)
            {
                gb_adjust.Enabled = true;
                gb_beforeTranfer.Enabled = false;
                cbo_adjustFrmStore.Text = "";
                cbo_adjustToStore.Text = "";
            }
        }

        private void rdo_adjustTranfer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_adjustTranfer.Checked == true)
            {
                gb_adjust.Enabled = false;
                gb_beforeTranfer.Enabled = true;
                rdo_adjustSTPositive.Checked = false;
                rdo_adjustSTNegative.Checked = false;
            }
        }


        private void btn_SaveSTMovement_Click(object sender, EventArgs e)
        {
            if (cbo_adjustFrmStore.SelectedValue.ToString() != cbo_adjustToStore.SelectedValue.ToString())
            {

                //Msg = "Insert New Record in Flow Process!";
                //Class_Log CL = new Class_Log();
                //CL.tbname = Msg;
                //CL.oldvalue = Log_OldValue;
                //CL.newvalue = Log_NewValue;
                //CL.Save_log();

            }

            else
            {
                MessageBox.Show("คลังในการโอนย้ายห้ามเหมือนกัน", "การโอนย้ายผิดพลาด !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbo_adjustToStore.Text = "";
            }
        }

        private void dtg_storeSetting_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                if (chk_storeQA.Checked == false)
                {
                    id_change = Convert.ToInt16(dtg_storeSetting.Rows[0].Cells[0].Value.ToString().Trim());
                    txt_storeQA.Text = dtg_storeSetting.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txt_storeGrade.Text = dtg_storeSetting.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txt_storeDescriptoin.Text = dtg_storeSetting.Rows[e.RowIndex].Cells[3].Value.ToString();
                }

                if (chk_storeZone.Checked == false)
                {
                    id_change = Convert.ToInt16(dtg_storeSetting.Rows[0].Cells[0].Value.ToString().Trim());
                    txt_IDZone.Text = dtg_storeSetting.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txt_nameZone.Text = dtg_storeSetting.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txt_qtyZone.Text = dtg_storeSetting.Rows[e.RowIndex].Cells[2].Value.ToString();
                    cb_storeQA.Text = dtg_storeSetting.Rows[e.RowIndex].Cells[3].Value.ToString();
                }
            }
            catch { }
        }

        private void Sub_Fwarehouse_Load(object sender, EventArgs e)
        {
            Load_LoadProduct();
            Load_Quality();
            Load_StoreSetting();
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
                if (DR1["ID_Menu"].ToString().Trim() == "80") //ความปลอดภัย   9
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True")
                    { /* add menu nornallyk */

                        (tab_menu.TabPages[0] as TabPage).Enabled = true;
                    }
                }

                if (DR1["ID_Menu"].ToString().Trim() == "81") //ความปลอดภัย   9
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True")
                    { /* add menu nornallyk */

                        (tab_menu.TabPages[1] as TabPage).Enabled = true;
                    }
                }

                if (DR1["ID_Menu"].ToString().Trim() == "82") //ความปลอดภัย   9
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True")
                    { /* add menu nornallyk */

                        (tab_menu.TabPages[2] as TabPage).Enabled = true;
                    }
                }

                if (DR1["ID_Menu"].ToString().Trim() == "83") //ความปลอดภัย   9
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

        private void cb_product_Store_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_StoreSetting();
        }

        private void cbo_product_STMovement_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
