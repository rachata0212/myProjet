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
using System.Globalization;

namespace Truck_Analytics
{
    public partial class F_Search : Form
    {
        public F_Search()
        {
            InitializeComponent();
        }

        public int id_findType = 0;
        public string id_value = "";
        public string id_vendor = "";
        public string name_value = "";
        public string id_bankcode = "";
        public int trucktype = 0;
        public string weighttype = "";
        public string id_product = "";
        public int jobType = 0;       
        string find_Name = "";

        private void F_Search_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();


            //DateTimeFormatInfo dt = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
            this.dtp_date.CustomFormat = "dd/MM/yyyy";
            this.dtp_date.Format = DateTimePickerFormat.Custom;

            if (id_findType == 1)//Search Product ID  หน้าตาชั่งไมอยู่ในกลุ่ม ที่เหลือหน้าหลัก
            {
             
                this.Text = "ค้นหาข้อมูสินค้า";  // ที่ไม่มีในหน้าเร่ิมต้น
                find_Name = "SELECT  [ProductID] AS 'รหัสินค้า',[ProductName] AS 'ชื่อสินค้า' FROM  [dbo].[TB_Products] WHERE [ProductID] <> 'RM-001' AND [ProductID] <> 'RM-004' AND [ProductID] <> 'FG-001'  AND [ProductID] <> 'ST0803-002' AND [StatusActive]=1 Order by [ProductID] ";
                
            }

            if (id_findType == 2)//Search Weight Type
            {               
                this.Text = "ค้นหาประเภทงานชั่ง";
                find_Name = "SELECT  [WeightTypeID] AS 'ประเภทงาน',[WeightTypeName] AS 'ชื่อประเภทงาน' FROM  [dbo].[TB_WeightType] Order by [WeightTypeID]";
         
            }


            if (id_findType == 3)//Search Vendor
            {
                rdo_purchase.Checked = true; rdo_sale.Checked = false;
                this.Text = "ค้นหาข้อมูลผู้ขายสินค้า";
                find_Name = "SELECT  [Vendor_No] AS 'รหัสผู้ขาย',[Names] AS 'ชื่อผู้ขาย',[TambonName] AS 'ตำบล',[AmphurName] AS 'อำเภอ',[ProvinceName] AS 'จังหวัด' FROM  [dbo].[V_Find_Vendor] Where [Vendor_No] <> '01' AND [Vendor_No] <> '02' AND [Vendor_No] <> 'AP01-0001' AND [Vendor_No] <> 'AP01-0002' Order by [Vendor_No]";
            }


            if (id_findType == 4)//Search Custer
            {
                rdo_sale.Checked = true; rdo_purchase.Checked = false;
                this.Text = "ค้นหาข้อมูลผู้ซื้อสินค้า";
                find_Name = "SELECT  [CustomerID]  AS 'รหัสผู้ซื้อ',[CustomerName] AS 'ชื่อผู้ซื้อ',[TambonName] AS 'ตำบล',[AmphurName]  AS 'อำเภอ',[ProvinceName] AS 'จังหวัด'  FROM [dbo].[V_Find_Customer] Order by [CustomerID]";
            }

            if (id_findType == 5)//Search Type Truck ID
            {               
                this.Text = "ค้นหาข้อมูรถบรรทุก";
                find_Name = "SELECT  [TruckTypeID] AS 'รหัสประเภทรถ',[TruckTypeName] AS 'ชื่อประเภทรถ' FROM [dbo].[TB_TruckType] Order by [TruckTypeID]";
            }

            if (id_findType == 15)//Search trannsport
            {
                this.Text = "ค้นหาข้อมูบริษัทฯขนส่ง";
                find_Name = "SELECT  [TransportID] AS 'รหัสขนส่ง',[TransportName] AS 'ชื่อบริษัทขนส่ง' FROM [dbo].[TB_Transport] Order by [TransportID]";
            }

            //if (id_findType == 6)//Search ID Register - Reprint   // Purchase
            //{
            //    this.Text = "ค้นหาข้อมูการลงทะเบียนงานซื้อ";
            //    find_Name = "SELECT [RegisterInDate] AS 'วันที่'  ,[TicketCodeIn] AS 'เลขที่ตั๋ว' ,[QueueNo] AS 'คิว',[ProductName] AS 'สินค้า' ,[Names] AS 'ชื่อผู้ขาย',[Plate1] AS 'ทะเบียน',[TruckTypeName] AS 'ประเภทรถ',[TruckTypeID],[WeightTypeID],[ProductID] AS 'รหัสสินค้า' FROM [dbo].[V_Ticket_Register] WHERE   DATEPART(year,[RegisterInDate]) = '" + dtp_date.Value.Year + "'  and DATEPART(day, [RegisterInDate]) = '" + dtp_date.Value.Day + "' and DATEPART(month, [RegisterInDate]) = '" + dtp_date.Value.Month + "' ";
            //}

            //if (id_findType == 7)//Search ID Register - Reprint   // Sale
            //{
            //    this.Text = "ค้นหาข้อมูการชั่งสินค้าออก";
            //    find_Name = "SELECT [RegisterInDate] AS 'วันที่ออกตั๋ว',[TicketCodeIn] AS 'รหัสตั๋ว' ,[QueueNo] AS 'คิว',[ProductName] AS 'สินค้า',[CustomerName] AS 'ชื่อผู้ซื้อ',[Plate1] AS 'ทะเบียน',[TruckTypeName] AS 'ประเภทรถ',[ProductID] AS 'รหัสสินค้า' FROM [dbo].[V_Ticket_Register_Sale] WHERE   DATEPART(year,[RegisterInDate]) = '" + dtp_date.Value.Year + "'  and DATEPART(day, [RegisterInDate]) = '" + dtp_date.Value.Day + "' and DATEPART(month, [RegisterInDate]) = '" + dtp_date.Value.Month + "' ";

            //}

            if (id_findType == 8)//Search Employee on AD
            {
             
                this.Text = "ค้นหาข้อมูลผู้ใช้งาน";
                find_Name = "SELECT [UserID] AS 'รหัส',[FullUserName] AS 'ชื่อ-นามสกุล',[Email] AS 'อีเมล์' FROM  [dbo].[TB_Users] Order by [UserID]";
            }


            //if (id_findType == 9)//Search Sale
            //{
            //    rdo_purchase.Checked = true;
            //    this.Text = "ค้นหาข้อมูการชั่งสินค้า";

            //    //find_Name = "SELECT [TicketCodeIn] AS 'เลขที่ชั่ง',[RegisterInDate] AS 'วันที่ชั่ง',[CustomerName]  AS 'ชื่อผู้ซื้อ',[Plate1] AS 'ทะเบียน',[TruckTypeName]  AS 'ประเภทรถ' ,[ProductName]  AS 'สินค้า'   ,[QueueNo] AS 'คิวที่' FROM [dbo].[V_WeightData_Sale] Where [proc_type]='W' AND [OutboundWeight] is Null ";

            //}

            if (id_findType == 10)//Search Location
            {
           
                this.Text = "ค้นหาข้อมูลจุดเก็บสินค้า";
                int Id_count = 0;

                try
                {
                    con.Open();
                    string sql1 = "SELECT Count([NO_Zone])AS CountCheck FROM [dbo].[V_LocationZone] WHERE [ProductID] = '" + id_product + "' AND [Product_Vendor]='" + id_vendor + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, con);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    {
                        Id_count = Convert.ToInt16(DR1["CountCheck"].ToString());
                    }
                    DR1.Close();
                    con.Close();
                }
                catch { con.Close(); }

                if (Id_count != 0)
                {
                    find_Name = "SELECT [NO_Zone] AS 'รหัสจัดเก็บ' ,[Name_Zone] AS 'ชื่อจุดเก็บ' ,[UnitINStock]  AS 'คลังคงเหลือ',[QtyName] AS 'ความชื้น' ,[QtyValue] AS 'เกรดสินค้า' ,[QtyRemark] AS 'คำอธิบาย'  FROM  [dbo].[V_LocationZone] WHERE  [ProductID]  ='" + id_product + "' AND [Product_Vendor]='" + id_vendor + "'";
                }
                                                                                                          

              else
                {
                    find_Name = "SELECT [NO_Zone] AS 'รหัสจัดเก็บ' ,[Name_Zone] AS 'ชื่อจุดเก็บ' ,[UnitINStock]  AS 'คลังคงเหลือ',[QtyName] AS 'ความชื้น' ,[QtyValue] AS 'เกรดสินค้า' ,[QtyRemark] AS 'คำอธิบาย'  FROM  [dbo].[V_LocationZone] WHERE  [ProductID]  ='" + id_product + "'";
                }
              

            }


            if (id_findType == 11)//Search Product ID
            {            
                this.Text = "ค้นหาข้อมูสินค้า";
                find_Name = "SELECT  [ProductID] AS 'รหัสสินค้า',[ProductName] AS 'ชื่อสินค้า' FROM  [dbo].[TB_Products] Where [StatusActive]=1 ";
            }
                                 
            
            if (find_Name != "")
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(find_Name, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "g_v");
                dtg_data.DataSource = ds.Tables["g_v"];
                con.Close();

                dtg_data.Columns[0].Width = 200;
                rdo_purchase.Enabled = false;
                rdo_sale.Enabled = false;
                dtp_date.Enabled = false;
            }

            // adjust column
            if (id_findType == 13 || id_findType == 14)//Search Vendor NAV OR Customer
            {
                
                string SQL = "";
                if (id_findType == 13)//Search Vendor NAV
                {
                    SQL = "SELECT [No_] AS 'รหัส',[Name] AS 'ชื่อผู้ขาย',[Vendor Bank] AS 'รหัสธนาคาร' FROM [Sapthip_LIVE].[dbo].[Sapthip LIVE$Vendor]";
                }


                if (id_findType == 14)//Search Customer NAV
                {
                    SQL = "SELECT [No_] AS 'รหัส',[Name] AS 'ชื่อผู้ขาย'  FROM [Sapthip_LIVE].[dbo].[Sapthip LIVE$Customer]";
                }

                SqlConnection con1 = new SqlConnection("Data Source=192.168.168.14; uid=sync_app; pwd=sync@1qaz2wsx;database=Sapthip_LIVE;");
                con1.Open();
                SqlDataAdapter da = new SqlDataAdapter(SQL, con1);
                DataSet ds = new DataSet();
                da.Fill(ds, "g_v");
                dtg_data.DataSource = ds.Tables["g_v"];
                con1.Close();

                id_value = "";
                rdo_purchase.Enabled = false;
                rdo_sale.Enabled = false;
                dtp_date.Enabled = false;
            }


            if (dtg_data.RowCount > 0)
            {
                Adjust_sizeColume();
            }
        }

        private void Adjust_sizeColume()
        {

            if (id_findType == 1)
            {
                dtg_data.Columns[0].Width = 180;

            }


            if (id_findType == 6 && rdo_purchase.Checked==true)
            {
                dtg_data.Columns[0].Width = 180;
                dtg_data.Columns[1].Width = 130;
                dtg_data.Columns[2].Width = 80;
                dtg_data.Columns[3].Width = 150;
                dtg_data.Columns[4].Width = 280;
                dtg_data.Columns[5].Width = 120;
                dtg_data.Columns[6].Width = 120;
                dtg_data.Columns[7].Visible = false;
                dtg_data.Columns[8].Visible = false;

                rdo_purchase.Enabled = true;
                rdo_purchase.Checked = true;
                dtp_date.Enabled = true;
            }

            if (id_findType == 6 && rdo_sale.Checked == true)
            {
                dtg_data.Columns[0].Width = 180;
                dtg_data.Columns[1].Width = 130;
                dtg_data.Columns[2].Width = 80;
                dtg_data.Columns[3].Width = 150;
                dtg_data.Columns[4].Width = 280;
                dtg_data.Columns[5].Width = 120;
                dtg_data.Columns[6].Width = 120;

                rdo_sale.Enabled = true;
                rdo_sale.Checked = true;
                dtp_date.Enabled = true;


            }

            if (id_findType == 10)
            {
                dtg_data.Columns[0].Width = 100;
                dtg_data.Columns[1].Width = 150;
                dtg_data.Columns[2].Width = 220;
                dtg_data.Columns[3].Width = 100;
                dtg_data.Columns[4].Width = 200;

            }

            

            for (int i = 0; i < dtg_data.RowCount; i++)
            {
                if (i % 2 == 0)
                {
                    dtg_data.Rows[i].DefaultCellStyle.BackColor = Color.Bisque;
                }

                else { dtg_data.Rows[i].DefaultCellStyle.BackColor = Color.White; }

            }

            tool_count.Text = "จำนวน: " + dtg_data.RowCount.ToString() + " ข้อมูล ";
            dtg_data.ClearSelection();
        }

        private void Search_Data()
        {
            int year = dtp_date.Value.Year;

            if (rdo_purchase.Checked == true)
            {
                if (id_findType == 3 )//Search Vedor
                {
                    rdo_purchase.Checked = true;
                    this.Text = "ค้นหาข้อมูลผู้ขายสินค้า";

                    if (rdo_findId.Checked == true)
                    {
                        find_Name = "SELECT  [Vendor_No] AS 'รหัสผู้ขาย',[Names] AS 'ชื่อผู้ขาย',[TambonName] AS 'ตำบล',[AmphurName] AS 'อำเภอ',[ProvinceName] AS 'จังหวัด' FROM  [dbo].[V_Find_Vendor] Where  [Vendor_No] Like '%" + txt_findName.Text.Trim() + "%' Order by [Vendor_No]";

                        //find_Name = "SELECT  [Vendor_No] AS 'รหัสผู้ขาย',[Names] AS 'ชื่อผู้ขาย',[TambonName] AS 'ตำบล',[AmphurName] AS 'อำเภอ',[ProvinceName] AS 'จังหวัด' FROM  [dbo].[V_Find_Vendor] Where [Vendor_No] <> '01' AND [Vendor_No] <> '02' AND [Vendor_No] <> 'AP01-0001' AND [Vendor_No] <> 'AP01-0002' AND [Vendor_No] Like '%" + txt_findName.Text.Trim() + "%' Order by [Vendor_No]";
                    }

                    if (rdo_findName.Checked == true)
                    {
                        find_Name = "SELECT  [Vendor_No] AS 'รหัสผู้ขาย',[Names] AS 'ชื่อผู้ขาย',[TambonName] AS 'ตำบล',[AmphurName] AS 'อำเภอ',[ProvinceName] AS 'จังหวัด' FROM  [dbo].[V_Find_Vendor] Where  [Names] Like '%" + txt_findName.Text.Trim() + "%' Order by [Vendor_No]";

                        //find_Name = "SELECT  [Vendor_No] AS 'รหัสผู้ขาย',[Names] AS 'ชื่อผู้ขาย',[TambonName] AS 'ตำบล',[AmphurName] AS 'อำเภอ',[ProvinceName] AS 'จังหวัด' FROM  [dbo].[V_Find_Vendor] Where [Vendor_No] <> '01' AND [Vendor_No] <> '02' AND [Vendor_No] <> 'AP01-0001' AND [Vendor_No] <> 'AP01-0002' AND [Names] Like '%" + txt_findName.Text.Trim() + "%' Order by [Vendor_No]";
                    }
                }
            
                if (id_findType == 6)//Search job Register,Truck in,Out - Reprint   // Purchase
                {
                    this.Text = "ค้นหาข้อมูลงานซื้อสินค้า";
                    find_Name = "SELECT [RegisterInDate] AS 'วันที่'  ,[TicketCodeIn] AS 'เลขที่ตั๋ว' ,[QueueNo] AS 'คิว',[ProductName] AS 'สินค้า' ,[Names] AS 'ชื่อผู้ขาย',[Plate1] AS 'ทะเบียน',[TruckTypeName] AS 'ประเภทรถ',[TruckTypeID],[WeightTypeID],[ProductID] AS 'รหัสสินค้า',[proc_name] AS 'กระบวนการ'  FROM [dbo].[V_Ticket_Register] WHERE [Names] Like '%" + txt_findName.Text.Trim() + "%' AND DATEPART(year,[RegisterInDate]) = '" + dtp_date.Value.Year + "'  and DATEPART(day, [RegisterInDate]) = '" + dtp_date.Value.Day + "' and DATEPART(month, [RegisterInDate]) = '" + dtp_date.Value.Month + "' ";
                } 
            }


            if (rdo_sale.Checked == true)
            {

                if (id_findType == 4)//Search Custer
                {
                    rdo_sale.Checked = true;
                    this.Text = "ค้นหาข้อมูลผู้ซื้อสินค้า";

                    if (rdo_findId.Checked == true)
                    {
                        find_Name = "SELECT  [CustomerID]  AS 'รหัสผู้ซื้อ',[CustomerName] AS 'ชื่อผู้ซื้อ',[TambonName] AS 'ตำบล',[AmphurName]  AS 'อำเภอ',[ProvinceName] AS 'จังหวัด'  FROM  [dbo].[V_Find_Customer] Where [CustomerID] Like '%" + txt_findName.Text.Trim() + "%' Order by [CustomerID]";
                    }
                    if (rdo_findName.Checked == true)
                    {
                        find_Name = "SELECT  [CustomerID]  AS 'รหัสผู้ซื้อ',[CustomerName] AS 'ชื่อผู้ซื้อ',[TambonName] AS 'ตำบล',[AmphurName]  AS 'อำเภอ',[ProvinceName] AS 'จังหวัด'  FROM  [dbo].[V_Find_Customer] Where [CustomerName] Like '%" + txt_findName.Text.Trim() + "%' Order by [CustomerID]";
                    }
                }

                if (id_findType == 6)//Search Ticket out casawaw  //Sale
                {
                    this.Text = "ค้นหาข้อมูลงานขายสินค้า";
                    find_Name = "SELECT [RegisterInDate] AS 'วันที่ออกตั๋ว',[TicketCodeIn] AS 'รหัสตั๋ว',[QueueNo] AS 'คิว',[ProductName] AS 'สินค้า',[CustomerName] AS 'ผู้ซื้อ',[Plate1] AS 'ทะเบียน',[TruckTypeName] AS 'ประเภทรถ',[ProductID] AS 'รหัสสินค้า',[proc_name] AS 'กระบวนการ'  FROM [dbo].[V_PrintTicket_Sale]  WHERE [CustomerName] Like '%" + txt_findName.Text.Trim() + "%' AND  DATEPART(year,[RegisterInDate]) = '" + dtp_date.Value.Year + "'  and DATEPART(day, [RegisterInDate]) = '" + dtp_date.Value.Day + "' and DATEPART(month, [RegisterInDate]) = '" + dtp_date.Value.Month + "' ";
                }                
            }


            if (id_findType == 13)//Search Vendor NAV
            {
                this.Text = "ค้นหาผู้ขายสินค้า";

                if (rdo_findId.Checked == true)
                {
                    find_Name = "SELECT [Vendor_No] AS 'รหัส',[Names] AS 'ชื่อผู้ขาย' FROM [dbo].[Vendor] WHERE [Vendor_No] Like '%" + txt_findName.Text.Trim() + "%'";
                }

                if (rdo_findName.Checked == true)
                {
                    find_Name = "SELECT [Vendor_No] AS 'รหัส',[Names] AS 'ชื่อผู้ขาย' FROM [dbo].[Vendor] WHERE [Names] Like '%" + txt_findName.Text.Trim() + "%'";
                }

            }


            if (id_findType == 14)//Search Customer NAV
            {
                this.Text = "ค้นหาผู้ซื้อสินค้า";

                if (rdo_findId.Checked == true)
                {
                    find_Name = "SELECT [CustomerID] AS 'รหัส',[CustomerName] AS 'ชื่อผู้ซื้อ' FROM [dbo].[TB_Customers] Where [CustomerID] Like '%" + txt_findName.Text.Trim() + "%'";
                }

                if (rdo_findName.Checked == true)
                {
                    find_Name = "SELECT [CustomerID] AS 'รหัส',[CustomerName] AS 'ชื่อผู้ซื้อ' FROM [dbo].[TB_Customers] Where [CustomerName] Like '%" + txt_findName.Text.Trim() + "%'";
                }
            }
                     
                       
            if (find_Name != "")
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(find_Name, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "g_v");
                dtg_data.DataSource = ds.Tables["g_v"];
                con.Close();

                if (dtg_data.RowCount > 0)
                {
                    Adjust_sizeColume();
                }
            }
        }

        private void dtg_data_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                if (id_findType == 1 || id_findType == 2 || id_findType == 3 || id_findType == 4 || id_findType == 5 || id_findType == 8 || id_findType == 10 || id_findType == 11 || id_findType == 15)
                {
                    id_value = dtg_data.Rows[e.RowIndex].Cells[0].Value.ToString();   // id ticket no
                    name_value = dtg_data.Rows[e.RowIndex].Cells[1].Value.ToString();

                }

                if (id_findType == 6)
                {
                    id_value = dtg_data.Rows[e.RowIndex].Cells[1].Value.ToString();
                                      

                    if (rdo_purchase.Checked == true)
                    {
                        weighttype = dtg_data.Rows[e.RowIndex].Cells[8].Value.ToString();
                        trucktype = Convert.ToInt16(dtg_data.Rows[e.RowIndex].Cells[7].Value.ToString()); //id truck type
                        id_product = dtg_data.Rows[e.RowIndex].Cells[9].Value.ToString();
                    }

                    if (rdo_sale.Checked == true)
                    {
                        id_product = dtg_data.Rows[e.RowIndex].Cells[7].Value.ToString();
                    }
                }               
                               

                if (id_findType == 13 || id_findType == 14)
                {
                    id_value = dtg_data.Rows[e.RowIndex].Cells[0].Value.ToString();
                    name_value = dtg_data.Rows[e.RowIndex].Cells[1].Value.ToString();

                    if (id_findType == 13)
                    {
                        id_bankcode = dtg_data.Rows[e.RowIndex].Cells[2].Value.ToString();
                    }
                }



                //if (id_findType == 7)
                //{
                //    id_product = dtg_data.Rows[e.RowIndex].Cells[5].Value.ToString();
                //}

                //if (rdo_purchase.Checked == true) { jobType = 1; }
                //if (rdo_sale.Checked == true) { jobType = 2; }
            }

            catch { }

            finally
            {
                if (rdo_purchase.Checked == true)
                {
                    jobType = 1;
                }
                if (rdo_sale.Checked == true)
                {
                    jobType = 2;
                }
              
            }


            if (id_value !="")
            {
                this.Close();
            }
        }

        private void rdo_purchase_CheckedChanged(object sender, EventArgs e)
        {        
            Search_Data();
        }

        private void rdo_sale_CheckedChanged(object sender, EventArgs e)
        {            
            Search_Data();
        }

        private void dtp_date_ValueChanged(object sender, EventArgs e)
        {
            Search_Data();
        }

        private void dtg_data_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                if (id_findType == 6)
                {
                    tool_selectitem.Text = dtg_data.Rows[e.RowIndex].Cells[1].Value.ToString() + ": " + dtg_data.Rows[e.RowIndex].Cells[3].Value.ToString();
                }

                else
                {
                    tool_selectitem.Text = dtg_data.Rows[e.RowIndex].Cells[0].Value.ToString() + ": " + dtg_data.Rows[e.RowIndex].Cells[1].Value.ToString();
                }
            }
            catch { }
        }

        private void txt_findName_TextChanged(object sender, EventArgs e)
        {
            Search_Data();
        }
    }
}
