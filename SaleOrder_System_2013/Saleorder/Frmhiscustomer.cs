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
    public partial class Frmhiscustomer : Form
    {
        public Frmhiscustomer()
        {
            InitializeComponent();
        }

        string idsale = ""; string idqua = "";
        DataSet ds = new DataSet();
        int idaddcertcom =0; //address from certcompany
        int idaddsendbill=0;//ที่อยู่ส่งบิล
        int idtypecomqua = 0; //ข้อมูลประเภทการประกอบการ
        int idaddcontact=0;//ที่อยู่ผู้ติดต่อ
        int idaddsendproduct=0;//ที่อยู่ส่งส ินค้า
        int idbusiness=0;//ประเภทธุรกิจ
        int idmedia=0;
        int idtypevat=0;
        int idformatpayment=0;   //รูปแบบการชำระเงิน (เงินสด หรือเครดิต)
        int idquaterpastbill=0;
        int idtimepastbil=0;   //save tiem of past bill
        int idtypeofpayment=0;//ประเภทการชำระเงิน (เป็นเช็คหรือโอนเงิน)
        int idemp=0;
        int idrefdoc=0;
        int idsave = 0;  //check status save all

        //update tabel price
        int idpro = 0;
        decimal price = 0;

        //referrance ducument
        int personcard = 0;
        int copycertcompany = 0;
        int copypptwenty = 0;
        int mapsendbill = 0;
        int mapsendsendpro = 0;

        //Check Status  Addnew or Update
        int idstatus = 0;

        private void Frmhiscustomer_Load(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (idstatus == 0)//add new
            {
                loadcreditday(CN);                
                loadbillday(CN);
                loadbilltime(CN);
                loadcreditofmount(CN);
                loadcredittime(CN);
                loadvat(CN);
                
            }

            if (idstatus == 1)// edit
            { 
            
            }
            CN.Close();
        }   

        private void loadvat(SqlConnection CN)
        {
            string sql1 = "select * from tbtypevat";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(ds, "loadtypevat");
            cbvat.DataSource = ds.Tables["loadtypevat"];
            cbvat.DisplayMember = "namevat";
            cbvat.ValueMember = "idtypevat";
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void loadcreditday(SqlConnection CN)
        {
            string sql1 = "select * from tbformatofpayment";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(ds, "unitcreditday");
            cbunitcreditday.DataSource = ds.Tables["unitcreditday"];
            cbunitcreditday.DisplayMember = "namepayment";
            cbunitcreditday.ValueMember = "idformatofpayment";
        }

        private void loadbilltime(SqlConnection CN)
        {
            string sql1 = "select * from tbtimerecivebill";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(ds, "timerecivebill");
            cbbillhour.DataSource = ds.Tables["timerecivebill"];
            cbbillhour.DisplayMember = "namtime";
            cbbillhour.ValueMember = "idtimebill";
        }

        private void loadbillday(SqlConnection CN)
        {
            string sql1 = "select * from tbday";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(ds, "billday");
            cbbillday.DataSource = ds.Tables["billday"];
            cbbillday.DisplayMember = "nameday";
            cbbillday.ValueMember = "idday";
        }

        //private void loadbilldate(SqlConnection CN)
        //{
        //    string sql1 = "select * from tbformatofpayment";
        //    SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
        //    da1.Fill(ds, "unitcreditday");
        //    cbunitcreditday.DataSource = ds.Tables["unitcreditday"];
        //    cbunitcreditday.DisplayMember = "namepayment";
        //    cbunitcreditday.ValueMember = "idformatofpayment";
        //}

        private void loadcredittime(SqlConnection CN)
        {
            string sql1 = "select * from tbtimerecivebill";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(ds, "credittime");
            cbhourcheqe.DataSource = ds.Tables["credittime"];
            cbhourcheqe.DisplayMember = "namtime";
            cbhourcheqe.ValueMember = "idtimebill";
        }

        private void loadcreditofmount(SqlConnection CN)
        {
            string sql1 = "select * from tbdate";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(ds, "creditdate");
            cbdateofmount.DataSource = ds.Tables["creditdate"];
            cbdateofmount.DisplayMember = "namedate";
            cbdateofmount.ValueMember = "iddate";
        }



        private void btnaddedit_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            //date status now
            string date = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string datetime = month + "/" + date + "/" + year;

            string sdate = dtpstartcard.Value.Day.ToString();
            string smonth = dtpstartcard.Value.Month.ToString();
            string syear = dtpstartcard.Value.Year.ToString();
            string stime = smonth + "/" + sdate + "/" + syear;

            string edate = dtpexpirecard.Value.Day.ToString();
            string emonth = dtpexpirecard.Value.Month.ToString();
            string eyear = dtpexpirecard.Value.Year.ToString();
            string etime = emonth + "/" + edate + "/" + eyear;

            savetypecompany();//save ข้อมูลประเภทการประกอบการ
            savetypeofpayment();//save ประเภทการชำระเงิน
            savetimeofpastbill();
            quatorofpastbill();
            savemedia();
            savebusiness();
            saverefdocument();

            if (idsave == 1)
            {
                string sql = "insert into tbhistorycustomer(dateaddhis,namecusth,namecuseng,idaddcert,idquacompany,idaddcontact,idaddsendproduct,idbusiness,idmedia,idformatofpayment,idquaterpastbill,idtimepastbill,idtypeofpayment,idemp,idsale,idrefdoc,idtypevat,moneycredit) values ('" + datetime + "','" + txtnamcusth.Text + "','" + txtnamecuseng.Text + "'," + idaddcertcom + "," + idtypecomqua + "," + idaddcontact + "," + idaddsendproduct + "," + idbusiness + "," + idmedia + "," + idformatpayment + "," + idquaterpastbill + "," + idtimepastbil + "," + idtypeofpayment + ",'" + Program.empID + "','" + idsale + "','" + idrefdoc + "',4,0)";
                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();

                int idmaxhistory = 0;
                string sql2 = "select MAX(idhistorycus) AS idmax FROM tbhistorycustomer";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();
                DR2.Read();
                //SELECT     MAX(idaddress) AS maxidquatypecom FROM tbquacompany
                {
                    idmaxhistory = Convert.ToInt32(DR2["idmax"].ToString().Trim());
                }
                DR2.Close();

                if (idstatus == 0)// status addnew
                {
                    string sql1 = "insert into tbhischangdata(datehischang,remarkhischang,idempapprove,idtypechange,idhistorycus,idstatusqua,oldnamechange,newnamechage) values ('" + datetime + "','เพิ่มข้อมูลใหม่','" + Program.empID + "',1," + idmaxhistory + ",1,'-','-')";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();

                    string sql3 = "update tbquatation set idhistorycus='" + idmaxhistory + "' Where idqua='" + idqua + "'";
                    SqlCommand CM3 = new SqlCommand(sql3, CN);
                    CM3.ExecuteNonQuery();

                    MessageBox.Show("บันทึกข้อมูลแล้ว ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            CN.Close();
            savepricecus();
        }

        private void savepricecus()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb; CN.Open();
            string date = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string sumdate = month + "/" + date + "/" + year;

            string idmaxqua = "";
            string sql2 = "select MAX(idhistorycus) AS idmaxqua FROM tbhistorycustomer";
            SqlCommand CM2 = new SqlCommand(sql2, CN);
            SqlDataReader DR2 = CM2.ExecuteReader();
            DR2.Read();
            { idmaxqua = DR2["idmaxqua"].ToString().Trim(); }
            DR2.Close();

            string sql3 = "insert into tbchangprice(changdate,refidchage,idpro,changprice,changremark,idstatusqua) values ('" + sumdate + "'," + idmaxqua + "," + idpro + "," + price + ",'เพิ่มข้อมูลใหม่',5)";
            SqlCommand CM3 = new SqlCommand(sql3, CN);
            CM3.ExecuteNonQuery();
            CN.Close();
        }

        private void saverefdocument()
        {
            if (cbcopyperson.Checked == true
                || cbcopycertcompany.Checked == true
                || cbcopymapbill.Checked == true
                || cbcopypp20.Checked == true
                || cbcopymapsend.Checked == true)
            {
                if (cbcopyperson.Checked == true)
                { personcard = 1; }
                if (cbcopycertcompany.Checked == true)
                { copycertcompany = 1; }
                if (cbcopymapbill.Checked == true)
                { mapsendbill = 1; }
                if (cbcopypp20.Checked == true)
                { copypptwenty = 1; }
                if (cbcopymapsend.Checked == true)
                { mapsendsendpro = 1; }

                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();

                string sql1 = "insert into tbreferanceDoc(personcard,copycertcompany,copypptwenty,mapsendbill,mapsendsendpro) values (" + personcard + "," + copycertcompany + "," + mapsendbill + "," + copypptwenty + "," + mapsendsendpro + ")";

                SqlCommand CM1 = new SqlCommand(sql1, CN);
                CM1.ExecuteNonQuery();

                string sql2 = "select MAX(idrefdoc) AS idmax FROM tbreferanceDoc";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();
                DR2.Read();
                //SELECT     MAX(idaddress) AS maxidquatypecom FROM tbquacompany
                { idrefdoc = Convert.ToInt32(DR2["idmax"].ToString().Trim()); }
                DR2.Close();

                if (idbusiness != 0)
                { idsave = 1; }
                CN.Close();
            }
        }

        private void savebusiness()
        {
            if (rdotypebuchemi.Checked == true
       || rdotypebudye.Checked == true
       || rdotypeeletonic.Checked == true
       || rdotypebufood.Checked == true
       || rdotypebutredding.Checked == true
       || rdotypebumedecil.Checked == true
       || rdotypebuorther.Checked == true)
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open(); string sql = "";

                if (rdotypebuchemi.Checked == true)//from cus
                { sql = "insert into tbbusiness(idtypebusiness) values (1)"; }
                if (rdotypebudye.Checked == true)//from cus
                { sql = "insert into tbbusiness(idtypebusiness) values (2)"; }
                if (rdotypeeletonic.Checked == true)//from cus
                { sql = "insert into tbbusiness(idtypebusiness) values (3)"; }
                if (rdotypebufood.Checked == true)//from cus
                { sql = "insert into tbbusiness(idtypebusiness) values (4)"; }
                if (rdotypebutredding.Checked == true)//from cus
                { sql = "insert into tbbusiness(idtypebusiness) values (5)"; }
                if (rdotypebumedecil.Checked == true)//from cus
                { sql = "insert into tbbusiness(idtypebusiness) values (6)"; }
                if (rdotypebuorther.Checked == true)//from cus
                { sql = "insert into tbbusiness(idtypebusiness,businessremak) values (7,'" + txttypebuorther.Text + "')"; }

                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();

                string sql2 = "select MAX(idbusiness) AS idmax FROM tbbusiness";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();
                DR2.Read();
                //SELECT     MAX(idaddress) AS maxidquatypecom FROM tbquacompany
                {
                    idbusiness = Convert.ToInt32(DR2["idmax"].ToString().Trim());
                }
                DR2.Close();

                if (idbusiness != 0)
                { idsave = 1; }
                CN.Close();
            }
        }
        
        private void savemedia()
        {
            if (rdofromcus.Checked == true
                || rdofederation.Checked == true
                || rdofromgoogle.Checked == true
                || rdofromnewpaper.Checked == true
                || rdoorthermedia.Checked == true)
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open(); string sql = "";

                if (rdofromcus.Checked == true)//from cus
                { sql = "insert into tbmedia(idtypemedia) values (1)"; }
                if (rdofederation.Checked == true)//from cus
                { sql = "insert into tbmedia(idtypemedia) values (2)"; }
                if (rdofromfriend.Checked == true)//from cus
                { sql = "insert into tbmedia(idtypemedia) values (3)"; }
                if (rdofromgoogle.Checked == true)//from cus
                { sql = "insert into tbmedia(idtypemedia) values (4)"; }
                if (rdofromnewpaper.Checked == true)//from cus
                { sql = "insert into tbmedia(idtypemedia) values (5)"; }
                if (rdoorthermedia.Checked == true)//from cus
                { sql = "insert into tbmedia(idtypemedia,remark) values (6,'" + txtorthermedia.Text + "')"; }

                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();

                string sql2 = "select MAX(idmedia) AS idmax FROM tbmedia";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();
                DR2.Read();
                //SELECT     MAX(idaddress) AS maxidquatypecom FROM tbquacompany
                {
                    idmedia = Convert.ToInt32(DR2["idmax"].ToString().Trim());
                }
                DR2.Close();

                if (idmedia != 0)
                { idsave = 1; }
                CN.Close();
            }
           
        }

        private void quatorofpastbill()
        {
            if (rdopastbilafsendproduct.Checked == true
                || rdopastbillaf7day.Checked == true
                || rdopastbillaf15day.Checked == true
                || rdopastbillaf30day.Checked == true)
            {
                idsave = 1;
            }
            if (rdopastbilafsendproduct.Checked == true)//pase bill of send pro now
            {
                idquaterpastbill = 1;
            }
            if (rdopastbillaf7day.Checked == true)//pase bill of 7 day
            {
                idquaterpastbill = 2;
            }
            if (rdopastbillaf15day.Checked == true)//pase bill of 15 day
            {
                idquaterpastbill = 3;
            }
            if (rdopastbillaf30day.Checked == true)//pase bill of 30 day
            {
                idquaterpastbill = 4;
            }
        }

        private void savetimeofpastbill()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql = "insert into tbtimepastbill(idday,idtimebill) values (" + cbbillday.SelectedValue.ToString() + "," + cbbillhour.SelectedValue.ToString() + ")";            

            SqlCommand CM = new SqlCommand(sql, CN);
            CM.ExecuteNonQuery();

            string sql2 = "select MAX(idtimepastbill) AS idmax FROM tbtimepastbill";
            SqlCommand CM2 = new SqlCommand(sql2, CN);
            SqlDataReader DR2 = CM2.ExecuteReader();
            DR2.Read();
            //SELECT     MAX(idaddress) AS maxidquatypecom FROM tbquacompany
            {
                if (DR2["idmax"].ToString() != null)
                {
                    idtimepastbil = Convert.ToInt32(DR2["idmax"].ToString());
                }
            }
            DR2.Close();

            if (idtimepastbil != 0)
            { idsave = 1; }
            CN.Close();
        }

        private void savetypeofpayment()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); string sql = "";

            if (rdocheqe.Checked == true) //save type check and get idmax  
            {
                sql = "insert into tbtypeofpayment(idformatpayment,idtimebill) values (1,'" + cbhourcheqe.SelectedValue.ToString() + "')";
            }
            if (rdotranfer.Checked == true)//save tyep tranfer and get idmax
            {
                sql = "insert into tbtypeofpayment(idformatpayment,iddate) values (2,'" + cbdateofmount.SelectedValue.ToString() + "')";
            }

            SqlCommand CM = new SqlCommand(sql, CN);
            CM.ExecuteNonQuery();
            string sql2 = "select MAX(idtypeofpayment) AS idmax FROM tbtypeofpayment";
            SqlCommand CM2 = new SqlCommand(sql2, CN);
            SqlDataReader DR2 = CM2.ExecuteReader();
            DR2.Read();
            //SELECT     MAX(idaddress) AS maxidquatypecom FROM tbquacompany
            {
                idtypeofpayment = Convert.ToInt32(DR2["idmax"].ToString().Trim());
            }
            DR2.Close();

            if (idtypeofpayment != 0)
            { idsave = 1; }
            CN.Close();
        }

        private void savetypecompany()//บันทึกประเภทการประกอบการ
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sdate = dtpstartcard.Value.Day.ToString();
            string smonth = dtpstartcard.Value.Month.ToString();
            string syear = dtpstartcard.Value.Year.ToString();
            string stime = smonth + "/" + sdate + "/" + syear;

            string edate = dtpexpirecard.Value.Day.ToString();
            string emonth = dtpexpirecard.Value.Month.ToString();
            string eyear = dtpexpirecard.Value.Year.ToString();
            string etime = emonth + "/" + edate + "/" + eyear;

            if (rdocompany.Checked == true)
            {
                string sql = "insert into tbquacompany(serailno,snofprovice,namesn,idquatypecom) values ('" + txtnocompany.Text + "','" + txtnocert.Text + "','" + txtnamecert.Text + "'," + 1 + ")";

                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();
            }
            if (rdoperson.Checked == true)
            {
                string sql = "insert into tbquacompany(serailno,snofprovice,cardstartdate,cardexpiredate,idquatypecom) values ('" + txtnocard.Text + "','" + txtwhereoutcard.Text + "','" + stime + "','" + etime + "'," + 2 + ")";

                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();
            }

            string sql2 = "select MAX(idquacompany) AS maxidquatypecom FROM tbquacompany";
            SqlCommand CM2 = new SqlCommand(sql2, CN);
            SqlDataReader DR2 = CM2.ExecuteReader();
            DR2.Read();
            //SELECT     MAX(idaddress) AS maxidquatypecom FROM tbquacompany
            {
                idtypecomqua =Convert.ToInt32(DR2["maxidquatypecom"].ToString().Trim());               
            }
            DR2.Close();

            if (idtypecomqua != 0)
            { idsave = 1; }
            CN.Close();
        }     

        
        private void rdocompany_CheckedChanged(object sender, EventArgs e)
        {
            if (rdocompany.Checked == true)
            {
                gbcompany.Enabled = true;
                gbperson.Enabled = false;
            }
        }

        private void rdoperson_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoperson.Checked == true)
            {
                gbperson.Enabled = true;
                gbcompany.Enabled = false;
            }
           
        }

        private void btnserchemp_Click(object sender, EventArgs e)
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
                    txtnameemp.Text = DR1["empname"].ToString().Trim();
                }
                DR1.Close();
            }
            CN.Close();
        }  
      
        private void rdoorthermedia_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoorthermedia.Checked == true)
            { txtorthermedia.ReadOnly = false; }
            else
            { txtorthermedia.Clear(); txtorthermedia.ReadOnly = true; }
        }

        private void rdotypebuorther_CheckedChanged(object sender, EventArgs e)
        {
            if (rdotypebuorther.Checked == true)
            { txttypebuorther.ReadOnly = true; }
            else
            { txttypebuorther.Clear(); txttypebuorther.ReadOnly = false; }
        }

        private void txtmoneycredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((e.KeyChar < 48 || e.KeyChar > 57 || e.KeyChar == 47) && e.KeyChar != 13 && e.KeyChar != 8)
            //{
            //    MessageBox.Show("ป้อนได้แต่ตัวเลขเท่านั้น", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    e.Handled = true;
            //}
            //else if (e.KeyChar == 13)
            //{
            //    if (txtmoneycredit.Text != "")
            //    {
            //        Decimal weigthfirst = Convert.ToDecimal(txtmoneycredit.Text);
            //        if (weigthfirst == 0)
            //        {
            //            MessageBox.Show("ค่าห้ามเป็นศูนย์ค่ะ", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            txtmoneycredit.Focus();
            //        }
            //        //decimal weigthbf = Convert.ToInt32(txtweigthkk.Text);
            //        txtmoneycredit.Text = weigthfirst.ToString("#,###.#0");
            //        cbtypevat.Focus();
            //    }
            }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            //Frmcomquatation fcomqtt = new Frmcomquatation();
            //fcomqtt.idsearch = 1;
            //fcomqtt.ShowDialog();

            //if (fcomqtt.idcom != 0)
            //{
            //    //search address contact
            //    string sql1 = "select * from vscomquatation where idaddress='" + fcomqtt.idcom + "' and idtypeaddress = 2";
            //    SqlCommand CM1 = new SqlCommand(sql1, CN);
            //    SqlDataReader DR1 = CM1.ExecuteReader();

            //    DR1.Read();
            //    {
            //        idaddcontact =Convert.ToInt32(DR1["idaddress"].ToString().Trim());
            //        txtnamcusth.Text = DR1["namecus"].ToString().Trim();
            //        txtconno.Text = DR1["addno"].ToString().Trim();
            //        txtconroad.Text = DR1["addroad"].ToString().Trim();
            //        txtcontum.Text = DR1["addtumb"].ToString().Trim();
            //        txtconvilage.Text = DR1["addvilage"].ToString().Trim();
            //        txtconprovice.Text = DR1["addprovice"].ToString().Trim();
            //        txtconzipcode.Text = DR1["addzipcode"].ToString().Trim();
            //        txtcontel.Text = DR1["addtel"].ToString().Trim();
            //        txtconfax.Text = DR1["addfax"].ToString().Trim();
            //        txtconcontact.Text = DR1["addnamecontace"].ToString().Trim();
            //        txtconremark.Text = DR1["addremark"].ToString().Trim();
            //        idqua = DR1["idqua"].ToString().Trim();
            //        idpro = Convert.ToInt16(DR1["idpro"].ToString().Trim());
            //        price = Convert.ToDecimal(DR1["priceperunit"].ToString().Trim());
            //    }
            //    DR1.Close();


                //search address send product
                string sql2 = "select * from vscomquatation where idqua='" + idqua + "' and idtypeaddress = 3";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();

                DR2.Read();
                {
                    idaddsendproduct =Convert.ToInt32(DR2["idaddress"].ToString().Trim());
                    txtsendproname.Text = DR2["namecus"].ToString().Trim();
                    txtsendprono.Text = DR2["addno"].ToString().Trim();
                    txtsendproroad.Text = DR2["addroad"].ToString().Trim();
                    txtsendprotum.Text = DR2["addtumb"].ToString().Trim();
                    txtsendprovilage.Text = DR2["addvilage"].ToString().Trim();
                    txtsendproprovice.Text = DR2["addprovice"].ToString().Trim();
                    txtsendprozipcode.Text = DR2["addzipcode"].ToString().Trim();
                    txtsendprotel.Text = DR2["addtel"].ToString().Trim();
                    txtsendprocontact.Text = DR2["addnamecontace"].ToString().Trim();
                }
                DR2.Close();
            

            CN.Close();
        }

        private void rdousecontact_CheckedChanged(object sender, EventArgs e)
        {
            idaddcertcom = idaddcontact;
        }

        private void rdousesenproduct_CheckedChanged(object sender, EventArgs e)
        {
            idaddcertcom = idaddsendproduct;
        }

        private void rdousesendbill_CheckedChanged(object sender, EventArgs e)
        {
            idaddcertcom = idaddsendbill;
        }

        private void rdobillnewadd_CheckedChanged(object sender, EventArgs e)
        {//ntewsave
            idaddsendbill = 0;
            txtsendbillname.Clear();
            txtsendbillno.Clear();
            txtsendbillroad.Clear();
            txtsendbilltum.Clear();
            txtsendbillvilage.Clear();
            txtsendbillprovice.Clear();
            txtsendbillzipcode.Clear();
            txtsendbillcontact.Clear();
            txtsendbilltel.Clear();
            txtsendbillfax.Clear();
        }

        private void rdobilluseaddcontact_CheckedChanged(object sender, EventArgs e)
        {
            idaddsendbill = idaddcontact;
            txtsendbillname.Text = txtnamcusth.Text;
            txtsendbillno.Text = txtconno.Text;
            txtsendbillroad.Text = txtconroad.Text;
            txtsendbilltum.Text = txtcontum.Text;
            txtsendbillvilage.Text = txtconvilage.Text;
            txtsendbillprovice.Text = txtconprovice.Text;
            txtsendbillzipcode.Text = txtconzipcode.Text;
            txtsendbilltel.Text = txtcontel.Text;
            txtsendbillfax.Text = txtconfax.Text;
            txtsendbillcontact.Text = txtconcontact.Text;
        }

        private void rdobilluseaddsendproduct_CheckedChanged(object sender, EventArgs e)
        {
            idaddsendbill = idaddsendproduct;
            txtsendbillname.Text = txtsendproname.Text;
            txtsendbillno.Text = txtsendprono.Text;
            txtsendbillroad.Text = txtsendproroad.Text;
            txtsendbilltum.Text = txtsendprotum.Text;
            txtsendbillvilage.Text = txtsendprovilage.Text;
            txtsendbillprovice.Text = txtsendproprovice.Text;
            txtsendbillzipcode.Text = txtsendprozipcode.Text;
            txtsendbilltel.Text = txtsendprotel.Text;
            txtsendbillcontact.Text = txtsendprocontact.Text;
        }

        private void cbunitcreditday_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbunitcreditday.SelectedIndex == 0)
            {
                idformatpayment = 2;//credit of 7 day
            }
            if (cbunitcreditday.SelectedIndex == 1)
            {
                idformatpayment = 3;//credit of 15 day
            }
            if (cbunitcreditday.SelectedIndex == 2)
            {
                idformatpayment = 4;//credit of 30 day
            }
        }

        private void rdocheqe_CheckedChanged(object sender, EventArgs e)
        {
            if (rdocheqe.Checked == true)
            {
                cbdateofmount.Enabled = false;
                cbhourcheqe.Enabled = true;
            }
        }

        private void rdotranfer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdotranfer.Checked == true)
            {
                cbdateofmount.Enabled = true;
            }
        }

        
       
        private void cbbillday_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbillday.Text != "")
            {
                cbbillhour.Enabled = true;
            }
        }

        private void rdosenduseaddcontact_CheckedChanged(object sender, EventArgs e)
        {
            idaddsendproduct = idaddcontact;
        }

        private void rdofromnewpaper_CheckedChanged(object sender, EventArgs e)
        {
            if (rdofromnewpaper.Checked == true)
            {
                txtorthermedia.ReadOnly = true;
            }
        }

        private void rdofromgoogle_CheckedChanged(object sender, EventArgs e)
        {
            if (rdofromgoogle.Checked == true)
            {
                txtorthermedia.ReadOnly = true;
            }
        }

        private void rdofromfriend_CheckedChanged(object sender, EventArgs e)
        {
            if (rdofromfriend.Checked == true)
            {
                txtorthermedia.ReadOnly = true;
            }
        }

        private void rdofromcus_CheckedChanged(object sender, EventArgs e)
        {
            if (rdofromcus.Checked == true)
            {
                txtorthermedia.ReadOnly = true;
            }
        }

        private void rdofederation_CheckedChanged(object sender, EventArgs e)
        {
            if (rdofederation.Checked == true)
            {
                txtorthermedia.ReadOnly = true;
            }
        }

        private void rdosendnewadd_CheckedChanged(object sender, EventArgs e)
        {

        }     
        
        
    }
}