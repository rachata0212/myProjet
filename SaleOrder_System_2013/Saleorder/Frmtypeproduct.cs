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
    public partial class Frmtypeproduct : Form
    {
        public Frmtypeproduct()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet(); DataSet dssearch = new DataSet();
        //DataSet ds1 = new DataSet(); DataSet dssearch1 = new DataSet();
        string idpro = "0"; string id = "0";

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frmtypeproduct_Load(object sender, EventArgs e)
        {
           LoadtypeProduct();
        }

        private void LoadtypeProduct()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
           
            ds.Clear(); dssearch.Clear();
            dtgtypepro.DataSource = dssearch;
            string sql = "select * from vsupproduct order by namesup";
            SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
            da1.Fill(ds, "vtypepro");
            dtgtypepro.DataSource = ds.Tables["vtypepro"];
            CN.Close();
        }

        private void btnserchpro_Click(object sender, EventArgs e)
        {          
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            Frmserch fs = new Frmserch();
            fs.sname = "spropur";
            fs.ShowDialog();
            id = fs.returnid;

            if (id != "0")
            {
                string sql = "select * from tbproduct where idpro='" + id + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();
                idpro = id.ToString();

                DR1.Read();
                {
                    idpro =DR1["idpro"].ToString().Trim();
                    txtproname.Text = DR1["proname"].ToString().Trim();
                }
                DR1.Close();
            }
            CN.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (idpro != "0" && txtsubpro.Text != "")
            {
                string sql1 = "insert into tbsupproduct(namesup,remark,idpro) values('" + txtsubpro.Text + "','" + txtremark.Text + "'," + idpro + ")";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                CM1.ExecuteNonQuery();

                MessageBox.Show("บันทึกข้อมูลเรียบร้อย !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LoadtypeProduct();  
            }
            CN.Close();
        }

     

       
    }
}