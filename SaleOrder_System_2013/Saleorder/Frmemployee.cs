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
    public partial class Frmemployee : Form
    {
        public Frmemployee()
        {
            InitializeComponent();
        }

        public string idemp = "0"; 
        public int status = 0; 
        string msnfrom = ""; 
        int idtypelog = 0;

        string idcom = "";
        string iddep = "";
        string idtype = "";
        string idposition = "";
        string datelog = DateTime.Now.Day.ToString();
        string monthlog = DateTime.Now.Month.ToString();
        string yearlog = DateTime.Now.Year.ToString();


        private void btnserchcom_Click(object sender, EventArgs e)
        {
            Frmserch fs = new Frmserch();
            fs.sname = "";
            fs.sname = "sempcom";
            fs.ShowDialog();
            idcom = fs.returnid;

            if (idcom != "")
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();
                string sql = "select * from vcompany where idcom='" + idcom + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                DR.Read();
                {
                    idcom = DR["idcom"].ToString();
                    txtnamecom.Text = DR["cname"].ToString();
                    txtbranch.Text = DR["bname"].ToString();
                }
                DR.Close();
            }
        }
        
        string id = "0";
        private void btnserchdep_Click(object sender, EventArgs e)
        {
            Frmserch fs = new Frmserch();
            fs.sname = "";
            fs.sname = "sdep";
            fs.ShowDialog();
            iddep = fs.returnid;

            if (iddep != "0" && iddep != "")
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();
                string sql = "select * from vdepartment where iddep='" + iddep + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                DR.Read();
                { txtnamedep.Text = DR["depname"].ToString(); }
                DR.Close();
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnserchtype_Click(object sender, EventArgs e)
        {
            Frmserch fs = new Frmserch();
            fs.sname = "";
            fs.sname = "stypeemp";
            fs.ShowDialog();
            idtype = fs.returnid;

            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (idtype != "")
            {
                string sql = "select * from vemptype where idemptype='" + idtype + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                DR.Read();
                { txtnametype.Text = DR["nametype"].ToString(); }
                DR.Close();
            }

        }

        private void Frmemployee_Load(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (status != 0)//ถ้ารับค่าเท่ากับ 1 จะทำการอัพเดต
            {
                string sql = "select * from tbemployee where idemp='" + idemp + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                DR.Read();
                {
                    txtid.Text = DR["idemp"].ToString().Trim();
                    txtname.Text = DR["empname"].ToString().Trim();
                    txtsurname.Text = DR["empsur"].ToString().Trim();
                    txttel.Text = DR["emptel"].ToString().Trim();
                    txtexi.Text = DR["empexit"].ToString().Trim();
                    txtmobile.Text = DR["empmobile"].ToString().Trim();
                    txtuid.Text = DR["uid"].ToString().Trim();
                    txtpwd.Text = DR["pwd"].ToString().Trim();
                    txtremark.Text = DR["remark"].ToString().Trim();
                    iddep = DR["iddep"].ToString().Trim();
                    idcom = DR["idcom"].ToString().Trim();
                    idtype = DR["idemptype"].ToString().Trim();
                    idposition = DR["idposition"].ToString().Trim();
                }
                DR.Close();

                //-------------------------------

                string sql1 = "select * from tbdepartment where iddep='" + iddep + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    txtnamedep.Text = DR1["depname"].ToString();
                }
                DR1.Close();

                //--------------------------------------------

                string sql2 = "select * from vemptype where idemptype='" + idtype + "'";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();

                DR2.Read();
                {
                    txtnametype.Text = DR2["nametype"].ToString();
                }
                DR2.Close();

                //-------------------------------------------------

                string sql3 = "select * from vcompany where idcom='" + idcom + "'";
                SqlCommand CM3 = new SqlCommand(sql3, CN);
                SqlDataReader DR3 = CM3.ExecuteReader();

                DR3.Read();
                {
                    txtnamecom.Text = DR3["cname"].ToString();
                    txtbranch.Text = DR3["bname"].ToString();
                }
                DR3.Close();

                if (idposition != "")
                {
                    string sql4 = "select * from tbempposition where idposition='" + idposition + "'";
                    SqlCommand CM4 = new SqlCommand(sql4, CN);
                    SqlDataReader DR4 = CM4.ExecuteReader();

                    DR4.Read();
                    { txtpositon.Text = DR4["positionname"].ToString(); }
                    DR4.Close();
                }
            }

            else   //insert into
            {
                string sql3 = "select * from tbemployee ORDER BY idempauto DESC";
                SqlCommand CM3 = new SqlCommand(sql3, CN);
                SqlDataReader DR3 = CM3.ExecuteReader();

                DR3.Read();
                {
                    txtid.Text = DR3["idemp"].ToString();
                }
                DR3.Close();

                txtid.SelectionStart = 2;
                txtid.SelectionLength = 5;
                int run = 1 + Convert.ToInt16(txtid.SelectedText.ToString());

                txtid.Text = "EM" + string.Format("{0:000}", run);

            }

            msnfrom = this.Name.ToString();
            idtypelog = 7;//open
            Savelogevent();
        }

        private void btnaddedit_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (status != 0)//ถ้ารับค่าไม่เท่ากับ 0 จะอัพเดท
            {
                string sql = "update tbemployee set empname='" + txtname.Text.Trim() + "',empsur='" + txtsurname.Text.Trim() + "',emptel='" + txttel.Text + "',empexit='" + txtexi.Text + "',empmobile='" + txtmobile.Text + "',uid='" + txtuid.Text + "',pwd='" + txtpwd.Text + "',remark='" + txtremark.Text + "',iddep=" + iddep + ",idemptype=" + idtype + ",idcom='" + idcom + "',idposition = '" + idposition + "' Where idemp= '" + txtid.Text + "'";

                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();

                MessageBox.Show("ข้อมูลทำการปรับปรุงแล้ว ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                msnfrom = this.Name.ToString();
                idtypelog = 2;//update
                Savelogevent();
                this.Close();
            }

            if (status == 0)
            {
                string sqla = "insert into tbemployee (idemp,empname,empsur,emptel,empexit,empmobile,uid,pwd,isemp,remark,iddep,idemptype,idcom,idposition) values ('" + txtid.Text + "','" + txtname.Text + "','" + txtsurname.Text + "','" + txttel.Text + "','" + txtexi.Text + "','" + txtmobile.Text + "','" + txtuid.Text + "','" + txtpwd.Text + "'," + 0 + ",'" + txtremark.Text + "'," + iddep + "," + idtype + ",'" + idcom + "','" + idposition + "')";

                SqlCommand CMa = new SqlCommand(sqla, CN);
                CMa.ExecuteNonQuery();

                string sqlb = "insert into tbemail (emailname,idemp values ('-','" + txtid.Text + "')";
                SqlCommand CMb = new SqlCommand(sqlb, CN);
                CMb.ExecuteNonQuery();

                MessageBox.Show("ข้อมูลทำการเพิ่มแล้ว ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                msnfrom = this.Name.ToString();
                idtypelog = 1;//insert
                Savelogevent();
                this.Close();

            }
            CN.Close();
        }

        private void btnexit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Savelogevent()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string selectdatelog = monthlog + "/" + datelog + "/" + yearlog;
            string sql1 = "insert into tblog(logname,datein,timein,idtypelog,idemp,remark) values('" + msnfrom + "','" + selectdatelog + "','" + DateTime.Now.ToLongTimeString() + "'," + idtypelog + ",'" + Program.empID + "','" + idemp + "')";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            CM1.ExecuteNonQuery();
            CN.Close();
        }

        private void Frmemployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            msnfrom = this.Name.ToString();
            idtypelog = 6;//close
            Savelogevent();
        }

        private void btnposition_Click(object sender, EventArgs e)
        {
            Frmserch fs = new Frmserch();
            fs.sname = "";
            fs.sname = "sposition";
            fs.ShowDialog();
            idposition = fs.returnid;

            if (idposition != "0" && idposition != "")
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();
                string sql = "select * from vposition where idposition='" + idposition + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                DR.Read();
                {
                    txtpositon.Text = DR["positionname"].ToString();                    
                }
                DR.Close();
                CN.Close();
            }
        }
    }
}









