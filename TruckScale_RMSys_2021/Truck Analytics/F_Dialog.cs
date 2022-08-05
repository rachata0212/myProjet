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
    public partial class F_Dialog : Form
    {
        public F_Dialog()
        {
            InitializeComponent();
        }

        public string QR_code = "";
        public string Weight_type = "";
        private void F_Dialog_Load(object sender, EventArgs e)
        {
            txt_qrcode.Focus();
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-us"));
        }

        private void txt_qrcode_KeyPress(object sender, KeyPressEventArgs e)
        
        {
            //if (txt_qrcode.Text != "")
            //{
            //    //check qrcode

            if (e.KeyChar == 13)
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                int count_ticket = 0;

                string sql1 = "Select count ([TicketCodeIn])as CountTicket From[dbo].[V_WeightData] Where [TicketCodeIn] ='" + txt_qrcode.Text.Trim() + "' ";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();
                DR1.Read();
                {
                    count_ticket = Convert.ToInt16(DR1["CountTicket"].ToString());
                }
                DR1.Close();
                con.Close();

                Weight_type = "Purchase";


                //6-0004
                if (count_ticket == 0)
                {
                    con.Open();
                    string sql2 = "Select count ([TicketCodeIn])as CountTicket From[dbo].[V_WeightData_Sale] Where [TicketCodeIn] ='" + txt_qrcode.Text.Trim() + "'";
                    SqlCommand CM2 = new SqlCommand(sql2, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    DR2.Read();
                    {
                        count_ticket = Convert.ToInt16(DR2["CountTicket"].ToString());
                    }
                    DR2.Close();
                    con.Close();

                    Weight_type = "Sale";

                }

                if (count_ticket != 0)
                {
                    QR_code = txt_qrcode.Text.Trim();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("ไม่่มีข้อมูลเลขที่ตั๋วลงทะเบียนออกนี้ " + txt_qrcode.Text, "ข้อมูลลงทะเบียนออกไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_qrcode.Clear();
                    txt_qrcode.Focus();
                }


                //}
            }
        }
    }
}
