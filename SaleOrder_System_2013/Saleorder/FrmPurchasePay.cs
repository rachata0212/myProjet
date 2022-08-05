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
    public partial class FrmPurchasePay : Form
    {
        public FrmPurchasePay()
        {
            InitializeComponent();
        }

        string desum;
        string dtsum;
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet ds5 = new DataSet();
        DataSet ds6 = new DataSet();
        DataSet ds7 = new DataSet();
        DataSet dsmenu = new DataSet();
        decimal disquota = 0;
        decimal pricesum = 0;
        string idbsup = "";
        decimal dcNow = 0;
        decimal dccut = 0;
        int countItems = 0;
        int idcheck = 0;
        decimal pricepur = 0;
        decimal weigthsup = 0;

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

        private void FrmPurchasePay_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            ds1.Clear();
            startDreport(); endEreport();
            string name = "";
            string idname = "";
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
                        
            if (cbmenu.SelectedIndex == 0)//งานชั่งเข้าคลัง
            {
                ds1.Clear();
                string sql2 = "select * from vWTrckinRP where (dateWbf BETWEEN '" + dtsum + "' AND '" + desum + "')";
                SqlDataAdapter da = new SqlDataAdapter(sql2, CN);
                da.Fill(ds1, "alltruckin");
                dtgtruckin.DataSource = ds1.Tables["alltruckin"];
                dtgtruckin.Visible = true; dtgtruckin.Dock = DockStyle.Fill;
                lbinformation.Text = dtgtruckin.RowCount.ToString(); cbcompany.Enabled = false; dtgtruckin.BringToFront();
            }

            if (cbmenu.SelectedIndex == 1)//งานซื้อ - ขาย [ส่งตรง]
            {
                string sql2 = "SELECT * FROM vWFsTCrp WHERE (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') order by datepur";
                ds2.Clear();
                SqlDataAdapter da = new SqlDataAdapter(sql2, CN);
                da.Fill(ds2, "fstc");
                dtgrpfstc.DataSource = ds2.Tables["fstc"];
                dtgrpfstc.Visible = true; dtgrpfstc.Dock = DockStyle.Fill;
                lbinformation.Text = dtgrpfstc.RowCount.ToString(); cbcompany.Enabled = false; dtgrpfstc.BringToFront();
            }

            if (cbmenu.SelectedIndex == 2)//ตรวจสอบ สถานะงานซื้อ
            {
                string sql1 = "select * from vpricepur where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') AND weigthsup <> 0 order by datepur";
                ds3.Clear();
                SqlDataAdapter da = new SqlDataAdapter(sql1, CN);
                da.Fill(ds3, "checkpurchase");
                dtgpricepur.DataSource = ds3.Tables["checkpurchase"];
                dtgpricepur.Visible = true; //dtgpricepur.Dock = DockStyle.Fill;
                lbinformation.Text = dtgpricepur.RowCount.ToString(); cbcompany.Enabled = false; dtgpricepur.BringToFront();   

                for (int i = 0; i < dtgpricepur.RowCount; i++)//For คำนวนหาข้อมูล
                {
                    string sql2 = "select pricepur,quatadicount from tbpricepur where idbranchSup = " + dtgpricepur[2, i].Value.ToString().Trim() + "";
                    SqlCommand CM1 = new SqlCommand(sql2, CN);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    {
                        try
                        {
                            idbsup = dtgpricepur[2, i].Value.ToString();
                            dtgpricepur[11, i].Value = DR1["pricepur"].ToString();
                            weigthsup = Convert.ToDecimal(dtgpricepur[10, i].Value.ToString().Trim());
                            pricepur = Convert.ToDecimal(dtgpricepur[11, i].Value.ToString().Trim());
                            pricesum = pricepur * weigthsup;
                            dtgpricepur[12, i].Value = pricesum.ToString();
                        }

                        catch { }
                    }
                    DR1.Close(); 
                }

                LoadBackdata1();
                CheckCutDiscount();
            }
            

            if (cbmenu.SelectedIndex == 3)//ตรวจสอบ สถานะงานขนส่ง
            {
                ////SELECT idbranch,(comsup +' จ. '+ provice) AS NameSup FROM vpurchase

                //string sql1 = "select DISTINCT idbsup,(comsup +' จ.'+ provicesup) AS NameSup from vpurchase where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') AND comsup is not null";
                //idname = "idbranch";
                //name = "NameSup";
                //SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                //da1.Fill(dsmenu, "checksup");
                //cbcompany.DataSource = dsmenu.Tables["checksup"];
                //cbcompany.DisplayMember = name;
            }

            if (cbmenu.SelectedIndex == 4)//ตรวจสอบ สถานะผู้จำหน่าย
            {
              //SELECT idbranch,(comsup +' จ. '+ provice) AS NameSup FROM vpurchase

                string sql1 = "select DISTINCT idbsup,(comsup +' จ.'+ provicesup) AS NameSup from vpurchase where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') AND comsup is not null";
                idname = "idbsup";
                name = "NameSup";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                da1.Fill(dsmenu, "checksup");
                cbcompany.DataSource = dsmenu.Tables["checksup"];
                cbcompany.ValueMember = idname;
                cbcompany.DisplayMember = name; 
            }

            if (cbmenu.SelectedIndex == 5)//ตรวจสอบ สถานะผู้รับขนส่ง
            {
                string sql1 = "select DISTINCT idbtran,(comtran +' จ.'+ provicetran) AS NameTran from vpurchase where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') AND comsup is not null";
                idname = "idbtran";
                name = "NameTran";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                da1.Fill(dsmenu, "checktran");
                cbcompany.DataSource = dsmenu.Tables["checktran"];
                cbcompany.ValueMember = idname;
                cbcompany.DisplayMember = name; 
            }    
        }

        private void CheckCutDiscount()
        {
            int rowindexdtg1 = 0;
            //int rouindexdtgpur = 0;

                for (int i = 0; i < dtgpricepur.RowCount; i++)
                {
                    try
                    {
                        for (int a = 0; a < dtgbackdata1.RowCount; a++)
                        {
                            rowindexdtg1 = a;
                            if (dtgpricepur[2, i].Value.ToString() == dtgbackdata1[1, a].Value.ToString())
                            {
                                if (dtgpricepur[5, i].Value.ToString() == dtgbackdata1[3, a].Value.ToString())
                                {
                                    decimal qoutanow = Convert.ToDecimal(dtgbackdata1[5, a].Value.ToString().Trim());
                                    decimal pricenow = Convert.ToDecimal(dtgpricepur[12, i].Value.ToString());


                                    if (qoutanow > pricenow)
                                    {
                                        dtgpricepur[13, i].Value = Convert.ToString(Convert.ToDecimal(dtgbackdata1[5, a].Value.ToString()) - Convert.ToDecimal(dtgpricepur[12, i].Value.ToString()));
                                        dtgbackdata1[5, a].Value = dtgpricepur[13, i].Value.ToString().Trim();

                                        if (Convert.ToDecimal(dtgpricepur[13, i].Value.ToString().Trim()) < 50000)
                                        { dtgpricepur.Rows[i].Cells[13].Style.BackColor = Color.Khaki; }
                                    }

                                    else
                                    {
                                        SqlConnection CN = new SqlConnection();
                                        CN.ConnectionString = Program.urldb;
                                        CN.Open(); int CheckSPO = 0;
                                        string sql2 = "select count(idbranchSup)as CheckSPO from tbpricepur where idbranchSup = " + dtgpricepur[2, i].Value.ToString().Trim() + " and   idcompur = '" + dtgpricepur[5, i].Value.ToString().Trim() + "' AND quatadicount <> 0 ";
                                        SqlCommand CM1 = new SqlCommand(sql2, CN);
                                        SqlDataReader DR1 = CM1.ExecuteReader();

                                        DR1.Read();
                                        {
                                            CheckSPO = Convert.ToInt16(DR1["CheckSPO"].ToString().Trim());
                                        }
                                        DR1.Close();

                                        if (CheckSPO > 1)
                                        {
                                            MessageBox.Show("count > 1");
                                            ds7.Clear();
                                            string sql1 = "select idpricepur,idbranchsup,idcompur,pricepur,quatadicount from tbpricepur where idbranchSup = " + dtgpricepur[2, i].Value.ToString().Trim() + " and   idcompur = '" + dtgpricepur[5, i].Value.ToString().Trim() + "' AND quatadicount <> 0 ";
                                            ds7.Clear();
                                            SqlDataAdapter da7 = new SqlDataAdapter(sql1, CN);
                                            da7.Fill(ds7, "over2column");
                                            dtgbackdata2.DataSource = ds7.Tables["over2column"];





                                        }




                                        dtgbackdata1.Rows[a].DefaultCellStyle.BackColor = Color.Khaki;
                                        dtgpricepur.Rows[i].Cells[13].Style.BackColor = Color.Coral;
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {

                        dtgpricepur.Rows[i].Cells[13].Style.BackColor = Color.Coral; dtgbackdata1.Rows[rowindexdtg1].DefaultCellStyle.BackColor = Color.Coral;

                        decimal dicountIngrid = 0;//เงินมัดจำคงเหลือ
                        decimal discprict = 0;   //ราคาซื้อที่จะซื้อแต่เงินมัดจำไม่พอ
                        decimal distotal = 0; //เป็นราคาที่ต้องซื้อ
                        decimal dispriceold = 0; 

                        dicountIngrid = Convert.ToDecimal(dtgpricepur[13, i].Value.ToString().Trim());//เงินมัดจำคงเหลือ
                        discprict = Convert.ToDecimal(dtgpricepur[11, i].Value.ToString().Trim());   //ราคาซื้อที่จะซื้อแต่เงินมัดจำไม่พอ
                        distotal = dicountIngrid / discprict; //เป็นราคาที่ต้องซื้อ
                        dispriceold = Convert.ToDecimal(dtgpricepur[10, i].Value.ToString().Trim()) - distotal; //ราคาที่เหลือจากเอาราคาที่เงินคงเหลือตั้ง ลบด้วยราคาซื้ออันไหม่

                        MessageBox.Show("dispricole plus" + dispriceold.ToString());






                    }
            }          

        }

        private void LoadBackdata1()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();            
            ds6.Clear();

            string sql6 = "select  DISTINCT '' as Idpricepur,idbsup,comsup,idcpur,compur,'' as Quota  from  vpricepur where (datepur BETWEEN '" + dtsum + "' AND '" + desum + "') AND comsup is not null";            
            SqlDataAdapter da6 = new SqlDataAdapter(sql6, CN);
            da6.Fill(ds6, "loadback1");
            dtgbackdata1.DataSource = ds6.Tables["loadback1"];

            for (int i = 0; i < dtgbackdata1.RowCount; i++)
            {
                string sql2 = "select idpricepur,quatadicount from tbpricepur where idbranchSup = " + dtgbackdata1[1, i].Value.ToString().Trim() + " AND idcomPur = '" + dtgbackdata1[3, i].Value.ToString().Trim() + "' ";
                SqlCommand CM1 = new SqlCommand(sql2, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    try
                    {
                        dtgbackdata1[0, i].Value = DR1["idpricepur"].ToString();
                        dtgbackdata1[5, i].Value = DR1["quatadicount"].ToString();
                    }
                    catch { }
                }
                DR1.Close();  
            
            }
        }

        private void LoadSupdata()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (cbmenu.SelectedIndex == 4)//load sup
            {
             
            }

            if (cbmenu.SelectedIndex == 5)//load tran
            {

            }
        }
       
        private void btnsetting_Click(object sender, EventArgs e)
        {
            FrmPurpaysetting fppst = new FrmPurpaysetting();
            fppst.ShowDialog();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbmenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbcompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSupdata();
        }

        private void btnst1_Click(object sender, EventArgs e)
        {

        }

        private void btnviewer_Click(object sender, EventArgs e)
        {

        }

       
    }
}
