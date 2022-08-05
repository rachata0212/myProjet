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
    public partial class FrmPurpaysetting : Form
    {
        public FrmPurpaysetting()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet();
        DataSet dscb = new DataSet();
        string idsuppliers;
        int idareapur;
        int idfrom;
        int idto;
        int erowindex;
        int ecolumn;
        int idstatus =0 ;       

        private void cbmenu_SelectedIndexChanged(object sender, EventArgs e)
        {      
            LoadDataCB();
        }

        private void LoadDataCB()
        { 
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); ds.Clear();
                     

//            ราคาซื้อปาล์ม
//ราคาขนส่ง
//เงินมัดจำ
            if (cbmenu.SelectedIndex == 0)
            {
                ds.Clear(); dscb.Clear();
                string sql2 = "select *  from vpurprice ORDER BY idpricepur ";
                SqlDataAdapter da = new SqlDataAdapter(sql2, CN);
                da.Fill(ds, "pricepur");
                dtgpriceplam.DataSource = ds.Tables["pricepur"];
                dtgpriceplam.BringToFront(); dtgpriceplam.Visible = true;
                dtgpriceplam.Dock = DockStyle.Fill;

                for (int i = 0; i < dtgpriceplam.RowCount; i++)
                {
                    try
                    {

                        if (Convert.ToDecimal(dtgpriceplam[8, i].Value.ToString().Trim()) < 50000)
                        {
                            dtgpriceplam.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                        }
                    }
                    catch { }
                }
                

                //SELECT idbranch,(comsup +' จ. '+ provice) AS NameSup FROM vpurchase
                string sql1 = "select DISTINCT idBsup,(NBsup +' จ.'+  ProviceCpur) AS NameSup from vpurprice";                
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                da1.Fill(dscb, "dscb");
                cbocompany.DataSource = dscb.Tables["dscb"];
                cbocompany.DisplayMember = "NameSup";
                cbocompany.ValueMember = "idBsup";

            }
            if (cbmenu.SelectedIndex == 1)
            {
                string sql2 = "select *  from vpricetran ORDER BY idpaytran";
                SqlDataAdapter da = new SqlDataAdapter(sql2, CN);
                da.Fill(ds, "pricetran");
                dtgpricetran.DataSource = ds.Tables["pricetran"];
                dtgpricetran.BringToFront(); dtgpricetran.Visible = true;
                dtgpricetran.Dock = DockStyle.Fill;
            }            
        }
           

        private void FrmPurpaysetting_Load(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
           
        private void dtgpriceplam_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ecolumn = e.ColumnIndex;

            if (e.ColumnIndex == 2)
            {
                Frmserch fs = new Frmserch();
                fs.sname = "svbranch";
                fs.ShowDialog();

                if (fs.returnid.Trim() != "0")
                {
                    idsuppliers = fs.returnid.Trim();
                    Searchsuppliers();
                    btnsave.ForeColor = Color.Red; btnsave.Text = "Save";
                }
            }

            if (e.ColumnIndex == 5)
            {
                Frmserch fs = new Frmserch();
                fs.sname = "spurcom";
                fs.ShowDialog();

                if (fs.returnid.Trim() != "0")
                {
                    idsuppliers = fs.returnid.Trim();
                    SearchPurchase();
                    btnsave.ForeColor = Color.Red; btnsave.Text = "Save";
                }
            }

            if (e.ColumnIndex == 7)//ราคา
            {
                btnsave.ForeColor = Color.Red; btnsave.Text = "Save";
                dtgpriceplam[9, erowindex].Value = DateTime.Now.ToShortDateString();

                if (dtgpriceplam.AllowUserToAddRows == false)
                { idstatus = 1; }
            }

            if (e.ColumnIndex == 8)//เงินมัดจำ
            {
                btnsave.ForeColor = Color.Red; btnsave.Text = "Save";
                if (dtgpriceplam.AllowUserToAddRows == false)
                { idstatus = 1; }
            }

            if (e.ColumnIndex == 11)//เลือกโซน
            {
                Frmserch fs = new Frmserch();
                fs.sname = "sareapurchase";
                fs.ShowDialog();

                if (fs.returnid.Trim() != "0")
                {
                    idareapur = Convert.ToInt16(fs.returnid.Trim());
                    SearchAreaPur();
                    btnsave.ForeColor = Color.Red; btnsave.Text = "Save";
                }
                if (dtgpriceplam.AllowUserToAddRows == false)
                { idstatus = 1; }
            }
        }

        private void Searchsuppliers()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (idsuppliers != "")
            {

                string sql = "select idbranch,cname,provice from vbranch where idbranch=" + idsuppliers + "";              
                
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();                

                DR1.Read();
                {
                    if (cbmenu.SelectedIndex == 0)
                    {
                        //dtgpriceplam[0, erowindex].Value = "รหัสอัตโนมัติ";
                        dtgpriceplam[1, erowindex].Value = DR1["idbranch"].ToString();
                        dtgpriceplam[2, erowindex].Value = DR1["cname"].ToString();
                        dtgpriceplam[3, erowindex].Value = DR1["provice"].ToString();  
                    }
                    if (cbmenu.SelectedIndex == 1 && ecolumn == 1)
                    {
                        idfrom =Convert.ToInt16(idsuppliers);
                        //dtgpricetran[0, erowindex].Value = "รหัสอัตโนมัติ";
                        dtgpricetran[1, erowindex].Value = DR1["cname"].ToString();
                        dtgpricetran[2, erowindex].Value = DR1["provice"].ToString();
                    }

                    if (cbmenu.SelectedIndex == 1 && ecolumn == 3)
                    {
                        idto = Convert.ToInt16(idsuppliers);
                        dtgpricetran[3, erowindex].Value = DR1["cname"].ToString();
                        dtgpricetran[4, erowindex].Value = DR1["provice"].ToString();
                    }
                }
                DR1.Close();             
            }
            CN.Close();
        }

        private void SearchPurchase()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (idsuppliers != "")
            {

                string sql = "select idcom,cname,provice from vcompany where idcom='" + idsuppliers + "'";

                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    if (cbmenu.SelectedIndex == 0)
                    {

                        dtgpriceplam[4, erowindex].Value = DR1["idcom"].ToString();
                        dtgpriceplam[5, erowindex].Value = DR1["cname"].ToString();
                        dtgpriceplam[6, erowindex].Value = DR1["provice"].ToString(); 
                    }                 
                }
                DR1.Close();
            }

            CN.Close();
        }

        private void SearchAreaPur()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (idsuppliers != "")
            {
                string sql = "select * from tbareapriceplam where idareaprice=" + idareapur + "";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    dtgpriceplam[11, erowindex].Value = DR1["areaname"].ToString(); 
                }
                DR1.Close();
            }

            CN.Close();
        }

        private void dtgpriceplam_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            erowindex = e.RowIndex;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (cbmenu.SelectedIndex == 0)//save pricplam
            {
                if (dtgpriceplam.AllowUserToAddRows == false && idstatus == 0)
                {
                    dtgpriceplam.AllowUserToAddRows = true;
                    btnsave.Text = "Save"; btnsave.ForeColor = Color.Red;
                }
                else if (dtgpriceplam.AllowUserToAddRows == true)
                {
                    Savetodata(); btnsave.Text = "* New"; btnsave.ForeColor = Color.LightGreen;
                }

                else if (idstatus == 1)//update
                {
                    Updatetodata();
                    btnsave.Text = "* New"; btnsave.ForeColor = Color.LightGreen; idstatus = 0;
                }
            }

            if (cbmenu.SelectedIndex == 1)//save pricetran
            {
                if (dtgpricetran.AllowUserToAddRows == false && idstatus == 0)
                {
                    dtgpricetran.AllowUserToAddRows = true;
                    btnsave.Text = "Save"; btnsave.ForeColor = Color.Red;
                }
                else if (dtgpricetran.AllowUserToAddRows == true)
                { Savetodata(); btnsave.Text = "* New"; btnsave.ForeColor = Color.LightGreen; }

                else if (idstatus == 1)//update
                {
                    Updatetodata();
                    btnsave.Text = "* New"; btnsave.ForeColor = Color.LightGreen; idstatus = 0;
                }
            }
        }

        private void Savetodata()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            try
            {

                if (cbmenu.SelectedIndex == 0)
                {
                    string sql = "insert into tbpricepur (idbranchSup,idcomPur,pricepur,quatadicount,uptodate,rfspo,idareaprice) values (" + dtgpriceplam[1, erowindex].Value.ToString().Trim() + ",'" + dtgpriceplam[4, erowindex].Value.ToString().Trim() + "'," + dtgpriceplam[7, erowindex].Value.ToString().Trim() + "," + dtgpriceplam[8, erowindex].Value.ToString().Trim() + ",'" + string.Format("{0:mm/dd/yyyy}", DateTime.Now) + "','" + dtgpriceplam[10, erowindex].Value.ToString().Trim() + "'," + idareapur + ")";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();
                    MessageBox.Show("บันทึกข้อมูลสำเร็จ", "บันทึก !");
                    LoadDataCB(); dtgpriceplam.AllowUserToAddRows = false;
                }

                if (cbmenu.SelectedIndex == 1)
                {
                    string sql = "insert into tbpaytransport (idstart,idend,pricetran,weigthaccept) values (" + idfrom + "," + idto + ",'" + dtgpricetran[5, erowindex].Value.ToString().Trim() + "','" + dtgpricetran[6, erowindex].Value.ToString().Trim() + "')";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();
                    MessageBox.Show("บันทึกข้อมูลสำเร็จ", "บันทึก !");
                    LoadDataCB(); dtgpricetran.AllowUserToAddRows = false;
                }

                CN.Close();
            }
            catch { MessageBox.Show("ข้อมูลไม่ครบถ้วน กรุณาตรวจสอบอีกครั้ง","ผิดพลาด !"); }
        }

        private void Updatetodata()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            try
            {
                string sql = "";
                if (cbmenu.SelectedIndex == 0)
                {
                    if (ecolumn == 7)//update price
                    {
                        sql = "update tbpricepur set pricepur=" + dtgpriceplam[7, erowindex].Value.ToString().Trim() + " Where idpricepur= '" + dtgpriceplam[0, erowindex].Value.ToString().Trim() + "'";
                    }

                    //if (ecolumn == 8)//updatae quota
                    //{
                    //    sql = "update tbpricepur set quatadicount=" + dtgpriceplam[8, erowindex].Value.ToString().Trim() + " Where idpricepur= '" + dtgpriceplam[0, erowindex].Value.ToString().Trim() + "'";
                    //}

                    if (ecolumn == 10)//update zone
                    {
                        sql = "update tbpricepur set idareaprice=" + idareapur + " Where idpricepur= '" + dtgpriceplam[10, erowindex].Value.ToString().Trim() + "'";
                    }                    

                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();
                    MessageBox.Show("ปรับปรุงข้อมูลสำเร็จ", "บันทึก !");
                    LoadDataCB();
                }

                if (cbmenu.SelectedIndex == 1)
                {
                    if (ecolumn == 5)
                    {
                        sql = "update tbpaytransport set pricetran=" + dtgpricetran[5, erowindex].Value.ToString().Trim() + " Where idpaytran= " + dtgpricetran[0, erowindex].Value.ToString().Trim() + "";
                    }
                    if (ecolumn == 6)
                    {
                        sql = "update tbpaytransport set weigthaccept=" + dtgpricetran[6, erowindex].Value.ToString().Trim() + " Where idpaytran= " + dtgpricetran[0, erowindex].Value.ToString().Trim() + "";
                    }

                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();
                    MessageBox.Show("ปรับปรุงข้อมูลสำเร็จ", "บันทึก !");
                    LoadDataCB();
                }

                CN.Close();
            }
            catch { MessageBox.Show("ข้อมูลไม่ครบถ้วน กรุณาตรวจสอบอีกครั้ง", "ผิดพลาด !"); }
        }

        private void dtgpricetran_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            erowindex = e.RowIndex;
        }

        private void dtgpricetran_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ecolumn = e.ColumnIndex;

            if (e.ColumnIndex == 1)
            {
                Frmserch fs = new Frmserch();
                fs.sname = "svbranch";
                fs.ShowDialog();

                if (fs.returnid.Trim() != "0")
                {
                    idsuppliers = fs.returnid.Trim();
                    ecolumn = e.ColumnIndex; Searchsuppliers();
                    btnsave.ForeColor = Color.Red; btnsave.Text = "Save";
                }
            }
            if (e.ColumnIndex == 3)
            {
                Frmserch fs = new Frmserch();
                fs.sname = "svbranch";
                fs.ShowDialog();
                
                if (fs.returnid.Trim() != "0")
                {
                    idsuppliers = fs.returnid.Trim();
                    ecolumn = e.ColumnIndex; Searchsuppliers();
                    btnsave.ForeColor = Color.Red; btnsave.Text = "Save";
                }
            }
            if (e.ColumnIndex == 5)
            {
                btnsave.ForeColor = Color.Red; btnsave.Text = "Save";

                if (dtgpricetran.AllowUserToAddRows == false)
                { idstatus = 1; }
            }

            if (e.ColumnIndex == 6)
            {
                btnsave.ForeColor = Color.Red; btnsave.Text = "Save";

                if (dtgpricetran.AllowUserToAddRows == false)
                { idstatus = 1; }
            }
        }

        private void cbocompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open(); ds.Clear();
                string sql2 = "select *  from vpurprice where idBsup =" + cbocompany.SelectedValue.ToString() + " ORDER BY idpricepur ";
                SqlDataAdapter da = new SqlDataAdapter(sql2, CN);
                da.Fill(ds, "pricepur");
                dtgpriceplam.DataSource = ds.Tables["pricepur"];
            }
            catch { }
        }
               

    }
}
