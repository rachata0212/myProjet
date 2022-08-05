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
    public partial class FrmWeigthbeforetruckin : Form
    {
        public FrmWeigthbeforetruckin()
        {
            InitializeComponent();
        }

        public string idtran; 
        string msnfrom = ""; 
        int idtypelog = 0; 
        public string idpur = "0"; 
        public string fromweigth = ""; 
        public decimal weigthnet = 0; 
        public string datewbf = ""; 
        string idcomtran = ""; 
        DateTime dts; 
        public decimal weigthbf = 0; 
        public string valuereturn = "";
        public string sumdatebf= "";
        string datelog = DateTime.Now.Day.ToString();
        string monthlog = DateTime.Now.Month.ToString();
        string yearlog = DateTime.Now.Year.ToString();

        private void FrmWeigthbeforetruckin_Load(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            txtweigthin.Text = "0";
            txtidtran.Text = idtran;

            if (fromweigth == "purchas" || fromweigth == "purtosale")//ปรับปรุงข้อมูลซื้อ
            {                
                label1.Text = "น้ำหนักชั่งต้นทาง(กก.)";
                string sql = "select idpur,datepur from tbpurchase where idtran='" + idtran + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                DR.Read();
                {
                    idpur = Convert.ToString(DR["idpur"].ToString());
                    dts = Convert.ToDateTime(DR["datepur"].ToString());
                }
                DR.Close();    
            }

            else if (fromweigth == "salecus")//ปรับปรุงข้อมูลขาย
            {
                label1.Text = "น้ำหนักชั่งปลายทาง(กก.)";
                string sql = "select idorder,orderdate from tborder where idtran='" + idtran + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                DR.Read();
                {
                    idpur = Convert.ToString(DR["idorder"].ToString());
                    dts = Convert.ToDateTime(DR["orderdate"].ToString());
                }
                DR.Close();

                string sql1 = "select * from vonholetruckout where idtran='" + idtran + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();
                DR1.Read();
                {
                    txtcustomer.Text = DR1["comcus"].ToString().Trim();
                    txtserailcar.Text = DR1["serailcar"].ToString().Trim();
                    txtweigthbf.Text = DR1["weigthbf"].ToString().Trim();
                    txtweigthaf.Text = DR1["weigthaf"].ToString().Trim();
                    txtweigthnet.Text = DR1["weigthnet"].ToString().Trim();
                    txtproduct.Text = DR1["proname"].ToString().Trim();
                }
                DR1.Close();
            }

            else if (fromweigth == "purtosale")//ปรับปรุงข้อมูล ซ์อ มา ขายไป ผ่านตาชั่ง
            {
                label1.Text = "น้ำหนักชั่งต้นทาง(กก.)";
            }

            weigthnet = Convert.ToInt32(txtweigthnet.Text.Trim());
            msnfrom = this.Name.ToString();
            idtypelog = 7;//open
            CN.Close();
            Savelogevent();
        }       

        private void btnOK_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            //weigthbf = 0;

            string deday = dtpdatetime.Value.Day.ToString();
            string demonth = dtpdatetime.Value.Month.ToString();
            string deyear = dtpdatetime.Value.Year.ToString();
            string desum = demonth + "/" + deday + "/" + deyear;
          //  weigthbf = Convert.ToInt32(txtweigthin.Text.Trim());

            if (txtweigthin.Text != "")
            {               
                if (weigthbf > 0 ||sweigth !=0)
                {
                    Program.idstatus = 1;
                }
            }  
            
             if (Program.idstatus == 1 && fromweigth == "salecus" && txtmoisture.Text !="")//ปรับปรุงข้อมูลขาย
            {
                decimal deweigth = weigthnet - sweigth;
                string sql1 = "update tbtransport set idfrom='C003',idtruck= 3,moisture=" + Convert.ToDecimal(txtmoisture.Text.Trim()) + " Where idtran= '" + idtran + "'";

                string sql3 = "update tbweigth set dateWcus ='" + desum + "',weigthcus=" + sweigth + ",weigthsupdfsale=" + deweigth + " where idtran= '" + idtran + "'";
                SqlCommand CM3 = new SqlCommand(sql3, CN);
                CM3.ExecuteNonQuery();  

                string sql5 = "update tborder set remark3='ส่งสินค้าแล้ว' Where idtran= '" + idtran + "'";
                SqlCommand CM5 = new SqlCommand(sql5, CN);
                CM5.ExecuteNonQuery();

                SqlCommand CM1 = new SqlCommand(sql1, CN);
                CM1.ExecuteNonQuery();

                MessageBox.Show("ปรับปรุงข้อมูลเรียบร้อย !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                msnfrom = this.Name.ToString();
                idtypelog = 2;//insert
                Savelogevent();
                this.Close();
            }           

             if (Program.idstatus == 0)
            {
                MessageBox.Show("ค่าห้ามเป็นศูนย์หรือห้ามว่าง", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtweigthin.Focus();
            }
            CN.Close();
        }

        Decimal sweigth;
        private void txtweigthin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57 || e.KeyChar == 47) && e.KeyChar != 13 && e.KeyChar != 8)
            {
                MessageBox.Show("ป้อนได้แต่ตัวเลขเท่านั้น", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
            else if (e.KeyChar == 13)
            {
                try
                {
                    if (txtweigthin.Text != "")
                    {
                        sweigth = Convert.ToDecimal(txtweigthin.Text);
                        if (sweigth == 0)
                        {
                            MessageBox.Show("ค่าห้ามเป็นศูนย์ค่ะ", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtweigthin.Clear(); txtweigthin.Focus();
                        }
                        txtweigthin.Text = sweigth.ToString("#,###.#0");
                        btnOK.Focus();
                    }
                }
                catch (Exception ex)
                { MessageBox.Show("คุณระบุบรูปแบบตัวเลขผิด กรุณาลบและระบุใหม่", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop); }

            }
        }

        private void Savelogevent()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string selectdatelog = monthlog + "/" + datelog + "/" + yearlog;
            string sql1 = "insert into tblog(logname,datein,timein,idtypelog,idemp,remark) values('" + msnfrom + "','" + selectdatelog + "','" + DateTime.Now.ToLongTimeString() + "'," + idtypelog + ",'" + Program.empID + "','" + idtran + "')";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            CM1.ExecuteNonQuery();
            CN.Close();
        }

        private void FrmWeigthbeforetruckin_FormClosed(object sender, FormClosedEventArgs e)
        {
            msnfrom = this.Name.ToString();
            idtypelog = 6;//close
            Savelogevent();              
        }

        decimal weigthfirst = 0;
        private void txtmoisture_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 13 && e.KeyChar != 8 && e.KeyChar == 47)
            {
                MessageBox.Show("ป้อนได้แต่ตัวเลขเท่านั้น", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
            else if (e.KeyChar == 13)
            {
                if (txtmoisture.Text != "")
                {
                    weigthfirst = Convert.ToDecimal(txtmoisture.Text);
                    if (weigthfirst == 0)
                    {
                        MessageBox.Show("ค่าห้ามเป็นศูนย์ค่ะ", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtmoisture.Focus();
                        txtmoisture.Enabled = false;
                    }
                    //decimal weigthbf = Convert.ToInt32(txtweigthkk.Text);
                    txtmoisture.Text = weigthfirst.ToString("##.##");                   
                }
            }
        }

    }
}