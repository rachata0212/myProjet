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
    public partial class w : Form
    {
        public w()
        {
            InitializeComponent();
        }

        DataSet dscbbranch = new DataSet(); // combo box branch
        DataSet dscbselect = new DataSet(); //combo box selecttype search product ,transport,customer, suppliers
        DataSet dscbmenu1 = new DataSet();
        DataSet dscbmenu2 = new DataSet();
        DataSet dscbmenu3 = new DataSet();
        DataSet dscbmenu4 = new DataSet();
        DataSet dscbmenu5 = new DataSet();
        DataSet dscbmenu6 = new DataSet();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet(); //dtg grind truck in
        DataSet ds2 = new DataSet(); //dtg grind truck out
        DataSet ds3 = new DataSet();
        DataSet ds4 = new DataSet();
        DataSet ds5 = new DataSet();
        DataSet ds6 = new DataSet();
        DataSet ds7 = new DataSet();
        DataSet ds8 = new DataSet();
        DataSet ds9 = new DataSet();
        DataSet ds10 = new DataSet();

        int     idmenu = 0;                     //id menu report         
        string desum;
        string dtsum;
        string firtmenu = "";
        string secoundmenu = "";
        string idbranch = "";
        string idtypereport = "";
        int idmenuunlock = 0;
        int pwdunlock = 0;
        string selectvalue = "";               
        string idtran = "0";
        string weigthbranch = "0";          //�����Ң���  ��.�Ң�
        string weigthsuporcus = "0";        //�����Ң���  ��.�ç����������١���
        int     idRowindex = 0;
        string information = "";
        dtssaleorder dssearch = new dtssaleorder();
        double win = 0;
        double wout = 0;
        double wdf = 0;
        double wsup = 0;
        double wsupdfnet =0;
        double wcus = 0;
        double wnetdfcus = 0;
        double wselect = 0;  

        private void Checkidmenu()
        {
            idmenu =Convert.ToInt16(cbprivatemenu.SelectedValue.ToString());
        }

        private void startDreport()
        {
            string dsday = DTpkST.Value.Day.ToString();
            string dsmonth = DTpkST.Value.Month.ToString();
            string dsyear = DTpkST.Value.Year.ToString();
            dtsum = dsyear + "/" + dsmonth + "/" + dsday;
        }

        private void endEreport()
        {
            string deday = DTpkED.Value.Day.ToString();
            string demonth = DTpkED.Value.Month.ToString();
            string deyear = DTpkED.Value.Year.ToString();
            desum = deyear + "/" + demonth + "/" + deday;
        }

        private void CheckFirtmenu()
        {
            firtmenu = cbprivatemenu.SelectedIndex.ToString();
        }

        private void CheckSecoundmenu()
        {
            secoundmenu = cbmenusub2.Text.Trim();
        }

        private void CheckidBranch()
        {
        }

        private void CheckTypereport()
        {
            
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }          
        
        private void FrmreportBranch_Load(object sender, EventArgs e)
        {           
            LoadmenuRemport();
        }

        /*
        
	1	- ��§ҹ����
	2	- ��§ҹ���
	3	- ��§ҹ���� - ���
	4	- ��§ҹ������
	5	- ��§ҹ����͡
	6	- ��§ҹ����
	7	- ��§ҹ�Թ����ʵ�͡
	8	- ��§ҹ��º ����-���
	9	- ��§ҹ��º ������-����͡
	10	- ��§ҹ¡��ԡ/����¹�ŧ�ҹ
	11	- ��§ҹ�÷����ѹ
	12	- ��§ҹἹ����١���

        */
        

        private void LoadmenuRemport()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql1 = "select idreport,reportname from vmenureport where idemp='" + Program.empID + "' AND isviewer = 1 order by idreport ";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(dscbbranch, "loadmenu");
            cbprivatemenu.DataSource = dscbbranch.Tables["loadmenu"];
            cbprivatemenu.DisplayMember = "reportname";
            cbprivatemenu.ValueMember = "idreport";
            cbprivatemenu.Text = "";

            string sql2= "select idbranch,bname from vautokeychar";
            SqlDataAdapter da2 = new SqlDataAdapter(sql2, CN);
            da2.Fill(dscbbranch, "loadb");
            cbbranch.DataSource = dscbbranch.Tables["loadb"];
            cbbranch.DisplayMember = "bname";
            cbbranch.ValueMember = "idbranch";
            //cbbranch.Items.Insert(99, "�ٷء�Ң�");     
            CN.Close();
        }

        private void DisableAllgrid()
        {
            dtgtruckin.Visible = false;
            dtgtruckout.Visible = false;
            dtgpurordertran.Visible = false;
            dtgsaleordertran.Visible = false;
            dtgrpfstc.Visible = false;
            dtgpurcancle.Visible = false;
            dtgsalecancle.Visible = false;
            dtgcalclejob.Visible = false;            
            dtgstock.Visible = false;
            dtgstocksumday.Visible = false;
            dtgcalclejobTinTout.Visible = false;
        } 

        private void ChecksumDTG()
        {
            lbinformation.Visible = true;           
            lbinformation.Text="";            
          
            if (idmenu == 1)////��§ҹ����
            {
                lbinformation.Text = "   Total: " + dtgpurordertran.RowCount.ToString() + " Items";
            }

            if (idmenu == 2)////��§ҹ���
            {
                lbinformation.Text = "   Total: " + dtgsaleordertran.RowCount.ToString() + " Items";
            }

            if (idmenu == 3)////��§ҹ������ - ����
            {
                Resetweigth();

                if (dtgrpfstc.Visible == true && dtgrpfstc.RowCount != 0)
                {
                    for (int i = 0; i < dtgrpfstc.RowCount; i++)
                    {
                        win = win + Convert.ToDouble(dtgrpfstc[11, i].Value.ToString()) / 1000;
                        wout = wout + Convert.ToDouble(dtgrpfstc[12, i].Value.ToString()) / 1000;
                        wdf = wdf + Convert.ToDouble(dtgrpfstc[13, i].Value.ToString()) / 1000;

                        int x = i % 2;
                        if (x == 0)
                        { dtgrpfstc.Rows[i].DefaultCellStyle.BackColor = Color.Lavender; }
                    }

                    information = "";
                    information += "Sup-WeigthTotal: " + win.ToString("#,###.##") + " TON,";
                    information += " Cus-WeigthTotal: " + wout.ToString("#,###.##") + " TON,";
                    information += " WeigthDeferanchTotal: " + wdf.ToString("#,###.##") + " TON,";
                    information += " Total: " + dtgrpfstc.RowCount.ToString() + " Items";
                    lbinformation.Text = information;
                }
            }

            if (idmenu == 4)////��§ҹ������
            {
                Resetweigth();

                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();

                if (dtgtruckin.Visible == true && dtgtruckin.RowCount != 0)
                {
                    for (int i = 0; i < dtgtruckin.RowCount; i++)
                    {
                        win = win + Convert.ToDouble(dtgtruckin[11, i].Value.ToString()) / 1000;
                        wout = wout + Convert.ToDouble(dtgtruckin[12, i].Value.ToString()) / 1000;
                        wdf = wdf + Convert.ToDouble(dtgtruckin[13, i].Value.ToString()) / 1000;
                        wsup = wsup + Convert.ToDouble(dtgtruckin[14, i].Value.ToString()) / 1000;
                        if (dtgtruckin[13, i].Value.ToString() != "0")
                        { wsupdfnet = wsupdfnet + Convert.ToDouble(dtgtruckin[15, i].Value.ToString()) / 1000; }

                        int x = i % 2;
                        if (x == 0)
                        { dtgtruckin.Rows[i].DefaultCellStyle.BackColor = Color.Lavender; }


                        int idcounttrans = 0;
                        string sql3 = "select count(idtran)as idcounttrans  from tbphysicalproduct where idtran = '" + dtgtruckin[20, i].Value.ToString().Trim() + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        SqlDataReader DR3 = CM3.ExecuteReader();

                        DR3.Read();
                        { idcounttrans = Convert.ToInt16(DR3["idcounttrans"].ToString()); }
                        DR3.Close();

                        if (idcounttrans != 0)
                        { dtgtruckin[19, i].Value = "o"; }

                        else
                        { dtgtruckin[19, i].Value = "Add"; }
                    }
                    information = "";
                    information += "W-inTotal: " + win.ToString("#,###.##") + " TON,";
                    information += " W-outTotal: " + wout.ToString("#,###.##") + " TON,";
                    information += " W-netTotal: " + wdf.ToString("#,###.##") + " TON,";
                    information += " W-SupTotal: " + wsup.ToString("#,###.##") + " TON,";
                    information += " W-SupDefNet: " + wsupdfnet.ToString("#,###.##") + " TON,";
                    information += " Total: " + dtgtruckin.RowCount.ToString() + " Items";
                    lbinformation.Text = information;
                }
            }

            if (idmenu == 5)// ��§ҹ����͡
            {
                Resetweigth();

                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();

                if (dtgtruckout.Visible == true && dtgtruckout.RowCount != 0)
                {
                    for (int i = 0; i < dtgtruckout.RowCount; i++)
                    {
                        win = win + Convert.ToDouble(dtgtruckout[10, i].Value.ToString()) / 1000;
                        wout = wout + Convert.ToDouble(dtgtruckout[11, i].Value.ToString()) / 1000;
                        wdf = wdf + Convert.ToDouble(dtgtruckout[12, i].Value.ToString()) / 1000;
                        wcus = wcus + Convert.ToDouble(dtgtruckout[14, i].Value.ToString()) / 1000;
                        if (dtgtruckout[12, i].Value.ToString() != "0")
                        {
                            wnetdfcus = wnetdfcus + Convert.ToDouble(dtgtruckout[15, i].Value.ToString()) / 1000;
                        }
                        wselect = wselect + Convert.ToDouble(dtgtruckout[16, i].Value.ToString()) / 1000;
                        int x = i % 2;
                        if (x == 0)
                        { dtgtruckout.Rows[i].DefaultCellStyle.BackColor = Color.Lavender; }

                        int idcounttrans = 0;
                        string sql3 = "select count(idtran)as idcounttrans  from tbphysicalproduct where idtran = '" + dtgtruckout[23, i].Value.ToString().Trim() + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        SqlDataReader DR3 = CM3.ExecuteReader();

                        DR3.Read();
                        { idcounttrans = Convert.ToInt16(DR3["idcounttrans"].ToString()); }
                        DR3.Close();

                        if (idcounttrans != 0)
                        { dtgtruckout[20, i].Value = "o"; }

                        else
                        { dtgtruckout[20, i].Value = "Add"; }
                    }

                    information = "";
                    information += "W-InTotal: " + win.ToString("#,###.##") + " TON,";
                    information += " W-OutTotal: " + wout.ToString("#,###.##") + " TON,";
                    information += " W-NetTotal: " + wdf.ToString("#,###.##") + " TON,";
                    information += " W-CusTotal: " + wcus.ToString("#,###.##") + " TON,";
                    information += " W-NetDefCusTotal: " + wnetdfcus.ToString("#,###.##") + " TON,";
                    information += " W-SelectTotal: " + wselect.ToString("#,###.##") + " TON,";
                    information += " Total: " + dtgtruckout.RowCount.ToString() + " Items";                                lbinformation.Text = information;
                }
            }

            if (idmenu == 6)// ����
            {
              
            }

            if (idmenu == 7)// ��§ҹ�Թ����ʵ�͡
            {
                if (dtgstock.Visible == true)
                {
                    lbinformation.Text = "   Total: " + dtgstock.RowCount.ToString() + " Items";
                }
                if (dtgstocksumday.Visible == true)
                { lbinformation.Text = "   Total: " + dtgstocksumday.RowCount.ToString() + " Items"; }
               
            }

            if (idmenu == 8)// ��§ҹ��º ����-���
            {
            }

            if (idmenu == 9)// ��§ҹ��º ������-����͡
            {
            }

            if (idmenu == 10)// ��§ҹ¡��ԡ/����¹�ŧ�ҹ
            {
                
            }
        }    

        //
        //   New Object ************************************
              

        private void EnableAllButton()
        {
            cbmenusub1.Enabled = true;
            cbmenusub2.Enabled = true;
            cbbranch.Enabled = true;           
            cbtypereport.Enabled = true;            
            DTpkST.Enabled = true;
            DTpkED.Enabled = true;
            btnviewer.Enabled = true;
            cbmenusub1.Text = "";
        }

        private void cbprivatemenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbprivatemenu.SelectedValue.ToString() != "System.Data.DataRowView")
            { idmenu = Convert.ToInt16(cbprivatemenu.SelectedValue.ToString()); }
            if (idmenu != 0) 
            { CreateMenuReport(); }            
        }

        private void CreateMenuReport()
        {
            cbmenusub1.Items.Clear();
            DisableAllgrid();
            EnableAllButton();
            cbtypereport.Text = "";
            cbmenusub2.Text = "";

            if (idmenu != 0)
            {               
                if (idmenu == 1 || idmenu == 2 || idmenu == 3 || idmenu == 4 || idmenu == 5)     
                {  
                    //if(idmenu==3)
                    //{
                    //    cbmenusub1.Items.Add("��§ҹẺ��ػ������");
                    //    cbmenusub1.Items.Add("��§ҹẺ��ػ�����");
                    //}
                    cbmenusub1.Items.Add("�٢����ŷ�����");
                    cbmenusub1.Items.Add("�¡����Թ���");
                    cbmenusub1.Items.Add("�¡�������");
                    cbmenusub1.Items.Add("�¡����¹ö");

                    if (idmenu == 1 || idmenu == 4)//����-������
                    {
                        cbmenusub1.Items.Add("�¡�������˹���");
                        cbmenusub1.Items.Add("�¡���������");

                        if (idmenu == 1)//����������Ң�������͡
                        { cbbranch.Enabled = false; }
                    }

                    if (idmenu == 2 || idmenu == 5) //���-����͡
                    {
                        cbmenusub1.Items.Add("�¡����١���");

                        if (idmenu == 5)
                        { cbmenusub1.Items.Add("�¡�������˹���"); }

                        if (idmenu == 2)//���������Ң�������͡
                        { cbbranch.Enabled = false; }
                    }

                    if (idmenu == 3) //����-����͡
                    {                       
                        cbmenusub1.Items.Add("�¡����١���");
                        cbmenusub1.Items.Add("�¡���������");
                        cbmenusub1.Items.Add("�¡�������˹���");
                        cbtypereport.Text = "" ;
                    }
                }

                if (idmenu == 6) //��§ҹ����
                {
                    cbmenusub1.Items.Add("��������");
                    cbmenusub1.Items.Add("�÷����ѹ");
                    cbmenusub1.Items.Add("Ἱ����١���");
                    cbmenusub1.Items.Add("����ѷ����");

                    cbmenusub1.Text = "";
                    cbmenusub1.Enabled = false;
                    cbmenusub2.Enabled = false;
                    cbbranch.Enabled = false;
                    cbtypereport.Enabled = false;
                }

                if (idmenu == 7) //��§ҹ�Թ����ʵ�͡
                {
                    //DTpkST.Enabled = false;
                    //DTpkED.Enabled = false;
                    cbmenusub1.Items.Add("���Թ��ҷ�����");                   
                    cbmenusub1.Items.Add("�¡����Թ���");
                }

                if (idmenu == 8) //��§ҹ��º ����-���
                {
                    cbmenusub1.Text = "";
                    cbmenusub1.Enabled = false;
                    cbmenusub2.Enabled = false;
                }

                if (idmenu == 9) //��§ҹ��º ������-����͡
                {
                    cbmenusub1.Text = "";
                    cbmenusub1.Enabled = false;
                    cbmenusub2.Enabled = false;
                }

                if (idmenu == 10) //��§ҹ¡��ԡ/����¹�ŧ�ҹ
                {
                    cbmenusub1.Items.Add("��¡��¡��ԡ");
                    cbmenusub1.Items.Add("��¡������¹�ŧ�ҹ");
                    cbbranch.Enabled = false;
                    cbtypereport.Enabled = false;
                }

                if (idmenu == 11) //��§ҹ�÷����ѹ
                {
                    cbmenusub1.Enabled = false;
                    cbmenusub2.Enabled = false;
                    cbbranch.Enabled = false;
                    cbtypereport.Enabled = false;
                }

                if (idmenu == 12) //��§ҹἹ����١���
                {
                    cbmenusub1.Enabled = false;
                    cbmenusub2.Enabled = false;
                    DTpkST.Enabled = false;
                    DTpkED.Enabled = false;
                    cbbranch.Enabled = false;
                    cbtypereport.Enabled = false;
                    btnviewer.Enabled = false;                    
                    btnstatusjob.Enabled = false;
                    Loadmaps();
                }

                if (idmenu == 13) //��§ҹ��Ե
                {
                  
                }


                if (idmenu == 14) //��§ҹ����٧
                {
                    Frmreportadvance frpad = new Frmreportadvance();
                    frpad.ShowDialog();
                }

                if (idmenu == 15) //�Ө����ç�������Т���
                {
                    FrmPurchasePay frpad = new FrmPurchasePay();
                    frpad.ShowDialog();
                }
            }
        }

        private void Loadmaps()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            ds.Clear(); dssearch.Clear();

            dtgviewfile.DataSource = dssearch;
            string sql = "select * from vmapcompany";
            SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
            da1.Fill(ds, "maps");
            dtgviewfile.DataSource = ds.Tables["maps"];
            dtgviewfile.Visible = true; dtgviewfile.Dock = DockStyle.Fill;
            lbinformation.Text = dtgviewfile.RowCount.ToString();
            CN.Close();
        }

        private void cbmenusub1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAllDatagrid();            
            ChecksumDTG();           
        }       

        private void LoadAllDatagrid()
        {
            DisableAllgrid(); 
            dscbselect.Clear(); 
            dscbmenu2.Clear();
            cbmenusub2.DataSource = null;
            cbmenusub2.Items.Clear();
            ds1.Clear();  
            CheckFirtmenu();
            idbranch = "";
            CheckSecoundmenu();

            startDreport();  //check date report
            endEreport();      //check date report
            //SqlConnection.ClearAllPool 
            SqlConnection.ClearAllPools();
            SqlConnection CN = new SqlConnection();            
            CN.ConnectionString = Program.urldb;
            CN.Open(); 
            
            string sql1 = "";
            string idname = "";
            string name = "";            

            //cbtypereport.Text = "";
            //cbtypereport.Enabled = false;


            if (idmenu == 1)////��§ҹ����
            {               
                if (cbmenusub1.SelectedIndex == 0)//�ٷ�����
                {                   
                    ds1.Clear();
                   // sql1 = "select * from vWPurRP where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "')";
                    sql1 = "select * from vpurchase where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "')";
                    //
                    SqlDataAdapter da = new SqlDataAdapter(sql1, CN);
                    da.Fill(ds1, "purchase");
                    dtgpurordertran.DataSource = ds1.Tables["purchase"];
                    cbmenusub2.Enabled = false;
                    dtgpurordertran.Visible = true; dtgpurordertran.Dock = DockStyle.Fill;
                    lbinformation.Visible = true;

                    cbtypereport.Enabled = true;
                    cbtypereport.Items.Clear();
                    cbtypereport.Items.Add("��Ẻ�����");
                    cbtypereport.Items.Add("�١�ҿ����ѹ");
                    cbtypereport.Items.Add("�١�ҿ�ѻ����");
                    cbtypereport.Items.Add("�١�ҿ�����͹");
                    cbtypereport.Items.Add("���ҧ㺺ѹ�֡��ë����Թ���");
                    cbtypereport.Items.Add("�٫���Ẻᨡᨧ����");
                    cbtypereport.Items.Add("����ػ�����/���˹ѡ");
                    cbtypereport.Items.Add("�٤س�Ҿ�ͧ�Թ���");
                    cbtypereport.Text = "��Ẻ�����";
                   
                    cbmenusub2.Enabled = false; cbbranch.Text = ""; 
                    
                }
                if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                {
                    sql1 = "select DISTINCT idpro,proname from vpurchase where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') AND proname is not null";
                    idname = "idpro";
                    name = "proname";
                }

                if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                {
                    sql1 = "select DISTINCT idcomtran,comtran from vpurchase where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') AND comtran is not null";
                    idname = "idcomtran";
                    name = "comtran";
                }

                if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡�������¹
                {
                    sql1 = "select DISTINCT serailcar from vpurchase where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') AND serailcar is not null";
                    idname = "serailcar";
                    name = "serailcar";
                }

                if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡�������˹���
                {

                    sql1 = "select DISTINCT idcomsup,comsup from vpurchase where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') AND comsup is not null";
                    idname = "idcomsup";
                    name = "comsup";
                }

                if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡���������
                {
                    sql1 = "select DISTINCT idcompur,compur from vpurchase where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') AND comsup is not null";
                    idname = "idcompur";
                    name = "compur";
                }

                if (cbmenusub1.SelectedIndex != 0 && sql1 != "")
                {
                  
                    cbmenusub2.Enabled = true;
                    SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                    da1.Fill(dscbmenu2, "purchase");
                    cbmenusub2.DataSource = dscbmenu2.Tables["purchase"];
                    cbmenusub2.DisplayMember = name;
                    cbmenusub2.ValueMember = idname;
                    cbtypereport.Enabled = false;
                }                              

                ColorStatusCheckPurchase();
            }

            if (idmenu == 2)////��§ҹ���
            {
                if (cbmenusub1.SelectedIndex == 0)//�ٷ�����
                {
                    ds2.Clear();
                    // sql1 = "select * from vWSaleRP where (orderdate BETWEEN '" + dtsum + "' AND '" + desum + "')";
                    sql1 = "select * from vsaleorder where (orderdate BETWEEN '" + dtsum + "' AND '" + desum + "')";                    
                    SqlDataAdapter da = new SqlDataAdapter(sql1, CN);
                    da.Fill(ds2, "alltruckout");
                    dtgsaleordertran.DataSource = ds2.Tables["alltruckout"];
                    cbmenusub2.Enabled = false;
                    dtgsaleordertran.Visible = true; dtgsaleordertran.Dock = DockStyle.Fill;
                    lbinformation.Visible = true;

                    cbtypereport.Enabled = true;
                    cbtypereport.Items.Clear();
                    cbtypereport.Items.Add("����§ҹẺ�����");
                    cbtypereport.Items.Add("����§ҹ��ҿ����ѹ");
                    cbtypereport.Items.Add("����§ҹ��ҿ�ѻ����");
                    cbtypereport.Items.Add("����§ҹ��ҿ�����͹");
                    cbtypereport.Items.Add("�٤س�Ҿ�ͧ�Թ���");
                    cbtypereport.Text = "����§ҹẺ�����";
                    
                    cbmenusub2.Enabled = false; cbbranch.Text = "";
                }

                if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                {
                    sql1 = "select DISTINCT idpro,proname from vsaleorder where (orderdate BETWEEN '" + dtsum + "' AND '" + desum + "') AND proname is not null";
                    idname = "idpro";
                    name = "proname";
                }

                if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                {
                    sql1 = "select DISTINCT idcomtran,comtran from vsaleorder where (orderdate BETWEEN '" + dtsum + "' AND '" + desum + "') AND comtran is not null";
                    idname = "idcomtran";
                    name = "comtran";
                }

                if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡����¹
                {
                    sql1 = "select DISTINCT serailcar from vsaleorder where (orderdate BETWEEN '" + dtsum + "' AND '" + desum + "') AND serailcar is not null";
                    name = "serailcar";
                }
                if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡����١���
                {
                    sql1 = "select DISTINCT idcomcus,comcus from vsaleorder where (orderdate BETWEEN '" + dtsum + "' AND '" + desum + "') AND comcus is not null";
                    idname = "idcomcus";
                    name = "comcus";
                }

                if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡��������
                {
                    sql1 = "select DISTINCT idcomsale,comsale from vsaleorder where (orderdate BETWEEN '" + dtsum + "' AND '" + desum + "') AND comsale is not null";
                    idname = "idcomsale";
                    name = "comsale";
                }

                if (cbmenusub1.SelectedIndex != 0)
                {
                    cbmenusub2.Enabled = true;
                    SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                    da1.Fill(dscbmenu2, "truckoutselect");
                    cbmenusub2.DataSource = dscbmenu2.Tables["truckoutselect"];
                    cbmenusub2.DisplayMember = name;
                    cbmenusub2.ValueMember = idname;
                    cbtypereport.Text = "����§ҹẺ�����";
                    cbtypereport.Enabled = false;

                }

                ColorStatusCheckSale();
                CheckAddressCus();
            }

            if (idmenu == 3)////��§ҹ������ - ����
            {
                if (firtmenu == "0" || firtmenu == "1" || firtmenu == "2")//�ٷ�����
                {
                    cbbranch.Text = "��Ẻ����ҹ�Ң�";
                    idbranch = ""; cbbranch.SelectedIndex = 0;                    
                    cbtypereport.Enabled = true;
                    cbtypereport.Items.Clear();
                    cbtypereport.Text = "����§ҹẺ�����";
                    cbtypereport.Items.Add("����§ҹẺ�����");

                    cbmenusub2.DataSource = null;
                    dscbmenu2.Tables.Clear();
                    cbmenusub2.Items.Insert(0, "�٨ҡ�ѹ�����觫���");//1   
                    cbmenusub2.Items.Insert(1, "�٨ҡ�ѹ���ŧ�Թ���");//3    
                    cbmenusub2.Text = "�٨ҡ�ѹ�����觫���";
                }

                if (cbmenusub1.SelectedIndex == 0)//�ٷ�����
                {
                    string sql2 = "SELECT * FROM vWFsTCrp WHERE (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') order by datepur desc";
                    ds2.Clear();
                    SqlDataAdapter da = new SqlDataAdapter(sql2, CN);
                    da.Fill(ds2, "fstc");
                    dtgrpfstc.DataSource = ds2.Tables["fstc"];
                    dtgrpfstc.Visible = true; dtgrpfstc.Dock = DockStyle.Fill;                  
                }

                if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                {
                    sql1 = "select DISTINCT proname from vWFsTCrp where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') AND proname is not null";

                    name = "proname";
                }

                if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                {
                    sql1 = "select DISTINCT comtran from vWFsTCrp where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') AND comtran is not null";

                    name = "comtran";
                }
                if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡����¹
                {
                    sql1 = "select DISTINCT serailcar from vWFsTCrp where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') AND serailcar is not null";
                    name = "serailcar";
                }

                if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡����١���
                {
                    sql1 = "select DISTINCT comcus from vWFsTCrp where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') AND comcus is not null";

                    name = "comcus";
                }

                if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡������
                {
                    sql1 = "select DISTINCT comsale from vWFsTCrp where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') AND comsale is not null";

                    name = "comsale";
                }

                if (cbmenusub1.SelectedIndex == 6)//����§ҹ�¡�������� ����˹���
                {
                    sql1 = "select DISTINCT comsup from vWFsTCrp where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') AND comsup is not null";
                    name = "comsup";
                }

                if (sql1 !="" )//�ٷ�����
                {  
                    cbmenusub2.Enabled = true;
                    SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                    da1.Fill(dscbmenu2, "fstc");
                    cbmenusub2.DataSource = dscbmenu2.Tables["fstc"];
                    cbmenusub2.DisplayMember = name;
                    cbmenusub2.Text = "�ٷء�������ҹ";
                }
            }

            if (idmenu == 4)////��§ҹ������
            {
                if (cbmenusub1.SelectedIndex == 0)//�ٷ�����
                {
                    ds1.Clear();
                    string sql2 = "select * from vWTrckinRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')";
                    SqlDataAdapter da = new SqlDataAdapter(sql2, CN);
                    da.Fill(ds1, "alltruckin");
                    dtgtruckin.DataSource = ds1.Tables["alltruckin"];
                    dtgtruckin.Visible = true; dtgtruckin.Dock = DockStyle.Fill;
                    lbinformation.Visible = true;

                    cbmenusub2.Items.Insert(0, "�٨ҡ�ѹ�����觫���");//3
                    cbmenusub2.Items.Insert(1, "�٨ҡ�ѹ���ŧ�Թ���");//3
                    cbmenusub2.Text = "�٨ҡ�ѹ�����觫���"; idbranch = "";

                }
                if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                {
                    sql1 = "select DISTINCT idsuppro,proname from vWTrckinRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "') AND proname is not null";
                    idname = "idsuppro";
                    name = "proname";
                }

                if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                {
                    sql1 = "select DISTINCT idcomtran,comtran from vWTrckinRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "') AND comtran is not null";
                    idname = "idcomtran";
                    name = "comtran";
                }

                if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡�������¹
                {
                    sql1 = "select DISTINCT serailcar from vWTrckinRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "') AND serailcar is not null";

                    name = "serailcar";
                }

                if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡�������˹���
                {
                    sql1 = "select DISTINCT idcomsup,comsup from vWTrckinRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "') AND comsup is not null";
                    idname = "idcomsup";
                    name = "comsup";
                }

                if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡���������
                {
                    sql1 = "select DISTINCT idcompur,compur from vWTrckinRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "') AND compur is not null";
                    idname = "idcompur";
                    name = "compur";
                }

                if (sql1 != "")
                {
                    cbmenusub2.Enabled = true;
                    SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                    da1.Fill(dscbmenu2, "truckin");
                    cbmenusub2.DataSource = dscbmenu2.Tables["truckin"];
                    cbmenusub2.DisplayMember = name;
                    cbmenusub2.ValueMember = idname;
                    cbbranch.Text = "�ٷء�Ң�";
                    idbranch = "";

                }

                cbtypereport.Enabled = true;
                cbtypereport.Items.Clear();
                cbtypereport.Items.Add("����§ҹẺ�����");
                cbtypereport.Items.Add("����§ҹ��ҿ����ѹ");
                cbtypereport.Items.Add("����§ҹ��ҿ�ѻ����");
                cbtypereport.Items.Add("����§ҹ��ҿ�����͹");                

                if (cbmenusub1.SelectedIndex == 0)
                { cbtypereport.Items.Add("���ҧ㺺ѹ�֡��ë����Թ���"); cbtypereport.Items.Add("�٤س�Ҿ�ͧ�Թ���");}

                cbtypereport.Text = "����§ҹẺ�����";
                dtgtruckin.Visible = true;
            }

            if (idmenu == 5)// ��§ҹ����͡
            {
                if (cbmenusub1.SelectedIndex == 0)//�ٷ�����
                {
                    ds1.Clear();
                    sql1 = "select * from vWTrckoutRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')";
                    SqlDataAdapter da = new SqlDataAdapter(sql1, CN);
                    da.Fill(ds1, "alltruckout");
                    dtgtruckout.DataSource = ds1.Tables["alltruckout"];
                    //cbmenusub2.Enabled = false;
                    dtgtruckout.Visible = true; dtgtruckout.Dock = DockStyle.Fill;
                    lbinformation.Visible = true;

                    idbranch = ""; 
                    cbtypereport.Enabled = true;
                    cbtypereport.Items.Clear();
                    cbtypereport.Items.Add("����§ҹẺ�����");
                    cbtypereport.Items.Add("����§ҹ��ҿ����ѹ");
                    cbtypereport.Items.Add("����§ҹ��ҿ�ѻ����");
                    cbtypereport.Items.Add("����§ҹ��ҿ�����͹");
                    cbtypereport.Items.Add("�٤س�Ҿ�ͧ�Թ���");
                    cbtypereport.Text = "����§ҹẺ�����";                   

                    cbmenusub2.DataSource = null;
                    dscbmenu2.Tables.Clear();
                    cbmenusub2.Items.Insert(0, "�٨ҡ�ѹ����Ѻ Order");//1
                    cbmenusub2.Items.Insert(1, "�٨ҡ�ѹ��������");//2
                    cbmenusub2.Items.Insert(2, "�٨ҡ�ѹ���ŧ�Թ���");//3                    
                    cbmenusub2.Text = "�٨ҡ�ѹ����Ѻ Order";
                    cbmenusub2.Enabled = true;
                }

                if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                {
                    sql1 = "select DISTINCT idsuppro,proname from vWTrckoutRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "') AND proname is not null";
                    idname = "idsuppro";
                    name = "proname";
                }

                if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                {
                    sql1 = "select DISTINCT idcomtran,comtran from vWTrckoutRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "') AND comtran is not null";
                    idname = "idcomtran";
                    name = "comtran";
                }

                if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡����¹
                {
                    sql1 = "select DISTINCT serailcar from vWTrckoutRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "') AND serailcar is not null";
                    name = "serailcar";
                }
                if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡����١���
                {
                    sql1 = "select DISTINCT idcomcus,comcus from vWTrckoutRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "') AND comcus is not null";
                    idname = "idcomcus";
                    name = "comcus";
                }

                if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡��������
                {
                    sql1 = "select DISTINCT idcomsale,comsale from vWTrckoutRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "') AND comsale is not null";
                    idname = "idcomsale";
                    name = "comsale";
                }

                if (cbmenusub1.SelectedIndex != 0 && sql1 !="")
                {
                    cbmenusub2.Enabled = true;
                    //cbmenusub2.DataSource = dscbmenu2;
                    SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                    da1.Fill(dscbmenu2, "truckoutselect");
                    cbmenusub2.DataSource = dscbmenu2.Tables["truckoutselect"];
                    cbmenusub2.DisplayMember = name;
                    cbmenusub2.ValueMember = idname;
                    idbranch = "";
                }              
            }

            if (idmenu == 6)// ����
            {
                //if (cbmenusub1.SelectedIndex == 0)//�ٷ�����
                //{
                //    ds2.Clear();
                //    sql1 = "select * from vWTrckoutRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')";
                //    SqlDataAdapter da = new SqlDataAdapter(sql1, CN);
                //    da.Fill(ds2, "alltruckout");
                //    dtgtruckout.DataSource = ds2.Tables["alltruckout"];
                //    cbmenusub2.Enabled = false;
                //    dtgtruckout.Visible = true; dtgtruckout.Dock = DockStyle.Fill;
                //}

                //if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                //{
                //    sql1 = "select DISTINCT idsuppro,proname from vWTrckoutRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "') AND idbranch=" + cbbranch.SelectedValue.ToString() + " AND proname is not null";
                //    idname = "idsuppro";
                //    name = "proname";
                //}

                //if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡����¹
                //{
                //    sql1 = "select DISTINCT serailcar from vWTrckoutRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "') AND idbranch=" + cbbranch.SelectedValue.ToString() + " AND serailcar is not null";
                //    name = "serailcar";
                //}                              

                //if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡�������˹���
                //{
                //    sql1 = "select DISTINCT idcomsup,comsup from vWTrckinRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "') AND comsup is not null";
                //    idname = "idcomsup";
                //    name = "comsup";
                //}

                //if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡����١���
                //{
                //    sql1 = "select DISTINCT idcomcus,comcus from vWTrckoutRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "') AND idbranch=" + cbbranch.SelectedValue.ToString() + " AND comcus is not null";
                //    idname = "idcomcus";
                //    name = "comcus";
                //}

                //if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                //{
                //    sql1 = "select DISTINCT idcomtran,comtran from vWTrckoutRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "') AND idbranch=" + cbbranch.SelectedValue.ToString() + " AND comtran is not null";
                //    idname = "idcomtran";
                //    name = "comtran";
                //}  

                //if (cbmenusub1.SelectedIndex != 0)
                //{
                //    cbmenusub2.Enabled = true;
                //    SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                //    da1.Fill(dscbmenu2, "truckoutselect");
                //    cbmenusub2.DataSource = dscbmenu2.Tables["truckoutselect"];
                //    cbmenusub2.DisplayMember = name;
                //    cbmenusub2.ValueMember = idname;
                //}
            }

            if (idmenu == 7)// ��§ҹ�Թ����ʵ�͡
            {
                if (cbmenusub1.SelectedIndex == 0)
                {
                    cbmenusub2.Items.Add("���Թ��Ҥ���ѧ�Ѩ�غѹ");
                    cbmenusub2.Items.Add("���Թ��Ҥ���ѧ��͹��ѧ");
                    cbmenusub2.Items.Add("�١�õѴʵ�͡������-�͡");
                    cbtypereport.Enabled = false;
                }                

                if (cbmenusub1.SelectedIndex == 1)
                {
                    sql1 = "select DISTINCT proname from vproductstock";
                    cbmenusub2.Enabled = true;
                    SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                    da1.Fill(dscbmenu2, "ddd");
                    cbmenusub2.DataSource = dscbmenu2.Tables["ddd"];
                    cbmenusub2.DisplayMember = "proname";
                    cbmenusub2.ValueMember = "proname";
                }              
            }

            if (idmenu == 8)// ��§ҹ��º ����-���
            {
            }

            if (idmenu == 9)// ��§ҹ��º ������-����͡
            {
            }

            if (idmenu == 10)// ��§ҹ¡��ԡ/����¹�ŧ�ҹ
            {
                cbmenusub2.Enabled = true;
                cbmenusub2.DataSource = null;
                cbmenusub2.Items.Clear();

                if (cbmenusub1.SelectedIndex == 0)
                {
                    cbmenusub2.Items.Insert(0, "¡��ԡ Order �����Թ���");//1
                    cbmenusub2.Items.Insert(1, "¡��ԡ Order ����Թ���");//2
                    cbmenusub2.Items.Insert(2, "¡��ԡ Order ���� -> ���");//3
                    cbmenusub2.Items.Insert(3, "¡��ԡ ������");//4
                    cbmenusub2.Items.Insert(4, "¡��ԡ ����͡");//5
                    cbmenusub2.Items.Insert(5, "��� Order �����Թ���");//16
                    cbmenusub2.Items.Insert(6, "��� Order ����Թ���");//17
                    cbmenusub2.Items.Insert(7, "��� Order ���� -> ���");//18
                    cbmenusub2.Items.Insert(8, "���ҧ Order �������");//19                  
                }
                if (cbmenusub1.SelectedIndex == 1)
                {
                    cbmenusub2.Items.Insert(0, "����¹�ŧ�١���");//6
                    cbmenusub2.Items.Insert(1, "����¹�ŧ�Թ���");//7
                    cbmenusub2.Items.Insert(2, "����¹�ŧ����ѷ����");//8
                    cbmenusub2.Items.Insert(3, "����¹�ŧ��Դ/������ö");//9
                    cbmenusub2.Items.Insert(4, "����¹�ŧ����¹ö");//10
                    cbmenusub2.Items.Insert(5, "����¹�ŧ�ҢҨѴ��");//11
                    cbmenusub2.Items.Insert(6, "����¹�ŧ [���� - ��ѧ] -> [���� - ���]");//12
                    cbmenusub2.Items.Insert(7, "����¹�ŧ [���� - ���] -> [���� - ��ѧ]");//13
                    cbmenusub2.Items.Insert(8, "����¹�ŧ [��ѧ1 - ���] -> [��ѧ1 - ��ѧ1]");//14
                    cbmenusub2.Items.Insert(9, "����¹�ŧ [��ѧ1 - ���] -> [��ѧ1 - ��ѧ2]");//15   
                }

                if (cbmenusub1.SelectedIndex == 2)
                {
                    cbmenusub2.Items.Insert(0, "�͹��˹ѡ�١���");
                }
            }

            CN.Close();
        }

        private void cbmenusub2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dscbselect.Clear();
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql1 = "";
            
            startDreport();  //check date report
            endEreport();      //check date report

             DisableAllgrid();
            selectvalue = cbmenusub2.Text;

            if (idmenu == 1)//��§ҹ����
            {                
                if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                {
                    sql1 = "select * from vpurchase where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "')  AND  proname = '" + selectvalue + "'order by datepur";
                }

                if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                {
                    sql1 = "select * from vpurchase where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "')  AND comtran= '" + selectvalue + "'order by datepur";
                }

                if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡�������¹
                {
                    sql1 = "select * from vpurchase where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "')  AND serailcar = '" + selectvalue + "' order by datepur";
                }

                if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡�������˹���
                {
                    sql1 = "select * from vpurchase where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "')  AND comsup = '" + selectvalue + "' order by datepur";
                }

                if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡���������
                {
                    sql1 = "select * from vpurchase where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "')  AND compur = '" + selectvalue + "'order by datepur";
                }

                if (sql1 != "")
                {
                    ds1.Clear();  
                    SqlDataAdapter da = new SqlDataAdapter(sql1, CN);
                    da.Fill(ds1, "purchase");
                    dtgpurordertran.DataSource = ds1.Tables["purchase"];
                    dtgpurordertran.Visible = true; dtgpurordertran.Dock = DockStyle.Fill;                
                }

                ColorStatusCheckPurchase();
            }

            if (idmenu == 2)//��§ҹ���
            {
                if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                {
                    sql1 = "select * from vsaleorder where (orderdate BETWEEN '" + dtsum + "' AND '" + desum + "')  AND proname = '" + selectvalue + "' order by orderdate";
                }

                if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                {
                    sql1 = "select * from vsaleorder where (orderdate BETWEEN '" + dtsum + "' AND '" + desum + "')  AND comtran= '" + selectvalue + "' order by orderdate";
                }

                if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡�������¹
                {
                    sql1 = "select * from vsaleorder where (orderdate BETWEEN '" + dtsum + "' AND '" + desum + "')  AND serailcar = '" + selectvalue + "' order by orderdate";
                }

                if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡����١���
                {
                    sql1 = "select * from vsaleorder where (orderdate BETWEEN '" + dtsum + "' AND '" + desum + "')  AND comcus = '" + selectvalue + "' order by orderdate";
                }

                if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡��������
                {
                    sql1 = "select * from vsaleorder where (orderdate BETWEEN '" + dtsum + "' AND '" + desum + "')  AND comsale = '" + selectvalue + "' order by orderdate";
                }

                if (cbmenusub1.SelectedIndex != 0)
                {
                    ds2.Clear();
                    SqlDataAdapter da = new SqlDataAdapter(sql1, CN);
                    da.Fill(ds2, "sale");
                    dtgsaleordertran.DataSource = ds2.Tables["sale"];
                    dtgsaleordertran.Visible = true; dtgsaleordertran.Dock = DockStyle.Fill;
                }

                CheckAddressCus();
                ColorStatusCheckSale();
            }

            if (idmenu == 3)//��§ҹ���� - ���
            {

                //  string sql2 = "SELECT * FROM vWFsTCrp WHERE (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') order by datepur desc";
                try
                {
                    if (cbmenusub1.SelectedIndex == 0)
                    {
                        if (cbmenusub2.SelectedIndex == 0)
                        {
                            sql1 = "SELECT * FROM vWFsTCrp WHERE (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') AND idbranch is null order by datepur";
                            cbbranch.SelectedIndex = 0;
                            cbbranch.Text = "��Ẻ����ҹ�Ң�";
                            idbranch = ""; 
                        }

                        if (cbmenusub2.SelectedIndex == 1)
                        {
                            sql1 = "SELECT * FROM vWFsTCrp WHERE (dateWcus BETWEEN '" + dtsum + "' AND '" + desum + "') AND idbranch is null order by dateWcus";
                            cbbranch.SelectedIndex = 0;
                            cbbranch.Text = "��Ẻ����ҹ�Ң�";
                            idbranch = ""; 
                        }
                    }

                    if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                    {
                        sql1 = "select * from vWFsTCrp where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "')  AND proname = '" + selectvalue + "' order by datepur desc";
                    }

                    if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                    {
                        sql1 = "select * from vWFsTCrp where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "')  AND comtran= '" + selectvalue + "' order by datepur desc";
                    }

                    if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡�������¹
                    {
                        sql1 = "select * from vWFsTCrp where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "')  AND serailcar = '" + selectvalue + "' order by datepur desc";
                    }

                    if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡����١���
                    {
                        sql1 = "select * from vWFsTCrp where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "')  AND comcus = '" + selectvalue + "' order by datepur desc";
                    }

                    if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡������
                    {
                        sql1 = "select * from vWFsTCrp where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "')  AND comsale = '" + selectvalue + "' order by datepur desc";
                    }


                    if (cbmenusub1.SelectedIndex == 6)//����§ҹ�¡�������˹���
                    {
                        sql1 = "select * from vWFsTCrp where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "')  AND comsup = '" + selectvalue + "' order by datepur desc";
                    }

                    if (cbmenusub1.SelectedIndex != 0 || cbmenusub1.SelectedIndex != 1 || cbmenusub2.SelectedIndex != 2)
                    {
                        ds2.Clear();
                        SqlDataAdapter da = new SqlDataAdapter(sql1, CN);
                        da.Fill(ds2, "fstc");
                        dtgrpfstc.DataSource = ds2.Tables["fstc"];
                        dtgrpfstc.Visible = true; dtgrpfstc.Dock = DockStyle.Fill; cbtypereport.Enabled = false;
                    }
                }
                catch { }
            }

            if (idmenu == 4)//��§ҹ������
            {
                if (cbmenusub1.SelectedIndex == 0)//����§ҹ������
                {
                    if (cbmenusub2.SelectedIndex == 0 || cbmenusub2.SelectedIndex == -1)
                    {
                        sql1 = "select * from vWTrckinRP where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "')order by datepur ";
                    }
                    if (cbmenusub2.SelectedIndex == 1)
                    {
                        sql1 = "select * from vWTrckinRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')order by datepur ";
                    }
                }
                                               
                    if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                    {
                        sql1 = "select * from vWTrckinRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')  AND  proname = '" + cbmenusub2.Text.Trim() + "'order by dateWbf";
                    }

                    if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                    {
                        sql1 = "select * from vWTrckinRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')  AND comtran= '" + cbmenusub2.Text.Trim() + "'order by dateWbf";
                    }

                    if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡�������¹
                    {
                        sql1 = "select * from vWTrckinRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')  AND serailcar = '" + cbmenusub2.Text.Trim() + "'order by dateWbf";
                    }

                    if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡�������˹���
                    {
                        sql1 = "select * from vWTrckinRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')  AND comsup = '" + cbmenusub2.Text.Trim() + "'order by dateWbf";
                    }

                    if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡���������
                    {
                        sql1 = "select * from vWTrckinRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')  AND compur = '" + cbmenusub2.Text.Trim() + "'order by dateWbf";
                    }

                    if (sql1 != "")
                    {
                        ds1.Clear();                        
                        SqlDataAdapter da = new SqlDataAdapter(sql1, CN);
                        da.Fill(ds1, "alltruckin");
                        dtgtruckin.DataSource = ds1.Tables["alltruckin"];
                        dtgtruckin.Visible = true; dtgtruckin.Dock = DockStyle.Fill;
                        cbbranch.Text = "�ٷء�Ң�";
                        idbranch = "";
                    }
                }            

            if (idmenu == 5)//��§ҹ����͡
            {
                if (cbmenusub1.SelectedIndex == 0)//��Ẻ������
                {
                    string sql2 = ""; ds2.Clear();
                    if (cbmenusub2.SelectedIndex == 0)//��Ẻ�ѹ����Ѻ order
                    {
                        sql2 = "select * from vWTrckoutRP where (orderdate BETWEEN '" + dtsum + "' AND '" + desum + "') order by orderdate";
                    }

                    if (cbmenusub2.SelectedIndex == 1) //��Ẻ�ѹ����鹵Ҫ��
                    { sql2 = "select * from vWTrckoutRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "') order by dateWbf,timeWbf"; }

                    if (cbmenusub2.SelectedIndex == 2)//��Ẻ�ѹ���ŧ�Թ����١���
                    { sql2 = "select * from vWTrckoutRP where (dateWcus BETWEEN '" + dtsum + "' AND '" + desum + "') order by dateWcus"; }

                    if (sql2 != "")
                    {
                        SqlDataAdapter da = new SqlDataAdapter(sql2, CN);
                        da.Fill(ds2, "alltruckout");
                        dtgtruckout.DataSource = ds2.Tables["alltruckout"];
                        dtgtruckout.Visible = true; dtgtruckout.Dock = DockStyle.Fill;
                        cbbranch.Text = "�ٷء�Ң�";
                        idbranch = "";
                    }
                }

                if (cbmenusub1.SelectedIndex != 0)//����Ẻ������
                {
                    if (cbmenusub1.SelectedIndex == 1)//����§ҹ����Թ���
                    {
                        sql1 = "select * from vWTrckoutRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')  AND proname = '" + selectvalue + "'order by dateWbf";
                    }

                    if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                    {
                        sql1 = "select * from vWTrckoutRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')  AND comtran= '" + selectvalue + "'order by dateWbf";
                    }

                    if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡�������¹
                    {
                        sql1 = "select * from vWTrckoutRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')  AND serailcar = '" + selectvalue + "'order by dateWbf";
                    }

                    if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡����١���
                    {
                        sql1 = "select * from vWTrckoutRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')  AND comcus = '" + selectvalue + "'order by dateWbf";
                    }

                    if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡������
                    {
                        sql1 = "select * from vWTrckoutRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')  AND comsale = '" + selectvalue + "'order by dateWbf";
                    }

                    if (cbmenusub1.SelectedIndex != 0)
                    {
                        ds2.Clear();
                        SqlDataAdapter da = new SqlDataAdapter(sql1, CN);
                        da.Fill(ds2, "alltruckout");
                        dtgtruckout.DataSource = ds2.Tables["alltruckout"];
                        dtgtruckout.Visible = true; dtgtruckout.Dock = DockStyle.Fill;
                        idbranch = "";
                        cbbranch.Text = "�ٷء�Ң�";
                    }
                } 
            }
            if (idmenu == 6)//��§ҹ����
            {



            }

         //   selectvalue = cbmenusub2.Text;
            if (idmenu == 7)//��§ҹ�Թ����ʵ�͡
            {
                if (cbmenusub1.SelectedIndex == 1)//��੾���Թ���
                {
                    dscbmenu4.Clear();
                    sql1 = "select * from vproductstock where proname ='" + selectvalue + "'order by bname,proname,namesup";
                    dtgstock.DataSource = dscbmenu4;
                    SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                    da1.Fill(dscbmenu4, "vproname");
                    dtgstock.DataSource = dscbmenu4.Tables["vproname"];
                    dtgstock.Visible = true; dtgstock.Dock = DockStyle.Fill;
                }

                if (cbmenusub1.SelectedIndex == 0)//�ٷ��������Ẻ�����͹�
                {
                    if (cbmenusub2.SelectedIndex == 0)
                    {
                        DTpkST.Enabled = false; DTpkED.Enabled = false;
                    }
                    if (cbmenusub2.SelectedIndex == 1)
                    {
                        DTpkST.Enabled = true; DTpkED.Enabled = false;                      
                    }

                    if (cbmenusub2.SelectedIndex == 0 || cbmenusub2.SelectedIndex == 1)
                    {
                        string hisdate="";
                        if (cbmenusub2.SelectedIndex == 0)
                        {
                            string dsday = Convert.ToString(DateTime.Now.Day - 1);
                            string dsmonth = DateTime.Now.Month.ToString();
                            string dsyear = DateTime.Now.Year.ToString();
                            hisdate = dsyear + "/" + dsmonth + "/" + dsday;
                        }
                        else
                        {
                            startDreport(); hisdate = dtsum;
                        }                      

                        ds2.Clear(); startDreport();
                        dtgstock.DataSource = ds2;
                        sql1 = "select * from vproductstock where stockdate='" + hisdate + "'";                       
                        SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                        da1.Fill(ds2, "vstock");
                        dtgstock.DataSource = ds2.Tables["vstock"];
                        dtgstock.Visible = true; dtgstock.Dock = DockStyle.Fill;                        
                        cbbranch.Text = "�ٷ�����";
                    }

                    if (cbmenusub2.SelectedIndex == 2)//�١�õѴʵ�͡��Ш��ѹ�٨ҡ�������Ŵ�ҡ ��������Ъ���͡
                    {
                        ds2.Clear(); startDreport(); endEreport();
                        dtgstocksumday.DataSource = ds2;
                        //sql1 = "select * from vhistockday where datehis='" + dtsum + "' ";
                        sql1 = "select * from vhistockday where (datehis BETWEEN '" + dtsum + "' AND '" + desum + "') ";                      
                        SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                        da1.Fill(ds2, "vstockday");
                        dtgstocksumday.DataSource = ds2.Tables["vstockday"];
                        dtgstocksumday.Visible = true; dtgstocksumday.Dock = DockStyle.Fill;
                        dtgstocksumday.Enabled = true;
                        DTpkST.Enabled = true; DTpkED.Enabled = true;
                        cbbranch.Text = "�ٷ�����";
                    } 
                }
            }

            if (idmenu == 8)// ��§ҹ��º ����-���
            {
               
            }

            if (idmenu == 9)//��§ҹ��º ������-����͡
            {



            }

            if (idmenu == 10)//��§ҹ¡��ԡ/����¹�ŧ�ҹ
            {
                if (cbmenusub1.SelectedIndex ==0 )
                {
                    if (cbmenusub2.SelectedIndex == 0)//¡��ԡ Order �����Թ���  1
                    {
                        sql1 = "select * from vcanclepurchase where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') AND idstatus = 7 order by datepur";
                        ds3.Clear();
                        SqlDataAdapter da3 = new SqlDataAdapter(sql1, CN);
                        da3.Fill(ds3, "purcancle");
                        dtgpurcancle.DataSource = ds3.Tables["purcancle"];
                        dtgpurcancle.Visible = true; dtgpurcancle.Dock = DockStyle.Fill;
                    }

                    if (cbmenusub2.SelectedIndex == 1)//¡��ԡ Order ����Թ���  2
                    {
                        sql1 = "select * from vcanclesaleorder where (orderdate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idstatus =7 order by orderdate";
                        ds4.Clear();
                        SqlDataAdapter da4 = new SqlDataAdapter(sql1, CN);
                        da4.Fill(ds4, "salecancle");
                        dtgsalecancle.DataSource = ds4.Tables["salecancle"];
                        dtgsalecancle.Visible = true; dtgsalecancle.Dock = DockStyle.Fill;
                    }

                    if (cbmenusub2.SelectedIndex == 2)//¡��ԡ Order ���� -> ���  3
                    {
                        sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 3 order by cancledate";
                    }

                    if (cbmenusub2.SelectedIndex == 3)//¡��ԡ ������  4
                    {
                        sql1 = "select * from vcanclejobTinTout where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 4 order by cancledate";
                        ds2.Clear();
                        SqlDataAdapter da = new SqlDataAdapter(sql1, CN);
                        da.Fill(ds2, "clejobTinTout");
                        dtgcalclejobTinTout.DataSource = ds2.Tables["clejobTinTout"];
                        dtgcalclejobTinTout.Visible = true; dtgcalclejobTinTout.Dock = DockStyle.Fill;
                    }

                    if (cbmenusub2.SelectedIndex == 4)//¡��ԡ ����͡  5
                    {
                        sql1 = "select * from vcanclejobTinTout where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 2 order by cancledate";
                        ds2.Clear();
                        SqlDataAdapter da = new SqlDataAdapter(sql1, CN);
                        da.Fill(ds2, "clejobTinTout");
                        dtgcalclejobTinTout.DataSource = ds2.Tables["clejobTinTout"];
                        dtgcalclejobTinTout.Visible = true; dtgcalclejobTinTout.Dock = DockStyle.Fill;
                    }

                    if (cbmenusub2.SelectedIndex == 5)//��� Order �����Թ��� 16
                    {
                        sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 16 order by cancledate";                        
                    }

                    if (cbmenusub2.SelectedIndex == 6)//��� Order ����Թ���  17
                    {
                        sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 17 order by cancledate";
                    }

                    if (cbmenusub2.SelectedIndex == 7)//��� Order ���� -> ���  18
                    {
                        sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 18 order by cancledate";
                    }

                    if (cbmenusub2.SelectedIndex == 8)//���ҧ Order �������  19
                    {
                        sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 19 order by cancledate";
                    }

                    if (cbmenusub2.SelectedIndex != 0 && cbmenusub2.SelectedIndex != 1 && cbmenusub2.SelectedIndex != 3 && cbmenusub2.SelectedIndex != 4)
                    {                        
                        ds2.Clear();
                        SqlDataAdapter da = new SqlDataAdapter(sql1, CN);
                        da.Fill(ds2, "canclejob");
                        dtgcalclejob.DataSource = ds2.Tables["canclejob"];
                        dtgcalclejob.Visible = true; dtgcalclejob.Dock = DockStyle.Fill;
                    }

                }

                if (cbmenusub1.SelectedIndex == 1)
               {
                   if (cbmenusub2.SelectedIndex == 0)//����¹�ŧ�١���  //6
                   {
                       sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 6 order by cancledate";
                   }

                   if (cbmenusub2.SelectedIndex == 1)//����¹�ŧ�Թ���   //7
                   {
                       sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 7 order by cancledate";
                   }

                   if (cbmenusub2.SelectedIndex == 2)//����¹�ŧ����ѷ���� //8
                   {
                       sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 8 order by cancledate";
                   }

                   if (cbmenusub2.SelectedIndex == 3)//����¹�ŧ��Դ/������ö");//9
                   {
                       sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 9 order by cancledate";
                   }

                   if (cbmenusub2.SelectedIndex == 4)//����¹�ŧ����¹ö");//10
                   {
                       sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 10 order by cancledate";
                   }

                   if (cbmenusub2.SelectedIndex == 5)//����¹�ŧ�ҢҨѴ��");//11
                   {
                       sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 11 order by cancledate";
                   }

                   if (cbmenusub2.SelectedIndex == 6)//����¹�ŧ Order [���� - ��ѧ] -> [���� - ���]");//12
                   {
                       sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND  idtypecancle = 12 order by cancledate";
                   }

                   if (cbmenusub2.SelectedIndex == 7)//����¹�ŧ Order [���� - ���] -> [���� - ��ѧ]");//13
                   {
                       sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 13 order by cancledate";
                   }

                   if (cbmenusub2.SelectedIndex == 8)//����¹�ŧ Order [��ѧ1 - ���] -> [��ѧ1 - ��ѧ1]");//14
                   {
                       sql1 = "select * from vcanclejob where(cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 14 order by cancledate";
                   }

                    if (cbmenusub2.SelectedIndex == 9)//����¹�ŧ Order [��ѧ1 - ���] -> [��ѧ1 - ��ѧ2]");//15
                   {
                       sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 15 order by cancledate";
                   }

                   if (sql1 != "")
                   {
                       ds2.Clear();
                       SqlDataAdapter da = new SqlDataAdapter(sql1, CN);
                       da.Fill(ds2, "canclejob");
                       dtgcalclejob.DataSource = ds2.Tables["canclejob"];
                       dtgcalclejob.Visible = true; dtgcalclejob.Dock = DockStyle.Fill;
                   }                    
                }

                if (firtmenu == "2")//�͹��˹ѡ�١���
                {                   

                }
            }

            CN.Close();
            lbinformation.Visible = true;
            ChecksumDTG();
        }   

        private void cbbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ds1.Clear(); ds2.Clear();
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); string sql1 = ""; 
            startDreport();  //check date report
            endEreport();      //check date report
            cbtypereport.Text = "";
            idbranch = cbbranch.SelectedValue.ToString();
            //������ҡѺ��� ������Ң�������͡           
            

            if (idmenu == 3)//��§ҹ���� - ���
            {
                if (cbmenusub1.SelectedIndex == 0 || cbmenusub1.SelectedIndex == -1)//�ٷ�����
                {
                    ds2.Clear();
                    if (cbmenusub2.SelectedIndex == 0)
                    {
                        sql1 = "SELECT * FROM vWFsTCrp WHERE (datepur BETWEEN '" + dtsum + "' AND '" + desum + "')  AND idbranch = " + cbbranch.SelectedValue.ToString() + " order by datepur";
                    }

                    if (cbmenusub2.SelectedIndex == 1)
                    {
                        sql1 = "SELECT * FROM vWFsTCrp WHERE (dateWcus BETWEEN '" + dtsum + "' AND '" + desum + "') AND idbranch = " + cbbranch.SelectedValue.ToString() + " order by dateWcus";
                    }                  
                }

                if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                {
                    sql1 = "select * from vWFsTCrp where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') AND idbranch= " + cbbranch.SelectedValue.ToString() + "";
                }

                if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                {
                    sql1 = "select * from vWFsTCrp where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') AND idbranch= " + cbbranch.SelectedValue.ToString() + "";
                }

                if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡����¹
                {
                    sql1 = "select * from vWFsTCrp where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') AND idbranch= " + cbbranch.SelectedValue.ToString() + "";
                }

                if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡����١���
                {
                    sql1 = "select * from vWFsTCrp where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "')AND idbranch= " + cbbranch.SelectedValue.ToString() + "";
                }

                if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡������
                {
                    sql1 = "select * from vWFsTCrp where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "')AND idbranch= " + cbbranch.SelectedValue.ToString() + "";
                }

                if (cbmenusub1.SelectedIndex == 6)//����§ҹ�¡�������� ����˹���
                {
                    sql1 = "select * from vWFsTCrp where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "')AND idbranch= " + cbbranch.SelectedValue.ToString() + "";
                }

                if (sql1 != "")
                {
                    SqlDataAdapter da = new SqlDataAdapter(sql1, CN);
                    da.Fill(ds2, "alltruckout");
                    dtgrpfstc.DataSource = ds2.Tables["alltruckout"];
                    dtgrpfstc.Visible = true; dtgrpfstc.Dock = DockStyle.Fill;
                }
            }

            if (idmenu == 4)//��§ҹ������
            {
                if (cbmenusub1.SelectedIndex == 0)//����§ҹ����������ѹ���
                {
                    sql1 = "select * from vWTrckinRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')  AND  idbranch=" + cbbranch.SelectedValue.ToString() + " ";
                }

                if (cbmenusub1.SelectedIndex == 1 && selectvalue != "")//����§ҹ�¡����Թ���
                {
                    sql1 = "select * from vWTrckinRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')  AND   proname = '" + selectvalue + "' AND idbranch= " + cbbranch.SelectedValue.ToString() + "";
                }

                if (cbmenusub1.SelectedIndex == 2 && selectvalue != "")//����§ҹ�¡�������
                {
                    sql1 = "select * from vWTrckinRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')  AND   comtran= '" + selectvalue + "' AND idbranch= " + cbbranch.SelectedValue.ToString() + "";
                }

                if (cbmenusub1.SelectedIndex == 3 && selectvalue != "")//����§ҹ�¡�������¹
                {
                    sql1 = "select * from vWTrckinRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')  AND   serailcar = '" + selectvalue + "' AND idbranch= " + cbbranch.SelectedValue.ToString() + "";
                }

                if (cbmenusub1.SelectedIndex == 4 && selectvalue != "")//����§ҹ�¡�������˹���
                {
                    sql1 = "select * from vWTrckinRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')  AND comsup = '" + selectvalue + "' AND idbranch= " + cbbranch.SelectedValue.ToString() + "";
                }

                if (cbmenusub1.SelectedIndex == 5 && selectvalue != "")//����§ҹ�¡���������
                {
                    sql1 = "select * from vWTrckinRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')  AND   compur = '" + selectvalue + "' AND idbranch= " + cbbranch.SelectedValue.ToString() + "";
                }

                if (sql1 != "")
                {
                    ds1.Clear();
                    SqlDataAdapter da = new SqlDataAdapter(sql1, CN);
                    da.Fill(ds1, "viewtruckin");
                    dtgtruckin.DataSource = ds1.Tables["viewtruckin"];
                    dtgtruckin.Visible = true; dtgtruckin.Dock = DockStyle.Fill; cbtypereport.Text = "����§ҹẺ�����";
                }
            }

            if (idmenu == 5)//��§ҹ����͡
            {
                if (cbmenusub1.SelectedIndex == 0)//����§ҹ����������ѹ���
                {
                    if (cbmenusub2.SelectedIndex == 0)//��Ẻ�ѹ����Ѻ order
                    {
                        sql1 = "select * from vWTrckoutRP where (orderdate  BETWEEN '" + dtsum + "' AND '" + desum + "')  AND  idbranch=" + cbbranch.SelectedValue.ToString() + " order by orderdate";  
                    }

                    if (cbmenusub2.SelectedIndex == 1)//��Ẻ�ѹ����鹵Ҫ��
                    {
                        sql1 = "select * from vWTrckoutRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')  AND  idbranch=" + cbbranch.SelectedValue.ToString() + " order by dateWbf,timeWbf";  
                    }

                    if (cbmenusub2.SelectedIndex == 2)//��Ẻ�ѹ���ŧ�Թ����١���
                    {
                        sql1 = "select * from vWTrckoutRP where (dateWcus BETWEEN '" + dtsum + "' AND '" + desum + "')  AND  idbranch=" + cbbranch.SelectedValue.ToString() + " order by dateWcus";  
                    }                                   
                }

                if (cbmenusub1.SelectedIndex == 1 && selectvalue != "")//����§ҹ�¡����Թ���
                {
                        sql1 = "select * from vWTrckoutRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')  AND   proname = '" + selectvalue + "' AND idbranch= " + cbbranch.SelectedValue.ToString() + " order by orderdate";                  
                }

                if (cbmenusub1.SelectedIndex == 2 && selectvalue != "")//����§ҹ�¡�������
                {
                        sql1 = "select * from vWTrckoutRP where (orderdate BETWEEN '" + dtsum + "' AND '" + desum + "')  AND   comtran= '" + selectvalue + "' AND idbranch= " + cbbranch.SelectedValue.ToString() + " order by orderdate";
                                      
                }

                if (cbmenusub1.SelectedIndex == 3 && selectvalue != "")//����§ҹ�¡�������¹
                {
                        sql1 = "select * from vWTrckoutRP where (orderdate BETWEEN '" + dtsum + "' AND '" + desum + "')  AND   serailcar = '" + selectvalue + "' AND idbranch= " + cbbranch.SelectedValue.ToString() + " order by orderdate";
                                         
                }

                if (cbmenusub1.SelectedIndex == 4 && selectvalue != "")//����§ҹ�¡����١���
                {
                        sql1 = "select * from vWTrckoutRP where (orderdate BETWEEN '" + dtsum + "' AND '" + desum + "')  AND   comcus = '" + selectvalue + "' AND idbranch= " + cbbranch.SelectedValue.ToString() + " order by orderdate";
                      
                }

                if (cbmenusub1.SelectedIndex == 5 && selectvalue != "")//����§ҹ�¡��������
                {
                    sql1 = "select * from vWTrckoutRP where (orderdate BETWEEN '" + dtsum + "' AND '" + desum + "')  AND   comsale = '" + selectvalue + "' AND idbranch= " + cbbranch.SelectedValue.ToString() + " order by orderdate";
                }

                if (sql1 != "")
                {
                    ds2.Clear();
                    SqlDataAdapter da = new SqlDataAdapter(sql1, CN);
                    da.Fill(ds2, "alltruckout");
                    dtgtruckout.DataSource = ds2.Tables["alltruckout"];
                    dtgtruckout.Visible = true; dtgtruckout.Dock = DockStyle.Fill; cbtypereport.Text = "����§ҹẺ�����";
                }
            }
            if (idmenu == 6)//��§ҹ����
            {



            }

            if (idmenu == 7)//��§ҹ�Թ����ʵ�͡
            {
                dscbmenu4.Clear();
                if (cbmenusub1.SelectedIndex == 0)//�ٷ�����
                {
                    if (cbmenusub2.SelectedIndex == 0)//�٤���ѧ�Ѩ�غѹ����Ң�
                    {
                        sql1 = "select * from vproductstock where idbranch ='" + cbbranch.SelectedValue.ToString() + "'";
                    }
                    if (cbmenusub2.SelectedIndex == 1)//�٤���ѧ��͹��ѧ����ѹ��� ����Ң�
                    {
                        sql1 = "select * from vproductstock where stockdate='" + dtsum + "'AND idbranch ='" + cbbranch.SelectedValue.ToString() + "'";
                    }

                    if (cbmenusub2.SelectedIndex == 2)//�٤�������͹���Ǣͧ�ʹ�Թ��ҵ���ѹ���
                    {                     
                        ds2.Clear();
                        startDreport(); endEreport();
                        string sql2 = "select * from vhistockday where (datehis BETWEEN '" + dtsum + "' AND '" + desum + "') AND idbranch ='" + cbbranch.SelectedValue.ToString() + "'";
                        dtgstocksumday.DataSource = ds2;
                        SqlDataAdapter da1 = new SqlDataAdapter(sql2, CN);
                        da1.Fill(ds2, "vstockday");
                        dtgstocksumday.DataSource = ds2.Tables["vstockday"];  
                    }
                }                         

                if (cbmenusub1.SelectedIndex == 1)
                {
                    sql1 = "select * from vproductstock where proname ='" + cbmenusub2.Text.Trim() + "'AND idbranch ='" + cbbranch.SelectedValue.ToString() + "'";
                }

                if (cbmenusub2.SelectedIndex != 2)
                {
                    dtgstock.DataSource = dscbmenu4;
                    SqlDataAdapter da2 = new SqlDataAdapter(sql1, CN);
                    da2.Fill(dscbmenu4, "proname");
                    dtgstock.DataSource = dscbmenu4.Tables["proname"];
                    dtgstock.Visible = true; dtgstock.Dock = DockStyle.Fill;
                }
            }

            if (idmenu == 8)//��§ҹ������ - ����
            {



            }

            if (idmenu == 9)//��§ҹ��º ������-����͡
            {



            }

            if (idmenu == 10)//��§ҹ¡��ԡ/����¹�ŧ�ҹ
            {
                if (firtmenu == "0")
                {
                    if (cbmenusub2.SelectedIndex == 2)//¡��ԡ Order ���� -> ���  3
                    {
                        sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 3 AND idbranch=" + cbbranch.SelectedValue.ToString() + "";
                    }

                    if (cbmenusub2.SelectedIndex == 3)//¡��ԡ ������  4
                    {
                        sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 4 AND idbranch=" + cbbranch.SelectedValue.ToString() + "";
                    }

                    if (cbmenusub2.SelectedIndex == 4)//¡��ԡ ����͡  5
                    {
                        sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 5 AND idbranch=" + cbbranch.SelectedValue.ToString() + "";
                    }

                    if (cbmenusub2.SelectedIndex == 5)//��� Order �����Թ��� 16
                    {
                        sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 16 AND idbranch=" + cbbranch.SelectedValue.ToString() + "";
                    }

                    if (cbmenusub2.SelectedIndex == 6)//��� Order ����Թ���  17
                    {
                        sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 17 AND idbranch=" + cbbranch.SelectedValue.ToString() + "";
                    }

                    if (cbmenusub2.SelectedIndex == 7)//��� Order ���� -> ���  18
                    {
                        sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 18 AND idbranch=" + cbbranch.SelectedValue.ToString() + "";
                    }

                    if (cbmenusub2.SelectedIndex == 8)//���ҧ Order �������  19
                    {
                        sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 19 AND idbranch=" + cbbranch.SelectedValue.ToString() + "";
                    }

                    if (cbmenusub2.SelectedIndex != 0 && cbmenusub2.SelectedIndex != 1)
                    {
                        ds2.Clear();
                        SqlDataAdapter da = new SqlDataAdapter(sql1, CN);
                        da.Fill(ds2, "canclejob");
                        dtgcalclejob.DataSource = ds2.Tables["canclejob"];
                        dtgcalclejob.Visible = true; dtgcalclejob.Dock = DockStyle.Fill;
                    }
                }

                if (firtmenu == "1")
                {
                    if (cbmenusub2.SelectedIndex == 0)//����¹�ŧ�١���  //6
                    {
                        sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 6 AND idbranch=" + cbbranch.SelectedValue.ToString() + "";
                    }

                    if (cbmenusub2.SelectedIndex == 1)//����¹�ŧ�Թ���   //7
                    {
                        sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 7 AND idbranch=" + cbbranch.SelectedValue.ToString() + "";
                    }

                    if (cbmenusub2.SelectedIndex == 2)//����¹�ŧ����ѷ���� //8
                    {
                        sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 8 AND idbranch=" + cbbranch.SelectedValue.ToString() + "";
                    }

                    if (cbmenusub2.SelectedIndex == 3)//����¹�ŧ��Դ/������ö");//9
                    {
                        sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 9 AND idbranch=" + cbbranch.SelectedValue.ToString() + "";
                    }

                    if (cbmenusub2.SelectedIndex == 4)//����¹�ŧ����¹ö");//10
                    {
                        sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 10 AND idbranch=" + cbbranch.SelectedValue.ToString() + "";
                    }

                    if (cbmenusub2.SelectedIndex == 5)//����¹�ŧ�ҢҨѴ��");//11
                    {
                        sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 11";
                    }

                    if (cbmenusub2.SelectedIndex == 6)//����¹�ŧ Order [���� - ��ѧ] -> [���� - ���]");//12
                    {
                        sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND  idtypecancle = 12 AND idbranch=" + cbbranch.SelectedValue.ToString() + "";
                    }

                    if (cbmenusub2.SelectedIndex == 7)//����¹�ŧ Order [���� - ���] -> [���� - ��ѧ]");//13
                    {
                        sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 13 AND idbranch=" + cbbranch.SelectedValue.ToString() + "";
                    }

                    if (cbmenusub2.SelectedIndex == 8)//����¹�ŧ Order [��ѧ1 - ���] -> [��ѧ1 - ��ѧ1]");//14
                    {
                        sql1 = "select * from vcanclejob where(cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 14 AND idbranch=" + cbbranch.SelectedValue.ToString() + "";
                    }

                    if (cbmenusub2.SelectedIndex == 9)//����¹�ŧ Order [��ѧ1 - ���] -> [��ѧ1 - ��ѧ2]");//15
                    {
                        sql1 = "select * from vcanclejob where (cancledate BETWEEN '" + dtsum + "' AND '" + desum + "') AND idtypecancle = 15 AND idbranch=" + cbbranch.SelectedValue.ToString() + "";
                    }

                    if (sql1 != "")
                    {
                        ds2.Clear();
                        SqlDataAdapter da = new SqlDataAdapter(sql1, CN);
                        da.Fill(ds2, "canclejob");
                        dtgcalclejob.DataSource = ds2.Tables["canclejob"];
                        dtgcalclejob.Visible = true; dtgcalclejob.Dock = DockStyle.Fill;
                    }
                }               
            }

            CN.Close();
            ChecksumDTG();
        }

        private void dtgtruckin_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            {
                weigthbranch = dtgtruckin[12, e.RowIndex].Value.ToString();
                weigthsuporcus = dtgtruckin[15, e.RowIndex].Value.ToString();
                idRowindex = e.RowIndex;
                idtran = dtgtruckin[20, e.RowIndex].Value.ToString().Trim();
            }

            if (e.ColumnIndex == 19)
            {
                idmenuunlock = 23;
                CheckUnlockpwd();

                if (dtgtruckin[19, e.RowIndex].Value.ToString() == "Add")//insert
                {
                    if (pwdunlock == 1)
                    {
                        Frmphysicalproduct fspo = new Frmphysicalproduct();
                        fspo.idtran = dtgtruckin[20, e.RowIndex].Value.ToString();
                        fspo.idorder = 1;
                        fspo.idstatus = 1;
                        fspo.ShowDialog();
                        LoadAllDatagrid();
                    }
                }

               else if (e.RowIndex == 19 || dtgtruckin[19, e.RowIndex].Value.ToString() == "o")//view
                {
                    Frmphysicalproduct fspo = new Frmphysicalproduct();
                    fspo.idtran = dtgtruckin[20, e.RowIndex].Value.ToString();
                    fspo.idorder = 1;
                    fspo.idstatus = 3;
                    fspo.ShowDialog();
                }
            }
        }

        private void dtgtruckout_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {    
            if (e.RowIndex < 0) return;
            {
                weigthbranch = dtgtruckout[12, e.RowIndex].Value.ToString();
                weigthsuporcus = dtgtruckout[14, e.RowIndex].Value.ToString();
                idRowindex = e.RowIndex;
                idtran = dtgtruckout[23, e.RowIndex].Value.ToString().Trim(); ;
            }            

            if (e.ColumnIndex == 20)
            {
                idmenuunlock = 23;
                CheckUnlockpwd();

                if (dtgtruckout[20, e.RowIndex].Value.ToString() == "Add")//insert
                {
                    if (pwdunlock == 1)
                    {
                        Frmphysicalproduct fspo = new Frmphysicalproduct();
                        fspo.idtran = dtgtruckout[23, e.RowIndex].Value.ToString();
                        fspo.idorder = 2;
                        fspo.idstatus = 1;
                        fspo.ShowDialog();
                        LoadAllDatagrid();
                    }
                }

                else if (e.RowIndex == 20 || dtgtruckout[20, e.RowIndex].Value.ToString() == "o")//view
                {
                    Frmphysicalproduct fspo = new Frmphysicalproduct();
                    fspo.idtran = dtgtruckout[23, e.RowIndex].Value.ToString();
                    fspo.idorder = 2;
                    fspo.idstatus = 3;
                    fspo.ShowDialog();
                }
            }
        }

        private void RageSTToED_datePrint(Frmviewreport frrp)
        {
            frrp.startdate = Convert.ToInt16(DTpkST.Value.Day.ToString());
            frrp.startmount = Convert.ToInt16(DTpkST.Value.Month.ToString());
            frrp.startyear = Convert.ToInt16(DTpkST.Value.Year.ToString());
            frrp.enddate = Convert.ToInt16(DTpkED.Value.Day.ToString());
            frrp.endmount = Convert.ToInt16(DTpkED.Value.Month.ToString());
            frrp.endyear = Convert.ToInt16(DTpkED.Value.Year.ToString());
        }

        private void btnviewer_Click(object sender, EventArgs e)
        {
            Frmviewreport frrp = new Frmviewreport();

            if (idmenu == 1)
            {
                if (cbmenusub1.SelectedIndex == 0 || cbmenusub1.SelectedIndex == -1)//�ٷ�����
                {
                    if (cbtypereport.SelectedIndex == 0)
                    {
                        frrp.rpname = "crpPurchaseAll";
                        frrp.cationname = "����§ҹ���ͷ�����";
                    }
                    if (cbtypereport.SelectedIndex == 1)
                    {
                        frrp.rpname = "crpPurchaseDayGraph";
                        frrp.cationname = cbtypereport.Text;
                    }

                    if (cbtypereport.SelectedIndex == 2)
                    {
                        frrp.rpname = "crpPurchaseWeekGraph";
                        frrp.cationname = cbtypereport.Text;
                    }

                    if (cbtypereport.SelectedIndex == 3)
                    {
                        frrp.rpname = "crpPurchaseMontGraph";
                        frrp.cationname = cbtypereport.Text;
                    }

                    if (cbtypereport.SelectedIndex == 4)
                    {
                        frrp.rpname = "crpPurchaseAllDesign";
                        frrp.cationname = cbtypereport.Text;
                    }
                    if (cbtypereport.SelectedIndex == 5)
                    {
                        frrp.rpname = "crppurordertranbysup";
                        //frrp.cationname = cbtypereport.Text;
                    }

                    if (cbtypereport.SelectedIndex == 6)
                    {
                        frrp.rpname = "crppursumweigth";
                        //frrp.cationname = cbtypereport.Text;
                    }

                    if (cbtypereport.SelectedIndex == 7)
                    {
                        frrp.rpname = "Crpphysicalpur";                        
                    }
                }

                else
                {

                    if (cbmenusub1.SelectedIndex == 1)//���͡੾�е���Թ���
                    {
                        frrp.rpname = "crpPurchaseFiltter";
                        frrp.filterby = cbmenusub2.Text.Trim();
                        frrp.cationname = cbmenusub1.Text;
                        frrp.valuename = "proname";
                    }

                    if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                    {
                        frrp.rpname = "crpPurchaseFiltter";
                        frrp.filterby = cbmenusub2.Text.Trim();
                        frrp.cationname = cbmenusub1.Text;
                        frrp.valuename = "comtran";
                    }

                    if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡�������¹
                    {
                        frrp.rpname = "crpPurchaseFiltter";
                        frrp.filterby = cbmenusub2.Text.Trim();
                        frrp.cationname = cbmenusub1.Text;
                        frrp.valuename = "serailcar";
                    }


                    if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡�������˹���
                    {
                        frrp.rpname = "crpPurchaseFiltter";
                        frrp.filterby = cbmenusub2.Text.Trim();
                        frrp.cationname = cbmenusub1.Text;
                        frrp.valuename = "comsup";
                    }

                    if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡���������
                    {
                        frrp.rpname = "crpPurchaseFiltter";
                        frrp.filterby = cbmenusub2.Text.Trim();
                        frrp.cationname = cbmenusub1.Text;
                        frrp.valuename = "compur";
                    }
                }

                //RageSTToED_datePrint(frrp);
                //frrp.ShowDialog();
            }

            if (idmenu == 2)////��§ҹ���
            {
                if (cbmenusub1.SelectedIndex == 0 || cbmenusub1.SelectedIndex == -1)//�ٷ�����
                {
                    if (cbtypereport.SelectedIndex == 0)
                    {
                        frrp.rpname = "crpSaleAll";
                        frrp.cationname = "����§ҹ��·�����";
                    }
                    if (cbtypereport.SelectedIndex == 1)
                    {
                        frrp.rpname = "crpSaleDayGraph";
                        frrp.cationname = cbtypereport.Text;
                    }
                    if (cbtypereport.SelectedIndex == 2)
                    {
                        frrp.rpname = "crpSaleWeekGraph";
                        frrp.cationname = cbtypereport.Text;
                    }
                    if (cbtypereport.SelectedIndex == 3)
                    {
                        frrp.rpname = "crpSaleMontGraph";
                        frrp.cationname = cbtypereport.Text;
                    }
                    if (cbtypereport.SelectedIndex == 4)
                    {
                        frrp.rpname = "Crpphysicalsale";
                    }
                }

                if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                {
                    frrp.rpname = "crpSaleFiltter";
                    frrp.filterby = cbmenusub2.Text.Trim();
                    frrp.cationname = cbmenusub1.Text;
                    frrp.valuename = "proname";
                }

                if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                {
                    frrp.rpname = "crpSaleFiltter";
                    frrp.filterby = cbmenusub2.Text.Trim();
                    frrp.cationname = cbmenusub1.Text;
                    frrp.valuename = "comtran";
                }

                if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡����¹
                {
                    frrp.rpname = "crpSaleFiltter";
                    frrp.filterby = cbmenusub2.Text.Trim();
                    frrp.cationname = cbmenusub1.Text;
                    frrp.valuename = "serailcar";
                }
                if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡����١���
                {
                    frrp.rpname = "crpSaleFiltter";
                    frrp.filterby = cbmenusub2.Text.Trim();
                    frrp.cationname = cbmenusub1.Text;
                    frrp.valuename = "comcus";
                }

                if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡��������
                {
                    frrp.rpname = "crpSaleFiltter";
                    frrp.filterby = cbmenusub2.Text.Trim();
                    frrp.cationname = cbmenusub1.Text;
                    frrp.valuename = "comsale";
                }
            }

            if (idmenu == 3)////��§ҹ������ - ����
            {
                if (cbmenusub1.SelectedIndex == 0 || cbmenusub1.SelectedIndex == -1)
                {
                    if (cbmenusub2.SelectedIndex == 0 || cbmenusub2.SelectedIndex == -1)//;y
                    {
                        if (cbbranch.SelectedIndex == 0 || cbbranch.SelectedIndex == -1)
                        {
                            frrp.rpname = "crpPurtoSaleFilbyOrderdateTrucknopass";
                            frrp.cationname = " " + cbmenusub1.Text.Trim() + "(" + cbmenusub2.Text.Trim() + ")";
                        }
                        else
                        {
                            frrp.rpname = "crpPurtoSaleFilbyOrderdateTruckpass";
                            frrp.filterby = cbbranch.SelectedValue.ToString();
                            frrp.cationname = " " + cbmenusub1.Text.Trim() + "(" + cbmenusub2.Text.Trim() + ")";
                        }
                    }

                    if (cbmenusub2.SelectedIndex == 1)
                    {
                        if (cbbranch.SelectedIndex == 0 || cbbranch.SelectedIndex == -1)
                        {
                            frrp.rpname = "crpPurtoSaleFilbySenddatenopass";
                            frrp.cationname = " " + cbmenusub1.Text.Trim() + "(" + cbmenusub2.Text.Trim() + ")";
                        }
                        else
                        {
                            frrp.rpname = "crpPurtoSaleFilbySenddatepass";
                            frrp.filterby = cbbranch.SelectedValue.ToString();
                            frrp.cationname = " " + cbmenusub1.Text.Trim() + "(" + cbmenusub2.Text.Trim() + ")";
                        }
                    }
                }

                if (cbmenusub1.SelectedIndex == 1)//�¡����Թ���
                {
                    frrp.rpname = "crpPurtoSaleFilby";
                    frrp.cationname = cbmenusub2.Text.Trim();
                    frrp.filterby = cbmenusub2.Text.Trim();
                    frrp.valuename = "proname";
                }

                if (cbmenusub1.SelectedIndex == 2)//����
                {
                    frrp.rpname = "crpPurtoSaleFilby";
                    frrp.cationname = cbmenusub2.Text.Trim();
                    frrp.filterby = cbmenusub2.Text.Trim();
                    frrp.valuename = "comtran";
                }

                if (cbmenusub1.SelectedIndex == 3)//����¹ö
                {
                    frrp.rpname = "crpPurtoSaleFilby";
                    frrp.cationname = cbmenusub2.Text.Trim();
                    frrp.filterby = cbmenusub2.Text.Trim();
                    frrp.valuename = "serailcar";
                }
                if (cbmenusub1.SelectedIndex == 4)//�١���
                {
                    frrp.rpname = "crpPurtoSaleFilby";
                    frrp.cationname = cbmenusub2.Text.Trim();
                    frrp.filterby = cbmenusub2.Text.Trim();
                    frrp.valuename = "comcus";
                }


                if (cbmenusub1.SelectedIndex == 5)//������
                {
                    frrp.rpname = "crpPurtoSaleFilby";
                    frrp.cationname = cbmenusub2.Text.Trim();
                    frrp.filterby = cbmenusub2.Text.Trim();
                    frrp.valuename = "comsale";
                }

                if (cbmenusub1.SelectedIndex == 6)//����˹���
                {
                    frrp.rpname = "crpPurtoSaleFilby";
                    frrp.cationname = cbmenusub2.Text.Trim();
                    frrp.filterby = cbmenusub2.Text.Trim();
                    frrp.valuename = "comsup";
                }
            }

            if (idmenu == 4)////��§ҹ������
            {
                if (cbmenusub1.SelectedIndex == 0 || cbmenusub1.SelectedIndex == -1)//All
                {
                    if (idbranch == "")//all branch
                    {
                        if (cbmenusub2.SelectedIndex == 0 || cbmenusub2.SelectedIndex == -1)//����ѹ������
                        {
                            if (cbtypereport.SelectedIndex == 0 || cbtypereport.SelectedIndex == -1)
                            {
                                frrp.rpname = "crpTruckinAllBranchBydatepur";
                                frrp.cationname = "����§ҹ�����ҷ������ѹ�����觫���";
                            }
                            if (cbtypereport.SelectedIndex == 1)
                            {
                                frrp.rpname = "crpTruckinDayGraphbydatepur";
                                frrp.cationname = cbtypereport.Text + cbmenusub2.Text;
                            }
                            if (cbtypereport.SelectedIndex == 2)
                            {
                                frrp.rpname = "crpTruckinWeekGraphbydatepur";
                                frrp.cationname = cbtypereport.Text + cbmenusub2.Text;
                            }
                            if (cbtypereport.SelectedIndex == 3)
                            {
                                frrp.rpname = "crpTruckinMontGraphbydatepur";
                                frrp.cationname = cbtypereport.Text + cbmenusub2.Text;
                            }

                            if (cbtypereport.SelectedIndex == 4)
                            {
                                if (cbmenusub2.SelectedIndex == 0 || cbmenusub2.SelectedIndex == -1)
                                {
                                    frrp.rpname = "crpPurchaseAllDesignSuccessbydatepur";
                                    frrp.cationname = cbtypereport.Text + cbmenusub2.Text;
                                }
                                if (cbmenusub2.SelectedIndex == 1)
                                {
                                    frrp.rpname = "crpPurchaseAllDesignSuccessbydateresive";
                                    frrp.cationname = cbtypereport.Text + cbmenusub2.Text;
                                }
                            }
                        }


                        if (cbmenusub2.SelectedIndex == 1)//����ѹ���ŧ
                        {
                            if (cbtypereport.SelectedIndex == 0 || cbtypereport.SelectedIndex == -1)
                            {
                                frrp.rpname = "crpTruckinAllBranchBydatewbf";
                                frrp.cationname = "����§ҹ�����ҷ���������ѹ���ŧ";
                            }
                            if (cbtypereport.SelectedIndex == 1)
                            {
                                frrp.rpname = "crpTruckinDayGraphbydatewbf";
                                frrp.cationname = cbtypereport.Text + cbmenusub2.Text;
                            }
                            if (cbtypereport.SelectedIndex == 2)
                            {
                                frrp.rpname = "crpTruckinWeekGraphbydatewbf";
                                frrp.cationname = cbtypereport.Text + cbmenusub2.Text;
                            }
                            if (cbtypereport.SelectedIndex == 3)
                            {
                                frrp.rpname = "crpTruckinMontGraphbydatewbf";
                                frrp.cationname = cbtypereport.Text + cbmenusub2.Text;
                            }

                            if (cbtypereport.SelectedIndex == 4)
                            {
                                if (cbmenusub2.SelectedIndex == 0 || cbmenusub2.SelectedIndex == -1)
                                {
                                    frrp.rpname = "crpPurchaseAllDesignSuccessbydatepur";
                                    frrp.cationname = cbtypereport.Text + cbmenusub2.Text;
                                }
                                if (cbmenusub2.SelectedIndex == 1)
                                {
                                    frrp.rpname = "crpPurchaseAllDesignSuccessbydateresive";
                                    frrp.cationname = cbtypereport.Text + cbmenusub2.Text;
                                }
                            }                          
                        }

                    }

                    else
                    {
                        if (cbmenusub2.SelectedIndex == 0 || cbmenusub2.SelectedIndex == -1)//����ѹ������
                        {
                            if (cbtypereport.SelectedIndex == 0 || cbtypereport.SelectedIndex == -1)
                            {
                                frrp.rpname = "crpTruckinbyBranchbydatepur";
                                frrp.cationname = "����§ҹ�����ҷ������ѹ�����觫���";
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());

                            }
                            if (cbtypereport.SelectedIndex == 1)
                            {
                                frrp.rpname = "crpTruckinDayGraphbydatepurBrach";
                                frrp.cationname = cbtypereport.Text + cbmenusub2.Text;
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                            }
                            if (cbtypereport.SelectedIndex == 2)
                            {
                                frrp.rpname = "crpTruckinWeekGraphbydatepurBranch";
                                frrp.cationname = cbtypereport.Text + cbmenusub2.Text;
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                            }
                            if (cbtypereport.SelectedIndex == 3)
                            {
                                frrp.rpname = "crpTruckinMontGraphbydatepurBranch";
                                frrp.cationname = cbtypereport.Text + cbmenusub2.Text;
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                            }

                            if (cbtypereport.SelectedIndex == 4)
                            {
                                if (cbmenusub2.SelectedIndex == 0 || cbmenusub2.SelectedIndex == -1)
                                {
                                    frrp.rpname = "crpPurchaseAllDesignSuccessbydatepur";
                                    frrp.cationname = cbtypereport.Text + cbmenusub2.Text;
                                    frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                }
                                if (cbmenusub2.SelectedIndex == 1)
                                {
                                    frrp.rpname = "crpPurchaseAllDesignSuccessbydateresive";
                                    frrp.cationname = cbtypereport.Text + cbmenusub2.Text;
                                    frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                }
                            }
                        }


                        if (cbmenusub2.SelectedIndex == 1)//����ѹ���ŧ
                        {
                            if (cbtypereport.SelectedIndex == 0 || cbtypereport.SelectedIndex == -1)
                            {
                                frrp.rpname = "crpTruckinbyBranchbydatewbf";
                                frrp.cationname = "����§ҹ�����ҷ���������ѹ���ŧ";
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                            }
                            if (cbtypereport.SelectedIndex == 1)
                            {
                                frrp.rpname = "crpTruckinDayGraphbydatewbfBranch";
                                frrp.cationname = cbtypereport.Text + cbmenusub2.Text;
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                            }
                            if (cbtypereport.SelectedIndex == 2)
                            {
                                frrp.rpname = "crpTruckinWeekGraphbydatewbfBranch";
                                frrp.cationname = cbtypereport.Text + cbmenusub2.Text;
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                            }
                            if (cbtypereport.SelectedIndex == 3)
                            {
                                frrp.rpname = "crpTruckinMontGraphbydatewbfBranch";
                                frrp.cationname = cbtypereport.Text + cbmenusub2.Text;
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                            }

                            if (cbtypereport.SelectedIndex == 4)
                            {
                                if (cbmenusub2.SelectedIndex == 0 || cbmenusub2.SelectedIndex == -1)
                                {
                                    frrp.rpname = "crpPurchaseAllDesignSuccessbydatepur";
                                    frrp.cationname = cbtypereport.Text + cbmenusub2.Text;
                                    frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                }
                                if (cbmenusub2.SelectedIndex == 1)
                                {
                                    frrp.rpname = "crpPurchaseAllDesignSuccessbydateresive";
                                    frrp.cationname = cbtypereport.Text + cbmenusub2.Text;
                                    frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                }
                            }
                        }
                    }

                    if (cbtypereport.SelectedIndex == 5)
                    {
                        frrp.rpname = "Crpphysicalpur";
                    }
                }

                else //����Ẻ������
                {
                    if (idbranch == "")//all branch
                    {
                        if (cbtypereport.SelectedIndex == 0 || cbtypereport.SelectedIndex == -1)
                        {
                            if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ��ҷ�����
                            {
                                frrp.rpname = "crpTruckinFiltter";
                                frrp.valuename = "proname";
                            }

                            if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                            {
                                frrp.rpname = "crpTruckinFiltter";
                                frrp.valuename = "comtran";
                            }

                            if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡�������¹
                            {
                                frrp.rpname = "crpTruckinFiltter";
                                frrp.valuename = "serailcar";
                            }

                            if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡�������˹���
                            {
                                frrp.rpname = "crpTruckinFiltter";
                                frrp.valuename = "comsup";
                            }

                            if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡���������
                            {
                                frrp.rpname = "crpTruckinFiltter";
                                frrp.valuename = "compur";
                            }

                            frrp.filterby = cbmenusub2.Text.Trim();
                            frrp.cationname = cbmenusub1.Text;

                        }

                        if (cbtypereport.SelectedIndex == 1)//all branch graph day
                        {
                            if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                            {

                                frrp.rpname = "crpTruckinFiltterbygraphday";
                                frrp.valuename = "proname";
                            }

                            if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                            {
                                frrp.rpname = "crpTruckinFiltterbygraphday";
                                frrp.valuename = "comtran";
                            }

                            if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡�������¹
                            {
                                frrp.rpname = "crpTruckinFiltterbygraphday";
                                frrp.valuename = "serailcar";
                            }

                            if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡�������˹���
                            {
                                frrp.rpname = "crpTruckinFiltterbygraphday";
                                frrp.valuename = "comsup";
                            }

                            if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡���������
                            {
                                frrp.rpname = "crpTruckinFiltterbygraphday";
                                frrp.valuename = "compur";
                            }

                            frrp.filterby = cbmenusub2.Text.Trim();
                            frrp.cationname = cbmenusub1.Text;

                        }

                        if (cbtypereport.SelectedIndex == 2)//all branch graph week
                        {
                            if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                            {

                                frrp.rpname = "crpTruckinFiltterbygraphweek";
                                frrp.valuename = "proname";
                            }

                            if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                            {
                                frrp.rpname = "crpTruckinFiltterbygraphweek";
                                frrp.valuename = "comtran";
                            }

                            if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡�������¹
                            {
                                frrp.rpname = "crpTruckinFiltterbygraphweek";
                                frrp.valuename = "serailcar";
                            }

                            if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡�������˹���
                            {
                                frrp.rpname = "crpTruckinFiltterbygraphweek";
                                frrp.valuename = "comsup";
                            }

                            if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡���������
                            {
                                frrp.rpname = "crpTruckinFiltterbygraphweek";
                                frrp.valuename = "compur";
                            }

                            frrp.filterby = cbmenusub2.Text.Trim();
                            frrp.cationname = cbmenusub1.Text;
                        }

                        if (cbtypereport.SelectedIndex == 3)//all branch graph mont
                        {
                            if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                            {
                                frrp.rpname = "crpTruckinFiltterbygraphmont";
                                frrp.valuename = "proname";
                            }

                            if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                            {
                                frrp.rpname = "crpTruckinFiltterbygraphmont";
                                frrp.valuename = "comtran";
                            }

                            if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡�������¹
                            {
                                frrp.rpname = "crpTruckinFiltterbygraphmont";
                                frrp.valuename = "serailcar";
                            }

                            if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡�������˹���
                            {
                                frrp.rpname = "crpTruckinFiltterbygraphmont";
                                frrp.valuename = "comsup";
                            }

                            if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡���������
                            {
                                frrp.rpname = "crpTruckinFiltterbygraphmont";
                                frrp.valuename = "compur";
                            }

                            frrp.filterby = cbmenusub2.Text.Trim();
                            frrp.cationname = cbmenusub1.Text;
                        }
                    }

                    else
                    {
                        if (cbtypereport.SelectedIndex == 0 || cbtypereport.SelectedIndex == -1)//Ẻ��§ҹ�����
                        {
                            if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                            {
                                frrp.rpname = "crpTruckinFiltterbyBranch";                               
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                frrp.valuename = "proname";
                            }

                            if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                            {
                                frrp.rpname = "crpTruckinFiltterbyBranch";                               
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                frrp.valuename = "comtran";
                            }

                            if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡�������¹
                            {
                                frrp.rpname = "crpTruckinFiltterbyBranch";                                
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                frrp.valuename = "serailcar";
                            }

                            if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡�������˹���
                            {
                                frrp.rpname = "crpTruckinFiltterbyBranch";                               
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                frrp.valuename = "comsup";
                            }

                            if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡���������
                            {
                                frrp.rpname = "crpTruckinFiltterbyBranch";                               
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                frrp.valuename = "compur";
                            }

                            frrp.filterby = cbmenusub2.Text.Trim();
                            frrp.cationname = cbmenusub1.Text;
                        }

                        if (cbtypereport.SelectedIndex == 1) //by graph day
                        {
                            if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                            {
                                frrp.rpname = "crpTruckinFiltterbyBranchgraphday";                                
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                frrp.valuename = "proname";
                            }

                            if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                            {
                                frrp.rpname = "crpTruckinFiltterbyBranchgraphday";                                
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                frrp.valuename = "comtran";
                            }

                            if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡�������¹
                            {
                                frrp.rpname = "crpTruckinFiltterbyBranchgraphday";                              
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                frrp.valuename = "serailcar";
                            }

                            if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡�������˹���
                            {
                                frrp.rpname = "crpTruckinFiltterbyBranchgraphday";                              
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                frrp.valuename = "comsup";
                            }

                            if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡���������
                            {
                                frrp.rpname = "crpTruckinFiltterbyBranchgraphday";                                
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                frrp.valuename = "compur";
                            }

                            frrp.filterby = cbmenusub2.Text.Trim();
                            frrp.cationname = cbmenusub1.Text;
                        }

                        if (cbtypereport.SelectedIndex == 2) //by graph week
                        {
                            if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                            {
                                frrp.rpname = "crpTruckinFiltterbyBranchgraphweek";
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                frrp.valuename = "proname";
                            }

                            if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                            {
                                frrp.rpname = "crpTruckinFiltterbyBranchgraphweek";
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                frrp.valuename = "comtran";
                            }

                            if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡�������¹
                            {
                                frrp.rpname = "crpTruckinFiltterbyBranchgraphweek";
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                frrp.valuename = "serailcar";
                            }

                            if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡�������˹���
                            {
                                frrp.rpname = "crpTruckinFiltterbyBranchgraphweek";
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                frrp.valuename = "comsup";
                            }

                            if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡���������
                            {
                                frrp.rpname = "crpTruckinFiltterbyBranchgraphweek";
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                frrp.valuename = "compur";
                            }

                            frrp.filterby = cbmenusub2.Text.Trim();
                            frrp.cationname = cbmenusub1.Text;
                        }

                        if (cbtypereport.SelectedIndex == 3) //by graph mont
                        {
                            if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                            {
                                frrp.rpname = "crpTruckinFiltterbyBranchgraphmont";
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                frrp.valuename = "proname";
                            }

                            if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                            {
                                frrp.rpname = "crpTruckinFiltterbyBranchgraphmont";
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                frrp.valuename = "comtran";
                            }

                            if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡�������¹
                            {
                                frrp.rpname = "crpTruckinFiltterbyBranchgraphmont";
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                frrp.valuename = "serailcar";
                            }

                            if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡�������˹���
                            {
                                frrp.rpname = "crpTruckinFiltterbyBranchgraphmont";
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                frrp.valuename = "comsup";
                            }

                            if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡���������
                            {
                                frrp.rpname = "crpTruckinFiltterbyBranchgraphmont";
                                frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                                frrp.valuename = "compur";
                            }

                            frrp.filterby = cbmenusub2.Text.Trim();
                            frrp.cationname = cbmenusub1.Text;
                        } 
                    }
                }                
            }

            if (idmenu == 5)// ��§ҹ����͡
            {
                if (cbmenusub1.SelectedIndex == 0 || cbmenusub1.SelectedIndex == -1)//All
                {
                    if (idbranch == "")//all branch
                    {
                        if (cbmenusub2.SelectedIndex == 0)
                        {
                            if (cbtypereport.SelectedIndex == 0 || cbtypereport.SelectedIndex == -1)//Ẻ����� (����������)
                            {
                                frrp.rpname = "crpTruckoutAllbyorderdate";
                                frrp.cationname = "����§ҹ���Թ����͡������ (����ѹ����Ѻ Order)";
                            }
                            if (cbtypereport.SelectedIndex == 1)
                            {
                                frrp.rpname = "crpTruckoutDayGraphorderdate";
                            }
                            if (cbtypereport.SelectedIndex == 2)
                            {
                                frrp.rpname = "crpTruckoutWeekGraphorderdate";
                            }
                            if (cbtypereport.SelectedIndex == 3)
                            {
                                frrp.rpname = "crpTruckoutMontGraphorderdate";
                            }

                            if (cbtypereport.SelectedIndex != 0 || cbtypereport.SelectedIndex != -1)//Ẻ����� (����������)
                            { frrp.cationname = cbtypereport.Text; }
                        }

                        if (cbmenusub2.SelectedIndex == 1)//����ѹ������Թ���
                        {
                            if (cbtypereport.SelectedIndex == 0 || cbtypereport.SelectedIndex == -1)
                            {
                                frrp.rpname = "crpTruckoutAllbydateWbf";
                                frrp.cationname = "����§ҹ���Թ����͡������ (����ѹ������Թ���)";
                            }

                            if (cbtypereport.SelectedIndex == 1)
                            {
                                frrp.rpname = "crpTruckoutDayGraphdateWbf";
                            }
                            if (cbtypereport.SelectedIndex == 2)
                            {
                                frrp.rpname = "crpTruckoutWeekGraphdateWbf";
                            }

                            if (cbtypereport.SelectedIndex == 3)
                            {
                                frrp.rpname = "crpTruckoutMontGraphdateWbf";
                            }

                            if (cbtypereport.SelectedIndex != 0 || cbtypereport.SelectedIndex != -1)
                            { frrp.cationname = cbtypereport.Text; }

                        }


                        if (cbmenusub2.SelectedIndex == 2)//����ѹ���ŧ�Թ���
                        {
                            if (cbtypereport.SelectedIndex == 0 || cbtypereport.SelectedIndex == -1)
                            {
                                frrp.rpname = "crpTruckoutAllbydateWcus";
                                frrp.cationname = "����§ҹ���Թ����͡������ (����ѹ���ŧ�Թ���)";
                            }

                            if (cbtypereport.SelectedIndex == 1)
                            {
                                frrp.rpname = "crpTruckoutDayGraphdateWcus";
                            }
                            if (cbtypereport.SelectedIndex == 2)
                            {
                                frrp.rpname = "crpTruckoutWeekGraphdateWcus";
                            }
                            if (cbtypereport.SelectedIndex == 3)
                            {
                                frrp.rpname = "crpTruckoutMontGraphdateWcus";
                            }

                            if (cbtypereport.SelectedIndex != 0 || cbtypereport.SelectedIndex != -1)
                            {
                                frrp.cationname = cbtypereport.Text;
                            }
                        }

                        if (cbtypereport.SelectedIndex == 4)
                        {
                            frrp.rpname = "Crpphysicalsale";
                        }
                    }

                    else  // ��Ẻ���͡�Ң� ��Ẻ������
                    {
                        if (cbmenusub2.SelectedIndex == 0)
                        {
                            if (cbtypereport.SelectedIndex == 0 || cbtypereport.SelectedIndex == -1)//Ẻ����� (����������)
                            {
                                frrp.rpname = "crpTruckoutAllbyorderdateBranch";
                                frrp.cationname = "����§ҹ���Թ����͡������ (����ѹ����Ѻ Order)";  //
                            }
                            if (cbtypereport.SelectedIndex == 1)
                            {
                                frrp.rpname = "crpTruckoutDayGraphBranchorderdate";                              
                            }
                            if (cbtypereport.SelectedIndex == 2)
                            {
                                frrp.rpname = "crpTruckoutWeekGraphBranchorderdate";
                            }
                            if (cbtypereport.SelectedIndex == 3)
                            {
                                frrp.rpname = "crpTruckoutMontGraphBranchorderdate";
                            }

                            if (cbtypereport.SelectedIndex != 0 || cbtypereport.SelectedIndex != -1)//Ẻ����� (����������)
                            { frrp.cationname = cbtypereport.Text; frrp.cationname = "���͡�Ң� " + cbbranch.Text + "(" + cbmenusub2.Text + ")"; }                         
                        }

                        if (cbmenusub2.SelectedIndex == 1)//����ѹ������Թ���
                        {
                            if (cbtypereport.SelectedIndex == 0 || cbtypereport.SelectedIndex == -1)
                            {
                                frrp.rpname = "crpTruckoutAllbydateWbfBranch";
                                frrp.cationname = "����§ҹ���Թ����͡������ (����ѹ������Թ���)";//
                            }

                            if (cbtypereport.SelectedIndex == 1)
                            {
                                frrp.rpname = "crpTruckoutDayGraphBranchdateWbf";
                            }
                            if (cbtypereport.SelectedIndex == 2)
                            {
                                frrp.rpname = "crpTruckoutWeekGraphBranchdateWbf";
                            }

                            if (cbtypereport.SelectedIndex == 3)
                            {
                                frrp.rpname = "crpTruckoutMontGraphBranchdateWbf";
                            }

                            if (cbtypereport.SelectedIndex != 0 || cbtypereport.SelectedIndex != -1)
                            { frrp.cationname = cbtypereport.Text; frrp.cationname = "���͡�Ң� " + cbbranch.Text + "(" + cbmenusub2.Text + ")"; }                         

                        }


                        if (cbmenusub2.SelectedIndex == 2)//����ѹ���ŧ�Թ��ҷ���١���
                        {
                            if (cbtypereport.SelectedIndex == 0 || cbtypereport.SelectedIndex == -1)
                            {
                                frrp.rpname = "crpTruckoutAllbydateWcusBranch";
                                frrp.cationname = "����§ҹ���Թ����͡������ (����ѹ���ŧ�Թ���)";//
                            }

                            if (cbtypereport.SelectedIndex == 1)
                            {
                                frrp.rpname = "crpTruckoutDayGraphBranchdateWcus";
                            }
                            if (cbtypereport.SelectedIndex == 2)
                            {
                                frrp.rpname = "crpTruckoutWeekGraphBranchdateWcus";
                            }
                            if (cbtypereport.SelectedIndex == 3)
                            {
                                frrp.rpname = "crpTruckoutMontGraphBranchdateWcus";
                            }

                            if (cbtypereport.SelectedIndex != 0 || cbtypereport.SelectedIndex != -1)
                            {
                                frrp.cationname = cbtypereport.Text; frrp.cationname ="���͡�Ң� " + cbbranch.Text + "(" + cbmenusub2.Text + ")"; }              
                        }

                        frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                    }
                }


                else  // ��Ẻ੾���Թ��� ���ͺ���ѷ ������� �
                {
                    if (idbranch == "")//all branch
                    {
                        if (cbtypereport.SelectedIndex == 0 || cbtypereport.SelectedIndex == -1)//Ẻ����� (����������)
                        {
                            if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                            {
                                frrp.rpname = "crpTruckoutFiltterallbranch";
                                frrp.valuename = "proname";
                            }

                            if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                            {
                                frrp.rpname = "crpTruckoutFiltterallbranch";
                                frrp.valuename = "comtran";
                            }

                            if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡����¹
                            {
                                frrp.rpname = "crpTruckoutFiltterallbranch";
                                frrp.valuename = "serailcar";
                            }
                            if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡����١���
                            {
                                frrp.rpname = "crpTruckoutFiltterallbranch";
                                frrp.valuename = "comcus";
                            }

                            if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡��������
                            {
                                frrp.rpname = "crpTruckoutFiltterallbranch";
                                frrp.valuename = "comsale";
                            }
                        }

                        if (cbtypereport.SelectedIndex == 1) //graph day
                        {
                            //crpTruckoutFillterDayGraphorderdate
                            if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                            {
                                frrp.rpname = "crpTruckoutFillterDayGraphorderdate";
                                frrp.valuename = "proname";
                            }

                            if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                            {
                                frrp.rpname = "crpTruckoutFillterDayGraphorderdate";
                                frrp.valuename = "comtran";
                            }

                            if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡����¹
                            {
                                frrp.rpname = "crpTruckoutFillterDayGraphorderdate";
                                frrp.valuename = "serailcar";
                            }
                            if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡����١���
                            {
                                frrp.rpname = "crpTruckoutFillterDayGraphorderdate";
                                frrp.valuename = "comcus";
                            }

                            if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡��������
                            {
                                frrp.rpname = "crpTruckoutFillterDayGraphorderdate";
                                frrp.valuename = "comsale";
                            }

                        }
                        if (cbtypereport.SelectedIndex == 2)//graph week
                        {
                            if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                            {
                                frrp.rpname = "crpTruckoutFillterWeekGraphorderdate";
                                frrp.valuename = "proname";
                            }

                            if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                            {
                                frrp.rpname = "crpTruckoutFillterWeekGraphorderdate";
                                frrp.valuename = "comtran";
                            }

                            if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡����¹
                            {
                                frrp.rpname = "crpTruckoutFillterWeekGraphorderdate";
                                frrp.valuename = "serailcar";
                            }
                            if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡����١���
                            {
                                frrp.rpname = "crpTruckoutFillterWeekGraphorderdate";
                                frrp.valuename = "comcus";
                            }

                            if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡��������
                            {
                                frrp.rpname = "crpTruckoutFillterWeekGraphorderdate";
                                frrp.valuename = "comsale";
                            }

                        }
                        if (cbtypereport.SelectedIndex == 3)//graph mont
                        {
                            if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                            {
                                frrp.rpname = "crpTruckoutFillterMontGraphorderdate";
                                frrp.valuename = "proname";
                            }

                            if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                            {
                                frrp.rpname = "crpTruckoutFillterMontGraphorderdate";
                                frrp.valuename = "comtran";
                            }

                            if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡����¹
                            {
                                frrp.rpname = "crpTruckoutFillterMontGraphorderdate";
                                frrp.valuename = "serailcar";
                            }
                            if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡����١���
                            {
                                frrp.rpname = "crpTruckoutFillterMontGraphorderdate";
                                frrp.valuename = "comcus";
                            }

                            if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡��������
                            {
                                frrp.rpname = "crpTruckoutFillterMontGraphorderdate";
                                frrp.valuename = "comsale";
                            }
                        }

                        if (cbtypereport.SelectedIndex != 0 || cbtypereport.SelectedIndex != -1)//Ẻ����� (����������)
                        {
                            frrp.filterby = cbmenusub2.Text.Trim();
                            frrp.cationname = cbmenusub1.Text;                           
                        }
                    }


                    else  //���͡੾���Ң� ੾���Թ��� ���ͺ���ѷ
                    {
                        if (cbtypereport.SelectedIndex == 0 || cbtypereport.SelectedIndex == -1)//Ẻ����� (����������)
                        {
                            if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                            {
                                frrp.rpname = "crpTruckoutFiltterbranch";
                                frrp.valuename = "proname";
                            }

                            if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                            {
                                frrp.rpname = "crpTruckoutFiltterbranch";
                                frrp.valuename = "comtran";
                            }

                            if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡����¹
                            {
                                frrp.rpname = "crpTruckoutFiltterbranch";
                                frrp.valuename = "serailcar";
                            }
                            if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡����١���
                            {
                                frrp.rpname = "crpTruckoutFiltterbranch";
                                frrp.valuename = "comcus";
                            }

                            if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡��������
                            {
                                frrp.rpname = "crpTruckoutFiltterbranch";
                                frrp.valuename = "comsale";
                            }
                        }

                        if (cbtypereport.SelectedIndex == 1) //graph day
                        {
                            //crpTruckoutFillterDayGraphorderdate
                            if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                            {
                                frrp.rpname = "crpTruckoutFillterDayGraphorderdateBranch";
                                frrp.valuename = "proname";
                            }

                            if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                            {
                                frrp.rpname = "crpTruckoutFillterDayGraphorderdateBranch";
                                frrp.valuename = "comtran";
                            }

                            if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡����¹
                            {
                                frrp.rpname = "crpTruckoutFillterDayGraphorderdateBranch";
                                frrp.valuename = "serailcar";
                            }
                            if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡����١���
                            {
                                frrp.rpname = "crpTruckoutFillterDayGraphorderdateBranch";
                                frrp.valuename = "comcus";
                            }

                            if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡��������
                            {
                                frrp.rpname = "crpTruckoutFillterDayGraphorderdateBranch";
                                frrp.valuename = "comsale";
                            }

                        }
                        if (cbtypereport.SelectedIndex == 2)//graph week
                        {
                            if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                            {
                                frrp.rpname = "crpTruckoutFillterWeekGraphorderdateBranch";
                                frrp.valuename = "proname";
                            }

                            if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                            {
                                frrp.rpname = "crpTruckoutFillterWeekGraphorderdateBranch";
                                frrp.valuename = "comtran";
                            }

                            if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡����¹
                            {
                                frrp.rpname = "crpTruckoutFillterWeekGraphorderdateBranch";
                                frrp.valuename = "serailcar";
                            }
                            if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡����١���
                            {
                                frrp.rpname = "crpTruckoutFillterWeekGraphorderdateBranch";
                                frrp.valuename = "comcus";
                            }

                            if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡��������
                            {
                                frrp.rpname = "crpTruckoutFillterWeekGraphorderdateBranch";
                                frrp.valuename = "comsale";
                            }

                        }
                        if (cbtypereport.SelectedIndex == 3)//graph mont
                        {
                            if (cbmenusub1.SelectedIndex == 1)//����§ҹ�¡����Թ���
                            {
                                frrp.rpname = "crpTruckoutFillterMontGraphorderdateBranch";
                                frrp.valuename = "proname";
                            }

                            if (cbmenusub1.SelectedIndex == 2)//����§ҹ�¡�������
                            {
                                frrp.rpname = "crpTruckoutFillterMontGraphorderdateBranch";
                                frrp.valuename = "comtran";
                            }

                            if (cbmenusub1.SelectedIndex == 3)//����§ҹ�¡����¹
                            {
                                frrp.rpname = "crpTruckoutFillterMontGraphorderdateBranch";
                                frrp.valuename = "serailcar";
                            }
                            if (cbmenusub1.SelectedIndex == 4)//����§ҹ�¡����١���
                            {
                                frrp.rpname = "crpTruckoutFillterMontGraphorderdateBranch";
                                frrp.valuename = "comcus";
                            }

                            if (cbmenusub1.SelectedIndex == 5)//����§ҹ�¡��������
                            {
                                frrp.rpname = "crpTruckoutFillterMontGraphorderdateBranch";
                                frrp.valuename = "comsale";
                            }
                        }


                        if (cbtypereport.SelectedIndex != 0 || cbtypereport.SelectedIndex != -1)//Ẻ����� (����������)
                        {
                            frrp.filterby = cbmenusub2.Text.Trim();
                            frrp.cationname = cbmenusub1.Text;
                            frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                        }
                    }




                    

                }
            }
                

                if (idmenu == 6)// ����
                {

                }

                if (idmenu == 7)// ��§ҹ�Թ����ʵ�͡
                {
                    if (cbmenusub2.SelectedIndex == 0)
                    {
                        if (cbbranch.Text == "�ٷ�����")
                        { frrp.rpname = "crpStockAllnow"; }
                        else { frrp.rpname = "crpStockFiltternow"; frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString()); }
                    }
                    if (cbmenusub2.SelectedIndex == 1)//ʵ�͡��͹��ѧ
                    {
                        if (cbbranch.Text == "�ٷ�����")
                        { frrp.rpname = "crpStockAllold"; }
                        else { 

                            frrp.rpname = "crpStockFiltterold"; 
                            frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString());
                        }
                    }
                    if (cbmenusub2.SelectedIndex == 2)//����ѵ�ʵ�͡���͹��ѧ
                    {
                        if (cbbranch.Text == "�ٷ�����")
                        { frrp.rpname = "crpStockAllhisday"; }


                        else { frrp.rpname = "crpStockFiltterhisday"; frrp.idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString()); }
                    }
                }

                if (idmenu == 8)// ��§ҹ��º ����-��� ��Ш��ѹ
                {
                    frrp.rpname = "crpComparePtS";
                    frrp.cationname = "����§ҹ����͡������";
                }

                if (idmenu == 9)// ��§ҹ��º ������-����͡
                {



                }

                if (idmenu == 10)// ��§ҹ¡��ԡ/����¹�ŧ�ҹ
                {

                }

                if (idmenu == 11)// ��§ҹ�÷����ѹ
                {
                    frrp.rpname = "rprateoil";
                }

                //if (idbranch != "" || idbranch!= "System.Data.DataRowView")
                //{
                //    frrp.idbranch = Convert.ToInt16(idbranch);
                //}

               
            RageSTToED_datePrint(frrp);
            frrp.ShowDialog();
        }
   
        private void btnclose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
            
        private void btnstatusjob_Click(object sender, EventArgs e)
        {
            Frmpayjob fpj = new Frmpayjob();
            fpj.ShowDialog();
        }

        private void dtgviewfile_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string viewfile = "";
            try
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();

                string sql2 = "select filepath from tbmaps where idauto='" + dtgviewfile[0, e.RowIndex].Value.ToString().Trim() + "'";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();

                DR2.Read();
                { viewfile = DR2["filepath"].ToString(); }
                DR2.Close();

                System.Diagnostics.Process.Start(viewfile);
                CN.Close();
            }
            catch (Exception ex)
            { MessageBox.Show("��辺�����س��ͧ����Դ", "�Դ��Ҵ !", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dtgtruckout_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            double weightbf = 0;
            double weightaf = 0;
            double dfweigdf = 0;

            if (e.ColumnIndex == 10)//��.��
            {
                idmenuunlock = 24;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    weightbf = Convert.ToDouble(dtgtruckout[10, idRowindex].Value.ToString());
                    string sql1 = "update tbweigth set weigthbf =" + weightbf + " Where idtran= '" + idtran + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();
                    string sql5 = "update tborder set remark3='���ö˹ѡ' Where idtran= '" + idtran + "'";
                    SqlCommand CM5 = new SqlCommand(sql5, CN);
                    CM5.ExecuteNonQuery();
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }
            if (e.ColumnIndex == 11)//��.˹ѡ
            {
                idmenuunlock = 25;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    weightbf = Convert.ToDouble(dtgtruckout[10, idRowindex].Value.ToString());
                    weightaf = Convert.ToDouble(dtgtruckout[11, idRowindex].Value.ToString());
                    dfweigdf = weightaf - weightbf;
                    dtgtruckout[12, idRowindex].Value = dfweigdf.ToString();
                    string sql1 = "update tbweigth set weigthaf=" + weightaf + ",weigthnet=" + dfweigdf + " Where idtran= '" + idtran + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();

                    string sql5 = "update tborder set remark3='�͹��˹ѡ�١���',idstatus = 1 Where idtran= '" + idtran + "'";
                    SqlCommand CM5 = new SqlCommand(sql5, CN);
                    CM5.ExecuteNonQuery();
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }

            if (e.ColumnIndex == 13)//date cus
            {
                idmenuunlock = 26;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    try
                    {
                        DateTime dt = new DateTime();
                        dt = Convert.ToDateTime(dtgtruckout[13, idRowindex].Value.ToString());
                        string day = dt.Day.ToString();
                        string month = dt.Month.ToString();
                        string year = dt.Year.ToString();
                        string date = month + "/" + day + "/" + year;

                        string sql = "update tbweigth set dateWcus= '" + date + "' Where idtran= '" + idtran + "'";
                        SqlCommand CM = new SqlCommand(sql, CN);
                        CM.ExecuteNonQuery();
                        //MessageBox.Show("Update Complete", "Complete !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    { MessageBox.Show("����Ţ��ҹ��", "�Դ��Ҵ !", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }

            if (e.ColumnIndex == 14)//wegthcus
            {
                idmenuunlock = 27;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    double weightnet = Convert.ToDouble(dtgtruckout[12, idRowindex].Value.ToString());
                    double weightcus = Convert.ToDouble(dtgtruckout[14, idRowindex].Value.ToString());
                    double weigthdf = weightcus - weightnet;
                    dtgtruckout[15, idRowindex].Value = weigthdf.ToString();
                    string sql = "update tbweigth set weigthcus= '" + weightcus + "',weigthsupdfsale= '" + weigthdf + "' Where idtran= '" + idtran + "'";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }

            if (e.ColumnIndex == 16)//selet weight
            {
                idmenuunlock = 28;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    FrmInsertweigth finsw = new FrmInsertweigth();
                    finsw.wbf = Convert.ToDecimal(dtgtruckin[12, idRowindex].Value.ToString());
                    finsw.waf = Convert.ToDecimal(dtgtruckin[14, idRowindex].Value.ToString());
                    finsw.idtran = idtran.Trim();
                    finsw.idsave = 1;
                    finsw.ShowDialog();
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }

            if (e.ColumnIndex == 17)
            {  
                idmenuunlock = 37;
                CheckUnlockpwd();

                if (pwdunlock == 1)//update status recivebill
                {
                    if (dtgtruckout[17, e.RowIndex].Value.ToString() != "True")
                    {
                        Frmconfirmpwd fcompw = new Frmconfirmpwd();    
                        fcompw.ShowDialog();

                        if (fcompw.idcheck == 1)
                        {
                            string sql1 = "update tborder set recivebill = 0 Where idtran= '" + idtran + "'";
                            SqlCommand CM1 = new SqlCommand(sql1, CN);
                            CM1.ExecuteNonQuery();                         
                        }
                    }

                    else
                    {

                        string sql1 = "update tborder set recivebill= 1 Where idtran= '" + idtran + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, CN);
                        CM1.ExecuteNonQuery();
                    }
                }

                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }

          
            if (e.ColumnIndex == 18)//moisture
            {
                idmenuunlock = 29;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    decimal moisture = Convert.ToDecimal(dtgtruckout[18, idRowindex].Value.ToString());
                    string sql1 = "update tbtransport set moisture=" + moisture + " Where idtran= '" + idtran + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }

            if (e.ColumnIndex == 19)//WperV
            {
                idmenuunlock = 30;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    decimal kkperweigth = Convert.ToDecimal(dtgtruckout[19, idRowindex].Value.ToString());
                    string sql1 = "update tbtransport set kkperweigth=" + kkperweigth + " Where idtran= '" + idtran + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }


            if (e.ColumnIndex == 21)//remark 2
            {
                idmenuunlock = 31;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    try
                    {
                        string remark2 = dtgtruckout[21, idRowindex].Value.ToString();
                        string sql1 = "update tbtransport set remark2= '" + remark2 + "' Where idtran= '" + idtran + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, CN);
                        CM1.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("������������ҧ", "�Դ��Ҵ !", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }

            if (e.ColumnIndex == 22)//invoice
            {
                idmenuunlock = 32;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    try
                    {
                        string rfinvoice = dtgtruckout[22, idRowindex].Value.ToString();
                        string sql1 = "update tbtransport set rfinvoice= '" + rfinvoice + "' Where idtran= '" + idtran + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, CN);
                        CM1.ExecuteNonQuery();                        
                    }
                    catch (Exception ex)
                    { MessageBox.Show("������������ҧ", "�Դ��Ҵ !", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }

                
            }

            CN.Close();
        }

        private void dtgrpfstc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();            

            if (e.ColumnIndex == 11)//��.�� 9
            {
                idmenuunlock = 35;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    try
                    {
                        string weightsup;
                        weightsup = dtgrpfstc[11, idRowindex].Value.ToString();
                        if (dtgrpfstc[11, idRowindex].Value.ToString() == "")
                        { weightsup = "0"; }
                        string sql1 = "update tbweigth set weigthsup=" + weightsup + " Where idtran= '" + idtran + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, CN);
                        CM1.ExecuteNonQuery();
                    }
                    catch
                    { MessageBox.Show("����Ţ��ҹ��", "�Դ��Ҵ !", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }

            if (e.ColumnIndex == 13)//��.���� 10 (��.�١���)
            {
                idmenuunlock = 27;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    try
                    {
                        double weightsup = Convert.ToDouble(dtgrpfstc[11, idRowindex].Value.ToString());
                        double weightcus = Convert.ToDouble(dtgrpfstc[13, idRowindex].Value.ToString());
                        double dfweigth = weightcus - weightsup;

                        //dtgrpfstc[13, idRowindex].Value = dfweigth.ToString();

                        string sql1 = "update tbweigth set weigthcus =" + weightcus + ",weigthsupdfsale=" + dfweigth + " Where idtran= '" + idtran + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, CN);
                        CM1.ExecuteNonQuery();
                    }
                    catch
                    { MessageBox.Show("��.�鹵�ͧ�����ҡѺ 0", "�Դ��Ҵ !", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }

            
            if (e.ColumnIndex == 15)//�ѹ���ŧ�Թ���
            {
                idmenuunlock = 26;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    try
                    {
                        DateTime dt = new DateTime();
                        dt = Convert.ToDateTime(dtgrpfstc[15, idRowindex].Value.ToString());
                        string day = dt.Day.ToString();
                        string month = dt.Month.ToString();
                        string year = dt.Year.ToString();
                        string date = month + "/" + day + "/" + year;

                        string sql1 = "update tbweigth set dateWcus = '" + date + "' Where idtran= '" + idtran + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, CN);
                        CM1.ExecuteNonQuery();
                    }
                    catch
                    { }
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }

            //if (e.ColumnIndex == 15)//�ѹ���ŧ
            //{
            //    DateTime dt = new DateTime();
            //    dt = Convert.ToDateTime(dtgrpfstc[16, idRowindex].Value.ToString());
            //    string day = dt.Day.ToString();
            //    string month = dt.Month.ToString();
            //    string year = dt.Year.ToString();
            //    string date = month + "/" + day + "/" + year;

            //    string sql1 = "update tbweigth set dateWbf =" + date + " Where idtran= '" + idtran + "'";
            //    SqlCommand CM1 = new SqlCommand(sql1, CN);
            //    CM1.ExecuteNonQuery();
            //}

            if (e.ColumnIndex == 16)//�������
            {
                idmenuunlock = 29;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    string moisture = dtgrpfstc[16, idRowindex].Value.ToString();
                    if (moisture != "")
                    {
                        string sql1 = "update tbtransport set moisture = " + moisture + " Where idtran= '" + idtran + "'";
                        SqlCommand CM1 = new SqlCommand(sql1, CN);
                        CM1.ExecuteNonQuery();
                    }
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }

            if (e.ColumnIndex == 17)//invoic3
            {
                 idmenuunlock = 32;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    string rfinvoice = dtgrpfstc[17, idRowindex].Value.ToString();
                    string sql1 = "update tbtransport set rfinvoice = '" + rfinvoice + "' Where idtran= '" + idtran + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }

            if (e.ColumnIndex == 18)//�����˵�
            {
                idmenuunlock = 31;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    string value = dtgrpfstc[18, idRowindex].Value.ToString();
                    string sql1 = "update tbtransport set remark2 = '" + value + "' Where idtran= '" + idtran + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }

            CN.Close(); ChecksumDTG();
        }

        private void dtgrpfstc_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                idtran = dtgrpfstc[0, e.RowIndex].Value.ToString().Trim();
                idRowindex = e.RowIndex; // selectvalue = cbmenusub2.SelectedValue.ToString();
            }

            if (e.ColumnIndex == 0)//Information Data
            {
                try
                {
                    // string idtran;
                    idtran = dtgrpfstc[0, idRowindex].Value.ToString();
                    if (idtran != "")
                    {
                        FrmInformation fimt = new FrmInformation();
                        fimt.xposition = Convert.ToInt16(MousePosition.X);
                        fimt.yposition = Convert.ToInt16(MousePosition.Y);
                        fimt.idtran = idtran;
                        fimt.ShowDialog();
                    }
                }
                catch
                { MessageBox.Show("������͡�Դ��Ҵ !", "�Դ��Ҵ !", MessageBoxButtons.OK, MessageBoxIcon.Error); }               
            }

            if (e.ColumnIndex == 1)//ʶҹЧҹ
            {
                idmenuunlock = 36;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    Frmselectjobtrack fsmo = new Frmselectjobtrack();
                    fsmo.idtran = idtran;
                    fsmo.xposition = Convert.ToInt16(MousePosition.X);
                    fsmo.yposition = Convert.ToInt16(MousePosition.Y);
                    fsmo.ShowDialog();
                    LoadAllDatagrid();
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }

            if (e.ColumnIndex == 16)//���͡���˹ѡ
            {
                idmenuunlock = 28;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    try
                    {
                        FrmInsertweigth finsw = new FrmInsertweigth();
                        finsw.wbf = Convert.ToInt16(dtgrpfstc[12, idRowindex].Value.ToString());
                        finsw.waf = Convert.ToInt16(dtgrpfstc[13, idRowindex].Value.ToString());
                        finsw.idtran = idtran.Trim(); finsw.idsave = 0;
                        finsw.ShowDialog();
                        dtgrpfstc[14, idRowindex].Value = finsw.wslt.ToString();
                        LoadAllDatagrid();
                    }
                    catch
                    { MessageBox.Show("��.�鹵�ͧ�����ҡѺ 0", "�Դ��Ҵ !", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }

            ChecksumDTG();
        }

        private void dtgtruckout_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 5)//select product
            {
                if (dtgtruckout[12, e.RowIndex].Value.ToString() == "0")
                {
                    idmenuunlock = 3;
                    CheckUnlockpwd();
                    if (pwdunlock == 1)
                    {
                        try
                        {
                        Frmselectproduct fspd = new Frmselectproduct();
                        fspd.idtran = dtgtruckout[23, e.RowIndex].Value.ToString().Trim();
                        fspd.idload = 1;
                        fspd.ShowDialog();
                        LoadAllDatagrid();
                        }
                        catch
                        { MessageBox.Show("���˹ѡ�ط�Ե�ͧ�դ����ҡѺ 0 ��ҹ��", "�Դ��Ҵ !!", MessageBoxButtons.OK, MessageBoxIcon.Error);}
                    }                    
                      else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��","�Դ��Ҵ!",MessageBoxButtons.OK); }
                }
            }

            if (e.ColumnIndex == 16)//���͡
            {
                idmenuunlock = 28;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    try
                    {
                        FrmInsertweigth finsw = new FrmInsertweigth();
                        finsw.wbf = Convert.ToDecimal(dtgtruckout[12, idRowindex].Value.ToString());
                        finsw.waf = Convert.ToDecimal(dtgtruckout[14, idRowindex].Value.ToString());
                        finsw.idtran = idtran.Trim(); ;
                        finsw.idsave = 1;
                        finsw.ShowDialog();
                        LoadAllDatagrid();
                    }
                    catch
                    { MessageBox.Show("����Ţ��ҹ��", "�Դ��Ҵ !", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }
             
            ChecksumDTG();
        }        

        private void dtgtruckin_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1)//ʶҹ�
            {
                idmenuunlock = 36;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    Frmselectjobtrack fsmo = new Frmselectjobtrack();
                    fsmo.idtran = idtran;
                    fsmo.xposition = Convert.ToInt16(MousePosition.X);
                    fsmo.yposition = Convert.ToInt16(MousePosition.Y);
                    fsmo.ShowDialog();
                    LoadAllDatagrid();
                }
            }

            if (e.ColumnIndex == 5)//product
            {
                idmenuunlock = 3;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    if (dtgtruckin[12, e.RowIndex].Value.ToString() == "0")
                    {
                        Frmselectproduct fspd = new Frmselectproduct();
                        fspd.idtran = dtgtruckin[19, e.RowIndex].Value.ToString().Trim();
                        fspd.ShowDialog();
                        LoadAllDatagrid();
                    }
                    else { MessageBox.Show("���˹ѡ�ط�Ե�ͧ�դ����ҡѺ 0 ��ҹ��", "�Դ��Ҵ !!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
           
            if (e.ColumnIndex == 16)//���͡���˹ѡ
            {
                idmenuunlock = 28;
                    CheckUnlockpwd();
                    if (pwdunlock == 1)
                    {
                        try
                        {
                            FrmInsertweigth finsw = new FrmInsertweigth();
                            finsw.wbf = Convert.ToDecimal(dtgtruckin[13, idRowindex].Value.ToString());
                            finsw.waf = Convert.ToDecimal(dtgtruckin[14, idRowindex].Value.ToString());
                            finsw.idtran = idtran.Trim();
                            finsw.idsave = 2;
                            finsw.ShowDialog();
                            LoadAllDatagrid();
                        }
                        catch
                        { MessageBox.Show("����Ţ��ҹ��", "�Դ��Ҵ !", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
            }           

            idRowindex = e.RowIndex;
            ChecksumDTG();
        }

        private void cbhide_CheckedChanged(object sender, EventArgs e)
        {
            if (cbhide.Checked == true)
            { panel6.Visible = false; }
            else { panel6.Visible = true; }
        }

        private void dtgtruckin_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            double weightbf = 0;
            double weightaf = 0;
            double dfweigdf = 0;

            //dtgrpfstc[11, idRowindex].Value = dfweigth.ToString();
            if (e.ColumnIndex == 9 && dtgtruckin[9, idRowindex].Value.ToString() != "")//update dateWbf
            {
                idmenuunlock = 35;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    DateTime dt = new DateTime();
                    dt = Convert.ToDateTime(dtgtruckin[9, idRowindex].Value.ToString());
                    string day = dt.Day.ToString();
                    string month = dt.Month.ToString();
                    string year = dt.Year.ToString();
                    string date = month + "/" + day + "/" + year;

                    string sql1 = "update tbweigth set dateWbf =" + date + " Where idtran= '" + idtran + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }


            if (e.ColumnIndex == 11)//���˹ѡ
            {
                idmenuunlock = 25;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    weightbf = Convert.ToDouble(dtgtruckin[11, idRowindex].Value.ToString());

                    string sql1 = "update tbweigth set weigthbf =" + weightbf + " Where idtran= '" + idtran + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();

                    string sql5 = "update tbpurchase set remark3='���ö��'Where idtran= '" + idtran + "'";
                    SqlCommand CM5 = new SqlCommand(sql5, CN);
                    CM5.ExecuteNonQuery();
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }

            if (e.ColumnIndex == 12)//weight af
            {
                idmenuunlock = 24;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    weightbf = Convert.ToDouble(dtgtruckin[11, idRowindex].Value.ToString());
                    weightaf = Convert.ToDouble(dtgtruckin[12, idRowindex].Value.ToString());
                    dfweigdf = weightbf - weightaf;
                    dtgtruckin[13, idRowindex].Value = dfweigdf.ToString();
                    string sql1 = "update tbweigth set weigthaf=" + weightaf + ",weigthnet=" + dfweigdf + " Where idtran= '" + idtran + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();

                    string sql5 = "update tbpurchase set remark3 ='�Ѻ�Թ�������',idstatus = 2 Where idtran= '" + idtran + "'";
                    SqlCommand CM5 = new SqlCommand(sql5, CN);
                    CM5.ExecuteNonQuery();
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }

            if (e.ColumnIndex == 14)//weigtn sup
            {
                idmenuunlock = 33;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    double weaf = Convert.ToDouble(dtgtruckin[13, idRowindex].Value.ToString());
                    double wesup = Convert.ToDouble(dtgtruckin[14, idRowindex].Value.ToString());
                    double weigdf = weaf - wesup;
                    dtgtruckin[15, idRowindex].Value = weigdf.ToString();
                    string sql1 = "update tbweigth set weigthsup=" + wesup + ",weigthsupdfsale=" + weigdf + " Where idtran= '" + idtran + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }

            if (e.ColumnIndex == 17)//moisture
            {
                idmenuunlock = 29;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    decimal moisture = Convert.ToDecimal(dtgtruckin[17, idRowindex].Value.ToString());
                    string sql1 = "update tbtransport set moisture=" + moisture + " Where idtran= '" + idtran + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }

            if (e.ColumnIndex == 18)//kk per weigth
            {
                idmenuunlock = 30;
                CheckUnlockpwd();
                if (pwdunlock == 1)
                {
                    decimal wperv = Convert.ToDecimal(dtgtruckin[18, idRowindex].Value.ToString());
                    string sql1 = "update tbtransport set kkperweigth=" + wperv + " Where idtran= '" + idtran + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();
                }
                else
                { MessageBox.Show("�س������Ѻ�Է���㹡������¹�ŧ��䢢����Ź��", "�Դ��Ҵ!", MessageBoxButtons.OK); }
            }

            CN.Close();
            ChecksumDTG();
        }

        private void dtgrpfstc_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idtran = dtgrpfstc[0, e.RowIndex].Value.ToString().Trim();
            idRowindex = e.RowIndex;
        }
                  
        private void cbtypereport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnquickview_Click(object sender, EventArgs e)
        {
            Frmqickview fqview = new Frmqickview();
            fqview.ShowDialog();
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
                    dtgsaleordertran[6, i].Value = DR2["bname"].ToString() + " " + DR2["baddress"].ToString() + " " + DR2["rd"].ToString() + " " + DR2["tumb"].ToString() + " " + DR2["country"].ToString() + " " + DR2["provice"].ToString() + " " + DR2["zipcode"].ToString();
                }
                DR2.Close();
            }

            CN.Close();
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
                        dtgpurordertran[2, i].Value = "Success";
                        dtgpurordertran.Rows[i].Cells[2].Style.BackColor = Color.FromArgb(215, 228, 188);
                    }

                    else if (DR1["idstatus"].ToString() == "7")
                    {
                        dtgpurordertran[2, i].Value = "Cancle";
                        dtgpurordertran.Rows[i].Cells[2].Style.BackColor = Color.FromArgb(242, 221, 220);
                        dtgpurordertran.Rows[i].Cells[2].Style.ForeColor = Color.Red;
                    }

                    else
                    {
                        dtgpurordertran[2, i].Value = "-";
                        dtgpurordertran.Rows[i].Cells[2].Style.BackColor = Color.FromArgb(242, 221, 220);
                    }
                }
                DR1.Close();

                string idselect = "";
                string sql2 = "select idtran  from tbpurchase where idpur = '" + dtgpurordertran[0, i].Value.ToString().Trim() + "'";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();

                DR2.Read();
                { idselect = DR2["idtran"].ToString().Trim(); }
                DR2.Close();


                int idcounttrans = 0; // �͡ʶҹл���
                string sql3 = "select count(idtran)as idcounttrans  from tbphysicalproduct where idtran = '" + idselect + "'";
                SqlCommand CM3 = new SqlCommand(sql3, CN);
                SqlDataReader DR3 = CM3.ExecuteReader();

                DR3.Read();
                { idcounttrans = Convert.ToInt16(DR3["idcounttrans"].ToString()); }
                DR3.Close();               

                if (idcounttrans != 0)
                {                   
                    dtgpurordertran[1, i].Value = "view";                  
                }

               else
                { 
                    dtgpurordertran[1, i].Value = "-"; 
                }
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
                        dtgsaleordertran[2, i].Value = "Success"; 
                        dtgsaleordertran.Rows[i].Cells[2].Style.BackColor = Color.FromArgb(215, 228, 188);
                    }

                    else if (DR1["idstatus"].ToString() == "7")
                    {
                        dtgsaleordertran[2, i].Value = "Cancle";
                        dtgsaleordertran.Rows[i].Cells[2].Style.BackColor = Color.FromArgb(242, 221, 220);
                        dtgsaleordertran.Rows[i].Cells[2].Style.ForeColor = Color.Red;
                    }

                    else { 
                        dtgsaleordertran[2, i].Value = "-"; 
                        dtgsaleordertran.Rows[i].Cells[2].Style.BackColor = Color.FromArgb(242, 221, 220); 
                    }
                }
                DR1.Close();

                string idselect = "";// �͡ʶҹл���
                string sql2 = "select idtran  from tborder where idorder = '" + dtgsaleordertran[0, i].Value.ToString().Trim() + "'";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();

                DR2.Read();
                { idselect = DR2["idtran"].ToString().Trim(); }
                DR2.Close();


                int idcounttrans = 0;
                string sql3 = "select count(idtran)as idcounttrans  from tbphysicalproduct where idtran = '" + idselect + "'";
                SqlCommand CM3 = new SqlCommand(sql3, CN);
                SqlDataReader DR3 = CM3.ExecuteReader();

                DR3.Read();
                { idcounttrans = Convert.ToInt16(DR3["idcounttrans"].ToString()); }
                DR3.Close();

                if (idcounttrans != 0)
                {
                    dtgsaleordertran[1, i].Value = "view";
                }

                else
                {
                    dtgsaleordertran[1, i].Value = "-";
                }
            }

            CN.Close();
        }

        private void Resetweigth()
        {
            win = 0;
            wout = 0;
            wdf = 0;
            wcus = 0;
            wsup = 0;
            wselect = 0;
            wnetdfcus = 0;
            wsupdfnet = 0;

            lbinformation.Text = "";        
        }

        private void DTpkST_ValueChanged(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            if (idmenu == 7)// ��§ҹ�Թ����ʵ�͡
            {
                if (cbmenusub2.SelectedIndex == 1)
                {
                    ds2.Clear();
                    startDreport();
                    dtgstock.DataSource = ds2;
                    string sql1 = "select * from vproductstock where stockdate='" + dtsum + "'";   
                    SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                    da1.Fill(ds2, "vstockdaysearch");
                    dtgstock.DataSource = ds2.Tables["vstockdaysearch"];
                    lbinformation.Text = "   Total: " + dtgstock.RowCount.ToString() + " Items";
                    cbbranch.Text = "�ٷ�����";
                }
            }
            CN.Close();
        }

        private void DTpkED_ValueChanged(object sender, EventArgs e)
        {
            if (idmenu == 7)//��§ҹ�Թ����ʵ�͡
            { 
                if (cbmenusub1.SelectedIndex == 0)//�ٷ��������Ẻ�����͹�
                {  
                    if (cbmenusub2.SelectedIndex == 2)//�١�õѴʵ�͡��Ш��ѹ�٨ҡ�������Ŵ�ҡ ��������Ъ���͡
                    {
                        SqlConnection CN = new SqlConnection();
                        CN.ConnectionString = Program.urldb;
                        CN.Open();
                        ds2.Clear();
                        startDreport(); endEreport();
                        string sql1 = "select * from vhistockday where (datehis BETWEEN '" + dtsum + "' AND '" + desum + "')";           

                        dtgstocksumday.DataSource = ds2;
                        SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                        da1.Fill(ds2, "vstockday");
                        dtgstocksumday.DataSource = ds2.Tables["vstockday"];
                        lbinformation.Text = "   Total: " + dtgstocksumday.RowCount.ToString() + " Items";
                        cbbranch.Text = "�ٷ�����";
                        Program.CN.Close();
                    }
                }

                lbinformation.Visible = true;
            }
        }

        private void lbinformation_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("W-In:��.���, W-Out:��.�͡, W-Net:��.�ط��, W-Sup:��.�ç�����, W-SupDefNet:��.��ҧ(�ç�����-�ط��), W-Cus:��.�١���, W-NetDefCus:��.��ҧ(�ط��-�١���), W-Select:��.���͡�Դ���, Total-Items:�ӹǹ�����ŷ����� ", lbinformation);
        }

        private void dtgpurordertran_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1 && dtgpurordertran[1, e.RowIndex].Value.ToString() != "-")
            {
                Frmphysicalproduct fspo = new Frmphysicalproduct();
                fspo.idrequest = dtgpurordertran[0, e.RowIndex].Value.ToString();
                fspo.idorder = 1;
                fspo.idstatus = 2;
                fspo.ShowDialog();
            }
        //    else { MessageBox.Show("No Data","Error"); }
        }

        private void dtgsaleordertran_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {           
                if (e.ColumnIndex == 1 && dtgsaleordertran[1, e.RowIndex].Value.ToString() != "-")
                {
                    Frmphysicalproduct fspo = new Frmphysicalproduct();
                    fspo.idrequest = dtgsaleordertran[0, e.RowIndex].Value.ToString();
                    fspo.idorder = 2;
                    fspo.idstatus = 2;
                    fspo.ShowDialog();
                }            
        }

        private void CheckUnlockpwd()
        {           
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            try
            {
                string sql2 = "SELECT Count(pwdunlock)as CountTrue FROM vunlockpwd WHERE idemplock ='" + Program.empID + "' AND idmenuunlock=" + idmenuunlock + "";
                SqlCommand CM5 = new SqlCommand(sql2, CN);
                SqlDataReader DR5 = CM5.ExecuteReader();
                DR5.Read();
                { pwdunlock = Convert.ToInt16(DR5["CountTrue"].ToString().Trim()); }
                DR5.Close();
            }
            catch
            { MessageBox.Show("user ���������Ѻ͹حҵ�㹡������¹�ŧ������", "�Դ��Ҵ !", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            CN.Close();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            LoadAllDatagrid();
        }
             
        
    }
}