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
    public partial class F_GroupMNT : Form
    {
        public F_GroupMNT()
        {
            InitializeComponent();
        }

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

        private void btn_save_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                int VendorGroup_Status = 0;
                if (chk_Sts.Checked == true)
                { VendorGroup_Status = 1; }


                if (cb_addNew.Checked == true) // New Record
                {
                    con.Open();
                    string sql = "Insert Into [VendorGroup] ([VendorGroupID],[VendorGroupName],[VendorGroup_Status]) Values('" + txt_idGroup.Text.Trim() + "', '" + txt_namGroupt.Text.Trim() + "'," + VendorGroup_Status + ")";
                    SqlCommand CM2 = new SqlCommand(sql, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    con.Close();
                                   

                    con.Open();
                    string sql1 = "Insert Into  [dbo].[TB_PaymentSetting] ([ProductID],[VendorGroupID],[UnitID]) Values('" + cb_Payproduct_True.SelectedValue.ToString() + "', '" + txt_idGroup.Text.Trim() + "',1 )";
                    SqlCommand CM1 = new SqlCommand(sql1, con);
                    SqlDataReader DR1 = CM1.ExecuteReader();
                    con.Close();

                    Msg = "VendorGroup";
                    Log_NewValue = "VendorGroupID =" + txt_idGroup.Text.Trim() +
            "," + "VendorGroupName = " + txt_namGroupt.Text.Trim() +
            "," + "VendorGroup_Status = " + VendorGroup_Status.ToString();

                    Log_OldValue = "-";
                    Class_Log CL = new Class_Log();
                    CL.tbname = Msg;
                    CL.oldvalue = Log_OldValue;
                    CL.newvalue = Log_NewValue;
                    CL.Save_log();



                }

                else  // Edit Record
                {
                    con.Open();
                    string sql1 = "Update [VendorGroup] Set VendorGroupName ='" + txt_namGroupt.Text + "',[VendorGroup_Status] = " + VendorGroup_Status + "  Where [VendorGroupID] = '" + txt_idGroup.Text.Trim() + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, con);
                    SqlDataReader DR1 = CM1.ExecuteReader();
                    con.Close();

                    con.Open();
                    string sql2 = "Update [TB_PaymentSetting] Set ProductID ='" + cb_Payproduct_True.SelectedValue.ToString() + "' Where [VendorGroupID] = '" + txt_idGroup.Text.Trim() + "'";
                    SqlCommand CM2 = new SqlCommand(sql2, con);
                    SqlDataReader DR2 = CM1.ExecuteReader();
                    con.Close();
                                                                                                                                                                     
                    Msg = "VendorGroup";
                    Log_NewValue = "VendorGroupName =" + txt_namGroupt.Text.Trim() +
            "," + "VendorGroup_Status = " + VendorGroup_Status.ToString() +
            "," + "Where VendorGroupID= " + txt_idGroup.Text;

                    Log_OldValue = "-";
                    Class_Log CL = new Class_Log();
                    CL.tbname = Msg;
                    CL.oldvalue = Log_OldValue;
                    CL.newvalue = Log_NewValue;
                    CL.Save_log();

                }

                Load_group();
            }
            catch { MessageBox.Show("รหัสกลุ่มซ้ำ กรุณาเปลี่ยนรหัสใหม่","บันทึกข้อมูลผิดพลาด!!",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void F_GroupMNT_Load(object sender, EventArgs e)
        {
            Load_group();
            Load_Product();
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
        private void Load_group()
        {
            
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            string sql = "SELECT [VendorGroupID] AS 'รหัส',[VendorGroupName] AS 'ชื่อกลุ่ม',[VendorGroup_Status] AS 'สถานะเปิดใช้งาน' FROM  [dbo].[VendorGroup]";
            SqlDataAdapter da1 = new SqlDataAdapter(sql, con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "g_l");
            dtg_group.DataSource = ds1.Tables["g_l"];
            con.Close();
            dtg_group.Columns[0].Width = 100;
        }

        private void dtg_group_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                cb_addNew.Checked = false;
                txt_idGroup.Text = dtg_group.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_namGroupt.Text = dtg_group.Rows[e.RowIndex].Cells[1].Value.ToString();

                if (dtg_group.Rows[e.RowIndex].Cells[2].Value.ToString() == "True")
                {
                    chk_Sts.Checked = true;
                }
                else { chk_Sts.Checked = false;}
            }
        }

        private void cb_addNew_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_addNew.Checked == true)
            {
                txt_idGroup.Clear();
                txt_namGroupt.Clear();
                chk_Sts.Checked = false;
            }
        }
    }
}
