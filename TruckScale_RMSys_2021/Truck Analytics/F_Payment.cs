using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Data.SqlClient;
using GemBox.Spreadsheet;
using GemBox.Spreadsheet.WinFormsUtilities;
using System.Threading;


namespace Truck_Analytics
{
    public partial class F_Payment : Form
    {
        public F_Payment()
        {
            InitializeComponent();
        }

        //public override string ReadLine();
        string Table_Name = "";
        string Log_NewValue = "";
        string Log_OldValue = "";
        string DB_Name = "";
        string VendorCode = "";
        int e_rowIndex = 0;
        string ID_VendorGPay = "";
        int LabID = 0;    //เก็บค่าประเภท การวิเคราะห์
        int PaysetID = 0;
        double StarchValue = 0;
        decimal Pricepay = 0;
        string ProductID = "";
        int C_count = 0;
                
        private void F_Payment_Load(object sender, EventArgs e)
        {            
            Load_items();
            Load_DBName();
            ststool_userlogin.Text = " Login Name: "+ Program.user_name;
            timer1.Enabled = true;

            if (Program.DB_Name != "SapthipNewDB")
            {
                groupBox1.BackColor = Color.Crimson;
            }
        }

        int service_total = 0;
        int load_total = 0;
        int id_checkprocess = 0;
        int count_VendorGroup = 0;

        private void Load_items()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                //Product 
                SqlCommand cmd = new SqlCommand("Select [ProductID],[ProductName]  From  [dbo].[TB_Products] WHERE [ProductID] = 'RM-001' OR [ProductID] = 'RM-004' ", con);
                DataSet ds = new DataSet();
                //ds.Clear();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                cb_product.DataSource = ds.Tables[0];
                cb_product.DisplayMember = "ProductName";
                cb_product.ValueMember = "ProductID";

            }
            catch { }

            cb_product.Text = "";
            cb_product.SelectedIndex = -1;
            lbl_productName.Text = "...";
        }

     
        private void Clear_DTG()
        {

            //dtg_weight.DataSource = null;
            dtg_calpayment.DataSource = null;
            dtg_calNav.DataSource = null;

            dtg_calNav.Rows.Clear();
            dtg_calNav.Columns.Clear();

            //dtg_CalPay.DataSource = null;
            // dtg_weight.Rows.Clear();
            //dtg_calpayment.Rows.Clear();            
            //dtg_calNav.Rows.Clear();

            // dtg_weight.Columns.Clear();
            //dtg_calpayment.Columns.Clear();           
            //dtg_calNav.Columns.Clear();

        }

        private void Load_DBName()
        {
            string config = Application.StartupPath + "\\config.dll";
            if (System.IO.File.Exists(config))
            {
                System.IO.StreamReader StrRer = new System.IO.StreamReader(config);

                List<string> listStr = new List<string>();

                while (!StrRer.EndOfStream)
                {
                    listStr.Add(StrRer.ReadLine());
                }
                DB_Name = listStr[4].ToString();

                StrRer.Close();
            }
        }

        private void Load_DATA_ConfirmPayment()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            dtg_weight.DataSource = null;



            if (cb_product.SelectedIndex >= -1)
            {
                string sql = "SELECT DISTINCT [TicketCodeIn] AS 'รหัส่ชั่ง',[DateIN] AS 'วันที่',[TimeIN] AS 'เวลา',[ProductID] AS 'รหัสสินค้า' ,[QueueNo] AS 'คิว',[Vendor_No] AS 'รหัสผู้ขาย',[Vendor_Name] AS 'ชื่อผู้ขาย',[Plate1] AS 'ทะเบียน',[GrossWeight] AS 'น้ำหนักสุทธิ',[DiscutValue] AS 'น้ำหนักตัด',FORMAT([GrossWeight] - (([GrossWeight]*[DiscutValue])/100),'###') AS 'น้ำหนักก่อนจ่าย',[Price] AS 'ราคาซื้อ',[PriceExtra] AS 'ราคาพิเศษ',[PriceNet] AS 'ราคาจ่ายหน้าตั๋ว',[LabValue1] AS 'วิเคราะห์1',[LabValue2] AS 'วิเคราะห์2',[LabValue3] AS 'วิเคราะห์3',[LabValue4] AS 'วิเคราะห์4',[LabVselect] AS 'เลือกผลวิเคราะห์'   FROM [dbo].[V_PaymentPending] WHERE [ProductID] = '" + cb_product.SelectedValue.ToString().Trim() + "' AND [proc_type] = 'P' ";

                SqlDataAdapter da1 = new SqlDataAdapter(sql, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_l");
                dtg_weight.DataSource = ds1.Tables["g_l"];
                con.Close();

                dtg_weight.Columns[0].Width = 120;
                dtg_weight.Columns[4].Width = 60;
                dtg_weight.Columns[5].Width = 100;
                dtg_weight.Columns[6].Width = 150;
                dtg_weight.Columns[9].Width = 60;
                dtg_weight.Columns[11].Width = 60;
                dtg_weight.Columns[12].Width = 60;

                ststool_totalweight.Text = "Total :" + dtg_weight.RowCount.ToString() + " Items";
            }
        }


        private void Load_Cal_Payment1()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();


            if (cb_product.SelectedValue.ToString() != "System.Data.DataRowView")
            {

                string sql1 = "SELECT DISTINCT [TicketCodeIn] AS 'รหัส่ชั่ง',[DateIN] AS 'วันทึ่ชั่ง',[ProductID] AS 'รหัสสินค้า' ,[QueueNo] AS 'คิว',[Vendor_No] AS 'รหัสผู้ขาย',[Vendor_Name] AS 'ชื่อผู้ขาย','' AS 'กลุ่ม/โควต้า',[Plate1] AS 'ทะเบียน',FORMAT([GrossWeight],'###') AS 'น้ำหนักสุทธิ','' AS 'ผล QA','' AS 'หลังตัด SP','' AS 'นน.หลังจ่าย',CAST([LabVselect] AS INT) AS '%แป้ง','' AS 'ราคารับซื้อ','' AS 'หักค่าชั่ง','' AS 'หักค่าลง','' AS 'รวมค่าบริการ' ,'' AS 'ราคาก่อนหัก','' AS 'ราคาหลังหัก','' AS 'นน.เจือป่น','' AS 'นน.ก่อนจ่าย','' AS 'ผล SP','' AS 'หมายเหตุ' FROM  [dbo].[V_PaymentPending] WHERE [ProductID] = '" + cb_product.SelectedValue.ToString().Trim() + "' AND [proc_type] = 'P' ";

                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_l");
                dtg_calpayment.DataSource = ds1.Tables["g_l"];
                con.Close();

                st_toolpayment.Text = "Total :" + dtg_calpayment.RowCount.ToString() + " Items";
                dtg_calpayment.ClearSelection();


                string sql2 = "SELECT DISTINCT [TicketCodeIn]  AS 'บัตรชั่ง',[DateIN] AS 'วันที่ชั่ง',[TimeIN] AS 'เวลาชั่ง' ,[QueueNo] AS 'คิว',[Vendor_No] AS 'รหัสผู้ขาย' ,[Vendor_Name] AS 'ชื่อผู้ขาย' ,[Plate1] AS 'ทะเบียนรถ',[InboundWeight] AS 'นน.เข้า' ,[OutboundWeight] AS 'นน.ออก' ,[GrossWeight] AS 'นน.สุทธิ' ,[Starch] AS 'ค่าแป้ง' ,[Head] AS 'ค่าเหง้า' ,[Moist] AS 'ค่าชื้น/เน่า' ,[Impur] AS 'ค่า สจป.' FROM [SapthipNewDB].[dbo].[V_PaymentPending_Export] WHERE [ProductID] = '" + cb_product.SelectedValue.ToString().Trim() + "' AND [proc_type] = 'P' ";

                SqlDataAdapter da2 = new SqlDataAdapter(sql2, con);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2, "g_e");
                dtg_exportFile.DataSource = ds2.Tables["g_e"];
                con.Close();

                ms_toolcalExport.Text = "Total :" + dtg_exportFile.RowCount.ToString() + " Items";
                dtg_exportFile.ClearSelection();


            }
        }

        private void Check_coutVendor()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;

            con.Open();
            string sql1 = "Select Count([VendorGroupID]) AS CountItems  From  [dbo].[V_CalPayment_VenGroup] Where [Vendor_No]='" + VendorCode + "' AND [ProductID]='" + lbl_productName.Text.Trim() + "' AND [StsActive] =1 ";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();
            DR1.Read();
            {
               count_VendorGroup = Convert.ToInt16(DR1["CountItems"].ToString());       
            }
            DR1.Close();
            con.Close();
        }


        private void Load_Cal_Payment2()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;

            SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
            con1.ConnectionString = Program.pathdb_Weight;

            //SqlDataAdapter dtAdapter = new SqlDataAdapter();
            //con.Open();

            int e_Index = 0;
            string Table = "";
            int Optional_Status = 0;
            decimal Optional_Value = 0;
            int ExcludeMoistStatus = 0;
            decimal ExcludeMoist_value = 0;


            //try
            //{
            for (int i = 0; i < dtg_calpayment.RowCount; i++)
            {

                try
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                   
                    e_Index = i;
                    con.Open();
                    Table = "กลุ่มผู้ขาย";

                    VendorCode = dtg_calpayment.Rows[i].Cells[4].Value.ToString().Trim();

                    Check_coutVendor();

                    if (count_VendorGroup == 1)
                    {
                        string sql1 = "Select [VendorGroupID],[PriceFac],[OptionalVisual],[OptionalVisualStatus],[ExcludeMoistStatus]   From  [dbo].[V_CalPayment_VenGroup] Where [Vendor_No]='" + dtg_calpayment.Rows[i].Cells[4].Value.ToString().Trim() + "' AND [ProductID]='" + dtg_calpayment.Rows[i].Cells[2].Value.ToString().Trim() + "' AND [StsActive] =1 ";
                        SqlCommand CM1 = new SqlCommand(sql1, con);
                        SqlDataReader DR1 = CM1.ExecuteReader();
                        DR1.Read();
                        {
                            dtg_calpayment.Rows[i].Cells[6].Value = DR1["VendorGroupID"].ToString();
                            dtg_calpayment.Rows[i].Cells[13].Value = DR1["PriceFac"].ToString();

                            if (DR1["OptionalVisualStatus"].ToString() == "True")
                            {
                                Optional_Status = 1;
                                Optional_Value = Convert.ToDecimal(DR1["OptionalVisual"].ToString());
                            }


                            //ExcludeMoistStatus  --ไม่คิดรวมผลวิเคราะห์ประเภท: เน่า
                            //OptionalVisualStatus   --คิดผลตัดรวมเท่ากับ/ไม่เกิน:

                            if (DR1["ExcludeMoistStatus"].ToString() == "True")
                            {
                                ExcludeMoistStatus = 1;
                            }

                        }
                        DR1.Close();
                        con.Close();
                    }
                    else
                    {

                        dtg_calpayment.Rows[i].Cells[6].Value = "#N/A";
                        dtg_calpayment.Rows[i].Cells[22].Value = "กลุ่ม/โควต้า >2";
                        count_VendorGroup = 0;
                    }          
                    
                    string DisctPrice ; 
                        //// เก็บค่า ว่าจะให้ตัด เป็นราคาเงิน หรือ ตัดเป็นน้ำหนัก
                        //    0 = หักเป็นจำนวนเงิน
                        //    1 = หักเป็นน้ำหนัก
                        
                    int LabtypeID = 0;
                    //เก็บค่า ว่าบันทึกที่ตาราง Visual หรือ ตาราง Lab
                    // 1= เข็คค่าที่ตาราง Lab
                    // 2= เช็คที่ตาราง Visual
                    string LabName;     //ชือผลวิเคราะห
                    decimal LabValue = 0;   //เก็บค่าบันทึกจากตาราง V_VisualLog
                    decimal Sum_Visual_BF=0 ; //เก็บค่าผลรวมของ ก่อนคำนวนผลสุดท้าย
                    decimal Sum_Visual_AF =0; //เก็บค่าผลรวมของ ผลสุดท้ายแต่ละรายการวิเคราะห์                 

                    decimal Sum_Starch_BF = 0;  //ค่าแป้งก่อนคำนวน
                    decimal Sum_Starch_AF = 0; //ค่าแป้งหลังคำนวน

                    //Table = "ค้นหาการบัน";
                    con.Open();

                    //MessageBox.Show(dtg_calpayment.Rows[i].Cells[0].Value.ToString().Trim());

                    string sql3 = "Select * From  [dbo].[V_VisualLog] Where [TicketCodeIn]='" + dtg_calpayment.Rows[i].Cells[0].Value.ToString().Trim() + "' AND [LabOpserv] = 0 Order by [LabID]";

                    SqlCommand CM3 = new SqlCommand(sql3, con);
                    SqlDataReader DR3 = CM3.ExecuteReader();
                    while (DR3.Read())
                    {
                        LabID = Convert.ToInt16(DR3["LabID"].ToString());
                        LabtypeID = Convert.ToInt16(DR3["LabtypeID"].ToString());  //เช็ควว่า จะตัด ที่ตารางเกณฑ์ไหน
                        LabValue = Convert.ToDecimal(DR3["LabValue"].ToString());
                        LabName = DR3["LabName"].ToString();
                        DisctPrice = DR3["DisctPrice"].ToString();                                  

                        if (con1.State == ConnectionState.Open) { con1.Close(); } /* con1.Open();*/

                        //DisctPrice   -> หักราคา หรือหัก นน.  
                        //-  = 0  หักน้ำหนัก
                        //  =  1 หักราคา

                        //LabtypeID    -> ดึงเกณฑ์วิเคราะห์ จาก table
                        //  =   1   ดึงข้อมูลเประเภทเครื่องมือ  Table Lab
                        //   =   2 ดึงข้อมูฃประเภทกายภาพ Table Visual
                        //Sum_Visual_BF = 0;
                        //Sum_Visual_AF = 0;

                        try
                        {
                            //if (DisctPrice == 0)
                            //{

                            //---------------- เช็ค ข้อมูล ว่าค่าอยู่ Table ไหน ถ้าค่า = 1 คือค่าของ Visual WH อยู่ที่ Lab ของ SP
                            string id_CheckTable;
                            ProductID = dtg_calpayment.Rows[i].Cells[2].Value.ToString().Trim();

                            con1.Open();
                            string sql100 = "Select [Dilldata]  From  [dbo].[TB_LabName] Where [LabName]='" + LabName + "' AND [LabActive]=1 AND [ProductID]='" + dtg_calpayment.Rows[i].Cells[2].Value.ToString().Trim() + "'";
                            SqlCommand CM100 = new SqlCommand(sql100, con1);
                            SqlDataReader DR100 = CM100.ExecuteReader();
                            DR100.Read();
                            {
                                id_CheckTable = DR100["Dilldata"].ToString();
                            }
                            DR100.Close();
                            con1.Close();

                            decimal Starch_min = 0;
                            decimal Starch_max = 0;


                            if (DisctPrice == "False") //เก็บค่า Visual
                            {
                                //Sum_Visual_BF += Convert.ToDecimal(DR3["LabValue"].ToString());
                                Sum_Visual_BF += LabValue;
                            }


                            if (LabtypeID == 1) //ดึงข้อมูลจาก การบันทึกผู้วิเคราะห์แบบใช้เครื่องมือ
                            {
                                // { Sum_Visual_BF += Convert.ToDecimal(DR3["LabValue"].ToString()); }  //เก็บค่ารวมน้ำหนักที่เป็นประเภทน้ำนหัก

                                Table = "เงื่อนไขการจ่าย-SP";  // % แป้ง
                                string sql2 = "";
                                string sql5 = "";

                                //if (DisctPrice == "False") //เก็บค่า Visual
                                //{
                                //    //Sum_Visual_BF += Convert.ToDecimal(DR3["LabValue"].ToString());
                                //    Sum_Starch_BF += LabValue;
                                //}

                                sql2 = "Select Top(1)[ValueSP] From [dbo].[V_CalPayment_Lab] Where [MinSP] <= " + LabValue + " AND [VendorGroupID]='" + dtg_calpayment.Rows[i].Cells[6].Value.ToString().Trim() + "' AND [ProductID]='" + dtg_calpayment.Rows[i].Cells[2].Value.ToString().Trim() + "' AND [LabID]=" + LabID + " Order by [MinSP] desc ";


                                sql5 = "Select Top(1)[ValueSP] From [dbo].[V_CalPayment_Lab] Where [MaxSP] >= " + LabValue + " AND [VendorGroupID]='" + dtg_calpayment.Rows[i].Cells[6].Value.ToString().Trim() + "' AND [ProductID]='" + dtg_calpayment.Rows[i].Cells[2].Value.ToString().Trim() + "'  AND [LabID]=" + LabID + " Order by [MaxSP] ";


                                try
                                {
                                    con1.Open();
                                    SqlCommand CM2 = new SqlCommand(sql2, con1);
                                    SqlDataReader DR2 = CM2.ExecuteReader();
                                    DR2.Read();
                                    {
                                        if (DisctPrice == "True") //เก็บค่า ที่เพิ่ม หัก เป็นตัวเงิน
                                        {
                                            Starch_min = Convert.ToDecimal(DR2["ValueSP"].ToString());
                                        }

                                        else   //เก็บค่า ที่หัก เป็นตัว นน.
                                        {
                                            Sum_Visual_AF += Convert.ToDecimal(DR2["ValueSP"].ToString());
                                        }

                                    }
                                    DR2.Close();
                                    con1.Close();
                                }
                                catch { Starch_min = 0; }

                                try
                                {
                                    con1.Open();
                                    SqlCommand CM5 = new SqlCommand(sql5, con1);
                                    SqlDataReader DR5 = CM5.ExecuteReader();
                                    DR5.Read();
                                    {
                                        Starch_max = Convert.ToDecimal(DR5["ValueSP"].ToString());
                                    }
                                    DR5.Close();
                                    con1.Close();
                                }
                                catch { Starch_max = 0; }

                                if (LabName != "แป้ง")
                                {
                                    if (Starch_min == Starch_max)
                                    {
                                        Sum_Starch_AF += Starch_min;
                                    }
                                    else
                                    {
                                        Sum_Starch_AF += Starch_max;
                                    }
                                }

                                else
                                {
                                    decimal strach = 0;

                                    if (dtg_calpayment.Rows[i].Cells[13].Value.ToString().Trim() != "")
                                    { strach = Convert.ToDecimal(dtg_calpayment.Rows[i].Cells[13].Value.ToString().Trim().ToString()); }

                                    dtg_calpayment.Rows[i].Cells[13].Value = strach + (Starch_max);
                                    //Visual_max = Visual_max

                                }
                            }

                            if (LabtypeID == 2)  //การบันทึกผู้วิเคราะห์แบบกายภาพ                    
                            {

                                Table = "เงื่อนไขตัดน้ำหนัก-SP";

                                decimal visual_min = 0;
                                decimal visual_max = 0;

                                if (con1.State == ConnectionState.Open)
                                {
                                    con1.Close();
                                }

                                if (id_CheckTable == "True") //// เช้ค ค่า visaul ต่างตาราง จาก level เปลี่ยนค่าใช้งานที่ SP ทำจ่าย
                                {
                                    Check_Dill_Data(); //เช็คการดึงค่าจากค่าตาราง Level เป็นตาราง Range  ของแผนก SP ที่ถูกเซ็ตไว้ที่หน้า QA filed "มีเงื่อนไขการจ่าย"

                                    if (C_count == 0) // 
                                    {
                                        con1.Open();
                                        string sql40 = "SELECT Top(1) [ValueSP] FROM [dbo].[V_CalPayment_Visual] WHere [LabID]='" + LabID + "' AND [ValueWH] >=" + LabValue + " AND [VendorGroupID]='" + dtg_calpayment.Rows[i].Cells[6].Value.ToString().Trim() + "' AND [StatusSP]=1 Order by [ValueWH]";

                                        SqlCommand CM40 = new SqlCommand(sql40, con1);
                                        SqlDataReader DR40 = CM40.ExecuteReader();
                                        DR40.Read();
                                        {
                                            visual_max = Convert.ToDecimal(DR40["ValueSP"].ToString());
                                        }
                                        DR40.Close();
                                        con1.Close();
                                    }

                                    else
                                    {
                                        string sql41 = "SELECT top 1[ValueSP] AS 'ValueSP_Min' FROM [dbo].[V_VisualSP_DillData]  Where  [LabID] = " + LabID + "  AND Convert(float,[Vmin]) <= " + LabValue + " AND [VendorGroupID]='" + dtg_calpayment.Rows[i].Cells[6].Value.ToString().Trim() + "' AND [StatusSP]=1  Order By [idVSRNo] Desc";

                                        string sql42 = "SELECT top 1[ValueSP] AS 'ValueSP_Max' FROM [dbo].[V_VisualSP_DillData]  Where  [LabID] = " + LabID + " AND Convert(float,[Vmax]) >= " + LabValue + " AND [VendorGroupID]='" + dtg_calpayment.Rows[i].Cells[6].Value.ToString().Trim() + "' AND [StatusSP]=1 Order By [idVSRNo] ASC";

                                        con1.Open();
                                        SqlCommand CM41 = new SqlCommand(sql41, con1);
                                        SqlDataReader DR41 = CM41.ExecuteReader();
                                        DR41.Read();
                                        {
                                            visual_min = Convert.ToDecimal(DR41["ValueSP_Min"].ToString());
                                        }
                                        DR41.Close();
                                        con1.Close();

                                        con1.Open();
                                        SqlCommand CM42 = new SqlCommand(sql42, con1);
                                        SqlDataReader DR42 = CM42.ExecuteReader();
                                        DR42.Read();
                                        {
                                            visual_max = Convert.ToDecimal(DR42["ValueSP_Max"].ToString());
                                        }
                                        DR42.Close();
                                        con1.Close();
                                    }

                                    //-- Labid 17  เน่า  มันสด
                                    //-- ExcludeMoistStatus ไม่คิดผลรวมประเภทเน่า

                                    //ExcludeMoist_value  ตัดไม่เกิน
                                    //ExcludeMoistStatus   ไม่คิด ค่า Lab ประเภทเน่า  (ID 17)

                                    if (visual_min == visual_max)
                                    {
                                        if (LabID == 17 && ExcludeMoistStatus == 1)
                                        {
                                            ExcludeMoist_value += visual_min;
                                        }
                                        else
                                        {
                                            Sum_Visual_AF += visual_min;
                                        }

                                    }
                                    else
                                    {
                                        if (LabID == 17 && ExcludeMoistStatus == 1)
                                        {
                                            ExcludeMoist_value += visual_max;
                                        }
                                        else
                                        {
                                            Sum_Visual_AF += visual_max;
                                        }
                                    }

                                }



                                //ดึงค่า visual จากตาราง lab
                                //else
                                //{
                                //    con1.Open();
                                //    string sql40 = "SELECT Top(1) [ValueSP] FROM [dbo].[V_CalPayment_Lab] WHere [LabName]='" + LabName + "' AND[MinSP] <=" + LabValue + " AND [VendorGroupID]='" + dtg_calpayment.Rows[i].Cells[6].Value.ToString().Trim() + "' AND [ProductID]='" + dtg_calpayment.Rows[i].Cells[2].Value.ToString().Trim() + "' AND [StatusSP]=1 Order by [MinSP] Desc";
                                //    SqlCommand CM40 = new SqlCommand(sql40, con1);
                                //    SqlDataReader DR40 = CM40.ExecuteReader();
                                //    DR40.Read();
                                //    {
                                //        Visual_min = Convert.ToDecimal(DR40["ValueSP"].ToString());
                                //    }
                                //    DR40.Close();
                                //    con1.Close();

                                //    con1.Open();
                                //    string sql61 = "SELECT Top(1) [ValueSP] FROM [dbo].[V_CalPayment_Lab] WHere [LabName]='" + LabName + "' AND[MaxSP] >=" + LabValue + " AND [VendorGroupID]='" + dtg_calpayment.Rows[i].Cells[6].Value.ToString().Trim() + "' AND [ProductID]='" + dtg_calpayment.Rows[i].Cells[2].Value.ToString().Trim() + "' AND [StatusSP]=1 ";

                                //    SqlCommand CM61 = new SqlCommand(sql61, con1);
                                //    SqlDataReader DR61 = CM61.ExecuteReader();
                                //    DR61.Read();
                                //    {
                                //        Visual_max = Convert.ToDecimal(DR61["ValueSP"].ToString());
                                //    }
                                //    DR61.Close();
                                //    con1.Close();

                                //    if (Visual_min == Visual_max)
                                //    {
                                //        if (LabID == 17 && ExcludeMoistStatus == 1)
                                //        {
                                //            ExcludeMoist_value += Visual_min;
                                //        }
                                //        else
                                //        {
                                //            Sum_Visual_AF += Visual_min;
                                //        }
                                //    }
                                //    else
                                //    {
                                //        if (LabID == 17 && ExcludeMoistStatus == 1)
                                //        {
                                //            ExcludeMoist_value += Visual_max;
                                //        }
                                //        else
                                //        {
                                //            Sum_Visual_AF += Visual_max;
                                //        }
                                //    }

                                //    //Sum_Visual_BF = 0;
                                //    //Sum_Visual_AF = 0;

                                //}


                                //Sum_Visual_BF += LabValue;

                                //MessageBox.Show(Sum_Visual_BF.ToString(), " Sum_Visual_BF Loop 2");

                                //MessageBox.Show(Sum_Visual_AF.ToString(), " Sum_Visual_AF Loop 2");

                            }


                            //dtg_calpayment.Rows[e_Index].Cells[9].Value = Sum_Visual_BF.ToString();   //ก่อนตัด เกณฑ์ SP (เกณฑ์ตัดของ QA)
                            //dtg_calpayment.Rows[e_Index].Cells[21].Value = Sum_Visual_AF.ToString();   //หลังตัดเกณฑ์ SP เพ่ิม


                            //MessageBox.Show(Sum_Visual_BF.ToString(), " Sum_Visual_BF Loop 2");
                            //MessageBox.Show(Sum_Visual_AF.ToString(), " Sum_Visual_AF Loop 2");

                            dtg_calpayment.Rows[e_Index].Cells[9].Value = Sum_Visual_BF.ToString();   //ก่อนตัด เกณฑ์ SP (เกณฑ์ตัดของ QA)
                            dtg_calpayment.Rows[e_Index].Cells[21].Value = Sum_Visual_AF.ToString();

                        }
                        catch
                        {
                            dtg_calpayment.Rows[e_Index].Cells[22].Value = Table; Table = "";
                        }

                        //DisctPrice = 0;
                   
                    }

                    con.Close();
                                                      

                    if (ExcludeMoistStatus == 1)
                    {
                        if (Optional_Status == 1)
                        {
                            if (Sum_Visual_AF >= Optional_Value)
                            {
                                Optional_Value += ExcludeMoist_value;
                            }

                            else
                            {
                                Sum_Visual_AF += ExcludeMoist_value;
                            }
                        }
                    }

                    //Optional    คิดผลตัดรวมเท่ากับ/ไม่เกิน:
                    if (Optional_Status == 1)
                    {
                        if (Sum_Visual_AF >= Optional_Value)
                        {                         

                            dtg_calpayment.Rows[e_Index].Cells[10].Value = Optional_Value.ToString("F");

                            dtg_calpayment.Rows[e_Index].Cells[10].Style.BackColor = Color.Azure;
                        }

                        else
                        {                           
                            dtg_calpayment.Rows[e_Index].Cells[10].Value = Sum_Visual_AF.ToString();
                        }
                    }
                                                         
                    else
                    {
                        dtg_calpayment.Rows[e_Index].Cells[10].Value = dtg_calpayment.Rows[e_Index].Cells[21].Value.ToString();
                    }
                                                         
                    //คำนวนน้ำหนักสินค้า ตามเกณฑ์ใหม่
                    double net_weight = Convert.ToDouble(dtg_calpayment.Rows[i].Cells[8].Value.ToString());
                    double xx = net_weight * Convert.ToDouble(dtg_calpayment.Rows[i].Cells[10].Value.ToString()) / 100;
                    double weightBFpay = net_weight - xx;

                    dtg_calpayment.Rows[i].Cells[19].Value = xx.ToString("##,###.##");
                    dtg_calpayment.Rows[i].Cells[20].Value = weightBFpay.ToString("###.##");

                    double cc = System.Math.Floor(xx);
                        double vv = xx - cc;

                        if (vv >= 0.50)  //คำนวน น้ำหนักหัก เกินหรือเท่ากับ 0.50 ปัดขึ้น
                        {
                            xx = System.Math.Floor(xx) + 1;
                        }
                        ///Floor
                        else { xx = cc; }

                        double gross_weight = net_weight - System.Math.Round(xx);
                        dtg_calpayment.Rows[i].Cells[11].Value = System.Math.Round(gross_weight).ToString("##,###.##");

                        //คำนวณเงินจ่ายที่ได้จาก % แป้งแล้ว
                        StarchValue = Convert.ToDouble(dtg_calpayment.Rows[i].Cells[13].Value.ToString());

                        //double TotalPay = (gross_weight * StarchValue) *1;

                    double TotalPay = Math.Round(gross_weight * StarchValue, 2);


                    //หัาค่าบริการ   // service charge
                        dtg_calpayment.Rows[i].Cells[14].Value = "0";     //- Service Weight
                        dtg_calpayment.Rows[i].Cells[15].Value = "0";      // -  Service Load
                        dtg_calpayment.Rows[i].Cells[16].Value = "0";     // - total

                    decimal vat = 0;
                    decimal WeightPrice = 0;
                    decimal LoadPrice = 0;
                    decimal Total_Price = 0;
                    int vat_include = 0;


                    try
                    {
                        con1.Open();
                        string sql60 = "SELECT [WeightPrice],[LoadPrice],[IncludeVat],[VatUnit] FROM  [dbo].[V_Service_payment] WHere [TicketCodeIn]='" + dtg_calpayment.Rows[i].Cells[0].Value.ToString().Trim() + "'";
                        SqlCommand CM60 = new SqlCommand(sql60, con1);
                        SqlDataReader DR60 = CM60.ExecuteReader();
                        DR60.Read();
                        {
                            if (DR60["IncludeVat"].ToString() == "True")
                            { vat_include = 1; }

                            vat = Convert.ToDecimal(DR60["VatUnit"].ToString());
                            WeightPrice = Convert.ToDecimal(DR60["WeightPrice"].ToString());
                            LoadPrice = Convert.ToDecimal(DR60["LoadPrice"].ToString());
                        }
                        DR60.Close();
                        con1.Close();
                    }

                    catch
                    {
                        vat = 0;
                        WeightPrice = 0;
                        LoadPrice = 0;
                    }


                    decimal price_w = (WeightPrice * 100) / (100 + vat);
                    decimal price_l = (LoadPrice * 100) / (100 + vat);
                    // iNcluede Vat
                    if (vat_include == 1)
                    {
                        WeightPrice = price_w;
                        LoadPrice = price_l;
                    }

                    Total_Price = WeightPrice + LoadPrice;

                    dtg_calpayment.Rows[i].Cells[14].Value = WeightPrice.ToString("F");
                    dtg_calpayment.Rows[i].Cells[15].Value = LoadPrice.ToString("F");
                    dtg_calpayment.Rows[i].Cells[16].Value = Total_Price.ToString("F");

                  
                    double CheckDef = System.Math.Floor(TotalPay);
                        double Answer = TotalPay - CheckDef;

                        if (Answer >= 0.5)
                        {
                            CheckDef = CheckDef + 1;
                            dtg_calpayment.Rows[i].Cells[17].Value = CheckDef.ToString("##,###.##");
                        }

                        else
                        {
                            dtg_calpayment.Rows[i].Cells[17].Value = CheckDef.ToString("##,###.##");
                        }


                    if (dtg_calpayment.Rows[i].Cells[16].Value.ToString() != "0.00")
                    {
                        double Dicut_Service = Convert.ToDouble(dtg_calpayment.Rows[i].Cells[16].Value.ToString());
                        double Sum_Service = ((Dicut_Service * 7) / 100) + Dicut_Service;

                        CheckDef = CheckDef - Sum_Service;

                        dtg_calpayment.Rows[i].Cells[18].Value = CheckDef.ToString("##,###.##");
                    }
                    else { dtg_calpayment.Rows[i].Cells[18].Value = dtg_calpayment.Rows[i].Cells[17].Value.ToString(); }


                    if (dtg_calpayment.Rows[i].Cells[19].Value.ToString() == "")
                    {
                        dtg_calpayment.Rows[i].Cells[19].Value = "-";
                    }

                    Optional_Status = 0;        
                }
                catch
                {
                    //dtg_calpayment.Rows[e_Index].Cells[16].Value = Table;
                }

            }


            try
            {
                for (int z = 0; z < dtg_calpayment.RowCount; z++)
                {
                    if (dtg_calpayment.Rows[z].Cells[22].Value.ToString() != "")
                    {
                        dtg_calpayment.Rows[z].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
                
                dtg_calpayment.Columns[0].Width = 110;
                dtg_calpayment.Columns[1].Width = 100;
                dtg_calpayment.Columns[2].Width = 80;
                dtg_calpayment.Columns[3].Width = 50;
                dtg_calpayment.Columns[4].Width = 100;
                dtg_calpayment.Columns[5].Width = 150;
                dtg_calpayment.Columns[7].Width = 100;
                dtg_calpayment.Columns[8].Width = 100;
                dtg_calpayment.Columns[9].Width = 80;
                dtg_calpayment.Columns[10].Width = 110;
                dtg_calpayment.Columns[11].Width = 100;
                dtg_calpayment.Columns[12].Width = 60;
                dtg_calpayment.Columns[13].Width = 80;
                dtg_calpayment.Columns[14].Width = 80;
                dtg_calpayment.Columns[15].Width = 80;
                dtg_calpayment.Columns[16].Width = 80;
                dtg_calpayment.Columns[17].Width = 110;
                dtg_calpayment.Columns[18].Width = 110;
                dtg_calpayment.Columns[22].Width = 160;
                this.dtg_calpayment.Columns[9].DefaultCellStyle.BackColor = Color.Wheat;
                this.dtg_calpayment.Columns[10].DefaultCellStyle.BackColor = Color.LightBlue;
                this.dtg_calpayment.Columns[11].DefaultCellStyle.BackColor = Color.LightGreen;
                this.dtg_calpayment.Columns[12].DefaultCellStyle.BackColor = Color.LightCyan;
                this.dtg_calpayment.Columns[13].DefaultCellStyle.BackColor = Color.LightGreen;
                this.dtg_calpayment.Columns[14].DefaultCellStyle.BackColor = Color.Wheat;
                this.dtg_calpayment.Columns[15].DefaultCellStyle.BackColor = Color.Wheat;
                this.dtg_calpayment.Columns[16].DefaultCellStyle.BackColor = Color.Wheat;
                this.dtg_calpayment.Columns[17].DefaultCellStyle.BackColor = Color.Wheat;
                this.dtg_calpayment.Columns[18].DefaultCellStyle.BackColor = Color.LightGreen;
                this.dtg_calpayment.Columns[20].DefaultCellStyle.BackColor = Color.Wheat;
                this.dtg_calpayment.Columns[21].DefaultCellStyle.BackColor = Color.Wheat;
            }
            catch { }

            dtg_calpayment.ClearSelection();
        }
                  
        private void Check_Dill_Data()
        {

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql4 = "Select Count([LabID]) AS 'C_count' FROM  [dbo].[TB_LabName]  WHERE [ProductID] = '" + ProductID + "' AND [LabActive]=1 AND  [LabtypeID]=2 AND [Dilldata] =1 AND [LabPayment]=1 AND [LabID]=" + LabID  + "";
            SqlCommand CM = new SqlCommand(sql4, con);
            SqlDataReader DR = CM.ExecuteReader();
            DR.Read();
            {
                C_count = Convert.ToUInt16(DR["C_count"].ToString());
            }
            DR.Close();
            con.Close();

        }

        private void btn_calculator_Click(object sender, EventArgs e)
        {
            Cal_NAV();    //คำนวนเข้านาวิชั่น
            Load_Vendor();
            Load_MAP_Customer();
            Load_Summary();
            tabControl2.SelectedIndex = 2;
            tabControl4.SelectedIndex = 0;

            if (dtg_calNav.RowCount != 0)
            {
                btn_savetoTempNav.Enabled = true;
            }
        }

        private void Load_Cal_Payment3()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            if (cb_product.SelectedIndex > -1)
            {

                //FORMAT([GrossWeight] - (([GrossWeight]*[DiscutValue])/100),'N2') AS 'น้ำหนักก่อนจ่าย',[
                string sql = "SELECT DISTINCT [Vendor_No] AS 'รหัสผู้ขาย',[Vendor_Name] AS 'ชื่อผู้ขาย',[ProductID] AS 'รหัสสินค้า','' AS 'นน.สุทธิรวม','' AS 'ราคารับซื้อ/กก.','' AS 'ราคารวม','' AS 'ค่าชั่งสินค้า','' AS 'ค่าลงสินค้า','' AS 'ราคาจ่ายจริง',[DateIN] AS 'วันที่จ่าย','' AS 'Cal','' AS 'To_Store' FROM  [dbo].[V_PaymentPending]  WHERE [proc_type] = 'P' AND [ProductID]='" + cb_product.SelectedValue.ToString() + "'";

                SqlDataAdapter da1 = new SqlDataAdapter(sql, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_l");
                dtg_CalPay.DataSource = ds1.Tables["g_l"];
                con.Close();

                //dtg_calpayment.Columns[1].Width = 80;
                //dtg_calpayment.Columns[2].Width = 80;
                //Load_Cal_Payment2();
            }

            decimal Sum_Netweight = 0;
            decimal Sum_Price = 0;
            decimal Unit_Price = 0;
            decimal PriceService_weight = 0;
            decimal PriceService_Load = 0;
            decimal Sum_PriceService = 0;
            decimal Sum_NetPrice = 0;
            decimal Sum_Store = 0;

            for (int i = 0; i < dtg_CalPay.RowCount; i++)
            {
                Sum_Netweight = 0;
                Sum_Price = 0;
                Unit_Price = 0;
                PriceService_weight = 0;
                PriceService_Load = 0;
                Sum_PriceService = 0;
                Sum_NetPrice = 0;
                Sum_Store = 0;


                for (int x = 0; x < dtg_calpayment.RowCount; x++)
                {
                    if (dtg_CalPay.Rows[i].Cells[1].Value.ToString().Trim() == dtg_calpayment.Rows[x].Cells[4].Value.ToString().Trim() && dtg_CalPay.Rows[i].Cells[10].Value.ToString().Trim() == dtg_calpayment.Rows[x].Cells[1].Value.ToString().Trim())
                    {

                        //น้ำหนักรวม
                        if (dtg_calpayment.Rows[x].Cells[11].Value.ToString().Trim() != "")
                        {
                            //decimal xx = Convert.ToDecimal(dtg_calpayment.Rows[x].Cells[15].Value.ToString());
                            Sum_Netweight += Convert.ToDecimal(dtg_calpayment.Rows[x].Cells[11].Value.ToString());

                        }

                        //หักค่าบริการชั่งสินค้า
                        if (dtg_calpayment.Rows[x].Cells[14].Value.ToString().Trim() != "")
                        {
                            PriceService_weight += Convert.ToDecimal(dtg_calpayment.Rows[x].Cells[14].Value.ToString().Trim());
                        }
                       

                        //หักค่าบริการงานลงสินค้า
                        if (dtg_calpayment.Rows[x].Cells[15].Value.ToString().Trim() != "")
                        {
                            PriceService_Load += Convert.ToDecimal(dtg_calpayment.Rows[x].Cells[15].Value.ToString().Trim());
                        }                  

                        //หักค่าบริการรวม
                        if (dtg_calpayment.Rows[x].Cells[16].Value.ToString().Trim() != "")
                        {
                            Sum_PriceService += Convert.ToDecimal(dtg_calpayment.Rows[x].Cells[16].Value.ToString().Trim());
                        }


                        //ราคารวม                        
                        if (dtg_calpayment.Rows[x].Cells[18].Value.ToString().Trim() != "")
                        {
                            //decimal xx = Convert.ToDecimal(dtg_calpayment.Rows[x].Cells[15].Value.ToString());
                            Sum_Price += Convert.ToDecimal(dtg_calpayment.Rows[x].Cells[18].Value.ToString());
                        }


                        //นน. เข้าคลัง                       
                        if (dtg_calpayment.Rows[x].Cells[8].Value.ToString().Trim() != "")
                        {
                            //decimal xx = Convert.ToDecimal(dtg_calpayment.Rows[x].Cells[15].Value.ToString());
                            Sum_Store += Convert.ToDecimal(dtg_calpayment.Rows[x].Cells[8].Value.ToString());

                        }
                        
                        dtg_CalPay.Rows[i].Cells[7].Value = Sum_PriceService.ToString();
                                                                       
                        //dtg_CalPay.Rows[i].Cells[12].Value = dtg_calpayment.Rows[x].Cells[8].Value.ToString();

                        try
                        {

                            //Decimal covert_Price = ((Sum_PriceService * 7) / 100) + Sum_PriceService;
                            //Sum_PriceService = covert_Price;

                            Unit_Price = Sum_Price / Sum_Netweight;
                            Sum_NetPrice = Sum_Price;// + Sum_PriceService;
                            //Sum_NetPrice = Sum_Price ;

                            decimal xx = Sum_Netweight * Convert.ToDecimal(Unit_Price.ToString("##,###.##"));
                            //decimal xx = Sum_Netweight * Convert.ToDecimal(System.Math.Floor(Unit_Price));
                            //dtg_CalPay.Rows[i].Cells[11].Value = xx.ToString("##,###.##");
                            dtg_CalPay.Rows[i].Cells[11].Value = Sum_NetPrice.ToString("##,###.##");

                            dtg_CalPay.Rows[i].Cells[4].Value = Sum_Netweight.ToString("##,###.##");
                            dtg_CalPay.Rows[i].Cells[5].Value = Unit_Price.ToString("F");
                            dtg_CalPay.Rows[i].Cells[6].Value = Sum_Price.ToString("##,###.##");
                            dtg_CalPay.Rows[i].Cells[7].Value = PriceService_weight.ToString("##,###.##");
                            dtg_CalPay.Rows[i].Cells[8].Value = PriceService_Load.ToString("##,###.##");                                          

                            double yy = Convert.ToDouble(dtg_CalPay.Rows[i].Cells[11].Value.ToString());
                            double vv = Convert.ToDouble(Math.Ceiling(yy)) - Convert.ToDouble(yy);

                            if (vv > 0.50)  //คำนวน น้ำหนักหัก เกินหรือเท่ากับ 0.50 ปัดขึ้น
                            {
                                dtg_CalPay.Rows[i].Cells[9].Value = Math.Floor(yy).ToString("##,###");
                            }
                            ///Floor
                            else
                            {
                                dtg_CalPay.Rows[i].Cells[9].Value = Math.Ceiling(yy).ToString("##,###");
                            }
                                                       
                            dtg_CalPay.Rows[i].Cells[12].Value =Sum_Store.ToString("##,###");

                            //this.dtg_CalPay.Columns[0].DefaultCellStyle.BackColor = Color.LightGreen;
                            this.dtg_CalPay.Columns[4].DefaultCellStyle.BackColor = Color.LightCyan;
                            this.dtg_CalPay.Columns[5].DefaultCellStyle.BackColor = Color.LightCyan;
                            this.dtg_CalPay.Columns[6].DefaultCellStyle.BackColor = Color.LightCyan;
                            this.dtg_CalPay.Columns[7].DefaultCellStyle.BackColor = Color.LightSalmon;
                            this.dtg_CalPay.Columns[8].DefaultCellStyle.BackColor = Color.LightSalmon;
                            this.dtg_CalPay.Columns[9].DefaultCellStyle.BackColor = Color.LightGreen;

                            if (dtg_CalPay.Rows[i].Cells[5].Value.ToString() == "")
                            { this.dtg_CalPay.Rows[i].Cells[5].Style.BackColor = Color.Red; }

                            if (dtg_CalPay.Rows[i].Cells[6].Value.ToString() == "")
                            { this.dtg_CalPay.Rows[i].Cells[6].Style.BackColor = Color.Red; }

                            if (dtg_CalPay.Rows[i].Cells[7].Value.ToString() == "")
                            { dtg_CalPay.Rows[i].Cells[7].Value = "0"; }

                            if (dtg_CalPay.Rows[i].Cells[8].Value.ToString() == "")
                            { dtg_CalPay.Rows[i].Cells[8].Value = "0"; }


                            if (this.dtg_CalPay.Rows[i].Cells[9].Value.ToString() == "")
                            { this.dtg_CalPay.Rows[i].Cells[9].Style.BackColor = Color.Red; }

                            if (this.dtg_CalPay.Rows[i].Cells[5].Value.ToString() != "" && this.dtg_CalPay.Rows[i].Cells[6].Value.ToString() != "" && this.dtg_CalPay.Rows[i].Cells[9].Value.ToString() != "") { dtg_CalPay.Rows[i].Cells[0].Value = "True"; }

                            if (dtg_CalPay.Rows[i].Cells[0].Value.ToString() == "True")

                            { this.dtg_CalPay.Rows[i].Cells[0].Style.BackColor = Color.LightGreen; }
                            else {

                                this.dtg_CalPay.Rows[i].Cells[0].Style.BackColor = Color.Red;
                                this.dtg_CalPay.Rows[i].Cells[0].ReadOnly = true;
                            }

                            dtg_CalPay.Columns[0].Width = 80;
                            dtg_CalPay.Columns[1].Width = 100;
                            dtg_CalPay.Columns[2].Width = 250;
                            dtg_CalPay.Columns[3].Width = 100;
                            dtg_CalPay.Columns[7].Width = 100;
                            dtg_CalPay.Columns[8].Width = 100;

                        }
                        catch { dtg_CalPay.Rows[i].Cells[5].Value = "-"; dtg_CalPay.Rows[i].Cells[7].Value = "0"; dtg_CalPay.Rows[i].Cells[8].Value = "0"; this.dtg_CalPay.Rows[i].Cells[0].ReadOnly = true; this.dtg_CalPay.Rows[i].Cells[0].Style.BackColor = Color.Red; }

                    }

                }


            }

            //dtg_CalPay.Columns[0].Width = 120;
        }

        //private void import_weight()
        //{
        //    try
        //    {                

        //        DataTable dt = new DataTable();

        //        for (int i = 0; i < 37; i++)
        //        {
        //            dt.Columns.Add(i.ToString(), typeof(string));
        //        }

        //        dtg_weight.DataSource = dt;


        //            string[] lines = File.ReadAllLines(txt_pathTextFileweight.Text, Encoding.Default);
        //            string[] values;


        //            for (int i = 0; i < lines.Length; i++)
        //            {
        //                values = lines[i].ToString().Split('^');
        //                string[] row = new string[values.Length];

        //                for (int j = 0; j < values.Length; j++)
        //                {
        //                    row[j] = values[j].Trim();
        //                }
        //                dt.Rows.Add(row);
        //            }

        //            tool_totalweight.Text = "Total Weight:" + dtg_weight.RowCount.ToString() + "Items";
        //    }
        //    catch (Exception err)
        //    {
        //        //Display any errors in a Message Box.
        //        System.Windows.Forms.MessageBox.Show("Error+ err.Message", err.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}

        //private void import_payment()
        //{           
        //    try
        //    {
        //        DataTable dt = new DataTable();

        //        for (int i = 0; i < 30; i++)
        //        {
        //            dt.Columns.Add(i.ToString(), typeof(string));
        //        }

        //        dtg_payment.DataSource = dt;


        //        string[] lines = File.ReadAllLines(txt_pathTextFilepayment.Text, Encoding.Default);
        //        string[] values;


        //        for (int i = 0; i < lines.Length; i++)
        //        {
        //            values = lines[i].ToString().Split('^');
        //            string[] row = new string[values.Length];

        //            for (int j = 0; j < values.Length; j++)
        //            {
        //                row[j] = values[j].Trim();
        //            }
        //            dt.Rows.Add(row);
        //        }

        //        tool_totalpay.Text = "Total Payment:" + dtg_payment.RowCount.ToString() + "Items";
        //    }
        //    catch (Exception err)
        //    {
        //        //Display any errors in a Message Box.
        //        System.Windows.Forms.MessageBox.Show("Error+ err.Message", err.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}

        //private void Cal_weight()
        //{

        //    DataGridViewColumn colHold = new DataGridViewTextBoxColumn();
        //    colHold.Name = "รหัสชั่ง";
        //    colHold.Name = "วันที่ชั่ง";
        //    colHold.Name = "รหัสสินค้า";
        //    colHold.Name = "รหัสคิว";
        //    colHold.Name = "รหัสผู้ขาย";
        //    colHold.Name = "ชื่อผู้ขาย";
        //    colHold.Name = "ทะเบียน";
        //    colHold.Name = "น้ำหนัก";
        //    colHold.Name = "ค่าชั่งสินค้า";
        //    colHold.Name = "ค่าลงสินค้า";

        //    //dtg_calweight.Columns.Add(colHold);

        //    //dtg_calweight.ColumnCount = 10;    
        //    //dtg_calweight.Columns[0].Name = "รหัสชั่ง";
        //    //dtg_calweight.Columns[1].Name = "วันที่ชั่ง";
        //    //dtg_calweight.Columns[2].Name = "รหัสสินค้า";
        //    //dtg_calweight.Columns[3].Name = "รหัสคิว";
        //    //dtg_calweight.Columns[4].Name = "รหัสผู้ขาย";
        //    //dtg_calweight.Columns[5].Name = "ชื่อผู้ขาย";
        //    //dtg_calweight.Columns[6].Name = "ทะเบียน";
        //    //dtg_calweight.Columns[7].Name = "น้ำหนัก";
        //    //dtg_calweight.Columns[8].Name = "ค่าชั่งสินค้า";   
        //    //dtg_calweight.Columns[9].Name = "ค่าลงสินค้า";

        //    //this.dtg_calweight.Columns[8].DefaultCellStyle.BackColor = Color.Wheat;
        //    //this.dtg_calweight.Columns[9].DefaultCellStyle.BackColor = Color.DeepSkyBlue;

        //    //else
        //    //{ dtg_calweight.Columns[8].Name = "ค่าลงสินค้า"; }

        //    service_total = 0;
        //    load_total = 0;


        //    for (int i = 0; i < dtg_weight.RowCount; i++)
        //    {
        //        //Convert from data Double date "4.35610000000000E+0004"
        //        string b = dtg_weight.Rows[i].Cells[15].Value.ToString();
        //        double d = double.Parse(b);
        //        // Get the converted date from the OLE automation date.
        //        DateTime conv = DateTime.FromOADate(d);
        //        int Service_truck = 0;  //ค่าบริการชั่ง
        //        int Service_load = 0;  // ค่าบริการลงสินค้า

        //        //           
        //        //2.ดั้มลงเอง(เครดิต)->หักจากระบบนาวิชั่น

        //        //4.ยกดั้มให้(เครดิต)->หักจากระบบนาวิชั่น


        //        if (cb_product.SelectedIndex == 1)
        //        {
        //            int weight = Convert.ToInt32(dtg_weight.Rows[i].Cells[34].Value.ToString());

        //            if (dtg_weight.Rows[i].Cells[30].Value.ToString().Trim() == "ดั้มลงเอง (เครดิต)")
        //            {
        //                if (weight < 15000)
        //                { Service_truck = 50; }
        //                else { Service_truck = 100; }
        //            }

        //            if (dtg_weight.Rows[i].Cells[30].Value.ToString().Trim() == "ยกดั้มให้ (เครดิต)")
        //            {
        //                if (weight < 15000)
        //                { Service_truck = 50; Service_load = 100; }
        //                else { Service_truck = 100; Service_load = 200; }
        //            }



        //        }

        //        else
        //        {


        //        }



        //    }
        //}

        //private void Cal_payment()
        //{
        //    //dtg_calpayment.Columns.Clear();
        //    //dtg_calpayment.Rows.Clear();

        //    DataGridViewColumn colHold = new DataGridViewTextBoxColumn();

        //    colHold.Name = "รหัสผู้ขาย";
        //    colHold.Name = "เลขที่เอกสาร";
        //    colHold.Name = "วันที่ซื้อ";
        //    colHold.Name = "รหัสสินค้า";
        //    colHold.Name = "น.น.สุทธิ";
        //    colHold.Name = "น.น.หัก";
        //    colHold.Name = "น.น.คงเหลือ";
        //    colHold.Name = "หักค่าชั่ง";
        //    colHold.Name = "หักค่าลง";
        //    colHold.Name = "รวมเงินจ่าย";

        //    dtg_calpayment.Columns.Add(colHold);

        //    dtg_calpayment.ColumnCount = 10;

        //    dtg_calpayment.Columns[0].Name = "รหัสผู้ขาย";
        //    dtg_calpayment.Columns[1].Name = "เลขที่เอกสาร";
        //    dtg_calpayment.Columns[2].Name = "วันที่ซื้อ";
        //    dtg_calpayment.Columns[3].Name = "รหัสสินค้า";
        //    dtg_calpayment.Columns[4].Name = "น.น.สุทธิ";
        //    dtg_calpayment.Columns[5].Name = "น.น.หัก";
        //    dtg_calpayment.Columns[6].Name = "น.น.คงเหลือ";
        //    dtg_calpayment.Columns[7].Name = "ค่าบริการชั่ง";
        //    dtg_calpayment.Columns[8].Name = "ค่าลงสินค้า";
        //    dtg_calpayment.Columns[9].Name = "รวมเงินจ่าย";

        //    this.dtg_calpayment.Columns[7].DefaultCellStyle.BackColor = Color.Wheat;
        //    this.dtg_calpayment.Columns[8].DefaultCellStyle.BackColor = Color.DeepSkyBlue;


        //}

        private void Cal_NAV()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            dtg_calNav.DataSource = null;
            dtg_calNav.Rows.Clear();
            dtg_calNav.Columns.Clear();

            DataGridViewColumn colHold = new DataGridViewTextBoxColumn();

            colHold.Name = "Document_No";
            colHold.Name = "Vendor_Truck";
            colHold.Name = "Vendor_No";
            colHold.Name = "Vendor_Name";
            colHold.Name = "Line_No";
            colHold.Name = "Item_No";
            colHold.Name = "Locat_Code";
            colHold.Name = "Quantity";
            colHold.Name = "Unit";
            colHold.Name = "Total";
            colHold.Name = "Revenue";
            colHold.Name = "Vocuher_Des";
            colHold.Name = "Doc_Date";
            colHold.Name = "DueDate";
            colHold.Name = "Customer_No";
            colHold.Name = "Sales_Amount";
            colHold.Name = "Sales_VAT_Amount";
            colHold.Name = "Service_Total";
            colHold.Name = "Load_Total";
            colHold.Name = "To_Store";

            dtg_calNav.Columns.Add(colHold);
            dtg_calNav.ColumnCount = 20;

            dtg_calNav.Columns[0].Name = "Document_No";
            dtg_calNav.Columns[1].Name = "Ven_NoTruck";
            dtg_calNav.Columns[2].Name = "Ven_NoNAV";
            dtg_calNav.Columns[3].Name = "Ven_Name";
            dtg_calNav.Columns[4].Name = "Line_No";
            dtg_calNav.Columns[5].Name = "Item_No";
            dtg_calNav.Columns[6].Name = "Locat_Code";
            dtg_calNav.Columns[7].Name = "Quantity";
            dtg_calNav.Columns[8].Name = "Unit";
            dtg_calNav.Columns[9].Name = "Net_Total";
            dtg_calNav.Columns[10].Name = "Revenue";
            dtg_calNav.Columns[11].Name = "Voucher_Des";
            dtg_calNav.Columns[12].Name = "Doc_Date";
            dtg_calNav.Columns[13].Name = "DueDate";
            dtg_calNav.Columns[14].Name = "Customer_No";
            dtg_calNav.Columns[15].Name = "Sales_Amount";
            dtg_calNav.Columns[16].Name = "Sales_VAT_Amount";
            dtg_calNav.Columns[17].Name = "Service_Total";
            dtg_calNav.Columns[18].Name = "Load_Total";
            dtg_calNav.Columns[19].Name = "To_Store";

            //DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            //checkBoxColumn.HeaderText = "Edit";
            //checkBoxColumn.Width = 60;
            //checkBoxColumn.Name = "Edit";
            //dtg_calNav.Columns.Insert(13, checkBoxColumn);


            for (int i = 0; i < dtg_CalPay.RowCount; i++)
            {
                double price = 0;  //ราคาจ่าย
                double weighttotal = 0;   //นน. รวม
                //double dicount = 0;  //หัก           
                double unit_price = 0;
                //string net_svchange = "0";
                DateTime dt_runNo = Convert.ToDateTime(dtg_CalPay.Rows[i].Cells[10].Value.ToString());

                int Round_Pay = 0;
                string Payment_No = "";

                con.Open();
                string sql1 = "Select Count([Vendor_No]) AS 'C_Items' FROM [dbo].[TB_Payment] Where [PayDate]='"+ dt_runNo.ToString("yyyy-MM-dd") + "' AND Vendor_No='"+ dtg_CalPay.Rows[i].Cells[1].Value.ToString().Trim() + "' ";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                DR1.Read();
                {
                    Round_Pay = Convert.ToInt16(DR1["C_Items"].ToString());
                }
                DR1.Close();
                con.Close();

                Round_Pay++;

                //SPYYMMDD-AP02-0064-1
                //"SP" + Payment_No + "-" + dtg_CalPay.Rows[i].Cells[1].Value.ToString()
                Payment_No = "SP" + dt_runNo.ToString("yy") + dt_runNo.Month.ToString() + dt_runNo.Day.ToString("00") + "-" + dtg_CalPay.Rows[i].Cells[1].Value.ToString() + "-" + Round_Pay.ToString();
                                
                               
                //MessageBox.Show(dtg_CalPay.Rows[i].Cells[0].Value.ToString());
                try
                {
                    if (dtg_CalPay.Rows[i].Cells[0].Value.ToString() == "True")
                    {
                        string Voucher_Des = "";
                        if (dtg_CalPay.Rows[i].Cells[4].Value.ToString().Trim() != "")
                        {
                            Voucher_Des = "ซื้อ" + cb_product.Text + " " + dtg_CalPay.Rows[i].Cells[12].Value.ToString().Trim() + " กก.";
                        }


                        if (dtg_CalPay.Rows[i].Cells[6].Value.ToString() != "") { price = Convert.ToDouble(dtg_CalPay.Rows[i].Cells[6].Value.ToString()); }
                        if (dtg_CalPay.Rows[i].Cells[4].Value.ToString() != "") { weighttotal = Convert.ToDouble(dtg_CalPay.Rows[i].Cells[4].Value.ToString()); }
                        //net_svchange = dtg_calpayment.Rows[i].Cells[10].Value.ToString();
                        unit_price = price / weighttotal;


                        //cale Vat 06/04/2021
                        decimal price_w = 0;   //(WeightPrice * 100) / (100 + 7);
                        decimal price_l = 0;  //(LoadPrice * 100) / (100 + 7);
                        decimal w =Convert.ToDecimal(dtg_CalPay.Rows[i].Cells[7].Value.ToString());
                        decimal l = Convert.ToDecimal(dtg_CalPay.Rows[i].Cells[8].Value.ToString());                       
                        decimal total_service = 0;
                        decimal total_vat = 0;
                        decimal sale_amount = 0;
                        decimal Store = Convert.ToDecimal(dtg_CalPay.Rows[i].Cells[12].Value.ToString());

                        price_w = (w / 100) * (100 + 7);
                        price_l = (l / 100) * (100 + 7);
                        sale_amount = w + l;
                        total_service = price_w + price_l;
                        total_vat = total_service - (w + l);

                        //decimal xxx= (WeightPrice * 100) / (100 + 7);
                        //System.Math.Round(gross_weight).ToString("##,###.##");

                        string[] row = new string[] { Payment_No , dtg_CalPay.Rows[i].Cells[1].Value.ToString(), "", "", "10000", cb_product.SelectedValue.ToString(), "FAC-002", dtg_CalPay.Rows[i].Cells[4].Value.ToString(), unit_price.ToString("F"), dtg_CalPay.Rows[i].Cells[6].Value.ToString(),"0", Voucher_Des, dtg_CalPay.Rows[i].Cells[10].Value.ToString(), dtg_CalPay.Rows[i].Cells[10].Value.ToString(),"",sale_amount.ToString("F"), total_vat.ToString("F"), System.Math.Floor(price_w).ToString("F"), System.Math.Floor(price_l).ToString("F"), System.Math.Floor(Store).ToString("F") };
                        dtg_calNav.Rows.Add(row);
                    }
                }
                catch { }

            }

            this.dtg_calNav.Columns[1].DefaultCellStyle.BackColor = Color.Khaki;
            this.dtg_calNav.Columns[2].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[4].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[5].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[6].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[7].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[8].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[9].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[10].DefaultCellStyle.BackColor = Color.LightPink;
            this.dtg_calNav.Columns[11].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[12].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[13].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[14].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[15].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[16].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[19].DefaultCellStyle.BackColor = Color.LightGreen;
            //this.dtg_calNav.Columns[14].DefaultCellStyle.BackColor = Color.OrangeRed;

            dtg_calNav.Columns[0].Width = 180;
            //dtg_calNav.Columns[3].Width = 200;
            dtg_calNav.Columns[4].Width = 80;
            dtg_calNav.Columns[5].Width = 80;
            dtg_calNav.Columns[8].Width = 70;
            dtg_calNav.Columns[9].Width = 100;
            dtg_calNav.Columns[10].Width = 70;
            dtg_calNav.Columns[11].Width = 150;
            dtg_calNav.Columns[12].Width = 100;
            dtg_calNav.Columns[13].Width = 100;

            ststool_totalweight.Text = "Totlal: " + dtg_calNav.RowCount.ToString() + " Items";

            dtg_calNav.ClearSelection();
        }

        private void Cal_NAV_Import()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            dtg_calNav.DataSource = null;
            dtg_calNav.Rows.Clear();
            dtg_calNav.Columns.Clear();

            DataGridViewColumn colHold = new DataGridViewTextBoxColumn();

            colHold.Name = "Document_No";
            colHold.Name = "Vendor_Truck";
            colHold.Name = "Vendor_No";
            colHold.Name = "Vendor_Name";
            colHold.Name = "Line_No";
            colHold.Name = "Item_No";
            colHold.Name = "Locat_Code";
            colHold.Name = "Quantity";
            colHold.Name = "Unit";
            colHold.Name = "Total";
            colHold.Name = "Revenue";
            colHold.Name = "Vocuher_Des";
            colHold.Name = "Doc_Date";
            colHold.Name = "DueDate";
            colHold.Name = "Customer_No";
            colHold.Name = "Sales_Amount";
            colHold.Name = "Sales_VAT_Amount";
            colHold.Name = "Service_Total";
            colHold.Name = "Load_Total";
            colHold.Name = "To_Store";

            dtg_calNav.Columns.Add(colHold);
            dtg_calNav.ColumnCount = 20;

            dtg_calNav.Columns[0].Name = "Document_No";
            dtg_calNav.Columns[1].Name = "Ven_NoTruck";
            dtg_calNav.Columns[2].Name = "Ven_NoNAV";
            dtg_calNav.Columns[3].Name = "Ven_Name";
            dtg_calNav.Columns[4].Name = "Line_No";
            dtg_calNav.Columns[5].Name = "Item_No";
            dtg_calNav.Columns[6].Name = "Locat_Code";
            dtg_calNav.Columns[7].Name = "Quantity";
            dtg_calNav.Columns[8].Name = "Unit";
            dtg_calNav.Columns[9].Name = "Net_Total";
            dtg_calNav.Columns[10].Name = "Revenue";
            dtg_calNav.Columns[11].Name = "Voucher_Des";
            dtg_calNav.Columns[12].Name = "Doc_Date";
            dtg_calNav.Columns[13].Name = "DueDate";
            dtg_calNav.Columns[14].Name = "Customer_No";
            dtg_calNav.Columns[15].Name = "Sales_Amount";
            dtg_calNav.Columns[16].Name = "Sales_VAT_Amount";
            dtg_calNav.Columns[17].Name = "Service_Total";
            dtg_calNav.Columns[18].Name = "Load_Total";
            dtg_calNav.Columns[19].Name = "To_Store";

            //DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            //checkBoxColumn.HeaderText = "Edit";
            //checkBoxColumn.Width = 60;
            //checkBoxColumn.Name = "Edit";
            //dtg_calNav.Columns.Insert(13, checkBoxColumn);


            for (int i = 0; i < dtg_importFile.RowCount; i++)
            {
                double price = 0;  //ราคาจ่าย
                double weighttotal = 0;   //นน. รวม
                //double dicount = 0;  //หัก           
                double unit_price = 0;
                //string net_svchange = "0";
                DateTime dt_runNo = Convert.ToDateTime(dtg_importFile.Rows[i].Cells[0].Value.ToString());

                int Round_Pay = 0;
                string Payment_No = "";

                con.Open();
                string sql1 = "Select Count([Vendor_No]) AS 'C_Items' FROM [dbo].[TB_Payment] Where [PayDate]='" + dt_runNo.ToString("yyyy-MM-dd") + "' AND Vendor_No='" + dtg_importFile.Rows[i].Cells[3].Value.ToString().Trim() + "' ";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                DR1.Read();
                {
                    Round_Pay = Convert.ToInt16(DR1["C_Items"].ToString());
                }
                DR1.Close();
                con.Close();

                Round_Pay++;

                //SPYYMMDD-AP02-0064-1
                //"SP" + Payment_No + "-" + dtg_CalPay.Rows[i].Cells[1].Value.ToString()
                Payment_No = "SP" + dt_runNo.ToString("yy") + dt_runNo.Month.ToString() + dt_runNo.Day.ToString("00") + "-" + dtg_importFile.Rows[i].Cells[3].Value.ToString() + "-" + Round_Pay.ToString();


                //MessageBox.Show(dtg_CalPay.Rows[i].Cells[0].Value.ToString());
                try
                {
                    //if (dtg_importFile.Rows[i].Cells[0].Value.ToString() == "True")
                    //{
                        string Voucher_Des = "";
                        if (dtg_importFile.Rows[i].Cells[4].Value.ToString().Trim() != "")
                        {
                            Voucher_Des = "ซื้อ" + cb_product.Text + " " + dtg_importFile.Rows[i].Cells[10].Value.ToString().Trim() + " กก.";
                        }


                        if (dtg_importFile.Rows[i].Cells[11].Value.ToString() != "") { price = Convert.ToDouble(dtg_importFile.Rows[i].Cells[11].Value.ToString()); }
                        if (dtg_importFile.Rows[i].Cells[10].Value.ToString() != "") { weighttotal = Convert.ToDouble(dtg_importFile.Rows[i].Cells[10].Value.ToString()); }
                        //net_svchange = dtg_calpayment.Rows[i].Cells[10].Value.ToString();
                        unit_price = price / weighttotal;


                        //cale Vat 06/04/2021
                        decimal price_w = 0;   //(WeightPrice * 100) / (100 + 7);
                        decimal price_l = 0;  //(LoadPrice * 100) / (100 + 7);
                        decimal w = 0;  // Convert.ToDecimal(dtg_importFile.Rows[i].Cells[7].Value.ToString()); //ค่าชั่ง
                        decimal l = 0;// Convert.ToDecimal(dtg_importFile.Rows[i].Cells[8].Value.ToString());  //ค่าลง
                        decimal total_service = 0;
                        decimal total_vat = 0;
                        decimal sale_amount = 0;
                        decimal Store = Convert.ToDecimal(dtg_importFile.Rows[i].Cells[7].Value.ToString());

                        price_w = (w / 100) * (100 + 7);
                        price_l = (l / 100) * (100 + 7);
                        sale_amount = w + l;
                        total_service = price_w + price_l;
                        total_vat = total_service - (w + l);

                        //decimal xxx= (WeightPrice * 100) / (100 + 7);
                        //System.Math.Round(gross_weight).ToString("##,###.##");

                        string[] row = new string[] { Payment_No, dtg_importFile.Rows[i].Cells[3].Value.ToString(), "", "", "10000", cb_product.SelectedValue.ToString(), "FAC-002", dtg_importFile.Rows[i].Cells[7].Value.ToString(), unit_price.ToString("F"), dtg_importFile.Rows[i].Cells[11].Value.ToString(), "0", Voucher_Des, dtg_importFile.Rows[i].Cells[0].Value.ToString(), dtg_importFile.Rows[i].Cells[0].Value.ToString(), "", sale_amount.ToString("F"), total_vat.ToString("F"), System.Math.Floor(price_w).ToString("F"), System.Math.Floor(price_l).ToString("F"), System.Math.Floor(Store).ToString("F") };
                        dtg_calNav.Rows.Add(row);
                    //}
                }
                catch { }

            }

            this.dtg_calNav.Columns[1].DefaultCellStyle.BackColor = Color.Khaki;
            this.dtg_calNav.Columns[2].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[4].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[5].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[6].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[7].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[8].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[9].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[10].DefaultCellStyle.BackColor = Color.LightPink;
            this.dtg_calNav.Columns[11].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[12].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[13].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[14].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[15].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[16].DefaultCellStyle.BackColor = Color.LightGreen;
            this.dtg_calNav.Columns[19].DefaultCellStyle.BackColor = Color.LightGreen;
            //this.dtg_calNav.Columns[14].DefaultCellStyle.BackColor = Color.OrangeRed;

            dtg_calNav.Columns[0].Width = 180;
            //dtg_calNav.Columns[3].Width = 200;
            dtg_calNav.Columns[4].Width = 80;
            dtg_calNav.Columns[5].Width = 80;
            dtg_calNav.Columns[8].Width = 70;
            dtg_calNav.Columns[9].Width = 100;
            dtg_calNav.Columns[10].Width = 70;
            dtg_calNav.Columns[11].Width = 150;
            dtg_calNav.Columns[12].Width = 100;
            dtg_calNav.Columns[13].Width = 100;

            ststool_totalweight.Text = "Totlal: " + dtg_calNav.RowCount.ToString() + " Items";

            dtg_calNav.ClearSelection();
        }

        private void cb_product_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Refresh_Data();
        }

        private void Refresh_Data()
        {
            if (cb_product.SelectedIndex == 0)  // มันเส้น
            {
                lbl_productName.BackColor = Color.LightYellow;
                Load_DATA_ConfirmPayment();
                lbl_productName.Text = cb_product.SelectedValue.ToString();
                btn_calculator.Enabled = true;

                Clear_DTG();   //เคลียร์ขอมูลเก่าทิ้ง
                Load_Cal_Payment1();     //เรียนข้อมูลค้างจ่าย
                Load_Cal_Payment2(); //คำนวนหน้ำหนัก
                Load_Cal_Payment3();   //รวมรายการรับซื้อ
                           
            }
            else if (cb_product.SelectedIndex == 1)   //มันสด
            {
                lbl_productName.BackColor = Color.LightGreen;
                Load_DATA_ConfirmPayment();
                lbl_productName.Text = cb_product.SelectedValue.ToString();
                btn_calculator.Enabled = true;

                Clear_DTG();   //เคลียร์ขอมูลเก่าทิ้ง
                Load_Cal_Payment1();     //เรียนข้อมูลค้างจ่าย

                Load_Cal_Payment2(); //คำนวนหน้ำหนัก
                Load_Cal_Payment3();   //รวมรายการรับซื้อ
                               
            }

            tabControl2.SelectedIndex = 0;
            tabControl1.SelectedIndex = 1;
        }
            
        private void Load_Vendor()
        {

            SqlConnection con = new SqlConnection(Program.pathdb14_NAV);
            con.ConnectionString = Program.pathdb14_NAV;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            //con.Open();

            string Vendor_name = "";

            for (int i = 0; i < dtg_calNav.RowCount; i++)
            {
                try
                {

                    Vendor_name = dtg_calNav.Rows[i].Cells[1].Value.ToString().Trim();

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    con.Open();

                    string sql1 = "Select [No_],[Name]  FROM [Sapthip_LIVE].[dbo].[Sapthip LIVE$Vendor]  Where [No_] ='" + Vendor_name + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, con);
                    SqlDataReader DR1 = CM1.ExecuteReader();
                    DR1.Read();
                    {
                        if (DR1["No_"].ToString() != "")
                        {
                            dtg_calNav.Rows[i].Cells[2].Value = DR1["No_"].ToString();
                            dtg_calNav.Rows[i].Cells[3].Value = DR1["Name"].ToString();
                        }

                    }
                    DR1.Close();
                    con.Close();
                }
                catch
                {

                    //  MessageBox.Show("ไม่มีข้อมุลรหัสผู้ขายนี้ " + Vendor_name + " ในระบบนาวิชั่นกรุณาตรวจสอบ!!", "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    dtg_calNav.Rows[i].Cells[2].Style.BackColor = Color.Red;
                    dtg_calNav.Rows[i].Cells[2].Value = "#VALUE!";
                    con.Close();
                }

            }

            //rdr.Close();
           

        }


        private void Load_MAP_Customer()
        {

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            //con.Open();

            string Vendor_name = "";

            for (int i = 0; i < dtg_calNav.RowCount; i++)
            {
                try
                {

                    Vendor_name = dtg_calNav.Rows[i].Cells[1].Value.ToString().Trim();

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    con.Open();

                    string sql1 = "Select [Customer_No]  FROM  [dbo].[Ven_Map_Cus]  Where [Vendor_No] ='" + dtg_calNav.Rows[i].Cells[2].Value.ToString().Trim() + "' AND [Product_ID] ='" + dtg_calNav.Rows[i].Cells[5].Value.ToString() + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, con);
                    SqlDataReader DR1 = CM1.ExecuteReader();
                    DR1.Read();
                    {
                        dtg_calNav.Rows[i].Cells[14].Value = DR1["Customer_No"].ToString().Trim();
                    }
                    DR1.Close();
                    con.Close();
                    //if (DR1["Customer_No"].ToString() == "")
                    //{
                    //    dtg_calNav.Rows[i].Cells[14].Value = "";
                    //}

                }
                catch
                {

                    //  MessageBox.Show("ไม่มีข้อมุลรหัสผู้ขายนี้ " + Vendor_name + " ในระบบนาวิชั่นกรุณาตรวจสอบ!!", "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    dtg_calNav.Rows[i].Cells[14].Style.BackColor = Color.Red;
                    dtg_calNav.Rows[i].Cells[14].Value = "";
                    dtg_calNav.Rows[i].Cells[15].Value = "0";
                    dtg_calNav.Rows[i].Cells[16].Value = "0";
                    dtg_calNav.Rows[i].Cells[17].Value = "0";
                    dtg_calNav.Rows[i].Cells[18].Value = "0";
                    con.Close();
                }
            }
        }

        private void Load_Summary()
        {
            double sum_weight = 0;
            double sum_charge = 0;
            double sum_price = 0;
            for (int i = 0; i < dtg_calNav.RowCount; i++)
            {
                if (dtg_calNav.Rows[i].Cells[7].Value.ToString() != "")
                {
                    sum_weight += Convert.ToDouble(dtg_calNav.Rows[i].Cells[7].Value.ToString());
                }

                if (dtg_calNav.Rows[i].Cells[10].Value.ToString() != "")
                {
                    sum_charge += Convert.ToDouble(dtg_calNav.Rows[i].Cells[10].Value.ToString());
                }

                if (dtg_calNav.Rows[i].Cells[9].Value.ToString() != "")
                {
                    sum_price += Convert.ToDouble(dtg_calNav.Rows[i].Cells[9].Value.ToString());
                }
            }
        }


        private void btn_savetoTempNav_Click(object sender, EventArgs e)
        {
            DialogResult answer;
            answer = MessageBox.Show("กรุณายืนยันการส่งข้อมูลไปยังระบบนาวิชั่น!! ", "ยืนยันมการส่งข้อมูล", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (answer == DialogResult.OK)
            {
                backgroundWorker1.RunWorkerAsync();
                Save_toNAV();               
                           
                MessageBox.Show("บันทึกข้อมูลไปยังนาวิชั่น! บันทึก:" + save_success + " รายการ, ปรับปรุง:" + edit_success + " รายการ, ไม่สำเร็จ: " + save_unsuccess + " รายการ", "ผลการบันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tool_lblprogress.Text = "";
                tool_ProgressBar.Value = 0;


                save_success = 0;
                save_unsuccess = 0;
                edit_success = 0;

                dtg_CalPay.DataSource = null;
                dtg_calpayment.DataSource = null;
                dtg_calNav.DataSource = null;
                dtg_calNav.Rows.Clear();
                dtg_calNav.Columns.Clear();
                dtg_weight.DataSource = null;
                lbl_productName.Text = "<-เลือกสินค้าที่ต้องการทำรายการ";
                cb_product.SelectedIndex = -1;

                tabControl1.SelectedIndex = 0;
                tabControl4.SelectedIndex = 0;
            }

        }

        int save_unsuccess = 0;
        int save_success = 0;
        int edit_success = 0;
        string Doc_check = "";
        int id_dup = 0;
        int Process_id = 0;

        //private void Save_Simulator()
        //{
        //    //conect SQL 14, DB 2215
        //    SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
        //    con1.ConnectionString = Program.pathdb_Weight;
        //    SqlDataAdapter dtAdapter1 = new SqlDataAdapter();
        //    //con1.Open();

        //    //conect SQL 14, DB 2215
        //    SqlConnection con4 = new SqlConnection(Program.pathdb_Weight);
        //    con4.ConnectionString = Program.pathdb_Weight;
        //    SqlDataAdapter dtAdapter4 = new SqlDataAdapter();
        //    con4.Open();

        //    DateTime doc_date = new DateTime();

        //    string date = Program.Date_Now + ' ' + DateTime.Now.ToString("HH:mm:ss.sss", CultureInfo.CreateSpecificCulture("en-US"));
        

        //    for (int i = 0; i < dtg_calNav.RowCount; i++)
        //    {
        //        doc_date = Convert.ToDateTime(dtg_calNav.Rows[i].Cells[12].Value.ToString().Trim());

        //        //update store
        //        double Qty = Convert.ToDouble(dtg_calNav.Rows[i].Cells[7].Value.ToString().Trim());
        //        double Store = Convert.ToDouble(dtg_calNav.Rows[i].Cells[19].Value.ToString().Trim());
        //        double Unit_Amount = Convert.ToDouble(dtg_calNav.Rows[i].Cells[8].Value.ToString().Trim());
        //        double Price_Total = Convert.ToDouble(dtg_calNav.Rows[i].Cells[9].Value.ToString().Trim());
        //        double Service_Change = Convert.ToDouble(dtg_calNav.Rows[i].Cells[10].Value.ToString().Trim());
                                
        //        Doc_check = dtg_calNav.Rows[i].Cells[0].Value.ToString().Trim();
             

        //        if (id_dup != 1 && dtg_calNav.Rows[i].Cells[1].Value.ToString().Trim() != "#VALUE!")
        //        {      

        //            if (con1.State == ConnectionState.Open)
        //            {
        //                con1.Close();
        //            }
        //            con1.Open();

        //            string sql1 = "INSERT INTO [dbo].[TB_Payment_Simulator] ([PayDocNo],[PayDate],[Vendor_No],[ProductID],[Qty_Net],[Unit_Net],[Price_Net],[Rev_net],[SaveDate],[Customer_No],[Sales_Amount],[Sales_VAT_Amount],[Remark],[Qty_Store]) VALUES('" + dtg_calNav.Rows[i].Cells[0].Value.ToString() + "','" + doc_date.ToString("yyyy-MM-dd 00:00:00.000", CultureInfo.CreateSpecificCulture("en-US")) + "','" + dtg_calNav.Rows[i].Cells[2].Value.ToString().Trim() + "','" + dtg_calNav.Rows[i].Cells[5].Value.ToString().Trim() + "'," + Qty.ToString("F") + "," + Unit_Amount + "," + Price_Total.ToString("F") + "," + Service_Change + ",'" + date + "','" + dtg_calNav.Rows[i].Cells[14].Value.ToString().Trim() + "'," + dtg_calNav.Rows[i].Cells[15].Value.ToString().Trim() + "," + dtg_calNav.Rows[i].Cells[16].Value.ToString().Trim() + ",'บันทึกสำเร็จ'," + Store.ToString("F") + ")";


        //            SqlCommand CM1 = new SqlCommand(sql1, con1);
        //            SqlDataReader DR1 = CM1.ExecuteReader();
        //            con1.Close();

        //            int PaymentID = 0;
        //            //Select Max id paymentdetail
        //            con1.Open();
        //            string sql6 = "SELECT MAX([PaymentID]) AS PaymentID FROM [dbo].[TB_Payment_Simulator] ";
        //            SqlCommand CM6 = new SqlCommand(sql6, con1);
        //            SqlDataReader DR6 = CM6.ExecuteReader();
        //            DR6.Read();
        //            {
        //                PaymentID = Convert.ToInt32(DR6["PaymentID"].ToString());
        //            }
        //            DR6.Close();
        //            con1.Close();

        //            //update Weight                       
        //            for (int r = 0; r < dtg_calpayment.RowCount; r++)
        //            {
        //                if (con1.State == ConnectionState.Open)
        //                {
        //                    con1.Close();
        //                }

                   
        //                //con2.Open();
        //                //string sql4 = "Update  [dbo].[TB_PaymentDetail] SET [StatusActive]=0 WHERE  [TicketCodeIn]='" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "'";
        //                //SqlCommand CM4 = new SqlCommand(sql4, con2);
        //                //SqlDataReader DR4 = CM4.ExecuteReader();
        //                //con2.Close();

        //                int IDPaymentDetail = 0;

        //                if (dtg_calNav.Rows[i].Cells[2].Value.ToString().Trim() == dtg_calpayment.Rows[r].Cells[4].Value.ToString() && dtg_calNav.Rows[i].Cells[12].Value.ToString().Trim() == dtg_calpayment.Rows[r].Cells[1].Value.ToString())
        //                {
        //                    //
        //                    decimal Weigh_Net = Convert.ToDecimal(dtg_calpayment.Rows[r].Cells[8].Value.ToString().Trim());
        //                    decimal Weight_Pay = Convert.ToDecimal(dtg_calpayment.Rows[r].Cells[11].Value.ToString().Trim());
        //                    decimal Service_Weight = Convert.ToDecimal(dtg_calpayment.Rows[r].Cells[14].Value.ToString().Trim());// ค่าชั่ง
        //                    decimal Service_Load = Convert.ToDecimal(dtg_calpayment.Rows[r].Cells[15].Value.ToString().Trim());   //ค่าลงสินค้า
        //                    decimal Service_Changes = Convert.ToDecimal(dtg_calpayment.Rows[r].Cells[16].Value.ToString().Trim());  // รวมค่าชั่ง + ค่าลงสินค้า
        //                    decimal PricePayment = Convert.ToDecimal(dtg_calpayment.Rows[r].Cells[17].Value.ToString().Trim());

        //                    con1.Open();
        //                    string sql5 = "INSERT INTO [dbo].[TB_PaymentDetail_Simulator]([TicketCodeIn],[VendorGroup],[VisualWH],[VisualSP],[Weigh_Net],[Weight_Pay],[PriceStarch],[ValueStarch],[ServiceChange],[PricePayment],[StatusActive],[PayDocID],[Weight_Price],[Load_Price]) VALUES('" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "','" + dtg_calpayment.Rows[r].Cells[6].Value.ToString().Trim() + "'," + dtg_calpayment.Rows[r].Cells[9].Value.ToString().Trim() + "," + dtg_calpayment.Rows[r].Cells[10].Value.ToString().Trim() + "," + Weigh_Net + "," + Weight_Pay + "," + dtg_calpayment.Rows[r].Cells[13].Value.ToString().Trim() + "," + dtg_calpayment.Rows[r].Cells[12].Value.ToString().Trim() + "," + Service_Changes.ToString("F") + "," + PricePayment + ",1," + PaymentID + "," + Service_Weight.ToString("F") + "," + Service_Load.ToString("F") + ")";
        //                    SqlCommand CM5 = new SqlCommand(sql5, con1);
        //                    SqlDataReader DR5 = CM5.ExecuteReader();
        //                    con1.Close();

                            
        //                    //Select Max id paymentdetail
        //                    con1.Open();
        //                    string sql10 = "SELECT MAX([PayDetailNo]) AS IDPaymentDetail FROM [dbo].[TB_PaymentDetail_Simulator] ";
        //                    SqlCommand CM10 = new SqlCommand(sql10, con1);
        //                    SqlDataReader DR10 = CM10.ExecuteReader();
        //                    DR10.Read();
        //                    {
        //                        IDPaymentDetail = Convert.ToInt32(DR10["IDPaymentDetail"].ToString());
        //                    }
        //                    DR10.Close();
        //                    con1.Close();


        //                    // insert visual value detail
        //                    //Select Loop

        //                    //SELECT dbo.TB_VisualLog.TicketCodeIn, dbo.TB_VISUALTYPE.VisualType, dbo.TB_VisualLog.ValueVisual    FROM     dbo.TB_VisualLog INNER JOIN    dbo.TB_VISUALTYPE ON dbo.TB_VisualLog.VisualType = dbo.TB_VISUALTYPE.VisualType  WHERE [TicketCodeIn] ='631103-0008'


        //                    int LabID = 0;
        //                    decimal LabValue = 0;
        //                    //int LabtypeID = 0;
        //                    string VendorGroupID = "";

        //                    if (con1.State == ConnectionState.Open)
        //                    {
        //                        con1.Close();
        //                    }

        //                    con1.Open();

        //                    string sql7 = "SELECT[TicketCodeIn] ,(Select Top 1([LabID]) From[dbo].[V_CalPayment_Lab] Where[dbo].[V_CalPayment_Lab].[ProductID] = '" + dtg_calpayment.Rows[r].Cells[2].Value.ToString().Trim() + "' AND Trim([dbo].[V_CalPayment_Lab].[LabName])= Trim([dbo].[V_VisualLog].LabName))	 AS 'LabID_SP',[LabName],[LabValue] ,(Select Top 1([StatusSP]) From[dbo].[V_CalPayment_Lab] Where[dbo].[V_CalPayment_Lab].[ProductID] = '" + dtg_calpayment.Rows[r].Cells[2].Value.ToString().Trim() + "' AND[dbo].[V_CalPayment_Lab].[StatusSP] = 1  AND Trim([dbo].[V_CalPayment_Lab].[LabName])=Trim([dbo].[V_VisualLog].LabName))	 AS 'Status_SP',(SELECT  Top 1([VendorGroupID])  FROM [dbo].[V_CalPayment_VenGroup]  WHERE  Vendor_No = (Select [Vendor_No] From [dbo].[TB_WeightData]  WHERE [dbo].[TB_WeightData].TicketCodeIn ='" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "') AND [dbo].[V_CalPayment_VenGroup].[ProductID] =  '" + dtg_calpayment.Rows[r].Cells[2].Value.ToString().Trim() + "' AND [dbo].[V_CalPayment_VenGroup].[StsActive]=1 ) AS 'Vendor_Group'	From[dbo].[V_VisualLog] WHERE [TicketCodeIn] ='" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "'";


        //                    SqlCommand CM7 = new SqlCommand(sql7, con1);
        //                    SqlDataReader DR7 = CM7.ExecuteReader();
        //                    while (DR7.Read())
        //                    {
        //                        //(DR1["No_"].ToString() != "")

        //                        try
        //                        {
        //                            if (DR7["Status_SP"].ToString().Trim() == "True")
        //                            {
        //                                LabID = Convert.ToInt16(DR7["LabID_SP"].ToString());
        //                                LabValue = Convert.ToDecimal(DR7["LabValue"].ToString());
        //                                VendorGroupID = DR7["Vendor_Group"].ToString();
        //                                decimal value_min = 0;
        //                                decimal value_max = 0;

        //                                string sql11 = "Select Top(1)[ValueSP] From [dbo].[V_CalPayment_Lab] Where [MinSP] <= " + LabValue + " AND [VendorGroupID]='" + VendorGroupID + "' AND [ProductID]='" + dtg_calpayment.Rows[e_rowIndex].Cells[2].Value.ToString().Trim() + "' AND [LabID]=" + LabID + " Order by [MinSP] desc ";

        //                                string sql12 = "Select Top(1)[ValueSP] From [dbo].[V_CalPayment_Lab] Where [MaxSP] >= " + LabValue + " AND [VendorGroupID]='" + VendorGroupID + "' AND [ProductID]='" + dtg_calpayment.Rows[e_rowIndex].Cells[2].Value.ToString().Trim() + "'  AND [LabID]=" + LabID + " Order by [MaxSP] ";

        //                                try
        //                                {
        //                                    if (con4.State == ConnectionState.Open)
        //                                    {
        //                                        con4.Close();
        //                                    }
        //                                    con4.Open();

        //                                    SqlCommand CM11 = new SqlCommand(sql11, con4);
        //                                    SqlDataReader DR11 = CM11.ExecuteReader();
        //                                    DR11.Read();
        //                                    {
        //                                        value_min = Convert.ToDecimal(DR11["ValueSP"].ToString());
        //                                    }
        //                                    DR11.Close();
        //                                    con4.Close();
        //                                }
        //                                catch { value_min = 0; con4.Close(); }

        //                                try
        //                                {
        //                                    con4.Open();
        //                                    SqlCommand CM12 = new SqlCommand(sql12, con4);
        //                                    SqlDataReader DR12 = CM12.ExecuteReader();
        //                                    DR12.Read();
        //                                    {
        //                                        value_max = Convert.ToDecimal(DR12["ValueSP"].ToString());
        //                                    }
        //                                    DR12.Close();
        //                                    con4.Close();
        //                                }
        //                                catch { value_max = 0; con4.Close(); }

        //                                decimal value_save = 0;

        //                                if
        //                                    (value_min == value_max)
        //                                { value_save = value_min; }
        //                                else
        //                                { value_save = value_max; }


        //                                //Optional_Status = 1;
        //                                //Optional_Value = Convert.ToDecimal(DR1["OptionalVisual"].ToString());

        //                                con4.Open();
        //                                string sql13 = "INSERT INTO [dbo].[TB_PaymentLabDetail_Simulator]([PayDetailNo],[LabID],[Value],[Status_Active]) VALUES(" + IDPaymentDetail + "," + LabID + "," + value_save + ",1)";
        //                                SqlCommand CM13 = new SqlCommand(sql13, con4);
        //                                SqlDataReader DR13 = CM13.ExecuteReader();
        //                                con4.Close();
        //                            }

        //                        }

        //                        catch { }
        //                    }
        //                    con1.Close();

        //                    con1.Open();

        //                    string sql8 = "SELECT[TicketCodeIn] ,(Select Top 1([LabID]) From[dbo].[V_CalPayment_Visual] Where[dbo].[V_CalPayment_Visual].[ProductID] = '" + dtg_calpayment.Rows[r].Cells[2].Value.ToString().Trim() + "' AND Trim([dbo].[V_CalPayment_Visual].[LabName])= Trim([dbo].[V_VisualLog].LabName))	 AS 'LabID_SP',[LabName],[LabValue] ,(Select Top 1([StatusSP]) From[dbo].[V_CalPayment_Visual] Where[dbo].[V_CalPayment_Visual].[ProductID] = '" + dtg_calpayment.Rows[r].Cells[2].Value.ToString().Trim() + "' AND[dbo].[V_CalPayment_Visual].[StatusSP] = 1 AND Trim([dbo].[V_CalPayment_Visual].[LabName])=Trim([dbo].[V_VisualLog].LabName))	 AS 'Status_SP',(SELECT  Top 1([VendorGroupID])  FROM [dbo].[V_CalPayment_VenGroup]  WHERE  Vendor_No = (Select [Vendor_No] From [dbo].[TB_WeightData]  WHERE [dbo].[TB_WeightData].TicketCodeIn ='" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "') AND [dbo].[V_CalPayment_VenGroup].[ProductID] =  '" + dtg_calpayment.Rows[r].Cells[2].Value.ToString().Trim() + "' AND [dbo].[V_CalPayment_VenGroup].[StsActive]=1) AS 'Vendor_Group'	From[dbo].[V_VisualLog] WHERE[TicketCodeIn] ='" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "'";

        //                    SqlCommand CM8 = new SqlCommand(sql8, con1);
        //                    SqlDataReader DR8 = CM8.ExecuteReader();
        //                    while (DR8.Read())
        //                    {
        //                        try
        //                        {
        //                            if (DR8["Status_SP"].ToString().Trim() == "True")
        //                            {
        //                                LabID = Convert.ToInt16(DR8["LabID_SP"].ToString());
        //                                LabValue = Convert.ToDecimal(DR8["LabValue"].ToString());
        //                                VendorGroupID = DR8["Vendor_Group"].ToString();

        //                                decimal Value_visual = 0;
        //                                con4.Open();
        //                                string sql40 = "SELECT Top(1) [ValueSP] FROM [dbo].[V_CalPayment_Visual] WHere [LabID]='" + LabID + "' AND [ValueWH] >=" + LabValue + " AND [VendorGroupID]='" + VendorGroupID + "' AND [StatusSP]=1 Order by [ValueWH]";


        //                                SqlCommand CM40 = new SqlCommand(sql40, con4);
        //                                SqlDataReader DR40 = CM40.ExecuteReader();
        //                                DR40.Read();
        //                                {
        //                                    Value_visual = Convert.ToDecimal(DR40["ValueSP"].ToString());
        //                                }
        //                                DR40.Close();
        //                                con4.Close();

        //                                con4.Open();
        //                                string sql9 = "INSERT INTO [dbo].[TB_PaymentVisualeDetail_Simulator]([PayDetailNo],[LabID],[Value],[Status_Active]) VALUES(" + IDPaymentDetail + "," + LabID + "," + Value_visual + ",1)";
        //                                SqlCommand CM9 = new SqlCommand(sql9, con4);
        //                                SqlDataReader DR9 = CM9.ExecuteReader();
        //                                con4.Close();
        //                            }
        //                        }
        //                        catch { }
        //                    }

        //                    DR7.Close();
        //                }

        //            }

        //            Class_Log CL = new Class_Log();
        //            CL.tbname = "Simulator on payment!";
        //            CL.oldvalue = "-";
        //            CL.newvalue = dtg_payHistory.Rows[i].Cells[2].Value.ToString();
        //            CL.Save_log();

        //        }


        //        ////module Update Function
        //        else if (id_dup == 1)

        //        {                    

        //            if (con4.State == ConnectionState.Open)
        //            {
        //                con4.Close();
        //            }
        //            con4.Open();

        //            string sql3 = "INSERT INTO [dbo].[TB_Payment_Simulator]([PayDocNo],[PayDate],[Vendor_No],[ProductID],[Qty_Net],[Unit_Net],[Price_Net],[Rev_net],[SaveDate],[Customer_No],[Sales_Amount],[Sales_VAT_Amount],[Remark]) VALUES('" + dtg_calNav.Rows[i].Cells[0].Value.ToString() + "','" + doc_date.ToString("yyyy-MM-dd 00:00:00.000", CultureInfo.CreateSpecificCulture("en-US")) + "','" + dtg_calNav.Rows[i].Cells[2].Value.ToString().Trim() + "','" + dtg_calNav.Rows[i].Cells[5].Value.ToString().Trim() + "'," + Qty.ToString("F") + "," + Unit_Amount + "," + Price_Total.ToString("F") + "," + Service_Change + ",'" + date + "','" + dtg_calNav.Rows[i].Cells[14].Value.ToString().Trim() + "'," + dtg_calNav.Rows[i].Cells[15].Value.ToString().Trim() + "," + dtg_calNav.Rows[i].Cells[16].Value.ToString().Trim() + ",'บันทึกสำเร็จ')";

        //            SqlCommand CM3 = new SqlCommand(sql3, con4);
        //            SqlDataReader DR3 = CM3.ExecuteReader();
        //            con4.Close();


        //            int PaymentID = 0;
        //            //Select Max id paymentdetail
        //            con4.Open();
        //            string sql6 = "SELECT MAX([PaymentID]) AS PaymentID FROM  [dbo].[TB_Payment] ";
        //            SqlCommand CM6 = new SqlCommand(sql6, con4);
        //            SqlDataReader DR6 = CM6.ExecuteReader();
        //            DR6.Read();
        //            {
        //                PaymentID = Convert.ToInt32(DR6["PaymentID"].ToString());
        //            }
        //            DR6.Close();
        //            con4.Close();

        //            //update Weight                       
        //            for (int r = 0; r < dtg_calpayment.RowCount; r++)
        //            {
        //                if (con4.State == ConnectionState.Open)
        //                {
        //                    con4.Close();
        //                }

        //                if (dtg_calpayment.Rows[r].Cells[1].Value.ToString().Trim() == dtg_calNav.Rows[i].Cells[12].Value.ToString().Trim() && dtg_calpayment.Rows[r].Cells[4].Value.ToString().Trim() == dtg_calNav.Rows[i].Cells[1].Value.ToString().Trim())
        //                {                     
        //                    decimal Weigh_Net = Convert.ToDecimal(dtg_calpayment.Rows[r].Cells[8].Value.ToString().Trim());
        //                    decimal Weight_Pay = Convert.ToDecimal(dtg_calpayment.Rows[r].Cells[11].Value.ToString().Trim());
        //                    decimal Service_Weight = Convert.ToDecimal(dtg_calpayment.Rows[r].Cells[15].Value.ToString().Trim());
        //                    decimal Service_Load = Convert.ToDecimal(dtg_calpayment.Rows[r].Cells[16].Value.ToString().Trim());
        //                    decimal PricePayment = Convert.ToDecimal(dtg_calpayment.Rows[r].Cells[17].Value.ToString().Trim());
        //                    int IDPaymentDetail = 0;

        //                    con4.Open();

        //                    string sql5 = "INSERT INTO  [dbo].[TB_PaymentDetail_Simulator]([TicketCodeIn],[VendorGroup],[VisualWH],[VisualSP],[Weigh_Net],[Weight_Pay],[PriceStarch],[ValueStarch],[ServiceChange],[PricePayment],[StatusActive],[PayDocID],[Weight_Price],[Load_Price]) VALUES('" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "','" + dtg_calpayment.Rows[r].Cells[6].Value.ToString().Trim() + "'," + dtg_calpayment.Rows[r].Cells[9].Value.ToString().Trim() + "," + dtg_calpayment.Rows[r].Cells[10].Value.ToString().Trim() + "," + Weigh_Net + "," + Weight_Pay + "," + dtg_calpayment.Rows[r].Cells[13].Value.ToString().Trim() + "," + dtg_calpayment.Rows[r].Cells[12].Value.ToString().Trim() + "," + dtg_calpayment.Rows[r].Cells[14].Value.ToString().Trim() + "," + PricePayment + ",1," + PaymentID + "," + Service_Weight.ToString("F") + "," + Service_Load.ToString("F") + ")";
        //                    SqlCommand CM5 = new SqlCommand(sql5, con4);
        //                    SqlDataReader DR5 = CM5.ExecuteReader();
        //                    con4.Close();

        //                    if (con1.State == ConnectionState.Open)
        //                    {
        //                        con1.Close();
        //                    }

        //                    con1.Open();
        //                    string sql10 = "SELECT MAX([PayDetailNo]) AS IDPaymentDetail FROM [dbo].[TB_PaymentDetail] ";
        //                    SqlCommand CM10 = new SqlCommand(sql10, con1);
        //                    SqlDataReader DR10 = CM10.ExecuteReader();
        //                    DR10.Read();
        //                    {
        //                        IDPaymentDetail = Convert.ToInt32(DR10["IDPaymentDetail"].ToString());
        //                    }
        //                    DR10.Close();
        //                    con1.Close();

        //                    int LabID = 0;
        //                    decimal LabValue = 0;
        //                    //int LabtypeID = 0;
        //                    string VendorGroupID = "";

        //                    if (con1.State == ConnectionState.Open)
        //                    {
        //                        con1.Close();
        //                    }

        //                    con1.Open();
        //                    string sql7 = "SELECT[TicketCodeIn] ,(Select Top 1([LabID]) From[dbo].[V_CalPayment_Lab] Where[dbo].[V_CalPayment_Lab].[ProductID] = '" + dtg_calpayment.Rows[r].Cells[2].Value.ToString().Trim() + "' AND Trim([dbo].[V_CalPayment_Lab].[LabName])= Trim([dbo].[V_VisualLog].LabName))	 AS 'LabID_SP',[LabName],[LabValue] ,(Select Top 1([StatusSP]) From[dbo].[V_CalPayment_Lab] Where[dbo].[V_CalPayment_Lab].[ProductID] = '" + dtg_calpayment.Rows[r].Cells[2].Value.ToString().Trim() + "' AND[dbo].[V_CalPayment_Lab].[StatusSP] = 1  AND Trim([dbo].[V_CalPayment_Lab].[LabName])=Trim([dbo].[V_VisualLog].LabName))	 AS 'Status_SP',(SELECT  Top 1([VendorGroupID])  FROM [dbo].[V_CalPayment_VenGroup]  WHERE  Vendor_No = (Select [Vendor_No] From [dbo].[TB_WeightData]  WHERE [dbo].[TB_WeightData].TicketCodeIn ='" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "') AND [dbo].[V_CalPayment_VenGroup].[ProductID] =  '" + dtg_calpayment.Rows[r].Cells[2].Value.ToString().Trim() + "' AND [dbo].[V_CalPayment_VenGroup].[StsActive]=1 ) AS 'Vendor_Group'	From[dbo].[V_VisualLog] WHERE [TicketCodeIn] ='" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "'";


        //                    SqlCommand CM7 = new SqlCommand(sql7, con1);
        //                    SqlDataReader DR7 = CM7.ExecuteReader();
        //                    while (DR7.Read())
        //                    {
        //                        //(DR1["No_"].ToString() != "")

        //                        try
        //                        {
        //                            if (DR7["Status_SP"].ToString().Trim() == "True")
        //                            {
        //                                LabID = Convert.ToInt16(DR7["LabID_SP"].ToString());
        //                                LabValue = Convert.ToDecimal(DR7["LabValue"].ToString());
        //                                VendorGroupID = DR7["Vendor_Group"].ToString();
        //                                decimal value_min = 0;
        //                                decimal value_max = 0;

        //                                string sql11 = "Select Top(1)[ValueSP] From [dbo].[V_CalPayment_Lab] Where [MinSP] <= " + LabValue + " AND [VendorGroupID]='" + VendorGroupID + "' AND [ProductID]='" + dtg_calNav.Rows[i].Cells[5].Value.ToString().Trim() + "' AND [LabID]=" + LabID + " Order by [MinSP] desc ";

        //                                string sql12 = "Select Top(1)[ValueSP] From [dbo].[V_CalPayment_Lab] Where [MaxSP] >= " + LabValue + " AND [VendorGroupID]='" + VendorGroupID + "' AND [ProductID]='" + dtg_calNav.Rows[i].Cells[5].Value.ToString().Trim() + "'  AND [LabID]=" + LabID + " Order by [MaxSP] ";

        //                                try
        //                                {
        //                                    con4.Open();
        //                                    SqlCommand CM11 = new SqlCommand(sql11, con4);
        //                                    SqlDataReader DR11 = CM11.ExecuteReader();
        //                                    DR11.Read();
        //                                    {
        //                                        value_min = Convert.ToDecimal(DR11["ValueSP"].ToString());
        //                                    }
        //                                    DR11.Close();
        //                                    con4.Close();
        //                                }
        //                                catch { value_min = 0; con4.Close(); }

        //                                try
        //                                {
        //                                    con4.Open();
        //                                    SqlCommand CM12 = new SqlCommand(sql12, con4);
        //                                    SqlDataReader DR12 = CM12.ExecuteReader();
        //                                    DR12.Read();
        //                                    {
        //                                        value_max = Convert.ToDecimal(DR12["ValueSP"].ToString());
        //                                    }
        //                                    DR12.Close();
        //                                    con4.Close();
        //                                }
        //                                catch { value_max = 0; con4.Close(); }


        //                                decimal value_save = 0;

        //                                if
        //                                    (value_min == value_max)
        //                                { value_save = value_min; }
        //                                else
        //                                { value_save = value_max; }

        //                                con4.Open();
        //                                string sql13 = "INSERT INTO [dbo].[TB_PaymentLabDetail_Simulator]([PayDetailNo],[LabID],[Value],[Status_Active]) VALUES(" + IDPaymentDetail + "," + LabID + "," + value_save + ",1)";
        //                                SqlCommand CM13 = new SqlCommand(sql13, con4);
        //                                SqlDataReader DR13 = CM13.ExecuteReader();
        //                                con4.Close();
        //                            }

        //                        }

        //                        catch { }
        //                    }
        //                    con1.Close();

        //                    con1.Open();
        //                    string sql8 = "SELECT[TicketCodeIn] ,(Select Top 1([LabID]) From[dbo].[V_CalPayment_Visual] Where[dbo].[V_CalPayment_Visual].[ProductID] = '" + dtg_calpayment.Rows[r].Cells[2].Value.ToString().Trim() + "' AND Trim([dbo].[V_CalPayment_Visual].[LabName])= Trim([dbo].[V_VisualLog].LabName))	 AS 'LabID_SP',[LabName],[LabValue] ,(Select Top 1([StatusSP]) From[dbo].[V_CalPayment_Visual] Where[dbo].[V_CalPayment_Visual].[ProductID] = '" + dtg_calpayment.Rows[r].Cells[2].Value.ToString().Trim() + "' AND[dbo].[V_CalPayment_Visual].[StatusSP] = 1 AND Trim([dbo].[V_CalPayment_Visual].[LabName])=Trim([dbo].[V_VisualLog].LabName))	 AS 'Status_SP',(SELECT  Top 1([VendorGroupID])  FROM [dbo].[V_CalPayment_VenGroup]  WHERE  Vendor_No = (Select [Vendor_No] From [dbo].[TB_WeightData]  WHERE [dbo].[TB_WeightData].TicketCodeIn ='" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "') AND [dbo].[V_CalPayment_VenGroup].[ProductID] =  '" + dtg_calpayment.Rows[r].Cells[2].Value.ToString().Trim() + "' AND [dbo].[V_CalPayment_VenGroup].[StsActive]=1) AS 'Vendor_Group'	From[dbo].[V_VisualLog] WHERE[TicketCodeIn] ='" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "'";

        //                    SqlCommand CM8 = new SqlCommand(sql8, con1);
        //                    SqlDataReader DR8 = CM8.ExecuteReader();
        //                    while (DR8.Read())
        //                    {
        //                        try
        //                        {
        //                            if (DR8["Status_SP"].ToString().Trim() == "True")
        //                            {
        //                                LabID = Convert.ToInt16(DR8["LabID_SP"].ToString());
        //                                LabValue = Convert.ToDecimal(DR8["LabValue"].ToString());
        //                                VendorGroupID = DR8["Vendor_Group"].ToString();

        //                                decimal Value_visual = 0;
        //                                con4.Open();
        //                                string sql40 = "SELECT Top(1) [ValueSP] FROM [dbo].[V_CalPayment_Visual] WHere [LabID]='" + LabID + "' AND [ValueWH] >=" + LabValue + " AND [VendorGroupID]='" + VendorGroupID + "' AND [StatusSP]=1 Order by [ValueWH]";
        //                                SqlCommand CM40 = new SqlCommand(sql40, con4);
        //                                SqlDataReader DR40 = CM40.ExecuteReader();
        //                                DR40.Read();
        //                                {
        //                                    Value_visual = Convert.ToDecimal(DR40["ValueSP"].ToString());
        //                                }
        //                                DR40.Close();
        //                                con4.Close();

        //                                con4.Open();
        //                                string sql9 = "INSERT INTO [dbo].[TB_PaymentVisualeDetail_Simulator]([PayDetailNo],[LabID],[Value],[Status_Active]) VALUES(" + IDPaymentDetail + "," + LabID + "," + Value_visual + ",1)";
        //                                SqlCommand CM9 = new SqlCommand(sql9, con4);
        //                                SqlDataReader DR9 = CM9.ExecuteReader();
        //                                con4.Close();
        //                            }
        //                        }
        //                        catch { con4.Close(); }
        //                    }

        //                    DR7.Close();
                           
        //                }


        //            }
        //        }


        //        else
        //        { //dtg rows color }

        //            //MessageBox.Show(dtg_calNav.Rows[i].Cells[14].Value.ToString());
        //            dtg_calNav.Rows[i].Cells[3].Style.BackColor = Color.Red; id_dup = 0; save_unsuccess += 1;
        //        }

        //    }


        //    //rdr.Close();
        //    con1.Close();


        //    //V_PaymentReport
        //    //V_Payment_Recived_R004
        //    //V_CostSP_RM004


        //}

        private void Save_toNAV()
        {          
            //conect SQL 14, DB 2215
            SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
            con1.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter1 = new SqlDataAdapter();
            //con1.Open();

            // Connect SQL 14, DB Sapthip_UAT_221119
            SqlConnection con2 = new SqlConnection(Program.pathdb14_NAV);
            con2.ConnectionString = Program.pathdb14_NAV;
            SqlDataAdapter dtAdapter2 = new SqlDataAdapter();
            con2.Open();

            // Connect SQL 225, SapthipNewDB 
            SqlConnection con3 = new SqlConnection(Program.pathdb14_TruckScale);
            con3.ConnectionString = Program.pathdb14_TruckScale;
            SqlDataAdapter dtAdapter3 = new SqlDataAdapter();

            //conect SQL 14, DB 2215
            SqlConnection con4 = new SqlConnection(Program.pathdb_Weight);
            con4.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter4 = new SqlDataAdapter();
            con4.Open();

            DateTime doc_date = new DateTime();

            string date = Program.Date_Now + ' ' + DateTime.Now.ToString("HH:mm:ss.sss", CultureInfo.CreateSpecificCulture("en-US"));

            id_checkprocess = 1;

            Check_ProcessID();
            Process_id++;

            for (int i = 0; i < dtg_calNav.RowCount; i++)
            {
                doc_date = Convert.ToDateTime(dtg_calNav.Rows[i].Cells[12].Value.ToString().Trim());

                //update store
                double Qty = Convert.ToDouble(dtg_calNav.Rows[i].Cells[7].Value.ToString().Trim());
                double Store = Convert.ToDouble(dtg_calNav.Rows[i].Cells[19].Value.ToString().Trim());
                double Unit_Amount = Convert.ToDouble(dtg_calNav.Rows[i].Cells[8].Value.ToString().Trim());
                double Price_Total = Convert.ToDouble(dtg_calNav.Rows[i].Cells[9].Value.ToString().Trim());
                double Service_Change = Convert.ToDouble(dtg_calNav.Rows[i].Cells[10].Value.ToString().Trim());

                if (con3.State == ConnectionState.Open)
                {
                    con3.Close();
                }
                con3.Open();

                if (con2.State == ConnectionState.Open)
                {
                    con2.Close();
                }
                con2.Open();


                Doc_check = dtg_calNav.Rows[i].Cells[0].Value.ToString().Trim();
                Check_DuplicateDoc();


                if (id_dup != 1 && dtg_calNav.Rows[i].Cells[2].Value.ToString().Trim() != "#VALUE!")
                {

                    //test 17.12.2021--------------------

                    string Voucher_Des_Sale = "";
                    if (dtg_calNav.Rows[i].Cells[15].Value.ToString().Trim() != "0")
                    {
                        Voucher_Des_Sale = "ค่าชั่งรถ" + cb_product.Text + " " + doc_date.ToString("dd/MM/yyyy ", CultureInfo.CreateSpecificCulture("en-US"));
                    }

                    string sql = "INSERT INTO [dbo].[Purchase_Invoice]([Document_No],[Line_No],[Vendor_No],[Type],[Item_No],[Location_Code],[Quantity],[Unit_Amount],[Total_Amount],[Document_Date],[Car_Registration_No],[DueDate],[UserID],[Interfaced],[Sent_DateTime],[Count],[Revenue_Incl_VAT],[Voucher_Description],[Interface Remark],[Customer_No],[Sales_Amount],[Sales_VAT_Amount],[Sales_Voucher_Description]) VALUES('" + dtg_calNav.Rows[i].Cells[0].Value.ToString().Trim() + "'," + dtg_calNav.Rows[i].Cells[4].Value.ToString().Trim() + ",'" + dtg_calNav.Rows[i].Cells[2].Value.ToString().Trim() + "',0,'" + dtg_calNav.Rows[i].Cells[5].Value.ToString().Trim() + "','" + dtg_calNav.Rows[i].Cells[6].Value.ToString().Trim() + "'," + Store.ToString("F") + "," + Unit_Amount + "," + Price_Total.ToString("F") + ",'" + doc_date.ToString("yyyy-MM-dd 00:00:00.000", CultureInfo.CreateSpecificCulture("en-US")) + "','-',' " + doc_date.ToString("yyyy-MM-dd 00:00:00.000", CultureInfo.CreateSpecificCulture("en-US")) + "','" + Program.user_name + "',0,'" + DateTime.Now.ToString("yyyy-MM-dd 00:00:00.000", CultureInfo.CreateSpecificCulture("en-US")) + "',1," + Service_Change + ",'" + dtg_calNav.Rows[i].Cells[11].Value.ToString().Trim() + "','New Transection','" + dtg_calNav.Rows[i].Cells[14].Value.ToString().Trim() + "'," + dtg_calNav.Rows[i].Cells[15].Value.ToString().Trim() + "," + dtg_calNav.Rows[i].Cells[16].Value.ToString().Trim() + ",'" + Voucher_Des_Sale + "')";


                    SqlCommand CM2 = new SqlCommand(sql, con3);
                    SqlDataReader DR2 = CM2.ExecuteReader();

                    dtg_calNav.Rows[i].Cells[3].Style.BackColor = Color.Green;
                    save_success += 1;
                    con3.Close();

                    Class_Log CL = new Class_Log();
                    CL.tbname = "New record Purchase to Invoice!";
                    CL.oldvalue = "-";
                    CL.newvalue = dtg_calNav.Rows[i].Cells[0].Value.ToString().Trim();
                    CL.Save_log();

                    if (con1.State == ConnectionState.Open)
                    {
                        con1.Close();
                    }
                    con1.Open();


                    //test 17.12.2021--------------------

                    string sql1 = "INSERT INTO [dbo].[TB_Payment]([PayDocNo],[PayDate],[Vendor_No],[ProductID],[Qty_Net],[Unit_Net],[Price_Net],[Rev_net],[SaveDate],[Customer_No],[Sales_Amount],[Sales_VAT_Amount],[Remark],[Qty_Store]) VALUES('" + dtg_calNav.Rows[i].Cells[0].Value.ToString() + "','" + doc_date.ToString("yyyy-MM-dd 00:00:00.000", CultureInfo.CreateSpecificCulture("en-US")) + "','" + dtg_calNav.Rows[i].Cells[2].Value.ToString().Trim() + "','" + dtg_calNav.Rows[i].Cells[5].Value.ToString().Trim() + "'," + Qty.ToString("F") + "," + Unit_Amount + "," + Price_Total.ToString("F") + "," + Service_Change + ",'" + date + "','" + dtg_calNav.Rows[i].Cells[14].Value.ToString().Trim() + "'," + dtg_calNav.Rows[i].Cells[15].Value.ToString().Trim() + "," + dtg_calNav.Rows[i].Cells[16].Value.ToString().Trim() + ",'บันทึกสำเร็จ'," + Store.ToString("F") + ")";


                    SqlCommand CM1 = new SqlCommand(sql1, con1);
                    SqlDataReader DR1 = CM1.ExecuteReader();
                    con1.Close();

                    int PaymentID = 0;
                    //Select Max id paymentdetail
                    con1.Open();
                    string sql6 = "SELECT MAX([PaymentID]) AS PaymentID FROM [dbo].[TB_Payment] ";
                    SqlCommand CM6 = new SqlCommand(sql6, con1);
                    SqlDataReader DR6 = CM6.ExecuteReader();
                    DR6.Read();
                    {
                        PaymentID = Convert.ToInt32(DR6["PaymentID"].ToString());
                    }
                    DR6.Close();
                    con1.Close();

                    //update Weight                       
                    for (int r = 0; r < dtg_calpayment.RowCount; r++)
                    {
                        if (con1.State == ConnectionState.Open)
                        {
                            con1.Close();
                        }

                        if (dtg_calpayment.Rows[r].Cells[1].Value.ToString().Trim() == dtg_calNav.Rows[i].Cells[12].Value.ToString().Trim() && dtg_calpayment.Rows[r].Cells[4].Value.ToString().Trim() == dtg_calNav.Rows[i].Cells[1].Value.ToString().Trim())
                        {

                            string value_1 = dtg_calpayment.Rows[r].Cells[4].Value.ToString().Trim();
                            string value_2 = dtg_calNav.Rows[i].Cells[1].Value.ToString().Trim();

                            //test 17.12.2021--------------------

                            con1.Open();
                            string sql3 = "Update [dbo].[TB_WeightData] Set [Process_id]=" + Process_id + ",[Remark1]='" + dtg_calNav.Rows[i].Cells[0].Value.ToString().Trim() + "' Where [TicketCodeIn] = '" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "'";
                            SqlCommand CM3 = new SqlCommand(sql3, con1);
                            SqlDataReader DR3 = CM3.ExecuteReader();
                            con1.Close();                         
                        }

                        int IDPaymentDetail = 0;

                        if (dtg_calNav.Rows[i].Cells[2].Value.ToString().Trim() == dtg_calpayment.Rows[r].Cells[4].Value.ToString() && dtg_calNav.Rows[i].Cells[12].Value.ToString().Trim() == dtg_calpayment.Rows[r].Cells[1].Value.ToString())
                        {
                            //
                            decimal Weigh_Net = Convert.ToDecimal(dtg_calpayment.Rows[r].Cells[8].Value.ToString().Trim());
                            decimal Weight_Pay = Convert.ToDecimal(dtg_calpayment.Rows[r].Cells[11].Value.ToString().Trim());
                            decimal Service_Weight = Convert.ToDecimal(dtg_calpayment.Rows[r].Cells[14].Value.ToString().Trim());
                            decimal Service_Load = Convert.ToDecimal(dtg_calpayment.Rows[r].Cells[15].Value.ToString().Trim());
                            decimal PricePayment = Convert.ToDecimal(dtg_calpayment.Rows[r].Cells[17].Value.ToString().Trim());
                            int Status_SP = 0;
                            //test 17.12.2021--------------------
                            int C_Save = 0;

                            con1.Open();
                            string sql101 = "SELECT Count([TicketCodeIn]) AS 'C_Save' FROM [dbo].[TB_PaymentDetail] WHERE [TicketCodeIn] ='" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "'";
                            SqlCommand CM101 = new SqlCommand(sql101, con1);
                            SqlDataReader DR101 = CM101.ExecuteReader();
                            DR101.Read();
                            {
                                C_Save = Convert.ToInt16(DR101["C_Save"].ToString());
                            }
                            DR101.Close();
                            con1.Close();

                            if (C_Save == 0)
                            {
                                con1.Open();
                                string sql5 = "INSERT INTO [dbo].[TB_PaymentDetail]([TicketCodeIn],[VendorGroup],[VisualWH],[VisualSP],[Weigh_Net],[Weight_Pay],[PriceStarch],[ValueStarch],[ServiceChange],[PricePayment],[StatusActive],[PayDocID],[Weight_Price],[Load_Price]) VALUES('" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "','" + dtg_calpayment.Rows[r].Cells[6].Value.ToString().Trim() + "'," + dtg_calpayment.Rows[r].Cells[9].Value.ToString().Trim() + "," + dtg_calpayment.Rows[r].Cells[10].Value.ToString().Trim() + "," + Weigh_Net + "," + Weight_Pay + "," + dtg_calpayment.Rows[r].Cells[13].Value.ToString().Trim() + "," + dtg_calpayment.Rows[r].Cells[12].Value.ToString().Trim() + "," + dtg_calpayment.Rows[r].Cells[16].Value.ToString().Trim() + "," + PricePayment + ",1," + PaymentID + "," + Service_Weight.ToString("F") + "," + Service_Load.ToString("F") + ")";
                                SqlCommand CM5 = new SqlCommand(sql5, con1);
                                SqlDataReader DR5 = CM5.ExecuteReader();
                                con1.Close();

                                //Select Max id paymentdetail
                                con1.Open();
                                string sql10 = "SELECT MAX([PayDetailNo]) AS IDPaymentDetail FROM [dbo].[TB_PaymentDetail] ";
                                SqlCommand CM10 = new SqlCommand(sql10, con1);
                                SqlDataReader DR10 = CM10.ExecuteReader();
                                DR10.Read();
                                {
                                    IDPaymentDetail = Convert.ToInt32(DR10["IDPaymentDetail"].ToString());
                                }
                                DR10.Close();
                                con1.Close();

                            }

                            else
                            {
                                con1.Open();
                                string sql5 = "Update [dbo].[TB_PaymentDetail] SET [VendorGroup] ='" + dtg_calpayment.Rows[r].Cells[6].Value.ToString().Trim() + "',[VisualWH] =" + dtg_calpayment.Rows[r].Cells[9].Value.ToString().Trim() + ",[VisualSP] =" + dtg_calpayment.Rows[r].Cells[10].Value.ToString().Trim() + ",[Weigh_Net] = " + Weigh_Net + ",[Weight_Pay] = " + Weight_Pay + ",[PriceStarch] = " + dtg_calpayment.Rows[r].Cells[13].Value.ToString().Trim() + ",[ValueStarch] = " + dtg_calpayment.Rows[r].Cells[12].Value.ToString().Trim() + ",[ServiceChange] = " + dtg_calpayment.Rows[r].Cells[16].Value.ToString().Trim() + ",[PricePayment] = " + PricePayment + ",[StatusActive] = 1,[PayDocID] =" + PaymentID + ",[Weight_Price] =" + Service_Weight.ToString("F") + ",[Load_Price]= " + Service_Load.ToString("F") + "  WHERE [TicketCodeIn] ='" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "'";
                                SqlCommand CM5 = new SqlCommand(sql5, con1);
                                SqlDataReader DR5 = CM5.ExecuteReader();
                                con1.Close();


                                con1.Open();
                                string sql10 = "SELECT [PayDetailNo]  FROM [dbo].[TB_PaymentDetail] WHERE [TicketCodeIn] ='" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "'";
                                SqlCommand CM10 = new SqlCommand(sql10, con1);
                                SqlDataReader DR10 = CM10.ExecuteReader();
                                DR10.Read();
                                {
                                    IDPaymentDetail = Convert.ToInt32(DR10["PayDetailNo"].ToString());
                                }
                                DR10.Close();
                                con1.Close();
                            }
                                                       
                           

                            int LabID = 0;
                            decimal LabValue = 0;
                            //int LabtypeID = 0;
                            string VendorGroupID = "";

                            if (con1.State == ConnectionState.Open)
                            { con1.Close(); }

                            con1.Open();
                            //Save Payment Lab
                            string sql7 = "SELECT[TicketCodeIn] ,(Select Top 1([LabID]) From[dbo].[V_CalPayment_Lab] Where[dbo].[V_CalPayment_Lab].[ProductID] = '" + dtg_calpayment.Rows[r].Cells[2].Value.ToString().Trim() + "' AND Trim([dbo].[V_CalPayment_Lab].[LabName])= Trim([dbo].[V_VisualLog].LabName) AND VendorGroupID ='" + dtg_calpayment.Rows[e_rowIndex].Cells[6].Value.ToString().Trim() + "') AS 'LabID_SP',[LabName],[LabValue] ,(Select Top 1([StatusSP]) From[dbo].[V_CalPayment_Lab] Where[dbo].[V_CalPayment_Lab].[ProductID] = '" + dtg_calpayment.Rows[r].Cells[2].Value.ToString().Trim() + "' AND [dbo].[V_CalPayment_Lab].[StatusSP] = 1  AND Trim([dbo].[V_CalPayment_Lab].[LabName])=Trim([dbo].[V_VisualLog].LabName) AND VendorGroupID = '" + dtg_calpayment.Rows[e_rowIndex].Cells[6].Value.ToString().Trim() + "')	 AS 'Status_SP',(SELECT  Top 1([VendorGroupID])  FROM [dbo].[V_CalPayment_VenGroup]  WHERE  Vendor_No = (Select [Vendor_No] From [dbo].[TB_WeightData]  WHERE [dbo].[TB_WeightData].TicketCodeIn ='" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "') AND [dbo].[V_CalPayment_VenGroup].[ProductID] =  '" + dtg_calpayment.Rows[r].Cells[2].Value.ToString().Trim() + "' AND [dbo].[V_CalPayment_VenGroup].[StsActive]=1 ) AS 'Vendor_Group'	From[dbo].[V_VisualLog] WHERE [TicketCodeIn] ='" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "'";
                            
                            SqlCommand CM7 = new SqlCommand(sql7, con1);
                            SqlDataReader DR7 = CM7.ExecuteReader();
                            while (DR7.Read())
                            {
                                try
                                {
                                    if (DR7["Status_SP"].ToString().Trim() == "True")
                                    {
                                        LabID = Convert.ToInt16(DR7["LabID_SP"].ToString());
                                        LabValue = Convert.ToDecimal(DR7["LabValue"].ToString());
                                        VendorGroupID = DR7["Vendor_Group"].ToString();
                                        decimal value_min = 0;
                                        decimal value_max = 0;

                                        string sql11 = "Select Top(1)[ValueSP] From [dbo].[V_CalPayment_Lab] Where [MinSP] <= " + LabValue + " AND [VendorGroupID]='" + VendorGroupID + "' AND [ProductID]='" + dtg_calpayment.Rows[e_rowIndex].Cells[2].Value.ToString().Trim() + "' AND [LabID]=" + LabID + " Order by [MinSP] desc ";

                                        string sql12 = "Select Top(1)[ValueSP] From [dbo].[V_CalPayment_Lab] Where [MaxSP] >= " + LabValue + " AND [VendorGroupID]='" + VendorGroupID + "' AND [ProductID]='" + dtg_calpayment.Rows[e_rowIndex].Cells[2].Value.ToString().Trim() + "'  AND [LabID]=" + LabID + " Order by [MaxSP] ";

                                        try
                                        {
                                            if (con4.State == ConnectionState.Open)
                                            {
                                                con4.Close();
                                            }
                                            con4.Open();

                                            SqlCommand CM11 = new SqlCommand(sql11, con4);
                                            SqlDataReader DR11 = CM11.ExecuteReader();
                                            DR11.Read();
                                            {
                                                value_min = Convert.ToDecimal(DR11["ValueSP"].ToString());
                                            }
                                            DR11.Close();
                                            con4.Close();
                                        }
                                        catch { value_min = 0; con4.Close(); }

                                        try
                                        {
                                            con4.Open();
                                            SqlCommand CM12 = new SqlCommand(sql12, con4);
                                            SqlDataReader DR12 = CM12.ExecuteReader();
                                            DR12.Read();
                                            {
                                                value_max = Convert.ToDecimal(DR12["ValueSP"].ToString());
                                            }
                                            DR12.Close();
                                            con4.Close();
                                        }
                                        catch { value_max = 0; con4.Close(); }


                                        decimal value_save = 0;

                                        if
                                            (value_min == value_max)
                                        { value_save = value_min; }
                                        else
                                        { value_save = value_max; }

                                        //test 17.12.2021--------------------

                                        con4.Open();
                                        string sql13 = "INSERT INTO [dbo].[TB_PaymentLabDetail]([PayDetailNo],[LabID],[Value],[Status_Active]) VALUES(" + IDPaymentDetail + "," + LabID + "," + value_save + ",1)";
                                        SqlCommand CM13 = new SqlCommand(sql13, con4);
                                        SqlDataReader DR13 = CM13.ExecuteReader();
                                        con4.Close();
                                    }
                                }

                                catch { con4.Close(); }
                            }
                            con1.Close();
                            DR7.Close();


                            //Save Payment Visual

                            con1.Open();
                            string sql8 = "SELECT[TicketCodeIn] ,(Select Top 1([LabID]) From[dbo].[V_CalPayment_Visual] Where[dbo].[V_CalPayment_Visual].[ProductID] = '" + dtg_calpayment.Rows[r].Cells[2].Value.ToString().Trim() + "' AND Trim([dbo].[V_CalPayment_Visual].[LabName])= Trim([dbo].[V_VisualLog].LabName))	 AS 'LabID_SP',[LabName],[LabValue] ,(Select Top 1([StatusSP]) From[dbo].[V_CalPayment_Visual] Where[dbo].[V_CalPayment_Visual].[ProductID] = '" + dtg_calpayment.Rows[r].Cells[2].Value.ToString().Trim() + "' AND[dbo].[V_CalPayment_Visual].[StatusSP] = 1 AND Trim([dbo].[V_CalPayment_Visual].[LabName])=Trim([dbo].[V_VisualLog].LabName))	 AS 'Status_SP',(SELECT  Top 1([VendorGroupID])  FROM [dbo].[V_CalPayment_VenGroup]  WHERE  Vendor_No = (Select [Vendor_No] From [dbo].[TB_WeightData]  WHERE [dbo].[TB_WeightData].TicketCodeIn ='" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "') AND [dbo].[V_CalPayment_VenGroup].[ProductID] =  '" + dtg_calpayment.Rows[r].Cells[2].Value.ToString().Trim() + "' AND [dbo].[V_CalPayment_VenGroup].[StsActive]=1) AS 'Vendor_Group'	From[dbo].[V_VisualLog] WHERE[TicketCodeIn] ='" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "'";

                            decimal Value_visual = 0;

                            SqlCommand CM8 = new SqlCommand(sql8, con1);
                            SqlDataReader DR8 = CM8.ExecuteReader();
                            while (DR8.Read())
                            {
                                try
                                {
                                    if (DR8["Status_SP"].ToString().Trim() == "True")
                                    {
                                        Status_SP = 1;
                                        LabID = Convert.ToInt16(DR8["LabID_SP"].ToString());
                                        LabValue = Convert.ToDecimal(DR8["LabValue"].ToString());
                                        VendorGroupID = DR8["Vendor_Group"].ToString();
                                    }


                                    if (Status_SP == 1)
                                    {
                                        con4.Open();
                                        string sql41 = "SELECT Top(1) [ValueSP] FROM [dbo].[V_CalPayment_Visual] WHere [LabID]='" + LabID + "' AND [ValueWH] >=" + LabValue + " AND [VendorGroupID]='" + VendorGroupID + "' AND [StatusSP]=1 Order by [ValueWH]";

                                        SqlCommand CM41 = new SqlCommand(sql41, con4);
                                        SqlDataReader DR41 = CM41.ExecuteReader();
                                        DR41.Read();
                                        {
                                            Value_visual = Convert.ToDecimal(DR41["ValueSP"].ToString());
                                        }
                                        DR41.Close();
                                        con4.Close();


                                        string sql11 = "Select Top(1)[ValueSP] From [dbo].[V_CalPayment_Lab] Where [MinSP] <= " + LabValue + " AND [VendorGroupID]='" + VendorGroupID + "' AND [ProductID]='" + dtg_calpayment.Rows[e_rowIndex].Cells[2].Value.ToString().Trim() + "' AND [LabID]=" + LabID + " Order by [MinSP] desc ";

                                        string sql12 = "Select Top(1)[ValueSP] From [dbo].[V_CalPayment_Lab] Where [MaxSP] >= " + LabValue + " AND [VendorGroupID]='" + VendorGroupID + "' AND [ProductID]='" + dtg_calpayment.Rows[e_rowIndex].Cells[2].Value.ToString().Trim() + "'  AND [LabID]=" + LabID + " Order by [MaxSP] ";

                                        decimal value_min = 0;
                                        decimal value_max = 0;

                                        try
                                        {
                                            if (con4.State == ConnectionState.Open)
                                            {
                                                con4.Close();
                                            }
                                            con4.Open();

                                            SqlCommand CM11 = new SqlCommand(sql11, con4);
                                            SqlDataReader DR11 = CM11.ExecuteReader();
                                            DR11.Read();
                                            {
                                                value_min = Convert.ToDecimal(DR11["ValueSP"].ToString());
                                            }
                                            DR11.Close();
                                            con4.Close();
                                        }
                                        catch { value_min = 0; con4.Close(); }

                                        try
                                        {
                                            con4.Open();
                                            SqlCommand CM12 = new SqlCommand(sql12, con4);
                                            SqlDataReader DR12 = CM12.ExecuteReader();
                                            DR12.Read();
                                            {
                                                value_max = Convert.ToDecimal(DR12["ValueSP"].ToString());
                                            }
                                            DR12.Close();
                                            con4.Close();
                                        }
                                        catch { value_max = 0; con4.Close(); }


                                        decimal value_save = 0;

                                        if
                                            (value_min == value_max)
                                        { value_save = value_min; }
                                        else
                                        { value_save = value_max; }

                                        
                                        string sql9 = "";

                                        if (C_Save == 0)
                                        {
                                            sql9 = "INSERT INTO [dbo].[TB_PaymentVisualeDetail]([PayDetailNo],[LabID],[Value],[Status_Active]) VALUES(" + IDPaymentDetail + "," + LabID + "," + value_save + ",1)";
                                        }

                                        if (C_Save == 1)
                                        {
                                            sql9 = "Update [dbo].[TB_PaymentVisualeDetail] SET [LabID] = " + LabID + ",[Value]= " + value_save + ", [Status_Active]= 1 WHERE  [PayDetailNo] = " + IDPaymentDetail + ")";
                                        }

                                        con4.Open();
                                        SqlCommand CM9 = new SqlCommand(sql9, con4);
                                        SqlDataReader DR9 = CM9.ExecuteReader();
                                        con4.Close();

                                        Status_SP = 0;

                                    }
                                }


                                catch
                                {
                                }

                            }

                            DR8.Read();
                            con1.Close();


                            //Save Payment Visual Detail
                            con1.Open();
                            string sql40 = "SELECT[TicketCodeIn] ,(Select Top 1([LabID]) From[dbo].[V_CalPayment_Visual_Detail] Where[dbo].[V_CalPayment_Visual_Detail].[ProductID] = '" + dtg_calpayment.Rows[r].Cells[2].Value.ToString().Trim() + "' AND Trim([dbo].[V_CalPayment_Visual_Detail].[LabName])= Trim([dbo].[V_VisualLog].LabName))	 AS 'LabID_SP',[LabName],[LabValue] ,(Select Top 1([StatusSP]) From[dbo].[V_CalPayment_Visual_Detail] Where[dbo].[V_CalPayment_Visual_Detail].[ProductID] = '" + dtg_calpayment.Rows[r].Cells[2].Value.ToString().Trim() + "' AND[dbo].[V_CalPayment_Visual_Detail].[StatusSP] = 1 AND Trim([dbo].[V_CalPayment_Visual_Detail].[LabName])=Trim([dbo].[V_VisualLog].LabName))	 AS 'Status_SP',(SELECT  Top 1([VendorGroupID])  FROM [dbo].[V_CalPayment_VenGroup]  WHERE  Vendor_No = (Select [Vendor_No] From [dbo].[TB_WeightData]  WHERE [dbo].[TB_WeightData].TicketCodeIn ='" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "') AND [dbo].[V_CalPayment_VenGroup].[ProductID] =  '" + dtg_calpayment.Rows[r].Cells[2].Value.ToString().Trim() + "' AND [dbo].[V_CalPayment_VenGroup].[StsActive]=1) AS 'Vendor_Group'	From[dbo].[V_VisualLog] WHERE[TicketCodeIn] ='" + dtg_calpayment.Rows[r].Cells[0].Value.ToString().Trim() + "'";

                            SqlCommand CM40 = new SqlCommand(sql40, con1);
                            SqlDataReader DR40 = CM40.ExecuteReader();
                            while (DR40.Read())
                            {
                                if (DR40["Status_SP"].ToString().Trim() == "True")
                                {
                                    Status_SP = 1;
                                    LabID = Convert.ToInt16(DR40["LabID_SP"].ToString());
                                    LabValue = Convert.ToDecimal(DR40["LabValue"].ToString());
                                    VendorGroupID = DR40["Vendor_Group"].ToString();
                                }


                                if (Status_SP == 1)
                                {
                                    string sql11 = "Select Top(1)[ValueSP] From [dbo].[V_CalPayment_Visual_Detail] Where [Vmin] <= " + LabValue + " AND [VendorGroupID]='" + VendorGroupID + "' AND [ProductID]='" + dtg_calpayment.Rows[e_rowIndex].Cells[2].Value.ToString().Trim() + "' AND [LabID]=" + LabID + " AND StatusSP = 1 Order by [Vmin] desc ";

                                    string sql12 = "Select Top(1)[ValueSP] From [dbo].[V_CalPayment_Visual_Detail] Where [Vmax] >= " + LabValue + " AND [VendorGroupID]='" + VendorGroupID + "' AND [ProductID]='" + dtg_calpayment.Rows[e_rowIndex].Cells[2].Value.ToString().Trim() + "'  AND [LabID]=" + LabID + " AND StatusSP = 1 Order by [Vmax] ";

                                    decimal value_min = 0;
                                    decimal value_max = 0;

                                    try
                                    {
                                        if (con4.State == ConnectionState.Open)
                                        {
                                            con4.Close();
                                        }
                                        con4.Open();

                                        SqlCommand CM11 = new SqlCommand(sql11, con4);
                                        SqlDataReader DR11 = CM11.ExecuteReader();
                                        DR11.Read();
                                        {
                                            value_min = Convert.ToDecimal(DR11["ValueSP"].ToString());
                                        }
                                        DR11.Close();
                                        con4.Close();
                                    }
                                    catch { value_min = 0; con4.Close(); }

                                    try
                                    {
                                        con4.Open();
                                        SqlCommand CM12 = new SqlCommand(sql12, con4);
                                        SqlDataReader DR12 = CM12.ExecuteReader();
                                        DR12.Read();
                                        {
                                            value_max = Convert.ToDecimal(DR12["ValueSP"].ToString());
                                        }
                                        DR12.Close();
                                        con4.Close();
                                    }
                                    catch { value_max = 0; con4.Close(); }


                                    decimal value_save = 0;

                                    if
                                        (value_min == value_max)
                                    { value_save = value_min; }
                                    else
                                    { value_save = value_max; }
                              
                                    //test 17.12.2021--------------------

                                    con4.Open();
                                    string sql9 = "INSERT INTO [dbo].[TB_PaymentVisualeDetail]([PayDetailNo],[LabID],[Value],[Status_Active]) VALUES(" + IDPaymentDetail + "," + LabID + "," + value_save + ",1)";
                                    SqlCommand CM9 = new SqlCommand(sql9, con4);
                                    SqlDataReader DR9 = CM9.ExecuteReader();
                                    con4.Close();

                                    Status_SP = 0;
                                }

                            }

                            DR40.Close();
                            con1.Close();

                        }





                        //Update TB_Temp Summary REcived SP
                        con1.Open();
                        SqlCommand cmd = new SqlCommand("ST_Up_TB_Temp_SummaryRecived_SP", con1);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PaymentID", PaymentID);                     
                        cmd.ExecuteNonQuery();
                        con1.Close();
                    }                   
                  
                    CL.tbname = "New record Payment!";
                    CL.oldvalue = "-";
                    CL.newvalue = dtg_calNav.Rows[i].Cells[0].Value.ToString();
                    CL.Save_log();

                }

                else
                { //dtg rows color }

                    //MessageBox.Show(dtg_calNav.Rows[i].Cells[14].Value.ToString());
                    dtg_calNav.Rows[i].Cells[3].Style.BackColor = Color.Red; id_dup = 0; save_unsuccess += 1;
                }

            }


            //rdr.Close();
            con1.Close();
            con2.Close();

            dtg_calNav.DataSource = null;

        }

        private void Check_ProcessID()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter2 = new SqlDataAdapter();
            con.Open();

            string sql1 = "";
            if (id_checkprocess == 1)
            {
                sql1 = "Select [proc_no] From [dbo].[TB_Process] Where [item_no] = '" + cb_product.SelectedValue.ToString() + "' AND [proc_type] ='P' ";
            }
            else
            {
                sql1 = "Select [proc_no] From [dbo].[TB_Process] Where [item_no] = '" + cb_product.SelectedValue.ToString() + "' AND [proc_type] ='T' ";
            }

            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();
            DR1.Read();
            {
                Process_id = Convert.ToInt16(DR1["proc_no"].ToString());
            }
            DR1.Close();

            //rdr.Close();
            con.Close();

        }
        private void Check_DuplicateDoc()
        {
            SqlConnection con = new SqlConnection(Program.pathdb14_TruckScale);
            con.ConnectionString = Program.pathdb14_TruckScale;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql1 = "Select count([Document_No]) as doc_count From [dbo].[Purchase_Invoice] Where [Document_No]='" + Doc_check + "'";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();
            DR1.Read();
            {
                id_dup = Convert.ToInt16(DR1["doc_count"].ToString());
            }
            DR1.Close();

            //rdr.Close();
            con.Close();
        }
 

        private void btn_history_Click(object sender, EventArgs e)
        {
            F_Payhistory flog = new F_Payhistory();
            flog.ShowDialog();

        }

        private void btn_GroupSetting_Click(object sender, EventArgs e)
        {
            F_Setting ftt = new F_Setting();       
            ftt.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_savetoTempNav.Enabled = false; msn_toolstatus.Text = "";

            if (tabControl1.SelectedIndex == 0)
            {
                ststool_totalweight.Text = "Totlal: " + dtg_weight.RowCount.ToString() + " Items";
            }

            if (tabControl1.SelectedIndex == 1)
            {
                ststool_totalweight.Text = "Totlal: " + dtg_calpayment.RowCount.ToString() + " Items";
                msn_toolstatus.Text = "ดับเบิ้ลคลิ๊ก -> ดูรายละเอียดของจ่าย/เปลี่ยนแปลงข้อมูล ทุกรายการจ่าย, คลิ๊กขวเปลี่ยนแปลงกลุ่มเฉพาะรายการ";
            }

            if (tabControl1.SelectedIndex == 2)
            {
                ststool_totalweight.Text = "Totlal: " + dtg_CalPay.RowCount.ToString() + " Items";
            }

            if (tabControl1.SelectedIndex == 3)
            {               
                dtg_calNav.DataSource = null;
                ststool_totalweight.Text = "Totlal: " + dtg_calNav.RowCount.ToString() + " Items";
            }           
        }


        private void Recheck_Posted()
        {
            SqlConnection con = new SqlConnection(Program.pathdb14_NAV);
            con.ConnectionString = Program.pathdb14_NAV;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            int Posted_no = 0;


            for (int i = 0; i < dtg_payHistory.RowCount; i++)
            {
                string sql1 = "Select count([Document No_]) as doc_count From [dbo].[Sapthip LIVE$Purchase invoice Interface] Where [Document No_]='" + dtg_payHistory.Rows[i].Cells[2].Value.ToString().Trim() + "' AND [Posted]=1 ";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                DR1.Read();
                {
                    Posted_no = Convert.ToInt16(DR1["doc_count"].ToString());
                }
                DR1.Close();

                if (Posted_no == 1)
                {
                    dtg_payHistory.Rows[i].Cells[0].ReadOnly = true;
                }

            }

            con.Close();
        }  

                     

        private void Load_History()
        {
            if (cb_product.SelectedIndex != -1)
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                dtg_payHistory.DataSource = null;

                //DateTime dt = DateTime.Now;
                //int year_c = dt.Year + 543;

                //string dt = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US")); //+ ' ' + DateTime.Now.ToString("HH:mm", CultureInfo.CreateSpecificCulture("en-US"));

                // DATEPART(year,[SaveDate]) = '" + dt.Year + "'  and DATEPART(day, [SaveDate]) = '" + dt.Day + "' and DATEPART(month, [SaveDate]) = '" + dt.Month + "' ";

                string sql = "SELECT [PaymentID] AS 'ลำดับ',[PayDocNo] AS 'เลขที่จ่าย',[PayDate] AS 'วันที่ทำจ่าย',[Vendor_No] AS 'รหัสผู้ขาย',[Vendor_Name] AS 'ผู้ขาย',[ProductID] AS 'รหัสสินค้า',[ProductName] AS 'สินค้า',[Qty_Net] AS 'จำนวน',[Unit_Net] AS 'ราคา/หน่วย',[Rev_net] AS 'ค่าบริการอื่น ๆ',[Price_Net] AS 'ราคารวม',[Remark] AS 'หมายเหตุ'   FROM  [dbo].[V_PayHistory] WHERE [ProductID] ='" + cb_product.SelectedValue.ToString() + "' AND  [PayDate]='"+Program.Date_Now+"' ";

                SqlDataAdapter da1 = new SqlDataAdapter(sql, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "v_history");
                dtg_payHistory.DataSource = ds1.Tables["v_history"];
                con.Close();

                ststool_totalweight.Text = "Total :" + dtg_payHistory.RowCount.ToString() + " Items";

                Adjust_ColDTG_history();

               
            }
        }

        private void Adjust_ColDTG_history()
        {
            for (int i = 0; i < dtg_payHistory.RowCount; i++)
            {
                if (dtg_payHistory.Rows[i].Cells[12].Value.ToString().Trim() != "บันทึกสำเร็จ")
                {
                    this.dtg_payHistory.Rows[i].Cells[0].ReadOnly = true;
                    this.dtg_payHistory.Rows[i].Cells[0].Style.BackColor = Color.Red;
                }
                else { this.dtg_payHistory.Rows[i].Cells[0].Style.BackColor = Color.LightGreen; this.dtg_payHistory.Rows[i].Cells[0].ReadOnly = false; }
            }
            //this.dtg_payHistory.Rows[index].Cells["colName"].ReadOnly = true;

            dtg_payHistory.Columns[0].Width = 80;
            dtg_payHistory.Columns[1].Width = 70;
            dtg_payHistory.Columns[2].Width = 200;
            dtg_payHistory.Columns[3].Width = 100;
            dtg_payHistory.Columns[4].Width = 100;
            dtg_payHistory.Columns[5].Width = 300;
            dtg_payHistory.Columns[6].Width = 90;
            dtg_payHistory.Columns[7].Width = 120;
            dtg_payHistory.Columns[8].Width = 90;
            dtg_payHistory.Columns[9].Width = 90;
            dtg_payHistory.Columns[10].Width = 80;
            dtg_payHistory.Columns[11].Width = 100;

            dtg_payHistory.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtg_payHistory.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtg_payHistory.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtg_payHistory.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtg_payHistory.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtg_payHistory.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtg_payHistory.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            ststool_totalweight.Text = "Totlal: " + dtg_payHistory.RowCount.ToString() + " Items";
            dtg_payHistory.ClearSelection();
        }

        private void Load_Date_History()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                //CONVERT(VARCHAR(25), [WeightDate], 126)
                //Product 
                con.Open();
                SqlCommand cmd = new SqlCommand("Select DISTINCT [PayDate]  From [dbo].[TB_Payment] WHERE [ProductID] = '" + cb_product.SelectedValue.ToString() + "' ORDER BY [PayDate] DESC", con);
                DataSet ds = new DataSet();
                //ds.Clear();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                cb_datePayment.DataSource = ds.Tables[0];
                cb_datePayment.DisplayMember = "PayDate";
                cb_datePayment.ValueMember = "PayDate";
                con.Close();
            }
            catch { con.Close(); }

            cb_datePayment.Text = "";
            cb_datePayment.SelectedIndex = -1;

        }

        private void cb_datePayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {

                if (cb_datePayment.SelectedIndex > -1)
                {

                    con.Open();

                    DateTime dt = Convert.ToDateTime(cb_datePayment.SelectedValue.ToString());
                    string date = Program.Date_Now;

                    string sql = "SELECT [PaymentID] AS 'ลำดับ',[PayDocNo] AS 'เลขที่จ่าย',[PayDate] AS 'วันที่ทำจ่าย',[Vendor_No] AS 'รหัสผู้ขาย',[Vendor_Name] AS 'ผู้ขาย',[ProductID] AS 'รหัสสินค้า',[ProductName] AS 'สินค้า',[Qty_Net] AS 'จำนวน',[Unit_Net] AS 'ราคา/หน่วย',[Rev_net] AS 'ค่าบริการอื่น ๆ',[Price_Net] AS 'ราคารวม',[Remark] AS 'หมายเหตุ'   FROM  [dbo].[V_PayHistory] WHERE DATEPART(year,[PayDate]) = '" + dt.Year + "'  and DATEPART(day, [PayDate]) = '" + dt.Day + "' and DATEPART(month, [PayDate]) = '" + dt.Month + "'  Order by [PaymentID] desc ";

                    SqlDataAdapter da1 = new SqlDataAdapter(sql, con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1, "v_history");
                    dtg_payHistory.DataSource = ds1.Tables["v_history"];
                    con.Close();

                    Adjust_ColDTG_history();

                    rdo_repaySome.Enabled = true;
                    rdo_repaySome.Checked = true;
                    rdo_repayAll.Enabled = true;
                    btn_revertPay.Enabled = true;

                    Recheck_Posted();

                }
            }
            catch { con.Close(); }

        }

        private void btn_revertPay_Click(object sender, EventArgs e)
        {
            try
            {            
                
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

                SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
                con1.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter1 = new SqlDataAdapter();

                // Connect SQL 225, SapthipNewDB 
                SqlConnection con3 = new SqlConnection(Program.pathdb14_TruckScale);
                con3.ConnectionString = Program.pathdb14_TruckScale;
                SqlDataAdapter dtAdapter3 = new SqlDataAdapter();

                SqlConnection con4 = new SqlConnection(Program.pathdb14_NAV);
                con4.ConnectionString = Program.pathdb14_NAV;
                SqlDataAdapter dtAdapter2 = new SqlDataAdapter();

                id_checkprocess = 2;
                Check_ProcessID();
                Process_id--;

                int PayDetailNo = 0;

                if (rdo_repayAll.Checked == true)
                {
                    if (cb_datePayment.Text != "" || cb_product.Text != "")
                    {
                        if (cb_datePayment.Text == "")
                        { MessageBox.Show("กรุณาเลือกวันที่ที่ต้องการแก้ไข", "การแก้ไขผิดพลาด!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                        DateTime dt_Edit = new DateTime();
                        dt_Edit = Convert.ToDateTime(cb_datePayment.Text);

                        DateTime dt_Now = new DateTime();
                        dt_Now = DateTime.Now;

                        //string date_Edit = dt_Edit.ToString("yyyy-MM-dd");
                        //string date_Now = dt_Now.ToString("yyyy-MM-dd");

                        //if (date_Edit == date_Now)
                        //{
                        DialogResult dr = MessageBox.Show("คุณต้องการแก้ไขข้อมูลที่ได้ส่งไปนาวิชั่นอีกครั้งใช่หรือไม่", "ยืนยันข้อมูล", MessageBoxButtons.YesNoCancel,
                      MessageBoxIcon.Information);

                        if (dr == DialogResult.Yes)
                        {
                            for (int i = 0; i < dtg_payHistory.RowCount; i++)
                            {
                                if (dtg_payHistory.Rows[i].Cells[0].Value != null)
                                {
                                    con.Open();
                                    string sql = "Update [TB_Payment] Set Remark='รายการนี้ถูกดึงกลับไปแก้ไข' WHERE [PayDocNo] = '" + dtg_payHistory.Rows[i].Cells[2].Value.ToString() + "' ";
                                    SqlCommand CM = new SqlCommand(sql, con);
                                    SqlDataReader DR = CM.ExecuteReader();
                                    con.Close();                                                                                                           

                                    Class_Log CL = new Class_Log();
                                    CL.tbname = "Revert Record from History payment!";
                                    CL.oldvalue = "-";
                                    CL.newvalue = dtg_payHistory.Rows[i].Cells[2].Value.ToString();
                                    CL.Save_log();                                   


                                    con.Open();
                                    string sql10 = "SELECT [PayDetailNo] FROM [dbo].[TB_PaymentDetail]  WHERE [PayDocID ] = " + dtg_payHistory.Rows[i].Cells[1].Value.ToString().Trim() + "";
                                    SqlCommand CM10 = new SqlCommand(sql10, con);
                                    SqlDataReader DR10 = CM10.ExecuteReader();
                                    while (DR10.Read())
                                    {
                                        if (con1.State == ConnectionState.Open)
                                        {
                                            con1.Close();
                                        }
                                        con1.Open();

                                        string sql6 = "Update [TB_PaymentVisualeDetail] Set [Status_Active]= 0  WHERE [PayDetailNo] = " + DR10["PayDetailNo"].ToString() + "";
                                        SqlCommand CM6 = new SqlCommand(sql6, con1);
                                        SqlDataReader DR6 = CM6.ExecuteReader();
                                        con1.Close();

                                        con1.Open();
                                        string sql7 = "Update [TB_PaymentLabDetail] Set [Status_Active]= 0  WHERE [PayDetailNo] = " + DR10["PayDetailNo"].ToString() + "";
                                        SqlCommand CM7 = new SqlCommand(sql7, con1);
                                        SqlDataReader DR67 = CM7.ExecuteReader();
                                        con1.Close();

                                    }
                                    DR10.Close();
                                    con.Close();

                                    try
                                    {
                                        con.Open();
                                        string sql4 = "Delete [TB_PaymentDetail] WHERE [PayDocID ] = " + dtg_payHistory.Rows[i].Cells[1].Value.ToString().Trim
                                        () + "";
                                        SqlCommand CM4 = new SqlCommand(sql4, con);
                                        SqlDataReader DR4 = CM4.ExecuteReader();
                                        con.Close();
                                    }
                                    catch { con.Close(); }
                                    
                                    con.Open();
                                    string sql11 = "Delete [TB_Temp_Payment_Recived_R004] WHERE [PayDocNo] = '" + dtg_payHistory.Rows[i].Cells[1].Value.ToString().Trim
                                    () + "'";
                                    SqlCommand CM11 = new SqlCommand(sql11, con);
                                    SqlDataReader DR11 = CM11.ExecuteReader();
                                    con.Close();
                                    
                                    con.Open();
                                    string sql12 = "Delete [TB_Temp_Payment_RecivedAF_R004] WHERE [PayDocNo] = '" + dtg_payHistory.Rows[i].Cells[1].Value.ToString().Trim() + "'";
                                    SqlCommand CM12 = new SqlCommand(sql12, con);
                                    SqlDataReader DR12 = CM12.ExecuteReader();
                                    con.Close();
                                                                      
                                    con.Open();
                                    DateTime DT = Convert.ToDateTime(cb_datePayment.Text);
                                    string Date_Weight = DT.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));

                                    string sql_list = "";

                                    if (cb_product.SelectedValue.ToString() == "RM-004")
                                    {
                                        sql_list = "Select [LOGID] From [TB_WeightData]  WHERE [WeightDate] Between '" + Date_Weight + " 00:00.00'  AND  '" + Date_Weight + " 23:59:59.999' AND [ProductID]='RM-004' AND [Vendor_No]='" + dtg_payHistory.Rows[i].Cells[4].Value.ToString().Trim() + "'";
                                    }

                                    if (cb_product.SelectedValue.ToString() == "RM-001")
                                    {
                                        sql_list = "Select [LOGID] From [TB_WeightData]  WHERE [WeightDate] Between '" + Date_Weight + " 00:00.00'  AND  '" + Date_Weight + " 23:59:59.999' AND [ProductID]='RM-001' AND [Vendor_No]='" + dtg_payHistory.Rows[i].Cells[4].Value.ToString().Trim() + "'";
                                    }

                                    SqlCommand CM13 = new SqlCommand(sql_list, con);
                                    SqlDataReader DR13 = CM13.ExecuteReader();
                                    while (DR13.Read())
                                    {
                                        if (con1.State == ConnectionState.Open)
                                        {
                                            con1.Close();
                                        }
                                        con1.Open();
                                        string sql5 = "Update [TB_WeightData] Set [Process_id] = " + Process_id + ",[Remark1] = null  WHERE  [LOGID]=" + DR13["LOGID"].ToString().Trim() + "";
                                        SqlCommand CM5 = new SqlCommand(sql5, con1);
                                        SqlDataReader DR5 = CM5.ExecuteReader();
                                        con1.Close();
                                    }

                                    DR13.Close();
                                    con.Close();                               

                                    con3.Open();
                                    string sql8 = "Delete [dbo].[Purchase_Invoice] WHERE [Document_No] = '" + dtg_payHistory.Rows[i].Cells[2].Value.ToString().Trim
                                    () + "'";
                                    SqlCommand CM8 = new SqlCommand(sql8, con3);
                                    SqlDataReader DR8 = CM8.ExecuteReader();
                                    con3.Close();

                                    con4.Open();
                                    string sql9 = "Delete [dbo].[Sapthip LIVE$Purchase invoice Interface] WHERE [Document No_] = '" + dtg_payHistory.Rows[i].Cells[2].Value.ToString().Trim
                                    () + "'";
                                    SqlCommand CM9 = new SqlCommand(sql9, con4);
                                    SqlDataReader DR9 = CM9.ExecuteReader();
                                    con4.Close();   
                                }
                            }


                            MessageBox.Show("กลับรายการมาแก้ไขสำเร็จ ", "รายงาน!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (cb_product.SelectedIndex == 0)  // มันเส้น
                            {
                                lbl_productName.BackColor = Color.LightYellow;
                                Load_DATA_ConfirmPayment();
                                lbl_productName.Text = cb_product.SelectedValue.ToString();
                                btn_calculator.Enabled = true;

                                Clear_DTG();   //เคลียร์ขอมูลเก่าทิ้ง
                                Load_Cal_Payment1();     //เรียนข้อมูลค้างจ่าย
                                Load_Cal_Payment2(); //คำนวนหน้ำหนัก
                                Load_Cal_Payment3();   //รวมรายการรับซื้อ
                                                              
                            }
                            else if (cb_product.SelectedIndex == 1)   //มันสด
                            {
                                lbl_productName.BackColor = Color.LightGreen;
                                Load_DATA_ConfirmPayment();
                                lbl_productName.Text = cb_product.SelectedValue.ToString();
                                btn_calculator.Enabled = true;

                                Clear_DTG();   //เคลียร์ขอมูลเก่าทิ้ง
                                Load_Cal_Payment1();     //เรียนข้อมูลค้างจ่าย
                                Load_Cal_Payment2(); //คำนวนหน้ำหนัก
                                Load_Cal_Payment3();   //รวมรายการรับซื้อ
                                                            
                            }
                            //}

                            //else
                            //{
                            //    MessageBox.Show("รายการที่เลือกได้พ้นกำหนดการแก้ไขแล้ว", "การแก้ไขรายการผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //}

                            tabControl2.SelectedIndex = 0;
                            tabControl1.SelectedIndex = 1;
                        }
                    }
                }

                else if (rdo_repaySome.Checked == true)
                {
                    if (cb_datePayment.Text != "" || cb_product.Text != "")
                    {

                        if (cb_datePayment.Text == "")
                        { MessageBox.Show("กรุณาเลือกวันที่ที่ต้องการแก้ไข", "การแก้ไขผิดพลาด!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                        DateTime dt_Edit = new DateTime();
                        dt_Edit = Convert.ToDateTime(cb_datePayment.Text);

                        DateTime dt_Now = new DateTime();
                        dt_Now = DateTime.Now;

                        //string date_Edit = dt_Edit.ToString("yyyy-MM-dd");
                        //string date_Now = dt_Now.ToString("yyyy-MM-dd");

                        //if (date_Edit == date_Now)
                        //{
                        DialogResult dr = MessageBox.Show("คุณต้องการแก้ไขข้อมูลที่ได้ส่งไปนาวิชั่นอีกครั้งใช่หรือไม่", "ยืนยันข้อมูล", MessageBoxButtons.YesNoCancel,
                      MessageBoxIcon.Information);

                        if (dr == DialogResult.Yes)
                        {
                            for (int i = 0; i < dtg_payHistory.RowCount; i++)
                            {

                                if (dtg_payHistory.Rows[i].Cells[0].Value != null)
                                {
                                    con.Open();
                                    string sql = "Update [TB_Payment] Set Remark='รายการนี้ถูกดึงกลับไปแก้ไข' WHERE [PayDocNo] = '" + dtg_payHistory.Rows[i].Cells[2].Value.ToString() + "' ";
                                    SqlCommand CM = new SqlCommand(sql, con);
                                    SqlDataReader DR = CM.ExecuteReader();
                                    con.Close();


                                    Class_Log CL = new Class_Log();
                                    CL.tbname = "Revert Record from History payment!";
                                    CL.oldvalue = "-";
                                    CL.newvalue = dtg_payHistory.Rows[i].Cells[2].Value.ToString();
                                    CL.Save_log();                                                                        


                                    con.Open();
                                    string sql10 = "SELECT [PayDetailNo] FROM [dbo].[TB_PaymentDetail]  WHERE [PayDocID ] = " + dtg_payHistory.Rows[i].Cells[1].Value.ToString().Trim() + " ";
                                    SqlCommand CM10 = new SqlCommand(sql10, con);
                                    SqlDataReader DR10 = CM10.ExecuteReader();
                                    while (DR10.Read())
                                    {
                                        if (con1.State == ConnectionState.Open)
                                        {
                                            con1.Close();
                                        }
                                        con1.Open();

                                        PayDetailNo = Convert.ToInt32(DR10["PayDetailNo"].ToString());

                                        string sql6 = "DELETE [TB_PaymentVisualeDetail] WHERE [PayDetailNo] = " + PayDetailNo + "";
                                        SqlCommand CM6 = new SqlCommand(sql6, con1);
                                        SqlDataReader DR6 = CM6.ExecuteReader();
                                        con1.Close();

                                        con1.Open();
                                        string sql7 = "DELETE [TB_PaymentLabDetail] WHERE [PayDetailNo] = " + PayDetailNo + "";
                                        SqlCommand CM7 = new SqlCommand(sql7, con1);
                                        SqlDataReader DR67 = CM7.ExecuteReader();
                                        con1.Close();
                                    }
                                    DR10.Close();
                                    con.Close();

                                    con1.Open();
                                    string sql8 = "DELETE [TB_PaymentDetail] WHERE [PayDetailNo]= '" + PayDetailNo + "'";
                                    SqlCommand CM8 = new SqlCommand(sql8, con1);
                                    SqlDataReader DR8 = CM8.ExecuteReader();                                   
                                    con1.Close();
                                    

                                    //select  vendor , date payment , production 
                                    con.Open();                              
                                    DateTime DT = Convert.ToDateTime(cb_datePayment.Text);
                                    string Date_Weight = DT.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));

                                    string sql_list = "";

                                    if (cb_product.SelectedValue.ToString() == "RM-004")
                                    {
                                        sql_list = "Select [LOGID] From [TB_WeightData]  WHERE [WeightDate] Between '" + Date_Weight + " 00:00.00'  AND  '" + Date_Weight + " 23:59:59.999' AND [ProductID]='RM-004' AND [Vendor_No]='" + dtg_payHistory.Rows[i].Cells[4].Value.ToString().Trim() + "'";
                                    }

                                    if (cb_product.SelectedValue.ToString() == "RM-001")
                                    {
                                        sql_list = "Select [LOGID] From [TB_WeightData]  WHERE [WeightDate] Between '" + Date_Weight + " 00:00.00'  AND  '" + Date_Weight + " 23:59:59.999' AND [ProductID]='RM-001' AND [Vendor_No]='" + dtg_payHistory.Rows[i].Cells[4].Value.ToString().Trim() + "'";
                                    }

                                    SqlCommand CM11 = new SqlCommand(sql_list, con);
                                    SqlDataReader DR11 = CM11.ExecuteReader();
                                    while (DR11.Read())
                                    {

                                        if (con1.State == ConnectionState.Open)
                                        {
                                            con1.Close();
                                        }

                                        con1.Open();
                                        string sql5 = "Update [TB_WeightData] Set [Process_id] = " + Process_id + ",[Remark1] = null  WHERE  [LOGID]=" + DR11["LOGID"].ToString().Trim() + "";
                                        SqlCommand CM5 = new SqlCommand(sql5, con1);
                                        SqlDataReader DR5 = CM5.ExecuteReader();
                                        con1.Close();
                                       
                                    }

                                    DR11.Close();
                                    con.Close();

                                    try
                                    {
                                        con3.Open();
                                        string sql12 = "Delete [dbo].[Purchase_Invoice] WHERE [Document_No] = '" + dtg_payHistory.Rows[i].Cells[2].Value.ToString().Trim
                                        () + "'";
                                        SqlCommand CM12 = new SqlCommand(sql12, con3);
                                        SqlDataReader DR12 = CM11.ExecuteReader();
                                        con3.Close();
                                    }
                                    catch { }


                                    try
                                    {
                                        con4.Open();
                                        string sql9 = "Delete [dbo].[Sapthip LIVE$Purchase invoice Interface] WHERE [Document No_] = '" + dtg_payHistory.Rows[i].Cells[2].Value.ToString().Trim
                                        () + "'";
                                        SqlCommand CM9 = new SqlCommand(sql9, con4);
                                        SqlDataReader DR9 = CM9.ExecuteReader();
                                        con4.Close();
                                    }
                                    catch { }    
                                }
                            }


                            MessageBox.Show("กลับรายการมาแก้ไขสำเร็จ ", "รายงาน!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (cb_product.SelectedIndex == 0)  // มันเส้น
                            {
                                lbl_productName.BackColor = Color.LightYellow;
                                Load_DATA_ConfirmPayment();
                                lbl_productName.Text = cb_product.SelectedValue.ToString();
                                btn_calculator.Enabled = true;

                                Clear_DTG();   //เคลียร์ขอมูลเก่าทิ้ง
                                Load_Cal_Payment1();     //เรียนข้อมูลค้างจ่าย
                                Load_Cal_Payment2(); //คำนวนหน้ำหนัก
                                Load_Cal_Payment3();   //รวมรายการรับซื้อ

                                tabControl1.SelectedIndex = 2;
                            }
                            else if (cb_product.SelectedIndex == 1)   //มันสด
                            {
                                lbl_productName.BackColor = Color.LightGreen;
                                Load_DATA_ConfirmPayment();
                                lbl_productName.Text = cb_product.SelectedValue.ToString();
                                btn_calculator.Enabled = true;

                                Clear_DTG();   //เคลียร์ขอมูลเก่าทิ้ง
                                Load_Cal_Payment1();     //เรียนข้อมูลค้างจ่าย
                                Load_Cal_Payment2(); //คำนวนหน้ำหนัก
                                Load_Cal_Payment3();   //รวมรายการรับซื้อ

                                tabControl1.SelectedIndex = 2;
                            }
                            //}

                            //else
                            //{
                            //    MessageBox.Show("รายการที่เลือกได้พ้นกำหนดการแก้ไขแล้ว", "การแก้ไขรายการผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //}

                        }
                    }
                }

                else { MessageBox.Show("กรุณาเลือกสินค้าหรือวันที่ ที่ต้องการแก้ไข", "การแก้ไขรายการผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

       

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ststool_datetime.Text = "Login Date: " + DateTime.Now.ToShortDateString() +" Time: " + DateTime.Now.ToLongTimeString();            
        }

        private void dtg_calpayment_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    ContextMenu m = new ContextMenu();
            //    m.MenuItems.Add(new MenuItem("Cut"));
            //    m.MenuItems.Add(new MenuItem("Copy"));
            //    m.MenuItems.Add(new MenuItem("Paste"));

            //    int currentMouseOverRow = dtg_calpayment.HitTest(e.X, e.Y).RowIndex;

            //    if (currentMouseOverRow >= 0)
            //    {
            //        m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
            //    }

            //    m.Show(dtg_calpayment, new Point(e.X, e.Y));

            //}
        }

        private void dtg_calpayment_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            F_PaymentAudit fpad = new F_PaymentAudit();
            fpad.Ticket_Code = dtg_calpayment.Rows[e.RowIndex].Cells[0].Value.ToString();
            fpad.Product_Code = dtg_calpayment.Rows[e.RowIndex].Cells[2].Value.ToString();
            fpad.Vendor_Code = dtg_calpayment.Rows[e.RowIndex].Cells[4].Value.ToString();
            fpad.VendorGroup_Code = dtg_calpayment.Rows[e.RowIndex].Cells[6].Value.ToString();
            fpad.Value_Visual = dtg_calpayment.Rows[e.RowIndex].Cells[10].Value.ToString();
            fpad.Value_Starh = dtg_calpayment.Rows[e.RowIndex].Cells[12].Value.ToString();
            fpad.ShowDialog();
                                             

            if (dtg_calpayment.Rows[e.RowIndex].Cells[16].Value.ToString() == "กลุ่มผู้ขาย")
            {
                //V_CalPayment_VenGroup();


            }

            if (dtg_calpayment.Rows[e.RowIndex].Cells[16].Value.ToString() == "เงื่อนไขการจ่าย")
            {
                //V_CalPayment_Starch
                               
            }

            if (dtg_calpayment.Rows[e.RowIndex].Cells[16].Value.ToString() == "เงื่อนไขการตัดน้ำหนัก")
            {
                //V_CalPayment_Visual
                                             
            }


        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Refresh_Data();

            if (cb_product.SelectedIndex > -1)
            {                
                backgroundWorker1.RunWorkerAsync();
                tool_lblprogress.Text = "";
            }

            if (tabControl2.SelectedIndex == 2 && tabControl4.SelectedIndex ==1)
            {
                Load_Date_History();
            }

            //CC_ProgressBar.Value = 0; lbl_progress.Visible = false; 
        }

        private void bnt_recheck_Click(object sender, EventArgs e)
        {
            F_RecheckData frdt = new F_RecheckData();
            frdt.ID_Recheck = 1;
            frdt.ShowDialog();
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            F_MainReport fmp = new F_MainReport();
            fmp.ShowDialog();
        }

        private void menu_right_MouseClick(object sender, MouseEventArgs e)
        {

            F_RightClick frck = new F_RightClick();
            frck.ID_Vendor = VendorCode;
            frck.ID_Product = ProductID;
            frck.ShowDialog();

            Log_OldValue = dtg_calpayment.Rows[e_rowIndex].Cells[6].Value.ToString();

            dtg_calpayment.Rows[e_rowIndex].Cells[6].Value = frck.VendorGroupID.ToString();
            ID_VendorGPay = frck.ID_VednroGPay;
            
            Class_Log CL = new Class_Log();
            CL.tbname = "Change Data Vendor Group!";
            CL.oldvalue = Log_OldValue;
            CL.newvalue = frck.VendorGroupID.ToString();
            CL.Save_log();

            Load_PriceGroup();   //เปลี่ยนกลุ่มราคา รายรายการ
            Load_Cal_Payment3();   //รวมรายการรับซื้อ
        }

        private void dtg_calpayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                e_rowIndex = e.RowIndex;
                VendorCode = dtg_calpayment.Rows[e.RowIndex].Cells[4].Value.ToString();
                ProductID =  dtg_calpayment.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void Load_PriceGroup()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;

            SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
            con1.ConnectionString = Program.pathdb_Weight;

            dtg_calpayment.Rows[e_rowIndex].Cells[9].Value = "";
            dtg_calpayment.Rows[e_rowIndex].Cells[10].Value = "";
            dtg_calpayment.Rows[e_rowIndex].Cells[11].Value = "";
            //dtg_calpayment.Rows[e_rowIndex].Cells[13].Value = "";
            dtg_calpayment.Rows[e_rowIndex].Cells[14].Value = "";
            dtg_calpayment.Rows[e_rowIndex].Cells[15].Value = "";
            dtg_calpayment.Rows[e_rowIndex].Cells[16].Value = "";
            dtg_calpayment.Rows[e_rowIndex].Cells[17].Value = "";
            dtg_calpayment.Rows[e_rowIndex].Cells[18].Value = "";                                                           
            
            //con.Open();
         
            string Table = "";
         
                try
                {
                    //if (con.State == ConnectionState.Open)
                    //{
                    //    con.Close();
                    //}
                                       
                    //con.Open();

                    Table = "เปลี่ยนกลุ่มผู้ขาย";

                    VendorCode = dtg_calpayment.Rows[e_rowIndex].Cells[4].Value.ToString().Trim();

                Check_coutVendor();

                if (count_VendorGroup == 1)
                {
                    con.Open();
                    string sql1 = "Select [PriceFac]  From  [dbo].[V_CalPayment_VenGroup] Where [Vendor_No]='" + dtg_calpayment.Rows[e_rowIndex].Cells[4].Value.ToString().Trim() + "' AND [ProductID]='" + dtg_calpayment.Rows[e_rowIndex].Cells[2].Value.ToString().Trim() + "' AND [VendorGPay]=" + ID_VendorGPay + " ";
                    SqlCommand CM1 = new SqlCommand(sql1, con);
                    SqlDataReader DR1 = CM1.ExecuteReader();
                    DR1.Read();
                    {                     
                        dtg_calpayment.Rows[e_rowIndex].Cells[13].Value = DR1["PriceFac"].ToString();
                    }
                    con.Close();
                }

                else
                {
                    dtg_calpayment.Rows[e_rowIndex].Cells[6].Value = "#N/A";
                    dtg_calpayment.Rows[e_rowIndex].Cells[22].Value = "กลุ่ม/โควต้า >2";
                    count_VendorGroup = 0;
                }


                int LabID = 0;    //เก็บค่าประเภท การวิเคราะห์
                    string DisctPrice;
                    //// เก็บค่า ว่าจะให้ตัด เป็นราคาเงิน หรือ ตัดเป็นน้ำหนัก
                    //    0 = หักเป็นจำนวนเงิน
                    //    1 = หักเป็นน้ำหนัก

                    int LabtypeID = 0;
                    //เก็บค่า ว่าบันทึกที่ตาราง Visual หรือ ตาราง Lab
                    // 1= เข็คค่าที่ตาราง Lab
                    // 2= เช็คที่ตาราง Visual


                    decimal LabValue = 0;   //เก็บค่าบันทึกจากตาราง V_VisualLog
                    decimal Sum_Visual_BF = 0; //เก็บค่าผลรวมของ ก่อนคำนวนผลสุดท้าย
                    decimal Sum_Visual_AF = 0; //เก็บค่าผลรวมของ ผลสุดท้ายแต่ละรายการวิเคราะห์
                    string LabName;
    
                    con.Open();  
                    string sql3 = "Select * From  [dbo].[V_VisualLog] Where [TicketCodeIn]='" + dtg_calpayment.Rows[e_rowIndex].Cells[0].Value.ToString().Trim() + "'";

                    SqlCommand CM3 = new SqlCommand(sql3, con);
                    SqlDataReader DR3 = CM3.ExecuteReader();
                    while (DR3.Read())
                    {
                        LabID = Convert.ToInt16(DR3["LabID"].ToString());
                        LabtypeID = Convert.ToInt16(DR3["LabtypeID"].ToString());  //เช็ควว่า จะตัด ที่ตารางเกณฑ์ไหน
                        LabValue = Convert.ToDecimal(DR3["LabValue"].ToString());
                        LabName = DR3["LabName"].ToString();

                        DisctPrice = DR3["DisctPrice"].ToString();

                        //Sum_Visual_BF = 0;
                        //Sum_Visual_AF = 0;

                        if (con1.State == ConnectionState.Open) { con1.Close(); } /* con1.Open();*/

                        //DisctPrice   -> หักราคา หรือหัก นน.  
                        //-  = 0  หักน้ำหนัก
                        //  =  1 หักราคา

                        //LabtypeID    -> ดึงเกณฑ์วิเคราะห์ จาก table
                        //  =   1   ดึงข้อมูลเประเภทเครื่องมือ  Table Lab
                        //   =   2 ดึงข้อมูฃประเภทกายภาพ Table Visual

                        try
                        {
                            //if (DisctPrice == 0)
                            //{

                            //---------------- เช็ค ข้อมูล ว่าค่าอยู่ Table ไหน ถ้าค่า = 1 คือค่าของ Visual WH อยู่ที่ Lab ของ SP
                            string id_CheckTable;
                            con1.Open();
                            string sql100 = "Select [Dilldata]  From  [dbo].[TB_LabName] Where [LabName]='" + LabName + "' AND [ProductID]='" + dtg_calpayment.Rows[e_rowIndex].Cells[2].Value.ToString().Trim() + "'";
                            SqlCommand CM100 = new SqlCommand(sql100, con1);
                            SqlDataReader DR100 = CM100.ExecuteReader();
                            DR100.Read();
                            {
                                id_CheckTable = DR100["Dilldata"].ToString();
                            }
                        DR100.Close();
                        con1.Close();

                            decimal Visual_min = 0;
                            decimal Visual_max = 0;

                            if (LabtypeID == 1) //ดึงข้อมูลจาก การบันทึกผู้วิเคราะห์แบบใช้เครื่องมือ
                            {
                                // { Sum_Visual_BF += Convert.ToDecimal(DR3["LabValue"].ToString()); }  //เก็บค่ารวมน้ำหนักที่เป็นประเภทน้ำนหัก

                                Table = "เงื่อนไขการจ่าย-SP";  // % แป้ง
                                string sql2 = "";
                                string sql5 = "";

                                if (DisctPrice == "False") //เก็บค่า Visual
                                {
                                    Sum_Visual_BF += Convert.ToDecimal(DR3["LabValue"].ToString());
                                }

                                sql2 = "Select Top(1)[ValueSP] From [dbo].[V_CalPayment_Lab] Where [MinSP] <= " + LabValue + " AND [VendorGroupID]='" + dtg_calpayment.Rows[e_rowIndex].Cells[6].Value.ToString().Trim() + "' AND [ProductID]='" + dtg_calpayment.Rows[e_rowIndex].Cells[2].Value.ToString().Trim() + "' AND [LabID]=" + LabID + " Order by [MinSP] desc ";


                                sql5 = "Select Top(1)[ValueSP] From [dbo].[V_CalPayment_Lab] Where [MaxSP] >= " + LabValue + " AND [VendorGroupID]='" + dtg_calpayment.Rows[e_rowIndex].Cells[6].Value.ToString().Trim() + "' AND [ProductID]='" + dtg_calpayment.Rows[e_rowIndex].Cells[2].Value.ToString().Trim() + "'  AND [LabID]=" + LabID + " Order by [MaxSP] ";

                            try
                            {
                                con1.Open();
                                SqlCommand CM2 = new SqlCommand(sql2, con1);
                                SqlDataReader DR2 = CM2.ExecuteReader();
                                DR2.Read();
                                {
                                    Visual_min = Convert.ToDecimal(DR2["ValueSP"].ToString());
                                }
                                DR2.Close();
                                con1.Close();
                            }
                            catch { Visual_min = 0; con1.Close(); }

                            try
                            {
                                con1.Open();
                                SqlCommand CM5 = new SqlCommand(sql5, con1);
                                SqlDataReader DR5 = CM5.ExecuteReader();
                                DR5.Read();
                                {
                                    Visual_max = Convert.ToDecimal(DR5["ValueSP"].ToString());
                                }
                                DR5.Close();
                                con1.Close();
                            }
                            catch { Visual_max = 0; con1.Close(); }

                            if (LabName != "แป้ง")
                            {
                                if (Visual_min == Visual_max)
                                {                                    
                                        Sum_Visual_AF += Visual_min;                              
                                }
                                else
                                {
                                    Sum_Visual_AF += Visual_max;
                                }
                            }

                            else
                            {
                                decimal strach = 0;

                                if (dtg_calpayment.Rows[e_rowIndex].Cells[13].Value.ToString().Trim() != "")
                                { strach = Convert.ToDecimal(dtg_calpayment.Rows[e_rowIndex].Cells[13].Value.ToString().Trim().ToString()); }

                                dtg_calpayment.Rows[e_rowIndex].Cells[13].Value = strach + (Visual_max);
                                //Visual_max = Visual_max

                            }
                            }
                            
                            if (LabtypeID == 2)  //การบันทึกผู้วิเคราะห์แบบกายภาพ                    
                            {

                                //if (dtg_calpayment.Rows[i].Cells[0].Value.ToString().Trim() == "640406-0006")
                                //{
                                //    string test = "";
                                //}

                                Table = "เงื่อนไขตัดน้ำหนัก-SP";


                                decimal visual_min = 0;
                                decimal visual_max = 0;

                            if (id_CheckTable == "False")  //dill Data Fail
                            {
                                con1.Open();
                                string sql40 = "SELECT Top(1) [ValueSP] FROM [dbo].[V_CalPayment_Visual] WHere [LabID]='" + LabID + "' AND [ValueWH] >=" + LabValue + " AND [VendorGroupID]='" + dtg_calpayment.Rows[e_rowIndex].Cells[6].Value.ToString().Trim() + "' AND [StatusSP]=1 Order by [ValueWH]";
                                SqlCommand CM40 = new SqlCommand(sql40, con1);
                                SqlDataReader DR40 = CM40.ExecuteReader();
                                DR40.Read();
                                {
                                    visual_max = Convert.ToDecimal(DR40["ValueSP"].ToString());
                                }
                                DR40.Close();
                                con1.Close();

                                if (visual_min == visual_max) { Sum_Visual_AF += visual_min; }
                                else { Sum_Visual_AF += visual_max; }
                            }

                            else
                            {
                                con1.Open();
                                string sql40 = "SELECT Top(1) [ValueSP] FROM [dbo].[V_CalPayment_Lab] WHere [LabName]='" + LabName + "' AND[MinSP] <=" + LabValue + " AND [VendorGroupID]='" + dtg_calpayment.Rows[e_rowIndex].Cells[6].Value.ToString().Trim() + "' AND [ProductID]='" + dtg_calpayment.Rows[e_rowIndex].Cells[2].Value.ToString().Trim() + "' AND [StatusSP]=1 Order by [MinSP] Desc";
                                SqlCommand CM40 = new SqlCommand(sql40, con1);
                                SqlDataReader DR40 = CM40.ExecuteReader();
                                DR40.Read();
                                {
                                    Visual_min = Convert.ToDecimal(DR40["ValueSP"].ToString());
                                }
                                DR40.Close();
                                con1.Close();


                                con1.Open();
                                string sql61 = "SELECT Top(1) [ValueSP] FROM [dbo].[V_CalPayment_Lab] WHere [LabName]='" + LabName + "' AND[MaxSP] >=" + LabValue + " AND [VendorGroupID]='" + dtg_calpayment.Rows[e_rowIndex].Cells[6].Value.ToString().Trim() + "' AND [ProductID]='" + dtg_calpayment.Rows[e_rowIndex].Cells[2].Value.ToString().Trim() + "' AND [StatusSP]=1 ";

                                SqlCommand CM61 = new SqlCommand(sql61, con1);
                                SqlDataReader DR61 = CM61.ExecuteReader();
                                DR61.Read();
                                {
                                    Visual_max = Convert.ToDecimal(DR61["ValueSP"].ToString());
                                }
                                DR61.Close();
                                con1.Close();

                                if (Visual_min == Visual_max) { Sum_Visual_AF += Visual_min; }
                                else { Sum_Visual_AF += Visual_max; }

                                //Sum_Visual_BF = 0;
                                //Sum_Visual_AF = 0;

                            }

                                Sum_Visual_BF += Convert.ToDecimal(DR3["LabValue"].ToString());

                                dtg_calpayment.Rows[e_rowIndex].Cells[9].Value = Sum_Visual_BF.ToString();
                                dtg_calpayment.Rows[e_rowIndex].Cells[10].Value = Sum_Visual_AF.ToString();


                            }
                        }
                        catch { dtg_calpayment.Rows[e_rowIndex].Cells[22].Value = Table; Table = ""; con1.Close(); }

                        //DisctPrice = 0;

                    }

                    con.Close();


                    //คำนวนน้ำหนักสินค้า ตามเกณฑ์ใหม่
                    double net_weight = Convert.ToDouble(dtg_calpayment.Rows[e_rowIndex].Cells[8].Value.ToString());
                    double xx = net_weight * Convert.ToDouble(dtg_calpayment.Rows[e_rowIndex].Cells[10].Value.ToString()) / 100;

                    double cc = System.Math.Floor(xx);
                    double vv = xx - cc;

                    if (vv >= 0.50)  //คำนวน น้ำหนักหัก เกินหรือเท่ากับ 0.50 ปัดขึ้น
                    {
                        xx = System.Math.Floor(xx) + 1;
                    }
                    ///Floor
                    else { xx = cc; }

                    double gross_weight = net_weight - System.Math.Round(xx);
                    dtg_calpayment.Rows[e_rowIndex].Cells[11].Value = System.Math.Round(gross_weight).ToString("##,###.##");

                    //คำนวณเงินจ่ายที่ได้จาก % แป้งแล้ว
                    StarchValue = Convert.ToDouble(dtg_calpayment.Rows[e_rowIndex].Cells[13].Value.ToString());

                    double TotalPay = gross_weight * StarchValue;

                    //หัาค่าบริการ   // service charge
                    dtg_calpayment.Rows[e_rowIndex].Cells[14].Value = "0";     //- Service Weight
                    dtg_calpayment.Rows[e_rowIndex].Cells[15].Value = "0";      // -  Service Load
                    dtg_calpayment.Rows[e_rowIndex].Cells[16].Value = "0";     // - total

                    decimal vat = 0;
                    decimal WeightPrice = 0;
                    decimal LoadPrice = 0;
                    decimal Total_Price = 0;
                    int vat_include = 0;


                    try
                    {
                        con1.Open();
                        string sql60 = "SELECT [WeightPrice],[LoadPrice],[IncludeVat],[VatUnit] FROM  [dbo].[V_Service_payment] WHere [TicketCodeIn]='" + dtg_calpayment.Rows[e_rowIndex].Cells[0].Value.ToString().Trim() + "'";
                        SqlCommand CM60 = new SqlCommand(sql60, con1);
                        SqlDataReader DR60 = CM60.ExecuteReader();
                        DR60.Read();
                        {
                            if (DR60["IncludeVat"].ToString() == "True")
                            { vat_include = 1; }

                            vat = Convert.ToDecimal(DR60["VatUnit"].ToString());
                            WeightPrice = Convert.ToDecimal(DR60["WeightPrice"].ToString());
                            LoadPrice = Convert.ToDecimal(DR60["LoadPrice"].ToString());
                        }
                        DR60.Close();
                        con1.Close();
                    }

                    catch
                    {
                        vat = 0;
                        WeightPrice = 0;
                        LoadPrice = 0;
                    }


                    decimal price_w = (WeightPrice * 100) / (100 + vat);
                    decimal price_l = (LoadPrice * 100) / (100 + vat);
                    // iNcluede Vat
                    if (vat_include == 1)
                    {
                        WeightPrice = price_w;
                        LoadPrice = price_l;
                    }

                    Total_Price = WeightPrice + LoadPrice;

                    dtg_calpayment.Rows[e_rowIndex].Cells[14].Value = WeightPrice.ToString("F");
                    dtg_calpayment.Rows[e_rowIndex].Cells[15].Value = LoadPrice.ToString("F");
                    dtg_calpayment.Rows[e_rowIndex].Cells[16].Value = Total_Price.ToString("F");

                    //TotalPay = TotalPay - Convert.ToDouble(Total_Price);   // หักค่าบริการ


                    double CheckDef = System.Math.Floor(TotalPay);
                    double Answer = TotalPay - CheckDef;

                    if (Answer >= 0.50)
                    {
                        CheckDef = CheckDef + 1;
                        dtg_calpayment.Rows[e_rowIndex].Cells[17].Value = CheckDef.ToString("##,###.##");
                    }

                    else
                    {
                        dtg_calpayment.Rows[e_rowIndex].Cells[17].Value = CheckDef.ToString("##,###.##");
                    }  
                }
                catch
                {
                    //dtg_calpayment.Rows[e_Index].Cells[16].Value = Table;
                }           
            
            try
            {               
                    if (dtg_calpayment.Rows[e_rowIndex].Cells[18].Value.ToString() != "")
                    {
                        dtg_calpayment.Rows[e_rowIndex].DefaultCellStyle.BackColor = Color.Red;
                    }        
            }
            catch { }
        }

        private void btn_simulator_Click(object sender, EventArgs e)
        {
            //Save_Simulator();
        }

        private void rdo_SelAllpay_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_SelAllpay.Checked == true)
            {
                dtp_Onlypay.Enabled = false;

                for (int i = 0; i < dtg_CalPay.RowCount; i++)
                {
                    dtg_CalPay.Rows[i].Cells[0].Value = "True";
                }
            }
        }

        private void rdo_SelOnlypay_CheckedChanged(object sender, EventArgs e)
        {
           
            if (rdo_SelOnlypay.Checked == true)
            {
                dtp_Onlypay.Enabled = true;

                for (int i = 0; i < dtg_CalPay.RowCount; i++)
                {
                    dtg_CalPay.Rows[i].Cells[0].Value = "False";
                }
            }
        }              

        private void dtp_Onlypay_CloseUp(object sender, EventArgs e)
        {            
            int x = 0;

            if (rdo_SelOnlypay.Checked == true)
            {
                for (int i = 0; i < dtg_CalPay.RowCount; i++)
                {
                    if (dtg_CalPay.Rows[i].Cells[10].Value.ToString().Trim() == dtp_Onlypay.Text.Trim() && this.dtg_CalPay.Rows[i].Cells[0].Style.BackColor != Color.Red )
                    {
                        if (dtg_CalPay.Rows[i].Cells[0].Value == "False" && x == 0)
                        {
                            dtg_CalPay.Rows[i].Cells[0].Value = "True";
                            x = 1;
                        }
                    }

                    else if (dtg_CalPay.Rows[i].Cells[0].Value == "True" && x == 0)
                    {
                        dtg_CalPay.Rows[i].Cells[0].Value = "False";
                        x = 1;
                    }
                    x = 0;                  
                }
            }
        }
        

        private void rdo_repaySome_CheckedChanged(object sender, EventArgs e)
        {       
            if (rdo_repaySome.Checked == true)
            {
                for (int i = 0; i < dtg_payHistory.RowCount; i++)
                {
                    if (this.dtg_payHistory.Rows[i].Cells[0].Style.BackColor != Color.Red)
                    {
                        if (dtg_payHistory.Rows[i].Cells[0].Value == "True")
                        {
                            dtg_payHistory.Rows[i].Cells[0].Value =null;                         
                        }
                    }                   
                }
            }
        }

        private void rdo_repayAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_repayAll.Checked == true)
            {
                for (int i = 0; i < dtg_payHistory.RowCount; i++)
                {
                    if (this.dtg_payHistory.Rows[i].Cells[0].Style.BackColor != Color.Red)
                    {
                        if (dtg_payHistory.Rows[i].Cells[0].Value == null)
                        {
                            dtg_payHistory.Rows[i].Cells[0].Value = "True";
                        }
                    }
                }
            }
        }

        private void menu_right_Opening(object sender, CancelEventArgs e)
        {

        }

        private void too_menu1_Click(object sender, EventArgs e)
        {

        }

        private void btn_exportFile_Click(object sender, EventArgs e)
        {
            if (dtg_exportFile.RowCount != 0)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook ExcelBook;
                Microsoft.Office.Interop.Excel._Worksheet ExcelSheet;

                int i = 0;
                int j = 0;

                //create object of excel
                ExcelBook = (Microsoft.Office.Interop.Excel._Workbook)ExcelApp.Workbooks.Add(1);
                ExcelSheet = (Microsoft.Office.Interop.Excel._Worksheet)ExcelBook.ActiveSheet;

                // header
                for (i = 1; i <= this.dtg_exportFile.Columns.Count; i++)
                {
                    ExcelSheet.Cells[1, i] = this.dtg_exportFile.Columns[i - 1].HeaderText;
                }

                // data
                for (i = 1; i <= this.dtg_exportFile.RowCount; i++)
                {
                    for (j = 1; j <= dtg_exportFile.Columns.Count; j++)
                    {
                        ExcelSheet.Cells[i + 1, j] = dtg_exportFile.Rows[i - 1].Cells[j - 1].Value;
                    }
                }

                ExcelApp.Visible = true;
                ExcelSheet = null;
                ExcelBook = null;
                ExcelApp = null;
            }
        }

        private void btn_importFile_Click(object sender, EventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "Text file (*.xlsx, *.xlsm, *.xltx, *.xltm)|*.xlsx;*.xlsm;*.xltx;*.xltm|CSV files (*.csv, *.tsv)|*.csv;*.tsv|XLS files (*.xls, *.xlt)|*.xls;*.xlt|XLSX files  (*.txt, *.log)|*.txt;*.log|ODS files (*.ods, *.ots)|*.ods;*.ots|HTML files (*.html, *.htm)|*.html;*.htm";

                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pathFile = openFileDialog.FileName;
                    string ExtensionFile = Path.GetExtension(openFileDialog.FileName);                                 
                }

                var workbook = ExcelFile.Load(openFileDialog.FileName);
                // From ExcelFile to DataGridView.
                DataGridViewConverter.ExportToDataGridView(workbook.Worksheets.ActiveWorksheet, this.dtg_importFile, new ExportToDataGridViewOptions() { ColumnHeaders = true });

                workbook.Save("Payment " + DateTime.Now.ToShortDateString());

                btn_calImport.Enabled = true;
            }

            catch
            {

            }

        }

        private void tabControl4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl4.SelectedIndex == 1)
            {
                dtg_payHistory.DataSource = null;
                Load_History();
                Load_Date_History();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0;  i <= 100; i++)
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

        private void btn_calImport_Click(object sender, EventArgs e)
        {
            Cal_NAV_Import();    //คำนวนเข้านาวิชั่น

            Load_Vendor();

            Load_MAP_Customer();
            Load_Summary();

            tabControl2.SelectedIndex = 2;
            tabControl4.SelectedIndex = 0;

            if (dtg_calNav.RowCount != 0)
            {
                btn_savetoTempNav.Enabled = true;
            }

        }
    }
}
