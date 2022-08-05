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
    public partial class Frmchangpwd : Form
    {
        public Frmchangpwd()
        {
            InitializeComponent();
        }

        public string uid = "";
        public int idsuccess = 0;

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtconfirmpwd.Text != txtnewpwd.Text)
            {
                MessageBox.Show("ระบุรหัสผ่านใหม่ไม่ถูกต้องตรงกัน", "รหัสผ่านใหม่ไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtconfirmpwd.Clear(); txtconfirmpwd.Focus();
            }
            else { ChangPWD(); }
        }

        private void txtnewpwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtnewpwd.Text == "")
                { MessageBox.Show("กรุณาระบุรหัสผ่านใหม่", "สร้างรหัสผ่านใหม่", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else { txtconfirmpwd.Focus(); }
            }
        }

        private void txtconfirmpwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtconfirmpwd.Text != txtnewpwd.Text)
                {
                    MessageBox.Show("ระบุรหัสผ่านใหม่ไม่ถูกต้องตรงกัน", "รหัสผ่านใหม่ไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtconfirmpwd.Clear(); txtconfirmpwd.Focus();
                }
                else { ChangPWD(); }
            }
        }

        private void ChangPWD()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql1 = "update tbemployee set pwd='" + txtconfirmpwd.Text.Trim() + "' Where uid= '" + uid + "'";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            CM1.ExecuteNonQuery();
            MessageBox.Show("ระบบได้ทำการเปลี่ยนแปลงรหัสผ่านเรียบร้อยแล้วกรุณา Login เข้าโปรแกรมใหม่อีกครั้ง", "New Password Login!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CN.Close();
            idsuccess = 1;
            this.Close();
        }

        private void btncancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}