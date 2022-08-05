using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;

namespace Truck_Analytics
{
    public partial class F_ReportCRT : Form
    {
        public F_ReportCRT()
        {
            InitializeComponent();
        }


        ReportDocument _rpt = new ReportDocument();
        public int PrintformID;
        public string id_product;
        public string id_ticket;
        public int id_typeJob;
        //int id_printPrivew = 0;
        public int id_menu = 0;
        public int PrintEthFormat = 0;

        private void F_ReportCRT_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            //Load_SettingPrinter();
          
            string sql1 = "";

            // id print 1-5 เป็นตัวรายงานที่หน้าเครื่องชั่ง

            if (PrintformID == 1 || PrintformID == 3)
            {
                if (PrintformID == 1)
                {
                    if (id_typeJob == 1)  
                    {
                        sql1 = "Select * From   [dbo].[V_WeightData] Where [TicketCodeIn] ='" + id_ticket + "'";
                        DataSet ds = new DataSet();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);

                        if (PrintEthFormat == 0)
                        {
                            crp_TKCasawaChip crt_crp_TKCasawaChip = new crp_TKCasawaChip();                            
                            adapter.Fill(ds, "TKCasawaChip");
                            crt_crp_TKCasawaChip.SetDataSource(ds.Tables["TKCasawaChip"]);
                            crystalReportViewer1.ReportSource = crt_crp_TKCasawaChip;
                        }

                        if (PrintEthFormat == 1)
                        {
                            crp_TKCasawaChip_noForm crt_crp_TKCasawaChip = new crp_TKCasawaChip_noForm();
                            adapter.Fill(ds, "TKCasawaChip_noForm");
                            crt_crp_TKCasawaChip.SetDataSource(ds.Tables["TKCasawaChip_noForm"]);
                            crystalReportViewer1.ReportSource = crt_crp_TKCasawaChip;
                        }

                        crystalReportViewer1.Refresh();
                    }

                    if (id_typeJob == 2)  
                    {
                        sql1 = "Select * From   [dbo].[V_WeightData_Sale] Where [TicketCodeIn] ='" + id_ticket + "'";

                        DataSet ds = new DataSet();
                        crp_TKSaleProduct TKSaleProduct = new crp_TKSaleProduct();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
                        adapter.Fill(ds, "TicketSale");
                        TKSaleProduct.SetDataSource(ds.Tables["TicketSale"]);
                        crystalReportViewer1.ReportSource = TKSaleProduct;
                        crystalReportViewer1.Refresh();

                    }
                }

                if (PrintformID == 3)
                {
                    if (id_typeJob == 1)  // ซื้ออื่น ๆ สินค้าอื่น ๆ Viewer
                    {
                        sql1 = "Select * From   [dbo].[V_PrintTicket] Where [TicketCodeIn] ='" + id_ticket + "'";
                        DataSet ds = new DataSet();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);

                        if (PrintEthFormat == 0)
                        {
                            crp_TKOrtherProduct crt_crp_TKCasawaChip = new crp_TKOrtherProduct();
                            adapter.Fill(ds, "TK_etcProduct");
                            crt_crp_TKCasawaChip.SetDataSource(ds.Tables["TK_etcProduct"]);
                            crystalReportViewer1.ReportSource = crt_crp_TKCasawaChip;
                        }
                        if (PrintEthFormat == 1)
                        {
                            crp_TKOrtherProduct_noForm crt_crp_TKCasawaChip = new crp_TKOrtherProduct_noForm();
                            adapter.Fill(ds, "TK_etcProduct_noForm");
                            crt_crp_TKCasawaChip.SetDataSource(ds.Tables["TK_etcProduct_noForm"]);
                            crystalReportViewer1.ReportSource = crt_crp_TKCasawaChip;
                        }

                        crystalReportViewer1.Refresh();
                    }

                    if (id_typeJob == 2)   //ขายอื่น ๆ สินค้าอื่น ๆ Viewer
                    {
                        sql1 = "Select * From   [dbo].[V_WeightData_Sale] Where [TicketCodeIn] ='" + id_ticket + "'";

                        DataSet ds = new DataSet();
                        crp_TKSaleProduct TKSaleProduct = new crp_TKSaleProduct();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
                        adapter.Fill(ds, "TicketSale");
                        TKSaleProduct.SetDataSource(ds.Tables["TicketSale"]);
                        crystalReportViewer1.ReportSource = TKSaleProduct;
                        crystalReportViewer1.Refresh();

                    }
                }


            }
            //
                    

            if (PrintformID == 2) //ซื้อ มันสด
            {
                sql1 = "Select * From   [dbo].[V_PrintTicket] Where [TicketCodeIn] ='" + id_ticket + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);

                if (PrintEthFormat == 0)
                {
                    crp_TKCasawaRoot crt_TKCasawaRoot = new crp_TKCasawaRoot();
                    adapter.Fill(ds, "crt_TKCasawaRoot");
                    crt_TKCasawaRoot.SetDataSource(ds.Tables["crt_TKCasawaRoot"]);
                    crystalReportViewer1.ReportSource = crt_TKCasawaRoot;
                }

                if (PrintEthFormat == 1)
                {
                    crp_TKCasawaRoot_noForm crt_TKCasawaRoot = new crp_TKCasawaRoot_noForm();
                    adapter.Fill(ds, "crt_TKCasawaRoot_noForm");
                    crt_TKCasawaRoot.SetDataSource(ds.Tables["crt_TKCasawaRoot_noForm"]);
                    crystalReportViewer1.ReportSource = crt_TKCasawaRoot;

                }

                
                crystalReportViewer1.Refresh();
            }

            //if (PrintformID == 4)
            //{

            //    sql1 = "Select * From   [dbo].[V_PrintAuto] Where [PrintAT_No] ='" + id_ticket + "'";
            //}

            
            //Ticket  Auto

            if (PrintformID == 6) //ticket barcode watcake
            {
                if (id_typeJob == 1) //purchase 
                {
                    sql1 = "Select * From   [dbo].[V_PrintAuto_Pur] Where [PrintAT_No] ='" + id_ticket + "'";
                    DataSet ds = new DataSet();
                    crp_TKbarCodeAuto_Pur TKbarCodeAuto = new crp_TKbarCodeAuto_Pur();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
                    adapter.Fill(ds, "TKbarCodeAuto");
                    TKbarCodeAuto.SetDataSource(ds.Tables["TKbarCodeAuto"]);
                    TKbarCodeAuto.SetParameterValue("UserName", Program.user_name);
                    crystalReportViewer1.ReportSource = TKbarCodeAuto;
                    crystalReportViewer1.Refresh();
                }
                if (id_typeJob == 2) // sale
                {
                    sql1 = "Select * From   [dbo].[V_PrintAuto_Sale] Where [PrintAT_No] ='" + id_ticket + "'";
                    DataSet ds = new DataSet();
                    crp_TKbarCodeAuto_Sale TKbarCodeAuto = new crp_TKbarCodeAuto_Sale();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
                    adapter.Fill(ds, "TKbarCodeAuto");
                    TKbarCodeAuto.SetDataSource(ds.Tables["TKbarCodeAuto"]);
                    TKbarCodeAuto.SetParameterValue("UserName", Program.user_name);
                    crystalReportViewer1.ReportSource = TKbarCodeAuto;
                    crystalReportViewer1.Refresh();
                }
            }



            con.Close();

        }

        //private void Load_SettingPrinter()
        //{
        //    try
        //    {
        //        SqlConnection con = new SqlConnection(Program.pahtdb);
        //        con.ConnectionString = Program.pahtdb;
        //        SqlDataAdapter dtAdapter = new SqlDataAdapter();
        //        //dtg_vendorStarch.DataSource = null;
        //        con.Open();

        //        string sql1 = "SELECT [PrintAuto] FROM  [dbo].[TB_WeightscaleSetting] WHERE [WeightProductID]= '" + id_product + "' AND [Id_meun]=" + id_menu + "";

        //        SqlCommand CM1 = new SqlCommand(sql1, con);
        //        SqlDataReader DR1 = CM1.ExecuteReader();

        //        DR1.Read();
        //        {
        //            if (DR1["PrintAuto"].ToString() == "False")
        //            {
        //                id_printPrivew = 1;
        //            }

        //        }
        //        DR1.Close();
        //        con.Close();
        //    }
        //    catch { MessageBox.Show("สินค้านี้ยังไม่ได้เซ็ตระบบเครื่องพิมพ์ กรุณาไปตั้งค่าที่หน้า 'ตั้งค่า'->'ตั้งค่าการชั่งสินค้า -> ตั้งค่างานบริการ'","การพิมพ์ผิดพลาด !!",MessageBoxButtons.OK,MessageBoxIcon.Error); }

        //}







    }
}
