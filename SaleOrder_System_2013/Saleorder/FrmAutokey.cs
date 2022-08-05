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
    public partial class FrmAutokey : Form
    {
        public FrmAutokey()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet(); dtssaleorder dssearch = new dtssaleorder();
        private void btnserchbranch_Click(object sender, EventArgs e)
        {
            string id;
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            //if (searchtype == "stypecom")
            //{
            Frmserch fs = new Frmserch();
            fs.sname = "";
            fs.sname = "sbranch";
            fs.ShowDialog();
            id = fs.returnid;

            if (id != "0")
            {
                string sql2 = "select * from tbbrach where idbranch='" + id + "'";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();

                DR2.Read();
                {
                    txtid.Text = DR2["idbranch"].ToString().Trim();
                    txtnamebranch.Text = DR2["bname"].ToString().Trim();
                }
                DR2.Close();
            }
            CN.Close();
        }

        private void FrmAutokey_Load(object sender, EventArgs e)
        {
            Loadgrid();
        }

        private void Loadgrid()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql;
            ds.Clear();
            dssearch.Clear();
            dtgautokey.DataSource = dssearch;
            sql = "select * from vautokeychar";
            SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
            da1.Fill(ds, "skey");
            dtgautokey.DataSource = ds.Tables["skey"];
            dtgautokey.Visible = true;
            CN.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (txtid.Text != "" && txtkey.Text != "") // insert
            {
                string sql = "insert into tbatbranch(idbranch,charname,remarkatbranch) values ('" + txtid.Text + "','" + txtkey.Text + "','" + txtremark.Text + "')";

                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();

                MessageBox.Show("บันทึกข้อมูลประสบความสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loadgrid();
            }
            CN.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}