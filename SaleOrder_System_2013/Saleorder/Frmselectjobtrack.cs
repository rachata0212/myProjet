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
    public partial class Frmselectjobtrack : Form
    {
        public Frmselectjobtrack()
        {
            InitializeComponent();
        }

        public int xposition = 0;
        public int yposition = 0;
        public string idtran = "";
        DataSet ds2 = new DataSet();

        private void Frmselectjobtrack_Load(object sender, EventArgs e)
        {
            this.Location = new Point(xposition, yposition);
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql2 = "select * from tbjobtrack";
            SqlDataAdapter da2 = new SqlDataAdapter(sql2, CN);
            da2.Fill(ds2, "track");
            cbstatus.DataSource = ds2.Tables["track"];
            cbstatus.DisplayMember = "jobtrack";
            cbstatus.ValueMember = "idjobtrack";
            CN.Close();
        }

        private void btncancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql1 = "Update tbtransport set idjobtrack = " + cbstatus.SelectedValue.ToString() + ",remark2 = '" + txtremark.Text + "' where idtran = '" + idtran + "'";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            CM1.ExecuteNonQuery();           
            MessageBox.Show("ปรับปรุงข้อมูลเรียบร้อย ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CN.Close();
            this.Close();
        }
    }
}