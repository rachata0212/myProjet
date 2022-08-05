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
    public partial class Frmchangdate : Form
    {
        public Frmchangdate()
        {
            InitializeComponent();
        }

        public string idtran = "";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Frmchangdate_Load(object sender, EventArgs e)
        {           
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sdate = dtpdate.Value.Day.ToString();
            string smonth = dtpdate.Value.Month.ToString();
            string syear = dtpdate.Value.Year.ToString();
            string selectdate = smonth + "/" + sdate + "/" + syear;

            if (rdost.Checked == true && idtran != "")
            {
                string sql = "update tbtransport set dateWbf= '" + selectdate + "' Where idtran='" + idtran + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();
                MessageBox.Show("ปรับปรุงข้อมูลเรียบร้อย !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            if (rdoen.Checked == true && idtran != "")
            {
                string sql = "update tbtransport set dateAbf='" + selectdate + "'Where idtran='" + idtran + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();
                MessageBox.Show("ปรับปรุงข้อมูลเรียบร้อย !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();  
            }
            CN.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}