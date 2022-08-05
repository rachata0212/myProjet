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
                if (idmenuunlock == 14)//cancle ซื้อ
                {
                    string sql1 = "update tbpurchase set idstatus = 7,ctdate='" + sumdatebf + "',ctedtime='" + string.Format("{0:HH:mm:ss}", DateTime.Now) + "',remark1='" + remark.Trim() +"',remark2 = '-' where idpur= '" + idcancle + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery(); idreturn = 1; this.Close();
                }

                if (idmenuunlock == 15)//cancle ขาย
                {
                    string sql1 = "update tborder set idstatus = 7,ctdate='" + sumdatebf + "',ctedtime='" + string.Format("{0:HH:mm:ss}", DateTime.Now) + "',remark1='" + remark.Trim() + "',remark2='-' where idorder= '" + idcancle + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery(); idreturn = 1; this.Close();
                }
                
                if (idmenuunlock == 20)//cancle transport ซื้อมาขายไป
                {
                    //update status from table purchase  ทำการยกเลิกรายการซื้อ          
                    string sql1 = "update tbpurchase set idstatus = 4 where idtran= '" + idcancle + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();

                    //update status from table Order ทำการยกเลิกรายการขาย
                    string sql2 = "update tborder set idstatus = 3 where idtran= '" + idcancle + "'";
                    SqlCommand CM2 = new SqlCommand(sql2, CN);
                    CM2.ExecuteNonQuery();

                    //update transport ยกเลิกขนส่ง
                    string sql4 = "update tbtransport set idtruck = 5 where idtran='" + idcancle + "'";
                    SqlCommand CM4 = new SqlCommand(sql4, CN);
                    CM4.ExecuteNonQuery();

                    //insert tbjobcancle record
                    string sql = "insert into tbcanclejobrecord (rmidcacle,cancledate,cancletime,remarkcancle,idtypecancle,idbranch) values ('" + idcancle + "','" + sumdatebf + "','" + DateTime.Now.ToLongTimeString() + "','" + remark.Trim() + "',3," + Program.idbranch + ")";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();
                    this.Close();
                }

                if (idmenuunlock == 21)//cancle transport เปลี่ยนสถานะซื้ออันเก่า  หน้าตาชั่ง
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

                if (idmenuunlock == 22)//cancle transport เปลี่ยนสถานะขายอันเก่า  หน้าตาชั่ง
                {
                    //update status from table Order ทำการยกเลิกรายการขาย
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

            else { MessageBox.Show("รหัสไม่ถูกต้อง", "บันทึกการยกเลิกผิดพลาด !", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            CN.Close();
        }

        private void CheckUnlockpwd()
        {
            /*
             * 
             * 	
                
	            1	[ฝ่ายจัดขนส่ง] เปลี่ยน [คลัง1 - ขาย] -> [คลัง1 - คลัง2]
	            2	[ฝ่ายจัดขนส่ง] ยกเลิก Order ซื้อ
	           3	[ฝ่ายจัดขนส่ง] ยกเลิก Order ขาย        
             
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
            { MessageBox.Show("user นี้ไม่ได้รับอนุญาติในการเปลี่ยนแปลงข้อมู", "ผิดพลาด !", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                cboremark.Items.Add("-รอโอนเงิน");
                cboremark.Items.Add("-รถตักเสีย");
                cboremark.Items.Add("-รอต่อสัญญา");
                cboremark.Items.Add("-ไม่มีรถขึ้นสินค้า");
                cboremark.Items.Add("-สินค้าไม่พอ");
                cboremark.Items.Add("-เข้ารับสินค้าไม่ทัน");                         
            }

            if (idmenuunlock == 15)
            {
                cboremark.Items.Add("-พื้นที่ลงสินค้าไม่พอ");
                cboremark.Items.Add("-ติดเวลาลงสินค้าที่ลูกค้า");
                cboremark.Items.Add("-ไม่มีรถส่งสินค้า");                
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