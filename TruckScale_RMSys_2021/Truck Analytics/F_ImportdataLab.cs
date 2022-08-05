using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using GemBox.Spreadsheet;
using GemBox.Spreadsheet.WinFormsUtilities;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Globalization;


//using Excel = Microsoft.Office.Interop.Excel;


namespace Truck_Analytics
{
    public partial class F_ImportdataLab : Form
    {
        public F_ImportdataLab()
        {
            InitializeComponent();
        }

        public string Ticket_code = "";
        public string Simple_code = "";
        public string Product_id = "";
        public string Lab_code = "";
        OpenFileDialog fdlg = new OpenFileDialog();
        int sts_textchange = 0;


        //--------- Log
        string Msg = "";
        string Log_NewValue = "";
        string Log_OldValue = "";

        int Status_Use = 0;
        int Adddata_Per = 0;
        int Viewdata_Per = 0;
        string FileName_Move = "";
        string ID_AL = "";
        int ValueVisualNo = 0;
        string string1 = "";
        int LabID = 0;
        string Labname = "";
        string Messagemail = "";
        string tokenline = "";
        string ipsvr = "";
        string mailport = "";
        string accalert = "";
        string addpwd = "";
        int ShoDetail_line = 0;
        int ShoDetail_mail = 0;
        int Count_Alert = 0;
        int ID_UserApp = 0;
        int Status_Move = 0;

        private void Load_Permission()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql6 = "SELECT  Status_Use,Adddata_Per, Viewdata_Per FROM  [dbo].[V_Permission] WHERE [UserID] = '" + Program.user_id + "' AND [ID_Menu]= 21 ";
                SqlCommand CM6 = new SqlCommand(sql6, con);
                SqlDataReader DR6 = CM6.ExecuteReader();

                DR6.Read();
                {
                    if (DR6["Adddata_Per"].ToString().Trim() == "True") { Adddata_Per = 1; }
                    if (DR6["Viewdata_Per"].ToString().Trim() == "True") { Viewdata_Per = 1; }
                    if (DR6["Status_Use"].ToString().Trim() == "True") { Status_Use = 1; }
                }
                DR6.Close();
                con.Close();

                if (Viewdata_Per == 0)
                {
                    dtg_fileimport.Enabled = false;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("ไม่มีการเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานบันทึก-การนำเข้าไฟล์)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Msg = "Permission can't Access!";
                Log_NewValue = ex.ToString();
                Log_OldValue = "-";

                Class_Log CL = new Class_Log();
                CL.tbname = Msg;
                CL.oldvalue = Log_OldValue;
                CL.newvalue = Log_NewValue;
                CL.Save_log();

                this.Close();
            }

        }

        private void Load_CSVtoExcel()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql6 = "SELECT  [LabMoveAuto],[LabSourcepathCSV],[LabDispathCSV],[ColNameStarchNo],[ColValueStarchNo],[ColNameVANo],[ColValueVANo] FROM [dbo].[TB_LabSetting] WHERE [LabProductID] = '" + Product_id + "' ";
                SqlCommand CM6 = new SqlCommand(sql6, con);
                SqlDataReader DR6 = CM6.ExecuteReader();

                DR6.Read();
                {
                    if (DR6["LabMoveAuto"].ToString().Trim() == "True")
                    {
                        btn_browsfile.Enabled = false;
                        txt_destFile.Text = DR6["LabDispathCSV"].ToString().Trim();
                    }

                    else
                    {
                        btn_browsfile.Enabled = true;
                        txt_destFile.Text = "ระบบย้ายไฟล์อัตโนมัติปิดการใช้งาน";
                        txt_destFile.ForeColor = Color.Red;
                    }


                    //txt_indexnameStarch.Visible = false;
                    //txt_IndexnameVA.Visible = false;
                    //txt_indexvaluesStarch.Visible = false;
                    //txt_indexValueVA.Visible = false;


                    txt_indexnameStarch.Text = DR6["ColNameStarchNo"].ToString().Trim();
                    txt_indexvaluesStarch.Text = DR6["ColValueStarchNo"].ToString().Trim();
                    txt_IndexnameVA.Text = DR6["ColNameVANo"].ToString().Trim();
                    txt_indexValueVA.Text = DR6["ColValueVANo"].ToString().Trim();
                    txt_filepath.Text = DR6["LabSourcepathCSV"].ToString().Trim();
                    txt_sourceFile.Text = DR6["LabSourcepathCSV"].ToString().Trim();




                    //MessageBox.Show(txt_filepath.Text);
                    //
                    FileInfo longestFile = null;
                    string filter = @"*.*"; // all directories, all files
                    SearchOption searchType = SearchOption.AllDirectories;
                    longestFile = new DirectoryInfo(txt_filepath.Text)
                        .EnumerateFiles(filter, searchType)
                        .OrderByDescending(fil => fil.Length)
                        .FirstOrDefault();
                    //MessageBox.Show(longestFile.FullName.ToString());                
                    txt_filepath.Text = longestFile.FullName.ToString();
                    FileName_Move = longestFile.Name.ToString();


                    string ExtensionFile = Path.GetExtension(FileName_Move);

                    string str = "";
                    foreach (var c in ExtensionFile)
                    {
                        str = Convert.ToString((int)c);
                    }

                    if (str != "103" && str != "116")
                    {
                        var workbook = ExcelFile.Load(longestFile.FullName.ToString());
                        // From ExcelFile to DataGridView.
                        DataGridViewConverter.ExportToDataGridView(workbook.Worksheets.ActiveWorksheet, this.dtg_fileimport, new ExportToDataGridViewOptions() { ColumnHeaders = false });

                        workbook.Save(txt_destFile.Text + "\\" + FileName_Move);

                        txt_nameSelect1.Text = dtg_fileimport.Rows[dtg_fileimport.RowCount - 1].Cells[Convert.ToInt16(txt_indexnameStarch.Text.Trim())].Value.ToString();
                        txt_valueSelect1.Text = dtg_fileimport.Rows[dtg_fileimport.RowCount - 1].Cells[Convert.ToInt16(txt_indexvaluesStarch.Text)].Value.ToString();
                        txt_nameSelect2.Text = dtg_fileimport.Rows[dtg_fileimport.RowCount - 1].Cells[Convert.ToInt16(txt_IndexnameVA.Text)].Value.ToString();
                        txt_valueSelect2.Text = dtg_fileimport.Rows[dtg_fileimport.RowCount - 1].Cells[Convert.ToInt16(txt_indexValueVA.Text)].Value.ToString();

                        txt_indexnameStarch.Visible = true;
                        txt_IndexnameVA.Visible = true;
                        txt_indexvaluesStarch.Visible = true;
                        txt_indexValueVA.Visible = true;

                        dtg_fileimport.Rows[dtg_fileimport.RowCount - 1].Selected = true;
                    }

                    else
                    {
                        import_Textfile();

                        txt_nameSelect1.Text = dtg_fileimport.Rows[dtg_fileimport.RowCount - 1].Cells[6].Value.ToString();
                        txt_valueSelect1.Text = dtg_fileimport.Rows[dtg_fileimport.RowCount - 1].Cells[7].Value.ToString();
                        txt_nameSelect2.Text = dtg_fileimport.Rows[dtg_fileimport.RowCount - 1].Cells[24].Value.ToString();
                        txt_valueSelect2.Text = dtg_fileimport.Rows[dtg_fileimport.RowCount - 1].Cells[25].Value.ToString();

                        txt_indexnameStarch.Text = dtg_fileimport.Rows[dtg_fileimport.RowCount - 1].Cells[6].ColumnIndex.ToString();
                        txt_indexvaluesStarch.Text = dtg_fileimport.Rows[dtg_fileimport.RowCount - 1].Cells[7].ColumnIndex.ToString();
                        txt_IndexnameVA.Text = dtg_fileimport.Rows[dtg_fileimport.RowCount - 1].Cells[24].ColumnIndex.ToString();
                        txt_indexValueVA.Text = dtg_fileimport.Rows[dtg_fileimport.RowCount - 1].Cells[25].ColumnIndex.ToString();
                    }
                }



                DR6.Close();
                con.Close();

                if (Viewdata_Per == 0)
                {
                    dtg_fileimport.Enabled = false;
                }
            }

            catch (Exception ex)
            {
                //test
                //MessageBox.Show(ex.ToString());

                MessageBox.Show("ไม่พบรูปแบบไฟล์ข้อมูลที่นำเข้าระบบ กรุณาเช็คไฟล์จากแหล่งที่เก็บ: " + txt_sourceFile.Text.Trim(), "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Msg = "Source data file on failed!";
                Log_NewValue = ex.ToString();
                Log_OldValue = "-";

                Class_Log CL = new Class_Log();
                CL.tbname = Msg;
                CL.oldvalue = Log_OldValue;
                CL.newvalue = Log_NewValue;
                CL.Save_log();
            }

        }
      

        private void btn_browsfile_Click(object sender, EventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "Text file (*.txt, *.log)|*.txt;*.log|CSV files (*.csv, *.tsv)|*.csv;*.tsv|XLS files (*.xls, *.xlt)|*.xls;*.xlt|XLSX files (*.xlsx, *.xlsm, *.xltx, *.xltm)|*.xlsx;*.xlsm;*.xltx;*.xltm|ODS files (*.ods, *.ots)|*.ods;*.ots|HTML files (*.html, *.htm)|*.html;*.htm";


                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txt_filepath.Text = openFileDialog.FileName;

                    string ExtensionFile = Path.GetExtension(openFileDialog.FileName);

                    string str = "";
                    foreach (var c in ExtensionFile)
                    {
                        str = Convert.ToString((int)c);
                    }
                                       
                    if (str != "103" && str != "116")
                    {
                        var workbook = ExcelFile.Load(openFileDialog.FileName);
                        // From ExcelFile to DataGridView.
                        DataGridViewConverter.ExportToDataGridView(workbook.Worksheets.ActiveWorksheet, this.dtg_fileimport, new ExportToDataGridViewOptions() { ColumnHeaders = false });

                        workbook.Save(txt_destFile.Text + "\\" + FileName_Move);

                        txt_nameSelect1.Text = dtg_fileimport.Rows[0].Cells[6].Value.ToString();
                        txt_valueSelect1.Text = dtg_fileimport.Rows[0].Cells[7].Value.ToString();
                        txt_nameSelect2.Text = dtg_fileimport.Rows[0].Cells[15].Value.ToString();
                        txt_valueSelect2.Text = dtg_fileimport.Rows[0].Cells[16].Value.ToString();

                        txt_indexnameStarch.Text = dtg_fileimport.Rows[0].Cells[6].ColumnIndex.ToString();
                        txt_indexvaluesStarch.Text = dtg_fileimport.Rows[0].Cells[7].ColumnIndex.ToString();
                        txt_IndexnameVA.Text = dtg_fileimport.Rows[0].Cells[15].ColumnIndex.ToString();
                        txt_indexValueVA.Text = dtg_fileimport.Rows[0].Cells[16].ColumnIndex.ToString();

                    }

                    else
                    {
                        import_Textfile();

                        txt_nameSelect1.Text = dtg_fileimport.Rows[0].Cells[6].Value.ToString();
                        txt_valueSelect1.Text = dtg_fileimport.Rows[0].Cells[7].Value.ToString();
                        txt_nameSelect2.Text = dtg_fileimport.Rows[0].Cells[24].Value.ToString();
                        txt_valueSelect2.Text = dtg_fileimport.Rows[0].Cells[25].Value.ToString();

                        txt_indexnameStarch.Text = dtg_fileimport.Rows[0].Cells[6].ColumnIndex.ToString();
                        txt_indexvaluesStarch.Text = dtg_fileimport.Rows[0].Cells[7].ColumnIndex.ToString();
                        txt_IndexnameVA.Text = dtg_fileimport.Rows[0].Cells[24].ColumnIndex.ToString();
                        txt_indexValueVA.Text = dtg_fileimport.Rows[0].Cells[25].ColumnIndex.ToString();
                    }

                }

                
                Msg = "Import File!";
                Log_NewValue = txt_filepath.Text;
                Log_OldValue = Path.GetExtension(openFileDialog.FileName);

                Class_Log CL = new Class_Log();
                CL.tbname = Msg;
                CL.oldvalue = Log_OldValue;
                CL.newvalue = Log_NewValue;
                CL.Save_log();

                btn_save.Focus();
            }

            catch 

            {

            }


        }


        private void import_Textfile()
        {
            try
            {

                DataTable dt = new DataTable();

                for (int i = 0; i < 32; i++)
                {
                    dt.Columns.Add(i.ToString(), typeof(string));
                }

                dtg_fileimport.DataSource = dt;


                string[] lines = File.ReadAllLines(txt_filepath.Text, Encoding.Default);
                string[] values;


                for (int i = 0; i < lines.Length; i++)
                {
                    values = lines[i].ToString().Split(';');
                    string[] row = new string[values.Length];

                    for (int j = 0; j < values.Length; j++)
                    {
                        row[j] = values[j].Trim();
                    }
                    dt.Rows.Add(row);


                }

                dtg_fileimport.Columns[6].Width = 100;
                dtg_fileimport.Columns[7].Width = 100;
                dtg_fileimport.Columns[6].DefaultCellStyle.BackColor = Color.Beige;
                dtg_fileimport.Columns[7].DefaultCellStyle.BackColor = Color.Beige;


                dtg_fileimport.Columns[24].Width = 100;
                dtg_fileimport.Columns[25].Width = 100;
                dtg_fileimport.Columns[24].DefaultCellStyle.BackColor = Color.Fuchsia;
                dtg_fileimport.Columns[25].DefaultCellStyle.BackColor = Color.Fuchsia;

                dtg_fileimport.Rows[dtg_fileimport.RowCount - 1].Selected = true;

            }
            catch (Exception err)
            {
                // Display any errors in a Message Box.
                System.Windows.Forms.MessageBox.Show("Error+ err.Message", err.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                Msg = "Import file on failed!";
                Log_NewValue = err.ToString();
                Log_OldValue = "-";

                Class_Log CL = new Class_Log();
                CL.tbname = Msg;
                CL.oldvalue = Log_OldValue;
                CL.newvalue = Log_NewValue;
                CL.Save_log();
            }

        }


        private void ImportdataLab_Load(object sender, EventArgs e)
        {
            Load_Permission();

            if (Status_Use == 1)
            {
                try
                {
                    txt_simplecode.Text = Simple_code;
                    Load_Data();
                }

                catch (Exception ex)
                {
                    btn_save.Enabled = false;
                    cb_typelab.Enabled = false;
                    txt_simplecode.Clear();

                    MessageBox.Show("รายงานความผิดพลาด!!", "ไม่พบข้อมูลที่ต้องการค้นหา", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Msg = "Load Data file on failed!";
                    Log_NewValue = ex.ToString();
                    Log_OldValue = "-";

                    Class_Log CL = new Class_Log();
                    CL.tbname = Msg;
                    CL.oldvalue = Log_OldValue;
                    CL.newvalue = Log_NewValue;
                    CL.Save_log();
                }
            }

            else { MessageBox.Show("สิทธ์การใช้งานไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานบันทึก-การนำเข้าไฟล์ )", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void Load_Data()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql1 = "Select [QueueNo],[ProductName],[Plate1],[TruckTypeName],[ProductID] From [V_InuptLab] Where [TicketCodeIn]='" + Ticket_code + "' ";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                // count = Convert.ToInt16(DR1["countidqua"].ToString().Trim());

                lbl_quae.Text = DR1["QueueNo"].ToString().Trim();
                txt_product.Text = DR1["ProductName"].ToString().Trim();
                txt_truckno.Text = DR1["Plate1"].ToString().Trim();
                txt_trucktype.Text = DR1["TruckTypeName"].ToString().Trim();
                Product_id = DR1["ProductID"].ToString().Trim();
            }
            DR1.Close();

            con.Close();

            int w = panel4.Width / 2;
            int h = panel4.Height / 2;

            Load_TypeLab();


        }

        private void Load_TypeLab()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            //SqlConnection CN = new SqlConnection();
            //CN.ConnectionString = "server=192.168.111.225;initial catalog=HR_MNT;uid=hr_sync; pwd=hr@2021;";
            //CN.Open();

            SqlCommand cmd = new SqlCommand("Select [LabID],TRIM([LabNameTH]) AS 'LabNameTH'   From [TB_LabName] WHERE [ProductID]='" + Product_id + "' AND [LabActive]=1 AND [LabtypeID]=1", con);
            DataSet ds = new DataSet();
            //ds.Clear();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                // cb_section.DisplayMember = "nameSection_th" + "(" + "nameSection_eng" +")";
                //string name= "nameSection_th" + "(" + "nameSection_eng" + ")";

                cb_typelab.DisplayMember = "LabNameTH";
                cb_typelab.ValueMember = "LabID";
                cb_typelab.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }


        }

        private void F_ImportdataLab_ResizeEnd(object sender, EventArgs e)
        {
            int w = panel4.Width / 2;
            int h = panel4.Height / 2;

            int x = lbl_quae.Width / 2;
            int z = lbl_quae.Height / 2;

            lbl_quae.Location = new Point(w - x, h - z);
        }

        private void dtg_fileimport_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (sts_textchange == 1)
                {
                    txt_valueSelect1.Text = dtg_fileimport.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    txt_nameSelect1.Text = dtg_fileimport.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                }

                if (sts_textchange == 2)
                {
                    txt_valueSelect2.Text = dtg_fileimport.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    txt_nameSelect2.Text = dtg_fileimport.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                }

            }
            catch
            {

            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_valueSelect1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal i = Convert.ToDecimal(txt_valueSelect1.Text);
                txt_valueSelect1.ForeColor = Color.Black;
                sts_textchange = 0;
            }
            catch { txt_valueSelect1.ForeColor = Color.Red; }

        }

        private void txt_valueSelect2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal x = Convert.ToDecimal(txt_valueSelect2.Text);
                txt_valueSelect2.ForeColor = Color.Black;
                sts_textchange = 0;
            }
            catch { txt_valueSelect2.ForeColor = Color.Red; }
        }

        private void txt_valueSelect1_MouseClick(object sender, MouseEventArgs e)
        {
            txt_valueSelect1.Clear(); sts_textchange = 1;
        }

        private void txt_valueSelect2_MouseClick(object sender, MouseEventArgs e)
        {
            txt_valueSelect2.Clear(); sts_textchange = 2;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (Adddata_Per == 1)
            {
                if (txt_valueSelect1.Text != txt_valueSelect2.Text)
                {
                    try
                    {

                        DialogResult dr = MessageBox.Show("ยืนยันข้อมูล % แป้ง:" + txt_valueSelect1.Text + " ค่า VA:" + txt_valueSelect2.Text, "คุณต้องการบันทึกข้อมูลนี้ใช่หรือไม่", MessageBoxButtons.YesNo,
                  MessageBoxIcon.Information);

                        if (dr == DialogResult.Yes)
                        {
                            // Save to data base
                            Save_DataLab();
                        }

                        else { timer1.Enabled = false; }
                    }

                    catch
                    {
                        MessageBox.Show("ข้อมูลไม่ถูกต้องกรุณาเช็คอีกครั้ง!!", "รูปแบบข้อมูลผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                else
                {
                    MessageBox.Show("รายงานความผิดพลาด!!", "ข้อมูลต้องไม่เท่ากัน/เหมือนกัน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else { MessageBox.Show("สิทธ์การเพิ่มข้อมูลไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานบันทึก-การนำเข้าไฟล์)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void Save_DataLab()
        {
            txt_simplecode.SelectionStart = 0;
            txt_simplecode.SelectionLength = 20;
            //txt_simplecode.Text = txt_simplecode.SelectedText;

            // Source -> import file  มันเส้น
            //Source -> เครื่องมือแลป ไม้สับ , เหง้ามัน

            double value1 = 0;
            double value2 = 0;
            LabID = Convert.ToInt16(cb_typelab.SelectedValue.ToString());
            int LabID2 = 6;  // id va มันเส้น

            string date = Program.Date_Now + ' ' + Program.Time_Now;

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            if (Product_id == "RM-001")
            {
                value1 = Convert.ToDouble(txt_valueSelect1.Text);
                value2 = Convert.ToDouble(txt_valueSelect2.Text);
            }

            else if (Product_id == "")
            {
                value1 = Convert.ToDouble(txt_valueSelect3.Text);
            }


            //ค่าที่ 1
            if (value1 != 0)
            {
                con.Open();
                string sql1 = "Insert Into [TB_LabData]([TicketCodeIn], [LabID],[SimpleCode],[LabCode],[ValueLab],[CreateDate],[CreateBy],[InActive]) Values('" + Ticket_code + "', " + LabID + ", '" + txt_simplecode.SelectedText + "','" + Lab_code + "', " + value1 + ", '" + date + "', '" + Program.user_login + "',1)";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                con.Close();

                // Log
                Msg = "Update DataLab on Value1!";
                Log_NewValue = "TicketCodeIn =" + Ticket_code +
                    "," + "LabID = " + LabID.ToString() +
                    "," + "SimpleCode = " + txt_simplecode.SelectedText +
                    "," + "LabCode = " + Lab_code.ToString() +
                    "," + "ValueLab = " + value1.ToString() +
                    "," + "CreateDate = " + date.ToString() +
                    "," + "CreateBy = " + Program.user_login +
                    "," + "InActive = 1";    

                Log_OldValue = "-";
            }


            // ค่าที่ 2
            if (value2 != 0)
            {
                con.Open();
                string sql2 = "Insert Into [TB_LabData]([TicketCodeIn],[LabID],[SimpleCode],[LabCode],[ValueLab],[CreateDate],[CreateBy],[InActive]) Values('" + Ticket_code + "', '" + LabID2 + "', '" + txt_simplecode.SelectedText + "','" + Lab_code + "', " + value2 + ", '" + date + "', '" + Program.user_login + "',1)";
                SqlCommand CM2 = new SqlCommand(sql2, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();

                // Log
                Msg = "Update DataLab on Value2!";

                Log_NewValue = "TicketCodeIn =" + Ticket_code +
                "," + "LabID = " + LabID2.ToString() +
                "," + "SimpleCode = " + txt_simplecode.SelectedText +
                "," + "LabCode = " + Lab_code.ToString() +
                "," + "ValueLab = " + value2.ToString() +
                "," + "CreateDate = " + date.ToString() +
                "," + "CreateBy = " + Program.user_login +
                "," + "InActive = 1";

                Log_OldValue = "-";
            }

            if (value1 != 0)
            {
                try
                {
                    con.Open();
                    string sql3 = "Select [LOGID] From [dbo].[TB_ValueLab]  Where  LabID= " + LabID + " AND [Min] <" + value1 + " AND [Max] >= " + value1 + " AND Alert_Lab =1";
                    SqlCommand CM3 = new SqlCommand(sql3, con);
                    SqlDataReader DR3 = CM3.ExecuteReader();
                    DR3.Read();
                    {
                        ValueVisualNo = Convert.ToInt16(DR3["LOGID"].ToString().Trim());
                    }
                    DR3.Close();
                    con.Close();
                }
                catch { }
            }

            Load_CheckWaring();  //Check Count send mail
            Send_Alert();    // Send mail
            Save_App();  //update database of request approved                                                                                                                                       
            Class_Log CL = new Class_Log();
            CL.tbname = Msg;
            CL.oldvalue = Log_OldValue;
            CL.newvalue = Log_NewValue;
            CL.Save_log();            

            MessageBox.Show("บันทึกสำเร็จ!!", "รายงานการบันทึก", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (rdo_importfile.Checked == true)
            {
                dtg_fileimport.DataSource = null;
                txt_valueSelect1.Text = "-";
                txt_valueSelect2.Text = "-";
            }

            if (rdo_importMachine.Checked == true)
            {
                lblinfor.Text = "";
                txt_valueSelect3.Text = "-";
            }

            Status_Move = 1;
            lbl_quae.Text = "-";
            txt_simplecode.Clear();
            txt_product.Clear();
            cb_typelab.Text = "";
            txt_truckno.Clear();
            txt_trucktype.Clear();

            txt_simplecode.Focus();
        }

        private void Load_CheckWaring()
        {
            ///Concept flow 
            ///1. load value from setup alert report on true
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql1 = "Select Count([LOGID]) AS 'Check_ALT' From [dbo].[V_AlertSMG_Lab] Where [ProductID]='" + Product_id + "' AND [LOGID]='" + ValueVisualNo + "' AND [ID_Frm_TypeLab]=1";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                Count_Alert += Convert.ToInt16(DR1["Check_ALT"].ToString().Trim());
            }
            DR1.Close();
            con.Close();

            if (Count_Alert > 0)
            {
                con.Open();
                string sql2 = "Select [ID_User] From [dbo].[V_AlertSMG_Lab] Where [ProductID]='" + Product_id + "' AND [LOGID]='" + ValueVisualNo + "' AND [ID_Frm_TypeLab]=1 AND [App_Sts]=1 AND [Status_RP]=1  AND [Level_App]=1";
                SqlCommand CM2 = new SqlCommand(sql2, con);
                SqlDataReader DR2 = CM2.ExecuteReader();

                DR2.Read();
                {
                    ID_UserApp = Convert.ToInt16(DR2["ID_User"].ToString().Trim());
                }
                DR2.Close();
                con.Close();
            }
        }


        private void lineNotify(string msg)
        {
            string token = tokenline;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("https://notify-api.line.me/api/notify");
                var postData = string.Format("message={0}", msg);
                var data = Encoding.UTF8.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.Headers.Add("Authorization", "Bearer " + token);

                using (var stream = request.GetRequestStream()) stream.Write(data, 0, data.Length);
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void List_EmailAlert()
        {
            if (ValueVisualNo != 0)
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();
                string1 = "";

                string sql1 = "Select  DISTINCT([ID_ALRP]),[Email],[ID_AL] From [dbo].[V_AlertSMG_Lab] Where [ProductID]='" + Product_id + "' AND [LabID]='" + LabID + "' AND [ID_Frm_TypeLab]=1 AND [LOGID]=" + ValueVisualNo + " AND [Status_RP]=1";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                while (DR1.Read())
                {
                    string email = DR1["Email"].ToString().Trim();
                    ID_AL = DR1["ID_AL"].ToString().Trim();

                    if (string1.Contains(email) == false)
                    {
                        string1 += email + ",";
                    }

                }

                DR1.Close();
                con.Close();
            }
        }

        private void Load_ConfigAlert()
        {
            if (ID_AL != "")
            {
                SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
                con1.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con1.Open();

                string sql1 = "SELECT * FROM  [dbo].[V_Alert_Setting] Where [ID_AL]=" + ID_AL + " AND [ID_ALdStatus] = 1";
                SqlCommand CM1 = new SqlCommand(sql1, con1);
                SqlDataReader DR1 = CM1.ExecuteReader();

                while (DR1.Read())
                {
                    if (DR1["ID_ALtype"].ToString().Trim() == "1")  // Load mail config
                    {
                        ipsvr = DR1["Val1_ALT"].ToString().Trim();
                        mailport = DR1["Val2_ALT"].ToString().Trim();
                        accalert = DR1["Val3_ALT"].ToString().Trim();
                        addpwd = DR1["Val4_ALT"].ToString().Trim();

                        //ShoDetail
                        if (DR1["ShoDetail"].ToString().Trim() == "True")
                        {
                            ShoDetail_mail = 1;
                        }
                    }

                    if (DR1["ID_ALtype"].ToString().Trim() == "2") // Load line config
                    {
                        tokenline = DR1["Val1_ALT"].ToString().Trim();

                        if (DR1["ShoDetail"].ToString().Trim() == "True")
                        {
                            ShoDetail_line = 1;
                        }
                    }


                }
                DR1.Close();
                con1.Close();
            }
        }

        private void Send_Alert()
        {
            ///Concept flow            
            /// 2. load value setup alert by product & labtype from email & line app
            /// 3.check user from to alert
            /// 4 check user from to approved
            /// 5. sent alert by type email & line app   
            if (Count_Alert > 0)
            {
                /// Load formail Send Masgemess
                ///                 

                try
                {
                    if (ipsvr != "")
                    {
                        string Name = string1;
                        string1 = Name.Remove(Name.Length - 1);

                        int port = Convert.ToInt16(mailport);
                        SmtpClient smtpClient = new SmtpClient(ipsvr, port);
                        smtpClient.Credentials = new System.Net.NetworkCredential(accalert, addpwd);
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        MailMessage mailMessage = new MailMessage();
                        mailMessage.From = new MailAddress(accalert);
                        mailMessage.To.Add(string1);

                        if (ShoDetail_mail == 0)
                        { Messagemail = "-"; }

                        mailMessage.Subject = "การวิเคราะห์ทางกายภายไม่ผ่านเกณฑ์ตัวอย่างที่ : " + txt_simplecode.Text.Trim();
                        mailMessage.Body = "ชื่อสินค้า: " + txt_product.Text.Trim() + " เลขที่บัตรชั่ง: " + Ticket_code + " เลขที่ตัวอย่าง: " + txt_simplecode.Text.Trim() +
                            "\r\n ประเภทรถ: " + txt_trucktype.Text.Trim() + " ทะเบียนรถ: " + txt_truckno.Text.Trim() +
                           "\r\n" + "ผลการวิเคราะห์: " + Messagemail +
                            "\r\n" +
                            "ทดสอบส่งวันที่ :" + DateTime.Now.ToShortDateString() + " เวลา:" + DateTime.Now.ToLongTimeString() +
                             "\r\n" +
                            "------ ทดสอบระบบแจ้งเตือนผลไม่ผ่านเกณฑ์ งานชั่ง (Truck Scale Systems V 5.0.5) ------";
                        smtpClient.Send(mailMessage);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                    Msg = "Send SMS on App line to failed!";
                    Log_NewValue = ex.ToString();
                    Log_OldValue = "-";

                    Class_Log CL = new Class_Log();
                    CL.tbname = Msg;
                    CL.oldvalue = Log_OldValue;
                    CL.newvalue = Log_NewValue;
                    CL.Save_log();


                }

            }

            //SqlConnection con = new SqlConnection(Program.pahtdb);
            //con.ConnectionString = Program.pahtdb;
            //SqlDataAdapter dtAdapter = new SqlDataAdapter();

            //con.Open();
            //string sql1 = "Select Count([ValueVisualNo]) AS 'Check_ALT' From [dbo].[V_AlertSMG] Where [ProductID]='" + ProductID + "' AND [ValueVisualNo]='" + ValueVisualNo + "' AND [ID_Frm_TypeLab]=2";
            //SqlCommand CM1 = new SqlCommand(sql1, con);
            //SqlDataReader DR1 = CM1.ExecuteReader();

            //DR1.Read();
            //{
            //    Count_Alert += Convert.ToInt16(DR1["Check_ALT"].ToString().Trim());
            //}
            //DR1.Close();
        }


        private void Save_App()
        {
            if (ID_UserApp != 0)
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter1 = new SqlDataAdapter();

                con.Open();
                string sql1 = "Update [TB_WeightData] Set  [StatusID]=2 Where [TicketCodeIn] = '" + Ticket_code + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                con.Close();

                string date = Program.Date_Now + ' ' + DateTime.Now.ToString("HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));

                con.Open();
                string sql = "Insert Into [TB_Approved] ([TicketCodeIn],[SimpleCode],[CreateDate],[ID_UserApp],[StatusID]) Values('" + Ticket_code + "','" + Simple_code + "', '" + date + "', " + ID_UserApp + ",2)";
                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();

            }
        }

        private void Delete_File()
        {
            string sour_path = @"" + txt_sourceFile.Text + "\\" + FileName_Move;
            string disc_path = @"" + txt_destFile.Text + "\\" + FileName_Move;

            try
            {
                // Ensure that the target does not exist.
                if (File.Exists(disc_path))
                    File.Delete(sour_path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_pathSave_Click(object sender, EventArgs e)
        {
            F_PathMoveFile pmf = new F_PathMoveFile();
            pmf.ShowDialog();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Load_CSVtoExcel();
        }

        private void F_ImportdataLab_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Status_Move == 1)
            {
                Delete_File();
            }
        }

        private void rdo_importfile_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_importfile.Checked == true)
            {
                tb_SourceFile.SelectedIndex = 0;
                tb_sourceDetail.SelectedIndex = 0;

                Load_CSVtoExcel();
            }
        }

        private void rdo_importMachine_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_importMachine.Checked == true)
            {
                tb_SourceFile.SelectedIndex = 1;
                tb_sourceDetail.SelectedIndex = 1;
            }
        }

        private void btn_stReciveData_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("คุณต้องการยืนยันเริ่มรับข้อมูลจากเครื่องมือ ใช่หรือไม่ ?","ยืนยันการรับข้อมูล", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                richTextBox1.Clear();
                richTextBox1.Enabled = true;
                richTextBox1.Text = "  เริ่มรับข้อมูล.....";
                richTextBox1.Text += Environment.NewLine + "  ";
                timer1.Enabled = true;
                richTextBox1.Focus();
                richTextBox1.Select(richTextBox1.Text.Length, 0);
            }
        }

        int sec = 8; string word = "%M	Result";
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sec == 0)
            {
                Search_TXT();
                              

                if (txt_valueSelect3.Text != "-")
                {
                    timer1.Enabled = false;
                    DialogResult dr = MessageBox.Show("รายงานผลการวิเคราะห์: " + txt_valueSelect3.Text + " ต้องการยืนยันเพื่อบันทึกผลหรือไม่ ?", "รายงาน/ยืนยันการรับข้อมูล", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        Save_DataLab();
                        richTextBox1.Clear();
                        txt_simplecode.Focus();
                    }

                    if (dr == DialogResult.No)
                    { richTextBox1.Clear(); txt_valueSelect3.Text = "-"; richTextBox1.Enabled = false; richTextBox1.Text = "----หยุดการรับข้อมูล----"; }
                }
                else
                {
                    sec = 8;
                    richTextBox1.Focus();
                    richTextBox1.Select(richTextBox1.Text.Length, 0);
                }
            }
            else { sec--; }
        }

        private void Search_TXT()
        {
            string[] words = word.Split(',');
            foreach (string word in words)
            {
                int startindex = 0;
                while (startindex < richTextBox1.TextLength)
                {
                    int wordstartIndex = richTextBox1.Find(word, startindex, RichTextBoxFinds.None);
                    if (wordstartIndex != -1)
                    {
                        richTextBox1.SelectionStart = wordstartIndex - 6;
                        richTextBox1.SelectionLength = word.Length - 4;
                        richTextBox1.SelectionBackColor = Color.Yellow;
                        txt_valueSelect3.Text = richTextBox1.SelectedText.Trim();
                    }
                    else
                        break;
                    startindex += wordstartIndex + word.Length;
                }
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            sec = 8;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_valueSelect3.Text != "-")
            {
                DialogResult dr = MessageBox.Show("รายงานผลการวิเคราะห์: " + txt_valueSelect3.Text + " ต้องการยืนยันเพื่อบันทึกผลหรือไม่ ?", "รายงาน/ยืนยันการรับข้อมูล", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    Save_DataLab();
                    richTextBox1.Clear();
                    richTextBox1.Enabled = false;
                    richTextBox1.Text = "----หยุดการรับข้อมูล----";                   
                    txt_simplecode.Focus();
                }

                if (dr == DialogResult.No)
                { richTextBox1.Clear();  richTextBox1.Text = "----หยุดการรับข้อมูล----"; txt_valueSelect3.Text = "-"; }
            }
        }

        private void txt_simplecode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                int index = 0;
                int st_cha = 0;
                int ed_cha = 0;
                int count = 0;

                string str = txt_simplecode.Text;
                char[] b = new char[str.Length];

                b = str.ToCharArray();

                foreach (char c in b)
                {
                    index += 1;

                    if (c.ToString() == "-")
                    {
                        count += 1;
                    }

                    if (count == 2 && c.ToString() == "-")
                    {
                        st_cha = index;
                    }

                    if (count == 3 && c.ToString() == "-")
                    {
                        ed_cha = (index - st_cha) + 4;
                    }

                }

                txt_simplecode.SelectionStart = st_cha;
                txt_simplecode.SelectionLength = ed_cha;
                Ticket_code = txt_simplecode.SelectedText;

                Load_Data();

                //if (Product_id != "")
                //{
                //    richTextBox1.Text = "  เริ่มรับข้อมูล.....";
                //    richTextBox1.Text += Environment.NewLine + "  ";                    
                //    richTextBox1.Focus();
                //    richTextBox1.Select(richTextBox1.Text.Length, 0);
                //}
            }
        }

        private void tb_SourceFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tb_SourceFile.SelectedIndex == 0)
            {
                tb_sourceDetail.SelectedIndex = 0;
            }
            if (tb_SourceFile.SelectedIndex == 1)
            {
                tb_sourceDetail.SelectedIndex = 1;
            }
        }

    }

}
