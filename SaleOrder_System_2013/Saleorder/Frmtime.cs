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
    public partial class Frmtime : Form
    {
        public Frmtime()
        {
            InitializeComponent();
        }

        int idtime = 0;
        private void btnaddedit_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (txttime.Text != "")
            {
                string sql = "update tbtime set times=" + txttime.Text + " Where idtime= " + idtime + "";
                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();

                this.Close();

                MessageBox.Show("ข้อมูลทำการปรับปรุงแล้ว ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);    
            }
            CN.Close();
        }

        private void Frmtime_Load(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql = "select * from tbtime ORDER BY idtime DESC";
            SqlCommand CM = new SqlCommand(sql, CN);
            SqlDataReader DR = CM.ExecuteReader();

            DR.Read();
            {
                idtime = Convert.ToInt16(DR["idtime"].ToString());
                txttime.Text = Convert.ToString(DR["times"].ToString());
            }
            DR.Close();
            CN.Close();
        }
    }
}