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
    public partial class FrmapproveHistorycus : Form
    {
        public FrmapproveHistorycus()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet(); public int idstatus = 0; public int idhistorycus = 0; int autoidchang = 0;
        decimal price = 0; int idvat = 0;

        private void rdonoapprove_CheckedChanged(object sender, EventArgs e)
        {
            if (rdonoapprove.Checked == true)
            {
                txtremark.ReadOnly = false;
                txtremark.Focus();
                cbtypevat.Visible = false;
                txtcreditmoney.Visible = false;
            }
        }

        private void rdoapprove_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoapprove.Checked == true)
            {
                if (idstatus == 1)
                {
                    cbtypevat.Visible = true;
                }
                if (idstatus == 2)
                {
                    txtcreditmoney.Visible = true ;
                }

            }
        }

        private void FrmapproveQuatation_Load(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); cbtypevat.Text = "";

            loadvat(CN);
            if (idstatus == 1 || idstatus == 2)
            { Loadidchangdata(CN); }

            txtidqua.Text = idhistorycus.ToString();

            if (idstatus == 1)
            {
                cbtypevat.Visible = true;
                rdoapprove.Text = "��繴��¡Ѻ��úѹ�֡";
                rdonoapprove.Text = "�����繴����������Ѻ����";
            }
            if (idstatus == 2)
            {
                txtcreditmoney.Visible = true;
                rdoapprove.Text = "͹��ѵԺѹ�֡";
                rdonoapprove.Text = "���͹��ѵԺѹ�֡�������Ѻ����";
            }

            if (idstatus == 3)
            {
                cbtypevat.Visible = false;
                rdoapprove.Text = "��繴��¡Ѻ�������¹�ŧ";
                rdonoapprove.Text = "�����繴����������Ѻ����";
            }
            if (idstatus == 4)
            {
                txtcreditmoney.Visible = false;
                rdoapprove.Text = "͹��ѵ�����¹�ŧ";
                rdonoapprove.Text = "���͹��ѵԺѹ�֡�������Ѻ����";
            }
             if (idstatus == 5)
            {
                cbtypevat.Visible = false;
                rdoapprove.Text = "��繴��¡Ѻ��û�Ѻ�Ҥ�";
                rdonoapprove.Text = "�����繴����������Ѻ����";
            }
            if (idstatus == 6)
            {
                txtcreditmoney.Visible = false;
                rdoapprove.Text = "͹��ѵԡѺ��û�Ѻ�Ҥ�";
                rdonoapprove.Text = "���͹��ѵԺѹ�֡�������Ѻ����";
            }
            CN.Close();
        }

        private void Loadidchangdata(SqlConnection CN)
        {
            string sql1 = "select idchangauto from vhistorycus where idhistorycus= " + idhistorycus + "";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            SqlDataReader DR1 = CM1.ExecuteReader();
            DR1.Read();
            {
                autoidchang = Convert.ToInt32(DR1["idchangauto"].ToString());               
            }
            DR1.Close();
            CN.Close();
        }

        private void loadvat(SqlConnection CN)
        {
            string sql1 = "select * from tbtypevat";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(ds, "loadtypevat");
            cbtypevat.DataSource = ds.Tables["loadtypevat"];
            cbtypevat.DisplayMember = "namevat";
            cbtypevat.ValueMember = "idtypevat";
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); idvat=Convert.ToInt16(cbtypevat.SelectedValue.ToString());
           

            if (idstatus == 1 && idvat !=0)//approve for sale  ����ѵ��١���
            {
                string sql1 = "update tbhischangdata set idstatusqua = 2 Where idhistorycus= '" + txtidqua.Text + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                CM1.ExecuteNonQuery();

                string sql2 = "update tbhistorycustomer set idtypevat=" + idvat + " Where idhistorycus= '" + txtidqua.Text + "'";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                CM2.ExecuteNonQuery();


                MessageBox.Show("��Ѻ��ا���������º���� !", "��§ҹ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            if (idstatus == 2 && price != 0)//approve for manager ����ѵ��١���
            {
                string sql1 = "update tbhischangdata set idstatusqua = 4 Where idhistorycus='" + txtidqua.Text + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                CM1.ExecuteNonQuery();

                string sql2 = "update tbhistorycustomer set moneycredit=" + price + " Where idhistorycus='" + txtidqua.Text + "'";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                CM2.ExecuteNonQuery();

                MessageBox.Show("��Ѻ��ا���������º���� !", "��§ҹ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            if (idstatus == 3) //approve for sale  ����¹�ŧ����ѵ�
            {
                string sql1 = "update tbhischangdata set idstatusqua = 15 Where idchangauto= '" + txtidqua.Text + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                CM1.ExecuteNonQuery();  

                MessageBox.Show("��Ѻ��ا���������º���� !", "��§ҹ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            if (idstatus == 4)//approve for manager ����¹�ŧ����ѵ�
            {
                string sql1 = "update tbhischangdata set idstatusqua = 4 Where idchangauto='" + txtidqua.Text + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                CM1.ExecuteNonQuery();

                MessageBox.Show("��Ѻ��ا���������º���� !", "��§ҹ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            if (idstatus == 5) //approve for sale  �׹�ѹ����¹�ŧ�Ҥ�
            {
                string sql1 = "update tbhischangdata set idstatusqua = 17 Where idchangauto= '" + txtidqua.Text + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                CM1.ExecuteNonQuery();

                MessageBox.Show("��Ѻ��ا���������º���� !", "��§ҹ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            if (idstatus == 6)//approve for manager ͹��ѵ�����¹�ŧ�Ҥ�
            {
                string sql1 = "update tbhischangdata set idstatusqua = 4 Where idchangauto='" + txtidqua.Text + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                CM1.ExecuteNonQuery();

                MessageBox.Show("��Ѻ��ا���������º���� !", "��§ҹ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            CN.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtcreditmoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 13 && e.KeyChar != 8 && e.KeyChar != 46)
            {
                MessageBox.Show("��͹�������Ţ��ҹ��", "�Դ��Ҵ!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
            else if (e.KeyChar == 13)
            {
                if (txtcreditmoney.Text != "")
                {
                    price = Convert.ToDecimal(txtcreditmoney.Text);
                    if (price == 0)
                    {
                        MessageBox.Show("����������ٹ����", "�Դ��Ҵ!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtcreditmoney.Focus();
                    }
                    //decimal weigthbf = Convert.ToInt32(txtweigthkk.Text);
                    txtcreditmoney.Text = price.ToString("##,###.##");
                }
            }
        }

        private void cbtypevat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbtypevat.SelectedIndex == 10) return;
            //idvat = Convert.ToInt16(cbtypevat.SelectedValue.ToString());
        }

       
    }
}