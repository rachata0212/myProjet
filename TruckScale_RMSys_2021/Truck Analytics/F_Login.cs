using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using System.Data.SqlClient;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

namespace Truck_Analytics
{
    public partial class F_Login : Form
    {
        public F_Login()
        {
            InitializeComponent();
        }

        //public string Username;

        string Msg = "";
        string Log_NewValue = "";
        string Log_OldValue = "";
        string DB_Name = "SapthipNewDB";

        private void Form2_Load(object sender, EventArgs e)
        {
            //DB_Name = "SapthipNewDB";
        }

        private void Login()
        {
            //Save log
            Program.pathdb_Weight += " initial catalog=" + DB_Name + ";";

            if (tbxUserName.Text != "")
            {
                if (tbxPassword.Text != "")
                {
                    string nameLogin = tbxUserName.Text.Trim();
                    string pwdLogin = tbxPassword.Text.Trim();

                    string initLDAPPath = "dc=sapthip,dc=com";   //ถ้าจะให้ดีทำเป็นไฟล์ setup ด้านนอกสามารถเปลี่ยนภายหลังได้
                    string initLDAPServer = "192.168.111.13";  //ถ้าจะให้ดีทำเป็นไฟล์ setup ด้านนอกสามารถเปลี่ยนภายหลังได้
                    string initShortDomainName = "sapthip.com";   //ถ้าจะให้ดีทำเป็นไฟล์ setup ด้านนอกสามารถเปลี่ยนภายหลังได้
                    string strErrMsg;

                    string DomainAndUsername = "";
                    string strCommu;
                    bool flgLogin = false;
                    strCommu = ("LDAP://"

                    + (initLDAPServer + ("/" + initLDAPPath)));
                    DomainAndUsername = (initShortDomainName + ("\\" + nameLogin));
                    DirectoryEntry entry = new DirectoryEntry(strCommu, DomainAndUsername, pwdLogin);

                    object obj;

                    try
                    {
                        obj = entry.NativeObject;
                        DirectorySearcher search = new DirectorySearcher(entry);
                        SearchResult result;
                        search.Filter = ("(SAMAccountName="
                        + (nameLogin + ")"));
                        search.PropertiesToLoad.Add("cn");
                        result = search.FindOne();

                        if ((result == null))
                        {
                            flgLogin = false;
                            strErrMsg = "Please check user/password";
                        }

                        else
                        {
                            flgLogin = true;
                        }
                    }

                    catch (Exception ex)
                    {

                        flgLogin = false;
                        strErrMsg = "Please check User/password";


                        Msg = "User Login to failed!";
                        Log_NewValue = tbxUserName.Text.Trim();
                        Log_OldValue = "-";

                        Class_Log CL = new Class_Log();
                        CL.tbname = Msg;
                        CL.oldvalue = Log_OldValue;
                        CL.newvalue = Log_NewValue;                     

                    }

                    if ((flgLogin == true))
                    {
                        //test
                        // MessageBox.Show("Login OK");

                        if (DB_Name != "")
                        {                          
                            int Status_User = 9;

                            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                            con.ConnectionString = Program.pathdb_Weight;
                            SqlDataAdapter dtAdapter = new SqlDataAdapter();
                            con.Open();

                            string sql = "SELECT [Status_logon]  FROM [TB_Users] Where [User_AD] = '" + tbxUserName.Text.Trim() + "' AND [Status_Active]=1";

                            SqlCommand CM1 = new SqlCommand(sql, con);
                            SqlDataReader DR1 = CM1.ExecuteReader();

                            DR1.Read();
                            {                             
                                if (DR1["Status_logon"].ToString() =="True")
                                {
                                    Status_User = 1;
                                }

                                else { Status_User = 0; }
                            }
                            DR1.Close();
                            con.Close();


                            if (Status_User == 0)
                            {
                                string date = Program.Date_Now + " " + Program.Time_Now;

                                con.Open();
                                string sql1 = "UPDATE [dbo].[TB_Users] SET [Status_logon] = 1 ,[Devicelast_logon] ='" + Program.MachineName + "' ,[DTlast_logon] ='" + date + "',[IPlast_logon] = '" + Program.LocalIpAddress.Trim() + "' WHERE [User_AD] ='" + tbxUserName.Text.Trim() + "' AND [Status_Active] = 1";
                                SqlCommand CM2 = new SqlCommand(sql1, con);
                                SqlDataReader DR2 = CM2.ExecuteReader();
                                con.Close();

                                Program.user_login = tbxUserName.Text.Trim();
                                Program.uid_verifiled = 1;
                                string path_user = Program.pathdb_Weight;  // path user Access
                                Program.pathdb_Weight = path_user;
                                Program.DB_Name = DB_Name;  // check color status line
                                                               
                                Msg = "User Login to Completed!";
                                Log_NewValue = tbxUserName.Text.Trim();
                                Log_OldValue = "-";
                                Class_Log CL = new Class_Log();
                                CL.tbname = Msg;
                                CL.oldvalue = Log_OldValue;
                                CL.newvalue = Log_NewValue;
                                CL.Save_log();

                                this.Close();
                            }
                            else
                            {

                                Msg = "Connect Database With User is Duplicate!";
                                Log_NewValue = Program.user_login;
                                Log_OldValue = "-";

                                Class_Log CL = new Class_Log();
                                CL.tbname = Msg;
                                CL.oldvalue = Log_OldValue;
                                CL.newvalue = Log_NewValue;
                                CL.Save_log();

                                DialogResult answer;
                                answer = MessageBox.Show("ชื่อผู้ใช้งานนี้ได้ เข้าใช้งานในระบบแล้ว ไม่สามารถเข้าใช้งานซ้ำได้! หากต้องการเข้าใหม่กรุณายืนยันรหัสผ่านอีกครั้ง", "การเข้าใช้งานผิดพลาด!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                                if (answer == DialogResult.Yes)
                                {
                                    Program.user_login = tbxUserName.Text.Trim();

                                    F_Password Fwd = new F_Password();
                                    Fwd.id_request = 5;
                                    Fwd.ShowDialog();

                                    if (Fwd.sts_pwd == 1)
                                    {
                                        this.Close();

                                        Program.uid_verifiled = 1;
                                        string path_user = Program.pathdb_Weight;  // path user Access
                                        Program.pathdb_Weight = path_user;
                                        Program.DB_Name = DB_Name;  // check color status line
                                    }        
                                }

                            }

                        }

                        else
                        {
                            MessageBox.Show("คุณไม่ได้เลือกฐานข้อมูลในการเข้าใช้งาน.!", "ตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Error);


                            Msg = "Connect Database Failed!!";
                            Log_NewValue = "Connect Database";
                            Log_OldValue = "-";

                            Class_Log CL = new Class_Log();
                            CL.tbname = Msg;
                            CL.oldvalue = Log_OldValue;
                            CL.newvalue = Log_NewValue;
                            CL.Save_log();

                        }

                    }

                    else
                    {
                        MessageBox.Show("ไม่พบข้อมูลผู้ใช้งาน...!", "ตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("กรุณาระบุรหัสผ่าน...!", "ตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    Msg = "Password Login to Emtry!";
                    Log_NewValue = "-";
                    Log_OldValue = "-";
                    Class_Log CL = new Class_Log();
                    CL.tbname = Msg;
                    CL.oldvalue = Log_OldValue;
                    CL.newvalue = Log_NewValue;
                    CL.Save_log();


                    tbxPassword.Focus();
                }
            }
            else
            {
                MessageBox.Show("กรุณาระบุข้อมูลชื่อผู้ใช้งาน...!", "ตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Msg = "User Login Name to Emtry!";
                Log_NewValue = "-";
                Log_OldValue = "-";
                Class_Log CL = new Class_Log();
                CL.tbname = Msg;
                CL.oldvalue = Log_OldValue;
                CL.newvalue = Log_NewValue;
                CL.Save_log();

                tbxUserName.Select();
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("คุณต้องการยกเลิกใช้โปรแกรมใช่หรือไม่", "ยืนยันการยกเลิกใช้งานโปรแกรม!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult answer;
            answer = MessageBox.Show("คุณต้องการยกเลิกใช้โปรแกรมใช่หรือไม่", "ยืนยันการยกเลิกใช้งานโปรแกรม!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (answer == DialogResult.OK)
            {              
                this.Close();
            }
            else {

                //string test = "";
            }
        }
         


        private void tbxUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                tbxPassword.Focus();
            }
        }

        private void tbxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Login();
            }
        }

        private void btn_showpwd_MouseDown(object sender, MouseEventArgs e)
        {
            //tbxPassword.BackColor = Color.Red;
            tbxPassword.PasswordChar = '\0';
        }

        private void btn_showpwd_MouseUp(object sender, MouseEventArgs e)
        {
            //tbxPassword.BackColor = Color.White;
            tbxPassword.PasswordChar = '*';
            tbxPassword.Focus();
        }      
              
        
        private void tg_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (tg_btn.Checked == true)
            {
                DB_Name = "SapthipNewDB";
                txt_dbName.Text = "Database: Go Live";
            }
            else
            {
                DB_Name = "TruckScal_UAT";
                txt_dbName.Text = "Database: UAT";
            }
        }
    }
}
