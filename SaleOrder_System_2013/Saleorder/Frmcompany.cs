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
    public partial class Frmcompany : Form
    {
        public Frmcompany()
        {
            InitializeComponent();
        }

        DataSet dts = new DataSet();
        DataSet dt = new DataSet();
        DataSet dssearch1 = new DataSet();
        DataSet dssearch2 = new DataSet();
        DataSet dscompany = new DataSet();
        DataSet dsbranch = new DataSet();
        
        string datelog = DateTime.Now.Day.ToString();
        string monthlog = DateTime.Now.Month.ToString();
        string yearlog = DateTime.Now.Year.ToString();
        string msnfrom = ""; 
        int idtypelog = 0;
        int idbranchnew = 0;
        string idcomnew = "";
        int rowindexcom = 0;
        int rowindexbranch = 0;

        //dataBranch
        int idbranch = 0;
        int idtypecom = 0;
        string idcom = "";
        int idupdate = 0;  // 1 = update company        2 = update branch

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         

        private void Frmcompany_Load(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql1 = "select * from tbtypecom ";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(dts, "loadtypecom");
            cbselecttypecom.DataSource = dts.Tables["loadtypecom"];
            cbselecttypecom.DisplayMember = "nametype";
            cbselecttypecom.ValueMember = "idtypecom";

            


            //if (status == 0)//load ค่าว่าง ปกติ
            //{
            //    string sql = "select * from tbcompany order by idcom desc";
            //    SqlCommand CM = new SqlCommand(sql, CN);
            //    SqlDataReader DR = CM.ExecuteReader();

            //    DR.Read();
            //    {
            //        txtid.Text = DR["idcom"].ToString();
            //    }
            //    DR.Close();

            //    txtid.SelectionStart = 1;
            //    txtid.SelectionLength = 4;
            //    int run =1 + Convert.ToInt16(txtid.SelectedText.ToString());

            //    txtid.Text = "C" + string.Format("{0:000}", run);

            //}

            //else //ถ้าเท่ากับ 1 ให้ load update
            //{
            //    string sql = "select * from tbcompany where idcom ='" + idcom + "'";
            //    SqlCommand CM = new SqlCommand(sql, CN);
            //    SqlDataReader DR = CM.ExecuteReader();

            //    DR.Read();
            //    {
            //        txtid.Text = Convert.ToString(DR["idcom"]).Trim();
            //        txtsearch.Text = Convert.ToString(DR["cname"]).Trim();
            //        txtremark.Text = Convert.ToString(DR["cremark"]).Trim();
            //        txtidbranch.Text = Convert.ToString(DR["idbranch"]).Trim();
                    
            //    }
            //    DR.Close();


            //    string sql2 = "select * from tbbrach where idbranch='" + txtidbranch.Text + "'";
            //    SqlCommand CM2 = new SqlCommand(sql2, CN);
            //    SqlDataReader DR2 = CM2.ExecuteReader();

            //    DR2.Read();
            //    {
            //        txtnamebranch.Text = DR2["bname"].ToString().Trim();
            //    }
            //    DR2.Close();
                
            //}

            msnfrom = this.Name.ToString();
            idtypelog = 7;//open
            
            Savelogevent();
        }

        private void btnexit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCompany()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            dscompany.Clear();
            dtgcompany.DataSource = dssearch1;

            if (idtypecom != 0)
            {
                string sql1 = "select * from vtbcom where idtypecom=" + idtypecom + "";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                da1.Fill(dscompany, "tbcom");
                dtgcompany.DataSource = dscompany.Tables["tbcom"];

                string sql2 = "select * from tbtypecom where idtypecom=" + idtypecom + "";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();
                DR2.Read();
                {
                    lblinformation1.Text = DR2["remarktype"].ToString().Trim(); lblinformation1.ForeColor = Color.Red;
                }
                DR2.Close();

                lblcountcom.Text = "Total: " + dtgcompany.RowCount.ToString() + " Items";
                CN.Close();
            }
        }

        private void Loadbranch()
        {            
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); 
            dsbranch.Clear();           
            dtgbranch.DataSource = dssearch2;
            string sql = "select * from vbranch where idcom ='"+ idcom +"' ";
            SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
            da1.Fill(dsbranch, "sbranch");
            dtgbranch.DataSource = dsbranch.Tables["sbranch"];
            lblcountbranch.Text = "";
            lblcountbranch.Text = "Total: " + dtgbranch.RowCount.ToString() + " Items";
           
        }   

        private void btnaddedit_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
                       
            if (cbaddcom.Checked == true)//insert com
            {
                if (dtgbranch.RowCount == 1)//check ข้อมูลสาขา
                {
                    MessageBox.Show("คุณไม่ได้ระบุข้อมูลสาขา");
                }

                else if (dtgcompany.RowCount == 1)
                {
                    MessageBox.Show("คุณไม่ได้ระบุข้อมูลบริษัท");
                }
                else  //save step by step
                {
                    //บันทึกสาขา  -> ดึง ID สาขาที่บันทึกล่าสุด -> ดึง ID บริษัทที่บันทึกล่าสุด -> บันทึกบริษัท

                    //บันทึกสาขา
                    string bname = dtgbranch[1, 0].Value.ToString();
                    string baddress = dtgbranch[2, 0].Value.ToString();
                    string rd = dtgbranch[3, 0].Value.ToString();
                    string tumb = dtgbranch[4, 0].Value.ToString();
                    string country = dtgbranch[5, 0].Value.ToString();
                    string provice = dtgbranch[6, 0].Value.ToString();
                    string zipcode =dtgbranch[7, 0].Value.ToString();
                    string tel = dtgbranch[8, 0].Value.ToString();
                    string fax = dtgbranch[9, 0].Value.ToString();
                    string contact = dtgbranch[10, 0].Value.ToString();
                    string remark = dtgbranch[11, 0].Value.ToString();

                    if (dtgbranch[1, 0].Value.ToString() == "")
                    { MessageBox.Show("กรุณาระบุชื่อสาขาใหม่", "Error !"); }

                    if (dtgbranch[2, 0].Value.ToString() == "")
                    { baddress = "-"; }

                    if (dtgbranch[3, 0].Value.ToString() == "")
                    { rd = "-"; }

                    if (dtgbranch[4, 0].Value.ToString() == "")
                    { tumb = "-"; }

                    if (dtgbranch[5, 0].Value.ToString() == "")
                    { country = "-"; }

                    if (dtgbranch[6, 0].Value.ToString() == "")
                    { provice = "-"; }

                    if (dtgbranch[7, 0].Value.ToString() == "")
                    { zipcode = "0"; }

                    if (dtgbranch[8, 0].Value.ToString() == "")
                    { tel = "-"; }

                    if (dtgbranch[9, 0].Value.ToString() == "")
                    { fax = "-"; }

                    if (dtgbranch[10, 0].Value.ToString() == "")
                    { contact = "-"; }

                    if (dtgbranch[11, 0].Value.ToString() == "")
                    { remark = "-"; }
                    
                    string sql1 = "insert into tbbrach(bname,baddress,rd,tumb,country,provice,zipcode,tel,fax,contact,remark) values ('" + bname + "','" + baddress + "','" + rd + "','" + tumb + "','" + country + "','" + provice + "'," + zipcode + ",'" + tel + "','" + fax + "','" + contact + "','" + remark + "')";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    CM1.ExecuteNonQuery();

                    //ดึง ID สาขาที่บันทึกล่าสุด
                    LoadMaxiDBranchNew();

                    //ดึง ID บริษัทที่บันทึกล่าสุด
                    LoadMaxiDComNew();

                    //บันทึกบริษัท
                    string sql2 = "insert into tbcompany(idcom,cname,cremark,idbranch,idtypecom) values ('" + idcomnew + "','" + dtgcompany[1, 0].Value.ToString().Trim() + "','" + dtgcompany[2, 0].Value.ToString().Trim() + "'," + idbranchnew + "," + idtypecom + ")";
                    SqlCommand CM2 = new SqlCommand(sql2, CN);
                    CM2.ExecuteNonQuery();

                    MessageBox.Show("บันทึกข้อมูลประสบความสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    msnfrom = this.Name.ToString();
                    idtypelog = 1;//insert
                    Savelogevent();
                    cbaddcom.Checked = false;
                    LoadCompany();
                }
            
            }

           else if (cbaddcom.Checked == false || cbaddbranch.Checked==false)//update company and branch
            {
                if (idupdate == 1) //update company
                {
                    string sql = "update tbcompany set cname='" + dtgcompany[1, rowindexcom].Value.ToString() + "',cremark='" + dtgcompany[2, rowindexcom].Value.ToString() + "' Where idcom='" + idcom + "'";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();
                    MessageBox.Show("ปรับปรุงข้อมูลเรียบร้อย !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    msnfrom = this.Name.ToString();
                    idtypelog = 2;//update
                    Savelogevent();
                }

                if (idupdate == 2)//update branch
                {
                    string sql = "update tbbrach set bname='" + dtgbranch[1, rowindexbranch].Value.ToString() + "',baddress='" + dtgbranch[2, rowindexbranch].Value.ToString() + "',rd='" + dtgbranch[3, rowindexbranch].Value.ToString() + "',tumb='" + dtgcompany[4, rowindexbranch].Value.ToString() + "',country='" + dtgbranch[5, rowindexbranch].Value.ToString() + "',provice='" + dtgbranch[6, rowindexbranch].Value.ToString() + "',zipcode=" + dtgbranch[7, rowindexbranch].Value.ToString() + ",tel='" + dtgbranch[8, rowindexbranch].Value.ToString() + "',fax='" + dtgbranch[9, rowindexbranch].Value.ToString() + "',contact='" + dtgbranch[10, rowindexbranch].Value.ToString() + "',remark='" + dtgbranch[11, rowindexbranch].Value.ToString() + "' Where idcom='" + idcom + "'";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();
                    MessageBox.Show("ปรับปรุงข้อมูลเรียบร้อย !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                }
            }

              
            //if (status == 0) // insert
            //{
            //    string sql = "insert into tbcompany(idcom,cname,cremark,idbranch) values ('" + txtid.Text + "','" + txtsearch.Text + "','" + txtremark.Text + "'," + txtidbranch.Text + ")";

            //    SqlCommand CM = new SqlCommand(sql, CN);
            //    CM.ExecuteNonQuery();

            //    MessageBox.Show("บันทึกข้อมูลประสบความสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    msnfrom = this.Name.ToString();
            //    idtypelog = 1;//insert
            //    Savelogevent();
            //    this.Close();
            //}

            //else if (txtid.Text != "" && status != 0 && txtsearch.Text != "" && txtremark.Text != "")
            //{
            //    try
            //    {
            //        string sql = "update tbcompany set cname='" + txtsearch.Text + "',cremark='" + txtremark.Text + "',idbranch=" + txtidbranch.Text + " Where idcom='" + txtid.Text + "'";
            //        SqlCommand CM = new SqlCommand(sql, CN);
            //        CM.ExecuteNonQuery();

            //        MessageBox.Show("ปรับปรุงข้อมูลเรียบร้อย !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        txtid.Clear();
            //        txtidbranch.Clear();
            //        txtsearch.Clear();
            //        txtnamebranch.Clear();
            //        txtremark.Clear();
            //        msnfrom = this.Name.ToString();
            //        idtypelog = 2;//update
            //        Savelogevent();
            //        this.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("ข้อมูลต้องครบทุกช่อง" + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{
            //    {
            //        MessageBox.Show("ข้อมูลต้องครบทุกช่อง", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }      
  
        private void Savelogevent()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string selectdatelog = monthlog + "/" + datelog + "/" + yearlog;
            string sql1 = "insert into tblog(logname,datein,timein,idtypelog,idemp,remark) values('" + msnfrom + "','" + selectdatelog + "','" + DateTime.Now.ToLongTimeString() + "'," + idtypelog + ",'" + Program.empID + "','" + idcom + "')";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            CM1.ExecuteNonQuery();
            CN.Close();
        }

        private void Frmcompany_FormClosed(object sender, FormClosedEventArgs e)
        {
            msnfrom = this.Name.ToString();
            idtypelog = 6;//close
            Savelogevent();
        }
               
        private void cbselecttypecom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbselecttypecom.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                idtypecom = Convert.ToInt16(cbselecttypecom.SelectedValue.ToString());
                if (cbaddcom.Checked != true)
                { LoadCompany(); }
                else dscompany.Clear();
            }            
        }

        private void dtgcompany_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
               idcom = dtgcompany[0, e.RowIndex].Value.ToString().Trim();
               rowindexcom = e.RowIndex;
                Loadbranch();
            }
            catch { }

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            dscompany.Clear();
            dtgcompany.DataSource = dssearch1;
            string sql = "";
            if (txtsearch.Text != "")
            {
                 sql = "select * from vtbcom where cname like '%" + txtsearch.Text.Trim() + "%' AND idtypecom=" + cbselecttypecom.SelectedValue.ToString().Trim() + "";

            }
            else
            {
                 sql = "select * from vtbcom where idtypecom=" + cbselecttypecom.SelectedValue.ToString().Trim() + "";
            }
            SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
            da1.Fill(dscompany, "tbcom");
            dtgcompany.DataSource = dscompany.Tables["tbcom"];
            lblcountbranch.Text = "Total Company: " + dtgcompany.RowCount.ToString() + " Items";
            CN.Close();
        }
        
        private void cbaddbranch_CheckedChanged(object sender, EventArgs e)
        {
            if (cbaddbranch.Checked == true)
            {
                //cbselecttypecom.Enabled = false;
                //txtsearch.Enabled = false; status = 0;

                //FrmAddCom fac = new FrmAddCom();
                //fac.ShowDialog();
                //bname = fac.bname;
                //baddress = fac.baddress;
                //rd = fac.rd;
                //tumb = fac.tumb;
                //country = fac.country;
                //provice = fac.provice;
                //zipcode = fac.zipcode;
                //tel = fac.tel;
                //fax = fac.fax;
                //remark = fac.remark;
                //contact = fac.contact;
                //idtypecom = fac.idtypecom;

                //lblinformation.Text = "กรุณาใส่ชื่อบริษัทที่ต้องการเพิ่มใหม่"; 
                //lblinformation.ForeColor = Color.Red;

                //LoadBranchNew();
                //dscompany.Clear();
                //dsbranch.Clear(); dtgbranch.Enabled = false; 
                                
                dtgbranch.AllowUserToAddRows = true;
                txtsearch.Enabled = false;
                label5.Visible = true;

                if (cbaddcom.Checked == true)
                { dsbranch.Clear(); }

                else
                {
                    int rowindex = dtgbranch.RowCount;                    
                }
            }
            else { 
                Loadbranch();
                dtgbranch.AllowUserToAddRows = false; 
                txtsearch.Enabled = true; 
                label5.Visible = false;
            }
        }      
             
        private void LoadMaxiDComNew()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql = " select max(idcomauto)as idcomnew from tbcompany";
            SqlCommand CM = new SqlCommand(sql, CN);
            SqlDataReader DR = CM.ExecuteReader();
            DR.Read();
            {
                idcomnew = "C" + Convert.ToString(1 + Convert.ToInt16(DR["idcomnew"].ToString())); 
            }
            DR.Close();
            CN.Close();
        }

        private void LoadMaxiDBranchNew()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql = " select max(idbranch)as idbranchnew from tbbrach";
            SqlCommand CM = new SqlCommand(sql, CN);
            SqlDataReader DR = CM.ExecuteReader();
            DR.Read();
            {
                idbranchnew = Convert.ToInt16(DR["idbranchnew"].ToString());
            }
            DR.Close();
            CN.Close();
        }

        private void cbaddcom_CheckedChanged(object sender, EventArgs e)
        {
            if (cbaddcom.Checked == true)
            {
                dtgcompany.AllowUserToAddRows = true;
                cbaddbranch.Checked = true;
                cbaddbranch.Enabled = false;
                dscompany.Clear(); txtsearch.Enabled = false;              
                label2.Visible = true;
            }

            else { 
                dtgcompany.AllowUserToAddRows = false; 
                cbaddbranch.Checked = false; 
                cbaddbranch.Enabled = true;
                label2.Visible = false;
                LoadCompany(); 
            }
        }

        private void btnoption_Click(object sender, EventArgs e)
        {
            if (idbranch != 0)
            {
                FrmselectOption fselop = new FrmselectOption();
                fselop.idoption = 1;
                fselop.idbranch = idbranch;
                fselop.idvalue = idcom;
                fselop.ShowDialog();
            }
        }

        private void dtgbranch_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                idbranch = Convert.ToInt16(dtgbranch[0, e.RowIndex].Value.ToString().Trim());
                rowindexbranch = e.RowIndex;
            }
            catch { }
        }

        private void dtgcompany_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            idupdate = 1;
        }

        private void dtgbranch_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            idupdate = 2;
        }

    }
}
