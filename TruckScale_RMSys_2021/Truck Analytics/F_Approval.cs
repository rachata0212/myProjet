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
using System.Globalization;
using System.Net.Mail;

namespace Truck_Analytics
{
    public partial class F_Approval : Form
    {
        public F_Approval()
        {
            InitializeComponent();
        }

        string Ticket_Code = "";
        string SimpleCode = "";
        string ProductID = "";
        int ID_STS_APP = 0;
        int StatusID=0;
        int ID_App = 0;
        string ipsvr = "";
        string mailport = "";
        string accalert = "";
        string addpwd = "";
        int ID_User = 0;
        string Email = "";
        string Date_Alert = "";
        string Vendor_Name = "";
        string Truck_No = "";
        int E_Rowindex;

        private void F_Approval_Load(object sender, EventArgs e)
        {
            int Fw = this.Width;
            int SC = Fw / 5;

            dgv_datatruck.Width = SC * 3;

            //dgv_datatruck.Columns[6].Width = 100;
            //dgv_datatruck.Columns[8].Width = 120;

            Load_Data_PendingApp();
        }
        private void Load_Data_PendingApp()
        {

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            DataSet ds1 = new DataSet();
            ds1.Clear();
            // string sql = "Select * From [dbo].[V_InuptLab] ";
            string sql1 = "Select[ID_App] AS 'เลขอนุมัติ',[CreateDate] AS 'วันที่แจ้ง',[TicketCodeIn] AS 'เลขที่ชั่ง',[QueueNo] AS 'คิวที่',[Names] AS 'ชื่อผู้ขาย',[Plate1] AS 'ทะเบียน',[ProductName] AS 'สินค้า',[proc_name] AS 'ขั้นตอน',[SimpleCode],[ProductID],[StatusID] FROM  [dbo].[V_Approval] WHERE [ID_UserApp]='" + Program.user_id + "' AND [Ststus_App] is Null";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);

            da1.Fill(ds1,"g_l");
            dgv_datatruck.DataSource = ds1.Tables["g_l"];

            dgv_datatruck.Columns[0].Width = 70;
            dgv_datatruck.Columns[1].Width = 80;
            dgv_datatruck.Columns[2].Width = 160;
            dgv_datatruck.Columns[3].Width = 120;
            dgv_datatruck.Columns[4].Width = 60;
            dgv_datatruck.Columns[5].Width = 180;
            dgv_datatruck.Columns[9].Width = 0;
            dgv_datatruck.Columns[10].Width = 0;
            dgv_datatruck.Columns[11].Width = 0;


        }

        private void Load_Data_HistoryApp()
        {

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            DataSet ds1 = new DataSet();
            ds1.Clear();
            // string sql = "Select * From [dbo].[V_InuptLab] ";
            string sql1 = "Select[ID_App] AS 'เลขอนุมัติ',[Date_App] AS 'วันที่อนุมัติ',[TicketCodeIn] AS 'เลขที่ชั่ง',[QueueNo] AS 'คิวที่',[Names] AS 'ชื่อผู้ขาย',[Plate1] AS 'ทะเบียน',[ProductName] AS 'สินค้า',[Ststus_App] AS 'สถานะอนุมัติ',[SimpleCode],[ProductID] FROM [dbo].[V_Approval] WHERE [ID_UserApp]='" + Program.user_id + "' AND [Ststus_App] is not Null";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);

            da1.Fill(ds1, "g_l");
            dgv_datatruck.DataSource = ds1.Tables["g_l"];

            dgv_datatruck.Columns[0].Width = 0;
            dgv_datatruck.Columns[1].Width = 80;
            dgv_datatruck.Columns[2].Width = 160;
            dgv_datatruck.Columns[3].Width = 120;
            dgv_datatruck.Columns[4].Width = 60;
            dgv_datatruck.Columns[5].Width = 180;
            dgv_datatruck.Columns[9].Width = 0;
            dgv_datatruck.Columns[10].Width = 0;         
            dgv_datatruck.Columns[8].ReadOnly = true;
        }

        private void dgv_datatruck_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                E_Rowindex = e.RowIndex;

                if (rdo_appnow.Checked == true)
                {
                    E_Rowindex = e.RowIndex;
                    ID_App = Convert.ToInt16(dgv_datatruck.Rows[e.RowIndex].Cells[1].Value.ToString().Trim());
                    Date_Alert = dgv_datatruck.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                    Ticket_Code = dgv_datatruck.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                    Vendor_Name = dgv_datatruck.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
                    Truck_No = dgv_datatruck.Rows[e.RowIndex].Cells[6].Value.ToString().Trim();
                    SimpleCode = dgv_datatruck.Rows[e.RowIndex].Cells[9].Value.ToString().Trim();
                    ProductID = dgv_datatruck.Rows[e.RowIndex].Cells[10].Value.ToString().Trim();
                    StatusID = Convert.ToInt16(dgv_datatruck.Rows[e.RowIndex].Cells[11].Value.ToString().Trim());
                }

                if (radioButton1.Checked == true)
                {
                    ID_App = Convert.ToInt16(dgv_datatruck.Rows[e.RowIndex].Cells[1].Value.ToString().Trim());
                    Date_Alert = dgv_datatruck.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                    Ticket_Code = dgv_datatruck.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                    Vendor_Name = dgv_datatruck.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
                    Truck_No = dgv_datatruck.Rows[e.RowIndex].Cells[6].Value.ToString().Trim();
                    SimpleCode = dgv_datatruck.Rows[e.RowIndex].Cells[9].Value.ToString().Trim();
                    ProductID = dgv_datatruck.Rows[e.RowIndex].Cells[10].Value.ToString().Trim();
                }
                Load_DataLab();
                Load_DataVisual();
            }
            catch { }
        }


        private void Load_DataVisual()
        {
            //
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            // string sql = "Select * From [dbo].[V_InuptLab] ";
            string sql1 = "SELECT [LabID] AS 'รหัส',[LabName] AS 'รายการ',[ValueName] AS 'ผล',[ValueCal] AS 'ค่า',[SimpleCode] AS 'ตัวอย่าง',[LabOpserv] AS 'OFI',[VisualShowRemark] AS 'RM',[VisualIndex] AS 'VSID' FROM  [dbo].[V_DataVisual_Confirm] WHERE [TicketCodeIn] = '" + Ticket_Code + "' AND [SimpleCode]='" + SimpleCode + "' ORDER BY [LabID]";
            // string sql1 = "SELECT [VisualType],[VisualName] AS 'รายการวิเคราะห์',[Value1] AS 'ผลวิเคราะห์','' AS 'ค่าที่คิด',[SimpleCode] AS 'วิเคราะห์ครั้งที่','' AS 'หมายเหตุ' FROM  [dbo].[V_DataVisual_Confirm] WHERE [TicketCodeIn] = '" + Ticket_code + "' AND [VisualTypeActive]=1  ORDER BY [SimpleCode]";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "g_visual");
            dgv_datavisual.DataSource = ds1.Tables["g_visual"];
            con.Close();
            dgv_datavisual.Columns[0].Width = 50;
            dgv_datavisual.Columns[2].Width = 60;
            dgv_datavisual.Columns[3].Width = 80;
            //dgv_datavisual.Columns[3].Width = 60;
            //dgv_datavisual.Columns[4].Width = 60;
            dgv_datavisual.Columns[5].Width = 0;
            dgv_datavisual.Columns[6].Width = 0;
            dgv_datavisual.Columns[7].Width = 0;


            tool_countvisual.Text = "";
            tool_countvisual.Text = "จำนวน: " + dgv_datavisual.RowCount.ToString() + " ข้อมูล ";

            for (int i = 0; i < dgv_datavisual.RowCount; i++)
            {
                con.Open();
                string sql = "  SELECT Count([ValueVisualNo]) AS 'Check'  FROM  [dbo].[V_AlertSMG_Visual]  Where [LabID]=" + dgv_datavisual.Rows[i].Cells[0].Value.ToString() + " and [ID_User]=" + Program.user_id + " AND [Value1]= " + dgv_datavisual.Rows[i].Cells[3].Value.ToString() + "";
                SqlCommand CM1 = new SqlCommand(sql, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    if (DR1["Check"].ToString().Trim() != "0")
                    {
                        dgv_datavisual.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
                DR1.Close();
                con.Close();
            }

            dgv_datavisual.ClearSelection();
        }

        private void Load_DataLab()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open(); DataSet ds1 = new DataSet();

            // string sql = "Select * From [dbo].[V_InuptLab] ";
            string sql = "SELECT [LabID] AS 'รหัส',[LabName] AS 'รายการ' ,[ValueLab] AS 'ผล',[SimpleCode] AS 'เลขที่ตัวอย่าง',[LabCode] AS 'วิเคราะห์ครั้งที่',[LOGID] FROM  [dbo].[V_DataLab_Confirm] WHERE [TicketCodeIn]='" + Ticket_Code + "' AND [TypePno]=1 AND [Dilldata]=0 AND [LabCode]='" + SimpleCode + "' ORDER BY [LabID]";
            SqlDataAdapter da1 = new SqlDataAdapter(sql, con);    

            da1.Fill(ds1, "g_lab");
            dgv_datalab.DataSource = ds1.Tables["g_lab"];

            dgv_datalab.Columns[0].Width = 50;
            dgv_datalab.Columns[1].Width = 80;
            dgv_datalab.Columns[2].Width = 60;
            //dgv_datalab.Columns[3].Width = 50;
            //dgv_datalab.Columns[4].Width = 120;
            dgv_datalab.Columns[5].Width = 0;            
            con.Close();

            tool_countlab.Text = "";
            tool_countlab.Text = "จำนวน: " + dgv_datalab.RowCount.ToString() + " ข้อมูล ";

            for (int i = 0; i < dgv_datalab.RowCount; i++)
            {
                double v_min = 0;
                double v_max = 0;

                try
                {
                    con.Open();
                    string sql1 = "  SELECT top(1) [Min]  FROM  [dbo].[V_AlertSMG_Lab]  Where [LabID]=" + dgv_datalab.Rows[i].Cells[0].Value.ToString() + " and [ID_User]=" + Program.user_id + " AND [App_Sts]=1  AND [Min] < " + dgv_datalab.Rows[i].Cells[2].Value.ToString() + " Order by [LOGID] desc ";

                    SqlCommand CM1 = new SqlCommand(sql1, con);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    {
                        v_min = Convert.ToDouble(DR1["Min"].ToString().Trim());
                    }
                    DR1.Close();
                    con.Close();
                }
                catch { }

                try
                {
                    con.Open();
                    string sql2 = "  SELECT  top(1) [Min]  FROM  [dbo].[V_AlertSMG_Lab]  Where [LabID]=" + dgv_datalab.Rows[i].Cells[0].Value.ToString() + " and [ID_User]=" + Program.user_id + " AND [App_Sts]=1 AND [Min] >= " + dgv_datalab.Rows[i].Cells[2].Value.ToString() + "  Order by [LOGID] desc ";
                    SqlCommand CM2 = new SqlCommand(sql2, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();

                    DR2.Read();
                    {
                        v_max = Convert.ToDouble(DR2["Min"].ToString().Trim());
                    }
                    DR2.Close();
                    con.Close();


                }

                catch { }

                if (v_max > v_min)
                {
                    dgv_datalab.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }

            dgv_datalab.ClearSelection();
            
        }

        private void rdo_appnow_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_appnow.Checked == true)
            {
                btn_approved.Enabled = true;
                btn_reject.Enabled = true;
                dgv_datalab.DataSource = null;
                dgv_datavisual.DataSource = null;
                Load_Data_PendingApp();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                btn_approved.Enabled = false;
                btn_reject.Enabled = false;
                dgv_datalab.DataSource = null;
                dgv_datavisual.DataSource = null;
                Load_Data_HistoryApp();

                dgv_datatruck.ClearSelection();
            }
        }

        private void btn_approved_Click(object sender, EventArgs e)
        {

            int id_Select = 0;
            foreach (DataGridViewRow row in dgv_datatruck.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells[0].Value);
                if (isSelected)
                {
                    id_Select = 1;
                }
            }

            if (id_Select==1)
            {
                DialogResult dr = MessageBox.Show("คุณต้องกาอนุมัติรับสินค้ารายการนี้ " + Ticket_Code + " ใช่หรือไม่", "ยืนยันข้อมูล", MessageBoxButtons.YesNo,
          MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    ID_STS_APP = 1;
                    Save_App();
                    dgv_datalab.DataSource = null;
                    dgv_datavisual.DataSource = null;
                }
            }

            else
            {
                MessageBox.Show("กรูณาทำเครื่องถูกในรายการที่ต้องการอนุมัติ", "ยืนยันข้อมูลผิดพลาด", MessageBoxButtons.OK,
       MessageBoxIcon.Error);
            }


        }

        private void btn_reject_Click(object sender, EventArgs e)
        {
            ///Step
            ///update database weithgData   filed     StatusID
            ///
            DialogResult dr = MessageBox.Show("คุณต้องการยกเลิกรับสินค้ารายการนี้ " + Ticket_Code + " ใช่หรือไม่", "ยืนยันข้อมูล", MessageBoxButtons.YesNo,
         MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                ID_STS_APP = 0;
                ID_User = 0;
                Save_App();
            }
        }

        private void Save_App()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter1 = new SqlDataAdapter();

            string date = Program.Date_Now + ' ' + Program.Time_Now;
           

            if (ID_STS_APP == 0)  //Status Cancel
            {

                con.Open();
                string sql = "Update[TB_Approved] Set [Ststus_App] = " + ID_STS_APP + ",[StatusID]=5 ,[Date_App] ='" + date + "' Where [TicketCodeIn] = '" + Ticket_Code + "'";
                SqlCommand CM = new SqlCommand(sql, con);
                SqlDataReader DR = CM.ExecuteReader();
                con.Close();

                int ID_Process = 0;
                con.Open();
                //SELECT [proc_no]  FROM  [dbo].[TB_Process]  Where [proc_type] ='C'
                string sql1 = "SELECT [proc_no]  FROM  [dbo].[TB_Process]  Where [proc_type] ='W' AND [proc_name]='รอชั่งออก' AND [item_no]='" + ProductID + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    // count = Convert.ToInt16(DR1["countidqua"].ToString().Trim());
                    ID_Process = Convert.ToInt16(DR1["proc_no"].ToString().Trim());
                }
                DR1.Close();
                con.Close();

                con.Open();
                string sql2 = "Update [TB_WeightData] Set  [StatusID]=5,[Process_id]=" + ID_Process + " Where [TicketCodeIn] = '" + Ticket_Code + "'";
                SqlCommand CM2 = new SqlCommand(sql2, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();
            }

            if (ID_STS_APP == 1)
            {
                ///Step
                /////update database weithgData   filed     StatusID   
                //StatusID++;       


                ///search user appproved next Level  Type Data Lab
                if (dgv_datalab.RowCount > 0)
                {
                    for (int i = 0; i < dgv_datalab.RowCount; i++)
                    {
                        if (dgv_datalab.Rows[i].DefaultCellStyle.BackColor == Color.Yellow)
                        {                          
                            //SELECT [proc_no]  FROM  [dbo].[TB_Process]  Where [proc_type] ='C'
                            int APP_LV = 0;
                            try
                            {
                                int Lv_now = 0;
                                double Value_min = 0;
                                int Lv_apmin = 0;
                                double Value_max = 0;
                                int Lv_apmax = 0;

                                con.Open();
                                string sql1 = "Select [Level_App] From [dbo].[V_AlertSMG_Lab] Where [ProductID]='" + ProductID + "' AND [ID_Frm_TypeLab]=1 AND [App_Sts]=1  AND [Status_RP]=1 AND LabID =" + dgv_datalab.Rows[i].Cells[0].Value.ToString().ToString() + " AND [ID_User]=" + Program.user_id + " AND [Min] <" + dgv_datalab.Rows[i].Cells[2].Value.ToString().ToString() + "";
                                SqlCommand CM1 = new SqlCommand(sql1, con);
                                SqlDataReader DR1 = CM1.ExecuteReader();
                                DR1.Read();
                                {
                                    Lv_now = Convert.ToInt16(DR1["Level_App"].ToString().Trim());
                                }                                
                                DR1.Close();
                                con.Close();

                                Lv_now++;
                                                              

                                //Check Value Min
                                try
                                {
                                    con.Open();
                                    string sql2 = "Select top(1)[Min],[Level_App] From [dbo].[V_AlertSMG_Lab] Where [ProductID]='" + ProductID + "' AND [ID_Frm_TypeLab]=1 AND [App_Sts]=1  AND [Status_RP]=1 AND LabID =" + dgv_datalab.Rows[i].Cells[0].Value.ToString().ToString() + "  AND [Level_App]=" + Lv_now + " AND [Min] < " + dgv_datalab.Rows[i].Cells[2].Value.ToString().ToString() + " order by [Min] desc ";
                                    SqlCommand CM2 = new SqlCommand(sql2, con);
                                    SqlDataReader DR2 = CM2.ExecuteReader();
                                    DR2.Read();
                                    {
                                        Value_min = Convert.ToDouble(DR2["Min"].ToString().Trim());
                                        Lv_apmin = Convert.ToInt16(DR2["Level_App"].ToString().Trim());
                                    }
                                    DR2.Close();
                                    con.Close();
                                }
                                catch { con.Close(); }

                                //Check Value Max
                                try
                                {
                                    con.Open();
                                    string sql3 = "Select top(1)[Min],[Level_App] From [dbo].[V_AlertSMG_Lab] Where [ProductID]='" + ProductID + "' AND [ID_Frm_TypeLab]=1 AND [App_Sts]=1  AND [Status_RP]=1 AND LabID =" + dgv_datalab.Rows[i].Cells[0].Value.ToString().ToString() + " AND [Level_App]=" + Lv_now + " AND [Max] >= " + dgv_datalab.Rows[i].Cells[2].Value.ToString().ToString() + "";
                                    SqlCommand CM3 = new SqlCommand(sql3, con);
                                    SqlDataReader DR3 = CM3.ExecuteReader();
                                    DR3.Read();
                                    {
                                        Value_max = Convert.ToDouble(DR3["Min"].ToString().Trim());
                                        Lv_apmax = Convert.ToInt16(DR3["Level_App"].ToString().Trim());
                                    }
                                    DR3.Close();
                                    con.Close();
                                }

                                catch { con.Close(); }

                                if (Value_max > Value_min)
                                {
                                    APP_LV = Lv_apmax;
                                }
                                
                                if (APP_LV != 0)
                                {
                                    con.Open();
                                    string sql4 = "Select  [ID_User],[Email] From [dbo].[V_AlertSMG_Lab] Where [ProductID]='" + ProductID + "' AND [ID_Frm_TypeLab]=1 AND [App_Sts]=1  AND [Status_RP]=1 AND LabID =" + dgv_datalab.Rows[i].Cells[0].Value.ToString().ToString() + " AND [Level_App]=" + APP_LV + "  AND [Max] >= " + dgv_datalab.Rows[i].Cells[2].Value.ToString().ToString() + "";
                                    SqlCommand CM4 = new SqlCommand(sql4, con);
                                    SqlDataReader DR4= CM4.ExecuteReader();

                                    DR4.Read();
                                    {
                                        ID_User = Convert.ToInt16(DR4["ID_User"].ToString().Trim());
                                        Email = DR4["Email"].ToString().Trim();
                                    }
                                    DR4.Close();
                                    con.Close();
                                }
                            }
                            catch
                            {
                                con.Close();
                            }
                        }
                    }
                }

                ///search user appproved next Level  Type Data Lab
                if (dgv_datavisual.RowCount > 0)
                {
                   
                    for (int i = 0; i < dgv_datavisual.RowCount; i++)
                    {
                        if (dgv_datavisual.Rows[i].DefaultCellStyle.BackColor == Color.Yellow)
                        {
                            //SELECT [proc_no]  FROM  [dbo].[TB_Process]  Where [proc_type] ='C'
                            int APP_LV = 0;

                            try
                            {
                                //  เช็คว่า ตัวเอง อยู่ที่ Level Apprvrde อะไร
                                int Lv_now = 0;             
                            
                                con.Open();
                                string sql1 = "Select [Level_App] From [dbo].[V_AlertSMG_Visual] Where [ProductID]='" + ProductID + "' AND [ID_Frm_TypeLab]=2 AND [App_Sts]=1  AND [Status_RP]=1 AND LabID =" + dgv_datavisual.Rows[i].Cells[0].Value.ToString().ToString() + " AND [ID_User]=" + Program.user_id + " AND [ValueName] ='" + dgv_datavisual.Rows[i].Cells[2].Value.ToString().ToString().Trim() + "'";
                                SqlCommand CM1 = new SqlCommand(sql1, con);
                                SqlDataReader DR1 = CM1.ExecuteReader();
                                DR1.Read();
                                {
                                    Lv_now = Convert.ToInt16(DR1["Level_App"].ToString().Trim());
                                }
                                DR1.Close();
                                con.Close();

                                Lv_now++;
                                                              
                                try
                                {

                                    // เพิ่ม Level เพื่อไปหาว่า มี Level อนุมัติต่อไปไหม
                                    con.Open();
                                    string sql2 = "Select [Level_App] From [dbo].[V_AlertSMG_Visual] Where [ProductID]='" + ProductID + "' AND [ID_Frm_TypeLab]=2 AND [App_Sts]=1  AND [Status_RP]=1 AND LabID =" + dgv_datavisual.Rows[i].Cells[0].Value.ToString().ToString() + "  AND [Level_App]=" + Lv_now + " AND [ValueName] = '" + dgv_datavisual.Rows[i].Cells[2].Value.ToString().ToString().Trim() + "'";
                                    SqlCommand CM2 = new SqlCommand(sql2, con);
                                    SqlDataReader DR2 = CM2.ExecuteReader();
                                    DR2.Read();
                                    {
                                        APP_LV = Convert.ToInt16(DR2["Level_App"].ToString().Trim());
                                    }
                                    DR2.Close();
                                    con.Close();
                                }
                                catch { con.Close(); }                              


                                //ถ้ามี ให้ไปหา อีเมเล์เพื่อแจ้งอนุมัติ
                                if (APP_LV != 0)
                                {
                                    con.Open();
                                    string sql4 = "Select  [ID_User],[Email] From [dbo].[V_AlertSMG_Visual] Where [ProductID]='" + ProductID + "' AND [ID_Frm_TypeLab]=2 AND [App_Sts]=1  AND [Status_RP]=1 AND LabID =" + dgv_datavisual.Rows[i].Cells[0].Value.ToString().ToString() + " AND [Level_App]=" + APP_LV + "  AND [ValueName]= '" + dgv_datavisual.Rows[i].Cells[2].Value.ToString().ToString().Trim() + "'";                                    

                                    SqlCommand CM4 = new SqlCommand(sql4, con);
                                    SqlDataReader DR4 = CM4.ExecuteReader();

                                    DR4.Read();
                                    {
                                        ID_User = Convert.ToInt16(DR4["ID_User"].ToString().Trim());
                                        Email = DR4["Email"].ToString().Trim();
                                    }
                                    DR4.Close();
                                    con.Close();
                                }


                            }
                            catch { con.Close(); }
                        }
                    }
                }


                /////Next level App
                if (ID_User != 0)
                {
                    //update table Approve old record
                    StatusID++;
                    con.Open();
                    string sql3 = "Update [TB_Approved] Set [Ststus_App] = " + ID_STS_APP + ",[Date_App] ='" + date + "' Where [TicketCodeIn] = '" + Ticket_Code + "' AND [ID_App]=" + ID_App + "";
                    SqlCommand CM3 = new SqlCommand(sql3, con);
                    SqlDataReader DR3 = CM3.ExecuteReader();
                    con.Close();

                    //insert new record in table Approve            
                    con.Open();
                    string sql4 = "Insert Into [TB_Approved] ([TicketCodeIn],[SimpleCode],[CreateDate],[ID_UserApp],[StatusID]) Values('" + Ticket_Code + "','" + SimpleCode + "', '" + date + "', " + ID_User + "," + StatusID + ")";

                    SqlCommand CM4 = new SqlCommand(sql4, con);
                    SqlDataReader DR4 = CM4.ExecuteReader();
                    con.Close();


                    con.Open();
                    string sql2 = "Update [TB_WeightData] Set  [StatusID]=3 Where [TicketCodeIn] = '" + Ticket_Code + "'";
                    SqlCommand CM2 = new SqlCommand(sql2, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    con.Close();

                    ///sent mail alert to user approved level
                    Load_MailConfig();
                    Send_mailAlert();
                }

//Finish level App
                else   
                {

                    //update table Approve old record
                    con.Open();
                    string sql = "Update[TB_Approved] Set [Ststus_App] = " + ID_STS_APP + ",[Date_App] ='" + date + "' Where [TicketCodeIn] = '" + Ticket_Code + "' AND [ID_App]=" + ID_App + "";
                    SqlCommand CM = new SqlCommand(sql, con);
                    SqlDataReader DR = CM.ExecuteReader();
                    con.Close();

                    //con.Open();
                    //string sql4 = "Insert Into [TB_Approved] ([TicketCodeIn],[SimpleCode],[CreateDate],[ID_UserApp],[StatusID],[Date_App],[Ststus_App]) Values('" + Ticket_Code + "','" + SimpleCode + "', '" + date + "', " + Program.user_id + ",4,'" + date + "',1)";

                    //SqlCommand CM4 = new SqlCommand(sql4, con);
                    //SqlDataReader DR4 = CM4.ExecuteReader();
                    //con.Close();

                    con.Open();
                    string sql1 = "Update [TB_WeightData] Set  [StatusID]=4 Where [TicketCodeIn] = '" + Ticket_Code + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, con);
                    SqlDataReader DR1 = CM1.ExecuteReader();
                    con.Close();

                }
            }
                                   
            Load_Data_PendingApp();
        }


        private void Send_mailAlert()
        {
            try
            {
                int port = Convert.ToInt16(mailport);
                SmtpClient smtpClient = new SmtpClient(ipsvr, port);
                smtpClient.Credentials = new System.Net.NetworkCredential(accalert, addpwd);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(accalert);
                mailMessage.To.Add(Email);


                mailMessage.Subject = "รายงานผลวิเคราะห์ไม่ผ่านเกณฑ์ รออนุมัติ (" + Ticket_Code + ")";
                mailMessage.Body = "ชื่อสินค้า: " + ProductName + " เลขที่บัตรชั่ง: " + Ticket_Code + " เลขที่ตัวอย่าง: " + SimpleCode +
                    "\r\n ผู้ขาย: " + Vendor_Name + "\r\n" + "ทะเบียนรถ: " + Truck_No +
                    "\r\n" +
                    "วันที่แจ้ง :" + DateTime.Now.ToShortDateString() + " เวลา:" + DateTime.Now.ToLongTimeString() +
                     "\r\n" +
                    "------ ระบบแจ้งเตือนผลไม่ผ่านเกณฑ์ งานชั่ง (Truck Scale Systems V 5.0.5) ------";
                smtpClient.Send(mailMessage);
            }
            catch { MessageBox.Show("Mail Sending Error!! Pls. contatch admin","รายงานส่งอีเมล์ Email ผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }


        private void Load_MailConfig()
        {
            SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
            con1.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con1.Open();

            string sql1 = "SELECT * FROM  [dbo].[V_Alert_Setting] Where  [ProductID]='" + ProductID + "' AND [ID_ALtype] = 1";
            SqlCommand CM1 = new SqlCommand(sql1, con1);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {             
                    ipsvr = DR1["Val1_ALT"].ToString().Trim();
                    mailport = DR1["Val2_ALT"].ToString().Trim();
                    accalert = DR1["Val3_ALT"].ToString().Trim();
                    addpwd = DR1["Val4_ALT"].ToString().Trim();
            }
            DR1.Close();
            con1.Close();

        }



    }
}
