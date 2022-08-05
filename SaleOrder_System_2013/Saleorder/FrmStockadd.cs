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
    public partial class FrmStockadd : Form
    {
        public FrmStockadd()
        {
            InitializeComponent();
        }

        int idbranch = 0; int idsubpro = 0; int idcount = 0;
        DataSet ds = new DataSet(); DataSet dssearch = new DataSet(); string id = "0";
        DataSet ds1 = new DataSet(); DataSet dssearch1 = new DataSet();

        private void btnserchpro_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            Frmserch fs = new Frmserch();
            fs.sname = "ssubpro";
            fs.ShowDialog();
            id = fs.returnid;

            if (id != "0")
            {
                string sql = "select * from vsupproduct where idsuppro='" + id + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    idsubpro = Convert.ToInt16(DR1["idsuppro"].ToString().Trim());
                    txtnamepro.Text = DR1["namesup"].ToString().Trim();
                }
                DR1.Close();
            }
            CN.Close();
        }

        private void CheckCharAutoID()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            CheckIdbranch();
            string sql = "select count(idbranch) as checks from tbatbranch where idbranch ='" + idbranch + "'";
            SqlCommand CM1 = new SqlCommand(sql, CN);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                idcount = Convert.ToInt16(DR1["checks"].ToString().Trim());
            }
            DR1.Close();
            CN.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            CheckCharAutoID();
            CheckIdbranch();

            if (idbranch != 0 && idsubpro != 0 && txtton.Text != "")
            {
                if (idcount != 0)
                {
                    string sql1 = "insert into tbbranchinstock(idbranch,idsuppro,unitstock,remark) values(" + idbranch + ",'" + idsubpro + "'," + weigthkk + ",'" + txtremark.Text + "')";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();

                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSuproduct();
                }
                else
                { MessageBox.Show("ไม่สามารถบันทึกได้เนื่องจากคุณยังไม่ได้สร้างรหัสอักษรนำสาขา !", "ผิดพลาด !", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            CN.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadBranch()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql1 = "select idbranch,bname from vautokeychar ";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(ds1, "loadbranch");
            cbbranch.DataSource = ds1.Tables["loadbranch"];
            cbbranch.DisplayMember = "bname";
            cbbranch.ValueMember = "idbranch";
            CN.Close();
        }     

        private void FrmStockadd_Load(object sender, EventArgs e)
        {            
            LoadBranch();
            DisableAll();
        }

        private void LoadSuproduct()
        {
            try
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();
                ds.Clear(); dssearch.Clear();
                dtgstock.DataSource = dssearch;
                string sql = "select * from vproductstockbranch where idbranch=" + cbbranch.SelectedValue.ToString().Trim() + " order by namesup";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "vsuppro");
                dtgstock.DataSource = ds.Tables["vsuppro"];
                CN.Close();
            }
            catch { }
        }

        private void DisableAll()
        {
            btnaddtype.Enabled = false;
            btnsave.Enabled = false;
            btnserchpro.Enabled = false;           
            btnaddtype.Enabled = false;
            txtton.Enabled = false;
            txtremark.Enabled = false;
        }

        private void EnableAll()
        {
            btnaddtype.Enabled = true;
            btnsave.Enabled = true;
            btnserchpro.Enabled = true;          
            btnaddtype.Enabled = true;
            txtton.Enabled = true;
            txtremark.Enabled = true;
        }

        private void btnaddtype_Click(object sender, EventArgs e)
        {
            Frmtypeproduct ftpd = new Frmtypeproduct();
            ftpd.ShowDialog();            
        }

        private void cbnew_CheckedChanged(object sender, EventArgs e)
        {
            if (cbnew.Checked == true)
            { EnableAll(); }
            else
            { DisableAll(); }
        }

        double sweigth; double weigthkk = 0;
        private void txtweigth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 13 && e.KeyChar != 8 && e.KeyChar == 47)
            {
                MessageBox.Show("ป้อนได้แต่ตัวเลขเท่านั้น", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true; txtton.Clear();
            }
            else if (e.KeyChar == 13)
            {
                if (txtton.Text != "")
                {
                    sweigth = Convert.ToDouble(txtton.Text);
                    if (sweigth == 0)
                    {
                        MessageBox.Show("ค่าห้ามเป็นศูนย์ค่ะ", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtton.Clear(); txtton.Focus();
                    }
                    weigthkk = 1000 * Convert.ToDouble(sweigth);
                    txtton.Text = sweigth.ToString("#,###.##0");
                    txtkk.Text = "/ " + weigthkk.ToString("#,###") + " กิโลกรัม";  
                    txtremark.Focus();
                }
            }
        }

        private void cbbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSuproduct();
        }

        private void CheckIdbranch()
        {
            idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
        }

        private void dtgstock_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idsubpro = Convert.ToInt16(dtgstock[0, e.RowIndex].Value.ToString());
            txtnamepro.Text = dtgstock[2, e.RowIndex].Value.ToString();
            txtton.Text = dtgstock[3, e.RowIndex].Value.ToString();
            txtton.Enabled = true;
        }

        private void tbnaddjust_Click(object sender, EventArgs e)
        {
            if (idsubpro != 0 && txtton.Text != "")
            {
                DialogResult answer;
                answer = MessageBox.Show("คุณต้องการปรับปรุ่นสต็อกใช่หรือไม่ !", "กรุณายืนยัน !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (answer == DialogResult.OK)
                {
                    SqlConnection CN = new SqlConnection();
                    CN.ConnectionString = Program.urldb;
                    CN.Open();
                    string sql4 = "update tbbranchinstock set unitstock = " + weigthkk + " where idbistock ='" + idsubpro + "'";
                    SqlCommand CM4 = new SqlCommand(sql4, CN);
                    CM4.ExecuteNonQuery();
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSuproduct();
                    CN.Close();
                }
            }
        }

        
    }
}