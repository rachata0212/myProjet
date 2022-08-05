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
    public partial class Frmselectproduct : Form
    {
        public Frmselectproduct()
        {
            InitializeComponent();
        }

        string idbranch = "";
        public string idtran = "";
        DataSet ds = new DataSet();
        public int idload = 0;

        private void Frmselectproduct_Load(object sender, EventArgs e)
        {
            LoadIDbranch();
            LoadSupproduct();
        }

        private void LoadIDbranch()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql3 = "select idbranch from tbtransport WHERE idtran ='" + idtran + "'";
            SqlCommand CM3 = new SqlCommand(sql3, CN);
            SqlDataReader DR3 = CM3.ExecuteReader();

            DR3.Read();
            { idbranch = DR3["idbranch"].ToString(); }
            DR3.Close();
            CN.Close();
        }

        private void LoadSupproduct()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); int idpro = 0;  string sql3="";

            if (idload == 0)
            { sql3 = "select idpro from vpurchase WHERE idtran ='" + idtran + "'"; }
            else
            { sql3 = "select idpro from vsaleorder WHERE idtran ='" + idtran + "'"; }

            SqlCommand CM3 = new SqlCommand(sql3, CN);
            SqlDataReader DR3 = CM3.ExecuteReader();

            DR3.Read();
            { idpro = Convert.ToInt16(DR3["idpro"].ToString()); }
            DR3.Close();

            string sql1 = "select idsuppro,namesup from vproductinstock where idbranch=" + idbranch + " and idpro=" + idpro + "";

            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(ds, "spropur");
            cbselectpro.DataSource = ds.Tables["spropur"];
            cbselectpro.DisplayMember = "namesup";
            cbselectpro.ValueMember = "idsuppro";
            cbselectpro.Text = "";
            CN.Close();
        }

        private void btnweigtnsave_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql3 = "update tbtransport set idsuppro=" + cbselectpro.SelectedValue.ToString() + " Where idtran= '" + idtran + "'";

            SqlCommand CM3 = new SqlCommand(sql3, CN);
            CM3.ExecuteNonQuery();
            CN.Close();
            this.Close();
        }

        private void btncancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}