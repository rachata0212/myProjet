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

namespace Truck_Analytics
{
    public partial class Sub_Fapproval : Form
    {
        public Sub_Fapproval()
        {
            InitializeComponent();
        }

        int StS_Alert = 0;
        int e_RowIndex = 0;
        int ID_AL = 0;
        int ID_LineGroup = 0;
        int ID_TypeLoad = 0;
        int id_filterAlert = 0;
        int ID_ALRP = 0;

        // Log
        string Msg = "";
        string Log_OldValue = "-";
        string Log_NewValue = "-";

        private void chk_newAlert_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cb_menuAlert_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                if (tbc_mailAlert.SelectedIndex == 2)
                {
                    con.Open();
                    string sql6 = "SELECT * FROM  [dbo].[TB_Menu] WHERE [ID_Menu]=" + cb_menuAlert.SelectedValue.ToString() + "";
                    SqlCommand CM6 = new SqlCommand(sql6, con);
                    SqlDataReader DR6 = CM6.ExecuteReader();

                    DR6.Read();
                    {
                        //lbl_Menupermission.Text = DR6["Function_Menu"].ToString().Trim();
                    }
                    DR6.Close();
                    con.Close();

                    Check_StatusAlert();
                }

            }
            catch { con.Close(); }
        }

        private void cb_product_Alert_SelectedIndexChanged(object sender, EventArgs e)
        {
            Check_StatusAlert();
        }

        private void Check_StatusAlert()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                con.Open();

                string sql5 = "SELECT [ID_AL],[ID_ALStatus] FROM  [dbo].[TB_Alert] WHERE [ID_Menu]=" + cb_menuAlert.SelectedValue.ToString().Trim() + " AND [ProductID]='" + cb_product_Alert.SelectedValue.ToString().Trim() + "'  AND  [ID_processType]='" + cb_alertProcessIN.SelectedValue.ToString().Trim() + "' ";


                SqlCommand CM5 = new SqlCommand(sql5, con);
                SqlDataReader DR5 = CM5.ExecuteReader();

                DR5.Read();
                {
                    ID_AL = Convert.ToInt32(DR5["ID_AL"].ToString().Trim());

                    if (DR5["ID_ALStatus"].ToString().Trim() == "True")
                    {
                        chk_alert.Checked = true;
                    }
                    else { chk_alert.Checked = false; }

                    if (ID_AL != 0) { chk_newAlert.Enabled = false; }
                }
                DR5.Close();
                con.Close();
            }

            catch
            { con.Close(); ID_AL = 0; chk_newAlert.Enabled = true; chk_alert.Checked = false; btn_saveAlert.Enabled = true; }

            Load_emailGroup();
            Load_lineGroup();
        }

        private void cb_alertProcessIN_SelectedIndexChanged(object sender, EventArgs e)
        {
            Check_StatusAlert();
        }

        private void Load_emailGroup()
        {
            //SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            //con.ConnectionString = Program.pathdb_Weight;
            //SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                //con.Open();

                //dtg_emailGroup.DataSource = null;

                //string sql = "SELECT  [ID_ALtype] AS 'รหัส',[Name_ALtype] AS 'ประเภท',[Val1_ALT] AS 'เครื่องแม่ข่ายส่งเมล์',[Val2_ALT] AS 'เลขพอร์ต',[Val3_ALT] AS 'อีเมล์แจ้ง',[Val4_ALT] AS 'รหัสแจ้ง'   FROM [dbo].[V_Alert_Setting] Where [ID_Group] =1 AND [ID_Menu] = " + cb_menuAlert.SelectedValue.ToString() + " AND [ProductID] = '" + cb_product_Alert.SelectedValue.ToString() + "'";

                //SqlDataAdapter da1 = new SqlDataAdapter(sql, con);
                //DataSet ds1 = new DataSet();
                //da1.Fill(ds1, "g_mail");
                //dtg_emailGroup.DataSource = ds1.Tables["g_mail"];
                //con.Close();
            }
            catch {// con.Close(); 
            }

        }

        private void Load_lineGroup()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                con.Open();
                dtg_lineGroup.DataSource = null;

                string sql = "SELECT id_ALline AS 'รหัสกลุ่ม',AL_lineNameGroup AS 'ชือกลุ่ม',AL_lineNameToken AS 'รหัสโทเค็นไลน์',AL_lineSTSmsg AS 'ส่งข้อความ',AL_lineSTSimg AS 'ส่งรูปภาพ',AL_lineSTSdetail AS 'ส่งรายละเอียด',AL_lineStatus AS 'สถานะใช้งาน' FROM [dbo].[TB_Alertline] Where [ID_AL] = " + ID_AL + " ";

                SqlDataAdapter da1 = new SqlDataAdapter(sql, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_alert");
                dtg_lineGroup.DataSource = ds1.Tables["g_alert"];
                con.Close();

                dtg_lineGroup.Columns[0].Width = 80;
                dtg_lineGroup.Columns[1].Width = 150;
            }
            catch { con.Close(); }

        }

        private void btn_saveAlert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            if (chk_alert.Checked == true) { StS_Alert = 1; }

            if (chk_newAlert.Checked == true)  //Insert
            {
                con.Open();
                string sql2 = "Insert Into [dbo].[TB_Alert] ([ID_Menu],[ProductID],[ID_processType],[ID_ALStatus]) Values(" + cb_menuAlert.SelectedValue.ToString() + ",'" + cb_product_Alert.SelectedValue.ToString() + "','" + cb_alertProcessIN.SelectedValue.ToString().Trim() + "'," + StS_Alert + ")";
                SqlCommand CM2 = new SqlCommand(sql2, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();

                Msg = "Insert New Record in Alert Report Setting!";
                Log_NewValue = "ID_Menu = " + cb_menuAlert.SelectedValue.ToString() +
                        "," + "ProductID = " + cb_product_Alert.SelectedValue.ToString() +
                "," + "ID_processType = " + cb_alertProcessIN.SelectedValue.ToString().Trim() +
                "," + "ID_ALStatus = " + StS_Alert.ToString();
                Log_OldValue = "-";

                //Select Max ID from Table Alert == X
                con.Open();
                string sql3 = "SELECT Max([ID_AL]) AS 'New_ID'  FROM [dbo].[TB_Alert] ";
                SqlCommand CM3 = new SqlCommand(sql3, con);
                SqlDataReader DR3 = CM3.ExecuteReader();

                DR3.Read();
                {
                    ID_AL = Convert.ToInt16(DR3["New_ID"].ToString().Trim());
                }
                DR3.Close();
                con.Close();
            }


            else   // Update config
            {

                con.Open();
                string sql2 = "Update [dbo].[TB_Alert] Set [ID_ALStatus] =" + StS_Alert + " WHERE [ID_AL] = " + ID_AL + "";
                SqlCommand CM2 = new SqlCommand(sql2, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();

                Msg = "Update to Record in Alert Report Setting!";
                Log_OldValue = "ID_ALStatus =" + cb_menuAlert.SelectedValue.ToString() +
              "," + " Wherer ID_AL =" + StS_Alert.ToString();
                Log_NewValue = "-";
            }

            //btn_saveAlert.Enabled = false;


            Class_Log CL = new Class_Log();
            CL.tbname = Msg;
            CL.oldvalue = Log_OldValue;
            CL.newvalue = Log_NewValue;
            CL.Save_log();

            chk_newAlert.Checked = false;
            MessageBox.Show("ตั้งหัวข้อการแจ้งเตือนสำเร็จ !!", "บันทึกสำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Sub_Fapproval_Load(object sender, EventArgs e)
        {
            Load_Product();
            Load_mailSetup();
            Load_mailGroup();
            Load_Menu_Alert();
            Load_Alert_ProcessIN();        
        }

        private void Load_Product()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            try
            {
                //Product 
                SqlCommand cmd = new SqlCommand("Select [ProductID],[ProductID] +':'+ [ProductName] AS 'ProductName' From  [dbo].[TB_Products]  Where [StatusActive] =1", con);


                DataSet ds7 = new DataSet();
                //ds.Clear();
                SqlDataAdapter da7 = new SqlDataAdapter();
                da7.SelectCommand = cmd;
                da7.Fill(ds7);
                cb_product_Alert.DataSource = ds7.Tables[0];
                cb_product_Alert.DisplayMember = "ProductName";
                cb_product_Alert.ValueMember = "ProductID";
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

        private void Load_Menu_Alert()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand(" Select [ID_Menu],TRIM([Name_Menu]) AS 'Name_Menu'  From  [dbo].[TB_Menu] WHERE [ID_Menutype] = 5", con);
            DataSet ds = new DataSet();
            //ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            //Load product tab weight scale Setup
            cb_menuAlert.DataSource = ds.Tables[0];
            cb_menuAlert.DisplayMember = "Name_Menu";
            cb_menuAlert.ValueMember = "ID_Menu";
        }


        private void Load_Alert_ProcessIN()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand(" Select [prot_id],TRIM([prot_form]) AS 'Name_Menu'  From  [dbo].[TB_ProcessType] ", con);
            DataSet ds = new DataSet();
            //ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            //Load product tab weight scale Setup
            cb_alertProcessIN.DataSource = ds.Tables[0];
            cb_alertProcessIN.DisplayMember = "Name_Menu";
            cb_alertProcessIN.ValueMember = "prot_id";
        }

        private void Load_mailGroup()
        {

            cbo_mailGrop.DataSource = null;

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("SELECT [id_ALmail],[AL_mailNameGroup] FROM  [dbo].[TB_Alertmail] ", con);

            //SELECT  [VisualType] ,[VisualName]  FROM  [dbo].[TB_VISUALTYPE] WHERE [VisualProductID]='RM-004' AND [VisualopServ]=0 AND [VisualTypeActive]=1
            DataSet ds = new DataSet();
            //ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            //Load product tab weight scale Setup
            cbo_mailGrop.DataSource = ds.Tables[0];
            cbo_mailGrop.DisplayMember = "AL_mailNameGroup";
            cbo_mailGrop.ValueMember = "id_ALmail";

            //chk_newvisual.Checked = false;
            chk_mailSMG.Checked = false;
            chk_mailIMG.Checked = false;
            chk_mailDetail.Checked = false;
            chk_enableMailservice.Checked = false;
            chk_newMailGroup.Checked = false;
        }


        private void Load_mailSetup()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

                con.Open();
                string sql7 = "Select *  From [dbo].[TB_AlertSetup]";
                SqlCommand CM7 = new SqlCommand(sql7, con);
                SqlDataReader DR7 = CM7.ExecuteReader();

                DR7.Read();
                {
                    txt_mail_ipSRV.Text = DR7["IP_Srvmail"].ToString().Trim();
                    txt_mailPort.Text = DR7["Port"].ToString().Trim();
                    txt_mail_Account.Text = DR7["Email"].ToString().Trim();
                    txt_mail_pwd.Text = DR7["pwd"].ToString().Trim();

                    if (DR7["Status"].ToString().Trim() == "True")
                    {
                        chk_mailsetup.Checked = true;
                    }
                    else { chk_mailsetup.Checked = false; }

                }
                DR7.Close();
                con.Close();
            }
            catch { }
        }

        private void btn_mail_Test_Click(object sender, EventArgs e)
        {
            if (txt_mailTest.Text != "")
            {
                int port = Convert.ToInt16(txt_mailPort.Text);



                //smtp.UseDefaultCredentials = True;
                //smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);


                SmtpClient smtpClient = new SmtpClient(txt_mail_ipSRV.Text.Trim(), port);
                //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(txt_mail_Account.Text.Trim());
                mailMessage.To.Add(txt_mailTest.Text.Trim());
                mailMessage.Subject = "--:: ทดสอบการส่งอีเมล์จาก ระบบตาชั่ง ::--";
                mailMessage.Body = "ทดสอบส่งวันที่ :" + DateTime.Now.ToShortDateString() + " เวลา:" + DateTime.Now.ToLongTimeString() +
                    "\r\n" + "ประเภทการแจ้งเตือน:" + cb_menuAlert.Text.Trim() + " สินค้า: " + cb_product_Alert.Text.Trim() +
                    "\r\n" +
                    "------ Truck Scale Systems V 5.0.3 ------";


                ////smtpClient.UseDefaultCredentials = false;

                smtpClient.Credentials = new System.Net.NetworkCredential(txt_mail_Account.Text.Trim(), txt_mail_pwd.Text.Trim());
                //////smtpClient.Credentials = new System.Net.NetworkCredential(txt_accountAlertMail.Text.Trim(), txt_pwdmailAlert.Text.Trim());
                smtpClient.UseDefaultCredentials = true;
                //smtpClient.EnableSsl = true;

                ////ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                try
                {

                    smtpClient.Send(mailMessage);
                    MessageBox.Show("ส่งเมล์ทดสอบสำเร็จ", "รายงานทดสอบการส่งอีเมล์", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "รายงานทดสอบการส่งอีเมล์ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_mailTest.Focus();
                }
                //finally
                //{

                //    MessageBox.Show("ส่งเมล์ทดสอบสำเร็จ", "รายงานทดสอบการส่งอีเมล์", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            else { MessageBox.Show("ไม่ได้ใส่อีเมล์ผู้ทดสอบ", "รายงานทดสอบการส่งอีเมล์ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error); txt_mailTest.Focus(); }

           
        }

        private void btn_SaveMailsetup_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            int sts_mail = 0;
            int port_no = 0;

            if (txt_mailPort.Text != "")
            {
                port_no = Convert.ToInt16(txt_mailPort.Text);
            }
            if (chk_mailsetup.Checked == true)
            { sts_mail = 1; }

            con.Open();
            string sql3 = "Update [dbo].[TB_AlertSetup]  Set [IP_Srvmail] = '" + txt_mail_ipSRV.Text.Trim() + "',[Port]=" + port_no + ",[Email]='" + txt_mail_Account.Text.Trim() + "',[pwd]='" + txt_mail_pwd.Text.Trim() + "',[Status]=" + sts_mail + "";
            SqlCommand CM3 = new SqlCommand(sql3, con);
            SqlDataReader DR3 = CM3.ExecuteReader();
            con.Close();

            Msg = "Update to Record in Alert Setup!";
            Log_OldValue = "IP_Srvmail = " + txt_mail_ipSRV.Text.Trim() +
                "," + "Port = " + port_no.ToString() +
                "," + "Email = " + txt_mail_Account.Text.Trim() +
                "," + "Status = " + sts_mail.ToString();
            Log_NewValue = "-";

            Class_Log CL = new Class_Log();
            CL.oldvalue = Log_OldValue;
            CL.newvalue = Log_NewValue;
            CL.Save_log();

            MessageBox.Show("บันทึกสำเร็จ!!", "รายงานการบันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void chk_mailsetup_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void chk_newMailGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_newMailGroup.Checked == true)
            {
                cbo_mailGrop.DropDownStyle = ComboBoxStyle.DropDown;
                cbo_mailGrop.Text = "";
            }
            else
            {
                cbo_mailGrop.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void cbo_mailGrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

                chk_mailSMG.Checked = false;
                chk_mailIMG.Checked = false;
                chk_mailDetail.Checked = false;
                chk_enableMailservice.Checked = false;

                con.Open();
                string sql5 = "SELECT * FROM  [dbo].[TB_Alertmail] WHERE [id_ALmail]=" + cbo_mailGrop.SelectedValue.ToString().Trim() + "";

                SqlCommand CM5 = new SqlCommand(sql5, con);
                SqlDataReader DR5 = CM5.ExecuteReader();

                DR5.Read();
                {
                    string xx = DR5["AL_mailSTSmsg"].ToString().Trim();

                    if (DR5["AL_mailSTSmsg"].ToString().Trim() == "True")
                    { chk_mailSMG.Checked = true; }

                    if (DR5["AL_mailSTSimg"].ToString().Trim() == "True")
                    { chk_mailIMG.Checked = true; }

                    if (DR5["AL_mailSTSdetail"].ToString().Trim() == "True")
                    { chk_mailDetail.Checked = true; }

                    if (DR5["AL_ALStatus"].ToString().Trim() == "True")
                    { chk_enableMailservice.Checked = true; }

                }
                DR5.Close();
                con.Close();
            }
            catch { }
        }

        private void chk_enableMailservice_CheckedChanged(object sender, EventArgs e)
        {
            btn_saveAlert.Enabled = true;
        }

        private void chk_mailDetail_CheckedChanged(object sender, EventArgs e)
        {
            btn_saveAlert.Enabled = true;
        }

        private void btn_saveAlertMail_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            int STS_mailSMG = 0;
            int STS_mailIMG = 0;
            int STS_mailDetail = 0;
            int AL_ALStatus = 0;

            if (chk_mailSMG.Checked == true)
            { STS_mailSMG = 1; }

            if (chk_mailIMG.Checked == true)
            {
                STS_mailIMG = 1;
            }

            if (chk_mailDetail.Checked == true)
            {
                STS_mailDetail = 1;
            }

            if (chk_enableMailservice.Checked == true)
            {
                AL_ALStatus = 1;
            }

            if (ID_AL != 0)
            {
                if (chk_newMailGroup.Checked == true)
                {
                    con.Open();
                    string sql4 = "Insert Into [dbo].[TB_Alertmail] ([AL_mailNameGroup],[AL_mailSTSmsg],[AL_mailSTSimg],[AL_mailSTSdetail],[AL_mailStatus],[ID_AL]) Values('" + cbo_mailGrop.Text + "'," + STS_mailSMG + ", " + STS_mailIMG + "," + STS_mailDetail + "," + AL_ALStatus + "," + ID_AL + ")";
                    SqlCommand CM4 = new SqlCommand(sql4, con);
                    SqlDataReader DR4 = CM4.ExecuteReader();
                    con.Close();

                    Msg = "Insert New Record in Mail Alert!";
                    Log_NewValue = "AL_mailNameGroup = " + cbo_mailGrop.Text +
                      "," + "AL_mailSTSmsg = " + STS_mailSMG.ToString() +
                      "," + "AL_mailSTSimg = " + STS_mailIMG.ToString() +
                      "," + "AL_mailSTSdetail = " + STS_mailDetail.ToString() +
                      "," + "AL_mailStatus = " + AL_ALStatus.ToString() +
                      "," + "ID_AL = " + ID_AL.ToString();
                    Log_OldValue = "-";

                }

                else
                {
                    con.Open();
                    string sql3 = "Update [dbo].[TB_Alertmail]  Set [AL_mailNameGroup] = '" + cbo_mailGrop.Text + "',[AL_mailSTSmsg]=" + STS_mailSMG + ",[AL_mailSTSimg]=" + STS_mailIMG + ",[AL_mailSTSdetail]=" + STS_mailDetail + ",[AL_mailStatus]=" + AL_ALStatus + " WHeRE [id_ALmail]=" + cbo_mailGrop.SelectedValue.ToString() + "";
                    SqlCommand CM3 = new SqlCommand(sql3, con);
                    SqlDataReader DR3 = CM3.ExecuteReader();
                    con.Close();

                    Msg = "Update to Record in Mail Alert!";
                    Log_OldValue = "AL_mailSTSmsg = " + STS_mailSMG.ToString() +
                         "," + "AL_mailSTSimg = " + STS_mailIMG.ToString() +
                         "," + "AL_mailSTSdetail = " + STS_mailDetail.ToString() +
                         "," + "AL_mailStatus = " + AL_ALStatus.ToString() +
                         "," + "Where id_ALmail = " + cbo_mailGrop.SelectedValue.ToString();
                    Log_NewValue = "-";

                }

                MessageBox.Show("บันทึกสำเร็จ!!", "รายงานการบันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Class_Log CL = new Class_Log();
                CL.tbname = Msg;
                CL.oldvalue = Log_OldValue;
                CL.newvalue = Log_NewValue;
                CL.Save_log();

            }
            else
            {
                MessageBox.Show("บันทึกล้มเหล้ว!! เนื่องจากไม่ได้เลือก/ไม่มี กลุ่มขั้นตอนการทำงาน กรุณาเลือกกลุ่ม/สร้างขั้นตอนการทำงานก่อน", "รายงานการบันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            Load_mailGroup();
        }

        private void dtg_maiList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            e_RowIndex = e.RowIndex;
        }

        private void dtg_mailAdd_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            e_RowIndex = e.RowIndex;
        }

        private void btn_addrowlist_Click(object sender, EventArgs e)
        {
            if (e_RowIndex != -1 && dtg_maiList.Rows[e_RowIndex].DefaultCellStyle.ForeColor != Color.Red)
            {
                string[] row1 = new string[] { dtg_maiList.Rows[e_RowIndex].Cells[0].Value.ToString().Trim(), dtg_maiList.Rows[e_RowIndex].Cells[1].Value.ToString().Trim(), dtg_maiList.Rows[e_RowIndex].Cells[2].Value.ToString().Trim() };
                dtg_mailAdd.Rows.Add(row1);

                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                string sql = "Insert Into [dbo].[TB_AlertmailDetail] ([ALiduser_Email],[id_ALmail]) Values(" + dtg_maiList.Rows[e_RowIndex].Cells[0].Value.ToString().Trim() + "," + cbo_mailGrop.SelectedValue.ToString() + ")";
                con.Open();
                SqlCommand CM3 = new SqlCommand(sql, con);
                SqlDataReader DR3 = CM3.ExecuteReader();
                con.Close();

                dtg_maiList.Rows[e_RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                e_RowIndex = -1;
                lbl_rowcountAddEmail.Text = "จำนวน: " + dtg_mailAdd.RowCount.ToString() + "ข้อมูล";



            }
            else { MessageBox.Show("รายการนี้ได้ถูกเลือกไปแล้ว", "การเลือกผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_addAllrowlist_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtg_maiList.RowCount; i++)
            {
                string[] row1 = new string[] { dtg_maiList.Rows[i].Cells[0].Value.ToString().Trim(), dtg_maiList.Rows[i].Cells[1].Value.ToString().Trim(), dtg_maiList.Rows[i].Cells[2].Value.ToString().Trim() };
                dtg_mailAdd.Rows.Add(row1);

                dtg_maiList.Rows[i].DefaultCellStyle.ForeColor = Color.Red;

            }

            lbl_rowcountAddEmail.Text = "จำนวน: " + dtg_mailAdd.RowCount.ToString() + "ข้อมูล";
        }

        private void btn_removeAllrowlist_Click(object sender, EventArgs e)
        {
            if (dtg_mailAdd.RowCount != 0)
            {
                dtg_mailAdd.Rows.Clear();
                for (int i = 0; i < dtg_maiList.RowCount; i++)
                {
                    dtg_maiList.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }

                lbl_rowcountAddEmail.Text = "จำนวน: " + dtg_mailAdd.RowCount.ToString() + "ข้อมูล";
            }

        }

        private void btn_removerowlist_Click(object sender, EventArgs e)
        {
            if (dtg_mailAdd.RowCount != 0 && e_RowIndex != -1)
            {
                for (int i = 0; i < dtg_maiList.RowCount; i++)
                {
                    if (dtg_maiList.Rows[i].Cells[0].Value.ToString().Trim() == dtg_mailAdd.Rows[e_RowIndex].Cells[0].Value.ToString().Trim())

                    {

                        SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                        con.ConnectionString = Program.pathdb_Weight;
                        SqlDataAdapter dtAdapter = new SqlDataAdapter();
                        string sql = "Delete [dbo].[TB_AlertmailDetail] WHERE [ALiduser_Email]= " + dtg_mailAdd.Rows[e_RowIndex].Cells[0].Value.ToString().Trim() + "";
                        con.Open();
                        SqlCommand CM3 = new SqlCommand(sql, con);
                        SqlDataReader DR3 = CM3.ExecuteReader();
                        con.Close();

                        dtg_maiList.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        dtg_mailAdd.Rows.RemoveAt(e_RowIndex);
                        i = dtg_maiList.RowCount;
                        e_RowIndex = -1;
                        lbl_rowcountAddEmail.Text = "จำนวน: " + dtg_mailAdd.RowCount.ToString() + "ข้อมูล";
                    }
                }
            }
            else if (dtg_mailAdd.RowCount != 0)
            {
                dtg_mailAdd.Rows.Clear();
                e_RowIndex = -1;
                lbl_rowcountAddEmail.Text = "จำนวน: " + dtg_mailAdd.RowCount.ToString() + "ข้อมูล";
            }

            else
            { MessageBox.Show("ไม่มีรายการให้เลือก", "การเลือกผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_SavelineGroup_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

                int STS_lineSMG = 0;
                int STS_lineIMG = 0;
                int STS_lineDEtail = 0;
                int STST_line = 0;

                if (chk_enableLineMSG.Checked == true) { STS_lineSMG = 1; }
                if (chk_enableLineIMG.Checked == true) { STS_lineIMG = 1; }
                if (chk_shoLineDetail.Checked == true) { STS_lineDEtail = 1; }
                if (chk_enableLineservice.Checked == true) { STST_line = 1; }

                if (ID_AL != 0)
                {
                    if (chk_newlineGroup.Checked == true)
                    {
                        con.Open();
                        string sql5 = "Insert Into [dbo].[TB_Alertline] ([AL_lineNameGroup],[AL_lineNameToken],[AL_lineSTSmsg],[AL_lineSTSimg],[AL_lineSTSdetail],[AL_lineStatus],[ID_AL]) Values('" + txt_lineNamegroup.Text.Trim() + "','" + txt_tokenLine.Text.Trim() + "', " + STS_lineSMG + "," + STS_lineIMG + "," + STS_lineDEtail + "," + STST_line + "," + ID_AL + ")";
                        SqlCommand CM5 = new SqlCommand(sql5, con);
                        SqlDataReader DR5 = CM5.ExecuteReader();
                        con.Close();

                        Msg = "Insert New Record in Line Alert!";
                        Log_NewValue = "AL_lineNameGroup = " + txt_lineNamegroup.Text.Trim() +
                            "," + "AL_lineNameToken = " + txt_tokenLine.ToString() +
                            "," + "AL_lineSTSmsg = " + STS_lineSMG.ToString() +
                            "," + "AL_lineSTSimg = " + STS_lineIMG.ToString() +
                            "," + "AL_lineSTSdetail = " + STS_lineDEtail.ToString() +
                            "," + "AL_lineStatus = " + STST_line.ToString() +
                            "," + "ID_AL = " + ID_AL.ToString();
                        Log_OldValue = "-";
                    }

                    else
                    {
                        con.Open();
                        string sql4 = "Update [dbo].[TB_Alertline]  Set [AL_lineNameGroup] = '" + txt_lineNamegroup.Text.Trim() + "',[AL_lineNameToken]='" + txt_tokenLine.Text.Trim() + "',[AL_lineSTSmsg] = " + STS_lineSMG + ",[AL_lineSTSimg]=" + STS_lineIMG + ",[AL_lineSTSdetail]=" + STS_lineDEtail + ",[AL_lineStatus]=" + STST_line + " WHeRE [id_ALline]=" + ID_LineGroup + "";

                        SqlCommand CM4 = new SqlCommand(sql4, con);
                        SqlDataReader DR4 = CM4.ExecuteReader();
                        con.Close();

                        Msg = "Update to Record in Line Alert!";
                        Log_OldValue = "AL_lineNameGroup = " + txt_lineNamegroup.Text.Trim() +
                            "," + "AL_lineNameToken = " + txt_tokenLine.ToString() +
                            "," + "AL_lineSTSmsg = " + STS_lineSMG.ToString() +
                            "," + "AL_lineSTSimg = " + STS_lineIMG.ToString() +
                            "," + "AL_lineSTSdetail = " + STS_lineDEtail.ToString() +
                            "," + "AL_lineStatus = " + STST_line.ToString() +
                            "," + "id_ALline = " + ID_LineGroup.ToString();
                        Log_NewValue = "-";

                    }

                    Class_Log CL = new Class_Log();
                    CL.tbname = Msg;
                    CL.oldvalue = Log_OldValue;
                    CL.newvalue = Log_NewValue;
                    CL.Save_log();

                    txt_lineNamegroup.Clear();
                    txt_tokenLine.Clear();

                    MessageBox.Show("บันทึกข้อมูลสำเร็จ!!", "รายงานการบันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Load_lineGroup();
                }
                else
                {
                    MessageBox.Show("บันทึกล้มเหล้ว!! เนื่องจากไม่ได้เลือก/ไม่มี กลุ่มขั้นตอนการทำงาน กรุณาเลือกกลุ่ม/สร้างขั้นตอนการทำงานก่อน", "รายงานการบันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void chk_enableLineMSG_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                btn_saveAlert.Enabled = true;
            }
            catch { }
        }

        private void chk_shoLineDetail_CheckedChanged(object sender, EventArgs e)
        {
            btn_saveAlert.Enabled = true;
        }

        private void chk_enableLineservice_CheckedChanged(object sender, EventArgs e)
        {
            if (ID_AL == 0) { }
        }

        private void btn_linetest_Click(object sender, EventArgs e)
        {
            if (chk_enableLineMSG.Checked == true)
            {
                lineNotify(txt_linetest.Text.ToString());
            }
        }

        private void dtg_lineGroup_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ID_LineGroup = Convert.ToInt16(dtg_lineGroup.Rows[e.RowIndex].Cells[0].Value.ToString());
                txt_lineNamegroup.Text = dtg_lineGroup.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                txt_tokenLine.Text = dtg_lineGroup.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();

                if (dtg_lineGroup.Rows[e.RowIndex].Cells[3].Value.ToString() == "True")
                {
                    chk_enableLineMSG.Checked = true;
                }
                else { chk_enableLineMSG.Checked = false; }

                if (dtg_lineGroup.Rows[e.RowIndex].Cells[4].Value.ToString() == "True")
                {
                    chk_enableLineIMG.Checked = true;
                }
                else { chk_enableLineIMG.Checked = false; }

                if (dtg_lineGroup.Rows[e.RowIndex].Cells[5].Value.ToString() == "True")
                {
                    chk_shoLineDetail.Checked = true;
                }
                else { chk_shoLineDetail.Checked = false; }

                if (dtg_lineGroup.Rows[e.RowIndex].Cells[6].Value.ToString() == "True")
                {
                    chk_enableLineservice.Checked = true;
                }
                else { chk_enableLineservice.Checked = false; }

                chk_newlineGroup.Checked = false;
            }
        }

        private void lineNotify(string msg)
        {
            string token = txt_tokenLine.Text.Trim();
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
                Console.WriteLine(ex.ToString());
            }
        }

        private void chk_fillterAlert_CheckedChanged(object sender, EventArgs e)
        {

            if (chk_fillterAlert.Checked == true)
            {
                id_filterAlert = 1; Load_DTGUser_Report();
            }

            if (chk_fillterAlert.Checked == false)
            {
                id_filterAlert = 0; Load_DTGUser_Report();

            }

            Checl_Alert_Report();
            ID_TypeLoad = 1;  // Load all
            Load_AlertResualt();


        }

        private void Load_DTGUser_Report()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                dtg_alert_User.Columns.Clear();
                dtg_alert_User.DataSource = null;

                string sql1 = "";

                if (id_filterAlert == 0)

                {
                    sql1 = "SELECT [UserID] AS 'ลำดับ' ,[FullUserName] AS 'ชื่อผู้อนุมัติ' ,[Name_Dept] AS 'ฝ่าย/แผนก'  FROM [dbo].[V_User]";
                }

                if (id_filterAlert == 1)

                {
                    sql1 = "SELECT [ID_User] AS 'ลำดับ' ,[FullUserName] AS 'ชื่อผู้อนุมัติ' ,[Name_Dept] AS 'ฝ่าย/แผนก'   FROM [dbo].[V_MailAlert] Where [ID_AL] = " + ID_AL + " AND [ProductID] = '" + cb_product_Alert.SelectedValue.ToString() + "'  AND [Status_RP]=1 ";
                }

                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "report");
                dtg_alert_User.DataSource = ds1.Tables["report"];
                con.Close();
                
                DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
                dgvCmb.ValueType = typeof(bool);
                dgvCmb.Name = "Chk";
                dgvCmb.HeaderText = "เปิดใช้งาน";
                dtg_alert_User.Columns.Add(dgvCmb);
                               
                DataGridViewTextBoxColumn Col_TxTalert = new DataGridViewTextBoxColumn();
                dtg_alert_User.Columns.Add(Col_TxTalert);
                Col_TxTalert.HeaderText = "";
                Col_TxTalert.Name = "Alert";
                dtg_alert_User.Columns["Alert"].HeaderText = "ค่าที่แจ้งเตือน";
                
                DataGridViewCheckBoxColumn Col_CheckAlert = new DataGridViewCheckBoxColumn();
                Col_CheckAlert.ValueType = typeof(bool);
                Col_CheckAlert.Name = "Chk1";
                Col_CheckAlert.HeaderText = "เปิดเตือน";
                dtg_alert_User.Columns.Add(Col_CheckAlert);

                DataGridViewTextBoxColumn Col_TxTapp = new DataGridViewTextBoxColumn();
                dtg_alert_User.Columns.Add(Col_TxTapp);
                Col_TxTapp.HeaderText = "";
                Col_TxTapp.Name = "App";
                dtg_alert_User.Columns["App"].HeaderText = "ค่าที่อนุมัติ";

                DataGridViewTextBoxColumn Col_TxTLevel = new DataGridViewTextBoxColumn();
                dtg_alert_User.Columns.Add(Col_TxTLevel);
                Col_TxTLevel.HeaderText = "";
                Col_TxTLevel.Name = "Lev";
                dtg_alert_User.Columns["Lev"].HeaderText = "ลำดับอนุมัติ";

                DataGridViewCheckBoxColumn Col_CheckMail = new DataGridViewCheckBoxColumn();
                Col_CheckMail.ValueType = typeof(bool);
                Col_CheckMail.Name = "Chk2";
                Col_CheckMail.HeaderText = "เปิดอนุมัติ";
                dtg_alert_User.Columns.Add(Col_CheckMail);

                DataGridViewButtonColumn Col_BtnEdit = new DataGridViewButtonColumn();
                dtg_alert_User.Columns.Add(Col_BtnEdit);
                Col_BtnEdit.HeaderText = "แก้ไขข้อมูล";
                Col_BtnEdit.Text = "แก้ไข";
                Col_BtnEdit.Name = "Btn";
                Col_BtnEdit.UseColumnTextForButtonValue = true;
                               
                dtg_alert_User.Columns[0].Width = 60;
                dtg_alert_User.Columns[1].Width = 140;
                dtg_alert_User.Columns[2].Width = 180;
                dtg_alert_User.Columns[3].Width = 60;
                dtg_alert_User.Columns[5].Width = 60;
                dtg_alert_User.Columns[7].Width = 60;
                dtg_alert_User.Columns[8].Width = 60;
                dtg_alert_User.Columns[9].Width = 80;


                dtg_alert_User.Columns[0].ReadOnly = true;
                dtg_alert_User.Columns[1].ReadOnly = true;


                dtg_alert_User.Columns[0].DefaultCellStyle.BackColor = Color.SkyBlue;
                dtg_alert_User.Columns[1].DefaultCellStyle.BackColor = Color.SkyBlue;

                dtg_alert_User.Columns[2].DefaultCellStyle.BackColor = Color.SkyBlue;
                dtg_alert_User.Columns[3].DefaultCellStyle.BackColor = Color.LightGreen;
                dtg_alert_User.Columns[4].DefaultCellStyle.BackColor = Color.LightYellow;
                dtg_alert_User.Columns[5].DefaultCellStyle.BackColor = Color.LightYellow;
                dtg_alert_User.Columns[6].DefaultCellStyle.BackColor = Color.LightSalmon;
                dtg_alert_User.Columns[7].DefaultCellStyle.BackColor = Color.LightSalmon;
                dtg_alert_User.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtg_alert_User.Columns[8].DefaultCellStyle.BackColor = Color.LightSalmon;
            }
            catch { }


        }


        private void Load_AlertResualt()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
            con1.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter1 = new SqlDataAdapter();

            SqlConnection con2 = new SqlConnection(Program.pathdb_Weight);
            con2.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter2 = new SqlDataAdapter();

            SqlConnection con3 = new SqlConnection(Program.pathdb_Weight);
            con3.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter3 = new SqlDataAdapter();

            con.Open();

            try
            {
                dtg_alert_User.Rows[e_RowIndex].Cells[4].Value = "";
                dtg_alert_User.Rows[e_RowIndex].Cells[6].Value = "";
                dtg_alert_User.Rows[e_RowIndex].Cells[5].Value = "False";
                dtg_alert_User.Rows[e_RowIndex].Cells[8].Value = "False";
            }
            catch { }

            if (ID_TypeLoad == 1)

            {
                for (int i = 0; i < dtg_alert_User.RowCount; i++)
                {
                    try
                    {
                        con3.Open();
                        string sql3 = "SELECT [ID_ALRP] FROM [dbo].[TB_Alertreport] WHERE [ID_AL] = " + ID_AL + " AND [ID_User]=" + dtg_alert_User.Rows[i].Cells[0].Value.ToString() + "";
                        SqlCommand CM3 = new SqlCommand(sql3, con3);
                        SqlDataReader DR3 = CM3.ExecuteReader();
                        DR3.Read();
                        {
                            ID_ALRP = Convert.ToInt16(DR3["ID_ALRP"].ToString());
                        }
                        DR3.Close();
                        con3.Close();
                    }


                    catch { ID_ALRP = 0; con3.Close(); }

                    if (ID_ALRP != 0)
                    {

                        string sql4 = "SELECT [ID_Value],[Alert_Sts],[App_Sts],[ID_Frm_TypeLab] FROM [dbo].[V_Alert] WHERE [ID_ALRP] = " + ID_ALRP + " ";
                        SqlCommand CM4 = new SqlCommand(sql4, con);
                        SqlDataReader DR4 = CM4.ExecuteReader();

                        while (DR4.Read())
                        {
                            if (DR4["Alert_Sts"].ToString() == "True")
                            {
                                if (DR4["ID_Frm_TypeLab"].ToString() == "1")  //มาจาก การวิเคราะห์แบบเครื่องมือ
                                {
                                    con1.Open();
                                    string sql1 = "SELECT [Min],[Max],[Rate] FROM [dbo].[TB_ValueLab] WHERE [LOGID] = " + DR4["ID_Value"].ToString().Trim() + " ";
                                    SqlCommand CM1 = new SqlCommand(sql1, con1);
                                    SqlDataReader DR1 = CM1.ExecuteReader();

                                    DR1.Read();
                                    {
                                        dtg_alert_User.Rows[i].Cells[4].Value += "(" + DR1["Min"].ToString().Trim() + "-" + DR1["Max"].ToString().Trim() + "=" + DR1["Rate"].ToString().Trim() + "),";
                                    }
                                    DR1.Close();
                                    con1.Close();


                                }

                                if (DR4["ID_Frm_TypeLab"].ToString() == "2")  //มาจาก การวิเคราะห์แบบเครื่องมือ
                                {
                                    con2.Open();
                                    string sql2 = "SELECT [ValueName],[Value1] FROM [dbo].[TB_Valuevisual] WHERE [ValueVisualNo] = " + DR4["ID_Value"].ToString().Trim() + " ";
                                    SqlCommand CM2 = new SqlCommand(sql2, con2);
                                    SqlDataReader DR2 = CM2.ExecuteReader();

                                    DR2.Read();
                                    {
                                        dtg_alert_User.Rows[i].Cells[4].Value += "(" + DR2["ValueName"].ToString().Trim() + "-" + DR2["Value1"].ToString().Trim() + "),";
                                    }
                                    DR2.Close();
                                    con2.Close();
                                }

                                dtg_alert_User.Rows[i].Cells[5].Value = "True";
                            }

                            if (DR4["App_Sts"].ToString() == "True")
                            {
                                if (DR4["ID_Frm_TypeLab"].ToString() == "1")  //มาจาก การวิเคราะห์แบบเครื่องมือ
                                {
                                    con1.Open();
                                    string sql1 = "SELECT [Min],[Max],[Rate] FROM [dbo].[TB_ValueLab] WHERE [LOGID] = " + DR4["ID_Value"].ToString().Trim() + " ";
                                    SqlCommand CM1 = new SqlCommand(sql1, con1);
                                    SqlDataReader DR1 = CM1.ExecuteReader();

                                    DR1.Read();
                                    {
                                        dtg_alert_User.Rows[i].Cells[6].Value += "(" + DR1["Min"].ToString().Trim() + "-" + DR1["Max"].ToString().Trim() + "=" + DR1["Rate"].ToString().Trim() + "),";
                                    }
                                    DR1.Close();
                                    con1.Close();
                                }

                                if (DR4["ID_Frm_TypeLab"].ToString() == "2")  //มาจาก การวิเคราะห์แบบเครื่องมือ
                                {
                                    con2.Open();
                                    string sql2 = "SELECT [Value1] FROM [dbo].[TB_Valuevisual] WHERE [ValueVisualNo] = " + DR4["ID_Value"].ToString().Trim() + " ";
                                    SqlCommand CM2 = new SqlCommand(sql2, con2);
                                    SqlDataReader DR2 = CM2.ExecuteReader();

                                    DR2.Read();
                                    {
                                        dtg_alert_User.Rows[i].Cells[6].Value += DR2["Value1"].ToString().Trim();
                                    }
                                    DR2.Close();
                                    con2.Close();
                                }

                                dtg_alert_User.Rows[i].Cells[8].Value = "True";
                            }
                        }
                        DR4.Close();
                    }


                }
            }


            if (ID_TypeLoad == 2)
            {
                string sql4 = "SELECT [ID_Value],[Alert_Sts],[App_Sts],[ID_Frm_TypeLab] FROM [dbo].[V_Alert] WHERE [ID_ALRP] = " + ID_ALRP + " ";
                SqlCommand CM4 = new SqlCommand(sql4, con);
                SqlDataReader DR4 = CM4.ExecuteReader();

                while (DR4.Read())
                {
                    if (DR4["Alert_Sts"].ToString() == "True")
                    {
                        if (DR4["ID_Frm_TypeLab"].ToString() == "1")  //มาจาก การวิเคราะห์แบบเครื่องมือ
                        {
                            con1.Open();
                            string sql1 = "SELECT [Min],[Max],[Rate] FROM [dbo].[TB_ValueLab] WHERE [LOGID] = " + DR4["ID_Value"].ToString().Trim() + " ";
                            SqlCommand CM1 = new SqlCommand(sql1, con1);
                            SqlDataReader DR1 = CM1.ExecuteReader();

                            DR1.Read();
                            {
                                dtg_alert_User.Rows[e_RowIndex].Cells[4].Value += "(" + DR1["Min"].ToString().Trim() + "-" + DR1["Max"].ToString().Trim() + "=" + DR1["Rate"].ToString().Trim() + "),";
                            }
                            DR1.Close();
                            con1.Close();


                        }

                        if (DR4["ID_Frm_TypeLab"].ToString() == "2")  //มาจาก การวิเคราะห์แบบกายภาพ
                        {
                            con2.Open();
                            string sql2 = "SELECT [ValueName],[Value1] FROM [dbo].[TB_Valuevisual] WHERE [ValueVisualNo] = " + DR4["ID_Value"].ToString().Trim() + " ";
                            SqlCommand CM2 = new SqlCommand(sql2, con2);
                            SqlDataReader DR2 = CM2.ExecuteReader();

                            DR2.Read();
                            {
                                dtg_alert_User.Rows[e_RowIndex].Cells[4].Value += "(" + DR2["ValueName"].ToString().Trim() + "-" + DR2["Value1"].ToString().Trim() + "),";
                            }
                            DR2.Close();
                            con2.Close();
                        }

                        dtg_alert_User.Rows[e_RowIndex].Cells[5].Value = "True";
                    }

                    if (DR4["App_Sts"].ToString() == "True")
                    {
                        if (DR4["ID_Frm_TypeLab"].ToString() == "1")  //มาจาก การวิเคราะห์แบบเครื่องมือ
                        {
                            con1.Open();
                            string sql1 = "SELECT [Min],[Max],[Rate] FROM [dbo].[TB_ValueLab] WHERE [LOGID] = " + DR4["ID_Value"].ToString().Trim() + " ";
                            SqlCommand CM1 = new SqlCommand(sql1, con1);
                            SqlDataReader DR1 = CM1.ExecuteReader();

                            DR1.Read();
                            {
                                dtg_alert_User.Rows[e_RowIndex].Cells[6].Value += "(" + DR1["Min"].ToString().Trim() + "-" + DR1["Max"].ToString().Trim() + "=" + DR1["Rate"].ToString().Trim() + "),";
                            }
                            DR1.Close();
                            con1.Close();
                        }

                        if (DR4["ID_Frm_TypeLab"].ToString() == "2")  //มาจาก การวิเคราะห์แบบกายภาพ
                        {
                            con2.Open();
                            string sql2 = "SELECT [ValueName],[Value1] FROM [dbo].[TB_Valuevisual] WHERE [ValueVisualNo] = " + DR4["ID_Value"].ToString().Trim() + " ";
                            SqlCommand CM2 = new SqlCommand(sql2, con2);
                            SqlDataReader DR2 = CM2.ExecuteReader();

                            DR2.Read();
                            {
                                dtg_alert_User.Rows[e_RowIndex].Cells[6].Value += "(" + DR2["ValueName"].ToString().Trim() + "-" + DR2["Value1"].ToString().Trim() + "),";
                            }
                            DR2.Close();
                            con2.Close();
                        }

                        dtg_alert_User.Rows[e_RowIndex].Cells[8].Value = "True";
                    }
                }
                DR4.Close();

            }

        }


        private void Checl_Alert_Report()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();


                //Check Config User config
                for (int i = 0; i < dtg_alert_User.RowCount; i++)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    else { con.Open(); }

                    dtg_alert_User.Rows[i].Cells[3].Value = false;
                    con.Open();
                    string sql4 = "SELECT [Status_RP],[Level_App],[Level_App] FROM [dbo].[TB_Alertreport] WHERE [ID_AL] = " + ID_AL + " AND [ID_User]=" + dtg_alert_User.Rows[i].Cells[0].Value.ToString() + "";
                    SqlCommand CM4 = new SqlCommand(sql4, con);
                    SqlDataReader DR4 = CM4.ExecuteReader();

                    DR4.Read();
                    {
                        try
                        {

                            if (DR4["Status_RP"].ToString() == "True")
                            {
                                dtg_alert_User.Rows[i].Cells[7].Value = DR4["Level_App"].ToString();
                                dtg_alert_User.Rows[i].Cells[3].Value = true;
                                dtg_alert_User.Rows[i].Cells[5].ReadOnly = false;
                                dtg_alert_User.Rows[i].Cells[8].ReadOnly = false;
                                dtg_alert_User.Rows[i].Cells[9].ReadOnly = false;
                            }

                            else
                            {
                                dtg_alert_User.Rows[i].Cells[5].ReadOnly = true;
                                dtg_alert_User.Rows[i].Cells[8].ReadOnly = true;
                                dtg_alert_User.Rows[i].Cells[9].ReadOnly = true;
                            }
                        }
                        catch
                        {
                            dtg_alert_User.Rows[i].Cells[3].Value = false;
                            dtg_alert_User.Rows[i].Cells[5].ReadOnly = true;
                            dtg_alert_User.Rows[i].Cells[8].ReadOnly = true;
                            dtg_alert_User.Rows[i].Cells[9].ReadOnly = true;
                        }
                    }
                    DR4.Close();
                    //con.Close();
                }

                dtg_alert_User.Enabled = true;

                con.Close();

            }
            catch
            {

            }

        }

        private void tbc_mailAlert_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tbc_mailAlert.SelectedIndex == 0)
            {

            }

            if (tbc_mailAlert.SelectedIndex == 1)
            {
                Load_emailGroup();
                Load_UserMail();
            }

            if (tbc_mailAlert.SelectedIndex == 2)
            {
                Load_lineGroup();
            }

            if (tbc_mailAlert.SelectedIndex == 3)
            {
                Load_DTGUser_Report();
                Checl_Alert_Report();
                ID_TypeLoad = 1;  // Load all
                Load_AlertResualt();
            }
        }

        private void Load_UserMail()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql = "SELECT [UserID] AS 'รหัส',[FullUserName] AS 'ชื่อ-นามสกุล',[Email] AS 'อีเมล์',[Name_Dept] AS 'แผนก/ฝ่าย'  FROM [dbo].[V_User]";

            SqlDataAdapter da1 = new SqlDataAdapter(sql, con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "v_process");
            dtg_maiList.DataSource = ds1.Tables["v_process"];
            con.Close();


            dtg_maiList.Columns[0].Width = 60;
            dtg_maiList.Columns[1].Width = 150;
            dtg_maiList.Columns[2].Width = 180;
            dtg_maiList.Columns[3].Width = 200;


            lbl_rowcountLstEmail.Text = "จำนวน: " + dtg_maiList.RowCount.ToString() + "ข้อมูล";


        }


    }
}
