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
    public partial class FrmbuttonControl : Form
    {
        public FrmbuttonControl()
        {
            InitializeComponent();
        }

       // dtssaleorder dssearch = new dtssaleorder(); 
        DataSet ds = new DataSet();
        dtssaleorder dssearch1 = new dtssaleorder();
        dtssaleorder dssearch2 = new dtssaleorder();
        dtssaleorder dssearch3 = new dtssaleorder();
        dtssaleorder dssearch4 = new dtssaleorder();
        dtssaleorder dssearch5 = new dtssaleorder();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet ds4 = new DataSet();
        DataSet ds5 = new DataSet();
        DataSet ds6 = new DataSet();
        DataSet ds7 = new DataSet();

        int cstatus = 0;
        int cinsert = 0;
        int cupdate = 0;
        int cdelect = 0;
        
        string datelog = DateTime.Now.Day.ToString();
        string monthlog = DateTime.Now.Month.ToString();
        string yearlog = DateTime.Now.Year.ToString();
        
        //Main Search
        string idmdetail = "";  
        string idemp = "0";
       
        //Chage DATA
        int idunluck = 0;
        string idempunlock = "";
        int Checklock = 0;        

        //Button
        int idmenu = 0;
        string menuname = ""; 
        int idbtn = 0;
                
        //Report
        int idmenureport = 0;
        string check = "false";
        int rpcount = 0;
        int updateingrid = 0;

        //Save Event
        int idtypelog = 0;                   
        string msnfrom = "";                
        string eventstatus = "";  

        private void resetcheckbox()
        {
            cstatus = 0;
            cinsert = 0;
            cupdate = 0;
            cdelect = 0;           
        }        

        private void FrmbuttonControl_Load(object sender, EventArgs e)
        {    
            LoadEmplyeeList();//load employee  
            LoadGridMenu();//load menu for comb
            LoadMenuUnlock();
            LoadMenureport();
            DisableControl();
            msnfrom = this.Name.ToString();
            idtypelog = 7;//open
            Savelogevent();           
        }

        private void DisableControl()
        {
            gbobtn.Enabled = false;
            gbochagedata.Enabled = false;
            gborp.Enabled = false;        
        }

        private void EnableControl()
        {
            gbobtn.Enabled = true;
            gbochagedata.Enabled = true;
            gborp.Enabled = true;
        }

        private void LoadGridMenu()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql1 = "select * from tbmenu";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1,CN);
            da1.Fill(ds, "loadmenu");
            cmbmenu.DataSource = ds.Tables["loadmenu"];
            cmbmenu.DisplayMember = "menuname";
            cmbmenu.ValueMember = "idmenu";
            CN.Close();
        }

        private void LoadMenuUnlock()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql = "select * from tbmenuunlock";
            SqlDataAdapter da7 = new SqlDataAdapter(sql, CN);
            da7.Fill(ds7, "loadmunlock");
            cmbmenulock.DataSource = ds7.Tables["loadmunlock"];
            cmbmenulock.DisplayMember = "menuname";
            cmbmenulock.ValueMember = "idmenuunlock";            
            CN.Close();
        }

        private void LoadEmplyeeList()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql = "select idemp,empname,positionname from vemployee";
            SqlDataAdapter da = new SqlDataAdapter(sql, CN);
            da.Fill(ds, "LoadEmp");
            cboemployee.DataSource = ds.Tables["LoadEmp"];
            cboemployee.DisplayMember = "empname";          
            cboemployee.ValueMember = "idemp";             
        }               

        private void CheckBoxStatus()
        {
            if (cbmstatus.Checked == true)
            {
                cstatus = 1;
            }
            if (cbbtninsert.Checked == true)
            {
                cinsert = 1;
            }
            if (cbbtnupdate.Checked == true)
            {
                cupdate = 1;
            }
            if (cbbtndelect.Checked == true)
            {
                cdelect = 1;
            }
            
        }

        private void dtgemp_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            check = "true"; //เอาไว้ให้ cbomenu check ว่ามีการเรียนใช้จริง
            ds1.Clear(); dssearch1.Clear();            

            CheckboxAllFale();
            CheckboxDasible();
            cmbmenu.Enabled = true;
            LoadGridBTNfromSelect();                    
        }

        private void LoadGridBTNfromSelect()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            idemp = cboemployee.SelectedValue.ToString().Trim();
            dtgvlogin.DataSource = dssearch1;
            string sql = "select * from vpermision where idemp='" + idemp + "'";
            SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
            da1.Fill(ds1, "slogin");
            dtgvlogin.DataSource = ds1.Tables["slogin"];
            dtgvlogin.Visible = true;

            if (dtgvlogin.RowCount == 0)
            {
                CheckboxEnable();
            }
            CN.Close();
        }

        private void LoadPermissionBTN()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); dssearch1.Clear(); ds1.Clear();
            dtgvlogin.DataSource = dssearch1;
            String sql = "select * from vpermision where idemp='" + idemp + "'";
            SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
            da1.Fill(ds1, "slogin");
            dtgvlogin.DataSource = ds1.Tables["slogin"];
            dtgvlogin.Visible = true;

            if (dtgvlogin.RowCount == 0)
            {
                CheckboxEnable();
            }
        }

        private void LoadSearchEmpUnlock()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql1 = "select count(idempunlock)as empunlock from vunlockpwd where idemplock='" + idemp + "' AND idmenuunlock='" + cmbmenulock.SelectedValue.ToString() + "'";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                Checklock = Convert.ToInt16(DR1["empunlock"].ToString());
            }
            DR1.Close();

            if (Checklock == 1)//ถ้าค้นหาแล้วมีข้อมูลให้โชว์ที่หน้าข้อมูล
            {
                string sql2 = "select idempunlock,empunlock from vunlockpwd where idemplock='" + idemp + "' AND idmenuunlock='" + idunluck + "'";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();

                DR2.Read();
                {
                    idempunlock = DR2["idempunlock"].ToString();
                    txtnameunlock.Text = DR2["empunlock"].ToString();
                    DR2.Close();
                }
                if (Checklock == 0)
                {
                    idempunlock = "";
                    txtnameunlock.Clear();
                }
            }
            CN.Close();
        }
   
        private void CheckboxEnable()
        {           
            cbcheckall.Enabled = true;
            cbbtndelect.Enabled = true;           
            cbbtninsert.Enabled = true;           
            cbbtnupdate.Enabled = true;
            cbmstatus.Enabled = true;            
        }

        private void CheckboxDasible()
        {            
            cbcheckall.Enabled = false;
            cbbtndelect.Enabled = false;            
            cbbtninsert.Enabled = false;           
            cbbtnupdate.Enabled = false;
            cbmstatus.Enabled = false;
          
        }

        private void CheckboxAllTrue()
        {            
            cbbtndelect.Checked = true;            
            cbbtninsert.Checked = true;           
            cbbtnupdate.Checked = true;
            cbmstatus.Checked = true;            
        }

        private void CheckboxAllFale()
        {
            cbbtndelect.Checked = false;            
            cbbtninsert.Checked = false;            
            cbbtnupdate.Checked = false;
            cbmstatus.Checked = false;            
        }

        private void dtgvlogin_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            eventstatus = "update";
            idmdetail = dtgvlogin[0, e.RowIndex].Value.ToString().Trim();
            menuname = dtgvlogin[2, e.RowIndex].Value.ToString().Trim();           
            CheckboxEnable();

            if (e.RowIndex < 0) return;

            if (dtgvlogin[2, e.RowIndex].Value.ToString() == "True")
            {
                cbmstatus.Enabled = true; cbmstatus.Checked = true;
            }
            if (dtgvlogin[3, e.RowIndex].Value.ToString() == "True")
            {
                cbbtninsert.Enabled = true; cbbtninsert.Checked = true;
            }
            if (dtgvlogin[4, e.RowIndex].Value.ToString() == "True")
            {
                cbbtnupdate.Enabled = true; cbbtnupdate.Checked = true;
            }
            if (dtgvlogin[5, e.RowIndex].Value.ToString() == "True")
            {
                cbbtndelect.Enabled = true; cbbtndelect.Checked = true;
            }  
        }

        private void cmbmenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); dssearch1.Clear();          

            if (check == "true" && idemp != "" && idemp != "System.Data.DataRowView")
            {
                string sql = "select count(idmenu)as anwer from tbmenudetail where idmenu=" + cmbmenu.SelectedValue.ToString() + " and idemp ='" + idemp + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                DR.Read();
                {
                    if (DR["anwer"].ToString() == "1")//edit
                    {
                        CheckboxAllFale(); CheckboxDasible();
                        eventstatus = "update";
                    }

                    if (DR["anwer"].ToString() == "0") //insert
                    {
                        CheckboxAllFale(); CheckboxEnable();
                        eventstatus = "insert";
                    }
                }
                DR.Close();
            }
            CN.Close();
        }

        private void FrmbuttonControl_FormClosed(object sender, FormClosedEventArgs e)
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
            string sql1 = "insert into tblog(logname,datein,timein,idtypelog,idemp,remark) values('" + msnfrom + "','" + selectdatelog + "','" + DateTime.Now.ToLongTimeString() + "'," + idtypelog + ",'" + Program.empID + "','" + idbtn + "')";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            CM1.ExecuteNonQuery();
            CN.Close();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbcheckall_CheckedChanged(object sender, EventArgs e)
        {
            if (cbcheckall.Checked == true)
            {
                CheckboxAllTrue();
            }
            else { CheckboxAllFale(); }
        }
             
        private void SearchEmpunlock()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            if (idempunlock != "")
            {
                string sql = "select empname from vemployee where idemp='" + idempunlock + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                { txtnameunlock.Text = DR1["empname"].ToString().Trim(); }
                DR1.Close();
            }
            CN.Close();
        }

        private void btnsaveunlock_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();  
            if (Checklock == 0 )//insert user unlock
            {                                
                    if (txtnameunlock.Text != "")
                    {
                        string sqlb = "insert into tbunlockchangedata(iduser,idunlockpwd,idmenuunlock) values ('" + idemp + "','" + idempunlock + "','" + cmbmenulock.SelectedValue.ToString() + "')";

                        SqlCommand CMb = new SqlCommand(sqlb, CN);
                        CMb.ExecuteNonQuery();
                        // btnunlock.Enabled = true;                              
                        MessageBox.Show("Update Btn-Unlock OK", "BTN Unlock Report!", MessageBoxButtons.OK);
                    }
                    else MessageBox.Show("คุณยังไม่ได้ระบุชื่อผู้ปลดล็อค");                
            }

            if (Checklock == 1)//updateuser unlock=
            {
                string sqlb = "update tbunlockchangedata set idunlockpwd ='" + idempunlock + "' where idmenuunlock ='" + idunluck + "' AND iduser ='" + idemp + "'";
                SqlCommand CMb = new SqlCommand(sqlb, CN);
                CMb.ExecuteNonQuery();
               // btnunlock.Enabled = true;                        
                MessageBox.Show("Update Btn-Unlock OK", "BTN Unlock Report!", MessageBoxButtons.OK);
                
            }
            CN.Close();

            LoadChangData();
        }

        private void cbounlockbtn_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSearchEmpUnlock();
        }

        private void cboemployee_SelectedIndexChanged(object sender, EventArgs e)
        {  
            check = "true"; //เอาไว้ให้ cbomenu check ว่ามีการเรียนใช้จริง    
            idemp = cboemployee.SelectedValue.ToString().Trim();
            cboemployee.Text = "";
            CheckboxAllFale();
            CheckboxDasible();
            LoadEmpdetail();
            LoadPermissionBTN();
            LoadChangData();
            LoadReport();
            EnableControl();
            cmbmenu.Enabled = true;
            //idemp = "";
            //txtnameunlock.Clear();            
        }

        private void LoadChangData()//unlock
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); ds3.Clear(); dssearch3.Clear();

            dtgunlock.DataSource = dssearch3;
            string sql = "select idmenuunlock,menuname,empunlock from vunlockpwd where idemplock='" + idemp.Trim() + "' ";
            SqlDataAdapter da3 = new SqlDataAdapter(sql, CN);
            da3.Fill(ds3, "unlock");
            dtgunlock.DataSource = ds3.Tables["unlock"];
            txtnameunlock.Clear();
            CN.Close();
        }

        private void LoadReport()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); ds2.Clear(); dssearch2.Clear();
            dtgempreport.DataSource = dssearch2;
            string sql = "select * from vsettingreport where idemp='" + idemp.Trim() + "' ";
            SqlDataAdapter da2 = new SqlDataAdapter(sql, CN);
            da2.Fill(ds2, "sempre");
            dtgempreport.DataSource = ds2.Tables["sempre"];
            CN.Close(); 
        }             

        private void LoadEmpdetail()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); string empdetail="";
            if (idemp != "" && idemp !="System.Data.DataRowView")
            {
                //idemp,depname,bname,cname,nametype,positionname
                string sql = "select idemp,depname,bname,cname,nametype,positionname from vemployee where idemp='" + idemp + "'";
                SqlCommand CM1 = new SqlCommand(sql, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    empdetail += "รหัส: " + DR1["idemp"].ToString().Trim();
                    empdetail += " แผนก: " + DR1["depname"].ToString().Trim();
                    empdetail += " สาขา: " + DR1["bname"].ToString().Trim();
                    empdetail += " สังกัด: " + DR1["cname"].ToString().Trim();
                    empdetail += " ประเภท: " + DR1["nametype"].ToString().Trim();
                    empdetail += " ตำแหน่ง: " + DR1["positionname"].ToString().Trim();                 
                }
                DR1.Close();

                lblempdetail.Text = empdetail;
            }
            CN.Close();
        
        }

        private void btnsearchempunlock_Click(object sender, EventArgs e)
        {
            Frmserch fs = new Frmserch();
            fs.sname = "sempployee";
            fs.ShowDialog();
            if (fs.returnid.Trim() != "0")
            {
                idempunlock = fs.returnid;
                SearchEmpunlock();
            }
        }

        private void dtgunlock_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idunluck = Convert.ToInt16(dtgunlock[0, e.RowIndex].Value.ToString());
            LoadSearchEmpUnlock();
        }

        private void CheckReport()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql1 = "select count(idreport)as rpcount from vsettingreport where idemp='" + idemp + "'AND idreport=" + idmenureport + "";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                rpcount = Convert.ToInt16(DR1["rpcount"].ToString());
            }
            DR1.Close();
        }

        private void btnsavereport_Click(object sender, EventArgs e)
        {
            CheckReport();
            int isviewer = 0;           

            if (cbuse.Checked == true)
            { isviewer = 1; }

            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            if (rpcount == 0)
            {
                string sqla = "insert into tbreportdetail(idreport,isviewer,idemp) values (" + cbreportname.SelectedValue.ToString() + "," + isviewer + ",'" + idemp + "')";

                SqlCommand CMa = new SqlCommand(sqla, CN);
                CMa.ExecuteNonQuery();
            }

            if (rpcount != 0 && updateingrid == 0)
            {
                string sqla = "update tbreportdetail set isviewer =" + isviewer + " where idemp ='" + idemp + "' AND idreport=" + cbreportname.SelectedValue.ToString() + " ";

                SqlCommand CMa = new SqlCommand(sqla, CN);
                CMa.ExecuteNonQuery();
            }

            if (updateingrid == 1)
            {
                string sqla = "update tbreportdetail set isviewer =" + isviewer + " where idemp ='" + idemp + "' AND idreport=" + cbreportname.SelectedValue.ToString() + " ";

                SqlCommand CMa = new SqlCommand(sqla, CN);
                CMa.ExecuteNonQuery();
            }

            MessageBox.Show("ข้อมูลทำการปรับปรุงแล้ว ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cbuse.Checked = false;
            SearchReportuser();
        }

        private void btnsavebtncontrol_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (eventstatus == "insert") //insert
            {
                CheckBoxStatus();
                string sqla = "insert into tbbutton(btninsert,btnedit,btndelect) values (" + cinsert + "," + cupdate + "," + cdelect + ")";

                SqlCommand CMa = new SqlCommand(sqla, CN);
                CMa.ExecuteNonQuery();

                string sql = "select max(idbtn) as 'maxid' from tbbutton";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                DR.Read();
                {
                    idbtn = Convert.ToInt16(DR["maxid"].ToString());
                }
                DR.Close();

                string sqlb = "insert into tbmenudetail(status,idbtn,idemp,idmenu) values (" + cstatus + "," + idbtn + ",'" + idemp + "'," + cmbmenu.SelectedValue.ToString() + ")";

                SqlCommand CMb = new SqlCommand(sqlb, CN);
                CMb.ExecuteNonQuery();

                MessageBox.Show("บันทึกข้อมูลประสบความสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds1.Clear(); dssearch1.Clear();
                CheckboxAllFale();
                CheckboxDasible();
                resetcheckbox();

                msnfrom = this.Name.ToString();
                idtypelog = 1;//insert
                Savelogevent();
            }

            if (eventstatus == "update")//update 
            {
                CheckBoxStatus();

                string sql = "select idbtn from tbmenudetail where idmdetail =" + idmdetail + "";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                DR.Read();
                {
                    idbtn = Convert.ToInt16(DR["idbtn"].ToString());
                }
                DR.Close();

                string sqla = "update tbbutton set btninsert=" + cinsert + ",btnedit =" + cupdate + ",btndelect =" + cdelect + " Where idbtn= " + idbtn + "";

                SqlCommand CMa = new SqlCommand(sqla, CN);
                CMa.ExecuteNonQuery();

                string sqlb = "update tbmenudetail set status =" + cstatus + " where idmdetail =" + idmdetail + "";
                SqlCommand CMb = new SqlCommand(sqlb, CN);
                CMb.ExecuteNonQuery();

                MessageBox.Show("ข้อมูลทำการปรับปรุงแล้ว ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CheckboxAllFale();
                CheckboxDasible();
                resetcheckbox();

                ds1.Clear();
                dssearch1.Clear();
                msnfrom = this.Name.ToString();
                idtypelog = 2;//update
                Savelogevent();
            }

            cbcheckall.Checked = false;
            CN.Close();
            LoadGridBTNfromSelect();
        }

        private void cbreportname_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); dssearch1.Clear();

            if (idemp != "" && idemp != "System.Data.DataRowView")
            {
                string sql = "select count(idreport)as anwer from tbreportdetail where idreport=" + cbreportname.SelectedValue.ToString() + " and idemp ='" + idemp + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                DR.Read();
                {
                    if (DR["anwer"].ToString() == "1")//edit
                    {
                        cbuse.Enabled = false;
                       eventstatus = "update";
                    }

                    if (DR["anwer"].ToString() == "0") //insert
                    {
                       cbuse.Enabled = true;
                       eventstatus = "insert";
                    }
                }
                DR.Close();
            }
            CN.Close();
        }

        private void SearchReportuser()
        {
            ds5.Clear(); dssearch5.Clear();
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            dtgempreport.DataSource = dssearch5;
            string sql = "select * from vsettingreport where idemp='" + idemp + "' ";
            SqlDataAdapter da5 = new SqlDataAdapter(sql, CN);
            da5.Fill(ds5, "rpmenu");
            dtgempreport.DataSource = ds5.Tables["rpmenu"];
            dtgempreport.Visible = true;          

            for (int i = 0; i < dtgempreport.RowCount; i++)
            {
                if (dtgempreport[2, i].Value.ToString() == "False")
                {
                    dtgempreport.Rows[i].DefaultCellStyle.BackColor = Color.Gainsboro;
                }
            }
            updateingrid = 0;
        }

        private void dtgempreport_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idmenureport = Convert.ToInt16(dtgempreport[0, e.RowIndex].Value.ToString());
            cbuse.Enabled = true;
            if (dtgempreport[2, e.RowIndex].Value.ToString() == "True")
            { cbuse.Checked = true; }
            else cbuse.Checked = false;
        }

        private void LoadMenureport()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql2 = "select * from tbmenureport ";
            SqlDataAdapter da4 = new SqlDataAdapter(sql2, CN);
            da4.Fill(ds4, "loadreport");
            cbreportname.DataSource = ds4.Tables["loadreport"];
            cbreportname.DisplayMember = "reportname";
            cbreportname.ValueMember = "idreport";
        }       

        private void cmbmenulock_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); dssearch1.Clear();

            //if (cmbmenulock.SelectedValue.ToString() != "System.Data.DataRowView")
            //{idunluck = Convert.ToInt16(cmbmenulock.SelectedValue.ToString());}

            if (cmbmenulock.SelectedValue.ToString() != "System.Data.DataRowView" || idemp != "System.Data.DataRowView")
            {
                string sql = "select count(idmenuunlock)as anwer from vunlockpwd where idmenuunlock=" + cmbmenulock.SelectedValue.ToString() + " and idemplock ='" + idemp + "'";

             //   string sql = "select count(idmenu)as anwer from vpermision where idmenu=" + cmbmenulock.SelectedValue.ToString() + " and idemp ='" + idemp + "'";

                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                DR.Read();
                {
                    if (DR["anwer"].ToString() == "1")//edit
                    { eventstatus = "update"; Checklock = 1;}

                    if (DR["anwer"].ToString() == "0") //insert
                    { eventstatus = "insert"; Checklock = 0;  idempunlock = ""; txtnameunlock.Clear(); }
                }
                DR.Close();


            }
            CN.Close();
        }

    }
}