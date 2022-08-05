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
    public partial class FrmprinorsaveQuatation : Form
    {
        public FrmprinorsaveQuatation()
        {
            InitializeComponent();
        }
        public string idqua = "";
        private void btnok_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (rdoprint.Checked == true)
            {
                Frmviewreport fvrp = new Frmviewreport();
                fvrp.idqua = idqua;
                fvrp.rpname = "rpquatation";
                fvrp.ShowDialog();
                this.Close();
            }
            if (rdosaveandclose.Checked == true)
            {
                //updat seve  
                string sql = "update tbquatation set idstatusqua = 10 Where idqua='" + idqua + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();
                MessageBox.Show("ปรับปรุงข้อมูลเรียบร้อย !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }




    }
}