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
    public partial class Frmrateoilsetting : Form
    {
        public Frmrateoilsetting()
        {
            InitializeComponent();
        }

        public int idtruck = 0;
        public int editstatus = 0;
        int RowselectItem = 0;
        int RowIndex = 0;
        string idemp = ""; 
        DataSet dts = new DataSet();        
        DTrat dtwaring = new DTrat();
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        //เก็บค่าวันที่                                              เก็บสถานะการแจ้งเตือน timetik
        string dateexprie = "";
        int daydiscount = 0;
        int maxid = 0;

        private void CheckDiscount()
        {
            DateTime dtnow = new DateTime();
            dtnow = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            DateTime datenow = new DateTime(dtnow.Year, dtnow.Month, dtnow.Day);

            if (editstatus == 0)
            {
                DateTime dateWN = new DateTime(dtpdateexprie.Value.Year, dtpdateexprie.Value.Month, dtpdateexprie.Value.Day);
                TimeSpan difdate = dateWN - datenow;
                daydiscount = difdate.Days;
            }
            if (editstatus == 1)
            {
                DateTime dateWN = new DateTime();
                for (int i = 0; i < dtgwarning.RowCount; i++)
                {
                    dateWN = Convert.ToDateTime(dtgwarning[2, i].Value.ToString().Trim());
                    DateTime dateafwn = new DateTime(dateWN.Year, dateWN.Month, dateWN.Day);
                    TimeSpan difdate = dateafwn - datenow;
                    dtgwarning[4, i].Value = difdate.Days.ToString();
                }
            }
        }

        private void CheckExpireDate()
        {
            for (int i = 0; i < dtgwarning.RowCount; i++)
            {
                DateTime dtnow = new DateTime();
                dtnow = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                DateTime datenow = new DateTime(dtnow.Year, dtnow.Month, dtnow.Day);

                DateTime dateWarNing = new DateTime();
                dateWarNing =  Convert.ToDateTime(dtgwarning[2, i].Value.ToString().Trim());
                DateTime dateWN = new DateTime(dateWarNing.Year, dateWarNing.Month, dateWarNing.Day);

                TimeSpan difdate = dateWN - datenow;

                int daywarning = Convert.ToInt16(dtgwarning[3, i].Value.ToString().Trim());
                dtgwarning.Rows[i].DefaultCellStyle.BackColor = Color.White;

                if (difdate.Days <= daywarning)
                { dtgwarning.Rows[i].DefaultCellStyle.BackColor = Color.Red; }
            }
        }

        private void SelectDateexpire()
        {
            string date = dtpdateexprie.Value.Day.ToString();
            string month = dtpdateexprie.Value.Month.ToString();
            string year = dtpdateexprie.Value.Year.ToString();
            dateexprie = month + "/" + date + "/" + year;         
        }

        double rateoil = 0;
        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            SelectDateexpire();           
            
            if (txtserailcar.Text != "" && idemp != "" && editstatus == 0)
            {
                string sql1 = "insert into tbtruck(truckserail,remark,setrate,idemp,idtyperate) values ('" + txtserailcar.Text + "','" + txtremarktruck.Text + "'," + rateoil + ",'" + idemp + "','" + cbtyperate.SelectedValue.ToString() + "')";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                CM1.ExecuteNonQuery();

                string sql2 = "select Max(idtruck)as MaxID from tbtruck";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();
                //SELECT MAX(expression )FROM tables WHERE predicates;
                DR2.Read();
                { maxid = Convert.ToInt16(DR2["MaxID"].ToString()); }
                DR2.Close();

                SaveWarningToDatabase();
                MessageBox.Show("บันทึกข้อมูลประสบความสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAllTruck();
            }

            if (txtserailcar.Text != "" && editstatus == 1)
            {
                string sql1 = "update tbtruck set remark='" + txtremarktruck.Text + "',setrate='" + rateoil + "',idemp='" + idemp + "'Where idtruck= " + idtruck + "";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                CM1.ExecuteNonQuery();
                RemoveOlddatabase();
                SaveWarningToDatabase();
                MessageBox.Show("ปรับปรุงข้อมูลประสบความสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAllTruck();              
            }
            else
            {
                MessageBox.Show("ข้อมูลสำคัญไม่ได้ระบุ (ชื่อคนขับ/ ทะเบียน/ เลขไมค์) !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CN.Close();
        }

        private void SaveWarningToDatabase()
        {
            string sql = "insert into tbwarning(idtruck,daywaring,datewarning,idtypewarning) values(@idtruck,@daywaring,@datewarning,@idtypewarning)";
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            SqlTransaction tx = CN.BeginTransaction();
            DateTime now = DateTime.Now;
            int idsave = 0;
            if (editstatus == 0)//load adnew
            { idsave = maxid; }
            if (editstatus == 1)//load edit
            { idsave = idtruck; }

            for (int i = 0; i < dtgwarning.Rows.Count; i++)
            {
                SqlCommand cm = new SqlCommand(sql, CN, tx);
                cm.Parameters.Add("@idtruck", SqlDbType.Int).Value = idsave; 
                cm.Parameters.Add("@idtypewarning", SqlDbType.Int).Value = Convert.ToInt16(dtgwarning[0, i].Value);
                cm.Parameters.Add("@daywaring", SqlDbType.Int).Value = dtgwarning[3, i].Value;
                cm.Parameters.Add("@datewarning", SqlDbType.DateTime).Value = dtgwarning[2, i].Value;  
                cm.ExecuteNonQuery();
            }
            tx.Commit();
            CN.Close();
        }

        private void RemoveOlddatabase()
        {        
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql1 = "DELETE From tbwarning where idtruck=" + idtruck + "";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            CM1.ExecuteNonQuery();
            CN.Close();
        }       

        private void LoadTBwarningTodataset()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            dtgwarning.DataSource = dtwaring;
            string sql = "select * from vwarningtruck where idtruck=" + idtruck + "";
            SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
            da1.Fill(ds, "tbwarning");
            dtgwarning.DataSource = ds.Tables["tbwarning"];
            lblcount.Text = "จำนวน " + dtgwarning.RowCount.ToString() + " ข้อมูล";
            CN.Close();
        }

        private void ClearAllTruck()
        {
            txtempname.Clear();
            txtremarktruck.Clear();
            txtserailcar.Clear();            
            cbtyperate.Text = "";   
        }

        private void ClearAllWarning()
        {
            cbnamewarning.Text = "";
            cbdaywarning.Text = "";
            dtpdateexprie.Text = DateTime.Now.ToShortDateString();
            txtremarkwarning.Text = "-";
        }

        private void btnsearchemp_Click(object sender, EventArgs e)
        {
            Frmserch fs = new Frmserch();
            fs.sname = "sempdriver";
            fs.ShowDialog();
            if (fs.returnid.Trim() != "0")
            {
                idemp = fs.returnid;
                SearchEmp();                
            }
        }

        private void SearchEmp()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql4 = "select * from vemployee where idemp='" + idemp + "'";
            SqlCommand CM4 = new SqlCommand(sql4, CN);
            SqlDataReader DR4 = CM4.ExecuteReader();

            DR4.Read();
            { txtempname.Text = DR4["empname"].ToString(); }
            DR4.Close();
            CN.Close();
        }

        private void Frmrateoilsetting_Load(object sender, EventArgs e)
        {
            if (editstatus == 0)//load adnew
            { LoadTyperate(); }
            if (editstatus == 1)//load edit
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();               
                string sql1 = "SELECT * FROM vdrivertyperate WHERE idtruck =" + idtruck + "";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();
                DR1.Read();
                {
                    txtserailcar.Text = DR1["truckserail"].ToString().Trim();
                    txtempname.Text = DR1["empname"].ToString().Trim();
                    cbtyperate.Text = DR1["nametyperate"].ToString().Trim();                   
                    txtremarktruck.Text = DR1["remark"].ToString().Trim();
                    txtrateoil.Text = DR1["setrate"].ToString().Trim();
                    rateoil = Convert.ToDouble(DR1["setrate"].ToString().Trim());
                    idemp= DR1["idemp"].ToString().Trim();
                }
                DR1.Close();
                CN.Close();
                //load to dataset
               
                LoadTyperate();
                LoadTBwarningTodataset();
                CheckDiscount();
                CheckExpireDate();
                txtserailcar.Enabled = false;            
            }

            if (editstatus == 2)
            { }
        }

        private void LoadTyperate()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql1 = "select * from tbtyperate ";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(dts, "loadrate");
            cbtyperate.DataSource = dts.Tables["loadrate"];
            cbtyperate.DisplayMember = "nametyperate";
            cbtyperate.ValueMember = "idtyperate";
           
            string sql2 = "select * from tbtypewarning ";
            SqlDataAdapter da2 = new SqlDataAdapter(sql2, CN);
            da2.Fill(ds2, "typewarning");
            cbnamewarning.DataSource = ds2.Tables["typewarning"];
            cbnamewarning.DisplayMember = "nametype";
            cbnamewarning.ValueMember = "idtypewarning";
            cbnamewarning.Text = "";
            CN.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    int idcolor = 0;
        //    if (DateTime.Now.Second % 2 == 0)
        //    {
        //        idcolor = 1;
        //    }
        //    else
        //    { idcolor = 0; }


        //    if (Winsur == 1)
        //    {
        //        if (idcolor == 0)
        //        { lbldate.ForeColor = Color.Black; }
        //        else
        //        { lbldate.ForeColor = Color.Red; }
        //    }

            
            
        //}

        private void btninsertItem_Click(object sender, EventArgs e)
        {
            if (RowselectItem == 0)
            {
                inserttodataset();
            }
            if (RowselectItem != 0)
            {
                dtgwarning[2, RowIndex].Value = dtpdateexprie.Text;
                dtgwarning[3, RowIndex].Value = cbdaywarning.Text;
                CheckDiscount();
                CheckExpireDate();                
            }
        }

        private void inserttodataset()
        {      
            if (cbnamewarning.Text != "" &&cbdaywarning.Text !="")
            {                
                dtgwarning.DataSource = dtwaring.dtwarningtruck;
                DTrat.dtwarningtruckRow dro = dtwaring.dtwarningtruck.NewdtwarningtruckRow();
                dro.idtypewarning = Convert.ToInt16(cbnamewarning.SelectedValue.ToString().Trim());
                dro.nametype = cbnamewarning.Text;
                dro.datewarning = Convert.ToDateTime(dtpdateexprie.Text);
                dro.daywaring = Convert.ToInt16(cbdaywarning.Text.Trim());
                CheckDiscount();
                dro.daydicount = Convert.ToInt16(daydiscount);
                dro.remark = txtremarkwarning.Text; 
                dtwaring.dtwarningtruck.Rows.Add(dro);    
                ClearAllWarning();    
                CheckExpireDate();            
            }
            else
            { MessageBox.Show("ใส่ข้อมูลซ้ำหรือไม่ได้ระบุจำนวนสินค้า", "ผิดพลาด !", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }     

        private void btnremoveItem_Click(object sender, EventArgs e)
        {
            if (RowselectItem > 0)
            {
                for (int i = 0; i < dtgwarning.RowCount; i++)
                {
                    if (RowselectItem.ToString() ==dtgwarning[0,i].Value.ToString())
                    { dtgwarning.Rows.Remove(dtgwarning.Rows[i]); }
                }
                lblcount.Text = "จำนวน " + dtgwarning.RowCount.ToString() + " ข้อมูล";    
            }          
        }

        private void dtgwarning_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            RowselectItem = Convert.ToInt16(dtgwarning[0, e.RowIndex].Value.ToString());
            dtpdateexprie.Text = dtgwarning[2, e.RowIndex].Value.ToString();
            cbdaywarning.Text = dtgwarning[3, e.RowIndex].Value.ToString();
            RowIndex = e.RowIndex;
        }

        private void btnsearchemp_Click_1(object sender, EventArgs e)
        {
            Frmserch fs = new Frmserch();
            fs.sname = "sempdriver";
            fs.ShowDialog();
            idemp = fs.returnid;
            if (fs.returnid.Trim() != "0")
            { SearchEmp(); }
        }

        private void cbnamewarning_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idclear = 0;
            if (dtgwarning.RowCount != 0)
            {
                for (int i = 0; i < dtgwarning.RowCount; i++)
                {
                    if (Convert.ToInt16(cbnamewarning.SelectedValue.ToString()) == Convert.ToInt16(dtgwarning[0, i].Value.ToString()))
                    {
                        MessageBox.Show("คุณใส่ข้อมูลซ้ำ", "ผิดพลาด !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        idclear = 1;
                    }
                }

                if (idclear == 1)
                { cbdaywarning.Enabled = false; }
                else
                { cbdaywarning.Enabled = true; }
            }
        }

        private void txtrateoil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 13 && e.KeyChar != 8 && e.KeyChar != 46)
            {
                MessageBox.Show("ป้อนได้แต่ตัวเลขเท่านั้น", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
            else if (e.KeyChar == 13)
            {
                if (txtrateoil.Text != "")
                {
                    rateoil= Convert.ToDouble(txtrateoil.Text);
                    if (rateoil == 0)
                    {
                        MessageBox.Show("ค่าห้ามเป็นศูนย์ค่ะ", "ผิดพลาด!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtrateoil.Focus();
                    }
                    //decimal weigthbf = Convert.ToInt32(txtweigthkk.Text);
                    txtrateoil.Text = rateoil.ToString("##.##");
                }
            }
        }
    }
}