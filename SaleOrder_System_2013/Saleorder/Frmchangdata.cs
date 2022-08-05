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
    public partial class Frmchangdata : Form
    {
        public Frmchangdata()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet(); dtssaleorder dssearch = new dtssaleorder();
        DataSet ds1 = new DataSet(); dtssaleorder dssearch1 = new dtssaleorder();

        //เป็นค่ารับส่งผ่านระหว่างฟอร์ม                     
        public string idtranno = "0";       //ตัวแปร ไอดีขนส่ง เก่า ก่อนมีการเปลี่ยนแปลง idtran
        public int idordermenu = 0;         //ตัวแปร บอกประเภทการทำงานของแต่ละส่วน
        public int idbranch = 0;               //ตัวแปรสาขา
 
        int idmatchok = 0;                  //ตัวแปร id เอาไว้เช็คสินค้าว่า order ซื้อกับ order ขายตรงกันหรือไม่
        string remark = "";                 //ตัวแปร หมายเหตุของ tbtransport remark1
        int truckpass = 0;                  //ตัวแปร เช็คว่าผ่านสาขาหรือไม่        
        string IdtranNewgen = "0";          //ตัวแปร ไอดีขนส่งใหม่ เมื่อมีการเปลี่ยนแปลง idtran
        int idsearchsuppro = 0;             //ตัวแปร เก็บค่า ไอดีสินค้าย่อย
        string KeycharbyIDbranch = "";      //ตัวแปร เก็บค่าอักษรของสาขา
        string sumdate = "";                //ตัวแปร เก็บค่าวันที่ปัจจุบัน
        int idunlock = 0;                   //ตัวแปร เช็คการปลดล๊อกการเปลี่ยนแปลง
        int idmenuunlock = 0;
        string pwdunlock = "";
        //
        int ideventform = 0;                  //ตัวแปร เหตุการเปลี่ยนแปลง
        string msnfrom = "";                 //ตัวแปร เก็บการเปลี่ยนแปลงเหตุการณ์ฟอร์ม

        //------------- การยกเลิกหรือเปลี่ยนแปลง
        int idcancle = 0;       

        //------------------------  เก็บค่าเดิมก่อนมีการเปลี่ยนแปลง
        int idpro = 0;              string namepro = "";
        string idcus = "";          string namecus = "";                
        string idcomtran = "";      string namecomtran = "";  
        
        int idtypecar = 0;          string nametypecar = "";        
        string nameserail = ""; 
        string namebranch = "";
        string idcomsup = "";
        string idcompur = "";
        string idpur = "";            
        string idorder = "";
        int idsuppro = 0;
        // ------------------------------------------

        string datelog = DateTime.Now.Day.ToString();
        string monthlog = DateTime.Now.Month.ToString();
        string yearlog = DateTime.Now.Year.ToString();


        private void LoadDatetimeNow() //------------- Check Date time now!!!
        {
            string dnow = DateTime.Now.Day.ToString();
            string mnow = DateTime.Now.Month.ToString();
            string ynow = DateTime.Now.Year.ToString();
            sumdate = mnow + "/" + dnow + "/" + ynow;
        }
            

        private void Savelogevent()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string selectdatelog = monthlog + "/" + datelog + "/" + yearlog;
            string sql1 = "insert into tblog(logname,datein,timein,idtypelog,idemp,remark) values('" + msnfrom + "','" + selectdatelog + "','" + DateTime.Now.ToLongTimeString() + "'," + ideventform + ",'" + Program.empID + "','" + IdtranNewgen + "')";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            CM1.ExecuteNonQuery();
            CN.Close();
        }

        /*
         * 
         * ID table Change Data
    	1	ยกเลิก Order ซื้อสินค้า                               
	2	ยกเลิก Order ขายสินค้า                                
	3	ยกเลิก Order ซื้อ -> ขาย                               
	4	ยกเลิก ชั่งเข้า                                 
	5	ยกเลิก ชั่งออก                                  
	6	เปลี่ยนแปลงลูกค้า                                 
	7	เปลี่ยนแปลงสินค้า                                 
	8	เปลี่ยนแปลงบริษัทขนส่ง
	9	เปลี่ยนแปลงชนิด/ประเภทรถ
	10	เปลี่ยนแปลงทะเบียนรถ
	11	เปลี่ยนแปลงสาขาจัดส่ง
	12	เปลี่ยนแปลง Order [ซื้อ - คลัง] -> [ซื้อ - ขาย]
	13	เปลี่ยนแปลง Order [ซื้อ - ขาย] -> [ซื้อ - คลัง]
	14	เปลี่ยนแปลง Order [คลัง1 - ขาย] -> [คลัง1 - คลัง1]
	15	เปลี่ยนแปลง Order [คลัง1 - ขาย] -> [คลัง1 - คลัง2]
	16	กู้ Order ซื้อสินค้า     
	17	กู้ Order ขายสินค้า        
	18	กู้ Order ซื้อ -> ขาย   
	19	สร้าง Order เพิ่มเติม
         * 
         * pattlen       
         * 
         * idcancle =xx
         * SaveLogchagedata();
         * 
         * */

        private void SaveLogchagedata()//insert tbjobcancle record
        {            
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql = "insert into tbcanclejobrecord (rmidcacle,cancledate,cancletime,remarkcancle,idtypecancle,idbranch) values ('" + idtranno + "','" + sumdate + "','" + DateTime.Now.ToLongTimeString() + "','" + txtremarkcancle.Text.Trim() + "'," + idcancle + "," + Program.idbranch + ")";
            SqlCommand CM = new SqlCommand(sql, CN);
            CM.ExecuteNonQuery();
            CN.Close();
        }

        private void DisableRadionGBtransport()
        {
            rdoccuspro.Checked = false;
            rdoctypepro.Checked = false;
            rdoctran.Checked = false;
            rdoctypecar.Checked = false;
            rdocserailcar.Checked = false;
            rdocbranch.Checked = false;
            groupBox2.Enabled = false;

        }

        private void DisableRadionGBChageOrder()
        {
            rdocorderptob.Checked = false;
            rdocptosale1.Checked = false;
            rdocorderb1tosale.Checked = false;
            rdocorderb2tosale.Checked = false;
            cbbranch.Enabled = true;
            txtnamecus.Clear();
            rdooldorder.Checked = false;
            txtneworderid.Clear();
            rdoneworder.Checked = false;
            rdonopass.Checked = false;
            rdopass.Checked = false;
        }

        private void DisableRadionGBCancleOrder()
        {
            rdocanclepurchase.Checked = false;
            rdocanclesale.Checked = false;
            rdocanclepurtosale.Checked = false;           
        }

        private void FrmChageCar_Load(object sender, EventArgs e)
        {
            LoadDatetimeNow(); 
            ideventform = 7;
            msnfrom = "Open FormChange Data";
            Savelogevent();            
            lblidchange.Text = idtranno;

            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            //idordermenu == 1      Purchase  คลัง
            // idordermenu == 2     Sale  คลัง
            //idordermenu == 4      Purchase ขนส่ง
            // idordermenu == 5     Sale คลัง
            //idordermenu == 6      Purchase ขนส่ง หลังจากส่งให้สาขาแล้ว
            // idordermenu == 7     Sale คลัง หลังจากส่งให้สาขาแล้ว
            // idordermenu == 8     ซื้อมา - ขายไป
            //data purchase

            ChangStatusColor();

            if (idordermenu == 0)
            {
               
            }

            if (idordermenu == 1 || idordermenu == 8)//from warehouse
            {
             

                string sql = "select * from vpurchase where idtran='" + idtranno + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    idpur = DR1["idpur"].ToString().Trim();
                    namepro = DR1["proname"].ToString().Trim(); }
                DR1.Close();
            }

            //data saleorder
            if (idordermenu == 2 || idordermenu == 3 || idordermenu == 8)  //from warehouse
            {
               
                string sql = "select * from vsaleorder where idtran='" + idtranno + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    idorder = DR1["idorder"].ToString().Trim();
                    namecus = DR1["comcus"].ToString().Trim();
                    namepro = DR1["proname"].ToString().Trim();
                }
                DR1.Close();
                
            }

            if (idordermenu == 4)//change pruchase from transport
            {    
                
                string sql = "select * from vpurchase where idpur='" + idtranno + "'";

                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    idpur = DR1["idpur"].ToString().Trim();
                    nameserail = DR1["serailcar"].ToString().Trim();
                    namepro = DR1["proname"].ToString().Trim();
                    nametypecar = DR1["carname"].ToString().Trim();
                }
                DR1.Close();
                //Searchbranch1();
            }

            if (idordermenu == 5 && idtranno != "0")//change sale from transport
            {                             
                
                string sql = "select * from vsaleorder where idorder='" + idtranno + "'";

                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    idorder = DR1["idorder"].ToString().Trim();
                    namepro = DR1["proname"].ToString().Trim();
                    nametypecar = DR1["carname"].ToString().Trim();
                    namecus = DR1["comcus"].ToString().Trim();                    
                }
                DR1.Close();
            }

            if (idordermenu == 6 && idtranno !="0")//change pruchase from transport 
            {    
                string sql = "select * from vonholetruckin where idtran='" + idtranno + "'";

                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    idpur = DR1["idfrom"].ToString().Trim();
                    idbranch = Convert.ToInt16(DR1["idbranch"].ToString().Trim());
                    idsuppro = Convert.ToInt16(DR1["idsuppro"].ToString().Trim());
                    idcompur = DR1["idcompur"].ToString().Trim();
                    idcomtran = DR1["idcomtran"].ToString().Trim();  
                    namecomtran = DR1["comtran"].ToString().Trim();                    
                    nameserail = DR1["serailcar"].ToString().Trim();
                    idpro = Convert.ToInt16(DR1["idpro"].ToString().Trim());
                    namepro = DR1["proname"].ToString().Trim();
                    nametypecar = DR1["carname"].ToString().Trim();
                    namebranch = DR1["bname"].ToString().Trim();
                }
                DR1.Close();

                Searchbranch1();
                Searchbranch2();
            }

            if (idordermenu == 7 && idtranno != "0")//change sale from transport
            {
                if (idtranno != "0")
                {
                    string sql = "select * from vonholetruckout where idtran='" + idtranno + "'";

                    SqlCommand CM1 = new SqlCommand(sql, CN);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    {
                        idorder = DR1["idto"].ToString().Trim();
                        idbranch = Convert.ToInt16(DR1["idbranch"].ToString().Trim());
                        idpro = Convert.ToInt16(DR1["idpro"].ToString().Trim());//เดิมเป็น idsuppro แต่แปลงใน views แล้ว
                        namecus = DR1["comcus"].ToString().Trim();
                        idcomsup = DR1["idcomsup"].ToString().Trim();
                        idcomtran = DR1["idcomtran"].ToString().Trim();
                        namecomtran = DR1["comtran"].ToString().Trim();
                        nameserail = DR1["serailcar"].ToString().Trim();
                        namepro = DR1["proname"].ToString().Trim();
                        nametypecar = DR1["carname"].ToString().Trim();
                        namebranch = DR1["bname"].ToString().Trim();
                    }
                    DR1.Close();
                }

                Searchbranch1();
                Searchbranch2();
            }

            if (idordermenu == 8 && idtranno != "0")//change purchase to sale
            {          
      
                if (idtranno != "0")
                {
                    string sql = "select * from vFsTcFortrasport where idtran='" + idtranno + "'";

                    SqlCommand CM1 = new SqlCommand(sql, CN);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    { 
                        idpro = Convert.ToInt16(DR1["idpro"].ToString().Trim());//เดิมเป็น idsuppro แต่แปลงใน views แล้ว
                        idcomtran = DR1["idcomtran"].ToString().Trim();  
                        idcus = DR1["idcomcus"].ToString().Trim();   
                        namecus = DR1["comcus"].ToString().Trim();
                        idtypecar = Convert.ToInt16(DR1["idcar"].ToString().Trim());
                        txtserailcar.Text = DR1["serailcar"].ToString().Trim(); 
                    }
                    DR1.Close();
                }
                Searchbranch1();
            }
            CN.Close();          
        }

        private void Searchbranch1()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();           
           
            string sql2 = "select idbranch,bname from vautokeychar ";
            SqlDataAdapter da2 = new SqlDataAdapter(sql2, CN);
            da2.Fill(ds1, "loadbranch");

            comboBox1.DataSource = ds1.Tables["loadbranch"];
            comboBox1.DisplayMember = "bname";
            comboBox1.ValueMember = "idbranch";
            CN.Close();
        }

        private void Searchbranch2()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql1 = "select idbranch,bname from vautokeychar ";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(ds, "loadbranch");

            cbbranch.DataSource = ds.Tables["loadbranch"];
            cbbranch.DisplayMember = "bname";
            cbbranch.ValueMember = "idbranch";
            CN.Close();
        }           

        private void rdocorderptob_CheckedChanged(object sender, EventArgs e)
        {
            if (rdocorderptob.Checked == true)
            {
                DisableRadionGBtransport();                            
                rdocanclepurchase.Checked = false;              
                rdonopass.Checked = true;
                lbldepchangorder2.Text = "คำอธิบาย: ใช้ในกรณี รับสินค้าเข้าคลัง แล้วเปลี่ยนไปส่งให้ลูกค้าแทน";
                idmenuunlock = 10;
            }         
        }

        private void rdocptosale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdocptosale1.Checked == true)
            {
                DisableRadionGBtransport();
                lbldepchangorder2.Text = "คำอธิบาย: ใช้ในกรณี ส่งสินค้าลูกค้าแล้วทำการยกเลิก แล้วสินค้าเข้า สาขาเดิม";
                groupBox2.Enabled = true;
                rdoneworder.Checked = true;

                rdooldorder.Enabled = false; btnold.Enabled = false;
                rdoneworder.ForeColor = Color.Black;
                btnnew.ForeColor = Color.Red;
                
                rdopass.ForeColor = Color.Red;
                rdopass.Checked = true;
                rdonopass.Enabled = false;
                btnnew.Enabled = false;
                idmenuunlock = 11;
            }
        }

        private void rdocorderb1tosale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdocorderb1tosale.Checked == true)
            {
                DisableRadionGBtransport();              
                lbldepchangorder2.Text = "คำอธิบาย: ใช้ในกรณี ส่งสินค้าให้ลูกค้าแล้วยกเลิก แล้วรับสินค้าเข้า สาขาเดิม";            
                rdopass.ForeColor = Color.Red;               
                rdopass.Checked = true;  
                idmenuunlock = 12;
            }       
        }

        private void rdocorderb2tosale_CheckedChanged(object sender, EventArgs e)
        { 
            if (rdocorderb2tosale.Checked == true)
            {
                DisableRadionGBtransport();
                lbldepchangorder2.Text = "คำอธิบาย: ใช้ในกรณี ส่งสินค้าให้ลูกค้าแล้วยกเลิก แล้วรับสินค้าเข้า ต่างสาขา";                
                rdopass.ForeColor = Color.Red;
                rdopass.Checked = true;
                idmenuunlock = 13;
                comboBox1.Text = "";  
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();

                string sql2 = "select idbranch,bname from vautokeychar where idbranch=" + idbranch + "";
                SqlDataAdapter da2 = new SqlDataAdapter(sql2, CN);
                da2.Fill(ds1, "loadbranch");

                comboBox1.DataSource = ds1.Tables["loadbranch"];
                comboBox1.DisplayMember = "bname";
                comboBox1.ValueMember = "idbranch";
                CN.Close();
            }  
        }

        private void rdocanclepurtosale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdocanclepurtosale.Checked == true)
            {
                DisableRadionGBtransport();
                DisableRadionGBChageOrder();               
                lbldepchangorder1.Text = "คำอธิบาย: ใช้ในกรณี ยกเลิกการทำ  Order ซื้อ -> ขาย"; }          
        }

        private void rdorecoverypurchase_CheckedChanged(object sender, EventArgs e)
        {
            if (rdorecoverypurchase.Checked == true)
            {
                DisableRadionGBtransport();
                DisableRadionGBChageOrder();              
                lbldepchangorder1.Text = "คำอธิบาย: ใช้ในกรณี ต้องการคืน Order ซื้อที่ทำการยกเลิกไปแล้ว";
                idmenuunlock = 17;
            }          
        }

        private void rdorecoverysale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdorecoverysale.Checked == true)
            {
                DisableRadionGBtransport();
                DisableRadionGBChageOrder();                
                lbldepchangorder1.Text = "คำอธิบาย: ใช้ในกรณี ต้องการคืน Order ขายที่ทำการยกเลิกไปแล้ว";
                idmenuunlock = 18;
            }         
        }              

        private void SearchProduct()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            try
            {
                string sql = "select idsuppro from vproductinstock where idpro='" + idpro + "' AND idbranch='" + idbranch + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    idsuppro = Convert.ToInt16(DR1["idsuppro"].ToString().Trim());
                }
                DR1.Close();
            }
            catch
            { MessageBox.Show("สินค้าชนิดนี้ไม่มีในสาขานี้กรุณาไปเพิ่มชนิดสินค้าและสต๊อก", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); idsuppro = 0; }

            CN.Close();
        }

        private void tbnspro_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            //idordermenu == 1      Purchase  คลัง
            // idordermenu == 2     Sale  คลัง
            //idordermenu == 4      Purchase ขนส่ง
            // idordermenu == 5     Sale คลัง
            //idordermenu == 6      Purchase ขนส่ง หลังจากส่งให้สาขาแล้ว
            // idordermenu == 7     Sale คลัง หลังจากส่งให้สาขาแล้ว

            if (idordermenu == 1 || idordermenu == 2 || idordermenu == 4 || idordermenu == 5 || idordermenu == 6 || idordermenu == 7)
            {
                Frmserch fs = new Frmserch();
                fs.sname = "spropur";
                fs.ShowDialog();
                if (fs.returnid.Trim() != "0")
                {
                    string sql = "select * from tbproduct where idpro='" + fs.returnid.Trim() + "'";
                    SqlCommand CM1 = new SqlCommand(sql, CN);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    {
                        idpro = Convert.ToInt16(DR1["idpro"].ToString().Trim());
                        txtcproduct.Text = DR1["proname"].ToString().Trim();
                    }
                    DR1.Close();
                }
            }

            CN.Close();
        }

        private void btnscus_Click(object sender, EventArgs e)
        {
            Frmserch fs = new Frmserch();
            fs.sname = "scomcus";
            fs.ShowDialog();

            if (fs.returnid != "0")
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();
                string sql = "select idcom,cname from vcompany where idcom='" + fs.returnid + "'";//"update vcompany set idcom='" + fs.returnid + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    idcus = DR1["idcom"].ToString().Trim();
                    txtscuspro.Text = DR1["cname"].ToString().Trim();
                }
                DR1.Close();
                CN.Close();
            }
        }
      
        private void btnsComtran_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            Frmserch fs = new Frmserch();
            fs.sname = "ssendcom";
            fs.ShowDialog(); string id;
            id = fs.returnid;

            if (id != "0")
            {
                string sql = "select * from vcompany where idcom='" + id + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();


                DR1.Read();
                {
                    idcomtran = DR1["idcom"].ToString().Trim();
                    txtctran.Text = DR1["cname"].ToString().Trim();
                }
                DR1.Close();
            }

            CN.Close();
        }        

        private void btnstypcar_Click(object sender, EventArgs e)
        {            
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            Frmserch fs = new Frmserch();
            fs.sname = "scar";
            fs.ShowDialog(); string id;
            id = fs.returnid;

            if (id != "0")
            {
                string sql = "select idcar,carname from vcar where idcar='" + id + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();
                idtypecar = Convert.ToInt16(id);

                DR1.Read();
                {
                    idtypecar = Convert.ToInt16(DR1["idcar"].ToString().Trim());
                    txtccar.Text = DR1["carname"].ToString().Trim();
                }
                DR1.Close();
            }

            CN.Close();
        } 
       
        private void ConvertIDpro_IDsuppro()
        {
            try
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();
                string sql1 = "SELECT idsuppro FROM vproductinstock WHERE (idpro = " + idpro + ") AND (idbranch = " + idbranch + ")";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                { idsuppro = Convert.ToInt16(DR1["idsuppro"].ToString()); }
                DR1.Close();
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่มีสินค้าชนิดนี้ในสาขา กรุณาเลือกสินค้าให้ถูกต้องหรือไปเพิ่มสินค้าเข้าสต๊อก", "ผิดพลาด !", MessageBoxButtons.OK, MessageBoxIcon.Error); idsuppro = 0;
            }
        }

        private void MessageOK()
        { MessageBox.Show("ปรับปรุงข้อมูลเรียบร้อย!", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        private void bntsavechage_Click(object sender, EventArgs e)
        {
            CheckUnlockpwd();

            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();            
            //idordermenu == 1      Purchase  คลัง
            // idordermenu == 2     Sale  คลัง
            //idordermenu == 4      Purchase ขนส่ง
                // idordermenu == 5     Sale คลัง
            //idordermenu == 6      Purchase ขนส่ง หลังจากส่งให้สาขาแล้ว
            // idordermenu == 7     Sale คลัง หลังจากส่งให้สาขาแล้ว
            if (pwdunlock == txtconfirmpwd.Text.Trim() && txtremarkcancle.Text.Trim() != "")
            {
                if (idordermenu == 0)//ซ้อมา ขายไป
                {  
                    if (rdorecoverypurchase.Checked == true)//กู้ระบบการซื้อ
                    {
                        //update tbpurchase
                        string sql1 = "update tbpurchase set idstatus = 4,remark2 = '-',editstatus = 0,idtran = null where idpur= '" + idpur + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, CN);
                        CM1.ExecuteNonQuery();

                        idcancle = 16;
                        SaveLogchagedata();
                    }

                    if (rdorecoverysale.Checked == true)//กู้ระบบการขาย
                    {
                        //update tbpurchase
                        string sql1 = "update tborder set idstatus = 3,remark2 = '-',editstatus = 0,idtran = null where idorder= '" + idcus + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, CN);
                        CM1.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 17;
                        SaveLogchagedata();
                    }

                    if (rdorecoverypurtosale.Checked == true)
                    {
                        //ต้องลบ
                        string sql6 = "DELETE FROM tbtransport WHERE idtran =('" + idtranno + "')";
                        SqlCommand CM6 = new SqlCommand(sql6, CN);
                        CM6.ExecuteNonQuery();

                        //ต้องลบ
                        string sql5 = "DELETE FROM tbweigth WHERE idtran =('" + idtranno + "')";
                        SqlCommand CM5 = new SqlCommand(sql5, CN);
                        CM5.ExecuteNonQuery();

                        //update status from table purchase
                        string sql2 = "update tbpurchase set idstatus= 2,idtran='" + IdtranNewgen + "'Where idpur= '" + idpur + "'";
                        SqlCommand CM2 = new SqlCommand(sql2, CN);
                        CM2.ExecuteNonQuery();

                        //update status from table Order
                        string sql3 = "update tborder set idstatus= 1,idtran='" + IdtranNewgen + "'Where idorder= '" + idcus + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        if (rdonopass.Checked == true)//ถ้าซื้อแล้วไม่ผ่านสาขา
                        {
                            remark = "-";
                            //ซื้อจากผู้ผลิต และส่งให้ลูกค้า ให้บันทึก idsup -> idcus  insert into tbpurchase  
                            string sql1 = "insert into tbtransport(idtran,senddate,idfrom,idto,idcomtran,idtruck,truckpass,remark1) values ('" + IdtranNewgen + "','" + sumdate + "','" + idpur + "','" + idcus + "','" + idcomtran + "',4," + truckpass + ",'" + remark + "')";

                            SqlCommand CM1 = new SqlCommand(sql1, CN);
                            CM1.ExecuteNonQuery();
                        }

                        if (rdopass.Checked == true)  //ถ้าซื้อแล้วผ่านสาขา
                        {
                            //ซื้อจากผู้ผลิต และส่งให้ลูกค้า ให้บันทึก idsup -> idcus  insert into tbpurchase  
                            string sql1 = "insert into tbtransport(idtran,senddate,idfrom,idto,idcomtran,idtruck,idbranch,truckpass,remark1) values ('" + IdtranNewgen + "','" + sumdate + "','" + idpur + "','" + idcus + "','" + idcomtran + "',4," + idbranch + "," + truckpass + ",'" + remark + "')";

                            SqlCommand CM1 = new SqlCommand(sql1, CN);
                            CM1.ExecuteNonQuery();
                        }
                        

                        string sql4 = "insert into tbweigth(idtran) values('" + IdtranNewgen + "')";
                        SqlCommand CM4 = new SqlCommand(sql4, CN);
                        CM4.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 18;
                        SaveLogchagedata();
                    }
                }

                if (idordermenu == 1)//ตาชั่งเปลี่ยนแปลงข้อมูล การชั่งเข้า
                {
                    if (rdoctypepro.Checked == true)
                    { ConvertIDpro_IDsuppro(); }

                    if (idsuppro != 0 && rdoctypepro.Checked == true)
                    {
                        string sql3 = "update tbpurchase set idpro='" + idpro + "',remark2= 'เปลี่ยนสินค้าจาก: " + namepro + " เป็น " + txtcproduct.Text.Trim() + "',editstatus = 1 Where idtran= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        string sql2 = "update tbtransport set idsuppro='" + idsuppro + "' Where idtran= '" + idtranno + "'";
                        SqlCommand CM2 = new SqlCommand(sql2, CN);
                        CM2.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 7;
                        SaveLogchagedata();
                    }

                    if (idtypecar != 0 && rdoctypecar.Checked == true)//เปลี่ยนประเภทรถ
                    {
                        string sql3 = "update tbpurchase set idcar='" + idtypecar + "',remark2= 'เปลี่ยนประเภทรถจาก: " + nametypecar + " เป็น " + txtccar.Text.Trim() + "',editstatus = 1 Where idtran= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 9;
                        SaveLogchagedata();
                    }

                    if (txtserailcar.Text != "" && rdocserailcar.Checked == true)//ทะเบียนรถ
                    {
                        string sql3 = "update tbpurchase set serailcar='" + txtserailcar.Text.Trim() + "',remark2= 'เปลี่ยนทะเบียนรถจาก: " + nameserail + " เป็น " + txtserailcar.Text.Trim() + "',editstatus = 1 Where idtran= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        MessageBox.Show("ปรับปรุงข้อมูลเรียบร้อย!", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MessageOK();
                        idcancle = 7;
                        SaveLogchagedata();
                    }
                }

                if (idordermenu == 2)//ตาชั่งเปลี่ยนแปลงข้อมูล การชั่งออก
                {
                    if (rdoctypepro.Checked == true)
                    { ConvertIDpro_IDsuppro(); }

                    if (idsuppro != 0 && rdoctypepro.Checked == true)
                    {
                        string sql3 = "update tborder set idpro='" + idpro + "',remark2= 'เปลี่ยนสินค้าจาก: " + namepro + " เป็น " + txtcproduct.Text.Trim() + "',editstatus = 1 Where idtran= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        string sql2 = "update tbtransport set idsuppro='" + idsuppro + "' Where idtran= '" + idtranno + "'";
                        SqlCommand CM2 = new SqlCommand(sql2, CN);
                        CM2.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 7;
                        SaveLogchagedata();
                    }

                    if (idcus !="0" && rdoccuspro.Checked == true)
                    {
                        string sql3 = "update tborder set idcomcus='" + idcus + "',remark2= 'เปลี่ยนลูกค้าจาก: " + namecus + " เป็น " + txtscuspro.Text.Trim() + "',editstatus = 1 Where idtran= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        MessageBox.Show("ปรับปรุงข้อมูลเรียบร้อย!", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        idcancle = 6;
                        SaveLogchagedata();
                    }

                    if (idtypecar != 0 && rdoctypecar.Checked == true)//เปลี่ยนประเภทรถ
                    {
                        string sql3 = "update tborder set idcar='" + idtypecar + "',remark2= 'เปลี่ยนประเภทรถจาก: " + nametypecar + " เป็น " + txtccar.Text.Trim() + "',editstatus = 1 Where idtran= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 9;
                        SaveLogchagedata();
                    }

                    if (idcomtran != "0" && rdoctran.Checked == true)//เปลี่ยนบริษัทขนส่ง
                    {
                        string sql2 = "update tbtransport set idcomtran='" + idcomtran + "' Where idtran= '" + idtranno + "'";
                        SqlCommand CM2 = new SqlCommand(sql2, CN);
                        CM2.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 8;
                        SaveLogchagedata();
                    }

                    if (txtserailcar.Text != "" && rdocserailcar.Checked == true)//ทะเบียนรถ
                    {
                        string sql3 = "update tborder set serailcar='" + txtserailcar.Text.Trim() + "',remark2= 'เปลี่ยนทะเบียนรถจาก: " + nameserail + " เป็น " + txtserailcar.Text.Trim() + "',editstatus = 1 Where idtran= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        MessageBox.Show("ปรับปรุงข้อมูลเรียบร้อย!", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        idcancle = 10;
                        SaveLogchagedata();
                    }
                }

                if (idordermenu == 3)//เปลี่ยนลูกค้า ประวัติการชั่ง from truck out
                {
                    if (rdoccuspro.Checked == true)
                    {
                        string sql3 = "update tborder set idcomcus='" + idcus + "',remark2= 'เปลี่ยนลูกค้าจาก: " + namecus + " เป็น " + txtscuspro.Text.Trim() + "',editstatus = 1 Where idtran= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 6;
                        SaveLogchagedata();
                    }
                }

                if (idordermenu == 4)//เปลี่ยนข้อมูลจากการซื้อเข้า ในหน้าหลัก ORder ก่อนมีการจ่ายงานให้สาขา
                {
                   if (idpro != 0 && rdoctypepro.Checked == true)//เปลี่ยนประเภทสินค้า
                    {
                        string sql3 = "update tbpurchase set idpro='" + idpro + "',remark2= 'เปลี่ยนสินค้าจาก: " + namepro + " เป็น " + txtcproduct.Text.Trim() + "',editstatus = 1 Where idpur= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 7;
                        SaveLogchagedata();
                    }

                    if (idcomtran != "" && rdoctran.Checked == true)//เปลี่ยนแปลงบริษัทรถขนส่ง
                    {
                        string sql3 = "update tbpurchase set idcomtran='" + idcomtran + "',remark2= 'เปลี่ยน บ.ขนส่งจาก: " + namecomtran + " เป็น " + txtctran.Text.Trim() + "',editstatus = 1 Where idpur= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();                       

                        MessageOK();
                        idcancle = 8;
                        SaveLogchagedata();
                    } 

                   
                    if (idtypecar != 0 && rdoctypecar.Checked == true)//เปลี่ยนประเภทรถ
                    {
                        string sql3 = "update tbpurchase set idcar='" + idtypecar + "',remark2= 'เปลี่ยนประเภทรถจาก: " + nametypecar + " เป็น " + txtccar.Text.Trim() + "',editstatus = 1 Where idpur= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 9;
                        SaveLogchagedata();
                    }

                    if (txtserailcar.Text != "" && rdocserailcar.Checked == true)//เปลี่ยนทะเบียน
                    {
                        string sql3 = "update tbpurchase set serailcar='" + txtserailcar.Text.Trim() + "',remark2= 'เปลี่ยนทะเบียนจาก: " + nameserail + " เป็น " + txtserailcar.Text.Trim() + "',editstatus = 1 Where idpur= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 10;
                        SaveLogchagedata();
                    }                    

                    if (rdocanclepurchase.Checked == true)//ยกเลิกซื้อ
                    {
                        //update tbpurchase
                        string sql1 = "update tbpurchase set idstatus = 7,remark2 = '-' where idpur= '" + idtranno + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, CN);
                        CM1.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 1;
                        SaveLogchagedata();
                    }
                }

                if (idordermenu == 5)//เปลี่ยนข้อมูลจากการขายออก ในหน้าหลัก ORder ก่อนมีการจ่ายงานให้สาขา
                {
                    if (rdoccuspro.Checked == true)//เปลี่ยนลูกค้า
                    {
                        string sql3 = "update tborder set idcomcus='" + idcus + "',remark2= 'เปลี่ยนลูกค้าจาก: " + namecus + " เป็น " + txtscuspro.Text.Trim() + "',editstatus = 1 Where idorder= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 6;
                        SaveLogchagedata();
                    }

                    if (rdoctypepro.Checked == true)//เปลี่ยนสินค้า
                    {
                        string sql3 = "update tborder set idpro='" + idpro + "',remark2= 'เปลี่ยนสินค้าจาก: " + namepro + " เป็น " + txtscuspro.Text.Trim() + "',editstatus = 1 Where idorder = '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 7;
                        SaveLogchagedata();
                    }

                    if (rdoctypecar.Checked == true)//เปลี่ยนประเภทรถ
                    {
                        string sql3 = "update tborder set idcar='" + idtypecar + "',remark2= 'เปลี่ยนประเภทรถจาก: " + nametypecar + " เป็น " + txtccar.Text.Trim() + "',editstatus = 1 Where idorder= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 9;
                        SaveLogchagedata();
                    }

                    if (rdocanclesale.Checked == true)//ยกเลิกขาย
                    {
                        //update tbsale
                        string sql1 = "update tborder set idstatus = 7,remark2='-' where idorder= '" + idtranno + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, CN);
                        CM1.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 2;
                        SaveLogchagedata();
                    }
                }

                if (idordermenu == 6)//เปลี่ยนแปลงการซื้อเข้าหลังจากจ่ายงานแล้ว
                {
                    if (idpro != 0 && rdoctypepro.Checked == true)//เปลี่ยนสินค้า
                    {
                        ConvertIDpro_IDsuppro();

                        if (idsuppro != 0)
                        {
                            string sql3 = "update tbpurchase set idpro='" + idpro + "',remark2= 'เปลี่ยนสินค้าจาก: " + namepro + " เป็น " + txtcproduct.Text.Trim() + "',editstatus = 1 Where idtran= '" + idtranno + "'";
                            SqlCommand CM3 = new SqlCommand(sql3, CN);
                            CM3.ExecuteNonQuery();

                            string sql2 = "update tbtransport set idsuppro='" + idsuppro + "' Where idtran= '" + idtranno + "'";
                            SqlCommand CM2 = new SqlCommand(sql2, CN);
                            CM2.ExecuteNonQuery();

                            MessageOK();
                            idcancle = 7;
                            SaveLogchagedata();
                        }
                    }

                    if (idcomtran != "0" && rdoctran.Checked == true)//เปลี่ยนบริษัทขนส่ง
                    {
                        string sql3 = "update tbpurchase set idcomtran='" + idcomtran + "',remark2= 'เปลี่ยน บ.ขนส่งจาก: " + namecomtran + " เป็น " + txtctran.Text.Trim() + "',editstatus = 1 Where idtran= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        string sql2 = "update tbtransport set idcomtran='" + idcomtran + "' Where idtran= '" + idtranno + "'";
                        SqlCommand CM2 = new SqlCommand(sql2, CN);
                        CM2.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 8;
                        SaveLogchagedata();
                    }

                    if (idtypecar != 0 && rdoctypecar.Checked == true)//ประเภทรถ
                    {
                        string sql3 = "update tbpurchase set idcar='" + idtypecar + "',remark2= 'เปลี่ยนประเภทรถจาก: " + nametypecar + " เป็น " + txtccar.Text.Trim() + "',editstatus = 1 Where idpur= '" + idpur + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 9;
                        SaveLogchagedata();
                    }

                    if (txtserailcar.Text != "" && rdocserailcar.Checked == true)//ทะเบียนรถ
                    {
                        string sql3 = "update tbpurchase set serailcar='" + txtserailcar.Text.Trim() + "',remark2= 'เปลี่ยนทะเบียนรถจาก: " + nameserail + " เป็น " + txtserailcar.Text.Trim() + "',editstatus = 1 Where idtran= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 10;
                        SaveLogchagedata();
                    }

                    if (cbbranch.Text != "" && rdocbranch.Checked == true)//เปลี่ยนจ่ายสาขา
                    {
                        //  SearchSupproBybranch();  ให้ไปหาสินค้าย่อยในสาขานั้น ๆ
                        ConvertIDpro_IDsuppro();

                        if (idsuppro != 0)
                        {
                            //ต้องยกเลิก
                            string sql4 = "update tbtransport set idbranch = null ,idtruck = 5,remark2='เปลี่ยนการจ่ายงานจากสาขา: " + cbbranch.Text + " แทน' where idtran ='" + idtranno + "'";
                            SqlCommand CM4 = new SqlCommand(sql4, CN);
                            CM4.ExecuteNonQuery();

                            ////ต้องลบ
                            //string sql5 = "DELETE FROM tbweigth WHERE idtran ='" + idtranno + "'";
                            //SqlCommand CM5 = new SqlCommand(sql5, CN);
                            //CM5.ExecuteNonQuery();

                            string sql3 = "update tbpurchase set idtran='" + IdtranNewgen + "',remark2= 'เปลี่ยนสาขารับจาก: " + namebranch + " เป็น " + cbbranch.Text + "',remark3='ชั่งรถหนัก',editstatus = 1 Where idtran= '" + idtranno + "'";
                            SqlCommand CM3 = new SqlCommand(sql3, CN);
                            CM3.ExecuteNonQuery();

                            string sql2 = "insert into tbtransport(idtran,senddate,idfrom,idcomtran,idbranch,truckpass,idsuppro,idto) values ('" + IdtranNewgen + "','" + sumdate + "','" + idpur + "','" + idcomtran + "'," + idbranch + ",0," + idpro + ",'" + idcompur + "')";

                            SqlCommand CM2 = new SqlCommand(sql2, CN);
                            CM2.ExecuteNonQuery();

                            string sql12 = "insert into tbweigth  (idtran) values ('" + IdtranNewgen + "')";
                            SqlCommand CM12 = new SqlCommand(sql12, CN);
                            CM12.ExecuteNonQuery();
                                                        
                            MessageOK();
                            idcancle = 11;
                            SaveLogchagedata();
                        }
                    }

                    if (rdocanclepurchase.Checked == true)//ยกเลิกซื้อ
                    {
                        //update status from table purchase           
                        string sql1 = "update tbpurchase set idstatus = 7 where idtran= '" + idtranno + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, CN);
                        CM1.ExecuteNonQuery();

                        //update transport
                        string sql4 = "update tbtransport set idbranch = null ,idtruck = 5 where idtran ='" + idtranno + "'";
                        SqlCommand CM4 = new SqlCommand(sql4, CN);
                        CM4.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 1;
                        SaveLogchagedata();
                    }

                    if (rdocorderptob.Checked == true) //&& txtremarkcancle.Text != "" && txtconfirmpwd.Text !="" )
                    {
                        Checkmathproduct();

                        if (idmatchok == 1 && idorder != "")
                        {
                            /* step
                             1. ยกเลิกจ่ายงานในสาขานั้น
                             * หางาน order ลูกค้าใหม่แแล้วดึงไอดี sale ออกมา     S55xxxxxxx
                             * ดึงเลขที่ไอทีชั่งเข้าสาขาใหม่     T55xxxxxx 
                             * เลือกการชั่งน้ำหนัก ว่าต้องการชั่งผ่านสาขาหรือไม่
                             แล้วทำการบันทักทั้งหมด
                             * 
                             *  */
                            //update transport  สั่งให้ยกเลิก ไอดีเก่า
                            string sql4 = "update tbtransport set idbranch = null ,idtruck = 5,remark2='ยกเลิกซื้อเข้าเปลี่ยนเป็นส่งให้ลูกค้าเลขที่: " + idorder + " แทน' where idtran ='" + idtranno + "'";
                            SqlCommand CM4 = new SqlCommand(sql4, CN);
                            CM4.ExecuteNonQuery();

                            if (rdonopass.Checked == true)//ถ้าซื้อแล้วไม่ผ่านสาขา
                            {
                                remark = "-";
                                //ซื้อจากผู้ผลิต และส่งให้ลูกค้า ให้บันทึก idsup -> idcus  insert into tbpurchase  
                                string sql1 = "insert into tbtransport(idtran,senddate,idfrom,idto,idcomtran,idtruck,truckpass,remark1) values ('" + IdtranNewgen + "','" + sumdate + "','" + idpur + "','" + idorder + "','" + idcomtran + "',4," + truckpass + ",'" + remark + "')";

                                SqlCommand CM1 = new SqlCommand(sql1, CN);
                                CM1.ExecuteNonQuery();
                            }

                            if (rdopass.Checked == true)  //ถ้าซื้อแล้วผ่านสาขา
                            {
                                //ซื้อจากผู้ผลิต และส่งให้ลูกค้า ให้บันทึก idsup -> idcus  insert into tbpurchase  
                                string sql1 = "insert into tbtransport(idtran,senddate,idfrom,idto,idcomtran,idtruck,idbranch,truckpass,remark1) values ('" + IdtranNewgen + "','" + sumdate + "','" + idpur + "','" + idorder + "','" + idcomtran + "',4," + idbranch + "," + truckpass + ",'" + remark + "')";

                                SqlCommand CM1 = new SqlCommand(sql1, CN);
                                CM1.ExecuteNonQuery();
                            }

                            if (rdonopass.Checked == true || rdopass.Checked == true)
                            {
                                string sql12 = "insert into tbweigth  (idtran) values ('" + IdtranNewgen + "')";
                                SqlCommand CM12 = new SqlCommand(sql12, CN);
                                CM12.ExecuteNonQuery();

                                //update status from table purchase
                                string sql2 = "update tbpurchase set idstatus=" + 2 + ",idtran='" + IdtranNewgen + "' Where idpur= '" + idpur + "'";
                                SqlCommand CM2 = new SqlCommand(sql2, CN);
                                CM2.ExecuteNonQuery();

                                //update status from table Order
                                string sql3 = "update tborder set idstatus=" + 1 + ",idtran='" + IdtranNewgen + "' Where idorder= '" + idorder + "'";
                                SqlCommand CM3 = new SqlCommand(sql3, CN);
                                CM3.ExecuteNonQuery();

                                MessageOK();
                                idcancle = 12;
                                SaveLogchagedata();

                                this.Close();
                            }
                        }

                        else { MessageBox.Show("ชนิดสินค้าไม่ตรงกัน หรือไม่ได้เลือกลูกค้าส่ง", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }


                if (idordermenu == 7)//เปลี่ยนแปลงการขายออกหลังจากจ่ายงานแล้ว
                {
                    if (idcus != "" && rdoccuspro.Checked == true)//เปลี่ยนลูกค้า
                    {
                        string sql3 = "update tborder set idcomcus='" + idcus + "',remark2= 'เปลี่ยนลูกค้าจาก: " + namecus + " เป็น " + txtscuspro.Text.Trim() + "',editstatus = 1 Where idtran= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 6;
                        SaveLogchagedata();
                    }

                    if (idpro != 0 && rdoctypepro.Checked == true)//เปลี่ยนสินค้า
                    {
                        ConvertIDpro_IDsuppro();

                        if (idsuppro != 0)
                        {
                            string sql3 = "update tborder set idpro='" + idpro + "',remark2= 'เปลี่ยนสินค้าจาก: " + namepro + " เป็น " + txtcproduct.Text.Trim() + "',editstatus = 1 Where idtran= '" + idtranno + "'";
                            SqlCommand CM3 = new SqlCommand(sql3, CN);
                            CM3.ExecuteNonQuery();

                            string sql2 = "update tbtransport set idsuppro='" + idsuppro + "' Where idtran= '" + idtranno + "'";
                            SqlCommand CM2 = new SqlCommand(sql2, CN);
                            CM2.ExecuteNonQuery();

                            MessageOK();
                            idcancle = 7;
                            SaveLogchagedata();
                        }
                    }

                    if (idcomtran != "0" && rdoctran.Checked == true)//เปลี่ยนบริษัทขนส่ง
                    {
                        string sql2 = "update tbtransport set idcomtran='" + idcomtran + "' Where idtran= '" + idtranno + "'";
                        SqlCommand CM2 = new SqlCommand(sql2, CN);
                        CM2.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 8;
                        SaveLogchagedata();
                    }

                    if (idtypecar != 0 && rdoctypecar.Checked == true)//ประเภทรถ
                    {
                        string sql3 = "update tborder set idcar='" + idtypecar + "',remark2= 'เปลี่ยนประเภทรถจาก: " + nametypecar + " เป็น " + txtccar.Text.Trim() + "',editstatus = 1 Where idtran= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 9;
                        SaveLogchagedata();
                    }

                    if (txtserailcar.Text != "" && rdocserailcar.Checked == true)//ทะเบียนรถ
                    {
                        string sql3 = "update tborder set serailcar='" + txtserailcar.Text.Trim() + "',remark2= 'เปลี่ยนทะเบียนรถจาก: " + nameserail + " เป็น " + txtserailcar.Text.Trim() + "',editstatus = 1 Where idtran= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        MessageBox.Show("ปรับปรุงข้อมูลเรียบร้อย!", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        idcancle = 10;
                        SaveLogchagedata();
                    }

                    if (rdocbranch.Checked == true)//เปลี่ยนจ่ายสาขา
                    {
                        ConvertIDpro_IDsuppro();

                        if (idsuppro != 0)
                        {
                            //ต้องยกเลิก
                            string sql4 = "update tbtransport set idbranch = null ,idtruck = 5,remark2='เปลี่ยนการจ่ายงานจากสาขา: " + cbbranch.Text + " แทน' where idtran ='" + idtranno + "'";
                            SqlCommand CM4 = new SqlCommand(sql4, CN);
                            CM4.ExecuteNonQuery();

                            ////ต้องลบ
                            //string sql5 = "DELETE FROM tbweigth WHERE idtran ='" + idtranno + "'";
                            //SqlCommand CM5 = new SqlCommand(sql5, CN);
                            //CM5.ExecuteNonQuery();

                            string sql3 = "update tborder set idtran='" + IdtranNewgen + "',remark2= 'เปลี่ยนสาขาส่งจาก: " + namebranch + " เป็น " + cbbranch.Text + "',remark3='ชั่งรถเบา',editstatus = 1 Where idtran= '" + idtranno + "'";
                            SqlCommand CM3 = new SqlCommand(sql3, CN);
                            CM3.ExecuteNonQuery();

                            string sql2 = "insert into tbtransport(idtran,senddate,idfrom,idcomtran,idbranch,truckpass,idsuppro,idto) values ('" + IdtranNewgen + "','" + sumdate + "','" + idcomsup + "','" + idcomtran + "'," + idbranch + ",0," + idpro + ",'" + idorder + "')";

                            SqlCommand CM2 = new SqlCommand(sql2, CN);
                            CM2.ExecuteNonQuery();

                            string sql12 = "insert into tbweigth  (idtran) values ('" + IdtranNewgen + "')";
                            SqlCommand CM12 = new SqlCommand(sql12, CN);
                            CM12.ExecuteNonQuery();

                            MessageOK();
                            idcancle = 11;
                            SaveLogchagedata();
                        }
                    }

                    if (rdocanclesale.Checked == true)//ยกเลิกขาย
                    {
                        //update status from table sale           
                        string sql1 = "update tborder set idstatus = 7 where idtran= '" + idtranno + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, CN);
                        CM1.ExecuteNonQuery();

                        //update transport
                        string sql4 = "update tbtransport set idbranch = null ,idtruck = 5 where idtran ='" + idtranno + "'";
                        SqlCommand CM4 = new SqlCommand(sql4, CN);
                        CM4.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 2;
                        SaveLogchagedata();
                    }

                    if (rdocorderb1tosale.Checked == true || rdocorderb2tosale.Checked == true)
                    {
                        //update status from table purchase           
                        string sql1 = "update tborder set idstatus = 7 where idtran= '" + idtranno + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, CN);
                        CM1.ExecuteNonQuery();

                        //ต้องยกเลิก
                        string sql4 = "update tbtransport set idbranch = null ,idtruck = 5,remark2='ยกเลิกการส่งสินค้าให้ลูกค้าเลขที่: " + idorder + " แทน' where idtran ='" + idtranno + "'";
                        SqlCommand CM4 = new SqlCommand(sql4, CN);
                        CM4.ExecuteNonQuery();

                        ////ต้องลบ
                        //string sql5 = "DELETE FROM tbweigth WHERE idtran =('" + idtranno + "')";
                        //SqlCommand CM5 = new SqlCommand(sql5, CN);
                        //CM5.ExecuteNonQuery();                      


                        string sql2 = "update tbpurchase set idtran='" + IdtranNewgen + "',remark3='ชั่งรถหนัก' Where idpur= '" + Program.idsavelate + "'";
                        SqlCommand CM2 = new SqlCommand(sql2, CN);
                        CM2.ExecuteNonQuery();

                        string sql3 = "insert into tbtransport(idtran,senddate,idfrom,idcomtran,idbranch,truckpass,idsuppro,idto) values ('" + IdtranNewgen + "','" + sumdate + "','" + idpur + "','" + idcomtran + "'," + idbranch + ",0," + idpro + ",'" + idcomsup + "')";//,"++")";

                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        string sql12 = "insert into tbweigth  (idtran) values ('" + IdtranNewgen + "')";
                        SqlCommand CM12 = new SqlCommand(sql12, CN);
                        CM12.ExecuteNonQuery();

                        MessageOK();
                        if (rdocorderb1tosale.Checked == true)
                        { idcancle = 14; }
                        if (rdocorderb2tosale.Checked == true)
                        { idcancle = 15; }
                        SaveLogchagedata();
                    }

                    this.Close();
                }

                if (idordermenu == 8)//เปลี่ยนลูกค้าจาก ซื้อมา ขายไป
                {
                    if (txtctran.Text != "" && rdoctran.Checked == true)
                    {
                        string sql3 = "update tbpurchase set idcomtran='" + idcomtran + "',remark2= 'เปลี่ยน บ.ขนส่งจาก: " + namecomtran + " เป็น " + txtctran.Text.Trim() + "',editstatus = 1 Where idtran= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 8;
                        SaveLogchagedata();
                    } 

                    if (rdoccuspro.Checked == true)//ลูกค้า
                    {
                        string sql3 = "update tborder set idcomcus='" + idcus + "',remark2= 'เปลี่ยนลูกค้าจาก: " + namecus + " เป็น " + txtscuspro.Text.Trim() + "',editstatus = 1 Where idtran= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 6;
                        SaveLogchagedata();
                    }

                    if (rdocserailcar.Checked == true)//ทะเบียนรถ
                    {
                        string sql3 = "update tbpurchase set serailcar='" + txtserailcar.Text.Trim() + "',remark2= 'เปลี่ยนทะเบียนรถจาก: " + nameserail + " เป็น " + txtserailcar.Text.Trim() + "',editstatus = 1 Where idtran= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();                     

                        MessageOK();
                        idcancle = 7;
                        SaveLogchagedata();
                    }

                    if (rdocptosale1.Checked == true)//เปลี่ยน Order [ซื้อ - ขาย] -> [ซื้อ - คลัง]
                    {
                        //update status from table sale           
                        string sql1 = "update tborder set idstatus = 7 where idtran= '" + idtranno + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, CN);
                        CM1.ExecuteNonQuery();

                        //ต้องยกเลิก
                        string sql4 = "update tbtransport set idbranch = null ,idtruck = 5,remark2='ยกเลิกการส่งสินค้าให้ลูกค้าเลขที่: " + idorder + " แทน' where idtran ='" + idtranno + "'";
                        SqlCommand CM4 = new SqlCommand(sql4, CN);
                        CM4.ExecuteNonQuery();                     

                        string sql3 = "insert into tbtransport(idtran,senddate,idfrom,idcomtran,idbranch,truckpass,idsuppro,idto) values ('" + IdtranNewgen + "','" + sumdate + "','" + idpur + "','" + idcomtran + "'," + idbranch + ",0," + idpro + ",'" + idorder + "')";//,"++")";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        string sql2 = "update tbpurchase set idtran='" + IdtranNewgen + "',idstatus = 4,remark3='ชั่งรถหนัก' Where idpur= '" + idpur + "'";
                        SqlCommand CM2 = new SqlCommand(sql2, CN);
                        CM2.ExecuteNonQuery();


                        string sql12 = "insert into tbweigth  (idtran) values ('" + IdtranNewgen + "')";
                        SqlCommand CM12 = new SqlCommand(sql12, CN);
                        CM12.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 13;
                        SaveLogchagedata();
                    }

                    if (rdocanclepurtosale.Checked == true)//ยกเลิกซื้อ -> ขาย
                    {
                        //update status from table purchase           
                        string sql1 = "update tbpurchase set idstatus = 4,idtran = null  where idtran= '" + idtranno + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, CN);
                        CM1.ExecuteNonQuery();

                        //update status from table purchase           
                        string sql2 = "update tborder set idstatus = 3,idtran = null where idtran= '" + idtranno + "'";
                        SqlCommand CM2 = new SqlCommand(sql2, CN);
                        CM2.ExecuteNonQuery();

                        //update transport
                        string sql3 = "update tbtransport set idbranch = null ,idtruck = 5 where idtran ='" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 3;
                        SaveLogchagedata();
                    }

                    if (rdorecoverypurtosale.Checked == true)
                    {
                        ////ต้องลบ
                        //string sql5 = "DELETE FROM tbweigth WHERE idtran =('" + idtranno + "')";
                        //SqlCommand CM5 = new SqlCommand(sql5, CN);
                        //CM5.ExecuteNonQuery();

                        //ต้องลบ
                        //update transport
                        string sql6 = "update tbtransport set idbranch = null ,idtruck = 5 where idtran ='" + idtranno + "'";
                        SqlCommand CM6 = new SqlCommand(sql6, CN);
                        CM6.ExecuteNonQuery();

                        //update status from table purchase
                        string sql2 = "update tbpurchase set idcar='" + idtypecar + "',serailcar='" + txtserailcar.Text.Trim() + "',idstatus= 2,idtran='" + IdtranNewgen + "'Where idtran= '" + idtranno + "'";
                        SqlCommand CM2 = new SqlCommand(sql2, CN);
                        CM2.ExecuteNonQuery();

                        //update status from table Order
                        string sql3 = "update tborder set idcar='" + idtypecar + "',serailcar='" + txtserailcar.Text.Trim() + "',idstatus= 1,idtran='" + IdtranNewgen + "'Where idtran= '" + idtranno + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        if (rdonopass.Checked == true)//ถ้าซื้อแล้วไม่ผ่านสาขา
                        {
                            remark = "-";
                            //ซื้อจากผู้ผลิต และส่งให้ลูกค้า ให้บันทึก idsup -> idcus  insert into tbpurchase  
                            string sql1 = "insert into tbtransport(idtran,senddate,idfrom,idto,idcomtran,idtruck,truckpass,remark1) values ('" + IdtranNewgen + "','" + sumdate + "','" + idpur + "','" + idcus + "','" + idcomtran + "',4," + truckpass + ",'" + remark + "')";

                            SqlCommand CM1 = new SqlCommand(sql1, CN);
                            CM1.ExecuteNonQuery();
                        }

                        if (rdopass.Checked == true)  //ถ้าซื้อแล้วผ่านสาขา
                        {
                            //ซื้อจากผู้ผลิต และส่งให้ลูกค้า ให้บันทึก idsup -> idcus  insert into tbpurchase  
                            string sql1 = "insert into tbtransport(idtran,senddate,idfrom,idto,idcomtran,idtruck,idbranch,truckpass,remark1) values ('" + IdtranNewgen + "','" + sumdate + "','" + idpur + "','" + idcus + "','" + idcomtran + "',4," + idbranch + "," + truckpass + ",'" + remark + "')";

                            SqlCommand CM1 = new SqlCommand(sql1, CN);
                            CM1.ExecuteNonQuery();
                        }

                        string sql4 = "insert into tbweigth(idtran) values('" + IdtranNewgen + "')";
                        SqlCommand CM4 = new SqlCommand(sql4, CN);
                        CM4.ExecuteNonQuery();

                        MessageOK();
                        idcancle = 18;
                        SaveLogchagedata();
                    }

                    if (rdonopass.Checked == true)//Update ไม่ผ่านสาขา
                    {
                        //update transport
                        string sql3 = "update tbtransport set idbranch = null ,truckpass = 0,remark1 = '-'  where idtran ='" + idtranno + "'";          
                        SqlCommand CM1 = new SqlCommand(sql3, CN);
                        CM1.ExecuteNonQuery();
                    }

                    if (rdopass.Checked == true)  //Update แล้วผ่านสาขา
                    {
                        //update transport
                        remark ="นน.ผ่านตาชั่ง "+ comboBox1.Text;
                        string sql3 = "update tbtransport set idbranch = " + comboBox1.SelectedValue.ToString() + " ,truckpass = 1,remark1 = '" + remark + "'  where idtran ='" + idtranno + "'";                       
                        SqlCommand CM1 = new SqlCommand(sql3, CN);
                        CM1.ExecuteNonQuery();
                    }

                }

                this.Close();
            }

            else { MessageBox.Show("ไม่สามารถเปลี่ยนแปลงข้อมูลได้ เนื่องจากรหัสในการเปลี่ยนแปลงผิดหรือไม่ได้ใส่เหตุผลในการยกเลิก !", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            CN.Close();
        }

        private void btnold_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); rdooldorder.Checked = true;
            
            
            if (rdocorderptob.Checked == true)
            {
                FrmOrderSelect forse = new FrmOrderSelect();
                if (rdocorderptob.Checked == true)
                {
                    forse.nameselect = "Sale";
                    forse.idsearch = idtranno;
                    forse.ShowDialog();
                    if (forse.idselect != "0")
                    {
                        string sql = "select * from vsaleorder  where idorder='" + forse.idselect + "'";
                        SqlCommand CM1 = new SqlCommand(sql, CN);
                        SqlDataReader DR1 = CM1.ExecuteReader();

                        DR1.Read();
                        {
                            idorder = DR1["idorder"].ToString().Trim();
                            txtnamecus.Text = DR1["comcus"].ToString().Trim();
                        }
                        DR1.Close();
                    }
                }

                KeycharbyIDbranch = "D";  //ต้องเป็น D เพราะเปลี่ยนจาก ซื้อเข้าคลัง เป็น ซื้อ มาขายไป               
                CreateAutoID();
                txtnewid.Text = IdtranNewgen;
            }

            CN.Close();
        }

        private void rdopass_CheckedChanged(object sender, EventArgs e)
        {
            if (rdopass.Checked == true)
            {                 
                 truckpass = 1;
                 idmenuunlock = 9;
                 comboBox1.Enabled = true;
            }
        }

        private void rdonopass_CheckedChanged(object sender, EventArgs e)
        {
            if (rdonopass.Checked == true)
            {
                idmenuunlock = 9; comboBox1.Enabled = false;
            }
        }


        private void SearchKeychar()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql1 = "SELECT charname FROM vautokeychar WHERE idbranch =" + idbranch
 + "";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            SqlDataReader DR1 = CM1.ExecuteReader();
            DR1.Read();
            {
                KeycharbyIDbranch = DR1["charname"].ToString();               
            }
            DR1.Close();
            CN.Close();
        }
       
         private void CreateAutoID()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            long daterun = 0;
            int idrun = 0;
            //string keychar = "";
            string getidmax = "";

            string sql = "SELECT MAX(idtranauto) AS idmaxs FROM tbtransport WHERE (idtran LIKE '%" + KeycharbyIDbranch + "%')";
            SqlCommand CM = new SqlCommand(sql, CN);
            SqlDataReader DR = CM.ExecuteReader();
            DR.Read();
            { getidmax = DR["idmaxs"].ToString(); }
            DR.Close();

            if (getidmax != "")
            {
                string sql1 = "SELECT idtran FROM tbtransport WHERE idtranauto =" + getidmax + "";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();
                DR1.Read();
                {
                    textBox6.Text = DR1["idtran"].ToString();
                    textBox7.Text = DR1["idtran"].ToString();
                }
                DR1.Close();

                textBox6.SelectionStart = 1;
                textBox6.SelectionLength = 6;
                daterun = Convert.ToInt64(textBox6.SelectedText.ToString());//ตัดค่า 4 ปีเดือนวัน จากฐานข้อมูล
                textBox7.SelectionStart = 7;
                textBox7.SelectionLength = 9;
                idrun = Convert.ToInt16(textBox7.SelectedText.ToString());//ตัวลำดับที่ จากฐานข้อมูล            
            }

            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            string idcomplease = KeycharbyIDbranch + String.Format("{0:yy}", dt) + String.Format("{0:MM}", dt) + String.Format("{0:dd}", dt);
            long datenow = Convert.ToInt64(String.Format("{0:yy}", dt) + String.Format("{0:MM}", dt) + String.Format("{0:dd}", dt));

            if (datenow == daterun)
            {
                idrun++;
                IdtranNewgen = idcomplease + string.Format("{0:00}", idrun);
            }
            else
            {
                IdtranNewgen = idcomplease + "01";
            }

            CN.Close();
        }

         private void Checkmathproduct()
        {
            int idcarpur = 0;
            int idpropur = 0;
            int idcarsale = 0;
            int idprosale = 0;
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb; string sql1="";
            CN.Open();  

            try
            {
                if (idpur != "")
                { sql1 = "SELECT idpro,idcar FROM tbpurchase WHERE idpur = '" + idpur + "'"; }
                else { sql1 = "SELECT idpro,idcar FROM tbpurchase WHERE idpur = '" + Program.idsavelate + "'"; }
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            SqlDataReader DR1 = CM1.ExecuteReader();
            DR1.Read();
            {
                idpropur = Convert.ToInt16(DR1["idpro"].ToString());
                idcarpur = Convert.ToInt16(DR1["idcar"].ToString());
            }
            DR1.Close();

            if (idorder != "")
            {
                string sql2 = "SELECT idpro,idcar FROM tborder WHERE idorder ='" + idorder + "'";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();
                DR2.Read();
                {
                    idprosale = Convert.ToInt16(DR2["idpro"].ToString());
                    idcarsale = Convert.ToInt16(DR2["idcar"].ToString());
                }
                DR2.Close();
            }

            if (idpropur == idprosale)//เช็ครถพ่วง
            {
                idmatchok = 1;               
            }

         //  else{MessageBox.Show("ชนิดสินค้าไม่ตรงกัน !", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);}
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

            CN.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                remark = "นน.ผ่านตาชั่ง " + comboBox1.Text.Trim();
                idbranch = Convert.ToInt16(comboBox1.SelectedValue.ToString());
                rdopass.Checked = true;

                if (rdocorderb2tosale.Checked == true || rdocptosale1.Checked == true)
                {
                    idbranch = Convert.ToInt16(comboBox1.SelectedValue.ToString());
                    SearchKeychar();
                    CreateAutoID();
                    txtnewid.Text = IdtranNewgen;
                }
            }
            catch { }
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            if (rdocorderptob.Checked == true)
            {
                rdoneworder.Checked = true;
                FrmSaleOrder fsorder = new FrmSaleOrder();
                fsorder.add0rder = 3;
                fsorder.id = idtranno;
                fsorder.ShowDialog();

                idorder = Program.idsavelate;
                if (Program.idsavelate != "")
                { txtneworderid.Text = "เพิ่ม Order ID เลขที่: " + Program.idsavelate; }

                KeycharbyIDbranch = "D";  //ต้องเป็น D เพราะเปลี่ยนจาก ซื้อเข้าคลัง เป็น ซื้อ มาขายไป               
                CreateAutoID();
                txtnewid.Text = IdtranNewgen;
            }

            if (rdocorderb1tosale.Checked == true || rdocorderb2tosale.Checked == true)
            {
                rdoneworder.Checked = true;
                FrmPurchase fpch = new FrmPurchase();
                fpch.id = idtranno;
                fpch.idedit = 3;
                fpch.ShowDialog();

                idpur = Program.idsavelate;
                if (Program.idsavelate != "")
                { txtneworderid.Text = "เพิ่ม Order ID เลขที่: " + Program.idsavelate; }

                if (rdocorderb1tosale.Checked == true)
                {
                    SearchKeychar();
                    CreateAutoID();
                    txtnewid.Text = IdtranNewgen;
                }

                if (rdocorderb2tosale.Checked == true)
                {
                    idbranch = Convert.ToInt16(comboBox1.SelectedValue.ToString());
                    SearchKeychar();
                    CreateAutoID();
                    txtnewid.Text = IdtranNewgen;                
                } 
            }

            if (rdocptosale1.Checked == true)
            {
                rdoneworder.Checked = true;

                FrmPurchase fpch = new FrmPurchase();
                fpch.id = idtranno;
                fpch.idedit = 4;
                fpch.ShowDialog();
                idpur = Program.idsavelate;
                if (Program.idsavelate != "")
                { txtneworderid.Text = "เพิ่ม Order ID เลขที่: " + Program.idsavelate; }

                if (rdocorderb2tosale.Checked == true)
                {
                    idbranch = Convert.ToInt16(comboBox1.SelectedValue.ToString());
                    SearchKeychar();
                    CreateAutoID();
                    txtnewid.Text = IdtranNewgen;
                }

                if (rdocptosale1.Checked == true)
                {
                    idbranch = Convert.ToInt16(comboBox1.SelectedValue.ToString());
                    SearchKeychar();
                    CreateAutoID();
                    txtnewid.Text = IdtranNewgen;
                } 
            }
        }

        private void rdoccuspro_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoccuspro.Checked == true)
            {              
                DisableRadionGBChageOrder();
                idmenuunlock = 4; btnscuspro.Enabled = true;
            }
            else { idmenuunlock = 0; btnscuspro.Enabled = true; }
        }

        private void rdoctypepro_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoctypepro.Checked == true)
            {               
                DisableRadionGBChageOrder();
                idmenuunlock = 3; btnspro.Enabled = true;
            }
            else { idmenuunlock = 0; btnspro.Enabled = false; }

        }

        private void rdoctran_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoctran.Checked == true)
            {               
                DisableRadionGBChageOrder();
                idmenuunlock = 6; btnsctran.Enabled = true;
            }
            else { idmenuunlock = 0; btnsctran.Enabled = false; }

        }

        private void rdoctypecar_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoctypecar.Checked == true)
            {               
                DisableRadionGBChageOrder();
                idmenuunlock = 8; btnstypcar.Enabled = true;
            }
            else { idmenuunlock = 0; btnstypcar.Enabled = false; }

        }

        private void rdocserailcar_CheckedChanged(object sender, EventArgs e)
        {
            if (rdocserailcar.Checked == true)
            {               
                DisableRadionGBChageOrder();
                idmenuunlock = 7;
            }
            else { idmenuunlock = 0; }
        }

        private void rdocbranch_CheckedChanged(object sender, EventArgs e)
        {
            if (rdocbranch.Checked == true)
            {               
                DisableRadionGBChageOrder();
                idmenuunlock = 9;
            }
            else {idmenuunlock = 9; }
        }

        private void cbbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbranch.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                SearchKeychar();
                CreateAutoID();
                txtnewid.Text = IdtranNewgen;
            }
        }

        private void rdooldorder_CheckedChanged(object sender, EventArgs e)
        {
            if (rdooldorder.Checked == true)
            { btnold.Enabled = true; }
            else btnold.Enabled = false;
        }

        private void rdocanclepurchase_CheckedChanged(object sender, EventArgs e)
        {
            if (rdocanclepurchase.Checked == true)
            {
                DisableRadionGBtransport();
                DisableRadionGBChageOrder();               
                lbldepchangorder1.Text = "คำอธิบาย: ใช้ในกรณี ยกเลิกการทำ  Order ซื้อ";
                idmenuunlock = 14;
            }
        }

        private void btnsearchrecovery_Click(object sender, EventArgs e)
        {
            if (rdorecoverypurchase.Checked == true)
            {
                FrmOrderSelect fosl = new FrmOrderSelect();
                fosl.nameselect = "Recoverypur";
                fosl.ShowDialog();
                idpur = fosl.idselect;
                txtremarkorder.Text = "กู้ Order เลขที่ ID: " + idpur;
            }

            if (rdorecoverysale.Checked == true)
            {
                FrmOrderSelect fosl = new FrmOrderSelect();
                fosl.nameselect = "Recoverysale";
                fosl.ShowDialog();
                idcus = fosl.idselect;
                txtremarkorder.Text = "กู้ Order เลขที่ ID: " + idcus;
            }
            if (rdorecoverypurtosale.Checked == true)
            {
                FrmOrderSelect fosl = new FrmOrderSelect();
                fosl.nameselect = "Recoverypurtosale";
                fosl.ShowDialog();
                idtranno = fosl.idselect;
                txtremarkorder.Text = "กู้ Order เลขที่ ID: " + idtranno;

                if (idtranno != "0")
                {
                    SqlConnection CN = new SqlConnection();
                    CN.ConnectionString = Program.urldb;
                    CN.Open();
                    string sql2 = "SELECT idpur,idorder,idcomtran FROM vcanclepurtosale WHERE idtran ='" + idtranno + "'";
                    SqlCommand CM2 = new SqlCommand(sql2, CN);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    DR2.Read();
                    {
                        idpur = DR2["idpur"].ToString();
                        idcus = DR2["idorder"].ToString();
                        idcomtran = DR2["idcomtran"].ToString();
                    }
                    DR2.Close();
                    CN.Close();

                    KeycharbyIDbranch = "D";  //ต้องเป็น D เพราะเปลี่ยนจาก ซื้อเข้าคลัง เป็น ซื้อ มาขายไป               
                    CreateAutoID();
                    txtnewid.Text = IdtranNewgen;
                }
            }
        }

        private void rdocanclesale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdocanclesale.Checked == true)
            {
                DisableRadionGBtransport();
                DisableRadionGBChageOrder();               
                txtserailcar.Clear();
                idpro = 0;
                idtypecar = 0;
                lbldepchangorder1.Text = "คำอธิบาย: ใช้ในกรณี ยกเลิกการทำ  Order ขาย";
                idmenuunlock = 15;
            }
        }

        private void rdoneworder_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoneworder.Checked == true)
            { btnnew.Enabled = true; }
        }

        private void rdocptosale2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Frmchangdata_FormClosing(object sender, FormClosingEventArgs e)
        {
            ideventform = 6;
            msnfrom = "Close FormChange Data";
            Savelogevent();
        }

        private void rdorecoverypurtosale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdorecoverypurtosale.Checked == true)
            {               
                rdonopass.Checked = true;               
                rdonopass.ForeColor = Color.Red;
                rdopass.ForeColor = Color.Red;
                rdocserailcar.ForeColor = Color.Red;
                rdoctypecar.ForeColor = Color.Red;               
                Searchbranch1();
                idmenuunlock = 19;
            }
        }

        private void CheckUnlockpwd()
        {
            /*
             * 	
                1	[ฝ่ายจัดซื้อ] เปลี่ยนแปลงจัดซื้อ
	            2	[ฝ่ายขายสินค้า] เปลี่ยนแปลงการขาย
	            3	[ฝ่ายจัดสินค้า] เปลี่ยนแปลงชนิดสินค้า
	            4	[ฝ่ายจัดสินค้า] เปลี่ยนแปลงลูกค้า
	            5	[ฝ่ายจัดขนส่ง] เปลี่ยนแปลงส่งลูกค้า
	            6	[ฝ่ายจัดขนส่ง] เปลี่ยนแปลงผู้ขนส่ง
	            7	[ฝ่ายจัดขนส่ง] เปลี่ยนแปลงทะเบียน
	            8	[ฝ่ายจัดขนส่ง] เปลี่ยนแปลงชนิด/ประเภทรถ
	            9	[ฝ่ายจัดขนส่ง] เปลี่ยนแปลงสาขาจัดส่ง
	            10	[ฝ่ายจัดขนส่ง] เปลี่ยน [ซื้อ - คลัง] -> [ซื้อ - ขาย]
	            11	[ฝ่ายจัดขนส่ง] เปลี่ยน [ซื้อ - ขาย] -> [ซื้อ - คลัง]
	            12	[ฝ่ายจัดขนส่ง] เปลี่ยน [คลัง1 - ขาย] -> [คลัง1 - คลัง1]
	            13	[ฝ่ายจัดขนส่ง] เปลี่ยน [คลัง1 - ขาย] -> [คลัง1 - คลัง2]
	            14	[ฝ่ายจัดขนส่ง] ยกเลิก Order ซื้อ
	            15	[ฝ่ายจัดขนส่ง] ยกเลิก Order ขาย       
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
            { MessageBox.Show("user นี้ไม่ได้รับอนุญาติในการเปลี่ยนแปลงข้อมู","ผิดพลาด !",MessageBoxButtons.OK,MessageBoxIcon.Error);}
            CN.Close();
        }

        private void rdocanclepurtosale_CheckedChanged_1(object sender, EventArgs e)
        {
            idmenuunlock = 16;
        }

        private void ChangStatusColor()//เปลี่ยนสีให้ทราบว่าสามารถเปลี่ยนแปลงข้อมูลอะไรได้บ้าง
        {
            if (idordermenu == 0)
            {
                rdorecoverypurchase.ForeColor = Color.Red;
                rdorecoverysale.ForeColor = Color.Red;
                rdorecoverypurtosale.ForeColor = Color.Red;
                rdonopass.ForeColor = Color.Red;
                rdopass.ForeColor = Color.Red;
            }

            else if (idordermenu == 1)
            {
                rdoctypepro.ForeColor = Color.Red;
                rdoctypecar.ForeColor = Color.Red;
                rdocserailcar.ForeColor = Color.Red;
            }

            else if (idordermenu == 2)
            {
                rdoctypepro.ForeColor = Color.Red;
                rdoccuspro.ForeColor = Color.Red;
                rdoctypecar.ForeColor = Color.Red;
                rdoctran.ForeColor = Color.Red;
                rdocserailcar.ForeColor = Color.Red;
            }

            else if (idordermenu == 3)
            { rdoccuspro.ForeColor = Color.Red; }
            else if (idordermenu == 4)
            {
                rdoctypepro.ForeColor = Color.Red;
                rdoctran.ForeColor = Color.Red;
                rdoctypecar.ForeColor = Color.Red;
                rdocserailcar.ForeColor = Color.Red;
                rdocanclepurchase.ForeColor = Color.Red;
            }
            else if (idordermenu == 5)
            {
                rdoccuspro.ForeColor = Color.Red;
                rdoctypepro.ForeColor = Color.Red;
                rdoctypecar.ForeColor = Color.Red;
                rdocanclesale.ForeColor = Color.Red;

            }
            else if (idordermenu == 6)
            {
                rdoctypepro.ForeColor = Color.Red;
                rdoctran.ForeColor = Color.Red;
                rdoctypecar.ForeColor = Color.Red;
                rdocserailcar.ForeColor = Color.Red;
                rdocbranch.ForeColor = Color.Red;
                rdocanclepurchase.ForeColor = Color.Red;
                rdocorderptob.ForeColor = Color.Red;
                rdonopass.ForeColor = Color.Red;
                rdopass.ForeColor = Color.Red;
            }
            else if (idordermenu == 7)
            {
                rdoccuspro.ForeColor = Color.Red;
                rdoctypepro.ForeColor = Color.Red;
                rdoctran.ForeColor = Color.Red;
                rdoctypecar.ForeColor = Color.Red;
                rdocserailcar.ForeColor = Color.Red;
                rdocbranch.ForeColor = Color.Red;
                rdocanclesale.ForeColor = Color.Red;
                rdocorderb1tosale.ForeColor = Color.Red;
                rdocorderb2tosale.ForeColor = Color.Red;
            }
            else if (idordermenu == 8)
            {
                rdoctran.ForeColor = Color.Red;
                rdoccuspro.ForeColor = Color.Red;
                rdocserailcar.ForeColor = Color.Red;
                rdocptosale1.ForeColor = Color.Red;
                rdocanclepurtosale.ForeColor = Color.Red;
                rdorecoverypurtosale.ForeColor = Color.Red;
                rdonopass.ForeColor = Color.Red;
                rdopass.ForeColor = Color.Red;
            }
        }


    }
}