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
    public partial class Frmdraftquatation : Form
    {
        public Frmdraftquatation()
        {
            InitializeComponent();
        }

        string idcus = ""; int idpro = 0; int idsquaauto = 0; string idqua = ""; DataSet ds = new DataSet(); string idsale = ""; Decimal price = 0; int idformatepay = 0; int idproold = 0; int idhiscus = 0;

        private void btnproduct_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            Frmserch fs = new Frmserch();
            fs.sname = "spro";
            fs.ShowDialog();
            string id = fs.returnid;

            if (id != "0")
            {
                string sql = "select * from vproduct where idpro='" + id + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    idpro =Convert.ToInt16(DR1["idpro"].ToString().Trim());
                    txtproductname.Text = DR1["proname"].ToString().Trim();
                }
                DR1.Close();
            }
        }

        private void tbpriceperunit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 13 && e.KeyChar != 8 && e.KeyChar != 46)
            {
                MessageBox.Show("ป้อนได้แต่ตัวเลขเท่านั้น", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
            else if (e.KeyChar == 13)
            {
                if (txtpriceperunit.Text != "")
                {
                    price = Convert.ToDecimal(txtpriceperunit.Text);
                    if (price == 0)
                    {
                        MessageBox.Show("ค่าห้ามเป็นศูนย์ค่ะ", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtpriceperunit.Focus();
                    }
                    //decimal weigthbf = Convert.ToInt32(txtweigthkk.Text);
                    txtpriceperunit.Text = price.ToString("#,###.#0");
                    rdotypcashmoney.Focus();
                }
            }
        }

        private void cbusedatacus_CheckedChanged(object sender, EventArgs e)
        {
            if (cbusedatacus.Checked == true)
            {
                txtsendcontact.Text = txtcuscontact.Text;
                txtsendno.Text = txtcusno.Text;
                txtsendprovice.Text = txtcusprovice.Text;
                txtsendroad.Text = txtcusroad.Text;
                txtsendtel.Text = txtcustel.Text;
                txtsendtum.Text = txtcustum.Text;
                txtsendvilage.Text = txtcusvilage.Text;
                txtsendzipcode.Text = txtcuszipcode.Text;

                //------------------
                txtsendReadonlyTrue();

            }
            if (cbusedatacus.Checked == false)
            {
                txtsendReadonlyFalse();
                txtAllsendClear();
            }
        }

        private void txtsendReadonlyTrue()
        {
            //txtnamecus.ReadOnly = true;
            txtsendcontact.ReadOnly = true;
            txtsendno.ReadOnly = true;
            txtsendprovice.ReadOnly = true;
            txtsendroad.ReadOnly = true;
            txtsendtel.ReadOnly = true;
            txtsendtum.ReadOnly = true;
            txtsendvilage.ReadOnly = true;
            txtsendzipcode.ReadOnly = true;
        }

        private void txtAllsendClear()
        {
            //txtnamecus.Clear(); 
            txtsendcontact.Clear();
            txtsendno.Clear();
            txtsendprovice.Clear();
            txtsendroad.Clear();
            txtsendtel.Clear();
            txtsendtum.Clear();
            txtsendvilage.Clear();
            txtsendzipcode.Clear();
        }

        private void txtsendReadonlyFalse()
        {
            //txtnamecus.ReadOnly = true;
            txtsendcontact.ReadOnly = false;
            txtsendno.ReadOnly = false;
            txtsendprovice.ReadOnly = false;
            txtsendroad.ReadOnly = false;
            txtsendtel.ReadOnly = false;
            txtsendtum.ReadOnly = false;
            txtsendvilage.ReadOnly = false;
            txtsendzipcode.ReadOnly = false;
        }

        private void txtCusReadonlyFalse()
        {
            cbusedatacus.Enabled = true;
            txtnamecus.ReadOnly = false;
            txtcuscontact.ReadOnly = false;
            txtcusno.ReadOnly = false;
            txtcusprovice.ReadOnly = false;
            txtcusroad.ReadOnly = false;
            txtcusfax.ReadOnly = false;
            txtcustel.ReadOnly = false;
            txtcustum.ReadOnly = false;
            txtcusvilage.ReadOnly = false;
            txtcuszipcode.ReadOnly = false;
        }

        private void txtCusReadonlyTrue()
        {
            cbusedatacus.Enabled = false;
            txtnamecus.ReadOnly = true;
            txtcuscontact.ReadOnly = true;
            txtcusno.ReadOnly = true;
            txtcusprovice.ReadOnly = true;
            txtcusroad.ReadOnly = true;
            txtcustel.ReadOnly = true;
            txtcusfax.ReadOnly = true;
            txtcustum.ReadOnly = true;
            txtcusvilage.ReadOnly = true;
            txtcuszipcode.ReadOnly = true;
        }

        private void txtAllCusClear()
        {
            txtnamecus.Clear();
            txtcuscontact.Clear();
            txtcusno.Clear();
            txtcusprovice.Clear();
            txtcusroad.Clear();
            txtcustel.Clear();
            txtcusfax.Clear();
            txtcustum.Clear();
            txtcusvilage.Clear();
            txtcuszipcode.Clear();
        }


        private void rdocusold_CheckedChanged(object sender, EventArgs e)
        {
            if (rdocusold.Checked == true)
            {
                btnsearchcus.Enabled = true;
                txtAllCusClear();
                txtAllsendClear();
                txtCusReadonlyTrue();
                txtsendReadonlyTrue();
            }
        }

        private void rdocusnew_CheckedChanged(object sender, EventArgs e)
        {
            if (rdocusnew.Checked == true)
            {
                btnsearchcus.Enabled = false;
                txtsendReadonlyFalse();
                txtCusReadonlyFalse();
                cbusedatacus.Checked = false;
                ClearAlltextbox();
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadtypenameunit()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql1 = "select * from tbtypenameunit";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(ds, "namtype");
            cbunit.DataSource = ds.Tables["namtype"];
            cbunit.DisplayMember = "nameunit";
            cbunit.ValueMember = "idtypeunit";

        }

        private void Frmdraftquatation_Load(object sender, EventArgs e)
        {
            idsale = Program.empID;
            txtnamesale.Text = Program.names;
            rdocusold.Focus();
            rdocusold.Checked = true;
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            loadtypenameunit();

            int count = 0;

            string sql1 = "select  COUNT(idqua) AS countidqua from tbquatation ORDER BY countidqua DESC";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                count = Convert.ToInt16(DR1["countidqua"].ToString().Trim());
            }
            DR1.Close();

            if (count != 0)
            {
                string sql = "select idquaauto,idqua from tbquatation ORDER BY idquaauto DESC";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                DR.Read();
                {
                    idsquaauto = Convert.ToInt16(DR["idquaauto"].ToString());
                    txtoldid.Text = DR["idqua"].ToString();
                }
                DR.Close();
            }

            else
            { txtoldid.Text = "Q0000000001"; }

            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            txtoldid.SelectionStart = 1;
            txtoldid.SelectionLength = 6;
            long daterun = Convert.ToInt64(txtoldid.SelectedText.ToString());//ตัดค่า 4 ปีเดือนวัน จากฐานข้อมูล

            txtoldid.SelectionStart = 7;
            txtoldid.SelectionLength = 9;
            int idrun = Convert.ToInt16(txtoldid.SelectedText.ToString());//ตัวลำดับที่ จากฐานข้อมูล
            string idcomplease = "Q" + String.Format("{0:yy}", dt) + String.Format("{0:MM}", dt) + String.Format("{0:dd}", dt);
            long datenow = Convert.ToInt64(String.Format("{0:yy}", dt) + String.Format("{0:MM}", dt) + String.Format("{0:dd}", dt));

            if (datenow == daterun)
            {
                idrun++;
                txtidqua.Text = idcomplease + string.Format("{0:00}", idrun);
            }
            else
            {
                txtidqua.Text = idcomplease + "01";
            }

            CN.Close();
        }

        private void checktextboxandid()
        {
            if (txtnamecus.Text != "" && txtpriceperunit.Text != "0" && txtremark.Text != "" && idpro != 0 && txtcusno.Text != "" && txtcusroad.Text != "" && txtcustum.Text != "" && txtcusvilage.Text != "" && txtcusprovice.Text != "" && txtcuszipcode.Text != "" && txtcusfax.Text != "" && txtcuscontact.Text != "" && rdotypcashmoney.Checked != false || rdotypecreditmoney.Checked != false)
            {
                idcheck = 1;
            }
            else
            { MessageBox.Show("ข้อมูลไม่ครบ!หรือราคาเท่ากับ 0 ถ้าช่องเป็นค่าว่างกรุณาใส่เครื่องหมาย '-' ในช่องนั้น", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        int idcheck = 0;
        private void btnaddedit_Click(object sender, EventArgs e)
        {
            checktextboxandid();
            Saveaddresscontact();           
        }        

        private void Saveaddresscontact()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (rdotypcashmoney.Checked == true)
            { idformatepay = 1; }
            else
            {
                if (cbunitcreditday.SelectedIndex == 0)
                { idformatepay = 2; }
                if (cbunitcreditday.SelectedIndex == 1)
                { idformatepay = 3; }
                if (cbunitcreditday.SelectedIndex == 2)
                { idformatepay = 3; }
            }

            string sql4 = "insert into tbCustomer(namecusth,idformatofpayment,idemp,idsale) values ('" + txtnamecus.Text + "','" + idformatepay + "','" + Program.empID + "','" + idsale + "')";
            SqlCommand CM4 = new SqlCommand(sql4, CN);
            CM4.ExecuteNonQuery();

            int idhistorycus = 0;
            string sql3 = "select MAX(idhistorycus)as idhistorycus  from tbCustomer";
            SqlCommand CM3 = new SqlCommand(sql3, CN);
            SqlDataReader DR1 = CM3.ExecuteReader();
            DR1.Read();
            { idhistorycus = Convert.ToInt16(DR1["idhistorycus"].ToString().Trim()); }
            DR1.Close();


            if (cbusedatacus.Checked == false)
            {
                string sql1 = "insert into tbaddresscompany(addno,addroad,addtumb,addvilage,addprovice,addzipcode,addnamecontace,addtel,addfax,idtypeaddress,idstatusqua,idhistorycus) values ('" + txtcusno.Text + "','" + txtcusroad.Text + "','" + txtcustum.Text + "','" + txtcusvilage.Text + "','" + txtcusprovice.Text + "','" + txtcuszipcode.Text + "','" + txtcuscontact.Text + "','" + txtcustel.Text + "','" + txtcusfax.Text + "',1,1," + idhistorycus + ")";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                CM1.ExecuteNonQuery();

                string sql2 = "insert into tbaddresscompany(addno,addroad,addtumb,addvilage,addprovice,addzipcode,addnamecontace,addtel,idtypeaddress,idstatusqua,idhistorycus) values ('" + txtsendno.Text + "','" + txtsendroad.Text + "','" + txtsendtum.Text + "','" + txtsendvilage.Text + "','" + txtsendprovice.Text + "','" + txtsendzipcode.Text + "','" + txtsendcontact.Text + "','" + txtsendtel.Text + "',3,1," + idhistorycus + ")";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                CM2.ExecuteNonQuery();

            }
            else if (cbusedatacus.Checked == true)
            {
                string sql2 = "insert into tbaddresscompany(addno,addroad,addtumb,addvilageode,addprovice,addzipc,addnamecontace,addtel,addfax,idtypeaddress,idstatusqua,idhistorycus) values ('" + txtcusno.Text + "','" + txtcusroad.Text + "','" + txtcustum.Text + "','" + txtcusvilage.Text + "','" + txtcusprovice.Text + "','" + txtcuszipcode.Text + "','" + txtcuscontact.Text + "','" + txtcustel.Text + "','" + txtcusfax.Text + "',5,1," + idhistorycus + ")";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                CM2.ExecuteNonQuery();
            }

            string date = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string sumdate = month + "/" + date + "/" + year;

            string sdate = dtpstartuse.Value.Day.ToString();
            string smonth = dtpstartuse.Value.Month.ToString();
            string syear = dtpstartuse.Value.Year.ToString();
            string startdate = smonth + "/" + sdate + "/" + syear;    

            if (idcheck == 1)
            {
                if (price != 0)
                {
                    string sql1 = "insert into tbquatation(idqua,datequa,unit,priceperunit,idtypeunit,remark,startusedate,idpro,idstatusqua,idhistorycus) values ('" + txtidqua.Text + "','" + sumdate + "'," + txtunit.Text + "," + price + "," + cbunit.SelectedValue.ToString() + ",'" + txtremark.Text + "','" + startdate + "'," + idpro + ",1," + idhistorycus + ")";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();


                    MessageBox.Show("บันทึกข้อมูลประสบความสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                { MessageBox.Show("ราคาขายต่อหน่วยต้องไม่เท่ากันศูนย์ !", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error); txtpriceperunit.Focus(); }
            }
        }

        private void btnsearchsale_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            Frmserch fs = new Frmserch();
            fs.sname = "sempsale";
            fs.ShowDialog();
            string id = fs.returnid;

            if (id != "0")
            {
                string sql = "select * from vempsale where idemp='" + id + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    idsale = DR1["idemp"].ToString().Trim();
                    txtnamesale.Text = DR1["empname"].ToString().Trim();
                }
                DR1.Close();
            }

            CN.Close();
        }

        private void rdotypcashmoney_CheckedChanged(object sender, EventArgs e)
        {
            if (rdotypcashmoney.Checked == true)
            {
                idformatepay = 1;
            }
        }

        private void rdotypecreditmoney_CheckedChanged(object sender, EventArgs e)
        {
            if (rdotypecreditmoney.Checked == true)
            {
                cbunitcreditday.Enabled = true;
            }
        }

        private void cbunitcreditday_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbunitcreditday.SelectedIndex == 0)
            {
                idformatepay = 2;
            }
            if (cbunitcreditday.SelectedIndex == 1)
            {
                idformatepay = 3;
            }
            if (cbunitcreditday.SelectedIndex == 2)
            {
                idformatepay = 4;
            }
        }

        private void txtnamecus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { txtcusno.Focus(); }
        }

        private void txtcusno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { txtcusroad.Focus(); }
        }

        private void txtcusroad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { txtcustum.Focus(); }
        }

        private void txtcustum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { txtcusvilage.Focus(); }
        }

        private void txtcusvilage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { txtcusprovice.Focus(); }
        }

        private void txtcusprovice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { txtcuszipcode.Focus(); }
        }

        private void txtcuszipcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { txtcuscontact.Focus(); }
        }

        private void txtcuscontact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { txtcustel.Focus(); }
        }

        private void txtcusfax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { btnproduct.Focus(); }
        }

        private void txtcustel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { txtcusfax.Focus(); }
        }

        private void txtremark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { btnaddedit.Focus(); }
        }

        private void btnsearchcus_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            Frmserch fs = new Frmserch();
            fs.sname = "scomcusquatation";
            fs.ShowDialog();
            if (fs.returnid.Trim() != "0")
            { 
                //search address contact
                string sql1 = "select * from vscomquatation where idaddress=" + fs.returnid +" and idtypeaddress = 2";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();
                string nametype = "";

                DR1.Read();
                {
                    txtnamecus.Text = DR1["namecus"].ToString().Trim();
                    txtcusno.Text = DR1["addno"].ToString().Trim();
                    txtcusroad.Text = DR1["addroad"].ToString().Trim();
                    txtcustum.Text = DR1["addtumb"].ToString().Trim();
                    txtcusvilage.Text = DR1["addvilage"].ToString().Trim();
                    txtcusprovice.Text = DR1["addprovice"].ToString().Trim();
                    txtcuszipcode.Text = DR1["addzipcode"].ToString().Trim();
                    txtcustel.Text = DR1["addtel"].ToString().Trim();
                    txtcusfax.Text = DR1["addfax"].ToString().Trim();
                    txtcuscontact.Text = DR1["addnamecontace"].ToString().Trim();
                    txtremark.Text = DR1["addremark"].ToString().Trim();
                    idqua = DR1["idqua"].ToString().Trim();                  
                    idproold = Convert.ToInt16(DR1["idpro"].ToString().Trim());                   
                    txtproductname.Text = DR1["proname"].ToString().Trim();
                    nametype = DR1["namepayment"].ToString().Trim();
                    txtremark.Text = DR1["remark"].ToString().Trim();
                    dtpstartuse.Text = DR1["startusedate"].ToString().Trim();
                }
                DR1.Close();

                if (nametype == "ชำระด้วยเงินสด")
                {
                    rdotypcashmoney.Checked = true;
                }
                else
                { rdotypecreditmoney.Checked = true; cbunitcreditday.Text = nametype; }

                txtpriceperunit.BackColor = Color.Salmon;
                cbunitcreditday.BackColor = Color.Salmon;
                
                //search address send product
                string sql2 = "select * from vscomquatation where idqua='" + idqua + "' and idtypeaddress = 3";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();

                DR2.Read();
                {
                    txtsendno.Text = DR2["addno"].ToString().Trim();
                    txtsendroad.Text = DR2["addroad"].ToString().Trim();
                    txtsendtum.Text = DR2["addtumb"].ToString().Trim();
                    txtsendvilage.Text = DR2["addvilage"].ToString().Trim();
                    txtsendprovice.Text = DR2["addprovice"].ToString().Trim();
                    txtsendzipcode.Text = DR2["addzipcode"].ToString().Trim();
                    txtsendtel.Text = DR2["addtel"].ToString().Trim();
                    txtsendcontact.Text = DR2["addnamecontace"].ToString().Trim();
                }
                DR2.Close();
            }
            
             //search price product
            //string sql3 = "select * from tbchangprice where refidchage=" + idhiscus + " order by idchangprice ";
             //  string sql3="select MAX(idchangprice)as idmax  from tbchangprice where refidchage = "+idhiscus+"";

            if (idhiscus != 0)
            {
                string sql3 = "select idchangprice,idpro,changprice from tbchangprice where refidchage=" + idhiscus + " order by idchangprice desc";
                SqlCommand CM3 = new SqlCommand(sql3, CN);
                SqlDataReader DR3 = CM3.ExecuteReader();

                DR3.Read();
                {
                    idpro = Convert.ToInt16(DR3["idpro"].ToString().Trim());
                    txtpriceperunit.Text = DR3["changprice"].ToString().Trim();
                }
                DR3.Close();
                price = Convert.ToDecimal(txtpriceperunit.Text.Trim());
            }
            CN.Close();
        }

        private void ClearAlltextbox()
        {
            idqua = ""; txtnamecus.Clear(); txtcusno.Clear(); txtcusroad.Clear();
            txtcustum.Clear(); txtcusvilage.Clear(); txtcusprovice.Clear();
            txtcuszipcode.Clear(); txtcustel.Clear(); txtcusfax.Clear();
            txtcuscontact.Clear(); txtremark.Clear(); txtsendno.Clear(); txtsendroad.Clear();
            txtsendtum.Clear(); txtsendvilage.Clear(); txtsendprovice.Clear(); txtsendzipcode.Clear();
            txtsendtel.Clear(); txtsendcontact.Clear();
        }
    }
}