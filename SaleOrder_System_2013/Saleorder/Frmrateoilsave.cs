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
    public partial class Frmrateoilsave : Form
    {
        public Frmrateoilsave()
        {
            InitializeComponent();
        }

        public int editstatus = 0;
        public int idtruck = 0;
        public int idtyperate = 0;      
        public int idtruckedit = 0;
        public double bfmileage = 0;///
        public double afmileage = 0;///
        string daterefil = "";       
        double newmileage = 0; //       
        double kilomete = 0;       ////
        double unitliterefil = 0;   //
        double priceperlite = 0;  //
        double averateperkm = 0;
        double pricetotal = 0;  //

        /*
         * 
         * ระยะทาง (kilomete)  = (เลขไมค์ใหม่)newmileage - (เลขไมค์เก่า)oldmileage
         * 
         * เฉลี่ยการใช้/กม.(averateperkm) = ระยะทาง (kilomete) / จำนวนลิตรที่เติม (unitliterefil)
         * 
         * จำนวนเงิน (pricetotal)= จำนวนลิตรที่เติม (unitliterefil) * ราคา/ลิตร (priceperlite)
         *    
         *                      */

        private void LoadShowFormula()
        {
            if (idtyperate == 1)
            {
                lbl1.Text = "เลขไมค์ใหม่ - เลขไมค์เก่า = ระยะทาง(กม.)";
                lbl2.Text = "ระยะทาง  % จำนวนน้ำมันที่เติม(ลิตร) = เฉลี่ยการใช้น้ำมัน/กม.";
                lbl3.Text = "จำนวนน้ำมันที่เติม(ลิตร) X ราคาน้ำมัน/ลิตร = จำนวนเงิน";
            }
            if (idtyperate == 2)
            {
                lbl1.Text = "ชั่วโมง(ชม.) = ชั่วโมงการทำงาน";
                lbl2.Text = "จำนวนน้ำมันที่เติม(ลิตร) % ชั่วโมงการทำงาน = เฉลี่ยการใช้น้ำมัน/ชม.";
                lbl3.Text = "จำนวนน้ำมันที่เติม(ลิตร) X ราคาน้ำมัน/ลิตร  = จำนวนเงิน";
            }
        }

        private void Frmrateoilsave_Load(object sender, EventArgs e)
        {
            if (editstatus == 0 || editstatus == 1)//บันทึกค่าระบบ
            {
                LoadTruckRate();
                Loadoldmileage();
                LoadShowFormula();
                if (txtafmileage.Text == "")
                {
                    txtafmileage.Text = "-";
                    if (txtafmileage.Text == "-")
                    { txtremark.Text = "ค่าเริ่มต้นระบบ"; }
                }

                txtlastmileage.Focus();
            }    
                
              if(editstatus == 2 ||editstatus == 3)//
            {
                LoaddataEdit(); LoadTruckRate();           
            }

            if (editstatus == 2)
            {
                if (txtafmileage.Text == "0")
                { cbeditmith.Enabled = true; }
            }  

            if (editstatus == 3)
            {
                txtlastmileage.Enabled = false; cbinsertmild.Enabled = true;
            }                       
        }

        private void LoaddataEdit()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql2 = "SELECT * FROM tbrateOil WHERE idauto =" + idtruckedit + " order by idauto desc";
            SqlCommand CM2 = new SqlCommand(sql2, CN);
            SqlDataReader DR2 = CM2.ExecuteReader();
            DR2.Read();
            {
                dtprefil.Text = DR2["daterefil"].ToString();
                txtlastmileage.Text = DR2["mileageNo"].ToString();                
                txtunitliterefil.Text = DR2["unitliterefil"].ToString();
                txtpriceperlite.Text = DR2["priceperlite"].ToString();               
                txtremark.Text = DR2["remark"].ToString();
            }
            DR2.Close();
            CN.Close();
            txtafmileage.Text = afmileage.ToString();          
        }

        private void Loadoldmileage()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            int count=0;

            string sql1 = "select count(idtruck)as countid  from tbrateOil where idtruck =" + idtruck + "";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            SqlDataReader DR1 = CM1.ExecuteReader();
   DR1.Read();
            {   count = Convert.ToInt16(DR1["countid"].ToString().Trim());   }
            DR1.Close();

            if (count != 0)//เช็คว่ามีข้อมูลเก่าอยู่หรือไม่
            {
                string sql2 = "select mileageNo,priceperlite from tbrateOil where idtruck =" + idtruck + " order by idauto desc";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();

                DR2.Read();
                {
                    txtafmileage.Text = DR2["mileageNo"].ToString().Trim();
                    txtpriceperlite.Text = DR2["priceperlite"].ToString().Trim();
                    afmileage = Convert.ToDouble(txtafmileage.Text.Trim());
                }
                DR2.Close();
            }
            CN.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();

                if (editstatus == 0)
                {
                    txtremark.Text = "ค่าเริ่มต้นระบบ";
                    string dsday = dtprefil.Value.Day.ToString();
                    string dsmonth = dtprefil.Value.Month.ToString();
                    string dsyear = dtprefil.Value.Year.ToString();
                    daterefil = dsmonth + "/" + dsday + "/" + dsyear;

                    string sql = "insert into tbrateOil(idtruck,daterefil,mileageNo,unitliterefil,priceperlite,remark) values (" + idtruck + ",'" + daterefil + "','" + txtlastmileage.Text + "'," + txtunitliterefil.Text + "," + txtpriceperlite.Text + ",'" + txtremark.Text + "')";

                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();

                    MessageBox.Show("บันทึกข้อมูลประสบความสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (editstatus == 1) //บันทึกสะสมระยะทางการทำงานหรือชั่วโมงการทำงาน
                {
                    string dsday = dtprefil.Value.Day.ToString();
                    string dsmonth = dtprefil.Value.Month.ToString();
                    string dsyear = dtprefil.Value.Year.ToString();
                    daterefil = dsmonth + "/" + dsday + "/" + dsyear;

                    string sql = "insert into tbrateOil(idtruck,daterefil,mileageNo,unitliterefil,priceperlite,remark) values (" + idtruck + ",'" + daterefil + "','" + txtlastmileage.Text + "'," + txtunitliterefil.Text + "," + txtpriceperlite.Text + ",'" + txtremark.Text + "')";

                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();

                    MessageBox.Show("บันทึกข้อมูลประสบความสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (editstatus == 2 || editstatus == 3) //แก้ไขครั้งล่าสุด
                {
                    string dsday = dtprefil.Value.Day.ToString();
                    string dsmonth = dtprefil.Value.Month.ToString();
                    string dsyear = dtprefil.Value.Year.ToString();
                    daterefil = dsmonth + "/" + dsday + "/" + dsyear;
                    string sql = "";

                    if (editstatus == 2)
                    {
                        sql = "update tbrateOil set daterefil='" + daterefil + "',mileageNo='" + txtlastmileage.Text + "',kilomete = 0 ,unitliterefil=" + txtunitliterefil.Text + ",priceperlite='" + txtpriceperlite.Text + "',averateperkm = 0 ,pricetotal= 0 ,remark='" + txtremark.Text + "' Where idauto= " + idtruckedit + "";
                    }
                    if (editstatus == 3)
                    {
                        sql = "update tbrateOil set daterefil='" + daterefil + "',kilomete=" + kilomete + ",unitliterefil=" + txtunitliterefil.Text + ",priceperlite='" + txtpriceperlite.Text + "',averateperkm = 0 ,pricetotal= 0 ,remark='" + txtremark.Text + "' Where idauto= " + idtruckedit + "";
                    }
                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();

                    MessageBox.Show("ปรับปรุงข้อมูลประสบความสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                CN.Close();
                this.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void dtprefil_ValueChanged(object sender, EventArgs e)
        {
            txtlastmileage.Focus();
        }

        private void txtlastmileage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && idtyperate != 1)
            {
                if (cbinsertmild.Checked == true)
                {
                    decimal bfmile = Convert.ToDecimal(txtbfmileage.Text.Trim());
                    decimal afmile = Convert.ToDecimal(txtafmileage.Text.Trim());
                    decimal insertmaile = Convert.ToDecimal(txtlastmileage.Text.Trim());
                    if (insertmaile < bfmile || insertmaile > afmile)
                    {
                        MessageBox.Show("ระบุเลขไมล์ระหว่างช่วงผิด !", "ระบุเลขไมล์ผิดพลาด !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtlastmileage.Clear();
                        txtlastmileage.Focus();
                    }
                    else
                    { txtunitliterefil.Focus(); }
                }
                else
                { txtunitliterefil.Focus(); }
            }
        }

        private void txtunitliterefil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) //รับค่าจำนวนลิตรที่เติม
            { txtpriceperlite.Focus(); }
        }

        private void txtpriceperlite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { btnsave.Focus(); }
        }

        private void LoadTruckRate()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql2 = "SELECT idtyperate,nametyperate,truckserail FROM vdrivertyperate WHERE idtruck =" + idtruck + "";
            SqlCommand CM2 = new SqlCommand(sql2, CN);
            SqlDataReader DR2 = CM2.ExecuteReader();
            DR2.Read();
            {
                idtyperate = Convert.ToInt16(DR2["idtyperate"].ToString().Trim());
                txtserailcar.Text = DR2["truckserail"].ToString().Trim();
                txtratename.Text = DR2["nametyperate"].ToString().Trim();
            }
            DR2.Close();
            CN.Close();
        }

        private void btnsave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { btnsave.Focus(); }
        }

        private void dtprefil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { txtlastmileage.Focus(); }
        }

        private void cbinsertmild_CheckedChanged(object sender, EventArgs e)
        {
            if (cbinsertmild.Checked == true)
            {
                editstatus = 1;
                if (idtyperate == 1)
                {
                    label6.Text = "เลขไมล์ที่แก้ไขเพิ่มเติม :";
                    label21.Text = "ระหว่างเลขไมล์ก่อน - เลขไมล์หลัง";
                }

                txtbfmileage.Text = txtlastmileage.Text;
                txtlastmileage.Clear();
                txtunitliterefil.Clear();
                txtlastmileage.Enabled = true;
            }
        }

       

    }
}