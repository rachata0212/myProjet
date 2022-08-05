using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Truck_Analytics
{
    public partial class F_VendorDetail : Form
    {
        public F_VendorDetail()
        {
            InitializeComponent();
        }

        int TombonId = 0;

        private void F_VendorDetail_Load(object sender, EventArgs e)
        {
            Load_Owner();
            Load_Tambon();
            Load_Amphor();
            Load_Provice();
        }

        private void Load_VendorGroup()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                dtg_vendorGroup.DataSource = null;

                string sql = "SELECT [VendorGPay] AS 'ลำดับที่', [Vendor_No] AS 'รหัสผู้ขาย',[VendorGroupID] AS 'รหัสกลุ่ม',[VendorGroupName] AS 'ชื่อกลุ่ม',[StsActive] AS 'สถานะใช้งาน' FROM [dbo].[V_VendorGroup]  WHERE [Vendor_No]= '" + txt_idVendor.Text + "'";

                SqlDataAdapter da1 = new SqlDataAdapter(sql, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_l");
                dtg_vendorGroup.DataSource = ds1.Tables["g_l"];
                con.Close();

                dtg_vendorGroup.Columns[0].Width = 100;
                dtg_vendorGroup.Columns[1].Width = 120;
                dtg_vendorGroup.Columns[2].Width = 120;
                dtg_vendorGroup.Columns[4].Width = 120;
            }
            catch { }
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

        private void txt_searchName_TextChanged(object sender, EventArgs e)
        {
            Initialize_SearchVendor_ComboBox();
        }
             

        private void Initialize_SearchVendor_ComboBox()
        {
            mtCo_searchName.Clear();
            mtCo_searchName.SourceDataString = new string[6] { "Vendor_No", "Names", "Address", "TambonName", "AmphurName", "ProvinceName" };
            mtCo_searchName.ColumnWidth = new string[6] { "80", "220", "280", "80", "80", "100" };
            mtCo_searchName.DataSource = GetDataSource_Vendor();

            btn_SearchVendor.ForeColor = Color.Blue;
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

        private void btn_SearchVendor_Click(object sender, EventArgs e)
        {          
                Load_Owner();
                Load_SearchNew_Record();
                Load_VendorGroup();
                Search_Type();                  
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

        private void btn_groupVendor_Click(object sender, EventArgs e)
        {
            F_VendorGrup FVG = new F_VendorGrup();
            FVG.ShowDialog();
        }

     
        private void Load_Tambon()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            SqlCommand cmd = new SqlCommand(" Select [TombonId],[TambonName]  From [dbo].[TamBon] ", con);
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
            SqlCommand cmd = new SqlCommand(" Select [AmphurId],[AmphurName]  From [dbo].[Amphur] ", con);
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
            SqlCommand cmd = new SqlCommand(" Select [ProvinceId],[ProvinceName]  From [dbo].[Province] ", con);
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

        private void cbo_amphor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbt_porvice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbo_tambon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void Load_Amphor_SelectTambon()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            SqlCommand cmd = new SqlCommand(" Select [AmphurId],[AmphurName]  From [dbo].[Amphur] Where [AmphurId] ", con);
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


        private void chk_searchAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_searchAddress.Checked == true)
            {
                gb_searchAddress.Enabled = true;
                txt_searchAddress.Focus();
            }
            else { gb_searchAddress.Enabled = false;
                rdo_tambon.Checked = false;
                rdo_amphor.Checked = false;
                rdo_provice.Checked = false;
                txt_searchAddress.Clear();
                mtCo_searchAddress.Clear();
            }
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
                    sql = "SELECT [TombonId] AS 'รหัสตำบล',Trim([TambonName]) AS 'ชื่อตำบล/แขวง',Trim([AmphurName]) AS 'ชื่ออำเภอ/เขต',Trim ([ProvinceName]) AS 'ชื่อจังหวัด',Trim([ZipCode]) AS 'รหัสไปรษณีย์' FROM [dbo].[V_Vendor] Where [TambonName] like '%" + txt_searchAddress.Text.Trim() + "%'";
                }

                if (rdo_amphor.Checked == true)
                {
                    sql = "SELECT [TombonId] AS 'รหัสตำบล',Trim([TambonName]) AS 'ชื่อตำบล/แขวง',Trim([AmphurName]) AS 'ชื่ออำเภอ/เขต',Trim ([ProvinceName]) AS 'ชื่อจังหวัด',Trim([ZipCode]) AS 'รหัสไปรษณีย์' FROM [dbo].[V_Vendor] Where [AmphurName] like '%" + txt_searchAddress.Text.Trim() + "%'";
                }

                if (rdo_provice.Checked == true)
                {
                    sql = "SELECT [TombonId] AS 'รหัสตำบล',Trim([TambonName]) AS 'ชื่อตำบล/แขวง',Trim([AmphurName]) AS 'ชื่ออำเภอ/เขต',Trim ([ProvinceName]) AS 'ชื่อจังหวัด',Trim([ZipCode]) AS 'รหัสไปรษณีย์' FROM [dbo].[V_Vendor] Where [ProvinceName] like '%" + txt_searchAddress.Text.Trim() + "%'";
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



        private void btn_searchAddress_Click(object sender, EventArgs e)
        {
            TombonId = Convert.ToInt32(mtCo_searchAddress.SelectedItem.Value.ToString());
            Search_Type();
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

        private void btn_googleMap_Click(object sender, EventArgs e)
        {
            string URL_MAP = "https://www.google.co.th/maps/@" + txt_latitude.Text.Trim() + "," + txt_longitude.Text.Trim() + ".15z";

            System.Diagnostics.Process.Start("https://www.google.co.th/maps/@" + txt_latitude.Text.Trim() + "," + txt_longitude.Text.Trim() + ".15z");

            //https://www.google.co.th/maps/@13.7237436,100.5183629,15z
        }

        private void chk_newVendor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter1 = new SqlDataAdapter();
            //con1.Open();

            con.Open();
            String sql = "UPDATE [dbo].[Vendor] SET [Names] = '" + txt_name.Text.Trim() + "' ,[Address] ='" + txt_address.Text.Trim() + "' ,[TombonId] =" + cbo_tambon.SelectedValue.ToString().Trim() + ",[Phone_No] = '" + txt_mobileNo.Text.Trim() + "' ,[Email] = '" + txt_email.Text.Trim() + "' ,[Line_ID] = '" + txt_lineID.Text.Trim() + "' ,[Contact] ='" + txt_nameContach.Text.Trim() + "' ,[OwnerID] = " + cbo_typeSorucRM.SelectedValue.ToString() + ", [Lat_RM_Addr]='" + txt_latitude.Text.Trim() + "' ,[Long_RM_Addr]='" + txt_longitude.Text.Trim() + "' WHERE [Vendor_No] ='" + txt_idVendor.Text.Trim() + "'";
            SqlCommand CM2 = new SqlCommand(sql, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();
                        
            MessageBox.Show("ปรับปรุงข้อมูลสำเร็จ+++", "ผลการบันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Cler_Data();
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






        }

        private void rdo_tambon_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_tambon.Checked == true)
            { txt_searchAddress.Enabled = true; }
            else { txt_searchAddress.Enabled = false; }
        }

        private void rdo_amphor_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_amphor.Checked == true)
            { txt_searchAddress.Enabled = true; }
            else { txt_searchAddress.Enabled = false; }
        }

        private void rdo_provice_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_provice.Checked == true)
            { txt_searchAddress.Enabled = true; }
            else { txt_searchAddress.Enabled = false; }
        }

        private void cbo_typeSorucRM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
