using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SaleOrder
{
    public partial class Frmpermisionapprovequa : Form
    {
        public Frmpermisionapprovequa()
        {
            InitializeComponent();
        }

        string idemp = "";

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            //Frmserch fs = new Frmserch();
            //fs.sname = "sempsale";
            //fs.ShowDialog();
            //if (fs.returnid.Trim() != "0")
            //{
            //    txtidsale.Text = fs.returnid;
            //    Searchemp();
            //    txtqano.Focus();
            //}
        }

        private void Searchemp()
        {
            //SqlConnection CN = new SqlConnection();
            //CN.ConnectionString = Program.urldb;
            //CN.Open();

            //if (txtidsale.Text.Trim() != "")
            //{
            //    string sql = "select * from vempsale where idemp='" + txtidsale.Text + "'";
            //    SqlCommand CM1 = new SqlCommand(sql, CN);
            //    SqlDataReader DR1 = CM1.ExecuteReader();

            //    DR1.Read();
            //    {
            //        txtidsale.Text = DR1["idemp"].ToString().Trim();
            //        txtnamessale.Text = DR1["empname"].ToString().Trim();
            //    }
            //    DR1.Close();
            //}
            //CN.Close();
        }

    }
}