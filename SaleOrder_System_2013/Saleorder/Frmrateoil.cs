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
    public partial class Frmrateoil : Form
    {
        public Frmrateoil()
        {
            InitializeComponent();
        }
        int statusselect = 0;
        DTrat dts = new DTrat();
        DTrat dtg = new DTrat();
        DataSet ds = new DataSet();
        int idtyperate = 0;
        string monthData = "";
        string stdateReport = "";
        string stmonthReport = "";
        string styearReport = "";
        string eddateReport = "";
        string edmonthReport = "";
        string edyearReport = "";
        int idsearchjob = 0;

        private void LoadRateOrderDetail()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            dtg.Clear(); ds.Clear();
            dtgrate.DataSource = dtg;
            string sql = "";
            //  idtype rate 1= คิดแบบระยะทาง
            //idtype rate 2= คิดแบบชั่วโมงการทำงาน
                       
            if (idsearchjob == 1 && cbtruckserail.Text != "")
            {
                if (cbviewall.Checked == false)
                {
                    sql = "SELECT  * FROM vrateoil  Where idtruck ='" + cbtruckserail.SelectedValue.ToString() + "' AND (Month(daterefil) =" + monthData + ")order by mileageNo desc, daterefil desc ";
                }

                else
                {
                    sql = "select * from vrateoil WHERE idtruck ='" + cbtruckserail.SelectedValue.ToString() + "' order by mileageNo desc,daterefil desc";
                }
            }

            if (idsearchjob == 2 && cbtruckserail.Text != "")
            {
                if (cbviewall.Checked == false)
                {
                    sql = "SELECT  * FROM vrateoil  Where idtruck ='" + cbtruckserail.SelectedValue.ToString() + "' AND (Month(daterefil) =" + monthData + ")order by daterefil desc ";
                }

                else
                {
                    sql = "select * from vrateoil WHERE idtruck ='" + cbtruckserail.SelectedValue.ToString() + "' order by daterefil desc";
                }              
            }

            if (sql != "")
            {
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "dsrate");
                dtgrate.DataSource = ds.Tables["dsrate"];

                if (dtgrate.RowCount == 0)
                { lblcount.Text = "จำนวน - ข้อมูล"; }
                else
                {
                    lblcount.Text = "จำนวน " + dtgrate.RowCount.ToString() + " ข้อมูล";
                }
            }
            CN.Close();
        }    

        private void LoadTruckSerail()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            dts.Clear();
            string sql2 = "select idtruck,truckserail from tbtruck ";
            SqlDataAdapter da2 = new SqlDataAdapter(sql2, CN);
            da2.Fill(dts, "loadserail");
            cbtruckserail.DataSource = dts.Tables["loadserail"];
            cbtruckserail.DisplayMember = "truckserail";
            cbtruckserail.ValueMember = "idtruck";
            //cbtruckserail.Text = "";
            statusselect = 1;
            CN.Close();
        }

        private void LoadTruckNameDrive()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            DateTime dtinsur = new DateTime();
            DateTime dttax = new DateTime();

            string sql2 = "SELECT empname,empsur,nametyperate,remark,idtyperate FROM vdrivertyperate WHERE idtruck ='" + cbtruckserail.SelectedValue.ToString() + "'";
            SqlCommand CM2 = new SqlCommand(sql2, CN);
            SqlDataReader DR2 = CM2.ExecuteReader();
            DR2.Read();
            {
                txtdrivemp.Text = DR2["empname"].ToString();
                txtsurname.Text = DR2["empsur"].ToString();
                txtratename.Text = DR2["nametyperate"].ToString();
                txtremark.Text = DR2["remark"].ToString();
                idtyperate = Convert.ToInt16(DR2["idtyperate"].ToString());
            }
            DR2.Close();
            CN.Close();
        } 

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void Frmrateoil_Load(object sender, EventArgs e)
        {        
            LoadTruckSerail();
        }

        private void RefreshIndexdatagrid()
        {
            decimal x=0;
            for (int i = 0; i < dtgrate.RowCount; i++)
            {
                dtgrate[0, i].Value = Convert.ToString(i + 1);               
            }        
        }

        private void btnrecode_Click(object sender, EventArgs e)
        {
            if (cbtruckserail.Text != "")
            {
                Frmrateoilsave fros = new Frmrateoilsave();

                if (dtgrate.RowCount == 0)//บันทึกเริ่มค่าระบบ
                {
                    fros.editstatus = 0; fros.idtruck = Convert.ToInt16(cbtruckserail.SelectedValue.ToString().Trim());
                }

                else //ทำการบ้นทึกปกติ
                {
                    fros.editstatus = 1; fros.idtruck = Convert.ToInt16(cbtruckserail.SelectedValue.ToString().Trim()); 
                }

                fros.ShowDialog();
                LoadRateOrderDetail();
                RefreshIndexdatagrid();
                CaculaterTabledata();
                btnclose.Enabled = false;
                btnreport.Enabled = false;
            }
        }

        private void cbtruckserail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (statusselect == 1)
            {
                ClearAll();

                if (cbviewall.Checked == true)
                { idsearchjob = 1; }

                else if (cbviewall.Checked == false)
                {
                    idsearchjob = 2;
                    monthData = dtpsjobmont.Value.Month.ToString();
                }

                LoadTruckNameDrive();
                LoadRateOrderDetail();
                CheckDateExprie();
                RefreshIndexdatagrid();
                CaculaterTabledata();
            }
        }

        private void ClearAll()
        {
            txtdrivemp.Clear();
            txtratename.Clear();
            txtremark.Clear();
            txtsurname.Clear();
        }

        private void btnaddtruck_Click(object sender, EventArgs e)
        {
            Frmrateoilsetting frtstting = new Frmrateoilsetting();

            if (cbnew.Checked == false && cbtruckserail.Text != "")
            {
                frtstting.editstatus = 1;
                frtstting.idtruck = Convert.ToInt16(cbtruckserail.SelectedValue.ToString());
            }

            frtstting.ShowDialog();
            statusselect = 0;           
            LoadTruckSerail();           
            CheckDateExprie();
        }

        private void dtpsjobmont_ValueChanged(object sender, EventArgs e)
        {
            idsearchjob = 2;
            monthData = dtpsjobmont.Value.Month.ToString();
            LoadRateOrderDetail();
            RefreshIndexdatagrid();
            CaculaterTabledata();
        }
               
        private void SelectMontReport()
        {
            stdateReport = dtpstreport.Value.Day.ToString();
            stmonthReport = dtpstreport.Value.Month.ToString();
            styearReport = dtpstreport.Value.Year.ToString();

            eddateReport = dtpedreport.Value.Day.ToString();
            edmonthReport = dtpedreport.Value.Month.ToString();
            edyearReport = dtpedreport.Value.Year.ToString();
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            SelectMontReport();
            Frmviewreport fvrp = new Frmviewreport();
            if (cbtruckserail.Text == "")
            { fvrp.rpname = "rprateoil"; }
            if (cbtruckserail.Text != "")
            { fvrp.rpname = "rprateoilfillserail"; fvrp.filterby = cbtruckserail.Text.Trim(); }
            fvrp.startdate = Convert.ToInt16(stdateReport);
            fvrp.startmount = Convert.ToInt16(stmonthReport);
            fvrp.startyear = Convert.ToInt16(styearReport);

            fvrp.enddate = Convert.ToInt16(eddateReport);
            fvrp.endmount = Convert.ToInt16(edmonthReport);
            fvrp.endyear = Convert.ToInt16(edyearReport);
            fvrp.ShowDialog();
        }

        private void dtgrate_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.RowIndex == 0)//แก้ไขตัวล่าสุด สามารถแก้ไขเลขไมค์ได้
            {
                Frmrateoilsave fros = new Frmrateoilsave();
                fros.editstatus = 2;
                fros.idtruck = Convert.ToInt16(cbtruckserail.SelectedValue.ToString());
                fros.afmileage = Convert.ToDouble(dtgrate[2, e.RowIndex + 1].Value.ToString());               
                fros.idtruckedit = Convert.ToInt16(dtgrate[9, e.RowIndex].Value.ToString());
                fros.ShowDialog();
            }

           else if (e.RowIndex + 1 != dtgrate.RowCount)  //แก้ไขตัวที่ไม่ใช้ล่าสุด ไม่สามารถแก้ไขเลขไมค์ได้ 
            {
                Frmrateoilsave fros = new Frmrateoilsave();
                fros.editstatus = 3;
                fros.idtruck = Convert.ToInt16(cbtruckserail.SelectedValue.ToString());
                fros.afmileage = Convert.ToDouble(dtgrate[2, e.RowIndex -1].Value.ToString());
                fros.bfmileage = Convert.ToDouble(dtgrate[2, e.RowIndex].Value.ToString());
                fros.idtruckedit = Convert.ToInt16(dtgrate[9, e.RowIndex].Value.ToString());
                fros.ShowDialog();
            }
            else //ห้ามแก้ไขข้อมูลตั้งค่าระบบ
            { MessageBox.Show("ไม่สามารถแก้ไขข้อมูลตั้งค่าระบบได้ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error); }
           
            LoadRateOrderDetail();
            CheckDateExprie();
            RefreshIndexdatagrid();
            CaculaterTabledata();
        }

        private void cbnew_CheckedChanged(object sender, EventArgs e)
        {
            if (cbnew.Checked == true)
            {
                cbtruckserail.Text = ""; cbtruckserail.Enabled = false;
            }
            else { cbtruckserail.Enabled = true; }
        }

        private void CheckDateExprie()
        {
            int enable = 0;
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            DateTime dtnow = new DateTime();
            dtnow = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            DateTime datenow = new DateTime(dtnow.Year, dtnow.Month, dtnow.Day);

            DateTime dateWarNing = new DateTime();

            string sql2 = "SELECT datewarning,daywaring FROM tbwarning WHERE idtruck ='" + cbtruckserail.SelectedValue.ToString() + "'";
            SqlCommand CM2 = new SqlCommand(sql2, CN);
            SqlDataReader DR2 = CM2.ExecuteReader();

            while (DR2.Read())
            {
                dateWarNing = Convert.ToDateTime(DR2["datewarning"].ToString());
                DateTime dateWN = new DateTime(dateWarNing.Year, dateWarNing.Month, dateWarNing.Day);
                TimeSpan difdate = dateWN - datenow;

                if (difdate.Days <= Convert.ToInt16(DR2["daywaring"].ToString()))
                {
                    timewarning.Enabled = true; enable = 1;
                } 
            }
            DR2.Close();

            if (enable == 0)
            { timewarning.Enabled = false; panel3.Visible = false; }
            CN.Close();
        }

        private void timewarning_Tick(object sender, EventArgs e)
        {
            panel3.Visible = true;

            if (DateTime.Now.Second % 2 == 0)

            { txtwarning.BackColor = Color.Red; }
            else
            {
                txtwarning.BackColor = Color.White;
            }
        }
          
        private void CaculaterTabledata()
        {
            decimal afmile = 0;
            decimal bfmile = 0;
            double kilomet = 0;
            double unitrefil = 0;
            double priceoil = 0;
            double averatekm = 0;
            double prictotal = 0;

            try
            {
                for (int i = dtgrate.RowCount; i > 0; i--)
                {
                    if (i != 1)
                    {
                        afmile = Convert.ToDecimal(dtgrate[2, i - 2].Value.ToString().Trim());
                        bfmile = Convert.ToDecimal(dtgrate[2, i - 1].Value.ToString().Trim());

                        if (bfmile != 0)
                        { kilomet = Convert.ToDouble(afmile - bfmile); }
                        dtgrate[3, i - 2].Value = kilomet.ToString();

                        unitrefil = Convert.ToDouble(dtgrate[4, i - 2].Value.ToString().Trim());

                        if (idtyperate == 1)
                        { averatekm = kilomet / unitrefil; }
                        else if (idtyperate == 2)
                        { averatekm = unitrefil / kilomet; }
                        
                        dtgrate[6, i - 2].Value = averatekm.ToString("###.#0");
                        if (dtgrate[6, i - 2].Value.ToString() == "NaN") { dtgrate[6, i - 2].Value = "0"; }

                        priceoil = Convert.ToDouble(dtgrate[5, i - 2].Value.ToString().Trim());
                        prictotal = unitrefil * priceoil;

                        dtgrate[7, i - 2].Value = prictotal;

                        if (kilomet < 0)
                        {
                            dtgrate.Rows[i - 2].DefaultCellStyle.BackColor = Color.Coral;
                        }
                        else { dtgrate.Rows[i - 2].DefaultCellStyle.BackColor = Color.White; }
                    }
                }

                decimal x = 0;
                for (int i = 0; i < dtgrate.RowCount; i++)
                {
                    if (dtgrate[7, i].Value.ToString().Trim() != "")
                    {
                        x = x + Convert.ToDecimal(dtgrate[7, i].Value.ToString().Trim());
                        label11.Text = "จำนวนเงินรวม(บาท) " + x.ToString("#,###.#0").Trim();
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void btnsavedatabase_Click(object sender, EventArgs e)
        {
            SaveDetailtodatabase();
            MessageBox.Show("ปรับปรุงข้อมูลประสบความสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnreport.Enabled = true;
            btnclose.Enabled = true;
        }

        private void SaveDetailtodatabase()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            DateTime dt = new DateTime();

            string dsday = "";
            string dsmonth = "";
            string dsyear = "";
            string daterefil = "";

            for (int i = 0; i < dtgrate.RowCount; i++)
            {
                dt = Convert.ToDateTime(dtgrate[1, i].Value.ToString());
                dsday = dt.Day.ToString();
                dsmonth = dt.Month.ToString();
                dsyear = dt.Year.ToString();
                daterefil = dsmonth + "/" + dsday + "/" + dsyear;

                decimal caculateaverateperkm = 0;


                if (dtgrate[6, i].Value.ToString() != "Infinity")
                { caculateaverateperkm = Convert.ToDecimal(dtgrate[6, i].Value.ToString()); }

                string sql = "update tbrateOil set daterefil='" + daterefil + "',mileageNo =" + dtgrate[2, i].Value.ToString() + ",kilomete=" + dtgrate[3, i].Value.ToString() + ",unitliterefil=" + dtgrate[4, i].Value.ToString() + ",priceperlite=" + dtgrate[5, i].Value.ToString() + ",averateperkm=" + caculateaverateperkm + ",pricetotal=" + dtgrate[7, i].Value.ToString() + ",remark='" + dtgrate[8, i].Value.ToString() + "' Where idauto= " + dtgrate[9, i].Value.ToString() + "";
                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();
            }
            CN.Close();
        }

        private void Frmrateoil_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveDetailtodatabase();            
        }

        private void cbviewall_CheckedChanged(object sender, EventArgs e)
        {           
                         LoadTruckNameDrive();
                         ds.Clear();
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();
                string sql = "";

                if (cbviewall.Checked == true)
                {
                  
 dtpsjobmont.Enabled = false;               

                    if (idtyperate == 1)//แบบระยะทาง
                    {
                        sql = "SELECT  * FROM vrateoil  Where idtruck ='" + cbtruckserail.SelectedValue.ToString().Trim() + "' order by  mileageNo desc,daterefil desc ";
                    }
                    else //แบบชั่วโมง
                    { sql = "SELECT  * FROM vrateoil  Where idtruck ='" + cbtruckserail.SelectedValue.ToString().Trim() + "' order by daterefil desc "; }
                }
                else if (cbviewall.Checked == false)
                {
                    dtpsjobmont.Enabled = true;

                    if (idtyperate == 1)//แบบระยะทาง
                    {
                        sql = "SELECT  * FROM vrateoil  Where idtruck ='" + cbtruckserail.SelectedValue.ToString() + "' AND (Month(daterefil) =" + monthData + ") order by mileageNo desc, daterefil desc ";
                    }

                    {
                        sql = "select * from vrateoil WHERE idtruck ='" + cbtruckserail.SelectedValue.ToString() + "' AND (Month(daterefil) =" + monthData + ") order by mileageNo desc,daterefil desc";
                    }
                }

                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "dsrate");
                dtgrate.DataSource = ds.Tables["dsrate"];

                if (dtgrate.RowCount == 0)
                { lblcount.Text = "จำนวน - ข้อมูล"; }
                else
                {
                    lblcount.Text = "จำนวน " + dtgrate.RowCount.ToString() + " ข้อมูล";
                }

                CN.Close();

                CheckDateExprie();
                RefreshIndexdatagrid();
                CaculaterTabledata();

          
        }    

    }
}