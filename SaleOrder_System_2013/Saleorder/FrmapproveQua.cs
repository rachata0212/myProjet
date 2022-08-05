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
    public partial class FrmapproveQua : Form
    {
        public FrmapproveQua()
        {
            InitializeComponent();
        }

        public string idquatation = ""; public int iduser = 0;
        private void FrmapproveQua_Load(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (iduser == 1)
            {
                lblstatus.Text = "�׹�ѹ��ʹ��Ҥ�";
                rdoapprove.Text = "�׹�ѹ��ʹ��Ҥҹ��";
                rdonoapprove.Text = "����׹�ѹ��ʹ��Ҥҹ��";
                txtidqua.Text = idquatation;
                txtremark.Text = "�觧ҹ�����䢨ҡ���¢��";
            }
            if (iduser == 2)
            {
                lblstatus.Text = "͹��ѵ���ʹ��Ҥ�";
                rdoapprove.Text = "͹��ѵ���ʹ��Ҥҹ��";
                rdonoapprove.Text = "���͹��ѵ���ʹ��Ҥҹ��";
                txtidqua.Text = idquatation;
                txtremark.Text = "�觧ҹ�����䢨ҡ���º�����";
            }

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (rdoapprove.Checked == true)
            {
                if (iduser == 1)
                {
                    string sql = "update tbquatation set idstatusqua = 2 Where idqua= '" + txtidqua.Text + "'";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();
                    MessageBox.Show("��Ѻ��ا���������º���� !", "��§ҹ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                 if (iduser == 2)
                {
                    string sql = "update tbquatation set idstatusqua = 4 Where idqua='" + txtidqua.Text + "'";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();
                    MessageBox.Show("��Ѻ��ا���������º���� !", "��§ҹ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            else if (rdonoapprove.Checked == true)
            {
                if (iduser == 1)
                {
                    string sql = "update tbquatation set idstatusqua =3,remark=" + txtremark.Text + " Where idqua='" + txtidqua.Text + "'";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();
                    MessageBox.Show("��Ѻ��ا���������º���� !", "��§ҹ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (iduser == 2)
                {
                    string sql = "update tbquatation set idstatusqua =3,remark=" + txtremark.Text + "  Where idqua='" + txtidqua.Text + "'";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();
                    MessageBox.Show("��Ѻ��ا���������º���� !", "��§ҹ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("��س��к����˵���ʹ��Ҥҷ���ͧ��� !", "��§ҹ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtremark.Focus();
            }

            CN.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdonoapprove_CheckedChanged(object sender, EventArgs e)
        {
            if (rdonoapprove.Checked == true)
            { txtremark.ReadOnly = false; }
        }

        private void rdoapprove_CheckedChanged(object sender, EventArgs e)
        {
            txtremark.ReadOnly = true;
        }
    }
}