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
    public partial class Frmcosttran : Form
    {
        public Frmcosttran()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet ds4 = new DataSet();
        DataSet ds5 = new DataSet();
        DTrat dssearch1 = new DTrat();
        DTrat dssearch2 = new DTrat();
        DTrat dssearch3 = new DTrat();
        DTrat dssearch4 = new DTrat();
        decimal countkilomet = 0;
        decimal countbath = 0;
        int idcar=0;
         string dssum="";
         string desum="";

        private void SelectSTandDate()
        {
            string dsday = dtpstreport.Value.Day.ToString();
            string dsmonth = dtpstreport.Value.Month.ToString();
            string dsyear = dtpstreport.Value.Year.ToString();
            dssum = dsmonth + "/" + dsday + "/" + dsyear;

            string deday = dtpedreport.Value.Day.ToString();
            string demonth = dtpedreport.Value.Month.ToString();
            string deyear = dtpedreport.Value.Year.ToString();
            desum = demonth + "/" + deday + "/" + deyear;
        }

        private void btnimport_Click(object sender, EventArgs e)
        {

            btnprocess.Enabled = true;
            btnprocess.ForeColor = Color.Red;
            btnprocess.Focus();

            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            DateTime ds = new DateTime();
            string MaxID = "";
            string rfworder = "";
            string rfdateorder = "";
            string sql1 = "select Min(idcostrate)as MaxID from tbratecostdetail where idtyperatekilo =" + cbtyperate.SelectedValue.ToString().Trim() + " AND rfdateorder is null";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                MaxID = DR1["MaxID"].ToString();
            }
            DR1.Close();


            ds4.Clear(); dssearch4.Clear();

            if (MaxID == null || MaxID == "") { MaxID = "0"; }

            string sql2 = " SELECT idtran FROM tbratecostdetail INNER JOIN tborder ON tbratecostdetail.rfworder = tborder.idtran WHERE tbratecostdetail.idcostrate >= " + MaxID + " AND tbratecostdetail.idtyperatekilo = " + cbtyperate.SelectedValue.ToString().Trim() + "AND tbratecostdetail.km is null AND tborder.idstatus =1 AND tborder.idtran is not null AND tbratecostdetail.idemp ='" + cbemp.SelectedValue.ToString().Trim() + "'";

            SqlDataAdapter da2 = new SqlDataAdapter(sql2, CN);
            da2.Fill(ds2, "viewdata");
            dtgratetransport.DataSource = ds2.Tables["viewdata"];
            dtgratetransport.Visible = true; dtgratetransport.Dock = DockStyle.Fill; dtgratetransport.BringToFront();
            lblcount.Text = "Total: " + dtgratetransport.RowCount + " Items";

            CN.Close();

            int countid = 0;
            string idtrandel = "";

            for (int i = 0; i < dtgratetransport.RowCount; i++)
            {
                string sql3 = "SELECT Count(idtran)as countid  FROM vWSaleRP_Custrate WHERE idtran = '" + dtgratetransport[0, i].Value.ToString().Trim() + "'";
                SqlCommand CM3 = new SqlCommand(sql3, CN);
                SqlDataReader DR3 = CM3.ExecuteReader();
                DR3.Read();
                { countid = Convert.ToInt16(DR3["countid"].ToString().Trim()); }
                DR3.Close();

                if (countid == 0)
                {
                    string sql4 = "delete tbratecostdetail where rfworder ='" + dtgratetransport[0, i].Value.ToString().Trim() + "'";
                    SqlCommand CM4 = new SqlCommand(sql4, CN);
                    CM4.ExecuteNonQuery();
                }
            }

            SearchDetail();

        }

        private void SearchDetail()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            SelectSTandDate();
       
            if (cbtyperate.SelectedIndex == 0 || cbtyperate.SelectedIndex == -1)//pur to sale
            {
                // sql6 = "SELECT idtran,dateWcus as DateOrder,idcomsup as IDFrom,comsup as FromCompany,idcomcus as IDTO,comcus as ToCompany,proname as Product,idcar as IDTRUCK,carname as TypeTruck,serailcar as TruckNO FROM vtranreplyFsTc WHERE (idtran > '" + rfworder + "') AND dateWcus > '" + sumdatebf + "' ORDER BY datewcus";
            }

            if (cbtyperate.SelectedIndex == 1)//pur to branch
            {
                //  sql6 = "SELECT idtran,datepur as DateOrder,idcomsup as IDFrom,comsup as FromCompany,idcompur as IDTO,compur as ToCompany,proname as Product,idcar as IDTRUCK,carname as TypeTruck,serailcar as TruckNO FROM vWPurRP WHERE (idtran > '" + rfworder + "') AND datepur > '" + sumdatebf + "' ORDER BY datepur";
            }

            if (cbtyperate.SelectedIndex == 2)//branch to sale
            {           
                for (int i = 0; i < dtgratetransport.RowCount; i++)
                {                   
                        string sql3 = "SELECT orderdate,idcomsup,bname,comsale,idcomcus,comcus,proname,idcar,carname,serailcar FROM vWSaleRP_Custrate WHERE idtran = '" + dtgratetransport[0, i].Value.ToString().Trim() + "' AND (orderdate BETWEEN '" + dssum + "' AND '" + desum + "')";
                        SqlCommand CM4 = new SqlCommand(sql3, CN);
                        SqlDataReader DR4 = CM4.ExecuteReader();
                        DR4.Read();
                        {
                            dtgratetransport[1, i].Value = DR4["orderdate"].ToString().Trim();
                            dtgratetransport[2, i].Value = DR4["idcomsup"].ToString().Trim();
                            dtgratetransport[3, i].Value = DR4["bname"].ToString().Trim();
                            dtgratetransport[4, i].Value = DR4["comsale"].ToString().Trim();
                            dtgratetransport[5, i].Value = DR4["idcomcus"].ToString().Trim();
                            dtgratetransport[6, i].Value = DR4["comcus"].ToString().Trim();
                            dtgratetransport[7, i].Value = DR4["proname"].ToString().Trim();
                            dtgratetransport[8, i].Value = DR4["idcar"].ToString().Trim();
                            dtgratetransport[9, i].Value = DR4["carname"].ToString().Trim();
                            dtgratetransport[10, i].Value = DR4["serailcar"].ToString().Trim();
                        }
                        DR4.Close();

                        dtgratetransport.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                
            }

            //if (sql6 != "")
            //{
            //    SqlDataAdapter da4 = new SqlDataAdapter(sql6, CN);
            //    da4.Fill(ds4, "viewdata");
            //    dtgratetransport.DataSource = ds4.Tables["viewdata"];
            //    lblcount.Text = "Total: " + dtgratetransport.RowCount + " Items";
            //    CN.Close();
            //}
        
        
        
        }

        private void btnprocess_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            btnsave.Enabled = true;
            btnsave.ForeColor = Color.Red;
            btnsave.Focus();
            cbviewrate.Enabled = true;

            decimal kilomet = 0;

            for (int i = 0; i < dtgratetransport.RowCount; i++)
            {
                //try
                //{
                int countkm = 0;
                string sql4 = "select count(km)as kmcount from vcostrate where idfrom = '" + dtgratetransport[2, i].Value.ToString().Trim() + "' AND idto='" + dtgratetransport[5, i].Value.ToString().Trim() + "'";
                SqlCommand CM4 = new SqlCommand(sql4, CN);
                SqlDataReader DR4 = CM4.ExecuteReader();
                DR4.Read();
                {
                    countkm = Convert.ToInt16(DR4["kmcount"].ToString().Trim());
                }
                DR4.Close();

                if (countkm != 0)
                {  
                    string sql1 = "select km from vcostrate where idfrom = '" + dtgratetransport[2, i].Value.ToString().Trim() + "' AND idto='" + dtgratetransport[5, i].Value.ToString().Trim() + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    { kilomet = Convert.ToDecimal(DR1["km"].ToString().Trim()); }
                    DR1.Close();                
                }                  

                    idcar = Convert.ToInt16(dtgratetransport[8, i].Value.ToString().Trim());
                    ds1.Clear();

                    //MessageBox.Show("โหลดตารางวิ่งรถ " + idcar.ToString());
                    LoadRatecost();               

                    for (int z = 0; z < dtgviewrate.RowCount; z++)
                    {                           
                        if (kilomet > Convert.ToInt16(dtgviewrate[1, z].Value.ToString()))
                        {                           
                            dtgratetransport[11, i].Value = kilomet.ToString().Trim();
                            dtgratetransport[12, i].Value = dtgviewrate[2, z + 1].Value.ToString();
                            dtgratetransport[13, i].Value = "-";
                            dtgratetransport[14, i].Value = dtgviewrate[2, z + 1].Value.ToString();
                            dtgratetransport[15, i].Value = "-";                           
                        }

                        else if (kilomet < Convert.ToInt16(dtgviewrate[1, z].Value.ToString()))
                        {
                            if (kilomet != 0)
                            {
                                dtgratetransport[11, i].Value = kilomet.ToString().Trim();
                                dtgratetransport[12, i].Value = dtgviewrate[2, z].Value.ToString();
                                dtgratetransport[13, i].Value = "-";
                                dtgratetransport[14, i].Value = dtgviewrate[2, z].Value.ToString();
                                dtgratetransport[15, i].Value = "-";                               
                            }
                           else if (kilomet == 0 )
                            {
                                dtgratetransport[11, i].Value = "-";
                                dtgratetransport[12, i].Value = "-";
                                dtgratetransport[13, i].Value = "-";
                                dtgratetransport[14, i].Value = "-";
                                dtgratetransport[15, i].Value = "-";
                                dtgratetransport.Rows[i].DefaultCellStyle.BackColor = Color.AntiqueWhite;                                
                            }  
                        }
                    }
                                  

                    kilomet = 0;                   
                ////}
                ////catch (Exception ex)
                ////{ MessageBox.Show(ex.Message + "ไม่มี Order นี้ในฐานข้อมูลระยะทาง"); }
            }

            SumKKandBaht();  
            CN.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {   
            //btnreport.Enabled = true;
            //btnreport.ForeColor = Color.Red;
            //btnreport.Focus();
            SaveData();
        }

        private void SaveData()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); string sql = "";      DateTime dt=new DateTime();  


            for (int i = 0; i < dtgratetransport.RowCount; i++)
            {
                dt = Convert.ToDateTime(dtgratetransport[1, i].Value.ToString());
                string deday = dt.Day.ToString();
                string demonth = dt.Month.ToString();
                string deyear = dt.Year.ToString();
                string desum = demonth + "/" + deday + "/" + deyear;
               

                if (dtgratetransport[10, i].Value.ToString() != "-")
                {
                    int bahtadmit = 0;

                    try
                    {
                        if (dtgratetransport[12, i].Value.ToString() != "-")
                        { bahtadmit = Convert.ToInt16(dtgratetransport[13, i].Value.ToString()); }

                        sql = "update tbratecostdetail set rfdateorder = '" + desum + "',km = " + dtgratetransport[11, i].Value.ToString() + ",bahtrate = " + dtgratetransport[12, i].Value.ToString() + ", bahtadmit = " + bahtadmit + ",bathtotal = '" + dtgratetransport[14, i].Value.ToString() + "',remark = '" + dtgratetransport[15, i].Value.ToString() + "' where rfworder ='" + dtgratetransport[0, i].Value.ToString().Trim() + "'";
                        SqlCommand CM = new SqlCommand(sql, CN);
                        CM.ExecuteNonQuery();

                    }
                    catch { }
                }
            //}
            //catch
            //{
            //    //update
            //    //sql = "update tbcostrate set km = " + txtkilomete.Text.Trim() + ",idfrom = '" + idcomstd + "' ,idto = '" + idcomed + "' Where idcostrate = " + idcostrate + "";
            //}

        }
            MessageBox.Show("บันทึกข้อมูลประสบความสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btngetreport_Click(object sender, EventArgs e)
        {
            ViewReport();
        }

        private void ViewReport()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); string sql = ""; ds2.Clear();
            SelectSTandDate();

            if (cbemp.Text != "")
            {
                sql = "SELECT rfdateorder AS OrderDate, empname AS DriverName, bname AS Branch, cname AS CustomerName, proname AS ProductName, carname AS TruckName,serailcar AS TruckNO, bahtrate AS Baht, bahtadmit AS Positive, km AS Distance, bathtotal AS TotalBaht, remark AS Remark FROM vrpratecostemp WHERE (rfdateorder BETWEEN '" + dssum + "' AND '" + desum + "') AND idemp ='" + cbemp.SelectedValue.ToString().Trim() + "' ";
            }
            else
            { sql = "SELECT rfdateorder AS OrderDate, empname AS DriverName, bname AS Branch, cname AS CustomerName, proname AS ProductName, carname AS TruckName,serailcar AS TruckNO, bahtrate AS Baht, bahtadmit AS Positive, km AS Distance, bathtotal AS Total, remark AS Remark FROM vrpratecostemp WHERE (rfdateorder BETWEEN '" + dssum + "' AND '" + desum + "')"; }

            if (sql != "")
            {
                SqlDataAdapter da2 = new SqlDataAdapter(sql, CN);
                da2.Fill(ds2, "viewdaterate"); dtgviewsdata.Visible = true; dtgviewsdata.Dock = DockStyle.Fill;
                dtgviewsdata.DataSource = ds2.Tables["viewdaterate"];
                dtgviewrate.Visible = true; dtgviewrate.Dock = DockStyle.Fill; dtgviewrate.BringToFront();
                lblcount.Text = "Total: " + dtgviewsdata.RowCount + " Items";
                CN.Close();
            }
        }

        private void btnreport_Click(object sender, EventArgs e)
        {

        }

        private void btnsetting_Click(object sender, EventArgs e)
        {
            Frmcostsetting frcom = new Frmcostsetting();
            frcom.ShowDialog();
        }

        private void Frmcosttran_Load(object sender, EventArgs e)
        {
            Loadtyerate(); Loademp();
        }

        private void Loadtyerate()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql1 = "select * from tbtyperatekilo ";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(ds5, "typerate");
            cbtyperate.DataSource = ds5.Tables["typerate"];
            cbtyperate.DisplayMember = "nametyperate";
            cbtyperate.ValueMember = "idtyperatekilo";
           
            //combo1.Items[0].Text = 'new Text';
         
            cbtyperate.Text = "";
            CN.Close();
        }

        private void Loademp()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql1 = "select idemp,empname from tbemployee where idposition =13 ";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(ds5, "employee");
            cbemp.DataSource = ds5.Tables["employee"];
            cbemp.DisplayMember = "empname";
            cbemp.ValueMember = "idemp";
            cbemp.Text = "";
            CN.Close();
        }

        private void rdoimport_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoimport.Checked == true)
            {
                lblimport.Enabled = true;
                btnimport.Enabled = true;
                dtgratetransport.Visible = true; dtgratetransport.Dock = DockStyle.Fill; dtgviewsdata.Visible = false;
            }
        }

        private void rdoviewdata_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoviewdata.Checked == true)
            {
                lblimport.Enabled = false;
                btnimport.Enabled = false;
                btnprocess.Enabled = false;
               // btnreport.Enabled = false;
                btnsave.Enabled = false;
                dtgviewsdata.Visible = true; dtgviewsdata.Dock = DockStyle.Fill; dtgratetransport.Visible = false;
            }
        }

        private void cbtyperate_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbviewrate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbviewrate.Checked == true)
            {                
                dtgviewrate.Visible = true;
            }
            else { dtgviewrate.Visible = false; }

        }

        private void LoadRatecost()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql6 = "select idcar,ratecostkm,price from vcostprice where  idcar =" + idcar + "";
            SqlDataAdapter da4 = new SqlDataAdapter(sql6, CN);
            da4.Fill(ds1, "LoadRatecost");
            dtgviewrate.DataSource = ds1.Tables["LoadRatecost"];           
            CN.Close();
        }

        private void dtgratetransport_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= 0 && e.ColumnIndex != 13 && dtgratetransport[12, e.RowIndex].Value.ToString().Trim() == "" && dtgratetransport[12, e.RowIndex].Value.ToString().Trim() == "-") return;
                dtgratetransport[14, e.RowIndex].Value = Convert.ToString(Convert.ToInt16(dtgratetransport[12, e.RowIndex].Value.ToString().Trim()) + Convert.ToInt16(dtgratetransport[13, e.RowIndex].Value.ToString().Trim()));

            SumKKandBaht();
        }

        private void btnprintrp_Click(object sender, EventArgs e)
        {
            Frmviewreport frrp = new Frmviewreport();
            
            if (cbemp.Text == "")
            { frrp.rpname = "crpratetruckempAll"; }
            else { frrp.rpname = "crpratetruckempFilter"; frrp.filterby = cbemp.SelectedValue.ToString().Trim(); }           
            frrp.startdate = Convert.ToInt16(dtpstreport.Value.Day.ToString());
            frrp.startmount = Convert.ToInt16(dtpstreport.Value.Month.ToString());
            frrp.startyear = Convert.ToInt16(dtpstreport.Value.Year.ToString());
            
            frrp.enddate = Convert.ToInt16(dtpedreport.Value.Day.ToString());
            frrp.endmount = Convert.ToInt16(dtpedreport.Value.Month.ToString());
            frrp.endyear = Convert.ToInt16(dtpedreport.Value.Year.ToString());
            frrp.ShowDialog();
        }

        private void SumKKandBaht()
        {
            countbath = 0;
            countkilomet = 0;

            for (int i = 0; i < dtgratetransport.RowCount; i++)
            {
                try
                {
                    countbath = countbath + Convert.ToInt16(dtgratetransport[14, i].Value.ToString());
                    countkilomet = countkilomet + Convert.ToInt16(dtgratetransport[11, i].Value.ToString());
                    lblcount.Text = "รวมระยะทาง = " + countkilomet.ToString("#,###") + " กิโลเมตร รวมจำนวนเงิน = " + countbath.ToString("#,###") + " บาท";
                }
                catch { }
            } 
        }

    }
}