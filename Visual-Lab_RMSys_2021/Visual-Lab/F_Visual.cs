using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Collections;
using System.Net.Mail;
using System.Globalization;



namespace Visual_Lab
{
    public partial class F_Visual : Form
    {
        public F_Visual()
        {
            InitializeComponent();


        }
                
        int statat_edit = 0;
        string Table_Name = "";
        string Log_newValue = "";
        string Log_oldValue = "";
        int id_process = 0;
        string name_process = "";
        decimal db_Version = 0;

        int Status_Use = 0;
        int Adddata_Per = 0;
        int Editdata_Per = 0;
        int Viewdata_Per = 0;
        int ValueVisualNo = 0;
        int Count_Alert=0;
        string ID_AL = "";
        int Lab_id = 0;
        string Messagemail = "";
        string tokenline = "";
        string ipsvr = "";
        string mailport = "";
        string accalert = "";
        string addpwd = "";
        int ShoDetail_line = 0;
        int ShoDetail_mail = 0;
        int ID_UserApp = 0;


        private void Load_Permission()
        {
            try
            {
                //test
                //Adddata_Per = 1;
                //Editdata_Per = 1;
                //Viewdata_Per = 1;
                //Status_Use = 1;

                SqlConnection con = new SqlConnection(Program.pahtdb);
                con.ConnectionString = Program.pahtdb;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql6 = "SELECT  Status_Use, Adddata_Per, Editdata_Per, Viewdata_Per FROM [SapthipNewDB].[dbo].[V_Permission] WHERE [UserID] = '" + Program.user_id + "' AND [ID_Menu]= 19 ";
                SqlCommand CM6 = new SqlCommand(sql6, con);
                SqlDataReader DR6 = CM6.ExecuteReader();

                DR6.Read();
                {
                    if (DR6["Adddata_Per"].ToString().Trim() == "True") { Adddata_Per = 1; }
                    if (DR6["Editdata_Per"].ToString().Trim() == "True") { Editdata_Per = 1; }
                    if (DR6["Viewdata_Per"].ToString().Trim() == "True") { Viewdata_Per = 1; }
                    if (DR6["Status_Use"].ToString().Trim() == "True") { Status_Use = 1; }
                }
                DR6.Close();
                con.Close();

                if (Adddata_Per == 1)
                {
                    btn_scan.Enabled = true;                   
                    //btn_save.Enabled = true;
                    txt_qrcode.ReadOnly = false;
                    dtg_savetype.Enabled = true;
                    txt_remark.Enabled = true;
                }

                if (Adddata_Per == 0) { MessageBox.Show("สิทธ์การเพิ่มข้อมูลไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานบันทึก-ทางกายภาพ)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }

            catch {
                MessageBox.Show("ไม่มีการเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานบันทึก-ทางกายภาพ)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }


        private void Save_Log()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd") + ' ' + DateTime.Now.ToString("HH:mm");

            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql = "Insert Into [TB_Log] ([LogDateTime],[Username],[TableName],[OldValue],[NewValue],[MachineName],[LocalIpAddress]) Values('" + date + "', '" + Program.user_login + "', '" + Table_Name + "','" + Log_newValue + "', '" + Log_oldValue + "', '" + Program.MachineName + "', '" + Program.LocalIpAddress + "')";
            SqlCommand CM2 = new SqlCommand(sql, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();
        }

        private void Load_CheckVersion_Software()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            string sql6 = "SELECT [no_version] FROM [dbo].[TB_Version] WHERE [id_version] = 4";
            SqlCommand CM6 = new SqlCommand(sql6, con);
            SqlDataReader DR6 = CM6.ExecuteReader();

            DR6.Read();
            {               
                db_Version = Convert.ToDecimal(DR6["no_version"].ToString().Trim());
            }
            DR6.Close();
            con.Close();


        }

        private void Adjust_location()
        {
            int f_wide = this.Width;

            panel5.Width = f_wide;
            panel6.Width = (f_wide * 20) / 100;

        }



        private void F_Visual_Load(object sender, EventArgs e)
        {
            // for test 
            Adjust_location();

            StreamReader sw = new StreamReader(Application.StartupPath + "\\cn.dll");
            string connecpovider = sw.ReadToEnd();
            Program.CN = new SqlConnection();
            Program.CN.ConnectionString = connecpovider;
            Program.pahtdb = connecpovider;
            Program.MachineName = Environment.MachineName.ToString();
            Program.LocalIpAddress = GetIPAddress();
            Program.user_id = 22;

            StreamReader vs = new StreamReader(Application.StartupPath + "\\version.dll");
            string version = vs.ReadToEnd();

            Load_CheckVersion_Software();
            Check_StatusWiFi();
            timer1.Enabled = true;             


            if (Convert.ToDecimal(version) >= db_Version)
            {
                //F_Login flg = new F_Login();
                //flg.ShowDialog();

                //test
                //Program.user_id = 4;

                lbl_version.Text = "เวอร์ชั่นที่พัฒนา: "+ version.Trim();

                if (Program.user_id != 0)
                {
                    Load_Permission();

                    if (Status_Use == 1)
                    {
                        this.WindowState = FormWindowState.Maximized;

                        Load_Adjust_Size();

                        txt_qrcode.Focus();
                    }

                    else
                    {
                        MessageBox.Show("ไม่มีการเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานบันทึก-ทางกายภาพ)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

                else { Application.Exit(); }
            }
            else {

                MessageBox.Show("โปรแกรมไม่ใช่เวอร์ชั่นล่าสุด กรุณาอัพเดทโปรแกรม", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void Load_Location()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT [NO_Zone] ,Trim([Name_Zone]) AS 'Name_Zone'  FROM [dbo].[V_LocationZone] Where  [ProductID]='" + ProductID + "'", con);

            DataSet ds = new DataSet();
            //ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.SelectCommand.CommandTimeout = 0;
            da.Fill(ds);
            //Load product tab weight scale Setup
            cb_location.DataSource = ds.Tables[0];
            cb_location.DisplayMember = "Name_Zone";
            cb_location.ValueMember = "NO_Zone";
            con.Close();
        }

        private void Load_Adjust_Size()
        {
            int PN_all = this.Width;
            panel5.Width = (PN_all * 5) / 100;
            panel6.Width = (PN_all * 5) / 100;
            panel8.Location = new Point ((pnl_hcenter.Width/2)-(panel8.Width/2),15);

            label11.Location = new Point((panel7.Width / 2) - (label11.Width / 2), 9);


            //int PN_all = this.Width;
            //double PN_Main = PN_all * 0.60;
            //int ddd = PN_all - Convert.ToInt16(PN_Main);
            //pnl_left.Width = ((PN_all - Convert.ToInt16(PN_Main)) / 2) / 2;
            //pnl_right.Width = pnl_left.Width;
            // adjuxt panel main
            //pnl_left.Width = (PN_all * 5) / 100;
            //pnl_right.Width = (PN_all * 5) / 100;
            //pnl_hleft.Width = (PN_all * 5) / 100;


            ////adjust panel on tob
            //pnl_hleft.Width = (PN_button - 905) / 2;
            //pnl_hright.Width = (PN_button - 905) / 2;

            ////adjust panel on button
            //pnl_bLeft.Width = (PN_button - 924) / 2;
            //pnl_bRight.Width = (PN_button - 924) / 2;

        }

        private string GetIPAddress()
        {
            StringBuilder sb = new StringBuilder();
            String strHostName = string.Empty;
            strHostName = Dns.GetHostName();
            //sb.Append("The Local Machine Host Name: " + strHostName);
            //sb.AppendLine();
            IPHostEntry ipHostEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] address = ipHostEntry.AddressList;
            sb.Append(address[1].ToString());
            sb.AppendLine();
            return sb.ToString();
        }

        private void Load_Defualt_Setting()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql1 = "Select [LabSourcepathVisual],[LabDispathVisual]  From [TB_LabSetting] WHERE [LabProductID]= '"+ ProductID + "'";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                Program.Sourc_Imagefile = DR1["LabSourcepathVisual"].ToString().Trim();
                Program.Dis_Imagefile = DR1["LabDispathVisual"].ToString().Trim();
                //[QueueNo]
            }
            DR1.Close();

            con.Close();


            //string path = Application.StartupPath + @"\pic_temp\" + txt_qrcode.Text + "-1.JPG";

            if (Program.Sourc_Imagefile == @"..\pic_temp\")
            { Program.Sourc_Imagefile = @"\pic_temp\"; }
                                 
        }

        private void btn_scan_Click(object sender, EventArgs e)
        {


        }

        string ProductID = "";

        private void Load_Data()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pahtdb);
                con.ConnectionString = Program.pahtdb;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql1 = "Select [ProductName],[Plate1],[TruckTypeName],[QueueNo],[ProductID],[proc_no] From [V_InuptLab] Where [TicketCodeIn]='" + txt_ticketcode.Text.Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    txt_product.Text = DR1["ProductName"].ToString().Trim();
                    txt_trucktype.Text = DR1["TruckTypeName"].ToString().Trim();
                    txt_truckno.Text = DR1["Plate1"].ToString().Trim();
                    txt_queNo.Text = DR1["QueueNo"].ToString().Trim();
                    ProductID = DR1["ProductID"].ToString().Trim();
                    id_process = Convert.ToInt16(DR1["proc_no"].ToString().Trim());
                    //[QueueNo] v[proc_no]
                }
                DR1.Close();

                con.Close();

                Check_Status_edit();
                //Load_MainmenuDTG();
            }
            catch { }
        }

        private void Load_Mositure()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pahtdb);
                con.ConnectionString = Program.pahtdb;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

                con.Open();
                string sql1 = "Select [ValueLab] FROM [SapthipNewDB].[dbo].[TB_LabData]  WHERE  [TicketCodeIn] ='"+txt_ticketcode.Text.Trim()+"' and LabID = 4 ORDER BY [LOGID] offset 0 ROWS  Fetch Next 1 ROWS only";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                DR1.Read();
                {
                    txt_moistExam1.Text = DR1["ValueLab"].ToString().Trim();  
                }
                DR1.Close();
                con.Close();

                con.Open();
                string sql2 = "Select [ValueLab] FROM [SapthipNewDB].[dbo].[TB_LabData]  WHERE  [TicketCodeIn] ='" + txt_ticketcode.Text.Trim() + "' and LabID = 4 ORDER BY [LOGID] offset 1 ROWS  Fetch Next 1 ROWS only";
                SqlCommand CM2 = new SqlCommand(sql2, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                DR2.Read();
                {
                    txt_moistExam2.Text = DR2["ValueLab"].ToString().Trim();
                }
                DR2.Close();
                con.Close();

            }
            catch { }

        }

        private void Check_Status_edit()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql1 = "Select Count([TicketCodeIn])  AS 'Check_Insert' FROM [TB_VisualData]  Where [TicketCodeIn]='" + txt_ticketcode.Text.Trim() + "'";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                if (Convert.ToInt16(DR1["Check_Insert"].ToString().Trim()) >= 1)
                {
                    statat_edit = 1;
                }
            }
            DR1.Close();

            con.Close();

        }

        private void btn_imag1_Click(object sender, EventArgs e)
        {           
            F_Camera fc = new F_Camera();

            string path = Application.StartupPath + @"\pic_temp\" + txt_qrcode.Text + "-1.JPG";
            if (!File.Exists(path))
            {
                fc.id_status = 2;
                fc.pic_no = 1;
                fc.simple_code = txt_qrcode.Text;
                fc.ShowDialog();               
            }

            else {

                fc.id_status = 3;
                fc.pic_no = 1;
                fc.simple_code = txt_qrcode.Text;
                fc.ShowDialog();
            }
                     
        }

        private void btn_imag2_Click(object sender, EventArgs e)
        {            
            F_Camera fc = new F_Camera();

            string path = Application.StartupPath + @"\pic_temp\" + txt_qrcode.Text + "-2.JPG";
            if (!File.Exists(path))
            {
                fc.id_status = 2;
                fc.pic_no = 2;
                fc.simple_code = txt_qrcode.Text;
                fc.ShowDialog();
              
            }

            else
            {
              
                fc.id_status = 3;
                fc.pic_no = 2;
                fc.simple_code = txt_qrcode.Text;
                fc.ShowDialog();
            }

        }

        private void btn_imag3_Click(object sender, EventArgs e)
        {
          
            F_Camera fc = new F_Camera();


            string path = Application.StartupPath + @"\pic_temp\" + txt_qrcode.Text + "-3.JPG";
            if (!File.Exists(path))
            {             
                fc.id_status = 2;
                fc.pic_no = 3;
                fc.simple_code = txt_qrcode.Text;
                fc.ShowDialog();
            }

            else
           {
                fc.id_status = 3;
                fc.pic_no = 3;
                fc.simple_code = txt_qrcode.Text;
                fc.ShowDialog();
            }
          
        }

        private void btn_imag4_Click(object sender, EventArgs e)
        {            
            F_Camera fc = new F_Camera();
       

            string path = Application.StartupPath + @"\pic_temp\" + txt_qrcode.Text + "-4.JPG";
            if (!File.Exists(path))
           {
                fc.id_status = 2;
                fc.pic_no = 4;
                fc.simple_code = txt_qrcode.Text;
                fc.ShowDialog();              
            }

            else
            {
                fc.id_status = 3;
                fc.pic_no = 4;
                fc.simple_code = txt_qrcode.Text;
                fc.ShowDialog();
            }
        }


        private void btn_cancel_Click(object sender, EventArgs e)
        {          
            Application.Exit();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //if (Viewdata_Per == 1)
            //{
            //    Scan_QRcode();
            //}
            //else { MessageBox.Show("สิทธิ์ในการดูข้อมูล/ค้นหา ถูกจำกัด กรุณาติดต่อผู้ดูแลระบบ! (งานบันทึก-ทางกายภาพ)", "รายงานความผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error); }


            Scan_QRcode();

        }

        private void Scan_QRcode()
        {         
            F_Camera fc = new F_Camera();

            if (chk_editCamera.Checked == true)
            {
                fc.id_camera = 1;
            }

            fc.id_status = 1;
            fc.simple_code = txt_qrcode.Text;
            fc.ShowDialog();
            chk_editCamera.Checked = false;

            if (fc.Sts_Img1 == 1)
            { chk_stsImg1.Checked = true; chk_stsImg1.ForeColor = Color.Green; }
            if (fc.Sts_Img2 == 1)
            { chk_stsImg2.Checked = true; chk_stsImg2.ForeColor = Color.Green; }
            if (fc.Sts_Img3 == 1)
            { chk_stsImg3.Checked = true; chk_stsImg3.ForeColor = Color.Green; }
            if (fc.Sts_Img4 == 1)
            { chk_stsImg4.Checked = true; chk_stsImg4.ForeColor = Color.Green; }

            //if (txt_qrcode.Text != "")
            //{
            //    btn_imag1.Enabled = true;
            //    btn_imag2.Enabled = true;
            //    btn_imag3.Enabled = true;
            //    btn_imag4.Enabled = true;

            //    int st_cha = 0;
            //    int ed_cha = 0;
            //    int count = 0;
            //    int index = 0;


            //    string str = txt_qrcode.Text;
            //    char[] b = new char[str.Length];

            //    b = str.ToCharArray();

            //    foreach (char c in b)
            //    {
            //        index += 1;

            //        if (c.ToString() == "-")
            //        {
            //            count += 1;
            //        }

            //        if (count == 2 && c.ToString() == "-")
            //        {
            //            st_cha = index;
            //        }

            //        if (count == 3 && c.ToString() == "-")
            //        {
            //            ed_cha = (index - st_cha) + 4;
            //        }

            //    }

            //    txt_qrcode.SelectionStart = st_cha;
            //    txt_qrcode.SelectionLength = ed_cha;
            //    txt_ticketcode.Text = txt_qrcode.SelectedText;

            //    //Load_Data();
            //    //Load_MainmenuDTG();
            //    //Check_image();

            //    timer1.Enabled = false;
            //}

        }

        //data source=192.168.111.225;initial catalog=SapthipNewDB;uid=truck_scale; pwd=pass@2020;
        private const string ConnectionString = @"data source=192.168.111.228;initial catalog=SapthipNewDB;uid=truck_scale; pwd=pass@2020";

        private void Load_MainmenuDTG()
        {
            //SqlConnection con = new SqlConnection(Program.pahtdb);
            //con.ConnectionString = Program.pahtdb;
            //SqlDataAdapter dtAdapter = new SqlDataAdapter();
            //con.Open();

            //// string sql = "Select * From [dbo].[V_InuptLab] ";
            //string sql1 = " SELECT  [LabName] AS 'ชื่อประเภท',[LabID] AS 'รหัส' FROM [SapthipNewDB].[dbo].[TB_LabName] Where [ProductID] = '" + ProductID + "' AND [LabActive]=1 AND [LabtypeID] = 2";
            //SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
            //DataSet ds1 = new DataSet();
            //da1.Fill(ds1, "g_l");
            //dtg_savetype.DataSource = ds1.Tables["g_l"];
            //con.Close();

            ////DataTable dtTable = ds1.Tables["g_l"];
            //this.dtg_savetype.AutoGenerateColumns = false;
            //this.dtg_savetype.AllowUserToAddRows = false;
            //this.dtg_savetype.DataSource = ds1.Tables["g_l"];


            //for (int i = 0; i < dtg_savetype.RowCount; i++)
            //{
            //    if (con.State == ConnectionState.Open)
            //    { con.Close(); }

            //    DataSet ds = new DataSet();

            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("SELECT [ValueVisualNo],[ValueName]  FROM [SapthipNewDB].[dbo].[TB_Valuevisual] WHERE [LabID]= " + dtg_savetype.Rows[i].Cells[2].Value.ToString().Trim() + " ORDER BY [ValueVisualNo]", con);
            //    //SqlCommand cmd = new SqlCommand("SELECT [ValueVisualNo] ,[ValueName],[LabID]  FROM [SapthipNewDB].[dbo].[TB_Valuevisual]  ORDER BY [ValueVisualNo]", con);

            //    //ds.Clear();
            //    SqlDataAdapter da = new SqlDataAdapter();
            //    da.SelectCommand = cmd;
            //    da.Fill(ds);
            //    //Load product tab weight scale Setup

            //                   // Bind ComboBox           
            //    this.ValueLab.DataPropertyName = "Name";
            //    this.ValueLab.DataSource = ds.Tables[0];
            //    this.ValueLab.ValueMember = "ValueVisualNo";
            //    this.ValueLab.DisplayMember = "ValueName";

            //    // Loop defult selected from Datatable
            //    foreach (DataGridViewRow row in this.dtg_savetype.Rows)
            //    {
            //        DataRow sel = dtTable.Select("LabID = '" + row.Cells["LabID"].Value.ToString() + "' ").FirstOrDefault();
            //        if (sel != null)
            //        {
            //            row.Cells["ValueName"].Value = sel["ValueVisualNo"].ToString();
            //        }
            //    }

            //    //// Summary Total Point
            //    //int iTotal = 0;
            //    //foreach (DataGridViewRow row in this.dataGridView1.Rows)
            //    //{
            //    //    iTotal = iTotal + Convert.ToInt32(row.Cells["POINT"].Value);
            //    //}
            //    //this.lblTotalPoint.Text = String.Format("Total Point : {0}", iTotal);

            //}



            dtg_savetype.Columns.Clear();

            //Fetch the data from Database.
            dtg_savetype.DataSource = this.GetData("SELECT  [LabID] AS 'รหัสประเภท',[LabName] AS 'ชื่อประเภท' FROM [SapthipNewDB].[dbo].[TB_LabName] Where [ProductID] = '" + ProductID + "' AND [LabActive]=1 AND [LabtypeID] = 2 ");


            dtg_savetype.AllowUserToAddRows = false;

            //Add a ComboBox Column to the DataGridView.
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.HeaderText = "ผลวิเคราะห์ที่ต้องบันทึก";
            comboBoxColumn.Width = 100;
            comboBoxColumn.Name = "comboBoxColumn";
            dtg_savetype.Columns.Add(comboBoxColumn);

            //Loop through the DataGridView Rows.
            foreach (DataGridViewRow row in dtg_savetype.Rows)
            {
                //Reference the ComboBoxCell.
                DataGridViewComboBoxCell comboBoxCell = (row.Cells[2] as DataGridViewComboBoxCell);

                //Insert the Default Item to ComboBoxCell.
                //comboBoxCell.Items.Add("--Select--");

                ////Set the Default Value as the Selected Value.
                //comboBoxCell.Value = "--Select--";

                DataTable dt = null;
                //Fetch the Countries from Database.
                // DataTable dt = this.GetData("SELECT [VisualType] ,[Value]  FROM [SapthipNewDB].[dbo].[TB_VALUEVISUAL]");
                //if (statat_edit == 0)
                //{
                dt = this.GetData("SELECT [ValueVisualNo] ,[ValueName]  FROM [SapthipNewDB].[dbo].[TB_Valuevisual] WHERE [LabID]= " + row.Cells[0].Value.ToString() + " AND [VisualActive]=1 ORDER BY [ValueVisualNo]");
                //}

                //else { dt = this.GetData("SELECT [VisualType] ,[Value1]  FROM [SapthipNewDB].[dbo].[TB_VISUAL1] WHERE [VisualType]= '" + row.Cells[0].Value.ToString() + "'"); }

                //Loop through the DataTable Rows.
                foreach (DataRow drow in dt.Rows)
                {
                    //Fetch the CustomerId (Primary Key) value.
                    string ValueVisualNo = drow[0].ToString();

                    //Add the Country value to the ComboBoxCell.
                    comboBoxCell.Items.Add(drow[1]);    ///Display text

                    //Except for CustomerId #3.
                    if (ValueVisualNo != "")
                    {
                        //Compare the value of CustomerId.
                        if (row.Cells[0].Value.ToString() == ValueVisualNo)
                        {
                            //Once CustomerId is matched, select the Country in ComboBoxCell.
                            comboBoxCell.Value = drow[1];
                            //comboBoxCell.ValueMember = drow[0].ToString(); 

                        }
                    }
                }

                if (comboBoxCell.Items.Count <= 0)
                {
                    dtg_savetype.Rows[comboBoxCell.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                    //dtg_savetype.Rows[comboBoxCell.RowIndex].ReadOnly = true;
                }
            }

            //if (statat_edit == 0)
            //{
            dtg_savetype.Columns["รหัสประเภท"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtg_savetype.Columns["ชื่อประเภท"].SortMode = DataGridViewColumnSortMode.NotSortable;
            //}

            //else
            //{
            //    dtg_savetype.Columns["VisualType"].SortMode = DataGridViewColumnSortMode.NotSortable;
            //    dtg_savetype.Columns["Value1"].SortMode = DataGridViewColumnSortMode.NotSortable;
            //}

            dtg_savetype.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dtg_savetype.Columns[0].Width = 0;
            dtg_savetype.Columns[1].Width = 250;

        }

        private DataTable GetData(string sql)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }



        private void dtg_savetype_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dtg_savetype.Rows[e.RowIndex].Cells[0].Value.ToString());





        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            SqlConnection con1 = new SqlConnection(Program.pahtdb);
            con1.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter1 = new SqlDataAdapter();
            //con.Open();

            if (txt_qrcode.Text != "")
            {
                if (Adddata_Per == 1)
                {
                    DialogResult dr = MessageBox.Show("คุณต้องการบันทึกข้อมูลนี้ใช่หรือไม่", "ยืนยันข้อมูล", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Information);

                    if (dr == DialogResult.Yes)
                    {
                        //save data to file temp
                        Save_fileTemp();

                        try
                        {
                            Move_File1();
                        }

                        catch
                        {
                            MessageBox.Show("การย้ายรูปล้มเลว กรุณาบันทึกอีกครั้ง!!", "รายงานผิดพลาด!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        finally
                        {
                            for (int i = 0; i < dtg_savetype.RowCount; i++)
                            {
                                con.Open();

                                if (con1.State == ConnectionState.Open)
                                {
                                    con1.Close();
                                }

                                con1.Open();
                                string sql1 = "Select [ValueVisualNo] From [dbo].[TB_Valuevisual] Where [LabID]='" + dtg_savetype.Rows[i].Cells[0].Value.ToString().Trim() + "' AND [ValueName]='" + dtg_savetype.Rows[i].Cells[2].Value.ToString().Trim() + "'";
                                SqlCommand CM1 = new SqlCommand(sql1, con1);
                                SqlDataReader DR1 = CM1.ExecuteReader();

                                Lab_id = Convert.ToInt16(dtg_savetype.Rows[i].Cells[0].Value.ToString().Trim());

                                DR1.Read();
                                {
                                    ValueVisualNo = Convert.ToInt16(DR1["ValueVisualNo"].ToString().Trim());

                                    String Sample = "ประเภท: " + dtg_savetype.Rows[i].Cells[1].Value.ToString().Trim() + " ผล: " + dtg_savetype.Rows[i].Cells[2].Value.ToString().Trim();

                                    if (Messagemail.Contains(Sample) == false)
                                    {
                                        Messagemail += Sample + Environment.NewLine;
                                    }

                                    List_EmailAlert();

                                    if (ID_AL != "")
                                    {
                                        Load_ConfigAlert();
                                    }

                                    if (ValueVisualNo != 0)
                                    {
                                        Load_CheckWaring();   ///test  27.07
                                    }


                                    if (tokenline != "" && ID_UserApp > 0) ///test  27.07  && ID_UserApp >0
                                    {
                                       
                                            string MsgLine = "แจ้งเตือนสินค้าไม่ผ่านเกณฑ์" + Environment.NewLine + "วันที่:" + DateTime.Now.ToShortDateString() + " เวลา: " + DateTime.Now.ToLongTimeString() + Environment.NewLine + "ประเภท: " + txt_product.Text.Trim() + " เลขที่ชั่ง: " + txt_ticketcode.Text.Trim() + " เลขที่ตัวอย่าง: " + txt_qrcode.Text.Trim() + Environment.NewLine + " คิวที่: " + txt_queNo.Text.Trim() + " ชนิดรถ: " + txt_trucktype.Text.Trim() + " ทะเบียน: " + txt_truckno.Text.Trim();
                                            lineNotify(MsgLine);
                               
                                        if (ShoDetail_line == 1)
                                        {
                                            if (i >= 0)
                                            {
                                                String s = Sample;
                                                s = s.Replace("%", " เปอร์เซ็นต์");

                                                string MsgLine2 = "";
                                                if (i < dtg_savetype.RowCount)
                                                {
                                                    //ผลการวิเคราะห์:ประเภท: ป่น ผล: 5%
                                                    MsgLine2 = "การวิเคราะห์-" + s;
                                                    lineNotify(MsgLine2);
                                                }

                                                if (i == dtg_savetype.RowCount - 1)
                                                {
                                                    MsgLine2 = " -:- ระบบแจ้งเตือนผลไม่ผ่านเกณฑ์ (Truck Scale Systems V 5.0.5) -:-";

                                                    lineNotify(MsgLine2);
                                                }

                                            }
                                        }

                                    }

                                }
                                DR1.Close();


                                if (dtg_savetype.Rows[i].DefaultCellStyle.BackColor != Color.Yellow)
                                {
                                    string sql = "Insert Into [TB_VisualData] ([TicketCodeIn],[SimpleCode],[LabID],[ValueID],[ValueName],[Remark]) Values('" + txt_ticketcode.Text.Trim() + "', '" + txt_qrcode.Text.Trim() + "', " + dtg_savetype.Rows[i].Cells[0].Value.ToString().Trim() + "," + ValueVisualNo + ",'" + dtg_savetype.Rows[i].Cells[2].Value.ToString().Trim() + "','" + txt_remark.Text + "')";
                                    SqlCommand CM2 = new SqlCommand(sql, con);
                                    SqlDataReader DR2 = CM2.ExecuteReader();

                                    con.Close();
                                    Table_Name = "TB_VisualData";
                                    Log_oldValue = "-";
                                    Log_newValue = "New Record: TicketNo" + txt_ticketcode.Text + " Simple: " + txt_qrcode.Text + " Value: " + dtg_savetype.Rows[i].Cells[0].Value.ToString().Trim();
                                    Save_Log();
                                }

                            }

                            //update process id

                        
                            Load_CheckProcess();

                            if (name_process == "WH")
                            {
                                id_process++;

                                con.Open();
                                string sql1 = "Update [TB_WeightData] Set  Process_id=" + id_process + ",WarehouseID='" + cb_location.SelectedValue.ToString() + "' Where [TicketCodeIn] = '" + txt_ticketcode.Text.Trim() + "'";
                                SqlCommand CM1 = new SqlCommand(sql1, con);
                                SqlDataReader DR1 = CM1.ExecuteReader();
                                con.Close();
                            }

                            try
                            {
                                     //check count send mail                 
                                Send_Alert();
                                Save_App();
                            }
                            catch { }

                            Clear_fileTemp();
                            Clear_Object();
                            Count_Alert = 0;
                            string1 = "";

                            MessageBox.Show("บันทึกสำเร็จ!!", "รายงานการบันทึก", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_qrcode.Focus();
                            chk_stsImg1.Checked = false; chk_stsImg1.ForeColor = Color.Black;
                            chk_stsImg2.Checked = false; chk_stsImg2.ForeColor = Color.Black;
                            chk_stsImg3.Checked = false; chk_stsImg3.ForeColor = Color.Black;
                            chk_stsImg4.Checked = false; chk_stsImg4.ForeColor = Color.Black;


                        }

                    }
                }
                else { MessageBox.Show("สิทธ์การแก้ไขไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานบันทึก-ทางกายภาพ)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
            else { MessageBox.Show("ไม่มีข้อมุลที่ต้องการบันทึก", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }


            txt_qrcode.Focus();
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-us"));
        }

        private void Save_App()
        {
            if (ID_UserApp > 0)
            {
                SqlConnection con = new SqlConnection(Program.pahtdb);
                con.ConnectionString = Program.pahtdb;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

                con.Open();
                string sql1 = "Update [TB_WeightData] Set  [StatusID]=2 Where [TicketCodeIn] = '" + txt_ticketcode.Text.Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                con.Close();

                string date = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US")) + ' ' + DateTime.Now.ToString("HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));

                con.Open();
                string sql = "Insert Into [TB_Approved] ([TicketCodeIn],[SimpleCode],[CreateDate],[ID_UserApp],[StatusID]) Values('" + txt_ticketcode.Text.Trim() + "','" + txt_qrcode.Text.Trim() + "', '" + date + "', " + ID_UserApp + ",2)";
                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();
            }

        }
                                    

        String string1 ="";
        private void Load_CheckWaring()
        {
            ///Concept flow 
            ///1. load value from setup alert report on true
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            con.Open();
            string sql1 = "Select Count([ValueVisualNo]) AS 'Check_ALT' From [dbo].[V_AlertSMG_Visual] Where [ProductID]='" + ProductID + "' AND [ValueVisualNo]='" + ValueVisualNo + "' AND [ID_Frm_TypeLab]=2 AND [ID_ALStatus]=1";
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
                    string sql2 = "Select [ID_User] From [dbo].[V_AlertSMG_Visual] Where [ProductID]='" + ProductID + "' AND [ValueVisualNo]='" + ValueVisualNo + "' AND [ID_Frm_TypeLab]=2 AND [App_Sts]=1 AND [Level_App]=1";
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


        private void List_EmailAlert()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            string1 = "";
            con.Open();
            string sql1 = "Select  DISTINCT([ID_ALRP]),[Email],[ID_AL] From [dbo].[V_AlertSMG_Visual] Where [ProductID]='" + ProductID + "' AND [LabID]=" + Lab_id + " AND [ID_Frm_TypeLab]=2 AND [ValueVisualNo]='" + ValueVisualNo + "' AND [Status_RP] = 1 AND [Alert_Sts] = 1 AND [ID_ALStatus] =1";   

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

        private void Load_ConfigAlert()
        {  
            SqlConnection con1 = new SqlConnection(Program.pahtdb);
            con1.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con1.Open();

            string sql1 = "SELECT * FROM [SapthipNewDB].[dbo].[V_Alert_Setting] Where [ID_AL]=" + ID_AL + " AND [ID_ALdStatus] = 1";
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
                        
                        mailMessage.Subject = "การวิเคราะห์ทางกายภายไม่ผ่านเกณฑ์ตัวอย่างที่ : " + txt_qrcode.Text;
                        mailMessage.Body = "ชื่อสินค้า: " + txt_product.Text.Trim() + " เลขที่บัตรชั่ง: " + txt_ticketcode.Text.Trim() + " เลขที่ตัวอย่าง: " + txt_qrcode.Text.Trim() +
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

        private void Load_CheckProcess()
        {

            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql1 = "Select [proc_type] From [SapthipNewDB].[dbo].[TB_Process] Where  [proc_no]=" + id_process + " AND [item_no] = '" + ProductID + "'";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                name_process = DR1["proc_type"].ToString().Trim();               
            }
            DR1.Close();
            con.Close();
        }


        private void Save_fileTemp()  //รอทำต่อ save ข้้อมูล สำรองที่บันทึก
        {

            //string path = Application.StartupPath + "\\save_temp.dll";
            //string[] lines = { txt_qrcode.Text.Trim(), };
            //File.WriteAllLines(path, lines);

        }

        private void Clear_fileTemp()  //รอทำต่อ ลบ ข้้อมูล สำรองที่บันทึก
        {


        }



        private void Clear_Object()
        {
            txt_product.Clear();
            txt_qrcode.Clear();
            txt_remark.Clear();
            txt_ticketcode.Clear();
            txt_truckno.Clear();
            txt_trucktype.Clear();
            txt_moistExam1.Clear();
            txt_moistExam2.Clear();
            txt_queNo.Text = "-";        
            dtg_savetype.DataSource = null;


        }

        //COMBO COLUMN
        private void Move_File1()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            string sql = "Insert Into [TB_Image] ([TicketCode],[SimpleCode]) Values('" + txt_ticketcode.Text + "','" + txt_qrcode.Text + "')";
            SqlCommand CM = new SqlCommand(sql, con);
            SqlDataReader DR = CM.ExecuteReader();
            con.Close();

            Table_Name = "TB_Image";
            Log_oldValue = "-";
            Log_newValue = "New Record: TicketNo" + txt_ticketcode.Text + " Simple: " + txt_qrcode.Text;
            Save_Log();


            string root = @"" + Program.Dis_Imagefile + DateTime.Now.Day + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year;
            // If directory does not exist, don't even try   
            if (Directory.Exists(root))
            {
                //Directory.Delete(root);
            }

            else
            {   
               // string folder_Name= @"" + Program.Dis_Imagefile + DateTime.Now.ToShortDateString();
                DirectoryInfo di = Directory.CreateDirectory(root);
            }

            F_Camera FC = new F_Camera();


            if (Program.img1_paht !="")
            {               
                string sour_path = Program.img1_paht + ".jpg";
                string disc_path = @""+root +"\\" + txt_qrcode.Text + "-1.jpg";


                if (!File.Exists(sour_path))
                {
                    using (FileStream fs = File.Create(sour_path)) { }
                }
                // Ensure that the target does not exist.  
                if (File.Exists(disc_path))
                    File.Delete(disc_path);

                File.Move(sour_path, disc_path);
                                          
                con.Open();
                string sql1 = "Update [TB_Image] Set [Path_Image1] ='" + disc_path + "' WHERE [TicketCode]= '" + txt_ticketcode.Text + "' AND [SimpleCode] = '" + txt_qrcode.Text + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                con.Close();

                Table_Name = "TB_Image";
                Log_oldValue = "-";
                Log_newValue = "Update Record: Path_Image1_TicketNo" + txt_ticketcode.Text + " Simple: " + txt_qrcode.Text;
                Save_Log();

            }

            if (Program.img2_paht != "")
            {
                string sour_path = Program.img2_paht + ".jpg";
                string disc_path = @"" + root + "\\" + txt_qrcode.Text + "-2.jpg";


                if (!File.Exists(sour_path))
                {
                    using (FileStream fs = File.Create(sour_path)) { }
                }
                // Ensure that the target does not exist.  
                if (File.Exists(disc_path))
                    File.Delete(disc_path);

                File.Move(sour_path, disc_path);


                con.Open();
                string sql1 = "Update [TB_Image] Set [Path_Image2] ='" + disc_path + "' WHERE [TicketCode]='" + txt_ticketcode.Text + "' AND [SimpleCode] = '" + txt_qrcode.Text + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                con.Close();

                Table_Name = "TB_Image";
                Log_oldValue = "-";
                Log_newValue = "Update Record: Path_Image2_TicketNo" + txt_ticketcode.Text + " Simple: " + txt_qrcode.Text;
                Save_Log();
            }

            if (Program.img3_paht != "")
            {
                string sour_path = Program.img3_paht + ".jpg";
                string disc_path = @"" + root + "\\" + txt_qrcode.Text + "-3.jpg";


                if (!File.Exists(sour_path))
                {
                    using (FileStream fs = File.Create(sour_path)) { }
                }
                // Ensure that the target does not exist.  
                if (File.Exists(disc_path))
                    File.Delete(disc_path);

                File.Move(sour_path, disc_path);

                con.Open();
                string sql1 = "Update [TB_Image] Set [Path_Image3] ='" + disc_path + "' WHERE [TicketCode]= '" + txt_ticketcode.Text + "' AND [SimpleCode] = '" + txt_qrcode.Text + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                con.Close();

                Table_Name = "TB_Image";
                Log_oldValue = "-";
                Log_newValue = "Update Record: Path_Image3_TicketNo" + txt_ticketcode.Text + " Simple: " + txt_qrcode.Text;
                Save_Log();

            }

            if (Program.img4_paht != "")
            {
                string sour_path = Program.img4_paht + ".jpg";
                string disc_path = @"" + root + "\\" + txt_qrcode.Text + "-4.jpg";


                if (!File.Exists(sour_path))
                {
                    using (FileStream fs = File.Create(sour_path)) { }
                }
                // Ensure that the target does not exist.  
                if (File.Exists(disc_path))
                    File.Delete(disc_path);

                File.Move(sour_path, disc_path);

                con.Open();
                string sql1 = "Update [TB_Image] Set [Path_Image4] ='" + disc_path + "' WHERE [TicketCode]= '" + txt_ticketcode.Text + "' AND [SimpleCode] = '" + txt_qrcode.Text + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                con.Close();

                Table_Name = "TB_Image";
                Log_oldValue = "-";
                Log_newValue = "Update Record: Path_Image4_TicketNo" + txt_ticketcode.Text + " Simple: " + txt_qrcode.Text;
                Save_Log();
            }


        }
                 


        private void F_Visual_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void txt_qrcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    if (txt_qrcode.Text != "")
                    {
                        int st_cha = 0;
                        int ed_cha = 0;
                        int count = 0;
                        int index = 0;


                        string str = txt_qrcode.Text;
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

                        txt_qrcode.SelectionStart = st_cha;
                        txt_qrcode.SelectionLength = ed_cha;
                        txt_ticketcode.Text = txt_qrcode.SelectedText;

                        if (chk_audit.Checked == false)
                        {
                            Load_Data();
                            Load_Defualt_Setting();
                            Load_MainmenuDTG();
                            Load_Location();
                            Load_Mositure();
                        }

                        else
                        {

                            F_RecheckData frdt = new F_RecheckData();
                            frdt.Simple_code = txt_qrcode.Text.Trim();
                            frdt.Ticket_Code = txt_ticketcode.Text.Trim();
                            frdt.ShowDialog();
                        }
                    }
                }
                catch { txt_qrcode.Clear(); txt_qrcode.Focus(); }
            }
        }

        private void chk_editCamera_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_editCamera.Checked == true)
            {
                F_PWD Fwd = new F_PWD();
                Fwd.ShowDialog();

                if (Fwd.Value_Confirm == 1)
                {
                    chk_editCamera.Checked = true;
                    Scan_QRcode();
                }

                else { chk_editCamera.Checked = false; }

            }

        }

        private void txt_qrcode_MouseClick(object sender, MouseEventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-us"));
        }

        int C_Check = 30;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                if (C_Check == 0)
                {
                    Check_StatusWiFi();
                    C_Check = 30;
                }

                else { C_Check--; }

            }
        }


        private void Check_StatusWiFi()
        {
            try
            {
                System.Diagnostics.Process P = new System.Diagnostics.Process();
                P.StartInfo.FileName = "netsh.exe";
                P.StartInfo.Arguments = "wlan show interfaces";
                P.StartInfo.UseShellExecute = false;
                P.StartInfo.RedirectStandardOutput = true;
                P.StartInfo.CreateNoWindow = true;
                P.Start();

                string S = P.StandardOutput.ReadToEnd();
                string SID = S.Substring(S.IndexOf("SSID"));
                SID = SID.Substring(SID.IndexOf(":"));
                SID = SID.Substring(2, SID.IndexOf("\n")).Trim();

                string SIGN = S.Substring(S.IndexOf("Signal"));
                SIGN = SIGN.Substring(SIGN.IndexOf(":"));
                SIGN = SIGN.Substring(2, SIGN.IndexOf("\n")).Trim();

                lbl_stswifiname.ForeColor = Color.Blue;
                lbl_stswifiname.Text = SID;
                lbl_stsWifisignal.Text = SIGN;
                P.WaitForExit();


                int value = Convert.ToInt16(SIGN.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, ""));

                if (value <= 15)
                {
                    txt_wifi_lv0.BackColor = Color.Red;
                    txt_wifi_lv1.BackColor = Color.Gainsboro;
                    txt_wifi_lv2.BackColor = Color.Gainsboro;
                    txt_wifi_lv3.BackColor = Color.Gainsboro;
                    txt_wifi_lv4.BackColor = Color.Gainsboro;

                    lbl_stsWifisignal.ForeColor = Color.DarkRed;
                    txt_msgStatusWifi.ForeColor = Color.DarkRed;
                    txt_msgStatusWifi.Text = "Bad";
                    btn_save.Enabled = false;

                }

                else if (value <= 30)
                {
                    txt_wifi_lv0.BackColor = Color.Red;
                    txt_wifi_lv1.BackColor = Color.Orange;
                    txt_wifi_lv2.BackColor = Color.Gainsboro;
                    txt_wifi_lv3.BackColor = Color.Gainsboro;
                    txt_wifi_lv4.BackColor = Color.Gainsboro;

                    lbl_stsWifisignal.ForeColor = Color.DarkOrange;
                    txt_msgStatusWifi.ForeColor = Color.DarkOrange;
                    txt_msgStatusWifi.Text = "Poor";
                    btn_save.Enabled = true;
                }

                else if (value <= 50)
                {
                    txt_wifi_lv0.BackColor = Color.Red;
                    txt_wifi_lv1.BackColor = Color.Orange;
                    txt_wifi_lv2.BackColor = Color.Yellow;
                    txt_wifi_lv3.BackColor = Color.Gainsboro;
                    txt_wifi_lv4.BackColor = Color.Gainsboro;

                    lbl_stsWifisignal.ForeColor = Color.YellowGreen;
                    txt_msgStatusWifi.ForeColor = Color.YellowGreen;
                    txt_msgStatusWifi.Text = "Good";
                    btn_save.Enabled = true;
                }

                else if (value <= 75)
                {
                    txt_wifi_lv0.BackColor = Color.Red;
                    txt_wifi_lv1.BackColor = Color.Orange;
                    txt_wifi_lv2.BackColor = Color.Yellow;
                    txt_wifi_lv3.BackColor = Color.LightGreen;
                    txt_wifi_lv4.BackColor = Color.Gainsboro;

                    lbl_stsWifisignal.ForeColor = Color.Green;
                    txt_msgStatusWifi.ForeColor = Color.Green;
                    txt_msgStatusWifi.Text = "Very Good";
                    btn_save.Enabled = true;
                }


                else
                {
                    txt_wifi_lv0.BackColor = Color.Red;
                    txt_wifi_lv1.BackColor = Color.Orange;
                    txt_wifi_lv2.BackColor = Color.Yellow;
                    txt_wifi_lv3.BackColor = Color.LightGreen;
                    txt_wifi_lv4.BackColor = Color.Green;

                    lbl_stsWifisignal.ForeColor = Color.Green;
                    txt_msgStatusWifi.ForeColor = Color.Green;
                    txt_msgStatusWifi.Text = "Excellent";
                    btn_save.Enabled = true;
                }
            }


            catch
            {
                lbl_stswifiname.Text = "Not available";
                lbl_stswifiname.ForeColor = Color.Red; btn_save.Enabled = false;
                lbl_stsWifisignal.Text = "-";
                txt_msgStatusWifi.Text = "-";
            }

        }



    }
}
