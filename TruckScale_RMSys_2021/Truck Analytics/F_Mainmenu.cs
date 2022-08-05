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
using System.Data.SqlClient;
using System.Net;

namespace Truck_Analytics
{
    public partial class F_Mainmenu : Form
    {

        string Msg = "";
        string Log_NewValue = "";
        string Log_OldValue = "";


        public F_Mainmenu()
        {
            InitializeComponent();
        }

        private void btn_lab_Click(object sender, EventArgs e)
        {
            F_Lab fl = new F_Lab();
            fl.ShowDialog();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            F_ConfirmLab fcl = new F_ConfirmLab();
            fcl.ShowDialog();

        }

        private void btn_payment_Click(object sender, EventArgs e)
        {
            F_Payment fpm = new F_Payment();
            fpm.ShowDialog();
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            //F_Password fps = new F_Password();
            //fps.id_request = 2;
            //fps.ShowDialog();

            //if (fps.sts_pwd == 1)
            //{
            //    F_LabSetting fls = new F_LabSetting();
            //    fls.ShowDialog();
            //}

            F_Setting fs = new F_Setting();
            fs.ShowDialog();
            //F_LabSetting fls = new F_LabSetting();
            //fls.ShowDialog();

        }

        private void F_Mainmenu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            Connect_UserAccess();

            F_Login flg = new F_Login();
            flg.ShowDialog();

            if (Program.user_login != "" && Program.uid_verifiled==1)
            {
                //check permission     
                //this.WindowState = FormWindowState.Normal;               
                //Connect_Database();
                Load_CNDBTruck14();
                Load_CNDBNAV();                
                Load_PermissionMenu();
                //MessageBox.Show(Program.MachineName);

                if (Program.DB_Name != "SapthipNewDB")
                {
                    panel1.BackColor = Color.Crimson;
                }
            }

            else { Application.Exit(); 
            }
        }

        private void Load_CNDBNAV()
        {

            StreamReader sw = new StreamReader(Application.StartupPath + "\\cn14_Nav.dll");
            string connecpovider = sw.ReadToEnd();


            try
            {
                Program.CN = new SqlConnection();
                Program.CN.ConnectionString = connecpovider;
                Program.pathdb14_NAV = connecpovider;
                sw.Close();
            }
            catch
            {
                //MessageBox.Show("Is Not Connection to Database..", "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();

                DialogResult answer;
                answer = MessageBox.Show("Database Navision Is't Connect!! Pls. check CN1.dll in Debug Folder!! ", "Connection to Databas Failed", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (answer == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }
               
        //private void Connect_Database()
        //{

        //    StreamReader sw = new StreamReader(Application.StartupPath + "\\uAccess.dll");
        //    string connecpovider = sw.ReadToEnd();      

        //    try
        //    {
        //        Program.CN = new SqlConnection();
        //        Program.CN.ConnectionString = connecpovider;
        //        Program.pathdb_Weight = connecpovider;
        //        sw.Close();
        //    }
        //    catch
        //    {
        //        //MessageBox.Show("Is Not Connection to Database..", "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        sw.Close();
        //        DialogResult answer;
        //        answer = MessageBox.Show("Database Navision Is't Connect!! Pls. check CN1.dll in Debug Folder!! ", "Connection to Databas Failed", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        //        if (answer == DialogResult.OK)
        //        {
        //            Application.Exit();
        //        }
        //    }
        //}

        private void Connect_UserAccess()
        {

            StreamReader sw = new StreamReader(Application.StartupPath + "\\cndb.dll");
            string connecpovider = sw.ReadToEnd();

            try
            {
                Program.CN = new SqlConnection();
                Program.CN.ConnectionString = connecpovider;
                Program.pathdb_Weight = connecpovider;            

                Program.MachineName = Environment.MachineName.ToString();
                Program.LocalIpAddress = GetIPAddress();
                sw.Close();
            }
            catch
            {
                //MessageBox.Show("Is Not Connection to Database..", "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();

                DialogResult answer;
                answer = MessageBox.Show("Path User_Access is Not Extting! OR Database Navision Is't Connect!! Pls. check uAccess.dll in Debug Folder!! ", "Read file User Access Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (answer == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }


        private void Load_CNDBTruck14()
        {

            StreamReader sw = new StreamReader(Application.StartupPath + "\\cn14_Truck.dll");
            string connecpovider = sw.ReadToEnd();

            try
            {
                Program.CN = new SqlConnection();
                Program.CN.ConnectionString = connecpovider;
                Program.pathdb14_TruckScale = connecpovider;
                sw.Close();

            }
            catch
            {
                //MessageBox.Show("Is Not Connection to Database..", "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();

                DialogResult answer;
                answer = MessageBox.Show("Database Navision Is't Connect!! Pls. check CN1.dll in Debug Folder!! ", "Connection to Databas Failed", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (answer == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private void Load_PermissionMenu()  // check การเปิดใช้งานของแต่ละ เมนูหลักการทำงาน
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql6 = "SELECT [ID_Menu],[Status_Use],[UserID],[FullUserName] FROM [dbo].[V_Permission] WHERE [User_AD] = '" + Program.user_login + "' AND [ID_Menutype]= 1 ";
                SqlCommand CM6 = new SqlCommand(sql6, con);
                SqlDataReader DR6 = CM6.ExecuteReader();

                //Idmenu
                //เมนูลงทะเบียน     1
                //เมนูงานชั่งสินค้า     2
                //เมนูบันทึกผลวิเคราะห์    3
                //เมนูยืนยันผลวิเคราะห์   4
                //เมนูบันทึกจ่าย    5
                //เมนูตั้งค่าโปรแกรม   6
                int MenuID = 0;  // check menuname
                int Count_menu = 0;   //check unit no menu open
                int M_1 = 0;
                int M_2 = 0;
                int M_3 = 0;
                int M_4 = 0;
                int M_5 = 0;
                int M_6 = 0;
                int M_7 = 0;

                //[UserID]
                while (DR6.Read())
                {
                    MenuID = Convert.ToInt16(DR6["ID_Menu"].ToString().Trim());
                    Program.user_name = DR6["FullUserName"].ToString().Trim();
                    if (MenuID == 1) { if (DR6["Status_Use"].ToString().Trim() == "True") { M_1 = 1; Count_menu += 1; Program.user_id = Convert.ToInt16(DR6["UserID"].ToString().Trim()); } }
                    if (MenuID == 2) { if (DR6["Status_Use"].ToString().Trim() == "True") { M_2 = 1; Count_menu += 1; Program.user_id = Convert.ToInt16(DR6["UserID"].ToString().Trim()); } }
                    if (MenuID == 3) { if (DR6["Status_Use"].ToString().Trim() == "True") { M_3 = 1; Count_menu += 1; Program.user_id = Convert.ToInt16(DR6["UserID"].ToString().Trim()); } }
                    if (MenuID == 4) { if (DR6["Status_Use"].ToString().Trim() == "True") { M_4 = 1; Count_menu += 1; Program.user_id = Convert.ToInt16(DR6["UserID"].ToString().Trim()); } }
                    if (MenuID == 5) { if (DR6["Status_Use"].ToString().Trim() == "True") { M_5 = 1; Count_menu += 1; Program.user_id = Convert.ToInt16(DR6["UserID"].ToString().Trim()); } }
                    if (MenuID == 6) { if (DR6["Status_Use"].ToString().Trim() == "True") { M_6 = 1; Count_menu += 1; Program.user_id = Convert.ToInt16(DR6["UserID"].ToString().Trim()); } }
                    if (MenuID == 50) { if (DR6["Status_Use"].ToString().Trim() == "True") { M_7 = 1; Count_menu += 1; Program.user_id = Convert.ToInt16(DR6["UserID"].ToString().Trim()); } }
                }
                DR6.Close();
                con.Close();


                if (M_1 == 1)
                {
                    if (Count_menu == 1)
                    {
                        F_Register FRT = new F_Register();
                        FRT.ShowDialog();
                        Application.Exit();
                    }

                    btn_register.Enabled = true;
                    lbl_register.ForeColor = Color.Black;
                }


                if (M_2 == 1)
                {
                    if (Count_menu == 1)
                    {
                        F_Weight FRT = new F_Weight();
                        FRT.ShowDialog();
                        Application.Exit();
                    }

                    btn_truck.Enabled = true;
                    lbl_truck.ForeColor = Color.Black;
                }


                if (M_3 == 1)
                {
                    if (Count_menu == 1)
                    {
                        F_Lab FML = new F_Lab();
                        FML.ShowDialog();
                        Application.Exit();
                    }

                    btn_lab.Enabled = true;
                    lbl_lab.ForeColor = Color.Black;
                }


                if (M_4 == 1)
                {
                    if (Count_menu == 1)
                    {
                        F_ConfirmLab FMC = new F_ConfirmLab();
                        FMC.ShowDialog();

                        Application.Exit();
                    }

                    btn_confirmlab.Enabled = true;
                    lbl_confirmlab.ForeColor = Color.Black;
                }


                if (M_5 == 1)
                {
                    if (Count_menu == 1)
                    {
                        F_Payment FPM = new F_Payment();
                        FPM.ShowDialog();
                        Application.Exit();
                    }

                    btn_payment.Enabled = true;
                    lbl_payment.ForeColor = Color.Black;
                }


                if (M_6 == 1)
                {
                    if (Count_menu == 1)
                    {
                        F_Setting FMS = new F_Setting();
                        FMS.ShowDialog();
                        Application.Exit();
                    }

                    btn_setting.Enabled = true;                 
                }

                if (M_7 == 1)
                {
                    if (Count_menu == 1)
                    {
                        F_Approval FAA = new F_Approval();
                        FAA.ShowDialog();
                        Application.Exit();
                    }

                    btn_approved.Enabled = true;
                    lbl_approved.ForeColor = Color.Black;
                }


                if (Count_menu > 1)
                {
                    this.WindowState = FormWindowState.Normal;
                }

                
            }

            catch { }
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


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            F_Register frs = new F_Register();
            frs.Show();
        }

        private void btn_truck_Click(object sender, EventArgs e)
        {           
                F_Weight fw = new F_Weight();
                fw.ShowDialog();           
        }

        private void btn_approved_Click(object sender, EventArgs e)
        {
            F_Approval fapp = new F_Approval();
            fapp.ShowDialog();
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            F_MainReport FMR = new F_MainReport();
            FMR.ShowDialog();
        }

        private void bnt_recheck_Click(object sender, EventArgs e)
        {
            F_RecheckData frdt = new F_RecheckData();
            frdt.ID_Recheck = 1;
            frdt.ShowDialog();
        }

        private void btn_setting_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("งานตั้งค่าโปรแกรม", btn_setting);
        }

        private void btn_report_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("งานออกรายงาน", btn_report);
        }

        private void bnt_recheck_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("งานตรวจสอบขั้นตอนการทำงาน", bnt_recheck);
        }

        private void F_Mainmenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.DB_Name != null)
            {
                LogOut();
            }
        }

        private void btn_swUser_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("เปลี่ยนชื่อผู้เข้าใช้งาน", btn_swUser);
        }

        private void btn_swUser_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("คุณต้องการเปลี่ยนผู้เข้าใช้งานโปรแกรมใช่หรือไม่", "ยืนยันการเปลี่ยนผู้เข้าระบบ", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information);

            if (dr == DialogResult.OK)
            {
                LogOut();
                Application.Restart();
            }
        }

        private void LogOut()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string date = Program.Date_Now + " " + Program.Time_Now;
            string sql1 = "UPDATE [dbo].[TB_Users] SET [Status_logon] = 0 WHERE [User_AD] ='" + Program.user_login + "'";

            SqlCommand CM2 = new SqlCommand(sql1, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();

            Msg = "Applicatiion to exti!";
            Log_NewValue = "Main Menu Form!";
            Log_OldValue = "-";

            Class_Log CL = new Class_Log();
            CL.tbname = Msg;
            CL.oldvalue = Log_OldValue;
            CL.newvalue = Log_NewValue;
            CL.Save_log();


        }
    }
}
