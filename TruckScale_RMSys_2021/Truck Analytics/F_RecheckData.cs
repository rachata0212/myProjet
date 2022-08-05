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
using System.Globalization;

namespace Truck_Analytics
{
    public partial class F_RecheckData : Form
    {
        public F_RecheckData()
        {
            InitializeComponent();
        }


        public int ID_Recheck = 0;
        int id_filter = 0;

      
        private void F_RecheckData_Load(object sender, EventArgs e)
        {
            //LoadProduct_Combo();

            //if (ID_Recheck == 1)
            //{
            //    ////SELECT [RegisterInDate],[TicketCodeIn],[Plate1],[TruckTypeName],[WeightTypeName],[ProductID],[ProductName] ,[QueueNo],[NameVen],[proc_type] ,[prot_form]  ,[WeightDate] ,[InboundDate] ,[InboundWeight] ,[OutboundDate] ,[OutboundWeight]  FROM  [dbo].[V_WeightData]

            //    //con.Open();

            //    //// string sql = "Select * From [dbo].[V_InuptLab] ";
            //    //sql1 = "SELECT [RegisterInDate],[TicketCodeIn],[Plate1],[TruckTypeName],[WeightTypeName],[ProductID],[ProductName] ,[QueueNo],[NameVen],[proc_type] ,[proc_name]  ,[WeightDate] ,[InboundDate] ,[InboundWeight] ,[OutboundDate] ,[OutboundWeight]  FROM  [dbo].[V_WeightData] WHERE  DATEPART(year,[RegisterInDate]) = '" + year_convert  + "'  and  DATEPART(day,[RegisterInDate]) = '" + DateTime.Now.Day + "' and  DATEPART(month,[RegisterInDate]) = '" + DateTime.Now.Month + "' ";
            //    LoadData();

            //}
            if (Program.DB_Name != "SapthipNewDB")
            {
                textBox1.BackColor = Color.Crimson;
            }
        }
        

        private void dtp_date_ValueChanged(object sender, EventArgs e)
        {
            Load_Follow();  
        }

        private void cbo_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadData();
        }

        private void cbo_filterProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Load_ProDTG();
        }

        private void rdo_sale_CheckedChanged(object sender, EventArgs e)
        {
            Load_Follow();                     
        }

        private void rdo_pur_CheckedChanged(object sender, EventArgs e)
        {           
            Load_Follow();              
        }

        private void Load_StatusProcess()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            string sql1 = "";
            dtg_recheck.DataSource = null;
            string year_convert = Convert.ToString(dtp_date.Value.Year, CultureInfo.CreateSpecificCulture("en-US"));

            try
            {
                if (rdo_pur.Checked == true)
                {
                    if (chk_normal.Checked == true)
                    {
                        //if (rdo_recheck.Checked == true)
                        //{
                            
                        //}
                        //else
                        //{
                        //    sql1 = "SELECT [RegisterInDate] AS 'วันที่' ,[TicketCodeIn] AS 'เลขที่บัตรชั่ง',[proc_name] AS 'สถานะ', CONVERT(varchar, [RegisterInDate], 108) AS 'เวลา',[TicketCodeIn] AS 'เลขที่ตั๋ว',[QueueNo] AS 'คิว',[ProductName]     AS 'สินค้า'  ,[Plate1] AS 'ทะเบียน' ,[TruckTypeName] AS 'ประเภท'  ,[NameVen] AS 'ผู้ขาย-ซื้อ' FROM [dbo].[V_WeightData]  Where  DATEPART(year,[RegisterInDate]) = '" + year_convert.ToString() + "'  and  DATEPART(day,[RegisterInDate]) = '" + dtp_date.Value.Day.ToString() + "' and  DATEPART(month,[RegisterInDate]) = '" + dtp_date.Value.Month.ToString() + "'";
                        //}
                    }

                    if (chk_auto.Checked == true)
                    {






                    }



                }

                if (rdo_sale.Checked == true)
                {
                    if (chk_normal.Checked == true)
                    {
                        //    if (rdo_recheck.Checked == true)
                        //    {

                      
                        //}

                        //else
                        //{
                        //    sql1 = "SELECT  [RegisterInDate] AS 'วันที่' ,[TicketCodeIn] AS 'เลขที่บัตรชั่ง',[proc_name] AS 'สถานะ', CONVERT(varchar, [RegisterInDate], 108) AS 'เวลา',[TicketCodeIn] AS 'เลขที่ตั๋ว',[QueueNo] AS 'คิว',[ProductName]     AS 'สินค้า'  ,[Plate1] AS 'ทะเบียน' ,[TruckTypeName] AS 'ประเภท'  ,[CustomerName] AS 'ผู้ซื้อ' FROM [dbo].[V_WeightData_Sale]  Where   [proc_name] ='" + cbo_status.SelectedValue.ToString().Trim() + "' AND DATEPART(year,[RegisterInDate]) = '" + year_convert.ToString() + "'  and  DATEPART(day,[RegisterInDate]) = '" + dtp_date.Value.Day.ToString() + "' and  DATEPART(month,[RegisterInDate]) = '" + dtp_date.Value.Month.ToString() + "'";
                        //}
                    }

                    if (chk_auto.Checked == true)
                    {




                    }

                }

                if (sql1 != "")
                {
                    SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1, "g_weightCess");
                    dtg_recheck.DataSource = ds1.Tables["g_weightCess"];
                    con.Close();
                }

            }
            catch
            {
            }

        }  


        private void Load_Follow()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            string sql1 = "";
            dtg_recheck.DataSource = null;
            string year_convert = Convert.ToString(dtp_date.Value.Year, CultureInfo.CreateSpecificCulture("en-US"));

            if (rdo_follow.Checked == true)  //ค้นหาติดตามงานปัจจุบัน
            {
                if (chk_normal.Checked == true)  //งานชั่งปกติ
                {
                    if (rdo_pur.Checked == true)//งานซื้อ
                    {

                        sql1 = "SELECT [no_process] AS 'ลำดับ' ,[TicketCodeIn] AS 'เลขที่บัตรชั่ง',[QueueNo] AS 'คิวที่', [Plate1] AS 'ทะเบียน',[ProductName] AS 'สินค้า',[NameVen] AS 'ผู้ขาย',CONVERT(varchar,[RegisterIn_Datetime],8)    AS 'ตั๋วเข้า'  ,'' AS 'ใช้เวลา1' ,CONVERT(varchar,[Confirm_Simple1_Datetime],8) AS 'วิเคราะห์ 1', '' AS 'ใช้เวลา2' ,CONVERT(varchar,[WeightIn_Datetime],8) AS 'ชั่งเข้า', '' AS 'ใช้เวลา3' ,CONVERT(varchar,[Confirm_Simple2_Datetime],8) AS 'วิเคราะห์ 2', '' AS 'ใช้เวลา4' ,CONVERT(varchar,[WeightOut_Datetime],8) AS 'ชั่งออก', '' AS 'ใช้เวลา5' ,CONVERT(varchar,[RegisterOut_Datetime],8) AS 'ตั๋วออก','' AS 'เวลารวม' FROM [dbo].[V_FollowProcess_Pur]  Where  [WeightTypeID] <> '03' AND DATEPART(year,[RegisterIn_Datetime]) = '" + year_convert.ToString() + "'  and  DATEPART(day,[RegisterIn_Datetime]) = '" + dtp_date.Value.Day.ToString() + "' and  DATEPART(month,[RegisterIn_Datetime]) = '" + dtp_date.Value.Month.ToString() + "' Order by [TicketCodeIn]";
                    }

                    if (rdo_sale.Checked == true) //งาน ขาย
                    {

                        sql1 = "SELECT [no_process] AS 'ลำดับ' ,[TicketCodeIn] AS 'เลขที่บัตรชั่ง',[QueueNo] AS 'คิวที่', [Plate1] AS 'ทะเบียน',[ProductName] AS 'สินค้า',[CustomerName] AS 'ผู้ซื้อ',CONVERT(varchar,[RegisterIn_Datetime],8)    AS 'ตั๋วเข้า'  ,'' AS 'ใช้เวลา1' ,CONVERT(varchar,[Confirm_Simple1_Datetime],8) AS 'วิเคราะห์ 1', '' AS 'ใช้เวลา2' ,CONVERT(varchar,[WeightIn_Datetime],8) AS 'ชั่งเข้า', '' AS 'ใช้เวลา3' ,CONVERT(varchar,[Confirm_Simple2_Datetime],8) AS 'วิเคราะห์ 2', '' AS 'ใช้เวลา4' ,CONVERT(varchar,[WeightOut_Datetime],8) AS 'ชั่งออก', '' AS 'ใช้เวลา5' ,CONVERT(varchar,[RegisterOut_Datetime],8) AS 'ตั๋วออก','' AS 'เวลารวม' FROM  [dbo].[V_FollowProcess_Sale]  Where  [WeightTypeID] <> '03' AND DATEPART(year,[RegisterIn_Datetime]) = '" + year_convert.ToString() + "'  and  DATEPART(day,[RegisterIn_Datetime]) = '" + dtp_date.Value.Day.ToString() + "' and  DATEPART(month,[RegisterIn_Datetime]) = '" + dtp_date.Value.Month.ToString() + "'  Order by [TicketCodeIn]";
                    }
                }


                if (chk_auto.Checked == true)  //งานชั่งปกติ
                {
                    if (rdo_pur.Checked == true)//งานซื้อ
                    {

                        sql1 = "SELECT [no_process] AS 'ลำดับ' ,[TicketCodeIn] AS 'เลขที่บัตรชั่ง',[QueueNo] AS 'คิวที่', [Plate1] AS 'ทะเบียน',[ProductName] AS 'สินค้า',[NameVen] AS 'ผู้ขาย',CONVERT(varchar,[RegisterIn_Datetime],8)    AS 'ตั๋วเข้า'  ,'' AS 'ใช้เวลา1' ,CONVERT(varchar,[Confirm_Simple1_Datetime],8) AS 'วิเคราะห์ 1', '' AS 'ใช้เวลา2' ,CONVERT(varchar,[WeightIn_Datetime],8) AS 'ชั่งเข้า', '' AS 'ใช้เวลา3' ,CONVERT(varchar,[Confirm_Simple2_Datetime],8) AS 'วิเคราะห์ 2', '' AS 'ใช้เวลา4' ,CONVERT(varchar,[WeightOut_Datetime],8) AS 'ชั่งออก', '' AS 'ใช้เวลา5' ,CONVERT(varchar,[RegisterOut_Datetime],8) AS 'ตั๋วออก','' AS 'เวลารวม' FROM [dbo].[V_FollowProcess_Pur]  Where  [WeightTypeID] = '03' AND DATEPART(year,[RegisterIn_Datetime]) = '" + year_convert.ToString() + "'  and  DATEPART(day,[RegisterIn_Datetime]) = '" + dtp_date.Value.Day.ToString() + "' and  DATEPART(month,[RegisterIn_Datetime]) = '" + dtp_date.Value.Month.ToString() + "' Order by [TicketCodeIn]";
                    }

                    if (rdo_sale.Checked == true) //งาน ขาย
                    {

                        sql1 = "SELECT [no_process] AS 'ลำดับ' ,[TicketCodeIn] AS 'เลขที่บัตรชั่ง',[QueueNo] AS 'คิวที่', [Plate1] AS 'ทะเบียน',[ProductName] AS 'สินค้า',[CustomerName] AS 'ผู้ซื้อ',CONVERT(varchar,[RegisterIn_Datetime],8)    AS 'ตั๋วเข้า'  ,'' AS 'ใช้เวลา1' ,CONVERT(varchar,[Confirm_Simple1_Datetime],8) AS 'วิเคราะห์ 1', '' AS 'ใช้เวลา2' ,CONVERT(varchar,[WeightIn_Datetime],8) AS 'ชั่งเข้า', '' AS 'ใช้เวลา3' ,CONVERT(varchar,[Confirm_Simple2_Datetime],8) AS 'วิเคราะห์ 2', '' AS 'ใช้เวลา4' ,CONVERT(varchar,[WeightOut_Datetime],8) AS 'ชั่งออก', '' AS 'ใช้เวลา5' ,CONVERT(varchar,[RegisterOut_Datetime],8) AS 'ตั๋วออก','' AS 'เวลารวม' FROM  [dbo].[V_FollowProcess_Sale]  Where [WeightTypeID] = '03' AND DATEPART(year,[RegisterIn_Datetime]) = '" + year_convert.ToString() + "'  and  DATEPART(day,[RegisterIn_Datetime]) = '" + dtp_date.Value.Day.ToString() + "' and  DATEPART(month,[RegisterIn_Datetime]) = '" + dtp_date.Value.Month.ToString() + "'  Order by [TicketCodeIn]";
                    }
                }






            }


            if (rdo_recheck.Checked == true) //ค้นหาจากสถนะงานชั่ง
            {
                if (chk_normal.Checked == true)
                {
                    if (rdo_pur.Checked == true)
                    {  
                        sql1 = "SELECT[LOGID]  As 'ลำดับ' ,CONVERT(varchar,[RegisterInDate], 103) AS 'วันที่',CONVERT(varchar, [RegisterInDate], 108) AS 'เวลา',[TicketCodeIn] AS 'เลขที่ชั่ง' ,[Plate1] AS 'ทะเบียนรถ',[TruckTypeName] AS 'ประเภทรถ',[WeightTypeName] AS 'ประเภทชั่ง',[ProductID] AS 'รหัสสินค้า' ,[ProductName] AS 'ชื่อสินค้า',[QueueNo] AS 'คิว',[Vendor_No] AS 'รหัสผู้ซื้อ',[NameVen] AS 'ผู้ซื้อ',[proc_name] AS 'สถานะ',[InboundDate] AS 'วันที่ชั่งเข้า',[InboundWeight] AS 'นน.ชั่งเข้า',[OutboundDate] AS 'วันที่ชั่งออก',[OutboundWeight] AS 'นน.ชั่งออก',[GrossWeight] AS 'นน.สุทธิ',[DriveName] AS 'ชื่อผู้ขับ',[TransportName] AS 'ชื่อขนส่ง' ,[UserName] AS 'ผู้ทำรายการ',[HeaderBill_NameCode] AS 'รหัสหัวบิล' ,[Names] AS 'ชื่อหัวบิล' FROM[SapthipNewDB].[dbo].[V_WeightData] Where [WeightTypeID] <> '03' AND DATEPART(year, [RegisterInDate]) = '" + year_convert.ToString() + "'  and DATEPART(day, [RegisterInDate]) = '" + dtp_date.Value.Day.ToString() + "' and DATEPART(month, [RegisterInDate]) = '" + dtp_date.Value.Month.ToString() + "'";
    }

                    if (rdo_sale.Checked == true)
                    {                     
                        sql1 = "SELECT[LOGID]  As 'ลำดับ' ,CONVERT(varchar,[RegisterInDate], 103) AS 'วันที่',CONVERT(varchar, [RegisterInDate], 108) AS 'เวลา',[TicketCodeIn] AS 'เลขที่ชั่ง' ,[Plate1] AS 'ทะเบียนรถ',[TruckTypeName] AS 'ประเภทรถ',[WeightTypeName] AS 'ประเภทชั่ง',[ProductID] AS 'รหัสสินค้า' ,[ProductName] AS 'ชื่อสินค้า',[QueueNo] AS 'คิว',[CustomerID] AS 'รหัสผู้ซื้อ',[CustomerName] AS 'ผู้ซื้อ',[proc_name] AS 'สถานะ',[InboundDate] AS 'วันที่ชั่งเข้า',[InboundWeight] AS 'นน.ชั่งเข้า',[OutboundDate] AS 'วันที่ชั่งออก',[OutboundWeight] AS 'นน.ชั่งออก',[GrossWeight] AS 'นน.สุทธิ',[DriveName] AS 'ชื่อผู้ขับ',[TransportName] AS 'ชื่อขนส่ง' ,[FullUserName] AS 'ผู้ทำรายการ',[HeaderBill_NameCodeCus] AS 'รหัสหัวบิล' ,[Names] AS 'ชื่อหัวบิล' FROM[SapthipNewDB].[dbo].[V_WeightData_Sale] Where [WeightTypeID] <> '03' AND DATEPART(year,[RegisterInDate]) = '" + year_convert.ToString() + "'  and  DATEPART(day,[RegisterInDate]) = '" + dtp_date.Value.Day.ToString() + "' and  DATEPART(month,[RegisterInDate]) = '" + dtp_date.Value.Month.ToString() + "'";
                    }

                }

                if (chk_auto.Checked == true) //งานชั่ง auto
                {
                    if (rdo_pur.Checked == true)//งานซื้อ
                    {

                        sql1 = "SELECT [LOGID] As 'ลำดับ' ,CONVERT(varchar,[RegisterInDate],103)  AS 'วันที่บันทึก' ,[TicketCodeIn] As 'เลขที่ตั๋ว',[Plate1] AS 'ทะเบียนรถ',[WeightTypeName] AS 'ประเภทชั่ง',[ProductID] AS 'รหัสสินค้า' ,[ProductName] AS 'ชื่อสินค้า',[QueueNo]  AS 'คิวที่',[Vendor_No] AS 'รหัสผู้ขาย',[NameVen] AS 'ชื่อผู้ขาย' ,[TruckTypeName] AS 'ประเภทรถ' ,[InboundDate] AS 'วันที่ชั่งเข้า',[InboundWeight] AS 'นน.ชั่งเข้า' ,[OutboundDate] AS 'วันที่ชั่งออก',[OutboundWeight] AS 'นน.ชั่งออก',[GrossWeight] AS 'นน.สทุธิ'   ,[Remark1] AS 'เลข Auto'  FROM [dbo].[V_WeightAuto_PUR]  Where  DATEPART(year,[RegisterInDate]) = '" + year_convert.ToString() + "'  and  DATEPART(day,[RegisterInDate]) = '" + dtp_date.Value.Day.ToString() + "' and  DATEPART(month,[RegisterInDate]) = '" + dtp_date.Value.Month.ToString() + "' Order by [TicketCodeIn]";

                    }

                    if (rdo_sale.Checked == true) //งาน ขาย
                    {

                        sql1 = "SELECT [LOGID] As 'ลำดับ' ,CONVERT(varchar,[RegisterInDate],103)  AS 'วันที่บันทึก' ,[TicketCodeIn] As 'เลขที่ตั๋ว',[Plate1] AS 'ทะเบียนรถ','ชั่งบัตร Auto' AS 'ประเภทชั่ง',[ProductID] AS 'รหัสสินค้า' ,[ProductName] AS 'ชื่อสินค้า',[QueueNo]  AS 'คิวที่',[CustomerID] AS 'รหัสผู้ซื้อ',[CustomerName] AS 'ชื่อผู้ซื้อ' ,[TruckTypeName] AS 'ประเภทรถ' ,[InboundDate] AS 'วันที่ชั่งเข้า',[InboundWeight] AS 'นน.ชั่งเข้า' ,[OutboundDate] AS 'วันที่ชั่งออก',[OutboundWeight] AS 'นน.ชั่งออก',[GrossWeight] AS 'นน.สทุธิ'   ,[Remark1] AS 'เลข Auto' FROM[dbo].[V_WeightAuto_Sale]  Where  DATEPART(year,[RegisterInDate]) = '" + year_convert.ToString() + "'  and  DATEPART(day,[RegisterInDate]) = '" + dtp_date.Value.Day.ToString() + "' and  DATEPART(month,[RegisterInDate]) = '" + dtp_date.Value.Month.ToString() + "'  Order by [TicketCodeIn]";
                    }
                }
            }


            if (sql1 != "")
            {
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_weightCess");
                dtg_recheck.DataSource = ds1.Tables["g_weightCess"];
                con.Close();
            }


            try
            {
                if (dtg_recheck.RowCount > 0)
                {
                    if (rdo_follow.Checked == true)
                    {
                        dtg_recheck.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dtg_recheck.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dtg_recheck.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dtg_recheck.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dtg_recheck.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dtg_recheck.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dtg_recheck.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dtg_recheck.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dtg_recheck.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dtg_recheck.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dtg_recheck.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dtg_recheck.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dtg_recheck.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dtg_recheck.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        dtg_recheck.Columns[0].Width = 70;
                        dtg_recheck.Columns[1].Width = 120;
                        dtg_recheck.Columns[2].Width = 80; //คิว
                        dtg_recheck.Columns[4].Width = 100;
                        dtg_recheck.Columns[5].Width = 160;

                        dtg_recheck.Columns[6].Width = 100;
                        dtg_recheck.Columns[7].Width = 100;
                        dtg_recheck.Columns[8].Width = 100;
                        dtg_recheck.Columns[9].Width = 100;
                        dtg_recheck.Columns[10].Width = 100;
                        dtg_recheck.Columns[11].Width = 100;
                        dtg_recheck.Columns[12].Width = 100;
                        dtg_recheck.Columns[13].Width = 100;
                        dtg_recheck.Columns[14].Width = 100;
                        dtg_recheck.Columns[15].Width = 100;
                        dtg_recheck.Columns[16].Width = 100;

                        Load_CaluseTime();
                    }

                    if (rdo_recheck.Checked == true)
                    {
                        if (chk_normal.Checked == true)
                        {
                            dtg_recheck.Columns[0].Width = 60;
                            dtg_recheck.Columns[1].Width = 90;
                            dtg_recheck.Columns[2].Width = 80; 
                            dtg_recheck.Columns[4].Width = 100;
                            dtg_recheck.Columns[5].Width = 100;
                            dtg_recheck.Columns[6].Width = 100;
                            dtg_recheck.Columns[7].Width = 90;
                            dtg_recheck.Columns[8].Width = 110;
                            dtg_recheck.Columns[9].Width = 70;
                            dtg_recheck.Columns[10].Width = 100;
                            dtg_recheck.Columns[11].Width = 150;
                            dtg_recheck.Columns[12].Width = 110;
                            dtg_recheck.Columns[13].Width = 140;
                            dtg_recheck.Columns[14].Width = 100; 
                            dtg_recheck.Columns[15].Width = 140;
                            dtg_recheck.Columns[16].Width = 100;
                            dtg_recheck.Columns[17].Width = 100;
                            dtg_recheck.Columns[18].Width = 140;
                        }

                        if (chk_auto.Checked == true)
                        {
                            dtg_recheck.Columns[0].Width = 60;
                            dtg_recheck.Columns[1].Width = 110;
                            dtg_recheck.Columns[2].Width = 100; 
                            dtg_recheck.Columns[4].Width = 100;
                            dtg_recheck.Columns[5].Width = 120;

                            dtg_recheck.Columns[6].Width = 100;
                            dtg_recheck.Columns[7].Width = 70;
                            dtg_recheck.Columns[8].Width = 110;
                            dtg_recheck.Columns[9].Width = 180;
                            dtg_recheck.Columns[10].Width = 100;
                            dtg_recheck.Columns[11].Width = 150;
                            dtg_recheck.Columns[12].Width = 100;
                            dtg_recheck.Columns[13].Width = 150;
                            dtg_recheck.Columns[14].Width = 100;
                            dtg_recheck.Columns[15].Width = 100;
                        }
                    }





               
                }

                dtg_recheck.ClearSelection();
                timer1.Enabled = true;
                btn_refresh.Enabled = true;
            }
            catch { }
           

        }

        private void Load_CaluseTime()
        {

            for (int i = 0; i < dtg_recheck.RowCount; i++)
            {
                if (dtg_recheck.Rows[i].Cells[7].Value.ToString() == "") { dtg_recheck.Rows[i].Cells[7].Value = "-"; }
                if (dtg_recheck.Rows[i].Cells[8].Value.ToString() == "") { dtg_recheck.Rows[i].Cells[8].Value = "-"; }
                if (dtg_recheck.Rows[i].Cells[9].Value.ToString() == "") { dtg_recheck.Rows[i].Cells[9].Value = "-"; }
                if (dtg_recheck.Rows[i].Cells[10].Value.ToString() == "") { dtg_recheck.Rows[i].Cells[10].Value = "-"; }
                if (dtg_recheck.Rows[i].Cells[11].Value.ToString() == "") { dtg_recheck.Rows[i].Cells[11].Value = "-"; }
                if (dtg_recheck.Rows[i].Cells[12].Value.ToString() == "") { dtg_recheck.Rows[i].Cells[12].Value = "-"; }
                if (dtg_recheck.Rows[i].Cells[13].Value.ToString() == "") { dtg_recheck.Rows[i].Cells[13].Value = "-"; }
                if (dtg_recheck.Rows[i].Cells[14].Value.ToString() == "") { dtg_recheck.Rows[i].Cells[14].Value = "-"; }
                if (dtg_recheck.Rows[i].Cells[15].Value.ToString() == "") { dtg_recheck.Rows[i].Cells[15].Value = "-"; }
                if (dtg_recheck.Rows[i].Cells[16].Value.ToString() == "") { dtg_recheck.Rows[i].Cells[16].Value = "-"; }
                if (dtg_recheck.Rows[i].Cells[17].Value.ToString() == "") { dtg_recheck.Rows[i].Cells[17].Value = "-"; }

                int D_AHour = 0;
                int D_AMinute = 0;
                int D_ASecound = 0;

                if (i % 2 == 0)
                {
                    dtg_recheck.Rows[i].DefaultCellStyle.BackColor = Color.Bisque;
                }

                else { dtg_recheck.Rows[i].DefaultCellStyle.BackColor = Color.White; }

                                                                                                    
                try
                {
                    //   ใช้เวลา ครั้งที่ 1
                    if (dtg_recheck.Rows[i].Cells[8].Value.ToString() != "-")
                    {
                        DateTime D_ST = Convert.ToDateTime(dtg_recheck.Rows[i].Cells[6].Value.ToString());
                        DateTime D_ED = Convert.ToDateTime(dtg_recheck.Rows[i].Cells[8].Value.ToString());

                        TimeSpan TS = D_ED.Subtract(D_ST);
                        //dtg_recheck.Rows[i].Cells[7].Value = TS.Hours.ToString() + ":" + TS.Minutes.ToString() + ":" + TS.Seconds.ToString("SS");
                        dtg_recheck.Rows[i].Cells[7].Value = TS.ToString(@"hh\:mm\:ss");
                        D_AHour += TS.Hours;
                        D_AMinute += TS.Minutes;
                        D_ASecound += TS.Seconds;

                    }


                    //   ใช้เวลา ครั้งที่ 2
                    if (dtg_recheck.Rows[i].Cells[8].Value.ToString() != "-" && dtg_recheck.Rows[i].Cells[10].Value.ToString() != "-")
                    {
                        DateTime D_ST = Convert.ToDateTime(dtg_recheck.Rows[i].Cells[8].Value.ToString());
                        DateTime D_ED = Convert.ToDateTime(dtg_recheck.Rows[i].Cells[10].Value.ToString());

                        TimeSpan TS = D_ED.Subtract(D_ST);
                        dtg_recheck.Rows[i].Cells[9].Value = TS.ToString(@"hh\:mm\:ss");
                        D_AHour += TS.Hours;
                        D_AMinute += TS.Minutes;
                        D_ASecound += TS.Seconds;
                    }

                    else
                    {
                        if (dtg_recheck.Rows[i].Cells[6].Value.ToString() != "-")
                        {
                            DateTime D_ST = Convert.ToDateTime(dtg_recheck.Rows[i].Cells[6].Value.ToString());
                            DateTime D_ED = Convert.ToDateTime(dtg_recheck.Rows[i].Cells[10].Value.ToString());

                            TimeSpan TS = D_ED.Subtract(D_ST);
                            dtg_recheck.Rows[i].Cells[9].Value = TS.ToString(@"hh\:mm\:ss");
                            D_AHour += TS.Hours;
                            D_AMinute += TS.Minutes;
                            D_ASecound += TS.Seconds;
                        }

                    }


                    //   ใช้เวลา ครั้งที่ 3
                    if (dtg_recheck.Rows[i].Cells[10].Value.ToString() != "-" && dtg_recheck.Rows[i].Cells[12].Value.ToString() != "-")
                    {
                        DateTime D_ST = Convert.ToDateTime(dtg_recheck.Rows[i].Cells[10].Value.ToString());
                        DateTime D_ED = Convert.ToDateTime(dtg_recheck.Rows[i].Cells[12].Value.ToString());

                        TimeSpan TS = D_ED.Subtract(D_ST);
                        dtg_recheck.Rows[i].Cells[11].Value = TS.ToString(@"hh\:mm\:ss");
                        D_AHour += TS.Hours;
                        D_AMinute += TS.Minutes;
                        D_ASecound += TS.Seconds;
                    }

                    
                    //   ใช้เวลา ครั้งที่ 4
                    if (dtg_recheck.Rows[i].Cells[12].Value.ToString() != "-" && dtg_recheck.Rows[i].Cells[14].Value.ToString() != "-")
                    {
                        DateTime D_ST = Convert.ToDateTime(dtg_recheck.Rows[i].Cells[12].Value.ToString());
                        DateTime D_ED = Convert.ToDateTime(dtg_recheck.Rows[i].Cells[14].Value.ToString());

                        TimeSpan TS = D_ED.Subtract(D_ST);
                        dtg_recheck.Rows[i].Cells[13].Value = TS.ToString(@"hh\:mm\:ss");
                        D_AHour += TS.Hours;
                        D_AMinute += TS.Minutes;
                        D_ASecound += TS.Seconds;
                    }

                    else
                    {

                        if (dtg_recheck.Rows[i].Cells[10].Value.ToString() != "-")
                        {
                            DateTime D_ST = Convert.ToDateTime(dtg_recheck.Rows[i].Cells[10].Value.ToString());
                            DateTime D_ED = Convert.ToDateTime(dtg_recheck.Rows[i].Cells[14].Value.ToString());

                            TimeSpan TS = D_ED.Subtract(D_ST);
                            dtg_recheck.Rows[i].Cells[13].Value = TS.ToString(@"hh\:mm\:ss");
                            D_AHour += TS.Hours;
                            D_AMinute += TS.Minutes;
                            D_ASecound += TS.Seconds;
                        }

                    }

                    //   ใช้เวลา ครั้งที่ 5
                    if (dtg_recheck.Rows[i].Cells[14].Value.ToString() != "-" && dtg_recheck.Rows[i].Cells[16].Value.ToString() != "-")
                    {
                        DateTime D_ED = Convert.ToDateTime(dtg_recheck.Rows[i].Cells[16].Value.ToString());
                        DateTime D_ST = Convert.ToDateTime(dtg_recheck.Rows[i].Cells[14].Value.ToString());
                        TimeSpan TS = D_ED.Subtract(D_ST);
                        dtg_recheck.Rows[i].Cells[15].Value = TS.ToString(@"hh\:mm\:ss");
                        D_AHour += TS.Hours;
                        D_AMinute += TS.Minutes;
                        D_ASecound += TS.Seconds;

                    }                                       

                }
                catch
                {
                    if (dtg_recheck.Rows[i].Cells[16].Value.ToString() != "-")
                    {
                        DateTime D_ED = Convert.ToDateTime(dtg_recheck.Rows[i].Cells[16].Value.ToString());

                        if (dtg_recheck.Rows[i].Cells[14].Value.ToString() != "-")
                        {
                            DateTime D_ST = Convert.ToDateTime(dtg_recheck.Rows[i].Cells[14].Value.ToString());
                            TimeSpan TS = D_ED.Subtract(D_ST);
                            dtg_recheck.Rows[i].Cells[15].Value = TS.ToString(@"hh\:mm\:ss");
                            D_AHour += TS.Hours;
                            D_AMinute += TS.Minutes;
                            D_ASecound += TS.Seconds;
                        }

                        if (dtg_recheck.Rows[i].Cells[12].Value.ToString() != "-")
                        {
                            DateTime D_ST = Convert.ToDateTime(dtg_recheck.Rows[i].Cells[12].Value.ToString());
                            TimeSpan TS = D_ED.Subtract(D_ST);
                            dtg_recheck.Rows[i].Cells[15].Value = TS.ToString(@"hh\:mm\:ss");
                            D_AHour += TS.Hours;
                            D_AMinute += TS.Minutes;
                            D_ASecound += TS.Seconds;
                        }

                        if (dtg_recheck.Rows[i].Cells[10].Value.ToString() != "-")
                        {
                            DateTime D_ST = Convert.ToDateTime(dtg_recheck.Rows[i].Cells[10].Value.ToString());
                            TimeSpan TS = D_ED.Subtract(D_ST);
                            dtg_recheck.Rows[i].Cells[15].Value = TS.ToString(@"hh\:mm\:ss");
                            D_AHour += TS.Hours;
                            D_AMinute += TS.Minutes;
                            D_ASecound += TS.Seconds;
                        }


                        if (dtg_recheck.Rows[i].Cells[8].Value.ToString() != "-")
                        {
                            DateTime D_ST = Convert.ToDateTime(dtg_recheck.Rows[i].Cells[8].Value.ToString());
                            TimeSpan TS = D_ED.Subtract(D_ST);
                            dtg_recheck.Rows[i].Cells[15].Value = TS.ToString(@"hh\:mm\:ss");
                            D_AHour += TS.Hours;
                            D_AMinute += TS.Minutes;
                            D_ASecound += TS.Seconds;
                        }


                        if (dtg_recheck.Rows[i].Cells[6].Value.ToString() != "-")
                        {
                            DateTime D_ST = Convert.ToDateTime(dtg_recheck.Rows[i].Cells[6].Value.ToString());
                            TimeSpan TS = D_ED.Subtract(D_ST);
                            dtg_recheck.Rows[i].Cells[15].Value = TS.ToString(@"hh\:mm\:ss");
                            D_AHour += TS.Hours;
                            D_AMinute += TS.Minutes;
                            D_ASecound += TS.Seconds;
                        }

                    }
                }

                finally
                {

                    int Secound = D_ASecound % 60;
                    int Minute = (D_AMinute + (D_ASecound / 60)) % 60;
                    int Minute_ = Minute % 60;
                    D_AHour += (D_AMinute + (D_ASecound / 60)) / 60;

                    string Convert_secound;
                    if (Secound == 0)
                    {
                        Convert_secound = "00";
                    }
                    else { Convert_secound = Secound.ToString(); }

                    dtg_recheck.Rows[i].Cells[17].Value = D_AHour.ToString("00") + ":" + Minute_.ToString("00") + ":" + Convert_secound;

                    if (dtg_recheck.Rows[i].Cells[17].Value.ToString() == "00:00:00") { dtg_recheck.Rows[i].Cells[17].Value = "-"; }

                }
            }


            dtg_recheck.Columns[6].DefaultCellStyle.BackColor = Color.Aquamarine;
            dtg_recheck.Columns[8].DefaultCellStyle.BackColor = Color.LightGreen;
            dtg_recheck.Columns[10].DefaultCellStyle.BackColor = Color.LightGreen;
            dtg_recheck.Columns[12].DefaultCellStyle.BackColor = Color.YellowGreen;
            dtg_recheck.Columns[14].DefaultCellStyle.BackColor = Color.LightGreen;
            dtg_recheck.Columns[16].DefaultCellStyle.BackColor = Color.LightGreen;

        }

        private void chk_recheck_CheckedChanged(object sender, EventArgs e)
        {

         
        }

        private void chk_allproduct_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdo_follow.Checked == true)
            //{
            //    Load_Follow();
            //}
            //if (rdo_recheck.Checked == true)
            //{
            //    LoadData();
            //}

            //if (chk_allproduct.Checked == true)
            //{
            //    cb_byproduct.Text = "--ดูเฉพาะสินค้า--";
            //    cb_byproduct.Enabled = false;

            //}
            //else { cb_byproduct.Enabled = true; }

        }

        private void cb_byproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (rdo_follow.Checked == true)
            //{
            //Load_Follow();
            //}
            //if (rdo_recheck.Checked == true)
            //{
            //    LoadData();
            //}
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        int x = 30;
        private void timer1_Tick(object sender, EventArgs e)
        {          
            lbl_refreshTime.Text = x.ToString();

            if (x != 0)
            {
                x--;
                lbl_refreshTime.Text = x.ToString() + " Sec";
            }
            else {
                x = 30;
                Load_Follow();
                
            }

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Load_Follow();           
        }

        private void rdo_follow_CheckedChanged(object sender, EventArgs e)
        {                     
            Load_Follow();
        }

        private void rdo_recheck_CheckedChanged(object sender, EventArgs e)
        {
            Load_Follow();
        }

        private void chk_normal_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_normal.Checked == true)
            {
                chk_auto.Checked = false;
            }

            Load_Follow();
        }

        private void chk_auto_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_auto.Checked == true)
            {
                chk_normal.Checked = false;
            }

            Load_Follow();
        }
    }
}
