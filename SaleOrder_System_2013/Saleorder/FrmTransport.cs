using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace SaleOrder
{
    public partial class FrmTransport : Form
    {
        public FrmTransport()
        {
            InitializeComponent();
        }

                string viewpath = "";
                string checkweigth = "";
                dtssaleorder dssearch = new dtssaleorder(); 
                DataSet ds = new DataSet(); 
                DataSet ds1 = new DataSet(); 
                string idtranno = "0"; 
                string msnfrom = ""; 
                int idtypelog = 0; 
                string idorder = "0"; 
                string idcus = "0"; 
                string idpur = "0";         
                string idcancletran = ""; 
                int idcheck = 0; 
                string namestatus = "";
                string selectdatehistruck = "";
                string datelog = DateTime.Now.Day.ToString();
                string monthlog = DateTime.Now.Month.ToString();
                string yearlog = DateTime.Now.Year.ToString();

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }               
        
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
                   Program.comport = DR["Portno"].ToString().Trim();
                   Program.baudrate = DR["BaudRate"].ToString().Trim();
                   Program.databit = Convert.ToInt16(DR["DataBit"].ToString().Trim());
                   Program.parity = DR["Parity"].ToString().Trim();
                   Program.stopbit = DR["StopBit"].ToString().Trim();
                   Program.stkeychar = Convert.ToInt16(DR["StKeychar"].ToString().Trim());
                   Program.UnitKeyRecive = Convert.ToInt16(DR["UnitKeyRecive"].ToString().Trim());
                   Program.Selectline = Convert.ToInt16(DR["Selectline"].ToString().Trim());
                }
                DR.Close();
                CN.Close();
            }
            catch (Exception ex)
            { MessageBox.Show("สาขานี้ไม่ได้เซ็ตตาชั่งไว้ กรุณาตั้งค่าการรับข้อมูลจากตาชั่ง", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void FrmTransport_Load(object sender, EventArgs e)
        {
            label2.Text = "ประจำวันที่ " + DateTime.Now.ToShortDateString();
            ds.Clear();
            dssearch.Clear();

            string date = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            sumdate = month + "/" + date + "/" + year;

            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
         
            LoadGridFsTctruck();   // for datagrid purchase to sale

            msnfrom = this.Name.ToString();
            idtypelog = 7;//open
            Savelogevent();
            txtcount.Text = dtgtranreplyFsTcPass.RowCount.ToString();
            LoadTrckConfig();
            CN.Close();
        }

        private static string Loadsumdate()
        {
            string date = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string sumdate = month + "/" + date + "/" + year;
            return sumdate;
        }

        private void DateHistoryNow()
        {
            string date = dtpselecttruck.Value.Day.ToString();
            string month = dtpselecttruck.Value.Month.ToString();
            string year = dtpselecttruck.Value.Year.ToString();
            selectdatehistruck = year + "/" + month + "/" + date;            
        }

        private void LoadGridFsTctruck()
        {
            DataSet ds4 = new DataSet(); dtssaleorder dssearch4 = new dtssaleorder();
            ds4.Clear(); dssearch4.Clear();
            dtgtranreplyFsTcPass.DataSource = dssearch4;
            string date = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string sumdate = month + "/" + date + "/" + year;

            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql4 = "SELECT * FROM vtranreplyFsTc WHERE idtruck <> 5 AND idtruck <> 3 AND idbranch=" + Program.idbranch + " order by senddate desc";

            SqlDataAdapter da4 = new SqlDataAdapter(sql4, CN);
            da4.Fill(ds4, "vtr");
            dtgtranreplyFsTcPass.DataSource = ds4.Tables["vtr"];

            for (int i = 0; i < dtgtranreplyFsTcPass.RowCount; i++)
            {
                if (dtgtranreplyFsTcPass[2, i].Value.ToString() == "นน.ผ่านตาชั่งเบา")
                { dtgtranreplyFsTcPass.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(216, 215, 216); }

                else
                { dtgtranreplyFsTcPass.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(215, 228, 188); }
            }
            CN.Close();
        }

        string sumdate = "";
        private void LoadTabHistoryFsTctruck()
        {
            DataSet ds4 = new DataSet(); dtssaleorder dssearch4 = new dtssaleorder();
            ds4.Clear(); dssearch4.Clear();
            dtghispurtosale.DataSource = dssearch4;           

            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql4 = "SELECT * FROM vtranreplyFsTc WHERE idtruck = 3 AND idbranch=" + Program.idbranch + " order by senddate desc";
            SqlDataAdapter da4 = new SqlDataAdapter(sql4, CN);
            da4.Fill(ds4, "vtr");
            dtghispurtosale.DataSource = ds4.Tables["vtr"];

            for (int i = 0; i < dtghispurtosale.RowCount; i++)
            {
                if (dtghispurtosale[2, i].Value.ToString() == "นน.ผ่านตาชั่งเบา")
                {
                    dtghispurtosale.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(216, 215, 216);
                }
                else
                {
                    dtghispurtosale.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(215, 228, 188);
                }
            }
            CN.Close();
        }

        private void LoadTabHistoryTruckin(SqlConnection CN)
        {
            ds.Clear(); dssearch.Clear();
            dtghistorytruckin.DataSource = dssearch; string sql3 = "";       

            if (cbselectalltruck.Checked == true)
            {
                sql3 = "select * from vWeigthTruckin  where idbranch=" + Program.idbranch + " AND idtranauto IS NOT NULL order by idtranauto desc"; dtpselecttruck.Enabled = false;
            }
            else
            {
                DateHistoryNow();
                sql3 = "select * from vWeigthTruckin  where idbranch=" + Program.idbranch + " AND dateWbf = '" + selectdatehistruck + "' AND idtranauto IS NOT NULL order by idtranauto desc";
            }

            SqlDataAdapter da3 = new SqlDataAdapter(sql3, CN);
            da3.Fill(ds, "vhistruckin");
            dtghistorytruckin.DataSource = ds.Tables["vhistruckin"];
            txtcount.Text = dtghistorytruckin.RowCount.ToString();
        }

        private void LoadTabHistoryTruckOut(SqlConnection CN)
        {
            ds.Clear(); dssearch.Clear();
            dtghistorytruckOut.DataSource = dssearch; string sql3 = "";

            if (cbselectalltruck.Checked == true)
            {
                sql3 = "select * from vWeigthTruckout  where idbranch =" + Program.idbranch + " AND idtranauto IS NOT NULL order by idtranauto desc"; dtpselecttruck.Enabled = false;
            }
            else
            {
                DateHistoryNow();
                sql3 = "select * from vWeigthTruckout  where idbranch =" + Program.idbranch + " AND dateWaf ='" + selectdatehistruck + "' AND idtranauto IS NOT NULL order by idtranauto desc";
            }

            SqlDataAdapter da3 = new SqlDataAdapter(sql3, CN);
            da3.Fill(ds, "vhistruckout");
            dtghistorytruckOut.DataSource = ds.Tables["vhistruckout"];
            txtcount.Text = dtghistorytruckOut.RowCount.ToString();            
        }

        private void FrmTransport_FormClosed(object sender, FormClosedEventArgs e)
        {
            msnfrom = this.Name.ToString();
            idtypelog = 6;//close
            Savelogevent();
        }

        private void Savelogevent()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string selectdatelog = monthlog + "/" + datelog + "/" + yearlog;
            string sql1 = "insert into tblog(logname,datein,timein,idtypelog,idemp,remark) values('" + msnfrom + "','" + selectdatelog + "','" + DateTime.Now.ToLongTimeString() + "'," + idtypelog + ",'" + Program.empID + "','" + idtranno + "')";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            CM1.ExecuteNonQuery();
            CN.Close();
        }

        private void dtgjobholetruckin_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (e.RowIndex < 0) return;

            string sql = "select idpur from tbpurchase where idtran='" + dtgjobholetruckin[0, e.RowIndex].Value.ToString() + "'";
            SqlCommand CM = new SqlCommand(sql, CN);
            SqlDataReader DR = CM.ExecuteReader();

            DR.Read();
            { idpur = Convert.ToString(DR["idpur"].ToString()); }
            DR.Close();

            Frmtruckin fti = new Frmtruckin();
            if (dtgjobholetruckin[1, e.RowIndex].Value.ToString().Trim() == "ชั่งรถหนัก")
            { fti.statustruck = 0; }
            else { fti.statustruck = 1; }
            fti.idpur = idpur;
            fti.idtran = Convert.ToString(dtgjobholetruckin[0, e.RowIndex].Value.ToString());
            fti.ShowDialog();

            LoadTabPurchase(CN);
            CN.Close();
        }

        private void dtgpurordertran_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void dtgpurordertran_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //SqlConnection CN = new SqlConnection();
            //CN.ConnectionString = Program.urldb;
            //CN.Open();
            //string sql;

            DialogResult answer;
            answer = MessageBox.Show("คุณต้องการย้ายสินค้าเข้าสต๊อกใช่หรือไม่ !", "กรุณายืนยัน !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (answer == DialogResult.OK)
            {
                //sql = "select idtran from tbpurchase where idpur='" + dtgpurordertran[0, e.RowIndex].Value.ToString() + "'";
                //SqlCommand CM = new SqlCommand(sql, CN);
                //SqlDataReader DR = CM.ExecuteReader();

                //DR.Read();
                //{
                //    idtranno = Convert.ToString(DR["idtran"].ToString());
                //}
                //DR.Close();

                ////ส่งค่าเพื่อไปใส่น้ำหนักต้นทาง
                ////FrmWeigthbeforetruckin fwbfti = new FrmWeigthbeforetruckin();
                ////fwbfti.idtran = idtranno;               
                ////fwbfti.fromweigth = "purchas";
                ////fwbfti.idpur = dtgpurordertran[0, e.RowIndex].Value.ToString();
                ////fwbfti.datewbf = dtgpurordertran[1, e.RowIndex].Value.ToString();
                ////fwbfti.ShowDialog();

                ////if (Program.idstatus == 1)
                ////{
                //Frmtruckin fti = new Frmtruckin();//ใส่น้ำหนักชั่งเข้า
                //fti.idpur = dtgpurordertran[0, e.RowIndex].Value.ToString();
                //fti.idtran = idtranno;
                //fti.ShowDialog();//bug
                //}               
            }

            else
            {
                MessageBox.Show("คุณไม่ได้ระบุบน้ำหนักต้นทาง", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //LoadTabPurchase(CN);
        }

        private void dtgjobholetruckin_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); string idpur = "0";
            string sql;

            sql = "select idpur from tbpurchase where idtran=" + dtgjobholetruckin[0, e.RowIndex].Value.ToString() + "";
            SqlCommand CM = new SqlCommand(sql, CN);
            SqlDataReader DR = CM.ExecuteReader();

            DR.Read();
            {
                idpur = Convert.ToString(DR["idpur"].ToString());
            }
            DR.Close();

            Frmtruckin fti = new Frmtruckin();
            fti.idpur = idpur;
            fti.idtran = Convert.ToString(dtgjobholetruckin[0, e.RowIndex].Value.ToString());
            fti.statustruck = 1;
            fti.ShowDialog();


            //string sumdate = Loadsumdate();
           // LoadTabPurchase(CN);/
            //LoadTabSaleOrder(CN, sumdate);
            CN.Close();
        }

        private void dtgsaleordertran_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //SqlConnection CN = new SqlConnection();
            //CN.ConnectionString = Program.urldb;
            //CN.Open();
            //string sql;

            DialogResult answer;
            answer = MessageBox.Show("คุณต้องการส่งสินค้าใช่หรือไม่ !", "กรุณายืนยัน !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (answer == DialogResult.OK)
            {
                ////string date = DateTime.Now.Day.ToString();
                ////string month = DateTime.Now.Month.ToString();
                ////string year = DateTime.Now.Year.ToString();
                ////string sumdate = month + "/" + date + "/" + year; 

                //sql = "select idtran from tborder where idorder='" + dtgsaleordertran[0, e.RowIndex].Value.ToString() + "'";
                //SqlCommand CM = new SqlCommand(sql, CN);
                //SqlDataReader DR = CM.ExecuteReader();

                //DR.Read();
                //{
                //    idtranno = Convert.ToString(DR["idtran"].ToString());
                //}
                //DR.Close();

                //Frmtruckout fti = new Frmtruckout();//ขึ้นชั่งรถเบา
                //fti.idorder = Convert.ToString(dtgsaleordertran[0, e.RowIndex].Value.ToString());
                //fti.statustruck = 0;
                //fti.idtran = idtranno;
                //fti.ShowDialog();

                //string sumdate = Loadsumdate();
                //LoadTabSaleOrder(CN, sumdate);

            }
        }

        private void dtgholetruckout_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); //ds.Clear(); dssearch.Clear(); 
            //int weigthaf = 0;           

            //try
            //{
            if (e.RowIndex < 0) return;


                if (dtgholetruckout[1, e.RowIndex].Value.ToString() == "ชั่งรถเบา" || dtgholetruckout[1, e.RowIndex].Value.ToString() == "ชั่งรถหนัก")
                {
                    string sql = "select idorder,idcomcus from tborder where idtran='" + dtgholetruckout[0, e.RowIndex].Value.ToString() + "'";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    SqlDataReader DR = CM.ExecuteReader();

                    DR.Read();
                    {
                        idorder = Convert.ToString(DR["idorder"].ToString());
                        idcus = Convert.ToString(DR["idcomcus"].ToString());
                    }
                    DR.Close();

                    Frmtruckout fto = new Frmtruckout();//ขึ้นชั่งรถหนัก
                    fto.idtran = Convert.ToString(dtgholetruckout[0, e.RowIndex].Value.ToString());
                    fto.idcus = idcus;
                    fto.idorder = idcancletran;
                    if (dtgholetruckout[1, e.RowIndex].Value.ToString().Trim() == "ชั่งรถเบา")//งานชั่งรถหนักออกส่งลูกค้า
                    { fto.statustruck = 0; }
                    if (dtgholetruckout[1, e.RowIndex].Value.ToString().Trim() == "ชั่งรถหนัก")//งานชั่งรถหนักออกส่งลูกค้า
                    { fto.statustruck = 2; fto.weigthbf = Convert.ToDecimal(dtgholetruckout[9, e.RowIndex].Value.ToString()); }
                    fto.ShowDialog();
                }

                else if (dtgholetruckout[1, e.RowIndex].Value.ToString().Trim() == "รอน้ำหนักลูกค้า")// ส่งน้ำหนักปลายทาง
                {
                    FrmWeigthbeforetruckin fwei = new FrmWeigthbeforetruckin();
                    fwei.fromweigth = "salecus";                   
                    fwei.idtran = Convert.ToString(dtgholetruckout[0, e.RowIndex].Value.ToString().Trim());
                    fwei.ShowDialog();
                }

                ds1.Clear(); dssearch.Clear(); ds.Clear();
                string sumdate = Loadsumdate();
                LoadTabSale(CN);
            //}
            //catch (Exception ex)
            //{ MessageBox.Show(ex.Message); }
                CN.Close();
        }

        private void dtgtranreplyFsTcPass_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {            
                if (dtgtranreplyFsTcPass[1, e.RowIndex].Value.ToString() == "ระหว่างเดินทาง" || dtgtranreplyFsTcPass[1, e.RowIndex].Value.ToString() == "ถึงปลายทางแล้ว")
                {
                    FrmInsertweigth finw = new FrmInsertweigth();
                    finw.idtran = dtgtranreplyFsTcPass[0, e.RowIndex].Value.ToString();
                    finw.valuereturn = dtgtranreplyFsTcPass[2, e.RowIndex].Value.ToString();
                    finw.ShowDialog();
                    LoadGridFsTctruck();//udate grid               
                }

                if (dtgtranreplyFsTcPass[11, e.RowIndex].Value.ToString() == "0")//นน.ชั่งหนักรถเข้า
                {
                    Frmtruckin fti = new Frmtruckin();
                    fti.statustruck = 2;

                    fti.idtran = Convert.ToString(dtgtranreplyFsTcPass[0, e.RowIndex].Value.ToString());
                    fti.ShowDialog();
                    LoadGridFsTctruck();
                }

                else if (dtgtranreplyFsTcPass[1, e.RowIndex].Value.ToString() == "ชั่งรถเบา")//คือชั่งหนัก
                {
                    FromInsertdate fisd = new FromInsertdate();
                    fisd.status = "2";
                    fisd.idtran = Convert.ToString(dtgtranreplyFsTcPass[0, e.RowIndex].Value.ToString().Trim());
                    fisd.ShowDialog();

                    if (fisd.status == "1")
                    {
                        Frmtruckout fti = new Frmtruckout();//ขึ้นชั่งรถเบา
                        fti.idtran = Convert.ToString(dtgtranreplyFsTcPass[0, e.RowIndex].Value.ToString().Trim());
                        fti.weigthbf = Convert.ToInt32(dtgtranreplyFsTcPass[11, e.RowIndex].Value.ToString().Trim());//นน.ต้นทาง
                        fti.weigthaf = Convert.ToInt32(dtgtranreplyFsTcPass[12, e.RowIndex].Value.ToString().Trim());//นน.ชั่งหนักเข้า
                        fti.statustruck = 3;
                        fti.ShowDialog();
                        LoadGridFsTctruck();
                    }
                    else
                    {
                        MessageBox.Show("คุณไม่ได้ระบุวันที่ขึ้นสินค้า !", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }              
            }

            else
            {
                MessageBox.Show("รายการนี้ได้ปิดงานแล้ว", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); 
            string sumdate = Loadsumdate();
            cbselectalltruck.Enabled = false;
            dtpselecttruck.Enabled = false;

            if (tabControl1.SelectedIndex == 0)
            {
                LoadGridFsTctruck();
                btnreprint.Enabled = true;   
                bntchagecar.Enabled = false;
                cbsentweigth.Enabled = false;
                btnmaps.Enabled = false;
            }

            if (tabControl1.SelectedIndex == 1)
            {
                LoadTabPurchase(CN);
                bntchagecar.Enabled = false;
                btnreprint.Enabled = false;
                cbsentweigth.Enabled = false;
                txtcolor1.BackColor = Color.FromArgb(214, 228, 188);
                txtcolor2.BackColor = Color.FromArgb(216, 216, 216);
                btnmaps.Enabled = false;
            }

            if (tabControl1.SelectedIndex == 2)
            {
                LoadTabSale(CN);
                bntchagecar.Enabled = false;
                btnreprint.Enabled = false;
                cbsentweigth.Enabled = true;
                btnmaps.Enabled = true;
            }

            if (tabControl1.SelectedIndex == 3)
            {
                LoadTabHistoryTruckin(CN);
                bntchagecar.Enabled = false; 
                btnreprint.Enabled = true;
                btncancletran.Enabled = true;
                cbsentweigth.Enabled = false;
                btnmaps.Enabled = false;
                dtpselecttruck.Enabled = true;
                cbselectalltruck.Enabled = true;
                if (cbselectalltruck.Checked == true)
                {dtpselecttruck.Enabled = false;} 
            }

            if (tabControl1.SelectedIndex == 4)
            {
                LoadTabHistoryTruckOut(CN);
                bntchagecar.Enabled = true;
                btnreprint.Enabled = true;
                btncancletran.Enabled = true;
                cbsentweigth.Enabled = false;
                btnmaps.Enabled = true;
                dtpselecttruck.Enabled = true;
                cbselectalltruck.Enabled = true;
                if (cbselectalltruck.Checked == true)
                { dtpselecttruck.Enabled = false; } 
            }
            if (tabControl1.SelectedIndex == 5)
            {
                LoadTabHistoryFsTctruck();
                bntchagecar.Enabled = false;
                btnreprint.Enabled = true;
                btncancletran.Enabled = true;
                cbsentweigth.Enabled = false;
                btnmaps.Enabled = false;
            }
            CN.Close();
        }        

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sumdate = Loadsumdate();

            if (tabControl1.SelectedIndex == 1)
            {
              //  LoadTabPurchase(CN);
            }

            if (tabControl1.SelectedIndex == 2)
            {
          //      LoadTabSaleOrder(CN, sumdate);
            }

            if (tabControl1.SelectedIndex == 3)
            {
                LoadTabSale(CN);
            }

            if (tabControl1.SelectedIndex == 4)
            {
                LoadTabHistoryTruckin(CN);
            }

            if (tabControl1.SelectedIndex == 5)
            {
                LoadTabHistoryTruckOut(CN);
            }
            CN.Close();
        }
        
        private void btnreprint_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                Frmselect_printtruck frpt = new Frmselect_printtruck();
                frpt.idtran = idreprint;
                frpt.ShowDialog();
            }
            if (tabControl1.SelectedIndex == 3)
            {
                Frmreporttruck frpt = new Frmreporttruck();
                frpt.idtran = idreprint;
                frpt.typetruck = "truckin";
                frpt.ShowDialog();
            }

            if (tabControl1.SelectedIndex == 4)
            {
                Frmreporttruck frpt = new Frmreporttruck();
                frpt.idtran = idreprint;
                frpt.typetruck = "truckout";
                frpt.ShowDialog();         

            }

            if (tabControl1.SelectedIndex == 5)
            {
                Frmselect_printtruck frpt = new Frmselect_printtruck();
                frpt.idtran = idreprint;
                frpt.ShowDialog();
            }            
        }

        string idreprint = "";
    
        private void dtghistorytruckin_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idreprint = dtghistorytruckin[13, e.RowIndex].Value.ToString();
        }

        private void dtghistorytruckOut_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idreprint = dtghistorytruckOut[13, e.RowIndex].Value.ToString();
            idcancletran = idreprint;                    
            idcheck = 3; bntchagecar.Enabled = true;
        }
                
        private void bntchagecar_Click(object sender, EventArgs e)
        {
             string sumdate = Loadsumdate();
             SqlConnection CN = new SqlConnection();
             CN.ConnectionString = Program.urldb;
             CN.Open();

              if (idcancletran != "" && idcheck == 0)//change idpro fs to c
            {
                Frmchangdata fdc = new Frmchangdata();
                fdc.idtranno = idcancletran;
                fdc.idordermenu = 1;
                fdc.idbranch =Convert.ToInt16(Program.idbranch);
                fdc.ShowDialog();
                 LoadGridFsTctruck(); 
            }


            if (idcancletran != "" && idcheck == 1)//change purchase
            {
                Frmchangdata fdc = new Frmchangdata();
                fdc.idtranno = idcancletran;
                fdc.idordermenu = 1;
                fdc.idbranch =Convert.ToInt16(Program.idbranch);
                fdc.ShowDialog();
                LoadTabPurchase(CN); 
            }

            if (idcancletran != "" && idcheck == 2)//change sale
            {
                Frmchangdata fdc = new Frmchangdata();
                fdc.idtranno = idcancletran;
                fdc.idordermenu = 2;
                fdc.idbranch = Convert.ToInt16(Program.idbranch);
                fdc.ShowDialog();
                LoadTabSale(CN); 
            }

            if (idcancletran != "" && idcheck == 3)//change history order
            {
                Frmchangdata fdc = new Frmchangdata();
                fdc.idtranno = idcancletran;
                fdc.idordermenu = 3;
                fdc.idbranch = Convert.ToInt16(Program.idbranch);
                fdc.ShowDialog();
                LoadTabHistoryTruckOut(CN);
            }
            CN.Close();                                  
        }

        private void btncancletran_Click(object sender, EventArgs e)
        {
            Frmconfirmpwdchagedata conf = new Frmconfirmpwdchagedata();
            if (idcheck == 0)
            { conf.idmenuunlock = 20; }
            if (idcheck == 1)
            { conf.idmenuunlock = 21; }
            if (idcheck == 2)
            { conf.idmenuunlock = 22; }
            conf.idcancle = idcancletran;
            conf.ShowDialog();

            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            LoadGridFsTctruck();
            LoadTabPurchase(CN);
            LoadTabSale(CN);
            CN.Close();
        }

        private void dtgpurordertran_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex < 0) return;
            //idcancletran = dtgpurordertran[0, e.RowIndex].Value.ToString();//id purchase
            //bntchagecar.Enabled = true; btncancletran.Enabled = true;
            //idcheck = 1;
        }

        private void dtgjobholetruckin_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return; //purchase truck in
            idcancletran = dtgjobholetruckin[0, e.RowIndex].Value.ToString();            
            bntchagecar.Enabled = true; btncancletran.Enabled = true;
            idcheck = 1;
        }

        private void dtgsaleordertran_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex < 0) return;//sale truck out            
            //idcancletran = dtgsaleordertran[0, e.RowIndex].Value.ToString();//id saleorder
            //bntchagecar.Enabled = true; btncancletran.Enabled = true;
            //idcheck = 2;
        }
        
        private void dtgholetruckout_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idreprint = dtgholetruckout[0, e.RowIndex].Value.ToString();
            idcancletran = dtgholetruckout[0, e.RowIndex].Value.ToString();
            namestatus = dtgholetruckout[2, e.RowIndex].Value.ToString().Trim();
            checkweigth = dtgholetruckout[8, e.RowIndex].Value.ToString().Trim();
            idcheck = 2; bntchagecar.Enabled = true;
            if (checkweigth == "0")
            { btncancletran.Enabled = true; }
            else { btncancletran.Enabled = false; }            
        }

        private void LoadTabPurchase(SqlConnection CN)
        {
            ds.Clear(); dssearch.Clear(); ds.Clear();
            dtgjobholetruckin.DataSource = dssearch;
            string sql3 = "select * from vonholetruckinFrombrach where idbranch=" + Program.idbranch + " AND idstatus <> 7 AND remark3 !='รับสินค้าแล้ว' order by datepur desc";
            SqlDataAdapter da3 = new SqlDataAdapter(sql3, CN);
            da3.Fill(ds, "vjobholein");
            dtgjobholetruckin.DataSource = ds.Tables["vjobholein"];
            for (int i = 0; i < dtgjobholetruckin.RowCount; i++)
            {               
                if (dtgjobholetruckin[1, i].Value.ToString().Trim() == "ชั่งรถเบา")
                { dtgjobholetruckin.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(216, 216, 216); }
                if (dtgjobholetruckin[1, i].Value.ToString().Trim() == "ชั่งรถหนัก")
                { dtgjobholetruckin.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(242, 221, 220); }
            }
        }

        private void LoadTabSale(SqlConnection CN)
        {
            ds1.Clear(); dssearch.Clear();
            dtgholetruckout.DataSource = dssearch;
string sql4="";
            if (cbsentweigth.Checked == true)
            { sql4 = "select * from vonholetruckoutFrombrach where idbranch=" + Program.idbranch + " AND idstatus <> 7 AND remark3 !='ส่งสินค้าแล้ว' AND remark3 ='รอน้ำหนักลูกค้า' order by orderdate desc"; }

            if (cbsentweigth.Checked == false)
            { sql4 = "select * from vonholetruckoutFrombrach where idbranch=" + Program.idbranch + " AND idstatus <> 7 AND remark3 !='ส่งสินค้าแล้ว' AND remark3 !='รอน้ำหนักลูกค้า' order by orderdate desc "; }

            //string sql4 = "select * from vonholetruckoutFiltter where idtruck <> 3 and idbranch=112 ";
            if (sql4 != "")
            {
                SqlDataAdapter da4 = new SqlDataAdapter(sql4, CN);
                da4.Fill(ds1, "vjobholeout");
                dtgholetruckout.DataSource = ds1.Tables["vjobholeout"];
                txtcount.Text = dtgholetruckout.RowCount.ToString();

                for (int i = 0; i < dtgholetruckout.RowCount; i++)
                {
                    if (dtgholetruckout[1, i].Value.ToString().Trim() == "ชั่งรถเบา")
                    { dtgholetruckout.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(216, 216, 216); }
                    if (dtgholetruckout[1, i].Value.ToString().Trim() == "ชั่งรถหนัก")
                    { dtgholetruckout.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(242, 221, 220); }
                }
            }
        }

        private void dtgtranreplyFsTcPass_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idreprint = dtgtranreplyFsTcPass[0, e.RowIndex].Value.ToString(); bntchagecar.Enabled = true;
            idcancletran = dtgtranreplyFsTcPass[0, e.RowIndex].Value.ToString(); idcheck = 0;
        }

        private void dtghispurtosale_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idreprint = dtghispurtosale[0, e.RowIndex].Value.ToString();
        }

        private void cbsentweigth_CheckedChanged(object sender, EventArgs e)
        {
            if (cbsentweigth.Checked == true || cbsentweigth.Checked == false)
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();
                LoadTabSale(CN);
                CN.Close();
            }
        }

        private void btnmaps_Click(object sender, EventArgs e)
        {
            //1. select idcomcus where idrepint
            //2. select url view file where idcomcus
            //3. startup application process where filetype
            string idcomcus = "";

            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); string sql1 = "";
            if (tabControl1.SelectedIndex == 2)
            {
                sql1 = "select idcomcus from vonholetruckoutFrombrach where idtran='" + idreprint + "'";
            }
            if (tabControl1.SelectedIndex == 4)
            { sql1 = "select idcomcus from vWeigthTruckout where idtran='" + idreprint + "'"; }
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

        private void dtpselecttruck_ValueChanged(object sender, EventArgs e)
        {
            string startdate = dtpselecttruck.Value.Day.ToString();
            string startmount =dtpselecttruck.Value.Month.ToString();
            string startyear = dtpselecttruck.Value.Year.ToString();
            string datesearch = startyear + "/" + startmount + "/" + startdate;
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); cbselectalltruck.Checked = false;

            if (tabControl1.SelectedIndex == 3)
            {
                ds.Clear(); dssearch.Clear();
                dtghistorytruckin.DataSource = dssearch;
                string sql3 = "select * from vWeigthTruckin  where idbranch=" + Program.idbranch + " AND dateWbf ='" + datesearch + "' AND idtranauto IS NOT NULL order by idtranauto desc";
                SqlDataAdapter da3 = new SqlDataAdapter(sql3, CN);
                da3.Fill(ds, "vhistruckin");
                dtghistorytruckin.DataSource = ds.Tables["vhistruckin"];
                txtcount.Text = dtghistorytruckin.RowCount.ToString();    
            }

            if (tabControl1.SelectedIndex == 4)
            {
                ds.Clear(); dssearch.Clear();
                dtghistorytruckOut.DataSource = dssearch;
                string sql3 = "select * from vWeigthTruckout  where idbranch=" + Program.idbranch + " AND dateWaf ='" + datesearch + "' AND idtranauto IS NOT NULL order by idtranauto desc";
                SqlDataAdapter da3 = new SqlDataAdapter(sql3, CN);
                da3.Fill(ds, "vhistruckout");
                dtghistorytruckOut.DataSource = ds.Tables["vhistruckout"];
                txtcount.Text = dtghistorytruckOut.RowCount.ToString();
            }
            CN.Close();
        }

        private void cbselectalltruck_CheckedChanged(object sender, EventArgs e)
        {
            string startdate = dtpselecttruck.Value.Day.ToString();
            string startmount = dtpselecttruck.Value.Month.ToString();
            string startyear = dtpselecttruck.Value.Year.ToString();
            string datesearch = startyear + "/" + startmount + "/" + startdate;
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (cbselectalltruck.Checked == true)
            {
                dtpselecttruck.Enabled = false;
                if (tabControl1.SelectedIndex == 3)
                {
                    ds.Clear(); dssearch.Clear();
                    dtghistorytruckin.DataSource = dssearch;
                    string sql3 = "select * from vWeigthTruckin  where idbranch=" + Program.idbranch + " AND idtranauto IS NOT NULL order by idtranauto desc";
                    SqlDataAdapter da3 = new SqlDataAdapter(sql3, CN);
                    da3.Fill(ds, "vhistruckin");
                    dtghistorytruckin.DataSource = ds.Tables["vhistruckin"];
                    txtcount.Text = dtghistorytruckin.RowCount.ToString();
                }

                if (tabControl1.SelectedIndex == 4)
                {
                    ds.Clear(); dssearch.Clear();
                    dtghistorytruckOut.DataSource = dssearch;
                    string sql3 = "select * from vWeigthTruckout  where idbranch=" + Program.idbranch + " AND idtranauto IS NOT NULL order by idtranauto desc";
                    SqlDataAdapter da3 = new SqlDataAdapter(sql3, CN);
                    da3.Fill(ds, "vhistruckout");
                    dtghistorytruckOut.DataSource = ds.Tables["vhistruckout"];
                    txtcount.Text = dtghistorytruckOut.RowCount.ToString();
                }
            }
            else
            {
                dtpselecttruck.Enabled = true;

                if (tabControl1.SelectedIndex == 3)
                {
                    ds.Clear(); dssearch.Clear();
                    dtghistorytruckin.DataSource = dssearch;
                    string sql3 = "select * from vWeigthTruckin  where idbranch=" + Program.idbranch + "  AND dateWbf = '" + datesearch + "' AND idtranauto IS NOT NULL order by idtranauto desc";
                    SqlDataAdapter da3 = new SqlDataAdapter(sql3, CN);
                    da3.Fill(ds, "vhistruckin");
                    dtghistorytruckin.DataSource = ds.Tables["vhistruckin"];
                    txtcount.Text = dtghistorytruckin.RowCount.ToString();
                }

                if (tabControl1.SelectedIndex == 4)
                {
                    ds.Clear(); dssearch.Clear();
                    dtghistorytruckOut.DataSource = dssearch;
                    string sql3 = "select * from vWeigthTruckout  where idbranch=" + Program.idbranch + " AND dateWaf ='" + datesearch + "' AND idtranauto IS NOT NULL order by idtranauto desc";
                    SqlDataAdapter da3 = new SqlDataAdapter(sql3, CN);
                    da3.Fill(ds, "vhistruckout");
                    dtghistorytruckOut.DataSource = ds.Tables["vhistruckout"];
                    txtcount.Text = dtghistorytruckOut.RowCount.ToString();
                }
            }
            CN.Close();

        }      

    }

}