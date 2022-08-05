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
    public partial class Frmconfirmpwd : Form
    {
        public Frmconfirmpwd()
        {
            InitializeComponent();
        }

        public int idcheck = 0; string pwd = "";

        private void Frmcomfirmpwd_Load(object sender, EventArgs e)
        {



        }

        private void btnok_Click(object sender, EventArgs e)
        {
            CheckPWD();
            if (txtpassword.Text.Trim() == pwd)
            {
                idcheck = 1;
                this.Close();
            }
            else
            { MessageBox.Show("รหัสผ่านไม่ถูกต้อง", "ผิดพลาด !"); txtpassword.Clear(); }
        }

        private void CheckPWD()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql2 = "SELECT pwd FROM tbemployee where idemp = '" + Program.empID + "'";
            SqlCommand CM2 = new SqlCommand(sql2, CN);
            SqlDataReader DR2 = CM2.ExecuteReader();
            DR2.Read();
            {
                pwd = DR2["pwd"].ToString().Trim();
            }
            DR2.Close();
        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                CheckPWD();
                if (txtpassword.Text.Trim() == pwd)
                {
                    idcheck = 1;
                    this.Close();
                }
                else
                { MessageBox.Show("รหัสผ่านไม่ถูกต้อง", "ผิดพลาด !"); txtpassword.Clear(); }
            }
        }

        private void btncancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
