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
using System.IO.Ports;
using System.Threading;
using System.Globalization;
using Microsoft.Reporting.WinForms;
using System.Net;
using System.IO;

namespace Truck_Analytics
{
    public partial class F_Weight : Form
    {
        public F_Weight()
        {
            InitializeComponent();
        }

        SerialPort sport = new SerialPort();
        double weight_interface = 0;

        int TypeJob = 0;
        int Process_id = 0;
        int Process_id_Auto = 0;
        double InboundWeight = 0;
        double OutboundWeight = 0;
        double Net_Weight = 0;
        decimal Gross_Weight = 0;
        decimal Discut_Weight = 0;
        decimal Price_STD = 0;
        decimal PriceExt = 0;
        decimal DiscutValue = 0;
        decimal SumPrice_STDExt = 0;
        decimal Net_Price = 0;
        int TruckType = 0;
        int Emp_confirm = 0;
        string Date_confirm = "";

        double UnitINStock = 0;

        int Check_ProductDen = 0;  //return status check pass
        double ValueDensity = 0;   // send value density
        double ValidDensity = 0;    // check % error   
        decimal Weight_Den = 0;
        string ID_cusDen = "";
        string Ticket_Den = "";
        int ShowInsertDen = 0;

        double Qty = 0;
        int PrintformID = 0;
        int id_service = 0;
        string Status_Weight = "";
        int STS_PrintEthFormat = 0;

        //---------------Print Auto
        string ProductID = "";
        int QueueNo = 0;
        string TicketCodeIn = "";
        string LocationID = "";
        int Status_WI = 0;
        int Status_WO = 0;

        //------------ Log
        string Msg = "";
        string Log_NewValue = "";
        string Log_OldValue = "";
        int Status_edit = 0;


        int Status_Use = 0;
        int Adddata_Per = 0;
        int Editdata_Per = 0;
        int Canceldata_Per = 0;
        int Viewdata_Per = 0;
        int Printdata_Per = 0;

        int Count_Ticket = 0;

        //-------------App Line
        string token = "";
        string ID_Barcode = "";

        //----------Auto mode
        int PurSale = 0;

        //File Dll
        // IO file Dll
        string value_line1 = "";
        string value_line2 = "";
        string value_line3 = "";
        string value_line4 = "";
        string value_line5 = "";
        string value_line6 = "";

        private void Load_Permission()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            try
            {

                //SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql6 = "SELECT  Status_Use, Adddata_Per, Editdata_Per, Canceldata_Per, Viewdata_Per, Printdata_Per FROM  [dbo].[V_Permission] WHERE [UserID] = '" + Program.user_id + "' AND [ID_Menu]= 17 ";
                SqlCommand CM6 = new SqlCommand(sql6, con);
                SqlDataReader DR6 = CM6.ExecuteReader();

                DR6.Read();
                {
                    if (DR6["Status_Use"].ToString().Trim() == "True") { Status_Use = 1; }
                    if (DR6["Adddata_Per"].ToString().Trim() == "True") { Adddata_Per = 1; }
                    if (DR6["Editdata_Per"].ToString().Trim() == "True") { Editdata_Per = 1; }
                    if (DR6["Canceldata_Per"].ToString().Trim() == "True") { Canceldata_Per = 1; }
                    if (DR6["Viewdata_Per"].ToString().Trim() == "True") { Viewdata_Per = 1; }
                    if (DR6["Printdata_Per"].ToString().Trim() == "True") { Printdata_Per = 1; }
                }
                DR6.Close();
                con.Close();

                if (Status_Use == 0)
                {
                    MessageBox.Show("สิทธ์การใช้งานไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานชั่งสินค้าเข้า-ออก)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

                if (Adddata_Per == 1)
                { btn_save.Enabled = true; }

                if (Editdata_Per == 1)
                {
                    btn_save.Enabled = true;
                    btn_findProduct.Enabled = true;
                    btn_findLocation.Enabled = true;
                    btn_findTrucktype.Enabled = true;
                    btn_findVencus.Enabled = true;
                }

            }

            catch {

                con.Close();
                MessageBox.Show("ไม่มีการเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานชั่งสินค้าเข้า-ออก)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }


        private void F_Weight_Load(object sender, EventArgs e)
        {

            Chang_sizeWindows();
            Load_Permission();
            Load_SiteTruck();

            //Load_StatusPur();
            //Load_StatusSale();
            //Load_DataRegister_Purchase();
            //Load_DataRegister_Sale();
            Load_PortScale();
            ConnectToSerail();
            timer1.Enabled = true;
            //cbo_status.Text = "--ดูสถานะงานอื่น--";
            tool_login.Text = "Login Name: " + Program.user_name;
            tool_DBName.Text = "Database Name: " + Program.DB_Name;
            timer2.Enabled = true;
            refresh_data = Program.refresh_Data;
            
            //if (txt_weightInterface.Text == "W-Scale")
            //{
            //    MessageBox.Show("สายส่ง/ข้อมูลชั่ง ไม่ได้ถูกเชื่อมต่อ กรุณาตรวจเช็คสาย", "การนำเข้าข้อมูลตาชั่งผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //refresh_data = Program.refresh_Data;
            //Load_DataRegister();
            //cbo_status.Text = "--ดูสถานะงานอื่น--";

            txt_qrCode.Focus();

            if (Program.DB_Name != "SapthipNewDB")
            {
                panel1.BackColor = Color.Crimson;
                lbl_sitetruck.BackColor = Color.Crimson;
                panel3.BackColor = Color.Crimson;
            }

            pn_detail.Width = 2;

        }

        private void Load_PortScale()
        {

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;

            try
            {
                con.Open();

                string sql1 = "Select * From  [dbo].[TB_Scale] Where [ScaleFormat] ='" + Program.TruckScaleName + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    Program.PortName = DR1["PortName"].ToString();
                    Program.BaudRate = DR1["BaudRate"].ToString();
                    Program.DataBit = Convert.ToInt16(DR1["DataBit"].ToString());
                    Program.Parity = DR1["Parity"].ToString();
                    Program.StopBit = DR1["StopBit"].ToString();
                    Program.StartSelect_Char = Convert.ToInt16(DR1["StartAscii"].ToString());
                    Program.EndSelect_Chare = Convert.ToInt16(DR1["EndAscii"].ToString());
                    Program.PrintFormateNo = Convert.ToInt16(DR1["PrintingNo"].ToString());

                    if (DR1["EditWeight_In"].ToString() == "True")
                    {
                        tg_Win.Visible = true;
                    }

                    if (DR1["EditWeight_Out"].ToString() == "True")
                    {
                        tg_Wout.Visible = true;
                    }
                }
                DR1.Close();
                con.Close();
            }
            catch { con.Close(); }


        }
        private void ConnectToSerail()
        {
            try
            {
                sport.PortName = Program.PortName;
                sport.BaudRate = int.Parse(Program.BaudRate);
                sport.Parity = (Parity)Enum.Parse(typeof(Parity), Program.Parity);
                sport.DataBits = Program.DataBit;
                sport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), Program.StopBit);
                sport.Handshake = Handshake.None;
                sport.DataReceived += OnSerialDataReceived;
                sport.ReadTimeout = 500;
                sport.WriteTimeout = 500;         

                try
                {
                    sport.Open();
                }

                catch (Exception ex)
                {
                    sport.Close();
                    MessageBox.Show("สายส่ง/ข้อมูลชั่ง ไม่ได้ถูกเชื่อมต่อ กรุณาตรวจเช็คสาย", "การนำเข้าข้อมูลตาชั่งผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);                 
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Comport Access Denie ! " + ex.Message + "", "Comport Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Msg = "Connect Serail port on failed!";
                Log_NewValue = ex.ToString();
                Log_OldValue = "-";

                Class_Log CL = new Class_Log();
                CL.tbname = Msg;
                CL.oldvalue = Log_OldValue;
                CL.newvalue = Log_NewValue;
                CL.Save_log();
            }
        }

        public void OnSerialDataReceived(object sender, SerialDataReceivedEventArgs args)
        {
            try
            {
                if (sport.IsOpen)
                {
                    //test 04/11/2021
                    Thread.Sleep(500);

                    string data = sport.ReadExisting();
                    this.BeginInvoke(new MethodInvoker(delegate () { txt_weightInterface.Text = data.Trim(); }));
                    //sport.Close();

                    RichTextBox.CheckForIllegalCrossThreadCalls = false;

                    //MessageBox.Show(data.ToString());
                    txt_weightInterface.SelectionStart = Program.StartSelect_Char;
                    txt_weightInterface.SelectionLength = Program.EndSelect_Chare;

                    weight_interface = Convert.ToDouble(txt_weightInterface.SelectedText.Trim());

                    if (tg_Win.Checked == false)
                    {
                        txt_weightDisply.Text = weight_interface.ToString();
                    }

                    if (tg_Wout.Checked == false)
                    {
                        txt_weightDisply.Text = weight_interface.ToString();
                    }

                }
            }
            catch {/* sport.Close();*/ }
        }

        private void Load_DataRegister_Purchase()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;

            try
            {
                con.Open();

                dtg_weightPurchase.DataSource = null;
                //prot_form
                string Date = dtp_historyPur.Value.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));

                //[RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' 
                string sql1 = "";


                if (cbo_statusPur.SelectedIndex > -1 && cbo_statusPur.Text != "--ดูสถานะงานอื่น--")
                {
                    sql1 = "SELECT [proc_name] AS 'สถานะ', CONVERT(varchar, [RegisterInDate], 108) AS 'เวลา',[TicketCodeIn] AS 'เลขที่ตั๋ว',[QueueNo] AS 'คิว',[ProductName]  AS 'สินค้า',[InboundWeight] AS 'นน.เข้า' , [OutboundWeight] AS 'นน.ออก' ,[Plate1] AS 'ทะเบียน' ,[TruckTypeName] AS 'ประเภท'  ,[NameVen] AS 'ผู้ขาย' FROM [dbo].[V_WeightData]  Where [proc_type] ='" + cbo_statusPur.SelectedValue.ToString().Trim() + "' AND [RegisterInDate] Between '" + Date + " 00:00.00'  AND  '" + Date + " 23:59:59.999'  AND WeightTypeID <> '03' ";                  
                }
                else
                {
                    sql1 = "SELECT [proc_name] AS 'สถานะ', CONVERT(varchar, [RegisterInDate], 108) AS 'เวลา',[TicketCodeIn] AS 'เลขที่ตั๋ว',[QueueNo] AS 'คิว',[ProductName] AS 'สินค้า',[Plate1] AS 'ทะเบียน',[TruckTypeName] AS 'ประเภท',[DriveName] AS 'ชื่อคนขับ',[NameVen] AS 'ผู้ขาย' FROM [dbo].[V_WeightData]  Where ([RegisterInDate] Between '" + Date + " 00:00.00'  AND  '" + Date + " 23:59:59.999' AND  [proc_type] ='WI')  OR ([RegisterInDate] Between '" + Date + " 00:00.00'  AND  '" + Date + " 23:59:59.999' AND  [proc_type] ='WO')  AND WeightTypeID <> '03' ";

                }
                //  string sql1 = "SELECT [prot_form] AS 'สถานะ', CONVERT(varchar, [RegisterInDate], 108) AS 'เวลา',[TicketCodeIn] AS 'เลขที่ตั๋ว',[QueueNo] AS 'คิว',[ProductName]     AS 'สินค้า'  ,[Plate1] AS 'ทะเบียน' ,[TruckTypeName] AS 'ประเภท'  ,[NameVen] AS 'ผู้ขาย-ซื้อ' FROM [dbo].[V_WeightData]  Where [RegisterInDate] BETWEEN {ts'" + dt.ToString() + " 00:00:00'} AND  {ts'" + dt.ToString() + " 23:59:59'} AND [proc_type] ='W'";


                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                da1.SelectCommand.CommandTimeout = 0;
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_vt");
                dtg_weightPurchase.DataSource = ds1.Tables["g_vt"];
                con.Close();

                if (cbo_statusPur.Text == "--ดูสถานะงานอื่น--")
                {
                    dtg_weightPurchase.Columns[0].Width = 100;
                    dtg_weightPurchase.Columns[1].Width = 100;
                    dtg_weightPurchase.Columns[2].Width = 120;
                    dtg_weightPurchase.Columns[3].Width = 40;
                    dtg_weightPurchase.Columns[4].Width = 100;
                    dtg_weightPurchase.Columns[5].Width = 100;
                    dtg_weightPurchase.Columns[6].Width = 80;
                    dtg_weightPurchase.Columns[7].Width = 130;

                    dtg_weightPurchase.Columns[0].ReadOnly = true;
                    dtg_weightPurchase.Columns[1].ReadOnly = true;
                    dtg_weightPurchase.Columns[2].ReadOnly = true;                
                    dtg_weightPurchase.Columns[4].ReadOnly = true;
                    dtg_weightPurchase.Columns[5].ReadOnly = true;
                    dtg_weightPurchase.Columns[6].ReadOnly = true;
                    dtg_weightPurchase.Columns[7].ReadOnly = true;
                    dtg_weightPurchase.Columns[8].ReadOnly = true;
                    dtg_weightPurchase.Columns[9].ReadOnly = true;

                }
                else
                {
                    dtg_weightPurchase.Columns[0].Width = 100;
                    dtg_weightPurchase.Columns[1].Width = 80;
                    dtg_weightPurchase.Columns[2].Width = 120;
                    dtg_weightPurchase.Columns[3].Width = 40;
                    dtg_weightPurchase.Columns[4].Width = 100;
                    dtg_weightPurchase.Columns[5].Width = 80;
                    dtg_weightPurchase.Columns[6].Width = 80;
                    dtg_weightPurchase.Columns[7].Width = 100;
                    dtg_weightPurchase.Columns[8].Width = 100;

                    dtg_weightPurchase.Columns[0].ReadOnly = true;
                    dtg_weightPurchase.Columns[1].ReadOnly = true;
                    dtg_weightPurchase.Columns[2].ReadOnly = true;                  
                    dtg_weightPurchase.Columns[4].ReadOnly = true;
                    dtg_weightPurchase.Columns[5].ReadOnly = true;
                    dtg_weightPurchase.Columns[6].ReadOnly = true;
                    dtg_weightPurchase.Columns[7].ReadOnly = true;
                    dtg_weightPurchase.Columns[8].ReadOnly = true;
                }

               
                dtg_weightPurchase.ClearSelection();

                for (int i = 0; i < dtg_weightPurchase.RowCount; i++)
                {
                    if (dtg_weightPurchase.Rows[i].Cells[0].Value.ToString().Trim() == "รอชั่งเข้า")
                    {
                        this.dtg_weightPurchase.Rows[i].Cells[0].Style.BackColor = Color.LightGreen;
                    }

                    else { this.dtg_weightPurchase.Rows[i].Cells[0].Style.BackColor = Color.LightYellow; }
                }


                this.dtg_weightPurchase.Columns[3].DefaultCellStyle.BackColor = Color.Bisque;

            }
            catch
            {
                con.Close();
            }
        }

        private void Load_DataRegister_Auto()
        {

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            try
            {
                con.Open();

                //prot_form
                dtg_weightAuto.DataSource = null;

                string Date = dtp_historyAuto.Value.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));

                string sql1 = "";


                if (cbo_statusAuto.SelectedIndex > -1 && cbo_statusAuto.Text != "--ดูสถานะงานอื่น--")
                {

                    sql1 = "SELECT [proc_name] AS 'สถานะ', CONVERT(varchar, [InboundDate], 108) AS 'เวลา',[TicketCodeIn] AS 'เลขที่ตั๋ว',[QueueNo] AS 'คิว',[ProductName]  AS 'สินค้า', [InboundWeight] AS 'นน.เข้า' , [OutboundWeight] AS 'นน.ออก'  ,[Plate1] AS 'ทะเบียน' ,[TruckTypeName] AS 'ประเภท',[CustomerID] AS 'รหัสผู้ซื้อ',[Vendor_No] AS 'รหัสผู้ขาย' FROM [dbo].[V_WeightAuto]  Where [proc_type] ='" + cbo_statusAuto.SelectedValue.ToString().Trim() + "' AND [InboundDate] Between '" + Date + " 00:00.00'  AND  '" + Date + " 23:59:59.999' AND WeightTypeID = '03'";
                }
                else
                {
                    sql1 = "SELECT [proc_name] AS 'สถานะ', CONVERT(varchar, [InboundDate], 108) AS 'เวลา',[TicketCodeIn] AS 'เลขที่ตั๋ว',[QueueNo] AS 'คิว',[ProductName] AS 'สินค้า'  ,[Plate1] AS 'ทะเบียน' ,[TruckTypeName] AS 'ประเภท'  ,[CustomerID] AS 'รหัสผู้ซื้อ',[Vendor_No] AS 'รหัสผู้ขาย' FROM [dbo].[V_WeightAuto]  WHERE ([InboundDate] Between '" + Date + " 00:00.00'  AND  '" + Date + " 23:59:59.999')  OR ([InboundDate] Between '" + Date + " 00:00.00'  AND  '" + Date + " 23:59:59.999') AND WeightTypeID = '03'";
                }


                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                da1.SelectCommand.CommandTimeout = 0;
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_vt");
                dtg_weightAuto.DataSource = ds1.Tables["g_vt"];
                con.Close();

                if (cbo_statusAuto.Text == "--ดูสถานะงานอื่น--")
                {
                    dtg_weightAuto.Columns[0].Width = 100;
                    dtg_weightAuto.Columns[1].Width = 80;
                    dtg_weightAuto.Columns[2].Width = 120;
                    dtg_weightAuto.Columns[3].Width = 40;
                    dtg_weightAuto.Columns[4].Width = 120;
                    dtg_weightAuto.Columns[5].Width = 100;
                    dtg_weightAuto.Columns[6].Width = 100;

                    dtg_weightAuto.Columns[0].ReadOnly = true;
                    dtg_weightAuto.Columns[1].ReadOnly = true;
                    dtg_weightAuto.Columns[2].ReadOnly = true;
                    dtg_weightAuto.Columns[4].ReadOnly = true;
                    dtg_weightAuto.Columns[5].ReadOnly = true;
                    dtg_weightAuto.Columns[6].ReadOnly = true;
              
                }
                else
                {
                    dtg_weightAuto.Columns[0].Width = 100;
                    dtg_weightAuto.Columns[1].Width = 80;
                    dtg_weightAuto.Columns[2].Width = 120;
                    dtg_weightAuto.Columns[3].Width = 40;
                    dtg_weightAuto.Columns[4].Width = 120;
                    dtg_weightAuto.Columns[5].Width = 80;
                    dtg_weightAuto.Columns[6].Width = 80;
              
                    dtg_weightAuto.Columns[0].ReadOnly = true;
                    dtg_weightAuto.Columns[1].ReadOnly = true;
                    dtg_weightAuto.Columns[2].ReadOnly = true;
                    dtg_weightAuto.Columns[4].ReadOnly = true;
                    dtg_weightAuto.Columns[5].ReadOnly = true;
                    dtg_weightAuto.Columns[6].ReadOnly = true;              

                }


                dtg_weightAuto.ClearSelection();

                for (int i = 0; i < dtg_weightAuto.RowCount; i++)
                {
                    if (dtg_weightAuto.Rows[i].Cells[0].Value.ToString().Trim() == "รอชั่งเข้า" || dtg_weightAuto.Rows[i].Cells[0].Value.ToString().Trim() == "ชั่งเข้า")
                    {
                        this.dtg_weightAuto.Rows[i].Cells[0].Style.BackColor = Color.LightGreen;
                    }

                    else { this.dtg_weightAuto.Rows[i].Cells[0].Style.BackColor = Color.LightYellow; }
                }
                
                this.dtg_weightAuto.Columns[3].DefaultCellStyle.BackColor = Color.Bisque;
            }
            catch { con.Close(); }
        }


        private void Load_DataRegister_Sale()
        {

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            try
            {
                con.Open();

                //prot_form
                dtg_weightSale.DataSource = null;

                string Date = dtp_historySale.Value.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));

                string sql1 = "";


                if (cbo_statusSale.SelectedIndex > -1 && cbo_statusSale.Text != "--ดูสถานะงานอื่น--")
                {

                    sql1 = "SELECT [proc_name] AS 'สถานะ', CONVERT(varchar, [RegisterInDate], 108) AS 'เวลา',[TicketCodeIn] AS 'เลขที่ตั๋ว',[QueueNo] AS 'คิว',[ProductName]  AS 'สินค้า', [InboundWeight] AS 'นน.เข้า' , [OutboundWeight] AS 'นน.ออก'  ,[Plate1] AS 'ทะเบียน' ,[TruckTypeName] AS 'ประเภท'  ,[CustomerName] AS 'ซื้อ' FROM [dbo].[V_WeightData_Sale]  Where [proc_type] ='" + cbo_statusSale.SelectedValue.ToString().Trim() + "' AND [RegisterInDate] Between '" + Date + " 00:00.00'  AND  '" + Date + " 23:59:59.999' AND WeightTypeID <> '03'";

                }
                else
                {

                    sql1 = "SELECT [proc_name] AS 'สถานะ', CONVERT(varchar, [RegisterInDate], 108) AS 'เวลา',[TicketCodeIn] AS 'เลขที่ตั๋ว',[QueueNo] AS 'คิว',[ProductName] AS 'สินค้า'  ,[Plate1] AS 'ทะเบียน' ,[TruckTypeName] AS 'ประเภท'  ,[CustomerName] AS 'ผู้ซื้อ' FROM [dbo].[V_WeightData_Sale]  WHERE ([RegisterInDate] Between '" + Date + " 00:00.00'  AND  '" + Date + " 23:59:59.999' AND  [proc_type] ='WI')  OR ([RegisterInDate] Between '" + Date + " 00:00.00'  AND  '" + Date + " 23:59:59.999' AND  [proc_type] ='WO') AND WeightTypeID <> '03'";
                }        
                    

                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                da1.SelectCommand.CommandTimeout = 0;
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_vt");
                dtg_weightSale.DataSource = ds1.Tables["g_vt"];
                con.Close();

                if (cbo_statusSale.Text == "--ดูสถานะงานอื่น--")
                {
                    dtg_weightSale.Columns[0].Width = 100;
                    dtg_weightSale.Columns[1].Width = 80;
                    dtg_weightSale.Columns[2].Width = 120;
                    dtg_weightSale.Columns[3].Width = 40;
                    dtg_weightSale.Columns[4].Width = 120;
                    dtg_weightSale.Columns[5].Width = 100;
                    dtg_weightSale.Columns[6].Width = 100;


                    dtg_weightSale.Columns[0].ReadOnly = true;
                    dtg_weightSale.Columns[1].ReadOnly = true;
                    dtg_weightSale.Columns[2].ReadOnly = true;
                    dtg_weightSale.Columns[4].ReadOnly = true;
                    dtg_weightSale.Columns[5].ReadOnly = true;
                    dtg_weightSale.Columns[6].ReadOnly = true;
                    dtg_weightSale.Columns[7].ReadOnly = true;
                    dtg_weightSale.Columns[8].ReadOnly = true;
                    dtg_weightSale.Columns[9].ReadOnly = true;
                }
                else
                {
                    dtg_weightSale.Columns[0].Width = 100;
                    dtg_weightSale.Columns[1].Width = 80;
                    dtg_weightSale.Columns[2].Width = 120;
                    dtg_weightSale.Columns[3].Width = 40;
                    dtg_weightSale.Columns[4].Width = 120;
                    dtg_weightSale.Columns[5].Width = 80;
                    dtg_weightSale.Columns[6].Width = 80;
                    dtg_weightSale.Columns[7].Width = 100;
                    dtg_weightSale.Columns[8].Width = 80;


                    dtg_weightSale.Columns[0].ReadOnly = true;
                    dtg_weightSale.Columns[1].ReadOnly = true;
                    dtg_weightSale.Columns[2].ReadOnly = true;
                    dtg_weightSale.Columns[4].ReadOnly = true;
                    dtg_weightSale.Columns[5].ReadOnly = true;
                    dtg_weightSale.Columns[6].ReadOnly = true;
                    dtg_weightSale.Columns[7].ReadOnly = true;
                  
                }

            
                dtg_weightSale.ClearSelection();

                for (int i = 0; i < dtg_weightSale.RowCount; i++)
                {
                    if (dtg_weightSale.Rows[i].Cells[0].Value.ToString().Trim() == "รอชั่งเข้า" || dtg_weightSale.Rows[i].Cells[0].Value.ToString().Trim() == "ชั่งเข้า")
                    {
                        this.dtg_weightSale.Rows[i].Cells[0].Style.BackColor = Color.LightGreen;
                    }

                    else { this.dtg_weightSale.Rows[i].Cells[0].Style.BackColor = Color.LightYellow; }
                }


                this.dtg_weightSale.Columns[3].DefaultCellStyle.BackColor = Color.Bisque;
            }
            catch { con.Close(); }
        }

        private void Load_StatusPur()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;

            string Date = dtp_historyPur.Value.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
            dtg_weightPurchase.DataSource = null;

            try
            {
                //Product 
                //cbo_status.DataSource = null;
                con.Open();
                SqlCommand cmd = new SqlCommand("Select DISTINCT([proc_name]) AS 'StatusTruck',[proc_type] as 'type'  From  [dbo].[V_WeightData] Where [RegisterInDate] Between '" + Date + " 00:00.00'  AND  '" + Date + " 23:59:59.999' ", con);
                DataSet ds = new DataSet();
                //ds.Clear();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(ds);

                //Load product tab weight scale Setup
                cbo_statusPur.DataSource = ds.Tables[0];
                cbo_statusPur.DisplayMember = "StatusTruck";
                cbo_statusPur.ValueMember = "type";
                cbo_statusPur.Text = "--ดูสถานะงานอื่น--";

                con.Close();
            }

            catch { con.Close(); }

        }

        private void Load_StatusSale()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;

            string Date = dtp_historyPur.Value.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
            dtg_weightSale.DataSource = null;

            try
            {
                //Product 
                con.Open();
                SqlCommand cmd = new SqlCommand("Select DISTINCT([proc_name]) AS 'StatusTruck',[proc_type] as 'type'  From  [dbo].[V_WeightData_Sale] Where [RegisterInDate] Between '" + Date + " 00:00.00'  AND  '" + Date + " 23:59:59.999' ", con);
                DataSet ds = new DataSet();
                //ds.Clear();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(ds);

                //Load product tab weight scale Setup
                cbo_statusSale.DataSource = ds.Tables[0];
                cbo_statusSale.DisplayMember = "StatusTruck";
                cbo_statusSale.ValueMember = "type";
                cbo_statusSale.Text = "--ดูสถานะงานอื่น--";
                con.Close();

                //Load_DataRegister_Sale();

            }

            catch { con.Close(); }

        }

        private void Load_StatusAuto()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;

            string Date = dtp_historyPur.Value.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
            dtg_weightAuto.DataSource = null;

            try
            {
                //Product 
                con.Open();
                SqlCommand cmd = new SqlCommand("Select DISTINCT([proc_name]) AS 'StatusTruck',[proc_type] as 'type'  From  [dbo].[V_WeightAuto] Where [InboundDate] Between '" + Date + " 00:00.00'  AND  '" + Date + " 23:59:59.999' ", con);
                DataSet ds = new DataSet();
                //ds.Clear();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(ds);

                //Load product tab weight scale Setup
                cbo_statusAuto.DataSource = ds.Tables[0];
                cbo_statusAuto.DisplayMember = "StatusTruck";
                cbo_statusAuto.ValueMember = "type";
                cbo_statusAuto.Text = "--ดูสถานะงานอื่น--";
                con.Close();

                //Load_DataRegister_Sale();

            }

            catch { con.Close(); }

        }

        private void Chang_sizeWindows()
        {
            int f_x = pn_weight.Width / 2;
            int f_y = pn_weight.Height / 2;

            int p_x = pn_location.Width / 2;
            int p_y = pn_location.Height / 2;

            pn_location.Location = new Point((f_x - p_x), 0);
            lbl_license.Location = new Point(p_y + (lbl_license.Width / 2), 5);
        }

        private void Load_SiteTruck()
        {
            string site_truck = "";
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

                site_truck = listStr[2].ToString();
                Program.TruckScaleName = listStr[3].ToString();
                StrRer.Close();
            }

            lbl_sitetruck.Text = "สาขา: " + site_truck;

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            con.Open();
            string sql6 = "SELECT *  FROM  [dbo].[V_Vendor] Where [Vendor_No] ='" + site_truck + "'";
            SqlCommand CM6 = new SqlCommand(sql6, con);
            SqlDataReader DR6 = CM6.ExecuteReader();

            DR6.Read();
            {
                lbl_sitetruck.Text += " เลขที่" + DR6["Address"].ToString().Trim() + "  ตำบล " + DR6["TambonName"].ToString().Trim() + " อำเภอ " + DR6["AmphurName"].ToString().Trim() + " จังหวัด " + DR6["ProvinceName"].ToString().Trim() + " " + DR6["ZipCode"].ToString().Trim();
            }
            DR6.Close();
            con.Close();

        }

        private void F_Weight_Resize(object sender, EventArgs e)
        {
            Chang_sizeWindows();
        }

        private void Check_TypeJob()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            //SqlDataAdapter dtAdapter = new SqlDataAdapter();
            //dtAdapter.SelectCommand.CommandTimeout = 0;
            con.Open();

            string sql1 = "Select [Vendor_No],[CustomerID] From   [dbo].[TB_WeightData] Where TicketCodeIn ='" + txt_qrCode.Text.Trim() + "'";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {

                if (DR1["Vendor_No"].ToString() != "")
                {
                    TypeJob = 1;// "Purchase";
                }

                if (DR1["CustomerID"].ToString() != "")
                {
                    TypeJob = 2;  //"Sale";
                }
            }
            DR1.Close();
            con.Close();

        }

        private void txt_qrCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());

            if (e.KeyChar == 13)
            {
                if (chk_weightAuto.Checked == false)
                {
                    if (Viewdata_Per == 1)
                    {
                        SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                        con.ConnectionString = Program.pathdb_Weight;

                        try
                        {

                            Check_TypeJob();  //ค้นหาประเภทงาน

                            string sql1 = "";
                            con.Open();

                            if (TypeJob == 1)   //purchase
                            {
                                sql1 = "Select * From   [dbo].[V_WeightData] Where TicketCodeIn ='" + txt_qrCode.Text.Trim() + "'";
                            }

                            if (TypeJob == 2)  // sale

                            {
                                sql1 = "Select * From   [dbo].[V_WeightData_Sale] Where TicketCodeIn ='" + txt_qrCode.Text.Trim() + "' ";
                            }

                            SqlCommand CM1 = new SqlCommand(sql1, con);
                            SqlDataReader DR1 = CM1.ExecuteReader();

                            DR1.Read();
                            {
                                if (DR1["proc_type"].ToString().Trim() == "WI" || DR1["proc_type"].ToString().Trim() == "WO")
                                {
                                    txt_ticketCode.Text = txt_qrCode.Text.Trim();
                                    TicketCodeIn = txt_ticketCode.Text;
                                    txt_dateWeight.Text = DateTime.Now.ToShortDateString();
                                    txt_qrCode.Clear();

                                    txt_weighttypeNo.Text = DR1["WeightTypeID"].ToString();
                                    lbl_weightTypeName.Text = DR1["WeightTypeName"].ToString();
                                    txt_productNo.Text = DR1["ProductID"].ToString();
                                    lbl_productName.Text = DR1["ProductName"].ToString();
                                    txt_plateno.Text = DR1["Plate1"].ToString();

                                    txt_truckTypeID.Text = DR1["TruckTypeID"].ToString();
                                    TruckType = Convert.ToInt16(txt_truckTypeID.Text.Trim());

                                    lbl_truckType.Text = DR1["TruckTypeName"].ToString();
                                    txt_driveName.Text = DR1["DriveName"].ToString();
                                    ProductID = DR1["ProductID"].ToString();
                                    txt_transportID.Text = DR1["TransportID"].ToString();
                                    lbl_transportName.Text = DR1["TransportName"].ToString();
                                    txt_remark.Text = DR1["Remark3"].ToString();
                                    

                                    if (TypeJob == 1)  //purchase
                                    {
                                        txt_vencusNo.Text = DR1["Vendor_No"].ToString();
                                        lbl_vencusName.Text = DR1["NameVen"].ToString();
                                    }

                                    if (TypeJob == 2)   // sale
                                    {
                                        txt_vencusNo.Text = DR1["CustomerID"].ToString();
                                        lbl_vencusName.Text = DR1["CustomerName"].ToString();
                                    }


                                    txt_queNo.Text = "คิวที่ " + DR1["QueueNo"].ToString(); //QueueNo
                                    Process_id = Convert.ToInt16(DR1["Process_id"].ToString());
                                    //Process_id


                                    if (DR1["proc_type"].ToString().Trim() == "WI")
                                    {       
                                        txt_queType.Text = "IN";
                                        txt_queType.ForeColor = Color.Green;
                                        txt_weight_In.Text = InboundWeight.ToString("##,###.##");
                                    }
                                                                                                         
                                    if (DR1["proc_type"].ToString().Trim() == "WO")
                                    {
                                        InboundWeight = Convert.ToDouble(DR1["InboundWeight"].ToString());
                                        txt_weight_In.Text = InboundWeight.ToString("##,###.##");

                                        txt_weight_Out.Text = OutboundWeight.ToString("##,###.##");
                                       
                                        txt_queType.Text = "OUT";
                                        txt_queType.ForeColor = Color.Orange;
                                    }                                

                                    if (txt_weighttypeNo.Text == "01")
                                    {
                                        lbl_pricetype.Text = "ราคารับซื้อปัจจุบัน:";
                                    }

                                    else { lbl_pricetype.Text = "ราคาขายปัจจุบัน:"; }

                                    btn_findVencus.Enabled = true;
                                    btn_findTrucktype.Enabled = true;
                                    btn_findTransport.Enabled = true;
                                    btn_findProduct.Enabled = true;
                                    btn_findLocation.Enabled = true;

                                    Cal_Weith();
                                    Load_STD_Price();
                                    Cal_PriceNet();
                                    Load_LocationProduct();
                                    Load_UnitINStock();
                                    //Load_FormatPrint();
                                    Load_Services();

                                    //ConnectToSerail();

                                }

                                else
                                {
                                    AutoClosingMessageBox.Show("เลขที่บัตรชั่งนี้ยังไม่พร้อมชัั่ง กรุณาตรวจสอบชั้นตอนการทำงานเลขที่บัตรนี้", "การเรียกบัตรชั่งผิดผลาด!!", 5000);
                                    txt_qrCode.Clear();
                                    Clear_Textbox();
                                }
                            }
                            DR1.Close();
                            con.Close();

                        }

                        catch (Exception err)

                        {
                            //Display any errors in a Message Box.
                            con.Close();
                            System.Windows.Forms.MessageBox.Show(err.ToString(), "Error+ err.Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            Msg = "Load Data Truck on failed!";
                            Log_NewValue = err.ToString();
                            Log_OldValue = "-";

                            Class_Log CL = new Class_Log();
                            CL.tbname = Msg;
                            CL.oldvalue = Log_OldValue;
                            CL.newvalue = Log_NewValue;
                            CL.Save_log();
                        }

                        // MessageBox.Show("ไม่พบข้อมูลงานชั่งเลขที่นี้ กรุณาตรวจสอบว่าเลขที่นี้มีอยู่จริงหรืออยู่ขั้นตอนไหนก่อนหรือหลังหรือไม่!!", "พบความผิดพลาดเรื่องน้ำหนัก", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                           

                        if (Status_edit == 0)
                        {                           
                            txt_queType.ForeColor = Color.Orange;

                            Load_FormatPrint();
                            Load_DataLabConfirm();
                        }                     

                    }
                }
                
                if (chk_weightAuto.Checked == true)
                {
                    Weight_Auto();
                }


            }

            //else { MessageBox.Show("สิทธิ์ในการดูข้อมูล/ค้นหา ถูกจำกัด กรุณาติดต่อผู้ดูแลระบบ! (งานชั่งสินค้าเข้า-ออก)", "รายงานความผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error); }     

        }

        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                MessageBox.Show(text, caption);
            }

            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }

            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow(null, _caption);
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }


        private void Load_UnitINStock()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;

            try
            {
                con.Open();

                string sql1 = "Select [UnitINStock] AS StockUnit From   [dbo].[TB_LocationZone] Where [ProductID] ='" + txt_productNo.Text.Trim() + "' AND [NO_Zone]='" + txt_locationNo.Text.Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    UnitINStock = Convert.ToDouble(DR1["StockUnit"].ToString());
                }
                DR1.Close();
                con.Close();
            }
            catch { con.Close(); }
        }


        private void Load_STD_Price()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;

                if (txt_stdPrice.Text == "")
                {
                    try
                    {
                        con.Open();
                        string sql1 = "Select [Price] From [dbo].[TB_LabConfirmPay] Where [TicketCodeIn] = '" + TicketCodeIn + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, con);
                        SqlDataReader DR1 = CM1.ExecuteReader();

                        DR1.Read();
                        {
                            Price_STD = Convert.ToDecimal(DR1["Price"].ToString());        
                        }
                        DR1.Close();
                        con.Close();


                        if (Price_STD == 0)
                        {
                            con.Open();
                            string sql = "Select [Price]  From[dbo].[TB_Products] Where [ProductID]='" + ProductID + "'";
                            SqlCommand CM = new SqlCommand(sql, con);
                            SqlDataReader DR = CM.ExecuteReader();

                            DR.Read();
                            {
                                Price_STD = Convert.ToDecimal(DR["Price"].ToString());
                            }
                            DR.Close();
                            con.Close();
                        }


                        if (Price_STD == 0)
                        { txt_stdPrice.Text = "0.00"; }

                        else
                        { txt_stdPrice.Text = Price_STD.ToString(); }
                        

                    }
                    catch { con.Close(); }
                }
            }
            catch { };
        }

        private void Load_FormatPrint()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;

            if (Printdata_Per == 1)
            {
                try
                {
                    con.Open();

                    string sql1 = "Select [PrintformID] From   [dbo].[V_WeightSeting] Where [WeightProductID] = '" + ProductID + "' ";
                    SqlCommand CM1 = new SqlCommand(sql1, con);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    //while (dr.Read())   

                    while (DR1.Read())
                    {
                        if (DR1["PrintformID"].ToString() == "1")
                        {
                            tg_printFormat1.Enabled = true; tg_printFormat1.Checked = true; PrintformID = Convert.ToInt16(DR1["PrintformID"].ToString());
                        }
                        //  else { rdo_printFormat1.Enabled = false; }


                        if (DR1["PrintformID"].ToString() == "2")
                        {
                            tg_printFormat2.Enabled = true; tg_printFormat2.Checked = true; PrintformID = Convert.ToInt16(DR1["PrintformID"].ToString());
                        }
                        //  else { rdo_printFormat2.Enabled = false; }

                        if (DR1["PrintformID"].ToString() == "3")
                        {
                            tg_printFormat3.Enabled = true; tg_printFormat3.Checked = true; PrintformID = Convert.ToInt16(DR1["PrintformID"].ToString());
                        }
                        //  else { rdo_printFormat3.Enabled = false; }

                        if (DR1["PrintformID"].ToString() == "4")
                        {
                            tg_printFormat4.Enabled = true; tg_printFormat4.Checked = true; PrintformID = Convert.ToInt16(DR1["PrintformID"].ToString());
                        }
                        //else { rdo_printFormat4.Enabled = false; }

                        //if (DR1["PrintformID"].ToString() == "5")
                        //{
                        //    rdo_printFormat5.Enabled = true; rdo_printFormat5.Checked = true; PrintformID = Convert.ToInt16(DR1["PrintformID"].ToString());
                        //}

                        //if (DR1["PrintformID"].ToString() == "6")
                        //{
                        //    rdo_printFormat5.Enabled = true; rdo_printFormat5.Checked = true; PrintformID = Convert.ToInt16(DR1["PrintformID"].ToString());
                        //}
                        //else { rdo_printFormat5.Enabled = false; }
                    }
                    DR1.Close();
                    con.Close();
                }
                catch (Exception ex)

                {

                    con.Close();
                    MessageBox.Show("ไม่ได้กำหนดหน้าแบบพิมพ์นี้", "รายงานความผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Msg = "Load format type Report on Print Failed!";
                    Log_NewValue = ex.ToString();
                    Log_OldValue = "-";

                    Class_Log CL = new Class_Log();
                    CL.tbname = Msg;
                    CL.oldvalue = Log_OldValue;
                    CL.newvalue = Log_NewValue;
                    CL.Save_log();

                }

            }

        }

        private void Load_DataLabConfirm()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;

            try
            {
                con.Open();
                string sql1 = "Select [PriceExtra],[DiscutValue] From   [dbo].[TB_LabConfirmPay] Where [TicketCodeIn] = '" + txt_ticketCode.Text + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    PriceExt = Convert.ToDecimal(DR1["PriceExtra"].ToString());
                    DiscutValue = Convert.ToDecimal(DR1["DiscutValue"].ToString());
                }
                DR1.Close();
                con.Close();
            }
            catch { con.Close(); }
        }

        private void Save_FollowProcess()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;

            try
            {
                // Save to data base
                //string date_time = Program.Date_Now + ' ' + Program.Time_Now;
                string Date_Now = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
                string Time_Now = DateTime.Now.ToString("HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));
                string date_time = Date_Now + ' ' + Time_Now;

                con.Open();

                string sql = "";
                if (txt_queType.Text.Trim() == "IN" || chk_weightAuto.Checked == true && Status_Weight == "IN")  //ครั้งที่ 1
                {
                    if (txt_queType.Text.Trim() == "IN")
                    {
                        sql = "Update [TB_FollowProcess] Set [WeightIn_Datetime] = '" + date_time + "' Where [TicketCodeIn] = '" + TicketCodeIn + "'";
                    }

                    if (chk_weightAuto.Checked == true && Status_Weight == "IN")
                    {
                        sql = "Insert Into [TB_FollowProcess] ([TicketCodeIn],[RegisterIn_Datetime],[WeightIn_Datetime]) Values('" + TicketCodeIn + "', '" + date_time + "', '" + date_time + "')";
                    }                
                }

                if (txt_queType.Text.Trim() == "OUT" || chk_weightAuto.Checked == true && Status_Weight == "OUT") //ครั้งที่ 2
                {

                    if (txt_queType.Text.Trim() == "OUT")
                    {

                        sql = "Update [TB_FollowProcess] Set [WeightOut_Datetime] = '" + date_time + "' Where [TicketCodeIn] = '" + TicketCodeIn + "'";
                    }

                    if (chk_weightAuto.Checked == true && Status_Weight == "OUT")
                    {
                        sql = "Update [TB_FollowProcess] Set [RegisterOut_Datetime] = '" + date_time + "' ,[WeightOut_Datetime] = '" + date_time + "' Where [TicketCodeIn] = '" + TicketCodeIn + "'";
                    }



                }

                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();
            }

            catch
            {
                con.Close();
                //MessageBox.Show("ข้อมูลยังไม่ครบ กรุณาตรวจสอบอีกครั้ง", "ข้อมูลผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Load_ProcessID()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;

            try
            {

                Process_id += 1;

                //Step Check Over Process
                int C_count = 0;
                try
                {
                    con.Open();
                    string sql2 = "Select Count([proc_no]) AS 'C_ID' From [dbo].[V_OverStep] Where [item_no]='" + ProductID + "' AND [venOrCus_No]='" + txt_vencusNo.Text.Trim() + "'  AND [proc_no]=" + Process_id + " AND [OverPro_Status]=1";
                    SqlCommand CM2 = new SqlCommand(sql2, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();

                    DR2.Read();
                    {
                        C_count = Convert.ToInt16(DR2["C_ID"].ToString());
                    }
                    DR2.Close();
                    con.Close();
                }
                catch { con.Close(); }

                if (C_count == 1)
                {
                    Process_id += 1;
                }
            }
            catch
            {
                con.Close();
                MessageBox.Show("มีความผิดพลาดเรื่องกระบวนการทำงานของแต่ละสถานี กรุณาเข้าไปตั้งค่าขั้นตอนการทำงานของสินค้า?", "ข้อมูลผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;

            SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
            con1.ConnectionString = Program.pathdb_Weight;

            con.Open();
            string sql1 = "SELECT Count([TicketCodeIn]) AS 'Count_Items' FROM [dbo].[TB_LabConfirmPay] WHERE [TicketCodeIn]= '" + txt_ticketCode.Text.Trim() + "' ";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();
            DR1.Read();
            {
                Count_Ticket = Convert.ToInt16(DR1["Count_Items"].ToString());
            }
            DR1.Close();
            con.Close();

            try
            {
                if (chk_chageService.Checked == true)
                { id_service = Convert.ToInt16(cbo_serviceName.SelectedValue.ToString().Trim()); }
            }
            catch { }

            if (txt_ticketCode.Text != "")
            {
                //Insert New Record Data
                if (Status_edit == 0)  // Insert Data
                {

                    DialogResult dr = MessageBox.Show("คุณต้องการบันทึกข้อมูลนี้ใช่หรือไม่", "ยืนยันข้อมูล", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Information);

                    if (dr == DialogResult.Yes)
                    {
                        // Save to data base
                        string date = DateTime.Now.ToString("yyyy-MM-dd") + ' ' + DateTime.Now.ToString("HH:mm:ss");

                        //con.Open();

                        //Process_id += 1;
                        Load_ProcessID();

                        //double weight_in = 0.00;
                        //double weight_out = 0.00;

                        ////Insert weight Manual
                        //weight_in = Convert.ToDouble(txt_weight_In.Text);
                        //weight_out = Convert.ToDouble(txt_weight_Out.Text);

                        ProductID = txt_productNo.Text.Trim();

                        // truck In
                        if (txt_queType.Text == "IN")
                        {

                            string Name_filed = "";
                            //if (weight_in == 0)
                            //{ weight_in = Convert.ToDouble(txt_weightDisply.Text.Trim()); }

                            if (txt_weighttypeNo.Text == "01")
                            {
                                Name_filed = "Vendor_No";
                            }
                            if (txt_weighttypeNo.Text == "02")
                            {
                                Name_filed = "CustomerID";
                            }

                            con.Open();
                            string sql2 = "Update [TB_WeightData] Set ProductID ='" + txt_productNo.Text + "' , Plate1 ='" + txt_plateno.Text + "' , TruckTypeID ='" + txt_truckTypeID.Text + "' ,WeightDate ='" + date + "' ,InboundDate ='" + date + "',Process_id=" + Process_id + ", InboundWeight =" + InboundWeight + "," + Name_filed + "='" + txt_vencusNo.Text + "',WarehouseID='" + txt_locationNo.Text.Trim() + "',DriveName='" + txt_driveName.Text.Trim() + "',[ServiceID]=" + id_service + ",[TransportID]=" + txt_transportID.Text.Trim() + ",[Remark3]='" + txt_remark.Text.Trim() + "'  Where [TicketCodeIn] = '" + TicketCodeIn + "'";
                            SqlCommand CM2 = new SqlCommand(sql2, con);
                            SqlDataReader DR2 = CM2.ExecuteReader();
                            con.Close();
                            
                            Save_FollowProcess();

                            Msg = "Update Data on Truck In!";
                            Log_NewValue = "ProductID =" + txt_productNo.Text +
                                "" + "Plate1 = " + txt_plateno.Text +
                                "" + "TruckTypeID = " + txt_truckTypeID.Text +
                                "" + "WeightDate = " + date +
                                "" + "InboundDate = " + date +
                                "" + "Process_id = " + Process_id.ToString() +
                                "" + "InboundWeight = " + InboundWeight +
                                "" + Name_filed + "=" + txt_vencusNo.Text +
                                "" + "WarehouseID =" + txt_locationNo.Text.Trim() +
                                "" + "DriveName =" + txt_driveName.Text.Trim() +
                                "" + "ServiceID = " + id_service.ToString() +
                                "" + "TransportID = " + txt_transportID.Text.Trim() +
                                "" + "Where[TicketCodeIn] = " + txt_ticketCode.Text.Trim();

                            Log_OldValue = "-";

                        }


                        //Truck Out
                        else
                        {

                            Price_STD = Convert.ToDecimal(txt_stdPrice.Text);
                            Discut_Weight = System.Math.Round(((DiscutValue * Convert.ToDecimal(Net_Weight)) / 100), 2, MidpointRounding.ToEven);
                            Gross_Weight = Convert.ToDecimal(Net_Weight) - Discut_Weight;
                            SumPrice_STDExt = Price_STD + PriceExt;

                            if (ProductID == "RM-004")
                            {
                                Net_Price = System.Math.Round(Gross_Weight * SumPrice_STDExt, 2, MidpointRounding.AwayFromZero);
                            }

                            //Check_ProductDensity();    

                            //Check_ProductDen 2 = สินค้าที่ไม่ต้องมีค่า den
                            //fds.Status_check  = สินค้าที่มีการยืนยันค่า den แล้ว                        
                            string Name_filed = "";
                            if (txt_weighttypeNo.Text == "01")
                            {
                                Name_filed = "Vendor_No";
                                UnitINStock = UnitINStock + Convert.ToDouble(Net_Weight);
                                //Net_Weight = weight_in - weight_out;
                            }
                            if (txt_weighttypeNo.Text == "02")
                            {
                                Name_filed = "CustomerID";
                                UnitINStock = UnitINStock - Convert.ToDouble(Net_Weight);
                                //Net_Weight = weight_out - weight_in;
                            }

                            // //test ไม้ฟืน 19/11/2021
                            con.Open();
                            string sql2 = "Update [TB_WeightData] Set OutboundDate ='" + date + "',Process_id=" + Process_id + ", OutboundWeight =" + OutboundWeight + ", EmployeeID =" + Program.user_id + ",[ServiceID]=" + id_service + ",WarehouseID='" + txt_locationNo.Text.Trim() + "',DriveName='" + txt_driveName.Text.Trim() + "',TransportID=" + txt_transportID.Text.Trim() + "," + Name_filed + "='" + txt_vencusNo.Text + "',[Remark3]='" + txt_remark.Text.Trim() + "' Where [TicketCodeIn] = '" + txt_ticketCode.Text.Trim() + "'";
                            SqlCommand CM2 = new SqlCommand(sql2, con);
                            SqlDataReader DR2 = CM2.ExecuteReader();
                            con.Close();

                            string price_net = "0.00";
                            if (Net_Price != 0)
                            {
                                price_net = Net_Price.ToString("###.##");
                            }

                            try
                            {
                                con.Open();
                                string sql3 = "Update [TB_LabConfirmPay] Set [Price] =" + Price_STD + ",[PriceNet]=" + price_net + " Where [TicketCodeIn] ='" + TicketCodeIn + "'";
                                SqlCommand CM3 = new SqlCommand(sql3, con);
                                SqlDataReader DR3 = CM3.ExecuteReader();
                                con.Close();
                            }
                            catch { con.Close(); }
                           


                            con.Open();
                            string sql4 = "Update [TB_LocationZone] Set [UnitINStock] =" + UnitINStock + " Where [NO_Zone] ='" + txt_locationNo.Text.Trim() + "' AND [ProductID] ='" + txt_productNo.Text.Trim() + "'";
                            SqlCommand CM4 = new SqlCommand(sql4, con);
                            SqlDataReader DR4 = CM4.ExecuteReader();
                            con.Close();

                            Update_StorckMovement();
                            Save_FollowProcess();

                            Msg = "Update Data on Truck Out!";
                            Log_NewValue = "ProductID =" + txt_productNo.Text +
                            "," + "Plate1 = " + txt_plateno.Text +
                            "," + "TruckTypeID = " + txt_truckTypeID.Text +
                            "," + "WeightDate = " + date +
                            "," + "InboundDate = " + date +
                            "," + "Process_id = " + Process_id.ToString() +
                            "," + "InboundWeight = " + InboundWeight +
                            "," + Name_filed + "=" + txt_vencusNo.Text +
                            "," + "WarehouseID =" + txt_locationNo.Text.Trim() +
                            "," + "DriveName =" + txt_driveName.Text.Trim() +
                            "," + "ServiceID = " + id_service.ToString() +
                            "," + "TransportID = " + txt_transportID.Text.Trim() +
                            "," + "Where[TicketCodeIn] = " + txt_ticketCode.Text.Trim();
                            Log_OldValue = "-";



                            if (Printdata_Per == 1)
                            {
                                //test ไม้ฟืน 19/11/2021
                                TypeJob = Convert.ToInt16(txt_weighttypeNo.Text.Trim());
                                TicketCodeIn = txt_ticketCode.Text.Trim();
                                ProductID = txt_productNo.Text.Trim();

                                Check_PrintAuto();

                            }
                            else { MessageBox.Show("สิทธ์การพิมพ์ไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานชั่งสินค้าเข้า-ออก)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }


                            Check_ProductDensity();

                            if (Check_ProductDen == 1)
                            {
                                ID_cusDen = txt_vencusNo.Text.Trim();
                                Ticket_Den = txt_ticketCode.Text.Trim();

                                if (ShowInsertDen == 1)
                                {
                                    F_Density fds = new F_Density();
                                    fds.Netweight = Net_Weight;
                                    fds.Vendor_Code = ID_cusDen;
                                    fds.Value_Density = ValueDensity;
                                    fds.Loss_Density = ValidDensity;
                                    fds.Qty_Product = Qty;
                                    fds.TicketCodeIn = Ticket_Den;
                                    fds.ShowDialog();

                                }
                                else
                                {
                                    Save_Density();
                                }
                            }
                        }
                                          

                        Class_Log CL = new Class_Log();
                        CL.tbname = Msg;
                        CL.oldvalue = Log_OldValue;
                        CL.newvalue = Log_NewValue;
                        CL.Save_log();

                        Send_lineAlert();
                        Clear_Textbox();

                        try
                        {
                            if (sport.IsOpen != true)
                            {
                                sport.Open();
                            }
                        }
                        catch { }                   
                    }
                }


                // Save Edit data
                else if (Status_edit == 1)
                {
                    string sql2 = "";
                    if (txt_weight_In.Text.Trim() != "" || txt_weight_In.Text.Trim() != "0")
                    {
                        InboundWeight = Convert.ToDouble(txt_weight_In.Text.Trim());
                    }

                    if (txt_weight_Out.Text.Trim() != "" || txt_weight_Out.Text.Trim() != "0")
                    {
                        OutboundWeight = Convert.ToDouble(txt_weight_Out.Text.Trim());
                    }

                    if (txt_weighttypeNo.Text == "01")
                    {
                        if (txt_weight_Net.Text == "")
                        {
                            Net_Weight = 0;
                        }

                        Price_STD = Convert.ToDecimal(txt_stdPrice.Text);
                        Discut_Weight = System.Math.Round(((DiscutValue * Convert.ToDecimal(Net_Weight)) / 100), 2, MidpointRounding.ToEven);
                        Gross_Weight = Convert.ToDecimal(Net_Weight) - Discut_Weight;
                        SumPrice_STDExt = Price_STD + PriceExt;

                        if (ProductID == "RM-004")
                        {
                            Net_Price = System.Math.Round(Gross_Weight * SumPrice_STDExt, 2, MidpointRounding.AwayFromZero);
                        }

                        //decimal Net_Price = System.Math.Round(Gross_Weight * xx, 2, MidpointRounding.AwayFromZero);
                     
                        sql2 = "Update [TB_WeightData] Set Plate1 ='" + txt_plateno.Text + "' ,Vendor_No='" + txt_vencusNo.Text + "',WarehouseID='" + txt_locationNo.Text.Trim() + "', InboundWeight=" + InboundWeight + ",OutboundWeight=" + OutboundWeight + ",ServiceID=" + id_service + ",DriveName='" + txt_driveName.Text.Trim() + "',TransportID=" + txt_transportID.Text.Trim() + ",[ProductID]='" + txt_productNo.Text + "',[Remark3]='" + txt_remark.Text.Trim() + "'  Where [TicketCodeIn] = '" + txt_ticketCode.Text.Trim() + "'";                                       

                    }

                    if (txt_weighttypeNo.Text == "02")
                    {
                        if (OutboundWeight != 0)
                        {
                            sql2 = "Update [TB_WeightData] Set Plate1 ='" + txt_plateno.Text + "' ,CustomerID='" + txt_vencusNo.Text + "',WarehouseID='" + txt_locationNo.Text.Trim() + "', InboundWeight=" + InboundWeight + ",OutboundWeight=" + OutboundWeight + ",ServiceID=" + id_service + ",DriveName='" + txt_driveName.Text.Trim() + "',TransportID=" + txt_transportID.Text.Trim() + ",[Remark3]='" + txt_remark.Text.Trim() + "' Where [TicketCodeIn] = '" + txt_ticketCode.Text.Trim() + "'";
                        }
                        else
                        {
                            sql2 = "Update [TB_WeightData] Set Plate1 ='" + txt_plateno.Text + "' ,CustomerID='" + txt_vencusNo.Text + "',WarehouseID='" + txt_locationNo.Text.Trim() + "', InboundWeight=" + InboundWeight + ",ServiceID=" + id_service + ",DriveName='" + txt_driveName.Text.Trim() + "',TransportID=" + txt_transportID.Text.Trim() + ",[Remark3]='" + txt_remark.Text.Trim() + "' Where [TicketCodeIn] = '" + txt_ticketCode.Text.Trim() + "'";
                        }
                    }


                    if (txt_weighttypeNo.Text == "03")
                    {
                        if (OutboundWeight != 0)
                        {
                            sql2 = "Update [TB_WeightData] Set InboundWeight=" + InboundWeight + ",OutboundWeight=" + OutboundWeight + " Where [TicketCodeIn] = '" + txt_ticketCode.Text.Trim() + "'";
                        }
                        else
                        {
                            sql2 = "Update [TB_WeightData] Set  InboundWeight=" + InboundWeight + " Where [TicketCodeIn] = '" + txt_ticketCode.Text.Trim() + "'";
                        }
                    }

                    con.Open();
                    SqlCommand CM2 = new SqlCommand(sql2, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    con.Close();

                    string Net_P = "0.00";
                    if (Net_Price != 0)
                    {
                        Net_P = Net_Price.ToString("###.##");
                    }

                    try
                    {
                        con.Open();
                        string sql3 = "Update [TB_LabConfirmPay] Set [Price] =" + Price_STD + ",[PriceNet]=" + Net_P + " Where [TicketCodeIn] ='" + txt_ticketCode.Text.Trim() + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, con);
                        SqlDataReader DR3 = CM3.ExecuteReader();
                        con.Close();
                    }

                    catch (Exception ex)
                    { con.Close(); MessageBox.Show(ex.ToString()); }


                    if (txt_weight_Net.Text.Trim() != "")
                    {
                        con.Open();
                        UnitINStock = UnitINStock + Net_Weight;
                        string sql4 = "Update [TB_LocationZone] Set [UnitINStock] =" + UnitINStock + " Where [NO_Zone] ='" + txt_locationNo.Text.Trim() + "' AND [ProductID] ='" + txt_productNo.Text.Trim() + "'";
                        SqlCommand CM4 = new SqlCommand(sql4, con);
                        SqlDataReader DR4 = CM4.ExecuteReader();
                        con.Close();
                    }


                    Check_ProductDensity();

                    //Enable Save Density Option
                    if (Check_ProductDen == 1)
                    {
                        // Enable Show Save Density Form
                        if (ShowInsertDen == 1)
                        {
                            F_Density fds = new F_Density();
                            fds.Netweight = Net_Weight;
                            fds.Vendor_Code = txt_vencusNo.Text.Trim();
                            fds.Value_Density = ValueDensity;
                            fds.Loss_Density = ValidDensity;
                            fds.Qty_Product = Qty;
                            fds.TicketCodeIn = txt_ticketCode.Text.Trim();
                            fds.STS_Edit = 1;
                            fds.ShowDialog();
                        }

                        //else Enable Save Density BackEnd
                        else
                        { Save_Density(); }
                    }

                    Clear_Textbox();

                    MessageBox.Show("บันทึกสำเร็จแแก้ไขสำเร็จ!!", "รายงานการบันทึก", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            else { MessageBox.Show("ไม่มีข้อมูลสำหรับบันทึก", "การบันทึกล้มเหลว!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-us"));

            Check_ProductDen = 0;
            txt_qrCode.Focus();
           
            tool_lblprogress.Text = "";
        }

        private void Save_Density()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            int STS_Edit = 0;
            //int Sealaudit_Only = 0;           
            //int Seal_Point1 = 0;
            //int Seal_Point2 = 0;
            //int Seal_Point3 = 0;
            //int Seal_Point4 = 0;
            //int Seal_Point5 = 0;
            //int Seal_Point6 = 0;
            //int Seal_Point7 = 0;
            //int Seal_Point8 = 0;
            //int Seal_Point9 = 0;
            //int Seal_Point10 = 0;
            //int Seal_Point11 = 0;
            //int Seal_Point12 = 0;
            //int Seal_Point13 = 0;
            //int Seal_Point14 = 0;
            //int Seal_Point15 = 0;

            double Qty_result_LO = 0;
            double Value_Dif_LO = 0;
            double Den_result_LO = 0;
            double Qty_result_Load = 0;
            double Value_Density_load = 0;
            double Value_Dif_Load = 0;
            double Den_result_Load = 0;
            //Weight_Den = Convert.ToDecimal(Net_Weight);
            //ID_cusDen = txt_vencusNo.Text.Trim();
            //Ticket_Den = txt_ticketCode.Text.Trim();
            //Net_Weight = Convert.ToDouble(Net_Weight);

            Qty_result_LO = Convert.ToDouble(Net_Weight / ValueDensity);  //หาจำนวนลิตร
            Value_Dif_LO = Qty_result_LO - Qty;
            Den_result_LO = (Value_Dif_LO / Qty) * 100;   //% ร้อยล่ะ
            Qty_result_Load = Convert.ToDouble(Net_Weight / 0);  //หาจำนวนลิตร
            Qty_result_Load = ValueDensity;
            TicketCodeIn = txt_ticketCode.Text.Trim();

            Value_Density_load = ValueDensity;
            Value_Dif_Load = Value_Dif_LO;


            int delta = DayOfWeek.Monday - DateTime.Now.DayOfWeek;
            DateTime monday = DateTime.Now.AddDays(delta == 1 ? -6 : delta);
            string date = monday.ToString("yyyy-MM-dd") + " 00:00:00";

            con.Open();
            string sql6 = "SELECT Count([TicketCodeIn]) AS 'T_Count' FROM [dbo].[TB_DensityRecord] WHERE [TicketCodeIn]= '" + TicketCodeIn + "'";
            SqlCommand CM6 = new SqlCommand(sql6, con);
            SqlDataReader DR6 = CM6.ExecuteReader();

            DR6.Read();
            {
                STS_Edit = Convert.ToInt16(DR6["T_Count"].ToString().Trim());
            }
            DR6.Close();
            con.Close();
                                 

            string sql = "";

            if (STS_Edit == 0)
            {
                sql = "Insert Into [TB_DensityRecord] ([TicketCodeIn],[DateRecordDen],[Qty_ProSTD],[Qty_Product],[LabDensity],[ValueDensity],[DeffDensity],[Qty_Product_Load],[LabDensity_Load],[ValueDensity_Load],[DeffDensity_Load],[BranchID],[Degree_ID]) Values('" + TicketCodeIn + "','" + date + "'," + Qty + ", " + Qty_result_LO.ToString("#") + ", " + ValueDensity + "," + Value_Dif_LO.ToString("F") + ", " + Den_result_LO.ToString("F") + ", " + Qty_result_LO.ToString("#") + ", " + Value_Density_load + "," + Value_Dif_Load.ToString("F") + ", " + Den_result_Load.ToString("F") + ",'02',0)";

                Msg = "Insert Data in DensityRecord!";
            }

            if (STS_Edit == 1)
            {
                sql = "Update [TB_DensityRecord]  Set [DateRecordDen] ='" + date + "',[Qty_ProSTD] = " + Qty + ",[Qty_Product]=" + Qty_result_LO.ToString("#") + ",[LabDensity]= " + ValueDensity + ",[ValueDensity] =" + Value_Dif_LO.ToString("F") + ",[DeffDensity]=" + Den_result_LO.ToString("F") + ", [Qty_Product_Load]=" + Qty_result_LO.ToString("#") + ",[LabDensity_Load]= " + Value_Density_load + ",[ValueDensity_Load]=" + Value_Dif_Load.ToString("F") + ",[DeffDensity_Load]=" + Den_result_Load.ToString("F") + "  WHERE [TicketCodeIn] = '" + TicketCodeIn + "'";

                Msg = "Update Data in DensityRecord!";
            }

            con.Open();
            SqlCommand CM2 = new SqlCommand(sql, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();

        }

        private void Send_lineAlert()
        {
            string msg1 = "";
            string sql = "";
            //Gross_Weight = Convert.ToDecimal(txt_weight_Net.Text);
            //Price_STD = Convert.ToDecimal(txt_stdPrice.Text);
            //Discut_Weight = System.Math.Round(((DiscutValue * Gross_Weight) / 100), 2, MidpointRounding.ToEven);
            //Gross_Weight = Gross_Weight - Discut_Weight;
            //SumPrice_STDExt = Price_STD + PriceExt;


            if (txt_queType.Text == "IN")
            {
                msg1 = "รายงาน: งานชั่งน้ำหนักเข้า" + Environment.NewLine + " บัตรชั่งเลขที่: " + txt_ticketCode.Text.Trim() + " คิวที่: " + txt_queNo.Text.Trim() + " สินค้า: " + ProductName + " ทะเบียนรถ: " + txt_plateno.Text.Trim() + Environment.NewLine + " ประเภทชั่ง: " + lbl_weightTypeName.Text.Trim() + " ชือผู้ขาย/ผู้ซื้อ: " + lbl_vencusName.Text.Trim() + " น้ำหนักเข้า: " + txt_weight_In.Text.Trim() + " ";
                sql = "SELECT [AL_lineNameToken] FROM [dbo].[V_TokenLine] WHERE [ID_processType]='WI' AND [ProductID]='" + ProductID + "' AND [AL_lineStatus]=1";
            }

            if (txt_queType.Text == "OUT")
            {
                msg1 = "รายงาน: งานชั่งน้ำหนักออก" + Environment.NewLine + " บัตรชั่งเลขที่: " + txt_ticketCode.Text.Trim() + " คิวที่: " + txt_queNo.Text.Trim() + " สินค้า: " + ProductName + " ทะเบียนรถ: " + txt_plateno.Text.Trim() + Environment.NewLine + " ประเภทชั่ง: " + lbl_weightTypeName.Text.Trim() + " ชือผู้ขาย/ผู้ซื้อ: " + lbl_vencusName.Text.Trim() + " น้ำหนักเข้า: " + txt_weight_In.Text.Trim() + " น้ำหนักออก: " + txt_weight_Out.Text.Trim() + " น้ำหนักสุทธิ/ก่อนหัก: " + Net_Weight.ToString() + " น้ำหนักสิ่งเจือป่น: " + Discut_Weight.ToString() + " น้ำหนักหลังจัก สิ่งเจือป่น: " + Gross_Weight.ToString() + " ";

                sql = "SELECT [AL_lineNameToken] FROM [dbo].[V_TokenLine] WHERE [ID_processType]='WO' AND [ProductID]='" + ProductID + "' AND [AL_lineStatus]=1";
            }


                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();           

            try
            {
                con.Open();
                SqlCommand CM = new SqlCommand(sql, con);
                SqlDataReader DR = CM.ExecuteReader();
                while (DR.Read())
                {
                    token = DR["AL_lineNameToken"].ToString();
                    lineNotify(msg1);
                }
                DR.Close();
                con.Close();
            }
            catch { con.Close(); }
        }

        private void lineNotify(string msg)
        {
            _lineNotify(msg, 0, 0, "");
        }

        private void _lineNotify(string msg, int stickerPackageID, int stickerID, string pictureUrl)
        {
            //string token = "EdpkjZaUn6Sl5wCf0hDge2jXUePDZ7aTTdhpv6XOPda";
            try
            {
                var request = (System.Net.HttpWebRequest)WebRequest.Create("https://notify-api.line.me/api/notify");

                var postData = string.Format("message={0}", msg);

                if (stickerPackageID > 0 && stickerID > 0)
                {
                    var stickerPackageId = string.Format("stickerPackageId={0}", stickerPackageID);
                    var stickerId = string.Format("stickerId={0}", stickerID);
                    postData += "&" + stickerPackageId.ToString() + "&" + stickerId.ToString();
                }

                var data = Encoding.UTF8.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.Headers.Add("Authorization", "Bearer " + token);

                using (var stream = request.GetRequestStream()) stream.Write(data, 0, data.Length);
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
        }


        private void Update_StorckMovement()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            //SqlDataAdapter dtAdapter = new SqlDataAdapter();
            //dtAdapter.SelectCommand.CommandTimeout = 0;
            con.Open();

            string Remark = "Ticket No: " + txt_ticketCode.Text.Trim();

            string Date =DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US")) + " " + DateTime.Now.ToString("HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));

            string sql3 = "";
            //  purchase
            if (txt_weighttypeNo.Text == "01")
            {
                sql3 = "Insert Into [TB_StockMovement] ([Stock_MoveDate],[ProductID],[Stock_In],[Stock_Balance],[Stock_UnitPrice],[Stock_TypeID],[Stock_Zone],[Stock_Remark])  Values ('" + Date + "','" + txt_productNo.Text.Trim() + "'," + Net_Weight + "," + UnitINStock + "," + txt_stdPrice.Text.Trim() + ",'P','" + txt_locationNo.Text.Trim() + "','" + Remark + "' )";
            }

            //  Sale
            if (txt_weighttypeNo.Text == "02")
            {
                sql3 = "Insert Into [TB_StockMovement] ([Stock_MoveDate],[ProductID],[Stock_Out],[Stock_Balance],[Stock_UnitPrice],[Stock_TypeID],[Stock_Zone],[Stock_Remark])  Values ('" + Date + "','" + txt_productNo.Text.Trim() + "'," + Net_Weight + "," + UnitINStock + "," + txt_stdPrice.Text.Trim() + ",'S','" + txt_locationNo.Text.Trim() + "','" + Remark + "')";
            }
            
            //string sql3 = "Insert Into [TB_LabConfirmPay] ([TicketCodeIn],[Price],[PriceNet])  Values ('" + txt_ticketCode.Text.Trim() + "'," + Price_STD + "," + Net_Price.ToString("###.##") + ")";
            SqlCommand CM3 = new SqlCommand(sql3, con);
            SqlDataReader DR3 = CM3.ExecuteReader();
            con.Close();
            
        }



        private void Check_PrintAuto()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                //SqlDataAdapter dtAdapter = new SqlDataAdapter();
                //dtAdapter.SelectCommand.CommandTimeout = 0;
                con.Open();

                int id_printPrivew = 0;
                string sql1 = "SELECT [PrintAuto],[PrintEthFormat] FROM [dbo].[TB_WeightscaleSetting] WHERE [WeightProductID]= '" + ProductID + "' ";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    if (DR1["PrintAuto"].ToString() == "False")
                    {
                        id_printPrivew = 1;
                    }

                    if (DR1["PrintEthFormat"].ToString() == "True")
                    {
                        STS_PrintEthFormat = 1;
                    }
                }
                DR1.Close();
                con.Close();

                DataSet ds = new DataSet();

                string sql2 = "";

                // id print 1-5 เป็นตัวรายงานที่หน้าเครื่องชั่ง
                //PrintformID                                      //typejob
                //   1   มันเส้น                                  1 ซื้อ
                //   2    มันสด                                  2 ขาย
                //   3   ไม้สับ, เอทานอล  ใช้บัตรทั่วไป
                //  4    wet cake ใบเล็ก
                //   5
                //   6    ออกใบตั๋วชั่ง barcode audto
             

                //--TypeJob 1 = งานซื้อ
                //--TypeJob 2 = งานขาย

                if (PrintformID == 1 || PrintformID == 2)
                {
                    //sql2 = "Select * From   [dbo].[V_PrintTicket_Sale] Where [TicketCodeIn] ='" + TicketCodeIn + "'";

                    //sql2 = "Select Top 1 * From   [dbo].[V_PrintTicket] Where [TicketCodeIn] ='" + TicketCodeIn + "'";


                    if (TypeJob == 1)
                    {
                        sql2 = "Select * From  [dbo].[V_WeightData] Where [TicketCodeIn] ='" + TicketCodeIn + "'";
                        //sql2 = "Select * From  [dbo].[V_PrintTicket] Where [TicketCodeIn] ='" + TicketCodeIn + "'";
                    }
                    if (TypeJob == 2)
                    {
                        sql2 = "Select * From  [dbo].[V_WeightData_Sale] Where [TicketCodeIn] ='" + TicketCodeIn + "'";
                        //sql2 = "Select * From  [dbo].[V_PrintTicket_Sale] Where [TicketCodeIn] ='" + TicketCodeIn + "'";
                    }

                }

                //if (PrintformID == 3)
                //{
                //    sql2 = "Select * From   [dbo].[V_WeightData_Sale] Where [TicketCodeIn] ='" + TicketCodeIn + "'";
                //}

                //if (PrintformID == 4)
                //{
                //    //sql2 = "Select * From [dbo].[V_PrintAuto] Where [ID_Barcode] ='" + ID_Barcode + "'";
                //    sql2 = "Select * From  [dbo].[V_WeightData_Sale] Where [TicketCodeIn] ='" + TicketCodeIn + "'";
                //}
                
                
                if (PrintformID == 1 || PrintformID == 3)  //ticket truck out  orther product  มันเส้น
                {
                    if (TypeJob == 1) // ซื้อ
                    {
                        if (id_printPrivew == 0)
                        {
                            crp_TKCasawaChip_auto crt_ticket = new crp_TKCasawaChip_auto();
                            SqlDataAdapter adapter = new SqlDataAdapter(sql2, con);
                            adapter.SelectCommand.CommandTimeout = 0;
                            adapter.Fill(ds, "TicketOut");
                            crt_ticket.SetDataSource(ds.Tables["TicketOut"]);

                            CrystalDecisions.Shared.PageMargins marginX = new CrystalDecisions.Shared.PageMargins();
                            marginX.leftMargin = 0;
                            marginX.rightMargin = 0;
                            marginX.topMargin = 0;
                            marginX.bottomMargin = 0;

                            crt_ticket.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                            crt_ticket.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                            crt_ticket.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                            crt_ticket.PrintOptions.ApplyPageMargins(marginX);
                            crt_ticket.PrintToPrinter(1, false, 0, 0);
                        }

                        if (id_printPrivew == 1)
                        {
                            F_ReportCRT fcr = new F_ReportCRT();
                            fcr.PrintformID = PrintformID;
                            fcr.PrintEthFormat = STS_PrintEthFormat;
                            fcr.id_typeJob = TypeJob;
                            fcr.id_product = ProductID;
                            fcr.id_ticket = TicketCodeIn;
                            fcr.ShowDialog();

                            //testc 
                            //
                            //F_Report Frp = new F_Report();
                            //Frp.Ticket_code = TicketCodeIn;                
                            //Frp.ShowDialog();
                        }
                    }

                    if (TypeJob == 2)  //ขาย
                    {
                        if (id_printPrivew == 0)
                        {
                            crp_TKSaleProduct crt_ticket = new crp_TKSaleProduct();
                            SqlDataAdapter adapter = new SqlDataAdapter(sql2, con);
                            adapter.SelectCommand.CommandTimeout = 0;
                            adapter.Fill(ds, "TicketSale");
                            crt_ticket.SetDataSource(ds.Tables["TicketSale"]);
                            crt_ticket.PrintToPrinter(1, false, 0, 0);
                        }

                        if (id_printPrivew == 1)
                        {
                            F_ReportCRT fcr = new F_ReportCRT();
                            fcr.PrintformID = PrintformID;
                            fcr.PrintEthFormat = STS_PrintEthFormat;
                            fcr.id_typeJob = TypeJob;
                            fcr.id_product = ProductID;
                            fcr.id_ticket = TicketCodeIn;
                            fcr.ShowDialog();
                        }
                    }



                }

                if (PrintformID == 2) //ticket truck out  มันสด
                {
                    if (id_printPrivew == 0)
                    {
                        crp_TKCasawaRoot_auto crt_ticket = new crp_TKCasawaRoot_auto();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql2, con);
                        adapter.SelectCommand.CommandTimeout = 0;
                        adapter.Fill(ds, "TicketOut");
                        crt_ticket.SetDataSource(ds.Tables["TicketOut"]);

                        crt_ticket.PrintToPrinter(1, false, 0, 0);

                        CrystalDecisions.Shared.PageMargins marginX = new CrystalDecisions.Shared.PageMargins();
                        marginX.leftMargin = 0;
                        marginX.rightMargin = 0;
                        marginX.topMargin = 0;
                        marginX.bottomMargin = 0;

                        crt_ticket.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                        crt_ticket.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                        crt_ticket.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                        crt_ticket.PrintOptions.ApplyPageMargins(marginX);
                        crt_ticket.PrintToPrinter(1, false, 0, 0);

                        //Print_Ticket();
                    }

                    if (id_printPrivew == 1)
                    {
                        F_ReportCRT fcr = new F_ReportCRT();
                        fcr.PrintformID = PrintformID;
                        fcr.PrintEthFormat = STS_PrintEthFormat;
                        fcr.id_typeJob = TypeJob;
                        fcr.id_product = ProductID;
                        fcr.id_ticket = TicketCodeIn;
                        fcr.ShowDialog();
                    }
                }

                if (PrintformID == 4) //barcode Auto Truck IN
                {
                    int CheckItems = 0;
                    con.Open();
                    string sql10 = "Select Count([TicketCodeIn]) AS 'C_Items' From [dbo].[V_WeightAuto_PUR] Where [TicketCodeIn] ='" + TicketCodeIn + "'";
                    SqlCommand CM10 = new SqlCommand(sql10, con);
                    SqlDataReader DR10 = CM10.ExecuteReader();

                    DR10.Read();
                    {
                        try
                        {
                            CheckItems = Convert.ToInt16(DR10["C_Items"].ToString());
                        }
                        catch { }
                    }
                    DR10.Close();
                    con.Close();

                    if (CheckItems != 0)
                    {
                        sql2 = "Select * From  [dbo].[V_WeightAuto_Pur] Where [TicketCodeIn] ='" + TicketCodeIn + "'";
                    }

                    else
                    {
                        sql2 = "Select * From  [dbo].[V_WeightAuto_Sale] Where [TicketCodeIn] ='" + TicketCodeIn + "'";
                    }

                    if (Status_Weight == "IN")
                    {
                        if (CheckItems != 0)
                        {
                            crp_TKprintAutoIN_Pur crt_ticket = new crp_TKprintAutoIN_Pur();
                            SqlDataAdapter adapter = new SqlDataAdapter(sql2, con);
                            adapter.SelectCommand.CommandTimeout = 0;
                            adapter.Fill(ds, "Ticketin_Auto");
                            crt_ticket.SetDataSource(ds.Tables["Ticketin_Auto"]);
                            crt_ticket.PrintToPrinter(1, false, 0, 0);
                        }

                        else {

                            crp_TKprintAutoIN_Sale crt_ticket = new crp_TKprintAutoIN_Sale();
                            SqlDataAdapter adapter = new SqlDataAdapter(sql2, con);
                            adapter.SelectCommand.CommandTimeout = 0;
                            adapter.Fill(ds, "Ticketin_Auto");
                            crt_ticket.SetDataSource(ds.Tables["Ticketin_Auto"]);
                            crt_ticket.PrintToPrinter(1, false, 0, 0);

                        }
                    }


                    if (Status_Weight == "OUT")
                    {
                        if (CheckItems != 0)
                        {
                            crp_TKprintAutoOUT_Pur crt_ticket = new crp_TKprintAutoOUT_Pur();
                            SqlDataAdapter adapter = new SqlDataAdapter(sql2, con);
                            adapter.SelectCommand.CommandTimeout = 0;
                            adapter.Fill(ds, "Ticketout_Auto");
                            crt_ticket.SetDataSource(ds.Tables["Ticketout_Auto"]);
                            crt_ticket.PrintToPrinter(1, false, 0, 0);
                        }

                        else
                        {
                            crp_TKprintAutoOUT_Sale crt_ticket = new crp_TKprintAutoOUT_Sale();
                            SqlDataAdapter adapter = new SqlDataAdapter(sql2, con);
                            adapter.SelectCommand.CommandTimeout = 0;
                            adapter.Fill(ds, "Ticketout_Auto");
                            crt_ticket.SetDataSource(ds.Tables["Ticketout_Auto"]);
                            crt_ticket.PrintToPrinter(1, false, 0, 0);

                        }
                       
                    }
                    
                    txt_msgAuto.Text = "บันทึกข้อมูลสำเร็จ!";
                    Clear_Textbox();
                    txt_qrCode.Focus();
                }

                if (PrintformID == 6) //ticket barcode watcake
                {

                    
                    //sql2 = "Select * From  [dbo].[V_WeightData_Sale] Where [TicketCodeIn] ='" + TicketCodeIn + "'";

                    //if (id_printPrivew == 0)
                    //{
                    //    crp_TKbarCodeAuto crt_ticket = new crp_TKbarCodeAuto();
                    //    SqlDataAdapter adapter = new SqlDataAdapter(sql2, con);
                    //    adapter.SelectCommand.CommandTimeout = 0;
                    //    adapter.Fill(ds, "TicketOut");
                    //    crt_ticket.SetDataSource(ds.Tables["TicketOut"]);
                    //    crt_ticket.SetParameterValue("UserName", Program.user_name);
                    //    crt_ticket.PrintToPrinter(1, false, 0, 0);

                    //}

                    //if (id_printPrivew == 1)
                    //{
                    //    F_ReportCRT fcr = new F_ReportCRT();
                    //    fcr.PrintformID = PrintformID;
                    //    fcr.id_typeJob = TypeJob;
                    //    fcr.id_product = ProductID;
                    //    fcr.id_ticket = TicketCodeIn;
                    //    fcr.ShowDialog();
                    //}
                }
                               
                con.Close();                

            }
            catch (Exception ex)
            { txt_msgAuto.Text = ex.ToString().Trim(); }

        }
               
        private void Check_ProductDensity()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                
                con.Open();
                string sql4 = "SELECT [ActiveDensity],[ShowInsertDen],[ValueDensity],[ValidDensity],[Qtyethanal]  FROM [dbo].[TB_LabSetting]  Where [LabProductID] ='" + ProductID + "'";
                SqlCommand CM4 = new SqlCommand(sql4, con);
                SqlDataReader DR4 = CM4.ExecuteReader();

                DR4.Read();
                {
                    if (DR4["ActiveDensity"].ToString() == "True")
                    {
                        Check_ProductDen = 1;
                        //ShowInsertDen= Convert.ToInt16(DR4["ShowInsertDen"].ToString());
                        ValueDensity = Convert.ToDouble(DR4["ValueDensity"].ToString());   //ค่า den
                        ValidDensity = Convert.ToDouble(DR4["ValidDensity"].ToString());   //error รับได้
                        Qty = Convert.ToDouble(DR4["Qtyethanal"].ToString());  //ปริมาตร

                        if (DR4["ShowInsertDen"].ToString() == "True")
                        {
                            ShowInsertDen = 1;
                        }

                    }

                    else { Check_ProductDen = 2; }
                }
                DR4.Close();
                con.Close();
            }
            catch {
              //  MessageBox.Show("สินค้านี้ยังไม่ได้กำหนดเงื่อนไข Density เริ่ม กรุณาไปกำหนด", "การบันทึกล้มเหลว!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private void Load_LocationProduct()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            //SqlDataAdapter dtAdapter = new SqlDataAdapter();
            //dtAdapter.SelectCommand.CommandTimeout = 0;

            int ID_Mointure = 0;
            decimal Value_M = 0;
            decimal Value_Select = 0;

            try   //check Lab ลงคลังหรือไม่
            {
                con.Open(); // Load Lab Type  ID in Check Stock


                string sql1 = "SELECT LabTypeID FROM  [dbo].[TB_LabType] WHERE  (LabTypeProductID = '" + txt_productNo.Text.Trim() + "') AND (LabInStock = 1)";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    ID_Mointure = Convert.ToInt16(DR1["LabTypeID"].ToString());
                }
                DR1.Close();
                con.Close();


                con.Open(); // Load Value Lab in Location
                string sql2 = "SELECT MAX(ValueLab) AS ValueLab  FROM [dbo].[V_LabCheckLocation]  WHERE LabTypeID = " + ID_Mointure + " AND [ProductID] ='" + txt_productNo.Text.Trim() + "' AND [TicketCodeIn]='" + txt_ticketCode.Text.Trim() + "'";
                SqlCommand CM2 = new SqlCommand(sql2, con);
                SqlDataReader DR2 = CM2.ExecuteReader();

                DR2.Read();
                {
                    if (DR2["ValueLab"].ToString() != "")
                    {
                        Value_M = Convert.ToDecimal(DR2["ValueLab"].ToString());
                    }
                }
                DR2.Close();
                con.Close();


                if (Value_M != 0)
                {
                    con.Open(); // Get Value on Range % mointure
                    string sql3 = "Select Max([QtyName]) AS MAXQTY  FROM [dbo].[V_LocationZone] WHERE [ProductID] ='" + txt_productNo.Text.Trim() + "' AND [QtyName] <" + Value_M + "  AND [Product_Vendor]='" + txt_vencusNo.Text.Trim() + "' ";
                    SqlCommand CM3 = new SqlCommand(sql3, con);
                    SqlDataReader DR3 = CM3.ExecuteReader();

                    DR3.Read();
                    {
                        Value_Select = Convert.ToDecimal(DR3["MAXQTY"].ToString());
                    }
                    DR3.Close();
                    con.Close();
                }


                con.Open();
                string sql4 = "";

                if (Value_Select != 0)
                {
                    sql4 = "SELECT [NO_Zone],[Name_Zone]  FROM [dbo].[V_LocationZone]  Where [ProductID] ='" + txt_productNo.Text.Trim() + "' AND [QtyName]=" + Value_Select + " AND [Product_Vendor]='" + txt_vencusNo.Text.Trim() + "' ";
                }
                else { sql4 = "SELECT [NO_Zone],[Name_Zone]  FROM [dbo].[V_LocationZone]  Where [ProductID] ='" + txt_productNo.Text.Trim() + "'"; }

                SqlCommand CM4 = new SqlCommand(sql4, con);
                SqlDataReader DR4 = CM4.ExecuteReader();

                DR4.Read();
                {
                    txt_locationNo.Text = DR4["NO_Zone"].ToString().Trim();
                    lbl_locationName.Text = DR4["Name_Zone"].ToString().Trim();
                }
                DR4.Close();
                con.Close();

            }

            catch  //ถ้าไม่ลงให้ดูจุดลงได้เลย
                       
            {
                try
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    //MessageBox.Show("สินค้าตัวนี้ไม่ได้ระบบจุดลง / ไม่เปิดใช้งาน","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    con.Open();
                    string sql4 = "SELECT [NO_Zone],[Name_Zone]  FROM [dbo].[V_LocationZone]  Where [ProductID] ='" + txt_productNo.Text.Trim() + "'";
                    SqlCommand CM4 = new SqlCommand(sql4, con);
                    SqlDataReader DR4 = CM4.ExecuteReader();

                    DR4.Read();
                    {
                        txt_locationNo.Text = DR4["NO_Zone"].ToString().Trim();
                        lbl_locationName.Text = DR4["Name_Zone"].ToString().Trim();
                    }
                    DR4.Close();
                    con.Close();
                }

                catch { MessageBox.Show("สินค้าตัวนี้ไม่ได้ระบบจุดลง / ไม่เปิดใช้งาน", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }

        }

                     
        private void Clear_Textbox()
        {
            txt_weighttypeNo.Clear();
            lbl_weightTypeName.Text = "";
            txt_productNo.Clear();
            lbl_productName.Text = "";
            txt_plateno.Clear();
            txt_truckTypeID.Clear();
            lbl_truckType.Text = "";
            txt_vencusNo.Clear();
            lbl_vencusName.Text = "";
            txt_queNo.Text = "คิวที่ -";
            txt_queType.Text = "-";
            chk_chageService.Checked = false;
            txt_ticketCode.Clear();
            txt_dateWeight.Clear();
            txt_weight_In.Text = "0.00";
            txt_weight_Out.Text = "0.00";
            txt_weight_Net.Text = "0.00";
            txt_locationNo.Clear();
            lbl_locationName.Text = "";
            txt_stdPrice.Clear();
            txt_driveName.Clear();
            tg_printFormat1.Checked = false;
            tg_printFormat2.Checked = false;
            tg_printFormat3.Checked = false;
            tg_printFormat4.Checked = false;
            Status_edit = 0;   
            txt_priceNet.Clear();
            txt_transportID.Clear();
            lbl_transportName.Text = "";
            txt_remark.Clear();
            tg_Win.Checked = false;
            tg_Wout.Checked = false;
            InboundWeight = 0;
            OutboundWeight = 0;
            id_service = 0;
            TruckType = 0;
            Net_Weight = 0;
            txt_qrCode.Clear();
            txt_qrCode.Focus();



            ProductID = "";
            QueueNo = 0;
            TicketCodeIn = "";
            LocationID = "";
            Status_WI = 0;
            Status_WO = 0;
        }


        private void txt_weight_In_TextChanged(object sender, EventArgs e)
        {
            //txt_weight_In.Text = set_format.ToString("##,###.##");
            i = 3; btn_save.Enabled = false;
        }

        int i = 3;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (i != 0)
                {
                    i = i - 1;
                }

                else
                {
                    if (txt_ticketCode.Text != "" && chk_weightAuto.Checked == false)
                    {
                        btn_save.Enabled = true; //sport.Close();
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        private void txt_weightInterface_TextChanged(object sender, EventArgs e)
        {

        }

        private void F_Weight_FormClosed(object sender, FormClosedEventArgs e)
        {
            sport.Close();
        }

        private void btn_etcidproductFind_Click(object sender, EventArgs e)
        {
            if (txt_ticketCode.Text != "")
            {
                F_Search fnd = new F_Search();
                fnd.id_findType = 11;
                fnd.ShowDialog();
                if (fnd.id_value != "")
                {
                    txt_productNo.Text = fnd.id_value;
                    lbl_productName.Text = fnd.name_value;
                }

                Load_Location();
            }
        }

       

        private void btn_findLocation_Click(object sender, EventArgs e)
        {
            if (txt_ticketCode.Text != "")
            {
                // find location
                F_Search fnd = new F_Search();
                fnd.id_findType = 10;
                fnd.id_product = txt_productNo.Text.Trim();
                fnd.id_vendor = txt_vencusNo.Text.Trim();
                fnd.ShowDialog();

                if (fnd.id_value.Trim() != "")
                {
                    txt_locationNo.Text = fnd.id_value;
                    lbl_locationName.Text = fnd.name_value;
                }

            }
        }

        private void btn_findTrucktype_Click(object sender, EventArgs e)
        {
            if (txt_ticketCode.Text != "")
            {
                F_Search fnd = new F_Search();
                fnd.id_findType = 5;

                fnd.ShowDialog();

                if (fnd.id_value != "")
                {
                    txt_truckTypeID.Text = fnd.id_value;
                    lbl_truckType.Text = fnd.name_value;
                }
            }

            if (txt_truckTypeID.Text != "")
            {
                Load_Services();              
            }

        }

        private void Load_ServicesAuto()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;

            int Single_Truck = 0;
            int Double_Truck = 0;
            int TruckTypeID = 0;          

            con.Open();
            string sql = "SELECT [TruckTypeID],[TruckCapacity] FROM[dbo].[TB_TruckType] ";
            SqlCommand CM = new SqlCommand(sql, con);
            SqlDataReader DR = CM.ExecuteReader();

           while (DR.Read())
            {
                if (DR["TruckTypeID"].ToString().Trim() == "1")
                {
                    Single_Truck = Convert.ToInt32(DR["TruckCapacity"].ToString().Trim());
                }

                if (DR["TruckTypeID"].ToString().Trim() == "2")
                {
                    Double_Truck = Convert.ToInt32(DR["TruckCapacity"].ToString().Trim());
                }

            }
            DR.Close();
            con.Close();


            if (InboundWeight > OutboundWeight)
            {
                if (OutboundWeight <= Single_Truck)
                {
                    TruckTypeID = 1;
                }

                if (OutboundWeight >= Double_Truck)
                {
                    TruckTypeID = 2;
                }

                Net_Weight = InboundWeight - OutboundWeight;
            }

            if (InboundWeight < OutboundWeight)
            {

                if (InboundWeight <= Single_Truck)
                {
                    TruckTypeID = 1;
                }

                if (InboundWeight >= Double_Truck)
                {
                    TruckTypeID = 2;
                }

                Net_Weight = OutboundWeight - InboundWeight;
            }
                    
            
            txt_truckTypeID.Text = TruckTypeID.ToString();

            con.Open();
            string sql1 = "SELECT [ServiceID] FROM[dbo].[TB_Services] WHERE [WeightProductID] = '" + txt_productNo.Text.Trim() + "' AND [TruckTypeID] = " + TruckTypeID + "";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                id_service = Convert.ToInt16(DR1["ServiceID"].ToString().Trim());
            }
            DR1.Close();
            con.Close();

        }

        private void Load_Services()
        {
            try
            {
                CBO_Service();  

                cbo_serviceName.DataSource = null;
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                //SqlDataAdapter dtAdapter = new SqlDataAdapter();
                //dtAdapter.SelectCommand.CommandTimeout = 0;          

                con.Open();
                string sql1 = "SELECT [ServiceID] FROM[dbo].[TB_Services] WHERE [WeightProductID] = '" + ProductID + "' AND [TruckTypeID] = " + TruckType + "";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    id_service = Convert.ToInt16(DR1["ServiceID"].ToString().Trim());
                }
                DR1.Close();
                con.Close();            


                if (id_service != 0  && chk_weightAuto.Checked ==true)
                {
                    con.Open();
                    int IncludeVat = 0;
                    string sql2 = "SELECT [ServiceName],[WeightPrice],[LoadPrice],[IncludeVat],[ServiceStatus]   FROM [dbo].[TB_Services] where [ServiceID]=" + id_service + "";
                    SqlCommand CM2 = new SqlCommand(sql2, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();

                    DR2.Read();
                    {
                        if (DR2["ServiceStatus"].ToString().Trim() == "True")
                        {
                            chk_chageService.Checked = true;
                            cbo_serviceName.Enabled = true;

                            //cbo_serviceName.SelectedValue = id_service;
                            cbo_serviceName.Text = DR2["ServiceName"].ToString().Trim();

                            txt_weightPrice.Text = DR2["WeightPrice"].ToString().Trim();
                            txt_loadPrice.Text = DR2["LoadPrice"].ToString().Trim();

                            if (DR2["IncludeVat"].ToString().Trim() == "True")
                            {
                                IncludeVat = 1;
                            }

                            int total_price = Convert.ToInt32(txt_weightPrice.Text.Trim()) + Convert.ToInt32(txt_loadPrice.Text.Trim());
                            txt_totalPrice.Text = total_price.ToString();

                            if (IncludeVat == 1)
                            { lbl_vat.Text = "รวมภาษีมูลค่าเพิ่มแล้ว"; lbl_vat.ForeColor = Color.Blue; }

                            else { lbl_vat.Text = "ไม่รวมภาษีมูลค่าเพิ่ม"; lbl_vat.ForeColor = Color.Yellow; }
                        }



                    }
                    DR2.Close();
                    con.Close();
                }

                if (chk_chageService.Checked == false)
                {
                    cbo_serviceName.Text = " -- เลือกประเภทการบริการ -- ";
                    txt_weightPrice.Text = "-";
                    txt_loadPrice.Text = "-";
                    txt_totalPrice.Text = "-";
                }
            }
            catch
            {
              
            }

        }

        private void CBO_Service()
        {
            try
            {
                cbo_serviceName.DataSource = null;
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT [ServiceID],[ServiceName] FROM [dbo].[TB_Services] where  [WeightProductID] = '" + ProductID + "' AND [TruckTypeID]=" + TruckType + "", con);

                DataSet ds = new DataSet();
                //ds.Clear();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(ds);
                //Load product tab weight scale Setup
                cbo_serviceName.DataSource = ds.Tables[0];
                cbo_serviceName.DisplayMember = "ServiceName";
                cbo_serviceName.ValueMember = "ServiceID";
                con.Close();
            }
            catch
                { }
               
        }


        private void btn_vencusFind_Click(object sender, EventArgs e)
        {
            if (txt_ticketCode.Text != "")
            {
                F_Search fnd = new F_Search();                
                if (txt_weighttypeNo.Text == "01")  //งานซื้อ  ค้นหาผู้ขาย
                { fnd.id_findType = 3; }
                if (txt_weighttypeNo.Text == "02")   //งานขาย ค้นหาผู้ซื้อ
                { fnd.id_findType = 4; }
                fnd.ShowDialog();
                txt_vencusNo.Text = fnd.id_value;
                lbl_vencusName.Text = fnd.name_value;

                Load_Location();
                //txt_locationNo.Clear();
                lbl_locationName.BackColor = SystemColors.ActiveCaption;            

            }
        }

        private void Load_Location()
        {

                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
            //    SqlDataAdapter dtAdapter = new SqlDataAdapter();
            //dtAdapter.SelectCommand.CommandTimeout = 0;
            int Id_count = 0;
                string SQL2 = "";
                try
                {
                    con.Open();
                    string sql1 = "SELECT Count([NO_Zone])AS CountCheck FROM [dbo].[V_LocationZone] WHERE [ProductID] = '" + txt_productNo.Text.Trim() + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, con);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    {
                        Id_count = Convert.ToInt16(DR1["CountCheck"].ToString());
                    }
                    DR1.Close();
                    con.Close();

                }
                catch (Exception ex)
            { con.Close();  MessageBox.Show(ex.ToString()); }


                if (Id_count != 0)
                {
                    try
                    {
                        int id_C = 0;
                        con.Open();
                        string sql1 = "SELECT Count([NO_Zone]) AS CountCheck FROM [dbo].[V_LocationZone] WHERE [ProductID] = '" + txt_productNo.Text.Trim() + "' AND [Product_Vendor] ='" + txt_vencusNo.Text.Trim() + "' ";
                        SqlCommand CM1 = new SqlCommand(sql1, con);
                        SqlDataReader DR1 = CM1.ExecuteReader();

                        DR1.Read();
                        {
                            id_C = Convert.ToInt16(DR1["CountCheck"].ToString());
                        }
                        DR1.Close();
                        con.Close();


                        if (id_C != 0)
                        {
                            SQL2 = "SELECT [NO_Zone],[Name_Zone] FROM  [dbo].[V_LocationZone] WHERE  [ProductID]  ='" + txt_productNo.Text.Trim() + "' AND [Product_Vendor]='" + txt_vencusNo.Text.Trim() + "'";
                        }

                        else
                        {
                            //txt_locationNo.Clear();
                            //lbl_locationName.Text = "";

                            int id_X = 0;
                            con.Open();
                            string sql3 = "SELECT Count([NO_Zone]) AS CountCheck FROM [dbo].[V_LocationZone] WHERE [ProductID] = '" + txt_productNo.Text.Trim() + "'  AND  [Product_Vendor] IS NULL ";
                            SqlCommand CM3 = new SqlCommand(sql3, con);
                            SqlDataReader DR3 = CM3.ExecuteReader();

                            DR3.Read();
                            {
                                id_X = Convert.ToInt16(DR3["CountCheck"].ToString());
                            }
                            DR3.Close();
                            con.Close();


                            if (id_X != 0)
                            {
                                con.Open();
                                string sql4 = "SELECT [NO_Zone],[Name_Zone] FROM [dbo].[V_LocationZone] WHERE [ProductID] = '" + txt_productNo.Text.Trim() + "'  ";
                                SqlCommand CM4 = new SqlCommand(sql4, con);
                                SqlDataReader DR4 = CM4.ExecuteReader();

                                DR4.Read();
                                {
                                    txt_locationNo.Text = DR4["NO_Zone"].ToString().Trim();
                                    lbl_locationName.Text = DR4["Name_Zone"].ToString().Trim();
                                }
                                DR4.Close();
                                con.Close();
                            }

                            else
                            {
                                txt_locationNo.Text = "-";
                                lbl_locationName.Text = "ไม่มีจุดเก็บสำหรับสินค้าประเภทนี้"; lbl_locationName.BackColor = Color.Red;
                            }

                            //SQL2 = "SELECT [NO_Zone],[Name_Zone]  FROM  [dbo].[V_LocationZone] WHERE  [ProductID]  ='" + txt_productNo.Text.Trim() + "'";
                        }

                    if (SQL2 != "")
                    {
                        con.Open();
                        SqlCommand CM2 = new SqlCommand(SQL2, con);
                        SqlDataReader DR2 = CM2.ExecuteReader();

                        DR2.Read();
                        {
                            txt_locationNo.Text = DR2["NO_Zone"].ToString().Trim();
                            lbl_locationName.Text = DR2["Name_Zone"].ToString().Trim();
                        }
                        DR2.Close();
                        con.Close();
                    }
                    }
                    catch (Exception ex)
                { con.Close();  MessageBox.Show(ex.ToString()); }
                }


                else

                {
                    txt_locationNo.Text = "-";
                    lbl_locationName.Text = "ไม่มีจุดเก็บสำหรับสินค้าประเภทนี้"; lbl_locationName.BackColor = Color.Red;
                }

        }

        private void txt_weight_Out_TextChanged(object sender, EventArgs e)
        {
            try
            {               
                if (txt_weighttypeNo.Text == "01")
                {                    
                    //OutboundWeight = 0;
                    Net_Weight = InboundWeight - OutboundWeight;
                    txt_weight_Net.Text = Net_Weight.ToString("##,###.##");                  
                }


                if (txt_weighttypeNo.Text == "02")
                {
                    OutboundWeight = Convert.ToDouble(txt_weight_Out.Text);
                    Net_Weight = OutboundWeight - InboundWeight;
                    txt_weight_Net.Text = Net_Weight.ToString("##,###.##");
                    label13.ForeColor = Color.Green;

                    i = 3; btn_save.Enabled = false;
                }

                if (txt_weighttypeNo.Text == "03")
                {
                    if(InboundWeight > OutboundWeight)
                    {
                        Net_Weight = InboundWeight - OutboundWeight;
                        txt_weight_Net.Text = Net_Weight.ToString("##,###.##");
                    }

                    if (OutboundWeight > InboundWeight)
                    {
                        OutboundWeight = Convert.ToDouble(txt_weight_Out.Text);
                        Net_Weight = OutboundWeight - InboundWeight;
                        txt_weight_Net.Text = Net_Weight.ToString("##,###.##");
                    }
                }
            }
            catch (Exception ex)

            {
                label13.ForeColor = Color.Red;
                txt_weight_Net.Text = "Error"; }
        }

        private void txt_qrCode_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F2)    //Print again
            //{
            //    if (Printdata_Per == 1)
            //    {
            //        //if (rdo_printFormat1.Checked == true || rdo_printFormat2.Checked == true || rdo_printFormat3.Checked == true || rdo_printFormat4.Checked == true || rdo_printFormat5.Checked == true)
            //        //{
            //            F_FindData fnd = new F_FindData();
            //            //F_ReportCRT fcrt = new F_ReportCRT();
            //        fnd.id_findType = 15;
            //        fnd.ShowDialog();

            //        //fcrt.id_print = 2;
            //        //fcrt.id_print = 1;
            //        //fcrt.id_print = 3;

            //        txt_productNo.Text = fnd.id_product;                   

            //        Load_FormatPrint();

            //        if (rdo_printFormat1.Checked == true) { PrintformID = 1; }  //form มันเส้น   
            //        if (rdo_printFormat2.Checked == true) { PrintformID = 2; } //form มันสด   
            //        if (rdo_printFormat3.Checked == true) { PrintformID = 3; }  //form ไม้สับ //เอทานอล
            //        if (rdo_printFormat4.Checked == true) { PrintformID = 4; }  //form wet cake

            //        if (fnd.id_value != "")
            //        {
            //            TicketCodeIn = fnd.id_value;
            //            ProductID = fnd.id_product;
            //            TypeJob = fnd.jobType;     //ประเภทงาน
            //            Check_PrintAuto();
            //            //    fcrt.id_ticket = fnd.id_value;
            //            //    fcrt.id_product = fnd.id_product;
            //            //fcrt.id_typeJob = fnd.jobType;
            //            //    fcrt.ShowDialog();
            //        }
            //        //}

            //        else { MessageBox.Show("คุณไม่ได้เลือกรูปแบบพิมพ์", "การพิมพ์ผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            //    }

            //    else
            //    {
            //        MessageBox.Show("สิทธ์การพิมพ์ไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานชั่งสินค้าเข้า-ออก)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}


            //if (e.KeyCode == Keys.F3)   //Edit data
            //{
            //    string sql1 = "";
            //    F_FindData fnd = new F_FindData();
            //    fnd.id_findType = 9;
            //    fnd.ShowDialog();

            //    if (fnd.id_value != "")
            //    {
            //        sport.Close();
            //        SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            //        con.ConnectionString = Program.pathdb_Weight;
            //        SqlDataAdapter dtAdapter = new SqlDataAdapter();
            //        con.Open();

            //        txt_qrCode.Text = fnd.id_value;
            //        txt_ticketCode.Text = txt_qrCode.Text.Trim();
            //        txt_dateWeight.Text = DateTime.Now.ToShortDateString();
            //        txt_qrCode.Clear();

            //        if (fnd.jobType == 1)
            //        {                        
            //            sql1 = "Select * From   [dbo].[V_WeightData] Where TicketCodeIn ='" + fnd.id_value + "'";
            //        }
            //        if (fnd.jobType == 2)
            //        { 
            //            sql1 = "Select * From   [dbo].[V_WeightData_Sale] Where TicketCodeIn ='" + fnd.id_value + "'";
            //        }

            //        SqlCommand CM1 = new SqlCommand(sql1, con);
            //        SqlDataReader DR1 = CM1.ExecuteReader();

            //        DR1.Read();
            //        {
            //            txt_weighttypeNo.Text = DR1["WeightTypeID"].ToString();
            //            lbl_weightTypeName.Text = DR1["WeightTypeName"].ToString();
            //            txt_productNo.Text = DR1["ProductID"].ToString();
            //            lbl_productName.Text = DR1["ProductName"].ToString();
            //            txt_plateno.Text = DR1["Plate1"].ToString();
            //            txt_truckTypeID.Text = DR1["TruckTypeID"].ToString();
            //            lbl_truckType.Text = DR1["TruckTypeName"].ToString();

            //            if (fnd.jobType == 1)
            //            {
            //                txt_vencusNo.Text = DR1["Vendor_No"].ToString();
            //                lbl_vencusName.Text = DR1["NameVen"].ToString();
            //            }

            //            if (fnd.jobType == 2)
            //            {
            //                txt_vencusNo.Text = DR1["CustomerID"].ToString();
            //                lbl_vencusName.Text = DR1["CustomerName"].ToString();
            //            }


            //            txt_queNo.Text = "คิวที่ " + DR1["QueueNo"].ToString(); //QueueNo
            //            Process_id = Convert.ToInt16(DR1["Process_id"].ToString());
            //            //Process_id

            //            try
            //            {
            //                InboundWeight = Convert.ToDouble(DR1["InboundWeight"].ToString());
            //                txt_weight_In.Text = InboundWeight.ToString("#####.##");

            //            }
            //            catch
            //            { InboundWeight = 0; }
            //        }
            //        DR1.Close();
            //        con.Close();

            //        if (txt_weighttypeNo.Text == "01")
            //        {
            //            label17.Text = "ราคาซื้อปัจจุบัน:";
            //        }

            //        else { label17.Text = "ราคาขายปัจจุบัน:"; }

            //        Load_STD_Price();
            //        Load_LocationProduct();
            //        Load_FormatPrint();

            //        btn_save.Enabled = true;
            //        Status_edit = 1;
            //        btn_save.Focus();
            //    }
            //}
            if (e.KeyCode == Keys.F2)    //Print again
            {
                timer2.Enabled = false;

                if (Printdata_Per == 1)
                {
                    //if (rdo_printFormat1.Checked == true || rdo_printFormat2.Checked == true || rdo_printFormat3.Checked == true || rdo_printFormat4.Checked == true || rdo_printFormat5.Checked == true)
                    //{
                                      
                    F_Search fnd = new F_Search();
                    //F_ReportCRT fcrt = new F_ReportCRT();
                    fnd.id_findType = 6;
                    fnd.ShowDialog();

                    timer2.Enabled = true;
                    //fcrt.id_print = 2;
                    //fcrt.id_print = 1;
                    //fcrt.id_print = 3;

                    ProductID = fnd.id_product;
                    //txt_productNo.Text = fnd.id_product;

                    Load_FormatPrint();

                    if (tg_printFormat1.Checked == true) { PrintformID = 1; }  //form มันเส้น   
                    if (tg_printFormat2.Checked == true) { PrintformID = 2; } //form มันสด   
                    if (tg_printFormat3.Checked == true) { PrintformID = 3; }  //form ไม้สับ //เอทานอล
                    if (tg_printFormat4.Checked == true) { PrintformID = 4; }  //form wet cake

                    if (fnd.id_value != "")
                    {
                        TicketCodeIn = fnd.id_value;
                        //ProductID = fnd.id_product;
                        TypeJob = fnd.jobType;     //ประเภทงาน
                        Check_PrintAuto();
                        //    fcrt.id_ticket = fnd.id_value;
                        //    fcrt.id_product = fnd.id_product;
                        //fcrt.id_typeJob = fnd.jobType;
                        //    fcrt.ShowDialog();
                    }
                    //}

                    else { MessageBox.Show("คุณไม่ได้เลือกรูปแบบพิมพ์", "การพิมพ์ผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }

                else
                {
                    MessageBox.Show("สิทธ์การพิมพ์ไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานชั่งสินค้าเข้า-ออก)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    timer2.Enabled = true;
                }
            }


            if (e.KeyCode == Keys.F3)   //Edit data
            {
                timer2.Enabled = false;
                sport.Close();
                Clear_Textbox();

                if (Editdata_Per == 1)
                {
                    Status_edit = 1;
                    Load_ChangeData();     
                    
                }

                else
                {
                    MessageBox.Show("สิทธ์การพิมพ์ไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานชั่งสินค้าเข้า-ออก)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    timer2.Enabled = true;
                }
            }
                       

            //if (e.KeyCode == Keys.F4)   //Edit data
            //{
            //    if (Editdata_Per == 1)
            //    {
            //        Status_edit = 2;
            //        Load_ChangeData();

            //    }
            //    else
            //    {
            //        MessageBox.Show("สิทธ์การพิมพ์ไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานชั่งสินค้าเข้า-ออก)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //}

           
        }

        private void Load_ChangeData()
        {
            sport.Close();
            string sql1 = "";
            F_Search fnd = new F_Search();
            fnd.id_findType = 6;
            fnd.ShowDialog();
            timer2.Enabled = true;

            if (fnd.id_value != "")
            {
                //test weib auto
                //sport.Close();

                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                //SqlDataAdapter dtAdapter = new SqlDataAdapter();
                //dtAdapter.SelectCommand.CommandTimeout = 0;
                con.Open();

                txt_qrCode.Text = fnd.id_value;
                txt_ticketCode.Text = txt_qrCode.Text.Trim();
                txt_dateWeight.Text = DateTime.Now.ToShortDateString();
                txt_qrCode.Clear();

                TicketCodeIn = fnd.id_value;


                if (fnd.jobType == 1)
                {
                    sql1 = "Select * From  [dbo].[V_WeightData] Where TicketCodeIn ='" + TicketCodeIn + "'";
                }
                if (fnd.jobType == 2)
                {
                    sql1 = "Select * From  [dbo].[V_WeightData_Sale] Where TicketCodeIn ='" + TicketCodeIn + "'";
                }

                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    txt_weighttypeNo.Text = DR1["WeightTypeID"].ToString().Trim();
                    lbl_weightTypeName.Text = DR1["WeightTypeName"].ToString().Trim();
                    txt_productNo.Text = DR1["ProductID"].ToString().Trim();
                    lbl_productName.Text = DR1["ProductName"].ToString().Trim();
                    txt_plateno.Text = DR1["Plate1"].ToString().Trim();
                    txt_truckTypeID.Text = DR1["TruckTypeID"].ToString().Trim();
                    lbl_truckType.Text = DR1["TruckTypeName"].ToString().Trim();
                    txt_driveName.Text = DR1["DriveName"].ToString().Trim();
                    id_service = Convert.ToInt16(DR1["ServiceID"].ToString());
                    txt_transportID.Text = DR1["TransportID"].ToString();//[DriveName]
                    lbl_transportName.Text = DR1["TransportName"].ToString().Trim();
                    txt_remark.Text = DR1["Remark3"].ToString().Trim();

                    if (fnd.jobType == 1)
                    {
                        txt_vencusNo.Text = DR1["Vendor_No"].ToString().Trim();
                        lbl_vencusName.Text = DR1["NameVen"].ToString().Trim();
                    }

                    if (fnd.jobType == 2)
                    {
                        txt_vencusNo.Text = DR1["CustomerID"].ToString().Trim();
                        lbl_vencusName.Text = DR1["CustomerName"].ToString().Trim();
                    }


                    txt_queNo.Text = "คิวที่ " + DR1["QueueNo"].ToString().Trim();
                    ProductID = DR1["ProductID"].ToString().Trim();
                    Process_id = Convert.ToInt16(DR1["Process_id"].ToString());
                    //Process_id

                    try
                    {
                        InboundWeight = Convert.ToDouble(DR1["InboundWeight"].ToString());
                        txt_weight_In.Text = InboundWeight.ToString("##,###.##");

                        OutboundWeight = Convert.ToDouble(DR1["OutboundWeight"].ToString());
                        txt_weight_Out.Text = OutboundWeight.ToString("##,###.##");   
                        
                    }
                    catch
                    { InboundWeight = 0; }

                    try
                    {
                        if (fnd.jobType == 1)//ซื้อ หนักเข้า-เบาออก
                        {
                            Net_Weight = InboundWeight - OutboundWeight;
                            txt_weight_Net.Text = Net_Weight.ToString("##,###.##");                           
                        }

                        if (fnd.jobType == 2) // ขาย เบาเข้า-หนักออก
                        {
                            Net_Weight = OutboundWeight - InboundWeight;
                            txt_weight_Net.Text = Net_Weight.ToString("##,###.##");                          
                        }
                    }
                    catch { }
                }
                DR1.Close();
                con.Close();

                if (txt_weighttypeNo.Text == "01")
                {
                    lbl_pricetype.Text = "ราคาซื้อปัจจุบัน:";
                }

                else { lbl_pricetype.Text = "ราคาขายปัจจุบัน:"; }

           
               //txt_weight_Out.TextChanged += new EventHandler(txt_weight_Out_TextChanged);
               
                
                Load_STD_Price();
                Cal_PriceNet();
                Load_LocationProduct();
                Load_FormatPrint();
                Load_DataLabConfirm();
                Load_Services();
                btn_save.Enabled = true;               
                btn_save.Focus();
            }


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cbo_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DataRegister_Purchase();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refresh_data = Program.refresh_Data;
           
            Load_DataRegister_Purchase();
            Load_DataRegister_Sale();
            cbo_statusPur.Text = "--ดูสถานะงานอื่น--";

            Clear_Textbox();
        }       

        int refresh_data = Program.refresh_Data;
        private void timer2_Tick(object sender, EventArgs e)
        {     
            tool_datetime.Text = "Login Date: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();

            lbl_refreshTime.Text = refresh_data.ToString();

            if (refresh_data != 0)
            {
                refresh_data--;
                lbl_refreshTime.Text = refresh_data.ToString();
            }
            else
            {
                refresh_data= Program.refresh_Data;

                Load_DataRegister_Purchase();
                Load_DataRegister_Sale();
                cbo_statusPur.Text = "--ดูสถานะงานอื่น--";               
            }
        }

        private void bnt_recheck_Click(object sender, EventArgs e)
        {
            F_RecheckData frdt = new F_RecheckData();
            frdt.ID_Recheck = 1;
            timer2.Enabled = false;
            frdt.ShowDialog();
            timer2.Enabled = true;
            txt_qrCode.Focus();
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            F_MainReport fmp = new F_MainReport();
            fmp.ShowDialog();
            txt_qrCode.Focus();
        }

        private void chk_weightAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_weightAuto.Checked == true)
            {
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;             
                groupBox6.Enabled = false;
                btn_save.Enabled = false;
                label11.Enabled = false;
                label12.Enabled = false;
                txt_weight_In.Enabled = false;
                txt_weight_Out.Enabled = false;
                txt_weight_Net.Enabled = false;
                label13.Enabled = false;
                tg_printFormat4.Checked = true;               
                txt_ticketCode.Clear();              

                  CultureInfo en = new CultureInfo("en-us"); //เปลี่ยนภาษา windows
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(en);

                //txt_msgAuto.Location = new Point((pn_weight.Height / 2) - (txt_msgAuto.Height / 2), (pn_weight.Width / 2) - (txt_msgAuto.Width / 2));
                txt_msgAuto.Location = new Point((this.Height / 2) - (txt_msgAuto.Height ), (this.Width / 2) - (txt_msgAuto.Width / 3));

                txt_msgAuto.Visible = true;
                timer3.Enabled = true;
                timer2.Enabled = false;
                Clear_Textbox();
                txt_qrCode.Focus();
               
            }

            if (chk_weightAuto.Checked == false)
            {
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                groupBox4.Enabled = true;             
                groupBox6.Enabled = true;
                btn_save.Enabled = true;               
                txt_msgAuto.Visible = false;
                timer3.Enabled = false;
                label11.Enabled = true;
                label12.Enabled = true;             
                label13.Enabled = true;
                txt_weight_In.Enabled = true;
                txt_weight_Out.Enabled = true;
                txt_weight_Net.Enabled = true;
                timer2.Enabled = true;
            }
        }

        int msn_timeAuto = 8;
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (chk_weightAuto.Checked == true)
            {
                if (txt_msgAuto.Text != "-- Auto:On --")
                {
                    if (msn_timeAuto != 0)
                    {
                        if ((DateTime.Now.Second % 2) == 0)
                        {
                            txt_msgAuto.ForeColor = Color.Red;
                        }
                        else
                        {
                            txt_msgAuto.ForeColor = Color.White;
                        }

                        msn_timeAuto--;
                    }
                    else
                    {
                        msn_timeAuto = 5;
                        txt_msgAuto.Text = "-- Auto:On --";
                        txt_qrCode.Clear();
                        txt_qrCode.Focus();
                    }
                }

                else
                {                  

                    if ((DateTime.Now.Second % 2) == 0)
                    {
                        txt_msgAuto.ForeColor = Color.Green;
                    }
                    else
                    {
                        txt_msgAuto.ForeColor = Color.White;
                    }
                }
            }
           
        }

        int AutoTime = 0;
        private void Load_AutoTime()
        {         
            string Time_Check = "";
                    
            DateTime Time = DateTime.Parse(DateTime.Now.ToShortTimeString());
            int TimeNow = Convert.ToInt16(Time.ToString("HH")); 

            if (TimeNow == 0)
            {
                Time_Check = "[A_00]";
            }

            if (TimeNow == 1)
            {
                Time_Check = "[A_01]";
            }

            if (TimeNow == 2)
            {
                Time_Check = "[A_02]";
            }

            if (TimeNow == 3)
            {
                Time_Check = "[A_03]";
            }

            if (TimeNow == 4)
            {
                Time_Check = "[A_04]";
            }

            if (TimeNow == 5)
            {
                Time_Check = "[A_05]";
            }

            if (TimeNow == 6)
            {
                Time_Check = "[A_06]";
            }

            if (TimeNow == 7)
            {
                Time_Check = "[A_07]";
            }

            if (TimeNow == 8)
            {
                Time_Check = "[A_08]";
            }

            if (TimeNow == 9)
            {
                Time_Check = "[A_09]";
            }

            if (TimeNow == 10)
            {
                Time_Check = "[A_10]";
            }

            if (TimeNow == 11)
            {
                Time_Check = "[A_11]";
            }

            if (TimeNow == 12)
            {
                Time_Check = "[A_12]";
            }

            if (TimeNow == 13)
            {
                Time_Check = "[A_13]";
            }

            if (TimeNow == 14)
            {
                Time_Check = "[A_14]";
            }

            if (TimeNow == 15)
            {
                Time_Check = "[A_15]";
            }

            if (TimeNow == 16)
            {
                Time_Check = "[A_16]";
            }

            if (TimeNow == 17)
            {
                Time_Check = "[A_17]";
            }

            if (TimeNow == 18)
            {
                Time_Check = "[A_18]";
            }

            if (TimeNow == 19)
            {
                Time_Check = "[A_19]";
            }

            if (TimeNow == 20)
            {
                Time_Check = "[A_20]";
            }

            if (TimeNow == 21)
            {
                Time_Check = "[A_21]";
            }

            if (TimeNow == 22)
            {
                Time_Check = "[A_22]";
            }

            if (TimeNow == 23)
            {
                Time_Check = "[A_23]";
            }                   


            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            con.Open();
            string sql1 = "SELECT "+ Time_Check + " AS 'C_Time'  FROM [dbo].[TB_AutoTime]  Where [atMode_id] = 1";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                if (DR1["C_Time"].ToString().Trim() == "True")
                {
                    AutoTime = 1;
                }
            }
            DR1.Close();
            con.Close();
        }
             
        private void Weight_Auto()
        {
            Load_AutoTime();                    //check time

            try
            {
                if (AutoTime == 1)
                {

                    string date = DateTime.Now.ToString("yyyy-MM-dd") + ' ' + DateTime.Now.ToString("HH:mm:ss");
                   // string date = Program.Date_Now + ' ' + Program.Time_Now;
                    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                    con.ConnectionString = Program.pathdb_Weight;
                    //SqlDataAdapter dtAdapter = new SqlDataAdapter();
                    //dtAdapter.SelectCommand.CommandTimeout = 0;
                   
                    string Plate1 = "";
                    string VenCus = "";
                    string FiledName = "";
                    string WeightTypeID = "03";                   
                    string LocationID = "";                    
                    //string ProductID = "";                                
                    //weight_out = Convert.ToDouble(txt_weight_Out.Text);
                    con.Open();
                    string sql1 = "SELECT [ID_Barcode],[Plate1],[NO_Zone],[Ven_Cus_ID],[ProductID],[PurSale]  FROM [dbo].[TB_PrintAuto]  Where [ID_Barcode] ='" + txt_qrCode.Text.Trim() + "' AND [ActiveStatus] = 1";
                    SqlCommand CM1 = new SqlCommand(sql1, con);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    {
                        ID_Barcode = DR1["ID_Barcode"].ToString().Trim();
                        Plate1 = DR1["Plate1"].ToString().Trim();
                        LocationID = DR1["NO_Zone"].ToString().Trim();
                        VenCus = DR1["Ven_Cus_ID"].ToString().Trim();
                        ProductID = DR1["ProductID"].ToString();

                        if (DR1["PurSale"].ToString() == "False")   //check ประเภท งานซื้อหรือขาย   0= ซื้อ  1 = ขาย;
                        {
                            PurSale = 0;
                        }

                        if (DR1["PurSale"].ToString() == "True")   //check ประเภท งานซื้อหรือขาย   0= ซื้อ  1 = ขาย;
                        {
                            PurSale = 1;
                        }

                    }
                    DR1.Close();
                    con.Close();

                    //check tpye name on File Name save
                    if (PurSale == 0)
                    {
                        FiledName = "[Vendor_No]";
                    }

                    if (PurSale == 1)
                    {
                        FiledName = "[CustomerID]";
                    }

                    Check_StatusWeight();

                    Load_ProcessID_Auto();   //check process truck

                    if (Status_Weight == "IN" && Status_WI ==1)
                    {

                        Load_QueToday();    //create Q                      
                        Load_TicketNo();    // check ticket
                                            //Load_locationAuto();   
                                            // check location product
                                            //TruckType = 3;
                        Load_Services();

                        InboundWeight = weight_interface;  // insert weight from indicator
                        //Cal_Weith();

                        if (InboundWeight != 0 )
                        {
                            con.Open();
                            string sql2 = "Insert Into [TB_WeightData] ([TicketCodeIn],[WeightDate],[RegisterInDate],[QueueNo],[Plate1],[WeightTypeID],[ProductID]," + FiledName + ",[Process_id],[InboundDate],[InboundWeight],[Remark1],[WarehouseID],[EmployeeID],[TransportID],[Automode],[ServiceID],[SourceID],[TruckTypeID]) Values('" + TicketCodeIn + "', '" + date + "', '" + date + "', " + QueueNo + ",'" + Plate1.Trim() + "', '" + WeightTypeID + "', '" + ProductID + "','" + VenCus + "'," + Process_id_Auto + ",'" + date + "'," + InboundWeight + ",'" + ID_Barcode.Trim() + "','" + LocationID + "'," + Program.user_id + ",1,1," + id_service + ",78,3)";
                            SqlCommand CM2 = new SqlCommand(sql2, con);
                            SqlDataReader DR2 = CM2.ExecuteReader();
                            con.Close();

                            con.Open();
                            string sql3 = "Insert Into [TB_LabConfirmPay] ([TicketCodeIn],[Price],[PriceNet])  Values ('" + TicketCodeIn + "',0,0)";
                            SqlCommand CM3 = new SqlCommand(sql3, con);
                            SqlDataReader DR3 = CM3.ExecuteReader();
                            con.Close();

                            Save_FollowProcess();
                            PrintformID = 4;
                            Check_PrintAuto();

                        }

                        else {// MessageBox.Show("ข้อมูลน้ำหนักชั่งเข้าผิดพลาด! ไม่พบน้ำหนักชั่งเข้า", "การชั่งเข้าผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error); txt_qrCode.Clear(); txt_ticketCode.Clear(); 
                            txt_msgAuto.Text = "-- น้ำหนักชั่งผิดพลาด! --";
                        }


                        InboundWeight = 0;
                        Net_Weight = 0;
                        weight_interface = 0;

                    }

                    if (Status_Weight == "OUT" && Status_WO == 1)
                    {
                        con.Open();

                        string sql = "";
                       

                        if (PurSale == 0)
                        {
                            sql = "Select [TicketCodeIn],[InboundWeight],[ProductID] From[dbo].[TB_WeightData] Where [Remark1] ='" + txt_qrCode.Text.Trim() + "' AND  [OutboundWeight] is null AND QueueNo <> 0 Order by LOGID Desc";
                        }

                        if (PurSale == 1)
                        {
                            sql = "Select [TicketCodeIn],[InboundWeight],[ProductID] From[dbo].[TB_WeightData] Where [Remark1] ='" + txt_qrCode.Text.Trim() + "' AND  [OutboundWeight] is null  AND QueueNo <> 0 Order by LOGID Desc ";
                        }
                        SqlCommand CM = new SqlCommand(sql, con);
                        SqlDataReader DR = CM.ExecuteReader();

                        DR.Read();
                        {
                            InboundWeight= Convert.ToDouble(DR["InboundWeight"].ToString().Trim());
                            TicketCodeIn = DR["TicketCodeIn"].ToString().Trim();
                            txt_productNo.Text = DR["ProductID"].ToString().Trim();                            
                        }
                        DR.Close();
                        con.Close();

                        //Cal_Weith();
                        OutboundWeight = weight_interface;  // insert weight from indicator

                        Load_ServicesAuto();
                        Load_STD_Price();                  

                        Net_Price =Convert.ToDecimal(Net_Weight * Convert.ToDouble(Price_STD));

                        if (OutboundWeight != 0)
                        {                           

                            con.Open();
                            string sql3 = "Update [TB_WeightData] Set [Process_id]=" + Process_id_Auto + ",[OutboundDate] ='" + date + "', [OutboundWeight] =" + OutboundWeight + ", [ServiceID] =" + id_service + ", [TruckTypeID] =" + txt_truckTypeID.Text + ",[RegisterIOutdate] ='" + date + "' Where [TicketCodeIn]='" + TicketCodeIn + "'";
                            SqlCommand CM3 = new SqlCommand(sql3, con);
                            SqlDataReader DR3 = CM3.ExecuteReader();
                            con.Close();

                            con.Open();
                            string sql2 = "Update [TB_LabConfirmPay] Set [Price]=" + Price_STD + ",[PriceNet]=" + Net_Price + " Where [TicketCodeIn]='" + TicketCodeIn + "'";
                            SqlCommand CM2 = new SqlCommand(sql2, con);
                            SqlDataReader DR2 = CM2.ExecuteReader();
                            con.Close();
                            
                            Save_FollowProcess();
                            PrintformID = 4;
                            Check_PrintAuto();
                        }

                        else {

                            txt_msgAuto.Text = "-- น้ำหนักชั่งผิดพลาด! --";
                            //MessageBox.Show("ข้อมูลน้ำหนักชั่งออกผิดพลาด ไม่พบน้ำหนักชั่งออก", "การชั่งเข้าผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error); txt_qrCode.Clear(); txt_ticketCode.Clear();
                        }


                        InboundWeight = 0;
                        OutboundWeight = 0;
                        Net_Weight = 0;
                        weight_interface = 0;
                    }
                    
                    Clear_Textbox();

                }


                else
                {
                    txt_msgAuto.Text = "--- บันทึกนอกเวลาที่กำหนด ---";
                    txt_msgAuto.ForeColor = Color.Red;
                }

            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());
                //txt_msgAuto.Text = "-- ระบบผิดพลาด! --";
                //MessageBox.Show("ข้อมูลน้ำหนักชั่งออกผิดพลาด ไม่พบน้ำหนักชั่งออก", "การชั่งเข้าผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error); txt_qrCode.Clear(); 
            }

        }

        private void Load_QueToday()
        {
            //RegisterInDate
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            //SqlDataAdapter dtAdapter = new SqlDataAdapter();
            //dtAdapter.SelectCommand.CommandTimeout = 0;
            con.Open();

            string dt = DateTime.Now.ToString("yyyy-MM-dd");

            int q = 0;

            //string sql1 = "Select max([QueueNo])as MaxQ From [dbo].[TB_WeightData] Where RegisterInDate BETWEEN {ts'" + dt.ToString() + " 00:00:00'} AND  {ts'" + dt.ToString() + " 23:59:59'} AND [ProductID]='" + ProductID + "' AND [QueueNo] <> 0 AND Automode = 1";

            string sql1 = "Select max([QueueNo])as MaxQ From [dbo].[V_WeightAuto] Where [InboundDate] BETWEEN {ts'" + dt.ToString() + " 00:00:00'} AND  {ts'" + dt.ToString() + " 23:59:59'} AND [proc_type] <> 'C' AND [ProductID]='" + ProductID + "'";

            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                //MessageBox.Show(DR1["MaxQ"].ToString());
                // count = Convert.ToInt16(DR1["countidqua"].ToString().Trim());
                if (DR1["MaxQ"].ToString() != "")
                {
                    //MessageBox.Show(DR1["MaxQ"].ToString());
                    q = Convert.ToInt16(DR1["MaxQ"].ToString());
                    QueueNo = q + 1;                    
                }
            }
            DR1.Close();
            con.Close();

            if (q==0)
            {
                QueueNo = 1;
            }
        }

        private void Load_TicketNo()
        {         
            DateTime dt_c = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")));   // convert date                   
            string dt_s = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));

            int year = Convert.ToInt32(dt_c.ToString("yyyy")) + 543;
            string date_c = year.ToString() + "/" + dt_c.ToString("MM/dd");

            CultureInfo culture = new CultureInfo("en-US");
            DateTime tempDate = Convert.ToDateTime(date_c, culture);
            string date = "";// = tempDate.ToString("yyMMdd") + "-";
                                 
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            //SqlDataAdapter dtAdapter = new SqlDataAdapter();
            //dtAdapter.SelectCommand.CommandTimeout = 0;
            con.Open();

            string Index_Ticket = "";
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

                Index_Ticket = listStr[5].ToString().Trim();
                StrRer.Close();
            }


            date += Index_Ticket + tempDate.ToString("yyMMdd") + "-";

            string sql1 = "Select max([TicketCodeIn])as maxcode From[dbo].[V_WeightAuto] Where [InboundDate] BETWEEN {ts'" + dt_s.ToString() + " 00:00:00'} AND  {ts'" + dt_s.ToString() + " 23:59:59'} AND [TicketCodeIn] Like '%" + Index_Ticket + "%'  ";

            //test 
            //string sql1 = "Select max([TicketCodeIn])as maxcode From[dbo].[V_WeightAuto] Where[InboundDate] BETWEEN { ts'2022-07-16 00:00:00'}    AND  { ts'2022-07-16 23:59:59'}  AND[TicketCodeIn] Like '%A%'";



            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                // count = Convert.ToInt16(DR1["countidqua"].ToString().Trim());
                if (DR1["maxcode"].ToString() != "")
                {
                    //MessageBox.Show(DR1["MaxQ"].ToString());
                    txt_ticketCode.Text = DR1["maxcode"].ToString();
                }
            }
            DR1.Close();
            con.Close();

            if (txt_ticketCode.Text == "")
            {
                date += "0001";
                txt_ticketCode.Text = date;
                TicketCodeIn = date;
            }

            else
            {
                txt_ticketCode.Select(8, 11);
                int no = Convert.ToInt16(txt_ticketCode.SelectedText);
                txt_ticketCode.Text = no.ToString();

                if (txt_ticketCode.Text.Length == 1 || txt_ticketCode.Text == "9")
                {
                    if (txt_ticketCode.Text == "9")
                    {
                        date += "00" + Convert.ToString(no + 1);
                    }
                    else { date += "000" + Convert.ToString(no + 1); }
                }

                else if (txt_ticketCode.Text.Length == 2 || txt_ticketCode.Text == "99")
                {
                    if (txt_ticketCode.Text == "99")
                    {
                        date += "0" + Convert.ToString(no + 1);
                    }
                    else { date += "00" + Convert.ToString(no + 1); }
                }


                else if (txt_ticketCode.Text.Length == 3 || txt_ticketCode.Text == "999")
                {
                    if (txt_ticketCode.Text == "999")
                    {
                        date += "" + Convert.ToString(no + 1);
                    }
                    else { date += "0" + Convert.ToString(no + 1); }

                }

                if (txt_ticketCode.Text.Length == 4)
                {
                    date += Convert.ToString(no + 1);
                }

                //date += Convert.ToString(no);
                txt_ticketCode.Text = date;
                TicketCodeIn = date;
            }

        }

        //private void Save_FollowProcess()
        //{
        //    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
        //    con.ConnectionString = Program.pathdb_Weight;
        //    SqlDataAdapter dtAdapter = new SqlDataAdapter();

        //    try
        //    {
        //        con.Open();
        //        // Save to data base
        //        string date_time = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US")) + " " + DateTime.Now.ToString("HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));

        //        string sql = "";

        //        if (cb_registerOut.Checked == false)
        //        {
        //            sql = "Insert Into [TB_FollowProcess] ([TicketCodeIn],[RegisterIn_Datetime]) Values('" + txt_ticketno.Text.Trim() + "', '" + date_time + "')";
        //        }

        //        if (cb_registerOut.Checked == true)
        //        {
        //            sql = "Update [TB_FollowProcess] Set [RegisterOut_Datetime]= '" + date_time + "' Where [TicketCodeIn] = '" + txt_ticketno.Text.Trim() + "'";
        //        }

        //        SqlCommand CM2 = new SqlCommand(sql, con);
        //        SqlDataReader DR2 = CM2.ExecuteReader();
        //        con.Close();
        //    }

        //    catch
        //    {
        //        con.Close();
        //    }

        //}




        private void Load_ProcessID_Auto()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                //SqlDataAdapter dtAdapter = new SqlDataAdapter();
                //dtAdapter.SelectCommand.CommandTimeout = 0;
                con.Open();

                //string sql1 = "Select Min([proc_no])as minprocess From[dbo].[TB_Process] Where item_no='" + ProductID + "' AND [proc_type]='WI' OR AND [proc_type]='WO'";

                string sql = "";

                if (Status_Weight == "IN")
                {
                    sql = "Select [proc_no] From[dbo].[TB_Process] Where item_no='" + ProductID + "' AND [proc_type]='WI' AND [proc_atMode] = 1";
                }

                if (Status_Weight == "OUT")
                {
                    sql = "Select [proc_no] From[dbo].[TB_Process] Where item_no='" + ProductID + "' AND [proc_type]='WO' AND [proc_atMode] = 1";
                }

                SqlCommand CM1 = new SqlCommand(sql, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    Process_id_Auto = Convert.ToInt16(DR1["proc_no"].ToString());

                    if (Status_Weight == "IN")
                    {
                        Status_WI = 1;
                    }

                    if (Status_Weight == "OUT")
                    {
                        Status_WO = 1;
                    }
                }

                DR1.Close();
                con.Close();
            }
            catch
            {
                txt_msgAuto.Text = "พบความผิดพลาด! ในการตั้งค่าลำดับงาน";
            }
        }

        private void Check_StatusWeight()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                //SqlDataAdapter dtAdapter = new SqlDataAdapter();
                //dtAdapter.SelectCommand.CommandTimeout = 0;
                con.Open();

                string dt = DateTime.Now.ToString("yyyy-MM-dd");

                string sql1 = "Select Count([TicketCodeIn])as CountITems From[dbo].[TB_WeightData] Where [QueueNo] <> 0 AND [Remark1] = '" + txt_qrCode.Text.Trim() + "' AND [InboundWeight] > 0 AND [OutboundWeight] is null";

               // string sql1 = "Select Count([TicketCodeIn])as CountITems From[dbo].[TB_WeightData] Where RegisterInDate BETWEEN { ts'" + dt.ToString() + " 00:00:00'} AND  { ts'" + dt.ToString() + " 23:59:59'} AND [Remark1] = '" + txt_qrCode.Text.Trim() + "' AND [InboundWeight] > 0 AND [OutboundWeight] is null";

                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    if (Convert.ToInt16(DR1["CountITems"].ToString()) == 0)
                    {
                        Status_Weight = "IN";
                    }

                    else { Status_Weight = "OUT"; }

                }
                DR1.Close();
                con.Close();              
            }
            catch
            {
                txt_msgAuto.Text = "เลขบัตรชั่งนี้ไม่ได้บันทึกชั่งเข้า";
            }
        }

        //private void Load_locationAuto()
        //{
        //    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
        //    con.ConnectionString = Program.pathdb_Weight;
        //    //SqlDataAdapter dtAdapter = new SqlDataAdapter();
        //    //dtAdapter.SelectCommand.CommandTimeout = 0;
        //    con.Open();
        //    string sql4 = "SELECT [NO_Zone] FROM [dbo].[V_LocationZone] Where [ProductID] ='" + ProductID + "'";

        //    SqlCommand CM4 = new SqlCommand(sql4, con);
        //    SqlDataReader DR4 = CM4.ExecuteReader();

        //    DR4.Read();
        //    {
        //        LocationID = DR4["NO_Zone"].ToString().Trim();
        //    }
        //    DR4.Close();
        //    con.Close();

        //}

        private void cbo_serviceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_ticketCode.Text != "" && chk_chageService.Checked == true)
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                //SqlDataAdapter dtAdapter = new SqlDataAdapter();
                //dtAdapter.SelectCommand.CommandTimeout = 0;
                con.Open();

                string IncludeVat;
                string sql1 = "SELECT [WeightPrice],[LoadPrice],[IncludeVat]   FROM [dbo].[TB_Services] where [ServiceID]=" + cbo_serviceName.SelectedValue.ToString() + "";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    txt_weightPrice.Text= DR1["WeightPrice"].ToString().Trim();
                    txt_loadPrice.Text= DR1["LoadPrice"].ToString().Trim();
                    IncludeVat= DR1["IncludeVat"].ToString().Trim();
                    //cbo_serviceName.SelectedValue = id_service;
                }
                DR1.Close();
                con.Close();

                int total_price = Convert.ToInt32(txt_weightPrice.Text.Trim()) + Convert.ToInt32(txt_loadPrice.Text.Trim());
                txt_totalPrice.Text = total_price.ToString();

                if (IncludeVat == "True")
                { lbl_vat.Text = "รวมภาษีมูลค่าเพิ่มแล้ว"; lbl_vat.ForeColor = Color.Blue; }

                else { lbl_vat.Text = "ไม่รวมภาษีมูลค่าเพิ่ม"; lbl_vat.ForeColor = Color.Yellow; }       
            }
        }

        private void chk_chageService_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_chageService.Checked == true)
            {
                cbo_serviceName.Enabled = true; lbl_vat.Visible = true;
                txt_weightPrice.Enabled = true;
                txt_loadPrice.Enabled = true;
                txt_totalPrice.Enabled = true;
            }
            else { cbo_serviceName.Enabled = false;

                txt_weightPrice.Clear();
                txt_loadPrice.Clear();
                txt_totalPrice.Clear();             
                
                lbl_vat.Text = "";lbl_vat.Visible = false;
            }
        }
           

        private void cbo_statusSale_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DataRegister_Sale();
        }

        private void Print_Ticket()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            //SqlDataAdapter dtAdapter = new SqlDataAdapter();
            //dtAdapter.SelectCommand.CommandTimeout = 0;
         

            string ProductName;
            string QueueNo;
            string Plate1;
            string Vendor_Name;
            DateTime InDate = new DateTime();
            DateTime InTime = new DateTime();
            DateTime OutDate = new DateTime();
            DateTime OutTime = new DateTime();
      
            string ProvinceName;
            string LabValue1;
            string LabValue2;
            string LabValue3;
            string LabValue4;
            string LabVselect;          
                      
            string UserName;
            string WarehouseID;        
            decimal Price_E = 0;
            int PrintValueLab1 = 0;
            int PrintValueLab2 = 0;
            int PrintValueLab3 = 0;
            int PrintValueLab4 = 0;


            con.Open();
            string sql1 = "Select  *  FROM [dbo].[V_PrintTicket] Where [TicketCodeIn]='" + TicketCodeIn + "'";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                ProductName = DR1["ProductName"].ToString();
                QueueNo = DR1["QueueNo"].ToString();
                Plate1 = DR1["Plate1"].ToString();
                Vendor_Name = DR1["Vendor_Name"].ToString();
                InDate = Convert.ToDateTime(DR1["InDate"].ToString());
                InTime = Convert.ToDateTime(DR1["InTime"].ToString());
                OutDate = Convert.ToDateTime(DR1["OutDate"].ToString());
                OutTime = Convert.ToDateTime(DR1["OutTime"].ToString());
                InboundWeight = Convert.ToDouble(DR1["InboundWeight"].ToString());
                OutboundWeight = Convert.ToDouble(DR1["OutboundWeight"].ToString());
                Gross_Weight = Convert.ToDecimal(DR1["GrossWeight"].ToString());
                ProvinceName = DR1["ProvinceName"].ToString();
                LabValue1 = DR1["LabValue1"].ToString();
                LabValue2 = DR1["LabValue2"].ToString();
                LabValue3 = DR1["LabValue3"].ToString();
                LabValue4 = DR1["LabValue4"].ToString();
                LabVselect = DR1["LabVselect"].ToString();

                try
                {
                    DiscutValue = Convert.ToDecimal(DR1["DiscutValue"].ToString());
                }
                catch { DiscutValue = 0; }

                Price_STD = Convert.ToDecimal(DR1["Price"].ToString());
                PriceExt = Convert.ToDecimal(DR1["PriceExtra"].ToString());
                Net_Price = Convert.ToDecimal(DR1["PriceNet"].ToString());
                UserName = DR1["UserName"].ToString();
                WarehouseID = DR1["WarehouseID"].ToString();

                if (DR1["PrintValueLab1"].ToString() == "True")
                {
                    PrintValueLab1 = 1;
                }

                if (DR1["PrintValueLab2"].ToString() == "True")
                {
                    PrintValueLab2 = 1;
                }

                if (DR1["PrintValueLab3"].ToString() == "True")
                {
                    PrintValueLab3 = 1;
                }

                if (DR1["PrintValueLab4"].ToString() == "True")
                {
                    PrintValueLab4 = 1;
                }

            }
            DR1.Close();
            con.Close();

                      
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Report6.rdlc";

            ReportParameter rp = new ReportParameter("ProductName", ProductName);
            //Following line causes exception:
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
            this.reportViewer1.RefreshReport();                                          

            // crt_ticket.PrintToPrinter(1, false, 0, 0);
        }

        private void btn_cancelTruck_Click(object sender, EventArgs e)
        {
            if (Canceldata_Per == 1)
            {
                F_ChangeData FCC = new F_ChangeData();
                FCC.id_updateType = 2;
                FCC.ShowDialog();

                Load_DataRegister_Purchase();
                Load_DataRegister_Sale();

            }

            else { MessageBox.Show("ชื่อผู้ใช้งานนนี้ไม่ได้รับสิทธิ์ในการยกเลิกงานชั่ง","",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void txt_qrCode_MouseClick(object sender, MouseEventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-us"));
        }

        private void txt_weightInterface_TextChanged_1(object sender, EventArgs e)
        {
            //if (txt_queType.Text == "IN")
            //{
            //    txt_weight_In.Text = weight_interface.ToString("##,###.##");
            //    InboundWeight = weight_interface;

            //    if (txt_weight_In.Text == "")
            //    { txt_weight_In.Text = "0.00"; }
            //}

            //else if (txt_queType.Text == "OUT")

            //{
            //    txt_weight_Out.Text = weight_interface.ToString("##,###.##");
            //    double we_in = Convert.ToDouble(txt_weight_In.Text);
            //    double we_out = weight_interface;
            //    OutboundWeight = weight_interface;
            //    double we_net = 0;

            //    if (txt_weight_Out.Text == "")
            //    { txt_weight_In.Text = "0.00"; }

            //    if (txt_weighttypeNo.Text == "01")
            //    {
            //        we_net = we_in - we_out;
            //    }

            //    else { we_net = we_out - we_in; }

            //    txt_weight_Net.Text = we_net.ToString("##,###.##");

            //}    

            //if (txt_queType.Text == "IN")
            //{
            //    if (chk_Win.Checked == false)
            //    {
            //        txt_weight_In.Text = weight_interface.ToString("##,###.##");
            //    }
            //}

            //if (txt_queType.Text == "OUT")
            //{
            //    if (chk_Wout.Checked == false)
            //    {
            //        txt_weight_Out.Text = weight_interface.ToString("##,###.##");
            //    }
            //}

                //Cal_Weith();
        }

        private void Cal_Weith()
        {
            try
            {

                weight_interface = Convert.ToDouble(txt_weightDisply.Text);  //Test 

                if (txt_queType.Text.Trim() == "IN")
                {
                                          

                    if (tg_Win.Checked == false)
                    {
                        InboundWeight = weight_interface;
                        txt_weight_In.Text = InboundWeight.ToString("##,###.##");
                    }

                    else
                    {
                        InboundWeight = Convert.ToDouble(txt_weightDisply.Text);
                        txt_weight_In.Text = InboundWeight.ToString("##,###.##");
                    }
                }

                if (txt_queType.Text.Trim() == "OUT")
                {                                         

                    if (tg_Wout.Checked == false)
                    {
                        OutboundWeight = weight_interface;
                        txt_weight_Out.Text = OutboundWeight.ToString("##,###.##");
                        txt_weight_In.ForeColor = Color.Black;
                    }

                    else
                    {
                        OutboundWeight = Convert.ToDouble(txt_weightDisply.Text);
                        txt_weight_Out.Text = OutboundWeight.ToString("##,###.##");
                        txt_weight_Out.ForeColor = Color.Black;
                    }
                }


                if (txt_queType.Text.Trim() == "-")
                {                   
                    if (tg_Win.Checked == true)
                    {
                        InboundWeight = weight_interface;
                        txt_weight_In.Text = InboundWeight.ToString("##,###.##");
                        txt_weight_In.ForeColor = Color.Black;
                    }

                    if (tg_Wout.Checked == true)
                    {
                        OutboundWeight = weight_interface;
                        txt_weight_Out.Text = OutboundWeight.ToString("##,###.##");
                        txt_weight_Out.ForeColor = Color.Black;
                    }
                }

            }
            catch
            {
                if (txt_queType.Text.Trim() == "IN")
                {
                    txt_weight_In.Text = "Error"; txt_weight_In.ForeColor = Color.Red;
                }

                if (txt_queType.Text.Trim() == "OUT")
                {
                    txt_weight_Out.Text = "Error"; txt_weight_Out.ForeColor = Color.Red;
                }

                if (txt_queType.Text.Trim() == "-")
                {
                    if (txt_weightDisply.Text == "")
                    {
                        // txt_weight_Out.Text = ""; 
                        weight_interface = 0;

                    }

                    else { txt_weight_Out.Text = "Error"; txt_weight_Out.ForeColor = Color.Red; }
                }
            }

        }

        private void pn_weight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bnt_recheck_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(bnt_recheck, "ติดตามระบบงาน");            
        }

        private void btn_report_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btn_report, "ออกรายงาน");
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btn_refresh, "ปรับปรุงข้อมูล");
        }

        private void btn_chekIn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btn_chekIn, "งานชั่งซื้อ");
        }

        private void btn_checkOut_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btn_checkOut, "งานชั่งขาย");
        }

        private void btn_chekIn_Click(object sender, EventArgs e)
        {
            if (pn_detail.Width == 2)
            {
                pn_detail.Width = ((this.Width / 3)*2);
                pn_pur.Dock = DockStyle.Top;
                dtg_weightPurchase.Dock = DockStyle.Fill;
                pn_pur.Visible = true;
                dtg_weightPurchase.Visible = true;

                Load_StatusPur();
                cbo_statusPur.Text = "--ดูสถานะงานอื่น--";
                Load_DataRegister_Purchase();  //load job purchase

            }
            else {

                if (pn_pur.Visible == true)
                {
                    pn_detail.Width = 2;
                    pn_pur.Visible = false;
                    dtg_weightPurchase.Visible = false;
                    pn_sale.Visible = false;
                    dtg_weightSale.Visible = false;
                    pn_auto.Visible = false;
                    dtg_weightAuto.Visible = false;
                }

                else {

                    pn_pur.Dock = DockStyle.Top;
                    dtg_weightPurchase.Dock = DockStyle.Fill;
                    pn_pur.Visible = true;
                    dtg_weightPurchase.Visible = true;
                    pn_sale.Visible = false;
                    dtg_weightSale.Visible = false;
                    pn_auto.Visible = false;
                    dtg_weightAuto.Visible = false;
                }
            }

            txt_qrCode.Focus();

        }

        private void btn_checkOut_Click(object sender, EventArgs e)
        {
            if (pn_detail.Width == 2)
            {
                pn_detail.Width = ((this.Width / 3) * 2);
                pn_sale.Dock = DockStyle.Top;
                dtg_weightSale.Dock = DockStyle.Fill;
                pn_sale.Visible = true;
                dtg_weightSale.Visible = true;

                Load_StatusSale();
                cbo_statusSale.Text = "--ดูสถานะงานอื่น--";
                Load_DataRegister_Sale();  //load job sale
            }
            else {

                if (pn_sale.Visible == true)
                {
                    pn_detail.Width = 2;
                    pn_sale.Visible = false;
                    dtg_weightSale.Visible = false;
                    pn_pur.Visible = false;
                    dtg_weightPurchase.Visible = false;
                    pn_auto.Visible = false;
                    dtg_weightAuto.Visible = false;
                }

                else
                {
                    pn_sale.Dock = DockStyle.Top;
                    dtg_weightSale.Dock = DockStyle.Fill;
                    pn_sale.Visible = true;
                    dtg_weightSale.Visible = true;
                    pn_pur.Visible = false;
                    dtg_weightPurchase.Visible = false;
                    pn_auto.Visible = false;
                    dtg_weightAuto.Visible = false;

                }
            }

            txt_qrCode.Focus();
        }

        private void dtp_historyPur_ValueChanged(object sender, EventArgs e)
        {
            Load_StatusPur();
        }

        private void dtp_historySale_ValueChanged(object sender, EventArgs e)
        {
            Load_StatusSale();
        }

        private void dtg_weightPurchase_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dtg_weightPurchase.Rows[e.RowIndex].Cells[2].Value.ToString() != "")
                {
                    txt_qrCode.Text = dtg_weightPurchase.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                }
            }
            catch { }
        }

        private void dtg_weightSale_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dtg_weightSale.Rows[e.RowIndex].Cells[2].Value.ToString() != "")
                {
                    txt_qrCode.Text = dtg_weightSale.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                }
            }
            catch { }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void txt_stdPrice_TextChanged(object sender, EventArgs e)
        {
            Cal_PriceNet();
        }

        private void Cal_PriceNet()
        {
            try
            {
                if (Net_Weight != 0)
                {
                    double P_net = 0;
                    if (txt_stdPrice.Text != "")
                    {
                        Price_STD = Convert.ToDecimal(txt_stdPrice.Text);
                    }

                    P_net = Convert.ToDouble(Net_Weight) * Convert.ToDouble(Price_STD); // Convert.ToDouble(Net_Weight * Price_STD);

                    //decimal xx = System.Math.Floor(P_net);
                    //decimal yy = P_net - xx;

                    double cc = System.Math.Floor(P_net);
                    double vv = P_net - cc;

                    if (vv >= 0.50)  //คำนวน น้ำหนักหัก เกินหรือเท่ากับ 0.50 ปัดขึ้น
                    {
                        P_net = System.Math.Floor(P_net) + 1;
                    }
                    ///Floor
                    else { P_net = cc; }

                    Net_Price = Convert.ToDecimal(P_net);

                    if (P_net != 0)
                    {
                        txt_priceNet.Text = P_net.ToString("##,###.##");
                    }
                    else { txt_priceNet.Text ="0.00"; }
                }

            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }

        }

        private void btn_transport_Click(object sender, EventArgs e)
        {
            F_Search fnd = new F_Search();
            fnd.id_findType = 5;

            fnd.ShowDialog();

            if (fnd.id_value != "")
            {
                txt_truckTypeID.Text = fnd.id_value;
                lbl_truckType.Text = fnd.name_value;
            }
        }

        private void txt_weightDisply_TextChanged(object sender, EventArgs e)
        {
            Cal_Weith();
        }
               

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtg_weightPurchase_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (pn_pur.Visible == true)
            {
                pn_detail.Width = 2;
                pn_pur.Visible = false;
                dtg_weightPurchase.Visible = false;
                pn_sale.Visible = false;
                dtg_weightSale.Visible = false;
                txt_qrCode.Focus();
            }
        }

        private void dtg_weightSale_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (pn_sale.Visible == true)
            {
                pn_detail.Width = 2;
                pn_sale.Visible = false;
                dtg_weightSale.Visible = false;
                pn_pur.Visible = false;
                dtg_weightPurchase.Visible = false;
                txt_qrCode.Focus();
            }
        }

        private void txt_weighttypeNo_TextChanged(object sender, EventArgs e)
        {
            if (txt_weighttypeNo.Text == "01")
            {
                lbl_pricetype.Text = "ราคารับซื้อปัจจุบัน:";
            }

            if (txt_weighttypeNo.Text == "02")
            {
                lbl_pricetype.Text = "ราคาขายปัจจุบัน:";
            }
        }

        private void txt_weight_Net_TextChanged(object sender, EventArgs e)
        {
            Cal_PriceNet();
        }

        private void dtg_weightPurchase_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;

            try
            {    
                if (e.RowIndex > -1)
                {
                    con.Open();
                    string sql2 = "Update [TB_WeightData] Set [QueueNo] =" + dtg_weightPurchase.Rows[e.RowIndex].Cells[3].Value.ToString() + " Where [TicketCodeIn] = '" + dtg_weightPurchase.Rows[e.RowIndex].Cells[2].Value.ToString() + "'";
                    SqlCommand CM2 = new SqlCommand(sql2, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    con.Close();
                }
            }
            catch { MessageBox.Show("ใส่รูปแบบประเภทข้อมูลที่เป็นแบบตัวเลขเท่านั้น", "ใส่ข้อมูลผิดรูปแบบ", MessageBoxButtons.OK, MessageBoxIcon.Error); con.Close(); }
        }

        private void dtg_weightSale_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            try
            {
                if (e.RowIndex > -1)
                {
                    con.Open();
                    string sql2 = "Update [TB_WeightData] Set [QueueNo] =" + dtg_weightSale.Rows[e.RowIndex].Cells[3].Value.ToString() + " Where [TicketCodeIn] = '" + dtg_weightSale.Rows[e.RowIndex].Cells[2].Value.ToString() + "'";
                    SqlCommand CM2 = new SqlCommand(sql2, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    con.Close();
                }
            }
            catch { MessageBox.Show("ใส่รูปแบบประเภทข้อมูลที่เป็นแบบตัวเลขเท่านั้น", "ใส่ข้อมูลผิดรูปแบบ", MessageBoxButtons.OK, MessageBoxIcon.Error); con.Close(); }

        }

        private void btn_checkAuto_Click(object sender, EventArgs e)
        {
            if (pn_detail.Width == 2)
            {
                pn_detail.Width = ((this.Width / 3) * 2);
                pn_auto.Dock = DockStyle.Top;
                dtg_weightAuto.Dock = DockStyle.Fill;
                pn_auto.Visible = true;
                dtg_weightAuto.Visible = true;

                Load_StatusAuto();
                cbo_statusAuto.Text = "--ดูสถานะงานอื่น--";
                Load_DataRegister_Auto();  //load job sale
            }
            else
            {

                if (pn_auto.Visible == true)
                {
                    pn_detail.Width = 2;
                    pn_auto.Visible = false;
                    dtg_weightAuto.Visible = false;
                    pn_pur.Visible = false;
                    pn_sale.Visible = false;
                    dtg_weightPurchase.Visible = false;
                    dtg_weightSale.Visible = false;
                }

                else
                {
                    pn_auto.Dock = DockStyle.Top;
                    dtg_weightAuto.Dock = DockStyle.Fill;                 
                    pn_auto.Visible = true;
                    dtg_weightAuto.Visible = true;               
                    pn_pur.Visible = false;
                    dtg_weightPurchase.Visible = false;
                    pn_sale.Visible = false;
                    dtg_weightSale.Visible = false;

                }
            }
        }

        private void cbo_statusAuto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DataRegister_Auto();
        }

        private void dtp_historyAuto_ValueChanged(object sender, EventArgs e)
        {
            Load_StatusAuto();
        }

        private void dtg_weightAuto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            try
            {
                if (e.RowIndex > -1)
                {
                    con.Open();
                    string sql2 = "Update [TB_WeightData] Set [QueueNo] =" + dtg_weightAuto.Rows[e.RowIndex].Cells[3].Value.ToString() + " Where [TicketCodeIn] = '" + dtg_weightAuto.Rows[e.RowIndex].Cells[2].Value.ToString() + "'";
                    SqlCommand CM2 = new SqlCommand(sql2, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    con.Close();
                }
            }
            catch { MessageBox.Show("ใส่รูปแบบประเภทข้อมูลที่เป็นแบบตัวเลขเท่านั้น", "ใส่ข้อมูลผิดรูปแบบ", MessageBoxButtons.OK, MessageBoxIcon.Error); con.Close(); }

        }

        private void btn_checkAuto_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btn_checkOut, "งานชั่งอัตโนมัติ");
        }

        private void txt_qrCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(10);
                backgroundWorker1.WorkerReportsProgress = true;
                backgroundWorker1.ReportProgress(i);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tool_ProgressBar.Value = e.ProgressPercentage;
            tool_lblprogress.Text = "Processing.." + e.ProgressPercentage.ToString() + "%";
        }

        private void tg_Win_CheckedChanged(object sender, EventArgs e)
        {
            if (tg_Win.Checked == true)
            {
                sport.Close();
            }
            else
            {
                try
                {
                    sport.Open();
                }
                catch { }
            }
        }

        private void tg_Wout_CheckedChanged(object sender, EventArgs e)
        {
            if (tg_Wout.Checked == true)
            {
                sport.Close();
            }
            else
            {

                try
                {
                    sport.Open();
                }
                catch { }
            }
        }
    }
}
