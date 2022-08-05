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
    public partial class FrmPurchase : Form
    {
        public FrmPurchase()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string msnfrom = ""; 
        int idtypelog = 0; 
        public int idedit = 0; 
        int idsearchsuppro = 0;
        public int status = 0; 
        public string searchtype = ""; 
        public string id = ""; 
        int idtbpur=0;
        int idtypevat = 0;
        string datelog = DateTime.Now.Day.ToString();
        string monthlog = DateTime.Now.Month.ToString();
        string yearlog = DateTime.Now.Year.ToString();    

        private void DisableForEdit()
        {   
            btnsup.Enabled = false;
            btntypepro.Enabled = false;
            btnpurchase.Enabled = false;
            btnsend.Enabled = false;
            btncar.Enabled = false;
            txtremark.Enabled = false;
            txtpono.Enabled = false;
            dtpstdpo.Enabled = false;
            dtpedpo.Enabled = false;
            txtserailcar.Enabled = false;
            txtcontactcar.Enabled = false;
        }

        private void SearchSupproBybranch()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            try
            {
                string sql = "select idsuppro,namesup from vproductinstock where idsuppro='" + txtidpro.Text.Trim() + "' AND idbranch='" + Program.idbranch + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    idsearchsuppro = Convert.ToInt16(DR1["idsuppro"].ToString().Trim());
                }
                DR1.Close();
            }
            catch
            { MessageBox.Show("สินค้าชนิดนี้ไม่มีในสาขานี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void FrmPurchase_Load(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (idedit == 0 || idedit == 3 || idedit == 4)//Add new data
            {
                CreateAutoID(CN);

                txtlastsave.Text = Program.idsavelate;

                msnfrom = this.Name.ToString();
                idtypelog = 7;  //open
                Savelogevent();
            }


            if ( idedit == 1 ||idedit == 2 || idedit == 3 || idedit == 4)
            {
                if (idedit == 1 || idedit == 2)
                {
                    string sql = "select * from tbpurchase where idpur='" + id + "'";
                    SqlCommand CM1 = new SqlCommand(sql, CN);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    {
                        txtid.Text = DR1["idpur"].ToString().Trim();
                        dtppurchase.Text = DR1["datepur"].ToString().Trim();
                        txtidsup.Text = DR1["idcomsup"].ToString().Trim();
                        txtidpur.Text = DR1["idcompur"].ToString().Trim();
                        txtidcomtran.Text = DR1["idcomtran"].ToString().Trim();
                        txtidpro.Text = DR1["idpro"].ToString().Trim();
                        txtidcar.Text = DR1["idcar"].ToString().Trim();
                        txtcontactcar.Text = DR1["telcontact"].ToString().Trim();
                        txtserailcar.Text = DR1["serailcar"].ToString().Trim();
                        txtremark.Text = DR1["remark1"].ToString().Trim();
                        dtpstdpo.Text = DR1["stdpo"].ToString().Trim();
                        dtpedpo.Text = DR1["edpo"].ToString().Trim();
                        txtpono.Text = DR1["pono"].ToString().Trim();
                        idtypevat= Convert.ToInt16(DR1["idtypevat"].ToString().Trim());
                    }
                    DR1.Close();                    
                }
                if (idedit == 3)
                {
                    string sql = "select * from vonholetruckout where idtran='" + id + "'";
                    SqlCommand CM1 = new SqlCommand(sql, CN);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    {
                        txtidsup.Text = DR1["idcomsup"].ToString().Trim();
                        txtidpur.Text = DR1["idcomsup"].ToString().Trim();
                        txtidcomtran.Text = DR1["idcomtran"].ToString().Trim();
                        txtidpro.Text = DR1["idpro"].ToString().Trim();
                        txtidcar.Text = DR1["idcar"].ToString().Trim();
                        txtserailcar.Text = DR1["serailcar"].ToString().Trim();                        
                    }
                    DR1.Close();

                    txtremark.Text = "Order เพิ่มเติม";
                    txtremark.Enabled = false;
                    btntypepro.Enabled = false;
                    btnsend.Enabled = false;
                    btncar.Enabled = false;
                    dtppurchase.Enabled = false;
                    txtserailcar.Enabled = false;
                    txtcontactcar.Enabled = false;
                    txtpono.Text = "-";
                    txtcontactcar.Text = "-";
                    dtpstdpo.Enabled = false;
                    dtpedpo.Enabled = false;
                    LoadiDvat();
                    Searchcar();
                }

                if (idedit == 4)
                {
                    string sql = "select * from vFsTcFortrasport where idtran='" + id + "'";
                    SqlCommand CM1 = new SqlCommand(sql, CN);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    {
                        txtidsup.Text = DR1["idcomsup"].ToString().Trim();
                        txtidpur.Text = DR1["idcomsup"].ToString().Trim();
                        txtidcomtran.Text = DR1["idcomtran"].ToString().Trim();
                        txtidpro.Text = DR1["idpro"].ToString().Trim();
                        txtidcar.Text = DR1["idcar"].ToString().Trim();
                        txtserailcar.Text = DR1["serailcar"].ToString().Trim();
                    }
                    DR1.Close();

                    txtremark.Text = "Order เพิ่มเติม";
                    txtremark.Enabled = false;
                    btntypepro.Enabled = false;
                    btnsend.Enabled = false;
                    btncar.Enabled = false;
                    dtppurchase.Enabled = false;
                    txtserailcar.Enabled = false;
                    txtcontactcar.Enabled = false;
                    txtpono.Text = "-";
                    txtcontactcar.Text = "-";
                    dtpstdpo.Enabled = false;
                    dtpedpo.Enabled = false;
                    LoadiDvat();
                    Searchcar();
                }
                   
              
                Searchsuppliers();
                Searchpurchase();
                Searchcomtransport();
                Searchproduct();

                ////(idedit == 1)เป็นการแก้ไขเพิ่มเติมจากฝ่ายจัดซื้อ              

                if (idedit == 2 && idedit == 3)
                { txtremark.Text = "Order เพิ่มเติม"; }
            }

            CN.Close();
        }

        private void CreateAutoID(SqlConnection CN)
        {
            string sql = "select idpurauto,idpur from tbpurchase order by idpurauto desc";
            SqlCommand CM = new SqlCommand(sql, CN);
            SqlDataReader DR = CM.ExecuteReader();

            DR.Read();
            {
                idtbpur = Convert.ToInt16(DR["idpurauto"].ToString());
                txtid.Text = DR["idpur"].ToString();
                txtoldid.Text = DR["idpur"].ToString();
            }
            DR.Close();

            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            txtoldid.SelectionStart = 1;
            txtoldid.SelectionLength = 6;
            long daterun = Convert.ToInt64(txtoldid.SelectedText.ToString());//ตัดค่า 4 ปีเดือนวัน จากฐานข้อมูล

            txtid.SelectionStart = 7;
            txtid.SelectionLength = 9;
            int idrun = Convert.ToInt16(txtid.SelectedText.ToString());//ตัวลำดับที่ จากฐานข้อมูล
            string idcomplease = "P" + String.Format("{0:yy}", dt) + String.Format("{0:MM}", dt) + String.Format("{0:dd}", dt);
            long datenow = Convert.ToInt64(String.Format("{0:yy}", dt) + String.Format("{0:MM}", dt) + String.Format("{0:dd}", dt));

            if (datenow == daterun)
            {
                idrun++;
                txtid.Text = idcomplease + string.Format("{0:00}", idrun);
            }
            else
            {
                txtid.Text = idcomplease + "01";
            }
        }

        private void Searchsuppliers()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();            

            if (txtidsup.Text != "")
            {
                string sql = "select * from vcompany where idcom='" + txtidsup.Text.Trim() +"'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();                

                DR1.Read();
                {
                    txtnamesup.Text = DR1["cname"].ToString().Trim();

                    txtsupaddress.Text = DR1["baddress"].ToString().Trim() + " " + DR1["rd"].ToString().Trim() + " " + DR1["tumb"].ToString().Trim() + " " + DR1["country"].ToString().Trim() + " " + DR1["provice"].ToString().Trim() + " " + DR1["zipcode"].ToString().Trim();

                    txtsupcontact.Text = DR1["contact"].ToString().Trim();
                    txtsuptel.Text = DR1["tel"].ToString().Trim();
                }
                DR1.Close();
            }
        }

        private void Searchpurchase()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            if (txtidpur.Text != "")
            {
                string sql = "select * from vcompany where idcom='" + txtidpur.Text.Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();
                txtidpur.Text = id.ToString();

                DR1.Read();
                {
                    txtidpur.Text = DR1["idcom"].ToString().Trim();
                    txtpurname.Text = DR1["cname"].ToString().Trim();

                    txtpuraddress.Text = DR1["baddress"].ToString().Trim() + " " + DR1["rd"].ToString().Trim() + " " + DR1["tumb"].ToString().Trim() + " " + DR1["country"].ToString().Trim() + " " + DR1["provice"].ToString().Trim() + " " + DR1["zipcode"].ToString().Trim();
                }
                DR1.Close();
            }
        }

        private void Searchcomtransport()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            if (txtidcomtran.Text.Trim() != "")
            {
                string sql = "select * from vcompany where idcom='" + txtidcomtran.Text.Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();
                txtidcomtran.Text = id.ToString();

                DR1.Read();
                {
                    txtidcomtran.Text = DR1["idcom"].ToString().Trim();
                    txtsendname.Text = DR1["cname"].ToString().Trim();

                    txtsendaddress.Text = DR1["baddress"].ToString().Trim() + " " + DR1["rd"].ToString().Trim() + " " + DR1["tumb"].ToString().Trim() + " " + DR1["country"].ToString().Trim() + " " + DR1["provice"].ToString().Trim() + " " + DR1["zipcode"].ToString().Trim();
                }
                DR1.Close();
            }
        }

        private void Searchcar()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (txtidcar.Text != "")
            {
                string sql = "select * from tbcar where idcar='" + txtidcar.Text.Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();              

                DR1.Read();
                {
                    txtnamecar.Text = DR1["carname"].ToString().Trim();                   
                }
                DR1.Close();
            }
        }

        private void Searchproduct()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (txtidpro.Text != "")
            {
                string sql = "select * from tbproduct where idpro='" + txtidpro.Text.Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();
                txtidpro.Text = id.ToString();

                DR1.Read();
                {
                    txtidpro.Text = DR1["idpro"].ToString().Trim();
                    txtproname.Text = DR1["proname"].ToString().Trim();
                }
                DR1.Close();
            }        
        }

        private void SearchTruck()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (txtidcar.Text != "")
            {
                string sql = "select * from vcar where idcar='" + txtidcar.Text.Trim() +"'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();
                txtidcar.Text = id.ToString();

                DR1.Read();
                {
                    txtidcar.Text = DR1["idcar"].ToString().Trim();
                    txtnamecar.Text = DR1["carname"].ToString().Trim();
                }
                DR1.Close();
            }        
        }

        dtssaleorder dssearch = new dtssaleorder(); DataSet ds = new DataSet();
        private void btnsup_Click(object sender, EventArgs e)
        {
            Frmserch fs = new Frmserch();
            fs.sname = "ssupcom";
            fs.ShowDialog();

            if (fs.returnid.Trim() != "0")
            {
                txtidsup.Text = fs.returnid.Trim();
                Searchsuppliers();
                txtpono.Focus();
            }
        }

        private void btnpurchase_Click(object sender, EventArgs e)
        {
            Frmserch fs = new Frmserch();
            fs.sname = "spurcom";
            fs.ShowDialog();
            if (fs.returnid.Trim() != "0")
            {
                txtidpur.Text = fs.returnid.Trim();
                LoadiDvat();
                Searchpurchase();              
                btnsend.Focus();
            }
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            Frmserch fs = new Frmserch();
            fs.sname = "ssendcom";
            fs.ShowDialog();
            if (fs.returnid.Trim() != "0")
            {
                txtidcomtran.Text = fs.returnid.Trim();
                Searchcomtransport();
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
                txtidcar.Text = fs.returnid.Trim();
                SearchTruck();
                txtserailcar.Focus();
            }
        }

        private void btntypepro_Click(object sender, EventArgs e)
        {    
            Frmserch fs = new Frmserch();
            fs.sname = "spropur";
            fs.ShowDialog();
            if (fs.returnid.Trim() != "0")
            {
                txtidpro.Text = fs.returnid.Trim();
                Searchproduct();              
                btnpurchase.Focus();
            }
        }

        private void LoadiDvat()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            int count=0;

            string sql1 = "select count(idcom) as counsum from vtypeComFSTCvat where idcom = '" + txtidpur.Text.Trim() + "' and idtypeordervat = 1";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            { count = Convert.ToInt16(DR1["counsum"].ToString()); }
            DR1.Close();

            if (count != 0)
            {
                string sql2 = "select idtypevat from vtypeComFSTCvat where idcom='" + txtidpur.Text.Trim() + "' AND idtypeordervat= 1 ";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();

                DR2.Read();
                { idtypevat = Convert.ToInt16(DR2["idtypevat"].ToString()); }
                DR2.Close();
            }
        }        

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sdate = dtppurchase.Value.Day.ToString();
            string smonth = dtppurchase.Value.Month.ToString();
            string syear = dtppurchase.Value.Year.ToString();
            string selectdate = smonth + "/" + sdate + "/" + syear;

            string date = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string sumdate = month + "/" + date + "/" + year;

            string dsday = dtpstdpo.Value.Day.ToString();
            string dsmonth = dtpstdpo.Value.Month.ToString();
            string dsyear = dtpstdpo.Value.Year.ToString();
            string dtsum = dsmonth + "/" + dsday + "/" + dsyear;

            string deday = dtpedpo.Value.Day.ToString();
            string demonth = dtpedpo.Value.Month.ToString();
            string deyear = dtpedpo.Value.Year.ToString();
            string desum = demonth + "/" + deday + "/" + deyear;

            DateTime now = DateTime.Now;

            if (idtypevat == 0)
            { idtypevat = 4; }

            try
            {
                if (idedit == 1)// edit order
                {
                    string sql = "update tbpurchase set idcomsup='" + txtidsup.Text + "',idcompur='" + txtidpur.Text + "',idcomtran='" + txtidcomtran.Text + "',idpro='" + txtidpro.Text + "',idcar='" + txtidcar.Text + "',datepur='" + selectdate + "',ctdate='" + sumdate + "',ctedtime='" + string.Format("{0:HH:mm:ss}", DateTime.Now) + "',telcontact='" + txtcontactcar.Text + "',serailcar='" + txtserailcar.Text + "',pono='" + txtpono.Text + "',stdpo='" + dtsum + "',edpo='" + desum + "',idtypevat=" + idtypevat + ",remark1='" + txtremark.Text + " [มีการแก้ไข Order] " + "' Where idpur= '" + txtid.Text + "'";

                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();

                    //MessageBox.Show("ข้อมูลทำการปรับปรุงแล้ว ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else if (idedit == 0)//Add new order
                {
                    string sql = "insert into tbpurchase(idpur,datepur,ctdate,ctedtime,idcomsup,idcompur,idcomtran,idpro,idcar,telcontact,serailcar,pono,stdpo,edpo,remark1,idstatus,idtypevat) values ('" + txtid.Text + "','" + selectdate + "','" + sumdate + "','" + string.Format("{0:HH:mm:ss}", DateTime.Now) + "','" + txtidsup.Text + "','" + txtidpur.Text + "','" + txtidcomtran.Text + "'," + txtidpro.Text + "," + txtidcar.Text + ",'" + txtcontactcar.Text + "','" + txtserailcar.Text + "','" + txtpono.Text + "','" + dtsum + "','" + desum + "','" + txtremark.Text + "'," + 4 + "," + idtypevat + ")";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();
                }

                else if (idedit == 2 || idedit == 3 || idedit == 4)
                {
                    string sql = "insert into tbpurchase(idpur,datepur,ctdate,ctedtime,idcomsup,idcompur,idcomtran,idpro,idcar,telcontact,serailcar,pono,stdpo,edpo,remark1,idstatus,editstatus,idtypevat) values ('" + txtid.Text + "','" + selectdate + "','" + sumdate + "','" + string.Format("{0:HH:mm:ss}", DateTime.Now) + "','" + txtidsup.Text + "','" + txtidpur.Text + "','" + txtidcomtran.Text + "'," + txtidpro.Text + "," + txtidcar.Text + ",'" + txtcontactcar.Text + "','" + txtserailcar.Text + "','" + txtpono.Text + "','" + dtsum + "','" + desum + "','Order เพิ่มเติม'," + 4 + ",1," + idtypevat + ")";

                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();
                }
                
                MessageBox.Show("บันทึกข้อมูลประสบความสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.idsavelate = txtid.Text;
                msnfrom = this.Name.ToString();
                idtypelog = 1;//insert
                Savelogevent();

                DialogResult answer;
                answer = MessageBox.Show("คุณต้องการทำรายการต่อหรือไม่ !", "กรุณายืนยัน !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (answer == DialogResult.OK)
                {
                    ClearAll();
                }
                if (answer == DialogResult.Cancel)
                { this.Close(); }
               
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error ! =" + ex.Message, "Please ! Check any Insert data type", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearAll()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            CreateAutoID(CN);
            txtcontactcar.Clear();
            txtproname.Clear();
            txtpuraddress.Clear();
            txtpurname.Clear();
            txtremark.Text = "-";
            txtsendaddress.Clear();
            txtsendname.Clear();
            txtserailcar.Clear();
            txtsupaddress.Clear();
            txtsupcontact.Clear();
            txtsuptel.Clear();           
            txtidcar.Clear();
            txtidcomtran.Clear();
            txtidpro.Clear();
            txtidpur.Clear();
            txtidsup.Clear();
            txtlastsave.Clear();
            txtnamecar.Clear();
            txtnamesup.Clear();
            txtpono.Text = "-";
            btnsup.Focus();
        }

        private void Savelogevent()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string selectdatelog = monthlog + "/" + datelog + "/" + yearlog;

            string sql1 = "insert into tblog(logname,datein,timein,idtypelog,idemp,remark) values('" + msnfrom + "','" + selectdatelog + "','" + DateTime.Now.ToLongTimeString() + "'," + idtypelog + ",'" + Program.empID + "','" + txtid.Text.Trim() + "')";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            CM1.ExecuteNonQuery();
        }

        private void FrmPurchase_FormClosed(object sender, FormClosedEventArgs e)
        {            
            msnfrom = this.Name.ToString();
            idtypelog = 6;  //close
            Savelogevent();
        }

        private void txtpono_KeyPress(object sender, KeyPressEventArgs e)
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
                btntypepro.Focus();
            }
        }

        private void txtserailcar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtcontactcar.Focus();
            }
        }

        private void txtcontactcar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnsave.Focus();
            }
        }

        private void dtppurchase_ValueChanged(object sender, EventArgs e)
        {
            btnsup.Focus();
        } 


      
    }
}