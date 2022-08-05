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
    public partial class Frmconfirmpwdchagedata : Form
    {
        public Frmconfirmpwdchagedata()
        {
            InitializeComponent();
        }

        public int idreturn = 0;
        public string idcancle = "";
        public int idmenuunlock = 0;
        string sumdatebf = "";
        string pwdunlock = "";

        private void btnok_Click(object sender, EventArgs e)
        {
            string remark = "";
            string datebf = DateTime.Now.Day.ToString();
            string monthbf = DateTime.Now.Month.ToString();
            string yearbf = DateTime.Now.Year.ToString();
            sumdatebf = monthbf + "/" + datebf + "/" + yearbf;
            if (cborthercase.Checked == false)
            { remark = cboremark.Text.Trim(); }
            if (cborthercase.Checked == true)
            { remark = txtremark.Text.Trim(); }


            CheckUnlockpwd();

            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); DateTime now = DateTime.Now;

            if (pwdunlock == txtconfirmpwd.Text.Trim())
            {
                if (idmenuunlock == 14)//cancle ����
                {
                    string sql1 = "update tbpurchase set idstatus = 7,ctdate='" + sumdatebf + "',ctedtime='" + string.Format("{0:HH:mm:ss}", DateTime.Now) + "',remark1='" + remark.Trim() +"',remark2 = '-' where idpur= '" + idcancle + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery(); idreturn = 1; this.Close();
                }

                if (idmenuunlock == 15)//cancle ���
                {
                    string sql1 = "update tborder set idstatus = 7,ctdate='" + sumdatebf + "',ctedtime='" + string.Format("{0:HH:mm:ss}", DateTime.Now) + "',remark1='" + remark.Trim() + "',remark2='-' where idorder= '" + idcancle + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery(); idreturn = 1; this.Close();
                }
                
                if (idmenuunlock == 20)//cancle transport �����Ң���
                {
                    //update status from table purchase  �ӡ��¡��ԡ��¡�ë���          
                    string sql1 = "update tbpurchase set idstatus = 4 where idtran= '" + idcancle + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();

                    //update status from table Order �ӡ��¡��ԡ��¡�â��
                    string sql2 = "update tborder set idstatus = 3 where idtran= '" + idcancle + "'";
                    SqlCommand CM2 = new SqlCommand(sql2, CN);
                    CM2.ExecuteNonQuery();

                    //update transport ¡��ԡ����
                    string sql4 = "update tbtransport set idtruck = 5 where idtran='" + idcancle + "'";
                    SqlCommand CM4 = new SqlCommand(sql4, CN);
                    CM4.ExecuteNonQuery();

                    //insert tbjobcancle record
                    string sql = "insert into tbcanclejobrecord (rmidcacle,cancledate,cancletime,remarkcancle,idtypecancle,idbranch) values ('" + idcancle + "','" + sumdatebf + "','" + DateTime.Now.ToLongTimeString() + "','" + remark.Trim() + "',3," + Program.idbranch + ")";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();
                    this.Close();
                }

                if (idmenuunlock == 21)//cancle transport ����¹ʶҹЫ����ѹ���  ˹�ҵҪ��
                {

                    //update status from table purchase           
                    string sql1 = "update tbpurchase set idstatus = 7 where idtran= '" + idcancle + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();

                    //update transport
                    string sql4 = "update tbtransport set idtruck = 5 where idtran ='" + idcancle + "'";
                    SqlCommand CM4 = new SqlCommand(sql4, CN);
                    CM4.ExecuteNonQuery();

                    //insert tbjobcancle record
                    string sql = "insert into tbcanclejobrecord (rmidcacle,cancledate,cancletime,remarkcancle,idtypecancle,idbranch) values ('" + idcancle + "','" + sumdatebf + "','" + DateTime.Now.ToLongTimeString() + "','" + remark.Trim() + "',4," + Program.idbranch + ")";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();
                    this.Close();
                }

                if (idmenuunlock == 22)//cancle transport ����¹ʶҹТ���ѹ���  ˹�ҵҪ��
                {
                    //update status from table Order �ӡ��¡��ԡ��¡�â��
                    string sql2 = "update tborder set idstatus = 7 where idtran= '" + idcancle + "'";
                    SqlCommand CM2 = new SqlCommand(sql2, CN);
                    CM2.ExecuteNonQuery();

                    //update transport
                    string sql6 = "update tbtransport set  idbranch = null,idtruck = 5 where idtran='" + idcancle + "'";
                    SqlCommand CM6 = new SqlCommand(sql6, CN);
                    CM6.ExecuteNonQuery();

                    //insert tbjobcancle record
                    string sql = "insert into tbcanclejobrecord (rmidcacle,cancledate,cancletime,remarkcancle,idtypecancle,idbranch) values ('" + idcancle + "','" + sumdatebf + "','" + DateTime.Now.ToLongTimeString() + "','" + remark.Trim() + "',5," + Program.idbranch + ")";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();
                    this.Close();
                }
            }

            else { MessageBox.Show("�������١��ͧ", "�ѹ�֡���¡��ԡ�Դ��Ҵ !", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            CN.Close();
        }

        private void CheckUnlockpwd()
        {
            /*
             * 
             * 	
                
	            1	[���¨Ѵ����] ����¹ [��ѧ1 - ���] -> [��ѧ1 - ��ѧ2]
	            2	[���¨Ѵ����] ¡��ԡ Order ����
	           3	[���¨Ѵ����] ¡��ԡ Order ���        
             
             * 
             * */

            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            try
            {
                string sql2 = "SELECT pwdunlock FROM vunlockpwd WHERE idemplock ='" + Program.empID + "' AND idmenuunlock=" + idmenuunlock + "";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();
                DR2.Read();
                {
                    pwdunlock = DR2["pwdunlock"].ToString().Trim();
                }
                DR2.Close();
            }
            catch
            { MessageBox.Show("user ���������Ѻ͹حҵ�㹡������¹�ŧ�����", "�Դ��Ҵ !", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            CN.Close();
        }

        private void btncancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frmconfirmpwdcs_Load(object sender, EventArgs e)
        {
            lblidcancle.Text ="ID-Cancle NO: "+ idcancle.ToString().Trim();
            if (idmenuunlock == 14)
            {
                cboremark.Items.Add("-���͹�Թ");
                cboremark.Items.Add("-ö�ѡ����");
                cboremark.Items.Add("-�͵���ѭ��");
                cboremark.Items.Add("-�����ö����Թ���");
                cboremark.Items.Add("-�Թ�������");
                cboremark.Items.Add("-����Ѻ�Թ������ѹ");                         
            }

            if (idmenuunlock == 15)
            {
                cboremark.Items.Add("-��鹷��ŧ�Թ�������");
                cboremark.Items.Add("-�Դ����ŧ�Թ��ҷ���١���");
                cboremark.Items.Add("-�����ö���Թ���");                
            }
        }

        private void cborthercase_CheckedChanged(object sender, EventArgs e)
        {
            if (cborthercase.Checked == true)
            { txtremark.ReadOnly = false; cboremark.Enabled = false; }
            else { txtremark.ReadOnly = true; cboremark.Enabled = true; }
        }

    }
}