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
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Globalization;

namespace Truck_Analytics
{
    public partial class F_ManualdataLab : Form
    {
        public F_ManualdataLab()
        {
            InitializeComponent();
        }

        public string Ticket_code = "";
        public string Simple_code = "";
        public string Product_id = "";
        public string Lab_code = "";

        int Adddata_Per = 0;
        int Viewdata_Per = 0;
        int LabID = 0;
        string Labname = "";
        string Messagemail = "";
        string tokenline = "";
        string ipsvr = "";
        string mailport = "";
        string accalert = "";
        string addpwd = "";
        string ID_AL = "";        
        decimal value = 0;
        int ValueVisualNo = 0;
        int Count_Alert = 0;
        string string1 = "";
        int ID_UserApp = 0;
        int ShoDetail_line = 0;
        int ShoDetail_mail = 0;
       
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
            }
            catch
            {
                MessageBox.Show("ไม่มีการเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานบันทึก-แบบคีย์มือ)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void F_InsertDatalab_Load(object sender, EventArgs e)
        {

            Load_Permission();
            //List_EmailAlert();


            try
            {

                txt_simplecode.Text = Simple_code;

                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql1 = "Select [QueueNo],[ProductName],[Plate1],[TruckTypeName],[ProductID] From [V_InuptLab] Where [TicketCodeIn]='" + Ticket_code + "'";
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

                int w = panel3.Width / 2;
                int h = panel3.Height / 2;


                int x = lbl_quae.Width / 2;
                int z = lbl_quae.Height / 2;

                lbl_quae.Location = new Point(w - x, h - z);

                Load_TypeLab();

            }
            catch
            {
                MessageBox.Show("ไม่พบเลขที่ตัวอย่าง หรือสิทธ์ในการบันทึกไม่ถูกต้อง กรุณาตรวจสอบข้อมูล/ติดต่อผู้ดูแลระบบ", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }


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
            string sql1 = "Select [LabID] AS รหัส,[LabNameTH] AS 'ชื่อประเภท','' AS 'ผลวิเคราะห์ที่ได้'  From [dbo].[TB_LabName] WHERE [ProductID]='" + Product_id + "' AND [LabActive]=1 AND [LabtypeID] <> 2 AND [LabtypeID] <> 6 AND [Dilldata]=0  Order by [SortData]";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);

            da1.Fill(ds1, "g_l");
            dtg_valuelab.DataSource = ds1.Tables["g_l"];

            dtg_valuelab.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            try
            {
                //SqlDataAdapter da = new SqlDataAdapter();
                //da.SelectCommand = cmd;
                //da.Fill(ds);

                //cb_typelab.DisplayMember = "LabTypeNameTH";
                //cb_typelab.ValueMember = "LabTypeID";

                ////cb_typelab.DisplayMember = "VisualName";
                ////cb_typelab.ValueMember = "VisualType";

                //cb_typelab.DataSource = ds.Tables[0];

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

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
                string SimpleCode = "";
                string textLength = Simple_code;
                txt_simplecode.Text = Simple_code;


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

                    for (int i = 0; i < dtg_valuelab.RowCount; i++)
                    {
                        value = Convert.ToDecimal(dtg_valuelab.Rows[i].Cells[2].Value.ToString());
                        LabID = Convert.ToInt32(dtg_valuelab.Rows[i].Cells[0].Value.ToString());
                        Labname = dtg_valuelab.Rows[i].Cells[1].Value.ToString().Trim();

                        con.Open();
                        string sql = "Insert Into [TB_LabData](TicketCodeIn, LabID,SimpleCode,LabCode,ValueLab,CreateDate,CreateBy,InActive) Values('" + Ticket_code + "', '" + LabID + "', '" + SimpleCode + "','" + Lab_code + "', " + value + ", '" + date + "', '" + Program.user_login + "',1)";
                        SqlCommand CM2 = new SqlCommand(sql, con);
                        SqlDataReader DR2 = CM2.ExecuteReader();
                        con.Close();


                        //List Email
                        try
                        {
                            SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
                            con1.ConnectionString = Program.pathdb_Weight;
                            SqlDataAdapter dtAdapter1 = new SqlDataAdapter();

                            String Sample = "";

                            try
                            {
                                int LogID_Min = 0;
                                int LogID_Max = 0;
                                double Value_Min = 0;
                                double Value_Max = 0;
                                //ValueVisualNo
                                //
                                con1.Open();
                                string sql1 = "Select Top (1) [LOGID],[Min] From [dbo].[TB_ValueLab]  Where  LabID= " + LabID + " AND [Min] <" + value + " AND Alert_Lab =1 Order by LOGID desc";
                                SqlCommand CM1 = new SqlCommand(sql1, con1);
                                SqlDataReader DR1 = CM1.ExecuteReader();
                                DR1.Read();
                                {
                                    LogID_Min = Convert.ToInt16(DR1["LOGID"].ToString().Trim());
                                    Value_Min = Convert.ToDouble(DR1["Min"].ToString().Trim());
                                }
                                DR1.Close();
                                con1.Close();


                                con1.Open();
                                string sql3 = "Select Top (1) LOGID,[Min] From [dbo].[TB_ValueLab]  Where  LabID= " + LabID + " AND [Max] >= " + value + " AND Alert_Lab =1";
                                SqlCommand CM3 = new SqlCommand(sql3, con1);
                                SqlDataReader DR3 = CM3.ExecuteReader();
                                DR3.Read();
                                {
                                    LogID_Max = Convert.ToInt16(DR3["LOGID"].ToString().Trim());
                                    Value_Max = Convert.ToDouble(DR3["Min"].ToString().Trim());
                                }
                                DR3.Close();
                                con1.Close();

                                if (Value_Max > Value_Min || Value_Max == Value_Min)
                                {
                                    ValueVisualNo = LogID_Max;
                                }

                                else { ValueVisualNo = LogID_Min; }
                            }
                            catch { }


                            Sample = "ประเภท: " + Labname + " ผล: " + value;

                                if (Messagemail.Contains(Sample) == false)
                                {
                                    Messagemail += Sample + Environment.NewLine;
                                }
                                                                                                                                                                                                                                    
                            if (ValueVisualNo != 0)
                            {
                                //List_EmailAlert();
                                //Load_ConfigAlert();
                            }

                            if (tokenline != "")
                            {                                
                                    string MsgLine = "แจ้งเตือนสินค้าไม่ผ่านเกณฑ์" + Environment.NewLine + "วันที่:" + DateTime.Now.ToShortDateString() + " เวลา: " + DateTime.Now.ToLongTimeString() + Environment.NewLine + "ประเภท: " + txt_product.Text.Trim() + " เลขที่ชั่ง: " + Ticket_code + " เลขที่ตัวอย่าง: " + txt_simplecode.Text.Trim() + Environment.NewLine + " คิวที่: " + lbl_quae.Text.Trim() + " ชนิดรถ: " + txt_trucktype.Text.Trim() + " ทะเบียน: " + txt_truckno.Text.Trim();

                                    lineNotify(MsgLine);                               

                                if (ShoDetail_line == 1)
                                {                                   
                                        String s = Sample;
                                        s = s.Replace("%", " เปอร์เซ็นต์");

                                        string MsgLine2 = "";
                                        if (i < dtg_valuelab.RowCount)
                                        {
                                            //ผลการวิเคราะห์:ประเภท: ป่น ผล: 5%
                                            MsgLine2 = "การวิเคราะห์-" + s;
                                            lineNotify(MsgLine2);
                                        }

                                        if (i == dtg_valuelab.RowCount - 1)
                                        {
                                            MsgLine2 = " -:- ระบบแจ้งเตือนผลไม่ผ่านเกณฑ์ (Truck Scale Systems V 5.0.5) -:-";

                                            lineNotify(MsgLine2);
                                        }                                   
                                }

                            }

                        }
                        catch { }

                        //List_EmailAlert();
                    }

                    //Load_ConfigAlert();  //Load Config Alert mail & line
                    Load_CheckWaring();  //Check Count send mail
                    Send_Alert();    // Send mail
                    Save_App();  //update database of request approved
                    MessageBox.Show("บันทึกสำเร็จ!!", "รายงานการบันทึก", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }

            catch
            {
                MessageBox.Show("คุณใส่รูปแบบข้อมูลไม่ถูกต้อง", "รูปแบบข้อมูลผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txt_value.ForeColor = Color.Red;
                //txt_value.Focus();
            }

        }

        private void Save_App()
        {
            if (ID_UserApp > 0)
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter1 = new SqlDataAdapter();

                con.Open();
                string sql1 = "Update [TB_WeightData] Set  [StatusID]=2 Where [TicketCodeIn] = '" + Ticket_code + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                con.Close();

                string date = Program.Date_Now + ' ' + DateTime.Now.ToString("HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));

                con.Open();
                string sql = "Insert Into [TB_Approved] ([TicketCodeIn],[SimpleCode],[CreateDate],[ID_UserApp],[StatusID]) Values('" + Ticket_code + "','" + Simple_code + "', '" + date + "', " + ID_UserApp + ",2)";
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

                        mailMessage.Subject = "การวิเคราะห์ทางกายภายไม่ผ่านเกณฑ์ตัวอย่างที่ : " + txt_simplecode.Text.Trim();
                        mailMessage.Body = "ชื่อสินค้า: " + txt_product.Text.Trim() + " เลขที่บัตรชั่ง: " + Ticket_code + " เลขที่ตัวอย่าง: " + txt_simplecode.Text.Trim() +
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

            //SqlConnection con = new SqlConnection(Program.pahtdb);
            //con.ConnectionString = Program.pahtdb;
            //SqlDataAdapter dtAdapter = new SqlDataAdapter();

            //con.Open();
            //string sql1 = "Select Count([ValueVisualNo]) AS 'Check_ALT' From [dbo].[V_AlertSMG] Where [ProductID]='" + ProductID + "' AND [ValueVisualNo]='" + ValueVisualNo + "' AND [ID_Frm_TypeLab]=2";
            //SqlCommand CM1 = new SqlCommand(sql1, con);
            //SqlDataReader DR1 = CM1.ExecuteReader();

            //DR1.Read();
            //{
            //    Count_Alert += Convert.ToInt16(DR1["Check_ALT"].ToString().Trim());
            //}
            //DR1.Close();
        }

        
        private void Load_CheckWaring()
        {
            ///Concept flow 
            ///1. load value from setup alert report on true
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql1 = "Select Count([LOGID]) AS 'Check_ALT' From [dbo].[V_AlertSMG_Lab] Where [ProductID]='" + Product_id + "' AND [LOGID]='" + ValueVisualNo + "' AND [ID_Frm_TypeLab]=1 AND [ID_ALStatus] =1 AND [ID_ALStatus] =1";
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
                string sql2 = "Select [ID_User] From [dbo].[V_AlertSMG_Lab] Where [ProductID]='" + Product_id + "' AND [LOGID]='" + ValueVisualNo + "' AND [ID_Frm_TypeLab]=1 AND [App_Sts]=1 AND [Status_RP]=1  AND [Level_App]=1 AND [ID_ALStatus]";
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

        private void List_EmailAlert()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql1 = "Select  DISTINCT([ID_ALRP]),[Email],[ID_AL] From [dbo].[V_AlertSMG_Lab] Where [ProductID]='" + Product_id + "' AND [LabID]='" + LabID + "' AND [ID_Frm_TypeLab]=1 AND [LOGID]=" + ValueVisualNo + " AND [Status_RP]=1  AND [ID_ALStatus] =1 ";
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

        private void Load_ConfigAlert()
        {
            SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
            con1.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con1.Open();

            string sql1 = "SELECT * FROM  [dbo].[V_Alert_Setting] Where [ID_AL]=" + ID_AL + " AND [ID_ALdStatus] = 1";
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


        private void txt_value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Save_Data();
            }
        }
    }
}
