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
    public partial class FrmInsertweigth : Form
    {
        public FrmInsertweigth()
        {
            InitializeComponent();
        }

        decimal sweigth = 0; 
        decimal eweigth = 0; 
        decimal dfweigth = 0; 
        
        public decimal wbf = 0; 
        public decimal waf = 0; 
        public decimal wdf = 0; 
        public decimal wslt = 0; 
        public string idtran = "0"; 
        public string valuereturn = "";
        
        string status = ""; 
        string date = "";
        
        string msnfrom = ""; 
        int idtypelog = 0; 
        public int idsave = 0;
        

        private void txtweigthbf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57 || e.KeyChar == 47) && e.KeyChar != 13 && e.KeyChar != 8)
            {
                MessageBox.Show("ป้อนได้แต่ตัวเลขเท่านั้น", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
            else if (e.KeyChar == 13)
            {
                sweigth = Convert.ToDecimal(txtweigthbf.Text);

                if (txtweigthbf.Text !="")//ต้องมากกว่า 1000 กิโล หรือเท่ากับ 1 ตัน
                {                    
                    if (sweigth == 0)
                    {
                        MessageBox.Show("ค่าห้ามเป็นศูนย์ค่ะ", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtweigthbf.Clear(); txtweigthbf.Focus();
                    }
                    else if (sweigth < 1000)
                    {
                        MessageBox.Show("น้ำหนักต้องมีค่าตั้งแต่ 1000 ขึ้นไป", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtweigthbf.Clear(); txtweigthbf.Focus();
                    }
                    else
                    {
                        txtweigthaf.Focus(); 
                        wbf = sweigth;
                        txtweigthbf.Text = sweigth.ToString("#,###.#0");
                    }
                }                
            }

             //   MessageBox.Show("ระบุรูปแบบข้อมูลผิด", "ข้อมูลรูปแบบผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            
        }

        private void rdostart_CheckedChanged(object sender, EventArgs e)
        {
            if (rdostart.Checked == true)
            {
                txtweigthselect.BackColor = txtweigthbf.BackColor;
                txtweigthselect.Text = txtweigthbf.Text;
                CheckDefWeigth();
            }
        }

        private void tdoend_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoend.Checked==true)
            {
                txtweigthselect.BackColor = txtweigthaf.BackColor;
                txtweigthselect.Text = txtweigthaf.Text;
                CheckDefWeigth();
            }
        }

        private void CheckDefWeigth()
        {
            decimal weigthbf = Convert.ToDecimal(txtweigthbf.Text.Trim());
            decimal weigthaf = Convert.ToDecimal(txtweigthaf.Text.Trim());
            dfweigth = weigthbf - weigthaf;
            txtweigthdf.Text = Convert.ToString(weigthbf - weigthaf);        
        }

        private void txtweigthaf_KeyPress(object sender, KeyPressEventArgs e)
        {           

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 13 && e.KeyChar != 8)//&& e.KeyChar == 47)
            {
                MessageBox.Show("ป้อนได้แต่ตัวเลขเท่านั้น", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }                

            else if (e.KeyChar == 13)
            {
                eweigth = Convert.ToDecimal(txtweigthaf.Text);
                sweigth = Convert.ToDecimal(txtweigthbf.Text);

                if (txtweigthaf.Text != "")
                {
                    if (eweigth == 0)
                    {                       
                      //  txtweigthbf.Clear(); txtweigthbf.Focus();
                        rdostart.Enabled = false; rdoend.Enabled = false;
                    }
                    else if (eweigth < 1000)
                    {
                        MessageBox.Show("น้ำหนักต้องมีค่าตั้งแต่ 1000 ขึ้นไป", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtweigthaf.Clear(); txtweigthaf.Focus();
                    }

                    else
                    {
                        rdostart.Enabled = true; rdoend.Enabled = true;
                        dfweigth = eweigth - sweigth;
                        waf = eweigth;
                        wdf = dfweigth;
                        txtweigthaf.Text = eweigth.ToString("#,###.#0");
                        txtweigthdf.Text = Convert.ToString(dfweigth);                       
                    }
                }
            }           
        }

        private void FrmInsertweigth_Load(object sender, EventArgs e)
        {
            txtweigthbf.Text = wbf.ToString();
            txtweigthaf.Text = waf.ToString();
            txtweigthdf.Text = wdf.ToString();
            txtranno.Text = idtran.Trim();
            msnfrom = this.Name.ToString();
            eweigth = waf;
            sweigth = wbf;

            if (wbf != 0)
            { txtweigthbf.ReadOnly = true; }
            if (waf != 0)
            { txtweigthaf.ReadOnly = true; }
            if(idsave==2)
            { txtrfinvoice.Enabled = false; }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (wbf == 0)
            { wbf=Convert.ToDecimal(txtweigthbf.Text.Trim());}
            if (waf == 0)
            { waf = Convert.ToDecimal(txtweigthaf.Text.Trim()); }           


            if (idsave == 0) //p to s
            {
                if (txtweigthbf.Text != "" && txtweigthaf.Text != "" && txtweigthdf.Text != "")
                {  
                    string sql1 = "update tborder set idstatus = " + 1 + " Where idtran= '" + idtran + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();

                    string sql2 = "update tbpurchase set idstatus = " + 2 + " Where idtran= '" + idtran + "'";
                    SqlCommand CM2 = new SqlCommand(sql2, CN);
                    CM2.ExecuteNonQuery();

                    string sql = "update tbtransport set rfinvoice = '" + txtrfinvoice.Text + "',idtruck = 3, remark1='ปิดงาน' Where idtran= '" + idtran + "'";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();

                    string sql3 = "update tbweigth set weigthsup=" + wbf + ",weigthsupdfsale =" + dfweigth + ",weigthcus =" + waf + ",weigthselect = " + Convert.ToDecimal(txtweigthselect.Text) + " Where idtran= '" + idtran + "'";
                    SqlCommand CM3 = new SqlCommand(sql3, CN);
                    CM3.ExecuteNonQuery();
                }               
            }

            if (idsave == 1)//sale
            {
                string sql1 = "update tborder set idstatus = " + 1 + " Where idtran= '" + idtran + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                CM1.ExecuteNonQuery();

                string sql = "update tbtransport set rfinvoice = '" + txtrfinvoice.Text + "',idtruck = 3, remark1='ปิดงาน' Where idtran= '" + idtran + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();

                string sql2 = "update tbweigth set weigthselect = " + Convert.ToDecimal(txtweigthselect.Text) + " Where idtran= '" + idtran + "'";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                CM2.ExecuteNonQuery();
            
            }


            if (idsave == 2)//purchse
            {
                string sql1 = "update tbpurchase set idstatus = " + 2 + " Where idtran= '" + idtran + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                CM1.ExecuteNonQuery();

                string sql = "update tbtransport set idtruck=3,remark1='ปิดงาน' Where idtran= '" + idtran + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();

                string sql2 = "update tbweigth set weigthselect = " + Convert.ToDecimal(txtweigthselect.Text) + " Where idtran= '" + idtran + "'";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                CM2.ExecuteNonQuery();
            }
            

            MessageBox.Show("ปรับปรุงข้อมูลประสบความสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }          
    }
}