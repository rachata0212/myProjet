using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;

namespace SaleOrder
{
    public partial class FrmSaleOrder : Form
    {
        public FrmSaleOrder()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int status = 0; 
        public string id = "0"; 
        public long idorder = 0; 
        string msnfrom = ""; 
        int idtypelog = 0;

        dtssaleorder dssearch = new dtssaleorder(); 
        DataSet ds = new DataSet(); 
        
        public int idstatus = 0;
        public int idedit = 0;
        public int add0rder = 0;
        public string idsorder = "";
        int idtypevat = 0;
        int idtimerecivecus = 0;
        string datelog = DateTime.Now.Day.ToString();
        string monthlog = DateTime.Now.Month.ToString();
        string yearlog = DateTime.Now.Year.ToString();

        private void FrmSaleOrder_Load(object sender, EventArgs e)
        {
            if (idstatus == 0)
            {   
                CreatIDSaleorder();
                txtlastsave.Text = Program.idsavelate;
                msnfrom = this.Name.ToString();
                idtypelog = 7;//open
                Savelogevent();
                Loadtimerecivecus();
                cbtimerecivecus.Text = "ไม่จำกัดเวลา";
            }
            if (idstatus == 1)
            {
                try
                { Loadupdate(); }

                catch (Exception ex)
                {
                    MessageBox.Show("Debug" + ex.Message, "พลิดพลาด !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }            
            }

            if (add0rder == 2)
            {
                CreatIDSaleorder();
                txtremark.Text = "Order เพิ่มเติม แยกพ่วงเป็นเดี่ยวจากเลขที่ขาย 1.2: " + id.ToString() ;
                txtidcar.Clear();
                txtnamecar.Clear();
                btnsale.Enabled = false;
                btnpro.Enabled = false;
                btnpur.Enabled = false;
                btnordersale.Enabled = false;
            }

            if (add0rder == 3)
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();
                string sql = "select * from vonholetruckin where idtran='" + id + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    txtidcomsale.Text = DR1["idcompur"].ToString().Trim();                  
                    txtidpro.Text = DR1["idpro"].ToString().Trim();
                    txtidcar.Text = DR1["idcar"].ToString().Trim();                   
                }
                DR1.Close();
                CN.Close();

                dtpicker.Enabled = false;
                dtpstdqa.Enabled = false;
                dtpeqa.Enabled = false;
                txtremark.Text = "Order เพิ่มเติม";
                txtremark.Enabled = false;
                btnordersale.Enabled = false;
                btnpro.Enabled = false;
                btncar.Enabled = false;

                Searchcomsale();                
                Searchcar();
                Searchproduct();
                Searchsale();                             
            }

            if (add0rder == 1)
            {
                txtremark.Text = "Order เพิ่มเติม";
            }

            btnordersale.Focus();
        }

        private void CreatIDSaleorder()
        {
            dtpicker.Text = DateTime.Now.ToShortDateString();

            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql = "select idorderauto,idorder from tborder ORDER BY idorderauto DESC";
            SqlCommand CM = new SqlCommand(sql, CN);
            SqlDataReader DR = CM.ExecuteReader();

            DR.Read();
            {
                idorder = Convert.ToInt32(DR["idorderauto"].ToString());
                txtidorder.Text = DR["idorder"].ToString();
                txtoldid.Text = DR["idorder"].ToString();
            }
            DR.Close();
            CN.Close();

            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            txtoldid.SelectionStart = 1;
            txtoldid.SelectionLength = 6;
            long daterun = Convert.ToInt64(txtoldid.SelectedText.ToString());//ตัดค่า 4 ปีเดือนวัน จากฐานข้อมูล

            txtidorder.SelectionStart = 7;
            txtidorder.SelectionLength = 9;
            int idrun = Convert.ToInt16(txtidorder.SelectedText.ToString());//ตัวลำดับที่ จากฐานข้อมูล
            string idcomplease = "S" + String.Format("{0:yy}", dt) + String.Format("{0:MM}", dt) + String.Format("{0:dd}", dt);
            long datenow = Convert.ToInt64(String.Format("{0:yy}", dt) + String.Format("{0:MM}", dt) + String.Format("{0:dd}", dt));

            if (datenow == daterun)
            {
                idrun++;
                txtidorder.Text = idcomplease + string.Format("{0:00}", idrun);
            }
            else
            {
                txtidorder.Text = idcomplease + "01";
            }
        } 

        private void Loadupdate()
        {
           
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql = "select * from tborder where idorder='" + id + "'";
            SqlCommand CM1 = new SqlCommand(sql, CN);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                txtidorder.Text = DR1["idorder"].ToString().Trim();
                dtpicker.Text = DR1["orderdate"].ToString().Trim();
                txtidcomsale.Text = DR1["idcomsup"].ToString().Trim();
                txtidpur.Text = DR1["idcomcus"].ToString().Trim();
                txtidpro.Text = DR1["idpro"].ToString().Trim();
                txtidcar.Text = DR1["idcar"].ToString().Trim();
                txtqano.Text = DR1["qano"].ToString().Trim();                
                dtpstdqa.Text = DR1["stdqa"].ToString().Trim();
                dtpeqa.Text = DR1["edqa"].ToString().Trim();
                txtremark.Text = DR1["remark1"].ToString().Trim();
                txtidsale.Text = DR1["rfsale"].ToString().Trim();
                idtypevat = Convert.ToInt16(DR1["idtypevat"].ToString().Trim());
                idtimerecivecus = Convert.ToInt16(DR1["idtimerecive"].ToString().Trim());
            }

            DR1.Close();
            CN.Close();

            Searchcomsale();
            Searchcomcus();
            Searchcar();
            Searchproduct();
            Searchsale();
            Loadtimerecivecus();
            Searchtimerecivecus();
            
        }

        private void Searchtimerecivecus()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (idtimerecivecus != 0)
            {
                string sql = "select * from tbtimerecivecus where idtimerecive='" + idtimerecivecus + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    cbtimerecivecus.Text = DR1["timeredetail"].ToString().Trim();
                }
                DR1.Close();
            }
            CN.Close();
        }

        private void Searchcomsale()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (txtidcomsale.Text != "")
            {
                string sql = "select * from vcompany where idcom='" + txtidcomsale.Text.Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    txtidcomsale.Text = DR1["idcom"].ToString().Trim();
                    txtnameordersale.Text = DR1["cname"].ToString().Trim();
                    txtaddressordersale.Text = DR1["baddress"].ToString().Trim() + " " + DR1["rd"].ToString().Trim() + " " + DR1["tumb"].ToString().Trim() + " " + DR1["country"].ToString().Trim() + " " + DR1["provice"].ToString().Trim() + " " + DR1["zipcode"].ToString().Trim();
                }
                DR1.Close();
            }
            CN.Close();
        }

        private void Searchcomcus()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (txtidpur.Text.Trim() != "")
            {
                string sql = "select * from vcompany where idcom='" + txtidpur.Text + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    txtidpur.Text = DR1["idcom"].ToString().Trim();
                    txtnamepur.Text = DR1["cname"].ToString().Trim();
                    txtaddresspur.Text = DR1["baddress"].ToString().Trim() + " " + DR1["rd"].ToString().Trim() + " " + DR1["tumb"].ToString().Trim() + " " + DR1["country"].ToString().Trim() + " " + DR1["provice"].ToString().Trim() + " " + DR1["zipcode"].ToString().Trim();
                }
                DR1.Close();
            }
            CN.Close();
        }

        private void Searchproduct()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (txtidpro.Text.Trim() != "")
            {
                string sql = "select * from tbproduct where idpro='" + txtidpro.Text + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    txtidpro.Text = DR1["idpro"].ToString().Trim();
                    txtnamepro.Text = DR1["proname"].ToString().Trim();
                }
                DR1.Close();
            }
            CN.Close();
        }

        private void Searchcar()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); int idok = 0;

            if (txtidcar.Text.Trim() != "")
            {
                string sql = "select * from vcar where idcar='" + txtidcar.Text + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();
                txtidcar.Text = id.ToString();

                DR1.Read();
                {
                    if (idstatus == 2)
                    {
                        if (DR1["idcar"].ToString().Trim() == "9" || DR1["idcar"].ToString().Trim() == "10" || DR1["idcar"].ToString().Trim() == "11")
                        {
                            txtidcar.Text = DR1["idcar"].ToString().Trim();
                            idok = 1;
                        }
                        else MessageBox.Show("คุณเลือกรถที่จะส่งผิดประเภทกรุณณาเลือกรถประเภทรถเดี่ยวเท่านั้น", "ผิดพลาด !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtidcar.Clear(); txtnamecar.Clear();
                    }
                    if (idok == 0)
                    {
                        txtidcar.Text = DR1["idcar"].ToString().Trim();
                        txtnamecar.Text = DR1["carname"].ToString().Trim();
                    }
                }
                DR1.Close();
            }
            CN.Close();
        }

        private void Searchsale()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (txtidsale.Text.Trim() != "")
            {
                string sql = "select * from vempsale where idemp='" + txtidsale.Text + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    txtidsale.Text = DR1["idemp"].ToString().Trim();
                    txtnamessale.Text = DR1["empname"].ToString().Trim();
                }
                DR1.Close();
            }
            CN.Close();
        }

        private void LoadiDvat()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            int count = 0;

            string sql1 = "select count(idcom) as counsum from vtypeComFSTCvat where idcom = '" + txtidcomsale.Text.Trim() + "' and idtypeordervat = 2";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            { count = Convert.ToInt16(DR1["counsum"].ToString()); }
            DR1.Close();

            if (count != 0)
            {
                string sql2 = "select idtypevat from vtypeComFSTCvat where idcom='" + txtidcomsale.Text.Trim() + "' AND idtypeordervat = 2 ";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();

                DR2.Read();
                { idtypevat = Convert.ToInt16(DR2["idtypevat"].ToString()); }
                DR2.Close();
            }
            CN.Close();
        }

        private void btnordersale_Click(object sender, EventArgs e)
        {
            Frmserch fs = new Frmserch();
            fs.sname = "spurcom";
            fs.ShowDialog();
            if (fs.returnid.Trim() != "0")
            {
                txtidcomsale.Text = fs.returnid.Trim();
                LoadiDvat();
                Searchcomsale();
                btnsale.Focus();
            }
        }

        private void btnsale_Click(object sender, EventArgs e)
        {  
            Frmserch fs = new Frmserch();
            fs.sname = "sempsale";
            fs.ShowDialog();
            if (fs.returnid.Trim() != "0")
            {
                txtidsale.Text = fs.returnid;
                Searchsale();
                txtqano.Focus();
            }
        }

        private void btnpur_Click(object sender, EventArgs e)
        { 
            Frmserch fs = new Frmserch();
            fs.sname = "scomcus";
            fs.ShowDialog();
            if (fs.returnid.Trim() != "0")
            {
                txtidpur.Text = fs.returnid;                
                Searchcomcus();
                btnpro.Focus();
            }
        }      

        private void btnpro_Click(object sender, EventArgs e)
        {
            Frmserch fs = new Frmserch();
            fs.sname = "spropur";
            fs.ShowDialog();
            if (fs.returnid.Trim() != "0")
            {
                txtidpro.Text = fs.returnid;
                Searchproduct();
                btncar.Focus();
            }
        }

        private void btncar_Click(object sender, EventArgs e)
        {  
            Frmserch fs = new Frmserch();
            fs.sname = "scar";
            fs.ShowDialog();
            if (fs.returnid.Trim() != "0")
            {
                txtidcar.Text = fs.returnid;
                Searchcar();
                btnsave.Focus();
            }
        }
         
        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string date = dtpicker.Value.Day.ToString();
            string month = dtpicker.Value.Month.ToString();
            string year = dtpicker.Value.Year.ToString();
            string sumdate = month + "/" + date + "/" + year;

            string dsday = dtpstdqa.Value.Day.ToString();
            string dsmonth = dtpstdqa.Value.Month.ToString();
            string dsyear = dtpstdqa.Value.Year.ToString();
            string dtsum = dsmonth + "/" + dsday + "/" + dsyear;

            string deday = dtpeqa.Value.Day.ToString();
            string demonth = dtpeqa.Value.Month.ToString();
            string deyear = dtpeqa.Value.Year.ToString();
            string desum = demonth + "/" + deday + "/" + deyear;

            string nowdate = DateTime.Now.Day.ToString();
            string nowmonth = DateTime.Now.Month.ToString();
            string nowyear = DateTime.Now.Year.ToString();
            string nowdatesum = nowmonth + "/" + nowdate + "/" + nowyear;
           
            DateTime now = DateTime.Now;

            if (idtypevat == 0)
            { idtypevat = 4; }


            if (idstatus == 0 || idstatus != 1 && add0rder == 0 || add0rder == 1 || add0rder == 2 || add0rder == 3)
            {
                if (add0rder == 0)
                {
                    if (txtidcar.Text != "" && txtidpro.Text != "" && txtidpur.Text != "" && txtidorder.Text != "")
                    {
                        for (int i = 0; i < Convert.ToInt16(cbounitorder.Text.Trim
                            ()); i++)
                        {
                            string sql1 = "insert into tborder(idorder,orderdate,ctdate,ctedtime,idcomsup,idcomcus,idpro,idcar,qano,stdqa,edqa,remark1,rfsale,idstatus,idtypevat,idtimerecive) values ('" + txtidorder.Text + "','" + sumdate + "','" + nowdatesum + "','" + string.Format("{0:HH:mm:ss}", DateTime.Now) + "','" + txtidcomsale.Text + "','" + txtidpur.Text + "'," + txtidpro.Text + "," + txtidcar.Text + ",'" + txtqano.Text + "','" + dtsum + "','" + desum + "','" + txtremark.Text + "','" + txtidsale.Text + "'," + 3 + "," + idtypevat + "," + cbtimerecivecus.SelectedValue.ToString() + ")";
                            SqlCommand CM = new SqlCommand(sql1, CN);
                            CM.ExecuteNonQuery();

                            CreatIDSaleorder();
                        }

                        MessageBox.Show("บันทึกข้อมูลจำนวน " + cbounitorder.Text + " รายการ ประสบความสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (add0rder == 1 || add0rder == 2 || add0rder == 3)
                {
                    for (int i = 0; i < Convert.ToInt16(cbounitorder.Text.Trim
                           ()); i++)
                    {
                        string sql2 = "insert into tborder(idorder,orderdate,ctdate,ctedtime,idcomsup,idcomcus,idpro,idcar,qano,stdqa,edqa,remark1,rfsale,idstatus,editstatus,idtypevat,idtimerecive) values ('" + txtidorder.Text + "','" + sumdate + "','" + nowdatesum + "','" + string.Format("{0:HH:mm:ss}", DateTime.Now) + "','" + txtidcomsale.Text + "','" + txtidpur.Text + "'," + txtidpro.Text + "," + txtidcar.Text + ",'" + txtqano.Text + "','" + dtsum + "','" + desum + "','" + txtremark.Text + "','" + txtidsale.Text + "'," + 3 + ",1," + idtypevat + "," + cbtimerecivecus.SelectedValue.ToString() + ")";
                        SqlCommand CM = new SqlCommand(sql2, CN);
                        CM.ExecuteNonQuery();
                        CreatIDSaleorder();
                    }

                    MessageBox.Show("บันทึกข้อมูลจำนวน " + cbounitorder.Text + " รายการ ประสบความสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                Program.idsavelate = txtidorder.Text;
                idstatus = 99;//บอกกลับว่า save ok แล้ว
                idsorder = txtidorder.Text.Trim();
            }

              if(idstatus==1)
                {
                    string sql = "update tborder set idcomsup='" + txtidcomsale.Text + "',idcomcus ='" + txtidpur.Text + "',idpro='" + txtidpro.Text + "',idcar='" + txtidcar.Text + "',orderdate='" + sumdate + "',ctdate='" + nowdatesum + "',ctedtime='" + string.Format("{0:HH:mm:ss}", DateTime.Now) + "',qano='" + txtqano.Text + "',stdqa='" + dtsum + "',edqa='" + desum + "',remark1='" + txtremark.Text + " [มีการแก้ไข Order]" + "',idtypevat=" + idtypevat + ",rfsale='" + txtidsale.Text + "',idtimerecive=" + cbtimerecivecus.SelectedValue.ToString() + " Where idorder= '" + txtidorder.Text + "'";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();
                    MessageBox.Show("ข้อมูลทำการปรับปรุงแล้ว ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);  
                }
                CN.Close();

                DialogResult answer;
                answer = MessageBox.Show("คุณต้องการทำรายการต่อหรือไม่ !", "กรุณายืนยัน !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (answer == DialogResult.OK)
                {
                    ClearAll();
                }
                if (answer == DialogResult.Cancel)
                { this.Close(); }
        }

        private void Savelogevent()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string selectdatelog = monthlog + "/" + datelog + "/" + yearlog;
            string sql1 = "insert into tblog(logname,datein,timein,idtypelog,idemp,remark) values('" + msnfrom + "','" + selectdatelog + "','" + DateTime.Now.ToLongTimeString() + "'," + idtypelog + ",'" + Program.empID + "','" + txtidorder.Text.Trim() + "')";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            CM1.ExecuteNonQuery();
            CN.Close();
        }

        private void ClearAll()
        {
            CreatIDSaleorder();
            txtaddressordersale.Clear();
            txtaddresspur.Clear();
            txtidcar.Clear();
            txtidcomsale.Clear();           
            txtidpro.Clear();
            txtidpur.Clear();
            txtidsale.Clear();          
            txtnamecar.Clear();
            txtnameordersale.Clear();
            txtnamepro.Clear();
            txtnamepur.Clear();
            txtnamessale.Clear();
            txtqano.Text = "-";
            txtremark.Text = "-";
            btnordersale.Focus();
        }

        private void FrmSaleOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            msnfrom = this.Name.ToString();
            idtypelog = 6;
            Savelogevent();
        }

        private void dtpicker_ValueChanged(object sender, EventArgs e)
        {
            //if (idstatus == 0)
            //{
            //    //ดึงค่าวันที่ปัจจุบัน
            //    DateTime dtnow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //    //ดึงค่าวันที่ที่ทำการส่งล่วงหน้า
            //    DateTime dtselect = new DateTime(dtpicker.Value.Year, dtpicker.Value.Month, dtpicker.Value.Day);

            //    string idcomplease = "S" + String.Format("{0:yy}", dtselect) + String.Format("{0:MM}", dtselect) + String.Format("{0:dd}", dtselect);

            //    long dateselect = Convert.ToInt64(String.Format("{0:yy}", dtselect) + String.Format("{0:MM}", dtselect) + String.Format("{0:dd}", dtselect));
            //    long datenow = Convert.ToInt64(String.Format("{0:yy}", dtnow) + String.Format("{0:MM}", dtnow) + String.Format("{0:dd}", dtnow));

            //    if (dateselect > datenow)//ทำการเทียบค่าวันที่ ต้องมากกว่าหรือเท่ากับเท่านั้น
            //    {
            //        // txtidorder.Text = idcomplease + "01";                  
            //    }
            //    else if (dateselect == datenow)
            //    {
            //        //SqlConnection CN = new SqlConnection();
            //        //CN.ConnectionString = Program.urldb;
            //        //CN.Open();
            //        //string sql = "select idorderauto,idorder from tborder ORDER BY idorderauto DESC";
            //        //SqlCommand CM = new SqlCommand(sql, CN);
            //        //SqlDataReader DR = CM.ExecuteReader();

            //        //DR.Read();
            //        //{
            //        //    idorder = Convert.ToInt16(DR["idorderauto"].ToString());
            //        //    txtidorder.Text = DR["idorder"].ToString();
            //        //    txtoldid.Text = DR["idorder"].ToString();
            //        //}
            //        //DR.Close();

            //        //txtoldid.SelectionStart = 1;
            //        //txtoldid.SelectionLength = 6;
            //        //long daterun = Convert.ToInt64(txtoldid.SelectedText.ToString());//ตัดค่า 4 ปีเดือนวัน จากฐานข้อมูล

            //        //txtidorder.SelectionStart = 7;
            //        //txtidorder.SelectionLength = 9;
            //        //int idrun = Convert.ToInt16(txtidorder.SelectedText.ToString());//ตัวลำดับที่ จากฐานข้อมูล

            //        //string addid = "S" + String.Format("{0:yy}", dtselect) + String.Format("{0:MM}", dtselect) + String.Format("{0:dd}", dtselect);                   

            //        //if (dateselect == daterun)
            //        //{
            //        //    idrun++;
            //        //    txtidorder.Text = addid + string.Format("{0:00}", idrun);
            //        //}
            //        //else
            //        //{
            //        //    txtidorder.Text = addid + "01";
            //        //}    
            //    }
            //    else
            //    {
            //        MessageBox.Show("ไม่สามารถลงวันที่ส่งย้อนหลังได้", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        txtidorder.Clear();
            //    }
            //}

            btnordersale.Focus();
        }

        private void txtqano_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtremark.Focus();
            }
        }

        private void txtremark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnpur.Focus();
            }
        }

        private void Loadtimerecivecus()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql1 = "select * from tbtimerecivecus ";

            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(ds, "stimrecive");
            cbtimerecivecus.DataSource = ds.Tables["stimrecive"];
            cbtimerecivecus.DisplayMember = "timeredetail";
            cbtimerecivecus.ValueMember = "idtimerecive";
            cbtimerecivecus.Text = "";           
            CN.Close();
        }


    }
}