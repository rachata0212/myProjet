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
    public partial class FrmselectCarSplite : Form
    {
        public FrmselectCarSplite()
        {
            InitializeComponent();
        }

        public string idcar = "";
        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btncar_Click(object sender, EventArgs e)
        {
            Frmserch fs = new Frmserch();
            fs.sname = "scar";
            fs.ShowDialog();
            if (fs.returnid.Trim() != "0")
            {
                txtidcar.Text = fs.returnid;
                Searchcar();
            }
        }

        private void Searchcar()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql = "select * from vcar where idcar='" + txtidcar.Text + "'";
            SqlCommand CM1 = new SqlCommand(sql, CN);
            SqlDataReader DR1 = CM1.ExecuteReader();
            DR1.Read();
            {
                txtidcar.Text = DR1["idcar"].ToString().Trim();
                txtnamecar.Text = DR1["carname"].ToString().Trim();
            }
            DR1.Close();
            CN.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtidcar.Text == "9")
            {
                idcar = txtidcar.Text.Trim();
                this.Close(); 
            }

            else if (txtidcar.Text == "10")
            {
                idcar = txtidcar.Text.Trim();
                this.Close();
            }

            else if ( txtidcar.Text == "11")
            {
                idcar = txtidcar.Text.Trim();
                this.Close();
            }
            //save
            else
            { MessageBox.Show("คุณเลือกรถที่จะส่งผิดประเภทกรุณณาเลือกรถประเภทรถเดี่ยวเท่านั้น", "ผิดพลาด !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtidcar.Clear(); txtnamecar.Clear();
               
            }
        }

        private void FrmselectCarSplite_Load(object sender, EventArgs e)
        {

        }
    }
}