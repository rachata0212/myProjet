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
    public partial class Frmproduct : Form
    {
        public Frmproduct()
        {
            InitializeComponent();
        }

        public string proname = "";
        public int status = 0; 
        public string strx = ""; 
        int idpro = 0; 
        string msnfrom = ""; 
        int idtypelog = 0;
        string datelog = DateTime.Now.Day.ToString();
        string monthlog = DateTime.Now.Month.ToString();
        string yearlog = DateTime.Now.Year.ToString();

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frmproduct_Load(object sender, EventArgs e)
        {
            if (status != 0)//ถ้าไม่เท่ากับ 0 ให้สร้างใหม่
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();
                string sql = "select * from vproduct where idpro='" + proname + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                DR.Read();
                {
                    txtid.Text = DR["idpro"].ToString();
                    txtname.Text = DR["proname"].ToString();
                    txtremark.Text = DR["remark"].ToString();
                }
                DR.Close();
            }

            else
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();
                string sql = "select * from vproduct ORDER BY idpro DESC";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                DR.Read();
                {
                    idpro =Convert.ToInt16(DR["idpro"].ToString());
                }
                DR.Close();

                txtid.Text = Convert.ToString(idpro + 1);
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

            if (status != 0)
            {                               
               string sql = "update tbproduct set proname='" + txtname.Text + "',remark='" + txtremark.Text + "'Where idpro= "+ txtid.Text +"" ;              
                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();
                msnfrom = this.Name.ToString();
                idtypelog = 2;//update
                Savelogevent();
                this.Close();
                MessageBox.Show("ข้อมูลทำการปรับปรุงแล้ว " , "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);               
            }

            else if (status == 0)
            {

                if (txtname.Text == "")
                {
                    MessageBox.Show("ค่าห้ามว่างค่ะ", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtname.Focus();
                }
               
                else if (txtremark.Text == "")
                {
                    MessageBox.Show("ค่าห้ามว่างค่ะ", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtremark.Focus();
                }

                else
                {                    
                    string sqla = "insert into tbproduct(proname,remark) values ('" + txtname.Text + "','" + txtremark.Text + "')";   

                    SqlCommand CMa = new SqlCommand(sqla, CN);
                    CMa.ExecuteNonQuery();

                    MessageBox.Show("บันทึกข้อมูลประสบความสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    msnfrom = this.Name.ToString();
                    idtypelog = 1;//insert
                    Savelogevent();
                    this.Close();
                }
            }
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
            string sql1 = "insert into tblog(logname,datein,timein,idtypelog,idemp,remark) values('" + msnfrom + "','" + selectdatelog + "','" + DateTime.Now.ToLongTimeString() + "'," + idtypelog + ",'" + Program.empID + "','" + idpro + "')";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            CM1.ExecuteNonQuery();
        }

        private void Frmproduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            msnfrom = this.Name.ToString();
            idtypelog = 6;//close
            Savelogevent();
        }

    }
}