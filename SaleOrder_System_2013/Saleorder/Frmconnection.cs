using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Win32;

namespace SaleOrder
{
    public partial class Frmconnection : Form
    {
        public Frmconnection()
        {
            InitializeComponent();
        }

        RegistryKey r;
        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtdatabasename.Text == "")
                {
                    MessageBox.Show("TextBox Not Null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtdatabasename.Focus();
                }
                else if (txtdatasource.Text == "")
                {
                    MessageBox.Show("TextBox Not Null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtdatasource.Focus();
                }
                else if (txtpassword.Text == "")
                {
                    MessageBox.Show("TextBox Not Null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpassword.Focus();
                }
                else if (txtusername.Text == "")
                {
                    MessageBox.Show("TextBox Not Null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtusername.Focus();
                }
                else if (txtdatabasename.Text != "")
                {
                    FileInfo file = new FileInfo(Application.StartupPath + "\\cn.dll");
                    StreamWriter writer = file.CreateText();
                    string povider = "data source=" + txtdatasource.Text + ";" + "initial catalog=" + txtdatabasename.Text + ";" + "user id=" + txtusername.Text + ";" + "password=" + txtpassword.Text + ";";
                    writer.Write(povider);
                    writer.Close();
                    //Program.CN.Open();
                    r = Registry.CurrentUser.CreateSubKey("Saleorder");//สร้าง registry ที่ชื่อ MyRegistry1
                    r.SetValue("ServerName", txtdatasource.Text);//กำหนดค่า value
                    r.SetValue("DatabaseName", txtdatabasename.Text);
                    r.SetValue("UserID", txtusername.Text);
                    r.SetValue("Password", txtpassword.Text);
                    r.Close();
                    this.Close();
                }
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (txtdatabasename.Text == "")
            {
                MessageBox.Show("TextBox Not Null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdatabasename.Focus();
            }
            else if (txtdatasource.Text == "")
            {
                MessageBox.Show("TextBox Not Null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdatasource.Focus();
            }
            else if (txtusername.Text == "")
            {
                MessageBox.Show("TextBox Not Null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtusername.Focus();
            }
            else if (txtdatabasename.Text != "")
            {
                FileInfo file = new FileInfo(Application.StartupPath + "\\cn.dll");
                StreamWriter writer = file.CreateText();
                string povider = "data source=" + txtdatasource.Text + ";" + "initial catalog=" + txtdatabasename.Text + ";" + "user id=" + txtusername.Text + ";" + "password=" + txtpassword.Text + ";";
                writer.Write(povider);
                writer.Close();
                //Program.CN.Open();

                r = Registry.CurrentUser.CreateSubKey("Saleorder");//สร้าง registry ที่ชื่อ MyRegistry1
                r.SetValue("ServerName", txtdatasource.Text);//กำหนดค่า value
                r.SetValue("DatabaseName", txtdatabasename.Text);
                r.SetValue("UserID", txtusername.Text);
                r.SetValue("Password", txtpassword.Text);
                r.Close();
                this.Close();
            }   
        }

        private void btncancle_Click(object sender, EventArgs e)
        {
            DialogResult answer;
            answer = MessageBox.Show("คุณต้องการออกจากโปรแกรมใช่หรือไม่ !", "ยืนยัน", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (answer == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void Frmconnection_Load(object sender, EventArgs e)
        {

        }
    }
}