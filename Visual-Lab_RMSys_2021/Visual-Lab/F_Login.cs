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
using System.Net;

namespace Visual_Lab
{
    public partial class F_Login : Form
    {
        public F_Login()
        {
            InitializeComponent();
        }
             

        int Status_Use = 0;
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (tbxUserName.Text != "")
            {
                Login();
            }
            else
            {
                MessageBox.Show("กรุณาระบุข้อมูลชื่อผู้ใช้งาน...!", "ตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbxUserName.Select();
            }
        }

        private void Login()
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
                }

                if ((flgLogin == true))
                {
                    //test
                    // MessageBox.Show("Login OK");

                    Program.user_login = tbxUserName.Text.Trim();

                    Load_Permission();

                    if (Status_Use == 1)
                    {

                        this.Close();
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
                tbxPassword.Focus();
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

        private void Load_Permission()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pahtdb);
                con.ConnectionString = Program.pahtdb;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql6 = "SELECT  Status_Use,UserID FROM [SapthipNewDB].[dbo].[V_Permission] WHERE [User_AD] = '" + Program.user_login + "' AND [ID_Menu]= 7 ";
                SqlCommand CM6 = new SqlCommand(sql6, con);
                SqlDataReader DR6 = CM6.ExecuteReader();

                DR6.Read();
                {
                    Program.user_id = Convert.ToInt16(DR6["UserID"].ToString());
                    if (DR6["Status_Use"].ToString().Trim() == "True") { Status_Use = 1; }                  
                }
                DR6.Close();
                con.Close();

                if (Status_Use == 0)
                {
                    MessageBox.Show("สิทธิ์การใช้งานถูกจำกัด กรูณาตรวจสอบกับผู้ดูแลระบบ (เปิดโปรแกรม Visual)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Application.Exit();
                }             

            }

            catch
            {
                MessageBox.Show("ไม่มีการเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (เปิดโปรแกรม Visual)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Application.Exit();
            }

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

        private void F_Login_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            StreamReader sw = new StreamReader(Application.StartupPath + "\\cn.dll");
            string connecpovider = sw.ReadToEnd();
            Program.CN = new SqlConnection();
            Program.CN.ConnectionString = connecpovider;
            Program.pahtdb = connecpovider;
            Program.MachineName = Environment.MachineName.ToString();
            Program.LocalIpAddress = GetIPAddress();
        }
    }
}
