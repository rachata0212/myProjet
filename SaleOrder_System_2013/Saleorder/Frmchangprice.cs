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
    public partial class Frmchangprice : Form
    {
        public Frmchangprice()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int idpro = 0; string chagedate = "";
        int idhistorycus = 0;
        string refidchage = "";
        decimal priceold = 0;
        decimal pricenew = 0;

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string date = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string sumdate = month + "/" + date + "/" + year;
            
             //insert in history
            string sql1 = "insert into tbhischangdata(datehischang,oldnamechange,newnamechage,remarkhischang,idtypechange,idempapprove,idstatusqua,idhistorycus) values('" + sumdate + "','" + txtoldprice.Text.Trim() + "','" + txtnewprice.Text.Trim() + "','เปลี่ยนแปลงราคาขาย',12,'" + Program.empID + "',16," + idhistorycus + ")";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            CM1.ExecuteNonQuery();
            MessageBox.Show("ข้อมูลทำการปรับปรุงแล้ว ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CN.Close();
            this.Close();
        }

        private void btnserchcus_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            //Frmcomquatation fcomqtt = new Frmcomquatation();
            //fcomqtt.idsearch = 2;
            //fcomqtt.ShowDialog();
            string idqua="";

            //if (fcomqtt.idcom != 0)
            //{
            //    //search address contact
            //    string sql1 = "select idqua from tbaddresscompany where idaddress='" + fcomqtt.idcom + "' and idtypeaddress = 2";
            //    SqlCommand CM1 = new SqlCommand(sql1, CN);
            //    SqlDataReader DR1 = CM1.ExecuteReader();

            //    DR1.Read();
            //    { idqua = DR1["idqua"].ToString().Trim(); }
            //    DR1.Close();
            //}

            string sql3 = "select * from vchageprice where idqua='" + idqua + "'";
            SqlCommand CM3 = new SqlCommand(sql3, CN);
            SqlDataReader DR3 = CM3.ExecuteReader();

            DR3.Read();
            {
                idhistorycus = Convert.ToInt32(DR3["refidchage"].ToString().Trim());
                chagedate = DR3["changdate"].ToString().Trim();
                txtcomname.Text = DR3["namecus"].ToString().Trim();
                txtoldprice.Text = DR3["changprice"].ToString().Trim();
                txtoldremark.Text = DR3["changremark"].ToString().Trim() + " วันที่เปลี่ยนแปลงครั้งล่าสุด " + chagedate;
                refidchage = DR3["refidchage"].ToString().Trim();
                idpro=Convert.ToInt16(DR3["idpro"].ToString().Trim());  
            }
            DR3.Close();

            string sql2 = "select * from tbproduct where idpro=" + idpro + "";
            SqlCommand CM2 = new SqlCommand(sql2, CN);
            SqlDataReader DR2 = CM2.ExecuteReader();

            DR2.Read();
            {                
                txtproname.Text = DR2["proname"].ToString().Trim();                
            }
            DR2.Close();
            
            priceold = Convert.ToDecimal(txtoldprice.Text.Trim());
            CN.Close();
            }

        private void txtnewprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 13 && e.KeyChar != 8 && e.KeyChar != 46)
            {
                MessageBox.Show("ป้อนได้แต่ตัวเลขเท่านั้น", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
            else if (e.KeyChar == 13)
            {
                if (txtnewprice.Text != "")
                {
                    pricenew = Convert.ToDecimal(txtnewprice.Text);
                    if (pricenew == 0)
                    {
                        MessageBox.Show("ค่าห้ามเป็นศูนย์ค่ะ", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtnewprice.Focus();
                    }
                    //decimal weigthbf = Convert.ToInt32(txtweigthkk.Text);
                    txtnewprice.Text = pricenew.ToString("##.##");                   
                }
            }
        }

        private void Frmchangprice_Load(object sender, EventArgs e)
        {
            txtdate.Text = DateTime.Now.ToShortDateString();
        }
    }
}