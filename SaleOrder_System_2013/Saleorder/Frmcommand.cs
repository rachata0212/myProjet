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
    public partial class Frmcommand : Form
    {
        public Frmcommand()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet(); 
        DataSet dssloadgrid = new DataSet();
        int dsrunno = 0; string nameds = "";

        private void txtremark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ds.Clear(); dssloadgrid.Clear();
                try
                {
                    SqlConnection CN = new SqlConnection();
                    CN.ConnectionString = Program.urldb;
                    CN.Open();
                    dtganswer.DataSource = dssloadgrid;
                    string sql = txtcommand.Text.Trim();
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    nameds = dsrunno.ToString();
                    da1.Fill(ds, nameds);
                    dtganswer.DataSource = ds.Tables[nameds];
                    dsrunno += 1;
                    CN.Close();
                }
                catch
                { MessageBox.Show("คำสั่งผิดพลาด", "รบกวนเช็คคำสั่งอีกครั้ง",MessageBoxButtons.OK); }
            }
        }       

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}