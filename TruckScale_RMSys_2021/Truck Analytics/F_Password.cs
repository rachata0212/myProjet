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
using System.DirectoryServices;

namespace Truck_Analytics
{
    public partial class F_Password : Form
    {
        public F_Password()
        {
            InitializeComponent();
        }

        public int sts_pwd = 0;
        public int id_request = 0;

        string Msg = "";
        string Log_NewValue = "";
        string Log_OldValue = "";

        // check approved job
        int ID_JobApproved = 0;
        string UserAD_Approved = "";

       
                              
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (id_request != 4 && id_request != 5)
            {
                if (txt_pwd.Text == "1234")
                {
                    // 
                    sts_pwd = 1;
                                    
                    Msg = "Change Password Completed!";
                    Log_OldValue = "User Change =" + Program.user_id;             

                    this.Close();
                }
                else
                {
                    Msg = "Password Comfirm Failed!";
                    Log_OldValue = "User Change =" + Program.user_id;


                    MessageBox.Show("รหัสผ่านไม่ถูกต้อง", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_pwd.Clear();
                }
            }


            if (id_request == 4)
            {
                Check_UserApproved();
                Login();
            }

            if (id_request == 5)
            {
                Login();
            }

            Log_NewValue = "-";
            Class_Log CL = new Class_Log();
            CL.tbname = Msg;
            CL.oldvalue = Log_OldValue;
            CL.newvalue = Log_NewValue;
            CL.Save_log();

        }

        private void Login()
        {
            string nameLogin = "";

                if (txt_pwd.Text != "")
                {
                if (id_request == 4)
                {
                    nameLogin = UserAD_Approved;
                }

                if (id_request == 5)
                {
                    nameLogin = Program.user_login;
                }
                    string pwdLogin = txt_pwd.Text.Trim();

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
                    }

                    if ((flgLogin == true))
                    {                    
                        sts_pwd = 1;
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("ไม่พบข้อมูลผู้มีสิทธิ์อนุมัติงาน.!", "ตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("กรุณาระบุรหัสผ่านผู้มีสิทธิ์อนุมัติ.!", "ตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);               
                }
           
        
        }

        private void Check_UserApproved()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql6 = "SELECT [User_AD]  FROM  [dbo].[V_Permission] Where [ID_Menu] =40 AND [Approvdata_per]=1";
            SqlCommand CM6 = new SqlCommand(sql6, con);
            SqlDataReader DR6 = CM6.ExecuteReader();

            DR6.Read();
            {
               UserAD_Approved = DR6["User_AD"].ToString().Trim();                
            }
            DR6.Close();
            con.Close();
        }


        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void F_Password_Load(object sender, EventArgs e)
        {
            if (id_request == 1)
            {
                lbl_name.Text = "รหัสยืนยันการเปลี่ยนแปลง";
            }

            if (id_request == 2) //ก่อนเข้า
            {
                lbl_name.Text = "รหัสเข้าเปลี่ยนแปลงการตั้งค่า";
            }


            if (id_request == 3) //หลังเปลี่ยนแปลง
            {
                lbl_name.Text = "รหัสยืนยันการเปลี่ยนแปลงการตั้งค่า";
            }

            if (id_request == 4) //หลังเปลี่ยนแปลง
            {
                lbl_name.Text = "รหัสยืนยันการปล่อยสินค้าที่ไม่ผ่านเกณฑ์";
            }

            txt_pwd.Focus();
        }

        private void btn_showpwd_MouseDown(object sender, MouseEventArgs e)
        {
            txt_pwd.PasswordChar = '\0';
        }

        private void btn_showpwd_MouseUp(object sender, MouseEventArgs e)
        {
            txt_pwd.PasswordChar = '*';
        }

        private void txt_pwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (id_request != 4 && id_request != 5)
                {
                    if (txt_pwd.Text == "1234")
                    {
                        // 
                        sts_pwd = 1;

                        Msg = "Change Password Completed!";
                        Log_OldValue = "User Change =" + Program.user_id;

                        this.Close();
                    }
                    else
                    {
                        Msg = "Password Comfirm Failed!";
                        Log_OldValue = "User Change =" + Program.user_id;


                        MessageBox.Show("รหัสผ่านไม่ถูกต้อง", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_pwd.Clear();
                    }
                }


                if (id_request == 4)
                {
                    Check_UserApproved();
                    Login();
                }

                if (id_request == 5)
                {
                    Login();
                }

                Log_NewValue = "-";
                Class_Log CL = new Class_Log();
                CL.tbname = Msg;
                CL.oldvalue = Log_OldValue;
                CL.newvalue = Log_NewValue;
                CL.Save_log();

            }
        }
    }
}
