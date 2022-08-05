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
using System.Net;
using System.IO.Ports;
using System.Threading;
using System.Net.Mail;
using System.Globalization;

namespace Interface_Lab
{
    public partial class F_Increditor : Form
    {
        public F_Increditor()
        {
            InitializeComponent();
        }

        SerialPort sport = new SerialPort();
        string Product_id = "";
        string Status_diskplay = "";


        string Table_Name = "";
        string Log_newValue = "";
        string Log_oldValue = "";

        int Status_Use = 0;
        int Adddata_Per = 0;
        int Editdata_Per = 0;
        int Viewdata_Per = 0;
        int Configdata_Per = 0;
        int ValueVisualNo = 0;
        string Messagemail = "";
        string string1 = "";
        string ID_AL = "";
        string tokenline = "";
        string ipsvr = "";
        string mailport = "";
        string accalert = "";
        string addpwd = "";
        int ShoDetail_line = 0;
        int ShoDetail_mail = 0;
        int Count_Alert = 0;
        int ID_UserApp = 0;
        int LabID = 0;
        private void Load_Permission()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pahtdb);
                con.ConnectionString = Program.pahtdb;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql6 = "SELECT  Status_Use, Adddata_Per, Editdata_Per, Viewdata_Per,Configdata_Per  FROM [SapthipNewDB].[dbo].[V_Permission] WHERE [UserID] = '" + Program.user_id + "' AND [ID_Menu]= 20 ";
                SqlCommand CM6 = new SqlCommand(sql6, con);
                SqlDataReader DR6 = CM6.ExecuteReader();

                DR6.Read();
                {
                    if (DR6["Adddata_Per"].ToString().Trim() == "True") { Adddata_Per = 1; }
                    if (DR6["Editdata_Per"].ToString().Trim() == "True") { Editdata_Per = 1; }
                    if (DR6["Viewdata_Per"].ToString().Trim() == "True") { Viewdata_Per = 1; }
                    if (DR6["Status_Use"].ToString().Trim() == "True") { Status_Use = 1; }
                    if (DR6["Configdata_Per"].ToString().Trim() == "True") { Configdata_Per = 1; }
                }
                DR6.Close();
                con.Close();

                if (Adddata_Per == 1)
                {
                    txt_labSimpleCode.Enabled = true;
                    txt_valueSave.Enabled = true;
                    btn_save.Enabled = true;
                }

            }

            catch
            {
                MessageBox.Show("ไม่มีการเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานบันทึก-% แป้งมันสด)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }

        private void Save_Log()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd") + ' ' + DateTime.Now.ToString("HH:mm");

            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql = "Insert Into [TB_Log] ([LogDateTime],[Username],[TableName],[OldValue],[NewValue],[MachineName],[LocalIpAddress]) Values('" + date + "', '" + Program.user_login + "', '" + Table_Name + "','" + Log_newValue + "', '" + Log_oldValue + "', '" + Program.MachineName + "', '" + Program.LocalIpAddress + "')";
            SqlCommand CM2 = new SqlCommand(sql, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            F_Login flg = new F_Login();
            flg.ShowDialog();

            if (Program.user_id != 0)
            {
                Load_Permission();

                if (Status_Use == 1)
                {
                    this.WindowState = FormWindowState.Normal;

                    StreamReader sw = new StreamReader(Application.StartupPath + "\\cn.dll");
                    string connecpovider = sw.ReadToEnd();
                    Program.CN = new SqlConnection();
                    Program.CN.ConnectionString = connecpovider;
                    Program.pahtdb = connecpovider;
                    Program.MachineName = Environment.MachineName.ToString();
                    Program.LocalIpAddress = GetIPAddress();

                    Load_FileConfig();
                    Load_TruckScale_Config();
                    ConnectToSerail();

                    timer1.Enabled = true;
                    txt_labSimpleCode.Focus();

                }

                else
                {
                    MessageBox.Show("ไม่มีการเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานบันทึก-เปอร์เซ็นต์แป้งมันสด)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void Load_TruckScale_Config()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql6 = "SELECT *  FROM [SapthipNewDB].[dbo].[TB_Scale] Where [ScaleFormat] ='" + Program.ScaleName + "'";
            SqlCommand CM6 = new SqlCommand(sql6, con);
            SqlDataReader DR6 = CM6.ExecuteReader();

            DR6.Read();
            {
                Program.ScaleNo = Convert.ToInt16(DR6["ScaleCode"].ToString().Trim());
                Program.ScaleName = DR6["ScaleFormat"].ToString().Trim();
                Program.PortName = DR6["PortName"].ToString().Trim();
                Program.BaudRate = DR6["BaudRate"].ToString().Trim();
                Program.DataBit = Convert.ToInt16(DR6["DataBit"].ToString().Trim());
                Program.Parity = DR6["Parity"].ToString().Trim();
                Program.StopBit = DR6["StopBit"].ToString().Trim();
                Program.StartSelect_Char = Convert.ToInt16(DR6["StartAscii"].ToString().Trim());
                Program.EndSelect_Chare = Convert.ToInt16(DR6["EndAscii"].ToString().Trim());
            }
            DR6.Close();
            con.Close();

        }

        private void Load_FileConfig()
        {
            //  StreamReader sw = new StreamReader(Application.StartupPath + "\\config.dll");
            string filename = Application.StartupPath + "\\config.dll";

            if (System.IO.File.Exists(filename))
            {
                System.IO.StreamReader StrRer = new System.IO.StreamReader(filename);

                List<string> listStr = new List<string>();

                while (!StrRer.EndOfStream)
                {
                    listStr.Add(StrRer.ReadLine());
                }

                Program.ScaleName = listStr[0].ToString();
                Status_diskplay = listStr[1].ToString();

                StrRer.Close();
            }


            if (Status_diskplay == "Monitor 2 :True")
            {
                btn_monitor.Enabled = true;
            }
        }

        private string GetIPAddress()
        {
            StringBuilder sb = new StringBuilder();
            String strHostName = string.Empty;
            strHostName = Dns.GetHostName();
            //sb.Append("The Local Machine Host Name: " + strHostName);
            //sb.AppendLine();
            IPHostEntry ipHostEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] address = ipHostEntry.AddressList;
            sb.Append(address[1].ToString());
            sb.AppendLine();
            return sb.ToString();
        }

        private void ConnectToSerail()
        {
            //try
            //{
            sport.PortName = Program.PortName;
            sport.BaudRate = int.Parse(Program.BaudRate);
            sport.Parity = (Parity)Enum.Parse(typeof(Parity), Program.Parity);
            sport.DataBits = Program.DataBit;
            sport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), Program.StopBit);
            sport.Handshake = Handshake.None;
            sport.DataReceived += OnSerialDataReceived;
            sport.ReadTimeout = 800;
            sport.WriteTimeout = 800;
            //sport.Open();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Comport Access Denie ! " + ex.Message + "", "Comport Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        public void OnSerialDataReceived(object sender, SerialDataReceivedEventArgs args)
        {
            try
            {
                if (sport.IsOpen)
                {
                    Thread.Sleep(300);
                    string data = sport.ReadExisting();
                    this.BeginInvoke(new MethodInvoker(delegate () { txt_weightInterface.Text = data.Trim(); }));
                    //sport.Close();

                    RichTextBox.CheckForIllegalCrossThreadCalls = false;

                    /////////////--------------  test
                    Check_Weight();


                    if (txt_valueSave.Text != "")
                    {
                        sport.Close();
                        Save_Data();
                    }

                }
            }
            catch { }
        }

        private void Check_Weight()
        {
            int count = 0;
            int index = 0;
            int numbers = 0;
            double value = 0.00; // value check


            txt_weightInterface.SelectionStart = 0;
            txt_weightInterface.SelectionLength = 48;

            string str = txt_weightInterface.SelectedText;

            //string str = txt_weightInterface.Text;
            //48 char

            char[] b = new char[str.Length];
            numbers = str.Length;
            b = str.ToCharArray();



            foreach (char c in b)
            {
                index += 1;

                if (c.ToString() == ",")
                {
                    count += 1;           //บอก index       
                }

                if (count == 8)
                {
                    txt_weightInterface.SelectionStart = 43;
                    txt_weightInterface.SelectionLength = 4;

                    value = Convert.ToDouble(txt_weightInterface.SelectedText);
                    if (value != 0)
                    {
                        txt_valueSave.Text = txt_weightInterface.SelectedText;
                        sport.Close();
                    }

                }

                if (count == 7)
                {
                    txt_weightInterface.SelectionStart = 38;
                    txt_weightInterface.SelectionLength = 4;

                    value = Convert.ToDouble(txt_weightInterface.SelectedText);
                    if (value != 0)
                    {
                        txt_valueSave.Text = txt_weightInterface.SelectedText;
                        sport.Close();
                    }

                }

                if (count == 6)
                {
                    txt_weightInterface.SelectionStart = 33;
                    txt_weightInterface.SelectionLength = 4;

                    value = Convert.ToDouble(txt_weightInterface.SelectedText);
                    if (value != 0)
                    {
                        txt_valueSave.Text = txt_weightInterface.SelectedText;
                        sport.Close();
                    }

                }

                if (count == 5)
                {
                    txt_weightInterface.SelectionStart = 28;
                    txt_weightInterface.SelectionLength = 4;

                    value = Convert.ToDouble(txt_weightInterface.SelectedText);
                    if (value != 0)
                    {
                        txt_valueSave.Text = txt_weightInterface.SelectedText;
                        sport.Close();
                    }

                }

                if (count == 4)
                {
                    txt_weightInterface.SelectionStart = 23;
                    txt_weightInterface.SelectionLength = 4;

                    value = Convert.ToDouble(txt_weightInterface.SelectedText);
                    if (value != 0)
                    {
                        txt_valueSave.Text = txt_weightInterface.SelectedText;
                        sport.Close();
                    }

                }

                if (count == 3)
                {
                    txt_weightInterface.SelectionStart = 18;
                    txt_weightInterface.SelectionLength = 4;

                    value = Convert.ToDouble(txt_weightInterface.SelectedText);
                    if (value != 0)
                    {
                        txt_valueSave.Text = txt_weightInterface.SelectedText;
                        sport.Close();
                    }

                }

                if (count == 2)
                {
                    txt_weightInterface.SelectionStart = 13;
                    txt_weightInterface.SelectionLength = 4;

                    value = Convert.ToDouble(txt_weightInterface.SelectedText);
                    if (value != 0)
                    {
                        txt_valueSave.Text = txt_weightInterface.SelectedText;
                        sport.Close();
                    }

                }

                if (count == 1)
                {
                    txt_weightInterface.SelectionStart = 8;
                    txt_weightInterface.SelectionLength = 4;

                    value = Convert.ToDouble(txt_weightInterface.SelectedText);
                    if (value != 0)
                    {
                        txt_valueSave.Text = txt_weightInterface.SelectedText;
                        sport.Close();
                    }
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            //Save & load datagride
            if (Adddata_Per == 1 && txt_quea.Text.Trim() != "-")
            {
                Save_Data();
                Load_DTG_LabInterface();

                txt_weightInterface.Clear();
                txt_valueSave.Clear();
                txt_labSimpleCode.Clear();
                txt_labSimpleCode.Focus();
            }
            else {

                if (txt_quea.Text.Trim() != "-")
                { MessageBox.Show("ไม่พบข้อมูลชั่งสินค้าของเลขที่นี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานบันทึก-% แป้งมันสด)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                else
                {
                    MessageBox.Show("สิทธ์การเพิ่มข้อมูลไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานบันทึก-% แป้งมันสด)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void Save_Data()
        {
            try
            {
                double value = Convert.ToDouble(txt_valueSave.Text);
                txt_labSimpleCode.SelectionStart = 0;
                txt_labSimpleCode.SelectionLength = 20;

                //User requirement   29/09/2020  no message box confirm save to data
                //       DialogResult dr = MessageBox.Show("คุณต้องการบันทึกข้อมูลนี้ใช่หรือไม่", "ยืนยันข้อมูล", MessageBoxButtons.YesNoCancel,
                //MessageBoxIcon.Information);

                //       if (dr == DialogResult.Yes)
                //       {
                // Save to data base
                //int year_c = Convert.ToInt16(DateTime.Now.ToString("yyyy"));
                //string year = Convert.ToString(year_c - 543);

                //string date = year + DateTime.Now.ToString("-MM-dd") + ' ' + DateTime.Now.ToString("HH:mm");
                string date = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US")) + ' ' + DateTime.Now.ToString("HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));

                SqlConnection con = new SqlConnection(Program.pahtdb);
                con.ConnectionString = Program.pahtdb;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql = "Insert Into [TB_LabData](TicketCodeIn, LabID,SimpleCode,LabCode,ValueLab,CreateDate,CreateBy,InActive) Values('" + txt_ticketNo.Text + "', '" + cb_typelab.SelectedValue.ToString().Trim() + "', '" + txt_labSimpleCode.SelectedText + "','" + txt_labSimpleCode.Text + "', " + txt_valueSave.Text + ", '" + date + "', '" + Program.user_login + "',1)";
                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();

                //MessageBox.Show("บันทึกสำเร็จ!!", "รายงานการบันทึก", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LabID =Convert.ToInt16(cb_typelab.SelectedValue.ToString().Trim());
                Table_Name = "TB_LabData Interface";
                Log_oldValue = "-";
                Log_newValue = "New Record:" + txt_ticketNo.Text + " SimpleCode: " + txt_labSimpleCode.SelectedText + " ValueLab: " + txt_valueSave.Text;

                Save_Log();









                try
                {
                    con.Open();
                    string sql3 = "Select [LOGID] From [dbo].[TB_ValueLab]  Where  LabID= " + cb_typelab.SelectedValue.ToString().Trim() + " AND [Min] <" + txt_valueSave.Text + " AND [Max] >= " + txt_valueSave.Text + " AND Alert_Lab =1";
                    SqlCommand CM3 = new SqlCommand(sql3, con);
                    SqlDataReader DR3 = CM3.ExecuteReader();
                    DR3.Read();
                    {
                        ValueVisualNo = Convert.ToInt16(DR3["LOGID"].ToString().Trim());
                    }
                    DR3.Close();
                    con.Close();
                }
                catch { con.Close(); }

                String Sample = "";


                try
                {
                    int LogID_Min = 0;
                    int LogID_Max = 0;
                    double Value_Min = 0;
                    double Value_Max = 0;


                    con.Open();
                    string sql1 = "Select Top (1) [LOGID],[Min] From [dbo].[TB_ValueLab]  Where  LabID= " + LabID + " AND [Min] <" + value + " AND Alert_Lab =1 Order by LOGID desc";
                    SqlCommand CM1 = new SqlCommand(sql1, con);
                    SqlDataReader DR1 = CM1.ExecuteReader();
                    DR1.Read();
                    {
                        LogID_Min = Convert.ToInt16(DR1["LOGID"].ToString().Trim());
                        Value_Min = Convert.ToDouble(DR1["Min"].ToString().Trim());
                    }
                    DR1.Close();
                    con.Close();


                    con.Open();
                    string sql3 = "Select Top (1) LOGID,[Min] From [dbo].[TB_ValueLab]  Where  LabID= " + LabID + " AND [Max] >= " + value + " AND Alert_Lab =1";
                    SqlCommand CM3 = new SqlCommand(sql3, con);
                    SqlDataReader DR3 = CM3.ExecuteReader();
                    DR3.Read();
                    {
                        LogID_Max = Convert.ToInt16(DR3["LOGID"].ToString().Trim());
                        Value_Max = Convert.ToDouble(DR3["Min"].ToString().Trim());
                    }
                    DR3.Close();
                    con.Close();

                    if (Value_Max > Value_Min || Value_Max == Value_Min)
                    {
                        ValueVisualNo = LogID_Max;
                    }

                    else {
                        ValueVisualNo = LogID_Min;
                    }


                }
                catch { con.Close(); }


                Sample = "ประเภท: " + cb_typelab.Text.Trim() + " ผล: " + txt_valueSave.Text;

                if (Messagemail.Contains(Sample) == false)
                {
                    Messagemail += Sample + Environment.NewLine;
                }

                if (ValueVisualNo != 0)
                {
                    List_EmailAlert();
                    Load_ConfigAlert();
                }

                if (tokenline != "" && ID_UserApp != 0)
                {
                    string MsgLine = "แจ้งเตือนสินค้าไม่ผ่านเกณฑ์" + Environment.NewLine + "วันที่:" + DateTime.Now.ToShortDateString() + " เวลา: " + DateTime.Now.ToLongTimeString() + Environment.NewLine + "ประเภท: " + txt_product.Text.Trim() + " เลขที่ชั่ง: " + txt_ticketNo.Text.Trim() + " เลขที่ตัวอย่าง: " + txt_labSimpleCode.Text.Trim() + Environment.NewLine + " คิวที่: " + txt_quea.Text.Trim() + " ชนิดรถ: " + txt_trucktype.Text.Trim() + " ทะเบียน: " + txt_truckno.Text.Trim();

                    lineNotify(MsgLine);

                    if (ShoDetail_line == 1)
                    {
                        String s = Sample;
                        s = s.Replace("%", " เปอร์เซ็นต์");

                        string MsgLine2 = "";
                        //ผลการวิเคราะห์:ประเภท: ป่น ผล: 5%
                        MsgLine2 = "การวิเคราะห์-" + s;
                        lineNotify(MsgLine2);

                        MsgLine2 = " -:- ระบบแจ้งเตือนผลไม่ผ่านเกณฑ์ (Truck Scale Systems V 5.0.5) -:-";

                        lineNotify(MsgLine2);
                    }
                }


                //Load_CheckWaring();  //Check Count send mail

                //Send_Alert();    // Send mail

                //Save_App();  //update database of request approved
                                                                                                                                  
            }
            catch { }

            Load_DTG_LabInterface();
            txt_weightInterface.Clear();
            txt_valueSave.Clear();
            txt_labSimpleCode.Clear();

            //catch
            //{
            //    MessageBox.Show("คุณใส่รูปแบบข้อมูลไม่ถูกต้อง", "รูปแบบข้อมูลผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void Save_App()
        {
            if (ID_UserApp >= 0)
            {
                SqlConnection con = new SqlConnection(Program.pahtdb);
                con.ConnectionString = Program.pahtdb;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

                con.Open();
                string sql1 = "Update [TB_WeightData] Set  [StatusID]=2 Where [TicketCodeIn] = '" + txt_ticketNo.Text.Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                con.Close();

                string date = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US")) + ' ' + DateTime.Now.ToString("HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));

                con.Open();
                string sql = "Insert Into [TB_Approved] ([TicketCodeIn],[SimpleCode],[CreateDate],[ID_UserApp],[StatusID]) Values('" + txt_ticketNo.Text.Trim() + "','" + txt_labSimpleCode.Text.Trim() + "', '" + date + "', " + ID_UserApp + ",2)";
                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();

            }
        }

        private void Send_Alert()
        {
            ///Concept flow            
            /// 2. load value setup alert by product & labtype from email & line app
            /// 3.check user from to alert
            /// 4 check user from to approved
            /// 5. sent alert by type email & line app   
            if (Count_Alert > 0)
            {
                /// Load formail Send Masgemess
                ///                 

                try
                {
                    if (ipsvr != "")
                    {
                        string Name = string1;
                        string1 = Name.Remove(Name.Length - 1);

                        int port = Convert.ToInt16(mailport);
                        SmtpClient smtpClient = new SmtpClient(ipsvr, port);
                        smtpClient.Credentials = new System.Net.NetworkCredential(accalert, addpwd);
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        MailMessage mailMessage = new MailMessage();
                        mailMessage.From = new MailAddress(accalert);
                        mailMessage.To.Add(string1);

                        if (ShoDetail_mail == 0)
                        { Messagemail = "-"; }

                        mailMessage.Subject = "การวิเคราะห์ทางกายภายไม่ผ่านเกณฑ์ตัวอย่างที่ : " + txt_labSimpleCode.Text.Trim();
                        mailMessage.Body = "ชื่อสินค้า: " + txt_product.Text.Trim() + " เลขที่บัตรชั่ง: " + txt_ticketNo.Text.Trim() + " เลขที่ตัวอย่าง: " + txt_labSimpleCode.Text.Trim() +
                            "\r\n ประเภทรถ: " + txt_trucktype.Text.Trim() + " ทะเบียนรถ: " + txt_truckno.Text.Trim() +
                           "\r\n" + "ผลการวิเคราะห์: " + Messagemail +
                            "\r\n" +
                            "ทดสอบส่งวันที่ :" + DateTime.Now.ToShortDateString() + " เวลา:" + DateTime.Now.ToLongTimeString() +
                             "\r\n" +
                            "------ ทดสอบระบบแจ้งเตือนผลไม่ผ่านเกณฑ์ งานชั่ง (Truck Scale Systems V 5.0.5) ------";
                        smtpClient.Send(mailMessage);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

        }
        
        private void Load_CheckWaring()
        {
            ///Concept flow 
            ///1. load value from setup alert report on true
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql1 = "Select Count([LOGID]) AS 'Check_ALT' From [dbo].[V_AlertSMG_Lab] Where [ProductID]='" + Product_id + "' AND [LOGID]='" + ValueVisualNo + "' AND [ID_Frm_TypeLab]=1";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                Count_Alert += Convert.ToInt16(DR1["Check_ALT"].ToString().Trim());
            }
            DR1.Close();
            con.Close();

            if (Count_Alert > 0)
            {
                con.Open();
                string sql2 = "Select [ID_User] From [dbo].[V_AlertSMG_Lab] Where [ProductID]='" + Product_id + "' AND [LOGID]='" + ValueVisualNo + "' AND [ID_Frm_TypeLab]=1 AND [App_Sts]=1 AND [Status_RP]=1  AND [Level_App]=1";
                SqlCommand CM2 = new SqlCommand(sql2, con);
                SqlDataReader DR2 = CM2.ExecuteReader();

                DR2.Read();
                {
                    ID_UserApp = Convert.ToInt16(DR2["ID_User"].ToString().Trim());
                }
                DR2.Close();
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

        private void List_EmailAlert()
        {
            if (ValueVisualNo != 0)
            {
                SqlConnection con = new SqlConnection(Program.pahtdb);
                con.ConnectionString = Program.pahtdb;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();
                string1 = "";

                string sql1 = "Select  DISTINCT([ID_ALRP]),[Email],[ID_AL] From [dbo].[V_AlertSMG_Lab] Where [ProductID]='" + Product_id + "' AND [LabID]='" + cb_typelab.SelectedValue.ToString() + "' AND [ID_Frm_TypeLab]=1 AND [LOGID]=" + ValueVisualNo + " AND [Status_RP]=1";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                while (DR1.Read())
                {
                    string email = DR1["Email"].ToString().Trim();
                    ID_AL = DR1["ID_AL"].ToString().Trim();

                    if (string1.Contains(email) == false)
                    {
                        string1 += email + ",";
                    }
                }

                DR1.Close();
                con.Close();
            }
        }

        private void Load_ConfigAlert()
        {
            if (ID_AL != "")
            {
                SqlConnection con1 = new SqlConnection(Program.pahtdb);
                con1.ConnectionString = Program.pahtdb;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con1.Open();

                string sql1 = "SELECT * FROM [SapthipNewDB].[dbo].[V_Alert_Setting] Where [ID_AL]=" + ID_AL + " AND [ID_ALdStatus] = 1";
                SqlCommand CM1 = new SqlCommand(sql1, con1);
                SqlDataReader DR1 = CM1.ExecuteReader();

                while (DR1.Read())
                {
                    if (DR1["ID_ALtype"].ToString().Trim() == "1")  // Load mail config
                    {
                        ipsvr = DR1["Val1_ALT"].ToString().Trim();
                        mailport = DR1["Val2_ALT"].ToString().Trim();
                        accalert = DR1["Val3_ALT"].ToString().Trim();
                        addpwd = DR1["Val4_ALT"].ToString().Trim();

                        //ShoDetail
                        if (DR1["ShoDetail"].ToString().Trim() == "True")
                        {
                            ShoDetail_mail = 1;
                        }
                    }

                    if (DR1["ID_ALtype"].ToString().Trim() == "2") // Load line config
                    {
                        tokenline = DR1["Val1_ALT"].ToString().Trim();

                        if (DR1["ShoDetail"].ToString().Trim() == "True")
                        {
                            ShoDetail_line = 1;
                        }
                    }
                }
                DR1.Close();
                con1.Close();
            }
        }


        private void txt_simpleCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 )
            {
                if (Viewdata_Per == 1)
                {
                    try
                    {

                        int st_cha = 0;
                        int ed_cha = 0;
                        int count = 0;
                        int index = 0;


                        string str = txt_labSimpleCode.Text;
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

                        txt_labSimpleCode.SelectionStart = st_cha;
                        txt_labSimpleCode.SelectionLength = ed_cha;
                        txt_ticketNo.Text = txt_labSimpleCode.SelectedText;

                        SqlConnection con = new SqlConnection(Program.pahtdb);
                        con.ConnectionString = Program.pahtdb;
                        SqlDataAdapter dtAdapter = new SqlDataAdapter();
                        con.Open();


                        string sql1 = "Select [QueueNo],[ProductName],[Plate1],[TruckTypeName],[ProductID] From [V_InuptLab] Where [TicketCodeIn]='" + txt_ticketNo.Text + "' AND  [proc_type]='L+WH'";

                        //string sql1 = "Select [QueueNo],[ProductName],[Plate1],[TruckTypeName],[ProductID] From [V_InuptLab] Where [TicketCodeIn]='" + txt_ticketNo.Text + "'";

                        SqlCommand CM1 = new SqlCommand(sql1, con);
                        SqlDataReader DR1 = CM1.ExecuteReader();

                        DR1.Read();
                        {
                            // count = Convert.ToInt16(DR1["countidqua"].ToString().Trim());
                            txt_quea.Text = DR1["QueueNo"].ToString().Trim();
                            txt_product.Text = DR1["ProductName"].ToString().Trim();
                            txt_truckno.Text = DR1["Plate1"].ToString().Trim();
                            txt_trucktype.Text = DR1["TruckTypeName"].ToString().Trim();
                            Product_id = DR1["ProductID"].ToString().Trim();
                        }
                        DR1.Close();
                        con.Close();

                        Load_TypeLab();
                        Load_DTG_LabInterface();
                        Program.ticket_No = txt_ticketNo.Text;
                        Program.sample_code = txt_labSimpleCode.Text;

                        //btn_save.Focus();

                        txt_valueSave.Focus();
                        sport.Open();
                    }
                    catch
                    {
                        //MessageBox.Show("รายงานความผิดพลาด!!", "ไม่พบข้อมูลที่ต้องการค้นหา", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //this.Close();


                    }                    

                }

                else { MessageBox.Show("สิทธิ์ในการดูข้อมูล/ค้นหา ถูกจำกัด กรุณาติดต่อผู้ดูแลระบบ! (งานบันทึก-% แป้งมันสด)", "รายงานความผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                //test
                Check_LabSave();

             }

           
        }

        private void Check_LabSave()
        {
            //
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            dtg_saveHistory.DataSource = null;

            string sql1 = "SELECT [LOGID] AS 'ลำดับ',[LabCode] AS 'เลขที่ตัวอย่าง',[ValueLab] AS 'ค่าบันทึก' FROM TB_LabData WHERE  TicketCodeIn='" + txt_ticketNo.Text.Trim() + "'";     
            SqlDataAdapter da = new SqlDataAdapter(sql1, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "g_lab");
            dtg_saveHistory.DataSource = ds.Tables["g_lab"];           

            dtg_saveHistory.Columns[0].Width = 80;
            dtg_saveHistory.Columns[1].Width = 200;
            dtg_saveHistory.Columns[2].Width = 100;
            
            con.Close();

        }



        private void Load_TypeLab()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            //SqlConnection CN = new SqlConnection();
            //CN.ConnectionString = "server=192.168.111.225;initial catalog=HR_MNT;uid=hr_sync; pwd=hr@2021;";
            //CN.Open();

            SqlCommand cmd = new SqlCommand("Select [LabID],[LabNameTH]  From [TB_LabName] WHERE [ProductID]='" + Product_id + "' AND [LabID]=1 AND [LabActive] =1", con);
            DataSet ds = new DataSet();
            //ds.Clear();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                // cb_section.DisplayMember = "nameSection_th" + "(" + "nameSection_eng" +")";
                //string name= "nameSection_th" + "(" + "nameSection_eng" + ")";

                cb_typelab.DisplayMember = "LabNameTH";
                cb_typelab.ValueMember = "LabID";
                cb_typelab.DataSource = ds.Tables[0];

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

        private void btn_viweconfig_Click(object sender, EventArgs e)
        {
            if (Configdata_Per == 1)
            {
                F_Setting fst = new F_Setting();
                fst.ShowDialog();
                Load_FileConfig();
            }
            else { MessageBox.Show("สิทธ์การตั้งค่าไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานบันทึก-% แป้งมันสด)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
                

        private void Load_DTG_LabInterface()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            dtg_saveDetail.DataSource = null;

            string sql = "SELECT [LOGID] AS 'ลำดับ',[LabCode] AS 'เลขที่ตัวอย่าง',[LabNameTH] AS 'ประเภท' ,[ValueLab] AS 'ผลวิเคราะห์' FROM [SapthipNewDB].[dbo].[V_DataLab]  Where [LabCode]='" + txt_labSimpleCode.Text+ "'";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "g_v");
            dtg_saveDetail.DataSource = ds.Tables["g_v"];
            con.Close();

            dtg_saveDetail.Columns[0].Width = 80;
            dtg_saveDetail.Columns[1].Width = 230;
            //dtg_saveDetail.Columns[2].Width = 100;
          

        }

        private void btn_monitor_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_monitor.BackColor == Color.Black)
                {
                    F_Monitor n = new F_Monitor();
                    Screen[] screens = Screen.AllScreens;
                    setFormLocation(n, screens[1]);
                    n.Show();


                    btn_monitor.BackColor = Color.Green;
                }
                else
                {

                    F_Monitor obj = (F_Monitor)Application.OpenForms["F_Monitor"];
                    obj.Close();
                    btn_monitor.BackColor = Color.Black;

                }
            }
            catch { MessageBox.Show("ไม่พบหน้าจอที่ 2 ในการแสดงผล","การแสดงผลหน้าจอ 2 ผิดพลาด!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                btn_monitor.BackColor = Color.Black; btn_monitor.Enabled = false;
            }

        }


        private void setFormLocation(Form form, Screen screen)
        {
            // first method
            Rectangle bounds = screen.Bounds;
            form.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);

            // second method
            //Point location = screen.Bounds.Location;
            //Size size = screen.Bounds.Size;

            //form.Left = location.X;
            //form.Top = location.Y;
            //form.Width = size.Width;
            //form.Height = size.Height;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;

            txt_datetime.Text = "วัน:" + dt.ToString("dddd, dd MMMM yyyy", new System.Globalization.CultureInfo("th-TH")) + " เวลา:" + dt.ToString("HH:mm:ss");

            if (dtg_saveDetail.RowCount != Program.countItem_update)
            {
                Program.countItem_update = dtg_saveDetail.RowCount;               
            }

            if (txt_labSimpleCode.Text != "")
            {
                txt_labSimpleCode.Focus();
            }
           // else { timer2.Enabled = false; }
        }

        private void txt_valueSave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txt_labSimpleCode.Text != "")
                {
                    //btn_save.Focus();
                    Save_Data();
                    Check_LabSave();
                    //Load_DTG_LabInterface();
                    InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-us"));
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_clearQRcode_Click(object sender, EventArgs e)
        {
            txt_labSimpleCode.Clear();
            txt_labSimpleCode.Focus();
        }

        private void txt_labSimpleCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)    //Print again
            {
                if (timer1.Enabled == true)
                { timer1.Enabled = false; }
                else  
                { timer1.Enabled = true; }

            }
                if (e.KeyCode == Keys.F2)
            {
                txt_labSimpleCode.Clear();
                txt_labSimpleCode.Focus();
            }

        }

        private void txt_labSimpleCode_MouseClick(object sender, MouseEventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-us"));
        }
    }
}
