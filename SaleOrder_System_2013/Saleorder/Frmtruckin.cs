using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Threading;
using System.IO;

namespace SaleOrder
{
    public partial class Frmtruckin : Form
    {
      
        public Frmtruckin()
        {
            InitializeComponent();            
        }

        SerialPort sport = new SerialPort();         
        public string idpur = "0";      public decimal weigth =0 ; 
        string msnfrom = "";            int idtypelog = 0; 
        public int statustruck = 0;     decimal weigthaf = 0; 
        decimal weigthbf = 0;
        decimal weigthsup = 0;           public string idtran = "0"; 
        decimal weigthtruc = 0;         DateTime dts; 
        int idpro = 0;                  string idcomtran = ""; 
        string idcompur = "";           int idstock = 0;        
        DataSet ds = new DataSet();
        int status = 0;  // ใช้โหลดสถานะเลือก
        decimal weigthdfsavehisstock = 0;
        string weigthwait="";
        string datelog = DateTime.Now.Day.ToString();
        string monthlog = DateTime.Now.Month.ToString();
        string yearlog = DateTime.Now.Year.ToString();

        private void ConnectToSerail()
        {
            try
            {
                sport.PortName = Program.comport;
                sport.BaudRate = int.Parse(Program.baudrate);
                sport.Parity = (Parity)Enum.Parse(typeof(Parity), Program.parity);
                sport.DataBits = Program.databit;
                sport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), Program.stopbit);
                sport.Handshake = Handshake.None;
                sport.DataReceived += OnSerialDataReceived;
                sport.ReadTimeout = 800;
                sport.WriteTimeout = 800;
                sport.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Comport Access Denie ! " + ex.Message + "", "Comport Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public void OnSerialDataReceived(object sender, SerialDataReceivedEventArgs args)
        {
            if (sport.IsOpen)
            {
                Thread.Sleep(800);
                string data = sport.ReadExisting();
                this.BeginInvoke(new MethodInvoker(delegate() { richTextBox1.Text = data.Trim(); }));
                sport.Close();

                RichTextBox.CheckForIllegalCrossThreadCalls = false;
                for (int i = 0; i < richTextBox1.Lines.Length; i++)
                {
                    if (Program.Selectline == i)
                    {
                        textBox1.Text = richTextBox1.Lines[i].Trim();
                    }
                }

                textBox1.SelectionStart = Program.stkeychar;
                textBox1.SelectionLength = Program.UnitKeyRecive;
                txtweigthkk.Text = textBox1.SelectedText.Trim();
                weigthwait = textBox1.Text.Trim();
            }
        }        

        private void Frmtruckin_Load(object sender, EventArgs e)
        {    
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql;
            btnprint.Enabled = false;

            if (statustruck == 0 || statustruck == 2)//จองตอนชั่งเข้าหนักเข้า
            { CheckNoweigth(); }  
                                  
            if (idpur != "0" & statustruck == 0)  ///Load data ถ้าชั่งน้ำหนักสินค้าเข้าคลัง
            {
                LoadSupproduct(); 
                sql = "select * from vonholetruckin where idfrom='" + idpur + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();
                lblstatus.Text = "ชั่งรถหนักเข้า";
                //btnprint.Enabled = false;

                DR.Read();
                {
                    //idpro=Convert.ToInt16(DR["idpro"].ToString());
                    txtpurname.Text = DR["company"].ToString();                    
                    txtsupname.Text = DR["comsup"].ToString();
                    txtcar.Text = DR["carname"].ToString();
                    txtserailcar.Text = DR["serailcar"].ToString();
                    txtcontactcar.Text = DR["telcontact"].ToString();
                    //weigthbf = Convert.ToDecimal(DR["weigthbf"].ToString());
                    txtWeigthSt.Text = DR["weigthsup"].ToString(); 
                }
                DR.Close();
                if (txtWeigthSt.Text.Trim() != "0" || txtWeigthSt.Text.Trim() == "")
                { txtWeigthSt.ReadOnly = true; cbselectpro.Focus(); weigthfirst = Convert.ToDecimal(txtWeigthSt.Text.Trim()); }
                else txtWeigthSt.Focus();
                
                msnfrom = this.Name.ToString();
                idtypelog = 7;//open
                Savelogevent();
            }

            else if (idpur != "0" && statustruck == 1)  ///Load data ถ้าชั่งน้ำหนักชั่งเบา  และรอชั่งน้ำหนักเบาออก
            {
                lblstatus.Text = "ชั่งรถเบาออก"; LoadSupproduct(); 
                txtWeigthSt.Enabled = false;
                cbselectpro.Enabled = false;
                sql = "select * from vonholetruckin where idfrom='" + idpur + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();


                DR.Read();
                {
                    idpro = Convert.ToInt16(DR["idsuppro"].ToString());
                    txtpurname.Text = DR["company"].ToString();
                    txtsupname.Text = DR["comsup"].ToString();
                    txtcar.Text = DR["carname"].ToString();
                    cbselectpro.Text = DR["namesup"].ToString();
                    txtserailcar.Text = DR["serailcar"].ToString();
                    txtcontactcar.Text = DR["telcontact"].ToString();
                    weigthsup = Convert.ToDecimal(DR["weigthsup"].ToString());
                    weigthbf = Convert.ToDecimal(DR["weigthbf"].ToString());

                }
                DR.Close();

                LoadStockBacklog();
                txtWeigthSt.Visible = false;
                label3.Visible = false;
                btnrefrash.Focus();
                msnfrom = this.Name.ToString();
                idtypelog = 7;//open
                Savelogevent();
            }

            try
            {
                if (idtran != "0" & statustruck == 2)  ///Load data ถ้าชั่งน้ำหนัก ชั่งหนักซื้อมาขายไป
                {

                    lblstatus.Text = "ชั่งรถหนัก";
                    //int idtran = 0; 
                    LoadSupproduct();

                    sql = "select * from vtranreplyFsTc where idtran='" + idtran + "'";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    SqlDataReader DR = CM.ExecuteReader();

                    DR.Read();
                    {
                        cbselectpro.Text = DR["proname"].ToString(); 
                        txtpurname.Text = DR["comsale"].ToString();                        
                        txtsupname.Text = DR["comsup"].ToString();
                        txtcar.Text = DR["carname"].ToString();
                        txtserailcar.Text = DR["serailcar"].ToString();
                        txtcontactcar.Text = DR["telcontact"].ToString();
                    }
                    DR.Close();

                    cbselectpro.Enabled = false;
                    cbedit.Enabled = false;
                    txtWeigthSt.Visible = true;
                    label3.Visible = false;
                    btnrefrash.Focus();
                    msnfrom = this.Name.ToString();
                    idtypelog = 7;//open
                    Savelogevent();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ผิดพลาด !" + ex.Message, "เกิดความผิดพลาดเรื่องน้ำหนักต้นทาง !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CN.Close();
        }

        private void LoadSupproduct()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql3 = "select idpro from vpurchase WHERE idtran ='" + idtran + "'";
            SqlCommand CM3 = new SqlCommand(sql3, CN);
            SqlDataReader DR3 = CM3.ExecuteReader();

            DR3.Read();
            { idpro = Convert.ToInt16(DR3["idpro"].ToString()); }
            DR3.Close();

            string sql1 = "select idsuppro,namesup from vproductinstock where idbranch=" + Program.idbranch + " and idpro=" + idpro + "";

            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(ds, "spropur");
            cbselectpro.DataSource = ds.Tables["spropur"];
            cbselectpro.DisplayMember = "namesup";
            cbselectpro.ValueMember = "idsuppro";
            cbselectpro.Text = "";   
            status = 1;
            CN.Close();
        }

        private void LoadStockBacklog()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); string sql1 = ""; string sql2 = "";

            if (status == 1)
                {
                    sql1 = "select * from tbbranchinstock where idbranch=" + Program.idbranch + " and idsuppro=" + cbselectpro.SelectedValue.ToString().Trim() + "";

                    sql2 = "select idsuppro,namesup,bname from vproductinstock where idbranch=" + Program.idbranch + " and idsuppro=" + cbselectpro.SelectedValue.ToString().Trim() + "";
                }

                if (idpur != "0" && statustruck == 1)
                {
                    sql1 = "select * from tbbranchinstock where idbranch=" + Program.idbranch + " and idsuppro=" + idpro + "";
                   sql2 = "select idsuppro,namesup,bname from vproductinstock where idbranch=" + Program.idbranch + " and idsuppro=" + idpro + "";
                }

                if (status == 1 || statustruck == 1)
                {
                    SqlCommand CM = new SqlCommand(sql1, CN);
                    SqlDataReader DR = CM.ExecuteReader();
                    decimal ton = 0;
                    decimal kk = 0;
                    DR.Read();
                    {
                        kk = Convert.ToInt32(DR["unitstock"].ToString());
                        ton = Convert.ToInt32(DR["unitstock"].ToString()) / 1000;
                    }
                    DR.Close();

                    string lblnamebranch = "";
                    SqlCommand CM2 = new SqlCommand(sql2, CN);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    DR2.Read();
                    {
                        lblnamebranch = "สาขาชั่ง: " + DR2["bname"].ToString();
                    }
                    DR2.Close();
                    lblbranchstock.Text = lblnamebranch + " ยอดค้างคงเหลือ : " + kk.ToString() + " กก. " + ton + " ตัน.";
                }
                CN.Close();  
        }

        private void Loadunitstock()
        {
            try
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open(); string sql="";

                if (statustruck == 0)
                {
                    sql = "select * from tbbranchinstock where idbranch=" + Program.idbranch + " and idsuppro=" + cbselectpro.SelectedValue.ToString().Trim() + "";
                }

                if (statustruck == 1)
                { sql = "select * from tbbranchinstock where idbranch=" + Program.idbranch + " and idsuppro=" + idpro + ""; }
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();
                decimal ton=0;

                DR.Read();
                {
                    Program.unitstock = Convert.ToInt32(DR["unitstock"].ToString());    
                }
                DR.Close();

                idstock = 1;//บอกสถานะว่าไม่มีสินค้าในลานนี้       
                CN.Close();
            }
            catch (Exception ex)
            { MessageBox.Show("ไม่มีสินค้าในสาขานี้ กรุณาเพิ่มสินค้า", "ผิดพลาด !", MessageBoxButtons.OK, MessageBoxIcon.Error); idstock = 0; }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnweigtnsave_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
                decimal weigthtruck = Convert.ToDecimal(txtweigthkk.Text);
                string sumdatebf = "";
                string date = DateTime.Now.Day.ToString();
                string month = DateTime.Now.Month.ToString();
                string year = DateTime.Now.Year.ToString();
                string sumdate = month + "/" + date + "/" + year;
                Program.unitstock = 0;
                DateTime now = DateTime.Now;

                if (statustruck != 2)
                {
                    Loadunitstock();//load stock
                }

            if (idtran != "0" && statustruck == 0 && idstock == 1 && cbselectpro.Text != "" || idtran != "0" & statustruck == 1 && idstock == 1 ||statustruck ==2)//ชั่งรถหนักเข้า
            { 
                if (idstock == 1)//update WeigthBF
                {
                    //string datepur = "";     

                    string sql = "select datepur from tbpurchase where idtran='" + idtran + "'";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    SqlDataReader DR = CM.ExecuteReader();
                    DR.Read();
                    { dts = Convert.ToDateTime(DR["datepur"].ToString()); }
                    DR.Close();

                    string datebf = dts.Day.ToString();
                    string monthbf = dts.Month.ToString();
                    string yearbf = dts.Year.ToString();
                    sumdatebf = monthbf + "/" + datebf + "/" + yearbf;
                }

                if (idtran != "0" && statustruck == 0 && idstock == 1 && cbselectpro.Text != "")//ชั่งรถหนักเข้า (purchase)
                {
                    CheckProduct();
                    string sql1 = "";

                    if (txtWeigthSt.Text == "0")
                    {
                        sql1 = "update tbweigth set dateWbf='" + sumdate + "',timeWbf='" + string.Format("{0:HH:mm:ss}", DateTime.Now) + "',weigthbf=" + weigthtruck + ",wtype='" + textBox4.Text.Trim() + "' where idtran= '" + idtran + "'";
                    }

                    else
                    { sql1 = "update tbweigth set dateWbf='" + sumdate + "',timeWbf='" + string.Format("{0:HH:mm:ss}", DateTime.Now) + "',weigthsup =" + Convert.ToDecimal(txtWeigthSt.Text.Trim()) + ",weigthbf=" + weigthtruck + ",wtype='" + textBox4.Text.Trim() + "' where idtran= '" + idtran + "'"; }

                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();

                    string sql3 = "update tbtransport set idsuppro=" + cbselectpro.SelectedValue.ToString() + " Where idtran= '" + idtran + "'";
                    SqlCommand CM3 = new SqlCommand(sql3, CN);
                    CM3.ExecuteNonQuery();

                    string sql5 = "update tbpurchase set remark3='ชั่งรถเบา'Where idtran= '" + idtran + "'";
                    SqlCommand CM5 = new SqlCommand(sql5, CN);
                    CM5.ExecuteNonQuery();
                    this.Close();
                    btnprint.Enabled = true; btnprint.Focus();
                }

                if (idtran != "0" & statustruck == 1 && idstock == 1)//ชั่งรถเบาออก (purchase)
                {
                    //LoadSupproduct();
                    
                    idpro = Convert.ToInt16(cbselectpro.SelectedValue.ToString());
                    decimal weigthsupdfsale = 0; 
                    decimal weigthdf = weigthbf - weigthtruck; //นน.ส่วนต่าง ๆ = นน.ชั่งหนัก - นน.ชั่งเบา
                    weigthdfsavehisstock = weigthdf;

                    if (weigthsup != 0)
                    {
                        weigthsupdfsale = weigthdf - weigthsup;  //นน.ส่วนต่างของลูกค้ากับซื้อเข้าคลัง = นน.ปลายทาง - นน.ต้นทาง                           //บันทึกเข้า table tbweight
                    }  
                        
                        Program.unitstock = Program.unitstock + weigthdf;

                        string sql3 = "update tbweigth set weigthaf=" + weigthtruck + ",weigthnet=" + weigthdf + ",weigthsupdfsale=" + weigthsupdfsale + ",dateWaf='" + sumdate + "',timeWaf='" + string.Format("{0:HH:mm:ss}", DateTime.Now) + "' Where idtran= '" + idtran + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        //weigthaf=" + weigthdf + ",weigthdf=" + everagew,eigth + ",dateWaf='" + sumdate + "',
                    
                        string sql1 = "update tbtransport set idtruck=" + 3 + ",idsuppro= " + idpro + ",idjobtrack = 6  Where idtran= '" + idtran + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, CN);
                        CM1.ExecuteNonQuery();

                        string sql5 = "update tbpurchase set remark3='รับสินค้าแล้ว',idstatus = 2 Where idtran= '" + idtran + "'";
                        SqlCommand CM5 = new SqlCommand(sql5, CN);
                        CM5.ExecuteNonQuery();
                       
                        string sql6 = "update tbbranchinstock set unitstock=" + Program.unitstock + " Where idsuppro= " + idpro + " and idbranch=" + Program.idbranch + "";//update stock
                        SqlCommand CM6 = new SqlCommand(sql6, CN);
                        CM6.ExecuteNonQuery();

                        SaveHistoryStock();


                        MessageBox.Show("ปรับปรุงข้อมูลเรียบร้อย !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnweigtnsave.Enabled = false;
                        btnprint.Enabled = true;
                        btnclose.Enabled = true;
                        btnprint.Focus();

                        msnfrom = this.Name.ToString();
                        idtypelog = 1;//insert
                        Savelogevent();                    
                }

                if (idtran != "0" & statustruck == 2)  ///Load data ถ้าชั่งน้ำหนัก ชั่งหนักซื้อมาขายไป
                {                   
                    weigthfirst = Convert.ToDecimal(txtWeigthSt.Text);
                    string sql2 = "update tbweigth set dateWbf='" + sumdate + "',timeWbf='" + string.Format("{0:HH:mm:ss}", DateTime.Now) + "',weigthsup=" + weigthfirst + ",weigthbf=" + weigthtruck + ",wtype='" + textBox4.Text.Trim() + "' where idtran= '" + idtran + "'";
                    SqlCommand CM2 = new SqlCommand(sql2, CN);
                    CM2.ExecuteNonQuery();

                    string sql = "update tbtransport set remark1='ชั่งรถเบา'Where idtran= '" + idtran + "'";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();

                    MessageBox.Show("ปรับปรุงข้อมูลเรียบร้อย !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //this.Close(); 
                    btnprint.Enabled = true; btnprint.Focus();
                    btnclose.Enabled = true;

                    msnfrom = this.Name.ToString();
                    idtypelog = 1;//insert
                    Savelogevent();
                }
            }
            CN.Close();
        }

        private void SaveHistoryStock()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string date = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string datehis = month + "/" + date + "/" + year;

            string sql1 = "insert into tbhistorystock(datehis,weightnow,stocknow,idtypeordervat,idtran) values('" + datehis + "'," + weigthdfsavehisstock + "," + Program.unitstock + ",1,'" + idtran + "')";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            CM1.ExecuteNonQuery();
            CN.Close();            
        }

        private void CheckNoweigth()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            int idmaxweigth = 0; string chek = "";

            string keychar = "";
            string sql3 = "select charname from vautokeychar WHERE idbranch =" + Program.idbranch.Trim() + "";
            SqlCommand CM3 = new SqlCommand(sql3, CN);
            SqlDataReader DR3 = CM3.ExecuteReader();

            DR3.Read();
            { keychar = DR3["charname"].ToString().Trim(); }
            DR3.Close();

            int wtype = 0;

              string sql1 = " select  count(wtype)as wtype FROM vchecknoweigth where idbranch ='" + Program.idbranch.Trim() + "' AND wtype Like'%WI%' order by wtype desc";
              SqlCommand CM1 = new SqlCommand(sql1, CN);
              SqlDataReader DR1 = CM1.ExecuteReader();
              DR1.Read();
              {
                  wtype =Convert.ToInt16(DR1["wtype"].ToString());
              } //get weigth id type WI,WO              
              DR1.Close();

              if (wtype != 0)
              {
                  string sql = " select  wtype FROM vchecknoweigth where idbranch ='" + Program.idbranch.Trim() + "' AND wtype Like'%WI%' order by wtype desc";

                  SqlCommand CM = new SqlCommand(sql, CN);
                  SqlDataReader DR = CM.ExecuteReader();
                  DR.Read();
                  { textBox3.Text = DR["wtype"].ToString(); } //get weigth id type WI,WO              
                  DR.Close();
              }
              else { textBox3.Text = "WI-0000"; }

            textBox2.Text = idtran;//ดึงเลขที่การชั่งของ
            //textBox2.SelectionStart = 3;
            //textBox2.SelectionLength = 2;
            //int monthNo = Convert.ToInt16(textBox2.SelectedText.ToString());//get month runorder

            //int month = Convert.ToInt16(DateTime.Now.Month.ToString());

            textBox3.SelectionStart = 3;
            textBox3.SelectionLength = 4;
            int idold = Convert.ToInt16(textBox3.SelectedText.ToString());//get month runorder
            textBox4.Text = idold.ToString();

            //if (monthNo == month)//เทียบว่าเท่ากันให้บวบ  1
            if (idold != -1)
            {
                // idold = idold + 1;
                if (textBox4.Text.Length == 1)
                {
                    if (idold == 9)//WI-0009
                    {
                        idold = idold + 1;
                        textBox4.Text = "WI-00" + idold;
                    }
                    else //WI-0001 - WI-0008
                    {
                        idold = idold + 1;
                        textBox4.Text = "WI-000" + idold;
                    }
                }

                else if (textBox4.Text.Length == 2) //10 - 99
                {
                    if (idold == 99)//WI-0099
                    {
                        idold = idold + 1;
                        textBox4.Text = "WI-0" + idold;
                    }
                    else//WI-0011 - WI-0098}
                    {
                        idold = idold + 1;
                        textBox4.Text = "WI-00" + idold;
                    }
                }

                else if (textBox4.Text.Length == 3)
                {
                    if (idold == 999)//
                    {
                        idold = idold + 1;
                        textBox4.Text = "WI-" + idold;
                    }
                    else//WI-0101 - WI-0998}
                    {
                        idold = idold + 1;
                        textBox4.Text = "WI-0" + idold;
                    }
                }

                else if (textBox4.Text.Length == 4)
                {
                    idold = idold + 1;
                    if (idold != 10000)
                    { textBox4.Text = "WI-" + idold; }
                }
            }

            else
            { textBox4.Text = "WI-0001"; }
            CN.Close();
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

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (idtran != "0" & statustruck == 1)//ชั่งรถหนักเข้า
            {
                Frmreporttruck frpt = new Frmreporttruck();
                frpt.idtran = idtran;               
                frpt.typetruck = "truckin";
                frpt.ShowDialog();
                btnclose.Focus();
            }

            if (idtran != "0" & statustruck == 2)//ชั่งรถหนักเข้า
            {
                Frmreporttruck frpt = new Frmreporttruck();
                frpt.idtran = idtran;
                frpt.typetruck = "truckouttocusaf";
                frpt.ShowDialog();
                btnclose.Focus();
            }  
        }

        private void btnclose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        decimal sweigth;
        private void txtweigthkk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57 || e.KeyChar == 47) && e.KeyChar != 13 && e.KeyChar != 8)
            {
                MessageBox.Show("ป้อนได้แต่ตัวเลขเท่านั้น", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
            else if (e.KeyChar == 13)
            {
                if (txtweigthkk.Text != "")
                {
                   sweigth = Convert.ToDecimal(txtweigthkk.Text);
                    if (sweigth == 0)
                    {
                        MessageBox.Show("ค่าห้ามเป็นศูนย์ค่ะ", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtweigthkk.Focus();                        
                    }
                    //decimal weigthbf = Convert.ToInt32(txtweigthkk.Text);
                   txtweigthkk.Text = sweigth.ToString("#,###.#0");

                   //if (sweigth > 0)
                   //{
                   //    btnweigtnsave.Text = "บันทึก";
                   //    btnweigtnsave.Enabled = true;
                   //    btnweigtnsave.Focus();
                   //}                  
                }
            }
        }

        decimal weigthfirst = 0;
        private void txtWeigthSt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57 || e.KeyChar == 47) && e.KeyChar != 13 && e.KeyChar != 8)
            {
                if (txtWeigthSt.ReadOnly == false)
                {
                    MessageBox.Show("ป้อนได้แต่ตัวเลขเท่านั้น", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Handled = true; txtWeigthSt.Clear();
                }
            }

            if (e.KeyChar == 13 && txtWeigthSt.ReadOnly == false)
            {
                weigthfirst = Convert.ToDecimal(txtWeigthSt.Text);
                if (weigthfirst == 0)
                {
                    MessageBox.Show("ค่าห้ามเป็นศูนย์ค่ะ", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtWeigthSt.Focus();
                }

                txtWeigthSt.Text = weigthfirst.ToString("#,###.#0");
                cbselectpro.Focus();
            }
        }       

        private void btnrefrash_Click(object sender, EventArgs e)
        {
            ConnectToSerail();
            timer1.Enabled = true;            
        }

        private void cbvweigth_CheckedChanged(object sender, EventArgs e)
        {
            if (cbvweigth.Checked == true)
            { gblistbox.Visible = true; }
            else { gblistbox.Visible = false; }
        }

        private void CheckProduct()
        {
            idpro = Convert.ToInt16(cbselectpro.SelectedValue.ToString());
        }

        private void txtweigthkk_TextChanged(object sender, EventArgs e)
        {
            if (txtWeigthSt.Text == "" && txtWeigthSt.Text == "0")
            { txtweigthkk.Text = ""; }
        }

        private void cbselectpro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (status == 1)
            {
                idpro = Convert.ToInt16(cbselectpro.SelectedValue.ToString());
                LoadStockBacklog();
                btnrefrash.Focus();
            }
        }             

        private void cbedit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbedit.Checked == true)
            { cbselectpro.Enabled = true; }
            else { cbselectpro.Enabled = false; }
        }

        int i = 5;
        private void timer1_Tick(object sender, EventArgs e)
        {            
            if (i != 0)
            {
                if (weigthwait == textBox1.Text.Trim())
                {
                    i = i - 1;
                    btnweigtnsave.Text = "Wait: " + i.ToString();
                }
                else
                { i = 6; weigthwait = textBox1.Text.Trim(); }
            }

            else
            {
                btnweigtnsave.Text = "บันทึก";
                btnweigtnsave.Enabled = true;
                timer1.Enabled = false;
            }
        }

        private void cben_CheckedChanged(object sender, EventArgs e)
        {
            if (cben.Checked == true)
            { txtweigthkk.Enabled = true; }
            else txtweigthkk.Enabled = false;
        }

       

    }
}