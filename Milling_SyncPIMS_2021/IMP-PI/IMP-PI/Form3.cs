using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMP_PI
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public int Status_Confirm = 0;
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btn_confrim_Click(object sender, EventArgs e)
        {
            if (txt_pwd.Text == "9999")
            {
                Status_Confirm = 1;
                this.Close();
            }
            else { MessageBox.Show("รหัสยืนยันผิด กรุณาใส่รหัสที่ถูกต้องอีกครั้ง", "การยืนยันผิดพลาด!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
