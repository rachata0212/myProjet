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

namespace Truck_Analytics
{
    public partial class F_MainReport : Form
    {
        public F_MainReport()
        {
            InitializeComponent();
        }

        string Path_Image1_1 = "";
        string Path_Image1_2 = "";
        string Path_Image1_3 = "";
        string Path_Image1_4 = "";
        string Path_Image2_1 = "";
        string Path_Image2_2 = "";
        string Path_Image2_3 = "";
        string Path_Image2_4 = "";
        string Path_Image3_1 = "";
        string Path_Image3_2 = "";
        string Path_Image3_3 = "";
        string Path_Image3_4 = "";
        string Path_Image4_1 = "";
        string Path_Image4_2 = "";
        string Path_Image4_3 = "";
        string Path_Image4_4 = "";

        string ID_Vendor = "";
        string ID_Customer = "";
        string Sort_Product = "";
        string ProductID = "";
        private void F_MainPrint_Load(object sender, EventArgs e)
        {
            Load_MenuReport();
            //Load_Product();

            if (Program.DB_Name != "SapthipNewDB")
            {
                textBox1.BackColor = Color.Crimson;
            }
        }

        //private void Load_Product()
        //{
        //    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
        //    con.ConnectionString = Program.pathdb_Weight;
        //    SqlDataAdapter dtAdapter = new SqlDataAdapter();

        //    try
        //    {
        //        //Product 
        //        SqlCommand cmd = new SqlCommand("Select [ProductID],[ProductName]  From  [dbo].[TB_Products] Where [StatusActive]=1", con);
        //        DataSet ds = new DataSet();
        //        //ds.Clear();

        //        SqlDataAdapter da = new SqlDataAdapter();
        //        da.SelectCommand = cmd;
        //        da.Fill(ds);

        //        //Load product tab weight scale Setup
        //        cb_productReport.DataSource = ds.Tables[0];
        //        cb_productReport.DisplayMember = "ProductName";
        //        cb_productReport.ValueMember = "ProductID";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //        con.Dispose();
        //    }

        //}

        private void Load_MenuReport()
        {

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("SELECT[ID_Menu], TRIM([Name_Menu]) AS 'Name_Menu'  FROM  [dbo].[V_Permission] WHERE[User_AD] = '" + Program.user_login + "' AND[ID_Menutype] = 4 ", con);
            DataSet ds = new DataSet();
            //ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            //Load product tab weight scale Setup
            cb_typeReport.DataSource = ds.Tables[0];
            cb_typeReport.DisplayMember = "Name_Menu";
            cb_typeReport.ValueMember = "ID_Menu";

        }

        private void btn_saveLabtype_Click(object sender, EventArgs e)
        {
            //29  รายงานชั่งประจำวัน งานออกรายงาน                                        
            //30  รายงานสรุปชั่ง งานออกรายงาน                                        
            //31  รายงานผลวิเคราะห์เครื่องมือ งานออกรายงาน                                        
            //33  รายงานผลวิเคราะห์เครื่องมือแบบสรุป งานออกรายงาน                                        
            //34  รายงานผลวิเคราะห์แบบบันทึกมือ งานออกรายงาน                                        
            //35  รายงานผลวิเคราะห์แบบบันทึกมือแบบสรุป งานออกรายงาน                                        
            //36  รายงานผลวิเคราะห์แบบกายภาพ งานออกรายงาน                                        
            //37  รายงานผลวิเคราะห์แบบกายภาพแบบสรุป งานออกรายงาน                                        
            //38  รายงานผลการจ่ายวัตุดิบ งานออกรายงาน                                        
            //39  รายงานผลการจ่ายวัตุดิบแบบสรุป งานออกรายงาน                                        

            //39  รายงานผลการจ่ายวัตุดิบแบบสรุป งานออกรายงาน  

            //51  รายงานต้นทุนซื้อ งานออกรายงาน   

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            dtg_dataBFprint.Columns.Clear();
            dtg_dataBFprint.DataSource = null;
            DataSet ds1 = new DataSet();
            tabControl1.SelectedIndex = 1;
            string sql = "";
            btn_expExcel.Enabled = true;
            int id_print = Convert.ToInt16(cb_typeReport.SelectedValue.ToString());
                       
            try
            {                 
                string ST_Date = dtp_stReport.Value.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
                string ED_Date = dtp_edReport.Value.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));

                string Vendor_Code = "";
                string Customer_Code = "";


                if (cb_vendor.Text != "-- เลือกทั้งหมด --")
                {
                    Vendor_Code = cb_vendor.SelectedValue.ToString();
                    //Vendor_Code = cb_customer.SelectedValue.ToString();
                }

                if (cb_customer.Text != "-- เลือกทั้งหมด --")
                {
                    //Vendor_Code = cb_vendor.SelectedValue.ToString();
                    Customer_Code = cb_customer.SelectedValue.ToString();
                }

                //Report OK  All 
                if (id_print == 28) //Report register
                {
                    crp_register_01 crt_Register = new crp_register_01();

                    if (rdo_purchase.Checked == true)
                    {
                        sql = "SELECT *  FROM  [dbo].[V_Ticket_Register] WHERE ([RegisterIOutdate] Between '" + ST_Date + " 00:00:00.0'  AND  '" + ED_Date + " 23:00:00.0')";
                    }

                    if (rdo_sale.Checked == true)
                    {
                        sql = "SELECT *  FROM  [dbo].[V_Ticket_Register_Sale] WHERE ([RegisterIOutdate] Between '" + ST_Date + " 00:00:00.0'  AND  '" + ED_Date + " 23:00:00.0')";
                    }


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    if (rdo_purchase.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                        }
                    }

                    if (rdo_sale.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCodeCus] ='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [CustomerID]= '" + Customer_Code + "'";
                        }
                    }

                    DataSet ds = new DataSet();
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(ds, "payment");
                    crt_Register.SetDataSource(ds1.Tables["payment"]);
                    crystalReportViewer1.ReportSource = crt_Register;
                    crystalReportViewer1.Refresh();
                    con.Close();

                }

                //Report OK All
                if (id_print == 29) //daily weight report
                {
                    crp_Pur_weightdaily crt_weight = new crp_Pur_weightdaily();

                    if (rdo_purchase.Checked == true)
                    {
                        sql = "SELECT *  FROM  [dbo].[V_WeightData] WHERE ([OutboundDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    }

                    if (rdo_sale.Checked == true)
                    {
                        sql = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE ([OutboundDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    }


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    if (rdo_purchase.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                        }
                    }

                    if (rdo_sale.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCodeCus] ='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [CustomerID]= '" + Customer_Code + "'";
                        }
                    }


                    DataSet ds = new DataSet();
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(ds, "dialy_weight");
                    crt_weight.SetDataSource(ds.Tables["dialy_weight"]);
                    crystalReportViewer1.ReportSource = crt_weight;
                    crystalReportViewer1.Refresh();
                    con.Close();
                }

                //Report OK Purchase for LO
                if (id_print == 30) //summary weight report
                {
                    crp_Pur_weightsummary crt_weight = new crp_Pur_weightsummary();

                    if (rdo_purchase.Checked == true)
                    {
                        sql = "SELECT *  FROM  [dbo].[V_WeightData] WHERE ([OutboundDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    }

                    if (rdo_sale.Checked == true)
                    {
                        sql = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE ([OutboundDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    }


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    if (rdo_purchase.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                        }
                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    if (Vendor_Code != "")
                    //    {
                    //        sql += "AND ([HeaderBill_NameCodeCus] ='" + Vendor_Code + "')";
                    //    }
                    //    if (Customer_Code != "")
                    //    {
                    //        sql += " AND  [CustomerID]= '" + Customer_Code + "'";
                    //    }
                    //}


                    sql += " Order by [TicketCodeIn]";

                    DataSet ds = new DataSet();
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(ds, "sum_weight");
                    crt_weight.SetDataSource(ds.Tables["sum_weight"]);
                    crystalReportViewer1.ReportSource = crt_weight;
                    crystalReportViewer1.Refresh();
                    con.Close();

                }

                //Report OK 
                if (id_print == 36) //Visaul Report
                {                   

                    DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                    {
                        button.Name = "button";
                        button.HeaderText = "Image";
                        button.Text = "View";
                        button.UseColumnTextForButtonValue = true; //dont forget this line
                        this.dtg_dataBFprint.Columns.Add(button);
                    }
                                       

                    crp_Visual crp_visual = new crp_Visual();

                    // string sql1 = "SELECT *  FROM  [dbo].[V_Visual_Image] WHERE [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "'";

                    if (rdo_purchase.Checked == true)
                    {
                        sql = "SELECT *  FROM  [dbo].[V_Visual_Image] WHERE ([WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    sql = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE ([WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    //}


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    if (rdo_purchase.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                        }
                    }

                    if (rdo_sale.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCodeCus] ='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [CustomerID]= '" + Customer_Code + "'";
                        }
                    }


                    DataSet ds = new DataSet();
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(ds, "Rp_visual");
                    crp_visual.SetDataSource(ds.Tables["Rp_visual"]);
                    crystalReportViewer1.ReportSource = crp_visual;
                    crystalReportViewer1.Refresh();
                    con.Close();

                }

                //Report OK 
                if (id_print == 38) //QA Report All Lab RM-004, RM-001
                {
                    crp_PurReport_Summary_SP crp_SP = new crp_PurReport_Summary_SP();

                    //string sql1 = "Select * From [V_PaymentReport] Where [PayDate] Between '" + ST_Date + "'  AND  '" + ED_Date + "' Order by [PaymentID]";

                    if (rdo_purchase.Checked == true)
                    {
                        sql = "SELECT *  FROM  [dbo].[V_PaymentReport] WHERE ([PayDate] Between '" + ST_Date + "'  AND  '" + ED_Date + "')";
                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    sql = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE ([WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    //}


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    if (rdo_purchase.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                        }
                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    if (Vendor_Code != "")
                    //    {
                    //        sql += "AND ([HeaderBill_NameCodeCus] ='" + Vendor_Code + "')";
                    //    }
                    //    if (Customer_Code != "")
                    //    {
                    //        sql += " AND  [CustomerID]= '" + Customer_Code + "'";
                    //    }
                    //}


                    DataSet ds = new DataSet();
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(ds, "crt_SP_RM004");
                    crp_SP.SetDataSource(ds.Tables["crt_SP_RM004"]);
                    crp_SP.SetParameterValue("st_date", ST_Date.ToString());
                    crp_SP.SetParameterValue("ed_date", ED_Date.ToString());
                    crystalReportViewer1.ReportSource = crp_SP;
                    crystalReportViewer1.Refresh();
                    con.Close();

                }

                //Report OK 
                if (id_print == 39) //QA Report All Lab RM-004, RM-001
                {
                    crp_SP crp_Lab = new crp_SP();

                    //string sql1 = "Select * From [V_RpSP] Where [PayDate] Between '" + ST_Date + "'  AND  '" + ED_Date + "'  AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "'  Order by [Vendor_No]";
                    if (rdo_purchase.Checked == true)
                    {
                        sql = "SELECT *  FROM  [dbo].[V_RpSP] WHERE ([PayDate] Between '" + ST_Date + "'  AND  '" + ED_Date + "')";
                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    sql = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE ([WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    //}


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    if (rdo_purchase.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                        }
                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    if (Vendor_Code != "")
                    //    {
                    //        sql += "AND ([HeaderBill_NameCodeCus] ='" + Vendor_Code + "')";
                    //    }
                    //    if (Customer_Code != "")
                    //    {
                    //        sql += " AND  [CustomerID]= '" + Customer_Code + "'";
                    //    }
                    //}

                    DataSet ds = new DataSet();
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(ds, "payment");
                    crp_Lab.SetDataSource(ds.Tables["payment"]);
                    crp_Lab.SetParameterValue("st_date", ST_Date.ToString());
                    crp_Lab.SetParameterValue("ed_date", ED_Date.ToString());
                    crystalReportViewer1.ReportSource = crp_Lab;
                    crystalReportViewer1.Refresh();
                    con.Close();

                }

                //Report OK 
                if (id_print == 41) //daily weight report
                {
                    crp_Sale_weightdaily crt_weight = new crp_Sale_weightdaily();

                    //string sql1 = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "'";

                    //if (rdo_purchase.Checked == true)
                    //{
                    //    sql = "SELECT *  FROM  [dbo].[V_RpSP] WHERE ([PayDate] Between '" + ST_Date + "'  AND  '" + ED_Date + "')";
                    //}

                    if (rdo_sale.Checked == true)
                    {
                        sql = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE ([OutboundDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    }


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    //if (rdo_purchase.Checked == true)
                    //{
                    //    if (Vendor_Code != "")
                    //    {
                    //        sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                    //    }
                    //    if (Customer_Code != "")
                    //    {
                    //        sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                    //    }
                    //}

                    if (rdo_sale.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([CustomerID] ='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [HeaderBill_NameCodeCus]= '" + Customer_Code + "'";
                        }
                    }

                    DataSet ds = new DataSet();
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(ds, "dialy_weight");
                    crt_weight.SetDataSource(ds.Tables["dialy_weight"]);
                    crystalReportViewer1.ReportSource = crt_weight;
                    crystalReportViewer1.Refresh();
                    con.Close();

                }

                //Report OK 
                if (id_print == 42) //summary weight report
                {
                    crp_Sale_weightsummary_byDate crt_weight = new crp_Sale_weightsummary_byDate();

                    //string sql1 = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "'";

                    //if (rdo_purchase.Checked == true)
                    //{
                    //    sql = "SELECT *  FROM  [dbo].[V_RpSP] WHERE ([PayDate] Between '" + ST_Date + "'  AND  '" + ED_Date + "')";
                    //}

                    if (rdo_sale.Checked == true)
                    {
                        sql = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE ([OutboundDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    }


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    //if (rdo_purchase.Checked == true)
                    //{
                    //    if (Vendor_Code != "")
                    //    {
                    //        sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                    //    }
                    //    if (Customer_Code != "")
                    //    {
                    //        sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                    //    }
                    //}

                    if (rdo_sale.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([CustomerID] ='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [HeaderBill_NameCodeCus]= '" + Customer_Code + "'";
                        }
                    }



                    DataSet ds = new DataSet();
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(ds, "sum_weight");
                    crt_weight.SetDataSource(ds.Tables["sum_weight"]);
                    crystalReportViewer1.ReportSource = crt_weight;
                    crystalReportViewer1.Refresh();
                    con.Close();
                }

                //Report OK 
                if (id_print == 43) //SP report by product
                {
                    crp_payment_sumarry crt_payment = new crp_payment_sumarry();

                    // string sql1 = "SELECT [PaymentID],[SaveDate],[PayDocNo],CONVERT (varchar, [PayDate], 103)AS 'PayDate',[Vendor_No],[VendorName],[CountTicket],[WeightNet],[Qty_Net],[WeightDef],[Unit_Net],[Price_Net],[ProvinceName],[ProductID],[ProductName],[Remark],[OwnerName]  FROM[dbo].[V_PaymentReport] WHERE [PayDate] Between '" + ST_Date + "'  AND  '" + ED_Date + "' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "' Order by [Vendor_No]";
                    if (rdo_purchase.Checked == true)
                    {
                        sql = "SELECT [PaymentID],[SaveDate],[PayDocNo],CONVERT (varchar, [PayDate], 103)AS 'PayDate',[Vendor_No],[VendorName],[CountTicket],[WeightNet],[Qty_Net],[WeightDef],[Unit_Net],[Service_Charge],[Price_Net],[ProvinceName],[ProductID],[ProductName],[Remark],[OwnerName],[HeaderBill_NameCode]  FROM [dbo].[V_PaymentReport] WHERE ([PayDate] Between '" + ST_Date + "'  AND  '" + ED_Date + "')";
                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    sql = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE ([WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    //}


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    if (rdo_purchase.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                        }
                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    if (Vendor_Code != "")
                    //    {
                    //        sql += "AND ([HeaderBill_NameCodeCus] ='" + Vendor_Code + "')";
                    //    }
                    //    if (Customer_Code != "")
                    //    {
                    //        sql += " AND  [CustomerID]= '" + Customer_Code + "'";
                    //    }
                    //}

                    sql += " Order by [Vendor_No]";

                    DataSet ds = new DataSet();
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(ds, "sum_payment");
                    crt_payment.SetDataSource(ds.Tables["sum_payment"]);
                    crystalReportViewer1.ReportSource = crt_payment;
                    crystalReportViewer1.Refresh();
                    con.Close();
                }

                //Report OK 
                if (id_print == 44) //SP report by product
                {

                    if (Sort_Product == "ProductID ='RM-004'")
                    {
                        crp_payment_recived_R004 crt_payment = new crp_payment_recived_R004();

                        //string sql1 = "SELECT  *   FROM  [dbo].[V_Payment_Recived_R004] WHERE [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "' AND [StatusActive] =1 Order by [TicketCodeIn]";

                        if (rdo_purchase.Checked == true)
                        {
                            sql = "SELECT * FROM  [dbo].[V_Payment_Recived_R004]  WHERE ([WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                        }

                        //if (rdo_sale.Checked == true)
                        //{
                        //    sql = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE ([WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                        //}


                        if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                        {
                            sql += "AND (" + Sort_Product + ")";
                        }

                        if (rdo_purchase.Checked == true)
                        {
                            if (Vendor_Code != "")
                            {
                                sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                            }
                            if (Customer_Code != "")
                            {
                                sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                            }
                        }

                        //if (rdo_sale.Checked == true)
                        //{
                        //    if (Vendor_Code != "")
                        //    {
                        //        sql += "AND ([HeaderBill_NameCodeCus] ='" + Vendor_Code + "')";
                        //    }
                        //    if (Customer_Code != "")
                        //    {
                        //        sql += " AND  [CustomerID]= '" + Customer_Code + "'";
                        //    }
                        //}

                        sql += " AND [StatusActive] =1 Order by [TicketCodeIn]";

                        DataSet ds = new DataSet();
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                        adapter.Fill(ds, "sum_payment");
                        crt_payment.SetDataSource(ds.Tables["sum_payment"]);
                        crt_payment.SetParameterValue("User_inv", Program.user_name);
                        crystalReportViewer1.ReportSource = crt_payment;
                        crystalReportViewer1.Refresh();
                        con.Close();
                    }

                    if (Sort_Product == "ProductID ='RM-001'")
                    {
                        crp_payment_recived_R001 crt_payment = new crp_payment_recived_R001();

                        //string sql1 = "SELECT  *   FROM  [dbo].[V_Payment_Recived_R001] WHERE [PayDate] Between '" + ST_Date + "'  AND  '" + ED_Date + "' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "' AND [StatusActive] =1 Order by [TicketCodeIn] ";

                        if (rdo_purchase.Checked == true)
                        {
                            sql = "SELECT * FROM  [dbo].[V_Payment_Recived_R001]  WHERE ([WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                        }

                        //if (rdo_sale.Checked == true)
                        //{
                        //    sql = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE ([WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                        //}


                        if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                        {
                            sql += "AND (" + Sort_Product + ")";
                        }

                        if (rdo_purchase.Checked == true)
                        {
                            if (Vendor_Code != "")
                            {
                                sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                            }
                            if (Customer_Code != "")
                            {
                                sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                            }
                        }

                        //if (rdo_sale.Checked == true)
                        //{
                        //    if (Vendor_Code != "")
                        //    {
                        //        sql += "AND ([HeaderBill_NameCodeCus] ='" + Vendor_Code + "')";
                        //    }
                        //    if (Customer_Code != "")
                        //    {
                        //        sql += " AND  [CustomerID]= '" + Customer_Code + "'";
                        //    }
                        //}

                        sql += " AND [StatusActive] =1 Order by [TicketCodeIn] ";


                        DataSet ds = new DataSet();
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                        adapter.Fill(ds, "sum_payment");
                        crt_payment.SetDataSource(ds.Tables["sum_payment"]);
                        crt_payment.SetParameterValue("User_inv", Program.user_name);
                        crystalReportViewer1.ReportSource = crt_payment;
                        crystalReportViewer1.Refresh();
                        con.Close();
                    }

                }

                //Report OK
                if (id_print == 45) //SP report by product
                {
                    crp_sendproduct crt_payment = new crp_sendproduct();

                    //string sql1 = "SELECT *  FROM  [dbo].[V_ReportEthanol] WHERE [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "' Order by [TicketCodeIn]";

                    //if (rdo_purchase.Checked == true)
                    //{
                    //    sql = "SELECT *  FROM  [dbo].[V_RpSP] WHERE ([PayDate] Between '" + ST_Date + "'  AND  '" + ED_Date + "')";
                    //}

                    if (rdo_sale.Checked == true)
                    {
                        sql = "SELECT *  FROM  [dbo].[V_ReportEthanol] WHERE ([OutboundDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    }


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    //if (rdo_purchase.Checked == true)
                    //{
                    //    if (Vendor_Code != "")
                    //    {
                    //        sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                    //    }
                    //    if (Customer_Code != "")
                    //    {
                    //        sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                    //    }
                    //}

                    if (rdo_sale.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([CustomerID] ='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [HeaderBill_NameCodeCus]= '" + Customer_Code + "'";
                        }
                    }

                    sql += " Order by [TicketCodeIn]";


                    DataSet ds = new DataSet();
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(ds, "send_product");
                    crt_payment.SetDataSource(ds.Tables["send_product"]);
                    crystalReportViewer1.ReportSource = crt_payment;
                    crystalReportViewer1.Refresh();
                    con.Close();
                }

                //Report OK
                if (id_print == 46) //SP report by product   Daily
                {
                    DataTable dt = new DataTable();
                    //dtg_Cal.Visible = true;
                    //dtg_Cal.Dock = DockStyle.Fill;

                    dt.Columns.AddRange(new DataColumn[14] { new DataColumn("Date"), new DataColumn("W_Net"), new DataColumn("W_StarchIN"), new DataColumn("Max_StarchIN"), new DataColumn("Min_StarchIN"), new DataColumn("AVG_StarchPur"), new DataColumn("AVG_PricePur"), new DataColumn("AVG_PriceStarch"), new DataColumn("W_Starch28"), new DataColumn("AVG_Starch28"), new DataColumn("W_Starch23"), new DataColumn("AVG_Starch23"), new DataColumn("W_Visual"), new DataColumn("AVG_Visual") });

                    string Date = "";
                    string W_Net = "";
                    string W_StarchIN = "";
                    string Max_StarchIN = "";
                    string Min_StarchIN = "";
                    string AVG_StarchPur = "";
                    string AVG_PricePur = "";
                    string AVG_PriceStarch = "";
                    string W_Starch28 = "";
                    string AVG_Starch28 = "";
                    string W_Starch23 = "";
                    string AVG_Starch23 = "";
                    string W_Visual = "";
                    string AVG_Visual = "";

                    string st_date = dtp_stReport.Value.ToString("yyyy-MM-dd");
                    string ed_date = dtp_edReport.Value.ToString("yyyy-MM-dd");


                    string sql1 = "";

                    //"Select DISTINCT([PayDate]) AS 'DateS' From[dbo].[TB_Payment] Where[PayDate] Between '" + st_date + "' AND '" + ed_date + "'  AND [ProductID]= '" + cb_productReport.SelectedValue.ToString() + "' Order by [DateS]";

                    sql1 += "Select DISTINCT([PayDate]) AS 'DateS' From[dbo].[TB_Payment] Where[PayDate] Between '" + st_date + "' AND '" + ed_date + "' ";

                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql1 += "AND (" + Sort_Product + ")";
                    }

                    sql1 += " Order by[DateS]";


                    con.Open();
                    SqlCommand CM = new SqlCommand(sql1, con);
                    SqlDataReader DR = CM.ExecuteReader();

                    while (DR.Read())
                    {
                        DateTime DT = Convert.ToDateTime(DR.GetValue(0).ToString());
                        Date = DT.Day.ToString() + "/" + DT.Month.ToString() + "/" + DT.Year.ToString();

                        dt.Rows.Add(Date, W_Net, W_StarchIN, Max_StarchIN, Min_StarchIN, AVG_StarchPur, AVG_PricePur, AVG_PriceStarch, W_Starch28, AVG_Starch28, W_Starch23, AVG_Starch23, W_Visual, AVG_Visual);
                    }
                    con.Close();

                    dt.Rows.Add("สะสม", "", "", "", "", "", "", "", "", "", "", "", "", "");

                    dtg_CalDay.DataSource = dt;

                    dtg_CalDay.Columns[0].HeaderText = "วันที่";
                    dtg_CalDay.Columns[1].HeaderText = "นน.รับเข้า (กก.)";
                    dtg_CalDay.Columns[2].HeaderText = "นน.แป้งรับเข้า";
                    dtg_CalDay.Columns[3].HeaderText = "%แป้งสูงสุดที่รับ";
                    dtg_CalDay.Columns[4].HeaderText = "%แป้งต่ำสุดที่รับ";
                    dtg_CalDay.Columns[5].HeaderText = "%แป้งที่ซื้อเฉลี่ย";
                    dtg_CalDay.Columns[6].HeaderText = "ราคาซื้อเฉลี่ย";
                    dtg_CalDay.Columns[7].HeaderText = "ราคาแป้งเฉลี่ย";
                    dtg_CalDay.Columns[8].HeaderText = "นน.แป้ง >28%";
                    dtg_CalDay.Columns[9].HeaderText = "% นน.แป้ง >28% ";
                    dtg_CalDay.Columns[10].HeaderText = "นน.แป้ง <23%";
                    dtg_CalDay.Columns[11].HeaderText = "% นน.แป้ง <23%";
                    dtg_CalDay.Columns[12].HeaderText = "นน.สิ่งเจือปน";
                    dtg_CalDay.Columns[13].HeaderText = "% สิ่งเจือปน";

                    //dtg_CalDay.Columns[0].Width = 80;

                    //Summary

                    double Sum_Total_WNet = 0;
                    double Sum_Total_WStarch = 0;
                    double AVG_MaxStarch = 0;
                    double AVG_MinStarch = 0;
                    double AVG_PurStarch = 0;
                    double AVG_PriceStarchs = 0;
                    double AVG_PurPrice = 0;
                    double Sum_Total_W_Max28 = 0;
                    double Sum_Total_W_Min23 = 0;
                    double AVG_W_Max28 = 0;
                    double AVG_W_Min23 = 0;
                    double Sum_Total_W_Visual = 0;
                    double AVG_W_Visual = 0;

                    for (int i = 0; i < dtg_CalDay.Rows.Count; i++)
                    {
                        if (dtg_CalDay.Rows[i].Cells[0].Value.ToString() != "สะสม")
                        {
                            DateTime DT_con = Convert.ToDateTime(dtg_CalDay.Rows[i].Cells[0].Value.ToString());

                            String Date_con = DT_con.Year.ToString() + "-" + DT_con.Month.ToString() + "-" + DT_con.Day.ToString();


                            // Total 
                            int Itmes_Count = 0;
                            double Total_W_Net = 0;
                            double Total_W_Starch = 0;
                            double Total_AVG_MaxStarch = 0;
                            double Total_AVG_MinStarch = 0;
                            double Total_PriceStarchs = 0;
                            double Total_PurPrice = 0;
                            double Total_W_Max28 = 0;
                            double Total_W_Min23 = 0;
                            double Total_AVG_W_Max28 = 0;
                            double Total_AVG_W_Min23 = 0;
                            double Total_W_Visual = 0;
                            double Total_AVG_W_Visual = 0;

                            SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
                            con1.ConnectionString = Program.pathdb_Weight;
                            SqlDataAdapter dtAdapter1 = new SqlDataAdapter();
                            con1.Open();

                            SqlConnection con2 = new SqlConnection(Program.pathdb_Weight);
                            con2.ConnectionString = Program.pathdb_Weight;
                            SqlDataAdapter dtAdapter2 = new SqlDataAdapter();
                            con2.Open();

                            // string sql7 = "Select [PaymentID] From [dbo].[TB_Payment] Where [PayDate]='" + Date_con + "' AND [ProductID]= '" + cb_productReport.SelectedValue.ToString() + "'  AND Trim([Remark])='บันทึกสำเร็จ'";
                            string sql7 = "Select [PaymentID] From [dbo].[TB_Payment] Where [PayDate]='" + Date_con + "'";

                            if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                            {
                                sql7 += "AND (" + Sort_Product + ")";
                            }

                            sql7 += " AND Trim([Remark])= 'บันทึกสำเร็จ'";

                            SqlCommand CM7 = new SqlCommand(sql7, con1);
                            SqlDataReader DR7 = CM7.ExecuteReader();
                            while (DR7.Read())
                            {
                                string PaymentID = DR7["PaymentID"].ToString();

                                try
                                {

                                    string sql2 = "Select (([VisualSP]* [Weigh_Net])/100) AS 'W_Visual'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [ValueStarch] >= 28 AND [StatusActive]=1 ";
                                    SqlCommand CM2 = new SqlCommand(sql2, con2);
                                    SqlDataReader DR2 = CM2.ExecuteReader();
                                    DR2.Read();
                                    {
                                        Total_W_Visual += Convert.ToDouble(DR2["W_Visual"].ToString());
                                    }
                                    DR2.Close();
                                    con2.Close();
                                }
                                catch { con2.Close(); }

                                try
                                {
                                    con2.Open();
                                    string sql3 = "Select Sum([Weigh_Net])AS 'W_Max28'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [ValueStarch] >= 28 AND [StatusActive]=1 ";
                                    SqlCommand CM3 = new SqlCommand(sql3, con2);
                                    SqlDataReader DR3 = CM3.ExecuteReader();
                                    DR3.Read();
                                    {
                                        Total_W_Max28 += Convert.ToDouble(DR3["W_Max28"].ToString());
                                    }
                                    DR3.Close();
                                    con2.Close();
                                }
                                catch { con2.Close(); }

                                try
                                {
                                    con2.Open();
                                    string sql4 = "Select Sum([Weigh_Net])AS 'W_Min23'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [ValueStarch] <= 23 AND [StatusActive]=1";
                                    SqlCommand CM4 = new SqlCommand(sql4, con2);
                                    SqlDataReader DR4 = CM4.ExecuteReader();
                                    DR4.Read();
                                    {
                                        Total_W_Min23 += Convert.ToDouble(DR4["W_Min23"].ToString());
                                    }
                                    DR4.Close();
                                    con2.Close();
                                }
                                catch { con2.Close(); }

                                con2.Open();
                                string sql5 = "Select Count([TicketCodeIn])AS 'CountItems'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [StatusActive]=1";
                                SqlCommand CM5 = new SqlCommand(sql5, con2);
                                SqlDataReader DR5 = CM5.ExecuteReader();
                                DR5.Read();
                                {
                                    Itmes_Count += Convert.ToInt16(DR5["CountItems"].ToString());
                                }
                                DR5.Close();
                                con2.Close();

                                try
                                {
                                    con2.Open();
                                    string sql6 = "Select Sum([Weigh_Net])AS 'W_Net'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [StatusActive]=1";
                                    SqlCommand CM6 = new SqlCommand(sql6, con2);
                                    SqlDataReader DR6 = CM6.ExecuteReader();
                                    DR6.Read();
                                    {
                                        Total_W_Net += Convert.ToDouble(DR6["W_Net"].ToString());
                                    }
                                    DR6.Close();
                                    con2.Close();
                                }
                                catch { con2.Close(); }

                                try
                                {
                                    con2.Open();
                                    string sql8 = "Select  ([Weigh_Net]*[ValueStarch]/100) AS 'W_Pay',(PricePayment/Weigh_Net) AS 'AVG_Price'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [StatusActive]=1";

                                    SqlCommand CM8 = new SqlCommand(sql8, con2);
                                    SqlDataReader DR8 = CM8.ExecuteReader();
                                    while (DR8.Read())
                                    {
                                        Total_W_Starch += Convert.ToDouble(DR8["W_Pay"].ToString());
                                        Total_PurPrice += Convert.ToDouble(DR8["AVG_Price"].ToString());
                                    }
                                    DR8.Close();
                                    con2.Close();
                                }

                                catch
                                {
                                    con2.Close();
                                }


                                try
                                {
                                    con2.Open();
                                    string sql9 = "Select Max(ValueStarch) AS 'Max_Strach'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [StatusActive]=1";
                                    SqlCommand CM9 = new SqlCommand(sql9, con2);
                                    SqlDataReader DR9 = CM9.ExecuteReader();
                                    DR9.Read();
                                    {
                                        if (Total_AVG_MaxStarch == 0)
                                        {
                                            Total_AVG_MaxStarch = Convert.ToDouble(DR9["Max_Strach"].ToString());
                                        }
                                        else if (Convert.ToDouble(DR9["Max_Strach"].ToString()) > Total_AVG_MaxStarch)
                                        {
                                            Total_AVG_MaxStarch = Convert.ToDouble(DR9["Max_Strach"].ToString());
                                        }

                                    }
                                    DR9.Close();
                                    con2.Close();
                                }
                                catch { con2.Close(); }



                                try
                                {
                                    con2.Open();

                                    string sql10 = "Select Min(ValueStarch) AS 'Min_Strach'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [StatusActive]=1";
                                    SqlCommand CM10 = new SqlCommand(sql10, con2);
                                    SqlDataReader DR10 = CM10.ExecuteReader();
                                    DR10.Read();
                                    {

                                        if (Total_AVG_MinStarch == 0)
                                        {
                                            Total_AVG_MinStarch = Convert.ToDouble(DR10["Min_Strach"].ToString());
                                            AVG_MinStarch = Total_AVG_MinStarch;
                                        }
                                        else if (Convert.ToDouble(DR10["Min_Strach"].ToString()) < Total_AVG_MinStarch)
                                        {
                                            Total_AVG_MinStarch = Convert.ToDouble(DR10["Min_Strach"].ToString());
                                        }

                                    }
                                    DR10.Close();
                                    con2.Close();
                                }
                                catch
                                {
                                    con2.Close();
                                }

                            }

                            AVG_PurStarch = (Total_W_Starch / Total_W_Net) * 100;
                            Total_PurPrice = Total_PurPrice / Itmes_Count;
                            Total_PriceStarchs = Total_W_Net / Total_W_Starch;
                            Total_AVG_W_Max28 = (Total_W_Max28 / Total_W_Net) * 100;
                            Total_AVG_W_Min23 = (Total_W_Min23 / Total_W_Net) * 100;
                            Total_AVG_W_Visual = (Total_W_Visual / Total_W_Net) * 100;

                            dtg_CalDay.Rows[i].Cells[1].Value = Total_W_Net.ToString("##,###");
                            dtg_CalDay.Rows[i].Cells[2].Value = Total_W_Starch.ToString("##,###");
                            dtg_CalDay.Rows[i].Cells[3].Value = Total_AVG_MaxStarch.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[4].Value = Total_AVG_MinStarch.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[5].Value = AVG_PurStarch.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[6].Value = Total_PurPrice.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[7].Value = Total_PriceStarchs.ToString("f2");
                            if (Total_W_Max28 == 0) { dtg_CalDay.Rows[i].Cells[8].Value = Total_W_Max28.ToString("f2"); }
                            else { dtg_CalDay.Rows[i].Cells[8].Value = Total_W_Max28.ToString("##,###"); }
                            dtg_CalDay.Rows[i].Cells[9].Value = Total_AVG_W_Max28.ToString("f2");
                            if (Total_W_Min23 == 0) { dtg_CalDay.Rows[i].Cells[10].Value = Total_W_Min23.ToString("f2"); }
                            else { dtg_CalDay.Rows[i].Cells[10].Value = Total_W_Min23.ToString("##,###"); }
                            dtg_CalDay.Rows[i].Cells[11].Value = Total_AVG_W_Min23.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[12].Value = Total_W_Visual.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[13].Value = Total_AVG_W_Visual.ToString("f2");
                            //System.Math.Round(Total_AVG_MaxStarch);

                            AVG_PriceStarchs += Total_PriceStarchs;
                            Sum_Total_WNet += Total_W_Net;
                            Sum_Total_WStarch += Total_W_Starch;
                            AVG_PurPrice += Total_PurPrice;
                            Sum_Total_W_Max28 += Total_W_Max28;
                            Sum_Total_W_Min23 += Total_W_Min23;
                            Sum_Total_W_Visual += Total_W_Visual;

                            if (Total_AVG_MaxStarch > AVG_MaxStarch)
                            {
                                AVG_MaxStarch = Total_AVG_MaxStarch;
                            }

                            if (Total_AVG_MinStarch < AVG_MinStarch)
                            {
                                AVG_MinStarch = Total_AVG_MinStarch;
                            }

                            Total_W_Net = 0;
                            Total_W_Starch = 0;
                            Total_AVG_MaxStarch = 0;
                            Total_AVG_MinStarch = 0;
                            Total_PurPrice = 0;
                            Total_W_Max28 = 0;
                            Total_W_Min23 = 0;
                            Total_PriceStarchs = 0;
                            Total_W_Visual = 0;
                        }


                        else
                        {
                            int Rows = dtg_CalDay.RowCount - 1;

                            AVG_PurStarch = (Sum_Total_WStarch / Sum_Total_WNet) * 100;
                            AVG_PurPrice = AVG_PurPrice / Rows;
                            AVG_W_Max28 = Sum_Total_W_Max28 / Sum_Total_WNet;
                            AVG_W_Min23 = Sum_Total_W_Min23 / Sum_Total_WNet;
                            AVG_PriceStarchs = AVG_PriceStarchs / Rows;
                            AVG_W_Visual = Sum_Total_W_Visual / Sum_Total_WNet;

                            dtg_CalDay.Rows[i].Cells[1].Value = Sum_Total_WNet.ToString("##,###");
                            dtg_CalDay.Rows[i].Cells[2].Value = Sum_Total_WStarch.ToString("##,###");
                            dtg_CalDay.Rows[i].Cells[3].Value = AVG_MaxStarch.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[4].Value = AVG_MinStarch.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[5].Value = AVG_PurStarch.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[6].Value = AVG_PurPrice.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[7].Value = AVG_PriceStarchs.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[8].Value = Sum_Total_W_Max28.ToString("##,###");
                            dtg_CalDay.Rows[i].Cells[9].Value = AVG_W_Max28.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[10].Value = Sum_Total_W_Min23.ToString("##,###");
                            dtg_CalDay.Rows[i].Cells[11].Value = AVG_W_Min23.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[12].Value = Sum_Total_W_Visual.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[13].Value = AVG_W_Visual.ToString("f2");

                            Sum_Total_WNet = 0;
                            Sum_Total_WStarch = 0;
                            AVG_MaxStarch = 0;
                            AVG_MinStarch = 0;
                            AVG_PurPrice = 0;
                            AVG_PriceStarchs = 0;
                            AVG_W_Visual = 0;
                        }

                    }


                    DataTable dt1 = new DataTable();

                    dt1.Columns.AddRange(new DataColumn[14] { new DataColumn("Date"), new DataColumn("W_Net"), new DataColumn("W_StarchIN"), new DataColumn("Max_StarchIN"), new DataColumn("Min_StarchIN"), new DataColumn("AVG_StarchPur"), new DataColumn("AVG_PricePur"), new DataColumn("AVG_PriceStarch"), new DataColumn("W_Starch28"), new DataColumn("AVG_Starch28"), new DataColumn("W_Starch23"), new DataColumn("AVG_Starch23"), new DataColumn("W_Visual"), new DataColumn("AVG_Visual") });

                    foreach (DataGridViewRow dgv in dtg_CalDay.Rows)
                    {
                        dt1.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value, dgv.Cells[6].Value, dgv.Cells[7].Value, dgv.Cells[8].Value, dgv.Cells[9].Value, dgv.Cells[10].Value, dgv.Cells[11].Value, dgv.Cells[12].Value, dgv.Cells[13].Value);
                    }

                    ds1.Tables.Add(dt1);
                    ds1.WriteXmlSchema("dataCost.xml");

                    con.Close();


                    //dtg_Cal.Visible = true;
                    //dtg_Cal.Dock = DockStyle.Fill;

                    //transefer data to crystalreportviewer

                    Crp_CostSP cr = new Crp_CostSP();
                    cr.SetDataSource(ds1);
                    cr.SetParameterValue("Report_Name", cb_typeReport.Text);
                    //cr.SetParameterValue("Product_Name", cb_productReport.SelectedValue.ToString() + "-" + cb_productReport.Text);
                    cr.SetParameterValue("Product_Name", lbl_selectProduct.Text);
                    cr.SetParameterValue("St_date", dtp_stReport.Value.ToShortDateString());
                    cr.SetParameterValue("Ed_date", dtp_edReport.Value.ToShortDateString());
                    crystalReportViewer1.ReportSource = cr;
                    crystalReportViewer1.Refresh();


                }

                //Report Hold
                if (id_print == 47) //SP report by product   Monthly
                {
                    //DataSet ds1 = new DataSet();
                    DataTable dt = new DataTable();
                    //dtg_Cal.Visible = true;
                    //dtg_Cal.Dock = DockStyle.Fill;


                    dt.Columns.AddRange(new DataColumn[14] { new DataColumn("Date"), new DataColumn("W_Net"), new DataColumn("W_StarchIN"), new DataColumn("Max_StarchIN"), new DataColumn("Min_StarchIN"), new DataColumn("AVG_StarchPur"), new DataColumn("AVG_PricePur"), new DataColumn("AVG_PriceStarch"), new DataColumn("W_Starch28"), new DataColumn("AVG_Starch28"), new DataColumn("W_Starch23"), new DataColumn("AVG_Starch23"), new DataColumn("W_Visual"), new DataColumn("AVG_Visual") });

                    string Date = "";
                    string W_Net = "";
                    string W_StarchIN = "";
                    string Max_StarchIN = "";
                    string Min_StarchIN = "";
                    string AVG_StarchPur = "";
                    string AVG_PricePur = "";
                    string AVG_PriceStarch = "";
                    string W_Starch28 = "";
                    string AVG_Starch28 = "";
                    string W_Starch23 = "";
                    string AVG_Starch23 = "";
                    string W_Visual = "";
                    string AVG_Visual = "";

                    string st_date = dtp_stReport.Value.ToString("yyyy-MM-dd") + " 00:00:00.000";
                    string ed_date = dtp_edReport.Value.ToString("yyyy-MM-dd") + " 00:00:00.000";

                    //string connectionstring = @"data source=192.168.111.225;initial catalog=SapthipNewDB;uid=truck_scale; pwd=pass@2020;";
                    //string connectionstring = Program.pathdb_Weight;
                    con.Open();


                    // string sql1 = "Select DISTINCT([PayDate]) AS 'DateS' From[dbo].[TB_Payment] Where[PayDate] Between '" + ST_Date + "' AND '" + ED_Date + "'  AND [ProductID]= '" + cb_productReport.SelectedValue.ToString() + "' Order by [DateS]";

                    string sql1 = "";

                    sql1 += "Select DISTINCT([PayDate]) AS 'DateS' From[dbo].[TB_Payment] Where[PayDate] Between '" + ST_Date + "' AND '" + ED_Date + "'";

                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql1 += "AND (" + Sort_Product + ")";
                    }

                    sql1 += " Order by [DateS]";

                    SqlCommand CM = new SqlCommand(sql1, con);
                    SqlDataReader DR = CM.ExecuteReader();

                    //SqlConnection Conn = new SqlConnection(connectionstring);
                    //SqlCommand Comm = new SqlCommand(sql, con);
                    //con.Open();
                    //SqlDataReader DR = Comm.ExecuteReader();
                    while (DR.Read())
                    {
                        DateTime DT = Convert.ToDateTime(DR.GetValue(0).ToString());
                        Date = DT.Day.ToString() + "/" + DT.Month.ToString() + "/" + DT.Year.ToString();

                        dt.Rows.Add(Date, W_Net, W_StarchIN, Max_StarchIN, Min_StarchIN, AVG_StarchPur, AVG_PricePur, AVG_PriceStarch, W_Starch28, AVG_Starch28, W_Starch23, AVG_Starch23, W_Visual, AVG_Visual);
                    }
                    con.Close();

                    dt.Rows.Add("รวมสะสม", "", "", "", "", "", "", "", "", "", "", "", "", "");

                    dtg_CalDay.DataSource = dt;

                    dtg_CalDay.Columns[0].HeaderText = "วันที่";
                    dtg_CalDay.Columns[1].HeaderText = "นน.รับเข้า (กก.)";
                    dtg_CalDay.Columns[2].HeaderText = "นน.แป้งรับเข้า";
                    dtg_CalDay.Columns[3].HeaderText = "%แป้งสูงสุดที่รับ";
                    dtg_CalDay.Columns[4].HeaderText = "%แป้งต่ำสุดที่รับ";
                    dtg_CalDay.Columns[5].HeaderText = "%แป้งที่ซื้อเฉลี่ย";
                    dtg_CalDay.Columns[6].HeaderText = "ราคาซื้อเฉลี่ย";
                    dtg_CalDay.Columns[7].HeaderText = "ราคาแป้งเฉลี่ย";
                    dtg_CalDay.Columns[8].HeaderText = "นน.แป้ง >28%";
                    dtg_CalDay.Columns[9].HeaderText = "% นน.แป้ง >28% ";
                    dtg_CalDay.Columns[10].HeaderText = "นน.แป้ง <23%";
                    dtg_CalDay.Columns[11].HeaderText = "% นน.แป้ง <23%";
                    dtg_CalDay.Columns[12].HeaderText = "นน.สิ่งเจือปน";
                    dtg_CalDay.Columns[13].HeaderText = "% สิ่งเจือปน";

                    //dtg_CalDay.Columns[0].Width = 80;

                    //Summary

                    double Sum_Total_WNet = 0;
                    double Sum_Total_WStarch = 0;
                    double AVG_MaxStarch = 0;
                    double AVG_MinStarch = 0;
                    double AVG_PurStarch = 0;
                    double AVG_PriceStarchs = 0;
                    double AVG_PurPrice = 0;
                    double Sum_Total_W_Max28 = 0;
                    double Sum_Total_W_Min23 = 0;
                    double AVG_W_Max28 = 0;
                    double AVG_W_Min23 = 0;
                    double Sum_Total_W_Visual = 0;
                    double AVG_W_Visual = 0;

                    for (int i = 0; i < dtg_CalDay.Rows.Count; i++)
                    {
                        if (dtg_CalDay.Rows[i].Cells[0].Value.ToString() != "รวมสะสม")
                        {
                            DateTime DT_con = Convert.ToDateTime(dtg_CalDay.Rows[i].Cells[0].Value.ToString());

                            String Date_con = DT_con.Year.ToString() + "-" + DT_con.Month.ToString() + "-" + DT_con.Day.ToString();


                            // Total 
                            int Itmes_Count = 0;
                            double Total_W_Net = 0;
                            double Total_W_Starch = 0;
                            double Total_AVG_MaxStarch = 0;
                            double Total_AVG_MinStarch = 0;
                            double Total_PriceStarchs = 0;
                            double Total_PurPrice = 0;
                            double Total_W_Max28 = 0;
                            double Total_W_Min23 = 0;
                            double Total_AVG_W_Max28 = 0;
                            double Total_AVG_W_Min23 = 0;
                            double Total_W_Visual = 0;
                            double Total_AVG_W_Visual = 0;

                            SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
                            con1.ConnectionString = Program.pathdb_Weight;
                            SqlDataAdapter dtAdapter1 = new SqlDataAdapter();
                            con1.Open();

                            SqlConnection con2 = new SqlConnection(Program.pathdb_Weight);
                            con2.ConnectionString = Program.pathdb_Weight;
                            SqlDataAdapter dtAdapter2 = new SqlDataAdapter();
                            con2.Open();

   //string sql7 = "Select [PaymentID] From [dbo].[TB_Payment] Where [PayDate]='" + Date_con + "' AND [ProductID]= '" + cb_productReport.SelectedValue.ToString() + "' AND Trim([Remark])='บันทึกสำเร็จ'";

                            string sql7 = "";

                            sql1 += "[PaymentID] From [dbo].[TB_Payment] Where [PayDate]= Between '" + ST_Date + "' AND '" + ED_Date + "'";

                            if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                            {
                                sql1 += "AND (" + Sort_Product + ")";
                            }

                            sql1 += " AND Trim([Remark])='บันทึกสำเร็จ'";
                                                        

                            SqlCommand CM7 = new SqlCommand(sql7, con1);
                            SqlDataReader DR7 = CM7.ExecuteReader();
                            while (DR7.Read())
                            {
                                string PaymentID = DR7["PaymentID"].ToString();

                                try
                                {

                                    string sql2 = "Select (([VisualSP]* [Weigh_Net])/100) AS 'W_Visual'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [ValueStarch] >= 28 AND [StatusActive]=1 ";
                                    SqlCommand CM2 = new SqlCommand(sql2, con2);
                                    SqlDataReader DR2 = CM2.ExecuteReader();
                                    DR2.Read();
                                    {
                                        Total_W_Visual += Convert.ToDouble(DR2["W_Visual"].ToString());
                                    }
                                    DR2.Close();
                                    con2.Close();
                                }
                                catch { con2.Close(); }


                                //Total_W_Max28
                                try
                                {
                                    con2.Open();
                                    string sql3 = "Select Sum([Weigh_Net])AS 'W_Max28'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [ValueStarch] >= 28 AND [StatusActive]=1 ";
                                    SqlCommand CM3 = new SqlCommand(sql3, con2);
                                    SqlDataReader DR3 = CM3.ExecuteReader();
                                    DR3.Read();
                                    {
                                        Total_W_Max28 += Convert.ToDouble(DR3["W_Max28"].ToString());
                                    }
                                    DR3.Close();
                                    con2.Close();
                                }
                                catch { con2.Close(); }


                                //Total_W_Min23
                                try
                                {
                                    con2.Open();
                                    string sql4 = "Select Sum([Weigh_Net])AS 'W_Min23'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [ValueStarch] <= 23 AND [StatusActive]=1";
                                    SqlCommand CM4 = new SqlCommand(sql4, con2);
                                    SqlDataReader DR4 = CM4.ExecuteReader();
                                    DR4.Read();
                                    {
                                        Total_W_Min23 += Convert.ToDouble(DR4["W_Min23"].ToString());
                                    }
                                    DR4.Close();
                                    con2.Close();
                                }
                                catch { con2.Close(); }


                                //CountItems
                                con2.Open();
                                string sql5 = "Select Count([TicketCodeIn])AS 'CountItems'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [StatusActive]=1";
                                SqlCommand CM5 = new SqlCommand(sql5, con2);
                                SqlDataReader DR5 = CM5.ExecuteReader();
                                DR5.Read();
                                {
                                    Itmes_Count += Convert.ToInt16(DR5["CountItems"].ToString());
                                }
                                DR5.Close();
                                con2.Close();

                                //W_Net
                                con2.Open();
                                string sql6 = "Select Sum([Weigh_Net])AS 'W_Net'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [StatusActive]=1";
                                SqlCommand CM6 = new SqlCommand(sql6, con2);
                                SqlDataReader DR6 = CM6.ExecuteReader();
                                DR6.Read();
                                {
                                    Total_W_Net += Convert.ToDouble(DR6["W_Net"].ToString());
                                }
                                DR6.Close();
                                con2.Close();


                                //AVG_Price
                                con2.Open();
                                string sql8 = "Select  ([Weigh_Net]*[ValueStarch]/100) AS 'W_Pay',(PricePayment/Weigh_Net) AS 'AVG_Price'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [StatusActive]=1";

                                SqlCommand CM8 = new SqlCommand(sql8, con2);
                                SqlDataReader DR8 = CM8.ExecuteReader();
                                while (DR8.Read())
                                {
                                    Total_W_Starch += Convert.ToDouble(DR8["W_Pay"].ToString());
                                    Total_PurPrice += Convert.ToDouble(DR8["AVG_Price"].ToString());
                                }
                                DR8.Close();
                                con2.Close();


                                //Max_Strach
                                con2.Open();
                                string sql9 = "Select Max(ValueStarch) AS 'Max_Strach'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [StatusActive]=1";
                                SqlCommand CM9 = new SqlCommand(sql9, con2);
                                SqlDataReader DR9 = CM9.ExecuteReader();
                                DR9.Read();
                                {
                                    if (Total_AVG_MaxStarch == 0)
                                    {
                                        Total_AVG_MaxStarch = Convert.ToDouble(DR9["Max_Strach"].ToString());
                                    }
                                    else if (Convert.ToDouble(DR9["Max_Strach"].ToString()) > Total_AVG_MaxStarch)
                                    {
                                        Total_AVG_MaxStarch = Convert.ToDouble(DR9["Max_Strach"].ToString());
                                    }

                                }
                                DR9.Close();


                                //Min_Strach
                                string sql10 = "Select Min(ValueStarch) AS 'Min_Strach'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [StatusActive]=1";
                                SqlCommand CM10 = new SqlCommand(sql10, con2);
                                SqlDataReader DR10 = CM10.ExecuteReader();
                                DR10.Read();
                                {

                                    if (Total_AVG_MinStarch == 0)
                                    {
                                        Total_AVG_MinStarch = Convert.ToDouble(DR10["Min_Strach"].ToString());
                                        AVG_MinStarch = Total_AVG_MinStarch;
                                    }
                                    else if (Convert.ToDouble(DR10["Min_Strach"].ToString()) < Total_AVG_MinStarch)
                                    {
                                        Total_AVG_MinStarch = Convert.ToDouble(DR10["Min_Strach"].ToString());
                                    }

                                }
                                DR10.Close();


                            }

                            AVG_PurStarch = (Total_W_Starch / Total_W_Net) * 100;
                            Total_PurPrice = Total_PurPrice / Itmes_Count;
                            Total_PriceStarchs = Total_W_Net / Total_W_Starch;
                            Total_AVG_W_Max28 = (Total_W_Max28 / Total_W_Net) * 100;
                            Total_AVG_W_Min23 = (Total_W_Min23 / Total_W_Net) * 100;
                            Total_AVG_W_Visual = (Total_W_Visual / Total_W_Net) * 100;

                            dtg_CalDay.Rows[i].Cells[1].Value = Total_W_Net.ToString("##,###");
                            dtg_CalDay.Rows[i].Cells[2].Value = Total_W_Starch.ToString("##,###");
                            dtg_CalDay.Rows[i].Cells[3].Value = Total_AVG_MaxStarch.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[4].Value = Total_AVG_MinStarch.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[5].Value = AVG_PurStarch.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[6].Value = Total_PurPrice.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[7].Value = Total_PriceStarchs.ToString("f2");

                            //dtg_CalDay.Rows[i].Cells[8].Value = Total_W_Max28.ToString("f2");

                            dtg_CalDay.Rows[i].Cells[9].Value = Total_AVG_W_Max28.ToString("f2");


                            if (Total_W_Max28 == 0) { dtg_CalDay.Rows[i].Cells[8].Value = Total_W_Max28.ToString("f2"); }
                            else { dtg_CalDay.Rows[i].Cells[8].Value = Total_W_Max28.ToString("##,###"); }

                            if (Total_W_Min23 == 0) { dtg_CalDay.Rows[i].Cells[10].Value = Total_W_Min23.ToString("f2"); }
                            else { dtg_CalDay.Rows[i].Cells[10].Value = Total_W_Min23.ToString("##,###"); }

                            dtg_CalDay.Rows[i].Cells[11].Value = Total_AVG_W_Min23.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[12].Value = Total_W_Visual.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[13].Value = Total_AVG_W_Visual.ToString("f2");
                            //System.Math.Round(Total_AVG_MaxStarch);

                            AVG_PriceStarchs += Total_PriceStarchs;
                            Sum_Total_WNet += Total_W_Net;
                            Sum_Total_WStarch += Total_W_Starch;
                            AVG_PurPrice += Total_PurPrice;
                            Sum_Total_W_Max28 += Total_W_Max28;
                            Sum_Total_W_Min23 += Total_W_Min23;
                            Sum_Total_W_Visual += Total_W_Visual;

                            if (Total_AVG_MaxStarch > AVG_MaxStarch)
                            {
                                AVG_MaxStarch = Total_AVG_MaxStarch;
                            }

                            if (Total_AVG_MinStarch < AVG_MinStarch)
                            {
                                AVG_MinStarch = Total_AVG_MinStarch;
                            }

                            Total_W_Net = 0;
                            Total_W_Starch = 0;
                            Total_AVG_MaxStarch = 0;
                            Total_AVG_MinStarch = 0;
                            Total_PurPrice = 0;
                            Total_W_Max28 = 0;
                            Total_W_Min23 = 0;
                            Total_PriceStarchs = 0;
                            Total_W_Visual = 0;
                        }


                        else
                        {
                            int Rows = dtg_CalDay.RowCount - 1;

                            AVG_PurStarch = (Sum_Total_WStarch / Sum_Total_WNet) * 100;
                            AVG_PurPrice = AVG_PurPrice / Rows;
                            AVG_W_Max28 = (Sum_Total_W_Max28 / Sum_Total_WNet) * 100;
                            AVG_W_Min23 = (Sum_Total_W_Min23 / Sum_Total_WNet) * 100;
                            AVG_PriceStarchs = AVG_PriceStarchs / Rows;
                            AVG_W_Visual = (Sum_Total_W_Visual / Sum_Total_WNet) * 100;

                            dtg_CalDay.Rows[i].Cells[1].Value = Sum_Total_WNet.ToString("##,###");
                            dtg_CalDay.Rows[i].Cells[2].Value = Sum_Total_WStarch.ToString("##,###");
                            dtg_CalDay.Rows[i].Cells[3].Value = AVG_MaxStarch.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[4].Value = AVG_MinStarch.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[5].Value = AVG_PurStarch.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[6].Value = AVG_PurPrice.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[7].Value = AVG_PriceStarchs.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[8].Value = Sum_Total_W_Max28.ToString("##,###");
                            dtg_CalDay.Rows[i].Cells[9].Value = AVG_W_Max28.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[10].Value = Sum_Total_W_Min23.ToString("##,###");
                            dtg_CalDay.Rows[i].Cells[11].Value = AVG_W_Min23.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[12].Value = Sum_Total_W_Visual.ToString("f2");
                            dtg_CalDay.Rows[i].Cells[13].Value = AVG_W_Visual.ToString("f2");

                            Sum_Total_WNet = 0;
                            Sum_Total_WStarch = 0;
                            AVG_MaxStarch = 0;
                            AVG_MinStarch = 0;
                            AVG_PurPrice = 0;
                            AVG_PriceStarchs = 0;
                            AVG_W_Visual = 0;
                        }

                    }



                    ////Add Datagride Veiws Day To Datagride Views Month

                    DataTable dt2 = new DataTable();
                    dt2.Columns.AddRange(new DataColumn[14] { new DataColumn("Date"), new DataColumn("W_Net"), new DataColumn("W_StarchIN"), new DataColumn("Max_StarchIN"), new DataColumn("Min_StarchIN"), new DataColumn("AVG_StarchPur"), new DataColumn("AVG_PricePur"), new DataColumn("AVG_PriceStarch"), new DataColumn("W_Starch28"), new DataColumn("AVG_Starch28"), new DataColumn("W_Starch23"), new DataColumn("AVG_Starch23"), new DataColumn("W_Visual"), new DataColumn("AVG_Visual") });


                    //dt2.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "");
                    dtg_CalMonth.DataSource = dt2;

                    int Count_Rows = 0;
                    double Col1 = 0;
                    double Col2 = 0;
                    double Col3 = 0;
                    double Col4 = 0;
                    double Col5 = 0;
                    double Col6 = 0;
                    double Col7 = 0;
                    double Col8 = 0;
                    double Col9 = 0;
                    double Col10 = 0;
                    double Col11 = 0;
                    double Col12 = 0;
                    double Col13 = 0;

                    int Row_CalMonth = 0;
                    double Total_Col5 = 0;
                    double AVG_PurPP = 0;
                    double AVG_PriceST = 0;
                    double AVG_28 = 0;
                    double AVG_23 = 0;
                    double AVG_VS = 0;

                    //Create Mont on DTG Month
                    for (int x = 0; x < dtg_CalDay.RowCount; x++)
                    {
                        DateTime DateT;
                        if (dtg_CalDay.Rows[x].Cells[0].Value.ToString() != "รวมสะสม")
                        {
                            DateT = Convert.ToDateTime(dtg_CalDay.Rows[x].Cells[0].Value.ToString());

                            if (dtg_CalMonth.RowCount == 0)
                            {
                                dt2.Rows.Add(DateT.ToString("MM/yyyy"), "", "", "", "", "", "", "", "", "", "", "", "", "");
                                dtg_CalMonth.DataSource = dt2;

                                Col1 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[1].Value.ToString());
                                Col2 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[2].Value.ToString());
                                Col3 = Convert.ToDouble(dtg_CalDay.Rows[x].Cells[3].Value.ToString());
                                Col4 = Convert.ToDouble(dtg_CalDay.Rows[x].Cells[4].Value.ToString());
                                Col5 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[5].Value.ToString());
                                Col6 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[6].Value.ToString());
                                Col7 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[7].Value.ToString());
                                Col8 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[8].Value.ToString());
                                Col9 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[9].Value.ToString());
                                Col10 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[10].Value.ToString());
                                Col11 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[11].Value.ToString());
                                Col12 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[12].Value.ToString());
                                Col13 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[13].Value.ToString());
                                Count_Rows++;

                            }

                            else
                            {
                                int STS_Check = 0;

                                for (int v = 0; v < dtg_CalMonth.RowCount; v++)
                                {
                                    //ค้นหาเดือนที่ไม่ซ้ำ
                                    if (DateT.ToString("MM/yyyy") != dtg_CalMonth.Rows[v].Cells[0].Value.ToString().Trim())
                                    {
                                        STS_Check = 1;
                                    }

                                    //ถ้าเดือนเดียวไม่ต้องเพิ่มเดือน
                                    else
                                    {
                                        STS_Check = 0;

                                        Col1 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[1].Value.ToString());
                                        Col2 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[2].Value.ToString());
                                        Col3 = Convert.ToDouble(dtg_CalDay.Rows[x].Cells[3].Value.ToString());
                                        Col4 = Convert.ToDouble(dtg_CalDay.Rows[x].Cells[4].Value.ToString());
                                        Col5 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[5].Value.ToString());
                                        Col6 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[6].Value.ToString());
                                        Col7 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[7].Value.ToString());
                                        Col8 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[8].Value.ToString());
                                        Col9 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[9].Value.ToString());
                                        Col10 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[10].Value.ToString());
                                        Col11 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[11].Value.ToString());
                                        Col12 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[12].Value.ToString());
                                        Col13 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[13].Value.ToString());
                                    }



                                    dtg_CalMonth.Rows[v].Cells[1].Value = Col1.ToString("##,####");
                                    dtg_CalMonth.Rows[v].Cells[2].Value = Col2.ToString("##,####");
                                    dtg_CalMonth.Rows[v].Cells[3].Value = Col3.ToString("f2");
                                    dtg_CalMonth.Rows[v].Cells[4].Value = Col4.ToString("f2");
                                    dtg_CalMonth.Rows[v].Cells[5].Value = Col5.ToString("f2");
                                    dtg_CalMonth.Rows[v].Cells[6].Value = Col6.ToString("f2");
                                    dtg_CalMonth.Rows[v].Cells[7].Value = Col7.ToString("f2");
                                    dtg_CalMonth.Rows[v].Cells[8].Value = Col8.ToString("##,###");
                                    dtg_CalMonth.Rows[v].Cells[9].Value = Col9.ToString("##,###");
                                    dtg_CalMonth.Rows[v].Cells[10].Value = Col10.ToString("f2");
                                    dtg_CalMonth.Rows[v].Cells[11].Value = Col11.ToString("f2");
                                    dtg_CalMonth.Rows[v].Cells[12].Value = Col12.ToString("##,###");
                                }

                                if (STS_Check == 1)
                                {
                                    dt2.Rows.Add(DateT.ToString("MM/yyyy"), "", "", "", "", "", "", "", "", "", "", "", "", "");
                                    dtg_CalMonth.DataSource = dt2;
                                }
                            }

                        }
                    }


                    dt2.Rows.Add("รวมสะสม", "", "", "", "", "", "", "", "", "", "", "", "", "");
                    dtg_CalMonth.DataSource = dt2;

                }

                //Report OK Purchase
                if (id_print == 48) //LO Service Report
                {
                    con.Open();
                    // string sql1 = "Select * From [V_RpLO] Where [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "' AND WeightPrice <> 0 OR LoadPrice <> 0 Order by [TicketCodeIn]";

                    if (rdo_purchase.Checked == true)
                    {
                        sql = "SELECT *  FROM  [dbo].[V_RpLO] WHERE ([OutboundDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    sql = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE ([WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    //}


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    if (rdo_purchase.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                        }
                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    if (Vendor_Code != "")
                    //    {
                    //        sql += "AND ([HeaderBill_NameCodeCus] ='" + Vendor_Code + "')";
                    //    }
                    //    if (Customer_Code != "")
                    //    {
                    //        sql += " AND  [CustomerID]= '" + Customer_Code + "'";
                    //    }
                    //}


                    sql += " AND WeightPrice <> 0 OR LoadPrice <> 0 Order by [TicketCodeIn]";

                    DataSet ds = new DataSet();
                    crp_Lo crp_Lo = new crp_Lo();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(ds, "crt_LO");
                    crp_Lo.SetDataSource(ds.Tables["crt_LO"]);
                    crp_Lo.SetParameterValue("st_date", ST_Date.ToString());
                    crp_Lo.SetParameterValue("ed_date", ED_Date.ToString());
                    crystalReportViewer1.ReportSource = crp_Lo;
                    crystalReportViewer1.Refresh();
                    con.Close();
                }

                //Report OK Purchase
                if (id_print == 49) //Fincense Pending Payment
                {
                    crp_pendingFinance crp_SP = new crp_pendingFinance();

                    // string sql1 = "Select * From [V_PendingFinance] Where [SaveDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999'  AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "'  Order by [SaveDate]";

                    if (rdo_purchase.Checked == true)
                    {
                        sql = "SELECT *  FROM  [dbo].[V_PendingFinance] WHERE ([SaveDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    sql = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE ([WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    //}


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    if (rdo_purchase.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                        }
                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    if (Vendor_Code != "")
                    //    {
                    //        sql += "AND ([HeaderBill_NameCodeCus] ='" + Vendor_Code + "')";
                    //    }
                    //    if (Customer_Code != "")
                    //    {
                    //        sql += " AND  [CustomerID]= '" + Customer_Code + "'";
                    //    }
                    //}


                    sql += " Order by [SaveDate]";

                    con.Open();
                    DataSet ds = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(ds, "crt_pendingFN");
                    crp_SP.SetDataSource(ds.Tables["crt_pendingFN"]);
                    //crp_SP.SetParameterValue("st_date", ST_Date.ToString());
                    //crp_SP.SetParameterValue("ed_date", ED_Date.ToString());
                    crystalReportViewer1.ReportSource = crp_SP;
                    crystalReportViewer1.Refresh();
                    con.Close();
                }

                //Report OK  All
                if (id_print == 51) //QA Report Personal type
                {
                    crp_LabReport crp_Lab = new crp_LabReport();

                    //     string sql1 = "Select * From [V_RPLab1] Where [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999'";

                    if (rdo_purchase.Checked == true)
                    {
                        sql = "SELECT *  FROM  [dbo].[V_RPLab1] WHERE ([RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    }

                    if (rdo_sale.Checked == true)
                    {
                        sql = "SELECT *  FROM  [dbo].[V_RPLab1] WHERE ([RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    }


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    if (rdo_purchase.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                        }
                    }

                    if (rdo_sale.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCodeCus] ='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [CustomerID]= '" + Customer_Code + "'";
                        }
                    }

                    sql += " Order by [TicketCodeIn]";

                    con.Open();
                    DataSet ds = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(ds, "crt_qa");
                    crp_Lab.SetDataSource(ds.Tables["crt_qa"]);
                    crp_Lab.SetParameterValue("st_date", ST_Date.ToString());
                    crp_Lab.SetParameterValue("ed_date", ED_Date.ToString());
                    crystalReportViewer1.ReportSource = crp_Lab;
                    crystalReportViewer1.Refresh();
                    con.Close();
                }

                //Report OK Purchase filter product
                if (id_print == 52) //QA Report All Lab RM-004, RM-001
                {
                    if (rdo_purchase.Checked == true)
                    {
                        //sql = "SELECT *  FROM  [dbo].[V_WeightData] WHERE ([WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";

                        if (Sort_Product == "ProductID ='RM-004'")
                        {
                            sql = "Select * From [V_RPQA_RM004] Where [CreateDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999'";

                        }

                        if (Sort_Product == "ProductID ='RM-001'")
                        {
                            sql = "Select * From [V_RPQA_RM001] Where [CreateDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999'";
                        }

                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    sql = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE ([WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    //}


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    if (rdo_purchase.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                        }
                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    if (Vendor_Code != "")
                    //    {
                    //        sql += "AND ([HeaderBill_NameCodeCus] ='" + Vendor_Code + "')";
                    //    }
                    //    if (Customer_Code != "")
                    //    {
                    //        sql += " AND  [CustomerID]= '" + Customer_Code + "'";
                    //    }
                    //}

                    sql += " Order by [TicketCodeIn]";

                    if (Sort_Product == "ProductID ='RM-004'")
                    {
                        con.Open();
                        DataSet ds = new DataSet();
                        crp_LabRM004 crp_Lab = new crp_LabRM004();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                        adapter.SelectCommand.CommandTimeout = 0;
                        adapter.Fill(ds, "crt_qaRM004");
                        crp_Lab.SetDataSource(ds.Tables["crt_qaRM004"]);
                        crp_Lab.SetParameterValue("st_date", ST_Date.ToString());
                        crp_Lab.SetParameterValue("ed_date", ED_Date.ToString());
                        crystalReportViewer1.ReportSource = crp_Lab;
                        crystalReportViewer1.Refresh();
                        con.Close();
                    }
                    else if (Sort_Product == "ProductID ='RM-001'")
                    {
                        con.Open();
                        DataSet ds = new DataSet();
                        crp_LabRM001 crp_Lab = new crp_LabRM001();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                        adapter.SelectCommand.CommandTimeout = 0;
                        adapter.Fill(ds, "crt_qaRM001");
                        crp_Lab.SetDataSource(ds.Tables["crt_qaRM001"]);
                        crp_Lab.SetParameterValue("st_date", ST_Date.ToString());
                        crp_Lab.SetParameterValue("ed_date", ED_Date.ToString());
                        crystalReportViewer1.ReportSource = crp_Lab;
                        crystalReportViewer1.Refresh();
                        con.Close();
                    }


                    else
                    {
                        MessageBox.Show("ไม่มีรูปแบบรายงานในส่ินค้าตัวนี้", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                 
                }

                //Report OK Purchase  filter product before Payemnt
                if (id_print == 53) //รายงานการรับสินค้า(จำแนกตามลูกค้า)
                {
                    if (rdo_purchase.Checked == true)
                    {

                        if (Sort_Product == "ProductID ='RM-004'")
                        {
                            //string sql1 = "Select * From [V_CostSP_RM004] Where [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' Order by [TicketCodeIn]";
                            sql = "Select * From [V_CostSP_RM004] Where [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999'";

                        }

                        if (Sort_Product == "ProductID ='RM-001'") 
                        {
                            // string sql1 = "Select * From [V_CostSP_RM001] Where [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' Order by [TicketCodeIn]";

                            sql = "Select * From [V_CostSP_RM001] Where [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999'";
                        }

                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    sql = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE ([WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    //}


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    if (rdo_purchase.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                        }
                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    if (Vendor_Code != "")
                    //    {
                    //        sql += "AND ([HeaderBill_NameCodeCus] ='" + Vendor_Code + "')";
                    //    }
                    //    if (Customer_Code != "")
                    //    {
                    //        sql += " AND  [CustomerID]= '" + Customer_Code + "'";
                    //    }
                    //}

                    sql += " Order by [TicketCodeIn]";

                    if (Sort_Product == "ProductID ='RM-004'")
                    {
                        con.Open();
                        DataSet ds = new DataSet();
                        crp_recivedProRM004_byVendor crp_sp = new crp_recivedProRM004_byVendor();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                        adapter.Fill(ds, "crt_SPRM004");
                        crp_sp.SetDataSource(ds.Tables["crt_SPRM004"]);
                        crp_sp.SetParameterValue("st_date", ST_Date.ToString());
                        crp_sp.SetParameterValue("ed_date", ED_Date.ToString());
                        crystalReportViewer1.ReportSource = crp_sp;
                        crystalReportViewer1.Refresh();
                        con.Close();
                    }

                    else if (Sort_Product == "ProductID ='RM-001'")
                    {
                        con.Open();
                        DataSet ds = new DataSet();
                        crp_recivedProRM001_byVendor crp_sp = new crp_recivedProRM001_byVendor();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                        adapter.Fill(ds, "crt_SPRM001");
                        crp_sp.SetDataSource(ds.Tables["crt_SPRM001"]);
                        crp_sp.SetParameterValue("st_date", ST_Date.ToString());
                        crp_sp.SetParameterValue("ed_date", ED_Date.ToString());
                        crystalReportViewer1.ReportSource = crp_sp;
                        crystalReportViewer1.Refresh();
                        con.Close();
                    }

                    else
                    {
                        MessageBox.Show("ไม่มีรูปแบบรายงานในสินค้าตัวนี้", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    tabControl1.SelectedIndex = 1;
                }

                //Report OK Purchase
                if (id_print == 55) //รายงานต้นทุนสินค้า (จำแนกตามสินค้า) -[LO]         
                {
                    crp_costRM_byProduct_LO crt_payment = new crp_costRM_byProduct_LO();

                    // string sql1 = "SELECT  *  FROM  [dbo].[V_RpCostRM_byProduct-LO] WHERE [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "' ";

                    if (rdo_purchase.Checked == true)
                    {
                        if (Sort_Product == "ProductID ='RM-001'" || Sort_Product == "ProductID ='RM-004'")
                        {
                            sql = "SELECT *  FROM  [dbo].[V_RpCostRM_byProduct-LO] WHERE ([OutboundDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                        }
                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    sql = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE ([WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    //}


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    if (rdo_purchase.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                        }
                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    if (Vendor_Code != "")
                    //    {
                    //        sql += "AND ([HeaderBill_NameCodeCus] ='" + Vendor_Code + "')";
                    //    }
                    //    if (Customer_Code != "")
                    //    {
                    //        sql += " AND  [CustomerID]= '" + Customer_Code + "'";
                    //    }
                    //}


                    sql += " AND ([LabVselect] is not null) Order by [WeightDate]";


                    if (Sort_Product == "ProductID ='RM-001'" || Sort_Product == "ProductID ='RM-004'")
                    {
                        DataSet ds = new DataSet();
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                        adapter.Fill(ds, "cost_product");
                        crt_payment.SetDataSource(ds.Tables["cost_product"]);
                        crystalReportViewer1.ReportSource = crt_payment;
                        crystalReportViewer1.Refresh();
                        con.Close();
                    }

                    else
                    {
                        MessageBox.Show("ไม่มีรูปแบบรายงานในสินค้าตัวนี้", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtg_dataBFprint.DataSource = null;
                    }

                }

                //Report OK  All
                if (id_print == 56)      
                {

                    if (rdo_purchase.Checked == true)
                    {
                        //   //sql = "SELECT  *  FROM  [dbo].[V_Ticket_Register] WHERE [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "' ";

                        sql = "SELECT *  FROM  [dbo].[V_Ticket_Register] WHERE ([RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    }

                    if (rdo_sale.Checked == true)
                    {

                        //sql = "SELECT  *  FROM  [dbo].[V_Ticket_Register_Sale] WHERE [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "' ";

                        sql = "SELECT *  FROM  [dbo].[V_Ticket_Register_Sale] WHERE ([RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    }


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    if (rdo_purchase.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                        }
                    }

                    if (rdo_sale.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([CustomerID] ='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [HeaderBill_NameCodeCus]= '" + Customer_Code  + "'";
                        }
                    }

                    sql += " Order by [TicketCodeIn]";
                                       

                    if (rdo_purchase.Checked == true)
                    {
                        con.Open();
                        crp_register_SF crt_payment = new crp_register_SF();                     
                        DataSet ds = new DataSet();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                        adapter.Fill(ds, "regiter");
                        crt_payment.SetDataSource(ds.Tables["regiter"]);
                        crystalReportViewer1.ReportSource = crt_payment;
                        con.Close();
                    }

                    if (rdo_sale.Checked == true)
                    {
                        con.Open();
                        crp_register_SF_Sale crt_sale = new crp_register_SF_Sale();                    
                        DataSet ds = new DataSet();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                        adapter.Fill(ds, "regiter_sale");
                        crt_sale.SetDataSource(ds.Tables["regiter_sale"]);
                        crystalReportViewer1.ReportSource = crt_sale;
                        con.Close();
                    }


                    if (sql != "")
                    {
                        crystalReportViewer1.Refresh();
                    }

                }

                //รายงานภาพรับสินค้ามันสด[WH]                                                                         
                if (id_print == 57)
                {                
                    Load_DataPurchase();
                    btn_expExcel.Enabled = false;
                }
                
                //Report OK Sale
                if (id_print == 58)
                {
                    //if (rdo_purchase.Checked == true)
                    //{

                    //    if (Sort_Product == "ProductID = 'RM-004'")
                    //    {
                    //        //string sql1 = "Select * From [V_CostSP_RM004] Where [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' Order by [TicketCodeIn]";
                    //        sql = "Select * From [V_CostSP_RM004] Where [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999'";

                    //    }

                    //    if (Sort_Product == "ProductID = 'RM-001'")
                    //    {
                    //        // string sql1 = "Select * From [V_CostSP_RM001] Where [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' Order by [TicketCodeIn]";

                    //        sql = "Select * From [V_CostSP_RM001] Where [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999'";
                    //    }

                    //}

                    if (rdo_sale.Checked == true)
                    {
                        if (Sort_Product == "ProductID ='FG-001'")
                        {
                            // string sql1 = "Select * From [V_ReportEthanol_Audit] Where [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' Order by [TicketCodeIn]";
                            sql = "SELECT *  FROM  [dbo].[V_ReportEthanol_Audit] WHERE ([OutboundDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                        }
                    }


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    //if (rdo_purchase.Checked == true)
                    //{
                    //    if (Vendor_Code != "")
                    //    {
                    //        sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                    //    }
                    //    if (Customer_Code != "")
                    //    {
                    //        sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                    //    }
                    //}

                    if (rdo_sale.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([CustomerID] ='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [HeaderBill_NameCodeCus]= '" + Customer_Code + "'";
                        }
                    }

                    sql += " Order by [TicketCodeIn]";


                    if (Sort_Product == "ProductID ='FG-001'")
                    {
                        con.Open();
                        DataSet ds = new DataSet();
                        crp_ethanal_audit crp_eth = new crp_ethanal_audit();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                        adapter.Fill(ds, "crt_eth");
                        crp_eth.SetDataSource(ds.Tables["crt_eth"]);
                        crp_eth.SetParameterValue("st_date", ST_Date.ToString());
                        crp_eth.SetParameterValue("ed_date", ED_Date.ToString());
                        crystalReportViewer1.ReportSource = crp_eth;
                        crystalReportViewer1.Refresh();
                        con.Close();
                    }
                }

                //Report OK Purchase  filter product
                if (id_print == 59)
                {
                    if (rdo_purchase.Checked == true)
                    {

                        //string sql1 = "Select * From [V_WoodChip] Where [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' Order by [TicketCodeIn]";
                        if (Sort_Product == "ProductID ='ST0803-002'")
                        {
                            sql = "Select * From [V_WoodChip] Where [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999'";
                        }                      

                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    sql = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE ([WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    //}


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    if (rdo_purchase.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                        }
                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    if (Vendor_Code != "")
                    //    {
                    //        sql += "AND ([HeaderBill_NameCodeCus] ='" + Vendor_Code + "')";
                    //    }
                    //    if (Customer_Code != "")
                    //    {
                    //        sql += " AND  [CustomerID]= '" + Customer_Code + "'";
                    //    }
                    //}

                    sql += " Order by [TicketCodeIn]";

                    if (Sort_Product == "ProductID ='ST0803-002'")
                    {
                        con.Open();
                        DataSet ds = new DataSet();
                        crp_WoodChip_QA crp_eth = new crp_WoodChip_QA();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                        adapter.Fill(ds, "crp_woodchip");
                        crp_eth.SetDataSource(ds.Tables["crp_woodchip"]);
                        crp_eth.SetParameterValue("User_Crate", Program.user_name);
                        //crp_eth.SetParameterValue("ed_date", ED_Date.ToString());
                        crystalReportViewer1.ReportSource = crp_eth;
                        crystalReportViewer1.Refresh();
                        con.Close();
                    }
                }

                //OK  All
                if (id_print == 60) //summary weight report
                {
                    crp_Pur_weightsum_byUnitprice crt_weight = new crp_Pur_weightsum_byUnitprice();

                    //sql = "SELECT *  FROM  [dbo].[V_WeightData_UnitPrice] WHERE [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "' Order by [TicketCodeIn]";

                    if (rdo_purchase.Checked == true)
                    {
                        sql = "SELECT *  FROM  [dbo].[V_WeightData_UnitPrice] WHERE ([OutboundDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    }

                    if (rdo_sale.Checked == true)
                    {
                        sql = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE ([OutboundDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    }


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    if (rdo_purchase.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                        }
                    }

                    if (rdo_sale.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCodeCus] ='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [CustomerID]= '" + Customer_Code + "'";
                        }
                    }

                    sql += " Order by [TicketCodeIn]";

                    DataSet ds = new DataSet();
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(ds, "sum_weight");
                    crt_weight.SetDataSource(ds.Tables["sum_weight"]);
                    crystalReportViewer1.ReportSource = crt_weight;
                    crystalReportViewer1.Refresh();
                    con.Close();

                }


                //Report OK Purchase  filter product
                if (id_print == 61)
                {
                    if (rdo_purchase.Checked == true)
                    {

                        //string sql1 = "Select * From [V_WoodChip] Where [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' Order by [TicketCodeIn]";
                        if (Sort_Product == "ProductID ='RM-001_1'")
                        {
                            sql = "Select * From [V_FireWood] Where [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999'";
                        }

                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    sql = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE ([WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    //}


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    if (rdo_purchase.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                        }
                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    if (Vendor_Code != "")
                    //    {
                    //        sql += "AND ([HeaderBill_NameCodeCus] ='" + Vendor_Code + "')";
                    //    }
                    //    if (Customer_Code != "")
                    //    {
                    //        sql += " AND  [CustomerID]= '" + Customer_Code + "'";
                    //    }
                    //}

                    sql += " Order by [TicketCodeIn]";

                    if (Sort_Product == "ProductID ='RM-001_1'")
                    {
                        con.Open();
                        DataSet ds = new DataSet();
                        Crp_Firewood crp_eth = new Crp_Firewood();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                        adapter.Fill(ds, "crp_firewood");
                        crp_eth.SetDataSource(ds.Tables["crp_firewood"]);
                        crp_eth.SetParameterValue("User_Crate", Program.user_name);
                        //crp_eth.SetParameterValue("ed_date", ED_Date.ToString());
                        crystalReportViewer1.ReportSource = crp_eth;
                        crystalReportViewer1.Refresh();
                        con.Close();
                    }
                }


                //Report OK 
                if (id_print == 62) //Cost Summary Rawmat SP
                {
                    RP_SumPayment(con);
                }

                //Report OK 
                if (id_print == 63) //Store 
                {
                    Product_inStore();
                    tabControl1.SelectedIndex = 0;
                }

                //Report OK Purchase
                if (id_print == 64) //รายงานต้นทุนสินค้า (จำแนกตามสินค้า) -[LO]         
                {
                    crp_stock_movement crp_stock = new crp_stock_movement();

                    sql = "SELECT *  FROM  [dbo].[V_StockMovement] WHERE ([Stock_MoveDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }
                                        
                    sql += " Order by [Stock_MoveDate]";

                    DataSet ds = new DataSet();
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(ds, "st_movement");
                    crp_stock.SetDataSource(ds.Tables["st_movement"]);
                    crp_stock.SetParameterValue("st_date", ST_Date.ToString());
                    crp_stock.SetParameterValue("ed_date", ED_Date.ToString());
                    crystalReportViewer1.ReportSource = crp_stock;
                    crystalReportViewer1.Refresh();
                    con.Close();             
                    
                }

                //Report OK Purchase
                if (id_print == 65) //รายงานสินค้าคงคลัง        
                {
                    crp_store crp_stock = new crp_store();

                    sql = "SELECT *  FROM  [dbo].[V_StoreReport] Order by [NO_Zone] ";
                    DataSet ds = new DataSet();
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(ds, "store");
                    crp_stock.SetDataSource(ds.Tables["store"]);              
                    crystalReportViewer1.ReportSource = crp_stock;
                    crystalReportViewer1.Refresh();
                    con.Close();

                }

                //Report OK Purchase  filter product After Payemnt
                if (id_print == 67) //รายงานการรับสินค้า(จำแนกตามลูกค้า)   หลังจ่าย
                {
                    if (rdo_purchase.Checked == true)
                    {

                        if (Sort_Product == "ProductID ='RM-004'")
                        {
                            //string sql1 = "Select * From [V_CostSP_RM004] Where [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' Order by [TicketCodeIn]";
                            sql = "Select * From [V_CostSP_RM004_AfPayment] Where [WeightDate] Between '" + ST_Date + "'  AND  '" + ED_Date + "'";

                        }

                        if (Sort_Product == "ProductID ='RM-001'")
                        {
                            // string sql1 = "Select * From [V_CostSP_RM001] Where [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' Order by [TicketCodeIn]";

                            sql = "Select * From [V_CostSP_RM001_AfPayment] Where [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999'";
                        }

                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    sql = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE ([WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    //}


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    if (rdo_purchase.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                        }
                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    if (Vendor_Code != "")
                    //    {
                    //        sql += "AND ([HeaderBill_NameCodeCus] ='" + Vendor_Code + "')";
                    //    }
                    //    if (Customer_Code != "")
                    //    {
                    //        sql += " AND  [CustomerID]= '" + Customer_Code + "'";
                    //    }
                    //}

                    sql += " Order by [TicketCodeIn]";

                    if (Sort_Product == "ProductID ='RM-004'")
                    {
                        con.Open();
                        DataSet ds = new DataSet();
                        crp_recivedProRM004_byVendorAF crp_sp = new crp_recivedProRM004_byVendorAF();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                        adapter.Fill(ds, "crt_SPRM004");
                        crp_sp.SetDataSource(ds.Tables["crt_SPRM004"]);
                        crp_sp.SetParameterValue("st_date", ST_Date.ToString());
                        crp_sp.SetParameterValue("ed_date", ED_Date.ToString());
                        crystalReportViewer1.ReportSource = crp_sp;
                        crystalReportViewer1.Refresh();
                        con.Close();
                    }

                    else if (Sort_Product == "ProductID ='RM-001'")
                    {
                        con.Open();
                        DataSet ds = new DataSet();
                        crp_recivedProRM001_byVendorAF crp_sp = new crp_recivedProRM001_byVendorAF();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                        adapter.Fill(ds, "crt_SPRM001");
                        crp_sp.SetDataSource(ds.Tables["crt_SPRM001"]);
                        crp_sp.SetParameterValue("st_date", ST_Date.ToString());
                        crp_sp.SetParameterValue("ed_date", ED_Date.ToString());
                        crystalReportViewer1.ReportSource = crp_sp;
                        crystalReportViewer1.Refresh();
                        con.Close();
                    }

                    else
                    {
                        MessageBox.Show("ไม่มีรูปแบบรายงานในสินค้าตัวนี้", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    tabControl1.SelectedIndex = 1;
                }

                //Report OK Purchase LO show Lite 
                if (id_print == 70) //summary weight report
                {
                    crp_Pur_weightsummary_Liq crt_weight = new crp_Pur_weightsummary_Liq();

                    if (rdo_purchase.Checked == true)
                    {                   
                            sql = "SELECT *  FROM  [dbo].[V_WeightData_Liq] WHERE ([OutboundDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    sql = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE ([WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    //}


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                    if (rdo_purchase.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([HeaderBill_NameCode]='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [Vendor_No]= '" + Customer_Code + "'";
                        }
                    }

                    //if (rdo_sale.Checked == true)
                    //{
                    //    if (Vendor_Code != "")
                    //    {
                    //        sql += "AND ([HeaderBill_NameCodeCus] ='" + Vendor_Code + "')";
                    //    }
                    //    if (Customer_Code != "")
                    //    {
                    //        sql += " AND  [CustomerID]= '" + Customer_Code + "'";
                    //    }
                    //}


                    sql += " Order by [TicketCodeIn]";

                    DataSet ds = new DataSet();
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(ds, "sum_weight");
                    crt_weight.SetDataSource(ds.Tables["sum_weight"]);
                    crystalReportViewer1.ReportSource = crt_weight;
                    crystalReportViewer1.Refresh();
                    con.Close();

                }

                //Report OK 
                if (id_print == 90) //summary weight report
                {
                    crp_Sale_weightsummary_byCus crt_weight = new crp_Sale_weightsummary_byCus();

                    //string sql1 = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "'";

                    //if (rdo_purchase.Checked == true)
                    //{
                    //    sql = "SELECT *  FROM  [dbo].[V_RpSP] WHERE ([PayDate] Between '" + ST_Date + "'  AND  '" + ED_Date + "')";
                    //}

                    if (rdo_sale.Checked == true)
                    {
                        sql = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE ([OutboundDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999')";
                    }


                    if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
                    {
                        sql += "AND (" + Sort_Product + ")";
                    }

                  

                    if (rdo_sale.Checked == true)
                    {
                        if (Vendor_Code != "")
                        {
                            sql += "AND ([CustomerID] ='" + Vendor_Code + "')";
                        }
                        if (Customer_Code != "")
                        {
                            sql += " AND  [HeaderBill_NameCodeCus]= '" + Customer_Code + "'";
                        }
                    }



                    DataSet ds = new DataSet();
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(ds, "sum_weight");
                    crt_weight.SetDataSource(ds.Tables["sum_weight"]);
                    crystalReportViewer1.ReportSource = crt_weight;
                    crystalReportViewer1.Refresh();
                    con.Close();
                }


                try
                {
                    if (sql != "")
                    {
                        con.Open();
                        SqlDataAdapter da100 = new SqlDataAdapter(sql, con);
                        da100.SelectCommand.CommandTimeout = 0;
                        DataSet ds100 = new DataSet();
                        da100.Fill(ds100, "g_dataTemp");
                        dtg_dataBFprint.DataSource = ds100.Tables["g_dataTemp"];
                        con.Close();
                        dtg_dataBFprint.ClearSelection();
                    }
                }
             
                catch { }

                finally
                {
                    tool_countItems.Text = "จำนวน: " + dtg_dataBFprint.RowCount + " รายการ";
                }

            }

            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {

                if (id_print == 36)
                {
                    for (int i = 0; i < dtg_dataBFprint.RowCount; i++)
                    {
                        if (dtg_dataBFprint.Rows[i].Cells[15].Value.ToString() != "")
                        {
                            dtg_dataBFprint.Rows[i].Cells[0].Style.BackColor = Color.Green;                          
                        }

                        else { dtg_dataBFprint.Rows[i].Cells[0].Style.BackColor = Color.Red; }
                    }

                }
                                                                                                                                     
                //con.Open();
                //SqlDataAdapter da100 = new SqlDataAdapter(sql, con);
                //da100.SelectCommand.CommandTimeout = 0;
                //DataSet ds100 = new DataSet();
                //da100.Fill(ds100, "g_dataTemp");
                //dtg_dataBFprint.DataSource = ds100.Tables["g_dataTemp"];
                //con.Close();
                //dtg_dataBFprint.DataSource = ds1.Tables[0];
                //dtg_dataBFprint.ClearSelection();    
                //tool_countItems.Text = "จำนวน: " + dtg_dataBFprint.RowCount + " รายการ";

            }     
        }

        private void Product_inStore()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            dtg_dataBFprint.DataSource = null;
            dtg_dataBFprint.Rows.Clear();
            dtg_dataBFprint.Columns.Clear();
            int Count_row = 0;

            DataGridViewColumn colHold = new DataGridViewTextBoxColumn();

            dtg_dataBFprint.Name = "Product_ID";
            dtg_dataBFprint.Name = "Product_Name";
            dtg_dataBFprint.Name = "Type";
            dtg_dataBFprint.Name = "JAN";
            dtg_dataBFprint.Name = "FEB";
            dtg_dataBFprint.Name = "MAR";
            dtg_dataBFprint.Name = "APR";
            dtg_dataBFprint.Name = "MAY";
            dtg_dataBFprint.Name = " JUN";
            dtg_dataBFprint.Name = " JUL";
            dtg_dataBFprint.Name = " AUG";
            dtg_dataBFprint.Name = " SEP";
            dtg_dataBFprint.Name = " OCT";
            dtg_dataBFprint.Name = " NOV";
            dtg_dataBFprint.Name = " DEC";
            dtg_dataBFprint.Name = "TOTAL";

            dtg_dataBFprint.Columns.Add(colHold);
            dtg_dataBFprint.ColumnCount = 16;

            dtg_dataBFprint.Columns[0].Name = "รหัสสินค้า";
            dtg_dataBFprint.Columns[1].Name = "ชื่อสินค้า";
            dtg_dataBFprint.Columns[2].Name = "ประเภท";
            dtg_dataBFprint.Columns[3].Name = "ม.ค.";
            dtg_dataBFprint.Columns[4].Name = "ก.พ.";
            dtg_dataBFprint.Columns[5].Name = "มี.ค.";
            dtg_dataBFprint.Columns[6].Name = "เม.ย.";
            dtg_dataBFprint.Columns[7].Name = "พ.ค.";
            dtg_dataBFprint.Columns[8].Name = "มิ.ย.";
            dtg_dataBFprint.Columns[9].Name = "ก.ค.";
            dtg_dataBFprint.Columns[10].Name = "ส.ค.";
            dtg_dataBFprint.Columns[11].Name = "ก.ย.";
            dtg_dataBFprint.Columns[12].Name = "ต.ค.";
            dtg_dataBFprint.Columns[13].Name = "พ.ย.";
            dtg_dataBFprint.Columns[14].Name = "ธ.ค.";
            dtg_dataBFprint.Columns[15].Name = "รวม";

            
            this.dtg_dataBFprint.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            this.dtg_dataBFprint.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtg_dataBFprint.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtg_dataBFprint.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtg_dataBFprint.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtg_dataBFprint.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtg_dataBFprint.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtg_dataBFprint.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtg_dataBFprint.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtg_dataBFprint.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtg_dataBFprint.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtg_dataBFprint.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtg_dataBFprint.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dtg_dataBFprint.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtg_dataBFprint.Columns[15].DefaultCellStyle.Font = new Font(DataGrid.DefaultFont, FontStyle.Bold);
            this.dtg_dataBFprint.Columns[15].DefaultCellStyle.ForeColor = Color.Blue;


            con.Open();
            string sql = "SELECT [ProductID],[ProductName] FROM [dbo].[TB_Products]  WHERE [StatusActive]=1";
            SqlCommand CM10 = new SqlCommand(sql, con);
            SqlDataReader DR10 = CM10.ExecuteReader();
            while (DR10.Read())
            {

                if (DR10["ProductID"].ToString() == "FG-001")
                {
                    string[] row1 = new string[] { DR10["ProductID"].ToString() , DR10["ProductName"].ToString().Trim() , "รถ(คัน)", "", "","", "", "","","","","","","","",""};
                    dtg_dataBFprint.Rows.Add(row1);                                     

                    string[] row2 = new string[] {"", "", "PO(L)", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                    dtg_dataBFprint.Rows.Add(row2);

                    string[] row3 = new string[] {"", "", "นน.(กก.)", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                    dtg_dataBFprint.Rows.Add(row3);                 

                    string[] row4 = new string[] { "","", "จำนวน(ลิตร)", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                    dtg_dataBFprint.Rows.Add(row4);                
                }

                else

                {
                   
                    string[] row1 = new string[] { DR10["ProductID"].ToString(), DR10["ProductName"].ToString().Trim() , "รถ(คัน)", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                    dtg_dataBFprint.Rows.Add(row1);

                    string[] row2 = new string[] { "","", "นน.(กก.)", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                    dtg_dataBFprint.Rows.Add(row2);

                  
                }
            }
            DR10.Close();
            con.Close();


            string[] row5 = new string[] {"", "รวมรับ", "รถ(คัน)", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            dtg_dataBFprint.Rows.Add(row5);

            string[] row6 = new string[] {"", "", "นน.(กก.)", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            dtg_dataBFprint.Rows.Add(row6);
                    
            dtg_dataBFprint.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Load_SumData();

            dtg_dataBFprint.ClearSelection();
        }
               
        
        private void RP_SumPayment(SqlConnection con)
        {           
            string Vendor_No = "";
            string Customer_No = "";
            int Filter_type = 1;  // all

            if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --" && cb_vendor.Text == "-- เลือกทั้งหมด --" && cb_customer.Text == "-- เลือกทั้งหมด --")  
            {               
                Filter_type = 2;
            }

            if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --" && cb_vendor.Text != "-- เลือกทั้งหมด --" && cb_customer.Text == "-- เลือกทั้งหมด --")
            {
                Customer_No = cb_vendor.SelectedValue.ToString();
                Filter_type = 3;
            }
            
            if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --" && cb_vendor.Text == "-- เลือกทั้งหมด --" && cb_customer.Text != "-- เลือกทั้งหมด --")
            {
                Vendor_No = cb_customer.SelectedValue.ToString();
                Filter_type = 4;
            }

            if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --" && cb_vendor.Text != "-- เลือกทั้งหมด --" && cb_customer.Text != "-- เลือกทั้งหมด --")
            {
                Vendor_No = cb_customer.SelectedValue.ToString();
                Customer_No = cb_vendor.SelectedValue.ToString();
                Filter_type = 5;
            }


            con.Open();

          
            string ST_Date = dtp_stReport.Value.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
            string ED_Date = dtp_edReport.Value.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));

            crp_paySumSP crp_SP = new crp_paySumSP();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ST_SumPayment";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Filter_type", Filter_type));
            cmd.Parameters.Add(new SqlParameter("@ST_Date", ST_Date + " 00:00:00.0"));
            cmd.Parameters.Add(new SqlParameter("@ED_Date", ED_Date + " 23:59:00.0"));
            cmd.Parameters.Add(new SqlParameter("@ProducID", ProductID));
            cmd.Parameters.Add(new SqlParameter("@Vendor_NO", Vendor_No));
            cmd.Parameters.Add(new SqlParameter("@Customer_NO", Customer_No));
            cmd.Connection = con;

  

            SqlDataAdapter da = new SqlDataAdapter(cmd);

           
            DataSet ds = new DataSet();
            da.Fill(ds, "sumpay");
            crp_SP.Database.Tables[0].SetDataSource(ds.Tables["sumpay"]);
            crp_SP.SetParameterValue("st_date", dtp_stReport.Value.ToShortDateString());
            crp_SP.SetParameterValue("ed_date", dtp_edReport.Value.ToShortDateString());
            crystalReportViewer1.ReportSource = crp_SP;
            crystalReportViewer1.Refresh();
            con.Close();

            dtg_dataBFprint.DataSource = ds.Tables["sumpay"];
            dtg_dataBFprint.ClearSelection();
        }


        private void Load_DataPurchase()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            dtg_histruck.DataSource = null;
            //prot_form
            string Date_St = dtp_stReport.Value.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
            string Date_Ed = dtp_edReport.Value.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));

            //   string sql1 = "SELECT [TicketCodeIn] AS 'เลขที่ตั๋ว',[QueueNo] AS 'คิว',[ProductName] AS 'สินค้า',[Plate1] AS 'ทะเบียน',[NameVen] AS 'ผู้ขาย' FROM [dbo].[V_WeightData]  Where [ProductID]='"+cb_productReport.SelectedValue.ToString().Trim() +"' AND [RegisterInDate] Between '" + Date_St + " 00:00.00'  AND  '" + Date_Ed + " 23:59:59.999' ";
            
            string sql1 = "";
            sql1 = "SELECT[TicketCodeIn] AS 'เลขที่ตั๋ว',[QueueNo] AS 'คิว',[ProductName] AS 'สินค้า',[Plate1] AS 'ทะเบียน',[NameVen] AS 'ผู้ขาย' FROM[dbo].[V_WeightData] WHERE [RegisterInDate] Between '" + Date_St + " 00:00.00'  AND  '" + Date_Ed + " 23:59:59.999'";

            if (lbl_selectProduct.Text != "-- เลือกทั้งหมด --")
            {
                sql1 += "AND (" + Sort_Product + ")";
            }

            sql1 += " Order by [TicketCodeIn]";
         
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "g_vt");
            dtg_histruck.DataSource = ds1.Tables["g_vt"];
            con.Close();

            //dtg_histruck.Visible = true;
            dtg_histruck.Columns[1].Width = 50;
            dtg_histruck.Columns[2].Width = 80;
            dtg_histruck.Columns[3].Width = 80;
            tabControl1.SelectedIndex = 3;
        }

        private void Load_SumData()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            string ProductID = "";
            //double Total_X = 0;  //รวมข้อมูลแนวตั้ง
            //double Total_Y = 0;  //รวมข้อมูลนนอน
            //double Total_C = 0;
            //double Total_W = 0;

            double Total_C01 = 0;
            double Total_C02 = 0;
            double Total_C03 = 0;
            double Total_C04 = 0;
            double Total_C05 = 0;
            double Total_C06 = 0;
            double Total_C07 = 0;
            double Total_C08 = 0;
            double Total_C09 = 0;
            double Total_C10 = 0;
            double Total_C11 = 0;
            double Total_C12 = 0;
            double Total_CTT = 0;

            double Total_S01 = 0;
            double Total_S02 = 0;
            double Total_S03 = 0;
            double Total_S04 = 0;
            double Total_S05 = 0;
            double Total_S06 = 0;
            double Total_S07 = 0;
            double Total_S08 = 0;
            double Total_S09 = 0;
            double Total_S10 = 0;
            double Total_S11 = 0;
            double Total_S12 = 0;
            double Total_STT = 0;

            double value = 0;

            //DR7.Close();
            for (int i = 0; i < dtg_dataBFprint.RowCount; i++)
            {

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }            

                con.Open();

                SqlCommand Cmd = new SqlCommand();

                if (dtg_dataBFprint.Rows[i].Cells[0].Value.ToString().Trim() != "")
                {
                    ProductID = dtg_dataBFprint.Rows[i].Cells[0].Value.ToString().Trim();
                }


                if (ProductID == "FG-001")
                {
                    Cmd = new SqlCommand("ST_SumLO_Sale", con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@ProductID", ProductID);
                    Cmd.Parameters.AddWithValue("@YEAR", dtp_edReport.Value.Year);

                    //Define one SqlDataReader 
                    SqlDataReader objDR;
                    objDR = Cmd.ExecuteReader(); // here procedure gets execute
                    if (objDR.Read())
                    {
                        if (dtg_dataBFprint.Rows[i].Cells[2].Value.ToString() == "รถ(คัน)")
                        {
                            dtg_dataBFprint.Rows[i].Cells[3].Value = objDR["C_01"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[4].Value = objDR["C_02"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[5].Value = objDR["C_03"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[6].Value = objDR["C_04"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[7].Value = objDR["C_05"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[8].Value = objDR["C_06"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[9].Value = objDR["C_07"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[10].Value = objDR["C_08"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[11].Value = objDR["C_09"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[12].Value = objDR["C_10"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[13].Value = objDR["C_11"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[14].Value = objDR["C_12"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[15].Value = objDR["C_Total"].ToString();

                            dtg_dataBFprint.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                            //this.dtg_dataBFprint.Rows[i].Cells[2].Style.ForeColor = Color.Lime;

                            if (dtg_dataBFprint.Rows[i].Cells[3].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[3].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[3].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[3].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[3].Value = value.ToString("##,###");
                                Total_C01 += value;
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[4].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[4].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[4].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[4].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[4].Value = value.ToString("##,###");
                                Total_C02 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[5].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[5].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[5].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[5].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[5].Value = value.ToString("##,###");
                                Total_C03 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[6].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[6].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[6].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[6].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[6].Value = value.ToString("##,###");
                                Total_C04 += value;
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[7].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[7].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[7].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[7].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[7].Value = value.ToString("##,###");
                                Total_C05 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[8].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[8].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[8].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[8].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[8].Value = value.ToString("##,###");
                                Total_C06 += value;
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[9].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[9].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[9].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[9].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[9].Value = value.ToString("##,###");
                                Total_C07 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[10].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[10].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[10].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[10].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[10].Value = value.ToString("##,###");
                                Total_C08 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[11].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[11].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[11].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[11].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[11].Value = value.ToString("##,###");
                                Total_C09 += value;
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[12].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[12].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[12].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[12].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[12].Value = value.ToString("##,###");
                                Total_C10 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[13].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[13].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[13].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[13].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[13].Value = value.ToString("##,###");
                                Total_C11 += value;
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[14].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[14].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[14].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[14].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[14].Value = value.ToString("##,###");
                                Total_C12 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[15].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[15].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[15].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[15].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[15].Value = value.ToString("##,###");
                                Total_CTT += value;
                            }                                                                                                                                                                                                                                                                                                                           
                        }
                        
                        if (dtg_dataBFprint.Rows[i].Cells[2].Value.ToString() == "นน.(กก.)")
                        {
                            dtg_dataBFprint.Rows[i].Cells[3].Value = objDR["S_01"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[4].Value = objDR["S_02"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[5].Value = objDR["S_03"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[6].Value = objDR["S_04"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[7].Value = objDR["S_05"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[8].Value = objDR["S_06"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[9].Value = objDR["S_07"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[10].Value = objDR["S_08"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[11].Value = objDR["S_09"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[12].Value = objDR["S_10"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[13].Value = objDR["S_11"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[14].Value = objDR["S_12"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[15].Value = objDR["S_Total"].ToString();

                            dtg_dataBFprint.Rows[i].DefaultCellStyle.BackColor = Color.Ivory;
                            //this.dtg_dataBFprint.Rows[i].Cells[2].Style.ForeColor = Color.Fuchsia;

                            if (dtg_dataBFprint.Rows[i].Cells[3].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[3].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[3].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[3].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[3].Value = value.ToString("##,###");
                                Total_S01 += value;
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[4].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[4].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[4].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[4].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[4].Value = value.ToString("##,###");
                                Total_S02 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[5].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[5].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[5].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[5].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[5].Value = value.ToString("##,###");
                                Total_S03 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[6].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[6].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[6].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[6].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[6].Value = value.ToString("##,###");
                                Total_S04 += value;
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[7].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[7].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[7].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[7].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[7].Value = value.ToString("##,###");
                                Total_S05 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[8].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[8].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[8].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[8].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[8].Value = value.ToString("##,###");
                                Total_S06 += value;
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[9].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[9].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[9].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[9].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[9].Value = value.ToString("##,###");
                                Total_S07 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[10].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[10].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[10].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[10].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[10].Value = value.ToString("##,###");
                                Total_S08 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[11].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[11].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[11].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[11].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[11].Value = value.ToString("##,###");
                                Total_S09 += value;
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[12].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[12].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[12].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[12].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[12].Value = value.ToString("##,###");
                                Total_S10 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[13].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[13].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[13].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[13].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[13].Value = value.ToString("##,###");
                                Total_S11 += value;
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[14].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[14].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[14].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[14].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[14].Value = value.ToString("##,###");
                                Total_S12 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[15].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[15].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[15].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[15].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[15].Value = value.ToString("##,###");
                                Total_STT += value;
                            }

                        }
                        
                        if (dtg_dataBFprint.Rows[i].Cells[2].Value.ToString() == "PO(L)")
                        {
                            dtg_dataBFprint.Rows[i].Cells[3].Value = objDR["P_01"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[4].Value = objDR["P_02"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[5].Value = objDR["P_03"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[6].Value = objDR["P_04"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[7].Value = objDR["P_05"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[8].Value = objDR["P_06"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[9].Value = objDR["P_07"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[10].Value = objDR["P_08"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[11].Value = objDR["P_09"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[12].Value = objDR["P_10"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[13].Value = objDR["P_11"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[14].Value = objDR["P_12"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[15].Value = objDR["P_Total"].ToString();

                            dtg_dataBFprint.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;

                            if (dtg_dataBFprint.Rows[i].Cells[3].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[3].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[3].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[3].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[3].Value = value.ToString("##,###");                                
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[4].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[4].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[4].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[4].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[4].Value = value.ToString("##,###");                            
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[5].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[5].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[5].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[5].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[5].Value = value.ToString("##,###");                              
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[6].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[6].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[6].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[6].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[6].Value = value.ToString("##,###");                       
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[7].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[7].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[7].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[7].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[7].Value = value.ToString("##,###");                               
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[8].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[8].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[8].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[8].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[8].Value = value.ToString("##,###");                               
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[9].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[9].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[9].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[9].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[9].Value = value.ToString("##,###");                          
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[10].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[10].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[10].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[10].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[10].Value = value.ToString("##,###");                                
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[11].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[11].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[11].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[11].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[11].Value = value.ToString("##,###");                          
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[12].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[12].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[12].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[12].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[12].Value = value.ToString("##,###");                               
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[13].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[13].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[13].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[13].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[13].Value = value.ToString("##,###");                               
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[14].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[14].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[14].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[14].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[14].Value = value.ToString("##,###");                               
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[15].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[15].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[15].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[15].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[15].Value = value.ToString("##,###");                             
                            }

                        }

                        if (dtg_dataBFprint.Rows[i].Cells[2].Value.ToString() == "จำนวน(ลิตร)")
                        {
                            dtg_dataBFprint.Rows[i].Cells[3].Value = objDR["Q_01"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[4].Value = objDR["Q_02"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[5].Value = objDR["Q_03"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[6].Value = objDR["Q_04"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[7].Value = objDR["Q_05"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[8].Value = objDR["Q_06"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[9].Value = objDR["Q_07"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[10].Value = objDR["Q_08"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[11].Value = objDR["Q_09"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[12].Value = objDR["Q_10"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[13].Value = objDR["Q_11"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[14].Value = objDR["Q_12"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[15].Value = objDR["Q_Total"].ToString();

                            dtg_dataBFprint.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;

                            if (dtg_dataBFprint.Rows[i].Cells[3].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[3].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[3].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[3].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[3].Value = value.ToString("##,###");
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[4].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[4].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[4].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[4].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[4].Value = value.ToString("##,###");
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[5].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[5].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[5].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[5].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[5].Value = value.ToString("##,###");
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[6].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[6].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[6].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[6].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[6].Value = value.ToString("##,###");
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[7].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[7].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[7].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[7].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[7].Value = value.ToString("##,###");
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[8].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[8].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[8].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[8].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[8].Value = value.ToString("##,###");
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[9].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[9].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[9].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[9].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[9].Value = value.ToString("##,###");
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[10].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[10].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[10].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[10].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[10].Value = value.ToString("##,###");
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[11].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[11].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[11].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[11].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[11].Value = value.ToString("##,###");
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[12].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[12].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[12].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[12].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[12].Value = value.ToString("##,###");
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[13].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[13].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[13].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[13].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[13].Value = value.ToString("##,###");
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[14].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[14].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[14].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[14].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[14].Value = value.ToString("##,###");
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[15].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[15].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[15].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[15].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[15].Value = value.ToString("##,###");
                            }
                        }
                    }
                    // complete close datareader.
                    objDR.Close();
                }

                else
                {
                    Cmd = new SqlCommand("ST_SumLO_Pur", con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@ProductID", ProductID);
                    Cmd.Parameters.AddWithValue("@YEAR", dtp_edReport.Value.Year);

                    //Define one SqlDataReader 
                    SqlDataReader objDR;
                    objDR = Cmd.ExecuteReader(); // here procedure gets execute
                    if (objDR.Read())
                    {
                        if (dtg_dataBFprint.Rows[i].Cells[2].Value.ToString() == "รถ(คัน)")
                        {
                            dtg_dataBFprint.Rows[i].Cells[3].Value = objDR["C_01"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[4].Value = objDR["C_02"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[5].Value = objDR["C_03"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[6].Value = objDR["C_04"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[7].Value = objDR["C_05"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[8].Value = objDR["C_06"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[9].Value = objDR["C_07"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[10].Value = objDR["C_08"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[11].Value = objDR["C_09"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[12].Value = objDR["C_10"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[13].Value = objDR["C_11"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[14].Value = objDR["C_12"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[15].Value = objDR["C_Total"].ToString();

                            dtg_dataBFprint.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                            //this.dtg_dataBFprint.Rows[i].Cells[2].Style.ForeColor = Color.Lime;


                            if (dtg_dataBFprint.Rows[i].Cells[3].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[3].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[3].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[3].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[3].Value = value.ToString("##,###");
                                Total_C01 += value;
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[4].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[4].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[4].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[4].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[4].Value = value.ToString("##,###");
                                Total_C02 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[5].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[5].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[5].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[5].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[5].Value = value.ToString("##,###");
                                Total_C03 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[6].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[6].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[6].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[6].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[6].Value = value.ToString("##,###");
                                Total_C04 += value;
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[7].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[7].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[7].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[7].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[7].Value = value.ToString("##,###");
                                Total_C05 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[8].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[8].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[8].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[8].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[8].Value = value.ToString("##,###");
                                Total_C06 += value;
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[9].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[9].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[9].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[9].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[9].Value = value.ToString("##,###");
                                Total_C07 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[10].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[10].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[10].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[10].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[10].Value = value.ToString("##,###");
                                Total_C08 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[11].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[11].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[11].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[11].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[11].Value = value.ToString("##,###");
                                Total_C09 += value;
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[12].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[12].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[12].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[12].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[12].Value = value.ToString("##,###");
                                Total_C10 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[13].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[13].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[13].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[13].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[13].Value = value.ToString("##,###");
                                Total_C11 += value;
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[14].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[14].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[14].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[14].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[14].Value = value.ToString("##,###");
                                Total_C12 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[15].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[15].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[15].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[15].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[15].Value = value.ToString("##,###");
                                Total_CTT += value;
                            }
                        }


                        if (dtg_dataBFprint.Rows[i].Cells[2].Value.ToString() == "นน.(T)")
                        {
                            dtg_dataBFprint.Rows[i].Cells[3].Value = objDR["S_01"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[4].Value = objDR["S_02"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[5].Value = objDR["S_03"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[6].Value = objDR["S_04"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[7].Value = objDR["S_05"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[8].Value = objDR["S_06"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[9].Value = objDR["S_07"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[10].Value = objDR["S_08"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[11].Value = objDR["S_09"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[12].Value = objDR["S_10"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[13].Value = objDR["S_11"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[14].Value = objDR["S_12"].ToString();
                            dtg_dataBFprint.Rows[i].Cells[15].Value = objDR["S_Total"].ToString();

                            dtg_dataBFprint.Rows[i].DefaultCellStyle.BackColor = Color.Ivory;
                            //this.dtg_dataBFprint.Rows[i].Cells[2].Style.ForeColor = Color.Fuchsia;

                            if (dtg_dataBFprint.Rows[i].Cells[3].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[3].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[3].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[3].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[3].Value = value.ToString("##,###");
                                Total_S01 += value;
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[4].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[4].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[4].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[4].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[4].Value = value.ToString("##,###");
                                Total_S02 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[5].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[5].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[5].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[5].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[5].Value = value.ToString("##,###");
                                Total_S03 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[6].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[6].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[6].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[6].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[6].Value = value.ToString("##,###");
                                Total_S04 += value;
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[7].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[7].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[7].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[7].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[7].Value = value.ToString("##,###");
                                Total_S05 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[8].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[8].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[8].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[8].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[8].Value = value.ToString("##,###");
                                Total_S06 += value;
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[9].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[9].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[9].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[9].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[9].Value = value.ToString("##,###");
                                Total_S07 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[10].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[10].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[10].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[10].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[10].Value = value.ToString("##,###");
                                Total_S08 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[11].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[11].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[11].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[11].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[11].Value = value.ToString("##,###");
                                Total_S09 += value;
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[12].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[12].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[12].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[12].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[12].Value = value.ToString("##,###");
                                Total_S10 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[13].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[13].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[13].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[13].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[13].Value = value.ToString("##,###");
                                Total_S11 += value;
                            }

                            if (dtg_dataBFprint.Rows[i].Cells[14].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[14].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[14].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[14].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[14].Value = value.ToString("##,###");
                                Total_S12 += value;
                            }


                            if (dtg_dataBFprint.Rows[i].Cells[15].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[15].Value.ToString() == "0")
                            {
                                dtg_dataBFprint.Rows[i].Cells[15].Value = "-";
                            }
                            else
                            {
                                value = Convert.ToDouble(dtg_dataBFprint.Rows[i].Cells[15].Value.ToString());
                                dtg_dataBFprint.Rows[i].Cells[15].Value = value.ToString("##,###");
                                Total_STT += value;
                            }
                        }                       
                    }
                    // complete close datareader.
                    objDR.Close();
                }


               
                //Summary Rows
                if (dtg_dataBFprint.RowCount - i == 2)
                {
                    dtg_dataBFprint.Rows[i].Cells[3].Value = Total_C01.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[4].Value = Total_C02.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[5].Value = Total_C03.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[6].Value = Total_C04.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[7].Value = Total_C05.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[8].Value = Total_C06.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[9].Value = Total_C07.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[10].Value = Total_C08.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[11].Value = Total_C09.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[12].Value = Total_C10.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[13].Value = Total_C11.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[14].Value = Total_C12.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[15].Value = Total_CTT.ToString("##,###");
                    dtg_dataBFprint.Rows[i].DefaultCellStyle.Font = new Font(DataGrid.DefaultFont, FontStyle.Bold);
                    this.dtg_dataBFprint.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                    //this.dtg_dataBFprint.Rows[i].Cells[2].Style.ForeColor = Color.Lime;

                    dtg_dataBFprint.Rows[i].DefaultCellStyle.BackColor = Color.PaleTurquoise;
                }

                if (dtg_dataBFprint.RowCount - i == 1)
                {
                    dtg_dataBFprint.Rows[i].Cells[3].Value = Total_S01.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[4].Value = Total_S02.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[5].Value = Total_S03.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[6].Value = Total_S04.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[7].Value = Total_S05.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[8].Value = Total_S06.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[9].Value = Total_S07.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[10].Value = Total_S08.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[11].Value = Total_S09.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[12].Value = Total_S10.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[13].Value = Total_S11.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[14].Value = Total_S12.ToString("##,###");
                    dtg_dataBFprint.Rows[i].Cells[15].Value = Total_STT.ToString("##,###");
                    dtg_dataBFprint.Rows[i].DefaultCellStyle.Font = new Font(DataGrid.DefaultFont, FontStyle.Bold);
                    this.dtg_dataBFprint.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                    dtg_dataBFprint.Rows[i].DefaultCellStyle.BackColor = Color.PaleTurquoise;
                    //this.dtg_dataBFprint.Rows[i].Cells[2].Style.ForeColor = Color.Fuchsia;
                }
                

                if (dtg_dataBFprint.Rows[i].Cells[3].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[3].Value.ToString() == "0")
                {
                    dtg_dataBFprint.Rows[i].Cells[3].Value = "-";
                }

                if (dtg_dataBFprint.Rows[i].Cells[4].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[4].Value.ToString() == "0")
                {
                    dtg_dataBFprint.Rows[i].Cells[4].Value = "-";
                }

                if (dtg_dataBFprint.Rows[i].Cells[5].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[5].Value.ToString() == "0")
                {
                    dtg_dataBFprint.Rows[i].Cells[5].Value = "-";
                }

                if (dtg_dataBFprint.Rows[i].Cells[6].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[6].Value.ToString() == "0")
                {
                    dtg_dataBFprint.Rows[i].Cells[6].Value = "-";
                }

                if (dtg_dataBFprint.Rows[i].Cells[7].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[7].Value.ToString() == "0")
                {
                    dtg_dataBFprint.Rows[i].Cells[7].Value = "-";
                }

                if (dtg_dataBFprint.Rows[i].Cells[8].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[8].Value.ToString() == "0")
                {
                    dtg_dataBFprint.Rows[i].Cells[8].Value = "-";
                }

                if (dtg_dataBFprint.Rows[i].Cells[9].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[9].Value.ToString() == "0")
                {
                    dtg_dataBFprint.Rows[i].Cells[9].Value = "-";
                }

                if (dtg_dataBFprint.Rows[i].Cells[10].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[10].Value.ToString() == "0")
                {
                    dtg_dataBFprint.Rows[i].Cells[10].Value = "-";
                }

                if (dtg_dataBFprint.Rows[i].Cells[11].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[11].Value.ToString() == "0")
                {
                    dtg_dataBFprint.Rows[i].Cells[11].Value = "-";
                }

                if (dtg_dataBFprint.Rows[i].Cells[12].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[12].Value.ToString() == "0")
                {
                    dtg_dataBFprint.Rows[i].Cells[12].Value = "-";
                }

                if (dtg_dataBFprint.Rows[i].Cells[13].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[13].Value.ToString() == "0")
                {
                    dtg_dataBFprint.Rows[i].Cells[13].Value = "-";
                }

                if (dtg_dataBFprint.Rows[i].Cells[14].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[14].Value.ToString() == "0")
                {
                    dtg_dataBFprint.Rows[i].Cells[14].Value = "-";
                }

                if (dtg_dataBFprint.Rows[i].Cells[15].Value.ToString() == "" || dtg_dataBFprint.Rows[i].Cells[15].Value.ToString() == "0")
                {
                    dtg_dataBFprint.Rows[i].Cells[15].Value = "-";
                }
            }
            

            con.Close();


                //save to scrystal report
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductID", typeof(string));
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("JAN", typeof(string));
            dt.Columns.Add("FEB", typeof(string));
            dt.Columns.Add("MAR", typeof(string));
            dt.Columns.Add("ARP", typeof(string));
            dt.Columns.Add("MAY", typeof(string));
            dt.Columns.Add("JUN", typeof(string));
            dt.Columns.Add("JULY", typeof(string));
            dt.Columns.Add("AUG", typeof(string));
            dt.Columns.Add("SEP", typeof(string));
            dt.Columns.Add("OCT", typeof(string));
            dt.Columns.Add("NOV", typeof(string));
            dt.Columns.Add("DEC", typeof(string));
            dt.Columns.Add("Total", typeof(string));
          
                                                                        
            foreach (DataGridViewRow dgv in dtg_dataBFprint.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value, dgv.Cells[6].Value, dgv.Cells[7].Value, dgv.Cells[8].Value, dgv.Cells[9].Value, dgv.Cells[10].Value, dgv.Cells[11].Value, dgv.Cells[12].Value, dgv.Cells[13].Value, dgv.Cells[14].Value, dgv.Cells[15].Value);
            }

            ds.Tables.Add(dt);
            ds.WriteXmlSchema("DBTemp.xml");

            crp_store_year cr = new crp_store_year();           
            cr.SetDataSource(ds);
            cr.SetParameterValue("Year", dtp_edReport.Text);
            crystalReportViewer1.ReportSource = cr;
            
        }
          
        private void cb_typeReport_SelectedIndexChanged(object sender, EventArgs e)
        {          

            if (cb_typeReport.SelectedValue.ToString() == "57")
            {
                panel3.Visible = true;
                panel3.Dock = DockStyle.Right;
            }
            else { panel3.Visible = false; }

            Select_Product();

        }

        private void Select_Product()
        {
            try
            {
                rdo_purchase.Checked = false;
                rdo_sale.Checked = false;
                rdo_sale.Enabled = true;
                rdo_purchase.Enabled = true;
                Sort_Product = "";
                tabControl1.SelectedIndex = 1;
                btn_searchProduct.Enabled = true;
                lbl_selectProduct.Text = "";
                int id_print = Convert.ToInt16(cb_typeReport.SelectedValue.ToString());
                lbl_selectProduct.Text = "-- ทั้งหมด --";

                groupBox1.Enabled = true;
                groupBox3.Enabled = true;
                label2.Visible = true;
                dtp_stReport.Visible = true;
                dtp_edReport.Format = DateTimePickerFormat.Short;
                label3.Text = "วันที่สิ้นสุด:";
                dtp_edReport.ShowUpDown = false;

                //All Purchase & Sale
                if (id_print == 28 || id_print == 51 || id_print == 56 || id_print == 60)
                {
                    btn_searchProduct.Enabled = true;                 
                }

                if (id_print == 29 || id_print == 30 || id_print == 36 || id_print == 38 || id_print == 39 || id_print == 43 || id_print == 44 || id_print == 48  || id_print == 49 || id_print == 55 || id_print == 59 || id_print == 61 || id_print == 62 ) // Purchase Onloy
                {
                    rdo_purchase.Checked = true; rdo_sale.Enabled = false;
                }           


                if (id_print == 41 || id_print == 42 || id_print == 45 ||  id_print == 58)  // Sale Onloy
                {
                    rdo_sale.Checked = true; rdo_purchase.Enabled = false;
                }


                if ( id_print == 46 || id_print == 47 || id_print == 52 || id_print == 53) //SP report by product
                {
                    btn_searchProduct.Enabled = true;
                    lbl_selectProduct.Text = "มันเส้นหรือ มันสด";
                }
                            

                if (id_print == 57)   // REport Visual
                {
                    rdo_sale.Enabled = false;                   

                    tabControl1.SelectedIndex = 3;
                    Load_DataPurchase();
                }

                if (id_print == 63)   // REport Visual
                {
                    groupBox1.Enabled = false;
                    groupBox3.Enabled = false;
                    label2.Visible = false;
                    dtp_stReport.Visible = false;
                    btn_getData.Enabled = true;
                    dtp_edReport.Format = DateTimePickerFormat.Custom;
                    dtp_edReport.CustomFormat = "yyyy"; // this line gives you only the month and year.
                    dtp_edReport.ShowUpDown = true;
                    label3.Text = "  เลือกปี: ";
                    tabControl1.SelectedIndex = 0;
                }

                if (id_print == 64)   // REport Visual
                {
                    rdo_purchase.Enabled = false;
                    rdo_sale.Enabled = false;
                    groupBox1.Enabled = false;
                    btn_getData.Enabled = true;                       
                }

                if (id_print == 65)   // REport Store
                {
                    dtp_stReport.Enabled = false;
                    dtp_edReport.Enabled = false;
                    groupBox1.Enabled = false;
                    groupBox3.Enabled = false;
                    btn_getData.Enabled = true;
                }

                cb_vendor.Text = "-- เลือกทั้งหมด --";
                cb_customer.Text = "-- เลือกทั้งหมด --";
             

            }

            catch (Exception ex)

            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void cb_productReport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtp_edReport_ValueChanged(object sender, EventArgs e)
        {
            Load_Vendor_Customer();

            ////Select_Product();
            // try
            //{
            //    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            //    con.ConnectionString = Program.pathdb_Weight;
            //    SqlDataAdapter dtAdapter = new SqlDataAdapter();

            //    int id_print = Convert.ToInt16(cb_typeReport.SelectedValue.ToString());          

            //    string ST_Date = dtp_stReport.Value.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
            //    string ED_Date = dtp_edReport.Value.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));

            //    if (id_print == 28) //Report register
            //    {

            //        crp_register_01 crt_Register = new crp_register_01();
            //        string sql1 = "SELECT *  FROM  [dbo].[V_Ticket_Register] WHERE [RegisterInDate] Between '" + ST_Date + "'  AND  '" + ED_Date + "' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "'";

            //        DataSet ds = new DataSet();
            //        con.Open();
            //        SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //        adapter.Fill(ds, "payment");
            //        crt_Register.SetDataSource(ds.Tables["payment"]);
            //        crystalReportViewer1.ReportSource = crt_Register;
            //        crystalReportViewer1.Refresh();
            //        con.Close();
            //    }

            //    if (id_print == 29) //daily weight report
            //    {
            //        crp_Pur_weightdaily crt_weight = new crp_Pur_weightdaily();

            //        string sql1 = "SELECT *  FROM  [dbo].[V_WeightData] WHERE [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "'";

            //        DataSet ds = new DataSet();
            //        con.Open();
            //        SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //        adapter.Fill(ds, "dialy_weight");
            //        crt_weight.SetDataSource(ds.Tables["dialy_weight"]);
            //        crystalReportViewer1.ReportSource = crt_weight;
            //        crystalReportViewer1.Refresh();
            //        con.Close();
            //    }

            //    if (id_print == 30) //summary weight report
            //    {
            //        string sql1 = "";
            //        DataSet ds = new DataSet();
            //        con.Open();

            //        if (cb_productReport.SelectedValue.ToString() != "RM-001_1")
            //        {
            //            crp_Pur_weightsummary crt_weight = new crp_Pur_weightsummary();
            //            // string sql1 = "SELECT *  FROM  [dbo].[V_Ticket_Register] WHERE [RegisterInDate] Between '"+ST_Date+" 00:00.00'  AND  '"+ED_Date+ " 23:59:59.999' AND ProductID ='" + cb_productReport.SelectedValue.ToString() + "'";

            //            sql1 = "SELECT *  FROM  [dbo].[V_WeightData] WHERE [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "' Order by [TicketCodeIn]";
            //            SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //            adapter.Fill(ds, "sum_weight");
            //            crt_weight.SetDataSource(ds.Tables["sum_weight"]);
            //            crystalReportViewer1.ReportSource = crt_weight;

            //        }

            //        else
            //        {
            //            //crp_Pur_weightsummary_byUnitprice
            //            //crp_Pur_weightsummary_byUnitprice crt_weight = new crp_Pur_weightsummary();
            //            crp_Pur_weightsum_byUnitprice crt_weight = new crp_Pur_weightsum_byUnitprice();
            //            // string sql1 = "SELECT *  FROM  [dbo].[V_Ticket_Register] WHERE [RegisterInDate] Between '"+ST_Date+" 00:00.00'  AND  '"+ED_Date+ " 23:59:59.999' AND ProductID ='" + cb_productReport.SelectedValue.ToString() + "'";

            //            sql1 = "SELECT *  FROM  [dbo].[V_WeightData_UnitPrice] WHERE [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "' Order by [TicketCodeIn]";
            //            SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //            adapter.Fill(ds, "sum_weight");
            //            crt_weight.SetDataSource(ds.Tables["sum_weight"]);
            //            crystalReportViewer1.ReportSource = crt_weight;
            //        }

            //        crystalReportViewer1.Refresh();
            //        con.Close();
            //    }

            //    if (id_print == 36) //Visaul Report
            //    {
            //        crp_Visual crp_visual = new crp_Visual();

            //        string sql1 = "SELECT *  FROM  [dbo].[V_Visual_Image] WHERE [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "'";

            //        DataSet ds = new DataSet();
            //        con.Open();
            //        SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //        adapter.Fill(ds, "Rp_visual");
            //        crp_visual.SetDataSource(ds.Tables["Rp_visual"]);
            //        crystalReportViewer1.ReportSource = crp_visual;
            //        crystalReportViewer1.Refresh();
            //        con.Close();
            //    }

            //    if (id_print == 38) //QA Report All Lab RM-004, RM-001
            //    {
            //        if (cb_productReport.SelectedValue.ToString() == "RM-004")
            //        {
            //            con.Open();
            //            string sql1 = "Select * From [V_PaymentReport] Where [PayDate] Between '" + ST_Date + "'  AND  '" + ED_Date + "' Order by [PaymentID]";
            //            DataSet ds = new DataSet();
            //            crp_PurReport_Summary_SP crp_SP = new crp_PurReport_Summary_SP();
            //            SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //            adapter.Fill(ds, "crt_SP_RM004");
            //            crp_SP.SetDataSource(ds.Tables["crt_SP_RM004"]);
            //            crp_SP.SetParameterValue("st_date", ST_Date.ToString());
            //            crp_SP.SetParameterValue("ed_date", ED_Date.ToString());
            //            crystalReportViewer1.ReportSource = crp_SP;
            //            crystalReportViewer1.Refresh();
            //            con.Close();
            //        }
            //        //if (cb_productReport.SelectedValue.ToString() == "RM-001")
            //        //{
            //        //    con.Open();
            //        //    string sql1 = "Select * From [V_RPQA_RM001] Where [CreateDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' Order by [TicketCodeIn]";
            //        //    DataSet ds = new DataSet();
            //        //    crp_LabRM001 crp_Lab = new crp_LabRM001();
            //        //    SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //        //    adapter.Fill(ds, "crt_qaRM001");
            //        //    crp_Lab.SetDataSource(ds.Tables["crt_qaRM001"]);
            //        //    crp_Lab.SetParameterValue("st_date", ST_Date.ToString());
            //        //    crp_Lab.SetParameterValue("ed_date", ED_Date.ToString());
            //        //    crystalReportViewer1.ReportSource = crp_Lab;
            //        //    crystalReportViewer1.Refresh();
            //        //    con.Close();
            //        //}
            //    }

            //    if (id_print == 39) //QA Report All Lab RM-004, RM-001
            //    {
            //        //if (cb_productReport.SelectedValue.ToString() == "RM-004")
            //        //{
            //        //    con.Open();
            //        //    string sql1 = "Select * From [V_PaymentReport] Where [PayDate] Between '" + ST_Date + "'  AND  '" + ED_Date + "' Order by [PaymentID]";
            //        //    DataSet ds = new DataSet();
            //        //    crp_PurReport_Summary_SP crp_SP = new crp_PurReport_Summary_SP();
            //        //    SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //        //    adapter.Fill(ds, "crt_SP_RM004");
            //        //    crp_SP.SetDataSource(ds.Tables["crt_SP_RM004"]);
            //        //    crp_SP.SetParameterValue("st_date", ST_Date.ToString());
            //        //    crp_SP.SetParameterValue("ed_date", ED_Date.ToString());
            //        //    crystalReportViewer1.ReportSource = crp_SP;
            //        //    crystalReportViewer1.Refresh();
            //        //    con.Close();
            //        //}
            //        if (cb_productReport.SelectedValue.ToString() == "RM-001")
            //        {
            //            con.Open();
            //            string sql1 = "Select * From [V_RpSP] Where [PayDate] Between '" + ST_Date + "'  AND  '" + ED_Date + "'  AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "'  Order by [Vendor_No]";
            //            DataSet ds = new DataSet();
            //            crp_SP crp_Lab = new crp_SP();
            //            SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //            adapter.Fill(ds, "payment");
            //            crp_Lab.SetDataSource(ds.Tables["payment"]);
            //            crp_Lab.SetParameterValue("st_date", ST_Date.ToString());
            //            crp_Lab.SetParameterValue("ed_date", ED_Date.ToString());
            //            crystalReportViewer1.ReportSource = crp_Lab;
            //            crystalReportViewer1.Refresh();
            //            con.Close();
            //        }
            //    }

            //    if (id_print == 41) //daily weight report
            //    {
            //        crp_Sale_weightdaily crt_weight = new crp_Sale_weightdaily();

            //        string sql1 = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "'";

            //        DataSet ds = new DataSet();
            //        con.Open();
            //        SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //        adapter.Fill(ds, "dialy_weight");
            //        crt_weight.SetDataSource(ds.Tables["dialy_weight"]);
            //        crystalReportViewer1.ReportSource = crt_weight;
            //        crystalReportViewer1.Refresh();
            //        con.Close();
            //    }

            //    if (id_print == 42) //summary weight report
            //    {
            //        crp_Sale_weightsummary crt_weight = new crp_Sale_weightsummary();
            //        // string sql1 = "SELECT *  FROM  [dbo].[V_Ticket_Register] WHERE [RegisterInDate] Between '"+ST_Date+" 00:00.00'  AND  '"+ED_Date+ " 23:59:59.999' AND ProductID ='" + cb_productReport.SelectedValue.ToString() + "'";

            //        string sql1 = "SELECT *  FROM  [dbo].[V_WeightData_Sale] WHERE [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "'";

            //        DataSet ds = new DataSet();
            //        con.Open();
            //        SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //        adapter.Fill(ds, "sum_weight");
            //        crt_weight.SetDataSource(ds.Tables["sum_weight"]);
            //        crystalReportViewer1.ReportSource = crt_weight;
            //        crystalReportViewer1.Refresh();
            //        con.Close();
            //    }

            //    if (id_print == 43) //SP report by product
            //    {
            //        crp_payment_sumarry crt_payment = new crp_payment_sumarry();
            //        // string sql1 = "SELECT *  FROM  [dbo].[V_Ticket_Register] WHERE [RegisterInDate] Between '"+ST_Date+" 00:00.00'  AND  '"+ED_Date+ " 23:59:59.999' AND ProductID ='" + cb_productReport.SelectedValue.ToString() + "'";

            //        string sql1 = "SELECT [PaymentID],[SaveDate],[PayDocNo],CONVERT (varchar, [PayDate], 103)AS 'PayDate',[Vendor_No],[VendorName],[CountTicket],[WeightNet],[Qty_Net],[WeightDef],[Unit_Net],[Price_Net],[ProvinceName],[ProductID],[ProductName],[Remark],[OwnerName]  FROM[dbo].[V_PaymentReport] WHERE [PayDate] Between '" + ST_Date + "'  AND  '" + ED_Date + "' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "' Order by [Vendor_No]";

            //        DataSet ds = new DataSet();
            //        con.Open();
            //        SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //        adapter.Fill(ds, "sum_payment");
            //        crt_payment.SetDataSource(ds.Tables["sum_payment"]);
            //        crystalReportViewer1.ReportSource = crt_payment;
            //        crystalReportViewer1.Refresh();
            //        con.Close();
            //    }

            //    if (id_print == 44) //SP report by product
            //    {
            //        if (cb_productReport.SelectedValue.ToString() == "RM-004")
            //        {
            //            crp_payment_recived_R004 crt_payment = new crp_payment_recived_R004();

            //            //string sql1 = "SELECT  *   FROM  [dbo].[V_Payment_Recived_R004] WHERE [SaveDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "' AND [StatusActive] =1 Order by [TicketCodeIn]";

            //            string sql1 = "SELECT  *   FROM  [dbo].[V_Payment_Recived_R004] WHERE [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "' AND [StatusActive] =1 Order by [TicketCodeIn]";


            //            //string sql1 = "SELECT  *   FROM  [dbo].[V_Payment_Recived_R004] WHERE  [SaveDate]  Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "' AND [StatusActive] =1 Order by [TicketCodeIn]";

            //            DataSet ds = new DataSet();
            //            con.Open();
            //            SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //            adapter.Fill(ds, "sum_payment");
            //            crt_payment.SetDataSource(ds.Tables["sum_payment"]);
            //            crt_payment.SetParameterValue("User_inv", Program.user_name);
            //            crystalReportViewer1.ReportSource = crt_payment;
            //            crystalReportViewer1.Refresh();
            //            con.Close();
            //        }

            //        if (cb_productReport.SelectedValue.ToString() == "RM-001")
            //        {
            //            crp_payment_recived_R001 crt_payment = new crp_payment_recived_R001();
            //            // string sql1 = "SELECT *  FROM  [dbo].[V_Ticket_Register] WHERE [RegisterInDate] Between '"+ST_Date+" 00:00.00'  AND  '"+ED_Date+ " 23:59:59.999' AND ProductID ='" + cb_productReport.SelectedValue.ToString() + "'";

            //            string sql1 = "SELECT  *   FROM  [dbo].[V_Payment_Recived_R001] WHERE [PayDate] Between '" + ST_Date + "'  AND  '" + ED_Date + "' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "' AND [StatusActive] =1 Order by [TicketCodeIn] ";

            //            DataSet ds = new DataSet();
            //            con.Open();
            //            SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //            adapter.Fill(ds, "sum_payment");
            //            crt_payment.SetDataSource(ds.Tables["sum_payment"]);
            //            crt_payment.SetParameterValue("User_inv", Program.user_name);
            //            crystalReportViewer1.ReportSource = crt_payment;
            //            crystalReportViewer1.Refresh();
            //            con.Close();
            //        }

            //    }

            //    if (id_print == 45) //SP report by product
            //    {
            //        crp_sendproduct crt_payment = new crp_sendproduct();
            //        // string sql1 = "SELECT *  FROM  [dbo].[V_Ticket_Register] WHERE [RegisterInDate] Between '"+ST_Date+" 00:00.00'  AND  '"+ED_Date+ " 23:59:59.999' AND ProductID ='" + cb_productReport.SelectedValue.ToString() + "'";

            //        string sql1 = "SELECT *  FROM  [dbo].[V_ReportEthanol] WHERE [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "' Order by [TicketCodeIn]";

            //        DataSet ds = new DataSet();
            //        con.Open();
            //        SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //        adapter.Fill(ds, "send_product");
            //        crt_payment.SetDataSource(ds.Tables["send_product"]);
            //        crystalReportViewer1.ReportSource = crt_payment;
            //        crystalReportViewer1.Refresh();
            //        con.Close();
            //    }

            //    if (id_print == 46) //SP report by product   Daily
            //    {
            //        DataSet ds1 = new DataSet();
            //        DataTable dt = new DataTable();
            //        //dtg_Cal.Visible = true;
            //        //dtg_Cal.Dock = DockStyle.Fill;

            //        dt.Columns.AddRange(new DataColumn[14] { new DataColumn("Date"), new DataColumn("W_Net"), new DataColumn("W_StarchIN"), new DataColumn("Max_StarchIN"), new DataColumn("Min_StarchIN"), new DataColumn("AVG_StarchPur"), new DataColumn("AVG_PricePur"), new DataColumn("AVG_PriceStarch"), new DataColumn("W_Starch28"), new DataColumn("AVG_Starch28"), new DataColumn("W_Starch23"), new DataColumn("AVG_Starch23"), new DataColumn("W_Visual"), new DataColumn("AVG_Visual") });

            //        string Date = "";
            //        string W_Net = "";
            //        string W_StarchIN = "";
            //        string Max_StarchIN = "";
            //        string Min_StarchIN = "";
            //        string AVG_StarchPur = "";
            //        string AVG_PricePur = "";
            //        string AVG_PriceStarch = "";
            //        string W_Starch28 = "";
            //        string AVG_Starch28 = "";
            //        string W_Starch23 = "";
            //        string AVG_Starch23 = "";
            //        string W_Visual = "";
            //        string AVG_Visual = "";

            //        string st_date = dtp_stReport.Value.ToString("yyyy-MM-dd");
            //        string ed_date = dtp_edReport.Value.ToString("yyyy-MM-dd");

            //        ////string connectionstring = @"data source=192.168.111.228;initial catalog=SapthipNewDB;uid=truck_scale; pwd=pass@2020;";
            //        //string connectionstring = "@"+Program.pathdb_Weight;
            //        //con.Open();

            //        string sql = "Select DISTINCT([PayDate]) AS 'DateS' From[dbo].[TB_Payment] Where[PayDate] Between '" + st_date + "' AND '" + ed_date + "'  AND [ProductID]= '" + cb_productReport.SelectedValue.ToString() + "' Order by [DateS]";
            //        con.Open();
            //        SqlCommand CM = new SqlCommand(sql, con);
            //        SqlDataReader DR = CM.ExecuteReader();

            //        //SqlConnection Conn = new SqlConnection(connectionstring);
            //        //SqlCommand Comm = new SqlCommand(sql, con);

            //        //SqlDataReader DR = Comm.ExecuteReader();
            //        while (DR.Read())
            //        {
            //            DateTime DT = Convert.ToDateTime(DR.GetValue(0).ToString());
            //            Date = DT.Day.ToString() + "/" + DT.Month.ToString() + "/" + DT.Year.ToString();

            //            dt.Rows.Add(Date, W_Net, W_StarchIN, Max_StarchIN, Min_StarchIN, AVG_StarchPur, AVG_PricePur, AVG_PriceStarch, W_Starch28, AVG_Starch28, W_Starch23, AVG_Starch23, W_Visual, AVG_Visual);
            //        }
            //        con.Close();

            //        dt.Rows.Add("สะสม", "", "", "", "", "", "", "", "", "", "", "", "", "");

            //        dtg_CalDay.DataSource = dt;

            //        dtg_CalDay.Columns[0].HeaderText = "วันที่";
            //        dtg_CalDay.Columns[1].HeaderText = "นน.รับเข้า (กก.)";
            //        dtg_CalDay.Columns[2].HeaderText = "นน.แป้งรับเข้า";
            //        dtg_CalDay.Columns[3].HeaderText = "%แป้งสูงสุดที่รับ";
            //        dtg_CalDay.Columns[4].HeaderText = "%แป้งต่ำสุดที่รับ";
            //        dtg_CalDay.Columns[5].HeaderText = "%แป้งที่ซื้อเฉลี่ย";
            //        dtg_CalDay.Columns[6].HeaderText = "ราคาซื้อเฉลี่ย";
            //        dtg_CalDay.Columns[7].HeaderText = "ราคาแป้งเฉลี่ย";
            //        dtg_CalDay.Columns[8].HeaderText = "นน.แป้ง >28%";
            //        dtg_CalDay.Columns[9].HeaderText = "% นน.แป้ง >28% ";
            //        dtg_CalDay.Columns[10].HeaderText = "นน.แป้ง <23%";
            //        dtg_CalDay.Columns[11].HeaderText = "% นน.แป้ง <23%";
            //        dtg_CalDay.Columns[12].HeaderText = "นน.สิ่งเจือปน";
            //        dtg_CalDay.Columns[13].HeaderText = "% สิ่งเจือปน";

            //        dtg_CalDay.Columns[0].Width = 80;

            //        //Summary

            //        double Sum_Total_WNet = 0;
            //        double Sum_Total_WStarch = 0;
            //        double AVG_MaxStarch = 0;
            //        double AVG_MinStarch = 0;
            //        double AVG_PurStarch = 0;
            //        double AVG_PriceStarchs = 0;
            //        double AVG_PurPrice = 0;
            //        double Sum_Total_W_Max28 = 0;
            //        double Sum_Total_W_Min23 = 0;
            //        double AVG_W_Max28 = 0;
            //        double AVG_W_Min23 = 0;
            //        double Sum_Total_W_Visual = 0;
            //        double AVG_W_Visual = 0;

            //        for (int i = 0; i < dtg_CalDay.Rows.Count; i++)
            //        {
            //            if (dtg_CalDay.Rows[i].Cells[0].Value.ToString() != "สะสม")
            //            {
            //                DateTime DT_con = Convert.ToDateTime(dtg_CalDay.Rows[i].Cells[0].Value.ToString());

            //                String Date_con = DT_con.Year.ToString() + "-" + DT_con.Month.ToString() + "-" + DT_con.Day.ToString();


            //                // Total 
            //                int Itmes_Count = 0;
            //                double Total_W_Net = 0;
            //                double Total_W_Starch = 0;
            //                double Total_AVG_MaxStarch = 0;
            //                double Total_AVG_MinStarch = 0;
            //                double Total_PriceStarchs = 0;
            //                double Total_PurPrice = 0;
            //                double Total_W_Max28 = 0;
            //                double Total_W_Min23 = 0;
            //                double Total_AVG_W_Max28 = 0;
            //                double Total_AVG_W_Min23 = 0;
            //                double Total_W_Visual = 0;
            //                double Total_AVG_W_Visual = 0;

            //                SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
            //                con1.ConnectionString = Program.pathdb_Weight;
            //                SqlDataAdapter dtAdapter1 = new SqlDataAdapter();
            //                con1.Open();

            //                SqlConnection con2 = new SqlConnection(Program.pathdb_Weight);
            //                con2.ConnectionString = Program.pathdb_Weight;
            //                SqlDataAdapter dtAdapter2 = new SqlDataAdapter();
            //                con2.Open();

            //                string sql7 = "Select [PaymentID] From [dbo].[TB_Payment] Where [PayDate]='" + Date_con + "' AND [ProductID]= '" + cb_productReport.SelectedValue.ToString() + "'  AND Trim([Remark])='บันทึกสำเร็จ'";
            //                SqlCommand CM7 = new SqlCommand(sql7, con1);
            //                SqlDataReader DR7 = CM7.ExecuteReader();
            //                while (DR7.Read())
            //                {
            //                    string PaymentID = DR7["PaymentID"].ToString();

            //                    try
            //                    {

            //                        string sql2 = "Select (([VisualSP]* [Weigh_Net])/100) AS 'W_Visual'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [ValueStarch] >= 28 AND [StatusActive]=1 ";
            //                        SqlCommand CM2 = new SqlCommand(sql2, con2);
            //                        SqlDataReader DR2 = CM2.ExecuteReader();
            //                        DR2.Read();
            //                        {
            //                            Total_W_Visual += Convert.ToDouble(DR2["W_Visual"].ToString());
            //                        }
            //                        DR2.Close();
            //                        con2.Close();
            //                    }
            //                    catch { con2.Close(); }

            //                    try
            //                    {
            //                        con2.Open();
            //                        string sql3 = "Select Sum([Weigh_Net])AS 'W_Max28'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [ValueStarch] >= 28 AND [StatusActive]=1 ";
            //                        SqlCommand CM3 = new SqlCommand(sql3, con2);
            //                        SqlDataReader DR3 = CM3.ExecuteReader();
            //                        DR3.Read();
            //                        {
            //                            Total_W_Max28 += Convert.ToDouble(DR3["W_Max28"].ToString());
            //                        }
            //                        DR3.Close();
            //                        con2.Close();
            //                    }
            //                    catch { con2.Close(); }

            //                    try
            //                    {
            //                        con2.Open();
            //                        string sql4 = "Select Sum([Weigh_Net])AS 'W_Min23'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [ValueStarch] <= 23 AND [StatusActive]=1";
            //                        SqlCommand CM4 = new SqlCommand(sql4, con2);
            //                        SqlDataReader DR4 = CM4.ExecuteReader();
            //                        DR4.Read();
            //                        {
            //                            Total_W_Min23 += Convert.ToDouble(DR4["W_Min23"].ToString());
            //                        }
            //                        DR4.Close();
            //                        con2.Close();
            //                    }
            //                    catch { con2.Close(); }

            //                    con2.Open();
            //                    string sql5 = "Select Count([TicketCodeIn])AS 'CountItems'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [StatusActive]=1";
            //                    SqlCommand CM5 = new SqlCommand(sql5, con2);
            //                    SqlDataReader DR5 = CM5.ExecuteReader();
            //                    DR5.Read();
            //                    {
            //                        Itmes_Count += Convert.ToInt16(DR5["CountItems"].ToString());
            //                    }
            //                    DR5.Close();
            //                    con2.Close();

            //                    try
            //                    {
            //                        con2.Open();
            //                        string sql6 = "Select Sum([Weigh_Net])AS 'W_Net'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [StatusActive]=1";
            //                        SqlCommand CM6 = new SqlCommand(sql6, con2);
            //                        SqlDataReader DR6 = CM6.ExecuteReader();
            //                        DR6.Read();
            //                        {
            //                            Total_W_Net += Convert.ToDouble(DR6["W_Net"].ToString());
            //                        }
            //                        DR6.Close();
            //                        con2.Close();
            //                    }
            //                    catch { con2.Close(); }

            //                    try
            //                    {
            //                        con2.Open();
            //                        string sql8 = "Select  ([Weigh_Net]*[ValueStarch]/100) AS 'W_Pay',(PricePayment/Weigh_Net) AS 'AVG_Price'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [StatusActive]=1";

            //                        SqlCommand CM8 = new SqlCommand(sql8, con2);
            //                        SqlDataReader DR8 = CM8.ExecuteReader();
            //                        while (DR8.Read())
            //                        {
            //                            Total_W_Starch += Convert.ToDouble(DR8["W_Pay"].ToString());
            //                            Total_PurPrice += Convert.ToDouble(DR8["AVG_Price"].ToString());
            //                        }
            //                        DR8.Close();
            //                        con2.Close();
            //                    }

            //                    catch
            //                    {
            //                        con2.Close();
            //                    }


            //                    try
            //                    {
            //                        con2.Open();
            //                        string sql9 = "Select Max(ValueStarch) AS 'Max_Strach'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [StatusActive]=1";
            //                        SqlCommand CM9 = new SqlCommand(sql9, con2);
            //                        SqlDataReader DR9 = CM9.ExecuteReader();
            //                        DR9.Read();
            //                        {
            //                            if (Total_AVG_MaxStarch == 0)
            //                            {
            //                                Total_AVG_MaxStarch = Convert.ToDouble(DR9["Max_Strach"].ToString());
            //                            }
            //                            else if (Convert.ToDouble(DR9["Max_Strach"].ToString()) > Total_AVG_MaxStarch)
            //                            {
            //                                Total_AVG_MaxStarch = Convert.ToDouble(DR9["Max_Strach"].ToString());
            //                            }

            //                        }
            //                        DR9.Close();
            //                        con2.Close();
            //                    }
            //                    catch { con2.Close(); }



            //                    try
            //                    {
            //                        con2.Open();

            //                        string sql10 = "Select Min(ValueStarch) AS 'Min_Strach'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [StatusActive]=1";
            //                        SqlCommand CM10 = new SqlCommand(sql10, con2);
            //                        SqlDataReader DR10 = CM10.ExecuteReader();
            //                        DR10.Read();
            //                        {

            //                            if (Total_AVG_MinStarch == 0)
            //                            {
            //                                Total_AVG_MinStarch = Convert.ToDouble(DR10["Min_Strach"].ToString());
            //                                AVG_MinStarch = Total_AVG_MinStarch;
            //                            }
            //                            else if (Convert.ToDouble(DR10["Min_Strach"].ToString()) < Total_AVG_MinStarch)
            //                            {
            //                                Total_AVG_MinStarch = Convert.ToDouble(DR10["Min_Strach"].ToString());
            //                            }

            //                        }
            //                        DR10.Close();
            //                        con2.Close();
            //                    }
            //                    catch
            //                    {
            //                        con2.Close();
            //                    }

            //                }

            //                AVG_PurStarch = (Total_W_Starch / Total_W_Net) * 100;
            //                Total_PurPrice = Total_PurPrice / Itmes_Count;
            //                Total_PriceStarchs = Total_W_Net / Total_W_Starch;
            //                Total_AVG_W_Max28 = (Total_W_Max28 / Total_W_Net) * 100;
            //                Total_AVG_W_Min23 = (Total_W_Min23 / Total_W_Net) * 100;
            //                Total_AVG_W_Visual = (Total_W_Visual / Total_W_Net) * 100;

            //                dtg_CalDay.Rows[i].Cells[1].Value = Total_W_Net.ToString("##,###");
            //                dtg_CalDay.Rows[i].Cells[2].Value = Total_W_Starch.ToString("##,###");
            //                dtg_CalDay.Rows[i].Cells[3].Value = Total_AVG_MaxStarch.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[4].Value = Total_AVG_MinStarch.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[5].Value = AVG_PurStarch.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[6].Value = Total_PurPrice.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[7].Value = Total_PriceStarchs.ToString("f2");
            //                if (Total_W_Max28 == 0) { dtg_CalDay.Rows[i].Cells[8].Value = Total_W_Max28.ToString("f2"); }
            //                else { dtg_CalDay.Rows[i].Cells[8].Value = Total_W_Max28.ToString("##,###"); }
            //                dtg_CalDay.Rows[i].Cells[9].Value = Total_AVG_W_Max28.ToString("f2");
            //                if (Total_W_Min23 == 0) { dtg_CalDay.Rows[i].Cells[10].Value = Total_W_Min23.ToString("f2"); }
            //                else { dtg_CalDay.Rows[i].Cells[10].Value = Total_W_Min23.ToString("##,###"); }
            //                dtg_CalDay.Rows[i].Cells[11].Value = Total_AVG_W_Min23.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[12].Value = Total_W_Visual.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[13].Value = Total_AVG_W_Visual.ToString("f2");
            //                //System.Math.Round(Total_AVG_MaxStarch);

            //                AVG_PriceStarchs += Total_PriceStarchs;
            //                Sum_Total_WNet += Total_W_Net;
            //                Sum_Total_WStarch += Total_W_Starch;
            //                AVG_PurPrice += Total_PurPrice;
            //                Sum_Total_W_Max28 += Total_W_Max28;
            //                Sum_Total_W_Min23 += Total_W_Min23;
            //                Sum_Total_W_Visual += Total_W_Visual;

            //                if (Total_AVG_MaxStarch > AVG_MaxStarch)
            //                {
            //                    AVG_MaxStarch = Total_AVG_MaxStarch;
            //                }

            //                if (Total_AVG_MinStarch < AVG_MinStarch)
            //                {
            //                    AVG_MinStarch = Total_AVG_MinStarch;
            //                }

            //                Total_W_Net = 0;
            //                Total_W_Starch = 0;
            //                Total_AVG_MaxStarch = 0;
            //                Total_AVG_MinStarch = 0;
            //                Total_PurPrice = 0;
            //                Total_W_Max28 = 0;
            //                Total_W_Min23 = 0;
            //                Total_PriceStarchs = 0;
            //                Total_W_Visual = 0;
            //            }


            //            else
            //            {
            //                int Rows = dtg_CalDay.RowCount - 1;

            //                AVG_PurStarch = (Sum_Total_WStarch / Sum_Total_WNet) * 100;
            //                AVG_PurPrice = AVG_PurPrice / Rows;
            //                AVG_W_Max28 = Sum_Total_W_Max28 / Sum_Total_WNet;
            //                AVG_W_Min23 = Sum_Total_W_Min23 / Sum_Total_WNet;
            //                AVG_PriceStarchs = AVG_PriceStarchs / Rows;
            //                AVG_W_Visual = Sum_Total_W_Visual / Sum_Total_WNet;

            //                dtg_CalDay.Rows[i].Cells[1].Value = Sum_Total_WNet.ToString("##,###");
            //                dtg_CalDay.Rows[i].Cells[2].Value = Sum_Total_WStarch.ToString("##,###");
            //                dtg_CalDay.Rows[i].Cells[3].Value = AVG_MaxStarch.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[4].Value = AVG_MinStarch.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[5].Value = AVG_PurStarch.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[6].Value = AVG_PurPrice.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[7].Value = AVG_PriceStarchs.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[8].Value = Sum_Total_W_Max28.ToString("##,###");
            //                dtg_CalDay.Rows[i].Cells[9].Value = AVG_W_Max28.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[10].Value = Sum_Total_W_Min23.ToString("##,###");
            //                dtg_CalDay.Rows[i].Cells[11].Value = AVG_W_Min23.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[12].Value = Sum_Total_W_Visual.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[13].Value = AVG_W_Visual.ToString("f2");

            //                Sum_Total_WNet = 0;
            //                Sum_Total_WStarch = 0;
            //                AVG_MaxStarch = 0;
            //                AVG_MinStarch = 0;
            //                AVG_PurPrice = 0;
            //                AVG_PriceStarchs = 0;
            //                AVG_W_Visual = 0;
            //            }

            //        }


            //        DataTable dt1 = new DataTable();

            //        dt1.Columns.AddRange(new DataColumn[14] { new DataColumn("Date"), new DataColumn("W_Net"), new DataColumn("W_StarchIN"), new DataColumn("Max_StarchIN"), new DataColumn("Min_StarchIN"), new DataColumn("AVG_StarchPur"), new DataColumn("AVG_PricePur"), new DataColumn("AVG_PriceStarch"), new DataColumn("W_Starch28"), new DataColumn("AVG_Starch28"), new DataColumn("W_Starch23"), new DataColumn("AVG_Starch23"), new DataColumn("W_Visual"), new DataColumn("AVG_Visual") });

            //        foreach (DataGridViewRow dgv in dtg_CalDay.Rows)
            //        {
            //            dt1.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value, dgv.Cells[6].Value, dgv.Cells[7].Value, dgv.Cells[8].Value, dgv.Cells[9].Value, dgv.Cells[10].Value, dgv.Cells[11].Value, dgv.Cells[12].Value, dgv.Cells[13].Value);
            //        }

            //        ds1.Tables.Add(dt1);
            //        ds1.WriteXmlSchema("dataCost.xml");

            //        con.Close();


            //        //dtg_Cal.Visible = true;
            //        //dtg_Cal.Dock = DockStyle.Fill;

            //        //transefer data to crystalreportviewer

            //        Crp_CostSP cr = new Crp_CostSP();
            //        cr.SetDataSource(ds1);
            //        cr.SetParameterValue("Report_Name", cb_typeReport.Text);
            //        cr.SetParameterValue("Product_Name", cb_productReport.SelectedValue.ToString() + "-" + cb_productReport.Text);
            //        cr.SetParameterValue("St_date", dtp_stReport.Value.ToShortDateString());
            //        cr.SetParameterValue("Ed_date", dtp_edReport.Value.ToShortDateString());
            //        crystalReportViewer1.ReportSource = cr;
            //        crystalReportViewer1.Refresh();




            //    }

            //    if (id_print == 47) //SP report by product   Monthly
            //    {
            //        DataSet ds1 = new DataSet();
            //        DataTable dt = new DataTable();
            //        //dtg_Cal.Visible = true;
            //        //dtg_Cal.Dock = DockStyle.Fill;


            //        dt.Columns.AddRange(new DataColumn[14] { new DataColumn("Date"), new DataColumn("W_Net"), new DataColumn("W_StarchIN"), new DataColumn("Max_StarchIN"), new DataColumn("Min_StarchIN"), new DataColumn("AVG_StarchPur"), new DataColumn("AVG_PricePur"), new DataColumn("AVG_PriceStarch"), new DataColumn("W_Starch28"), new DataColumn("AVG_Starch28"), new DataColumn("W_Starch23"), new DataColumn("AVG_Starch23"), new DataColumn("W_Visual"), new DataColumn("AVG_Visual") });

            //        string Date = "";
            //        string W_Net = "";
            //        string W_StarchIN = "";
            //        string Max_StarchIN = "";
            //        string Min_StarchIN = "";
            //        string AVG_StarchPur = "";
            //        string AVG_PricePur = "";
            //        string AVG_PriceStarch = "";
            //        string W_Starch28 = "";
            //        string AVG_Starch28 = "";
            //        string W_Starch23 = "";
            //        string AVG_Starch23 = "";
            //        string W_Visual = "";
            //        string AVG_Visual = "";

            //        string st_date = dtp_stReport.Value.ToString("yyyy-MM-dd") + " 00:00:00.000";
            //        string ed_date = dtp_edReport.Value.ToString("yyyy-MM-dd") + " 00:00:00.000";

            //        //string connectionstring = @"data source=192.168.111.225;initial catalog=SapthipNewDB;uid=truck_scale; pwd=pass@2020;";
            //        //string connectionstring = Program.pathdb_Weight;
            //        con.Open();
            //        string sql = "Select DISTINCT([PayDate]) AS 'DateS' From[dbo].[TB_Payment] Where[PayDate] Between '" + ST_Date + "' AND '" + ED_Date + "'  AND [ProductID]= '" + cb_productReport.SelectedValue.ToString() + "' Order by [DateS]";

            //        SqlCommand CM = new SqlCommand(sql, con);
            //        SqlDataReader DR = CM.ExecuteReader();

            //        //SqlConnection Conn = new SqlConnection(connectionstring);
            //        //SqlCommand Comm = new SqlCommand(sql, con);
            //        //con.Open();
            //        //SqlDataReader DR = Comm.ExecuteReader();
            //        while (DR.Read())
            //        {
            //            DateTime DT = Convert.ToDateTime(DR.GetValue(0).ToString());
            //            Date = DT.Day.ToString() + "/" + DT.Month.ToString() + "/" + DT.Year.ToString();

            //            dt.Rows.Add(Date, W_Net, W_StarchIN, Max_StarchIN, Min_StarchIN, AVG_StarchPur, AVG_PricePur, AVG_PriceStarch, W_Starch28, AVG_Starch28, W_Starch23, AVG_Starch23, W_Visual, AVG_Visual);
            //        }
            //        con.Close();

            //        dt.Rows.Add("รวมสะสม", "", "", "", "", "", "", "", "", "", "", "", "", "");

            //        dtg_CalDay.DataSource = dt;

            //        dtg_CalDay.Columns[0].HeaderText = "วันที่";
            //        dtg_CalDay.Columns[1].HeaderText = "นน.รับเข้า (กก.)";
            //        dtg_CalDay.Columns[2].HeaderText = "นน.แป้งรับเข้า";
            //        dtg_CalDay.Columns[3].HeaderText = "%แป้งสูงสุดที่รับ";
            //        dtg_CalDay.Columns[4].HeaderText = "%แป้งต่ำสุดที่รับ";
            //        dtg_CalDay.Columns[5].HeaderText = "%แป้งที่ซื้อเฉลี่ย";
            //        dtg_CalDay.Columns[6].HeaderText = "ราคาซื้อเฉลี่ย";
            //        dtg_CalDay.Columns[7].HeaderText = "ราคาแป้งเฉลี่ย";
            //        dtg_CalDay.Columns[8].HeaderText = "นน.แป้ง >28%";
            //        dtg_CalDay.Columns[9].HeaderText = "% นน.แป้ง >28% ";
            //        dtg_CalDay.Columns[10].HeaderText = "นน.แป้ง <23%";
            //        dtg_CalDay.Columns[11].HeaderText = "% นน.แป้ง <23%";
            //        dtg_CalDay.Columns[12].HeaderText = "นน.สิ่งเจือปน";
            //        dtg_CalDay.Columns[13].HeaderText = "% สิ่งเจือปน";

            //        //dtg_CalDay.Columns[0].Width = 80;

            //        //Summary

            //        double Sum_Total_WNet = 0;
            //        double Sum_Total_WStarch = 0;
            //        double AVG_MaxStarch = 0;
            //        double AVG_MinStarch = 0;
            //        double AVG_PurStarch = 0;
            //        double AVG_PriceStarchs = 0;
            //        double AVG_PurPrice = 0;
            //        double Sum_Total_W_Max28 = 0;
            //        double Sum_Total_W_Min23 = 0;
            //        double AVG_W_Max28 = 0;
            //        double AVG_W_Min23 = 0;
            //        double Sum_Total_W_Visual = 0;
            //        double AVG_W_Visual = 0;

            //        for (int i = 0; i < dtg_CalDay.Rows.Count; i++)
            //        {
            //            if (dtg_CalDay.Rows[i].Cells[0].Value.ToString() != "รวมสะสม")
            //            {
            //                DateTime DT_con = Convert.ToDateTime(dtg_CalDay.Rows[i].Cells[0].Value.ToString());

            //                String Date_con = DT_con.Year.ToString() + "-" + DT_con.Month.ToString() + "-" + DT_con.Day.ToString();


            //                // Total 
            //                int Itmes_Count = 0;
            //                double Total_W_Net = 0;
            //                double Total_W_Starch = 0;
            //                double Total_AVG_MaxStarch = 0;
            //                double Total_AVG_MinStarch = 0;
            //                double Total_PriceStarchs = 0;
            //                double Total_PurPrice = 0;
            //                double Total_W_Max28 = 0;
            //                double Total_W_Min23 = 0;
            //                double Total_AVG_W_Max28 = 0;
            //                double Total_AVG_W_Min23 = 0;
            //                double Total_W_Visual = 0;
            //                double Total_AVG_W_Visual = 0;

            //                SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
            //                con1.ConnectionString = Program.pathdb_Weight;
            //                SqlDataAdapter dtAdapter1 = new SqlDataAdapter();
            //                con1.Open();

            //                SqlConnection con2 = new SqlConnection(Program.pathdb_Weight);
            //                con2.ConnectionString = Program.pathdb_Weight;
            //                SqlDataAdapter dtAdapter2 = new SqlDataAdapter();
            //                con2.Open();

            //                string sql7 = "Select [PaymentID] From [dbo].[TB_Payment] Where [PayDate]='" + Date_con + "' AND [ProductID]= '" + cb_productReport.SelectedValue.ToString() + "' AND Trim([Remark])='บันทึกสำเร็จ'";
            //                SqlCommand CM7 = new SqlCommand(sql7, con1);
            //                SqlDataReader DR7 = CM7.ExecuteReader();
            //                while (DR7.Read())
            //                {
            //                    string PaymentID = DR7["PaymentID"].ToString();

            //                    try
            //                    {

            //                        string sql2 = "Select (([VisualSP]* [Weigh_Net])/100) AS 'W_Visual'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [ValueStarch] >= 28 AND [StatusActive]=1 ";
            //                        SqlCommand CM2 = new SqlCommand(sql2, con2);
            //                        SqlDataReader DR2 = CM2.ExecuteReader();
            //                        DR2.Read();
            //                        {
            //                            Total_W_Visual += Convert.ToDouble(DR2["W_Visual"].ToString());
            //                        }
            //                        DR2.Close();
            //                        con2.Close();
            //                    }
            //                    catch { con2.Close(); }


            //                    //Total_W_Max28
            //                    try
            //                    {
            //                        con2.Open();
            //                        string sql3 = "Select Sum([Weigh_Net])AS 'W_Max28'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [ValueStarch] >= 28 AND [StatusActive]=1 ";
            //                        SqlCommand CM3 = new SqlCommand(sql3, con2);
            //                        SqlDataReader DR3 = CM3.ExecuteReader();
            //                        DR3.Read();
            //                        {
            //                            Total_W_Max28 += Convert.ToDouble(DR3["W_Max28"].ToString());
            //                        }
            //                        DR3.Close();
            //                        con2.Close();
            //                    }
            //                    catch { con2.Close(); }


            //                    //Total_W_Min23
            //                    try
            //                    {
            //                        con2.Open();
            //                        string sql4 = "Select Sum([Weigh_Net])AS 'W_Min23'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [ValueStarch] <= 23 AND [StatusActive]=1";
            //                        SqlCommand CM4 = new SqlCommand(sql4, con2);
            //                        SqlDataReader DR4 = CM4.ExecuteReader();
            //                        DR4.Read();
            //                        {
            //                            Total_W_Min23 += Convert.ToDouble(DR4["W_Min23"].ToString());
            //                        }
            //                        DR4.Close();
            //                        con2.Close();
            //                    }
            //                    catch { con2.Close(); }


            //                    //CountItems
            //                    con2.Open();
            //                    string sql5 = "Select Count([TicketCodeIn])AS 'CountItems'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [StatusActive]=1";
            //                    SqlCommand CM5 = new SqlCommand(sql5, con2);
            //                    SqlDataReader DR5 = CM5.ExecuteReader();
            //                    DR5.Read();
            //                    {
            //                        Itmes_Count += Convert.ToInt16(DR5["CountItems"].ToString());
            //                    }
            //                    DR5.Close();
            //                    con2.Close();

            //                    //W_Net
            //                    con2.Open();
            //                    string sql6 = "Select Sum([Weigh_Net])AS 'W_Net'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [StatusActive]=1";
            //                    SqlCommand CM6 = new SqlCommand(sql6, con2);
            //                    SqlDataReader DR6 = CM6.ExecuteReader();
            //                    DR6.Read();
            //                    {
            //                        Total_W_Net += Convert.ToDouble(DR6["W_Net"].ToString());
            //                    }
            //                    DR6.Close();
            //                    con2.Close();


            //                    //AVG_Price
            //                    con2.Open();
            //                    string sql8 = "Select  ([Weigh_Net]*[ValueStarch]/100) AS 'W_Pay',(PricePayment/Weigh_Net) AS 'AVG_Price'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [StatusActive]=1";

            //                    SqlCommand CM8 = new SqlCommand(sql8, con2);
            //                    SqlDataReader DR8 = CM8.ExecuteReader();
            //                    while (DR8.Read())
            //                    {
            //                        Total_W_Starch += Convert.ToDouble(DR8["W_Pay"].ToString());
            //                        Total_PurPrice += Convert.ToDouble(DR8["AVG_Price"].ToString());
            //                    }
            //                    DR8.Close();
            //                    con2.Close();


            //                    //Max_Strach
            //                    con2.Open();
            //                    string sql9 = "Select Max(ValueStarch) AS 'Max_Strach'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [StatusActive]=1";
            //                    SqlCommand CM9 = new SqlCommand(sql9, con2);
            //                    SqlDataReader DR9 = CM9.ExecuteReader();
            //                    DR9.Read();
            //                    {
            //                        if (Total_AVG_MaxStarch == 0)
            //                        {
            //                            Total_AVG_MaxStarch = Convert.ToDouble(DR9["Max_Strach"].ToString());
            //                        }
            //                        else if (Convert.ToDouble(DR9["Max_Strach"].ToString()) > Total_AVG_MaxStarch)
            //                        {
            //                            Total_AVG_MaxStarch = Convert.ToDouble(DR9["Max_Strach"].ToString());
            //                        }

            //                    }
            //                    DR9.Close();


            //                    //Min_Strach
            //                    string sql10 = "Select Min(ValueStarch) AS 'Min_Strach'  From [dbo].[TB_PaymentDetail] Where [PayDocID ]=" + PaymentID + " AND [StatusActive]=1";
            //                    SqlCommand CM10 = new SqlCommand(sql10, con2);
            //                    SqlDataReader DR10 = CM10.ExecuteReader();
            //                    DR10.Read();
            //                    {

            //                        if (Total_AVG_MinStarch == 0)
            //                        {
            //                            Total_AVG_MinStarch = Convert.ToDouble(DR10["Min_Strach"].ToString());
            //                            AVG_MinStarch = Total_AVG_MinStarch;
            //                        }
            //                        else if (Convert.ToDouble(DR10["Min_Strach"].ToString()) < Total_AVG_MinStarch)
            //                        {
            //                            Total_AVG_MinStarch = Convert.ToDouble(DR10["Min_Strach"].ToString());
            //                        }

            //                    }
            //                    DR10.Close();


            //                }

            //                AVG_PurStarch = (Total_W_Starch / Total_W_Net) * 100;
            //                Total_PurPrice = Total_PurPrice / Itmes_Count;
            //                Total_PriceStarchs = Total_W_Net / Total_W_Starch;
            //                Total_AVG_W_Max28 = (Total_W_Max28 / Total_W_Net) * 100;
            //                Total_AVG_W_Min23 = (Total_W_Min23 / Total_W_Net) * 100;
            //                Total_AVG_W_Visual = (Total_W_Visual / Total_W_Net) * 100;

            //                dtg_CalDay.Rows[i].Cells[1].Value = Total_W_Net.ToString("##,###");
            //                dtg_CalDay.Rows[i].Cells[2].Value = Total_W_Starch.ToString("##,###");
            //                dtg_CalDay.Rows[i].Cells[3].Value = Total_AVG_MaxStarch.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[4].Value = Total_AVG_MinStarch.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[5].Value = AVG_PurStarch.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[6].Value = Total_PurPrice.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[7].Value = Total_PriceStarchs.ToString("f2");

            //                //dtg_CalDay.Rows[i].Cells[8].Value = Total_W_Max28.ToString("f2");

            //                dtg_CalDay.Rows[i].Cells[9].Value = Total_AVG_W_Max28.ToString("f2");


            //                if (Total_W_Max28 == 0) { dtg_CalDay.Rows[i].Cells[8].Value = Total_W_Max28.ToString("f2"); }
            //                else { dtg_CalDay.Rows[i].Cells[8].Value = Total_W_Max28.ToString("##,###"); }

            //                if (Total_W_Min23 == 0) { dtg_CalDay.Rows[i].Cells[10].Value = Total_W_Min23.ToString("f2"); }
            //                else { dtg_CalDay.Rows[i].Cells[10].Value = Total_W_Min23.ToString("##,###"); }

            //                dtg_CalDay.Rows[i].Cells[11].Value = Total_AVG_W_Min23.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[12].Value = Total_W_Visual.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[13].Value = Total_AVG_W_Visual.ToString("f2");
            //                //System.Math.Round(Total_AVG_MaxStarch);

            //                AVG_PriceStarchs += Total_PriceStarchs;
            //                Sum_Total_WNet += Total_W_Net;
            //                Sum_Total_WStarch += Total_W_Starch;
            //                AVG_PurPrice += Total_PurPrice;
            //                Sum_Total_W_Max28 += Total_W_Max28;
            //                Sum_Total_W_Min23 += Total_W_Min23;
            //                Sum_Total_W_Visual += Total_W_Visual;

            //                if (Total_AVG_MaxStarch > AVG_MaxStarch)
            //                {
            //                    AVG_MaxStarch = Total_AVG_MaxStarch;
            //                }

            //                if (Total_AVG_MinStarch < AVG_MinStarch)
            //                {
            //                    AVG_MinStarch = Total_AVG_MinStarch;
            //                }

            //                Total_W_Net = 0;
            //                Total_W_Starch = 0;
            //                Total_AVG_MaxStarch = 0;
            //                Total_AVG_MinStarch = 0;
            //                Total_PurPrice = 0;
            //                Total_W_Max28 = 0;
            //                Total_W_Min23 = 0;
            //                Total_PriceStarchs = 0;
            //                Total_W_Visual = 0;
            //            }


            //            else
            //            {
            //                int Rows = dtg_CalDay.RowCount - 1;

            //                AVG_PurStarch = (Sum_Total_WStarch / Sum_Total_WNet) * 100;
            //                AVG_PurPrice = AVG_PurPrice / Rows;
            //                AVG_W_Max28 = (Sum_Total_W_Max28 / Sum_Total_WNet) * 100;
            //                AVG_W_Min23 = (Sum_Total_W_Min23 / Sum_Total_WNet) * 100;
            //                AVG_PriceStarchs = AVG_PriceStarchs / Rows;
            //                AVG_W_Visual = (Sum_Total_W_Visual / Sum_Total_WNet) * 100;

            //                dtg_CalDay.Rows[i].Cells[1].Value = Sum_Total_WNet.ToString("##,###");
            //                dtg_CalDay.Rows[i].Cells[2].Value = Sum_Total_WStarch.ToString("##,###");
            //                dtg_CalDay.Rows[i].Cells[3].Value = AVG_MaxStarch.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[4].Value = AVG_MinStarch.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[5].Value = AVG_PurStarch.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[6].Value = AVG_PurPrice.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[7].Value = AVG_PriceStarchs.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[8].Value = Sum_Total_W_Max28.ToString("##,###");
            //                dtg_CalDay.Rows[i].Cells[9].Value = AVG_W_Max28.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[10].Value = Sum_Total_W_Min23.ToString("##,###");
            //                dtg_CalDay.Rows[i].Cells[11].Value = AVG_W_Min23.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[12].Value = Sum_Total_W_Visual.ToString("f2");
            //                dtg_CalDay.Rows[i].Cells[13].Value = AVG_W_Visual.ToString("f2");

            //                Sum_Total_WNet = 0;
            //                Sum_Total_WStarch = 0;
            //                AVG_MaxStarch = 0;
            //                AVG_MinStarch = 0;
            //                AVG_PurPrice = 0;
            //                AVG_PriceStarchs = 0;
            //                AVG_W_Visual = 0;
            //            }

            //        }



            //        ////Add Datagride Veiws Day To Datagride Views Month

            //        DataTable dt2 = new DataTable();
            //        dt2.Columns.AddRange(new DataColumn[14] { new DataColumn("Date"), new DataColumn("W_Net"), new DataColumn("W_StarchIN"), new DataColumn("Max_StarchIN"), new DataColumn("Min_StarchIN"), new DataColumn("AVG_StarchPur"), new DataColumn("AVG_PricePur"), new DataColumn("AVG_PriceStarch"), new DataColumn("W_Starch28"), new DataColumn("AVG_Starch28"), new DataColumn("W_Starch23"), new DataColumn("AVG_Starch23"), new DataColumn("W_Visual"), new DataColumn("AVG_Visual") });


            //        //dt2.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "");
            //        dtg_CalMonth.DataSource = dt2;

            //        int Count_Rows = 0;
            //        double Col1 = 0;
            //        double Col2 = 0;
            //        double Col3 = 0;
            //        double Col4 = 0;
            //        double Col5 = 0;
            //        double Col6 = 0;
            //        double Col7 = 0;
            //        double Col8 = 0;
            //        double Col9 = 0;
            //        double Col10 = 0;
            //        double Col11 = 0;
            //        double Col12 = 0;
            //        double Col13 = 0;

            //        int Row_CalMonth = 0;
            //        double Total_Col5 = 0;
            //        double AVG_PurPP = 0;
            //        double AVG_PriceST = 0;
            //        double AVG_28 = 0;
            //        double AVG_23 = 0;
            //        double AVG_VS = 0;

            //        //Create Mont on DTG Month
            //        for (int x = 0; x < dtg_CalDay.RowCount; x++)
            //        {
            //            DateTime DateT;
            //            if (dtg_CalDay.Rows[x].Cells[0].Value.ToString() != "รวมสะสม")
            //            {
            //                DateT = Convert.ToDateTime(dtg_CalDay.Rows[x].Cells[0].Value.ToString());

            //                if (dtg_CalMonth.RowCount == 0)
            //                {
            //                    dt2.Rows.Add(DateT.ToString("MM/yyyy"), "", "", "", "", "", "", "", "", "", "", "", "", "");
            //                    dtg_CalMonth.DataSource = dt2;

            //                    Col1 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[1].Value.ToString());
            //                    Col2 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[2].Value.ToString());
            //                    Col3 = Convert.ToDouble(dtg_CalDay.Rows[x].Cells[3].Value.ToString());
            //                    Col4 = Convert.ToDouble(dtg_CalDay.Rows[x].Cells[4].Value.ToString());
            //                    Col5 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[5].Value.ToString());
            //                    Col6 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[6].Value.ToString());
            //                    Col7 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[7].Value.ToString());
            //                    Col8 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[8].Value.ToString());
            //                    Col9 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[9].Value.ToString());
            //                    Col10 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[10].Value.ToString());
            //                    Col11 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[11].Value.ToString());
            //                    Col12 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[12].Value.ToString());
            //                    Col13 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[13].Value.ToString());
            //                    Count_Rows++;

            //                }

            //                else
            //                {
            //                    int STS_Check = 0;

            //                    for (int v = 0; v < dtg_CalMonth.RowCount; v++)
            //                    {
            //                        //ค้นหาเดือนที่ไม่ซ้ำ
            //                        if (DateT.ToString("MM/yyyy") != dtg_CalMonth.Rows[v].Cells[0].Value.ToString().Trim())
            //                        {
            //                            STS_Check = 1;
            //                        }

            //                        //ถ้าเดือนเดียวไม่ต้องเพิ่มเดือน
            //                        else
            //                        {
            //                            STS_Check = 0;

            //                            Col1 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[1].Value.ToString());
            //                            Col2 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[2].Value.ToString());
            //                            Col3 = Convert.ToDouble(dtg_CalDay.Rows[x].Cells[3].Value.ToString());
            //                            Col4 = Convert.ToDouble(dtg_CalDay.Rows[x].Cells[4].Value.ToString());
            //                            Col5 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[5].Value.ToString());
            //                            Col6 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[6].Value.ToString());
            //                            Col7 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[7].Value.ToString());
            //                            Col8 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[8].Value.ToString());
            //                            Col9 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[9].Value.ToString());
            //                            Col10 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[10].Value.ToString());
            //                            Col11 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[11].Value.ToString());
            //                            Col12 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[12].Value.ToString());
            //                            Col13 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[13].Value.ToString());
            //                        }



            //                        dtg_CalMonth.Rows[v].Cells[1].Value = Col1.ToString("##,####");
            //                        dtg_CalMonth.Rows[v].Cells[2].Value = Col2.ToString("##,####");
            //                        dtg_CalMonth.Rows[v].Cells[3].Value = Col3.ToString("f2");
            //                        dtg_CalMonth.Rows[v].Cells[4].Value = Col4.ToString("f2");
            //                        dtg_CalMonth.Rows[v].Cells[5].Value = Col5.ToString("f2");
            //                        dtg_CalMonth.Rows[v].Cells[6].Value = Col6.ToString("f2");
            //                        dtg_CalMonth.Rows[v].Cells[7].Value = Col7.ToString("f2");
            //                        dtg_CalMonth.Rows[v].Cells[8].Value = Col8.ToString("##,###");
            //                        dtg_CalMonth.Rows[v].Cells[9].Value = Col9.ToString("##,###");
            //                        dtg_CalMonth.Rows[v].Cells[10].Value = Col10.ToString("f2");
            //                        dtg_CalMonth.Rows[v].Cells[11].Value = Col11.ToString("f2");
            //                        dtg_CalMonth.Rows[v].Cells[12].Value = Col12.ToString("##,###");
            //                    }

            //                    if (STS_Check == 1)
            //                    {
            //                        dt2.Rows.Add(DateT.ToString("MM/yyyy"), "", "", "", "", "", "", "", "", "", "", "", "", "");
            //                        dtg_CalMonth.DataSource = dt2;
            //                    }
            //                }



            //            }
            //        }



            //        dt2.Rows.Add("รวมสะสม", "", "", "", "", "", "", "", "", "", "", "", "", "");
            //        dtg_CalMonth.DataSource = dt2;



            //        //    for (int x = 0; x < dtg_CalDay.RowCount; x++)
            //        //{
            //        //    if (dtg_CalDay.Rows[x].Cells[0].Value.ToString() != "สะสม")
            //        //    {

            //        //        DateTime DateT = Convert.ToDateTime(dtg_CalDay.Rows[x].Cells[0].Value.ToString());

            //        //        ////if (dtg_CalMonth.RowCount == 0)
            //        //        ////{
            //        //        ///
            //        //        //dt2.Rows.Add(DateT.ToString("MM/yyyy"), "", "", "", "", "", "","","", "","","","", "");
            //        //        //dtg_CalMonth.DataSource = dt2;

            //        //        //dt2.Rows.Add(DateT.ToString("MM/yyyy"), dtg_CalDay.Rows[x].Cells[1].Value.ToString(), dtg_CalDay.Rows[x].Cells[2].Value.ToString(), dtg_CalDay.Rows[x].Cells[3].Value.ToString(), dtg_CalDay.Rows[x].Cells[4].Value.ToString(), dtg_CalDay.Rows[x].Cells[5].Value.ToString(), dtg_CalDay.Rows[x].Cells[6].Value.ToString(), dtg_CalDay.Rows[x].Cells[7].Value.ToString(), dtg_CalDay.Rows[x].Cells[8].Value.ToString(), dtg_CalDay.Rows[x].Cells[9].Value.ToString(), dtg_CalDay.Rows[x].Cells[10].Value.ToString(), dtg_CalDay.Rows[x].Cells[11].Value.ToString(), dtg_CalDay.Rows[x].Cells[12].Value.ToString(), dtg_CalDay.Rows[x].Cells[13].Value.ToString());
            //        //        //    dtg_CalMonth.DataSource = dt2;

            //        //            //Count_Rows++;

            //        //        //}

            //        //        //        for (int y = 0; y < dtg_CalMonth.RowCount; y++)
            //        //        //        {
            //        //        //            string date_c;
            //        //        //            if (DateT.Year == 2020)
            //        //        //            { date_c = DateT.Month.ToString() + "/" + Convert.ToString(DateT.Year + 543); }
            //        //        //            else { date_c = DateT.Month.ToString() + "/" + DateT.Year.ToString(); }


            //        //        //            if (dtg_CalMonth.Rows[y].Cells[0].Value.ToString().Trim() != date_c.Trim())  //ถ้าไม่เท่าให้ เปลี่ยนเดือนใหม่
            //        //        //            {
            //        //        //                dt2.Rows.Add(dtg_CalDay.Rows[x].Cells[0].Value.ToString(), "", "", "", "", "", "", "", "", "", "", "", "", "");
            //        //        //                dtg_CalMonth.DataSource = dt2;

            //        //        //                //Count_Rows++;
            //        //        //            }

            //        //        //            //else
            //        //        //            //{


            //        //        //            //    Count_Rows++;
            //        //        //            //    Col1 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[1].Value.ToString());
            //        //        //            //    Col2 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[2].Value.ToString());

            //        //        //            //    if (Convert.ToDouble(dtg_CalDay.Rows[x].Cells[3].Value.ToString()) > Col3)
            //        //        //            //    {
            //        //        //            //        Col3 = Convert.ToDouble(dtg_CalDay.Rows[x].Cells[3].Value.ToString());   //Max
            //        //        //            //    }

            //        //        //            //    if (Convert.ToDouble(dtg_CalDay.Rows[x].Cells[4].Value.ToString()) < Col4 || Col4 == 0)
            //        //        //            //    {
            //        //        //            //        Col4 = Convert.ToDouble(dtg_CalDay.Rows[x].Cells[4].Value.ToString());   //Min
            //        //        //            //    }

            //        //        //            //    Col5 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[5].Value.ToString());
            //        //        //            //    Col6 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[6].Value.ToString());
            //        //        //            //    Col7 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[7].Value.ToString());
            //        //        //            //    Col8 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[8].Value.ToString());
            //        //        //            //    Col9 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[9].Value.ToString());
            //        //        //            //    Col10 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[10].Value.ToString());
            //        //        //            //    Col11 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[11].Value.ToString());
            //        //        //            //    Col12 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[12].Value.ToString());
            //        //        //            //    Col13 += Convert.ToDouble(dtg_CalDay.Rows[x].Cells[13].Value.ToString());


            //        //        //            //    dtg_CalMonth.Rows[y].Cells[1].Value = Col1.ToString("##,####");
            //        //        //            //    dtg_CalMonth.Rows[y].Cells[2].Value = Col2.ToString("##,####");
            //        //        //            //    dtg_CalMonth.Rows[y].Cells[3].Value = Col3.ToString("f2");
            //        //        //            //    dtg_CalMonth.Rows[y].Cells[4].Value = Col4.ToString("f2");

            //        //        //            //    //dtg_CalMonth.Rows[y].Cells[7].Value = Col7.ToString("f2");
            //        //        //            //    dtg_CalMonth.Rows[y].Cells[8].Value = Col8.ToString("##,###");
            //        //        //            //    //dtg_CalMonth.Rows[y].Cells[9].Value = Col9.ToString("f2");
            //        //        //            //    dtg_CalMonth.Rows[y].Cells[10].Value = Col10.ToString("##,###");
            //        //        //            //    //dtg_CalMonth.Rows[y].Cells[11].Value = Col11.ToString("f2");
            //        //        //            //    dtg_CalMonth.Rows[y].Cells[12].Value = Col12.ToString("##,###");
            //        //        //            //    //dtg_CalMonth.Rows[y].Cells[13].Value = Col13.ToString("f2");

            //        //        //            //    Row_CalMonth = y;
            //        //        //            //}

            //        //    }

            //        //    Total_Col5 = (Col2 / Col1) * 100;
            //        //    AVG_PurPP = (Col6 / Count_Rows);
            //        //    AVG_PriceST = (Col7 / Count_Rows);
            //        //    AVG_28 = (Col8 / Col1) * 100;
            //        //    AVG_23 = (Col10 / Col1) * 100;
            //        //    AVG_VS = (Col12 / Col1) * 100;

            //        //    dtg_CalMonth.Rows[Row_CalMonth].Cells[5].Value = Total_Col5.ToString("f2");
            //        //    dtg_CalMonth.Rows[Row_CalMonth].Cells[6].Value = AVG_PurPP.ToString("f2");
            //        //    dtg_CalMonth.Rows[Row_CalMonth].Cells[7].Value = AVG_PriceST.ToString("f2");

            //        //    dtg_CalMonth.Rows[Row_CalMonth].Cells[9].Value = AVG_28.ToString("f2");
            //        //    dtg_CalMonth.Rows[Row_CalMonth].Cells[11].Value = AVG_23.ToString("f2");
            //        //    dtg_CalMonth.Rows[Row_CalMonth].Cells[13].Value = AVG_VS.ToString("f2");

            //        //}

            //        //    else
            //        //    {
            //        //        int Count_Z = 0;
            //        //        double S_Col1 = 0;
            //        //        double S_Col2 = 0;
            //        //        double S_Col3 = 0;
            //        //        double S_Col4 = 0;
            //        //        double S_Col5 = 0;
            //        //        double S_Col6 = 0;
            //        //        double S_Col7 = 0;
            //        //        double S_Col8 = 0;
            //        //        double S_Col9 = 0;
            //        //        double S_Col10 = 0;
            //        //        double S_Col11 = 0;
            //        //        double S_Col12 = 0;
            //        //        double S_Col13 = 0;

            //        //        for (int z = 0; z < dtg_CalMonth.RowCount; z++)
            //        //        {
            //        //            S_Col1 += Convert.ToDouble(dtg_CalMonth.Rows[z].Cells[1].Value.ToString());
            //        //            S_Col2 += Convert.ToDouble(dtg_CalMonth.Rows[z].Cells[2].Value.ToString());

            //        //            if (Convert.ToDouble(dtg_CalMonth.Rows[z].Cells[3].Value.ToString()) < S_Col3)
            //        //            { S_Col3 = Convert.ToDouble(dtg_CalMonth.Rows[z].Cells[3].Value.ToString()); }

            //        //            if (Convert.ToDouble(dtg_CalMonth.Rows[z].Cells[4].Value.ToString()) > S_Col3 || S_Col3 == 0)
            //        //            { S_Col4 = Convert.ToDouble(dtg_CalMonth.Rows[z].Cells[4].Value.ToString()); }

            //        //            S_Col5 += Convert.ToDouble(dtg_CalMonth.Rows[z].Cells[5].Value.ToString());

            //        //            S_Col6 += Convert.ToDouble(dtg_CalMonth.Rows[z].Cells[6].Value.ToString());

            //        //            S_Col7 += Convert.ToDouble(dtg_CalMonth.Rows[z].Cells[7].Value.ToString());

            //        //            S_Col8 += Convert.ToDouble(dtg_CalMonth.Rows[z].Cells[8].Value.ToString());

            //        //            S_Col10 += Convert.ToDouble(dtg_CalMonth.Rows[z].Cells[10].Value.ToString());

            //        //            S_Col12 += Convert.ToDouble(dtg_CalMonth.Rows[z].Cells[12].Value.ToString());

            //        //            Count_Z = z;
            //        //        }

            //        //        S_Col5 = (S_Col2 / S_Col1) * 100;
            //        //        S_Col6 = S_Col6 / (Count_Z + 1);
            //        //        S_Col7 = S_Col7 / (Count_Z + 1);
            //        //        S_Col9 = (S_Col8 / Col1) * 100;
            //        //        S_Col11 = (S_Col10 / Col1) * 100;
            //        //        S_Col13 = (S_Col12 / Col1) * 100;

            //        //        dt2.Rows.Add("สะสม", S_Col1.ToString("##,###"), S_Col2.ToString("##,###"), S_Col3.ToString("f2"), S_Col4.ToString("f2"), S_Col5.ToString("f2"), S_Col6.ToString("f2"), S_Col7.ToString("f2"), S_Col8.ToString("##,###"), S_Col9.ToString("f2"), S_Col10.ToString("##,###"), S_Col11.ToString("f2"), S_Col12.ToString("##,###"), S_Col13.ToString("f2"));
            //        //        dtg_CalMonth.DataSource = dt2;

            //        //    }

            //        //}


            //        //// Create Report
            //        //DataTable dt1 = new DataTable();

            //        //dt1.Columns.AddRange(new DataColumn[14] { new DataColumn("Date"), new DataColumn("W_Net"), new DataColumn("W_StarchIN"), new DataColumn("Max_StarchIN"), new DataColumn("Min_StarchIN"), new DataColumn("AVG_StarchPur"), new DataColumn("AVG_PricePur"), new DataColumn("AVG_PriceStarch"), new DataColumn("W_Starch28"), new DataColumn("AVG_Starch28"), new DataColumn("W_Starch23"), new DataColumn("AVG_Starch23"), new DataColumn("W_Visual"), new DataColumn("AVG_Visual") });

            //        //foreach (DataGridViewRow dgv in dtg_CalMonth.Rows)
            //        //{
            //        //    dt1.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value, dgv.Cells[6].Value, dgv.Cells[7].Value, dgv.Cells[8].Value, dgv.Cells[9].Value, dgv.Cells[10].Value, dgv.Cells[11].Value, dgv.Cells[12].Value, dgv.Cells[13].Value);
            //        //}

            //        //ds1.Tables.Add(dt1);



            //        //ds1.WriteXmlSchema("dataCost.xml");

            //        //Crp_CostSP cr = new Crp_CostSP();
            //        //cr.SetDataSource(ds1);
            //        //cr.SetParameterValue("Report_Name", cb_typeReport.Text);
            //        //cr.SetParameterValue("Product_Name", cb_productReport.SelectedValue.ToString() + "-" + cb_productReport.Text);
            //        //cr.SetParameterValue("St_date", dtp_stReport.Value.ToShortDateString());
            //        //cr.SetParameterValue("Ed_date", dtp_edReport.Value.ToShortDateString());
            //        //crystalReportViewer1.ReportSource = cr;
            //        //crystalReportViewer1.Refresh();

            //        //dtg_CalMonth.Columns[0].HeaderText = "วันที่";
            //        //dtg_CalMonth.Columns[1].HeaderText = "นน.รับเข้า (กก.)";
            //        //dtg_CalMonth.Columns[2].HeaderText = "นน.แป้งรับเข้า";
            //        //dtg_CalMonth.Columns[3].HeaderText = "%แป้งสูงสุดที่รับ";
            //        //dtg_CalMonth.Columns[4].HeaderText = "%แป้งต่ำสุดที่รับ";
            //        //dtg_CalMonth.Columns[5].HeaderText = "%แป้งที่ซื้อเฉลี่ย";
            //        //dtg_CalMonth.Columns[6].HeaderText = "ราคาซื้อเฉลี่ย";
            //        //dtg_CalMonth.Columns[7].HeaderText = "ราคาแป้งเฉลี่ย";
            //        //dtg_CalMonth.Columns[8].HeaderText = "นน.แป้ง >28%";
            //        //dtg_CalMonth.Columns[9].HeaderText = "% นน.แป้ง >28% ";
            //        //dtg_CalMonth.Columns[10].HeaderText = "นน.แป้ง <23%";
            //        //dtg_CalMonth.Columns[11].HeaderText = "% นน.แป้ง <23%";
            //        //dtg_CalMonth.Columns[12].HeaderText = "นน.สิ่งเจือปน";
            //        //dtg_CalMonth.Columns[13].HeaderText = "% สิ่งเจือปน";

            //        //dtg_CalMonth.Columns[0].Width = 80;


            //    }

            //    if (id_print == 48) //LO Service Report
            //    {
            //        con.Open();
            //        string sql1 = "Select * From [V_RpLO] Where [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "' AND WeightPrice <> 0 OR LoadPrice <> 0 Order by [TicketCodeIn]";
            //        DataSet ds = new DataSet();
            //        crp_Lo crp_Lo = new crp_Lo();
            //        SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //        adapter.Fill(ds, "crt_LO");
            //        crp_Lo.SetDataSource(ds.Tables["crt_LO"]);
            //        crp_Lo.SetParameterValue("st_date", ST_Date.ToString());
            //        crp_Lo.SetParameterValue("ed_date", ED_Date.ToString());
            //        crystalReportViewer1.ReportSource = crp_Lo;
            //        crystalReportViewer1.Refresh();
            //        con.Close();
            //    }

            //    if (id_print == 49) //Fincense Pending Payment
            //    {
            //        con.Open();

            //        string sql1 = "Select * From [V_PendingFinance] Where [SaveDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999'  AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "'  Order by [SaveDate]";


            //        //string sql1 = "Select * From [V_RpSP] Where [PayDate] Between '" + ST_Date + "'  AND  '" + ED_Date + "'";
            //        DataSet ds = new DataSet();
            //        crp_pendingFinance crp_SP = new crp_pendingFinance();
            //        SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //        adapter.Fill(ds, "crt_pendingFN");
            //        crp_SP.SetDataSource(ds.Tables["crt_pendingFN"]);
            //        //crp_SP.SetParameterValue("st_date", ST_Date.ToString());
            //        //crp_SP.SetParameterValue("ed_date", ED_Date.ToString());
            //        crystalReportViewer1.ReportSource = crp_SP;
            //        crystalReportViewer1.Refresh();
            //        con.Close();
            //    }

            //    if (id_print == 51) //QA Report Personal type
            //    {
            //        con.Open();
            //        string sql1 = "Select * From [V_RPLab1] Where [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999'";
            //        DataSet ds = new DataSet();
            //        crp_LabReport crp_Lab = new crp_LabReport();
            //        SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //        adapter.Fill(ds, "crt_qa");
            //        crp_Lab.SetDataSource(ds.Tables["crt_qa"]);
            //        crp_Lab.SetParameterValue("st_date", ST_Date.ToString());
            //        crp_Lab.SetParameterValue("ed_date", ED_Date.ToString());
            //        crystalReportViewer1.ReportSource = crp_Lab;
            //        crystalReportViewer1.Refresh();
            //        con.Close();
            //    }

            //    if (id_print == 52) //QA Report All Lab RM-004, RM-001
            //    {
            //        if (cb_productReport.SelectedValue.ToString() == "RM-004")
            //        {
            //            con.Open();
            //            string sql1 = "Select * From [V_RPQA_RM004] Where [CreateDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' Order by [TicketCodeIn]";
            //            DataSet ds = new DataSet();
            //            crp_LabRM004 crp_Lab = new crp_LabRM004();
            //            SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //            adapter.Fill(ds, "crt_qaRM004");
            //            crp_Lab.SetDataSource(ds.Tables["crt_qaRM004"]);
            //            crp_Lab.SetParameterValue("st_date", ST_Date.ToString());
            //            crp_Lab.SetParameterValue("ed_date", ED_Date.ToString());
            //            crystalReportViewer1.ReportSource = crp_Lab;
            //            crystalReportViewer1.Refresh();
            //            con.Close();
            //        }
            //        if (cb_productReport.SelectedValue.ToString() == "RM-001")
            //        {
            //            con.Open();
            //            string sql1 = "Select * From [V_RPQA_RM001] Where [CreateDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' Order by [TicketCodeIn]";
            //            DataSet ds = new DataSet();
            //            crp_LabRM001 crp_Lab = new crp_LabRM001();
            //            SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //            adapter.Fill(ds, "crt_qaRM001");
            //            crp_Lab.SetDataSource(ds.Tables["crt_qaRM001"]);
            //            crp_Lab.SetParameterValue("st_date", ST_Date.ToString());
            //            crp_Lab.SetParameterValue("ed_date", ED_Date.ToString());
            //            crystalReportViewer1.ReportSource = crp_Lab;
            //            crystalReportViewer1.Refresh();
            //            con.Close();
            //        }
            //    }

            //    if (id_print == 53) //รายงานการรับสินค้า(จำแนกตามลูกค้า)
            //    {
            //        if (cb_productReport.SelectedValue.ToString() == "RM-004")
            //        {
            //            con.Open();
            //            string sql1 = "Select * From [V_CostSP_RM004] Where [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' Order by [TicketCodeIn]";
            //            DataSet ds = new DataSet();
            //            crp_recivedProRM004_byVendor crp_sp = new crp_recivedProRM004_byVendor();
            //            SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //            adapter.Fill(ds, "crt_SPRM004");
            //            crp_sp.SetDataSource(ds.Tables["crt_SPRM004"]);
            //            crp_sp.SetParameterValue("st_date", ST_Date.ToString());
            //            crp_sp.SetParameterValue("ed_date", ED_Date.ToString());
            //            crystalReportViewer1.ReportSource = crp_sp;
            //            crystalReportViewer1.Refresh();
            //            con.Close();
            //        }

            //        else if (cb_productReport.SelectedValue.ToString() == "RM-001")
            //        {
            //            con.Open();
            //            string sql1 = "Select * From [V_CostSP_RM001] Where [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' Order by [TicketCodeIn]";
            //            DataSet ds = new DataSet();
            //            crp_recivedProRM001_byVendor crp_sp = new crp_recivedProRM001_byVendor();
            //            SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //            adapter.Fill(ds, "crt_SPRM001");
            //            crp_sp.SetDataSource(ds.Tables["crt_SPRM001"]);
            //            crp_sp.SetParameterValue("st_date", ST_Date.ToString());
            //            crp_sp.SetParameterValue("ed_date", ED_Date.ToString());
            //            crystalReportViewer1.ReportSource = crp_sp;
            //            crystalReportViewer1.Refresh();
            //            con.Close();
            //        }

            //        else
            //        {
            //            MessageBox.Show("ไม่มีรูปแบบรายงานในส่ินค้าตัวนี้", "รายงานความผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }

            //    }

            //    if (id_print == 55) //รายงานต้นทุนสินค้า (จำแนกตามสินค้า) -[LO]         
            //    {
            //        crp_costRM_byProduct_LO crt_payment = new crp_costRM_byProduct_LO();
            //        // string sql1 = "SELECT *  FROM  [dbo].[V_Ticket_Register] WHERE [RegisterInDate] Between '"+ST_Date+" 00:00.00'  AND  '"+ED_Date+ " 23:59:59.999' AND ProductID ='" + cb_productReport.SelectedValue.ToString() + "'";

            //        string sql1 = "SELECT  *  FROM  [dbo].[V_RpCostRM_byProduct-LO] WHERE [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "' ";

            //        DataSet ds = new DataSet();
            //        con.Open();
            //        SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //        adapter.Fill(ds, "cost_product");
            //        crt_payment.SetDataSource(ds.Tables["cost_product"]);
            //        crystalReportViewer1.ReportSource = crt_payment;
            //        crystalReportViewer1.Refresh();
            //        con.Close();

            //    }

            //    if (id_print == 56) //รายงานต้นทุนสินค้า (จำแนกตามสินค้า) -[LO]         
            //    {

            //        // string sql1 = "SELECT *  FROM  [dbo].[V_Ticket_Register] WHERE [RegisterInDate] Between '"+ST_Date+" 00:00.00'  AND  '"+ED_Date+ " 23:59:59.999' AND ProductID ='" + cb_productReport.SelectedValue.ToString() + "'";

            //        string sql1 = "";

            //        if (rdo_purchase.Checked == true)
            //        {
            //            con.Open();
            //            crp_register_SF crt_payment = new crp_register_SF();
            //            sql1 = "SELECT  *  FROM  [dbo].[V_Ticket_Register] WHERE [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "' ";
            //            DataSet ds = new DataSet();
            //            SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //            adapter.Fill(ds, "regiter");
            //            crt_payment.SetDataSource(ds.Tables["regiter"]);
            //            crystalReportViewer1.ReportSource = crt_payment;
            //            con.Close();
            //        }

            //        if (rdo_sale.Checked == true)
            //        {
            //            con.Open();
            //            crp_register_SF_Sale crt_sale = new crp_register_SF_Sale();
            //            sql1 = "SELECT  *  FROM  [dbo].[V_Ticket_Register_Sale] WHERE [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' AND [ProductID] = '" + cb_productReport.SelectedValue.ToString() + "' ";
            //            DataSet ds = new DataSet();
            //            SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //            adapter.Fill(ds, "regiter_sale");
            //            crt_sale.SetDataSource(ds.Tables["regiter_sale"]);
            //            crystalReportViewer1.ReportSource = crt_sale;
            //            con.Close();
            //        }


            //        if (sql1 != "")
            //        {
            //            crystalReportViewer1.Refresh();
            //        }

            //    }

            //    if (id_print == 57)
            //    {
            //        tabControl1.SelectedIndex = 2;
            //        Load_DataPurchase();
            //    }

            //    if (id_print == 58)
            //    {
            //        con.Open();
            //        string sql1 = "Select * From [V_ReportEthanol_Audit] Where [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' Order by [TicketCodeIn]";
            //        DataSet ds = new DataSet();
            //        crp_ethanal_audit crp_eth = new crp_ethanal_audit();
            //        SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //        adapter.Fill(ds, "crt_eth");
            //        crp_eth.SetDataSource(ds.Tables["crt_eth"]);
            //        crp_eth.SetParameterValue("st_date", ST_Date.ToString());
            //        crp_eth.SetParameterValue("ed_date", ED_Date.ToString());
            //        crystalReportViewer1.ReportSource = crp_eth;
            //        crystalReportViewer1.Refresh();
            //        con.Close();
            //    }

            //    if (id_print == 59)
            //    {
            //        con.Open();
            //        string sql1 = "Select * From [V_WoodChip] Where [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999' Order by [TicketCodeIn]";
            //        DataSet ds = new DataSet();
            //        crp_WoodChip_QA crp_eth = new crp_WoodChip_QA();
            //        SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            //        adapter.Fill(ds, "crp_woodchip");
            //        crp_eth.SetDataSource(ds.Tables["crp_woodchip"]);
            //        crp_eth.SetParameterValue("User_Crate", Program.user_name);
            //        //crp_eth.SetParameterValue("ed_date", ED_Date.ToString());
            //        crystalReportViewer1.ReportSource = crp_eth;
            //        crystalReportViewer1.Refresh();
            //        con.Close();
            //    }

            //}

            //catch (Exception ex)

            //{

            //    MessageBox.Show(ex.ToString());
            //}

        }

        private void txt_ticketCode_Img_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Load_Image();
            }
        }

        private void Load_Image()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            label6.Visible = true;   
            string str = "";
            pictureBox1.Image = null;

            string sql1 = "SELECT [SimpleCode],[Path_Image1],[Path_Image2],[Path_Image3],[Path_Image3],[Path_Image4]  FROM [dbo].[V_Visual_Image]  Where [TicketCodeIn] ='" + txt_ticketCode_Img.Text.Trim() + "'";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            while (DR1.Read())
            {
                str = DR1["SimpleCode"].ToString().Trim();

                if (str.Contains("-1-1"))
                    {
                    try
                    {
                        Path_Image1_1 = DR1["Path_Image1"].ToString().Trim();

                        if (Path_Image1_1 != "")
                        {
                            btn_Image1_1.Enabled = true;
                        }
                    }
                    catch { btn_Image1_1.Enabled = false; }

                    try
                    {
                        Path_Image1_2 = DR1["Path_Image2"].ToString().Trim();

                        if (Path_Image1_2 != "")
                        {
                            btn_Image1_2.Enabled = true;
                        }
                    }
                    catch { btn_Image1_2.Enabled = false; }

                    try
                    {
                        Path_Image1_3 = DR1["Path_Image3"].ToString().Trim();

                        if (Path_Image1_3 != "")
                        {
                            btn_Image1_3.Enabled = true;
                        }
                    }
                    catch { btn_Image1_3.Enabled = false; }

                    try
                    {
                        Path_Image1_4 = DR1["Path_Image4"].ToString().Trim();

                        if (Path_Image1_4 != "")
                        {
                            btn_Image1_4.Enabled = true;
                        }
                    }
                    catch { btn_Image1_4.Enabled = false; }
                }

                if (str.Contains("-1-2"))
                {
                    try
                    {
                        Path_Image2_1 = DR1["Path_Image1"].ToString().Trim();

                        if (Path_Image2_1 != "")
                        {
                            btn_Image2_1.Enabled = true;
                        }
                    }
                    catch { btn_Image2_1.Enabled = false; }

                    try
                    {
                        Path_Image2_2 = DR1["Path_Image2"].ToString().Trim();

                        if (Path_Image2_2 != "")
                        {
                            btn_Image2_2.Enabled = true;
                        }
                    }
                    catch { btn_Image2_2.Enabled = false; }

                    try
                    {
                        Path_Image2_3 = DR1["Path_Image3"].ToString().Trim();

                        if (Path_Image2_3 != "")
                        {
                            btn_Image2_3.Enabled = true;
                        }
                    }
                    catch { btn_Image2_3.Enabled = false; }

                    try
                    {
                        Path_Image2_4 = DR1["Path_Image4"].ToString().Trim();

                        if (Path_Image2_4 != "")
                        {
                            btn_Image2_4.Enabled = true;
                        }
                    }
                    catch { btn_Image2_4.Enabled = false; }
                }
                
                if (str.Contains("-2-1"))
                {
                    try
                    {
                        Path_Image3_1 = DR1["Path_Image1"].ToString().Trim();

                        if (Path_Image3_1 != "")
                        {
                            btn_Image3_1.Enabled = true;
                        }
                    }
                    catch { btn_Image3_1.Enabled = false; }

                    try
                    {
                        Path_Image3_2 = DR1["Path_Image2"].ToString().Trim();

                        if (Path_Image3_2 != "")
                        {
                            btn_Image3_2.Enabled = true;
                        }
                    }
                    catch { btn_Image3_2.Enabled = false; }

                    try
                    {
                        Path_Image3_3 = DR1["Path_Image3"].ToString().Trim();

                        if (Path_Image3_3 != "")
                        {
                            btn_Image3_3.Enabled = true;
                        }
                    }
                    catch { btn_Image3_3.Enabled = false; }

                    try
                    {
                        Path_Image3_4 = DR1["Path_Image4"].ToString().Trim();

                        if (Path_Image3_4 != "")
                        {
                            btn_Image3_4.Enabled = true;
                        }
                    }
                    catch { btn_Image3_4.Enabled = false; }
                }

                if (str.Contains("-2-2"))
                {
                    try
                    {
                        Path_Image4_1 = DR1["Path_Image1"].ToString().Trim();

                        if (Path_Image4_1 != "")
                        {
                            btn_Image4_1.Enabled = true;
                        }
                    }
                    catch { btn_Image4_1.Enabled = false; }

                    try
                    {
                        Path_Image4_2 = DR1["Path_Image2"].ToString().Trim();

                        if (Path_Image4_2 != "")
                        {
                            btn_Image4_2.Enabled = true;
                        }
                    }
                    catch { btn_Image4_2.Enabled = false; }

                    try
                    {
                        Path_Image4_3 = DR1["Path_Image3"].ToString().Trim();

                        if (Path_Image4_3 != "")
                        {
                            btn_Image4_3.Enabled = true;
                        }
                    }
                    catch { btn_Image4_3.Enabled = false; }

                    try
                    {
                        Path_Image4_4 = DR1["Path_Image4"].ToString().Trim();

                        if (Path_Image4_4 != "")
                        {
                            btn_Image4_4.Enabled = true;
                        }
                    }
                    catch { btn_Image4_4.Enabled = false; }
                }
                                                                                                                                        
            }
            DR1.Close();
            con.Close();
        }
     
             
        private void dtg_histruck_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txt_ticketCode_Img.Text = dtg_histruck.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            Load_Image();
        }

  

        private void dtp_stReport_ValueChanged(object sender, EventArgs e)
        {
            Load_Vendor_Customer();

            Select_Product();
        }

        private void btn_searchProduct_Click(object sender, EventArgs e)
        {
            
            F_SelectData FSD = new F_SelectData();           
            FSD.ShowDialog();

            lbl_selectProduct.Text = FSD.Select_Product;

            if (FSD.Sort_Product != "")
            {
                ProductID = FSD.ID_Product;
                Sort_Product = FSD.Sort_Product;
            }
            else { lbl_selectProduct.Text = "-- เลือกทั้งหมด --"; }

        }

        private void rdo_purchase_CheckedChanged(object sender, EventArgs e)
        {
            Load_Vendor_Customer();  
        }

        private void rdo_sale_CheckedChanged(object sender, EventArgs e)
        {
            Load_Vendor_Customer();
        }

        private void Load_Vendor_Customer()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();           

            string ST_Date = dtp_stReport.Value.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));
            string ED_Date = dtp_edReport.Value.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"));

            SqlCommand cmd1 = new SqlCommand();
            SqlCommand cmd2 = new SqlCommand();

            cb_vendor.DataSource = null;
            cb_customer.DataSource = null;
            dtg_dataBFprint.DataSource = null;

            //string sql_Vendor = "SELECT  DISTINCT [Vendor_No],[NameVen] FROM  [dbo].[V_WeightData] WHERE [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999'";
            //string sql_Customer = "SELECT  DISTINCT [HeaderBill_NameCode],[Names] FROM  [dbo].[V_WeightData] WHERE [WeightDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999'";

            if (rdo_purchase.Checked == true)
            {            
                //Select Vendor
                cmd1 = new SqlCommand("SELECT  DISTINCT [Vendor_No],[Names] FROM  [dbo].[V_Ticket_Register] WHERE [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999'", con);     
              
                //Select Customer
                cmd2 = new SqlCommand("SELECT DISTINCT [HeaderBill_NameCode],[NameCus] FROM  [dbo].[V_Ticket_Register] WHERE [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999'", con);

                con.Open();
                DataSet ds1 = new DataSet();
                //ds.Clear();
                SqlDataAdapter da1 = new SqlDataAdapter();
                da1.SelectCommand = cmd1;
                da1.Fill(ds1);
                //Load product tab weight scale Setup
                cb_customer.DataSource = ds1.Tables[0];
                cb_customer.DisplayMember = "Names";
                cb_customer.ValueMember = "Vendor_No";
                con.Close();

                con.Open();
                DataSet ds2 = new DataSet();
                //ds.Clear();
                SqlDataAdapter da2 = new SqlDataAdapter();
                da2.SelectCommand = cmd2;
                da2.Fill(ds2);
                //Load product tab weight scale Setup
                cb_vendor.DataSource = ds2.Tables[0];
                cb_vendor.DisplayMember = "NameCus";
                cb_vendor.ValueMember = "HeaderBill_NameCode";
                con.Close();
            }

            if (rdo_sale.Checked == true)
            {
                //Select Vendor
                cmd1 = new SqlCommand("SELECT  DISTINCT [CustomerID],[CustomerName] FROM  [dbo].[V_Ticket_Register_Sale] WHERE [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999'", con);

                //Select Customer
                cmd2 = new SqlCommand("SELECT DISTINCT [HeaderBill_NameCodeCus],[Names] FROM  [dbo].[V_Ticket_Register_Sale] WHERE [RegisterInDate] Between '" + ST_Date + " 00:00.00'  AND  '" + ED_Date + " 23:59:59.999'", con);

                con.Open();
                DataSet ds1 = new DataSet();
                //ds.Clear();
                SqlDataAdapter da1 = new SqlDataAdapter();
                da1.SelectCommand = cmd1;
                da1.Fill(ds1);
                //Load product tab weight scale Setup
                cb_vendor.DataSource = ds1.Tables[0];
                cb_vendor.DisplayMember = "CustomerName";
                cb_vendor.ValueMember = "CustomerID";
                con.Close();

                con.Open();
                DataSet ds2 = new DataSet();
                //ds.Clear();
                SqlDataAdapter da2 = new SqlDataAdapter();
                da2.SelectCommand = cmd2;
                da2.Fill(ds2);
                //Load product tab weight scale Setup
                cb_customer.DataSource = ds2.Tables[0];
                cb_customer.DisplayMember = "Names";
                cb_customer.ValueMember = "HeaderBill_NameCodeCus";
                con.Close();
            }
                    
            btn_getData.Enabled = true;
            cb_vendor.Text = "-- เลือกทั้งหมด --";
            cb_customer.Text = "-- เลือกทั้งหมด --";
            lbl_selectProduct.Text = "-- เลือกทั้งหมด --";

        }

        private void cb_vendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ID_Vendor = cb_vendor.SelectedValue.ToString().Trim();
            }
            catch { }
        }

        private void cb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ID_Customer = cb_customer.SelectedValue.ToString().Trim();
            }
            catch { }
        }

        private void chk_hideTool_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_hideTool.Checked == true)
            {
                panel1.Visible = false;
            }

            if (chk_hideTool.Checked == false)
            {
                panel1.Visible = true;
            }
        }

        private void btn_expExcel_Click(object sender, EventArgs e)
        {
            if (dtg_dataBFprint.RowCount != 0)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook ExcelBook;
                Microsoft.Office.Interop.Excel._Worksheet ExcelSheet;

                int i = 0;
                int j = 0;

                //create object of excel
                ExcelBook = (Microsoft.Office.Interop.Excel._Workbook)ExcelApp.Workbooks.Add(1);
                ExcelSheet = (Microsoft.Office.Interop.Excel._Worksheet)ExcelBook.ActiveSheet;

                // header
                for (i = 1; i <= this.dtg_dataBFprint.Columns.Count; i++)
                {
                    ExcelSheet.Cells[1, i] = this.dtg_dataBFprint.Columns[i - 1].HeaderText;
                }

                // data
                for (i = 1; i <= this.dtg_dataBFprint.RowCount; i++)
                {
                    for (j = 1; j <= dtg_dataBFprint.Columns.Count; j++)
                    {
                        ExcelSheet.Cells[i + 1, j] = dtg_dataBFprint.Rows[i - 1].Cells[j - 1].Value;
                    }
                }

                ExcelApp.Visible = true;
                ExcelSheet = null;
                ExcelBook = null;
                ExcelApp = null;
            }
        }

        private void dtg_dataBFprint_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex == 0)
            {
                //TODO - Button Clicked - Execute Code Here
                txt_ticketCode_Img.Text = dtg_dataBFprint.Rows[e.RowIndex].Cells[3].Value.ToString();

                tabControl1.SelectedIndex = 3;

                Load_Image();

            }
        }

        private void btn_Image1_1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(Path_Image1_1);
            }
            catch { MessageBox.Show("ภาพที่ถ่ายได้รับความเสียหาย/บันทึกไม่สมบูรณ์/หาแหล่งที่เก็บภาพไม่เจอ", "ไฟล์บันทึกมีปัญหา", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_Image1_2_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(Path_Image1_2);

            }
            catch { MessageBox.Show("ภาพที่ถ่ายได้รับความเสียหาย/บันทึกไม่สมบูรณ์/หาแหล่งที่เก็บภาพไม่เจอ", "ไฟล์บันทึกมีปัญหา", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_Image1_3_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(Path_Image1_3);
            }
            catch { MessageBox.Show("ภาพที่ถ่ายได้รับความเสียหาย/บันทึกไม่สมบูรณ์/หาแหล่งที่เก็บภาพไม่เจอ", "ไฟล์บันทึกมีปัญหา", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_Image1_4_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(Path_Image1_4);
            }
            catch { MessageBox.Show("ภาพที่ถ่ายได้รับความเสียหาย/บันทึกไม่สมบูรณ์/หาแหล่งที่เก็บภาพไม่เจอ", "ไฟล์บันทึกมีปัญหา", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_Image2_1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(Path_Image2_1);
            }
            catch { MessageBox.Show("ภาพที่ถ่ายได้รับความเสียหาย/บันทึกไม่สมบูรณ์/หาแหล่งที่เก็บภาพไม่เจอ", "ไฟล์บันทึกมีปัญหา", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_Image2_2_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(Path_Image2_2);
            }
            catch { MessageBox.Show("ภาพที่ถ่ายได้รับความเสียหาย/บันทึกไม่สมบูรณ์/หาแหล่งที่เก็บภาพไม่เจอ", "ไฟล์บันทึกมีปัญหา", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_Image2_3_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(Path_Image2_3);
            }
            catch { MessageBox.Show("ภาพที่ถ่ายได้รับความเสียหาย/บันทึกไม่สมบูรณ์/หาแหล่งที่เก็บภาพไม่เจอ", "ไฟล์บันทึกมีปัญหา", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_Image2_4_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(Path_Image2_4);
            }
            catch { MessageBox.Show("ภาพที่ถ่ายได้รับความเสียหาย/บันทึกไม่สมบูรณ์/หาแหล่งที่เก็บภาพไม่เจอ", "ไฟล์บันทึกมีปัญหา", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_Image3_1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(Path_Image3_1);
            }
            catch { MessageBox.Show("ภาพที่ถ่ายได้รับความเสียหาย/บันทึกไม่สมบูรณ์/หาแหล่งที่เก็บภาพไม่เจอ", "ไฟล์บันทึกมีปัญหา", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_Image3_2_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(Path_Image3_2);
            }
            catch { MessageBox.Show("ภาพที่ถ่ายได้รับความเสียหาย/บันทึกไม่สมบูรณ์/หาแหล่งที่เก็บภาพไม่เจอ", "ไฟล์บันทึกมีปัญหา", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_Image3_3_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(Path_Image3_3);
            }
            catch { MessageBox.Show("ภาพที่ถ่ายได้รับความเสียหาย/บันทึกไม่สมบูรณ์/หาแหล่งที่เก็บภาพไม่เจอ", "ไฟล์บันทึกมีปัญหา", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_Image3_4_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(Path_Image3_3);
            }
            catch { MessageBox.Show("ภาพที่ถ่ายได้รับความเสียหาย/บันทึกไม่สมบูรณ์/หาแหล่งที่เก็บภาพไม่เจอ", "ไฟล์บันทึกมีปัญหา", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_Image4_1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(Path_Image4_1);
            }
            catch { MessageBox.Show("ภาพที่ถ่ายได้รับความเสียหาย/บันทึกไม่สมบูรณ์/หาแหล่งที่เก็บภาพไม่เจอ", "ไฟล์บันทึกมีปัญหา", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_Image4_2_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(Path_Image4_2);
            }
            catch { MessageBox.Show("ภาพที่ถ่ายได้รับความเสียหาย/บันทึกไม่สมบูรณ์/หาแหล่งที่เก็บภาพไม่เจอ", "ไฟล์บันทึกมีปัญหา", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_Image4_3_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(Path_Image4_3);
            }
            catch { MessageBox.Show("ภาพที่ถ่ายได้รับความเสียหาย/บันทึกไม่สมบูรณ์/หาแหล่งที่เก็บภาพไม่เจอ", "ไฟล์บันทึกมีปัญหา", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_Image4_4_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(Path_Image4_4);
            }
            catch { MessageBox.Show("ภาพที่ถ่ายได้รับความเสียหาย/บันทึกไม่สมบูรณ์/หาแหล่งที่เก็บภาพไม่เจอ", "ไฟล์บันทึกมีปัญหา", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
