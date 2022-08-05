using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SaleOrder
{
    public partial class FrmInformation : Form
    {
        public FrmInformation()
        {
            InitializeComponent();
        }
        public int xposition;
        public int yposition;
        public string idtran = "";
        public int idtypeinfor = 0;

        private void FrmInformation_Load(object sender, EventArgs e)
        {
            this.Location = new Point(xposition, yposition);
            if (idtypeinfor == 0)//pur to sale
            {
                lblinformation.Text = "รายละเอียดข้อมูลซื้อ -> ขาย เลขที่: " + idtran.Trim();
                //lblpurhcase.Text = "ข้อมูลประเภทซื้อ -> คลัง";
                loadpurchase(); loadsale();
            }
            if (idtypeinfor == 1)//purchase
            {
                lblinformation.Text = "รายละเอียดข้อมูลซื้อเลขที่: " + idtran.Trim();                
                this.ClientSize = new System.Drawing.Size(313, 216);
                loadsale();
            }
            if (idtypeinfor == 2)//sale
            {
                lblinformation.Text = "รายละเอียดข้อมูลขายเลขที่: " + idtran.Trim();
                lblpurhcase.Text = "ข้อมูลต้นทาง";
                //this.Size.Width=;
                this.ClientSize = new System.Drawing.Size(313, 216);
                loadpurchase();
            }
        }

        private void loadpurchase()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string strPur = ""; string sql1 = ""; string strSale = "";

            if (idtypeinfor == 0)//pur to sale
            {
                sql1 = "SELECT idpur,datepur,comsup,compur,comtran,proname,carname,serailcar,telcontact FROM vpurchase WHERE idtran = '" + idtran.Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();
                DR1.Read();
                {
                    strPur += "รหัสซื้อ: " + DR1["idpur"].ToString() + "\r\n";
                    strPur += "วันที่ซื้อ: " + DR1["datepur"].ToString() + "\r\n";
                    strPur += "ผู้จำหน่าย: " + DR1["comsup"].ToString() + "\r\n";
                    strPur += "ผู้ซื้อ: " + DR1["compur"].ToString() + "\r\n";
                    strPur += "ผู้ขนส่ง: " + DR1["comtran"].ToString() + "\r\n";
                    strPur += "สินค้า: " + DR1["proname"].ToString() + "\r\n";
                    strPur += "ชนิด/ปรเภทรถ: " + DR1["carname"].ToString() + "\r\n";
                    strPur += "ทะเบียน: " + DR1["serailcar"].ToString() + "\r\n";
                    strPur += "เบอร์โทร: " + DR1["telcontact"].ToString() + "\r\n";
                }
                DR1.Close();
            }
            if (idtypeinfor == 1)//sale ข้อมูลปลาย
            {
                string sql = "SELECT idtran FROM tbpurchase WHERE idpur = '" + idtran.Trim() + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();
                DR.Read();
                {
                    idtran = DR["idtran"].ToString().Trim();
                }
                DR.Close();

                //sql1 = "SELECT idorder,orderdate,comcus,proname,carname,remark1 FROM vsaleorder WHERE idtran = '" + idtran.Trim() + "'";
                //SqlCommand CM1 = new SqlCommand(sql1, CN);
                //SqlDataReader DR1 = CM1.ExecuteReader();
                //DR1.Read();
                //{
                //    strSale += "รหัสขาย: " + DR1["idorder"].ToString() + "\r\n";
                //    strSale += "วันที่รับOrder: " + DR1["orderdate"].ToString() + "\r\n";
                //    strSale += "ผู้ซื้อ: " + DR1["comcus"].ToString() + "\r\n";
                //    strSale += "สินค้า: " + DR1["proname"].ToString() + "\r\n";
                //    strSale += "ชนิด/ประเภทรถ: " + DR1["carname"].ToString() + "\r\n";
                //    strSale += "หมายเหตุ: " + DR1["remark1"].ToString() + "\r\n";
                //}
                //DR1.Close();
            }
            txtpurchase.Text = strPur;
        }

        private void loadsale()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string strSale = ""; string sql1 = ""; string strPur = "";

            if (idtypeinfor == 0)//pur to sale
            {
                sql1 = "SELECT idorder,orderdate,comcus,proname,carname,remark1 FROM vsaleorder WHERE idtran = '" + idtran.Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();
                DR1.Read();
                {
                    strSale += "รหัสขาย: " + DR1["idorder"].ToString() + "\r\n";
                    strSale += "วันที่รับOrder: " + DR1["orderdate"].ToString() + "\r\n";
                    strSale += "ผู้ซื้อ: " + DR1["comcus"].ToString() + "\r\n";
                    strSale += "สินค้า: " + DR1["proname"].ToString() + "\r\n";
                    strSale += "ชนิด/ประเภทรถ: " + DR1["carname"].ToString() + "\r\n";
                    strSale += "หมายเหตุ: " + DR1["remark1"].ToString() + "\r\n";
                }
                DR1.Close();

                txtorder.Text = strSale;                
            }
            if (idtypeinfor == 1)//ดูข้อมูลปลายทางจากซื้อ
            {
                int countitems = 0;

                string sql = "SELECT idtran FROM tbpurchase WHERE idpur = '" + idtran.Trim() + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();
                DR.Read();
                {
                    idtran = DR["idtran"].ToString().Trim();
                }
                DR.Close();

                sql1 = "SELECT count(idorder)as coutitem FROM vsaleorder WHERE idtran = '" + idtran.Trim() + "'";
                SqlCommand CM0 = new SqlCommand(sql1, CN);
                SqlDataReader DR0 = CM0.ExecuteReader();
                DR0.Read();
                {
                    countitems = Convert.ToInt16(DR0["coutitem"].ToString());
                }
                DR0.Close();

                if (countitems == 1)
                {
                    sql1 = "SELECT idtran,idorder,orderdate,comcus,dateWbf,weigthsup,dateWcus,weigthsup,weigthcus,weigthsupdfsale,moisture,remark1 FROM vWFsTCrp WHERE idtran = '" + idtran.Trim() + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    SqlDataReader DR1 = CM1.ExecuteReader();
                    DR1.Read();
                    {
                        strSale += "เลขที่ขนส่ง: " + DR1["idtran"].ToString() + "\r\n";
                        strSale += "เลขที่ขาย: " + DR1["idorder"].ToString() + "   วันที่รับขาย: " + DR1["orderdate"].ToString() + "\r\n";
                        strSale += "บริษัท ผู้ซื้อ: " + DR1["comcus"].ToString() + "\r\n";
                        strSale += "วันที่ออกต้นทาง: " + DR1["dateWbf"].ToString() + "\r\n";
                        strSale += "วันที่ถึงปลายทาง: " + DR1["dateWcus"].ToString() + "\r\n";
                        strSale += "นน.ต้นทาง: " + DR1["weigthsup"].ToString() + "   นน.ปลายทาง: " + DR1["weigthcus"].ToString() + "\r\n";
                        strSale += "นน.ส่วงต่าง: " + DR1["weigthsupdfsale"].ToString() + "\r\n";
                        strSale += "ความชื้น: " + DR1["moisture"].ToString() + "\r\n";
                        strSale += "หมายเหตุ: " + DR1["remark1"].ToString() + "\r\n";
                    }
                    DR1.Close();
                    lblpurhcase.Text = "ข้อมูลปลายทาง ประเภทส่งตรง (ซื้อ -> ขาย)";
                }

                else if (countitems != 1)
                {
                    sql1 = "SELECT idtran,idtranauto,bname,comtran,compur,serailcar,dateWbf,dateWaf,weigthbf,weigthaf,weigthnet,weigthsup,weigthsupdfsale,moisture,kkperweigth,jobtrack FROM vWTrckinRP WHERE idtran = '" + idtran.Trim() + "'";
                    SqlCommand CM2 = new SqlCommand(sql1, CN);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    DR2.Read();
                    {
                        strSale += "เลขที่ขนส่ง: " + DR2["idtran"].ToString() + "     เลขที่ชั่งเข้า: " + DR2["idtranauto"].ToString() + "\r\n";
                        strSale += "สาขารับสินค้า: " + DR2["bname"].ToString() + "\r\n";                       
                        strSale += "บริษัท ขนส่ง: " + DR2["comtran"].ToString() + "\r\n";                      
                        strSale += "ทะเบียนรถ: " + DR2["serailcar"].ToString() + "\r\n";
                        strSale += "วันที่ชั่งเข้า: " + DR2["dateWbf"].ToString() + "\r\n";
                        strSale += "วันที่ชั่งออก: " + DR2["dateWaf"].ToString() + "\r\n";
                        strSale += "นน.ชั่งเข้า: " + DR2["weigthbf"].ToString() + "   นน.ชั่งออก: " + DR2["weigthaf"].ToString() + "\r\n";
                        strSale += "นน.สุทธิ: " + DR2["weigthnet"].ToString() + "   นน.โรงปาล์ม: " + DR2["weigthsup"].ToString() + " \r\n";
                        strSale += "นน.ส่วนต่าง: " + DR2["weigthsupdfsale"].ToString() + "\r\n";
                        strSale += "ความชื้นรับเข้า: " + DR2["moisture"].ToString() + "\r\n";
                        strSale += "นน./กิโลตวง: " + DR2["kkperweigth"].ToString() + "\r\n";
                        strSale += "สถานะงาน: " + DR2["jobtrack"].ToString() + "\r\n";
                    }
                    DR2.Close();
                    lblpurhcase.Text = "ข้อมูลปลายทาง ประเภทรับเข้าคลัง (ซื้อ -> คลัง)";
                }

                txtpurchase.Text = strSale;
            }          
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}