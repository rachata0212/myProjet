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
using System.Net;
using System.IO;
using System.Globalization;
using System.Diagnostics;


namespace Truck_Analytics
{
    public partial class F_ConfirmLab : Form
    {
        public F_ConfirmLab()
        {
            InitializeComponent();
        }
                          

        string Ticket_code = "";
        string Product_id = "";
        int Truck_type = 0;      
        double net_weight = 0.00; //นน.สุทธิ
        int Process_id = 0;
        int LabCheck_confirm = 0;
        int VisualCheck_confirm = 0;
        int id_confirmLevel = 0;

        //--- Lag
        string Msg = "";
        string Log_NewValue = "";
        string Log_OldValue = "";

        
        int LabSourchStarch = 0;   //check แหล่งที่ดึงข้อมูลผลแลป แบบ visual 
        string VenCus_No = "";

        int Adddata_Per = 0;
        int Viewdata_Per = 0;
        int Editdata_Per = 0;
        int Status_Use = 0;
        int Printdata_Per = 0;
        int Status_Edit = 0;

        int count_bf = 0;
        int count_af = 0;

        //------------ Line Alert --------------------

        int QueaNo = 0;
        string PlateNo = "";
        string Vendor_Name="";
        string OwnerName = "";
        string Lab1_Name = "";
        string Process_Name = "";
        string ProductName = "";
        string Lab1_1 = "";
        string Lab1_2 = "";
        string Lab1_3 = "";
        string Lab1_4 = "";
        string Lab1_5 = "";
        string Lab1_6 = "";

        string Lab2_Name = "";
        string Lab2_1 = "";
        string Lab2_2 = "";
        string Lab2_3 = "";
        string Lab2_4 = "";
        string Lab2_5 = "";
        string Lab2_6 = "";

        string Lab3_Name = "";
        string Lab3_1 = "";
        string Lab3_2 = "";
        string Lab3_3 = "";
        string Lab3_4 = "";
        string Lab3_5 = "";
        string Lab3_6 = "";

        string Lab4_Name = "";
        string Lab4_1 = "";
        string Lab4_2 = "";
        string Lab4_3 = "";
        string Lab4_4 = "";
        string Lab4_5 = "";
        string Lab4_6 = "";

        string Lab5_Name = "";
        string Lab5_1 = "";
        string Lab5_2 = "";
        string Lab5_3 = "";
        string Lab5_4 = "";
        string Lab5_5 = "";
        string Lab5_6 = "";

        string Lab6_Name = "";
        string Lab6_1 = "";
        string Lab6_2 = "";
        string Lab6_3 = "";
        string Lab6_4 = "";
        string Lab6_5 = "";
        string Lab6_6 = "";

        decimal Sum_visual = 0;

        int STS_Mode = 0;
        //-------------------------------------

        string token = "";

        private void Adjust_panel()
        {
           

            int x = this.Height;
            int y = this.Width;

            lbl_headinformation.Location =new Point ((y/2)-(lbl_headinformation.Width/2),10);

            int sc_x = x / 8;
            int sc_y = y / 7;

            pn_dataconfirm.Height = sc_x * 3;

            pn_lab.Width = sc_y *2;
        }


        private void F_ConfirmLab_Load(object sender, EventArgs e)
        {
            Load_Permission();
            Load_Datatruck();           
            tool_login.Text = "Login Name: " + Program.user_name;
            tool_DBName.Text = "Database Name: " + Program.DB_Name;
            timer1.Enabled = true;
            Adjust_panel();
                      

            if (Program.DB_Name != "SapthipNewDB")
            {
                panel3.BackColor = Color.Crimson;               
            }
        }

        private void Load_InformationLine()
        {
            try
            {
                SqlConnection con2 = new SqlConnection(Program.pathdb_Weight);
                con2.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

                string sql = "Select [QueueNo],[Plate1],[NameVen],[OwnerName],[proc_type] From [V_WeightData] Where [TicketCodeIn]= '" + Ticket_code + "'";
                con2.Open();
                SqlCommand CM2 = new SqlCommand(sql, con2);
                SqlDataReader DR2 = CM2.ExecuteReader();

                DR2.Read();
                {
                    QueaNo = Convert.ToInt16(DR2["QueueNo"].ToString().Trim());
                    PlateNo = DR2["Plate1"].ToString().Trim();
                    Vendor_Name = DR2["NameVen"].ToString().Trim();
                    OwnerName = DR2["OwnerName"].ToString().Trim();
                    Process_Name = DR2["proc_type"].ToString().Trim();
                }
                DR2.Close();
                con2.Close();
            }
            catch { }

        }

        private void Load_Labsetting()
        {   
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql6 = "SELECT  [LabSourchStarch] FROM  [dbo].[TB_LabSetting] WHERE [LabProductID] = '" + Product_id + "'";
                SqlCommand CM6 = new SqlCommand(sql6, con);
                SqlDataReader DR6 = CM6.ExecuteReader();

                DR6.Read();
                {
                    if (DR6["LabSourchStarch"].ToString().Trim() == "True") { LabSourchStarch = 1; }                   
                }
                DR6.Close();
                con.Close();              

        }

        private void Load_Permission()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql6 = "SELECT  Adddata_Per, Viewdata_Per,Editdata_Per,Status_Use,Printdata_Per FROM  [dbo].[V_Permission] WHERE [UserID] = '" + Program.user_id + "' AND [ID_Menu]= 23 ";
                SqlCommand CM6 = new SqlCommand(sql6, con);
                SqlDataReader DR6 = CM6.ExecuteReader();

                DR6.Read();
                {
                    if (DR6["Adddata_Per"].ToString().Trim() == "True") { Adddata_Per = 1; }
                    if (DR6["Viewdata_Per"].ToString().Trim() == "True") { Viewdata_Per = 1; }
                    if (DR6["Editdata_Per"].ToString().Trim() == "True") { Editdata_Per = 1; }
                    if (DR6["Status_Use"].ToString().Trim() == "True") { Status_Use = 1; }
                    if (DR6["Printdata_Per"].ToString().Trim() == "True") { Printdata_Per = 1; }
                }
                DR6.Close();
                con.Close();

                if (Status_Use == 0)
                {
                    MessageBox.Show("สิทธ์การใช้งานไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานยืนยันผลวิเคราะห์)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgv_datatruck.Enabled = false;
                }

                if (Viewdata_Per == 1)
                {
                    pn_lab.Enabled = true;                  
                    pn_dataconfirm.Enabled = true;
                }

                if (Printdata_Per == 1)
                {
                    btn_report.Enabled = true;
                }
                
            }
            catch
            {
                MessageBox.Show("ไม่มีการเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานยืนยันผลวิเคราะห์)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Load_Datatruck()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            // string sql = "Select * From [dbo].[V_InuptLab] ";
            string sql1 = " SELECT [proc_name] AS 'สถานะ',[TicketCodeIn] AS 'รหัสชั่ง',[QueueNo] AS 'คิว',CONVERT(varchar,[WeightDate],103) AS 'วันที่ชั้ง',[TruckTypeName] AS 'ประเภท',[ProductName] AS 'สินค้า',[InboundWeight] AS 'เข้า',[OutboundWeight] AS 'ออก',[GrossWeight] AS 'สุทธิ',[ProductID],[TruckTypeID],[proc_no],[StatusID],[StatusName],[proc_type],[Vendor_No] FROM [dbo].[V_InuptLab] Where [proc_type]='LC' OR [proc_type]='L+WH' Order by [WeightDate]";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "g_l");
            dgv_datatruck.DataSource = ds1.Tables["g_l"];
            con.Close();

            dgv_datatruck.Columns[0].Width = 60;
            dgv_datatruck.Columns[1].Width = 160;
            dgv_datatruck.Columns[2].Width = 100;
            dgv_datatruck.Columns[3].Width = 50;
            dgv_datatruck.Columns[4].Width = 140;
            dgv_datatruck.Columns[5].Width = 70;
            dgv_datatruck.Columns[6].Width = 100;
            dgv_datatruck.Columns[7].Width = 60;
            dgv_datatruck.Columns[8].Width = 60;
            dgv_datatruck.Columns[9].Width = 60;
            dgv_datatruck.Columns[10].Visible = false;
            dgv_datatruck.Columns[11].Visible = false;
            dgv_datatruck.Columns[12].Visible = false;
            dgv_datatruck.Columns[13].Visible = false;
            dgv_datatruck.Columns[14].Visible = false;
            dgv_datatruck.Columns[15].Visible = false;
            dgv_datatruck.Columns[16].Visible = false;
        }

        private void Load_DataLab()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            DataSet ds1 = new DataSet();
         
            // string sql = "Select * From [dbo].[V_InuptLab] ";
            string sql1 = "SELECT [InActive] AS 'เลือก',[LabID] AS 'รหัส',[LabName] AS 'รายการ' ,[ValueLab] AS 'ผล',[SimpleCode] AS 'เลขที่ตัวอย่าง',[LabCode] AS 'วิเคราะห์ครั้งที่',[LOGID] FROM  [dbo].[V_DataLab_Confirm] WHERE [TicketCodeIn]='" + Ticket_code + "' AND [Dilldata]=0 ORDER BY [SimpleCode],[LabCode]  ASC";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);          
            da1.Fill(ds1, "g_lab");
            dgv_datalab.DataSource = ds1.Tables["g_lab"];

            dgv_datalab.Columns[0].Width = 30;
            dgv_datalab.Columns[1].Width = 20;
            //dgv_datalab.Columns[1].Visible = false;
            dgv_datalab.Columns[2].Width = 40;
            dgv_datalab.Columns[3].Width = 30;
            dgv_datalab.Columns[4].Visible = false;
            //dgv_datalab.Columns[5].Width = 130;
            dgv_datalab.Columns[6].Width = 0;
            con.Close();

            dgv_datalab.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_datalab.Columns[3].DefaultCellStyle.BackColor = Color.LightGreen;
            

            con.Open();         
            string sql2 = "SELECT DISTINCT [LabID] AS 'รหัส',[LabName]  AS 'ชื่อวิเคราะห์',[SimpleCode] AS 'เลขที่ตัวอย่าง','' AS 'สัดส่วน','' AS 'วิเคราะห์ครั้งที่ 1','' AS 'วิเคราะห์ครั้งที่ 2' FROM  [dbo].[V_DataLab_Confirm] WHERE [TicketCodeIn]='" + Ticket_code + "' AND [InActive]=1 AND [Dilldata] =0 ORDER BY [LabID] ASC";
            SqlDataAdapter da2 = new SqlDataAdapter(sql2, con);
            DataSet ds2 = new DataSet();        
            da2.Fill(ds2, "g_cal");
            dgv_cal.DataSource = ds2.Tables["g_cal"];
            con.Close();

            tool_countlab.Text = "";
            tool_countlab.Text = "จำนวน: " + dgv_datalab.RowCount.ToString() + " ข้อมูล ";

            Check_countLab();
        }

        private void Check_countLab()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            // check จำนวนประเภทที่ต้องวิเคราะห์    
            count_af = 0;
            count_bf = 0;

            string sql1 = "Select Count([LabActive]) AS CheckLab From [dbo].[TB_LabName] Where [ProductID]='" + Product_id + "' AND [LabActive]=1 AND LabOpserv =0 ";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                count_bf = Convert.ToInt16(DR1["CheckLab"].ToString().Trim());
            }
            DR1.Close();


            // check จำนวนประเภท ที่ได้วิเคราะห์ไปแล้ว
            string sql2 = "SELECT Count(DISTINCT [LabName]) AS C_count FROM  [dbo].[V_DataLab_Confirm] Where [TicketCodeIn]='" + Ticket_code + "' AND  [InActive] =1 AND [TypePno]=1";
            SqlCommand CM2 = new SqlCommand(sql2, con);
            SqlDataReader DR2 = CM2.ExecuteReader();

            DR2.Read();
            {
                count_af = Convert.ToInt16(DR2["C_count"].ToString().Trim());
            }
            DR2.Close();

            string sql3 = "SELECT Count(DISTINCT[LabName]) AS C_count FROM[dbo].[V_DataVisual_Confirm] Where[TicketCodeIn] = '" + Ticket_code + "' AND[LabOpserv] = 0 AND[VSActive] = 1";
            SqlCommand CM3 = new SqlCommand(sql3, con);
            SqlDataReader DR3 = CM3.ExecuteReader();

            DR3.Read();
            {
                count_af += Convert.ToInt16(DR3["C_count"].ToString().Trim());
            }
            DR3.Close();

            tool_dicountlab.Text = "";
            if (count_bf != count_af)
            {
                tool_dicountlab.Text = "การวิเคราะห์ค้างคงเหลือ: " + Convert.ToString(count_bf - count_af) + " ประเภท";
            }

            else { tool_dicountlab.Text = "การวิเคราะห์ครบทุกประเภท"; LabCheck_confirm = 1; }

            con.Close();

        }

        private void Load_DataVisual()
        {
            //
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

             //string sql = "Select * From [dbo].[V_InuptLab] ";
            string sql1 = "SELECT [VSActive] AS 'เลือก',[LabID] AS 'รหัส',[LabName] AS 'รายการ',[ValueName] AS 'ผล',[ValueCal] AS 'ค่า',[SimpleCode] AS 'ตัวอย่าง',[LabOpserv] AS 'OFI',[VisualShowRemark] AS 'หมายเหตุ',[VisualIndex] FROM  [dbo].[V_DataVisual_Confirm] WHERE [TicketCodeIn] = '" + Ticket_code + "'  AND [VSActive]=1 ORDER BY [SimpleCode]";

            //string sql1 = "SELECT '',[LabID] AS 'รหัส',[LabName] AS 'รายการ',[ValueName] AS 'ผล',[ValueCal] AS 'ค่า',[SimpleCode] AS 'ตัวอย่าง',[LabOpserv] AS 'OFI',[VisualShowRemark] AS 'หมายเหตุ',[VisualIndex] FROM  [dbo].[V_DataVisual_Confirm] WHERE [TicketCodeIn] = '" + Ticket_code + "' AND [VSActive]=1 ORDER BY [SimpleCode]";


            SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "g_visual");
            dgv_datavisual.DataSource = ds1.Tables["g_visual"];
            con.Close();

            tool_countvisual.Text = "";
            tool_countvisual.Text = "จำนวน: " + dgv_datavisual.RowCount.ToString() + " ข้อมูล ";
            Check_Value();
            Check_countVisual();
        }

        private void Check_Value()
        {
            try
            {
            //    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            //con.ConnectionString = Program.pahtdb;
            //SqlDataAdapter dtAdapter = new SqlDataAdapter();

            string Show_Remark = "";

                txt_remark1.Clear();

            for (int i = 0; i < dgv_datavisual.RowCount; i++)
            {

                //con.Open();
                //string sql1 = "SELECT [Value1],[VisualShowRemark] FROM  [dbo].[TB_VALUEVISUAL] Where Trim([ValueName])='" + dgv_datavisual.Rows[i].Cells[3].Value.ToString().Trim() + "' AND [VisualType]= '" + dgv_datavisual.Rows[i].Cells[1].Value.ToString().Trim() + "'";
                //SqlCommand CM1 = new SqlCommand(sql1, con);
                //SqlDataReader DR1 = CM1.ExecuteReader();

                //DR1.Read();
                //{
                //    dgv_datavisual.Rows[i].Cells[4].Value = DR1["Value1"].ToString().Trim();
                //    dgv_datavisual.Rows[i].Cells[7].Value = DR1["VisualShowRemark"].ToString().Trim();
                //}


                if (dgv_datavisual.Rows[i].Cells[7].Value.ToString().Trim() == "True" && dgv_datavisual.Rows[i].Cells[0].Value.ToString().Trim() == "True")
                {
                    if (Show_Remark == "")
                    {
                        Show_Remark = dgv_datavisual.Rows[i].Cells[2].Value.ToString().Trim() + ":" + dgv_datavisual.Rows[i].Cells[3].Value.ToString().Trim();
                    }
                    else { Show_Remark += "," + dgv_datavisual.Rows[i].Cells[2].Value.ToString().Trim() + ":" + dgv_datavisual.Rows[i].Cells[3].Value.ToString().Trim(); }
                
                }

                //DR1.Close();
                //con.Close();

            }


            //if (listBox1.Items.Cast<String>().Where(x => x.ToString() == textBox1.Text).Count() == 0)

            //{
            //    listBox1.Items.Add(textBox1.Text);
            //}

            //else

            //{

            //    MessageBox.Show("ซ้ำ");

            //}

                                                          
            dgv_datavisual.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_datavisual.Columns[4].DefaultCellStyle.BackColor = Color.LightGreen;


                var text_splite = Show_Remark.Split(',');
                var notext_duplicate =
                    new HashSet<string>(text_splite);
                var noduplicate =
                    string.Join(", ", notext_duplicate);

            txt_remark1.Text = noduplicate;


        }

            catch { }
        }

                                    
        private void Check_countVisual()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();


            // check จำนวนประเภทที่ต้องวิเคราะห์
            int count_bf = 0;
            int count_af = 0;

            string sql1 = "Select Count([LabActive]) AS CheckLab From [dbo].[TB_LabName] Where [ProductID]='" + Product_id + "' AND [LabActive]=1 AND [LabtypeID]=2";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                count_bf = Convert.ToInt16(DR1["CheckLab"].ToString().Trim());
            }
            DR1.Close();


            // check จำนวนประเภท ที่ได้วิเคราะห์ไปแล้ว
            string sql2 = "SELECT Count(DISTINCT [LabName]) AS C_count FROM  [dbo].[V_DataVisual_Confirm] Where [TicketCodeIn]='" + Ticket_code + "' AND  [VSActive] =1";
            SqlCommand CM2 = new SqlCommand(sql2, con);
            SqlDataReader DR2 = CM2.ExecuteReader();

            DR2.Read();
            {
                count_af = Convert.ToInt16(DR2["C_count"].ToString().Trim());
            }
            DR2.Close();


            tool_dicountvisual.Text = "";
            if (count_bf != count_af)
            {
                tool_dicountvisual.Text = "การวิเคราะห์ค้างคงเหลือ: " + Convert.ToString(count_bf - count_af) + " ประเภท";
            }

            else { tool_dicountvisual.Text = "การวิเคราะห์ครบทุกประเภท"; VisualCheck_confirm = 1; }

            con.Close();

        }

        string id_typelab = "";
        string id_simple = "";
        double sum_lab = 0;
        //private void Check_SumLab()
        //{
        //    if (id_simple != "")
        //    {
        //        SqlConnection con = new SqlConnection(Program.pahtdb);
        //        con.ConnectionString = Program.pahtdb;
        //        SqlDataAdapter dtAdapter = new SqlDataAdapter();

        //        try
        //        {
        //            con.Open();
        //            string sql2 = "Select Sum ([ValueLab]) as LabSum from [dbo].[TB_LabData] WHERE [LabCode]= '" + id_simple + "' AND [LabTypeID]='" + id_typelab + "' AND [InActive]=1";
        //            SqlCommand CM2 = new SqlCommand(sql2, con);
        //            SqlDataReader DR2 = CM2.ExecuteReader();

        //            DR2.Read();
        //            {
        //                sum_lab = Convert.ToDouble(DR2["LabSum"].ToString().Trim());
        //            }
        //            DR2.Close();
        //            con.Close();
        //        }
        //        catch { sum_lab = 0; }   // หาค่าแล้วเป็นค่า Null  ค่าว่าง
        //    }
        //}

        private void Load_Cal()
        {    

            for (int y = 0; y < dgv_datalab.RowCount; y++)
                {
                    //dgv_datalab.Rows[y].Cells[0].Value = "True";   // check เลือกค่าที่ต้องการ

                    for (int z = 0; z < dgv_cal.RowCount; z++)
                    {

                        id_simple = dgv_datalab.Rows[y].Cells[5].Value.ToString();
                        id_typelab = dgv_datalab.Rows[y].Cells[1].Value.ToString();
                        //Check_SumLab();

                    if (Truck_type == 2)//รถพ่วง
                    {
                        // MessageBox.Show(sum_lab.ToString()+ "Y=" +y.ToString()+ "Z="+z.ToString());

                        if (z % 2 == 0)
                        {
                            dgv_cal.Rows[z].Cells[3].Value = "หัว ->> 45%";
                        }
                        else { dgv_cal.Rows[z].Cells[3].Value = "พ่วง ->> 55%"; }


                        if (dgv_cal.Rows[z].Cells[2].Value.ToString().Trim() == dgv_datalab.Rows[y].Cells[4].Value.ToString()) // simple ต้องเหมือนกัน
                        {

                            if (dgv_cal.Rows[z].Cells[0].Value.ToString().Trim() == dgv_datalab.Rows[y].Cells[1].Value.ToString()) //ค่า แลปเหมือนกัน
                            {
                                if (dgv_datalab.Rows[y].Cells[0].Value.ToString() == "True")
                                {
                                    string str = dgv_datalab.Rows[y].Cells[5].Value.ToString();    
                                    double resualt =Convert.ToDouble(Math.Round(Convert.ToDecimal(dgv_datalab.Rows[y].Cells[3].Value.ToString()), 2, MidpointRounding.ToEven));

                                    if (str.Contains("-1-1")) //แม่ครั้งที่ 1
                                    {
                                        //dgv_cal.Rows[z].Cells[4].Value = dgv_datalab.Rows[y].Cells[3].Value.ToString();
                                        //Math.Round(simple1_sum, 2, MidpointRounding.AwayFromZero);

                                        if (dgv_cal.Rows[z].Cells[4].Value.ToString() != "" && dgv_datalab.Rows[y].Cells[0].Value.ToString() == "True")
                                        {
                                            dgv_cal.Rows[z].Cells[4].Value = Math.Round(Convert.ToDouble(dgv_datalab.Rows[y].Cells[3].Value.ToString()) + Convert.ToDouble(dgv_cal.Rows[z].Cells[4].Value.ToString()), 2, MidpointRounding.ToEven);
                                        }

                                        else
                                        {
                                            //dgv_cal.Rows[z].Cells[4].Value = Math.Round(Convert.ToDecimal(dgv_datalab.Rows[y].Cells[3].Value.ToString()), 2, MidpointRounding.ToEven);
                                            dgv_cal.Rows[z].Cells[4].Value = resualt.ToString("##.##");
                                        }

                                    }

                                    if (str.Contains("-1-2"))  //แม่ครั้งที่ 2
                                    {                                        

                                        if (dgv_cal.Rows[z].Cells[5].Value.ToString() != "" && dgv_datalab.Rows[y].Cells[0].Value.ToString() == "True")
                                        {
                                            dgv_cal.Rows[z].Cells[5].Value = Math.Round(Convert.ToDouble(dgv_datalab.Rows[y].Cells[3].Value.ToString()) + Convert.ToDouble(dgv_cal.Rows[z].Cells[5].Value.ToString()), 2, MidpointRounding.ToEven);
;                                        }

                                        else {

                                            //dgv_cal.Rows[z].Cells[5].Value = Math.Round(Convert.ToDecimal(dgv_datalab.Rows[y].Cells[3].Value.ToString()), 2, MidpointRounding.ToEven);

                                            dgv_cal.Rows[z].Cells[5].Value = resualt.ToString("##.##");
                                        }

                                    }


                                    if (str.Contains("-2-1"))   //ลูกครั้งที่ 1
                                    {
                                        //dgv_cal.Rows[z].Cells[4].Value = dgv_datalab.Rows[y].Cells[3].Value.ToString();

                                        if (dgv_cal.Rows[z].Cells[4].Value.ToString() != "" && dgv_datalab.Rows[y].Cells[0].Value.ToString() == "True")
                                        {
                                            dgv_cal.Rows[z].Cells[4].Value = Math.Round(Convert.ToDouble(dgv_datalab.Rows[y].Cells[3].Value.ToString()) + Convert.ToDouble(dgv_cal.Rows[z].Cells[4].Value.ToString()), 2, MidpointRounding.ToEven);
                                        }

                                        else {

                                            //dgv_cal.Rows[z].Cells[4].Value = Math.Round(Convert.ToDecimal(dgv_datalab.Rows[y].Cells[3].Value.ToString()), 2, MidpointRounding.ToEven);

                                            dgv_cal.Rows[z].Cells[4].Value = resualt.ToString("##.##");
                                        }

                                    }
                                    

                                    if (str.Contains("-2-2"))   //ลูกครั้งที่ 2
                                    {
                                        //dgv_cal.Rows[z].Cells[5].Value = dgv_datalab.Rows[y].Cells[3].Value.ToString();

                                        if (dgv_cal.Rows[z].Cells[5].Value.ToString() != "" && dgv_datalab.Rows[y].Cells[0].Value.ToString() == "True")
                                        {
                                            dgv_cal.Rows[z].Cells[5].Value = Math.Round(Convert.ToDouble(dgv_datalab.Rows[y].Cells[3].Value.ToString()) + Convert.ToDouble(dgv_cal.Rows[z].Cells[5].Value.ToString()), 2, MidpointRounding.ToEven);
                                        }

                                        else {

                                            //dgv_cal.Rows[z].Cells[5].Value = Math.Round(Convert.ToDecimal(dgv_datalab.Rows[y].Cells[3].Value.ToString()), 2, MidpointRounding.ToEven);

                                            dgv_cal.Rows[z].Cells[5].Value = resualt.ToString("##.##");
                                        }

                                    }

                                    //if (dgv_cal.Rows[z].Cells[4].Value.ToString() == "")
                                    //        {
                                    //            dgv_cal.Rows[z].Cells[4].Value = sum_lab.ToString();
                                    //        }

                                    //        else
                                    //        {
                                    //            dgv_cal.Rows[z].Cells[5].Value = sum_lab.ToString();
                                    //        }
                                    //    //} 
                                }
                            }
                        }

                    }

                    else  //รถเดี่ยว
                    {
                        if (dgv_cal.Rows[z].Cells[2].Value.ToString().Trim() == dgv_datalab.Rows[y].Cells[4].Value.ToString()) // simple ต้องเหมือนกัน
                        {
                            //MessageBox.Show(dgv_datalab.Rows[y].Cells[3].Value.ToString());

                            if (dgv_cal.Rows[z].Cells[0].Value.ToString().Trim() == dgv_datalab.Rows[y].Cells[1].Value.ToString()) //ค่า แลปเหมือนกัน
                            {
                                string str = dgv_datalab.Rows[y].Cells[5].Value.ToString();

                                if (dgv_datalab.Rows[y].Cells[0].Value.ToString() == "True")
                                {

                                    if (str.Contains("-1-1")) //แม่ครั้งที่ 1
                                    {
                                        if (dgv_cal.Rows[z].Cells[4].Value.ToString() != "")
                                        {
                                            dgv_cal.Rows[z].Cells[4].Value = Convert.ToString(Convert.ToDouble(dgv_datalab.Rows[y].Cells[3].Value.ToString()) + Convert.ToDouble(dgv_cal.Rows[z].Cells[4].Value.ToString()));
                                        }

                                        else { dgv_cal.Rows[z].Cells[4].Value = dgv_datalab.Rows[y].Cells[3].Value.ToString(); }

                                    }

                                    if (str.Contains("-1-2"))  //แม่ครั้งที่ 2
                                    {
                                        if (dgv_cal.Rows[z].Cells[5].Value.ToString() != "" && dgv_datalab.Rows[y].Cells[0].Value.ToString() == "true")
                                        {
                                            //dgv_cal.Rows[z].Cells[5].Value = Convert.ToString(Convert.ToDouble(dgv_datalab.Rows[y].Cells[3].Value.ToString()) + Convert.ToDouble(dgv_cal.Rows[z].Cells[5].Value.ToString()));

                                            dgv_cal.Rows[z].Cells[5].Value = Convert.ToString(Convert.ToDouble(dgv_datalab.Rows[y].Cells[3].Value.ToString()) + Convert.ToDouble(dgv_cal.Rows[z].Cells[5].Value.ToString()));
                                        }

                                        else { dgv_cal.Rows[z].Cells[5].Value = dgv_datalab.Rows[y].Cells[3].Value.ToString(); }
                                    }
                                }

                                dgv_cal.Rows[z].Cells[3].Value = "เดี่ยว ->> 100%";

                            }                         
                        }
                    }
                    }
                }

                dgv_cal.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_cal.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_cal.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_cal.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgv_cal.Columns[0].Width = 60;                                        

        }
                    
                                            
        private void Load_DataConfirm()
        {
            //if (dgv_datalab.RowCount != 0 && dgv_datavisual.RowCount != 0)
            //{

                DataTable table = new DataTable();

                table.Columns.Add("id", typeof(string));// data type int
                table.Columns.Add("List", typeof(string));// data type string
                table.Columns.Add("No1", typeof(string));// datatype string
                table.Columns.Add("No2", typeof(string));// datatype string
                table.Columns.Add("Rate1", typeof(string));// data type int
                table.Columns.Add("Rate2", typeof(string));// data type int
                table.Columns.Add("Total", typeof(string));// data type int
                table.Columns.Add("Change", typeof(string));// data type int
                table.Columns.Add("Table", typeof(string));// data type int
                dgv_dataconfirm.DataSource = table;

                dgv_dataconfirm.Columns[0].HeaderText = "รหัส";
                dgv_dataconfirm.Columns[1].HeaderText = "รายการวิเคราะห์";
                dgv_dataconfirm.Columns[2].HeaderText = "ครั้งที่ 1 หัว (50%)";
                dgv_dataconfirm.Columns[3].HeaderText = "ครั้งที่ 1 พ่วง (50%)";
                dgv_dataconfirm.Columns[4].HeaderText = "ครั้งที่ 2 หัว (100%)";
                dgv_dataconfirm.Columns[5].HeaderText = "ครั้งที่ 2 พ่วง (100%)";
                dgv_dataconfirm.Columns[6].HeaderText = "ผลรวม";
                dgv_dataconfirm.Columns[7].HeaderText = "% ตัด +-";
                dgv_dataconfirm.Columns[8].HeaderText = "ตารางตัด";
                        
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string id_lab = "";
                string name_lab = "";
            string id_labtype = "";
            string sql1 = "Select [LabID],[LabName],[LabtypeID],[ProductID] From [dbo].[TB_LabName] Where [ProductID]='" + Product_id + "' AND [LabActive]=1 AND [TypePno]=1 AND [LabOpserv] = 0  OR [LabID]=6";

            //string sql1 = "Select [LabID],[LabName],[LabtypeID] From [dbo].[TB_LabName] Where [ProductID]='" + Product_id + "' AND [LabActive]=1 AND [TypePno]=1 AND [LabOpserv] = 0 AND [Dilldata]=0";


            SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

            while (DR1.Read())
            {
                if (DR1["ProductID"].ToString().Trim() == Product_id)
                {
                    id_lab = DR1["LabID"].ToString().Trim();
                    name_lab = DR1["LabName"].ToString().Trim();
                    id_labtype = DR1["LabtypeID"].ToString().Trim();
                    table.Rows.Add(id_lab, name_lab, "", "", "", "", "", "", id_labtype);
                    dgv_dataconfirm.DataSource = table;
                }
            }
                DR1.Close();
                con.Close();

                dgv_dataconfirm.Columns[0].Width = 0;
                dgv_dataconfirm.Columns[1].Width = 200;
                dgv_dataconfirm.Columns[2].Width = 140;
                dgv_dataconfirm.Columns[3].Width = 140;
                dgv_dataconfirm.Columns[8].Width = 0;

            //dgv_dataconfirm.Columns[1].HeaderCell.Style.BackColor = Color.Yellow;


            //Load_Function_Cal();
            //}
        }

        private void Load_Function_Cal()
        {
            try
            {

                dgv_dataconfirm.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_dataconfirm.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_dataconfirm.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_dataconfirm.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_dataconfirm.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_dataconfirm.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                // truck cal weight everage type   คำนวนแบบ เฉลี่ย แม่ลูก 55% ,45%
                double w1_cal = 45.00;  //weigth นน. แม่
                double w2_cal = 55.00; //weight นน. ลูก

                //double sum_value = 0;
                double cal1 = 0;
                double cal2 = 0;
                double cal3 = 0;
                double cal4 = 0;

                double simple1_sum = 0;
                double simple2_sum = 0;


                double simple_val1 = 0; // แม่ 1  dgv lab =4
                double simple_val2 = 0;  //ลูก 1  dgv lab =5     
                double simple_val3 = 0; // แม่ 2  dgv lab =6
                double simple_val4 = 0;  //ลูก 2  dgv lab =7     

                for (int i = 0; i < dgv_dataconfirm.RowCount; i++)  // loop เช็คประเภทผลวิเคราะห์ ที่ต้องเอามาแสดงผล
                {
                    for (int x = 0; x < dgv_cal.RowCount; x++)  //Product 1 Lab
                    {
                        string str = dgv_cal.Rows[x].Cells[2].Value.ToString().Trim();
                        
                        if (Truck_type == 1 && dgv_datalab.RowCount != 0) //Single Truck
                        {
                            if (rdo_everage.Checked == true)
                            {
                                if (dgv_dataconfirm.Rows[i].Cells[8].Value.ToString() == "1" )   /// คำนวน % แป้ง
                                {

                                    if (dgv_cal.Rows[x].Cells[0].Value.ToString() == dgv_dataconfirm.Rows[i].Cells[0].Value.ToString())
                                    {
                                        if (str.Contains("-1")) //ตัวอย่างที่ 1
                                        {       
                                            dgv_dataconfirm.Rows[i].Cells[2].Value = dgv_cal.Rows[x].Cells[4].Value.ToString().Trim();
                                            dgv_dataconfirm.Rows[i].Cells[4].Value = dgv_cal.Rows[x].Cells[5].Value.ToString().Trim();


                                            dgv_dataconfirm.Rows[i].Cells[3].Value = "";
                                            dgv_dataconfirm.Rows[i].Cells[5].Value = "";
                                            //dgv_dataconfirm.Rows[i].Cells[6].Value = "";

                                            if (dgv_cal.Rows[x].Cells[4].Value.ToString().Trim() != "")
                                            {
                                                simple_val1 = Convert.ToDouble(dgv_cal.Rows[x].Cells[4].Value.ToString().Trim());
                                            }

                                            if (dgv_cal.Rows[x].Cells[5].Value.ToString().Trim() != "")
                                            {
                                                simple_val2 = Convert.ToDouble(dgv_cal.Rows[x].Cells[5].Value.ToString().Trim());
                                            }
                                            simple1_sum = Convert.ToDouble((simple_val1 + simple_val2) / 2);
                                            
                                            // dgv_dataconfirm.Rows[i].Cells[6].Value = simple1_sum.ToString("##.###").Trim();
                                            if (simple1_sum == 0)
                                            {
                                                dgv_dataconfirm.Rows[i].Cells[6].Value = "0.00";
                                            }

                                            else
                                            {                                              

                                                dgv_dataconfirm.Rows[i].Cells[6].Value = simple1_sum.ToString("F");// Math.Round(simple1_sum, 2, MidpointRounding.AwayFromZero);//Math.Truncate(simple1_sum);                                    

                                                if (dgv_dataconfirm.Rows[i].Cells[0].Value.ToString() != "6")
                                                {
                                                    dgv_dataconfirm.Rows[i].DefaultCellStyle.BackColor = Color.PaleTurquoise;
                                                }
                                                else { dgv_dataconfirm.Rows[i].DefaultCellStyle.BackColor = Color.LightGray; }
                                            }
                                        }

                                    }
                                }

                                
                            }

                        }
                                                                                                                                                        

                        if (Truck_type == 2 && dgv_datalab.RowCount != 0) //Double Truck
                        {
                            if (rdo_everage.Checked == true)
                            {
                                //คำนวน ค่าของ ตัวอย่างแม่  
                             
                                                                                             
                                if (dgv_dataconfirm.Rows[i].Cells[8].Value.ToString() == "1")
                                {

                                    if (dgv_cal.Rows[x].Cells[4].Value.ToString().Trim() != "" && dgv_cal.Rows[x].Cells[0].Value.ToString() == dgv_dataconfirm.Rows[i].Cells[0].Value.ToString())
                                    {
                                        if (str.Contains("-1")) //ตัวอย่างที่ 1
                                        {
                                            simple_val1 = Convert.ToDouble(dgv_cal.Rows[x].Cells[4].Value.ToString().Trim());
                                            dgv_dataconfirm.Rows[i].Cells[2].Value = simple_val1.ToString("##.###");
                                        }

                                        if (str.Contains("-2")) //ตัวอย่างที่ 2
                                        {
                                            simple_val2 = Convert.ToDouble(dgv_cal.Rows[x].Cells[4].Value.ToString().Trim());
                                            dgv_dataconfirm.Rows[i].Cells[3].Value = simple_val2.ToString("##.###");
                                        }
                                    }

                                    if (dgv_cal.Rows[x].Cells[5].Value.ToString().Trim() != "" && dgv_cal.Rows[x].Cells[0].Value.ToString() == dgv_dataconfirm.Rows[i].Cells[0].Value.ToString())
                                    {
                                        if (str.Contains("-1")) //ตัวอย่างที่ 1
                                        {

                                            simple_val3 = Convert.ToDouble(dgv_cal.Rows[x].Cells[5].Value.ToString().Trim());
                                            dgv_dataconfirm.Rows[i].Cells[4].Value = simple_val3.ToString("##.###");
                                            //}
                                        }

                                        if (str.Contains("-2")) //ตัวอย่างที่ 2
                                        {
                                            simple_val4 = Convert.ToDouble(dgv_cal.Rows[x].Cells[5].Value.ToString().Trim());
                                            dgv_dataconfirm.Rows[i].Cells[5].Value = simple_val4.ToString("##.###");
                                        }
                                    }

                                    cal1 = Convert.ToDouble((simple_val1 * w1_cal) / 100);  //weight 45%    ส่วนหัวแม่ ตัวอย่าง 1
                                    cal2 = Convert.ToDouble((simple_val2 * w2_cal) / 100);   //wight 55%   ส่วนหางลูก ตัวอย่าง 1
                                    cal3 = Convert.ToDouble((simple_val3 * w1_cal) / 100);  //weight 45%    ส่วนหัวแม่ ตัวอย่าง 2
                                    cal4 = Convert.ToDouble((simple_val4 * w2_cal) / 100);   //wight 55%   ส่วนหางลูก ตัวอย่าง 2

                                    simple1_sum = cal1 + cal3;
                                    simple2_sum = cal2 + cal4;
                                    // double sum_net = (simple1_sum + simple2_sum) / 2;

                                    double sum_net = (simple1_sum + simple2_sum) / 2;   // % แป้งแต่ละตัวอย่าง รวมกัน หาร 2

                                    if (sum_net == 0)
                                    {
                                        dgv_dataconfirm.Rows[i].Cells[6].Value = "0";
                                    }
                                    else
                                    {
                                        if (dgv_dataconfirm.Rows[i].Cells[5].Value.ToString() != "")
                                        {
                                            dgv_dataconfirm.Rows[i].Cells[6].Value = Math.Round(sum_net, 2, MidpointRounding.AwayFromZero);
                                        }
                                        //Math.Truncate(sum_net);

                                        //Math.Round(value_sum, 2, MidpointRounding.AwayFromZero);


                                        //edit   17/09/21
                                        else {

                                            //dgv_dataconfirm.Rows[i].Cells[4].Value = "-";
                                            //dgv_dataconfirm.Rows[i].Cells[5].Value = "-";
                                            //dgv_dataconfirm.Rows[i].Cells[6].Value = "-";
                                            //dgv_dataconfirm.Rows[i].Cells[7].Value = "-";

                                        }


                                    }
                                    //dgv_dataconfirm.Rows[i].Cells[6].Value = sum_net.ToString("##.###");
                                    //dgv_dataconfirm.Rows[i].DefaultCellStyle.BackColor = Color.PaleTurquoise;

                                    if (dgv_dataconfirm.Rows[i].Cells[0].Value.ToString() != "6")
                                    {
                                        dgv_dataconfirm.Rows[i].DefaultCellStyle.BackColor = Color.PaleTurquoise;
                                    }
                                    else { dgv_dataconfirm.Rows[i].DefaultCellStyle.BackColor = Color.LightGray; }

                                }
                            }

                            //}

                        }
                    }
              
                }
            }

            catch { }

        }

        private void Load_Visual()  //Load visual
        {
            double value_sim1 = 0;
            double value_sim2 = 0;
            double value_sim3 = 0;
            double value_sim4 = 0;
            double value_sum = 0;
        

            for (int z = 0; z < dgv_dataconfirm.RowCount; z++)
            {          
                
                for (int x = 0; x < dgv_datavisual.RowCount; x++)
                {
                    //For test
                    //if (dgv_dataconfirm.Rows[z].Cells[8].Value.ToString() == "2")
                    //{
                    //    string xxxx = "";
                    //}


                    //if (dgv_dataconfirm.Rows[z].Cells[0].Value.ToString().Trim() == dgv_datavisual.Rows[x].Cells[1].Value.ToString().Trim()) //test


                        if (dgv_dataconfirm.Rows[z].Cells[0].Value.ToString().Trim() == dgv_datavisual.Rows[x].Cells[1].Value.ToString().Trim() && dgv_dataconfirm.Rows[z].Cells[8].Value.ToString() == "2" && dgv_datavisual.Rows[x].Cells[0].Value.ToString() == "True" && dgv_datavisual.Rows[x].Cells[6].Value.ToString() == "False")
                    {
                        string str = dgv_datavisual.Rows[x].Cells[5].Value.ToString().Trim();

                        if (str.Contains("-1-1")) //แม่ครั้งที่ 1
                        {
                            dgv_dataconfirm.Rows[z].Cells[2].Value = dgv_datavisual.Rows[x].Cells[4].Value.ToString().Trim();
                        }

                        if (str.Contains("-2-1"))   //ลูกครั้งที่ 1
                        {
                            dgv_dataconfirm.Rows[z].Cells[3].Value = dgv_datavisual.Rows[x].Cells[4].Value.ToString().Trim();
                        }

                        if (str.Contains("-1-2"))  //แม่ครั้งที่ 2  ---- มีปัญหา เพิ่มที่ 3 เอง
                        {
                            dgv_dataconfirm.Rows[z].Cells[4].Value = dgv_datavisual.Rows[x].Cells[4].Value.ToString().Trim();
                        }

                        if (str.Contains("-2-2"))   //ลูกครั้งที่ 2
                        {
                            dgv_dataconfirm.Rows[z].Cells[5].Value = dgv_datavisual.Rows[x].Cells[4].Value.ToString().Trim();
                        }


                        if (Truck_type == 1) //รถเดี่ยว
                        {
                            if (dgv_dataconfirm.Rows[z].Cells[2].Value.ToString() != "" && dgv_dataconfirm.Rows[z].Cells[2].Value.ToString() != "-")
                            {
                                value_sim1 = Convert.ToDouble(dgv_dataconfirm.Rows[z].Cells[2].Value.ToString());  //แม่
                            }
                            else { value_sim1 = 0; }

                            if (dgv_dataconfirm.Rows[z].Cells[4].Value.ToString() != "" && dgv_dataconfirm.Rows[z].Cells[4].Value.ToString() != "-")
                            {
                                value_sim2 = Convert.ToDouble(dgv_dataconfirm.Rows[z].Cells[4].Value.ToString());  //ลูก
                            }
                            else { value_sim2 = 0; }


                            value_sum = (value_sim1 + value_sim2) / 2;  // ค่าหาร 2 ของผลแลปแบบรถ เดี่ยว631123-0001

                            if (value_sum != 0)
                            {
                                dgv_dataconfirm.Rows[z].Cells[6].Value = value_sum.ToString("F");
                            }
                            else { dgv_dataconfirm.Rows[z].Cells[6].Value = "0.00"; }

                            dgv_dataconfirm.Rows[z].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                            dgv_dataconfirm.Rows[z].Cells[3].Value = "";
                            dgv_dataconfirm.Rows[z].Cells[5].Value = "";
                        }


                        if (Truck_type == 2) //รถพ่วง
                        {

                            if (dgv_dataconfirm.Rows[z].Cells[2].Value.ToString() != "" )
                            {
                               
                                value_sim1 = Convert.ToDouble((Convert.ToDouble(dgv_dataconfirm.Rows[z].Cells[2].Value.ToString()) * 45) / 100); //แม่ครั้งที่ 1
                            }
                            else
                            {
                                value_sim1 = 0; 
                            }

                            if (dgv_dataconfirm.Rows[z].Cells[3].Value.ToString() != "" )
                            {                              
                                    value_sim2 = Convert.ToDouble((Convert.ToDouble(dgv_dataconfirm.Rows[z].Cells[3].Value.ToString()) * 55) / 100);                            

                            }  //ลูกครั้งที่ 1
                            else
                            {
                                value_sim2 = 0; 
                            }

                            if (dgv_dataconfirm.Rows[z].Cells[4].Value.ToString() != "" )
                            {                               
                                    value_sim3 = Convert.ToDouble((Convert.ToDouble(dgv_dataconfirm.Rows[z].Cells[4].Value.ToString()) * 45) / 100);
                               
                            } //แม่ครั้งที่ 2

                            else
                            {
                                value_sim3 = 0; 
                            }

                            if (dgv_dataconfirm.Rows[z].Cells[5].Value.ToString() != "")
                            {
                                value_sim4 = Convert.ToDouble((Convert.ToDouble(dgv_dataconfirm.Rows[z].Cells[5].Value.ToString()) * 55) / 100);
                            } //ลูกครั้งที่ 2

                            else
                            {
                                value_sim4 = 0; dgv_dataconfirm.Rows[z].Cells[5].Value = "";
                            }


                            value_sum = (Convert.ToDouble(value_sim1) + Convert.ToDouble(value_sim2) + Convert.ToDouble(value_sim3) + Convert.ToDouble(value_sim4)) / 2;

                            if (dgv_dataconfirm.Rows[z].Cells[4].Value.ToString() != "" || dgv_dataconfirm.Rows[z].Cells[5].Value.ToString() != "")
                            {
                                if (value_sum != 0)
                                {
                                    dgv_dataconfirm.Rows[z].Cells[6].Value = value_sum.ToString("F"); // Math.Round(value_sum, 2, MidpointRounding.AwayFromZero);
                                }
                                else { dgv_dataconfirm.Rows[z].Cells[6].Value = "0.00"; }
                            }

                            dgv_dataconfirm.Rows[z].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                        }
                    }
                }
            }        
        }


        private void CheckBtnSave()
        {
            btn_confirm.Enabled = false;
            //int statusEnableSave = 0;
            //int CheckData = dgv_dataconfirm.RowCount * 6;

            //for (int z = 0; z < dgv_dataconfirm.Rows.Count; z++)
            //{
            //    if (dgv_dataconfirm.Rows[z].Cells[2].Value.ToString() != "" || dgv_datatruck.Rows[e_RowIndex].Cells[1].Value.ToString().Trim() == "บันทึกผลครั้งที่ 1/บันทึกผล")
            //    { CheckData--; }
            //    if (dgv_dataconfirm.Rows[z].Cells[3].Value.ToString() != "" || dgv_dataconfirm.Rows[z].Cells[3].Value.ToString() != "-" || dgv_datatruck.Rows[e_RowIndex].Cells[1].Value.ToString().Trim() == "บันทึกผลครั้งที่ 1/บันทึกผล")
            //    { CheckData--; statusEnableSave = 1; }
            //    if (dgv_dataconfirm.Rows[z].Cells[4].Value.ToString() != "" || dgv_datatruck.Rows[e_RowIndex].Cells[1].Value.ToString().Trim() == "บันทึกผลครั้งที่ 1/บันทึกผล")
            //    { CheckData--; }
            //    if (dgv_dataconfirm.Rows[z].Cells[5].Value.ToString() != "" || dgv_dataconfirm.Rows[z].Cells[5].Value.ToString() != "" || dgv_datatruck.Rows[e_RowIndex].Cells[1].Value.ToString().Trim() == "บันทึกผลครั้งที่ 1/บันทึกผล")
            //    { CheckData--; statusEnableSave = 1; }
            //    if (dgv_dataconfirm.Rows[z].Cells[6].Value.ToString() != "")
            //    { CheckData--; }
            //    if (dgv_dataconfirm.Rows[z].Cells[7].Value.ToString() != "")
            //    { CheckData--; }

            //}

            if (count_bf==count_af) { btn_confirm.Enabled = true; }


        }
                    
        private void Load_GetData_SQL()
        {
            //ดึงผลเทียบตารางเพื่อ เพิ่ม/ลด ตามเกณฑ์ที่ตั้งไว้
            SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
            con1.ConnectionString = Program.pathdb_Weight;

            SqlConnection con2 = new SqlConnection(Program.pathdb_Weight);
            con2.ConnectionString = Program.pathdb_Weight;

            SqlConnection con3 = new SqlConnection(Program.pathdb_Weight);
            con3.ConnectionString = Program.pathdb_Weight;

            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            Sum_visual = 0;
            //string sql = "";
            //con.Open();           

            //for
            for (int i = 0; i < dgv_dataconfirm.RowCount; i++)
            {
                if (dgv_dataconfirm.Rows[i].Cells[8].Value.ToString() == "1" ||  dgv_dataconfirm.Rows[i].Cells[8].Value.ToString().Trim() == "2") // ให้ปโหลดที่ table เกณฑ์ เครื่องมือ lab (Deduct Table)
                {
                    double value_min = 0;
                    double value_max = 0;
                    string sql_min = "";
                    string sql_max = "";
                    int count_min = 0;
                    int count_max = 0;
                    string sql_countmin = "";
                    string sql_countmax = "";                                       

                    if (dgv_dataconfirm.Rows[i].Cells[8].Value.ToString() == "1") // ให้ปโหลดที่ table LabData
                    {
                        sql_min = "SELECT top 1 [Rate]  FROM  [dbo].[TB_ValueLab] WHERE [LabID]=" + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString().Trim() + "  AND DeductActive =1  AND [Min] <=" + dgv_dataconfirm.Rows[i].Cells[6].Value.ToString().Trim() + " Order By [LOGID] Desc";

                        //sql_countmin = "SELECT count([Rate]) AS Countmin  FROM  [dbo].[TB_ValueLab] WHERE [LabID] = " + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString().Trim() + "  AND DeductActive = 1  AND[Min] <= " + dgv_dataconfirm.Rows[i].Cells[6].Value.ToString().Trim() + "";

                        //-----------------------------------

                        sql_max = "SELECT top 1 [Rate]  FROM  [dbo].[TB_ValueLab] WHERE [LabID]=" + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString().Trim() + "  AND DeductActive =1  AND  [Max] >=" + dgv_dataconfirm.Rows[i].Cells[6].Value.ToString().Trim() + " Order By [LOGID] ASC";

                        //sql_countmax = "SELECT count([Rate]) AS Countmax   FROM  [dbo].[TB_ValueLab] WHERE [LabID] = " + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString().Trim() + "  AND DeductActive = 1  AND[Max] >= " + dgv_dataconfirm.Rows[i].Cells[6].Value.ToString().Trim() + "";


                    }


                    if (dgv_dataconfirm.Rows[i].Cells[8].Value.ToString().Trim() == "2") // ให้ปโหลดที่ table VisualData
                    {

                        sql_min = "SELECT top 1[VSelect] FROM [dbo].[TB_ValueVisualDetail]  Where  [LabID] = " + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString().Trim() + "   AND Convert(float,[Vmin]) <= " + dgv_dataconfirm.Rows[i].Cells[6].Value.ToString().Trim() + " Order By [VVDeNo] Desc";

                        sql_max = "SELECT top 1[VSelect] FROM [dbo].[TB_ValueVisualDetail]  Where  [LabID] = " + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString().Trim() + "   AND Convert(float,[Vmax]) >= " + dgv_dataconfirm.Rows[i].Cells[6].Value.ToString().Trim() + " Order By [VVDeNo] ASC";       
                      
                    }

                    try

                    {                      
                        
                        try
                        {
                            if (con1.State == ConnectionState.Open)
                            { con1.Close(); }

                            con1.Open();
                            SqlCommand CM1 = new SqlCommand(sql_min, con1);
                            SqlDataReader DR1 = CM1.ExecuteReader();

                            DR1.Read();
                            {
                                if (dgv_dataconfirm.Rows[i].Cells[8].Value.ToString() == "1")  // สินค้าที่ดึงจาก lab
                                {
                                    value_min = Convert.ToDouble(DR1["Rate"].ToString().Trim());
                                }

                                else { value_min = Convert.ToDouble(DR1["VSelect"].ToString().Trim()); }
                            }
                            DR1.Close();
                            con1.Close();
                        }
                        catch { value_min = 0; }


                        //if (count_max > 0)
                        //{
                        //    //Load ค่าสูงสุด   

                        try
                        {
                            if (con2.State == ConnectionState.Open)
                            { con2.Close(); }

                            con2.Open();
                            SqlCommand CM2 = new SqlCommand(sql_max, con2);
                            SqlDataReader DR2 = CM2.ExecuteReader();

                            DR2.Read();
                            {
                                if (dgv_dataconfirm.Rows[i].Cells[8].Value.ToString() == "1")  // สินค้าที่ดึงจาก lab
                                {
                                    value_max = Convert.ToDouble(DR2["Rate"].ToString().Trim());
                                }
                                else { value_max = Convert.ToDouble(DR2["VSelect"].ToString().Trim()); }

                            }
                            DR2.Close();
                            con2.Close();
                        }
                        catch (Exception ex)

                        { value_max = 0; }                    

                            //MessageBox.Show(value_max.ToString());
                            if (dgv_dataconfirm.Rows[i].Cells[0].Value.ToString() != "6")
                            {
                                dgv_dataconfirm.Rows[i].Cells[7].Value = value_max.ToString("F"); // System.Math.Ceiling(value_max); ;                          
                            }
                            else { dgv_dataconfirm.Rows[i].Cells[7].Value = "-"; }
                    }

                    catch 
                    {                 
                        dgv_dataconfirm.Rows[i].Cells[7].Style.ForeColor = Color.Red;                 
                    }
                }
                
                //insert data to smg line app  
            }
        }


        private void Check_ServiceChage()
        {


        }

        private void Load_LoopCheck_Status()
        {


        }

        private void F_ConfirmLab_Resize(object sender, EventArgs e)
        {
            Adjust_panel();
            
        }

        int e_RowIndex = 0;
        private void dgv_datatruck_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (Viewdata_Per == 1)
            //{
            try
            {           
                txt_qrcode.Text = dgv_datatruck.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                Ticket_code = dgv_datatruck.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                ProductName = dgv_datatruck.Rows[e.RowIndex].Cells[6].Value.ToString().Trim();
                Load_InformationLine();

                count_bf = 0;
                count_af = 0;
                e_RowIndex = e.RowIndex;
                Data_ReadySave = 1;
                Load_DataTruck();
                Load_DataLine();
               

                if (dgv_datatruck.Rows[e.RowIndex].Cells[13].Value.ToString() != "1" && dgv_datatruck.Rows[e.RowIndex].Cells[13].Value.ToString() != "4")
                {
                    btn_confirm.Text = "ผลการวิเคราะห์ไม่ผ่านเกณฑ์รออนุมัติ (" + dgv_datatruck.Rows[e.RowIndex].Cells[14].Value.ToString().Trim() + ")";
                    btn_confirm.BackColor = Color.Khaki;
                    btn_confirm.Enabled = false;
                }



                else
                {

                    btn_confirm.Text = "ยืนยันและส่งข้อมูล";
                    btn_confirm.BackColor = Color.LightGreen;
                    btn_confirm.Enabled = true;
                }

                //}

                //else { MessageBox.Show("สิทธิ์ในการดูข้อมูล/ค้นหา ถูกจำกัด กรุณาติดต่อผู้ดูแลระบบ! (งานยืนยันผลวิเคราะห์)", "รายงานความผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        private void Load_DataTruck()
        {
            try
            {
                dgv_datalab.DataSource = null;
                dgv_datavisual.DataSource = null;
                dgv_cal.DataSource = null;
                dgv_dataconfirm.DataSource = null;

                if (STS_Mode == 1)
                {
                    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                    con.ConnectionString = Program.pathdb_Weight;
                    SqlDataAdapter dtAdapter = new SqlDataAdapter();
                    con.Open();

                    Ticket_code = txt_qrcode.Text.Trim();

                    string sql1 = "Select [ProductID],[TruckTypeID],[Process_id],[Vendor_No] From  [dbo].[V_WeightData] Where TicketCodeIn ='" + Ticket_code + "'";

                    SqlCommand CM1 = new SqlCommand(sql1, con);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    {
                        Product_id = DR1["ProductID"].ToString();
                        Truck_type = Convert.ToInt16(DR1["TruckTypeID"].ToString());
                        Process_id = Convert.ToInt16(DR1["Process_id"].ToString());
                        VenCus_No = DR1["Vendor_No"].ToString();

                    }
                    DR1.Close();
                    con.Close();
                }

                if (STS_Mode == 0)
                {
                    Ticket_code = dgv_datatruck.Rows[e_RowIndex].Cells[2].Value.ToString().Trim();
                    Product_id = dgv_datatruck.Rows[e_RowIndex].Cells[10].Value.ToString().Trim();
                    Truck_type = Convert.ToInt16(dgv_datatruck.Rows[e_RowIndex].Cells[11].Value.ToString().Trim());
                    Process_id = Convert.ToInt16(dgv_datatruck.Rows[e_RowIndex].Cells[12].Value.ToString().Trim());
                    VenCus_No = dgv_datatruck.Rows[e_RowIndex].Cells[16].Value.ToString().Trim();
                }

                //  net_weight = Convert.ToDouble(dgv_datatruck.Rows[e.RowIndex].Cells[8].Value.ToString().Trim());


                //if (dgv_datatruck.Rows[e_RowIndex].Cells[1].Value.ToString().Trim() == "บันทึกผลครั้งที่ 1/บันทึกผล" || dgv_datatruck.Rows[e_RowIndex].Cells[1].Value.ToString().Trim() == "บันทึกผล/ลงสินค้า") //บนทึกครั้งที่ 1  ให้
                //{
                //    id_confirmLevel = 1;
                //}
                if (dgv_datatruck.Rows[e_RowIndex].Cells[15].Value.ToString().Trim() == "L+WH" && chk_normalMode.Checked == true)
                {
                    id_confirmLevel = 1;
                }

                else { id_confirmLevel = 2; } //บันทึกครั้งที่ 2

                Load_Labsetting();
                Load_DataLab();   //ดึงข้อมูลที่บันทึกจากเครื่องมือ lab
                Load_DataVisual(); //ดึงข้อมูลที่บันทึกจาก visual
                Load_Cal(); // จัดขอ้มูลในแนวตั้งแนวนอน ตามตัวอย่างใหม่
                Load_DataConfirm();  //สร้างเมนูจาก Visual Lab มาที่ Data confirm Lab
                Load_Function_Cal();  //คำนวนสัดส่วน weithg น้ำหนัก แม่ ลูก จากการเลือกแบบ เฉลี่ย หรือ แบบค่าสูงสุดต่ำสุด
                Load_Visual();   //คำนวนผลที่ได้จาก  ตาราง visul มาใส่ในตาราง ยืนยันผลวิเคราะห์
                Load_GetData_SQL();  // Load data to Line app
                CheckBtnSave();

                dgv_datavisual.Columns[6].Visible = false;
                dgv_datavisual.Columns[7].Visible = false;
                dgv_datavisual.Columns[8].Visible = false;

                //dgv_datavisual.Columns[0].ReadOnly = true;
                //dgv_datavisual.Columns[1].Width = 50;
                //dgv_datavisual.Columns[2].Width = 60;
                //dgv_datavisual.Columns[3].Width = 70;
                //dgv_datavisual.Columns[4].Width = 50;

                dgv_datalab.ClearSelection();
                dgv_datavisual.ClearSelection();
                dgv_cal.ClearSelection();
                dgv_dataconfirm.ClearSelection();

            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());

            }

        }


     

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdo_everage.Checked == true)
            //{
            //    lbl_decript.Text = ":แม่ นน.45%, ลูก นน.55%";
            //}

            //else lbl_decript.Text = "-";
        }

        private void chk_resize_toollab_CheckedChanged(object sender, EventArgs e)
        {
            int w = this.Width;
            int w_n = pn_lab.Width;
            if (chk_resize_toollab.Checked == true)
            {
                pn_lab.Width = w / 2;
            }
            else {
                       
                int sc_y = w / 8;
                pn_lab.Width = sc_y * 3;
            }
        }

        private void chk_resize_visiuallab_CheckedChanged(object sender, EventArgs e)
        {
            int w = this.Width;
            int w_n = pn_lab.Width;
            if (chk_resize_visiuallab.Checked == true)
            {
                pn_lab.Width = w / 2;
            }
            else {
              
                int sc_y = w / 8;
                pn_lab.Width = sc_y * 3;
            }           
        }

        private void Send_lineAlert()
        {
            string msg1 = "รายงาน: งานบันทึกผลการวิเคราะห์" + Environment.NewLine + " บัตรชั่งเลขที่: " + Ticket_code + " คิวที่: " + QueaNo.ToString() + " สินค้า: " + ProductName + " ทะเบียนรถ: " + PlateNo + Environment.NewLine + " ผู้ขาย: " + Vendor_Name + " ประเภท: " + OwnerName;

            string msg2 = "";
            if (Lab1_Name != "")
            {
                msg2 = "--" + Lab1_Name + "--" + " [แม่ 1]: " + Lab1_1 + " [ลูก 1]: " + Lab1_2 + " [แม่ 2]: " + Lab1_3 + " [ลูก 2]: " + Lab1_4 + " [ผลรวม]: " + Lab1_5 + " [ผลตัด]: " + Lab1_6;
            }
            if (Lab2_Name != "")
            {
                msg2 += Environment.NewLine + "--" + Lab2_Name + "--" + " [แม่ 1]: " + Lab2_1 + " [ลูก 1]: " + Lab2_2 + " [แม่ 2]: " + Lab2_3 + " [ลูก 2]: " + Lab2_4 + " [ผลรวม]: " + Lab2_5 + " [ผลตัด]: " + Lab2_6;
            }

            if (Lab3_Name != "")
            {
                msg2 += Environment.NewLine + "--" + Lab3_Name + "--" + " [แม่ 1]: " + Lab3_1 + " [ลูก 1]: " + Lab3_2 + " [แม่ 2]: " + Lab3_3 + " [ลูก 2]: " + Lab3_4 + " [ผลรวม]: " + Lab3_5 + " [ผลตัด]: " + Lab3_6;
            }

            if (Lab4_Name != "")
            {
                msg2 += Environment.NewLine + "--" + Lab4_Name + "--" + " [แม่ 1]: " + Lab4_1 + " [ลูก 1]: " + Lab4_2 + " [แม่ 2:]: " + Lab4_3 + " [ลูก 2]: " + Lab4_4 + " [ผลรวม]: " + Lab4_5 + " [ผลตัด]: " + Lab4_6;
            }

            if (Lab5_Name != "")
            {
                msg2 += Environment.NewLine + "--" + Lab5_Name + "--" + " [แม่ 1]: " + Lab5_1 + " [ลูก 1]: " + Lab5_2 + " [แม่ 2]: " + Lab5_3 + " [ลูก 2]: " + Lab5_4 + " [ผลรวม]: " + Lab5_5 + " [ผลตัด]: " + Lab5_6;
            }

            if (Lab6_Name != "")
            {
                msg2 += Environment.NewLine + "--" + Lab6_Name + "--" + " [แม่ 1]: " + Lab6_1 + " [ลูก 1]: " + Lab6_2 + " [แม่ 2]: " + Lab6_3 + " [ลูก 2]: " + Lab6_4 + " [ผลรวม]: " + Lab6_5 + " [ผลตัด]: " + Lab6_6;
            }

            msg2 += Environment.NewLine + "สรุปผลรวมสิ่งเจือป่น: " + Sum_visual.ToString();

            string remark2 = "";
            if (txt_remark2.Text == "")
            {
                remark2 = "-";
            }
            else { remark2 = txt_remark2.Text; }

            msg2 += Environment.NewLine + "หมายเหตุ: " + remark2 + Environment.NewLine + "Report time: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();


            // Loop check Token send line
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql = "SELECT [AL_lineNameToken] FROM [dbo].[V_TokenLine] WHERE [ID_processType]='"+ Process_Name + "' AND [ProductID]='" + Product_id + "' AND [AL_lineStatus]=1";
            SqlCommand CM = new SqlCommand(sql, con);
            SqlDataReader DR = CM.ExecuteReader();
            while (DR.Read())
            {
                token = DR["AL_lineNameToken"].ToString();
                lineNotify(msg1);
                lineNotify(msg2);
            }
            DR.Close();
            con.Close();

            CLS_Linde_Data();
        }

        int Data_ReadySave = 1;
        private void btn_confirm_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;

            if (Adddata_Per == 1)
            {
                if (Data_ReadySave == 1)
                {                 
                    Confirm_DATALab();
                    chk_normalMode.Checked = true;
                    txt_qrcode.Clear();
                    txt_qrcode.Focus();
                }

                else { MessageBox.Show("ข้อมูลในการยืนยันยังไม่ครบ กรุณาบันทึกให้ครบ", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            else { MessageBox.Show("สิทธ์การเพิ่มข้อมูลไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานยืนยันผลวิเคราะห์)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Send_lineImg()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            //whil loop send image
            string sql1 = "Select * From [dbo].[TB_Image] Where [TicketCode]='" + Ticket_code + "'";

            //string sql1 = "Select [LabID],[LabName],[LabtypeID] From [dbo].[TB_LabName] Where [ProductID]='" + Product_id + "' AND [LabActive]=1 AND [TypePno]=1 AND [LabOpserv] = 0 AND [Dilldata]=0";

            con.Open();
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            while (DR1.Read())
            {
                if (DR1["Path_Image1"].ToString().Trim() != "")
                {
                    string Agr1 = "curl -X POST -H";
                    string Agr2 = "\"Authorization: Bearer EdpkjZaUn6Sl5wCf0hDge2jXUePDZ7aTTdhpv6XOPda\"" + " -F ";
                    string Agr3 = "\"message=Sample Code-> " + DR1["SimpleCode"].ToString().Trim() + "\"" + " -F ";
                    string Agr4 = "\"imageFile=@" + DR1["Path_Image1"].ToString().Trim() + "\"";
                    //string Agr5 = "\\192.168.111.225\\PIC_STW\\1-9-2021\\RM-004-640823-0001-1-1-1.jpg\"";
                    //string Agr5 = ""+ DR1["Path_Image1"].ToString().Trim() +"\"";
                    string Agr5 = " https://notify-api.line.me/api/notify";
                    string Agr6 = Agr1 + Agr2 + Agr3 + Agr4 + Agr5;

                    ProcessStartInfo ps = new ProcessStartInfo();
                    ps.FileName = "cmd.exe";
                    ps.WindowStyle = ProcessWindowStyle.Hidden;
                    ps.Arguments = @"/c" + Agr6;
                    Process.Start(ps);
                }

                if (DR1["Path_Image2"].ToString().Trim() != "")
                {
                    string Agr1 = "curl -X POST -H";
                    string Agr2 = "\"Authorization: Bearer EdpkjZaUn6Sl5wCf0hDge2jXUePDZ7aTTdhpv6XOPda\"" + " -F ";
                    string Agr3 = "\"message=Sample Code-> " + DR1["SimpleCode"].ToString().Trim() + "\"" + " -F ";
                    string Agr4 = "\"imageFile=@" + DR1["Path_Image2"].ToString().Trim() + "\"";
                    //string Agr5 = "\\192.168.111.225\\PIC_STW\\1-9-2021\\RM-004-640823-0001-1-1-1.jpg\"";
                    //string Agr5 = ""+ DR1["Path_Image1"].ToString().Trim() +"\"";
                    string Agr5 = " https://notify-api.line.me/api/notify";
                    string Agr6 = Agr1 + Agr2 + Agr3 + Agr4 + Agr5;

                    ProcessStartInfo ps = new ProcessStartInfo();
                    ps.FileName = "cmd.exe";
                    ps.WindowStyle = ProcessWindowStyle.Hidden;
                    ps.Arguments = @"/c" + Agr6;
                    Process.Start(ps);
                }

                if (DR1["Path_Image3"].ToString().Trim() != "")
                {
                    string Agr1 = "curl -X POST -H";
                    string Agr2 = "\"Authorization: Bearer EdpkjZaUn6Sl5wCf0hDge2jXUePDZ7aTTdhpv6XOPda\"" + " -F ";
                    string Agr3 = "\"message=Sample Code-> " + DR1["SimpleCode"].ToString().Trim() + "\"" + " -F ";
                    string Agr4 = "\"imageFile=@" + DR1["Path_Image3"].ToString().Trim() + "\"";
                    //string Agr5 = "\\192.168.111.225\\PIC_STW\\1-9-2021\\RM-004-640823-0001-1-1-1.jpg\"";
                    //string Agr5 = ""+ DR1["Path_Image1"].ToString().Trim() +"\"";
                    string Agr5 = " https://notify-api.line.me/api/notify";
                    string Agr6 = Agr1 + Agr2 + Agr3 + Agr4 + Agr5;

                    ProcessStartInfo ps = new ProcessStartInfo();
                    ps.FileName = "cmd.exe";
                    ps.WindowStyle = ProcessWindowStyle.Hidden;
                    ps.Arguments = @"/c" + Agr6;
                    Process.Start(ps);
                }

                if (DR1["Path_Image4"].ToString().Trim() != "")
                {
                    string Agr1 = "curl -X POST -H";
                    string Agr2 = "\"Authorization: Bearer EdpkjZaUn6Sl5wCf0hDge2jXUePDZ7aTTdhpv6XOPda\"" + " -F ";
                    string Agr3 = "\"message=Sample Code-> " + DR1["SimpleCode"].ToString().Trim() + "\"" + " -F ";
                    string Agr4 = "\"imageFile=@" + DR1["Path_Image4"].ToString().Trim() + "\"";
                    //string Agr5 = "\\192.168.111.225\\PIC_STW\\1-9-2021\\RM-004-640823-0001-1-1-1.jpg\"";
                    //string Agr5 = ""+ DR1["Path_Image1"].ToString().Trim() +"\"";
                    string Agr5 = " https://notify-api.line.me/api/notify";
                    string Agr6 = Agr1 + Agr2 + Agr3 + Agr4 + Agr5;

                    ProcessStartInfo ps = new ProcessStartInfo();
                    ps.FileName = "cmd.exe";
                    ps.WindowStyle = ProcessWindowStyle.Hidden;
                    ps.Arguments = @"/c" + Agr6;
                    Process.Start(ps);
                }

            }
            DR1.Close();

        }


        private void CLS_Linde_Data()
        {
            QueaNo = 0;
            PlateNo = "";
            Vendor_Name = "";
            Lab1_Name = "";
            Lab1_1 = "";
            Lab1_2 = "";
            Lab1_3 = "";
            Lab1_4 = "";
            Lab1_5 = "";
            Lab1_6 = "";

            Lab2_Name = "";
            Lab2_1 = "";
            Lab2_2 = "";
            Lab2_3 = "";
            Lab2_4 = "";
            Lab2_5 = "";
            Lab2_6 = "";

            Lab3_Name = "";
            Lab3_1 = "";
            Lab3_2 = "";
            Lab3_3 = "";
            Lab3_4 = "";
            Lab3_5 = "";
            Lab3_6 = "";

            Lab4_Name = "";
            Lab4_1 = "";
            Lab4_2 = "";
            Lab4_3 = "";
            Lab4_4 = "";
            Lab4_5 = "";
            Lab4_6 = "";

            Lab5_Name = "";
            Lab5_1 = "";
            Lab5_2 = "";
            Lab5_3 = "";
            Lab5_4 = "";
            Lab5_5 = "";
            Lab5_6 = "";

            Lab6_Name = "";
            Lab6_1 = "";
            Lab6_2 = "";
            Lab6_3 = "";
            Lab6_4 = "";
            Lab6_5 = "";
            Lab6_6 = "";
            Sum_visual = 0;

        }

        private void notifyPicture(string url)
        {
            _lineNotify(" ", 0, 0, url);
        }
        private void notifySticker(int stickerID, int stickerPackageID)
        {
            _lineNotify(" ", stickerPackageID, stickerID, "");
        }
        private void lineNotify(string msg)
        {
            _lineNotify(msg, 0, 0, "");
        }
        private void _lineNotify(string msg, int stickerPackageID, int stickerID, string pictureUrl)
        {          
            
            //string token = "EdpkjZaUn6Sl5wCf0hDge2jXUePDZ7aTTdhpv6XOPda";
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("https://notify-api.line.me/api/notify");

                var postData = string.Format("message={0}", msg);
              

                if (stickerPackageID > 0 && stickerID > 0)
                {
                    var stickerPackageId = string.Format("stickerPackageId={0}", stickerPackageID);
                    var stickerId = string.Format("stickerId={0}", stickerID);
                    postData += "&" + stickerPackageId.ToString() + "&" + stickerId.ToString();
                }
                
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
                //Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
        }

        private void Load_ProcessID()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();              

                Process_id += 1;

                //Step Check Over Process
                int C_count = 0;
                try
                {
                    con.Open();
                    string sql2 = "Select Count([proc_no]) AS 'C_ID' From [dbo].[V_OverStep] Where [item_no]='" + Product_id + "' AND [venOrCus_No]='" + VenCus_No + "'  AND [proc_no]=" + Process_id + " AND [OverPro_Status]=1";
                    SqlCommand CM2 = new SqlCommand(sql2, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();

                    DR2.Read();
                    {
                        C_count = Convert.ToInt16(DR2["C_ID"].ToString());
                    }
                    DR2.Close();
                    con.Close();
                }
                catch { con.Close(); }

                if (C_count == 1)
                {
                    Process_id += 1;
                }


            }
            catch
            {
                MessageBox.Show("มีความผิดพลาดเรื่องกระบวนการทำงานของแต่ละสถานี กรุณาเข้าไปตั้งค่าขั้นตอนการทำงานของสินค้า?", "ข้อมูลผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Load_SaveProcess()
        {
            Load_ProcessID();

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            con.Open();
            string sql1 = "Update [TB_WeightData] Set Process_id=" + Process_id + " Where [TicketCodeIn] = '" + Ticket_code + "'";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();
            con.Close();
        }

        private void Load_DataLine()
        {
            Clear_smsLine();

            for (int i = 0; i < dgv_dataconfirm.RowCount; i++)
            {
                if (dgv_dataconfirm.Rows[i].Cells[1].Value.ToString() != "VA")
                {
                    if (Lab1_Name == "")
                    {
                        Lab1_Name = dgv_dataconfirm.Rows[i].Cells[1].Value.ToString().Trim();
                        Lab1_1 = dgv_dataconfirm.Rows[i].Cells[2].Value.ToString().Trim();
                        Lab1_2 = dgv_dataconfirm.Rows[i].Cells[3].Value.ToString().Trim();
                        Lab1_3 = dgv_dataconfirm.Rows[i].Cells[4].Value.ToString().Trim();
                        Lab1_4 = dgv_dataconfirm.Rows[i].Cells[5].Value.ToString().Trim();
                        Lab1_5 = dgv_dataconfirm.Rows[i].Cells[6].Value.ToString().Trim();
                        Lab1_6 = dgv_dataconfirm.Rows[i].Cells[7].Value.ToString().Trim();
                    }

                    else if (Lab2_Name == "")
                    {
                        Lab2_Name = dgv_dataconfirm.Rows[i].Cells[1].Value.ToString().Trim();
                        Lab2_1 = dgv_dataconfirm.Rows[i].Cells[2].Value.ToString().Trim();
                        Lab2_2 = dgv_dataconfirm.Rows[i].Cells[3].Value.ToString().Trim();
                        Lab2_3 = dgv_dataconfirm.Rows[i].Cells[4].Value.ToString().Trim();
                        Lab2_4 = dgv_dataconfirm.Rows[i].Cells[5].Value.ToString().Trim();
                        Lab2_5 = dgv_dataconfirm.Rows[i].Cells[6].Value.ToString().Trim();
                        Lab2_6 = dgv_dataconfirm.Rows[i].Cells[7].Value.ToString().Trim();
                    }

                    else if (Lab3_Name == "")
                    {
                        Lab3_Name = dgv_dataconfirm.Rows[i].Cells[1].Value.ToString().Trim();
                        Lab3_1 = dgv_dataconfirm.Rows[i].Cells[2].Value.ToString().Trim();
                        Lab3_2 = dgv_dataconfirm.Rows[i].Cells[3].Value.ToString().Trim();
                        Lab3_3 = dgv_dataconfirm.Rows[i].Cells[4].Value.ToString().Trim();
                        Lab3_4 = dgv_dataconfirm.Rows[i].Cells[5].Value.ToString().Trim();
                        Lab3_5 = dgv_dataconfirm.Rows[i].Cells[6].Value.ToString().Trim();
                        Lab3_6 = dgv_dataconfirm.Rows[i].Cells[7].Value.ToString().Trim();
                    }

                    else if (Lab4_Name == "")
                    {
                        Lab4_Name = dgv_dataconfirm.Rows[i].Cells[1].Value.ToString().Trim();
                        Lab4_1 = dgv_dataconfirm.Rows[i].Cells[2].Value.ToString().Trim();
                        Lab4_2 = dgv_dataconfirm.Rows[i].Cells[3].Value.ToString().Trim();
                        Lab4_3 = dgv_dataconfirm.Rows[i].Cells[4].Value.ToString().Trim();
                        Lab4_4 = dgv_dataconfirm.Rows[i].Cells[5].Value.ToString().Trim();
                        Lab4_5 = dgv_dataconfirm.Rows[i].Cells[6].Value.ToString().Trim();
                        Lab4_6 = dgv_dataconfirm.Rows[i].Cells[7].Value.ToString().Trim();
                    }

                    else if (Lab5_Name == "")
                    {
                        Lab5_Name = dgv_dataconfirm.Rows[i].Cells[1].Value.ToString().Trim();
                        Lab5_1 = dgv_dataconfirm.Rows[i].Cells[2].Value.ToString().Trim();
                        Lab5_2 = dgv_dataconfirm.Rows[i].Cells[3].Value.ToString().Trim();
                        Lab5_3 = dgv_dataconfirm.Rows[i].Cells[4].Value.ToString().Trim();
                        Lab5_4 = dgv_dataconfirm.Rows[i].Cells[5].Value.ToString().Trim();
                        Lab5_5 = dgv_dataconfirm.Rows[i].Cells[6].Value.ToString().Trim();
                        Lab5_6 = dgv_dataconfirm.Rows[i].Cells[7].Value.ToString().Trim();
                    }

                    else if (Lab6_Name == "")
                    {
                        Lab6_Name = dgv_dataconfirm.Rows[i].Cells[1].Value.ToString().Trim();
                        Lab6_1 = dgv_dataconfirm.Rows[i].Cells[2].Value.ToString().Trim();
                        Lab6_2 = dgv_dataconfirm.Rows[i].Cells[3].Value.ToString().Trim();
                        Lab6_3 = dgv_dataconfirm.Rows[i].Cells[4].Value.ToString().Trim();
                        Lab6_4 = dgv_dataconfirm.Rows[i].Cells[5].Value.ToString().Trim();
                        Lab6_5 = dgv_dataconfirm.Rows[i].Cells[6].Value.ToString().Trim();
                        Lab6_6 = dgv_dataconfirm.Rows[i].Cells[7].Value.ToString().Trim();
                    }

                    if (dgv_dataconfirm.Rows[i].Cells[8].Value.ToString().Trim() == "2")
                    {
                        Sum_visual += Convert.ToDecimal(dgv_dataconfirm.Rows[i].Cells[7].Value.ToString().Trim());
                    }
                }
            }

        }

        decimal PriceExtra = 0;
        //private void Load_Pric_Extra()
        //{
        //    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
        //    con.ConnectionString = Program.pathdb_Weight;

        //    try
        //    {
        //        con.Open();
        //        string sql1 = "Select [PriceExtra] From   [dbo].[TB_LabConfirmPay] Where [TicketCodeIn] = '" + txt_qrcode.Text.Trim() + "'";
        //        SqlCommand CM1 = new SqlCommand(sql1, con);
        //        SqlDataReader DR1 = CM1.ExecuteReader();

        //        DR1.Read();
        //        {
        //            PriceExtra = Convert.ToDecimal(DR1["PriceExtra"].ToString());               
        //        }
        //        DR1.Close();
        //        con.Close();
        //    }
        //    catch { con.Close(); }
        //}
        private void Confirm_DATALab()
        { 
            //if (tool_dicountlab.Text == "การวิเคราะห์ครบทุกประเภท" && tool_dicountvisual.Text == "การวิเคราะห์ครบทุกประเภท")
            //{

            double Lab_dicutL = 0;
            double Log_dicutL = 0;

            DialogResult dr = MessageBox.Show("คุณต้องการบันทึกข้อมูลนี้ใช่หรือไม่", "ยืนยันข้อมูล", MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                if (txt_qrcode.Text.Trim() != "")
                { Ticket_code = txt_qrcode.Text.Trim(); }

                //Send_lineImg();

                // Save to data base
                //string date = DateTime.Now.ToString("yyyy/MM/dd") + ' ' + DateTime.Now.ToString("HH:mm");

                string date = DateTime.Now.ToString("yyyy-MM-dd") + ' ' + DateTime.Now.ToString("HH:mm:ss");

                decimal DiscutVusual = 0;
      

                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

                SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
                con1.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter1 = new SqlDataAdapter();
                                              

                int DisctPrice = 0;        
                

                for (int i = 0; i < dgv_dataconfirm.RowCount; i++)
                {
                    con.Open();
                    string sql_type = "SELECT [DisctPrice]  FROM  [dbo].[TB_LabName] Where LabID = " + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString() + " ";

                    SqlCommand CM = new SqlCommand(sql_type, con);
                    SqlDataReader DR = CM.ExecuteReader();

                    DR.Read();
                    {
                        if (DR["DisctPrice"].ToString().Trim() == "True")  // สินค้าที่ดึงจาก lab
                        {
                            DisctPrice = 1;
                        }
                    }
                    DR.Close();
                    con.Close();               
                    

                    if (i == 0)   ///บันทึกค่าผลแลป ที่เป็น % แป้ง หักเงิน
                    { 
                        decimal value1 = 0;
                        decimal value2 = 0;
                        string sql2 = "";
                        decimal Lab3 = 0;
                        double valueSelect = 0;                       
                        decimal Labselect = 0;
                        string Date_Now = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
                        string Time_Now = DateTime.Now.ToString("HH:mm", CultureInfo.CreateSpecificCulture("en-US"));
                        string date_time = Date_Now + ' ' + Time_Now;


                        if (dgv_dataconfirm.Rows[i].Cells[3].Value.ToString() != "")
                        { value1 = Convert.ToDecimal(dgv_dataconfirm.Rows[i].Cells[3].Value.ToString()); }

                        if (dgv_dataconfirm.Rows[i].Cells[5].Value.ToString() != "")
                        { value2 = Convert.ToDecimal(dgv_dataconfirm.Rows[i].Cells[5].Value.ToString()); }


                        if (dgv_dataconfirm.Rows[i].Cells[4].Value.ToString() != "")
                        { Lab3 = Convert.ToDecimal(dgv_dataconfirm.Rows[i].Cells[4].Value.ToString()); }

                            //con.Open();
                            
                            if (dgv_dataconfirm.Rows[i].Cells[6].Value.ToString() != "")
                            {
                                valueSelect = Convert.ToDouble(dgv_dataconfirm.Rows[i].Cells[6].Value.ToString());
                                Labselect = Convert.ToDecimal(dgv_dataconfirm.Rows[i].Cells[6].Value.ToString());
                            }

                        if (dgv_dataconfirm.Rows[i].Cells[7].Value.ToString() != "")
                        { PriceExtra = Convert.ToDecimal(dgv_dataconfirm.Rows[i].Cells[7].Value.ToString()); }

                        //SELECT top 1 [Rate]  FROM  [dbo].[TB_ValueLab] WHERE [LabID]=1  AND DeductActive =1  AND [Min] <=27.98 Order By [LOGID] Desc

                        //con.Open();
                        //string sql1 = "SELECT top 1 [Rate]  FROM  [dbo].[TB_ValueLab] WHERE [LabID]=1  AND DeductActive =1  AND [Min] <= " + dgv_dataconfirm.Rows[i].Cells[7].Value.ToString() + " Order By [LOGID] Desc";
                        //SqlCommand CM1 = new SqlCommand(sql1, con);
                        //SqlDataReader DR1 = CM1.ExecuteReader();

                        //DR1.Read();
                        //{
                        //    PriceExtra = Convert.ToDecimal(DR1["Rate"].ToString());                            
                        //}
                        //DR1.Close();
                        //con.Close();                                                                                       



                        if (id_confirmLevel == 1 && chk_normalMode.Checked == true) //บันทึกครั้งที่ 1
                        {
                            if (chk_normalMode.Checked == true)
                            {
                                con.Open();

                                string sql21 = "Update [TB_LabConfirmPay] Set  [DateTime_Confirm] ='" + date_time + "' ,[PriceExtra] =" + PriceExtra + ",[LabValue1]=" + dgv_dataconfirm.Rows[i].Cells[2].Value.ToString() + ",[LabValue2]=" + value1.ToString() + " ,[LabValue3]=" + Lab3.ToString() + ",[LabValue4]=" + value2.ToString() + ",[LabVselect]=" + Labselect + ",[Remark1]='" + txt_remark1.Text.Trim() + "',[Remark2]='" + txt_remark2.Text.Trim() + "',[EmployeeID]=" + Program.user_id + " Where [TicketCodeIn] ='" + Ticket_code + "'";

                                SqlCommand CM21 = new SqlCommand(sql21, con);
                                SqlDataReader DR21 = CM21.ExecuteReader();
                                con.Close();

                                Msg = "Update Data on ConfirmLab Lv1!";

                                Log_NewValue = "DateTime_Confirm =" + date_time.ToString() +
                            "," + "PriceExtra = " + PriceExtra.ToString() +
                            "," + "LabValue1 = " + dgv_dataconfirm.Rows[i].Cells[2].Value.ToString() +
                            "," + "LabValue2 = " + value1.ToString() +
                            "," + "LabValue3 = " + Lab3.ToString() +
                            "," + "LabValue4 = " + value2.ToString() +
                            "," + "LabVselect = " + Labselect +
                            "," + "Remark1 =" + txt_remark1.Text.Trim() +
                            "," + "Remark2 =" + txt_remark2.Text.Trim() +
                            "," + "EmployeeID = " + Program.user_id +
                            "," + "Where TicketCodeIn = " + Ticket_code;                                                                          

                                Log_OldValue = "-";                                
                                Send_lineAlert();
                                Load_SaveProcess();
                            }                       

                        }

                        else if (id_confirmLevel == 2 && chk_normalMode.Checked == true)
                        {                        

                            con.Open();
                            sql2 = "Update [TB_LabConfirmPay] Set [PriceExtra] =" + Convert.ToDecimal(dgv_dataconfirm.Rows[i].Cells[7].Value.ToString()) + ",[LabValue1]=" + dgv_dataconfirm.Rows[i].Cells[2].Value.ToString() + ",[LabValue2]=" + value1.ToString() + " ,[LabValue3]=" + Lab3.ToString() + ",[LabValue4]=" + value2.ToString() + ",[LabVselect]=" + Labselect + ",[Remark1]='" + txt_remark1.Text.Trim() + "',[Remark2]='" + txt_remark2.Text.Trim() + "',[DateTime_Confirm]='" + date_time + "',[EmployeeID]=" + Program.user_id + " Where [TicketCodeIn] ='" + Ticket_code + "'";

                            SqlCommand CM2 = new SqlCommand(sql2, con);
                            SqlDataReader DR2 = CM2.ExecuteReader();
                            con.Close();

                            Msg = "Update Data on ConfirmLab Lv2!";

                            Log_NewValue = "DateTime_Confirm =" + date_time.ToString() +
                     "," + "PriceExtra = " + PriceExtra.ToString() +
                     "," + "LabValue1 = " + dgv_dataconfirm.Rows[i].Cells[2].Value.ToString() +
                     "," + "LabValue2 = " + value1.ToString() +
                     "," + "LabValue3 = " + Lab3.ToString() +
                     "," + "LabValue4 = " + value2.ToString() +
                     "," + "LabVselect = " + Labselect +
                     "," + "Remark1 =" + txt_remark1.Text.Trim() +
                     "," + "Remark2 =" + txt_remark2.Text.Trim() +
                     "," + "EmployeeID = " + Program.user_id +
                     "," + "Where TicketCodeIn = " + Ticket_code;

                            Log_OldValue = "-";

                            Send_lineAlert();
                            Load_SaveProcess();
                        }
                    }

                    //if (DisctPrice == 0)
                    //{                
                    //    if (dgv_dataconfirm.Rows[i].Cells[7].Value.ToString() != "" && dgv_dataconfirm.Rows[i].Cells[8].Value.ToString() == "2")
                    //    {
                    //        DiscutVusual += Convert.ToDecimal(dgv_dataconfirm.Rows[i].Cells[7].Value.ToString());
                    //    }
                    //}

                    //con.Open();                    


                    if (id_confirmLevel == 1) /// insert  ครั้งที่ 1
                    {
                        if (dgv_dataconfirm.Rows[i].Cells[6].Value.ToString() != "")
                        {
                            int Count_VsLog = 0;

                            con.Open();
                            string sql20 = "SELECT Count(TicketCodeIn)AS CountCheck FROM [dbo].[TB_VisualLog] WHERE [TicketCodeIn] = '" + Ticket_code + "' AND [LabID] =" + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString() + " ";
                            SqlCommand CM20 = new SqlCommand(sql20, con);
                            SqlDataReader DR20 = CM20.ExecuteReader();

                            DR20.Read();
                            {
                                try
                                {
                                    Count_VsLog = Convert.ToInt16(DR20["CountCheck"].ToString());
                                }
                                catch { con.Close(); }
                            }
                            DR20.Close();
                            con.Close();

                            if (Count_VsLog == 0)
                            {
                                con1.Open();
                                string sql30 = "Insert Into [TB_VisualLog] ([TicketCodeIn],[LabID],[LabValue])  Values ('" + Ticket_code + "'," + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString() + "," + Convert.ToDecimal(dgv_dataconfirm.Rows[i].Cells[6].Value.ToString()) + ")";
                                SqlCommand CM30 = new SqlCommand(sql30, con1);
                                SqlDataReader DR30 = CM30.ExecuteReader();
                                con1.Close();
                            }

                        }
                       
                        double Lab1_1L = 0;
                        double Lab2_1L = 0;
                        double Lab1_2L = 0;
                        double Lab2_2L = 0;
                        double Lab_totalL = 0;


                        if (dgv_dataconfirm.Rows[i].Cells[2].Value.ToString() != "")
                        { Lab1_1L = Convert.ToDouble(dgv_dataconfirm.Rows[i].Cells[2].Value.ToString()); }
                        if (dgv_dataconfirm.Rows[i].Cells[3].Value.ToString() != "")
                        { Lab2_1L = Convert.ToDouble(dgv_dataconfirm.Rows[i].Cells[3].Value.ToString()); }
                        if (dgv_dataconfirm.Rows[i].Cells[4].Value.ToString() != "")
                        { Lab1_2L = Convert.ToDouble(dgv_dataconfirm.Rows[i].Cells[4].Value.ToString()); }
                        if (dgv_dataconfirm.Rows[i].Cells[5].Value.ToString() != "")
                        { Lab2_2L = Convert.ToDouble(dgv_dataconfirm.Rows[i].Cells[5].Value.ToString()); }
                        if (dgv_dataconfirm.Rows[i].Cells[6].Value.ToString() != "")
                        { Lab_totalL = Convert.ToDouble(dgv_dataconfirm.Rows[i].Cells[6].Value.ToString()); }
                        if (dgv_dataconfirm.Rows[i].Cells[7].Value.ToString() != "")
                        {
                            if (dgv_dataconfirm.Rows[i].Cells[7].Value.ToString() != "-" && dgv_dataconfirm.Rows[i].Cells[8].Value.ToString() == "2")
                            {
                                Log_dicutL += Convert.ToDouble(dgv_dataconfirm.Rows[i].Cells[7].Value.ToString());
                            }

                             if (dgv_dataconfirm.Rows[i].Cells[7].Value.ToString() != "-")
                            {
                                Lab_dicutL = Convert.ToDouble(dgv_dataconfirm.Rows[i].Cells[7].Value.ToString());
                            }

                        }

                        if (chk_normalMode.Checked == true)
                        {
                            int Count_LogConfirmPay = 0;
                            con.Open();
                            string sql20 = "SELECT Count(TicketCodeIn)AS CountCheck FROM [dbo].[TB_LogConfirmPay] WHERE [TicketCodeIn] = '" + Ticket_code + "' AND [LabID] =" + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString() + " ";
                            SqlCommand CM20 = new SqlCommand(sql20, con);
                            SqlDataReader DR20 = CM20.ExecuteReader();

                            DR20.Read();
                            {
                                try
                                {
                                    Count_LogConfirmPay = Convert.ToInt16(DR20["CountCheck"].ToString());
                                }
                                catch { }
                            }
                            DR20.Close();
                            con.Close();

                            if (Count_LogConfirmPay == 0)
                            {
                                con1.Open();
                                string sql5 = "Insert Into [TB_LogConfirmPay] ([TicketCodeIn],[LabID],[Lab1_1],[Lab2_1],[Lab1_2],[Lab2_2],[Lab_total],[Lab_dicut])  Values ('" + Ticket_code + "'," + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString() + "," + Lab1_1L.ToString("F") + "," + Lab2_1L.ToString("F") + " ," + Lab1_2L.ToString("F") + "," + Lab2_2L.ToString("F") + "," + Lab_totalL.ToString("F") + "," + Lab_dicutL.ToString("F") + ")";
                                SqlCommand CM3 = new SqlCommand(sql5, con1);
                                SqlDataReader DR3 = CM3.ExecuteReader();
                                con1.Close();
                              
                            }

                            else
                            {

                                con1.Open();
                                string sql5 = "Update [TB_LogConfirmPay] SET [Lab1_1]=" + Lab1_1L.ToString("F") + ",[Lab2_1]=" + Lab2_1L.ToString("F") + ",[Lab1_2]=" + Lab1_2L.ToString("F") + ",[Lab2_2]=" + Lab2_2L.ToString("F") + ",[Lab_total]=" + Lab_totalL.ToString("F") + ",[Lab_dicut] =" + Lab_dicutL.ToString("F") + " WHERE [TicketCodeIn] = '" + Ticket_code + "' AND  [LabID] =" + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString() + "";
                                SqlCommand CM5 = new SqlCommand(sql5, con1);
                                SqlDataReader DR5 = CM5.ExecuteReader();
                                con1.Close();
                            }

                            con1.Open();
                            string sql51 = "Update [TB_LabConfirmPay] SET [DiscutValue] =" + Log_dicutL.ToString("F") + " WHERE [TicketCodeIn] = '" + Ticket_code + "' ";
                            SqlCommand CM31 = new SqlCommand(sql51, con1);
                            SqlDataReader DR31 = CM31.ExecuteReader();
                            con1.Close();

                        }

                        else
                        {
                            con1.Open();
                            string sql5 = "Update [TB_LogConfirmPay] SET [Lab1_1]=" + Lab1_1L.ToString("F") + ",[Lab2_1]=" + Lab2_1L.ToString("F") + ",[Lab1_2]=" + Lab1_2L.ToString("F") + ",[Lab2_2]=" + Lab2_2L.ToString("F") + ",[Lab_total]=" + Lab_totalL.ToString("F") + ",[Lab_dicut] =" + Lab_dicutL.ToString("F") + " WHERE [TicketCodeIn] = '" + Ticket_code + "' AND [LabID] =" + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString() + " ";
                            SqlCommand CM3 = new SqlCommand(sql5, con1);
                            SqlDataReader DR3 = CM3.ExecuteReader();
                            con1.Close();

                            con1.Open();
                            string sql51 = "Update [TB_LabConfirmPay] SET [DiscutValue] =" + Log_dicutL.ToString("F") + " WHERE [TicketCodeIn] = '" + Ticket_code + "' ";
                            SqlCommand CM31 = new SqlCommand(sql51, con1);
                            SqlDataReader DR31 = CM31.ExecuteReader();
                            con1.Close();
                        }

                        
                    }

                    if (id_confirmLevel == 2) /// insert  ครั้งที่ 2
                    {
                        if (dgv_dataconfirm.Rows[i].Cells[6].Value.ToString() != "")
                        {
                            int Count_VsLog = 0;

                            con.Open();
                            string sql20 = "SELECT Count(TicketCodeIn)AS CountCheck FROM [dbo].[TB_VisualLog] WHERE [TicketCodeIn] = '" + Ticket_code + "' AND [LabID] =" + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString() + " ";
                            SqlCommand CM20 = new SqlCommand(sql20, con);
                            SqlDataReader DR20 = CM20.ExecuteReader();

                            DR20.Read();
                            {
                                try
                                {
                                    Count_VsLog = Convert.ToInt16(DR20["CountCheck"].ToString());
                                }
                                catch { con.Close(); }
                            }
                            DR20.Close();
                            con.Close();

                            if (Count_VsLog == 0)
                            {
                                con1.Open();
                                string sql30 = "Insert Into [TB_VisualLog] ([TicketCodeIn],[LabID],[LabValue])  Values ('" + Ticket_code + "'," + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString() + "," + Convert.ToDecimal(dgv_dataconfirm.Rows[i].Cells[6].Value.ToString()) + ")";
                                SqlCommand CM30 = new SqlCommand(sql30, con1);
                                SqlDataReader DR30 = CM30.ExecuteReader();
                                con1.Close();
                            }

                            else
                            {
                                con1.Open();
                                string sql30 = "Update [TB_VisualLog] Set [LabValue] = " + Convert.ToDecimal(dgv_dataconfirm.Rows[i].Cells[6].Value.ToString()) + " Where [TicketCodeIn] = '" + Ticket_code + "' AND [LabID] =" + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString() + " ";
                                SqlCommand CM30 = new SqlCommand(sql30, con1);
                                SqlDataReader DR30 = CM30.ExecuteReader();
                                con1.Close();
                            }

                        }

                        //Save Log configrm
                        //con1.Open();
                        double Lab1_1L = 0;
                        double Lab2_1L = 0;
                        double Lab1_2L = 0;
                        double Lab2_2L = 0;
                        double Lab_totalL = 0;
               
                        if (dgv_dataconfirm.Rows[i].Cells[2].Value.ToString() != "")
                        { Lab1_1L = Convert.ToDouble(dgv_dataconfirm.Rows[i].Cells[2].Value.ToString()); }
                        if (dgv_dataconfirm.Rows[i].Cells[3].Value.ToString() != "")
                        { Lab2_1L = Convert.ToDouble(dgv_dataconfirm.Rows[i].Cells[3].Value.ToString()); }
                        if (dgv_dataconfirm.Rows[i].Cells[4].Value.ToString() != "")
                        { Lab1_2L = Convert.ToDouble(dgv_dataconfirm.Rows[i].Cells[4].Value.ToString()); }
                        if (dgv_dataconfirm.Rows[i].Cells[5].Value.ToString() != "")
                        { Lab2_2L = Convert.ToDouble(dgv_dataconfirm.Rows[i].Cells[5].Value.ToString()); }
                        if (dgv_dataconfirm.Rows[i].Cells[6].Value.ToString() != "")
                        { Lab_totalL = Convert.ToDouble(dgv_dataconfirm.Rows[i].Cells[6].Value.ToString()); }
                        if (dgv_dataconfirm.Rows[i].Cells[7].Value.ToString() != "")
                        {
                            if (dgv_dataconfirm.Rows[i].Cells[7].Value.ToString() != "-" && dgv_dataconfirm.Rows[i].Cells[8].Value.ToString() == "2")
                            {
                                Log_dicutL += Convert.ToDouble(dgv_dataconfirm.Rows[i].Cells[7].Value.ToString());

                            }

                            if (dgv_dataconfirm.Rows[i].Cells[7].Value.ToString() != "-" )
                            {
                                Lab_dicutL = Convert.ToDouble(dgv_dataconfirm.Rows[i].Cells[7].Value.ToString());
                            }

                        }


                        if (chk_normalMode.Checked == true)
                        {
                            int Count_LogConfirmPay = 0;
                            con.Open();
                            string sql20 = "SELECT Count(TicketCodeIn)AS CountCheck FROM [dbo].[TB_LogConfirmPay] WHERE [TicketCodeIn] = '" + Ticket_code + "' AND [LabID] =" + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString() + " ";
                            SqlCommand CM20 = new SqlCommand(sql20, con);
                            SqlDataReader DR20 = CM20.ExecuteReader();

                            DR20.Read();
                            {
                                try
                                {
                                    Count_LogConfirmPay = Convert.ToInt16(DR20["CountCheck"].ToString());
                                }
                                catch { }
                            }
                            DR20.Close();
                            con.Close();

                            if (Count_LogConfirmPay == 0)
                            {
                                con1.Open();
                                string sql5 = "Insert Into [TB_LogConfirmPay] ([TicketCodeIn],[LabID],[Lab1_1],[Lab2_1],[Lab1_2],[Lab2_2],[Lab_total],[Lab_dicut])  Values ('" + Ticket_code + "'," + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString() + "," + Lab1_1L.ToString("F") + "," + Lab2_1L.ToString("F") + " ," + Lab1_2L.ToString("F") + "," + Lab2_2L.ToString("F") + "," + Lab_totalL.ToString("F") + "," + Lab_dicutL.ToString("F") + ")";
                                SqlCommand CM3 = new SqlCommand(sql5, con1);
                                SqlDataReader DR3 = CM3.ExecuteReader();
                                con1.Close();
                            }

                            else
                            {

                                con1.Open();
                                string sql5 = "Update [TB_LogConfirmPay] SET [LabID] =" + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString() + ",[Lab1_1]=" + Lab1_1L.ToString("F") + ",[Lab2_1]=" + Lab2_1L.ToString("F") + ",[Lab1_2]=" + Lab1_2L.ToString("F") + ",[Lab2_2]=" + Lab2_2L.ToString("F") + ",[Lab_total]=" + Lab_totalL.ToString("F") + ",[Lab_dicut] =" + Lab_dicutL.ToString("F") + " WHERE [TicketCodeIn] = '" + Ticket_code + "'  AND [LabID] =" + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString() + " ";
                                SqlCommand CM5 = new SqlCommand(sql5, con1);
                                SqlDataReader DR5 = CM5.ExecuteReader();
                                con1.Close();
                               
                            }


                            con1.Open();
                            //string sql51 = "Update [TB_LabConfirmPay] SET [DiscutValue] =" + Lab_dicutL + " WHERE [TicketCodeIn] = '" + Ticket_code + "' ";
                            string sql51 = "Update [TB_LabConfirmPay] SET  LabValue1 = " + Lab1_1L.ToString("F") + ",LabValue2 = " + Lab2_1L.ToString("F") + ",LabValue3 = " + Lab1_2L.ToString("F") + ",LabValue4 = " + Lab2_2L.ToString("F") + ",[DiscutValue] =" + Log_dicutL.ToString("F") + ",[LabVselect]=" + Lab_totalL.ToString("F") + ",[Remark1]='" + txt_remark1.Text.Trim() + "',[Remark2]='" + txt_remark2.Text.Trim() + "',[DateTime_Confirm]='" + date + "',[EmployeeID]='" + Program.user_id + "' WHERE [TicketCodeIn] = '" + Ticket_code + "' ";
                            SqlCommand CM31 = new SqlCommand(sql51, con1);
                            SqlDataReader DR31 = CM31.ExecuteReader();
                            con1.Close();

                        }

                        else
                        {
                            int Count_LogConfirmPay = 0;
                            con.Open();
                            string sql20 = "SELECT Count(TicketCodeIn)AS CountCheck FROM [dbo].[TB_LogConfirmPay] WHERE [TicketCodeIn] = '" + Ticket_code + "' AND [LabID] =" + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString() + " ";
                            SqlCommand CM20 = new SqlCommand(sql20, con);
                            SqlDataReader DR20 = CM20.ExecuteReader();

                            DR20.Read();
                            {
                                try
                                {
                                    Count_LogConfirmPay = Convert.ToInt16(DR20["CountCheck"].ToString());
                                }
                                catch { con.Close(); }
                            }
                            DR20.Close();
                            con.Close();

                            if (Count_LogConfirmPay == 0)
                            {
                                con1.Open();
                                string sql = "Insert Into [TB_LogConfirmPay] ([TicketCodeIn],[LabID],[Lab1_1],[Lab2_1],[Lab1_2],[Lab2_2],[Lab_total],[Lab_dicut])  Values ('" + Ticket_code + "'," + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString() + "," + Lab1_1L.ToString("F") + "," + Lab2_1L.ToString("F") + " ," + Lab1_2L.ToString("F") + "," + Lab2_2L.ToString("F") + "," + Lab_totalL.ToString("F") + "," + Lab_dicutL.ToString("F") + ")";
                                SqlCommand CM51 = new SqlCommand(sql, con1);
                                SqlDataReader DR51 = CM51.ExecuteReader();
                                con1.Close();
                            }

                            else
                            {

                                con1.Open();
                                string sql = "Update [TB_LogConfirmPay] SET [Lab1_1]=" + Lab1_1L.ToString("F") + ",[Lab2_1]=" + Lab2_1L.ToString("F") + ",[Lab1_2]=" + Lab1_2L.ToString("F") + ",[Lab2_2]=" + Lab2_2L.ToString("F") + ",[Lab_total]=" + Lab_totalL.ToString("F") + ",[Lab_dicut] =" + Lab_dicutL.ToString("F") + " WHERE [TicketCodeIn] = '" + Ticket_code + "' AND [LabID] =" + dgv_dataconfirm.Rows[i].Cells[0].Value.ToString() + " ";
                                SqlCommand CM5 = new SqlCommand(sql, con1);
                                SqlDataReader DR5 = CM5.ExecuteReader();
                                con1.Close();


                                if (i == 0)
                                {
                                    con1.Open();
                                    string sql51 = "Update [TB_LabConfirmPay] SET  LabValue1 = " + Lab1_1L.ToString("F") + ",LabValue2 = " + Lab2_1L.ToString("F") + ",LabValue3 = " + Lab1_2L.ToString("F") + ",LabValue4 = " + Lab2_2L.ToString("F") + ",[LabVselect]=" + Lab_totalL.ToString("F") + ",[PriceExtra]=" + PriceExtra + ",[Remark1]='" + txt_remark1.Text.Trim() + "',[Remark2]='" + txt_remark2.Text.Trim() + "',[DateTime_Confirm]='" + date + "',[EmployeeID]='" + Program.user_id + "' WHERE [TicketCodeIn] = '" + Ticket_code + "' ";
                                    SqlCommand CM31 = new SqlCommand(sql51, con1);
                                    SqlDataReader DR31 = CM31.ExecuteReader();
                                    con1.Close();
                                }


                                con1.Open();
                                string sql61 = "Update [TB_LabConfirmPay] SET  [DiscutValue] =" + Log_dicutL.ToString("F") + " WHERE [TicketCodeIn] = '" + Ticket_code + "' ";
                                SqlCommand CM61 = new SqlCommand(sql61, con1);
                                SqlDataReader DR61 = CM61.ExecuteReader();
                                con1.Close();
                            }

                        }                              

                    }

                     DisctPrice = 0;

                }


                //if (DiscutVusual != 0)
                //{
                //con.Open();
                //string sql4 = "Update [TB_LabConfirmPay] Set [DiscutValue]=" + DiscutVusual + " Where [TicketCodeIn] = '" + Ticket_code + "'";
                //SqlCommand CM4 = new SqlCommand(sql4, con);
                //SqlDataReader DR4 = CM4.ExecuteReader();
                //con.Close();

                Class_Log CL = new Class_Log();
                CL.tbname = Msg;
                CL.oldvalue = Log_OldValue;
                CL.newvalue = Log_NewValue;
                CL.Save_log();

                //}

                Save_FollowProcess();
                //con.Close();  
                MessageBox.Show("บันทึกสำเร็จ!!", "รายงานการบันทึก", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_Datatruck();
                dgv_dataconfirm.DataSource = null;
                dgv_cal.DataSource = null;
                dgv_datalab.DataSource = null;
                dgv_datavisual.DataSource = null;                
                

            }
            //}


            //catch
            //{
            //    MessageBox.Show("คุณใส่รูปแบบข้อมูลไม่ถูกต้อง", "รูปแบบข้อมูลผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //txt_value.ForeColor = Color.Red;
            //    //txt_value.Focus();
            //}

            //}


            //else { MessageBox.Show("ข้อมูลผลวิเคราะห์ยังบันทึกไม่ครบ","การยืนยันผิดพลาด!!!!",MessageBoxButtons.OK,MessageBoxIcon.Error); }

        }

        private void Clear_smsLine()
        {
            Sum_visual = 0;

            Lab1_Name = "";
            Lab1_1 = "";
            Lab1_2 = "";
            Lab1_3 = "";
            Lab1_4 = "";
            Lab1_5 = "";
            Lab1_6 = "";

            Lab2_Name = "";
            Lab2_1 = "";
            Lab2_2 = "";
            Lab2_3 = "";
            Lab2_4 = "";
            Lab2_5 = "";
            Lab2_6 = "";

            Lab3_Name = "";
            Lab3_1 = "";
            Lab3_2 = "";
            Lab3_3 = "";
            Lab3_4 = "";
            Lab3_5 = "";
            Lab3_6 = "";

            Lab4_Name = "";
            Lab4_1 = "";
            Lab4_2 = "";
            Lab4_3 = "";
            Lab4_4 = "";
            Lab4_5 = "";
            Lab4_6 = "";

            Lab5_Name = "";
            Lab5_1 = "";
            Lab5_2 = "";
            Lab5_3 = "";
            Lab5_4 = "";
            Lab5_5 = "";
            Lab5_6 = "";

            Lab6_Name = "";
            Lab6_1 = "";
            Lab6_2 = "";
            Lab6_3 = "";
            Lab6_4 = "";
            Lab6_5 = "";
            Lab6_6 = "";
        }

        private void Save_FollowProcess()
        {
            try
            {
                // Save to data base
                //string date_time = Program.Date_Now + ' ' + Program.Time_Now;
                string Date_Now = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
                string Time_Now = DateTime.Now.ToString("HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));
                string date_time = Date_Now + ' ' + Time_Now;

                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string sql = "";
                if (id_confirmLevel == 1)  //ครั้งที่ 1
                {
                    if (Product_id != "RM-004")
                    {
                        sql = "Update [TB_FollowProcess] Set [Confirm_Simple1_Datetime] = '" + date_time + "' Where [TicketCodeIn] = '" + Ticket_code + "'";
                    }

                    else
                    {
                        sql = "Update [TB_FollowProcess] Set [Confirm_Simple2_Datetime] = '" + date_time + "' Where [TicketCodeIn] = '" + Ticket_code + "'";
                    }
                }

                if (id_confirmLevel == 2)  //คร้งที่ 2
                {
                    sql = "Update [TB_FollowProcess] Set [Confirm_Simple2_Datetime] = '" + date_time + "' Where [TicketCodeIn] = '" + Ticket_code + "'";
                }

                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();
            }

            catch
            {
                //MessageBox.Show("ข้อมูลยังไม่ครบ กรุณาตรวจสอบอีกครั้ง", "ข้อมูลผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void dgv_datatruck_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               // MessageBox.Show(dgv_datatruck.Rows[e.RowIndex].Cells[0].Value.ToString());

                //if ((bool)dgv_datatruck.Rows[e.RowIndex].Cells[0].Value == false)
                //{
                //    MessageBox.Show("false");
                //}
            }

            catch { }
        }
                    

        private void dgv_datalab_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Status_Edit == 1)  //truck weight
                {
                    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                    con.ConnectionString = Program.pathdb_Weight;
                    SqlDataAdapter dtAdapter = new SqlDataAdapter();

                    int id_change = 0;
                    if (dgv_datalab.Rows[e.RowIndex].Cells[0].Value.ToString() == "True")
                    {
                        id_change = 1;
                    }

                    con.Open();

                    string sql = "Update [TB_LabData] Set [InActive] = " + id_change + " WHERE [LOGID]='" + dgv_datalab.Rows[e.RowIndex].Cells[6].Value.ToString().Trim() + "'";
                    SqlCommand CM2 = new SqlCommand(sql, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    con.Close();

                    Status_Edit = 0;

                    Load_DataLab();   //ดึงข้อมูลที่บันทึกจากเครื่องมือ lab
                    Load_DataVisual(); //ดึงข้อมูลที่บันทึกจาก visual
                    Load_Cal(); // จัดขอ้มูลในแนวตั้งแนวนอน ตามตัวอย่างใหม่
                    Load_DataConfirm();  //สร้างเมนูจาก Visual Lab มาที่ Data confirm Lab
                    Load_Function_Cal();  //คำนวนสัดส่วน weithg น้ำหนัก แม่ ลูก จากการเลือกแบบ เฉลี่ย หรือ แบบค่าสูงสุดต่ำสุด
                    Load_Visual();   //คำนวนผลที่ได้จาก  ตาราง visul มาใส่ในตาราง ยืนยันผลวิเคราะห์
                    Load_GetData_SQL();
                    Load_DataLine();
                    CheckBtnSave();
                }

                else { MessageBox.Show("สิทธ์การแก้ไขไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานยืนยันผลวิเคราะห์)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
            catch { }
        }
        
        private void dgv_datavisual_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{

            if (Status_Edit == 1)
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

                int id_change = 0;
                if (dgv_datavisual.Rows[e.RowIndex].Cells[0].Value.ToString() == "True")
                {
                    id_change = 1;
                }

                con.Open();

                string sql = "Update [TB_VisualData] Set [VSActive] = " + id_change + " WHERE [VisualIndex]='" + dgv_datavisual.Rows[e.RowIndex].Cells[8].Value.ToString().Trim() + "' AND [LabID]='" + dgv_datavisual.Rows[e.RowIndex].Cells[1].Value.ToString().Trim() + "' ";
                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();

                Status_Edit = 0;

                Load_DataLab();   //ดึงข้อมูลที่บันทึกจากเครื่องมือ lab
                Load_DataVisual(); //ดึงข้อมูลที่บันทึกจาก visual
                Load_Cal(); // จัดขอ้มูลในแนวตั้งแนวนอน ตามตัวอย่างใหม่
                Load_DataConfirm();  //สร้างเมนูจาก Visual Lab มาที่ Data confirm Lab
                Load_Function_Cal();  //คำนวนสัดส่วน weithg น้ำหนัก แม่ ลูก จากการเลือกแบบ เฉลี่ย หรือ แบบค่าสูงสุดต่ำสุด
                Load_Visual();   //คำนวนผลที่ได้จาก  ตาราง visul มาใส่ในตาราง ยืนยันผลวิเคราะห์
                Load_GetData_SQL();
                CheckBtnSave();
                Check_Value();
            }

            //else { MessageBox.Show("สิทธ์การแก้ไขไม่ได้ถูกเปิดใช้งานเมนูนี้ กรูณาตรวจสอบกับผู้ดูแลระบบ (งานยืนยันผลวิเคราะห์)", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            //}
            //catch { }
        }

        private void dgv_datalab_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Status_Edit = 1;
            }
        }

        private void dgv_datavisual_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Status_Edit = 1;
            }
        }

        private void txt_qrcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==13)
            {
                //MessageBox.Show(txt_qrcode.Text);

                if (chk_normalMode.Checked == true)
                {
                    
                    int icheck = 0;
                    Ticket_code = txt_qrcode.Text.Trim();
                    Load_InformationLine();

                    for (int i = 0; i < dgv_datatruck.RowCount; i++)
                    {
                        if (txt_qrcode.Text.Trim() == dgv_datatruck.Rows[i].Cells[2].Value.ToString().Trim())
                        {
                            dgv_datatruck.Rows[i].Selected = true;

                            //dgv_datatruck.Rows[i].Cells[0].Value = true;                        //dgv_datatruck_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
                            //this.button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                            e_RowIndex = i;
                            Load_DataTruck();
                            Load_DataLine();

                            Data_ReadySave = 1;
                            Confirm_DATALab();
                            icheck = 1;
                            txt_qrcode.Clear();
                            txt_qrcode.Focus();
                        }

                        else { dgv_datatruck.Rows[i].Selected = false; }
                        //   else { MessageBox.Show("ไม่มีข้อมูลที่จะยืนยันผลการบันทึก กรุณาตรวจสอบรหัสตัวอย่าง", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                        //txt_qrcode.Clear();

                    }

                    if (icheck == 0)
                    {
                        { MessageBox.Show("ไม่มีข้อมูลที่จะยืนยันผลการบันทึก กรุณาตรวจสอบรหัสตัวอย่าง", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }

                else
                {
                   
                    if (STS_Mode == 1)
                    {
                        Load_DataTruck();
                        Load_LabConfirm();
                    }                    
                }


                //Confirm_DATALab();
            }
        }


        private void Load_LabConfirm()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            Ticket_code = txt_qrcode.Text.Trim();

            string sql1 = "Select [Remark2] From  [dbo].[TB_LabConfirmPay] Where [TicketCodeIn] ='" + Ticket_code + "'";

            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                txt_remark2.Text = DR1["Remark2"].ToString().Trim();   
            }
            DR1.Close();
            con.Close();
        }       

        private void btn_report_Click(object sender, EventArgs e)
        {
            F_MainReport fmp = new F_MainReport();
            fmp.ShowDialog();
        }

        int refresh_data = Program.refresh_Data;
        private void timer1_Tick(object sender, EventArgs e)
        {
            tool_datetime.Text = "Login Date: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();

            if (refresh_data == 0)
            {
                refresh_data = Program.refresh_Data;
                Load_Datatruck();
            }
            else
            {
                refresh_data = refresh_data - 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refresh_data = Program.refresh_Data;

            dgv_cal.DataSource = null;
            dgv_datalab.DataSource = null;
            dgv_datavisual.DataSource = null;
            dgv_datatruck.DataSource = null;
            dgv_dataconfirm.DataSource = null;

            Load_Datatruck();
            dgv_datatruck.ClearSelection();
        }

        private void bnt_recheck_Click(object sender, EventArgs e)
        {
            F_RecheckData frdt = new F_RecheckData();
            frdt.ID_Recheck = 1;          
            frdt.ShowDialog();
        }

        private void dgv_datatruck_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void txt_qrcode_MouseClick(object sender, MouseEventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-us"));
        }

        private void chk_normalMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_normalMode.Checked == true)
            {
                chk_normalMode.Text = ":Normal Mode";
                chk_normalMode.ForeColor = Color.ForestGreen;
                STS_Mode = 0;
                btn_confirm.Enabled = true;
                dgv_datatruck.Enabled = true;
                txt_qrcode.Clear();
            }

            if (chk_normalMode.Checked == false)
            {
                chk_normalMode.Text = ":Edit Mode";
                chk_normalMode.ForeColor = Color.OrangeRed;
                STS_Mode = 1;
                btn_confirm.Enabled = false;
                dgv_datatruck.Enabled = false;
                id_confirmLevel = 2;
            }
        }
    }
}
