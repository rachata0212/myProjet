using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SaleOrder
{
    public partial class Frmlogin : Form
    {
        public Frmlogin()
        {
            InitializeComponent();
        }

        string statuslogin = "Fale";
        string datelog = DateTime.Now.Day.ToString();
        string monthlog = DateTime.Now.Month.ToString();
        string yearlog = DateTime.Now.Year.ToString();

        private void btncancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
           // CheckStatusLogin();//เช็คว่า username นี้กำลังเข้าใช้หรือไม่แล้วส่งค่าไปที่ตรวจสอบชื่อ/
            loginsystem(); //ตรวจสอบชื่อ
            UpdateLogIn();
        }

        private void CheckStatusLogin()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            try
            {
                string sql = "select isemp  from tbemployee where uid='" + txtuser.Text + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                DR.Read();
                {
                    if ("True" == DR["isemp"].ToString())
                    {
                        statuslogin = "True";//user id
                    }
                }
                DR.Close();
                CN.Close();
            }
            catch
            { MessageBox.Show("ไม่มีชื่อผู้ใช้งานนี้ในระบบ", "ผิดพลาด !", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void UpdateLogIn()//updata Status employee login
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql = "update tbemployee set isemp=" + 1 + " Where idemp= '" + Program.empID + "'";
            SqlCommand CM = new SqlCommand(sql, CN);
            CM.ExecuteNonQuery();
            CN.Close();
        }

        private void loginsystem()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string x = txtuser.Text;
            CheckStatusLogin();

            if (statuslogin == "Fale")//เช็คสถานล็อกอิน
            {
                string sql = "select * from vemplogin where uid='" + txtuser.Text + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                while (DR.Read())
                {
                    if (x.ToString() == DR["uid"].ToString().Trim())
                    {
                        if (txtpwd.Text == DR["pwd"].ToString().Trim())
                        {
                            Program.logins = DR["uid"].ToString();//user id
                            Program.names = DR["empname"].ToString(); //ชื่อพนักงาน                    
                            Program.iddept = DR["iddep"].ToString();//รหัสแผนกพนักงาน
                            Program.empID = DR["idemp"].ToString();//รหัสพนักงาน
                            Program.idbranch = DR["idbranch"].ToString(); //รหัสสาขา
                            Program.email = DR["emailname"].ToString(); //รหัสสาขา
                            Savelogevent();
                            this.Close();
                        }
                        else
                        {
                            txtuser.Clear();
                            txtpwd.Clear();
                        }
                    }
                }
                DR.Close();

                string sql1 = "select times from tbtime";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    Program.showtime = Convert.ToInt16(DR1["times"].ToString().Trim());
                }
                DR1.Close();
            }

            else
            { MessageBox.Show("ชื่อนี้ไม่มีในระบบหรือมีผู้ใช้แล้ว", "ลงชื่อเข้าใช้ซ้ำ", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            CN.Close();
        }       

        private void Savelogevent()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string selectdatelog = monthlog + "/" + datelog + "/" + yearlog; 
            string msnfrom = "FormLogin";
            string sql1 = "insert into tblog(logname,datein,timein,idtypelog,idemp,remark) values('" + msnfrom + "','" + selectdatelog + "','" + DateTime.Now.ToLongTimeString() + "'," + 4 + ",'" + Program.empID + "','" + Program.empID + "')";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            CM1.ExecuteNonQuery();
            CN.Close();
        }

        private void Frmlogin_Load(object sender, EventArgs e)
        {
            txtuser.Focus();
        }

        private void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtpwd.Focus();
            }
        }

        private void txtpwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                loginsystem();
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            CheckStatusLogin();

            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string x = txtuser.Text;            

            if (statuslogin == "True")//เช็คสถานล็อกอิน
            {
                string sql = "select * from vemplogin where uid='" + txtuser.Text + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                while (DR.Read())
                {
                    if (x.ToString() == DR["uid"].ToString().Trim())
                    {
                        if (txtpwd.Text == DR["pwd"].ToString().Trim())
                        {
                            //Reset status
                            DialogResult answer;
                            answer = MessageBox.Show("คุณต้องการรีเซ็ตสถานะชื่อนี้ใช่หรือไม่ !", "กรุณายืนยัน !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            if (answer == DialogResult.OK)
                            {
                                resetstatusID();
                            }
                        }
                        else
                        { MessageBox.Show("กรุณาระบุรหัสผ่านที่ถูกต้อง เพื่อทำการยืนยันตัวตนของท่าน", "ยืนยันตัวจริง", MessageBoxButtons.OK, MessageBoxIcon.Error); } 
                    }
                    else
                    { MessageBox.Show("UserID นี้ไม่มีในระบบ", "UserID ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error); }                    
                }
                DR.Close();               
            }





            CN.Close();
        }

        private void resetstatusID()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql1 = "update tbemployee set isemp=0 Where uid= '" + txtuser.Text.Trim() + "'";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            CM1.ExecuteNonQuery();
            MessageBox.Show("ระบบได้ทำการ Reset Login แล้วกรุณา Login เข้าโปรแกรมใหม่อีกครั้ง", "New Reset Login!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CN.Close();
            Application.Restart();
        }       

        private void bthchangpwd_Click(object sender, EventArgs e)
        {
            CheckStatusLogin();

            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string x = txtuser.Text;

            if (statuslogin == "Fale")//เช็คสถานล็อกอิน
            {
                string sql = "select * from vemplogin where uid='" + txtuser.Text + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                while (DR.Read())
                {
                    if (x.ToString() == DR["uid"].ToString().Trim())
                    {
                        if (txtpwd.Text == DR["pwd"].ToString().Trim())
                        {
                            //Reset status
                            DialogResult answer;
                            answer = MessageBox.Show("คุณต้องการเปลี่ยนแปลงรหัสผ่านใช่หรือไม่ !", "กรุณายืนยัน !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            if (answer == DialogResult.OK)
                            {
                                Frmchangpwd fcpwd = new Frmchangpwd();
                                fcpwd.uid = x.ToString();
                                fcpwd.ShowDialog();

                                if (fcpwd.idsuccess == 1)
                                {
                                    Application.Restart();
                                }
                            }
                        }
                        else
                        { MessageBox.Show("กรุณาระบุรหัสผ่านที่ถูกต้อง เพื่อทำการยืนยันตัวตนของท่าน", "ยืนยันตัวจริง", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                    { MessageBox.Show("UserID นี้ไม่มีในระบบ", "UserID ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                DR.Close();
            }
            CN.Close();
        }

        private void btnlostpwd_Click(object sender, EventArgs e)
        {
            CheckStatusLogin();

            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string x = txtuser.Text;

            if (statuslogin == "Fale")//เช็คสถานล็อกอิน
            {
                string sql = "select * from vemplogin where uid='" + txtuser.Text + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                while (DR.Read())
                {
                    if (x.ToString() == DR["uid"].ToString().Trim())
                    {
                        DialogResult answer;
                        answer = MessageBox.Show("คุณต้องการส่งคำร้องขอในการรีเซ็ตรหัสผ่านเพราะคุณลืมรหัสผ่านในการเข้าระบบใช้หรือไม่ !", "กรุณายืนยัน !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (answer == DialogResult.OK)
                        {
                            Frmresetpwdbyemail fcpwd = new Frmresetpwdbyemail();
                            fcpwd.uid = x.ToString();
                            fcpwd.ShowDialog();

                            if (fcpwd.idsuccess == 1)
                            {
                                MessageBox.Show("ระบบทำการส่งอีเมล์ไปยังผู้ดูแลระบบแล้ว กรุณารอในการแจ้งตอบกลับไปทางอีเมล์ของท่าน", "ยืนยันตัวจริง", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Application.Exit();
                            }
                        }                       
                    }
                    else
                    { MessageBox.Show("UserID นี้ไม่มีในระบบ", "UserID ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                DR.Close();
            }
            CN.Close();
        }

        private void btnreset_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("รีเซ็ตรหัสผ่านใหม่ถ้า Login ไม่ได้", btnreset);
        }

        private void bthchangpwd_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("เปลี่ยนแปลงรหัสผ่านใหม่", bthchangpwd); 
        }

        private void btnlostpwd_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show("ลืมรหัสผ่าน และส่งเรื่องให้ผู้ดูแลระบบเป็นคนรีเซ็ตรหัสใหม่ให้", btnlostpwd); 
        }




    }
}