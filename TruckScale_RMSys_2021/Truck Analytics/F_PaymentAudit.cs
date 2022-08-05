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

namespace Truck_Analytics
{
    public partial class F_PaymentAudit : Form
    {
        public F_PaymentAudit()
        {
            InitializeComponent();
        }

        public string Ticket_Code = "";
        public string Vendor_Code = "";
        public string Product_Code = "";
        public string VendorGroup_Code = "";
        public string Value_Starh = "";
        public string Value_Visual = "";
        string VendorGroup_Select = "";

        string Log_OldValue="";


        private void F_PaymentAudit_Load(object sender, EventArgs e)
        {
            Load_Vendor();
            Load_Labconfirm();
            Load_LabVisual();        
            Load_SPVendorGroup();

            lbl_group.Text = "เลขที่ตั๋ว:" + Ticket_Code + " รหัสสินค้า:" + Product_Code + " รหัสกลุ่มผู้ขาย:" + VendorGroup_Code;
            //Load_SPVendorGroupDetail();
        }

        private void Load_Vendor()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            con.Open();
            string sql2 = "SELECT  [Vendor_No] ,[Names],[Address],[TambonName] ,[AmphurName] ,[ProvinceName] ,[ZipCode] FROM  [dbo].[V_Vendor] WHERE [Vendor_No] ='" + Vendor_Code + "'";
            SqlCommand CM2 = new SqlCommand(sql2, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            DR2.Read();
            {
                lbl_vendor.Text = "รหัส: " + DR2["Vendor_No"].ToString().Trim() + " " + DR2["Names"].ToString().Trim() + " ที่อยู่: " + DR2["Address"].ToString().Trim() + " ตำบล:" + DR2["TambonName"].ToString().Trim() + " อำเภอ:" + DR2["AmphurName"].ToString().Trim() + " จังหวัด:" + DR2["ProvinceName"].ToString().Trim() + "  รหัสไปรษณีย์:" + DR2["ZipCode"].ToString().Trim();
            }

            con.Close();
        }

        private void Load_Labconfirm()
        {
            if (Ticket_Code != "")
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                con.Open();
                
                string sql2 = "SELECT[TicketCodeIn] AS 'รหัสตั๋ว',[LabValue1] AS 'ผลครั้งที่1' ,[LabValue2] AS 'ผลครั้งที่2' ,[LabValue3] AS 'ผลครั้งที่3' ,[LabValue4] AS 'ผลครั้งที่4' ,[LabVselect] AS 'ผลที่เลือก',[DiscutValue] AS 'ผลราคาซื้อ',[FullUserName] AS 'ผู้บันทึก'  FROM [dbo].[V_LabConfirm] WHERE[TicketCodeIn] ='" + Ticket_Code + "'";
                                              

        SqlDataAdapter da1 = new SqlDataAdapter(sql2, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "v_lconfirm");
                dtg_Labconfirm.DataSource = ds1.Tables["v_lconfirm"];
                con.Close();

                this.dtg_Labconfirm.Rows[0].Cells[5].Style.BackColor = Color.LightGreen;
                this.dtg_Labconfirm.Rows[0].Cells[6].Style.BackColor = Color.Khaki;
            }

        }

        private void Load_LabVisual()
        {
            if (Ticket_Code != "")
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                con.Open();

                // Check Tepe Lap onver condtion type
                int C_count = 0;

                int Lab_ID = 0;
                string Lab_Name = "";
                decimal Lab_Value = 0;
                
                decimal lab_min = 0;
                decimal lab_max = 0;

                decimal visual_min = 0;
                decimal visual_max = 0;


             

                SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
                con1.ConnectionString = Program.pathdb_Weight;
               
                //string sql2 = "SELECT dbo.TB_VisualLog.TicketCodeIn AS 'รหัสบัตรชั่ง', dbo.TB_LabName.LabName AS 'ประเภทผลวิเคราะห์', dbo.TB_VisualLog.LabValue AS '% ตัด +-' FROM     dbo.TB_VisualLog INNER JOIN    dbo.TB_LabName ON dbo.TB_VisualLog.LabID = dbo.TB_LabName.LabID  WHERE [TicketCodeIn] ='" + Ticket_Code + "'";
                string sql2= "SELECT [TicketCodeIn] AS 'เลขที่บัตรชั่ง',[LabID] AS 'รหัสประเภท',[LabName] AS 'ประเภทผลวิเคราะห์', [LabValue] AS 'ผลวิเคราะห์ QA','' AS 'เกณฑ์ตัด SP',[DisctPrice],[LabtypeID] From [dbo].[V_VisualLog]  WHERE [TicketCodeIn] ='" + Ticket_Code + "'";
                SqlDataAdapter da1 = new SqlDataAdapter(sql2, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "v_lvisual");
                dtg_Labvisual.DataSource = ds1.Tables["v_lvisual"];
                con.Close();

                dtg_Labvisual.Columns[0].Width = 120;
                dtg_Labvisual.Columns[1].Width = 80;                             
                dtg_Labvisual.Columns[5].Width = 0;
                dtg_Labvisual.Columns[6].Width = 0;

                for (int i = 0; i < dtg_Labvisual.RowCount; i++)
                {
                    Lab_ID =Convert.ToInt16(dtg_Labvisual.Rows[i].Cells[1].Value.ToString().Trim());
                    Lab_Name = dtg_Labvisual.Rows[i].Cells[2].Value.ToString().Trim();
                    Lab_Value =Convert.ToDecimal(dtg_Labvisual.Rows[i].Cells[3].Value.ToString().Trim());


                    if (dtg_Labvisual.Rows[i].Cells[5].Value.ToString() == "True")
                    {
                        this.dtg_Labvisual.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                    }

                    else { this.dtg_Labvisual.Rows[i].Cells[3].Style.BackColor = Color.Khaki; }

                    //try
                    //{
                    //    con1.Open();
                    //    string sql3 = "Select Top 1([LabID]) From [dbo].[V_CalPayment_Lab] Where Trim([dbo].[V_CalPayment_Lab].[LabName])='" + Lab_Name + "' AND [VendorGroupID]='" + VendorGroup_Code + "' AND [ProductID] = '" + Product_Code + "'";
                    //    SqlCommand CM3 = new SqlCommand(sql3, con1);
                    //    SqlDataReader DR3 = CM3.ExecuteReader();
                    //    DR3.Read();
                    //    {
                    //        dtg_Labvisual.Rows[i].Cells[2].Value = DR3["LabID"].ToString().Trim();
                    //    }
                    //    con1.Close();


                    //}

                    //catch
                    //{
                    //    con1.Close();

                    //    if (dtg_Labvisual.Rows[i].Cells[2].Value.ToString() == "")
                    //    {
                    //        try
                    //        {
                    //            con1.Open();
                    //            string sql3 = "Select Top 1([LabID]) From [dbo].[V_CalPayment_Visual] Where Trim([dbo].[V_CalPayment_Visual].[LabName])='" + Lab_Name + "' AND [VendorGroupID]='" + VendorGroup_Code + "' AND [ProductID] = '" + Product_Code + "'";
                    //            SqlCommand CM3 = new SqlCommand(sql3, con1);
                    //            SqlDataReader DR3 = CM3.ExecuteReader();
                    //            DR3.Read();
                    //            {
                    //                dtg_Labvisual.Rows[i].Cells[2].Value = DR3["LabID"].ToString().Trim();
                    //            }
                    //            con1.Close();
                    //        }
                    //        catch { dtg_Labvisual.Rows[i].Cells[2].Value = "-"; con1.Close(); }
                    //    }
                    //}


                    if (dtg_Labvisual.Rows[i].Cells[6].Value.ToString().Trim() == "1")
                    {

                        string sql6 = "Select Top(1)[ValueSP] From [dbo].[V_CalPayment_Lab] Where [MinSP] <= " + Lab_Value + " AND [VendorGroupID]='" + VendorGroup_Code + "' AND [ProductID]='" + Product_Code + "' AND [LabID]=" + Lab_ID + " Order by [MinSP] desc ";

                        string sql5 = "Select Top(1)[ValueSP] From [dbo].[V_CalPayment_Lab] Where [MaxSP] >= " + Lab_Value + " AND [VendorGroupID]='" + VendorGroup_Code + "' AND [ProductID]='" + Product_Code + "'  AND [LabID]=" + Lab_ID + " Order by [MaxSP] ";

                        try
                        {
                            con1.Open();
                            SqlCommand CM2 = new SqlCommand(sql6, con1);
                            SqlDataReader DR2 = CM2.ExecuteReader();
                            DR2.Read();
                            {
                                lab_min = Convert.ToDecimal(DR2["ValueSP"].ToString());
                            }
                            DR2.Close();
                            con1.Close();
                        }
                        catch { lab_min = 99; con1.Close(); }

                        try
                        {
                            con1.Open();
                            SqlCommand CM5 = new SqlCommand(sql5, con1);
                            SqlDataReader DR5 = CM5.ExecuteReader();
                            DR5.Read();
                            {
                                lab_max = Convert.ToDecimal(DR5["ValueSP"].ToString());
                            }
                            DR5.Close();
                            con1.Close();
                        }

                        catch { lab_max = 99; con1.Close(); }


                        if (lab_min == lab_max)
                        {
                            if (lab_min != 99 && lab_max != 99)
                            {
                                dtg_Labvisual.Rows[i].Cells[4].Value = lab_min.ToString();
                            }

                            else { dtg_Labvisual.Rows[i].Cells[4].Value = "-"; }
                        }
                        else
                        {
                            dtg_Labvisual.Rows[i].Cells[4].Value = lab_max.ToString();
                        }
                    }


                    if (dtg_Labvisual.Rows[i].Cells[6].Value.ToString().Trim() == "2" && VendorGroup_Code != "#N/A")
                    {
                        con1.Open();
                        string sql4 = "Select Count([LabID]) AS 'C_count' FROM  [dbo].[TB_LabName]  WHERE [ProductID] = '" + Product_Code + "' AND [LabActive]=1 AND  [LabtypeID]=2 AND [LabPayment] =0 AND [LabID]=" + Lab_ID + "";
                        SqlCommand CM = new SqlCommand(sql4, con1);
                        SqlDataReader DR = CM.ExecuteReader();
                        DR.Read();
                        {
                            C_count = Convert.ToUInt16(DR["C_count"].ToString());
                        }
                        DR.Close();
                        con1.Close();


                        if (C_count == 1) // 
                        {
                            con1.Open();
                            string sql40 = "SELECT Top(1) [ValueSP] FROM [dbo].[V_CalPayment_Visual] WHere [LabID]=" + Lab_ID + " AND [ValueWH] >=" + Lab_Value + " AND [VendorGroupID]='" + VendorGroup_Code + "' AND [StatusSP]=1 Order by [ValueWH]";

                            SqlCommand CM40 = new SqlCommand(sql40, con1);
                            SqlDataReader DR40 = CM40.ExecuteReader();
                            DR40.Read();
                            {
                                visual_min = Convert.ToDecimal(DR40["ValueSP"].ToString());
                            }
                            DR40.Close();
                            con1.Close();
                        }

                        else
                        {
                            string sql41 = "SELECT top 1[ValueSP] AS 'ValueSP_Min' FROM [dbo].[V_VisualSP_DillData]  Where  [LabID] = " + Lab_ID + "  AND Convert(float,[Vmin]) <= " + Lab_Value + " AND [VendorGroupID]='" + VendorGroup_Code + "' AND [StatusSP]=1  Order By [idVSRNo] Desc";

                            string sql42 = "SELECT top 1[ValueSP] AS 'ValueSP_Max' FROM [dbo].[V_VisualSP_DillData]  Where  [LabID] = " + Lab_ID + " AND Convert(float,[Vmax]) >= " + Lab_Value + " AND [VendorGroupID]='" + VendorGroup_Code + "' AND [StatusSP]=1 Order By [idVSRNo] ASC";

                            con1.Open();
                            SqlCommand CM41 = new SqlCommand(sql41, con1);
                            SqlDataReader DR41 = CM41.ExecuteReader();
                            DR41.Read();
                            {
                                visual_min = Convert.ToDecimal(DR41["ValueSP_Min"].ToString());
                            }
                            DR41.Close();
                            con1.Close();

                            con1.Open();
                            SqlCommand CM42 = new SqlCommand(sql42, con1);
                            SqlDataReader DR42 = CM42.ExecuteReader();
                            DR42.Read();
                            {
                                visual_max = Convert.ToDecimal(DR42["ValueSP_Max"].ToString());
                            }
                            DR42.Close();
                            con1.Close();
                        }


                        if (visual_min == visual_max)
                        {

                            dtg_Labvisual.Rows[i].Cells[4].Value = visual_min.ToString("F");
                        }

                        else
                        {

                            dtg_Labvisual.Rows[i].Cells[4].Value = visual_min.ToString("F");
                        }
                    }


                }
            }
        }

        
        private void Load_SPStarch()
        {
            if (VendorGroup_Code != "" && Product_Code !="" )
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                con.Open();
                string sql2 = "SELECT [VendorGroupID] AS 'รหัสกลุ่ม' ,[LabName] AS 'ชื่อการวิเคราะห์' ,[ValueLab] AS 'ค่าวิเคราะห์' ,[ValueSP] AS 'ราคาจ่าย' ,[StatusSP] AS 'สถานะ'  FROM  [dbo].[V_CalPayment_Lab]  WHERE [VendorGroupID] ='" + VendorGroup_Select + "' AND [ProductID] = '" + Product_Code + "' ";
                SqlDataAdapter da1 = new SqlDataAdapter(sql2, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "v_spstarch");
                dtg_SPstarch.DataSource = ds1.Tables["v_spstarch"];
                con.Close();
            }
        }

        private void Load_SPVisual()
        {
            if (VendorGroup_Code != "")
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                con.Open();
                string sql2 = "SELECT [VendorGroupID] AS 'กลุ่ม',[LabID] AS 'รหัสประเภท',[LabName] AS 'ชื่อประเภท',[ValueSP] AS 'ค่า SP' ,[StatusSP] AS 'สถานะ'  FROM  [dbo].[V_CalPayment_Visual]  WHERE [VendorGroupID] ='" + VendorGroup_Select + "' AND [StatusSP]=1";
                SqlDataAdapter da1 = new SqlDataAdapter(sql2, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "v_spvisual");
                dtg_SPvisual.DataSource = ds1.Tables["v_spvisual"];
                con.Close();
            }
        }


        private void Load_SPVendorGroup()
        {
            try
            {
                if (Vendor_Code != "")
                {
                    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                    con.ConnectionString = Program.pathdb_Weight;
                    con.Open();
                    dtg_SPvendorgroup.DataSource = null;
                    string sql2 = "SELECT  [VendorGPay] AS 'รหัส',[VendorGroupID] AS 'รหัสกลุ่ม' ,[VendorGroupName] AS 'ชื่อกลุ่ม',[StsActive] AS 'สถานะ'  FROM [dbo].[V_CalPayment_VenGroup]  WHERE  Vendor_No = '" + Vendor_Code + "' AND [ProductID]='" + Product_Code + "' ";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql2, con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1, "v_spVdgroup");
                    dtg_SPvendorgroup.DataSource = ds1.Tables["v_spVdgroup"];
                    con.Close();

                    dtg_SPvendorgroup.Columns[0].Width = 60;


                    for (int i = 0; i < dtg_SPvendorgroup.RowCount; i++)
                    {
                        if (dtg_SPvendorgroup.Rows[i].Cells[3].Value.ToString() == "True")
                        {
                            Log_OldValue = dtg_SPvendorgroup.Rows[i].Cells[3].Value.ToString();
                        }
                    }
                }
            }
            catch { }
        }

        private void Load_SPVendorGroupDetail()
        {
            if (VendorGroup_Select != "")
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                con.Open();
                dtg_SPvendorDetail.DataSource = null;
                string sql2 = "SELECT [PaysetID] AS 'รหัสกลุ่ม', [PriceFac] AS 'ราคาหน้าป้าย' ,[UnitName] AS 'หน่วย' ,[DateActive] AS 'จำกัดวันรับ' ,[StDate] AS 'วันเริ่มรับ' ,[EdDate] AS 'วันสิ้นสุดรับ'  ,[DocAppNo] AS 'เอกสารอนุมัติ'  FROM  [dbo].[V_PaymentSettingGroup]  WHERE [VendorGroupID] ='" + VendorGroup_Select + "' AND [ProductID]='" + Product_Code + "'";
                SqlDataAdapter da1 = new SqlDataAdapter(sql2, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "v_spVdgroupDetail");
                dtg_SPvendorDetail.DataSource = ds1.Tables["v_spVdgroupDetail"];
                con.Close();

                dtg_SPvendorDetail.Columns[0].Width = 60;
                dtg_SPvendorDetail.Columns[1].Width = 100;
                dtg_SPvendorDetail.Columns[2].Width = 60;
            }
        }






        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtg_SPvendorgroup_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                VendorGroup_Select = dtg_SPvendorgroup.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                Load_SPVendorGroupDetail();
                dtg_SPstarch.DataSource = null;
                dtg_SPvisual.DataSource = null;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
          

            

        }

        private void dtg_SPvendorDetail_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Load_SPStarch();
            Load_SPVisual();

            for (int i = 0; i < dtg_SPstarch.RowCount; i++)
            {
                if (Value_Starh == dtg_SPstarch.Rows[i].Cells[2].Value.ToString().Trim() && dtg_SPstarch.Rows[i].Cells[4].Value.ToString().Trim() == "True")
                {
                    this.dtg_SPstarch.Rows[i].Cells[2].Style.BackColor = Color.LightGreen;
                    this.dtg_SPstarch.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;

                }
            }

            for (int i = 0; i < dtg_Labvisual.RowCount; i++)
            {
                decimal value = Convert.ToDecimal(dtg_Labvisual.Rows[i].Cells[3].Value.ToString().Trim());
                int convert = Convert.ToInt16(value);

                for (int x = 0; x < dtg_SPvisual.RowCount; x++)
                {
                    if (dtg_Labvisual.Rows[i].Cells[1].Value.ToString().Trim() == dtg_SPvisual.Rows[x].Cells[2].Value.ToString().Trim() && convert.ToString() == dtg_SPvisual.Rows[x].Cells[3].Value.ToString().Trim())
                    {
                        this.dtg_SPvisual.Rows[x].Cells[2].Style.BackColor = Color.LightGreen;
                        this.dtg_SPvisual.Rows[x].Cells[3].Style.BackColor = Color.LightGreen;
                        this.dtg_SPvisual.Rows[x].Cells[4].Style.BackColor = Color.LightGreen;
                    }
                }



            }
        }

        private void dtg_SPvendorgroup_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            con.Open();

            int stsActive = 0;
            if (dtg_SPvendorgroup.Rows[e.RowIndex].Cells[3].Value.ToString() == "True")
            { stsActive = 1; }


            string sql2 = "Update  [dbo].[TB_VendorGroupPayment] Set [StsActive]=" + stsActive + "  WHERE  [VendorGPay]='" + dtg_SPvendorgroup.Rows[e.RowIndex].Cells[0].Value.ToString() + "' AND [Vendor_No]='" + Vendor_Code + "' ";

            SqlCommand CM2 = new SqlCommand(sql2, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();

            Class_Log CL = new Class_Log();
            CL.tbname = "Change Data Vendor Group!";
            CL.oldvalue = Log_OldValue;
            CL.newvalue = dtg_SPvendorgroup.Rows[e.RowIndex].Cells[0].Value.ToString();
            CL.Save_log();

            Load_SPVendorGroup();
        }
    }
}
