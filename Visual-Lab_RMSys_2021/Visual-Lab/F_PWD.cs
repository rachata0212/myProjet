using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Lab
{
    public partial class F_PWD : Form
    {
        public F_PWD()
        {
            InitializeComponent();
        }

        public int Value_Confirm = 0;
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (txt_pwd.Text == "9999")
            {
                Value_Confirm = 1;
                this.Close();

            }
            else { MessageBox.Show("รหัสผ่านในการเปลี่ยนแปลงผิด ! กรุณาใส่รหัสที่ถูกต้อง/ติดต่อผุ้ดูแลระบบ","รหัสยืนยันการเปลี่ยนปลง",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }
    }
}
