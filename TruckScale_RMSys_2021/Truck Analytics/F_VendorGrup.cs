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
    public partial class F_VendorGrup : Form
    {
        public F_VendorGrup()
        {
            InitializeComponent();
        }

        private void btn_Addgroup_Click(object sender, EventArgs e)
        {
            F_GroupMNT fgmn = new F_GroupMNT();
            fgmn.ShowDialog();
            Load_VendorGroup();
        }

        int VendorGPay = 0;
        string Log_TableName = "-";
        string Log_OldValue = "-";
        string Log_NewValue = "-";
        int id_dup = 0;
        private void F_VendorGrup_Load(object sender, EventArgs e)
        {
            Load_VendorGroup();
            Load_DATA();
        }

        private void Load_VendorGroup()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("Select [VendorGroupID],([VendorGroupID]+':'+ [VendorGroupName]) AS 'VendorGroupName'  From  [dbo].[VendorGroup] WHERE [VendorGroupID] <> 'VG-000' AND [VendorGroupID] <> 'VG-001' AND [VendorGroupID] <> 'VG-002' AND [VendorGroupID] <> 'VG-003' AND [VendorGroupID] <> 'VG-004' ", con);
            DataSet ds = new DataSet();
            //ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            //Load product tab weight scale Setup
            cb_vendorGroup.DataSource = ds.Tables[0];
            cb_vendorGroup.DisplayMember = "VendorGroupName";
            cb_vendorGroup.ValueMember = "VendorGroupID";            
        }

        private void cb_vendorGroup_SelectedIndexChanged(object sender, EventArgs e)
        {           
                Load_DATA();           
        }

        private void Load_DATA()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                if (cb_vendorGroup.SelectedIndex > -1)
                {
                    string sql = "SELECT [VendorGPay] AS 'ลำดับที่', [Vendor_No] AS 'รหัสผู้ขาย',[Vendor_Name] AS 'ชื่อผู้ขาย',[StsActive] AS 'สถานะใช้' FROM  [dbo].[V_VendorGroup]  WHERE [VendorGroupID]= '" + cb_vendorGroup.SelectedValue.ToString() + "'";

                    SqlDataAdapter da1 = new SqlDataAdapter(sql, con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1, "g_l");
                    dtg_vendor.DataSource = ds1.Tables["g_l"];
                    con.Close();
                    

                    if (cb_vendorGroup.SelectedValue.ToString() != "System.Data.DataView")
                    {
                        con.Open();
                        string sql1 = "Select [StsActive] From [dbo].[TB_VendorGroupPayment] Where [VendorGroupID]='" + cb_vendorGroup.SelectedValue.ToString().Trim() + "' ";
                        SqlCommand CM1 = new SqlCommand(sql1, con);
                        SqlDataReader DR1 = CM1.ExecuteReader();
                        DR1.Read();
                        {
                            if (DR1["StsActive"].ToString() == "True")
                            {
                                chk_STSacctive.Checked = true;
                            }
                        }
                        DR1.Close();

                        //rdr.Close();
                        con.Close();
                    }
                }

                tool_countItem.Text = "Items: " + dtg_vendor.RowCount.ToString() + " Data";

                dtg_vendor.Columns[0].Width = 100;
                dtg_vendor.Columns[1].Width = 200;
                dtg_vendor.Columns[6].Width = 0;
            }
            catch { }
        }

        private void btn_vendorFind_Click(object sender, EventArgs e)
        {
            F_Search fnd = new F_Search();
            fnd.id_findType = 3;
            fnd.ShowDialog();
            txt_idvendor.Text = fnd.id_value;
            lbl_vendorName.Text = fnd.name_value;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            Check_SaveDuplicate();

           
            int StsActive = 0;

            if (chk_STSacctive.Checked == true)
            {
                StsActive = 1;
            }

            if (id_dup == 0 && txt_idvendor.Text!="")
            {
                if (chk_addNew.Checked == true)
                {
                    con.Open();
                    string sql = "Insert Into [TB_VendorGroupPayment] ([VendorGroupID],[Vendor_No]) Values('" + cb_vendorGroup.SelectedValue.ToString() + "', '" + txt_idvendor.Text + "')";
                    SqlCommand CM2 = new SqlCommand(sql, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    con.Close();

                    Log_TableName = "TB_VendorGroupPayment: Insert";
                    Log_NewValue = txt_idvendor.Text;
                }

                //else
                //{
                //    con.Open();
                //    string sql = "Update [TB_VendorGroupPayment] SET [VendorGroupID]='" + cb_vendorGroup.SelectedValue.ToString() + "',[StDate] ='" + stDate + "',[EdDate]='" + edDate + "',[StsActive] =" + StsActive + "  WHERE [VendorGPay]= " + VendorGPay + "";
                //    SqlCommand CM2 = new SqlCommand(sql, con);
                //    SqlDataReader DR2 = CM2.ExecuteReader();
                //    con.Close();

                //    Log_TableName = "TB_VendorGroupPayment : Update";
                //    Log_OldValue = txt_idvendor.Text + ":" + StsActive.ToString();
                //}
                Load_DATA();
                Save_Log();
            }

            else {

                //MessageBox.Show("บันทึกข้อมูลซ้ำ/ไม่มีข้อมูลผู้ขาย กรุณาตรวจสอบข้อมูลอีกครั้ง","บันทึกข้อมูลผิดพลาด !!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                con.Open();
                string sql = "Update [TB_VendorGroupPayment] SET [VendorGroupID]='" + cb_vendorGroup.SelectedValue.ToString() + "',[StsActive] =" + StsActive + "  WHERE [VendorGPay]= " + VendorGPay + "";
                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();

                Log_TableName = "TB_VendorGroupPayment : Update";
                Log_OldValue = txt_idvendor.Text + ":" + StsActive.ToString();
                Load_DATA();
                Save_Log();
            }
        }


        private void Check_SaveDuplicate()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql1 = "Select count( VendorGroupID) as vendor_count From [dbo].[TB_VendorGroupPayment] Where [VendorGroupID]='" + cb_vendorGroup.SelectedValue.ToString().Trim() + "' AND [Vendor_No]='" + txt_idvendor.Text.Trim() + "'";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();
            DR1.Read();
            {
                id_dup = Convert.ToInt16(DR1["vendor_count"].ToString());
            }
            DR1.Close();

            //rdr.Close();
            con.Close();

        }

        private void Save_Log()
        {
            string date = Program.Date_Now + ' ' + Program.Time_Now;

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql = "Insert Into [TB_Log] ([LogDateTime],[Username],[TableName],[OldValue],[NewValue],[MachineName],[LocalIpAddress]) Values('" + date + "', '" + Program.user_login + "', '" + Log_TableName + "','" + Log_OldValue + "', '" + Log_NewValue + "', '" + Program.MachineName + "', '" + Program.LocalIpAddress + "')";
            SqlCommand CM2 = new SqlCommand(sql, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();
        }

        private void chk_addNew_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_addNew.Checked == true)
            {
                chk_STSacctive.Checked = true;
                txt_idvendor.Clear(); txt_findName.Clear();
                txt_findName.Enabled = false;              
                chk_STSacctive.Enabled = true;
                dtg_vendor.Enabled = false;
                btn_vendorFind.Enabled = true;
            }
            else {
                btn_vendorFind.Enabled = false;
                chk_STSacctive.Checked = false;
                txt_findName.Enabled = true;              
                chk_STSacctive.Enabled = false;
                dtg_vendor.Enabled = true;
            }

        }

        private void dtg_vendor_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                chk_STSacctive.Enabled = true;
                VendorGPay=Convert.ToInt16(dtg_vendor.Rows[e.RowIndex].Cells[0].Value.ToString());
                txt_idvendor.Text= dtg_vendor.Rows[e.RowIndex].Cells[1].Value.ToString();
                lbl_vendorName.Text = dtg_vendor.Rows[e.RowIndex].Cells[2].Value.ToString();

                if (dtg_vendor.Rows[e.RowIndex].Cells[3].Value.ToString() == "True")
                {
                    chk_STSacctive.Checked = true;
                }
                else { chk_STSacctive.Checked = false; }

                cb_vendorGroup.SelectedValue= dtg_vendor.Rows[e.RowIndex].Cells[6].Value.ToString();
            }

            catch { }
        }

        private void txt_findName_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            dtg_vendor.DataSource = null;

            if (cb_vendorGroup.SelectedIndex > -1)
            {
                string sql = "SELECT [VendorGPay] AS 'ลำดับที่', [Vendor_No] AS 'รหัสผู้ขาย',[Vendor_Name] AS 'ชื่อผู้ขาย',[StsActive] AS 'สถานะใช้' FROM  [dbo].[V_VendorGroup]  WHERE [VendorGroupID]= '" + cb_vendorGroup.SelectedValue.ToString() + "' AND  Vendor_Name Like'%" + txt_findName.Text.Trim() + "%' ";

                SqlDataAdapter da1 = new SqlDataAdapter(sql, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_l");
                dtg_vendor.DataSource = ds1.Tables["g_l"];
                con.Close();

                tool_countItem.Text ="Items: "+ dtg_vendor.RowCount.ToString() + " Data";

                dtg_vendor.Columns[0].Width = 100;
                dtg_vendor.Columns[1].Width = 200;
                //dtg_vendor.Columns[6].Width = 0;
            }

        }
    }
}
