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
    public partial class FrmSelectMoveJob : Form
    {
        public FrmSelectMoveJob()
        {
            InitializeComponent();
        }

        private void btncancle_Click(object sender, EventArgs e)
        {
            idok = 0;
            this.Close();
        }

        public int xposition = 0; 
        public int yposition = 0; 
        public string idmovejob = "0"; 
        public int typejob = 0;
        public int idbranch = 0;
        public string branchname = "";        
        public int idcus = 0; 
        public int idpropur = 0;
        public string idpur = "0";
        public string idorder = "0";
        string idcomtran = "";
        string msnfrom = ""; 
        int idtypelog = 0;         
        int idtran = 0; 
        string idtranno = "0";         
        string keychar = ""; 
        int idpro = 0; 
        int idsuppro = 0;
        string idempdrive = "";
        string idfrom = ""; // id เราเป็นผู้ขาย
        string idto = ""; //id เราเป็นลูกค้า
        
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        public int idok = 0;
        string datelog = DateTime.Now.Day.ToString();
        string monthlog = DateTime.Now.Month.ToString();
        string yearlog = DateTime.Now.Year.ToString();
        
        private void CheckProductDefult()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            try
            {
                string sql1 = "SELECT idsuppro FROM vproductinstock WHERE (idpro = " + idpro + ") AND (idbranch = " + cbbranch.SelectedValue.ToString() + ")";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                { idsuppro = Convert.ToInt16(DR1["idsuppro"].ToString()); }
                DR1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่มีสินค้าชนิดนี้ในสาขา กรุณาเลือกสินค้าให้ถูกต้องหรือไปเพิ่มสินค้าเข้าสต๊อก", "ผิดพลาด !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CN.Close();
        }

        private void Loadbranch()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql2 = "select idbranch,bname from vautokeychar ";
            SqlDataAdapter da2 = new SqlDataAdapter(sql2, CN);
            da2.Fill(ds1, "loadbranch");

            cbbranch.DataSource = ds1.Tables["loadbranch"];
            cbbranch.DisplayMember = "bname";
            cbbranch.ValueMember = "idbranch";
            CN.Close();
        }

        private void LoadComtransport()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();          
            string sql7 = "select idcom,cname from vcompany where idtypecom =3 or idcom ='C003'";
            SqlDataAdapter da3 = new SqlDataAdapter(sql7, CN);
            da3.Fill(ds, "loadcomtran");

            cbcomtran.DataSource = ds.Tables["loadcomtran"];
            cbcomtran.DisplayMember = "cname";
            cbcomtran.ValueMember = "idcom";
            CN.Close();
        }

        private void LoadoldIDtrasport()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();   
            string sql2 = "select idtranauto,idtran from tbtransport ORDER BY idtranauto DESC";
            SqlCommand CM2 = new SqlCommand(sql2, CN);
            SqlDataReader DR2 = CM2.ExecuteReader();

            try
            {
                DR2.Read();
                {
                    idtran = Convert.ToInt32(DR2["idtranauto"].ToString());
                    txtidtran.Text = DR2["idtran"].ToString();
                    txtoldid.Text = DR2["idtran"].ToString();
                }
                DR2.Close();
                CN.Close();
            }
            catch(Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
        }

        private void FrmSelectMoveJob_Load(object sender, EventArgs e)
        {
            txtdatetime.Text = DateTime.Now.ToShortDateString();            
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();            
            
            if (xposition != 0)
            { this.Location = new Point(xposition, yposition);       }

            if (typejob == 1)//จ่ายงานส่วนซื้อเข้าคลัง
            {
                txtserailcar.Enabled = false; cbcomtran.Enabled = false; cbnamedrive.Enabled = false;
            }

            if (typejob == 2)//จ่ายงานส่วนขายออกคลัง
            {             
            }

            if (typejob == 4)//ซื้อมา -> ขายไป
            {
                cbnamedrive.Enabled = false;
            }

            Loadbranch();
            LoadComtransport();
            LoadoldIDtrasport();
            SearchIDproduct();
            SearchIDcomtran();
            LoadTruckNO();
            LoadEmployeeDrverAll(); 
            

            if (typejob == 3 || typejob == 4)
            {
                cbbranch.Text = "ไม่ผ่านตาชั่งสาขา";
                cbcomtran.Enabled = false;
                txtserailcar.Enabled = false;
            }
            CN.Close();
        }

        private void SearchIDcomtran()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();           

            if (typejob == 1)
            {
                string sql2 = "select idcomtran from tbpurchase where idpur= '" + idpur + "'";

                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();

                DR2.Read();
                { idcomtran = DR2["idcomtran"].ToString(); }
                DR2.Close();
            }
            CN.Close();
        }

        private void SearchIDproduct()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql2 = "";

            if (typejob == 1 || typejob == 2)
            {
                if (typejob == 1)
                { sql2 = "select idpro,idcompur from tbpurchase where idpur= '" + idpur + "'"; }
                if (typejob == 2)
                { sql2 = "select idpro,idcomsup from tborder where idorder= '" + idorder + "'"; }

                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();

                DR2.Read();
                {
                    if (typejob == 1)
                    { idto = DR2["idcompur"].ToString(); }
                    if (typejob == 2)
                    { idfrom = DR2["idcomsup"].ToString(); }

                    idpro = Convert.ToInt16(DR2["idpro"].ToString());
                }
                DR2.Close();
            }

            if (typejob == 4)
            {
                int idpropur = 0;
                int idprosale = 0;

                if (idpur != "")
                {
                    string sql1 = "SELECT idpro FROM tbpurchase WHERE idpur = '" + idpur + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    SqlDataReader DR1 = CM1.ExecuteReader();
                    DR1.Read();
                    { idpropur = Convert.ToInt32(DR1["idpro"].ToString()); }
                    DR1.Close();
                }

                if (idorder != "")
                {
                    string sql3 = "SELECT idpro,idcar FROM tborder WHERE idorder ='" + idorder + "'";
                    SqlCommand CM2 = new SqlCommand(sql3, CN);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    DR2.Read();
                    { idprosale = Convert.ToInt32(DR2["idpro"].ToString()); }
                    DR2.Close();
                }

                if (idpropur == idprosale)
                { idpro = idpropur; }
            }
            CN.Close();
        }     

        private void btnok_Click(object sender, EventArgs e)
        {
            CreateAutoIDbybrannch();
            CheckProductDefult();
            
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); 
            
            string date = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string sumdate = month + "/" + date + "/" + year;

            if (typejob == 1 && idsuppro != 0)//from purchase
            {                
                if (cbcomtran.Text != "" & cbbranch.Text != "")
                {
                    txtserailcar.Enabled = false;
                    string sql1 = "insert into tbtransport(idtran,senddate,idfrom,idto,idcomtran,idbranch,truckpass,idsuppro) values ('" + idtranno + "','" + sumdate + "','" + idpur + "','" + idto + "','" + idcomtran + "'," + cbbranch.SelectedValue.ToString().Trim() + ",0," + idsuppro + ")";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();

                    string sql2 = "update tbpurchase set idtran='" + idtranno + "',remark3='ชั่งรถหนัก' Where idpur= '" + idpur + "'";
                    SqlCommand CM2 = new SqlCommand(sql2, CN);
                    CM2.ExecuteNonQuery();

                    string sql3 = "insert into tbweigth(idtran) values('" + idtranno + "')";
                    SqlCommand CM3 = new SqlCommand(sql3, CN);
                    CM3.ExecuteNonQuery();

                    if (cbpassweight.Checked == true)
                    {
                        string d = dateTimePicker1.Value.Day.ToString();
                        string m = dateTimePicker1.Value.Month.ToString();
                        string y = dateTimePicker1.Value.Year.ToString();
                        string da = m + "/" + d + "/" + y;

                        CheckNoweigthPurchase();
                        string sql6 = "update tbweigth set dateWbf = '" + da + "' ,weigthbf = 0 ,weigthaf = 0,weigthnet = 0, wtype ='" + textBox5.Text.Trim() + "' Where idtran= '" + idtranno + "'";
                        SqlCommand CM6 = new SqlCommand(sql6, CN);
                        CM6.ExecuteNonQuery();
                    }
                    

                    MessageBox.Show("ข้อมูลทำการปรับปรุงแล้ว ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    idok = 1;
                    msnfrom = this.Name.ToString();
                    idtypelog = 1;//update
                    Savelogevent();
                }
            }
            if (typejob == 2 && idsuppro != 0)//from sale
            {
                if (cbcomtran.Text.Trim() != "" & cbbranch.Text.Trim() != "" & txtserailcar.Text.Trim() != "")
                {
                    string sql3 = "";
                    sql3 = "insert into tbtransport(idtran,senddate,idto,idfrom,idbranch,truckpass,idcomtran,idsuppro) values ('" + idtranno + "','" + sumdate + "','" + idorder + "','" + idfrom + "'," + cbbranch.SelectedValue + "," + 0 + ",'" + cbcomtran.SelectedValue.ToString() + "'," + idsuppro + ")";

                    SqlCommand CM3 = new SqlCommand(sql3, CN);
                    CM3.ExecuteNonQuery();

                    string sql4 = "update tborder set idtran='" + idtranno + "',serailcar ='" + txtserailcar.Text + "',remark3='ชั่งรถเบา' Where idorder= '" + idorder + "'";   //chang update tborder
                    SqlCommand CM4 = new SqlCommand(sql4, CN);
                    CM4.ExecuteNonQuery();

                    string sql5 = "insert into tbweigth(idtran) values('" + idtranno + "')";
                    SqlCommand CM5 = new SqlCommand(sql5, CN);
                    CM5.ExecuteNonQuery();

                    if (cbpassweight.Checked == true)
                    {
                        string d = dateTimePicker1.Value.Day.ToString();
                        string m = dateTimePicker1.Value.Month.ToString();
                        string y = dateTimePicker1.Value.Year.ToString();
                        string da = m + "/" + d + "/" + y;

                        CheckNoweigthSale();
                        string sql6 = "update tbweigth set dateWbf = '" + da + "' ,weigthbf = 0 ,weigthaf = 0,weigthnet = 0, wtype ='" + textBox5.Text.Trim() + "' Where idtran= '" + idtranno + "'";
                        SqlCommand CM6 = new SqlCommand(sql6, CN);
                        CM6.ExecuteNonQuery();
                    }

                    string sql7 = "insert into tbratecostdetail (rfworder,idtyperatekilo,idemp) values ('" + idtranno + "',3,'" + idempdrive + "')";   //
                    SqlCommand CM7 = new SqlCommand(sql7, CN);
                    CM7.ExecuteNonQuery();
                    
                    MessageBox.Show("ข้อมูลทำการปรับปรุงแล้ว ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    idok = 1;
                    msnfrom = this.Name.ToString();
                    idtypelog = 1;//update
                    Savelogevent();
                }
            }

            if (idsuppro == 0)
            { MessageBox.Show("ไม่มีสินค้าชนิดนี้ในสาขา กรุณาเลือกสินค้าให้ถูกต้องหรือไปเพิ่มสินค้าเข้าสต๊อก", "ผิดพลาด !", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            if (typejob == 3 || typejob == 4)
            {                
                branchname = cbbranch.Text;
                idok = 1;
                this.Close();
            }
            CN.Close();
        }

        private void CreateAutoIDbybrannch()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            long daterun = 0;
            int idrun = 0;
            CheckKeychar();

            string getidmax = "";
            string sql = "SELECT MAX(idtranauto) AS idmaxs FROM tbtransport WHERE (idtran LIKE '%" + keychar + "%')";
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
                    textBox1.Text = DR1["idtran"].ToString();
                    textBox2.Text = DR1["idtran"].ToString();
                }
                DR1.Close();

                textBox1.SelectionStart = 1;
                textBox1.SelectionLength = 6;
                daterun = Convert.ToInt64(textBox1.SelectedText.ToString());//ตัดค่า 4 ปีเดือนวัน จากฐานข้อมูล
                textBox2.SelectionStart = 7;
                textBox2.SelectionLength = 9;
                idrun = Convert.ToInt32(textBox2.SelectedText.ToString());//ตัวลำดับที่ จากฐานข้อมูล            
            }

            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            string idcomplease = keychar + String.Format("{0:yy}", dt) + String.Format("{0:MM}", dt) + String.Format("{0:dd}", dt);
            long datenow = Convert.ToInt64(String.Format("{0:yy}", dt) + String.Format("{0:MM}", dt) + String.Format("{0:dd}", dt));

            if (datenow == daterun)
            {
                idrun++;
                idtranno = idcomplease + string.Format("{0:00}", idrun);
            }
            else
            {
                idtranno = idcomplease + "01";
            }

            if (typejob == 4)
            {
                //counts = Addselectproducttocombo(ds, CN, counts, countpro);
                //txtserailcar.Enabled = false; cbcomtran.Enabled = false;
            }

            //if (typejob == 1 || typejob == 2)
            //{
            //    string sql3 = "";

            //    if (typejob == 1)
            //    { sql3 = "select idpro from vpurchase WHERE idpur ='" + idmovejob + "'"; }
            //    if (typejob == 2)
            //    { sql3 = "select idpro from vsaleorder WHERE idorder ='" + idmovejob + "'"; }

            //    SqlCommand CM3 = new SqlCommand(sql3, CN);
            //    SqlDataReader DR3 = CM3.ExecuteReader();

            //    DR3.Read();
            //    { idpropur = Convert.ToInt16(DR3["idpro"].ToString()); }
            //    DR3.Close();
            //}

            textBox4.Text = idtranno.ToString();
            CN.Close();
        }
        
        private void Savelogevent()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string selectdatelog = monthlog + "/" + datelog + "/" + yearlog;
            string sql1 = "insert into tblog(logname,datein,timein,idtypelog,idemp,remark) values('" + msnfrom + "','" + selectdatelog + "','" + DateTime.Now.ToLongTimeString() + "'," + idtypelog + ",'" + Program.empID + "','" + idmovejob + "')";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            CM1.ExecuteNonQuery();
            CN.Close();
        }

        private void Frmcar_FormClosed(object sender, FormClosedEventArgs e)
        {
            msnfrom = this.Name.ToString();
            idtypelog = 6;//close
            Savelogevent();
        }

        private void cbbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbranch.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                idbranch = Convert.ToInt16(cbbranch.SelectedValue.ToString()); //CheckNoweigth();
            }
        }

        private void CheckKeychar()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql3 = "select charname from vautokeychar WHERE idbranch =" + cbbranch.SelectedValue.ToString().Trim() + "";
            SqlCommand CM3 = new SqlCommand(sql3, CN);
            SqlDataReader DR3 = CM3.ExecuteReader();

            DR3.Read();
            {
                keychar = DR3["charname"].ToString().Trim();
            }
            DR3.Close();
            CN.Close();
        }

        private void CheckNoweigthSale()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            //int idmaxweigth = 0; string chek = "";

            string keychar = "";
            string sql3 = "select charname from vautokeychar WHERE idbranch =" + cbbranch.SelectedValue.ToString() +"";
            SqlCommand CM3 = new SqlCommand(sql3, CN);
            SqlDataReader DR3 = CM3.ExecuteReader();

            DR3.Read();
            { keychar = DR3["charname"].ToString().Trim(); }
            DR3.Close();

            int idcountweigth = 0;

            string sqlwe = "SELECT COUNT(wtype) AS idcountweigth FROM vchecknoweigth where idbranch ='" + cbbranch.SelectedValue.ToString() + "' AND wtype Like'%WO%'";

            SqlCommand CMw = new SqlCommand(sqlwe, CN);
            SqlDataReader DRw = CMw.ExecuteReader();
            DRw.Read();
            { idcountweigth = Convert.ToInt32(DRw["idcountweigth"].ToString()); }
            DRw.Close();

            if (idcountweigth != 0)
            {
                string sql = " select  wtype FROM vchecknoweigth where idbranch ='" + cbbranch.SelectedValue.ToString() +"' AND wtype Like'%WO%' order by wtype desc";

                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();
                DR.Read();
                {
                    textBox6.Text = DR["wtype"].ToString(); //get weigth id type WI,WO                  
                }
                DR.Close();
            }

            if (idcountweigth == 0)
            { textBox6.Text = "WO-000"; }

            textBox7.Text = idtranno;//ดึงเลขที่การชั่งของ
            textBox7.SelectionStart = 3;
            textBox7.SelectionLength = 2;
            int monthNo = Convert.ToInt16(textBox7.SelectedText.ToString());//get month runorder

            // DateTime now = new DateTime();// get month now
            int month = Convert.ToInt16(DateTime.Now.Month.ToString());

            textBox6.SelectionStart = 3;
            textBox6.SelectionLength = 4;
            int idold = Convert.ToInt16(textBox6.SelectedText.ToString());//get month runorder
            textBox5.Text = idold.ToString();

            if (monthNo == month)//เทียบว่าเท่ากันให้บวบ  1
            {
                // idold = idold + 1;
                if (textBox5.Text.Length == 1)
                {
                    if (idold == 9)//WI-0009
                    {
                        idold = idold + 1;
                        textBox5.Text = "WO-00" + idold;
                    }
                    else //WI-0001 - WI-0008
                    {
                        idold = idold + 1;
                        textBox5.Text = "WO-000" + idold;
                    }
                }

                else if (textBox5.Text.Length == 2) //10 - 99
                {
                    if (idold == 99)//WI-0099
                    {
                        idold = idold + 1;
                        textBox5.Text = "WO-0" + idold;
                    }
                    else//WI-0011 - WI-0098}
                    {
                        idold = idold + 1;
                        textBox5.Text = "WO-00" + idold;
                    }
                }

                else if (textBox5.Text.Length == 3)
                {
                    if (idold == 999)//
                    {
                        idold = idold + 1;
                        textBox5.Text = "WO-" + idold;
                    }
                    else//WI-0101 - WI-0998}
                    {
                        idold = idold + 1;
                        textBox5.Text = "WO-0" + idold;
                    }
                }

                else if (textBox5.Text.Length == 4)
                {
                    idold = idold + 1;
                    if (idold != 10000)
                    { textBox5.Text = "WO-" + idold; }
                }
            }

            else
            { textBox5.Text = "WO-0001"; }
            CN.Close();
        }

        private void CheckNoweigthPurchase()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            int idmaxweigth = 0; string chek = "";

            string keychar = "";
            string sql3 = "select charname from vautokeychar WHERE idbranch =" + cbbranch.SelectedValue.ToString() + "";
            SqlCommand CM3 = new SqlCommand(sql3, CN);
            SqlDataReader DR3 = CM3.ExecuteReader();

            DR3.Read();
            { keychar = DR3["charname"].ToString().Trim(); }
            DR3.Close();

             int idcountweigth = 0;

            string sqlwe = "SELECT COUNT(wtype) AS idcountweigth FROM vchecknoweigth where idbranch ='" + cbbranch.SelectedValue.ToString() + "' AND wtype Like'%WI%'";

            SqlCommand CMw = new SqlCommand(sqlwe, CN);
            SqlDataReader DRw = CMw.ExecuteReader();
            DRw.Read();
            { idcountweigth = Convert.ToInt32(DRw["idcountweigth"].ToString()); }
            DRw.Close();

            if (idcountweigth != 0)
            {
                string sql = " select  wtype FROM vchecknoweigth where idbranch ='" + cbbranch.SelectedValue.ToString() + "' AND wtype Like'%WI%' order by wtype desc";

                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();
                DR.Read();
                {
                    textBox6.Text = DR["wtype"].ToString();//get weigth id type WI,WO               
                }
                DR.Close();
            }

            if (idcountweigth == 0)
            { textBox6.Text = "WO-000"; }

            textBox7.Text = idtranno;//ดึงเลขที่การชั่งของ
            textBox7.SelectionStart = 3;
            textBox7.SelectionLength = 2;
            int monthNo = Convert.ToInt16(textBox7.SelectedText.ToString());//get month runorder

            int month = Convert.ToInt16(DateTime.Now.Month.ToString());

            textBox6.SelectionStart = 3;
            textBox6.SelectionLength = 4;
            int idold = Convert.ToInt16(textBox6.SelectedText.ToString());//get month runorder
            textBox5.Text = idold.ToString();

            if (monthNo == month)//เทียบว่าเท่ากันให้บวบ  1
            {
                // idold = idold + 1;
                if (textBox5.Text.Length == 1)
                {
                    if (idold == 9)//WI-0009
                    {
                        idold = idold + 1;
                        textBox5.Text = "WI-00" + idold;
                    }
                    else //WI-0001 - WI-0008
                    {
                        idold = idold + 1;
                        textBox5.Text = "WI-000" + idold;
                    }
                }

                else if (textBox5.Text.Length == 2) //10 - 99
                {
                    if (idold == 99)//WI-0099
                    {
                        idold = idold + 1;
                        textBox5.Text = "WI-0" + idold;
                    }
                    else//WI-0011 - WI-0098}
                    {
                        idold = idold + 1;
                        textBox5.Text = "WI-00" + idold;
                    }
                }

                else if (textBox5.Text.Length == 3)
                {
                    if (idold == 999)//
                    {
                        idold = idold + 1;
                        textBox5.Text = "WI-" + idold;
                    }
                    else//WI-0101 - WI-0998}
                    {
                        idold = idold + 1;
                        textBox5.Text = "WI-0" + idold;
                    }
                }

                else if (textBox5.Text.Length == 4)
                {
                    idold = idold + 1;
                    if (idold != 10000)
                    { textBox5.Text = "WI-" + idold; }
                }
            }

            else
            { textBox5.Text = "WI-0001"; }
            CN.Close();
        }

        private void cbpassweight_CheckedChanged(object sender, EventArgs e)
        {   
            
            if (cbpassweight.Checked == true)
            {
                this.ClientSize = new System.Drawing.Size(475, 217);
           
            }
            else
            { this.ClientSize = new System.Drawing.Size(303, 217); }           
        }

        private void cbcomtran_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbcomtran.SelectedValue.ToString() == "C003")
            {
                LoadTruckNO(); LoadEmployeeDrverAll();            
            }
        }

        private void LoadTruckNO()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql2 = "select idtruck,truckserail from tbtruck  where idcargroup <> 5 and idcargroup <> 6";
            SqlDataAdapter da2 = new SqlDataAdapter(sql2, CN);
            da2.Fill(ds1, "loadtruckno");
            txtserailcar.DataSource = ds1.Tables["loadtruckno"];
            txtserailcar.DisplayMember = "truckserail";
            txtserailcar.ValueMember = "idtruck";
            CN.Close();
        }
        
        private void LoadEmployeeDrverAll()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql2 = "select idemp,empname from tbemployee where idposition = 13 ";
            SqlDataAdapter da2 = new SqlDataAdapter(sql2, CN);
            da2.Fill(ds1, "loadempdrive");
            cbnamedrive.DataSource = ds1.Tables["loadempdrive"];
            cbnamedrive.DisplayMember = "empname";
            cbnamedrive.ValueMember = "idemp";
            CN.Close();
        }

        private void LoadEmployeeDrverWhere()
        {
            try
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open(); 
                string sql = " select  idemp,empname FROM vemployeedrive where idtruck =" + txtserailcar.SelectedValue.ToString() + "";

                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();
                DR.Read();
                {
                    idempdrive = DR["idemp"].ToString();
                    cbnamedrive.Text = DR["empname"].ToString();//get weigth id type WI,WO                 
                }
                DR.Close();
                CN.Close();
            }
            catch { }
        }

        private void txtserailcar_SelectedIndexChanged(object sender, EventArgs e)
        {           
                LoadEmployeeDrverWhere();          
        }

        private void cbnamedrive_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{ idempdrive = cbnamedrive.SelectedValue.ToString(); }
            //catch { }
        }

      
    }
}