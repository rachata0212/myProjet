using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//using System.IO;

namespace SaleOrder
{
    public partial class Frmquatation : Form
    {
        public Frmquatation()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet(); string idqua = ""; string namestatusqua = ""; int idstatusqua = 0; int idhistorycus = 0; decimal price = 0; int idpro = 0; int refidchage = 0; string datest = ""; string dateed = "";

        private void tvquatation_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            //ds.Clear();
            dtgdrftquatation.Visible = false;

            //----------------------------------------------

            if (tvquatation.SelectedNode.Name == "ndequatation")//ออกใบเสนอราคา
            {
                Loadgriddraftquatation(CN);
            }            
            if (tvquatation.SelectedNode.Name == "ndehistorychangdata")//เปลี่ยนแปลงบันทึกประวัติ
            {
              //  Loadgridchanghiscus(CN);
            }
            if (tvquatation.SelectedNode.Name == "ndehistorychangprice")//เปลี่ยนแปลงราคา
            {
              //  Loadpricechage(CN);
            }


            //-------------------------------------------------------------
            //View History and Report
            if (tvquatation.SelectedNode.Name == "ndehistoryquatation")//ประวัติ
            {
               // Loadgriddraftquatation(CN);
            }
            if (tvquatation.SelectedNode.Name == "ndehistorycuslog")//เปลี่ยนแปลงข้อมูล
            {
               // Loadhistorycus(CN);
            }
            if (tvquatation.SelectedNode.Name == "ndehistorypricelog")//
            {
               // Loadpricechage(CN);
            }
            //---------------------------------------------------------------------


            if (tvquatation.SelectedNode.Name == "ndeapprovequa")//
            {
               

            }
            





            checkjobstatus();//check status job
            CN.Close();
        }

        private void Loadgriddraftquatation(SqlConnection CN)
        {
            string sql = ""; ds.Clear();

            sql = "select * from vdraftquatation";
            dtgdrftquatation.DefaultCellStyle.ForeColor = Color.Black;

            SqlDataAdapter da = new SqlDataAdapter(sql, CN);
            da.Fill(ds, "vdraftqua");
            dtgdrftquatation.DataSource = ds.Tables["vdraftqua"];
            DisableAllgrid();
            dtgdrftquatation.Visible = true; dtgdrftquatation.Dock = DockStyle.Fill;

            if (dtgdrftquatation.RowCount != 0)
            {
                //for (int i = 0; i < dtgdrftquatation.RowCount; i++)
                //{
                //    sql = "select * from vdraftquatation where idstatusqua <> 5";

                //    if (dtgdrftquatation[1, i].Value.ToString() == "รอพิมพ์ใบเสนอราคา")
                //    {
                //        dtgdrftquatation.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                //    }
                //    if (dtgdrftquatation[1, i].Value.ToString() == "รอบันทึกหรือยกเลิกใบเสนอราคา")
                //    {
                //        dtgdrftquatation.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                //    }
                //    if (dtgdrftquatation[1, i].Value.ToString() == "รอแก้ไข")
                //    {
                //        dtgdrftquatation.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                //    }

                //    if (dtgdrftquatation[1, i].Value.ToString() == "ขออนุมัติใบเสนอราคา")
                //    {
                //        dtgdrftquatation.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                //    }

                //    if (dtgdrftquatation[1, i].Value.ToString() == "อนุมัติใบเสนอราคา")
                //    {
                //        dtgdrftquatation.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                //    }
                //}
            }
        }

        private void Loadgridchanghiscus(SqlConnection CN)
        {           
            ds.Clear();
            string sql = "select * from vhistorycus";
            SqlDataAdapter da = new SqlDataAdapter(sql, CN);
            da.Fill(ds, "vhiscus");
            dtghistorycus.DataSource = ds.Tables["vhiscus"];
            DisableAllgrid();
            dtghistorycus.Visible = true; dtghistorycus.Dock = DockStyle.Fill;            
        }        

        private void Loadpricechage(SqlConnection CN)
        {
            //ds.Clear();
            //string sql = "select * from vhistorycus where (idstatusqua <> 5)";
            //SqlDataAdapter da = new SqlDataAdapter(sql, CN);
            //da.Fill(ds, "vprice");
            //dtgchangprice.DataSource = ds.Tables["vprice"];
            //DisableAllgrid();
            //dtgchangprice.Visible = true; dtgchangprice.Dock = DockStyle.Fill;
        }

        private void Loadhistorycus(SqlConnection CN)
        {
            ds.Clear();
            string sql = "select * from vhistorycus where (idstatusqua = 5)";
            SqlDataAdapter da = new SqlDataAdapter(sql, CN);
            da.Fill(ds, "vhiscus");
            dtghistorycus.DataSource = ds.Tables["vhiscus"];
            DisableAllgrid();
            dtghistorycus.Visible = true; dtghistorycus.Dock = DockStyle.Fill;
        }

        private void Frmquatation_Load(object sender, EventArgs e)
        {
            checkjobstatus();
        }

        private void CheckMenuandButton()
        {
           

        }

        private void DisableAllgrid()
        {            
            dtgdrftquatation.Visible = false;
            dtghistorycus.Visible = false;            
        }

        private void checkjobstatus()
        {
            //SqlConnection CN = new SqlConnection();
            //CN.ConnectionString = Program.urldb;
            //CN.Open();// ds.Clear();
        
            //SELECT     COUNT(idhistorycus) AS jobcounthistory FROM vhistorycus WHERE (idstatusqua = 6)

             //if (Program.iddept == "4")//check jo on sale support
             //{
             //    string sql1 = "select COUNT(idqua) AS jobcount from vdraftquatation where idstatusqua = 9";
             //    SqlCommand CM1 = new SqlCommand(sql1, CN);
             //    SqlDataReader DR1 = CM1.ExecuteReader();
             //    DR1.Read();
             //    { lbljobqua.Text = DR1["jobcount"].ToString(); }
             //    DR1.Close();

             //    string sql2 = "select COUNT(idhistorycus) AS jobcount from vhistorycus where idstatusqua = 4";
             //    SqlCommand CM2 = new SqlCommand(sql2, CN);
             //    SqlDataReader DR2 = CM2.ExecuteReader();
             //    DR2.Read();
             //    { lblchangdata.Text = DR2["jobcount"].ToString(); }
             //    DR2.Close();                  

             //    lbljoball.Text = Convert.ToString(Convert.ToInt16(lbljobqua.Text) + Convert.ToInt16(lblchangdata.Text) + Convert.ToInt16(lbljobchangprice.Text));
             //}
             //else if (Program.iddept == "4")// check job on sale
             //{
             //    string sql1 = "select COUNT(idqua) AS jobcount from vdraftquatation where idstatusqua = 7";
             //    SqlCommand CM1 = new SqlCommand(sql1, CN);
             //    SqlDataReader DR1 = CM1.ExecuteReader();
             //    DR1.Read();
             //    { lbljobqua.Text = DR1["jobcount"].ToString(); }
             //    DR1.Close();

             //    string sql2 = "select COUNT(idhistorycus) AS jobcount from vhistorycus where idstatusqua = 1";
             //    SqlCommand CM2 = new SqlCommand(sql2, CN);
             //    SqlDataReader DR2 = CM2.ExecuteReader();
             //    DR2.Read();
             //    { lblchangdata.Text = DR2["jobcount"].ToString(); }
             //    DR2.Close();               

             //    lbljoball.Text = Convert.ToString(Convert.ToInt16(lbljobqua.Text) + Convert.ToInt16(lblchangdata.Text) + Convert.ToInt16(lbljobchangprice.Text));
             //}
             //else if (Program.iddept == "4")//check job on manager
             //{
             //    string sql1 = "select COUNT(idqua) AS jobcount from vdraftquatation where idstatusqua = 7";
             //    SqlCommand CM1 = new SqlCommand(sql1, CN);
             //    SqlDataReader DR1 = CM1.ExecuteReader();
             //    DR1.Read();
             //    { lbljobqua.Text = DR1["jobcount"].ToString(); }
             //    DR1.Close();

             //    string sql2 = "select COUNT(idhistorycus) AS jobcount from vhistorycus where idstatusqua = 2";
             //    SqlCommand CM2 = new SqlCommand(sql2, CN);
             //    SqlDataReader DR2 = CM2.ExecuteReader();
             //    DR2.Read();
             //    { lblchangdata.Text = DR2["jobcount"].ToString(); }
             //    DR2.Close();              

             //    lbljoball.Text = Convert.ToString(Convert.ToInt16(lbljobqua.Text) + Convert.ToInt16(lblchangdata.Text) + Convert.ToInt16(lbljobchangprice.Text));
             //}  
        
        }

        private void btnaddedit_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();// ds.Clear();

            ////work for sale support
            if (tvquatation.SelectedNode.Name == "ndequatation")//พิมพ์ใบเสนอราคา
            {
                //if (namestatusqua == "รอพิมพ์ใบเสนอราคา")
                //{
                //    DialogResult answer;
                //    answer = MessageBox.Show("คุณต้องการบันทึกและปิดงานนี้ใช่หรือไม่ !", "กรุณายืนยัน !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                //    if (answer == DialogResult.OK)
                //    {
                //        string sql = "update tbquatation set idstatusqua = 5 Where idqua= '" + idqua + "'";
                //        SqlCommand CM = new SqlCommand(sql, CN);
                //        CM.ExecuteNonQuery();
                //        MessageBox.Show("ข้อมูลทำการปรับปรุงแล้ว ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Frmdraftquatation fqt = new Frmdraftquatation();               
                fqt.ShowDialog();

                        Loadgriddraftquatation(CN);
                    //}
                }
            //}

                if (tvquatation.SelectedNode.Name == "ndehistorychangdata")//บันทึกประวัติลูกค้า
            {

                Frmchangdatacustomer fcdacus = new Frmchangdatacustomer();
                fcdacus.ShowDialog();
            Loadhistorycus(CN);
            //        }
            //    }
            //    else
            //    {
            //        Frmhiscustomer fhctm = new Frmhiscustomer(); fhctm.ShowDialog(); Loadhistorycus(CN);
            //    }
            CN.Close();

        }

            //if (tvquatation.SelectedNode.Name == "ndehistorychangdata")//เปลี่ยนแปลงบันทึกประวัติ
            //{

            //    if (namestatusqua == "รอบันทึก")
            //    {
            //        DialogResult answer;
            //        answer = MessageBox.Show("คุณต้องการบันทึกและปิดงานนี้ใช่หรือไม่ !", "กรุณายืนยัน !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //        if (answer == DialogResult.OK)
            //        {
            //            string sql = "update tbhischangdata set idstatusqua = 5 Where idhistorycus= " + idhistorycus + "";
            //            SqlCommand CM = new SqlCommand(sql, CN);
            //            CM.ExecuteNonQuery();
            //            MessageBox.Show("ข้อมูลทำการปรับปรุงแล้ว ", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //            Loadgridchanghiscus(CN);
            //        }
            //    }

            //    checkjobstatus();           //check job
            //}
        }

        private void savepricecus()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb; CN.Open();
            string date = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string sumdate = month + "/" + date + "/" + year;            

            string sql3 = "insert into tbchangprice(changdate,refidchage,idpro,changprice,changremark,idstatusqua) values ('" + sumdate + "'," + refidchage + "," + idpro + "," + price + ",'เปลี่ยนแปลงราคา',5)";
            SqlCommand CM3 = new SqlCommand(sql3, CN);
            CM3.ExecuteNonQuery();
            CN.Close();
        }

        //private void viewerquatation()
        //{
        //    SqlConnection CN = new SqlConnection();
        //    CN.ConnectionString = Program.urldb;
        //    CN.Open();

        //    Frmdraftquaviewer fdqver = new Frmdraftquaviewer();
        //    fdqver.idqua = idqua;
        //    fdqver.ShowDialog();
        //}

        private void editquatation()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            Frmdraftquatation ffqua = new Frmdraftquatation();
            //fappqua.idquatation = idqua;
            //fappqua.iduser = 1;
            ffqua.ShowDialog();

            if (Program.iddept == "2")// sale
            {
                if (namestatusqua == "ขอยืนยันใบเสนอราคา")
                {
                    FrmapproveQua fappqua = new FrmapproveQua();//FrmapproveQua
                    fappqua.idquatation = idqua;
                    fappqua.iduser = 1;
                    fappqua.ShowDialog();
                }

                else
                {
                    MessageBox.Show("ข้อมูลนี้ไม่ได้อยู่ในส่วนงานของคุณแล้ว", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (Program.iddept == "4")// admin approve
            {
                if (namestatusqua == "ขออนุมัติใบเสนอราคา")
                {
                    FrmapproveQua fappqua = new FrmapproveQua();
                    fappqua.idquatation = idqua;
                    fappqua.iduser = 2;
                    fappqua.ShowDialog();
                }

                else
                {
                    MessageBox.Show("ข้อมูลนี้ไม่ได้อยู่ในส่วนงานของคุณแล้ว", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Loadgriddraftquatation(CN);
            CN.Close();
        }    
              
                     

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgdrftquatation_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();// ds.Clear();

            //work for sale support
            if (tvquatation.SelectedNode.Name == "ndequatation")//พิมพ์ใบเสนอราคา
            {
                //if (Program.iddept == "6")
                //{                    
                //    Loadgriddraftquatation(CN);
                //}

                FrmapproveQua fapqua = new FrmapproveQua();
                fapqua.iduser = 1;
                fapqua.idquatation = idqua;
                fapqua.ShowDialog();







            }

            CN.Close();
        }

        private void dtgdrftquatation_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idqua = dtgdrftquatation[0, e.RowIndex].Value.ToString();
            namestatusqua = dtgdrftquatation[1, e.RowIndex].Value.ToString();
        }

        private void dtghistorycus_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();// ds.Clear();

            //work for sale support
            if (tvquatation.SelectedNode.Name == "ndehistorycus")//บันทึกประวัติลูกค้า
            {     
                    Loadhistorycus(CN);                
            }

            //work for sale           
            if (tvquatation.SelectedNode.Name == "ndeconfirmhiscus")//ยืนยันประวัติลูกค้าใหม่
            {
                    Loadhistorycus(CN);               
            }

            //work for manager
            if (tvquatation.SelectedNode.Name == "ndeapprovenewcus")//อนุมัติการบันทึกลูกค้าใหม่
            {                   
                    Loadhistorycus(CN);                
            }
            CN.Close();
        }

        private void dtghistorycus_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idhistorycus = Convert.ToInt16(dtghistorycus[0, e.RowIndex].Value.ToString());
            namestatusqua = dtghistorycus[1, e.RowIndex].Value.ToString();   
        }
       
        private void btnprintqua_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();// ds.Clear();

            //work for sale support
            if (tvquatation.SelectedNode.Name == "ndequatation")//พิมพ์ใบเสนอราคา
            {               
                    Frmviewreport frrp = new Frmviewreport();
                    frrp.rpname = "rpquatation";
                    frrp.idqua = idqua;
                    frrp.ShowDialog();
                    Loadgriddraftquatation(CN);              
            }

            //View History and Report
            
            if (tvquatation.SelectedNode.Name == "ndehistorychangdata")//เปลี่ยนแปลงลูกค้า
            {
              
            }

            if (tvquatation.SelectedNode.Name == "ndehistorychangdata")//เปลี่ยนแปลงราคา
            {
              
              Loadgriddraftquatation(CN);
            }
            if (tvquatation.SelectedNode.Name == "ndehistoryquatation")//ประวัติใบเสนอราคา
            {
                
               Loadhistorycus(CN);
            }
            if (tvquatation.SelectedNode.Name == "ndehistorycuslog")//ประวัติลูกค้า
            {
                
               Loadgridchanghiscus(CN);
            }
            if (tvquatation.SelectedNode.Name == "ndehistorypricelog")//ประวัติราคา
            {
               
               Loadpricechage(CN);
            }
            CN.Close();
        }

        private void dtgchanghiscus_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
              

        private void dtgchangprice_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dtpreportst_ValueChanged(object sender, EventArgs e)
        {
            string date = dtpreportst.Value.Day.ToString();
            string month = dtpreportst.Value.Month.ToString();
            string year = dtpreportst.Value.Year.ToString();
            datest = year + "/" + month + "/" + date;
        }

        private void dtpreported_ValueChanged(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string date = dtpreported.Value.Day.ToString();
            string month = dtpreported.Value.Month.ToString();
            string year = dtpreported.Value.Year.ToString();
            dateed = year + "/" + month + "/" + date;

            //View History and Report
            if (tvquatation.SelectedNode.Name == "ndehistorycuslog")//ประวัติ
            {
                Loadgriddraftquatation(CN);
            }
            if (tvquatation.SelectedNode.Name == "ndehistorydatacuslog")//เปลี่ยนแปลงข้อมูล
            {
                Loadhistorycus(CN);
            }
            if (tvquatation.SelectedNode.Name == "ndehistorypricelog")//เปลี่ยนแปลงราคา
            {
                Loadgridchanghiscus(CN);
            }
            if (tvquatation.SelectedNode.Name == "ndehistoryquatation")//ประวัติใบเสนอ
            {
               Loadpricechage(CN);
            }
            CN.Close();
        }


    
       
    }
}