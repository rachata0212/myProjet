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
using System.IO;
using System.Globalization;
using System.Net;

namespace Truck_Analytics
{
    public partial class F_Lab : Form
    {
        public F_Lab()
        {
            InitializeComponent();
        }

        //Set Permission Access in Data
        int Status_Use_ImportFile = 0;
        int Status_Use_Manual = 0;
        int Adddata_Per = 0;
        int Viewdata_Per = 0;       
        string Product_id = "";
        string Ticket_Code = "";
        int ID_UserApp = 0;
        string Messagemail = "";
        string tokenline = "";     
        string SimpleCode = "";

       
        //-----  log
        string  Msg = "";
        string Log_NewValue = "";
        string Log_OldValue = "-";

        private void F_Lab_Load(object sender, EventArgs e)
        {
            Load_Permission_Import();
            Load_Permission_Manual();

            if (Status_Use_ImportFile == 1 || Status_Use_Manual == 1)
            {

                txt_qrcode.Enabled = true;
                dtg_keymanual.Enabled = true;
               
                Load_manual();
                Load_statusLab();
                tool_login.Text = "Login Name: " + Program.user_name;
                tool_DBName.Text = "Database Name: " + Program.DB_Name;
                timer1.Enabled = true;

                if (Program.DB_Name != "SapthipNewDB")
                {
                    panel3.BackColor = Color.Crimson;                 
                }

            }

            else { MessageBox.Show("ไม่มีการเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานบันทึก-แบบคีย์มือ หรือ งานบันทึก-ทางนำเข้าไฟล์)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Load_TypeLab()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            DataSet ds1 = new DataSet();
            ds1.Clear();
            // string sql = "Select * From [dbo].[V_InuptLab] ";
            string sql1 = "Select [LabID] AS รหัส,[LabNameTH] AS 'ชื่อประเภท','' AS 'ผลที่ได้'  From [dbo].[TB_LabName] WHERE [ProductID]='" + Product_id + "' AND [LabActive]=1 AND [LabtypeID] <> 2 AND [LabtypeID] <> 6 AND [Dilldata]=0  Order by [SortData]";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);

            da1.Fill(ds1, "g_l");
            dtg_valuelab.DataSource = ds1.Tables["g_l"];

            dtg_valuelab.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            try
            {
                dtg_valuelab.Columns[0].Width = 60;
                dtg_valuelab.Columns[2].Width = 100;

                dtg_valuelab.ClearSelection();               
               
                

                dtg_valuelab.Select();
                //dtg_valuelab.Rows[0].Cells[2].Selected = true;
                dtg_valuelab.CurrentCell = dtg_valuelab.Rows[0].Cells[2];
                dtg_valuelab.BeginEdit(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();

                //dtg_valuelab.ClearSelection();
                //dtg_valuelab.Rows[0].Cells[2].Selected = true;              
                //dtg_valuelab.CurrentCell = dtg_valuelab.Rows[0].Cells[2];



            }


        }

        private void Load_Permission_Import()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql6 = "SELECT  Status_Use FROM  [dbo].[V_Permission] WHERE [UserID] = '" + Program.user_id + "' AND [ID_Menu]= 21 ";
            SqlCommand CM6 = new SqlCommand(sql6, con);
            SqlDataReader DR6 = CM6.ExecuteReader();

            DR6.Read();
            {
                if (DR6["Status_Use"].ToString().Trim() == "True") { Status_Use_ImportFile = 1; }
            }
            DR6.Close();
            con.Close();

            if (Status_Use_ImportFile == 1)
            {
                rdo_importfile.Enabled = true;
                rdo_importfile.Checked = true;
            }
            
        }
        private void Load_Permission_Manual()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql6 = "SELECT  Status_Use FROM  [dbo].[V_Permission] WHERE [UserID] = '" + Program.user_id + "' AND [ID_Menu]= 22 ";
            SqlCommand CM6 = new SqlCommand(sql6, con);
            SqlDataReader DR6 = CM6.ExecuteReader();

            DR6.Read();
            {
                if (DR6["Status_Use"].ToString().Trim() == "True") { Status_Use_Manual = 1; }                                      
            }
            DR6.Close();
            con.Close();

            if (Status_Use_Manual == 1)
            {               
                rdo_manualkey.Enabled = true;
                rdo_manualkey.Checked = true;
            }           
        }

        private void Load_manual()
        {
            try
            {
                //SqlConnection CN = new SqlConnection();
                //CN.ConnectionString = "server=192.168.111.225;initial catalog=SapthipNewDB;uid=truck_scale; pwd=pass@2020;";
                //CN.Open();

                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                DataSet ds1 = new DataSet();
                ds1.Clear();
                // string sql = "Select * From [dbo].[V_InuptLab] ";
                //  string sql1 = " SELECT [proc_name] AS 'สถานะ',[TicketCodeIn] AS 'รหัสชั่ง',[QueueNo] AS 'คิวที่',[RegisterInDate] AS 'วันที่ลงทะเบียน',[WeightDate] AS 'วันที่ชั้ง',[TruckTypeName] AS 'ประเภทรถ',[ProductName] AS 'สินค้า',[InboundWeight] AS 'น้ำหนักเข้า',[OutboundWeight] AS 'น้ำหนักออก',[GrossWeight] AS 'น้ำหนักสุทธิ' FROM [dbo].[V_InuptLab] Where [proc_type] = 'LC' OR [proc_type] ='L+WH'";

                string sql1 = " SELECT [proc_name] AS 'สถานะ',[TicketCodeIn] AS 'รหัสชั่ง',[QueueNo] AS 'คิวที่',CONVERT(varchar,[RegisterInDate],103) AS 'วันที่',CONVERT(varchar,[WeightDate],108) AS 'เวลา',[TruckTypeName] AS 'ประเภท',[ProductName] AS 'สินค้า',[InboundWeight] AS 'นน.เข้า',[OutboundWeight] AS 'นน.ออก',[GrossWeight] AS 'นน.สุทธิ' FROM [dbo].[V_InuptLab] Where [proc_type] = 'LC' OR [proc_type] ='L+WH'";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);

                da1.Fill(ds1, "g_l");
                dtg_keymanual.DataSource = ds1.Tables["g_l"];

                DateTime dt = new DateTime();
                string Date_cV = "";

                dtg_keymanual.Columns[0].Width = 250;
                dtg_keymanual.Columns[1].Width = 120;
                dtg_keymanual.Columns[2].Width = 70;
                dtg_keymanual.Columns[3].Width = 100;
                dtg_keymanual.Columns[4].Width = 100;           

            }
            catch { }
        }

        private void txt_qrcode_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {                                            
                int st_cha = 0;
                int ed_cha = 0;
                int count = 0;
                int index = 0;
             
                string textLength = txt_qrcode.Text;
                txt_simplecode.Text = txt_qrcode.Text;


                if (textLength.Length < 23)
                {
                    txt_simplecode.SelectionStart = 0;
                    txt_simplecode.SelectionLength = 20;
                    SimpleCode = txt_simplecode.SelectedText;
                }
                else
                {
                    txt_simplecode.SelectionStart = 0;
                    txt_simplecode.SelectionLength = 24;
                    SimpleCode = txt_simplecode.SelectedText;

                }


                txt_simplecode.Text = SimpleCode;                
                string str = txt_qrcode.Text;
                char[] b = new char[str.Length];

                b = str.ToCharArray();

                foreach (char c in b)
                {
                    index += 1;

                    if (c.ToString() == "-")
                    {
                        count += 1;
                    }

                    if (count == 2 && c.ToString() == "-")
                    {
                        st_cha = index;
                    }

                    if (count == 3 && c.ToString() == "-")
                    {
                        ed_cha = (index - st_cha) + 4;
                    }

                }

                txt_qrcode.SelectionStart = st_cha;
                txt_qrcode.SelectionLength = ed_cha;
                Ticket_Code = txt_qrcode.SelectedText; 

                if (rdo_manualkey.Checked == true)
                {
                    //F_ManualdataLab fsin = new F_ManualdataLab();

                    //fsin.Simple_code = txt_qrcode.Text;
                    //fsin.Lab_code = txt_qrcode.Text;
                    //fsin.Ticket_code = txt_qrcode.SelectedText;
                    //fsin.ShowDialog();

                    Load_Permission();
                                                                                                                       
                }

                if (rdo_importfile.Checked == true)
                {
                    F_ImportdataLab fsin = new F_ImportdataLab();                    
                    fsin.Simple_code = txt_qrcode.Text;
                    fsin.Lab_code = txt_qrcode.Text;
                    fsin.Ticket_code = txt_qrcode.SelectedText;
                    fsin.ShowDialog();
                    txt_qrcode.Clear();
                }

                //txt_qrcode.Clear();
                Load_manual();
                Load_statusLab();
            }
        }

        private void Load_Permission()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql6 = "SELECT  Adddata_Per, Viewdata_Per FROM  [dbo].[V_Permission] WHERE [UserID] = '" + Program.user_id + "' AND [ID_Menu]= 22 ";
                SqlCommand CM6 = new SqlCommand(sql6, con);
                SqlDataReader DR6 = CM6.ExecuteReader();

                DR6.Read();
                {
                    if (DR6["Adddata_Per"].ToString().Trim() == "True") { Adddata_Per = 1; }
                    if (DR6["Viewdata_Per"].ToString().Trim() == "True") { Viewdata_Per = 1; }
                }
                DR6.Close();
                con.Close();


                if (Viewdata_Per == 1)
                {
                    dtg_valuelab.Enabled = true;
                    dtg_valuelab.ReadOnly = false;
                }
                else { MessageBox.Show("สิทธิ์ในการดูข้อมูล/ค้นหา ถูกจำกัด กรุณาติดต่อผู้ดูแลระบบ! (งานบันทึก-แบบคีย์มือ)", "รายงานความผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error); }


                try
                {
                    con.Open();
                    string sql1 = "Select [QueueNo],[ProductName],[Plate1],[TruckTypeName],[ProductID] From [V_InuptLab] Where [TicketCodeIn]='" + Ticket_Code + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, con);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    {
                        // count = Convert.ToInt16(DR1["countidqua"].ToString().Trim());                       
                        lbl_quae.Text = DR1["QueueNo"].ToString().Trim();
                        txt_product.Text = DR1["ProductName"].ToString().Trim();
                        txt_truckno.Text = DR1["Plate1"].ToString().Trim();
                        txt_trucktype.Text = DR1["TruckTypeName"].ToString().Trim();
                        Product_id = DR1["ProductID"].ToString().Trim();
                    }
                    DR1.Close();

                    con.Close();   

                    Load_TypeLab();

                }
                catch
                {
                    MessageBox.Show("ไม่พบเลขที่ตัวอย่าง หรือสิทธ์ในการบันทึกไม่ถูกต้อง กรุณาตรวจสอบข้อมูล/ติดต่อผู้ดูแลระบบ", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_qrcode.Clear();               
                }
            }
            catch
            {
                MessageBox.Show("ไม่มีการเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานบันทึก-แบบคีย์มือ)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btn_setting_Click(object sender, EventArgs e)
        {
            Sub_Flab fin = new Sub_Flab();
            fin.ShowDialog();
        }

        private void dtg_keymanual_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {                
                    F_DataLab fd = new F_DataLab();
                    fd.ticket_code = dtg_keymanual.Rows[e.RowIndex].Cells[1].Value.ToString();
                    fd.ShowDialog();                
            }

            catch { }
        }

        private void Load_statusLab()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                for (int i = 0; i < dtg_keymanual.RowCount; i++)
                {
                    int count = 0;

                    string sql1 = "Select Count(TicketCodeIn)AS C_itmes From [TB_LabData] Where [TicketCodeIn]='" + dtg_keymanual.Rows[i].Cells[1].Value.ToString().Trim() + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, con);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    {
                        // count = Convert.ToInt16(DR1["countidqua"].ToString().Trim());

                        count = Convert.ToInt16(DR1["C_itmes"].ToString().Trim());

                    }
                    DR1.Close();

                    if (count > 0)
                    {
                        dtg_keymanual.Rows[i].Cells[0].Value += ": " + count.ToString() + " data";
                    }
                }


                con.Close();
              
            }
            catch { }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Load_manual();
            Load_statusLab();
        }

        private void rdo_manualkey_CheckedChanged(object sender, EventArgs e)
        {
            txt_qrcode.Focus();
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-us"));
        }

        private void rdo_importfile_CheckedChanged(object sender, EventArgs e)
        {
            txt_qrcode.Focus();
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-us"));
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int refresh_data = Program.refresh_Data;
        private void timer1_Tick(object sender, EventArgs e)
        {
            tool_datetime.Text = "Login Date: " + DateTime.Now.ToShortDateString() +" " + DateTime.Now.ToLongTimeString();

            if (refresh_data == 0)
            {
                refresh_data = Program.refresh_Data;
                Load_manual();
                Load_statusLab();
            }
            else {
                refresh_data = refresh_data - 1;                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refresh_data = Program.refresh_Data;
            Load_manual();
            Load_statusLab();
        }

        private void txt_qrcode_MouseClick(object sender, MouseEventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-us"));
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (Adddata_Per == 1)
            {
                Save_Data();
            }

            else { MessageBox.Show("สิทธ์การเพิ่มข้อมูลไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานบันทึก-แบบคีย์มือ)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Save_Data()
        {
            try
            {

                decimal value = 0;
                int LabID = 0;
                string Labname = "";

                DialogResult dr = MessageBox.Show("คุณต้องการบันทึกข้อมูลนี้ใช่หรือไม่", "ยืนยันข้อมูล", MessageBoxButtons.YesNoCancel,
          MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    // Save to data base
                    int date_c = DateTime.Now.Year;
                    string date_a = DateTime.Now.ToString("MM-dd", CultureInfo.CreateSpecificCulture("en-US"));

                    string date = Convert.ToString(date_c) + "-" + date_a + ' ' + DateTime.Now.ToString("HH:mm");

                    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                    con.ConnectionString = Program.pathdb_Weight;
                    SqlDataAdapter dtAdapter = new SqlDataAdapter();
                    //con.Open();

                    string sql = "";

                    for (int i = 0; i < dtg_valuelab.RowCount; i++)
                    {
                        if (dtg_valuelab.Rows[i].Cells[2].Value.ToString() != "")
                        {
                            value = Convert.ToDecimal(dtg_valuelab.Rows[i].Cells[2].Value.ToString());
                            LabID = Convert.ToInt32(dtg_valuelab.Rows[i].Cells[0].Value.ToString());
                            Labname = dtg_valuelab.Rows[i].Cells[1].Value.ToString().Trim();


                            con.Open();
                            sql = "Insert Into [TB_LabData](TicketCodeIn, LabID,SimpleCode,LabCode,ValueLab,CreateDate,CreateBy,InActive) Values('" + Ticket_Code + "', '" + LabID + "', '" + txt_simplecode.Text + "','" + txt_qrcode.Text.Trim() + "', " + value + ", '" + date + "', '" + Program.user_login + "',1)";
                            SqlCommand CM2 = new SqlCommand(sql, con);
                            SqlDataReader DR2 = CM2.ExecuteReader();
                            con.Close();
                        }

                        //List Email
                        //try
                        //{
                        //    SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
                        //    con1.ConnectionString = Program.pathdb_Weight;
                        //    SqlDataAdapter dtAdapter1 = new SqlDataAdapter();

                        //    String Sample = "";

                        //    try
                        //    {
                        //        int LogID_Min = 0;
                        //        int LogID_Max = 0;
                        //        double Value_Min = 0;
                        //        double Value_Max = 0;
                        //        int ValueVisualNo = 0;
                        //        //ValueVisualNo
                        //        //
                        //        con1.Open();
                        //        string sql1 = "Select Top (1) [LOGID],[Min] From [dbo].[TB_ValueLab]  Where  LabID= " + LabID + " AND [Min] <" + value + " AND Alert_Lab =1 Order by LOGID desc";
                        //        SqlCommand CM1 = new SqlCommand(sql1, con1);
                        //        SqlDataReader DR1 = CM1.ExecuteReader();
                        //        DR1.Read();
                        //        {
                        //            LogID_Min = Convert.ToInt16(DR1["LOGID"].ToString().Trim());
                        //            Value_Min = Convert.ToDouble(DR1["Min"].ToString().Trim());
                        //        }
                        //        DR1.Close();
                        //        con1.Close();


                        //        con1.Open();
                        //        string sql3 = "Select Top (1) LOGID,[Min] From [dbo].[TB_ValueLab]  Where  LabID= " + LabID + " AND [Max] >= " + value + " AND Alert_Lab =1";
                        //        SqlCommand CM3 = new SqlCommand(sql3, con1);
                        //        SqlDataReader DR3 = CM3.ExecuteReader();
                        //        DR3.Read();
                        //        {
                        //            LogID_Max = Convert.ToInt16(DR3["LOGID"].ToString().Trim());
                        //            Value_Max = Convert.ToDouble(DR3["Min"].ToString().Trim());
                        //        }
                        //        DR3.Close();
                        //        con1.Close();

                        //        if (Value_Max > Value_Min || Value_Max == Value_Min)
                        //        {
                        //            ValueVisualNo = LogID_Max;
                        //        }

                        //        else { ValueVisualNo = LogID_Min; }
                        //    }
                        //    catch { }


                            //Sample = "ประเภท: " + Labname + " ผล: " + value;

                            //if (Messagemail.Contains(Sample) == false)
                            //{
                            //    Messagemail += Sample + Environment.NewLine;
                            //}

                            //if (ValueVisualNo != 0)
                            //{
                            //    //List_EmailAlert();
                            //    //Load_ConfigAlert();
                            //}

                            //if (tokenline != "")
                            //{
                            //    string MsgLine = "แจ้งเตือนสินค้าไม่ผ่านเกณฑ์" + Environment.NewLine + "วันที่:" + DateTime.Now.ToShortDateString() + " เวลา: " + DateTime.Now.ToLongTimeString() + Environment.NewLine + "ประเภท: " + txt_product.Text.Trim() + " เลขที่ชั่ง: " + Ticket_code + " เลขที่ตัวอย่าง: " + txt_simplecode.Text.Trim() + Environment.NewLine + " คิวที่: " + lbl_quae.Text.Trim() + " ชนิดรถ: " + txt_trucktype.Text.Trim() + " ทะเบียน: " + txt_truckno.Text.Trim();

                            //    lineNotify(MsgLine);

                            //    if (ShoDetail_line == 1)
                            //    {
                            //        String s = Sample;
                            //        s = s.Replace("%", " เปอร์เซ็นต์");

                            //        string MsgLine2 = "";
                            //        if (i < dtg_valuelab.RowCount)
                            //        {
                            //            //ผลการวิเคราะห์:ประเภท: ป่น ผล: 5%
                            //            MsgLine2 = "การวิเคราะห์-" + s;
                            //            lineNotify(MsgLine2);
                            //        }

                            //        if (i == dtg_valuelab.RowCount - 1)
                            //        {
                            //            MsgLine2 = " -:- ระบบแจ้งเตือนผลไม่ผ่านเกณฑ์ (Truck Scale Systems V 5.0.5) -:-";

                            //            lineNotify(MsgLine2);
                            //        }
                            //    }

                            //}

                        //}
                        //catch { }

                        //List_EmailAlert();
                    }

                    //Load_ConfigAlert();  //Load Config Alert mail & line
                    //Load_CheckWaring();  //Check Count send mail
                    //Send_Alert();    // Send mail
                    //Save_App();  //update database of request approved
                    MessageBox.Show("บันทึกสำเร็จ!!", "รายงานการบันทึก", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Msg = "Insert Data on Lab!";

                    Log_NewValue = "TicketCodeIn =" + Ticket_Code +
                            "," + "LabID = " + LabID.ToString() +
                            "," + "SimpleCode = " + txt_simplecode.Text +
                            "," + "LabCode = " + txt_qrcode.Text.Trim() +
                            "," + "ValueLab = " + value +
                            "," + "CreateDate = " + date.ToString() +
                            "," + "CreateBy = " + Program.user_login +                           
                            "," + "InActive = 1";    

                    Log_OldValue = "-";
                    Class_Log CL = new Class_Log();
                    CL.tbname = Msg;
                    CL.oldvalue = Log_OldValue;
                    CL.newvalue = Log_NewValue;
                    CL.Save_log();

                    Clear_TXT();
                    txt_qrcode.Clear();
                    txt_qrcode.Focus();
                    
                }
            }

            catch
            {
                MessageBox.Show("คุณใส่รูปแบบข้อมูลไม่ถูกต้อง", "รูปแบบข้อมูลผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txt_value.ForeColor = Color.Red;
                //txt_value.Focus();
                txt_qrcode.Clear();
            }

        }

        private void Clear_TXT()
        {
            lbl_quae.Text = "-";
            txt_truckno.Clear();
            txt_trucktype.Clear();
            txt_simplecode.Clear();
            txt_product.Clear();
            dtg_valuelab.DataSource = null;
        }


        private void Save_Approve()
        {
            if (ID_UserApp > 0)
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter1 = new SqlDataAdapter();

                con.Open();
                string sql1 = "Update [TB_WeightData] Set  [StatusID]=2 Where [TicketCodeIn] = '" + Ticket_Code + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                con.Close();

                string date = Program.Date_Now + ' ' + DateTime.Now.ToString("HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));

                con.Open();
                string sql = "Insert Into [TB_Approved] ([TicketCodeIn],[SimpleCode],[CreateDate],[ID_UserApp],[StatusID]) Values('" + Ticket_Code + "','" + txt_simplecode.Text.Trim() + "', '" + date + "', " + ID_UserApp + ",2)";
                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();
            }

        }
        private void lineNotify(string msg)
        {
            string token = tokenline;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("https://notify-api.line.me/api/notify");
                var postData = string.Format("message={0}", msg);
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
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
