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
using System.DirectoryServices;
using System.Net;
using System.IO;

namespace Truck_Analytics
{
    public partial class F_ChangeData : Form
    {
        public F_ChangeData()
        {
            InitializeComponent();
        }

        int TypeJob = 0;
        string ProductID = "";
        public int id_updateType = 0;

        //---------------------  app line
        string token = "";
        private void btn_showpwd_MouseDown(object sender, MouseEventArgs e)
        {
            //tbxPassword.BackColor = Color.Red;
            txt_pwd.PasswordChar = '\0';
        }

        private void txt_QRCode_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {

                try
                {

                    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                    con.ConnectionString = Program.pathdb_Weight;
                    SqlDataAdapter dtAdapter = new SqlDataAdapter();
                    con.Open();
                    

                    Check_TypeJob();  //ค้นหาประเภทงาน

                    string sql1 = "";


                    if (TypeJob == 1)   //purchase
                    {
                        sql1 = "Select * From  [dbo].[V_WeightData] Where TicketCodeIn ='" + txt_QRCode.Text.Trim() + "' AND [proc_type] !='P'  AND  [proc_type] !='C' AND  [proc_type] !='S'  ";
                    }

                    if (TypeJob == 2)  // sale
                    {
                        sql1 = "Select * From  [dbo].[V_WeightData_Sale] Where TicketCodeIn ='" + txt_QRCode.Text.Trim() + "' AND [proc_type] !='P' AND  [proc_type] !='C' AND  [proc_type] !='S' ";
                    }

                    SqlCommand CM1 = new SqlCommand(sql1, con);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    {
                        ProductID = DR1["ProductID"].ToString().Trim();

                        lbl_data.Text = "เลขที่บัตรชั่ง: " + txt_QRCode.Text.Trim();
                        lbl_data.Text += " คิวที่: " + DR1["QueueNo"].ToString().Trim(); //QueueNo
                        lbl_data.Text += " รหัสสินค้า: " + DR1["ProductID"].ToString().Trim();
                        lbl_data.Text += " ชื่อสินค้า: " + DR1["ProductName"].ToString().Trim();
                        lbl_data.Text += ""+ Environment.NewLine + " ทะเบียนรถ:" + DR1["Plate1"].ToString().Trim();
                        lbl_data.Text += " ประเภทรถ: " + DR1["TruckTypeName"].ToString().Trim();
                        lbl_data.Text += " ชื่อคนขับรถ: " + DR1["DriveName"].ToString().Trim();


                        if (TypeJob == 1)  //purchase
                        {
                            lbl_data.Text += "" + Environment.NewLine + " รหัสผู้ขาย: " + DR1["Vendor_No"].ToString().Trim();
                            lbl_data.Text += " ชื่อผู้ขาย: " + DR1["NameVen"].ToString().Trim();
                        }

                        if (TypeJob == 2)   // sale
                        {
                            lbl_data.Text += "" + Environment.NewLine + " รหัสผู้ซื้อ: " + DR1["CustomerID"].ToString().Trim();
                            lbl_data.Text += " ชื่อผู้ซื้อ: " + DR1["CustomerName"].ToString().Trim();
                        }



                    }
                    DR1.Close();
                    con.Close();

                    txt_pwd.Focus();


                }

                catch { txt_QRCode.Clear(); lbl_data.Text = ""; }
            }
        }


        private void Check_TypeJob()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            string sql1 = "Select [Vendor_No],[CustomerID] From  [dbo].[TB_WeightData] Where TicketCodeIn ='" + txt_QRCode.Text.Trim() + "' ";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {

                if (DR1["Vendor_No"].ToString() != "")
                {
                    TypeJob = 1;// "Purchase";
                }


                if (DR1["CustomerID"].ToString() != "")
                {
                    TypeJob = 2;  //"Sale";
                }
            }
            DR1.Close();

        }

        private void F_CancelConfirm_Load(object sender, EventArgs e)
        {
            txt_QRCode.Focus();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            if (txt_pwd.Text != "")
            {
                string nameLogin = Program.user_login;
                string pwdLogin = txt_pwd.Text.Trim();

                string initLDAPPath = "dc=sapthip,dc=com";   //ถ้าจะให้ดีทำเป็นไฟล์ setup ด้านนอกสามารถเปลี่ยนภายหลังได้
                string initLDAPServer = "192.168.168.13";  //ถ้าจะให้ดีทำเป็นไฟล์ setup ด้านนอกสามารถเปลี่ยนภายหลังได้
                string initShortDomainName = "sapthip.com";   //ถ้าจะให้ดีทำเป็นไฟล์ setup ด้านนอกสามารถเปลี่ยนภายหลังได้
                string strErrMsg;

                string DomainAndUsername = "";
                string strCommu;
                bool flgLogin = false;
                strCommu = ("LDAP://"

                + (initLDAPServer + ("/" + initLDAPPath)));
                DomainAndUsername = (initShortDomainName + ("\\" + nameLogin));
                DirectoryEntry entry = new DirectoryEntry(strCommu, DomainAndUsername, pwdLogin);

                object obj;

                try
                {
                    obj = entry.NativeObject;
                    DirectorySearcher search = new DirectorySearcher(entry);
                    SearchResult result;
                    search.Filter = ("(SAMAccountName="
                    + (nameLogin + ")"));
                    search.PropertiesToLoad.Add("cn");
                    result = search.FindOne();

                    if ((result == null))
                    {
                        flgLogin = false;
                        strErrMsg = "รหัสผ่านไม่ถูกต้อง!! กรุณาใส่รหัสผ่านใหม่อีกครั้ง";
                        txt_pwd.Clear();
                    }

                    else
                    {
                        flgLogin = true;
                    }
                }

                catch (Exception ex)
                {

                    flgLogin = false;
                    strErrMsg = "รหัสผ่านไม่ถูกต้อง!! กรุณาใส่รหัสผ่านใหม่อีกครั้ง";

                }

                if ((flgLogin == true))
                {
                    //test
                    // MessageBox.Show("Login OK");
                    Update_Data();
                                    
                    Class_Log CL = new Class_Log();
                    CL.tbname = "Cancel Ticket!";
                    CL.oldvalue = txt_QRCode.Text.Trim();
                    CL.newvalue = "-";
                    CL.Save_log();

                }

                else
                {
                    MessageBox.Show("รหัสผ่านไม่ถูกต้อง!! กรุณาใส่รหัสผ่านใหม่อีกครั้ง", "ยืนยันรหัสผ่านผิดพลาด!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }





        private void btn_showpwd_MouseUp(object sender, MouseEventArgs e)
        {
            txt_pwd.PasswordChar = '*';
            txt_pwd.Focus();
        }


        private void Update_Data()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            int id_Cancel = 0;

            string sql1 = "Select [proc_no] From [dbo].[TB_Process] Where [item_no] ='" + ProductID + "' AND [proc_type] ='C' ";
            SqlCommand CM1 = new SqlCommand(sql1, con);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                id_Cancel = Convert.ToInt16(DR1["proc_no"].ToString());
            }
            DR1.Close();
            con.Close();


            string sql = "";

            if (txt_Remark.Text != "")
            {

                if (id_updateType == 1) //register
                {
                    sql = "Update [TB_WeightData] Set [Process_id] = " + id_Cancel + ",[QueueNo]= 0, [Remark2]='" + txt_Remark.Text.Trim() + "' Where [TicketCodeIn] = '" + txt_QRCode.Text.Trim() + "'";
                }

                if (id_updateType == 2) //truck
                {
                    sql = "Update [TB_WeightData] Set [Process_id] = " + id_Cancel + ",[QueueNo]= 0 , [Remark2]='" + txt_Remark.Text.Trim() + "' Where [TicketCodeIn] = '" + txt_QRCode.Text.Trim() + "'";
                }

                con.Open();

                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();


                MessageBox.Show("ระบบได้ทำการยกเลิกชั่งสำเร็จ!!! ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Send_lineAlert();

                this.Close();
            }

            else {

                MessageBox.Show("กรุณาใส่เหตุผลในการยกเลิกบัตรเลขที่นี้!!! ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Remark.Focus();
            }

        }

        private void Send_lineAlert()
        {
            string msg1 = "";
            string sql = "";
            //Gross_Weight = Convert.ToDecimal(txt_weight_Net.Text);
            //Price_STD = Convert.ToDecimal(txt_stdPrice.Text);
            //Discut_Weight = System.Math.Round(((DiscutValue * Gross_Weight) / 100), 2, MidpointRounding.ToEven);
            //Gross_Weight = Gross_Weight - Discut_Weight;
            //SumPrice_STDExt = Price_STD + PriceExt;


            msg1 = "รายงาน: ยกเลิกงานชั่งน้ำหนัก/ยกเลิกรับสินค้า" + lbl_data.Text;

            sql = "SELECT [AL_lineNameToken] FROM [dbo].[V_TokenLine] WHERE [ID_processType]='C' AND [ProductID]='" + ProductID + "' AND [AL_lineStatus]=1";   

            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();


            SqlCommand CM = new SqlCommand(sql, con);
            SqlDataReader DR = CM.ExecuteReader();
            while (DR.Read())
            {
                token = DR["AL_lineNameToken"].ToString();
                lineNotify(msg1);
            }
            DR.Close();
            con.Close();
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
                var request = (System.Net.HttpWebRequest)WebRequest.Create("https://notify-api.line.me/api/notify");

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
                //MessageBox.Show(ex.ToString());
            }
        }

    }
}
