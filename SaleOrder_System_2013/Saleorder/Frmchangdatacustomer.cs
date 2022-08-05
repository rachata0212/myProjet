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
    public partial class Frmchangdatacustomer : Form
    {
        public Frmchangdatacustomer()
        {
            InitializeComponent();
        }

        public int idhistory = 0; string idqua = ""; DataSet ds = new DataSet();
        int idtypeaddress = 0;
        int idaddcert = 0;
        int idquacompany = 0;
        int idaddcontact = 0;
        int idaddsendproduct = 0;
        int idbusiness = 0;
        int idmedia = 0;
        int idtypevat = 0;
        int idformatofpayment = 0;
        int idquaterpastbill = 0;
        int idtimepastbill = 0;
        int idtypeofpayment = 0;
        string idsale = "";
        string idoldchang = "";
        string idnewchang = "";
        string oldnamechang = "";
        string newnamechang = "";
        int idbilldaynew = 0;
        int idbilltimenew = 0;
        int idbilldayold = 0;
        int idbilltimeold = 0;
        string billdaynamenew = "";
        string billdaynameold = "";
        string billtimenamenew = "";
        string billtimenameold = "";
        int iddatetranfer = 0;
        string oldnametime = "";
        string oldnamedate = "";
        int oldidtime = 0;
        int oldiddate = 0;
        string newnametime = "";
        string newnamedate = "";
        public int idedit = 0;


        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frmchangdatacustomer_Load(object sender, EventArgs e)
        {
            txtdate.Text = DateTime.Now.ToShortDateString();           
            disableallgroupbox();

            if (idedit == 1)//new
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();
                btnsearch.Enabled = false;
                loaddata();                
                loadcreditday(CN);
                    loadbillday(CN);
                    loadbilltime(CN);
                    loadcreditofmount(CN);
                    loadcredittime(CN);
                    loadvat(CN);
                    CN.Close();
            }
            else // edit
            {
                //SqlConnection CN = new SqlConnection();
                //CN.ConnectionString = Program.urldb;
                //CN.Open();

               
            }
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


        private void loaddata()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (idhistory != 0)
            {
                string sql1 = "select * from tbhistorycustomer where idhistorycus = " + idhistory + " ";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    txtnamecus.Text = DR1["namecusth"].ToString().Trim();
                    try
                    {
                        idformatofpayment = Convert.ToInt16(DR1["idformatofpayment"].ToString().Trim());
                        idaddcert = Convert.ToInt16(DR1["idaddcert"].ToString().Trim());
                        idquacompany = Convert.ToInt16(DR1["idquacompany"].ToString().Trim());
                        idaddcontact = Convert.ToInt16(DR1["idaddcontact"].ToString().Trim());
                        idaddsendproduct = Convert.ToInt16(DR1["idaddsendproduct"].ToString().Trim());
                        idbusiness = Convert.ToInt16(DR1["idbusiness"].ToString().Trim());
                        idmedia = Convert.ToInt16(DR1["idmedia"].ToString().Trim());
                        idtypevat = Convert.ToInt16(DR1["idtypevat"].ToString().Trim());
                        idquaterpastbill = Convert.ToInt16(DR1["idquaterpastbill"].ToString().Trim());
                        idtimepastbill = Convert.ToInt16(DR1["idtimepastbill"].ToString().Trim());
                        idtypeofpayment = Convert.ToInt16(DR1["idtypeofpayment"].ToString().Trim());
                        idsale = DR1["idsale"].ToString().Trim();
                    }
                    catch { }
                }
                DR1.Close();
            }
            CN.Close();
        }

        private void ClearTextboxaddress()
        {
            txtno.Clear();
            txtroad.Clear();
            txttum.Clear();
            txtvilage.Clear();
            txtprovice.Clear();
            txtzipcode.Clear();
            txttel.Clear();
            txtfax.Clear();
            txtremark.Clear();
        }

        private void DisableTextboxaddress()
        {
            txtno.Enabled = false;
            txtroad.Enabled = false;
            txttum.Enabled = false;
            txtvilage.Enabled = false;
            txtprovice.Enabled = false;
            txtzipcode.Enabled = false;
            txttel.Enabled = false;
            txtfax.Enabled = false;
            txtremark.Enabled = false;
        }

        private void EnableTextboxaddress()
        {
            txtno.Enabled = true;
            txtroad.Enabled = true;
            txttum.Enabled = true;
            txtvilage.Enabled = true;
            txtprovice.Enabled = true;
            txtzipcode.Enabled = true;
            txttel.Enabled = true;
            txtfax.Enabled = true;
            txtremark.Enabled = true;
        }


        private void disableallgroupbox()
        {
            Pnaddress.Visible = false;
            gbtimepastbill.Enabled = false;
            gbtypepayment.Enabled = false;
            gbpayment.Enabled = false;
            gbquaterpastbill.Enabled = false;
            gbcontact.Enabled = false;
            btnsale.Enabled = false;
            txtnewcontact.Clear();
            txtoldcontact.Clear();
        }


        private void Loadcreditday()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql1 = "select * from tbformatofpayment";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(ds, "typepayment");
            cbunitcreditday.DataSource = ds.Tables["typepayment"];
            cbunitcreditday.DisplayMember = "namepayment";
            cbunitcreditday.ValueMember = "idformatofpayment";
            CN.Close();
        }
        private void Loadtypepayment()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql4 = "select * from tbday";
            SqlDataAdapter da4 = new SqlDataAdapter(sql4, CN);
            da4.Fill(ds, "billday");
            cbbillday.DataSource = ds.Tables["billday"];
            cbbillday.DisplayMember = "nameday";
            cbbillday.ValueMember = "idday";

            string sql5 = "select * from tbtimerecivebill";
            SqlDataAdapter da5 = new SqlDataAdapter(sql5, CN);
            da5.Fill(ds, "billtime");
            cbbillhour.DataSource = ds.Tables["billtime"];
            cbbillhour.DisplayMember = "namtime";
            cbbillhour.ValueMember = "idtimebill";
            CN.Close();
        }

        private void LoadCheqeandtranfer()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql4 = "select * from tbtimerecivebill";
            SqlDataAdapter da4 = new SqlDataAdapter(sql4, CN);
            da4.Fill(ds, "billchecqe");
            cbhourcheqe.DataSource = ds.Tables["billchecqe"];
            cbhourcheqe.DisplayMember = "namtime";
            cbhourcheqe.ValueMember = "idtimebill";

            string sql5 = "select * from tbdate";
            SqlDataAdapter da5 = new SqlDataAdapter(sql5, CN);
            da5.Fill(ds, "billdate");
            cbdateofmount.DataSource = ds.Tables["billdate"];
            cbdateofmount.DisplayMember = "namedate";
            cbdateofmount.ValueMember = "iddate";
            CN.Close();
        }

        private void LoadaddressCus()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            int count = 0;

            string sql1 = "select  COUNT(idqua) AS countidqua from tbaddresscompany where idqua='" + idqua + "' and idtypeaddress=" + idtypeaddress + " ";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                count = Convert.ToInt16(DR1["countidqua"].ToString().Trim());
            }
            DR1.Close();

            if (count != 0)
            {
                if (idhistory != 0)
                {
                    string sql2 = "select * from tbaddresscompany where idqua='" + idqua + "' and idtypeaddress=" + idtypeaddress + " ";
                    //SqlCommand CM2 = new SqlCommand(sql2, CN);
                    //SqlDataReader DR2 = CM2.ExecuteReader();
                    ds.Clear();
                    SqlDataAdapter da = new SqlDataAdapter(sql2, CN);
                    da.Fill(ds, "vscomhis");
                    dtgaddressold.DataSource = ds.Tables["vscomhis"];
                }
            }
            CN.Close();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            //Frmcomquatation fcomqtt = new Frmcomquatation();
            //fcomqtt.idsearch = 2;
            //fcomqtt.ShowDialog();
            //idhistory = fcomqtt.idcom;
            //    if (fcomqtt.idcom == idtypeaddress) { ClearTextboxaddress(); }           
            loaddata();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string date = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string datetime = month + "/" + date + "/" + year;


            MessageBox.Show("ปรับปรุงข้อมูลเรียบร้อย !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CN.Close();
            this.Close();
        }

        int idmaxaddress = 0;
        private void InsertNewaddress()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            int idtypeadd = 0;

            string sql2 = "insert into tbaddresscompany(addno,addroad,addtumb,addvilage,addprovice,addzipcode,addnamecontace,addtel,addfax,idtypeaddress,idqua) values ('" + txtno.Text + "','" + txtroad.Text + "','" + txttum.Text + "','" + txtvilage.Text + "','" + txtprovice.Text + "','" + txtzipcode.Text + "','" + txtremark.Text + "','" + txttel.Text + "','" + txtfax.Text + "'," + idtypeadd + ",'" + idqua + "')";
            SqlCommand CM2 = new SqlCommand(sql2, CN);
            CM2.ExecuteNonQuery();

            string sql1 = "select  MAX(idaddress)AS idamx from tbaddresscompany";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            SqlDataReader DR1 = CM1.ExecuteReader();
            DR1.Read();
            { idmaxaddress = Convert.ToInt16(DR1["idamx"].ToString().Trim()); }
            DR1.Close();
            CN.Close();
        }

        private void rdotypecreditmoney_CheckedChanged(object sender, EventArgs e)
        {
            cbunitcreditday.Enabled = true;
        }

        private void rdocheqe_CheckedChanged(object sender, EventArgs e)
        {
            if (rdocheqe.Checked == true)
            {
                //idnewchang = "1";
                cbhourcheqe.Enabled = true;
                cbdateofmount.Enabled = false;
            }
        }

        private void rdotranfer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdotranfer.Checked == true)
            {
                cbdateofmount.Enabled = true;
                cbhourcheqe.Enabled = false;
            }
        }

        private void cbhourcheqe_SelectedIndexChanged(object sender, EventArgs e)
        {
            newnametime = cbhourcheqe.Text;
            //idtimepastbill=Convert.ToInt16(cbhourcheqe.SelectedItem.ToString());
        }

        private void cbdateofmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            newnamedate = cbdateofmount.Text;
            //iddatetranfer = Convert.ToInt16(cbdateofmount.SelectedValue.ToString());
        }

        private void btnsale_Click(object sender, EventArgs e)
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
                    txtnewcontact.Text = DR1["empname"].ToString().Trim();
                }
                DR1.Close();
            }
            CN.Close();
        }

        private void cbunitcreditday_SelectedIndexChanged(object sender, EventArgs e)
        {
            idnewchang = cbunitcreditday.SelectedValue.ToString();
            newnamechang = cbunitcreditday.Text;
        }

        private void cbbillday_SelectedIndexChanged(object sender, EventArgs e)
        {
            idnewchang = cbbillday.SelectedValue.ToString();
            billdaynamenew = cbbillday.Text;
        }

        private void cbbillhour_SelectedIndexChanged(object sender, EventArgs e)
        {
            idnewchang = cbbillhour.SelectedValue.ToString();
            billtimenamenew = cbbillhour.Text;
        }

        private void rdopastbilafsendproduct_CheckedChanged(object sender, EventArgs e)
        {
            idnewchang = "1";
            newnamechang = rdopastbilafsendproduct.Text;
        }

        private void rdopastbillaf7day_CheckedChanged(object sender, EventArgs e)
        {
            idnewchang = "2";
            newnamechang = rdopastbillaf7day.Text;
        }

        private void rdopastbillaf15day_CheckedChanged(object sender, EventArgs e)
        {
            idnewchang = "3";
            newnamechang = rdopastbillaf15day.Text;
        }

        private void rdopastbillaf30day_CheckedChanged(object sender, EventArgs e)
        {
            idnewchang = "4";
            newnamechang = rdopastbillaf30day.Text;
        }

        private void cbaddressnew_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnsearchadd_Click(object sender, EventArgs e)
        {

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


    }
}