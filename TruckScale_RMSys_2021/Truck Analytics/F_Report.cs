using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;



namespace Truck_Analytics
{
    public partial class F_Report : Form
    {
        public F_Report()
        {
            InitializeComponent();
        }

        public string Ticket_code = "";
        public int truckType = 0;           
        public string ID_Product = "";
        public int type_job = 0;
        int id_regisForm = 0;

        private void F_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ds_Purchase.V_Ticket_Register' table. You can move, or remove it, as needed.
         
            try
            {
                // TODO: This line of code loads data into the 'sapthipNewDBDataSet.V_PrintTicket' table. You can move, or remove it, as needed.
                //this.v_PrintTicketTableAdapter.Fill(this.sapthipNewDBDataSet.V_PrintTicket);
                // TODO: This line of code loads data into the 'DT_TicketViewer.V_PrintTicket' table. You can move, or remove it, as needed.
                //this.v_PrintTicketTableAdapter.Fill(this.DT_TicketViewer.V_PrintTicket);
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();  
                con.Open();

                string sql5 = "SELECT [id_regisForm] FROM  [dbo].[TB_WeightscaleSetting] Where  [WeightProductID]='" + ID_Product + "'";
                SqlCommand CM5 = new SqlCommand(sql5, con);
                SqlDataReader DR5 = CM5.ExecuteReader();
                DR5.Read();
                {
                    id_regisForm = Convert.ToInt16(DR5["id_regisForm"].ToString());
                }
                DR5.Close();
                con.Close();


                if (type_job != 5)   //Load form Register
                {
                    if (id_regisForm == 1) //งานซื้อแบบมีเก็บตัวอย่าง
                    {
                        Load_Ticket_Example();
                    }

                    if (id_regisForm == 2) //ซื้อกับ ขายทั่วไป ไม่มีเก็บตัวอย่าง
                    {
                        Load_Ticket_Personal();
                    }

                    if (id_regisForm == 3)  // ขาย Auto
                    {
                        //Load_Ticket_Viewer();
                    }
                }

                if (type_job == 5)  // Load Form Purchase Weight Casawa
                {
                    Load_Weight();
                }

                if (type_job == 6)  // Load Form Sale Weight
                {



                }
            }
            catch { MessageBox.Show("แบบฟอร์มลงทะเบียนผิดพลาด!!  กรุณาตรวจเช็คการตั้งค่ารูปแบบพิมพ์ลงทะเบียน"); }

        }

        private void Load_Weight()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();                   
            con.Open();

            string ProductName;
            string QueueNo;
            string Plate1;
            string Vendor_Name;
            DateTime InDate = new DateTime();
            DateTime InTime = new DateTime();
            DateTime OutDate = new DateTime();
            DateTime OutTime = new DateTime();
            decimal InboundWeight;
            decimal OutboundWeight;
            decimal GrossWeight;
            string ProvinceName;
            string LabValue1;
            string LabValue2;
            string LabValue3;
            string LabValue4;
            string LabVselect;
            decimal DiscutValue;
            string Price;
            string PriceExtra;
            string PriceNet;
            string UserName;
            string WarehouseID;
            decimal Discutweight = 0;
            decimal WeightNet = 0;
            decimal Price_E = 0;
            int PrintValueLab1 = 0;
            int PrintValueLab2 = 0;
            int PrintValueLab3 = 0;
            int PrintValueLab4 = 0;


            string sql1 = "Select  *  FROM  [dbo].[V_PrintTicket] Where [TicketCodeIn]='" + Ticket_code + "'";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                ProductName = DR1["ProductName"].ToString();
                QueueNo = DR1["QueueNo"].ToString();
                Plate1 = DR1["Plate1"].ToString();
                Vendor_Name = DR1["Vendor_Name"].ToString();
                InDate = Convert.ToDateTime(DR1["InDate"].ToString());
                InTime = Convert.ToDateTime(DR1["InTime"].ToString());
                OutDate = Convert.ToDateTime(DR1["OutDate"].ToString());
                OutTime = Convert.ToDateTime(DR1["OutTime"].ToString());
                InboundWeight = Convert.ToDecimal(DR1["InboundWeight"].ToString());
                OutboundWeight = Convert.ToDecimal(DR1["OutboundWeight"].ToString());
                GrossWeight = Convert.ToDecimal(DR1["GrossWeight"].ToString());
                ProvinceName = DR1["ProvinceName"].ToString();
                LabValue1 = DR1["LabValue1"].ToString();
                LabValue2 = DR1["LabValue2"].ToString();
                LabValue3 = DR1["LabValue3"].ToString();
                LabValue4 = DR1["LabValue4"].ToString();
                LabVselect = DR1["LabVselect"].ToString();
                DiscutValue = Convert.ToDecimal(DR1["DiscutValue"].ToString());
                Price = DR1["Price"].ToString();
                PriceExtra = DR1["PriceExtra"].ToString();
                PriceNet = DR1["PriceNet"].ToString();
                UserName = DR1["UserName"].ToString();
                WarehouseID = DR1["WarehouseID"].ToString();

                if (DR1["PrintValueLab1"].ToString() == "True")
                {
                    PrintValueLab1 = 1;
                }

                if (DR1["PrintValueLab2"].ToString() == "True")
                {
                    PrintValueLab2 = 1;
                }

                if (DR1["PrintValueLab3"].ToString() == "True")
                {
                    PrintValueLab3 = 1;
                }

                if (DR1["PrintValueLab4"].ToString() == "True")
                {
                    PrintValueLab4 = 1;
                }
        
            }
            DR1.Close();
            con.Close();
            
            DS_Weight dS_Weight = new DS_Weight();            
            DS_Weight.Weight_CasawaRow ds_Rows = dS_Weight.Weight_Casawa.NewWeight_CasawaRow();

            ds_Rows.QueueNo = QueueNo;
            ds_Rows.TicketCodeIn = Ticket_code;
            ds_Rows.Plate1 = Plate1;          
            ds_Rows.ProductName = ProductName;
            ds_Rows.Vendor_Name = Vendor_Name;
            ds_Rows.InDate = InDate;
            ds_Rows.InTime = InTime;
            ds_Rows.OutDate = OutDate;
            ds_Rows.OutTime = OutTime;
            ds_Rows.InboundWeight = InboundWeight;
            ds_Rows.OutboundWeight = OutboundWeight;
            ds_Rows.GrossWeight = GrossWeight;
            //ds_Rows.LabVselect = LabVselect;
            //ds_Rows.DiscutValue = DiscutValue;
            ds_Rows.ProvinceName = ProvinceName;

            if (PrintValueLab1 == 1)
            { ds_Rows.LabValue1 = LabValue1; }
            else { ds_Rows.LabValue1 = "-"; }

            if (PrintValueLab2 == 1)
            { ds_Rows.LabValue2 = LabValue2; }
            else { ds_Rows.LabValue2 = "-"; }

            if (PrintValueLab3 == 1)
            { ds_Rows.LabValue3 = LabValue3; }
            else { ds_Rows.LabValue3 = "-"; }
            
            if (PrintValueLab4 == 1)
            { ds_Rows.LabValue4 = LabValue4; }
            else { ds_Rows.LabValue4 = "-"; }
           
            ds_Rows.LabVselect = LabVselect;
            ds_Rows.DiscutValue = DiscutValue;
            ds_Rows.Price = Price;
            
            ds_Rows.PriceNet = PriceNet;
            ds_Rows.UserName = UserName;
            ds_Rows.WarehouseID = WarehouseID;

            //({ V_PrintTicket.GrossWeight}  *{ V_PrintTicket.DiscutValue})/ 100
            Discutweight = (GrossWeight * DiscutValue) / 100;
            ds_Rows.Discutweight = Discutweight.ToString("F");

            //{V_PrintTicket.GrossWeight}-{@DitcutWeight}
            WeightNet = GrossWeight - Discutweight;
            ds_Rows.WeightNet = WeightNet.ToString("F");

            //"เพิ่ม/ลด  " + totext({V_PrintTicket.PriceExtra}) + " สต.=   "+ totext({V_PrintTicket.Price}+{V_PrintTicket.PriceExtra}) + "  บาท/กก. " 
            Price_E =Convert.ToDecimal(Price) + Convert.ToDecimal(PriceExtra);
            ds_Rows.PriceExtra = "เพิ่ม/ลด  " + PriceExtra +" สต.=  "+ Price_E.ToString("F")+ " บาท/กก. ";

            dS_Weight.Weight_Casawa.AddWeight_CasawaRow(ds_Rows);
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DTS_Weight";
            reportDataSource.Value = dS_Weight.Weight_Casawa;

            //this.reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            reportViewer1.LocalReport.ReportEmbeddedResource = "Truck_Analytics.Rp_SaleTKnoSim.rdlc";
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportViewer1.RefreshReport();


        }              
            private void Load_Ticket_Viewer()
        {
            //SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            //con.ConnectionString = Program.pathdb_Weight;
            //con.Open();
            //DataTable dt = new DataTable();
            //dt = Getdata  Get Data("select * from tbl_Admission_Form");
            //con.Close();
            //ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
            //reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.ProcessingMode = ProcessingMode.Local;
            //reportViewer1.LocalReport.ReportEmbeddedResource = "RDLC.Report1.rdlc";
            //reportViewer1.LocalReport.DataSources.Add(datasource);
            ////this.reportViewer1.RefreshReport();
            //this.reportViewer1.RefreshReport();




            //-----------------------------------

            //reportViewer1.ProcessingMode = ProcessingMode.Local;
            ////reportViewer1.LocalReport.ReportEmbeddedResource = "Truck_Analytics.Report5.rdlc";

            //DataSet ds = new DataSet();
            //ds = GetData_TicketID(Ticket_code);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    ReportDataSource rds = new ReportDataSource("dsSalary", ds.Tables[0]);
            //    reportViewer1.LocalReport.DataSources.Clear();
            //    reportViewer1.LocalReport.DataSources.Add(rds);
            //    reportViewer1.LocalReport.Refresh();
            //    reportViewer1.RefreshReport();
            //}

            //ReportDataSource reportDataSource = new ReportDataSource();
            //reportDataSource.Name = "SapthipNewDBDataSet";           
            //reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.ReportEmbeddedResource = "Truck_Analytics.Report5.rdlc";
            //reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            //reportViewer1.RefreshReport();


        }


        //private DataSet GetData_TicketID(string id)
        //{        
        //    //            string conString =  ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //    //SqlConnection con = new SqlConnection(conString);
        //    //con.Open();
        //    //SqlCommand cmd = new SqlCommand(query);
        //    //cmd.Connection = con;
        //    //cmd.ExecuteNonQuery();
        //    //cmd.Dispose();
        //    //SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    //DataTable ds = new DataTable();
        //    //sda.Fill(ds);
        //    //return ds;
        //}

        private void Load_Ticket_Example()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                string ProductName = "";
                string ProductID = "";
                int QueueNo = 0;
                string SimCode1_1 = "";
                string SimCode1_2 = "";
                string SimCode2_1 = "";
                string SimCode2_2 = "";
                int ID_Exam = 0;
                string TruckTypeName = "";

                string Rmk1 = "";
                string Rmk2 = "";
                string Rmk3 = "";
                string Rmk4 = "";
                string Rmk5 = "";
                               

                string sql1 = "Select * FROM  [dbo].[V_Ticket_Register] Where [TicketCodeIn]='" + Ticket_code + "'";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    ProductID = DR1["ProductID"].ToString().Trim();
                    ProductName = DR1["ProductName"].ToString().Trim();
                    QueueNo = Convert.ToInt16(DR1["QueueNo"].ToString());
                    SimCode1_1 = DR1["SimpleCode1"].ToString().Trim();
                    SimCode2_1 = DR1["SimpleCode2"].ToString().Trim() ;
                    TruckTypeName = DR1["TruckTypeName"].ToString().Trim();
                }
                DR1.Close();
                con.Close();


                con.Open();
                string sql2 = "Select * FROM  [dbo].[TB_RegisterSetup] Where [Reg_ProductID]='" + ProductID + "'";
                SqlCommand CM2 = new SqlCommand(sql2, con);
                SqlDataReader DR2 = CM2.ExecuteReader();

                DR2.Read();
                {
                    ID_Exam = Convert.ToInt16(DR2["Exam_ID"].ToString());

                    if (DR2["Reg_chkRmk1"].ToString() == "True")
                    {
                        Rmk1 = DR2["Reg_Rmk1"].ToString().Trim();
                    }

                    if (DR2["Reg_chkRmk2"].ToString() == "True")
                    {
                        Rmk2 = DR2["Reg_Rmk2"].ToString().Trim();
                    }

                    if (DR2["Reg_chkRmk3"].ToString() == "True")
                    {
                        Rmk3 = DR2["Reg_Rmk3"].ToString().Trim();
                    }


                    if (DR2["Reg_chkRmk4"].ToString() == "True")
                    {
                        Rmk4 = DR2["Reg_Rmk4"].ToString().Trim();
                    }

                    if (DR2["Reg_chkRmk5"].ToString() == "True")
                    {
                        Rmk5 = DR2["Reg_Rmk5"].ToString().Trim();
                    }

                }
                DR2.Close();
                con.Close();


                SimCode1_2 = SimCode1_1 + "-2";
                SimCode1_1 += "-1";

                SimCode2_2 = SimCode2_1 + "-2";
                SimCode2_1 += "-1";


                this.reportViewer1.RefreshReport();
                this.reportViewer1.LocalReport.EnableExternalImages = true;
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;

                QRCoder.QRCodeGenerator qRCodeGenerator = new QRCoder.QRCodeGenerator();
                QRCoder.QRCodeData qRCodeDataTicket = qRCodeGenerator.CreateQrCode(Ticket_code, QRCoder.QRCodeGenerator.ECCLevel.Q);
                QRCoder.QRCode qRCodeTicket = new QRCoder.QRCode(qRCodeDataTicket);
                Bitmap bmp = qRCodeTicket.GetGraphic(4);


                QRCoder.QRCodeData qRCodeDataSim1_1 = qRCodeGenerator.CreateQrCode(SimCode1_1, QRCoder.QRCodeGenerator.ECCLevel.Q);
                QRCoder.QRCode qRCodeSim1_1 = new QRCoder.QRCode(qRCodeDataSim1_1);
                Bitmap bmp1_1 = qRCodeSim1_1.GetGraphic(4);

                QRCoder.QRCodeData qRCodeDataSim1_2 = qRCodeGenerator.CreateQrCode(SimCode1_2, QRCoder.QRCodeGenerator.ECCLevel.Q);
                QRCoder.QRCode qRCodeSim1_2 = new QRCoder.QRCode(qRCodeDataSim1_2);
                Bitmap bmp1_2 = qRCodeSim1_2.GetGraphic(4);

                QRCoder.QRCodeData qRCodeDataSim2_1 = qRCodeGenerator.CreateQrCode(SimCode2_1, QRCoder.QRCodeGenerator.ECCLevel.Q);
                QRCoder.QRCode qRCodeSim2_1 = new QRCoder.QRCode(qRCodeDataSim2_1);
                Bitmap bmp2_1 = qRCodeSim2_1.GetGraphic(3);

                QRCoder.QRCodeData qRCodeDataSim2_2 = qRCodeGenerator.CreateQrCode(SimCode2_2, QRCoder.QRCodeGenerator.ECCLevel.Q);
                QRCoder.QRCode qRCodeSim2_2 = new QRCoder.QRCode(qRCodeDataSim2_2);
                Bitmap bmp2_2 = qRCodeSim2_2.GetGraphic(4);


                ReportData reportData = new ReportData();
                ReportData.QRCodeRow qRCodeRow = reportData.QRCode.NewQRCodeRow();

                using (MemoryStream ms = new MemoryStream())
                {
                    bmp.Save(ms, ImageFormat.Bmp);
                    qRCodeRow.ImageTicket = ms.ToArray();
                }

                using (MemoryStream ms1_1 = new MemoryStream())
                {
                    bmp1_1.Save(ms1_1, ImageFormat.Bmp);
                    qRCodeRow.ImageSim1_1 = ms1_1.ToArray();
                }

                using (MemoryStream ms1_2 = new MemoryStream())
                {
                    bmp1_2.Save(ms1_2, ImageFormat.Bmp);
                    qRCodeRow.ImageSim1_2 = ms1_2.ToArray();
                }

                using (MemoryStream ms2_1 = new MemoryStream())
                {
                    bmp2_1.Save(ms2_1, ImageFormat.Bmp);
                    qRCodeRow.ImageSim2_1 = ms2_1.ToArray();
                }

                using (MemoryStream ms2_2 = new MemoryStream())
                {
                    bmp2_2.Save(ms2_2, ImageFormat.Bmp);
                    qRCodeRow.ImageSim2_2 = ms2_2.ToArray();
                }

                qRCodeRow.ProductName = ProductName;
                qRCodeRow.TicketCodeIn = Ticket_code;
                qRCodeRow.SimCode1_1 = SimCode1_1;
                qRCodeRow.SimCode1_2 = SimCode1_2;
                qRCodeRow.SimCode2_1 = SimCode2_1;
                qRCodeRow.SimCode2_2 = SimCode2_2;
                qRCodeRow.QueueNo = QueueNo.ToString().Trim();
                qRCodeRow.Date = DateTime.Now.ToShortDateString();
                qRCodeRow.Time = DateTime.Now.ToShortTimeString();
                qRCodeRow.TruckTypeName = TruckTypeName.Trim();
                qRCodeRow.Rmk1 = Rmk1.Trim() ;
                qRCodeRow.Rmk2 = Rmk2.Trim();
                qRCodeRow.Rmk3 = Rmk3.Trim();
                qRCodeRow.Rmk4 = Rmk4.Trim();
                qRCodeRow.Rmk5 = Rmk5.Trim();
                
                //qRCodeRow.TicketCodeIn = textBox2.Text;

                reportData.QRCode.AddQRCodeRow(qRCodeRow);

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "ReportData";
                reportDataSource.Value = reportData.QRCode;
                reportViewer1.LocalReport.DataSources.Clear();

                // ID Ticket Example
                ///  1 = no simaple
                ///  2  = 1 sample
                ///  3  = 2 sample
                ///  4 =  3 sample
                ///  5 = 4 sample               


                if (truckType == 1)  //งานซื้อ รถเดี่ยว
                {

                    if (ID_Exam == 2)
                    {
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Truck_Analytics.Rp_PurTK1sim_1.rdlc"; //รถเดี่ยว
                    }

                    if (ID_Exam == 3)
                    {
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Truck_Analytics.Rp_PurTK2sim_1.rdlc"; //รถเดี่ยว
                    }
                }

                if (truckType == 2)  // งานซื้อ รถพ่วง
                {
                    if (ID_Exam == 2)
                    {
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Truck_Analytics.Rp_PurTK1sim_2.rdlc";  //รถพ่วง
                    }
                    if (ID_Exam == 3)
                    {
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Truck_Analytics.Rp_PurTK2sim_2.rdlc"; //รถพ่วง
                    }

                }

                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                reportViewer1.RefreshReport();


            }
            catch { }
        }

        private void Load_Ticket_Personal()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();               
                con.Open();

                string ProductName = "";
                int QueueNo = 0;

                string sql1 = "";

                if (type_job == 1)
                {
                    sql1 = "Select  [ProductName],[QueueNo]  FROM  [dbo].[V_Ticket_Register] Where [TicketCodeIn]='" + Ticket_code + "'";
                }

                if (type_job == 2)
                {
                    sql1 = "Select [ProductName],[QueueNo] FROM  [dbo].[V_Ticket_Register_Sale] Where [TicketCodeIn]='" + Ticket_code + "'";
                }

                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    ProductName = DR1["ProductName"].ToString();
                    QueueNo = Convert.ToInt16(DR1["QueueNo"].ToString());
                }
                DR1.Close();
                con.Close();


                this.reportViewer1.RefreshReport();
                this.reportViewer1.LocalReport.EnableExternalImages = true;
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;

                QRCoder.QRCodeGenerator qRCodeGenerator1 = new QRCoder.QRCodeGenerator();
                QRCoder.QRCodeData qRCodeDataTicket1 = qRCodeGenerator1.CreateQrCode(Ticket_code, QRCoder.QRCodeGenerator.ECCLevel.Q);
                QRCoder.QRCode qRCodeTicket1 = new QRCoder.QRCode(qRCodeDataTicket1);
                Bitmap bmp = qRCodeTicket1.GetGraphic(7);


                if (type_job == 1 || type_job == 2)   //ฟอร์มลงทะเบียนทั่วไป  1- แบบซื้อ    2- แบบขาย
                {
                    DS_Salexsd DS_Sale = new DS_Salexsd();
                    DS_Salexsd.QR_SaleRow qR_SaleRow = DS_Sale.QR_Sale.NewQR_SaleRow();

                    //reportData1.QRCode_Sale.NewQRCode_SaleRow();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        bmp.Save(ms, ImageFormat.Bmp);
                        qR_SaleRow.ImageTicket = ms.ToArray();
                    }

                    qR_SaleRow.ProductName = ProductName;
                    qR_SaleRow.TicketCode = Ticket_code;

                    qR_SaleRow.QueueNo = QueueNo.ToString();
                    qR_SaleRow.Date_Sale = DateTime.Now.ToShortDateString();
                    qR_SaleRow.Time_Sale = DateTime.Now.ToShortTimeString();

                    DS_Sale.QR_Sale.AddQR_SaleRow(qR_SaleRow);

                    ReportDataSource reportDataSource = new ReportDataSource();

                    reportDataSource.Name = "DS_Sale";
                    reportDataSource.Value = DS_Sale.QR_Sale;

                    if (type_job == 1)
                    {
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Truck_Analytics.Rp_PurTKnoSim.rdlc";
                    }

                    if (type_job == 2)
                    {
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Truck_Analytics.Rp_SaleTKnoSim.rdlc";
                    }
                    reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                    reportViewer1.RefreshReport();          

                }               
               

            }
            catch { }



        }


    }
}
