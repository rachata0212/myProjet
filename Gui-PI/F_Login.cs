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

namespace Gui_PI
{
    public partial class F_Login : Form
    {
        public F_Login()
        {
            InitializeComponent();
        }

        //public string Username;
        private void Form2_Load(object sender, EventArgs e)
        {

        }

       public int IDUser_Enable = 0;
        private void Login()
        {
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
                    }

                    if ((flgLogin == true))
                    {
                        //test
                        // MessageBox.Show("Login OK");

                        Program.user_id = tbxUserName.Text.Trim();
                        Check_StatusUser();

                        if (IDUser_Enable == 1)
                        {
                            this.Close();
                        }

                        else { MessageBox.Show("ไอดีของคุณยังไม่ได้ถูกเปิดใช้งาน กรุณาติดต่อผู้ดูแลระบบ", "การเข้าใช้ผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
            else
            {
                MessageBox.Show("กรุณาระบุข้อมูลชื่อผู้ใช้งาน...!", "ตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbxUserName.Select();
            }
        }

        private void Check_StatusUser()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            string sql3 = "Select [U_Status] FROM [dbo].[TB_User]  Where [U_ID] ='" + Program.user_id + "'";
            SqlCommand CM3 = new SqlCommand(sql3, con);
            SqlDataReader DR3 = CM3.ExecuteReader();
            DR3.Read();
            {
                if (DR3["U_Status"].ToString().Trim() == "True")
                {
                    IDUser_Enable = 1;
                }               
            }
            DR3.Close();
            con.Close();
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
    }
}
