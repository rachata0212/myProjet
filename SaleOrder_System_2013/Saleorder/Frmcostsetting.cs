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
    public partial class Frmcostsetting : Form
    {
        public Frmcostsetting()
        {
            InitializeComponent();
        }

        int idcostrate = 0;
        string idcomstd = "";
        string idcomed = "";
        int idselect = 0;
        double kilomete = 0;
        public int idedit = 0;
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet dssearch1 = new DataSet();

        private void btnstd_Click(object sender, EventArgs e)
        {
            Frmserch fss = new Frmserch();
            fss.sname = "scomcostrate";
            fss.ShowDialog();
            idedit = 0;
            if (fss.returnid.Trim() != "0")
            {
                idselect = 1;
                idcomstd = fss.returnid;
                Searchcompany();
                btned.Enabled = true;
                btned.Focus();
                btnsaveedit.Enabled = true;
            }
        }

        private void btned_Click(object sender, EventArgs e)
        {
            Frmserch fss = new Frmserch();
            fss.sname = "scomcostrate";
            fss.ShowDialog();
            if (fss.returnid.Trim() != "0")
            {
                idselect = 2;
                idcomed = fss.returnid;
                Searchcompany();               
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsaveedit_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); string sql = ""; 

            if (idedit == 0 && idcomed !="")//insert
            {
                int insertyes = 0;
                for (int i = 0; i < dtgviewsdata.RowCount; i++)
                {
                    if (idcomstd == dtgviewsdata[1, i].Value.ToString().Trim() && idcomed == dtgviewsdata[3, i].Value.ToString().Trim()) { insertyes = 1; }
                }

                if (insertyes == 0)
                {
                    sql = "insert into tbcostrate(idfrom,idto,km) values ('" + idcomstd + "','" + idcomed + "'," + txtkilomete.Text.Trim() + ")";
                }
                else
                { MessageBox.Show("คุณบันทึกข้อมูลซ้ำ", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

           else if (idedit == 1 && idcomed != "")//update
            {
                sql = "update tbcostrate set km = " + txtkilomete.Text.Trim() + ",idfrom = '" + idcomstd + "' ,idto = '" + idcomed + "' Where idcostrate = " + idcostrate + "";
            }

            if (sql != "")
            {
                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();
                MessageBox.Show("บันทึกข้อมูลประสบความสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                idcomed = "";
                txted.Clear();
                txtkilomete.Clear();
                LoadCostrate();                
                btnstd.Focus();
            }
            CN.Close();
        }  

        private void Frmcostsetting_Load(object sender, EventArgs e)
        {
            LoadCostrate(); LoadSearchcom();
        }
                

        private void LoadCostrate()
        {           
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();
                ds2.Clear(); dssearch1.Clear();
                dtgviewsdata.DataSource = dssearch1;
                string sql2 = "SELECT idcostrate as IDNO, idfrom as IDFROM,comfrom as CompanyFrom,branchfrom as Branch, idto as IDTO,comto as CompanyTO,km as Distance FROM vcostrate ";
                SqlDataAdapter da2 = new SqlDataAdapter(sql2, CN);
                da2.Fill(ds2, "viewdata");
                dtgviewsdata.DataSource = ds2.Tables["viewdata"];
                lblcount.Text = "จำนวน " + dtgviewsdata.RowCount.ToString() + " ข้อมูล";
                idedit = 0;
                CN.Close();          
        }

        private void Searchcompany()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); string sql = ""; btnsaveedit.Enabled = true;

            if (idcomstd != "" || idcomed !="")
            {
                if (idselect == 1)
                { sql = "select cname,bname from vcompany where idcom ='" + idcomstd + "'"; }
                if (idselect == 2)
                { sql = "select cname,bname from vcompany where idcom ='" + idcomed + "'"; }

                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();
               
                DR1.Read();
                {
                    if (idselect == 1)
                    { txtstd.Text = DR1["bname"].ToString().Trim() + " , " + DR1["cname"].ToString().Trim(); }
                    if (idselect == 2)
                    { txted.Text = DR1["bname"].ToString().Trim() + " , " + DR1["cname"].ToString().Trim(); }

                }
                DR1.Close();

                if (idselect == 1)
                //DataGridView1.Item(ColumnIndex, RowIndex).Style.BackColor = Color
                 //dataGridView1.Rows[3].DefaultCellStyle.BackColor = Color.Green;
                {
                    for (int i = 0; i < dtgviewsdata.RowCount; i++)
                    {
                        dtgviewsdata.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                }

                if (idselect == 2)
                {
                    for (int i = 0; i < dtgviewsdata.RowCount; i++)
                    {                      
                        if (idcomstd == dtgviewsdata[5, i].Value.ToString().Trim() && idcomed == dtgviewsdata[6, i].Value.ToString().Trim())
                        {                            
                            dtgviewsdata.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            btnsaveedit.Enabled = false;
                        }
                    }
                }
            }
            CN.Close();
        }

        private void txtkilomete_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtkilomete_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 13 && e.KeyChar != 8 && e.KeyChar == 47)
            {
                MessageBox.Show("ป้อนได้แต่ตัวเลขเท่านั้น", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
            else if (e.KeyChar == 13)
            {
                if (txtkilomete.Text != "")
                {
                    kilomete = Convert.ToDouble(txtkilomete.Text);
                    if (kilomete == 0)
                    {
                        MessageBox.Show("ค่าห้ามเป็นศูนย์ค่ะ", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //decimal weigthbf = Convert.ToInt32(txtweigthkk.Text);
                    txtkilomete.Text = kilomete.ToString("##.##");
                }
            }
        }

        private void dtgviewsdata_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                idcostrate = Convert.ToInt16(dtgviewsdata[0, e.RowIndex].Value.ToString().Trim());
                txtstd.Text = dtgviewsdata[2, e.RowIndex].Value.ToString().Trim();
                txted.Text = dtgviewsdata[5, e.RowIndex].Value.ToString().Trim();
                txtkilomete.Text = dtgviewsdata[6, e.RowIndex].Value.ToString().Trim();
                idcomstd = dtgviewsdata[1, e.RowIndex].Value.ToString().Trim();
                idcomed = dtgviewsdata[3, e.RowIndex].Value.ToString().Trim();
                btnsaveedit.Enabled = true;
                cbnew.Checked = false;
                idedit = 1;
            }
            catch { }
        }

        private void cbnew_CheckedChanged(object sender, EventArgs e)
        {
            if (cbnew.Checked == true)
            {
                idcomstd = "";
                idcomed = "";
                txtstd.Clear();
                txted.Clear();
                txtkilomete.Clear();
                txtkilomete.ReadOnly = false;                
                idedit = 0;
                btned.Enabled = false;
                for (int i = 0; i < dtgviewsdata.RowCount; i++)
                {
                    dtgviewsdata.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
            else
            {
                btned.Enabled = true; txtkilomete.ReadOnly = true;
            }
        }               

        private void cbtruckrate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtruckrate.Checked == true)
            {
                LoadTypetruckrate();
                groupBox2.Visible = true;
            }
            else { groupBox2.Visible = false; }
        }

        private void LoadTypetruckrate()
        {
            //if (cbtypetruckrate.SelectedIndex != -1 && cbtypetruckrate.SelectedValue.ToString() != "System.Data.DataRowView")
            //{
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();
                string sql1 = "select DISTINCT idcargroup,cargroupname from tbcargroup ";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                da1.Fill(ds, "typeratess");
                cbtypetruckrate.DataSource = ds.Tables["typeratess"];
                cbtypetruckrate.DisplayMember = "cargroupname";
                cbtypetruckrate.ValueMember = "idcargroup";              
                CN.Close();                
            //}
        }

        private void cbtypetruckrate_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (cbtypetruckrate.SelectedIndex != -1 && cbtypetruckrate.SelectedValue.ToString() != "System.Data.DataRowView")
           {
               Loadgridtypetruckrate();             
            }
           
        }

        private void Loadgridtypetruckrate()
        {
            int x = 1;
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            ds2.Clear(); dssearch1.Clear();
            dtgtruckrate.DataSource = dssearch1;
            string sql2 = "SELECT * From  vcostpriceselect where idcargroup = " + cbtypetruckrate.SelectedValue.ToString() + " order by ratecostkm";
            SqlDataAdapter da2 = new SqlDataAdapter(sql2, CN);
            da2.Fill(ds2, "vtypetruck");
            dtgtruckrate.DataSource = ds2.Tables["vtypetruck"];
            CN.Close();
        }

        private void dtgtruckrate_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql = "";
            if (e.ColumnIndex == 1)//update ratekm
            {
                sql = "update tbpricecost set ratecostkm = " + dtgtruckrate[1, e.RowIndex].Value.ToString() + " Where idratecost = " + dtgtruckrate[0, e.RowIndex].Value.ToString() + " AND idcargroup = " + cbtypetruckrate.SelectedValue.ToString() + "  ";
            }           

            if (e.ColumnIndex == 2)//update price
            {
                sql = "update tbpricecost set price = " + dtgtruckrate[2, e.RowIndex].Value.ToString() + " Where idratecost = " + dtgtruckrate[0, e.RowIndex].Value.ToString() + " AND idcargroup = " + cbtypetruckrate.SelectedValue.ToString() + "  ";

            }

            if (sql != "")
            {
                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();
                CN.Close();
                Loadgridtypetruckrate();
            }
        }

        private void dtgviewsdata_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                try
                {
                    int km=Convert.ToInt16(dtgviewsdata[6, e.RowIndex].Value.ToString());
                    SqlConnection CN = new SqlConnection();
                    CN.ConnectionString = Program.urldb;
                    CN.Open();
                    string sql = "update tbcostrate set km = " + dtgviewsdata[6, e.RowIndex].Value.ToString() + " Where idcostrate = " + idcostrate + "";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();
                    CN.Close();
                }
                catch { MessageBox.Show("ต้องเป็นตัวเลขเท่านั้น", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void cbfrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Searchcom();
        }

        private void Searchcom()
        {
            if (cbfrom.SelectedIndex != -1 && cbfrom.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();
                ds2.Clear(); dssearch1.Clear();
                dtgviewsdata.DataSource = dssearch1;
                string sql2 = "SELECT idcostrate as IDNO, idfrom as IDFROM,comfrom as CompanyFrom, idto as IDTO,comto as CompanyTO,km as Distance FROM vcostrate where idfrom ='" + cbfrom.SelectedValue.ToString() + "' ";
                SqlDataAdapter da2 = new SqlDataAdapter(sql2, CN);
                da2.Fill(ds2, "viewdata");
                dtgviewsdata.DataSource = ds2.Tables["viewdata"];
                lblcount.Text = "จำนวน " + dtgviewsdata.RowCount.ToString() + " ข้อมูล";
                idedit = 0;
                CN.Close(); 
            }
        }

        private void LoadSearchcom()
        {           
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();
                string sql1 = "select DISTINCT idfrom,comfrom from vcostrate ";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                da1.Fill(ds, "searchcomfrom");
                cbfrom.DataSource = ds.Tables["searchcomfrom"];
                cbfrom.DisplayMember = "comfrom";
                cbfrom.ValueMember = "idfrom";
                CN.Close();            
        }

    }
}