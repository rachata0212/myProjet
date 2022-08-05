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
    public partial class Frmcar : Form
    {
        public Frmcar()
        {
            InitializeComponent();
        }

        public int idcar = 0; 
        string msnfrom = ""; 
        int idtypelog = 0; 
        public int idstatus = 0;
        string datelog = DateTime.Now.Day.ToString();
        string monthlog = DateTime.Now.Month.ToString();
        string yearlog = DateTime.Now.Year.ToString();

        private void btnaddedit_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (idstatus != 0)
            {
                string sql = "update tbcar set carname='" + txtnamecar.Text + "',carunit='" + txtsizecar.Text + "',carremark='" + txtremark.Text + "'Where idcar= " + txtidcar.Text + "";
                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();                

                MessageBox.Show("ข้อมูลทำการปรับปรุงแล้ว ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

                msnfrom = this.Name.ToString();
                idtypelog = 2;//update
                Savelogevent();

            }

            else if (idstatus == 0)
            {

                    string sqla = "insert into tbcar(carname,carunit,carremark) values ('" + txtnamecar.Text + "','" + txtsizecar.Text + "','" + txtremark.Text + "')";

                    SqlCommand CMa = new SqlCommand(sqla, CN);
                    CMa.ExecuteNonQuery();

                    MessageBox.Show("บันทึกข้อมูลประสบความสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                    msnfrom = this.Name.ToString();
                    idtypelog = 1;//insert
                    Savelogevent();
            }
            CN.Close();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frmcar_Load(object sender, EventArgs e)
        {
            if (idstatus != 0)//ถ้าไม่เท่ากับ 0 ให้สร้างใหม่
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();
                string sql = "select * from tbcar where idcar='" + idcar + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                DR.Read();
                {
                    txtidcar.Text = DR["idcar"].ToString();
                    txtnamecar.Text = DR["carname"].ToString();
                    txtsizecar.Text = DR["carunit"].ToString();
                    txtremark.Text = DR["carremark"].ToString();
                }
                DR.Close();
                CN.Close();
            }

            msnfrom = this.Name.ToString();
            idtypelog = 7;//open
            Savelogevent();
        }

        private void Savelogevent()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string selectdatelog = monthlog + "/" + datelog + "/" + yearlog;
            string sql1 = "insert into tblog(logname,datein,timein,idtypelog,idemp,remark) values('" + msnfrom + "','" + selectdatelog + "','" + DateTime.Now.ToLongTimeString() + "'," + idtypelog + ",'" + Program.empID + "','" + idcar + "')";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            CM1.ExecuteNonQuery();
            CN.Close();
        }

        private void Frmcar_FormClosed(object sender, FormClosedEventArgs e)
        {
            msnfrom = this.Name.ToString();
            idtypelog = 6;//close
            Savelogevent();
        } 

    }
}