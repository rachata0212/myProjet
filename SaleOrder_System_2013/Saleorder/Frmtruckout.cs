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
    public partial class Frmtruckout : Form
    {
        private TimeSpan m_timeCount;

        public Frmtruckout()
        {
            InitializeComponent();           
        }
                
        SerialPort sport = new SerialPort();
        DataSet ds = new DataSet();

        string msnfrom = "";                    int idtypelog = 0; 
        public string idorder = "0";            public int statustruck = 0; 
        public string idtran = "";              public decimal weigthbf = 0; 
        public string idcus = "0";              decimal weigthsup = 0; 
        string idcomtran = "0";                 public string dateaf = ""; 
        public decimal weigthaf = 0;            int idpro = 0;
        int idsupro = 0;
        string idcomsup = "";                   int idstock = 0;
        int status = 0;
        //for Truck Scale
        string comport = "";            string baudrate = "";
        int databit = 0;                string parity = "";
        string stopbit = "";            int stkeychar = 0;
        int UnitKeyRecive = 0;          int stlineindex = 0;
        string sumdate = "";
        decimal weigthdfsavehisstock = 0;
        string weigthwait = "";
        string datelog = DateTime.Now.Day.ToString();
        string monthlog = DateTime.Now.Month.ToString();
        string yearlog = DateTime.Now.Year.ToString();
        
        private void LoadTrckConfig()
        {
            try
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();
                string sql = "select * from tbsettruckscale where idbranch='" + Program.idbranch + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();
                DR.Read();
                {
                    comport = DR["Portno"].ToString().Trim();
                    baudrate = DR["BaudRate"].ToString().Trim();
                    databit = Convert.ToInt16(DR["DataBit"].ToString().Trim());
                    parity = DR["Parity"].ToString().Trim();
                    stopbit = DR["StopBit"].ToString().Trim();
                    stkeychar = Convert.ToInt16(DR["StKeychar"].ToString().Trim());
                    UnitKeyRecive = Convert.ToInt16(DR["UnitKeyRecive"].ToString().Trim());
                    stlineindex = Convert.ToInt16(DR["StlineIndex"].ToString().Trim());
                }
                DR.Close();
                CN.Close();
            }
            catch (Exception ex)
            { MessageBox.Show("สาขานี้ไม่ได้เซ็ตตาชั่งไว้ กรุณาตั้งค่าการรับข้อมูลจากตาชั่ง", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

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

        private void Frmtruckout_Load(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql;

            if (statustruck == 0)
            { CheckNoweigth(); } 

            if (idorder != "0" & statustruck == 0)
            {
                //gen data purchase   
                LoadSupproduct();
                lblstatus.Text = "ชั่งรถเบา";txtremark.Text = "-";

                sql = "select * from vonholetruckout where idtran='" + idtran + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();
                btnprint.Enabled = false;

                DR.Read();
                {
                    idpro = Convert.ToInt16(DR["idpro"].ToString());
                    txtcusname.Text = DR["comcus"].ToString();
                    txtsuppliers.Text = DR["comsup"].ToString();
                    txtcar.Text = DR["carname"].ToString();
                    txtserailcar.Text = DR["serailcar"].ToString(); 
                }
                DR.Close();
                cbselectpro.Text = "";
                msnfrom = this.Name.ToString();
                idtypelog = 7;//open
                Savelogevent();  
            }

            if (idorder != "0" & statustruck == 2)  
            {
                lblstatus.Text = "ชั่งรถหนัก";
                txtserailcar.Enabled = false; txtremark.Enabled = false;
                LoadSupproduct();
                sql = "select * from vonholetruckout where idtran='" + idtran + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();
                btnprint.Enabled = false;               
                DR.Read();
                {
                    idpro = Convert.ToInt16(DR["idsuppro"].ToString());
                    txtcusname.Text = DR["comcus"].ToString();                   
                    txtsuppliers.Text = DR["comsup"].ToString();
                    cbselectpro.Text = DR["namesup"].ToString();
                    txtcar.Text = DR["carname"].ToString();
                    txtserailcar.Text = DR["serailcar"].ToString();
                    txtremark.Text = DR["telno"].ToString();
                    weigthbf = Convert.ToDecimal(DR["weigthbf"].ToString());
                    idcomsup = DR["idcomsup"].ToString();
                }
                DR.Close();

                cbselectpro.Enabled = false;
                LoadStockBacklog();                          
                msnfrom = this.Name.ToString();
                idtypelog = 7;//open
                Savelogevent();  
            }

            if (idtran != "" & statustruck == 2 || statustruck == 0)
            {
                string sql1 = "select idcomtran from tbtransport where idtran='" + idtran + "'";
                SqlCommand CM = new SqlCommand(sql1, CN);
                SqlDataReader DR = CM.ExecuteReader();

                DR.Read();
                { idcomtran = DR["idcomtran"].ToString(); }
                DR.Close();

                if (idcomtran != "")
                {
                    string sql2 = "select idcom,cname from tbcompany where idcom='" + idcomtran + "'";
                    SqlCommand CM2 = new SqlCommand(sql2, CN);
                    SqlDataReader DR2 = CM2.ExecuteReader();

                    DR2.Read();
                    { txtcomtran.Text = DR2["cname"].ToString(); }
                    DR2.Close();
                    //cbselectpro.Text = "";
                    msnfrom = this.Name.ToString();
                    idtypelog = 7;//open
                    Savelogevent();  
                }
            }

            if (idtran != "" & statustruck == 3)//ซื้อมา - ขายไป
            {
                lblstatus.Text = "ชั่งรถเบา";
                txtserailcar.Enabled = false;                
                btnprint.Enabled = false;

                sql = "select * from vtranreplyFsTc where idtran='" + idtran + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();
                btnprint.Enabled = false;

                DR.Read();
                {
                    txtcusname.Text = DR["comcus"].ToString();
                    cbselectpro.Text = DR["proname"].ToString();
                    txtsuppliers.Text = DR["comsup"].ToString();
                    txtcomtran.Text = DR["comtran"].ToString();
                    txtcar.Text = DR["carname"].ToString();
                    txtserailcar.Text = DR["serailcar"].ToString();
                    txtremark.Text = DR["telcontact"].ToString();
                    weigthsup = Convert.ToDecimal(DR["weigthsup"].ToString());  
                }
                DR.Close();
                cbselectpro.Enabled = false;
                cbedit.Enabled = false;
                msnfrom = this.Name.ToString();
                idtypelog = 7;//open
                Savelogevent();  
            }
            CN.Close();
        }

        private void LoadSupproduct()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql3 = "select idpro from vsaleorder WHERE idtran ='" + idorder + "'";

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

        private void Loadunitstock()
        {
            try
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open(); string sql = "";

                if (statustruck == 0)
                {
                    sql = "select * from tbbranchinstock where idbranch=" + Program.idbranch + " and idsuppro=" + cbselectpro.SelectedValue.ToString().Trim() + "";
                }

                if (statustruck == 2)
                {
                    sql = "select * from tbbranchinstock where idbranch=" + Program.idbranch + " and idsuppro=" + idpro + "";
                }
                // string sql = "select * from vproduct where idbranch=" + Program.idbranch + " and idpro=" + idpro + "";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();
                //lblstatus.Text = "ชั่งรถหนักเข้า";

                DR.Read();
                { Program.unitstock = Convert.ToInt32(DR["unitstock"].ToString()); }
                DR.Close();
                idstock = 1;
                CN.Close();
            }
            catch (Exception ex)
            { MessageBox.Show("ไม่มีสินค้าในสาขานี้ กรุณาเพิ่มสินค้า", "ผิดพลาด !", MessageBoxButtons.OK, MessageBoxIcon.Error); idstock = 0; }
        }       
    
        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            decimal weigth = 0; decimal dfweigth = 0;
            weigth = Convert.ToDecimal(txtweigthkk.Text.Trim());
            //string selectupdate = "";   

            CheckDate();
            DateTime now = DateTime.Now;

            if (statustruck != 3)
            { Loadunitstock(); }

            if (idtran != "0" & statustruck == 0 & idstock == 1 & weigth !=0 || idtran != "0" & statustruck == 2 & idcomtran != "" & idstock == 1 & weigth !=0 || idtran != "" & statustruck == 3)
            {
                //CheckNoweigth();

                if (idtran != "0" & statustruck == 0 & idstock == 1 & cbselectpro.Text !="")//ชั่งเบาก่อน (Sale)
                {
                    CheckProduct();
                    string sql1 = "update tbtransport set idtruck = 2,telno ='" + txtremark.Text + "',idsuppro=" + cbselectpro.SelectedValue.ToString() + " Where idtran= '" + idtran + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();

                    string sql5 = "update tborder set remark3='ชั่งรถหนัก' Where idtran= '" + idtran + "'";
                    SqlCommand CM5 = new SqlCommand(sql5, CN);
                    CM5.ExecuteNonQuery();

                    string sql3 = "update tbweigth set dateWbf='" + sumdate + "',timeWbf='" + string.Format("{0:HH:mm:ss}", DateTime.Now) + "',weigthbf=" + weigth + ",wtype='" + textBox4.Text.Trim() + "' where idtran= '" + idtran + "'";
                    SqlCommand CM3 = new SqlCommand(sql3, CN);
                    CM3.ExecuteNonQuery();

                    MessageBox.Show("ปรับปรุงข้อมูลเรียบร้อย !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);   
                    msnfrom = this.Name.ToString();
                    idtypelog = 1;//insert
                    Savelogevent();
                    this.Close();
                }


                if (idtran != "0" & statustruck == 2 & idcomtran != "" & idstock == 1)//ชั่งหนัก (Sale)
                {
                    if (txtweigthkk.Text != "")
                    {
                        decimal hardweigth = Convert.ToInt32(txtweigthkk.Text.Trim());
                        idpro = Convert.ToInt16(cbselectpro.SelectedValue.ToString());

                        dfweigth = hardweigth - weigthbf; //น้ำหนักชั่งหนัก - น้ำหนักชั่งเบา
                        weigthdfsavehisstock = dfweigth;

                        string sql3 = "update tbweigth set weigthaf=" + hardweigth + ",weigthnet=" + dfweigth + ",dateWaf='" + sumdate + "',timeWaf='" + string.Format("{0:HH:mm:ss}", DateTime.Now) + "' Where idtran= '" + idtran + "'";                         
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        string sql1 = "update tbtransport set idtruck = 4,idfrom='" + idcomsup + "',idsuppro=" + idpro + " Where idtran= '" + idtran + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, CN);
                        CM1.ExecuteNonQuery();

                        string sql5 = "update tborder set remark3='รอน้ำหนักลูกค้า',idstatus = 1 Where idtran= '" + idtran + "'";
                        SqlCommand CM5 = new SqlCommand(sql5, CN);
                        CM5.ExecuteNonQuery();

                        Program.unitstock = Program.unitstock - dfweigth;
                        string sql6 = "update tbbranchinstock set unitstock=" + Program.unitstock + " Where idsuppro= " + idpro + " and idbranch=" + Program.idbranch + "";//update stock
                        SqlCommand CM6 = new SqlCommand(sql6, CN);
                        CM6.ExecuteNonQuery();

                        SaveHistoryStock();

                        MessageBox.Show("ปรับปรุงข้อมูลเรียบร้อย !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        msnfrom = this.Name.ToString();
                        idtypelog = 2;//insert
                        Savelogevent();
                        btnweigtnsave.Enabled = false;
                        btnprint.Enabled = true;
                        btnclose.Enabled = true;                       
                    }
                }

                if (idtran != "" & statustruck == 3) //(pur to sale)
                {
                    decimal totalweigth = 0;   //น้ำหนักสุทธิต่าง 
                    dfweigth = weigthbf - weigth;//น้ำหนักปลายทางสุทธิ = น้ำหนักชั่งเข้า - น้ำหนักเบาชั่งออก

                    if (weigthsup != 0)
                    {
                        totalweigth = dfweigth - weigthsup;   //น้ำหนักสุทธิต่าง = น้ำหนักต้นทางสุทธิ - น้ำหนักโรงปาล์ม
                    }
                    string sql3 = "update tbweigth set weigthaf=" + weigth + ",weigthnet=" + dfweigth + ",weigthsupdfsale=" + totalweigth + ",timeWaf='" + string.Format("{0:HH:mm:ss}", DateTime.Now) + "' Where idtran= '" + idtran + "'";
                    SqlCommand CM3 = new SqlCommand(sql3, CN);
                    CM3.ExecuteNonQuery();

                  //  string sql1 = "update tbtransport set idtruck = 3,remark1='ชั่งเสร็จสมบูรณ์' Where idtran= '" + idtran + "'";
                    string sql1 = "update tbtransport set idtruck = 3 Where idtran= '" + idtran + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();
                    btnprint.Enabled = true;
                    btnclose.Enabled = true;
                    btnclose.Focus();
                    btnweigtnsave.Enabled = false;
                }
            }
            CN.Close();
        }

        private void CheckDate()
        {
            string date = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            sumdate = month + "/" + date + "/" + year;
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

            string sql1 = "insert into tbhistorystock(datehis,weightnow,stocknow,idtypeordervat,idtran) values('" + datehis + "'," + weigthdfsavehisstock + "," + Program.unitstock + ",2,'" + idtran + "')";
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

            int idcountweigth = 0;

            string sqlwe = "SELECT COUNT(wtype) AS idcountweigth FROM vchecknoweigth where idbranch ='" + Program.idbranch.Trim() + "' AND wtype Like'%WO%'";

            SqlCommand CMw = new SqlCommand(sqlwe, CN);
            SqlDataReader DRw = CMw.ExecuteReader();
            DRw.Read();
            { idcountweigth = Convert.ToInt16(DRw["idcountweigth"].ToString()); }
            DRw.Close();

            if (idcountweigth != 0)
            {
                string sql = " select  wtype FROM vchecknoweigth where idbranch ='" + Program.idbranch.Trim() + "' AND wtype Like'%WO%' order by wtype desc";

                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();
                DR.Read();
                {

                    textBox3.Text = DR["wtype"].ToString(); //get weigth id type WI,WO                  
                }
                DR.Close();
            }

            if (idcountweigth == 0)
            { textBox3.Text = "WO-000"; }

            textBox2.Text = idtran;//ดึงเลขที่การชั่งของ
            //textBox2.SelectionStart = 3;
            //textBox2.SelectionLength = 2;
            //int monthNo = Convert.ToInt16(textBox2.SelectedText.ToString());//get month runorder

            // DateTime now = new DateTime();// get month now
            //int month = Convert.ToInt16(DateTime.Now.Month.ToString());

            textBox3.SelectionStart = 3;
            textBox3.SelectionLength = 4;
            int idold = Convert.ToInt16(textBox3.SelectedText.ToString());//get month runorder
            textBox4.Text = idold.ToString();

            //if (monthNo == month)//เทียบว่าเท่ากันให้บวบ  1
            if(idold != -1)
            {
                // idold = idold + 1;
                if (textBox4.Text.Length == 1)
                {
                    if (idold == 9)//WI-0009
                    {
                        idold = idold + 1;
                        textBox4.Text = "WO-00" + idold;
                    }
                    else //WI-0001 - WI-0008
                    {
                        idold = idold + 1;
                        textBox4.Text = "WO-000" + idold;
                    }
                }

                else if (textBox4.Text.Length == 2) //10 - 99
                {
                    if (idold == 99)//WI-0099
                    {
                        idold = idold + 1;
                        textBox4.Text = "WO-0" + idold;
                    }
                    else//WI-0011 - WI-0098}
                    {
                        idold = idold + 1;
                        textBox4.Text = "WO-00" + idold;
                    }
                }

                else if (textBox4.Text.Length == 3)
                {
                    if (idold == 999)//
                    {
                        idold = idold + 1;
                        textBox4.Text = "WO-" + idold;
                    }
                    else//WI-0101 - WI-0998}
                    {
                        idold = idold + 1;
                        textBox4.Text = "WO-0" + idold;
                    }
                }

                else if (textBox4.Text.Length == 4)
                {
                    idold = idold + 1;
                    if (idold != 10000)
                    { textBox4.Text = "WO-" + idold; }
                }
            }

            else
            { textBox4.Text = "WO-0001"; }
            CN.Close();
        }  

        private void Frmtruckout_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnsearchcomtran_Click(object sender, EventArgs e)
        {
            string sql;
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string id = "0";
            try
            {
                Frmserch fs = new Frmserch();
                fs.sname = "ssendcom";
                fs.ShowDialog();
                id = fs.returnid;

                if (id != "0")
                {
                    sql = "select * from vcompany where idcom='" + id + "'";
                    SqlCommand CM1 = new SqlCommand(sql, CN);
                    SqlDataReader DR1 = CM1.ExecuteReader();                 

                    DR1.Read();
                    {
                        idcomtran = DR1["idcom"].ToString().Trim();
                        txtcomtran.Text = DR1["cname"].ToString().Trim();
                    }
                    DR1.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error !" + ex.Message);
            }
            CN.Close();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (idtran != "0" & statustruck == 2)//ชั่งรถเบาออก
            {
                Frmreporttruck frpt = new Frmreporttruck();
                frpt.idtran = idtran;
                frpt.typetruck = "truckout";
                frpt.ShowDialog();
            }
            if (idtran != "0" & statustruck == 3)
            {                
                Frmselect_printtruck frpt = new Frmselect_printtruck();
                frpt.idtran = idtran;               
                frpt.ShowDialog();
            }           
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //decimal weigthfirst=0;    
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

        private void cbselectpro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbselectpro.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                if (status == 1 || statustruck == 2)
                {
                    //idsupro = Convert.ToInt16(cbselectpro.SelectedValue.ToString());
                    idpro = Convert.ToInt16(cbselectpro.SelectedValue.ToString());
                    LoadStockBacklog();
                    btnrefrash.Focus();
                }
            }
        }
        
        private void LoadStockBacklog()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); string sql1 = ""; string sql2 = "";
            idsupro = idpro;

            if (idsupro != 0)
            {
                sql1 = "select * from tbbranchinstock where idbranch=" + Program.idbranch + " and idsuppro=" + idsupro + "";

                sql2 = "select idsuppro,namesup,bname from vproductinstock where idbranch=" + Program.idbranch + " and idsuppro=" + idsupro + "";

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

          
            //if (idorder != "0" && statustruck == 1 || statustruck == 2 || idsupro != 0)
            //{
            //    if (statustruck == 1)
            //    { 
            //        sql1 = "select * from tbbranchinstock where idbranch=" + Program.idbranch + " and idsuppro=" + idsupro + "";
            //        sql2 = "select idsuppro,namesup,bname from vproductinstock where idbranch=" + Program.idbranch + " and idsuppro=" + idsupro + "";
            //    }
            //    if (statustruck == 2)
            //    {
            //        //idsupro = idpro;
            //        sql1 = "select * from tbbranchinstock where idbranch=" + Program.idbranch + " and idsuppro=" + idpro + "";
            //        sql2 = "select idsuppro,namesup,bname from vproductinstock where idbranch=" + Program.idbranch + " and idsuppro=" + idpro + "";     
            //    }  
            //}
            CN.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnmaps_Click(object sender, EventArgs e)
        {
            string idcomcus = "";
            string viewpath = "";
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql1 = "select idcomcus from vonholetruckoutFrombrach where idtran='" + idtran + "'";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            { idcomcus = DR1["idcomcus"].ToString(); }
            DR1.Close();

            try
            {
                string sql2 = "select filepath from tbmaps where idcom='" + idcomcus + "'";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();

                DR2.Read();
                { viewpath = DR2["filepath"].ToString(); }
                DR2.Close();

                System.Diagnostics.Process.Start(viewpath);
            }
            catch (Exception ex)
            { MessageBox.Show("ไม่พบไฟล์ที่คุณต้องการเปิด", "ผิดพลาด !", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            CN.Close();
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