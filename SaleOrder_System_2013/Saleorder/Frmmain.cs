using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using Microsoft.Win32;
using System.Threading;


namespace SaleOrder
{
       
    public partial class Frmmain : Form
    {
        public Frmmain()
        {
            InitializeComponent();
           
        }

        //class TestObject
        //{
        //    public int OneValue { get;set;}
        //    public int TwoValue { get;set;}
        //}

        string idorder = "";
        string statusedit = "";
        //--------------------------------------- check permision
        //int btninsert = 0;
        //int btnedit = 0;
        //int btndelect = 0;
        //int btnreport = 0;        
 //  ฝ่ายซื้อ
	    int		porder= 0;
	    int		ppurtran= 0;
        int     preport = 0;
 //   ฝ่ายขาย
	    int		squatation= 0;
	    int		sorder= 0;
	    int		sreport= 0;
 //   บัญชี
	    int		accreport= 0;
 //  ฝ่ายจัดขนส่ง
	    int	    torder= 0;
        int     trateoil= 0;
        int     tcosttran = 0;
	    int		tmaps= 0;
	    int		treport= 0;
//    ฝ่ายจัดสินค้า
	    int		ictypepro= 0;
	    int		icstock= 0;
	    int	    icorder= 0;
	    int		icreport= 0;
 //   ฝ่ายบริหาร
	    int		mreport= 0;
	    int		mtrancking= 0;
 //   ตั้งค่าระบบ
	    int		smenu= 0;
	    int		sbutton= 0;
        int     srateoil = 0;
	    int		sproduct= 0;
	    int		semployee= 0;
	    int		struck= 0;
	    int		sbranch= 0;
	    int		scompany= 0;
	    int		skeychar= 0;
	    int		stanscale= 0;
	    int		stimeshow	= 0;
 //   รายงานและความผิดพลาด
	    int	    rperror= 0;
        int help = 0;
        int iddate = 0;
/*  ฝ่ายซื้อ
	    ใบสั่งซื้อ		porder
	    รายงาน		preport
    ฝ่ายขาย
	    เสนอราคา		squatation
	    ใบสั่งจ่าย		sorder
	    รายงาน		sreport
    บัญชี
	    รายงาน		accreport
    ฝ่ายจัดขนส่ง
	    จ่าย-ยกเลิก จัดขนส่ง	torder
        ค่าเที่ยวและเรทน้ำมัน    trateoil
	    แผนที่จัดส่ง		       tmaps
	    รายงาน		       treport
    ฝ่ายจัดสินค้า
	    ประเภทสินค้า		ictypepro
	    สต๊อกสินค้า		icstock
	    รับ - จ่าย สินค้า	icorder
	    รายงาน		icreport
    ฝ่ายบริหาร
	    รายงาน		mreport
	    งานปัจจุบัน		mtrancking
    ตั้งค่าระบบ
	    เมนูรายการ		smenu
	    ปุ่มความคุม		sbutton
	    สินค้า		sproduct
	    พนักงาน		semployee
	    รถขนส่ง		struck
	    สาขา		sbranch
	    บริษัท		scompany
	    รหัสชั่ง		skeychar
	    เครื่องชั่ง		stanscale
	    เวลาโชว์		stimeshow	
    รายงานและความผิดพลาด
	    เหตุการณ์และความผิดพลาด	rperror
        ช่วยเหลือ			help                                                    */
        
        DataSet ds = new DataSet(); dtssaleorder dssearch = new dtssaleorder();
        DataSet ds1 = new DataSet(); dtssaleorder dssearch1 = new dtssaleorder();
        DataSet ds2 = new DataSet(); dtssaleorder dssearch2 = new dtssaleorder();
       
        string status = "";       
       //string weigthdf = "0";        
        RegistryKey r;
        string statuspathname = "";
        string datelog = DateTime.Now.Day.ToString();
        string monthlog = DateTime.Now.Month.ToString();
        string yearlog = DateTime.Now.Year.ToString();


        private void CheckMenuandButton()
        {
            try
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();

                string sql = "select * from vpermision where idemp='" + Program.empID + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                while (DR.Read())
                {
                    if (DR["idmenu"].ToString() == "1")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            porder = 1;
                        }
                    }
                    if (DR["idmenu"].ToString() == "2")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            preport = 1;
                        }
                    }
                    if (DR["idmenu"].ToString() == "3")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            squatation = 1;
                        }
                    }
                    if (DR["idmenu"].ToString() == "4")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            sorder = 1;
                        }
                    }

                    if (DR["idmenu"].ToString() == "5")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            sreport = 1;
                        }
                    }

                    if (DR["idmenu"].ToString() == "6")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            accreport = 1;
                        }
                    }
                    if (DR["idmenu"].ToString() == "7")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            torder = 1;
                        }
                    }
                    if (DR["idmenu"].ToString() == "8")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            trateoil = 1;
                        }
                    }
                    if (DR["idmenu"].ToString() == "9")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            tmaps = 1;
                        }
                    }
                    if (DR["idmenu"].ToString() == "10")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            treport = 1;
                        }
                    }
                    if (DR["idmenu"].ToString() == "11")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            ictypepro = 1;
                        }
                    }
                    if (DR["idmenu"].ToString() == "12")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            icstock = 1;
                        }
                    }
                    if (DR["idmenu"].ToString() == "13")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            icorder = 1;
                        }
                    }
                    if (DR["idmenu"].ToString() == "14")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            icreport = 1;
                        }
                    }
                    if (DR["idmenu"].ToString() == "15")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            mreport = 1;
                        }
                    }

                    if (DR["idmenu"].ToString() == "16")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            mtrancking = 1;
                        }
                    }

                    if (DR["idmenu"].ToString() == "17")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            smenu = 1;
                        }
                    }

                    if (DR["idmenu"].ToString() == "18")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            sbutton = 1;
                        }
                    }

                    if (DR["idmenu"].ToString() == "19")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            srateoil = 1;
                        }
                    }

                    if (DR["idmenu"].ToString() == "20")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            sproduct = 1;
                        }
                    }

                    if (DR["idmenu"].ToString() == "21")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            semployee = 1;
                        }
                    }

                    if (DR["idmenu"].ToString() == "22")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            struck = 1;
                        }
                    }

                    if (DR["idmenu"].ToString() == "23")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            sbranch = 1;
                        }
                    }

                    if (DR["idmenu"].ToString() == "24")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            scompany = 1;
                        }
                    }

                    if (DR["idmenu"].ToString() == "25")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            skeychar = 1;
                        }
                    }

                    if (DR["idmenu"].ToString() == "26")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            stanscale = 1;
                        }
                    }

                    if (DR["idmenu"].ToString() == "27")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            stimeshow = 1;
                        }
                    }

                    if (DR["idmenu"].ToString() == "28")//check error
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            rperror = 1;
                        }
                    }

                    if (DR["idmenu"].ToString() == "29")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            help = 1;
                        }
                    }

                    if (DR["idmenu"].ToString() == "30")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            tcosttran = 1;
                        }
                    }

                    if (DR["idmenu"].ToString() == "31")
                    {
                        if (DR["status"].ToString() == "True")
                        {
                            ppurtran = 1;
                        }
                    }
                   
                }
                DR.Close();
            }

            catch(Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
                //RegistryKey r;
        public string conid = "";
        string nmenu = ""; 
        int idtran = 0;
        string idpur = "0"; 
        string idcus = "0"; 
        string msnfrom = ""; 
        string dateWbf = "0";
        int idtypelog = 0; 

        private static void Sqlconnection()
        {
            StreamReader sw = new StreamReader(Application.StartupPath + "\\cn.dll");
            Program.CN = new SqlConnection();
            string connecpovider = sw.ReadToEnd();
            Program.CN.ConnectionString = connecpovider;
            Program.urldb = connecpovider;
          
            try
            {
                Program.CN.Open();          
            }
            catch
            {
                MessageBox.Show("Is Not Connection to Database..", "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.CN.Close();
                sw.Close();

                DialogResult answer;
                answer = MessageBox.Show("Create New Connection to Database Please! Now", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (answer == DialogResult.OK)
                {
                    Frmconnection fcon = new Frmconnection();
                    fcon.ShowDialog();
                    //MessageBox.Show("โปรแกรมปิดตัวเองกรุณาเปิดโปรแกรมใหม่ค่ะ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                }
                else Application.Exit();
            }
        }

        private void datetime_Tick(object sender, EventArgs e)
        {
            sttdatetime.Text = "   " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "         ";
            //runtime statusbar
        }

        private void CheckButton()
        {
            btnsave.Enabled = true;
            btndelete.Enabled = true;
        }

        private void treemenu_AfterSelect(object sender, TreeViewEventArgs e)
        {           
            ds.Clear();
            dssearch.Clear();
            dtporderby.Enabled = false;            
            string sql; timer2.Enabled = false; minute = 0;
            //SqlConnection CN = new SqlConnection();
            //CN.ConnectionString = Program.urldb;
            //CN.Open();
            //nmenu = "";

            if (treemenu.SelectedNode.Name == "porder")//ทำการายการซื้อ
            {
                if (porder == 1)
                {                    
                    nmenu = "porder";
                    dtporderby.Enabled = true;
                    iddate = 1; timer2.Enabled = true;
                    //sql = ViewPurchase(CN);
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            ppurtran = 1;
            if (treemenu.SelectedNode.Name == "ppurtran")//ทำการายการเงินมัดจำและขนส่ง
            {
                if (ppurtran == 1)
                {
                    nmenu = "ppurtran";
                    FrmPurchasePay fppy = new FrmPurchasePay();
                    fppy.ShowDialog();
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            preport = 1;
            if (treemenu.SelectedNode.Name == "preport")//รายงานซื้อ
            {
                if (preport == 1)
                {                   
                    nmenu = "preport";
                    w frmp = new w();
                    frmp.ShowDialog();
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            squatation = 1;
            if (treemenu.SelectedNode.Name == "squatation")//ออกใบเสนอราคา
            {
                if (squatation == 1)
                {
                    nmenu = "squatation";                   
                    Frmquatation fccj = new Frmquatation();
                    fccj.ShowDialog();
                    DisableAllDatagrid();
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

          
            if (treemenu.SelectedNode.Name == "sorder")//ทำรายการใบสั่งจ่าย
            {
                if (sorder == 1)
                {                    
                    nmenu = "sorder";
                    dtporderby.Enabled = true;
                    iddate = 2; timer2.Enabled = true;
                    //sql = ViewOrder(CN);
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            sreport = 1;
            if (treemenu.SelectedNode.Name == "sreport")//รายงานใบสั่งจ่าย
            {
                if (sreport == 1)
                {                   
                    nmenu = "sreport";
                    w frmp = new w();
                    frmp.ShowDialog();
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            accreport = 1;
            if (treemenu.SelectedNode.Name == "accreport")//รายงานบัญชี
            {
                if (accreport == 1)
                {                   
                    nmenu = "accreport";
                    w frmp = new w();
                    frmp.ShowDialog();
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            torder = 1;
            if (treemenu.SelectedNode.Name == "torder")//จัดขนส่ง เลือกจ่ายงานให้คลัง
            {
                if (torder == 1)
                {                   
                    Frmpayjob frmj = new Frmpayjob();
                    frmj.ShowDialog();
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            trateoil = 1;
            if (treemenu.SelectedNode.Name == "trateoil")//ค่าเที่ยวและเรทน้ำมัน
            {
                if (trateoil == 1)
                {
                    Frmrateoil frat = new Frmrateoil();
                    frat.ShowDialog();
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            tmaps = 1;
            if (treemenu.SelectedNode.Name == "tmaps")//แผนที่
            {
                if (tmaps == 1)
                {
                    Frmmap fmap = new Frmmap();
                    fmap.ShowDialog();
                    CheckButton();
                }
                else
                { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }


            treport = 1;
            if (treemenu.SelectedNode.Name == "treport")//รายงานฝ่ายจัดขนส่ง
            {
                if (treport == 1)
                {                   
                    nmenu = "treport";
                    w frmp = new w();
                    frmp.ShowDialog();
                    CheckButton();
                }
                else
                { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            ictypepro = 1;
            if (treemenu.SelectedNode.Name == "ictypepro")//ประเภทสินค้า	
            {
                if (ictypepro == 1)
                {
                    Frmtypeproduct fak = new Frmtypeproduct();
                    fak.ShowDialog();
                    CheckButton();
                }
                else
                { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            icstock = 1;
            if (treemenu.SelectedNode.Name == "icstock")//ส่วนสต๊อกสินค้า
            {
                if (icstock == 1)
                {
                    FrmStockadd stca = new FrmStockadd();
                    stca.ShowDialog();
                    CheckButton();
                }
                else
                { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            icorder = 1;
            if (treemenu.SelectedNode.Name == "icorder")//รับ จ่ายสินค้า
            {
                if (icorder == 1)
                {                    
                    nmenu = "icorder";
                    FrmTransport fprod = new FrmTransport();
                    fprod.ShowDialog();                    
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            icreport = 1;
            if (treemenu.SelectedNode.Name == "icreport")//รายงาน รับ จ่ายสินค้า
            {
                if (icreport == 1)
                {                   
                    nmenu = "icreport";
                    w frmp = new w();
                    frmp.ShowDialog();
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            mreport = 1;
            if (treemenu.SelectedNode.Name == "mreport")//รายงานผู้บริหาร
            {
                if (mreport == 1)
                {                   
                    nmenu = "mreport";
                    w frmp = new w();
                    frmp.ShowDialog();

                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            mtrancking = 1;
            if (treemenu.SelectedNode.Name == "mtrancking")//ติดตามงานปัจจุบัน
            {
                if (mtrancking == 1)
                {
                    Frmpayjob fstaj = new Frmpayjob();
                    fstaj.ShowDialog();

                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            sbutton = 1;
            if (treemenu.SelectedNode.Name == "sbutton")//ส่วนปุ่มควบคุม
            {
                if (sbutton == 1)
                {
                    nmenu = "sbutton";
                    FrmbuttonControl fbtn = new FrmbuttonControl();
                    fbtn.ShowDialog();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "sproduct")//ส่วนสินค้า
            {
                if (sproduct == 1)
                {                   
                    nmenu = "sproduct";
                    gridvproduct(dssearch, ds);
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "semployee")//ส่วนพนักงาน
            {
                if (semployee == 1)
                {                    
                    nmenu = "semployee";
                    gridvEmployee();
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "struck")//ส่วนประเภทรถขนส่ง
            {
                if (struck == 1)
                {                    
                    nmenu = "struck";                   
                    //sql = gridcar(CN);
                    CheckButton();
                }
                else
                { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            
            if (treemenu.SelectedNode.Name == "sbranch")//ส่วนสาขา
            {
                if (sbranch == 1)
                {                    
                    nmenu = "sbranch";
                    //sql = gridBranch(CN);
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "scompany")
            {
                if (scompany == 1)
                {                   
                    nmenu = "scompany";
                    gridsupcomcus();
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "skeychar")//ส่วนจัดการเรื่องตัวอักษรนำ
            {
                if (skeychar == 1)
                {
                    FrmAutokey fak = new FrmAutokey();
                    fak.ShowDialog();
                    CheckButton();
                }
                else
                { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "stanscale")//ส่วนจัดการเรื่องเซ็ตตาชั่ง
            {
                if (stanscale == 1)
                {
                    FrmTruckscale ftsc = new FrmTruckscale();
                    ftsc.ShowDialog();
                    CheckButton();
                }
                else
                { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "stimeshow")//ส่วนตั้งเวลาแจ้ง
            {
                if (stimeshow == 1)
                {                    
                    nmenu = "stimesho";
                    Frmtime frmp = new Frmtime();
                    frmp.ShowDialog();
                    CheckButton();
                }
                else
                { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            
            if (treemenu.SelectedNode.Name == "rperror")//ส่วนเหตุการ
            {              

                if (rperror == 1)
                {                   
                    nmenu = "rperror";
                        //sql = Gridlog(CN); iddate = 3;
                    CheckButton();
                }
                else
                { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "help")//ส่วนช่วยเหลือ
            {
                if (help == 1)
                {                   
                    nmenu = "help";
                    DisableAllDatagrid();
                    CheckButton();
                }
                else
                { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "tcosttran")//ส่วนค่าเที่ยขนส่ง
            {
                if (tcosttran == 1)
                {                   
                    nmenu = "tcosttran";
                    Frmcosttran frmp = new Frmcosttran();
                    frmp.ShowDialog();                    
                    CheckButton();
                }
                else
                { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            //CN.Close();
        }        

        private void DisableAllDatagrid()
        {
            dtgproduct.Visible = false;
            dtgemployee.Visible = false;
            dtgcompany.Visible = false;
            dtgpurordertran.Visible = false;
            dtgsaleordertran.Visible = false;
            dtgbranch.Visible = false;
            dtgcar.Visible = false;
            dtglog.Visible = false;
                     
        }                           

        private string Gridlog(SqlConnection CN)
        {
            string day = dtporderby.Value.Day.ToString();
            string month = dtporderby.Value.Month.ToString();
            string year = dtporderby.Value.Year.ToString();
            string date = month + "/" + day + "/" + year;
            dtporderby.Enabled = true;
            DisableAllDatagrid();
            string sql;
            ds.Clear();
            dssearch.Clear();
            dtglog.DataSource = dssearch;
            sql = "select * from vlog where datein='" + date + "' ";
            SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
            da1.Fill(ds, "slog");
            dtglog.DataSource = ds.Tables["slog"];
            dtglog.Dock = DockStyle.Fill;
            lbltotalitems.Text = "Total: " + dtglog.RowCount.ToString() + " Items";     
            dtglog.Visible = true;
                        
            return sql;
        }

        private string gridcar(SqlConnection CN)
        {
            DisableAllDatagrid();
            string sql;
            ds.Clear();
            dssearch.Clear();
            dtgcar.DataSource = dssearch;
            sql = "select * from tbcar";
            SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
            da1.Fill(ds, "scar");
            dtgcar.DataSource = ds.Tables["scar"];
            lbltotalitems.Text = "Total: " + dtgcar.RowCount.ToString() + " Items";
            dtgcar.Dock = DockStyle.Fill;                     
            dtgcar.Visible = true;            
            return sql;
        }

        private string gridBranch(SqlConnection CN)
        {
            DisableAllDatagrid();
            ds.Clear();
            dssearch.Clear();
            string sql;
            dtgbranch.DataSource = dssearch;
            sql = "select * from vbranch order by idbranch desc";
            SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
            da1.Fill(ds, "sbranch");
            dtgbranch.DataSource = ds.Tables["sbranch"];
            dtgbranch.Dock = DockStyle.Fill;
            lbltotalitems.Text = "Total: " + dtgbranch.RowCount.ToString() + " Items";        
            dtgbranch.Visible = true;                             
            return sql;
        }    

        private string ViewOrder(SqlConnection CN)
        {
            string day = dtporderby.Value.Day.ToString();
            string month = dtporderby.Value.Month.ToString();
            string year = dtporderby.Value.Year.ToString();
            string date = month + "/" + day + "/" + year;

            string sql; DisableAllDatagrid();
            dtgsaleordertran.DataSource = dssearch;
            ds.Clear(); dssearch.Clear();
            //orderdate =" + date + "
            sql = "select * from vsaleorder where orderdate ='" + date + "'";
            SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
            da1.Fill(ds, "ssorder");
            dtgsaleordertran.DataSource = ds.Tables["ssorder"];
            lbltotalitems.Text = "Total: " + dtgsaleordertran.RowCount.ToString() + " Items";
            dtgsaleordertran.Dock = DockStyle.Fill;           
            dtgsaleordertran.Visible = true;            
            ColorStatusCheckSale();
            CheckAddressCus();
            return sql;
        }

        private string ViewPurchase(SqlConnection CN)
        {
            string day = dtporderby.Value.Day.ToString();
            string month = dtporderby.Value.Month.ToString();
            string year = dtporderby.Value.Year.ToString();
            string date = month + "/" + day + "/" + year;

            string sql; DisableAllDatagrid();
            ds.Clear(); dssearch.Clear();
            dtgpurordertran.DataSource = dssearch;
            // datepur =" + date + "
            sql = "select * from vpurchase where datepur ='" + date + "'";
            SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
            da1.Fill(ds, "svsuot");
            dtgpurordertran.DataSource = ds.Tables["svsuot"];
            lbltotalitems.Text = "Total: " + dtgpurordertran.RowCount.ToString() + " Items";
            dtgpurordertran.Dock = DockStyle.Fill;            
            dtgpurordertran.Visible = true;                      
            ColorStatusCheckPurchase();
            return sql;
        }

        private void ColorStatusCheckPurchase()
        {
           SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            for (int i = 0; i < dtgpurordertran.RowCount; i++)
            {
                string sql1 = "select idtran,idstatus from vpurchase where idpur = '" + dtgpurordertran[0, i].Value.ToString().Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {                   
                   
                    if (DR1["idtran"].ToString() != "" && DR1["idstatus"].ToString() == "2")
                    { 
                        dtgpurordertran[1, i].Value = "Success"; 
                        dtgpurordertran.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(215, 228, 188); 
                    }

                    else if (DR1["idstatus"].ToString() == "7")
                    { 
                        dtgpurordertran[1, i].Value = "Cancle"; 
                        dtgpurordertran.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(242, 221, 220);
                        dtgpurordertran.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                    }

                    else { 
                        dtgpurordertran[1, i].Value = "-"; 
                        dtgpurordertran.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(242, 221, 220);
                    }
                }
                DR1.Close();
            }
            CN.Close();
        }

        private void ColorStatusCheckSale()
        {
           SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            for (int i = 0; i < dtgsaleordertran.RowCount; i++)
            { 
                string sql1 = "select idtran,idstatus from vsaleorder where idorder = '" + dtgsaleordertran[0, i].Value.ToString().Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {                  
                    if (DR1["idtran"].ToString() != "" && DR1["idstatus"].ToString() == "1")
                    {
                        dtgsaleordertran[1, i].Value = "Success";
                        dtgsaleordertran.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(215, 228, 188);
                    }

                    else  if (DR1["idstatus"].ToString() == "7")
                    {
                        dtgsaleordertran[1, i].Value = "Cancle";
                        dtgsaleordertran.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(242, 221, 220);
                        dtgsaleordertran.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                    }

                    else
                    {
                        dtgsaleordertran[1, i].Value = "-";
                        dtgsaleordertran.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(242, 221, 220);
                    }
                }
                DR1.Close();
            }

            CN.Close();
        }

        private void CheckAddressCus()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            int idbranchcus = 0;


            for (int i = 0; i < dtgsaleordertran.RowCount; i++)
            {
                string sql1 = "select idbranchCus from vsaleorder where idorder = '" + dtgsaleordertran[0, i].Value.ToString().Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    idbranchcus = Convert.ToInt16(DR1["idbranchCus"].ToString());
                }
                DR1.Close();

                string sql2 = "select * from tbbrach where idbranch = " + idbranchcus + "";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();

                DR2.Read();
                {
                    dtgsaleordertran[5, i].Value = DR2["bname"].ToString() + " " + DR2["baddress"].ToString() + " " + DR2["rd"].ToString() + " " + DR2["tumb"].ToString() + " " + DR2["country"].ToString() + " " + DR2["provice"].ToString() + " " + DR2["zipcode"].ToString();                    
                }
                DR2.Close();
            }

            CN.Close();
        }

        private void CheckStatusTransport()
        {
            dtgemployee.Visible = false;
            dtgproduct.Visible = false;
            dtgcompany.Visible = false;
            dtgsaleordertran.Visible = false;
            dtgpurordertran.Visible = false;
            dtgbranch.Visible = false;
            dtgcar.Visible = false;
            dtglog.Visible = false;                         
        }     
          
        private void gridsupcomcus()
        {
            ds.Clear(); dssearch.Clear();
            string sql;
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); DisableAllDatagrid();

            dtgcompany.DataSource = dssearch;
            sql = "select * from vtbcom";//ต่อด้วยเช็คแผนกพนักงานเพื่อค้นหาบริษัทที่แผนกใครแผนกมัน
            SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
            da1.Fill(ds, "com");
            dtgcompany.DataSource = ds.Tables["com"];
            lbltotalitems.Text = "Total: " + dtgcompany.RowCount.ToString() + " Items";
            dtgcompany.Dock = DockStyle.Fill;            
            dtgcompany.Visible = true;
            CN.Close();      
        }

        private void gridvEmployee()
        {
            ds.Clear();
            dssearch.Clear();
            dtgemployee.DataSource = dssearch;
            string sql; DisableAllDatagrid();
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            sql = "select * from vemployee";
            SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
            da1.Fill(ds, "emp");
            dtgemployee.DataSource = ds.Tables["emp"];
            lbltotalitems.Text = "Total: " + dtgemployee.RowCount.ToString() + " Items";
            dtgemployee.Dock = DockStyle.Fill;
            dtgemployee.Visible = true;
            CN.Close();
        }

        private void gridvproduct(dtssaleorder dssearch, DataSet ds)//refresh gridproduct
        {
            ds.Clear();
            dssearch.Clear();
            dtgproduct.DataSource = dssearch;
            string sql; DisableAllDatagrid();
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            sql = "select * from vproduct";
            SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
            da1.Fill(ds, "spro");
            dtgproduct.DataSource = ds.Tables["spro"];
            lbltotalitems.Text = "Total: " + dtgproduct.RowCount.ToString() + " Items";
            dtgproduct.Dock = DockStyle.Fill;
            dtgproduct.Visible = true;
            CN.Close();
        }     

        private void btnexit_Click_1(object sender, EventArgs e)
        {
            DialogResult answer;
            answer = MessageBox.Show("คุณต้องการออกจากโปรแกรมใช่หรือไม่ !", "กรุณายืนยัน !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (answer == DialogResult.OK)
            {
                Application.Exit();
            }
        }
   

        private void Frmmain_Load(object sender, EventArgs e)
        {             
            timer2.Enabled = false;
            //Sqlconnection();

          
            dtgpurordertran.Visible = false;
            dtgproduct.Visible = false;
            dtglog.Visible = false;
            dtgsaleordertran.Visible = false;


            //Frmlogin flg = new Frmlogin();
            //flg.ShowDialog();
            //loadpathshowstatusdatabase();
            //Checklogin();            
            ////MessageBox.Show(Program.showtime.ToString());
            //Program.CN.Close();
            CheckMenuandButton();//check status menu
            timer2.Enabled = true;
          
        }

        private void Checklogin()
        {
            if (Program.logins == "")
            {
                this.Close();
            }
            else
            {
                timeshowrequest();

                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();
                string sql = "select * from vemplogin where idemp='" + Program.empID.ToString() + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                DR.Read();
                {
                    sttlogindept.Text = "Login Name: " + DR["empname"].ToString() + "   Dept: " + DR["depname"].ToString();
                    sttcombranch.Text = "   Company: " + DR["cname"].ToString() + "   Branch: " + DR["bname"].ToString() + "";
                    sttbasepath.Text = statuspathname;

                    Program.idbranch = DR["idbranch"].ToString();
                }
                DR.Close();
                CN.Close();
            }
        }
        
        private void loadpathshowstatusdatabase()
        {
            string path = "Saleorder";
            r = Registry.CurrentUser.OpenSubKey(path); //เรียกใช้งาน OpenSubKey เพื่อทำให้สามารถเข้าถึง 
           statuspathname="   Conect Servername: " + Convert.ToString(r.GetValue("ServerName"))+"  Databasename: "+ Convert.ToString(r.GetValue("DatabaseName")); 
        }
        
        int timeshow = 0;
        private void timeshowrequest()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql = "select * from tbtime";
            SqlCommand CM = new SqlCommand(sql, CN);
            SqlDataReader DR = CM.ExecuteReader();
            DR.Read();
            {
                timeshow = Convert.ToInt16(DR["times"].ToString());
            }
            DR.Close();
            CN.Close();
        }

        private void dtgproduct_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idorder = dtgproduct[0, e.RowIndex].Value.ToString();           
        }

        private void dtgproduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            // status 0 = createnew  1=edit
            try
            {
                Frmproduct fprod = new Frmproduct();
                fprod.proname = dtgproduct[0, e.RowIndex].Value.ToString();
                fprod.status = 1;
                fprod.ShowDialog();
                gridvproduct(dssearch, ds);               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debug" + ex.Message, "พลิดพลาด !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void dtgemployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Frmemployee fme = new Frmemployee();
                fme.idemp = dtgemployee[0, e.RowIndex].Value.ToString();
                fme.status = 1; //ส่งค่าสถานะแก้ไข
                fme.ShowDialog();
                gridvEmployee();              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debug" + ex.Message, "พลิดพลาด !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void dtgemployee_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                idorder = dtgemployee[0, e.RowIndex].Value.ToString();               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error !" + ex.Message);
            }
        }

        private void dtgssupcomcus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idorder = dtgcompany[0, e.RowIndex].Value.ToString();            
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string sql;
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (nmenu == "sproduct")//
            {
                Frmproduct fprod = new Frmproduct();
                fprod.ShowDialog();
                gridvproduct(dssearch, ds);
            }

            if (nmenu == "semployee")
            {
                Frmemployee fem = new Frmemployee();
                fem.ShowDialog();
                gridvEmployee();
            }

            if (nmenu == "scompany")
            {
                Frmcompany fcom = new Frmcompany();                
                fcom.ShowDialog();
                gridsupcomcus();
            }

            if (nmenu == "porder")
            {
                FrmPurchase fprod = new FrmPurchase();                
                fprod.ShowDialog();
                ds.Clear();
                dssearch.Clear();
                sql = ViewPurchase(CN);               
            }

            if (nmenu == "sorder")
            {
                FrmSaleOrder fprod = new FrmSaleOrder();
                fprod.ShowDialog();
                ds.Clear();
                dssearch.Clear();
                sql = ViewOrder(CN);              
            }                       

            if (nmenu == "struck")
            {
                Frmcar fprod = new Frmcar();
                fprod.ShowDialog();
                ds.Clear();
                dssearch.Clear();               
                sql = gridcar(CN);
            }

            if (nmenu == "skeychar")
            {
                FrmAutokey fatk = new FrmAutokey();
                fatk.ShowDialog();                
            }

            if (nmenu == "stanscale")
            {
                FrmTruckscale ftsc = new FrmTruckscale();
                ftsc.ShowDialog();
            }           

            if (nmenu == "tmaps")
            {
                Frmmap fmap = new Frmmap();
                fmap.ShowDialog();
            }
            CN.Close();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string sql;// string sql4;// string sql5;//sql3; string 
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (nmenu == "sproduct" && idorder != "")//
            {
                Frmproduct fprod = new Frmproduct();
                fprod.proname = Convert.ToString(idorder).Trim();
                fprod.status = 1;
                fprod.ShowDialog();
                gridvproduct(dssearch, ds);
            }
            if (nmenu == "semployee" && idorder != "")
            {
                Frmemployee fre = new Frmemployee();
                fre.idemp = idorder;
                fre.status = 1;
                fre.ShowDialog();
                ds.Clear();
                dssearch.Clear();
                dtgproduct.DataSource = dssearch;
                gridvEmployee();
            }


            if (nmenu == "scompany" && idorder != "")
            {
                Frmcompany frcom = new Frmcompany();   
                frcom.ShowDialog();
                gridsupcomcus();               
            }

            else if (nmenu == "struck" && idorder != "")
            {
                Frmcar frmb = new Frmcar();
                frmb.idcar = Convert.ToInt16(idorder);
                frmb.idstatus = 1;
                frmb.ShowDialog();
                sql = gridcar(CN);
            }

            else if (nmenu == "porder" && idorder != "" && statusedit == "-")
            {
                FrmPurchase frcom = new FrmPurchase();
                frcom.id = idorder.Trim();
                frcom.idedit = 1;      
                frcom.ShowDialog();
                sql = ViewPurchase(CN);               
            }

            else if (nmenu == "sorder" && idorder != "" && statusedit == "-")
            {
                FrmSaleOrder fsorder = new FrmSaleOrder();
                fsorder.id = idorder.Trim();
                fsorder.idstatus = 1;
                fsorder.ShowDialog();
                sql = ViewOrder(CN);               
            }
            CN.Close();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); string sql;

            if (nmenu == "sproduct" && idorder != "")
            {
                DialogResult answer;
                answer = MessageBox.Show("คุณต้องการลบรายการนี้ใช่หรือไม่ !", "ยืนยัน", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (answer == DialogResult.OK)
                {
                    string sql1 = "delete dtproduct where idpro= " + idorder.Trim() + "";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();

                    MessageBox.Show("ข้อมูลที่คุณได้เลือกถูกยกเลิกแล้ว", "รายงาน !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ds.Clear();
                    gridvproduct(dssearch, ds);                   
                }
            }

            else if (nmenu == "semployee" && idorder != "")
            {
                string sql1 = "delete tbemployee where idemp= '" + idorder.Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                CM1.ExecuteNonQuery();

                MessageBox.Show("ข้อมูลที่คุณได้เลือกถูกยกเลิกแล้ว", "รายงาน !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds.Clear();
                gridvEmployee();                
            }

            //update tbcompany set cname='" + txtname.Text + "',cremark='" + txtremark.Text + "',idbranch=" + txtidbranch.Text + " Where idcom='" + txtid.Text + "'";

            if (nmenu == "porder" && idorder != "")
            {
                DialogResult answer;
                answer = MessageBox.Show("คุณต้องการยกเลิกรายการซื้อใช่หรือไม่ !", "กรุณายืนยัน !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (answer == DialogResult.OK)
                {
                    Frmconfirmpwdchagedata frcj = new Frmconfirmpwdchagedata();
                    frcj.idmenuunlock = 14;
                    frcj.idcancle = idorder.Trim();
                    frcj.ShowDialog();

                    if (frcj.idreturn == 1)
                    {
                        MessageBox.Show("ข้อมูลที่คุณได้เลือกถูกยกเลิกแล้ว", "รายงาน !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ds.Clear(); dssearch.Clear();
                        sql = ViewPurchase(CN);
                    }
                }
            }

            if (nmenu == "sorder" && idorder != "")
            {
                DialogResult answer;
                answer = MessageBox.Show("คุณต้องการยกเลิกรายการขายใช่หรือไม่ !", "กรุณายืนยัน !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (answer == DialogResult.OK)
                {
                    Frmconfirmpwdchagedata frcj = new Frmconfirmpwdchagedata();
                    frcj.idmenuunlock = 15;
                    frcj.idcancle = idorder.Trim();
                    frcj.ShowDialog();

                    if (frcj.idreturn == 1)
                    {
                        MessageBox.Show("ข้อมูลที่คุณได้เลือกถูกยกเลิกแล้ว", "รายงาน !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ds.Clear(); dssearch.Clear(); 
                        sql = ViewOrder(CN);
                    }
                }
            }
            CN.Close();
        }          

        private void dtgproduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idorder = dtgproduct[0, e.RowIndex].Value.ToString();
        }

        private void dtgemployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idorder = dtgemployee[0, e.RowIndex].Value.ToString();
        }
        
        private void dtgpurordertran_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idorder = dtgpurordertran[0, e.RowIndex].Value.ToString();
        }

        private void dtgsaleordertran_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idorder = dtgsaleordertran[0, e.RowIndex].Value.ToString();
        }

        private void dtgbranch_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idorder = dtgbranch[0, e.RowIndex].Value.ToString();
        }             

        private void dtgcompany_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (treemenu.SelectedNode.Name == "ndecom")
                {
                    Frmcompany frcom = new Frmcompany();                   
                    frcom.ShowDialog();                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debug" + ex.Message, "พลิดพลาด !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void Frmmain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.empID != "")
            {
                Savelogevent();
            }
        }

        private void UpdateLogIn()//updata Status employee login
        {
            try
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();
                string sql = "update tbemployee set isemp=" + 0 + " Where idemp= '" + Program.empID + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();
                CN.Close();
            }
            catch (Exception ex)
            { //Application.Restart();
                MessageBox.Show(ex.Message);
            }
        }

        private void Savelogevent()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string selectdatelog = monthlog + "/" + datelog + "/" + yearlog;  
            string msnfrom = "ExitProgram";
            string sql1 = "insert into tblog(logname,datein,timein,idtypelog,idemp,remark) values('" + msnfrom + "','" + selectdatelog + "','" + DateTime.Now.ToLongTimeString() + "'," + 6 + ",'" + Program.empID + "','" + Program.empID + "')";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            CM1.ExecuteNonQuery();
            CN.Close();
        }

        private void dtgcar_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;           
                idorder = dtgcar[0, e.RowIndex].Value.ToString();                        
        }

        private void dtgcar_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); string sql;

            try
            {
                Frmcar frmb = new Frmcar();
                frmb.idcar = Convert.ToInt16(dtgcar[0, e.RowIndex].Value.ToString());
                frmb.idstatus = 1;
                frmb.ShowDialog();
                sql = gridcar(CN);                
                CN.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debug" + ex.Message, "พลิดพลาด !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }           
        }   

        private void btnlogout_Click(object sender, EventArgs e)
        {
            DialogResult answer;
            answer = MessageBox.Show("คุณต้องการเปลี่ยนผู้งานใช่หรือไม่ !", "กรุณายืนยัน !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (answer == DialogResult.OK)
            {
                Program.CN.Close();
                Application.Restart();
            }
        }
                 
        private void processbar()
        {  
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (porder == 1)
            {              
              string  sql = ViewPurchase(CN);                
            }

            if (sorder == 1)
            {                
               string sql = ViewOrder(CN);              
            }
            CN.Close();
        }

        int minute = 0;                  
             
        private void Frmmain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Program.CN.Close();
            UpdateLogIn();
        }       
     
        private void btnviewreport_Click(object sender, EventArgs e)
        {
            //if (rdopurcancle.Checked == true)
            //{
            //    Frmviewreport frrp = new Frmviewreport();
            //    frrp.rpname = "rppurchasecancle";
            //    frrp.ShowDialog();
            //}
            //else if (rdosalecancle.Checked == true)
            //{
            //    Frmviewreport frrp = new Frmviewreport();
            //    frrp.rpname = "rpsalecancle";
            //    frrp.ShowDialog();
            //}

        }

        private void dtgpurordertran_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
                if (dtgpurordertran[1, e.RowIndex].Value.ToString() == "Cancle" || dtgpurordertran[1, e.RowIndex].Value.ToString() == "Success")
            { btnupdate.Enabled = false; btndelete.Enabled = false; }

            else
            {
                idorder = dtgpurordertran[0, e.RowIndex].Value.ToString().Trim();
                statusedit = dtgpurordertran[1, e.RowIndex].Value.ToString().Trim();
                btnupdate.Enabled = true; btndelete.Enabled = true;
            }
        }

        private void dtgsaleordertran_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           //if (e.RowIndex < 0) return;
           // dtgsaleordertran.DataSource = ds.Tables["ssorder"];
           // lbltotalitems.Text = "Total: " + dtgsaleordertran.RowCount.ToString() + " Items";

            if (dtgsaleordertran[1, e.RowIndex].Value.ToString() == "Cancle" || dtgsaleordertran[1, e.RowIndex].Value.ToString() == "Success" || dtgsaleordertran[1, e.RowIndex].Value.ToString() == "")
            { btnupdate.Enabled = false; btndelete.Enabled = false; }
            
            else
            {
                idorder = dtgsaleordertran[0, e.RowIndex].Value.ToString().Trim();
                statusedit = dtgsaleordertran[1, e.RowIndex].Value.ToString().Trim();
                btnupdate.Enabled = true; btndelete.Enabled = true;
            }
        }            
        
        private void button1_Click(object sender, EventArgs e)
        {
            Frmtruckin frm = new Frmtruckin();
            frm.ShowDialog();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            ds.Clear();
            dssearch.Clear();
           
            string sql;
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            nmenu = "";

            if (treemenu.SelectedNode.Name == "porder")//ทำการายการซื้อ
            {
                if (porder == 1)
                {                   
                    nmenu = "ndepurchase";
                    dtporderby.Enabled = true;
                    sql = ViewPurchase(CN);
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "preport")//รายงานซื้อ
            {
                if (preport == 1)
                {                  
                    nmenu = "ndereport";
                    w frmp = new w();
                    frmp.ShowDialog();
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "squatation")//ออกใบเสนอราคา
            {
                if (squatation == 1)
                {
                    nmenu = "ndequa";                    
                    Frmquatation fccj = new Frmquatation();
                    fccj.ShowDialog();
                    DisableAllDatagrid();
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "sorder")//ทำรายการใบสั่งจ่าย
            {
                if (sorder == 1)
                {                   
                    nmenu = "ndeorder";
                    dtporderby.Enabled = true;
                    sql = ViewOrder(CN);
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "sreport")//รายงานใบสั่งจ่าย
            {
                if (sreport == 1)
                {                  
                    nmenu = "ndereport";
                    w frmp = new w();
                    frmp.ShowDialog();
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "accreport")//รายงานบัญชี
            {
                if (accreport == 1)
                {                  
                    nmenu = "ndereport";
                    w frmp = new w();
                    frmp.ShowDialog();
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "torder")//จัดขนส่ง เลือกจ่ายงานให้คลัง
            {
                if (torder == 1)
                {                   
                    Frmpayjob frmj = new Frmpayjob();
                    frmj.ShowDialog();
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "trateoil")//ค่าเที่ยวและเรทน้ำมัน
            {
                if (trateoil == 1)
                {
                    Frmrateoil frat = new Frmrateoil();
                    frat.ShowDialog();
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "tmaps")//แผนที่
            {
                if (tmaps == 1)
                {
                    Frmmap fmap = new Frmmap();
                    fmap.ShowDialog();
                    CheckButton();
                }
                else
                { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "treport")//รายงานฝ่ายจัดขนส่ง
            {
                if (treport == 1)
                {                   
                    nmenu = "ndereport";
                    w frmp = new w();
                    frmp.ShowDialog();
                    CheckButton();
                }
                else
                { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "ictypepro")//ประเภทสินค้า	
            {
                if (ictypepro == 1)
                {
                    Frmtypeproduct fak = new Frmtypeproduct();
                    fak.ShowDialog();
                    CheckButton();
                }
                else
                { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "icstock")//ส่วนสต๊อกสินค้า
            {
                if (icstock == 1)
                {
                    FrmStockadd stca = new FrmStockadd();
                    stca.ShowDialog();
                    CheckButton();
                }
                else
                { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "icorder")//รับ จ่ายสินค้า
            {
                if (icorder == 1)
                {                   
                    nmenu = "ndeproin";
                    FrmTransport fprod = new FrmTransport();
                    fprod.ShowDialog();                  
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "icreport")//รายงาน รับ จ่ายสินค้า
            {
                if (icreport == 1)
                {                    
                    nmenu = "ndereport";
                    w frmp = new w();
                    frmp.ShowDialog();
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }


            if (treemenu.SelectedNode.Name == "mreport")//รายงานผู้บริหาร
            {
                if (mreport == 1)
                {                    
                    nmenu = "ndereport";
                    w frmp = new w();
                    frmp.ShowDialog();

                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "mtrancking")//ติดตามงานปัจจุบัน
            {
                if (mtrancking == 1)
                {
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
              

            if (treemenu.SelectedNode.Name == "sbutton")//ส่วนปุ่มควบคุม
            {
                if (sbutton == 1)
                {
                    nmenu = "ndecmbbtn";
                    FrmbuttonControl fbtn = new FrmbuttonControl();
                    fbtn.ShowDialog();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "sproduct")//ส่วนสินค้า
            {
                if (sproduct == 1)
                {                  
                    nmenu = "ndeproduct";
                    gridvproduct(dssearch, ds);
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "semployee")//ส่วนพนักงาน
            {
                if (semployee == 1)
                {                   
                    nmenu = "ndeemp";
                    gridvEmployee();
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "struck")//ส่วนประเภทรถขนส่ง
            {
                if (struck == 1)
                {                   
                    nmenu = "ndecar";
                    //DisableAllDatagrid();
                    sql = gridcar(CN);
                    CheckButton();
                }
                else
                { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }


            if (treemenu.SelectedNode.Name == "sbranch")//ส่วนสาขา
            {
                if (sbranch == 1)
                {                  
                    nmenu = "ndebranch";
                    //DisableAllDatagrid();             
                    sql = gridBranch(CN);
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "scompany")
            {
                if (scompany == 1)
                {                    
                    nmenu = "ndecom";
                    gridsupcomcus();
                    CheckButton();
                }
                else { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "skeychar")//ส่วนจัดการเรื่องตัวอักษรนำ
            {
                if (skeychar == 1)
                {
                    FrmAutokey fak = new FrmAutokey();
                    fak.ShowDialog();
                    CheckButton();
                }
                else
                { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "stanscale")//ส่วนจัดการเรื่องเซ็ตตาชั่ง
            {
                if (stanscale == 1)
                {
                    FrmTruckscale ftsc = new FrmTruckscale();
                    ftsc.ShowDialog();
                    CheckButton();
                }
                else
                { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "stimeshow")//ส่วนตั้งเวลาแจ้ง
            {
                if (stimeshow == 1)
                {                   
                    nmenu = "ndetime";
                    Frmtime frmp = new Frmtime();
                    frmp.ShowDialog();
                    CheckButton();
                }
                else
                { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }


            if (treemenu.SelectedNode.Name == "rperror")//ส่วนเหตุการ
            {
                if (rperror == 1)
                {                   
                    nmenu = "ndeevent";
                    sql = Gridlog(CN);
                    CheckButton();
                }
                else
                { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            if (treemenu.SelectedNode.Name == "help")//ส่วนช่วยเหลือ
            {
                if (help == 1)
                {                    
                    nmenu = "ndehelp";
                    DisableAllDatagrid();
                    CheckButton();
                }
                else
                { MessageBox.Show("คุณไม่ได้รับสิทธิ์เข้าถึงข้อมูลนี้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            CN.Close();
        }
                           
        private void dtgsaleordertran_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //SqlConnection CN = new SqlConnection();
            //CN.ConnectionString = Program.urldb;
            //CN.Open();
            //FrmSaleOrder fso = new FrmSaleOrder();
            //fso.idsorder = dtgsaleordertran[0, e.RowIndex].ToString();
            //fso.idstatus = 1;
            //fso.ShowDialog();
            //CN.Close();
        }

        private void dtporderby_ValueChanged(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (iddate == 1)
            {
                string sql = ViewPurchase(CN);
            }

            if (iddate == 2)
            {
                string sql = ViewOrder(CN);
            }

            if (iddate == 3)
            {               
               string sql = Gridlog(CN);               
            }

            CN.Close();
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            if (porder == 1)//go to report purchase
            {
               
            }

            if (sorder == 1)//go to report sale
            {
               
            }
        }

        private void cbhidemenu_CheckedChanged(object sender, EventArgs e)
        {
            if (cbhidemenu.Checked == true)
            { panel1.Visible = false; }
            else { panel1.Visible = true; }
        }
               
        private void timer2_Tick(object sender, EventArgs e)
        {            
            minute = minute + 1;

            if (minute == 300)
            {
                processbar();
                minute = 0; 
            }
        }

        private void bgWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //TestObject argumentTest = e.Argument as TestObject;

          
            //Thread.Sleep(10000);

            //argumentTest.OneValue = 6;
            //argumentTest.TwoValue = 3;

          
            //e.Result = argumentTest;
        }

        private void btnqreport_Click(object sender, EventArgs e)
        {           
            if (nmenu == "porder")
            {
                Frmviewreport frrp = new Frmviewreport();
                frrp.rpname = "crpPurchasequick";
                RageSTToED_datePrint(frrp);
                frrp.ShowDialog();
            }

            if (nmenu == "sorder")
            {
                Frmviewreport frrp = new Frmviewreport();
                frrp.rpname = "crpSalequick";
                RageSTToED_datePrint(frrp);
                frrp.ShowDialog();
            }
        }

        private void RageSTToED_datePrint(Frmviewreport frrp)
        {
            frrp.startdate = Convert.ToInt16(dtporderby.Value.Day.ToString());
            frrp.startmount = Convert.ToInt16(dtporderby.Value.Month.ToString());
            frrp.startyear = Convert.ToInt16(dtporderby.Value.Year.ToString());
        }

        private void dtgpurordertran_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgpurordertran[1, e.RowIndex].Value.ToString() != "-")
            {
                FrmInformation finfor = new FrmInformation();
                finfor.idtypeinfor = 1;
                finfor.xposition= Convert.ToInt16(MousePosition.X);
                finfor.yposition = Convert.ToInt16(MousePosition.Y);
                finfor.idtran = dtgpurordertran[0, e.RowIndex].Value.ToString();
                finfor.ShowDialog();
            }
        }

     
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.F10):
                    OpenFromcommand();

                    return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void OpenFromcommand()
        {
            Frmconfirmpwd fcfpwd = new Frmconfirmpwd();
            fcfpwd.ShowDialog();

            if (fcfpwd.idcheck == 1)
            { Frmcommand fcm = new Frmcommand(); fcm.ShowDialog(); }
        }
        
    }
}



























