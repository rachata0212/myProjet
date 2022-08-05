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
    public partial class Frmmergorder : Form
    {
        public Frmmergorder()
        {
            InitializeComponent();
        }


        public string idorder1 = "";
        public string idorder2 = "";
        string idcar = "";

        private void Frmmergorder_Load(object sender, EventArgs e)
        {
            Loadorder1();
            Loadorder2();
        }

        private void btncancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            Frmserch fs = new Frmserch();
            fs.sname = "scar";
            fs.ShowDialog();
            if (fs.returnid.Trim() != "0")
            {
                idcar = fs.returnid.Trim();
                SearchTruck();
                btnsearch.Focus();
            }
        }

        private void SearchTruck()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (idcar != "")
            {
                string sql = "select * from vcar where idcar='" + idcar + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                { txtcar.Text = DR1["carname"].ToString().Trim(); }
                DR1.Close();
            }
            CN.Close();
        }

        private void Loadorder1()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (idorder1 != "")
            {
                string sql = "select * from vsaleorder where idorder='" + idorder1 + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    richTextBox1.Text = "�Ţ���Order: " + idorder1 + Environment.NewLine + "�ѹ���Order: " + string.Format("{0:MM/dd/yyyy}", DR1["orderdate"].ToString().Trim()) + Environment.NewLine + "�١���: " + DR1["comcus"].ToString().Trim() + Environment.NewLine + "�Թ���: " + DR1["proname"].ToString().Trim() + Environment.NewLine + "��Դ������/ö: " + DR1["carname"].ToString().Trim();
                }
                DR1.Close();
            }
            CN.Close();
        }

          private void Loadorder2()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (idorder2 != "")
            {
                string sql = "select * from vsaleorder where idorder='" + idorder2 + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    richTextBox2.Text = "�Ţ���Order: " + idorder2 + Environment.NewLine + "�ѹ���Order: " + string.Format("{0:MM/dd/yyyy}", DR1["orderdate"].ToString().Trim()) + Environment.NewLine + "�١���: " + DR1["comcus"].ToString().Trim() + Environment.NewLine + "�Թ���: " + DR1["proname"].ToString().Trim() + Environment.NewLine + "��Դ������/ö: " + DR1["carname"].ToString().Trim();
                
                }
                DR1.Close();
            }
            CN.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            { groupBox2.Enabled = false; groupBox1.Enabled = true; txtremark.Text = "order ��� 2 ������� 1 ��ǧ ¡��ԡorder: " + idorder2; }
            if (radioButton2.Checked == true)
            { groupBox1.Enabled = false; groupBox2.Enabled = true; txtremark.Text = "order ��� 2 ������� 1 ��ǧ ¡��ԡorder: " + idorder1; }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string idorderselect = ""; string idordercancle = "";
            if (radioButton1.Checked == true)
            { idorderselect = idorder1; idordercancle = idorder2; }

            if (radioButton2.Checked == true)
            { idorderselect = idorder2; idordercancle = idorder1; }

            if (idcar != "")
            {
                //update
                string sql1 = "update tborder set idcar='" + idcar + "',remark1='" + txtremark.Text.Trim() + "' Where idorder= '" + idorderselect + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                CM1.ExecuteNonQuery();

                //cancle
                //update tbsale
                string sql2 = "update tborder set idstatus = 7,remark2='-' where idorder= '" + idordercancle + "'";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                CM2.ExecuteNonQuery();
                CN.Close();

                MessageBox.Show("��Ѻ��ا���������º����", "����͹!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            { MessageBox.Show("�س������кػ�����ö����ͧ������ !", "����͹!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }



    }
}