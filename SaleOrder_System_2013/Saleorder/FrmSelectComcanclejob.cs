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
    public partial class FrmSelectComcanclejob : Form
    {
        public FrmSelectComcanclejob()
        {
            InitializeComponent();
        }

        
        DataSet ds = new DataSet(); dtssaleorder dssearch = new dtssaleorder();
        DataSet ds1 = new DataSet(); dtssaleorder dssearch1 = new dtssaleorder();



        public int idsearch = 0; public string idcus = ""; public string namecus = ""; public string idsup = ""; public string namesup = "";
        private void FrmSelectComcanclejob_Load(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (idsearch == 0) //searhc order purchase sup
            {
                ds1.Clear(); dssearch1.Clear();
                string sql1 = "select * from vpurchesOrdertran";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                da1.Fill(ds1, "scomsup");
                dtgpurtranstatus.DataSource = ds1.Tables["scomsup"];
                dtgpurtranstatus.Visible = true;
                txtcount.Text = dtgpurtranstatus.RowCount.ToString();
            }
            if (idsearch == 1)// search order sale
            {
                ds.Clear(); dssearch.Clear();
                dtgsaletranstatus.DataSource = dssearch;
                string sql = "select * from vsaleordertran";
                SqlDataAdapter da = new SqlDataAdapter(sql, CN);
                da.Fill(ds, "scomcus");
                dtgsaletranstatus.DataSource = ds.Tables["scomcus"];
                dtgsaletranstatus.Visible = true;
                txtcount.Text = dtgsaletranstatus.RowCount.ToString();
            }
            CN.Close();
        }

        private void dtgsaletranstatus_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgsaletranstatus[0, e.RowIndex].Value.ToString() != "")//sale order
            {
                idcus = dtgsaletranstatus[0, e.RowIndex].Value.ToString();
                namecus = dtgsaletranstatus[2, e.RowIndex].Value.ToString();
                this.Close();           
            }
        }

        private void dtgpurtranstatus_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgpurtranstatus[0, e.RowIndex].Value.ToString() != "")//purchase order
            {
                idsup = dtgpurtranstatus[0, e.RowIndex].Value.ToString();
                namesup = dtgpurtranstatus[2, e.RowIndex].Value.ToString();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                this.Close();                 
        }

        private void dtgpurtranstatus_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgpurtranstatus.RowCount < 0) return;
            {
                idsup = dtgpurtranstatus[0, e.RowIndex].Value.ToString();
                namesup = dtgpurtranstatus[2, e.RowIndex].Value.ToString();
            }
        }

        private void dtgsaletranstatus_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgsaletranstatus.RowCount < 0) return;
            {
                idcus = dtgsaletranstatus[0, e.RowIndex].Value.ToString();
                namecus = dtgsaletranstatus[2, e.RowIndex].Value.ToString();
            }
        }
    }
}