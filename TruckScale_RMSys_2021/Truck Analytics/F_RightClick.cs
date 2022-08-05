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
    public partial class F_RightClick : Form
    {
        public F_RightClick()
        {
            InitializeComponent();
        }

        public string ID_Vendor = "";
        public string ID_Product = "";
        public string VendorGroupID = "";
        public string ID_VednroGPay = "";
        private void F_rightClice_Load(object sender, EventArgs e)
        {
            Load_VendorGrup();
        }

        private void Load_SPVendorGroupDetail()
        {
            if (VendorGroupID != "")
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                con.Open();
                //string sql2 = "SELECT [PaysetID] AS 'รหัสกลุ่ม', [PriceFac] AS 'ราคาโรงงาน' ,[UnitName] AS 'หน่วยน้ำหนัก' ,[DateActive] AS 'สถานะ' ,[StDate] AS 'วันที่เริ่ม' ,[EdDate] AS 'วันที่สิ้นสุด'  ,[DocAppNo] AS 'เอกสารอนุมัติ'  FROM  [dbo].[V_PaymentSettingGroup]  WHERE [VendorGroupID] ='" + VendorGroupID + "'";
                string sql2 = "SELECT [PaysetID] AS 'รหัสกลุ่ม', [PriceFac] AS 'ราคาหน้าป้าย' ,[UnitName] AS 'หน่วย' ,[DateActive] AS 'จำกัดวันรับ' ,[StDate] AS 'วันเริ่มรับ' ,[EdDate] AS 'วันสิ้นสุดรับ'  ,[DocAppNo] AS 'เอกสารอนุมัติ'  FROM  [dbo].[V_PaymentSettingGroup]  WHERE [VendorGroupID] ='" + VendorGroupID + "' AND [ProductID]='" + ID_Product + "'";

                SqlDataAdapter da1 = new SqlDataAdapter(sql2, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "v_spVdgroupDetail");
                dtg_SPvendorDetail.DataSource = ds1.Tables["v_spVdgroupDetail"];
                con.Close();
            }
        }

        private void Load_VendorGrup()
        {
            try
            {
                if (ID_Vendor != "")
                {
                    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                    con.ConnectionString = Program.pathdb_Weight;
                    con.Open();                 
              
                    SqlCommand cmd = new SqlCommand("SELECT  [VendorGPay],[VendorGroupName] FROM  [dbo].[V_CalPayment_VenGroup]  WHERE  Vendor_No = '" + ID_Vendor + "' AND [ProductID]='" + ID_Product + "' ", con);
                    DataSet ds1 = new DataSet();
                    //ds.Clear();
                    SqlDataAdapter da1 = new SqlDataAdapter();
                    da1.SelectCommand = cmd;
                    da1.Fill(ds1);
                    //Load product tab weight scale Setup
                    cbo_group.DataSource = ds1.Tables[0];
                    cbo_group.DisplayMember = "VendorGroupName";
                    cbo_group.ValueMember = "VendorGPay";

                    cbo_group.Text = " -- เลือกกลุ่ม -- ";
           
                    con.Close();
                }
            }
            catch { }


        }

        private void cbo_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_group.SelectedIndex > -1)
            {
                ID_VednroGPay = cbo_group.SelectedValue.ToString();
                Load_DetailGroup();
                Load_SPVendorGroupDetail(); 
            }
        }

        private void Load_DetailGroup()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql6 = "SELECT [VendorGroupID] FROM  [dbo].[V_CalPayment_VenGroup]  WHERE  [VendorGPay] = " + cbo_group.SelectedValue.ToString().Trim() + "";
                SqlCommand CM6 = new SqlCommand(sql6, con);
                SqlDataReader DR6 = CM6.ExecuteReader();

                DR6.Read();
                {
                    lbl_groupName.Text = DR6["VendorGroupID"].ToString().Trim();
                }
                DR6.Close();
                con.Close();

                VendorGroupID = lbl_groupName.Text.Trim();

            }
            catch { }

        }

        private void btn_close_Click(object sender, EventArgs e)
        {            
            this.Close();
        }
    }
}
