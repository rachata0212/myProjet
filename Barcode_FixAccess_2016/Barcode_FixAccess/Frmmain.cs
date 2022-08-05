using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace Barcode_FixAccess
{
    public partial class Frmmain : Form
    {
        public Frmmain()
        {
            InitializeComponent();
        }


        string Company_Select="";
        string Select_rows="";
        string value_search = "";
        int idsearch = 0;
        int index_SelectRow;
        int index_DeleteRow;
        DataTable t = new DataTable();
       

        private void GetAllDataBase()
        {
            try
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = "server=192.168.1.14;uid=sa; pwd=1234;";
                CN.Open();

                string sql2 = "SELECT NAME FROM [UMS LIVE].[dbo].[Company]";
                SqlDataAdapter dataadapter2 = new SqlDataAdapter(sql2, CN);
                DataSet ds2 = new DataSet();
                dataadapter2.Fill(ds2);
                cbdatabaseselect.DataSource = ds2.Tables[0];
                
                cbdatabaseselect.DisplayMember = "NAME";
                cbdatabaseselect.ValueMember = "NAME";
                cbdatabaseselect.Text = " -- Select --";
                btnconnect.Text = "Connection to Success!!"; btnconnect.ForeColor = Color.Green ;
                CN.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnconnect.Text = "Connection to Failed!!"; btnconnect.ForeColor = Color.Red; btnsetconnect.Enabled = true; }
        }
        
        private void rdooffice_CheckedChanged(object sender, EventArgs e)
        {
            RDO_Online();
        }

        private void rdoonline_CheckedChanged(object sender, EventArgs e)
        {
            RDO_Online();
        }


        private void RDO_Online()
        {
            if (rdoonline.Checked == true)
            {
                
                dtgsearch.Visible = true;
                panel8.Visible = true;
                cbshowopsearch.Enabled = true;

                btnprintpreview.Enabled = false;
                dtgsearch.Visible = true;                
                dtgselect.DataSource = null;
                dtgselect.Dock = DockStyle.Fill;
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.Visible = false;
                txtimportfile.Clear();
                panel8.Visible = true;

                gbonline.Enabled = true;
                gboffline.Enabled = false; 
            }

            if (rdooffice.Checked == true)
            {
               gboffline.Enabled = true;
               gbonline.Enabled = false;
               btnprintpreview.Enabled = false;

                dtgsearch.Visible = false;
                panel8.Visible = false;
                cbshowopsearch.Enabled = false;
               
                if (dtgselect.RowCount > 0)
                { dtgselect.Rows.Clear(); }
               
            }
        }


        private void btnconnect_Click(object sender, EventArgs e)
        {
            GetAllDataBase();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Get_data_Before_Search();
                Get_Branch();
                Get_DeptNo();
            }
            catch
            {
                MessageBox.Show("Your Can't Connect DataBase and Select Company", "Error!! Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cbdatabaseselect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbdatabaseselect.SelectedIndex > -1)
            {
                if (cbdatabaseselect.SelectedIndex == 0)
                {
                    Company_Select = "[UMS LIVE].[dbo].[UMS Lighter Co_,Ltd_$";
                }

                if (cbdatabaseselect.SelectedIndex == 1)
                {

                    Company_Select = "[UMS LIVE].[dbo].[UMS Logistic Management$";
                }

                if (cbdatabaseselect.SelectedIndex == 2)
                {

                    Company_Select = "[UMS LIVE].[dbo].[UMS Pellet Energy Co_,Ltd_$";
                }

                if (cbdatabaseselect.SelectedIndex == 3)
                {
                    Company_Select = "[UMS LIVE].[dbo].[UMS PORT Co,_ Ltd_$";
                }

                if (cbdatabaseselect.SelectedIndex == 4)
                {               
                    Company_Select = "[UMS LIVE].[dbo].[บมจ_ยูนิค ไมนิ่ง เซอร์วิสเซส$";
                }
            }

        }

        private void Get_data_Before_Search()
        {            
            DataSet ds1 = new DataSet();
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = "server=192.168.1.14; uid=sa; pwd=1234;";
            CN.Open();
            ds1.Clear();

            string sql1 = "SELECT " + Select_rows + "  [No_],[Description],[Last Date Modified] AS [Date Modifiled],[Global Dimension 1 Code] AS Branch,[Global Dimension 2 Code] AS [Dept Code] FROM " + Company_Select + "Fixed Asset] ";//Order by No_ 
            SqlDataAdapter dataadapter1 = new SqlDataAdapter(sql1, CN);
            dataadapter1.Fill(ds1, "Fixasset");
            dtgsearch.DataSource = ds1;
            dtgsearch.DataMember = "Fixasset";

            CN.Close();
            dtgsearch.Columns[0].Width = 80;
            dtgsearch.Columns[1].Width = 200;
            dtgsearch.Columns[3].Width = 60;
            dtgsearch.Columns[4].Width = 60;

            lblitemssearch.Text = "Data: " + dtgsearch.RowCount.ToString() + " Items";
            value_search = sql1;

        }

        private void cbunitrows_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbunitrows.SelectedIndex > -1)
            {
                if (cbunitrows.SelectedIndex == 0)
                {
                    Select_rows = "TOP 500";
                }
               else if (cbunitrows.SelectedIndex == 1)
                {
                    Select_rows = "TOP 1000";
                }

                else Select_rows = "";
            }


        }

        private void Get_Branch()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = "server=192.168.1.14;uid=sa; pwd=1234;";
            CN.Open();

            //DISTINCT

            string sql2 = "SELECT DISTINCT [Global Dimension 1 Code] AS Branch FROM " + Company_Select + "Fixed Asset]";
            SqlDataAdapter dataadapter2 = new SqlDataAdapter(sql2, CN);
            DataSet ds2 = new DataSet();
            dataadapter2.Fill(ds2);
            cbbranchselect.DataSource = ds2.Tables[0];
            cbbranchselect.DisplayMember = "Branch";
            cbbranchselect.ValueMember = "Branch";
            cbbranchselect.Text = " -- Select --";           
            CN.Close();  
        }

        private void Get_DeptNo()
        {          
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = "server=192.168.1.14;initial catalog=UMS LIVE; uid=sa; pwd=1234;";
           
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_getdept_barcode";
            cmd.Parameters.Add(new SqlParameter("@value_getselect", cbdatabaseselect.SelectedIndex + 1));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = CN;
            CN.Open();

            SqlDataAdapter SDTuser = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            DataSet DSuser = new DataSet();
            SDTuser.Fill(DSuser);
            cbdeptselect.DataSource = DSuser.Tables[0];
            cbdeptselect.DisplayMember = "NAMES";
            cbdeptselect.ValueMember = "DEPT";
            cbdeptselect.Text = "- - - Select  - - -";
            CN.Close();            

        }

        private void cbboxdept_CheckedChanged(object sender, EventArgs e)
        {
            if (cbboxdept.Checked == true)
            {
                cbdeptselect.Enabled = true; idsearch = 0;
            }
            else cbdeptselect.Enabled = false;
        }

        private void cbboxkbranch_CheckedChanged(object sender, EventArgs e)
        {
            if (cbboxkbranch.Checked == true)
            {
                cbbranchselect.Enabled = true; idsearch = 0;
            }
            else cbbranchselect.Enabled = false;
        }

        private void cbbranchselect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search_Select_Combo();
        }

        private void cbdeptselect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search_Select_Combo();
        }

        private void Search_Select_Combo()
        {
            try
            {

                string sql1 = "";

                if (cbboxkbranch.Checked==true & idsearch == 0)
                {
                    if (cbboxdept.Checked==true)
                    {
                        sql1 = "SELECT " + Select_rows + "  [No_],[Description],[Last Date Modified] AS [Date Modifiled],[Global Dimension 1 Code] AS Branch,[Global Dimension 2 Code] AS [Dept Code] FROM " + Company_Select + "Fixed Asset] WHERE [Global Dimension 1 Code]='" + cbbranchselect.Text.Trim() + "' AND [Global Dimension 2 Code] = '" + cbdeptselect.SelectedValue.ToString() + "'";//Order by No_                     
                    }
                    else
                    {
                        sql1 = "SELECT " + Select_rows + "  [No_],[Description],[Last Date Modified] AS [Date Modifiled],[Global Dimension 1 Code] AS Branch,[Global Dimension 2 Code] AS [Dept Code] FROM " + Company_Select + "Fixed Asset] WHERE [Global Dimension 1 Code]='" + cbbranchselect.Text.Trim() + "' ";//Order by No_ 
                    }
                    
                }


                if (cbboxdept.Checked == true & idsearch == 0)
                {
                    if (cbboxkbranch.Checked == true)
                    {
                        sql1 = "SELECT " + Select_rows + "  [No_],[Description],[Last Date Modified] AS [Date Modifiled],[Global Dimension 1 Code] AS Branch,[Global Dimension 2 Code] AS [Dept Code] FROM " + Company_Select + "Fixed Asset] WHERE [Global Dimension 1 Code]='" + cbbranchselect.Text.Trim() + "' AND [Global Dimension 2 Code] = '" + cbdeptselect.SelectedValue.ToString() + "'";//Order by No_   
   
                    }
                    else
                    {
                        sql1 = "SELECT " + Select_rows + "  [No_],[Description],[Last Date Modified] AS [Date Modifiled],[Global Dimension 1 Code] AS Branch,[Global Dimension 2 Code] AS [Dept Code] FROM " + Company_Select + "Fixed Asset] WHERE [Global Dimension 2 Code]='" + cbdeptselect.SelectedValue.ToString() + "' ";//Order by No_   


                    }

                }
                   
                DataSet ds1 = new DataSet();
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = "server=192.168.1.14; uid=sa; pwd=1234;";
                CN.Open();
                ds1.Clear();

                SqlDataAdapter dataadapter1 = new SqlDataAdapter(sql1, CN);
                dataadapter1.Fill(ds1, "Fixasset");
                dtgsearch.DataSource = ds1;
                dtgsearch.DataMember = "Fixasset";

                CN.Close();
                dtgsearch.Columns[0].Width = 80;
                dtgsearch.Columns[1].Width = 200;
                dtgsearch.Columns[3].Width = 60;
                dtgsearch.Columns[4].Width = 60;

                lblitemssearch.Text = "Data: " + dtgsearch.RowCount.ToString() + " Items";
                value_search = sql1;
            }
            catch 
            {
                //  MessageBox.Show(ex.Message);
            }
        
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
            idsearch = 1; string sql1 = "";
            DataSet ds1 = new DataSet();
            SqlConnection CN = new SqlConnection();
            //txtsearch.Clear();

            //CN.Open();

                if (cbbyfixcode.Checked== false && idsearch == 1 )  //sort by Description Column
                {
                    if (cbboxkbranch.Checked==true && cbboxdept.Checked == false)  // Search by Name witch check Branch (Description column)
                    {                     
                        sql1 = "SELECT " + Select_rows + "  [No_],[Description],[Last Date Modified] AS [Date Modifiled],[Global Dimension 1 Code] AS Branch,[Global Dimension 2 Code] AS [Dept Code] FROM " + Company_Select + "Fixed Asset] WHERE [Description] LIKE'% " + txtsearch.Text.Trim() + "%' AND [Global Dimension 1 Code]='" + cbbranchselect.Text.Trim() + "'";// AND [Global Dimension 2 Code] = '" + cbdeptselect.SelectedValue.ToString() + "'";                    
                    }

                    else if (cbboxkbranch.Checked == false && cbboxdept.Checked == true) // Search by Name check department (Description column)
                    {
                        sql1 = "SELECT " + Select_rows + "  [No_],[Description],[Last Date Modified] AS [Date Modifiled],[Global Dimension 1 Code] AS Branch,[Global Dimension 2 Code] AS [Dept Code] FROM " + Company_Select + "Fixed Asset] WHERE [Description] LIKE'% " + txtsearch.Text.Trim() + "%' AND [Global Dimension 2 Code] = '" + cbdeptselect.SelectedValue.ToString() + "'"; // AND [Global Dimension 1 Code]='" + cbbranchselect.Text.Trim() + "'";// 


                    }

                    else if (cbboxkbranch.Checked == true && cbboxdept.Checked == true)// Search by Name check branch and department (Description column)
                    {
                        sql1 = "SELECT " + Select_rows + "  [No_],[Description],[Last Date Modified] AS [Date Modifiled],[Global Dimension 1 Code] AS Branch,[Global Dimension 2 Code] AS [Dept Code] FROM " + Company_Select + "Fixed Asset] WHERE [Description] LIKE '% " + txtsearch.Text.Trim() + "%' AND [Global Dimension 2 Code] = '" + cbdeptselect.SelectedValue.ToString() + "' AND [Global Dimension 1 Code]='" + cbbranchselect.Text.Trim() + "'";// 

                    }

                    else if (cbboxkbranch.Checked == false && cbboxdept.Checked == false)
                    { 
                        sql1 = "SELECT " + Select_rows + "  [No_],[Description],[Last Date Modified] AS [Date Modifiled],[Global Dimension 1 Code] AS Branch,[Global Dimension 2 Code] AS [Dept Code] FROM " + Company_Select + "Fixed Asset] WHERE [Description] LIKE'% " + txtsearch.Text.Trim() + "%'";

                    }
                }
            
                if (cbbyfixcode.Checked == true && idsearch == 1) //sort by NO_ Column
                {
                    if (cbboxkbranch.Checked == true && cbboxdept.Checked == false)  // Search by Name witch check Branch (Description column)
                    {
                        sql1 = "SELECT " + Select_rows + "  [No_],[Description],[Last Date Modified] AS [Date Modifiled],[Global Dimension 1 Code] AS Branch,[Global Dimension 2 Code] AS [Dept Code] FROM " + Company_Select + "Fixed Asset] WHERE [No_] LIKE'%" + txtsearch.Text.Trim() + "%' AND [Global Dimension 1 Code]='" + cbbranchselect.Text.Trim() + "'";// AND [Global Dimension 2 Code] = '" + cbdeptselect.SelectedValue.ToString() + "'";                    
                    }

                    else if (cbboxkbranch.Checked == false && cbboxdept.Checked == true) // Search by Name check department (Description column)
                    {
                        sql1 = "SELECT " + Select_rows + "  [No_],[Description],[Last Date Modified] AS [Date Modifiled],[Global Dimension 1 Code] AS Branch,[Global Dimension 2 Code] AS [Dept Code] FROM " + Company_Select + "Fixed Asset] WHERE [No_] LIKE'%" + txtsearch.Text.Trim() + "%' AND [Global Dimension 2 Code] = '" + cbdeptselect.SelectedValue.ToString() + "'"; // AND [Global Dimension 1 Code]='" + cbbranchselect.Text.Trim() + "'";// 


                    }

                    else if (cbboxkbranch.Checked == true && cbboxdept.Checked == true)// Search by Name check branch and department (Description column)
                    {
                        sql1 = "SELECT " + Select_rows + "  [No_],[Description],[Last Date Modified] AS [Date Modifiled],[Global Dimension 1 Code] AS Branch,[Global Dimension 2 Code] AS [Dept Code] FROM " + Company_Select + "Fixed Asset] WHERE [No_] LIKE'%" + txtsearch.Text.Trim() + "%' AND [Global Dimension 2 Code] = '" + cbdeptselect.SelectedValue.ToString() + "' AND [Global Dimension 1 Code]='" + cbbranchselect.Text.Trim() + "'";// 

                    }

                    else if (cbboxkbranch.Checked == false && cbboxdept.Checked == false)
                    {
                        sql1 = "SELECT " + Select_rows + "  [No_],[Description],[Last Date Modified] AS [Date Modifiled],[Global Dimension 1 Code] AS Branch,[Global Dimension 2 Code] AS [Dept Code] FROM " + Company_Select + "Fixed Asset] WHERE [No_] LIKE'%" + txtsearch.Text.Trim() + "%'";

                    }
                }
            

                    CN.ConnectionString = "server=192.168.1.14; uid=sa; pwd=1234;";
                    CN.Open();
                    ds1.Clear();
                    SqlDataAdapter dataadapter1 = new SqlDataAdapter(sql1, CN);
                    dataadapter1.Fill(ds1, "Fixasset_seachtexchange");
                    dtgsearch.DataSource = ds1;
                    dtgsearch.DataMember = "Fixasset_seachtexchange";

                   

                    dtgsearch.Columns[0].Width = 80;
                    dtgsearch.Columns[1].Width = 200;
                    dtgsearch.Columns[3].Width = 60;
                    dtgsearch.Columns[4].Width = 60;


                    CN.Close();
                       
                lblitemssearch.Text = "Data: " + dtgsearch.RowCount.ToString() + " Items";
                value_search = sql1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
           //     MessageBox.Show("Your Can't Connect DataBase and Select Company","Error!! Connection",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtsearch.Clear();
            }

        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            DataSearch_Select_T0_DTGselect();            
        }

        private void dtgsearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index_SelectRow = e.RowIndex;
        }

        private void dtgselect_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index_DeleteRow = e.RowIndex;
        }

        
        private void DataSearch_Select_T0_DTGselect()
        {
            try
            {
                int Status_select = 0;

                for (int i = 0; i < dtgselect.Rows.Count; i++)
                {
                    if (dtgselect[0, i].Value.ToString().Trim() == dtgsearch[0, index_SelectRow].Value.ToString().Trim())
                    {
                        Status_select = 1;
                    }
                }

                if (Status_select == 0)
                {

                    dtgselect.ColumnCount = 4;

                    dtgselect.Columns[0].Name = "NO";
                    dtgselect.Columns[1].Name = "Location Code";
                    DataGridViewColumn column1 = dtgselect.Columns[1];
                    column1.Width = 150;

                    dtgselect.Columns[2].Name = "Name Fix-Asset";
                    DataGridViewColumn column2 = dtgselect.Columns[2];
                    column2.Width = 300;

                    dtgselect.Columns[3].Name = "Barcode Print";
                    DataGridViewColumn column3 = dtgselect.Columns[2];
                    column3.Width = 250;

                    string[] row = new string[] {
                dtgsearch[0, index_SelectRow].Value.ToString().Trim(), dtgsearch[3, index_SelectRow].Value.ToString().Trim(), dtgsearch[1, index_SelectRow].Value.ToString().Trim(),dtgsearch[3, index_SelectRow].Value.ToString().Trim() +"-" + dtgsearch[0, index_SelectRow].Value.ToString().Trim() };
                    dtgselect.Rows.Add(row);
                    
                }

                else
                {
                    MessageBox.Show("You Select Data Duplicate", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



                if (dtgselect.RowCount > 0)
                { btnprintpreview.Enabled = true; }
                else { btnprintpreview.Enabled = false; }


                lblitemselect.Text = "Data: " + dtgselect.RowCount.ToString() + " Items";
            }
            catch
            {
                MessageBox.Show("Your Can't Connect DataBase and Select Company", "Error!! Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsearch.Clear();
            }
        }

        
        private void dtgsearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataSearch_Select_T0_DTGselect(); 
        }

        private void btndeselect_Click(object sender, EventArgs e)
        {
            try
            {
                Remove_Row_DTGselect();
            }
            catch 
            {
                MessageBox.Show("Your Can't Connect DataBase or Select Company or Select Data Row!!", "Error!! Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Remove_Row_DTGselect()
        {
            dtgselect.Rows.RemoveAt(dtgselect.SelectedRows[0].Index);
            lblitemselect.Text = "Data: " + dtgselect.RowCount.ToString() + " Items";

            if (dtgselect.RowCount > 0)
            { btnprintpreview.Enabled = true; }
            else { btnprintpreview.Enabled = false; }
        }

        private void dtgselect_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Remove_Row_DTGselect();
        }

        private void cbbyfixcode_CheckedChanged(object sender, EventArgs e)
        {
            txtsearch.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //------------------ Find to File View before view print---------------------------//
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Find Search";
                //dlg.Filter = "bmp files (*.bmp)|*.bmp";
                dlg.Filter = "Select Files(*.xls; *.xlsx)|*.xls; *.xlsx";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtimportfile.Text = dlg.FileName.ToString();// (dlg.FileName.ToString());  txt           
                }

                dlg.Dispose();

                //------------ Insert URL path and Insert DataGridview1 ------------------//
                string strpath = txtimportfile.Text.Trim();
                //string strpath = @"C:\Users\shihafathw\Desktop\Employees.xls";
                // OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= '" + strpath + "';Extended Properties=" + (char)34 + "Excel 8.0;IMEX=1;" + (char)34 + "");

                string strConn = @"Data Source='" + strpath + "';Provider=Microsoft.ACE.OLEDB.12.0; Extended Properties=Excel 12.0;";
                OleDbDataAdapter da = new OleDbDataAdapter("select * from [Sheet1$]", strConn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dtgselect.Columns.Clear();
                dtgselect.DataSource = dt;
                btnprintpreview.Enabled = true;

                DataGridViewColumn column1 = dtgselect.Columns[1];
                column1.Width = 150;
                DataGridViewColumn column2 = dtgselect.Columns[2];
                column2.Width = 300;
                DataGridViewColumn column3 = dtgselect.Columns[2];
                column3.Width = 250;

                lblitemselect.Text = "Data: " + dtgselect.RowCount.ToString() + " Items";
            }
            catch { }
        }

        private void btnprintpreview_Click(object sender, EventArgs e)
        {
            if (rdoonline.Checked == true)
            {
                if (dtgselect.RowCount > 0)
                {
                    if (btnprintpreview.Text == "Print Preview")
                    {
                        dtgsearch.Visible = false;
                        crystalReportViewer1.Visible = true;
                        dtgselect.Size = new Size(455, 275);
                        dtgselect.Dock = DockStyle.Left;
                        panel8.Visible = false;

                        //  Loop_to_print_barcode();

                        DataGridViewColumn column1 = dtgselect.Columns[0];
                        column1.Width = 80;
                        DataGridViewColumn column2 = dtgselect.Columns[1];
                        column2.Width = 80;
                        DataGridViewColumn column3 = dtgselect.Columns[2];
                        column3.Width = 180;
                        DataGridViewColumn column4 = dtgselect.Columns[3];
                        column4.Width = 100;

                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("id", typeof(string));
                        dt.Columns.Add("name", typeof(string));
                        dt.Columns.Add("colo", typeof(string));
                        //foreach (DataGridViewRow dgv in dataGridView1.Rows)
                        //{
                        //    dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2]);
                        //}

                        for (int i = 0; i < dtgselect.RowCount; i++)
                        {
                            dt.Rows.Add(dtgselect[0, i].Value.ToString().Trim(), dtgselect[2, i].Value.ToString().Trim(), dtgselect[1, i].Value.ToString().Trim());
                        }

                        ds.Tables.Add(dt);
                        ds.WriteXmlSchema("Sample.xml");
                        CrystalReport2 cr = new CrystalReport2();
                        cr.SetDataSource(ds);
                        crystalReportViewer1.ReportSource = cr;
                        btnprintpreview.Text = "Un-Print";
                        btnprintpreview.ForeColor = Color.Red;
                    }

                    else//  if(btnprintpreview.Text == "Un-Print")
                    {
                        crystalReportViewer1.ReportSource = null;
                        crystalReportViewer1.Visible = false;

                        dtgsearch.Visible = true;
                        dtgselect.Dock = DockStyle.Fill;
                        if (dtgselect.RowCount < 0)
                        {
                            dtgselect.Rows.Clear();
                        }

                        DataGridViewColumn column1 = dtgselect.Columns[1];
                        column1.Width = 150;
                        DataGridViewColumn column2 = dtgselect.Columns[2];
                        column2.Width = 300;
                        DataGridViewColumn column3 = dtgselect.Columns[2];
                        column3.Width = 250;

                        panel8.Visible = true;

                        btnprintpreview.Text = "Print Preview";
                        btnprintpreview.ForeColor = Color.Blue;
                    }
                }

                else
                {
                    MessageBox.Show("You don't Select data to print", "Error!! Select Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (rdooffice.Checked == true)
            {
                if (btnprintpreview.Text == "Print Preview")
                {
                    dtgsearch.Visible = false;
                    crystalReportViewer1.Visible = true;
                    dtgselect.Size = new Size(455, 275);
                    dtgselect.Dock = DockStyle.Left;
                    panel8.Visible = false;

                    //  Loop_to_print_barcode();

                    DataGridViewColumn column1 = dtgselect.Columns[0];
                    column1.Width = 80;
                    DataGridViewColumn column2 = dtgselect.Columns[1];
                    column2.Width = 80;
                    DataGridViewColumn column3 = dtgselect.Columns[2];
                    column3.Width = 180;
                    DataGridViewColumn column4 = dtgselect.Columns[3];
                    column4.Width = 100;

                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("id", typeof(string));
                    dt.Columns.Add("name", typeof(string));
                    dt.Columns.Add("colo", typeof(string));
                    //foreach (DataGridViewRow dgv in dataGridView1.Rows)
                    //{
                    //    dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2]);
                    //}

                    for (int i = 0; i < dtgselect.RowCount; i++)
                    {
                        dt.Rows.Add(dtgselect[0, i].Value.ToString().Trim(), dtgselect[2, i].Value.ToString().Trim(), dtgselect[1, i].Value.ToString().Trim());
                    }

                    ds.Tables.Add(dt);
                    ds.WriteXmlSchema("Sample.xml");
                    CrystalReport2 cr = new CrystalReport2();
                    cr.SetDataSource(ds);
                    crystalReportViewer1.ReportSource = cr;
                    btnprintpreview.Text = "Un-Print";
                    btnprintpreview.ForeColor = Color.Red;
                }

                else//  if(btnprintpreview.Text == "Un-Print")
                {
                    crystalReportViewer1.ReportSource = null;
                    crystalReportViewer1.Visible = false;
                                       
                    dtgselect.Dock = DockStyle.Fill;
                    if (dtgselect.RowCount < 0)
                    {
                        dtgselect.Rows.Clear();
                    }

                    DataGridViewColumn column1 = dtgselect.Columns[1];
                    column1.Width = 150;
                    DataGridViewColumn column2 = dtgselect.Columns[2];
                    column2.Width = 300;
                    DataGridViewColumn column3 = dtgselect.Columns[2];
                    column3.Width = 250;

                    panel8.Visible = true;

                    btnprintpreview.Text = "Print Preview";
                    btnprintpreview.ForeColor = Color.Blue;
                }
            
            }

        }

        private void Frmmain_Load(object sender, EventArgs e)
        {
            ////create table with three columns
            //DataTable t = new DataTable();
            //t.Columns.Add("id", typeof(string));
            //t.Columns.Add("name", typeof(string));
            //t.Columns.Add("colo", typeof(string));
            ////add data to table
            //t.Rows.Add(1, "hasan", "amiri");
            //t.Rows.Add(2, "reza", "amiri");
            //t.Rows.Add(3, "amin", "neisi");

            ////bind table to datagridview
            //dataGridView1.DataSource = t;
        }

        private void cbshowopsearch_CheckedChanged(object sender, EventArgs e)
        {
            if (cbshowopsearch.Checked == true)
            {
                panel3.Visible = true;
            }
            else panel3.Visible = false;
        }

     

        
     
   
       

    }
}