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
using System.Threading;
using System.Net;
using System.IO;

namespace Truck_Analytics
{
    public partial class F_Register : Form
    {
        public F_Register()
        {
            InitializeComponent();
        }

        int id_status = 0;
        string ProductID_DB = "";
        string ProductID_RDO = "";
        int q = 0;
        int id_truckType = 0;
        double std_price = 0.00;
        int process_id = 0;
        int id_loaddata = 0;

        //--   save log
        string Msg = "";
        string Log_NewValue = "";
        string Log_OldValue = "";
        string Weight_type = "";


        int Status_UseIN = 0;
        int Adddata_PerIN = 0;
        int Editdata_PerIN = 0;
        int Viewdata_PerIN = 0;
        int Printdata_PerIN = 0;
        int Canceldata_Per = 0;
        int ServiceID = 0;
        int Status_UseOUT = 0;
        int Status_RollBackDate = 0;

        //-------Line App
        string token = "";
        // มันเส้น   Ie8s0WfV3264pJy9cjVMpzv6UvEbm8JoqkiiXDbdXgf

        // มันสด  1xWCEcA9XiMwrLXXsH0oES8z5CGPsEzEdvL9PP7j4It


        private void Load_Permission_Register_IN()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                con.Open();
                string sql6 = "SELECT  Status_Use, Adddata_Per, Editdata_Per, Viewdata_Per, Printdata_Per,Canceldata_Per FROM  [dbo].[V_Permission] WHERE [UserID] = '" + Program.user_id + "' AND [ID_Menu]= 16 ";
                SqlCommand CM6 = new SqlCommand(sql6, con);
                SqlDataReader DR6 = CM6.ExecuteReader();

                DR6.Read();
                {
                    if (DR6["Status_Use"].ToString().Trim() == "True") { Status_UseIN = 1; }
                    if (DR6["Adddata_Per"].ToString().Trim() == "True") { Adddata_PerIN = 1; }
                    if (DR6["Editdata_Per"].ToString().Trim() == "True") { Editdata_PerIN = 1; }
                    if (DR6["Viewdata_Per"].ToString().Trim() == "True") { Viewdata_PerIN = 1; }
                    if (DR6["Printdata_Per"].ToString().Trim() == "True") { Printdata_PerIN = 1; }
                    if (DR6["Canceldata_Per"].ToString().Trim() == "True") { Canceldata_Per = 1; }
                }
                DR6.Close();
                con.Close();
            }

            catch { con.Close(); }

        }


        private void Load_Permission_Register_OUT()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                con.Open();

                string sql6 = "SELECT  Status_Use, Adddata_Per, Editdata_Per, Viewdata_Per, Printdata_Per FROM  [dbo].[V_Permission] WHERE [UserID] = '" + Program.user_id + "' AND  [ID_Menu]= 27 ";
                SqlCommand CM6 = new SqlCommand(sql6, con);
                SqlDataReader DR6 = CM6.ExecuteReader();

                DR6.Read();
                {
                    if (DR6["Status_Use"].ToString().Trim() == "True") { Status_UseOUT = 1; }
                }
                DR6.Close();
                con.Close();

                if (Status_UseOUT == 1 && Status_UseIN == 1)
                {
                    this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                    cb_registerOut.Enabled = true;
                }

                if (Status_UseIN == 0 && Status_UseOUT == 1)
                {
                    this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                    cb_registerOut.Checked = true;
                    this.Close();
                }

                if (Status_UseIN == 1 && Status_UseOUT == 0)
                {
                    this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                    cb_registerOut.Enabled = false;
                }
                //else { cb_registerOut.Enabled = false; }

            }

            catch
            {
                con.Close();
            }

        }

        private void Load_StdProduct_Price()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {               
                con.Open();
                string sql1 = "Select [Price]  From[dbo].[TB_Products] Where [ProductID]='" + ProductID_RDO + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    std_price = Convert.ToDouble(DR1["Price"].ToString());
                }
                DR1.Close();
                con.Close();
            }
            catch
            {
                con.Close();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Load_StdProduct_Price();

            if (id_status == 0 && txt_ticketno.Text.Trim() != "Ticket No" && txt_ticketno.Text.Trim() != "")
            {
                if (Adddata_PerIN == 1)
                {
                    Load_ProcessID();
                    Save_Data();
                }
                else
                {
                    MessageBox.Show("สิทธ์การเพิ่มข้อมูลไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานลงทะเบียนตั๋วเข้า)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (id_status == 1)
            {
                if (Editdata_PerIN == 1)
                {
                    Updata_Data();               
                }

                else { MessageBox.Show("สิทธ์การแก้ไขไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานลงทะเบียนตั๋วเข้า)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (Printdata_PerIN == 1)
            {
                F_Report frp = new F_Report();
                frp.Ticket_code = txt_ticketno.Text.Trim();
                frp.truckType = id_truckType;
                frp.ID_Product = ProductID_RDO;
                frp.type_job = Convert.ToInt32(txt_weighttypeNo.Text.Trim());
                frp.ShowDialog();
                Clear_Data();
                Load_TicketNo();
            }

            else {
                MessageBox.Show("สิทธ์การพิมพ์ไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานลงทะเบียนตั๋วเข้า)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Save_FollowProcess()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                con.Open();
                // Save to data base
                string date_time = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US")) + " " + DateTime.Now.ToString("HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));

                string sql = "";

                if (cb_registerOut.Checked == false)
                {
                    sql = "Insert Into [TB_FollowProcess] ([TicketCodeIn],[RegisterIn_Datetime]) Values('" + txt_ticketno.Text.Trim() + "', '" + date_time + "')";
                }

                if (cb_registerOut.Checked == true)
                {
                    sql = "Update [TB_FollowProcess] Set [RegisterOut_Datetime]= '" + date_time + "' Where [TicketCodeIn] = '" + txt_ticketno.Text.Trim() + "'";
                }

                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();
            }

            catch
            {
                con.Close();
            }

        }

        private void Save_Data()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                DialogResult dr = MessageBox.Show("คุณต้องการบันทึกข้อมูลนี้ใช่หรือไม่", "ยืนยันข้อมูล", MessageBoxButtons.YesNo,
            MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    // Save to data base
                    string date = dtp_register.Value.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US")) + " " + dtp_register.Value.ToString("HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));

                    string sql = "";

                    int SourchRawmatID = 78;
                    if (cb_SourceRawmat.Text.Trim() != "ไม่ระบุ") { SourchRawmatID = Convert.ToInt16(cb_SourceRawmat.SelectedValue.ToString()); }
                    if (txt_transportID.Text == "") { txt_transportID.Text = "1"; txt_transportName.Text = "ไม่ระบุ"; }

                    Load_Service();

                    if (txt_weighttypeNo.Text == "01" && txt_simple1.Text.Trim() != "" && ServiceID != 0) //งานซื้อ
                    {
                        con.Open();
                        sql = "Insert Into [TB_WeightData] ([TicketCodeIn],[RegisterInDate],[QueueNo],[Plate1],[WeightTypeID],[TruckTypeID],[ProductID],[Vendor_No],[SimpleCode1],[SimpleCode2],[Process_id],[ServiceID],[EmployeeID],[SourceID],[DriveName],[TransportID],[Remark2]) Values('" + txt_ticketno.Text + "', '" + date + "', '" + Convert.ToString(q + 1) + "','" + txt_plateno.Text + "', '" + txt_weighttypeNo.Text + "', " + id_truckType + ", '" + ProductID_RDO + "','" + txt_vencusNo.Text + "','" + txt_simple1.Text + "','" + txt_simple2.Text + "'," + process_id + "," + ServiceID + "," + Program.user_id + "," + SourchRawmatID + ",'" + txt_driveName.Text.Trim() + "'," + txt_transportID.Text.Trim() + ",'" + txt_remark2.Text.Trim() + "')";
                        SqlCommand CM = new SqlCommand(sql, con);
                        SqlDataReader DR = CM.ExecuteReader();
                        con.Close();

                        Save_FollowProcess();

                    }
                    else if (txt_weighttypeNo.Text == "02") //งานขาย
                    {
                        con.Open();
                        sql = "Insert Into [TB_WeightData] ([TicketCodeIn],[RegisterInDate],[QueueNo],[Plate1],[WeightTypeID],[TruckTypeID],[ProductID],[CustomerID],[SimpleCode1],[SimpleCode2],[Process_id],[ServiceID],[EmployeeID],[SourceID],[DriveName],[TransportID],[Remark2]) Values('" + txt_ticketno.Text + "', '" + date + "', '" + Convert.ToString(q + 1) + "','" + txt_plateno.Text + "', '" + txt_weighttypeNo.Text + "', " + id_truckType + ", '" + ProductID_RDO + "','" + txt_vencusNo.Text + "','" + txt_simple1.Text + "','" + txt_simple2.Text + "'," + process_id + "," + ServiceID + "," + Program.user_id + "," + SourchRawmatID + ",'" + txt_driveName.Text.Trim() + "'," + txt_transportID.Text.Trim() + ",'" + txt_remark2.Text.Trim() + "')";
                        SqlCommand CM = new SqlCommand(sql, con);
                        SqlDataReader DR = CM.ExecuteReader();
                        con.Close();

                        Save_FollowProcess();
                    }
                    

                    con.Open();
                    string sql2 = "Insert Into [TB_LabConfirmPay] ([TicketCodeIn],[Price],[PriceNet])  Values ('" + txt_ticketno.Text.Trim() + "'," + std_price + ",0)";
                    SqlCommand CM2 = new SqlCommand(sql2, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    con.Close();

                    Send_lineAlert();
                
                    q = 0;

                    Msg = "Register in on New Ticket!";

                    Log_NewValue = "TicketCodeIn =" + txt_ticketno.Text +
              "," + "RegisterInDate = " + date.ToString() +
              "," + "QueueNo = " + Convert.ToString(q + 1) +
              "," + "Plate1 = " + txt_plateno.Text +
              "," + "WeightTypeID = " + txt_weighttypeNo.Text +
              "," + "TruckTypeID = " + id_truckType.ToString() +
              "," + "ProductID = " + ProductID_RDO.ToString()  +             
              "," + "CustomerID =" + txt_vencusNo.Text +
              "," + "SimpleCode1 =" + txt_simple1.Text +
              "," + "SimpleCode2 = " + txt_simple2.Text +
              "," + "EmployeeID = " + Program.user_id +
              "," + "SourceID = " + SourchRawmatID +
              "," + "DriveName = " + txt_driveName.Text.Trim() +
              "," + "TransportID = " + txt_transportID.Text.Trim() +
              "," + "Remark2 = " + txt_remark2.Text.Trim();
                                                                                                                                                                     
                    Log_OldValue = "-";
                    Class_Log CL = new Class_Log();
                    CL.tbname = Msg;
                    CL.oldvalue = Log_OldValue;
                    CL.newvalue = Log_NewValue;
                    CL.Save_log();                                                                                                                                                                                                        
                    MessageBox.Show("บันทึกสำเร็จ!!", "รายงานการบันทึก", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                }
            }

            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.ToString(), "ข้อมูลผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Load_Service()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                ServiceID = 0;

                con.Open();
                string sql1 = "Select [ServiceID]  From[dbo].[TB_Services] Where [WeightProductID]='" + ProductID_RDO + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    ServiceID = Convert.ToInt16(DR1["ServiceID"].ToString());
                }
                DR1.Close();
                con.Close();
            }
            catch
            {
                con.Close();
                MessageBox.Show("รายการตั๋วนี้ไม่ได้ระบุประเภทรถในการบริการชั่ง โหลด หรือขึ้นลงสินค้า กรุณาติดต่อผู้ดูแลระบบงานบริการงานชั่ง", "บันทึกผิดพลาด!!!", MessageBoxButtons.OK,
        MessageBoxIcon.Information);
            }
        }

        private void Updata_Data()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                DialogResult dr = MessageBox.Show("คุณต้องการบันทึกข้อมูลนี้ใช่หรือไม่", "ยืนยันข้อมูล", MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    // Save to data base
                    string date = Program.Date_Now + ' ' + Program.Time_Now;

                    con.Open();

                    string sql = "";

                    if (txt_weighttypeNo.Text == "01")
                    {
                        if (id_truckType == 1)
                        {
                            sql = "Update [TB_WeightData] Set [Plate1]='" + txt_plateno.Text + "',[WeightTypeID]='" + txt_weighttypeNo.Text + "',[TruckTypeID]= " + id_truckType + ",[Vendor_No]='" + txt_vencusNo.Text + "',[SourceID] =" + cb_SourceRawmat.SelectedValue.ToString().Trim() + ",[DriveName]='" + txt_driveName.Text.Trim() + "',[ProductID] ='" + ProductID_RDO + "',[SimpleCode1]='" + txt_simple1.Text.Trim() + "',[SimpleCode2]= '',[TransportID]=" + txt_transportID.Text.Trim() + ",[Remark2]='" + txt_remark2.Text.Trim() + "' WHERE [TicketCodeIn] ='" + txt_ticketno.Text + "'";
                        }
                        if (id_truckType == 2)
                        {
                            sql = "Update [TB_WeightData] Set [Plate1]='" + txt_plateno.Text + "',[WeightTypeID]='" + txt_weighttypeNo.Text + "',[TruckTypeID]= " + id_truckType + ",[Vendor_No]='" + txt_vencusNo.Text + "',[SourceID] =" + cb_SourceRawmat.SelectedValue.ToString().Trim() + ",[DriveName]='" + txt_driveName.Text.Trim() + "',[ProductID] ='" + ProductID_RDO + "',[SimpleCode1]='" + txt_simple1.Text.Trim() + "',[SimpleCode2]= '',[TransportID]=" + txt_transportID.Text.Trim() + ",[Remark2]='" + txt_remark2.Text.Trim() + "' WHERE [TicketCodeIn] ='" + txt_ticketno.Text + "'";
                        }
                    }

                    else {

                        sql = "Update [TB_WeightData] Set [Plate1]='" + txt_plateno.Text + "',[WeightTypeID]='" + txt_weighttypeNo.Text + "',[TruckTypeID]= " + id_truckType + ",[CustomerID]='" + txt_vencusNo.Text + "',[SourceID] =" + cb_SourceRawmat.SelectedValue.ToString().Trim() + ",[DriveName]='" + txt_driveName.Text.Trim() + "',[TransportID]=" + txt_transportID.Text.Trim() + ",[Remark2]='" + txt_remark2.Text.Trim() + "' WHERE [TicketCodeIn] ='" + txt_ticketno.Text + "'";
                    }

                    SqlCommand CM2 = new SqlCommand(sql, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    con.Close();


                    con.Open();
                    string sql3 = "Update [TB_LabConfirmPay] Set [Price] =" + std_price + " Where [TicketCodeIn] ='" + txt_ticketno.Text.Trim() + "'";
                    SqlCommand CM3 = new SqlCommand(sql3, con);
                    SqlDataReader DR3 = CM3.ExecuteReader();
                    con.Close();
                                                                                                                                    
                    Msg = "Updte Ticket! " + txt_ticketno.Text.Trim();

                    Log_NewValue = "ProductID =" + ProductID_RDO +
              "," + "Plate1 = " + txt_plateno.Text +
              "," + "TruckTypeID = " + txt_weighttypeNo.Text +              
              "," + "Vendor_No = " + txt_vencusNo.ToString() +                     
              "," + "SourceID =" + cb_SourceRawmat.SelectedValue.ToString().Trim() +
              "," + "DriveName =" + txt_driveName.Text.Trim() +           
              "," + "TransportID = " + txt_transportID.Text.Trim() +
              "," + "Where TicketCodeIn = " + txt_ticketno.Text.Trim();
                                                                                                                                                                                             
                    Log_OldValue = "-";
                    Class_Log CL = new Class_Log();
                    CL.tbname = Msg;
                    CL.oldvalue = Log_OldValue;
                    CL.newvalue = Log_NewValue;
                    CL.Save_log();

                    MessageBox.Show("ปรับปรุงสำเร็จ!!", "รายงานการบันทึก", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                }
            }

            catch
            {
                con.Close();
                MessageBox.Show("ข้อมูลเลขที่ชั่งซ้ำ กรุณาตรวจสอบเลขที่ชั่งอีกครั้ง", "ข้อมูลผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Clear_Data()
        {
            txt_plateno.Clear();
            txt_weighttypeNo.Clear();
            txt_vencusNo.Clear();
            txt_driveName.Clear();
            rdo_casawaChip.Checked = false;
            rdo_casawaRoot.Checked = false;
            rdo_etc.Checked = false;
            rdo_ethanol.Checked = false;
            rdo_truckdouble.Checked = false;
            rdo_trucksingle.Checked = false;
            rdo_woodShip.Checked = false;
            txt_etcidProduct.Clear();
            txt_tecNameproduct.Text = "";
            txt_weighttypeName.Text = "";
            txt_vencusName.Text = "";
            txt_simple1.Clear();
            txt_simple2.Clear();
            txt_transportID.Clear();
            txt_transportName.Clear();
            txt_remark2.Clear();

            ProductID_DB = "";
            q = 0;
            id_truckType = 0;
            std_price = 0.00;
            process_id = 0;            
            txt_queNo.Text = "-";
            id_loaddata = 0;
            //if (cb_registerOut.Checked == false)
            //{
            //    Load_TicketNo();
            //}
            //else {

            //    txt_ticketno.Clear();
            //    F_Dialog fd = new F_Dialog();
            //    fd.ShowDialog();

            //    txt_ticketno.Text = fd.QR_code;

            //    Update_RegisterOut();
            //}
        }

        //private void Load_PriceSTD()
        //{
        //    try
        //    {
        //        SqlConnection con = new SqlConnection(Program.pathdb_Weight);
        //        con.ConnectionString = Program.pathdb_Weight;
        //        SqlDataAdapter dtAdapter = new SqlDataAdapter();
        //        con.Open();

        //        string sql1 = "Select [Rate]  From[dbo].[TB_PriceSTD] Where ItemNo='" + ProductID + "'";
        //        SqlCommand CM1 = new SqlCommand(sql1, con);
        //        SqlDataReader DR1 = CM1.ExecuteReader();

        //        DR1.Read();
        //        {
        //            std_price = Convert.ToDouble(DR1["Rate"].ToString());
        //        }
        //        DR1.Close();
        //        con.Close();
        //    }

        //    catch {
        //        MessageBox.Show("มีความผิดพลาดเรื่องข้อมูลราคาสินค้าไม่ได้ตั้งค่า กรุณาเข้าไปตั้งค่าราคาสินค้าเริ่มต้น?","ข้อมูลผิดพลาด!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
        //    }
        //}

        private void Load_ProcessID()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                con.Open();

                string sql1 = "Select Min([proc_no])as minprocess From [dbo].[TB_Process] Where [item_no]='" + ProductID_RDO + "' AND [proc_type]='R'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    process_id = Convert.ToInt16(DR1["minprocess"].ToString());
                }
                DR1.Close();
                con.Close();     

                process_id += 1;

                //Step Check Over Process
                int C_count = 0;
                try
                {
                    con.Open();
                    string sql2 = "Select Count([proc_no]) AS 'C_ID' From [dbo].[V_OverStep] Where [item_no]='" + ProductID_RDO + "' AND [venOrCus_No]='" + txt_vencusNo.Text.Trim() + "'  AND [proc_no]=" + process_id + " AND [OverPro_Status]=1";
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
                    process_id += 1;
                }


            }
            catch
            {
                con.Close();
                MessageBox.Show("มีความผิดพลาดเรื่องกระบวนการทำงานของแต่ละสถานี กรุณาเข้าไปตั้งค่าขั้นตอนการทำงานของสินค้า?", "ข้อมูลผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("คุณต้องการออกจากหน้างานนี้ใช่หรือไม่?",
    "ปิดหน้าโปรแกรม",
    MessageBoxButtons.YesNo);

            if (result1 == DialogResult.Yes)
            {
                //MessageBox.Show("You answered yes, yes and no.");
                this.Close();
            }
        }

        private void F_Register_Load(object sender, EventArgs e)
        {
            Load_QueToday();
            cb_registerOut.Enabled = true;
            Load_Permission_Register_IN();
            Load_Permission_Register_OUT();
            Load_TicketNo();
            Load_SourceRawmat();
            Load_RegiterSetup();

            //lbl_userid.Text = "Welcome back K': " + Program.user_name;
            tool_DBName.Text = "Database Name: " + Program.DB_Name;

            if (Program.DB_Name != "SapthipNewDB")
            {
                panel2.BackColor = Color.Crimson;
            }

            dt_now = DateTime.Now.ToShortDateString();

            timer1.Enabled = true;
        }

        private void Send_lineAlert()
        {
            string msg1 = "รายงานการลงทะเบียนตั๋วใหม่" + Environment.NewLine + " บัตรชั่งเลขที่: " + txt_ticketno.Text.Trim() + " คิวที่: " + txt_queNo.Text.Trim() + " สินค้า: " + ProductName + " ทะเบียนรถ: " + txt_plateno.Text.Trim() + Environment.NewLine + " ประเภทชั่ง: " + txt_weighttypeName.Text.Trim() + " ชือผู้ขาย/ผู้ซื้อ: " + txt_vencusName.Text.Trim() + " แหล่งที่มาวัตถุดิบ: " + cb_SourceRawmat.Text.Trim() + "";

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql = "SELECT [AL_lineNameToken] FROM [dbo].[V_TokenLine] WHERE [ID_processType]='R' AND [ProductID]='" + ProductID_RDO+ "' AND [AL_lineStatus]=1";
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

        private void Load_RegiterSetup()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                con.Open();

                string sql6 = "SELECT [Reg_BackDate],[Reg_SearchHistory] FROM [dbo].[TB_RegisterSetup]";
                SqlCommand CM6 = new SqlCommand(sql6, con);
                SqlDataReader DR6 = CM6.ExecuteReader();

                DR6.Read();
                {
                    if (DR6["Reg_BackDate"].ToString().Trim() == "True")
                    {
                        Status_RollBackDate = 1;
                    }

                    if (DR6["Reg_SearchHistory"].ToString().Trim() == "True")
                    {
                        txt_SearchName.Enabled = true;
                        tg_btnSearchHistory.Enabled = true;
                    }
                    else { txt_SearchName.Enabled = false; tg_btnSearchHistory.Enabled = false; }

                }
                DR6.Close();
                con.Close();

            }
            catch { con.Close(); }
        }

        private void InitializeComboBox()
        {
            multi_cbSearch.Clear();
            multi_cbSearch.SourceDataString = new string[6] { "TicketCodeIn", "Plate1", "DriveName", "TruckTypeName", "ProductName", "Name" };
            multi_cbSearch.ColumnWidth = new string[6] { "80", "80", "110", "60", "60", "140" };
            multi_cbSearch.DataSource = GetDataSource();

            btn_clearSearch.Text = "OK"; btn_clearSearch.ForeColor = Color.Blue;
        }

        private DataTable GetDataSource()
        {
            DataTable dtSource = new DataTable();

            DataColumn dt_TicketCodeIn = new DataColumn("TicketCodeIn");
            dt_TicketCodeIn.DataType = System.Type.GetType("System.String");
            dtSource.Columns.Add(dt_TicketCodeIn);

            DataColumn dt_Plate = new DataColumn("Plate1");
            dt_Plate.DataType = System.Type.GetType("System.String");
            dtSource.Columns.Add(dt_Plate);

            DataColumn dt_DriveName = new DataColumn("DriveName");
            dt_DriveName.DataType = System.Type.GetType("System.String");
            dtSource.Columns.Add(dt_DriveName);

            DataColumn dt_TruckType = new DataColumn("TruckTypeName");
            dt_TruckType.DataType = System.Type.GetType("System.String");
            dtSource.Columns.Add(dt_TruckType);

            DataColumn dt_ProductName = new DataColumn("ProductName");
            dt_ProductName.DataType = System.Type.GetType("System.String");
            dtSource.Columns.Add(dt_ProductName);

            DataColumn dt_VenName = new DataColumn("Name");
            dt_VenName.DataType = System.Type.GetType("System.String");
            dtSource.Columns.Add(dt_VenName);

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql = "";

            if (tg_btnSearchHistory.Checked == false)
            {
                sql = "SELECT Trim([TicketCodeIn])  AS 'TicketCodeIn',Trim([Plate1]) AS 'Plate1',Trim([DriveName]) AS 'DriveName',Trim ([TruckTypeName]) AS 'TruckTypeName',Trim([ProductName]) AS 'ProductName',Trim([NameVen]) AS 'NameVen' FROM  [dbo].[V_WeightData] Where [NameVen] like '%" + txt_SearchName.Text.Trim() + "%' and [DriveName] <> '' Group by[Plate1],[TruckTypeName],[ProductName],[NameVen],[DriveName], TicketCodeIn Order by TicketCodeIn";
            }

            else
            {
                sql = "SELECT Trim([TicketCodeIn])  AS 'TicketCodeIn',Trim([Plate1]) AS 'Plate1',Trim([DriveName]) AS 'DriveName',Trim ([TruckTypeName]) AS 'TruckTypeName',Trim([ProductName]) AS 'ProductName',Trim([CustomerName]) AS 'CustomerName' FROM  [dbo].[V_WeightData_Sale] Where [CustomerName] like '%" + txt_SearchName.Text.Trim() + "%' and [DriveName] <> '' Group by[Plate1],[TruckTypeName],[ProductName],[CustomerName],[DriveName], TicketCodeIn Order by TicketCodeIn";

            }

            SqlCommand CM1 = new SqlCommand(sql, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            while (DR1.Read())
            {

                //DR1["maxcode"].ToString()

                //Add rows
                DataRow row = dtSource.NewRow();

                row[dt_TicketCodeIn] = DR1["TicketCodeIn"].ToString();
                row[dt_Plate] = DR1["Plate1"].ToString();
                row[dt_DriveName] = DR1["DriveName"].ToString();
                row[dt_TruckType] = DR1["TruckTypeName"].ToString();
                row[dt_ProductName] = DR1["ProductName"].ToString();

                if (tg_btnSearchHistory.Checked == false)
                {
                    row[dt_VenName] = DR1["NameVen"].ToString();
                }
                else { row[dt_VenName] = DR1["CustomerName"].ToString(); }

                dtSource.Rows.Add(row);
            }
            DR1.Close();
            con.Close();


            return dtSource;
        }
        private void Load_SourceRawmat()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT [SourceID],[SourceName]  FROM  [dbo].[TB_SourceRawmat]  Where SourceID <> 78  Order by SourceName ", con);
                DataSet ds = new DataSet();
                //ds.Clear();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                //Load product tab weight scale Setup
                cb_SourceRawmat.DataSource = ds.Tables[0];
                cb_SourceRawmat.DisplayMember = "SourceName";
                cb_SourceRawmat.ValueMember = "SourceID";
                con.Close();
            }
            catch { con.Close(); }
        }

        private void Load_TicketNo()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                con.Open();

                //string dt = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("th-TH"));   // select to sql
                //DateTime dt_c = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")));   // convert date       
                //string dt_s = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));   // select to sql

                string dt = dtp_register.Value.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("th-TH"));   // select to sql
                DateTime dt_c = Convert.ToDateTime(dtp_register.Value.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("en-US")));   // convert date       
                string dt_s = dtp_register.Value.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));   // select to sql

                int year = Convert.ToInt32(dt_c.ToString("yyyy")) + 543;
                string date_c = year.ToString() + "/" + dt_c.ToString("MM/dd");

                CultureInfo culture = new CultureInfo("en-US");
                DateTime tempDate = Convert.ToDateTime(date_c, culture);
                string date = tempDate.ToString("yyMMdd") + "-";

                txt_queType.Text = "IN";
                txt_queType.ForeColor = Color.Green;

                //txt_queNo.ForeColor = Color.ForestGreen;

                txt_ticketno.Clear();

                //string date = year_s.ToString() + DateTime.Now.ToString("MMdd");
                //DateTime date_c = Convert.ToDateTime(date);

                string sql1 = "Select max([TicketCodeIn])as maxcode From[dbo].[TB_WeightData] Where RegisterInDate BETWEEN {ts'" + dt_s.ToString() + " 00:00:00'} AND  {ts'" + dt_s.ToString() + " 23:59:59'} AND [Automode] = 0";

                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    // count = Convert.ToInt16(DR1["countidqua"].ToString().Trim());
                    if (DR1["maxcode"].ToString() != "")
                    {
                        //MessageBox.Show(DR1["MaxQ"].ToString());
                        txt_ticketno.Text = DR1["maxcode"].ToString();
                    }
                }
                DR1.Close();
                con.Close();

                if (txt_ticketno.Text == "")
                {
                    date += "0001";
                    txt_ticketno.Text = date;
                }

                else
                {
                    txt_ticketno.Select(7, 10);
                    int no = Convert.ToInt16(txt_ticketno.SelectedText);
                    txt_ticketno.Text = no.ToString();

                    if (txt_ticketno.Text.Length == 1 || txt_ticketno.Text == "9")
                    {
                        if (txt_ticketno.Text == "9")
                        {
                            date += "00" + Convert.ToString(no + 1);
                        }
                        else { date += "000" + Convert.ToString(no + 1); }
                    }

                    else if (txt_ticketno.Text.Length == 2 || txt_ticketno.Text == "99")
                    {
                        if (txt_ticketno.Text == "99")
                        {
                            date += "0" + Convert.ToString(no + 1);
                        }
                        else { date += "00" + Convert.ToString(no + 1); }
                    }


                    else if (txt_ticketno.Text.Length == 3 || txt_ticketno.Text == "999")
                    {
                        if (txt_ticketno.Text == "999")
                        {
                            date += "" + Convert.ToString(no + 1);
                        }
                        else { date += "0" + Convert.ToString(no + 1); }

                    }

                    if (txt_ticketno.Text.Length == 4)
                    {
                        date += Convert.ToString(no + 1);
                    }

                    //date += Convert.ToString(no);
                    txt_ticketno.Text = date;
                    id_status = 0;
                }

                if (txt_ticketno.Text == "Ticket No")
                {
                    MessageBox.Show("การสร้างเลขที่บัตรชั่งพบความผิดพลาด ไม่สามารถสร้างเลขที่บัตรชั่งได้ กรุณาตรวจรูปแบบวันที่ของวิโดว์ ดังนี้" + Environment.NewLine + "1.Region = 'Thailand'" + Environment.NewLine + "2.Regional format = 'English (United States)'" + Environment.NewLine + "3.Format Datae = 'English', Short date = 'dd/MM/yyyy' ", "รายงานความผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btn_save.Enabled = false;
                }      

            }
            catch {

                MessageBox.Show("การสร้างเลขที่บัตรชั่งพบความผิดพลาด ไม่สามารถสร้างเลขที่บัตรชั่งได้ กรุณาตรวจรูปแบบวันที่ของวิโดว์ ดังนี้" + Environment.NewLine + "1.Region = 'Thailand'" + Environment.NewLine + "2.Regional format = 'English (United States)'" + Environment.NewLine + "3.Format Datae = 'English', Short date = 'dd/MM/yyyy' ", "รายงานความผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_save.Enabled = false;

                con.Close();
            }

        }

        private void Load_QueToday()
        {
            if (txt_weighttypeNo.Text != "")
            {
                //RegisterInDate
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

                try
                {
                    con.Open();

                    //string dt = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
                    //string dt = Program.Date_Now;
                    string dt = dtp_register.Value.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));   // select to sql

                    txt_queNo.Text = "-";
                    q = 0;

                    //AND [WeightTypeID] = '02'


                    string sql1 = "";
                   

                    if (id_loaddata == 0)
                    {
                        //sql1 = "Select max([QueueNo])as MaxQ From [dbo].[TB_WeightData] Where RegisterInDate BETWEEN {ts'" + dt.ToString() + " 00:00:00'} AND  {ts'" + dt.ToString() + " 23:59:59'} AND [ProductID]='" + ProductID_RDO + "' AND [WeightTypeID]='" + txt_weighttypeNo.Text.Trim() + "' ";

                        sql1 = "Select max([QueueNo])as MaxQ From [dbo].[TB_WeightData] Where RegisterInDate BETWEEN {ts'" + dt.ToString() + " 00:00:00'} AND  {ts'" + dt.ToString() + " 23:59:59'} AND [ProductID]='" + ProductID_RDO + "' ";

                    }

                    if (id_loaddata == 1)
                    {
                        if (ProductID_DB == ProductID_RDO)
                        {

                            //sql1 = "Select [QueueNo] as MaxQ From [dbo].[TB_WeightData] Where [TicketCodeIn]='" + txt_ticketno.Text.Trim() + "' AND [ProductID]='" + ProductID_RDO + "' AND [WeightTypeID]='" + txt_weighttypeNo.Text.Trim() + "' ";

                            sql1 = "Select [QueueNo] as MaxQ From [dbo].[TB_WeightData] Where [TicketCodeIn]='" + txt_ticketno.Text.Trim() + "' AND [ProductID]='" + ProductID_RDO + "' ";
                        }
                        //else { sql1 = "Select max([QueueNo])as MaxQ From [dbo].[TB_WeightData] Where RegisterInDate BETWEEN {ts'" + dt.ToString() + " 00:00:00'} AND  {ts'" + dt.ToString() + " 23:59:59'} AND [ProductID]='" + ProductID + "' AND [WeightTypeID]='" + txt_weighttypeNo.Text.Trim() + "' "; }
                        else
                        {
                            sql1 = "Select max([QueueNo])as MaxQ From [dbo].[TB_WeightData] Where RegisterInDate BETWEEN {ts'" + dt.ToString() + " 00:00:00'} AND  {ts'" + dt.ToString() + " 23:59:59'} AND [ProductID]='" + ProductID_RDO + "' ";

                            //sql1 = "Select max([QueueNo])as MaxQ From [dbo].[TB_WeightData] Where RegisterInDate BETWEEN {ts'" + dt.ToString() + " 00:00:00'} AND  {ts'" + dt.ToString() + " 23:59:59'} AND [ProductID]='" + ProductID_RDO + "' AND [WeightTypeID]='" + txt_weighttypeNo.Text.Trim() + "' ";
                        }
                    }

                    SqlCommand CM1 = new SqlCommand(sql1, con);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    {
                        if (id_loaddata == 0 || ProductID_DB != ProductID_RDO)
                        {
                            if (DR1["MaxQ"].ToString() != "")
                            {
                                //MessageBox.Show(DR1["MaxQ"].ToString());
                                q = Convert.ToInt16(DR1["MaxQ"].ToString());
                                txt_queNo.Text = Convert.ToString(q + 1);
                                gb_trucktrype.Enabled = true;
                            }
                        }
                        else { txt_queNo.Text = DR1["MaxQ"].ToString(); }
                    }
                    DR1.Close();
                    con.Close();
                }

                catch { con.Close(); }

                if (txt_queNo.Text == "-" || txt_queNo.Text == "")
                {
                    txt_queNo.Text = "1"; gb_trucktrype.Enabled = true;
                }
            }
        }
       

        private void rdo_casawaRoot_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_casawaRoot.Checked == true && txt_weighttypeNo.Text != "")
            {              
                ProductID_RDO = "RM-004";  
                txt_etcidProduct.Clear();
                txt_tecNameproduct.Text = "";
                Load_QueToday();
                rdo_trucksingle.Checked = false;
                rdo_truckdouble.Checked = false;
                txt_simple1.Clear();
                txt_simple2.Clear();
                gb_trucktrype.Enabled = true;
            }
        }

        private void rdo_casawaShip_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_casawaChip.Checked == true  && txt_weighttypeNo.Text !="")
            {               
                ProductID_RDO = "RM-001";   
                txt_etcidProduct.Clear();
                txt_tecNameproduct.Text = "";
                Load_QueToday();
                rdo_trucksingle.Checked = false;
                rdo_truckdouble.Checked = false;
                txt_simple1.Clear();
                txt_simple2.Clear();
                gb_trucktrype.Enabled = true;
            }

        }

        private void rdo_woodShip_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_woodShip.Checked == true  && txt_weighttypeNo.Text != "")
            {
                ProductID_RDO = "ST0803-002";           
                txt_etcidProduct.Clear();
                txt_tecNameproduct.Text = "";
                Load_QueToday();
                rdo_trucksingle.Checked = false;
                rdo_truckdouble.Checked = false;
                txt_simple1.Clear();
                txt_simple2.Clear();
                gb_trucktrype.Enabled = true;
            }
        }

        private void rdo_ethanol_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_ethanol.Checked == true  && txt_weighttypeNo.Text != "")
            {                
                ProductID_RDO = "FG-001";
                txt_etcidProduct.Clear();
                txt_tecNameproduct.Text = "";
                Load_QueToday();
                rdo_trucksingle.Checked = false;
                rdo_truckdouble.Checked = false;
                txt_simple1.Clear();
                txt_simple2.Clear();
                gb_trucktrype.Enabled = true;

            }

        }

        private void btn_etcidproductFind_Click(object sender, EventArgs e)
        {
            if (txt_weighttypeNo.Text != "")
            {
                rdo_trucksingle.Checked = false;
                rdo_truckdouble.Checked = false;
                txt_simple1.Clear();
                txt_simple2.Clear();

                rdo_etc.Checked = true;
                F_Search fnd = new F_Search();
                fnd.id_findType = 1;
                fnd.ShowDialog();

                if (fnd.id_value != "")
                {
                    txt_etcidProduct.Text = fnd.id_value.Trim();

                        ProductID_RDO = fnd.id_value;
                        txt_tecNameproduct.Text = fnd.name_value.Trim();

                        Load_QueToday();
                        gb_trucktrype.Enabled = true;
                    
                }
            }

            else { MessageBox.Show("กรุณาเลือกประเภทงาน ซื้อ-ขายสินค้าก่อน!!!","รายงานความผิดพลาด",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void btn_trucktypeFind_Click(object sender, EventArgs e)
        {
            F_Search fnd = new F_Search();
            fnd.id_findType = 2;
            fnd.ShowDialog();

            if (fnd.id_value != "")
            {
                id_loaddata = 0;

                if (txt_weighttypeNo.Text != fnd.id_value)
                {
                    txt_weighttypeNo.Text = fnd.id_value;
                    txt_weighttypeName.Text = fnd.name_value;

                    if (txt_weighttypeNo.Text == "01") // Vendor  เราซื้อ
                    {
                        label5.Text = "ผู้ขาย"; cb_SourceRawmat.Enabled = true;
                        txt_transportID.Text = "1";  txt_transportName.Text = "ไม่ระบุ";
                    }

                    else if (txt_weighttypeNo.Text == "02") // Custor เราขาย
                    {
                        label5.Text = "ผู้ซื้อ"; cb_SourceRawmat.Enabled = false;cb_SourceRawmat.Text = "ไม่ระบุ";

                    }

                    else if (txt_weighttypeNo.Text == "03")
                    { label5.Text = "ชั่งบัตร Auto"; cb_SourceRawmat.Enabled = false; cb_SourceRawmat.Text = "ไม่ระบุ"; }

                    else
                    { label5.Text = "ชื่อผู้ซื้อ-ขาย";  cb_SourceRawmat.Text = "ไม่ระบุ"; cb_SourceRawmat.Enabled = true; }

                    txt_vencusNo.Clear();
                    txt_vencusName.Clear();

                    rdo_casawaChip.Checked = false;
                    rdo_casawaRoot.Checked = false;
                    rdo_ethanol.Checked = false;
                    rdo_etc.Checked = false;
                    rdo_woodShip.Checked = false;
                    txt_etcidProduct.Clear();
                    txt_tecNameproduct.Clear();
                    txt_queNo.Text = "-";
                    txt_driveName.Clear();
                    txt_plateno.Clear();
                }
                
                rdo_trucksingle.Checked = false;
                rdo_truckdouble.Checked = false;
                txt_simple1.Clear();
                txt_simple2.Clear();
            }

            if (txt_weighttypeNo.Text != "")
            {
                gb_product.Enabled = true;
            }

            else { gb_product.Enabled = false; }
        }

        private void btn_vencusFind_Click(object sender, EventArgs e)
        {
            if (txt_weighttypeNo.Text != "")
            {
                F_Search fnd = new F_Search();

                if (txt_weighttypeNo.Text == "01")
                { fnd.id_findType = 3; }
                if (txt_weighttypeNo.Text == "02")
                { fnd.id_findType = 4; }
                fnd.ShowDialog();

                if (fnd.id_value != "")
                {
                    txt_vencusNo.Text = fnd.id_value;
                    txt_vencusName.Text = fnd.name_value;
                }
            }

            else
            {
                MessageBox.Show("กรุณาเลือกประเภทชั่งก่อน", "ค้นหาผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdo_trucksingle_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_trucksingle.Checked == true)
            {
                id_truckType = 1;
            }
                                   
            if (rdo_trucksingle.Checked == true && rdo_etc.Checked==false && txt_weighttypeNo.Text =="01")
            {                     
                    txt_simple1.Text = ProductID_RDO + "-" + txt_ticketno.Text + "-1";
                    txt_simple2.Clear();  
            }

            if (rdo_trucksingle.Checked == true && rdo_etc.Checked == true && txt_weighttypeNo.Text == "01")
            {
                if (txt_etcidProduct.Text != "")
                {
                    txt_simple1.Text = ProductID_RDO + "-" + txt_ticketno.Text + "-1";
                    txt_simple2.Clear();
                }
            }
        }

        private void rdo_truckdouble_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_truckdouble.Checked == true)
            { id_truckType = 2; }
            if (rdo_truckdouble.Checked == true && rdo_etc.Checked == false && txt_weighttypeNo.Text == "01")
            {                
                txt_simple1.Text = ProductID_RDO + "-" + txt_ticketno.Text + "-1";
                txt_simple2.Text = ProductID_RDO + "-" + txt_ticketno.Text + "-2";
            }

            //if (rdo_truckdouble.Checked == true && rdo_etc.Checked == true && txt_weighttypeNo.Text == "01")
            //{
            //    if (txt_etcidProduct.Text != "")
            //    {                  
            //        txt_simple1.Text = ProductID_RDO + "-" + txt_ticketno.Text + "-1";
            //        txt_simple2.Text = ProductID_RDO + "-" + txt_ticketno.Text + "-2";
            //    }
            //}
        }
               
        private void rdo_etc_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_etc.Checked == true )
            {
                // ProductID = "FG-001";
                //txt_etcidProduct.Clear();
                txt_tecNameproduct.Text = "";
                rdo_trucksingle.Checked = false;
                rdo_truckdouble.Checked = false;
                txt_simple1.Clear();
                txt_simple2.Clear();              

             
                //F_Search fnd = new F_Search();
                //fnd.id_findType = 1;
                //fnd.ShowDialog();

                //if (fnd.id_value != "")
                //{
                //    txt_etcidProduct.Text = fnd.id_value.Trim();
                //    ProductID = fnd.id_value;
                //    txt_tecNameproduct.Text = fnd.name_value.Trim();
                //    Load_QueToday();
                //    gb_trucktrype.Enabled = true;
                //}
            }          

        }


        private void txt_plateno_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                txt_weighttypeNo.Focus();
            }
        }

        private void txt_weighttypeNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                F_Search fnd = new F_Search();
                fnd.id_findType = 2;
                fnd.ShowDialog();
                txt_weighttypeNo.Text = fnd.id_value;
                txt_weighttypeName.Text = fnd.name_value;

                if (txt_weighttypeNo.Text == "01") // Vendor  เราซื้อ
                { label5.Text = "ผู้ขาย"; }

                else if (txt_weighttypeNo.Text == "02") // Custor เราขาย
                { label5.Text = "ผู้ซื้อ"; }

                else if (txt_weighttypeNo.Text == "03")
                { label5.Text = "ชั่งบัตร Auto"; }

                else
                { label5.Text = "ชื่อผู้ซื้อ-ขาย"; }


                txt_vencusNo.Focus();
            }
        }

        private void txt_vencusNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                F_Search fnd = new F_Search();
               
                if (txt_weighttypeNo.Text == "01")  //Purchase
                { fnd.jobType = 3; }
                if (txt_weighttypeNo.Text == "02")   //Sale
                { fnd.id_findType = 4; }

                fnd.ShowDialog();
                txt_vencusNo.Text = fnd.id_value;
                txt_vencusName.Text = fnd.name_value;

                txt_driveName.Focus();
            }

        }

        private void txt_driveName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                gb_product.Focus();
            }
        }
     
        private void txt_ticketno_KeyDown(object sender, KeyEventArgs e)
        {
           

                                                                           
        }

 //       private void txt_ticketno_KeyPress(object sender, KeyPressEventArgs e)
 //       {
 //           if (e.KeyChar == 13)
 //           {
 //               SqlConnection con = new SqlConnection(Program.pahtdb);
 //               con.ConnectionString = Program.pahtdb;
 //               SqlDataAdapter dtAdapter = new SqlDataAdapter();
 //               con.Open();

 //               id_loaddata = 1;
 //               string truck_typenName = "";

 //               string sql1 = "Select * From [dbo].[V_WeightData] Where TicketCodeIn ='" + txt_ticketno.Text.Trim() + "'";
 //               SqlCommand CM1 = new SqlCommand(sql1, con);
 //               SqlDataReader DR1 = CM1.ExecuteReader();

 //               DR1.Read();
 //               {
 //                   txt_ticketno.Text = DR1["TicketCodeIn"].ToString();
 //                   txt_plateno.Text = DR1["Plate1"].ToString();
 //                   lbl_weighttypeName.Text = DR1["WeightTypeName"].ToString();
 //                   txt_weighttypeNo.Text = DR1["WeightTypeID"].ToString();
 //                   truck_typenName = DR1["TruckTypeName"].ToString();
 //                   ProductID = DR1["ProductID"].ToString().Trim();
 //                   txt_simple1.Text = DR1["SimpleCode1"].ToString();
 //                   txt_simple2.Text = DR1["SimpleCode2"].ToString();
 //                   txt_queNo.Text = DR1["QueueNo"].ToString();
 //                   lbl_vencusName.Text = DR1["NameVen"].ToString();
 //                   txt_vencusNo.Text = DR1["Vendor_No"].ToString();
 //               }
 //               DR1.Close();
 //               //con.Close();

 //               if (truck_typenName == "เดี่ยว")
 //               {
 //                   rdo_trucksingle.Checked = true;
 //               }
 //               else { rdo_truckdouble.Checked = true; }

 //               txt_queType.Text = "OUT";
 //               txt_queType.ForeColor = Color.Red;
 //               txt_queNo.ForeColor = Color.Red;

 //               if (ProductID == "RM-001")
 //               {
 //                   rdo_casawaRoot.Checked = true;
 //               }

 //               else if (ProductID == "RM-004")
 //               {
 //                   rdo_casawaShip.Checked = true;
 //               }

 //               else if (ProductID == "ST0803-002")
 //               {
 //                   rdo_woodShip.Checked = true;
 //               }

 //               else if (ProductID == "FG-001")
 //               {
 //                   rdo_ethanol.Checked = true;
 //               }

 //               else
 //               {
 //                   rdo_etc.Checked = true;

 //                   txt_etcidProduct.Text = ProductID;
 //                   string sql2 = "Select [ProductName] From [dbo].[TB_Products] Where [ProductID] ='" + ProductID + "'";
 //                   SqlCommand CM2 = new SqlCommand(sql2, con);
 //                   SqlDataReader DR2 = CM2.ExecuteReader();

 //                   DR2.Read();
 //                   {
 //                       lbl_etcproducName.Text = DR2["ProductName"].ToString();
 //                   }
 //                   DR2.Close();
 //               }


 //               con.Close();

 //               DialogResult result1 = MessageBox.Show("คุณต้องการลงทะเบียนตั๋วชั่งนี้ออกจากโรงงานใช่หรือไม่?",
 //"ปิดหน้าโปรแกรม",
 //MessageBoxButtons.YesNo);

 //               if (result1 == DialogResult.Yes)
 //               {
 //                   con.Open();
 //                   int id_process = 0;
 //                   // Goto update process id in table weight data
 //                   string sql6 = "Select Max([proc_no])AS maxR From [dbo].[TB_Process] Where [item_no] ='" + ProductID + "' AND [proc_type] ='R'";
 //                   SqlCommand CM6 = new SqlCommand(sql6, con);
 //                   SqlDataReader DR6 = CM6.ExecuteReader();

 //                   DR6.Read();
 //                   {
 //                       id_process = Convert.ToInt16(DR6["maxR"].ToString()) + 1;
 //                   }
 //                   DR6.Close();


 //                   string sql = "Update [TB_WeightData]  Set [Process_id] = '" + id_process + "' WHERE [TicketCodeIn]='" + txt_ticketno.Text.Trim() + "' ";
 //                   SqlCommand CM2 = new SqlCommand(sql, con);
 //                   SqlDataReader DR2 = CM2.ExecuteReader();

 //                   con.Close();
 //                   //clear data
 //                   Clear_Data();

 //               }


 //           }
 //       }

        public void cb_registerOut_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_registerOut.Checked == true)
            {
                txt_ticketno.Clear();

                F_Dialog fd = new F_Dialog();
                fd.ShowDialog();

                if (fd.QR_code != "")
                {
                    txt_ticketno.Text = fd.QR_code;
                    Weight_type = fd.Weight_type;
                    Update_RegisterOut();
                }
                else
                {

                    //cb_registerOut_CheckedChanged(this, EventArgs.Empty);
                  
                        Clear_Data(); cb_registerOut.Checked = false;
                    Load_TicketNo();
                }
            }

            else { Clear_Data(); Load_TicketNo(); }
        }

        private void Update_RegisterOut()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {     
                id_loaddata = 1;
                string truck_typenName = "";
                string sql1 = "";

                if (Weight_type == "Purchase")
                {
                    con.Open();
                    sql1 = "Select * From [dbo].[V_WeightData] Where TicketCodeIn ='" + txt_ticketno.Text.Trim() + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, con);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    {
                        txt_ticketno.Text = DR1["TicketCodeIn"].ToString();
                        txt_plateno.Text = DR1["Plate1"].ToString();
                        txt_weighttypeName.Text = DR1["WeightTypeName"].ToString();
                        txt_weighttypeNo.Text = DR1["WeightTypeID"].ToString();
                        truck_typenName = DR1["TruckTypeName"].ToString();
                        ProductID_DB = DR1["ProductID"].ToString().Trim();
                        txt_simple1.Text = DR1["SimpleCode1"].ToString();
                        txt_simple2.Text = DR1["SimpleCode2"].ToString();
                        txt_queNo.Text = DR1["QueueNo"].ToString();
                        txt_vencusName.Text = DR1["NameVen"].ToString();
                        txt_vencusNo.Text = DR1["Vendor_No"].ToString();
                    }
                    DR1.Close();
                    con.Close();
                }


                if (Weight_type == "Sale")
                {
                    con.Open();
                    sql1 = "Select * From [dbo].[V_WeightData_Sale] Where TicketCodeIn ='" + txt_ticketno.Text.Trim() + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, con);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    {
                        txt_ticketno.Text = DR1["TicketCodeIn"].ToString();
                        txt_plateno.Text = DR1["Plate1"].ToString();
                        txt_weighttypeName.Text = DR1["WeightTypeName"].ToString();
                        txt_weighttypeNo.Text = DR1["WeightTypeID"].ToString();
                        truck_typenName = DR1["TruckTypeName"].ToString();
                        ProductID_DB = DR1["ProductID"].ToString().Trim();                       
                        txt_queNo.Text = DR1["QueueNo"].ToString();
                        txt_vencusName.Text = DR1["CustomerName"].ToString();
                        txt_vencusNo.Text = DR1["CustomerID"].ToString();
                    }
                    DR1.Close();
                    con.Close();
                }
                //con.Close();

                if (truck_typenName == "เดี่ยว")
                {
                    rdo_trucksingle.Checked = true;
                }
                else { rdo_truckdouble.Checked = true; }

                txt_queType.Text = "OUT";
                txt_queType.ForeColor = Color.Red;
                txt_queNo.ForeColor = Color.Red;

                if (ProductID_DB == "RM-001")
                {
                    rdo_casawaChip.Checked = true;
                }

                else if (ProductID_DB == "RM-004")
                {
                    rdo_casawaRoot.Checked = true;
                }

                else if (ProductID_DB == "ST0803-002")
                {
                    rdo_woodShip.Checked = true;
                }

                else if (ProductID_DB == "FG-001")
                {
                    rdo_ethanol.Checked = true;
                }

                else
                {
                    con.Open();
                    rdo_etc.Checked = true;
                    txt_etcidProduct.Text = ProductID_DB;

                    string sql2 = "Select [ProductName] From [dbo].[TB_Products] Where [ProductID] ='" + ProductID_DB + "'";
                    SqlCommand CM2 = new SqlCommand(sql2, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();

                    DR2.Read();
                    {
                        txt_tecNameproduct.Text = DR2["ProductName"].ToString().Trim();
                    }
                    DR2.Close();
                    con.Close();
                }               

                DialogResult result1 = MessageBox.Show("คุณต้องการลงทะเบียนตั๋วชั่งนี้ออกจากโรงงานใช่หรือไม่?",
    "ปิดหน้าโปรแกรม",
    MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {
                    con.Open();
                   
                    string date = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US")) + " " + DateTime.Now.ToString("HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));

                    string sql = "Update [TB_WeightData]  Set [RegisterIOutdate] = '" + date + "' WHERE [TicketCodeIn]='" + txt_ticketno.Text.Trim() + "' ";
                    SqlCommand CM2 = new SqlCommand(sql, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();

                    con.Close();


                    Msg = "Register Out on Ticket!";
                    Log_NewValue = txt_ticketno.Text.Trim();
                    Log_OldValue = "-";
                    Class_Log CL = new Class_Log();
                    CL.tbname = Msg;
                    CL.oldvalue = Log_OldValue;
                    CL.newvalue = Log_NewValue;
                    CL.Save_log();

                    
                    Save_FollowProcess();                 
                    Clear_Data();
                }

            }

            catch { /*this.Close();*/  Load_TicketNo(); cb_registerOut.Checked = false; con.Close(); }

        }


        private void txt_ticketno_TextChanged(object sender, EventArgs e)
        {

        }

        private void bnt_recheck_Click(object sender, EventArgs e)
        {
            F_RecheckData frdt = new F_RecheckData();
            frdt.ID_Recheck = 1;           
            frdt.ShowDialog();
        }

        private void dtp_register_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_register.Value.Date >= DateTime.Today)
            {
                Clear_Data();
                Load_TicketNo();
            }

           else if (dtp_register.Value.Date <= DateTime.Today && Status_RollBackDate==1)
            {
                Clear_Data();
                Load_TicketNo();
            }
            else
            {
                MessageBox.Show("ไม่สามารถสร้างตั๋วลงทะเบียนย้อนหลังได้ กรุณาเปิดการใช้งานที่หน้าตั้งค่างานลงทะเบียน", "การสร้างตั๋วลงทะเบียนผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtp_register.Value = DateTime.Now;
                Clear_Data();
            }
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            F_MainReport fmp = new F_MainReport();
            fmp.ShowDialog();
        }

        private void txt_weighttypeName_KeyDown(object sender, KeyEventArgs e)
        {
            string sql1 = "";

            if (e.KeyCode == Keys.F2)
            {
                if (Printdata_PerIN == 1)  //พิมพ์ข้อมูลใหม่
                {
                    try
                    {

                        F_Search fnd = new F_Search();
                        F_Report frp = new F_Report();
                        fnd.id_findType = 6;
                        fnd.ShowDialog();

                        frp.Ticket_code = fnd.id_value;
                        frp.truckType = fnd.trucktype;
                        frp.ID_Product = fnd.id_product;
                        frp.type_job = fnd.jobType;

                        frp.ShowDialog();

                        ////Clear_Data();

                    }
                    catch { }
                }

                else { MessageBox.Show("สิทธ์การพิมพ์ไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานลงทะเบียนตั๋วเข้า)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }


            if (e.KeyCode == Keys.F3)  //แก้ไข ข้อมูล
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

                if (Editdata_PerIN == 1)
                {
                    try
                    {
                        F_Search fnd = new F_Search();
                        fnd.id_findType = 6;
                        fnd.ShowDialog();

                        id_loaddata = 1;

                        txt_ticketno.Text = fnd.id_value;
                        //txt_weighttypeNo.Text = fnd.jobType.ToString();                        

                        if (fnd.id_value != "")
                        {                      

                            id_status = 1;
                            // ต้องแก้ไขตัวค้นหาใหม่ เพราะ ต้องหา type เป็น status งาน 'R'                           
                            con.Open();


                            if (fnd.jobType == 1)
                            {

                                sql1 = "Select * From   [dbo].[V_WeightData] Where TicketCodeIn ='" + txt_ticketno.Text.Trim() + "' ";
                            }

                            if (fnd.jobType == 2)
                            {

                                sql1 = "Select * From   [dbo].[V_WeightData_Sale] Where TicketCodeIn ='" + txt_ticketno.Text.Trim() + "' ";
                            }

                            //fnd.ShowDialog();

                            //sql1 = "Select * From   [dbo].[V_WeightData] Where TicketCodeIn ='" + fnd.id_value + "' ";
                            SqlCommand CM1 = new SqlCommand(sql1, con);
                            SqlDataReader DR1 = CM1.ExecuteReader();

                            DR1.Read();
                            {
                                txt_ticketno.Text = DR1["TicketCodeIn"].ToString();
                                txt_plateno.Text = DR1["Plate1"].ToString();
                                txt_weighttypeNo.Text = DR1["WeightTypeID"].ToString();
                                txt_weighttypeName.Text = DR1["WeightTypeName"].ToString();
                                txt_transportID.Text = DR1["TransportID"].ToString();
                                txt_transportName.Text = DR1["TransportName"].ToString();
                                txt_remark2.Text = DR1["Remark2"].ToString();

                                if (txt_weighttypeNo.Text == "01")
                                {
                                    cb_SourceRawmat.Text = DR1["ProvinceName"].ToString();
                                    txt_vencusNo.Text = DR1["Vendor_No"].ToString();
                                    txt_vencusName.Text = DR1["NameVen"].ToString();
                                }

                                if (txt_weighttypeNo.Text == "02")
                                {
                                    txt_vencusNo.Text = DR1["CustomerID"].ToString();
                                    txt_vencusName.Text = DR1["CustomerName"].ToString();                                  
                                    cb_SourceRawmat.Enabled = false; cb_SourceRawmat.Text = "ไม่ระบุ";  
                                }

                                if (DR1["proc_name"].ToString().Trim() == "รอชั่งเข้า" || DR1["proc_name"].ToString().Trim() == "บันทึกผลครั้งที่1/บันทึกผล")
                                {
                                    gb_product.Enabled = true;
                                    gb_trucktrype.Enabled = true;
                                }
                                else {
                                    gb_product.Enabled = false;
                                    gb_trucktrype.Enabled = false;
                                }

                                txt_driveName.Text = DR1["DriveName"].ToString();
                                                               

                                if (DR1["ProductID"].ToString() == "RM-001")
                                {
                                    rdo_casawaChip.Checked = true;                                   
                                }
                            

                                else if (DR1["ProductID"].ToString() == "RM-004")
                                {
                                    rdo_casawaRoot.Checked = true;                                   
                                }

                                else if (DR1["ProductID"].ToString() == "ST0803-002")
                                {
                                    rdo_woodShip.Checked = true;                                    
                                }

                                else if (DR1["ProductID"].ToString() == "FG-001")
                                {
                                    rdo_ethanol.Checked = true;                                   
                                }

                                else
                                {
                                    rdo_etc.Checked = true;
                                    txt_etcidProduct.Text = DR1["ProductID"].ToString();
                                    txt_tecNameproduct.Text = DR1["ProductName"].ToString();                                  
                                }

                                if (DR1["TruckTypeID"].ToString() == "1")
                                { rdo_trucksingle.Checked = true; }
                                if (DR1["TruckTypeID"].ToString() == "2")
                                { rdo_truckdouble.Checked = true; }

                                txt_queNo.Text = DR1["QueueNo"].ToString(); //QueueNo                            

                                //[SimpleCode1]
                          
                                txt_simple1.Clear();
                                txt_simple2.Clear();

                                try
                                {
                                    txt_simple1.Text = DR1["SimpleCode1"].ToString();
                                    txt_simple2.Text = DR1["SimpleCode2"].ToString();
                                }
                                catch { }


                                ProductID_DB = DR1["ProductID"].ToString();
                            }
                            DR1.Close();
                            con.Close();
                                                    
                                                       
                        }


                        //if (txt_simple2.Text.Trim() == "")
                        //{
                        //    if (rdo_truckdouble.Checked == true)
                        //    {
                        //        txt_simple2.Text = ProductID_DB + "-" + txt_ticketno.Text + "-2";
                        //    }
                        //}
                                                                                                                                                                                    

                        //else { Load_TicketNo(); }
                    }
                    catch { con.Close(); }
                }

                else { MessageBox.Show("สิทธ์การแก้ไขไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานลงทะเบียนตั๋วเข้า)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

        }                    

        string dt_now = "";
        private void timer1_Tick(object sender, EventArgs e)
        {    
            tool_datetime.Text = "Login Date: " + DateTime.Now.ToShortDateString() + " Time: " + DateTime.Now.ToLongTimeString();

            //MessageBox.Show(tool_datetime.Text);
        }

     

        private void txt_SearchName_TextChanged(object sender, EventArgs e)
        {
            if (txt_SearchName.Text != "")
            {
                pn_Search.Visible = true;
                InitializeComboBox();
            }
            else { pn_Search.Visible = false; }
        }      

        private void btn_clearSearch_Click(object sender, EventArgs e)
        {
            if (btn_clearSearch.Text == "OK")
            {
                //Load data
                //MessageBox.Show(multi_cbSearch.SelectedItem.Value.ToString());

                Load_SearchNew_Record();
                btn_clearSearch.Text = "C";
                btn_clearSearch.ForeColor = Color.Red;

                if (tg_btnSearchHistory.Checked == true)
                {
                    cb_SourceRawmat.Enabled = false;
                }
            }

            else
            {
                multi_cbSearch.Clear();
                btn_clearSearch.Text = "OK";
                btn_clearSearch.ForeColor = Color.Blue;
                Clear_Data();
            }
        }

        private void Load_SearchNew_Record()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql1 = "";

            if (tg_btnSearchHistory.Checked==false)
            {
                sql1 = "Select * From   [dbo].[V_WeightData] Where TicketCodeIn ='" + multi_cbSearch.SelectedItem.Value.ToString() + "' ";
            }

            if (tg_btnSearchHistory.Checked==true)
            {
                sql1 = "Select * From   [dbo].[V_WeightData_Sale] Where TicketCodeIn ='" + multi_cbSearch.SelectedItem.Value.ToString() + "' ";
            }

            //fnd.ShowDialog();

            //sql1 = "Select * From   [dbo].[V_WeightData] Where TicketCodeIn ='" + fnd.id_value + "' ";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {            
                txt_plateno.Text = DR1["Plate1"].ToString();
                txt_weighttypeNo.Text = DR1["WeightTypeID"].ToString();
                txt_weighttypeName.Text = DR1["WeightTypeName"].ToString();
                txt_transportID.Text = DR1["TransportID"].ToString();
                txt_transportName.Text = DR1["TransportName"].ToString();
                txt_remark2.Text = DR1["Remark2"].ToString();

                if (txt_weighttypeNo.Text == "01")
                {
                    cb_SourceRawmat.Text = DR1["ProvinceName"].ToString();
                    txt_vencusNo.Text = DR1["Vendor_No"].ToString();
                    txt_vencusName.Text = DR1["NameVen"].ToString();
                    gb_product.Enabled = true;
                    gb_trucktrype.Enabled = true;
                    cb_SourceRawmat.Enabled = true;
                }

                if (txt_weighttypeNo.Text == "02")
                {
                    txt_vencusNo.Text = DR1["CustomerID"].ToString();
                    txt_vencusName.Text = DR1["CustomerName"].ToString();
                    gb_product.Enabled = true;
                    gb_trucktrype.Enabled = true;
                    cb_SourceRawmat.Enabled = false;
                }


                txt_driveName.Text = DR1["DriveName"].ToString();     
            }
            DR1.Close();

            con.Close();

        }

        private void btn_findTransport_Click(object sender, EventArgs e)
        {
            F_Search fnd = new F_Search();
            fnd.id_findType = 15;            
            fnd.ShowDialog();

            if (fnd.id_value != "")
            {
                txt_transportID.Text = fnd.id_value;
                txt_transportName.Text = fnd.name_value;
            }
        }

        private void btn_cancelTruck_Click(object sender, EventArgs e)
        {
            if (Canceldata_Per == 1)
            {
                F_ChangeData FCC = new F_ChangeData();
                FCC.id_updateType = 1;
                FCC.ShowDialog();

                //Load_DataRegister_Purchase();
                //Load_DataRegister_Sale();
            }

            else { MessageBox.Show("ชื่อผู้ใช้งานนนี้ไม่ได้รับสิทธิ์ในการยกเลิกงานชั่ง", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_refresh_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("ล้างข้อมูล", btn_refresh);
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Clear_Data();
            Load_TicketNo();
        }

        private void tg_btnSearchHistory_CheckedChanged(object sender, EventArgs e)
        {
            if (tg_btnSearchHistory.Checked == true) //sale
            {
                lbl_searchtype.Text = "ขาย";                
            }

            else
            {
                lbl_searchtype.Text = "ซื้อ";
            }

            txt_SearchName.Clear();
        }
    }
}
