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
    public partial class Frmpayjob : Form
    {
        public Frmpayjob()
        {
            InitializeComponent();
        }

        string idpur = "0"; string idcus = "0"; string dateWbf = "0"; string idtranno = "0";
        string idtran = "0"; int idmatchok = 0; string idcomtran = ""; string wtype = "";
        dtssaleorder dssearch = new dtssaleorder(); DataSet ds = new DataSet();
        DataSet ds1 = new DataSet(); dtssaleorder dssearch1 = new dtssaleorder();
        DataSet ds2 = new DataSet(); dtssaleorder dssearch2 = new dtssaleorder();
        DataSet ds3 = new DataSet(); dtssaleorder dssearch3 = new dtssaleorder();
        DataSet ds4 = new DataSet(); dtssaleorder dssearch4 = new dtssaleorder();
        DataSet ds5 = new DataSet(); dtssaleorder dssearch5 = new dtssaleorder();
        DataSet ds6 = new DataSet(); dtssaleorder dssearch6 = new dtssaleorder();
        int idsearchorder = 0;
        int idselectcancle = 0;
       
        private void dtgpurtranstatus_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisableAllbtn();

            if (dtgpurtranstatus[1, e.RowIndex].Value.ToString().Trim() == "-")
            {
                txtfrom.BackColor = Color.LightGreen;
                idpur = Convert.ToString(dtgpurtranstatus[0, e.RowIndex].Value.ToString());
                idselectcancle = 1;//ส่งไอดีไปยกเลิก       
                btnsplit.Enabled = false;
                btnsend.Enabled = true;
                btnchangdata.Enabled = true;
                btncancleorder.Enabled = true;
                SearchIDcomtran();
            }
        }
               
        private void dtgpurtranstatus_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisableAllbtn();

            if (dtgpurtranstatus[1, e.RowIndex].Value.ToString().Trim() == "-") 
            {
                FrmSelectMoveJob fsmo = new FrmSelectMoveJob();
                fsmo.typejob = 1;//ส่งค่าจ่ายงานจากการซื้อ                   
                fsmo.idpur = Convert.ToString(dtgpurtranstatus[0, e.RowIndex].Value.ToString());                
                fsmo.xposition = Convert.ToInt16(MousePosition.X);
                fsmo.yposition = Convert.ToInt16(MousePosition.Y);
                fsmo.ShowDialog();
                LoadAllGrid();
            }
        }
                
        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult answer;
            answer = MessageBox.Show("คุณต้องการยกเลิกรายการนี้ใช่หรือไม่ !", "กรุณายืนยัน !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (answer == DialogResult.OK)
            {
                if (rdomainmovejob.Checked == true || rdoptos.Checked == true)
                {
                    //FrmRemarkCancaljob frcj = new FrmRemarkCancaljob();
                    //if (idselectcancle == 1 && rdomainmovejob.Checked == true)//ยกเลิกการรับเข้า
                    //{
                    //    frcj.idchage = 1;
                    //    frcj.idcancle = idpur;
                    //    frcj.ShowDialog(); 
                    //}
                    //if (idselectcancle == 2 && rdomainmovejob.Checked == true)//ยกเลิกการส่งสินค้า
                    //{
                    //    frcj.idchage = 2;
                    //    frcj.idcancle = idcus;
                    //    frcj.ShowDialog(); 
                    //}
                    //if (rdoptos.Checked == true)//ยกเลิกซื้อมาขายไป
                    //{
                    //    frcj.idchage = 3;
                    //    frcj.idcancle = idtran;
                    //    frcj.ShowDialog();                       
                    //}                    
                }

                if (rdotout.Checked == true || rdotin.Checked == true)
                {
                    //Frmselectcanclejob fslcc = new Frmselectcanclejob();
                    //if (rdotin.Checked == true)//ยกเลิกการจ่ายเข้าคลัง
                    //{
                    //    fslcc.idpur = idpur;
                    //    fslcc.idselect = 1;
                    //    fslcc.ShowDialog();
                    //}

                    //if (rdotout.Checked == true)//ยกเลิกการจ่ายออกคลัง
                    //{
                    //    fslcc.idsale = idcus;
                    //    fslcc.idselect = 2;
                    //    fslcc.ShowDialog();
                    //}
                }

                LoadAllGrid();
            }
        }

        private string CheckUpdateDTGpurchaseorder(SqlConnection CN)
        {
            string day = dtporderbypur.Value.Day.ToString();
            string month = dtporderbypur.Value.Month.ToString();
            string year = dtporderbypur.Value.Year.ToString();
            string date = month + "/" + day + "/" + year;

            ds4.Clear(); dssearch4.Clear();
            dtgpurtranstatus.DataSource = dssearch4; string sql = "";

            if (idsearchorder == 0)//all
            {
               // sql = "select * from vpurchase WHERE datepur ='" + date + "' AND idstatus <> 7";//idstatus = 4";
                sql = "select * from vpurchase WHERE datepur ='" + date + "'";//idstatus = 4";
            }

            if (idsearchorder == 1)//select by combo
            {
                if (cbselectorder.SelectedIndex == 0 || cbselectorder.SelectedIndex == -1)
                {                 
                    sql = "select * from vpurchase WHERE datepur ='" + date + "'";
                }

                if (cbselectorder.SelectedIndex == 1)
                {
                   sql = "select * from vpurchase WHERE datepur ='" + date + "' AND idstatus = 2 AND idstatus <> 7 ";                  
                }

                if (cbselectorder.SelectedIndex == 2)
                {
                    sql = "select * from vpurchase WHERE datepur ='" + date + "' AND idstatus != 2 AND idstatus <> 7 ";
                   
                }
                if (cbselectorder.SelectedIndex == 3)
                {                   
                    sql = "select * from vpurchase WHERE datepur ='" + date + "' AND idstatus = 7";
                }
            }           
            
            SqlDataAdapter da4 = new SqlDataAdapter(sql, CN);
            da4.Fill(ds4, "vpuror");
            dtgpurtranstatus.DataSource = ds4.Tables["vpuror"];
            txtfrom.BackColor = Color.DarkSalmon;
            idpur = "0";

            for (int i = 0; i < dtgpurtranstatus.RowCount; i++)
            {
                string sql1 = "select idtran,idstatus from vpurchase where idpur = '" + dtgpurtranstatus[0, i].Value.ToString().Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    if (DR1["idtran"].ToString() != "" && DR1["idstatus"].ToString() == "2")
                    {
                        dtgpurtranstatus[1, i].Value = "Success";
                        dtgpurtranstatus.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(215, 228, 188);
                    }

                    else if (DR1["idstatus"].ToString() == "7")
                    {
                        dtgpurtranstatus[1, i].Value = "Cancle";
                        dtgpurtranstatus.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(242, 221, 220);
                        dtgpurtranstatus.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                    }

                    else
                    {
                        dtgpurtranstatus[1, i].Value = "-";
                        dtgpurtranstatus.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(242, 221, 220);
                    }
                }
                DR1.Close();
            }          
            return sql;
        }

        private string CheckUpdateDTGsaleorder(SqlConnection CN)
        {
            string day = dtporderbysale.Value.Day.ToString();
            string month = dtporderbysale.Value.Month.ToString();
            string year = dtporderbysale.Value.Year.ToString();
            string date = month + "/" + day + "/" + year;

            ds5.Clear(); dssearch5.Clear();
            dtgsaletranstatus.DataSource = dssearch5;
            string sql = "";
            

            if (idsearchorder == 0)//all
            {
                sql = "select * from vsaleorder WHERE orderdate ='" + date + "'";// idstatus = 3";           
            }
            if (idsearchorder == 1)//select by combo
            {
                if (cbselectorder.SelectedIndex == 0 || cbselectorder.SelectedIndex == -1)
                {
                     sql = "select * from vsaleorder WHERE orderdate ='" + date + "' AND idstatus <> 7";// idstatus = 3"; 
                }

                if (cbselectorder.SelectedIndex == 1)
                {
                    sql = "select * from vsaleorder WHERE orderdate ='" + date + "' AND idstatus = 1 ";// idstatus = 3"; 
                }

                if (cbselectorder.SelectedIndex == 2)
                {
                    sql = "select * from vsaleorder WHERE orderdate ='" + date + "' AND idstatus <> 1";// idstatus = 3";
                }

                if (cbselectorder.SelectedIndex == 3)
                {
                    sql = "select * from vsaleorder WHERE orderdate ='" + date + "' AND idstatus = 7 1";// idstatus = 3";
                }
            }

            SqlDataAdapter da5 = new SqlDataAdapter(sql, CN);
            da5.Fill(ds5, "vordert");
            dtgsaletranstatus.DataSource = ds5.Tables["vordert"];
            txtcus.BackColor = Color.DarkSalmon;
            idcus = "0"; int idbranchcus = 0;

            for (int i = 0; i < dtgsaletranstatus.RowCount; i++)
            {
                string sql1 = "select idbranchcus,idtran,idstatus from vsaleorder where idorder = '" + dtgsaletranstatus[0, i].Value.ToString().Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    if (DR1["idtran"].ToString() != "" && DR1["idstatus"].ToString() == "1")
                    { 
                        dtgsaletranstatus[1, i].Value = "Success";
                        dtgsaletranstatus.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(215, 228, 188);
                    }

                    else if (DR1["idstatus"].ToString() == "7")
                    {
                        dtgsaletranstatus[1, i].Value = "Cancle";
                        dtgsaletranstatus.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(242, 221, 220);
                        dtgsaletranstatus.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                    }

                    else 
                    {
                        dtgsaletranstatus[1, i].Value = "-";
                        dtgsaletranstatus.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(242, 221, 220);
                    }

                    idbranchcus = Convert.ToInt16(DR1["idbranchCus"].ToString());
                }
                DR1.Close();


                string sql2 = "select * from tbbrach where idbranch = " + idbranchcus + "";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();

                DR2.Read();
                {
                    dtgsaletranstatus[5, i].Value = DR2["bname"].ToString() + " " + DR2["baddress"].ToString() + " " + DR2["rd"].ToString() + " " + DR2["tumb"].ToString() + " " + DR2["country"].ToString() + " " + DR2["provice"].ToString() + " " + DR2["zipcode"].ToString();
                }
                DR2.Close();
            }
                       
            return sql;
        }       

        private void dtgsaletranstatus_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisableAllbtn();

            if (dtgsaletranstatus[1, e.RowIndex].Value.ToString().Trim() == "-")
            {
                FrmSelectMoveJob fsmo = new FrmSelectMoveJob();
                fsmo.typejob = 2;//ส่งค่าจ่ายงานจากการขาย                   
                fsmo.idorder = Convert.ToString(dtgsaletranstatus[0, e.RowIndex].Value.ToString());
                fsmo.xposition = Convert.ToInt16(MousePosition.X);
                fsmo.yposition = Convert.ToInt16(MousePosition.Y);
                fsmo.ShowDialog();
                LoadAllGrid();
            }
        }

        private void dtgsaletranstatus_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisableAllbtn();

            if (dtgsaletranstatus[1, e.RowIndex].Value.ToString().Trim() == "-" )
            {
                txtcus.BackColor = Color.LightGreen;
                idcus = Convert.ToString(dtgsaletranstatus[0, e.RowIndex].Value.ToString());
                btnchangdata.Enabled = true;
                btnsplit.Enabled = true;
                btnsend.Enabled = true;
                btncancleorder.Enabled = true;
                idselectcancle = 2;//ส่งไอดีไปยกเลิก               
            }
        }

        private void LoadTabSaleOrder()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); ds2.Clear(); dssearch2.Clear();   
            dtgsaleordertran.DataSource = dssearch2;
            string sql2 = "select * from vonholetruckout where idstatus = 3 ";
            SqlDataAdapter da2 = new SqlDataAdapter(sql2, CN);
            da2.Fill(ds2, "vordertran");
            dtgsaleordertran.DataSource = ds2.Tables["vordertran"];
            lblcountsale.Text = dtgsaleordertran.RowCount.ToString() + " Data";
        }

        private void LoadTabPurchase()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); ds1.Clear(); dssearch1.Clear(); 
            dtgpurordertran.DataSource = dssearch1;
            string sql1 = "select * from vonholetruckin where idstatus = 4";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(ds1, "vpurordertran");
            dtgpurordertran.DataSource = ds1.Tables["vpurordertran"];
            lblcountpurchase.Text = dtgpurordertran.RowCount.ToString() + " Data";
        }

        private void LoadGridFsTctruck()
        {   SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); ds3.Clear(); dssearch3.Clear(); 
                
            dtgtranreplyFsTcPass.DataSource = dssearch3;
            string sql3 = "SELECT * FROM vFsTcFortrasport WHERE idtruck <> 5 AND idtruck <> 3";
            SqlDataAdapter da3 = new SqlDataAdapter(sql3, CN);
            da3.Fill(ds3, "vtr");
            dtgtranreplyFsTcPass.DataSource = ds3.Tables["vtr"];
            lblcountpurchase.Text = dtgtranreplyFsTcPass.RowCount.ToString() + " Data";
        }

        private void Frmpayjob_Load(object sender, EventArgs e)
        {
            LoadAllGrid();
            DisableAllgroupbox();
            DisableAllbtn();
        }               

        private void DisableAllgroupbox()
        {
            gbtruckout.Visible = false;
            gbtruckin.Visible = false;
            gbpts.Visible = false;
            gbmainmovejob.Visible = false;
            bgbetweentran.Visible = false;
        }

        private void LoadAllGrid()
        {   SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();string sql; 
            
            ds3.Clear(); dssearch3.Clear();   

            ////load grid purchase
            sql = CheckUpdateDTGpurchaseorder(CN);
            ////load grid sale
            sql = CheckUpdateDTGsaleorder(CN);

            CheckUserOpenform();           
        }

        private void CheckUserOpenform()
        {
            if (Program.iddept == "3" || Program.iddept == "4")
            {
                btnsend.Enabled = true;
                btnsplit.Enabled = true;
                btnchangdata.Enabled = true;
                btnpurchase.Enabled = true;
                btnorder.Enabled = true;
            }

           else
            {btnsend.Enabled = false;
                btnsplit.Enabled = false;
                btnchangdata.Enabled = false;
                btnpurchase.Enabled = false;
                btnorder.Enabled = false;                
            }
        }

        private void Checkmathproduct()
        {
            int idcarpur = 0;
            int idpropur = 0;
            int idcarsale = 0;
            int idprosale = 0;
            int idcargrouppur = 0;
            int idcargroupsale = 0;
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();  

            try
            {
                string sql1 = "SELECT idpro,idcar FROM tbpurchase WHERE idpur = '" + idpur + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();
                DR1.Read();
                {
                    idpropur = Convert.ToInt16(DR1["idpro"].ToString());
                    idcarpur = Convert.ToInt16(DR1["idcar"].ToString());
                }
                DR1.Close();

                string sql2 = "SELECT idpro,idcar FROM tborder WHERE idorder ='" + idcus + "'";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();
                DR2.Read();
                {
                    idprosale = Convert.ToInt16(DR2["idpro"].ToString());
                    idcarsale = Convert.ToInt16(DR2["idcar"].ToString());
                }
                DR2.Close();


                if (idcarpur != 0)
                {
                    string sql3 = "SELECT idcargroup FROM tbcar WHERE idcar ='" + idcarpur + "'";
                    SqlCommand CM3 = new SqlCommand(sql3, CN);
                    SqlDataReader DR3 = CM3.ExecuteReader();
                    DR3.Read();
                    { idcargrouppur = Convert.ToInt16(DR3["idcargroup"].ToString()); }
                    DR3.Close();
                }

                if (idcarsale != 0)
                {
                    string sql4 = "SELECT idcargroup FROM tbcar WHERE idcar ='" + idcarsale + "'";
                    SqlCommand CM4 = new SqlCommand(sql4, CN);
                    SqlDataReader DR4 = CM4.ExecuteReader();
                    DR4.Read();
                    { idcargroupsale = Convert.ToInt16(DR4["idcargroup"].ToString()); }
                    DR4.Close();
                }
                
                if (idpropur == idprosale)//เช็ครถพ่วง
                {
                    if (idcargrouppur == idcargroupsale)
                    { idmatchok = 1; }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
         
        }

        private void SearchIDcomtran()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql1 = "SELECT idcomtran FROM vpurchase WHERE idpur = '" + idpur + "'";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            SqlDataReader DR1 = CM1.ExecuteReader();
            DR1.Read();
            { idcomtran = DR1["idcomtran"].ToString(); }
            DR1.Close();
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            CreateAutoIDbybrannch();
            Checkmathproduct();

            if (idmatchok == 1)
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();

                int truckpass = 0; string remark = ""; int idbranch = 0;
                string date = DateTime.Now.Day.ToString();//convert save datetime to transport
                string month = DateTime.Now.Month.ToString();
                string year = DateTime.Now.Year.ToString();
                string sumdate = month + "/" + date + "/" + year;

                truckpass = 1;
                FrmSelectMoveJob fsmo = new FrmSelectMoveJob();
                fsmo.typejob = 4;//ส่งค่าจ่ายงานจากการซื้อ            
                fsmo.idpur = idpur;
                fsmo.idorder = idcus;
                fsmo.ShowDialog();
                idbranch = fsmo.idbranch;

                if (fsmo.idok == 1)
                {
                    if (idpur != "0" && idcus != "0")
                    {
                        if (idbranch == 0)//ถ้าซื้อแล้วไม่ผ่านสาขา
                        {
                            remark = "-";
                            //ซื้อจากผู้ผลิต และส่งให้ลูกค้า ให้บันทึก idsup -> idcus  insert into tbpurchase  
                            string sql1 = "insert into tbtransport(idtran,senddate,idfrom,idto,idcomtran,idtruck,truckpass,remark1) values ('" + idtranno + "','" + sumdate + "','" + idpur + "','" + idcus + "','" + idcomtran + "',4," + truckpass + ",'" + remark + "')";

                            SqlCommand CM1 = new SqlCommand(sql1, CN);
                            CM1.ExecuteNonQuery();
                        }

                        else if (idbranch != 0)  //ถ้าซื้อแล้วผ่านสาขา
                        {
                            //ซื้อจากผู้ผลิต และส่งให้ลูกค้า ให้บันทึก idsup -> idcus  insert into tbpurchase 
                            remark = "นน.ผ่านตาชั่ง " + fsmo.branchname;
                            string sql1 = "insert into tbtransport(idtran,senddate,idfrom,idto,idcomtran,idtruck,idbranch,truckpass,remark1) values ('" + idtranno + "','" + sumdate + "','" + idpur + "','" + idcus + "','" + idcomtran + "',4," + idbranch + "," + truckpass + ",'" + remark + "')";

                            SqlCommand CM1 = new SqlCommand(sql1, CN);
                            CM1.ExecuteNonQuery();
                        }

                        string sql12 = "insert into tbweigth  (idtran,dateWbf,weigthbf,weigthaf,weigthnet) values ('" + idtranno + "','" + sumdate + "',0,0,0)";
                        SqlCommand CM12 = new SqlCommand(sql12, CN);
                        CM12.ExecuteNonQuery();                        


                        string sql2 = "update tbpurchase set idstatus=" + 2 + ",idtran='" + idtranno + "' Where idpur= '" + idpur + "'";
                        SqlCommand CM2 = new SqlCommand(sql2, CN);
                        CM2.ExecuteNonQuery();

                        string sql3 = "update tborder set idstatus=" + 1 + ",idtran='" + idtranno + "' Where idorder= '" + idcus + "'";
                        SqlCommand CM3 = new SqlCommand(sql3, CN);
                        CM3.ExecuteNonQuery();

                        MessageBox.Show("บันทึกข้อมูลประสบความสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllGrid();
                    }

                    else { MessageBox.Show("คุณไม่ได้ผู้ซื้อหรือลูกค้า !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }

                else { MessageBox.Show("คุณได้ยกเลิกในการจ่ายงานนี้หรือชนิดสินค้าไม่ตรงกัน !", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }

        private void CreateAutoIDbybrannch()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            long daterun = 0;
            int idrun = 0;
            string keychar = "";

            string getidmax = "";
            string sql = "SELECT MAX(idtranauto) AS idmaxs FROM tbtransport WHERE (idtran LIKE '%D%')";
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
                    textBox6.Text = DR1["idtran"].ToString();
                    textBox7.Text = DR1["idtran"].ToString();
                }
                DR1.Close();

                textBox6.SelectionStart = 1;
                textBox6.SelectionLength = 6;
                daterun = Convert.ToInt64(textBox6.SelectedText.ToString());//ตัดค่า 4 ปีเดือนวัน จากฐานข้อมูล
                textBox7.SelectionStart = 7;
                textBox7.SelectionLength = 9;
                idrun = Convert.ToInt16(textBox7.SelectedText.ToString());//ตัวลำดับที่ จากฐานข้อมูล            
            }

            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            string idcomplease = "D" + String.Format("{0:yy}", dt) + String.Format("{0:MM}", dt) + String.Format("{0:dd}", dt);
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
        }

        private void dtgpurordertran_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisableAllbtn();            
            if (e.RowIndex < 0) return;
            {                
                idpur = Convert.ToString(dtgpurordertran[12, e.RowIndex].Value.ToString());
                idtranno = Convert.ToString(dtgpurordertran[0, e.RowIndex].Value.ToString());
                idselectcancle = 3;//ส่งไอดีไปยกเลิก
                btnsplit.Enabled = false; btnchangdata.Enabled = true;
            }
        }

        private void dtgsaleordertran_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            {
                idcus = Convert.ToString(dtgsaleordertran[12, e.RowIndex].Value.ToString());
                idtranno = Convert.ToString(dtgsaleordertran[0, e.RowIndex].Value.ToString());
                idselectcancle = 4; btnchangdata.Enabled = true;
            }
        }

        private void dtgtranreplyFsTcPass_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            {
                idtranno = Convert.ToString(dtgtranreplyFsTcPass[0, e.RowIndex].Value.ToString());
                idselectcancle = 5; btnchangdata.Enabled = true;
            }
        }

        private void rdomainmovejob_CheckedChanged(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now; dtporderbypur.Enabled = true; dtporderbysale.Enabled = true;
            DisableAllbtn(); CheckUserOpenform();
            if (rdomainmovejob.Checked == true)
            {
                DisableAllgroupbox();
                gbmainmovejob.Dock = DockStyle.Fill;
                gbmainmovejob.Visible = true;
                btnsend.Enabled = true;
                btnsplit.Enabled = true;
                btnchangdata.Enabled = true;
                btncancleorder.Enabled = true;
                idpur = "0";
                idcus = "0";
                int time = Convert.ToInt16(string.Format("{0:HH}", DateTime.Now));
                string day = String.Format("{0:dddd}", DateTime.Now);

                if (time >= 17 || day == "Sunday" || day == "อาทิตย์")
                {
                    btnorder.Enabled = true;
                    btnpurchase.Enabled = true;
                }

                cbselectorder.DataSource = null;
                cbselectorder.Items.Clear();
                cbselectorder.Items.Add("ALL");
                cbselectorder.Items.Add("Success");
                cbselectorder.Items.Add("-"); 
                cbselectorder.Items.Add("Cancle");
                cbselectorder.Enabled = true;
            }

            LoadAllGrid();            
        }        

        private void rdotin_CheckedChanged(object sender, EventArgs e)
        {
            DisableAllbtn(); CheckUserOpenform(); dtporderbypur.Enabled = false; dtporderbysale.Enabled = false;
            if (rdotin.Checked == true)
            {                             
                DisableAllgroupbox();
                LoadTabPurchase();
                gbtruckin.Dock = DockStyle.Fill;
                gbtruckin.Visible = true;               
                btnchangdata.Enabled = true;
                LoadSelecttype();
            }           
        }

        private void rdotout_CheckedChanged(object sender, EventArgs e)
        {
            DisableAllbtn(); CheckUserOpenform(); dtporderbypur.Enabled = false; dtporderbysale.Enabled = false;
            if (rdotout.Checked == true)
            {
                DisableAllgroupbox();                
                LoadTabSaleOrder();
                gbtruckout.Dock = DockStyle.Fill;
                gbtruckout.Visible = true;               
                btnchangdata.Enabled = true;
                LoadSelecttype();
            }          
        }

        private void rdoptos_CheckedChanged(object sender, EventArgs e)
        {
            DisableAllbtn(); CheckUserOpenform(); dtporderbypur.Enabled = false; dtporderbysale.Enabled = false;
            if (rdoptos.Checked == true)
            {               
                DisableAllgroupbox();
                LoadGridFsTctruck();
                gbpts.Dock = DockStyle.Fill;
                gbpts.Visible = true;
                btnchangdata.Enabled = true;
                LoadSelecttype();
            }  
        
            
        }

        private void dtgsaleordertran_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisableAllbtn();
            if (e.RowIndex < 0) return;
            {
                idtranno = Convert.ToString(dtgsaleordertran[0, e.RowIndex].Value.ToString());
                idcus = Convert.ToString(dtgsaleordertran[12, e.RowIndex].Value.ToString()); btnchangdata.Enabled = true;}   
        }

        private void dtgtranreplyFsTcPass_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisableAllbtn();
            if (e.RowIndex < 0) return;
            { idtranno = Convert.ToString(dtgtranreplyFsTcPass[0, e.RowIndex].Value.ToString()); btnchangdata.Enabled = true; }
        }

        private void btnchangdata_Click(object sender, EventArgs e)
        {
            //idordermenu == 1      Purchase  คลัง
            // idordermenu == 2     Sale  คลัง
            //idordermenu == 4      Purchase ขนส่ง
            // idordermenu == 5     Sale คลัง
            //idordermenu == 6      Purchase  หลังจากจ่ายงานแล้ว
             //idordermenu == 7      Sale  หลังจากจ่ายงานแล้ว
            if (idpur != "0" || idcus != "0" || idpur != "" || idcus != "")
            {
                if (rdomainmovejob.Checked == true)
                {
                    Frmchangdata fcc = new Frmchangdata();
                    if (idpur == "0" || idcus == "0")
                    { fcc.idordermenu = 0; }
                    if (idpur != "0")//for purchase
                    { fcc.idordermenu = 4; fcc.idtranno = idpur; }//ซื้อจากขนส่ง
                    if (idcus != "0")// for sale
                    { fcc.idordermenu = 5; fcc.idtranno = idcus; }//ขายจากขนส่ง

                    fcc.ShowDialog();
                    LoadAllGrid();
                }

                if (rdotin.Checked == true)//ซื้อ งานจ่ายจากขนส่งแล้ว
                {
                    Frmchangdata fcc = new Frmchangdata();                   
                    fcc.idtranno = idtranno;
                    fcc.idordermenu = 6;
                    fcc.ShowDialog();
                    LoadTabPurchase();
                }

                if (rdotout.Checked == true || rdosentproduct.Checked == true)//ขาย งานจ่ายจากขนส่งแล้ว
                {
                    Frmchangdata fcc = new Frmchangdata();                   
                    fcc.idtranno = idtranno; 
                    fcc.idordermenu = 7;
                    fcc.ShowDialog();
                    LoadTabSaleOrder();
                }

                if (rdoptos.Checked == true)//งานซื้อมา ขายไป
                {
                    Frmchangdata fcc = new Frmchangdata();                    
                    fcc.idtranno = idtranno;
                    fcc.idordermenu = 8;
                    fcc.ShowDialog();
                    LoadGridFsTctruck();
                }
            }

           idpur = "0"; idcus = "0"; idtranno = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
              
        private void DisableAllbtn()
        {         
            //btnorder.Enabled = false;
            //btnpurchase.Enabled = false;
            btncancleorder.Enabled = false;
            btnsend.Enabled = false;
            btnsplit.Enabled = false;
            btnchangdata.Enabled = false;
        }

        private void btnorder_Click(object sender, EventArgs e)
        {
            FrmSaleOrder fsor = new FrmSaleOrder();
            fsor.add0rder = 1;
            fsor.ShowDialog();
            LoadAllGrid();
        }

        private void btnpurchase_Click(object sender, EventArgs e)
        {
            FrmPurchase fpch = new FrmPurchase();
            //fpch.idedit = 3;//บอกสถานะเไปเลี่ยนแปง
            fpch.ShowDialog();
            LoadAllGrid();
        }

        private void btnsplit_Click(object sender, EventArgs e)
        {
            int idcar = 0;
            string idorder1 = ""; int idcar1 = 0; int idcargroup1 = 0; int idpro1 = 0;
            string idorder2 = ""; int idcar2 = 0; int idcargroup2 = 0; int idpro2 = 0;
         
            if (idcus != "0" && dtgsaletranstatus.SelectedRows.Count ==1)
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();

                string sql2 = "SELECT idpro,idcar FROM tborder WHERE idorder ='" + idcus + "'";
                SqlCommand CM2 = new SqlCommand(sql2, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();
                DR2.Read();
                { idcar = Convert.ToInt16(DR2["idcar"].ToString()); }
                DR2.Close();

                if (idcar == 1 || idcar == 2 || idcar == 3 || idcar == 4 || idcar == 5)//เช็คว่าต้องเป็นรถพ่วงเท่านั้น                
                {
                    DialogResult answer;
                    answer = MessageBox.Show("คุณต้องการแตกรถพ่วงเป็นรถเดี่ยวใช่หรือไม่ !", "คำเตือน!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (answer == DialogResult.Yes)
                    {
                        FrmselectCarSplite fscs = new FrmselectCarSplite();
                        fscs.ShowDialog();
                        if (fscs.idcar != "")
                        {
                            FrmSaleOrder fsor = new FrmSaleOrder();
                            fsor.id = idcus;
                            fsor.idstatus = 1;
                            fsor.add0rder = 2;
                            fsor.ShowDialog();

                            if (fsor.idstatus == 99)
                            {
                                string sql = "update tborder set idcar='" + fscs.idcar + "',remark= 'Order เพิ่มเติม แยกพ่วงเป็นเดี่ยวเลขที่ขาย 1.1: " + fsor.idsorder + "' Where idorder= '" + idcus + "'";
                                SqlCommand CM = new SqlCommand(sql, CN);
                                CM.ExecuteNonQuery();
                                LoadAllGrid();
                            }
                        }
                    }
                }

                else MessageBox.Show("ต้องเป็นประเภทรถพ่วงเท่านั้นถึงจะแยกพ่วงเป็นเดี่ยวได้ !", "คำเตือน!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (dtgsaletranstatus.SelectedRows.Count == 2)
            {   
                SqlConnection CN = new SqlConnection();
                        CN.ConnectionString = Program.urldb;
                        CN.Open();            
                int row = 1;

                for (int i = 0; i < dtgsaletranstatus.SelectedRows.Count; i++)
                {
                    string idorders = "";

                    if (dtgsaletranstatus.SelectedRows[i].Cells[1].Value.ToString() == "-" && row == 1)
                    {
                        idorder1 = dtgsaletranstatus.SelectedRows[i].Cells[0].Value.ToString().Trim();
                    }

                    if (dtgsaletranstatus.SelectedRows[i].Cells[1].Value.ToString() == "-" && row == 2)
                    {
                        idorder2 = dtgsaletranstatus.SelectedRows[i].Cells[0].Value.ToString().Trim();
                    }

                    if (row == 1)
                    { idorders = idorder1; }
                    if (row == 2)
                    { idorders = idorder2; }

                    if (idorders != "")
                    {
                        string sql2 = "SELECT idpro,idcar,idpro FROM tborder WHERE idorder ='" + idorders + "'";
                        SqlCommand CM2 = new SqlCommand(sql2, CN);
                        SqlDataReader DR2 = CM2.ExecuteReader();
                        DR2.Read();
                        {
                            if (row == 1)
                            {
                                idcar1 = Convert.ToInt16(DR2["idcar"].ToString()); idpro1 = Convert.ToInt16(DR2["idpro"].ToString());

                            }
                            if (row == 2)
                            { idcar2 = Convert.ToInt16(DR2["idcar"].ToString()); idpro2 = Convert.ToInt16(DR2["idpro"].ToString()); }
                        }
                        DR2.Close();


                        if (row == 1)
                        {
                            string sql3 = "SELECT idcar,idcargroup FROM tbcar WHERE idcar ='" + idcar1 + "'";
                            SqlCommand CM3 = new SqlCommand(sql3, CN);
                            SqlDataReader DR3 = CM3.ExecuteReader();
                            DR3.Read();
                            { idcargroup1 = Convert.ToInt16(DR3["idcargroup"].ToString()); }
                            DR3.Close();
                        }
                        if (row == 2)
                        {
                            string sql4 = "SELECT idcar,idcargroup FROM tbcar WHERE idcar ='" + idcar2 + "'";
                            SqlCommand CM4 = new SqlCommand(sql4, CN);
                            SqlDataReader DR4 = CM4.ExecuteReader();
                            DR4.Read();
                            { idcargroup2 = Convert.ToInt16(DR4["idcargroup"].ToString()); }
                            DR4.Close();
                        }
                    }

                    row = row + 1;
                }

                int idok = 1;
              if (idorder1 == idorder2 || idcar1 != idcar2 || idpro1 != idpro2)
                { 
                  MessageBox.Show("คุณเลือกข้อมูลไม่ถูกต้อง (สถานนะต้องเท่ากับ - หรือข้อมูลประเภทรถไม่ต้องกัน)", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  idok = 0;
              }

              if (idok == 1)//check data after open editjob
              {
                  Frmmergorder fmorder = new Frmmergorder();
                  fmorder.idorder1 = idorder1;
                  fmorder.idorder2 = idorder2;
                  fmorder.ShowDialog();
                  LoadAllGrid();
              }            
            }
        }

        private void rdosentproduct_CheckedChanged(object sender, EventArgs e)
        {
            DisableAllbtn(); CheckUserOpenform(); dtporderbypur.Enabled = false;
            if (rdosentproduct.Checked == true)
            {
                DisableAllgroupbox();            
               
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open();
                ds6.Clear(); dssearch6.Clear();
                dtgholetruckout.DataSource = dssearch6;
                string sql4 = "select * from vonholetruckoutFrombrach where idstatus <> 7 AND idstatus = 1 order by orderdate desc";
                SqlDataAdapter da4 = new SqlDataAdapter(sql4, CN);
                da4.Fill(ds6, "vjobholeout");
                dtgholetruckout.DataSource = ds6.Tables["vjobholeout"];
                label5.Text = dtgholetruckout.RowCount.ToString() + "  Data";
                bgbetweentran.Dock = DockStyle.Fill;
                bgbetweentran.Visible = true; bgbetweentran.BringToFront();
               // LoadSelecttype();
            }
        }

        private void dtgholetruckout_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisableAllbtn();
            if (e.RowIndex < 0) return;
            {
                idtranno = Convert.ToString(dtgholetruckout[0, e.RowIndex].Value.ToString());
                idcus = Convert.ToString(dtgholetruckout[12, e.RowIndex].Value.ToString()); btnchangdata.Enabled = true;
            } 
        }

        private void dtporderby_ValueChanged(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); string sql;
            ds3.Clear(); dssearch3.Clear();
            ////load grid purchase
            sql = CheckUpdateDTGpurchaseorder(CN);
            CheckUserOpenform();
        }

        private void dtporderbysale_ValueChanged(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); string sql;
            ds3.Clear(); dssearch3.Clear();
            ////load grid sale
            sql = CheckUpdateDTGsaleorder(CN);
            CheckUserOpenform();
        }
        
        private void LoadSelecttype()
        {
            SqlConnection.ClearAllPools();
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); cbselectorder.Enabled = true;

            if (rdotin.Checked == true)
            {
                dssearch4.Clear();
                cbselectorder.DataSource = dssearch4;
                string sql1 = "select DISTINCT remark3 from vonholetruckin where idstatus <> 7 AND idstatus = 4 ";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                da1.Fill(dssearch4, "select");
                cbselectorder.DataSource = dssearch4.Tables["select"];
                cbselectorder.DisplayMember = "remark3";
                cbselectorder.ValueMember = "remark3";  
            }

            if (rdotout.Checked == true)
            {
                dssearch4.Clear();
                cbselectorder.DataSource = dssearch4;
                string sql1 = "select DISTINCT remark3 from vonholetruckout where idstatus <> 7 AND idstatus = 3 ";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                da1.Fill(dssearch4, "select");
                cbselectorder.DataSource = dssearch4.Tables["select"];
                cbselectorder.DisplayMember = "remark3";
                cbselectorder.ValueMember = "remark3";               
            }

            if (rdoptos.Checked == true)
            {
                dssearch4.Clear();
                cbselectorder.DataSource = dssearch4;
                string sql1 = "SELECT DISTINCT remark1 FROM vFsTcFortrasport WHERE idtruck <> 5 AND idtruck <> 3";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                da1.Fill(dssearch4, "select");
                cbselectorder.DataSource = dssearch4.Tables["select"];
                cbselectorder.DisplayMember = "remark1";
                cbselectorder.ValueMember = "remark1";          
            }

            if (rdosentproduct.Checked == true)
            {
                dssearch4.Clear();
                cbselectorder.DataSource = dssearch4;
                string sql1 = "SELECT DISTINCT remark3 FROM vonholetruckoutFrombrach WHERE idtruck <> 7";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                da1.Fill(dssearch4, "select");
                cbselectorder.DataSource = dssearch4.Tables["select"];
                cbselectorder.DisplayMember = "remark3";
                cbselectorder.ValueMember = "remark3";
            }

            cbselectorder.Enabled = true;
            CN.Close();
        }

        private void cbselectorder_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (rdomainmovejob.Checked == true)
            {
                idsearchorder = 1;
                LoadAllGrid();
            }

           else if (rdotin.Checked == true)
            {
                ds1.Clear(); dssearch1.Clear();
                dtgpurordertran.DataSource = dssearch1;
                string sql1 = "select * from vonholetruckin where idstatus <> 7 AND idstatus = 4 AND remark3 = '" + cbselectorder.Text.Trim() + "'";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
                da1.Fill(ds1, "vpurordertran");
                dtgpurordertran.DataSource = ds1.Tables["vpurordertran"];
                lblcountpurchase.Text = dtgpurordertran.RowCount.ToString() + " Data";
            }

          else  if (rdotout.Checked == true)
            {  
                ds2.Clear(); dssearch2.Clear();
                dtgsaleordertran.DataSource = dssearch2;
                string sql2 = "select * from vonholetruckout where idstatus <> 7 AND idstatus = 3  AND remark3 = '" + cbselectorder.Text.Trim() + "'";
                SqlDataAdapter da2 = new SqlDataAdapter(sql2, CN);
                da2.Fill(ds2, "vordertran");
                dtgsaleordertran.DataSource = ds2.Tables["vordertran"];
                lblcountsale.Text = dtgsaleordertran.RowCount.ToString() + " Data";
            }

          else  if (rdoptos.Checked == true)
            {
                if (cbselectorder.Text != "")
                {
                    ds3.Clear(); dssearch3.Clear();
                    dtgtranreplyFsTcPass.DataSource = dssearch3;
                    string sql3 = "SELECT * FROM vFsTcFortrasport WHERE idtruck <> 5 AND remark1 = '" + cbselectorder.Text.Trim() + "'";
                   // string sql3 = "SELECT * FROM vFsTcFortrasport WHERE idtruck <> 5 AND idtruck <> 3 AND remark1 = '" + cbselectorder.Text.Trim() + "'";
                    SqlDataAdapter da3 = new SqlDataAdapter(sql3, CN);
                    da3.Fill(ds3, "vtr");
                    dtgtranreplyFsTcPass.DataSource = ds3.Tables["vtr"];
                    lblcountpurchase.Text = dtgtranreplyFsTcPass.RowCount.ToString() + " Data";
                  
                }
            }

            //if (rdosentproduct.Checked == true)
            //{
            //    ds6.Clear(); dssearch6.Clear();
            //    dtgholetruckout.DataSource = dssearch6;
            //    string sql4 = "select * from vonholetruckoutFrombrach where idstatus <> 7  AND remark3 = '" + cbselectorder.Text.Trim() + "'";
            //    SqlDataAdapter da4 = new SqlDataAdapter(sql4, CN);
            //    da4.Fill(ds6, "vjobholeout");
            //    dtgholetruckout.DataSource = ds6.Tables["vjobholeout"];
            //    label5.Text = dtgholetruckout.RowCount.ToString() + " Data";
            //}

            CN.Close();

        }

        private void dtgtranreplyFsTcPass_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)//นน.ต้น 9
            {
                try
                {
                    // string idtran;                    
                    idtran = dtgtranreplyFsTcPass[0,e.RowIndex].Value.ToString();
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
                { MessageBox.Show("การเลือกผิดพลาด !", "ผิดพลาด !", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

        }

        private void rdomainmovejob_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("หน้าหลักจ่ายงาน", rdomainmovejob);
        }

        private void rdotin_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("หน้ารับสินค้าเข้า", rdotin);
        }

        private void rdotout_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("หน้าจ่ายสินค้าออก", rdotout);
        }

        private void rdoptos_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("หน้าสินค้าขายตรง (ซื้อ -> ขาย)", rdoptos);
        }

        private void rdosentproduct_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("หน้ารายการกำลังส่งถึงลูกค้า", rdosentproduct);
        }

        private void cbselectorder_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("เลือดูเฉพาะสถานะงาน (คอลัมน์ Status)", cbselectorder);
        }

        private void btnsend_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("ส่งงาน ", btnsend);
        }

        private void btnsplit_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("แยกพ่วง หรือ รวมเดี่ยว ", btnsplit);
        }

        private void btnchangdata_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("เปลี่ยนแปลงข้อมูล ", btnchangdata);
        }

        private void btnorder_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("สร้างรายการขาย ", btnorder);
        }
        
        private void btnpurchase_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("สร้างรายการซื้อ ", btnpurchase);
        }

        private void btncancleorder_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("ยกเลิกรายการซื้อ / รายการขาย ", btncancleorder);
        }

        private void btncancleorder_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); string sql;

            if (idselectcancle==1 && idpur != "")
            {
                DialogResult answer;
                answer = MessageBox.Show("คุณต้องการยกเลิกรายการซื้อใช่หรือไม่ !", "กรุณายืนยัน !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (answer == DialogResult.OK)
                {
                    Frmconfirmpwdchagedata frcj = new Frmconfirmpwdchagedata();
                    frcj.idmenuunlock = 14;
                    frcj.idcancle = idpur.Trim();
                    frcj.ShowDialog();

                    if (frcj.idreturn == 1)
                    {
                        MessageBox.Show("ข้อมูลที่คุณได้เลือกถูกยกเลิกแล้ว", "รายงาน !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ds3.Clear(); dssearch3.Clear();
                        sql = CheckUpdateDTGpurchaseorder(CN);                      
                    }
                }
            }

            else if (idselectcancle == 2 && idcus != "")
            {
                DialogResult answer;
                answer = MessageBox.Show("คุณต้องการยกเลิกรายการขายใช่หรือไม่ !", "กรุณายืนยัน !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (answer == DialogResult.OK)
                {
                    Frmconfirmpwdchagedata frcj = new Frmconfirmpwdchagedata();
                    frcj.idmenuunlock = 15;
                    frcj.idcancle = idcus.Trim();
                    frcj.ShowDialog();

                    if (frcj.idreturn == 1)
                    {
                        MessageBox.Show("ข้อมูลที่คุณได้เลือกถูกยกเลิกแล้ว", "รายงาน !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ds3.Clear(); dssearch3.Clear();
                        sql = CheckUpdateDTGsaleorder(CN);
                    }
                }
            }
            CN.Close();

        }
    


    }
}