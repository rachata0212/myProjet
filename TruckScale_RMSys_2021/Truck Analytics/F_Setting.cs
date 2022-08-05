using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace Truck_Analytics
{
    public partial class F_Setting : Form
    {
        public F_Setting()
        {
            InitializeComponent();
        }
                
        int ID_OverStep = 0;
        int PaySeting_ID = 0;
        int idSTRNo = 0;
        int idUpdate_type = 0;
        int id_countCheck = 0;

        // Log
        string Msg = "";    
        string Log_OldValue = "-";
        string Log_NewValue = "-";


        int id_ProcessRegister = 0;
        int e_RowIndex = 0;
        int e_ColIndex = 0;
       
        int items_CountDB = 0;
        int items_CountNAV = 0;
        string LabtypeID = "";
      

        int TombonId = 0;

        //----------- Alert  
        int ID_AL = 0;
        int id_filterAlert = 0;
        int id_filterApproved = 0;        
   
        int ID_ALRP = 0;
        int ID_TypeLoad = 0;
        int ID_LineGroup = 0;
        int StS_Alert = 0;
        
        int StS_mail = 0;    
        int ShoDetail_mail = 0;
        
        int StS_line = 0;
        int ShoDetail_line = 0;
        int C_count = 0;


        //id menu
        int M0 = 0;
        int M1 = 0;
        int M2 = 0;
        int M3 = 0;
        int M4 = 0;
        int M5 = 0;
        int M6 = 0;
        int M7 = 0;
        int M8 = 0;
        int M9 = 0;

        public void Load_form(object Form)
        {
            if (this.pn_mainform.Controls.Count > 0)
                this.pn_mainform.Controls.RemoveAt(0);
            Form F = Form as Form;
            F.TopLevel = false;
            F.Dock = DockStyle.Fill;
            this.pn_mainform.Controls.Add(F);
            this.pn_mainform.Tag = F;
            F.Show();

            pn_mainform.Dock = DockStyle.Fill;
        }

        private void F_Setting_Load(object sender, EventArgs e)
        {

            //tab1.Enabled = False
            //Tb_tabmenu.Controls.Remove(tcp_index0); //ความปลอดภัย   9     
     
            Load_CheckPermission();

            if (Program.DB_Name != "SapthipNewDB")
            {
                txt_value.BackColor = Color.Crimson;
            }
        }


       



        //private void Load_UserMailAlert()
        //{
        //    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
        //    con.ConnectionString = Program.pathdb_Weight;
        //    SqlDataAdapter dtAdapter = new SqlDataAdapter();

        //    SqlCommand cmd = new SqlCommand(" Select [UserID],[FullUserName]  From  [dbo].[TB_Users] ", con);
        //    DataSet ds = new DataSet();
        //    //ds.Clear();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = cmd;
        //    da.Fill(ds);
        //    //Load product tab weight scale Setup
        //    cb_employeeAlert.DataSource = ds.Tables[0];
        //    cb_employeeAlert.DisplayMember = "FullUserName";
        //    cb_employeeAlert.ValueMember = "UserID";
        //}

      
        

   
        //private void Load_MenuPermission()
        //{
        //    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
        //    con.ConnectionString = Program.pathdb_Weight;
        //    SqlDataAdapter dtAdapter = new SqlDataAdapter();
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("Select [ID_Menu],Trim(Convert(char,[ID_Menu])) + ': '+ Trim([Name_Menu]) AS 'Name_Menu'  From  [dbo].[TB_Menu] ", con);
        //    DataSet ds = new DataSet();
        //    //ds.Clear();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = cmd;
        //    da.Fill(ds);
        //    //Load product tab weight scale Setup
        //    cb_menuPermission.DataSource = ds.Tables[0];
        //    cb_menuPermission.DisplayMember = "Name_Menu";
        //    cb_menuPermission.ValueMember = "ID_Menu";
        //    con.Close();
        //}


    

        private void Load_CheckPermission()
        {  
            SqlConnection con1 = new SqlConnection(Program.pathdb_Weight);
            con1.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter1 = new SqlDataAdapter();
            con1.Open();
        
            string sql1 = "SELECT [ID_Menu],[Status_Active] FROM  [dbo].[V_Permission] WHERE User_AD ='" + Program.user_login +"' and Status_Use =1 and ID_Menutype = 2 ";
            SqlCommand CM1 = new SqlCommand(sql1, con1);
            SqlDataReader DR1 = CM1.ExecuteReader();

            while (DR1.Read())
            {
                if (DR1["ID_Menu"].ToString().Trim() == "9") //ความปลอดภัย   9
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True") { /* add menu nornallyk */

                        btn_security.Enabled = true;                       
                    }                 
                }

                if (DR1["ID_Menu"].ToString().Trim() == "14") //การเชื่อมต่อขอ้มูล 14
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True") { /* add menu nornallyk */

                        btn_link.Enabled = true;
                    }
                    
                }


                if (DR1["ID_Menu"].ToString().Trim() == "11") //ตั้งค่างานลงทะเบียน 11
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True") { /* add menu nornallyk */

                        btn_register.Enabled = true;
                    }               
                  
                }


                if (DR1["ID_Menu"].ToString().Trim() == "10") //ตั้งค่างานชั่งสินค้า  10
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True") { /* add menu nornallyk */

                        btn_truckScale.Enabled = true;
                    }
                   
                }


                if (DR1["ID_Menu"].ToString().Trim() == "68") //ตังค่างานคลัง 68
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True") { /* add menu nornallyk */

                        btn_warehouse.Enabled = true;
                    }
                   
                }

                if (DR1["ID_Menu"].ToString().Trim() == "12") //ตั้งค่างานบันทึกผลวิเคราะห์ 12
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True") { /* add menu nornallyk */

                        btn_lab.Enabled = true;                    
                    }
                  
                }


                if (DR1["ID_Menu"].ToString().Trim() == "13") //ตั้งค่างานซื้อ/จ่ายสินนค้า 13
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True") { /* add menu nornallyk */

                        btn_payment.Enabled = true;
                    }
                 
                }


                if (DR1["ID_Menu"].ToString().Trim() == "15") // ตั้งค่างานอนุมัติและแจ้งเตือน 15
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True") { /* add menu nornallyk */

                        btn_approved.Enabled = true;
                    }                
                }

                if (DR1["ID_Menu"].ToString().Trim() == "69") // ประวัติการเข้าใช้งาน 69
                {
                    if (DR1["Status_Active"].ToString().Trim() == "True") { /* add menu nornallyk */

                        btn_log.Enabled = true;
                    }
                   
                }

            }
            DR1.Close();
            con1.Close();
                                                                              

            //if (id_ProcessConfig == 1)  // Purchse Dept Config
            //{
            //    Tb_tabmenu.Controls.Remove(tcp_index0);
            //    Tb_tabmenu.Controls.Remove(tcp_index1);
            //    Tb_tabmenu.Controls.Remove(tcp_index3);
            //    Tb_tabmenu.Controls.Remove(tcp_index5);
            //    Tb_tabmenu.Controls.Remove(tcp_index4);
            //    Tb_tabmenu.Controls.Remove(tcp_index8);
            //    Tb_tabmenu.Controls.Remove(tcp_index7);


            //    Load_VendorGroup();
            //    Load_VendorSettingGroup();
            //    Load_UnitType();
            //}











        }

        
        private static void EnableControls(Control.ControlCollection ctls, bool enable)
        {
            foreach (Control ctl in ctls)
            {
                ctl.Enabled = enable;
                EnableControls(ctl.Controls, enable);
            }
        }

        
        
               

     
        //int id_change = 0;
        //int id_ststuschange = 0;   

        //int id_view = 0;
      
    
        
    
       
        //string id_update;
            

        //int PrintAT_No = 0;
        //string id_CustomerAuto = "";
        //string id_ProductAuto = "";
        //string id_ZoneAuto = "";
        //int id_editPrintAuto = 0;
 
        //int id_services = 0;
              
        //int sts_chnage = 0;
        //int id_search = 0;
        //int Id_Map = 0;
        //int sts_dup = 0;
     
        private void txt_value_TextChanged(object sender, EventArgs e)
        {

        }
        

        private void btn_security_Click(object sender, EventArgs e)
        {
            lbl_menu.Text = "งานตั้งค่าความปลอดภัยของการเข้าถึงข้อมูลและระบบ (Security)";
            Load_form(new Sub_Fsecurity());

            Msg = "Access Menu Access Program Setting!";
            Log_OldValue = "-";
            Log_NewValue = "-";
            Save_MenuAccessLog();
        }

        private void btn_link_Click(object sender, EventArgs e)
        {          
            lbl_menu.Text = "งานตั้งค่าการเชื่อมต่อข้อมูลและอุปกรณ์ต่าง ๆ (Data Link && Communication Port)";
            Load_form(new Sub_Flink());

            Msg = "Access Menu Link & Communication Port Setting!";
            Log_OldValue = "-";
            Log_NewValue = "-";
            Save_MenuAccessLog();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            lbl_menu.Text = "งานตั้งค่างานลงทะเบียนเพื่อออกคิวอาร์โค้ด (Register && QR-Code)";
            Load_form(new Sub_Fregister());

            Msg = "Access Menu Register Setting!";
            Log_OldValue = "-";
            Log_NewValue = "-";
            Save_MenuAccessLog();
        }

        private void btn_truckScale_Click(object sender, EventArgs e)
        {
            lbl_menu.Text = "งานตั้งค่างานชั่งสินค้าและบริการ (TruckScale && Service)";
            Load_form(new Sub_FtruckScale());

            Msg = "Access Menu TruckScale Setting!";
            Log_OldValue = "-";
            Log_NewValue = "-";
            Save_MenuAccessLog();
        }

        private void btn_warehouse_Click(object sender, EventArgs e)
        {
            lbl_menu.Text = "งานตั้งค่าคลังสินค้า (Store && Warehouse)";
            Load_form(new Sub_Fwarehouse());

            Msg = "Access Menu Warehouse Setting!";
            Log_OldValue = "-";
            Log_NewValue = "-";
            Save_MenuAccessLog();
        }

        private void btn_lab_Click(object sender, EventArgs e)
        {
            //ตั้งค่าผลวิเคราะห์
            lbl_menu.Text = "งานตั้งค่าผลวิเคราะห์ในเงื่อนไขต่าง ๆ (Lab && Condition)";
            Load_form(new Sub_Flab());

            Msg = "Access Menu Lab Setting!";
            Log_OldValue = "-";
            Log_NewValue = "-";
            Save_MenuAccessLog();
        }

        private void btn_payment_Click(object sender, EventArgs e)
        {
            lbl_menu.Text = "งานตั้งค่างานซื้อ/จ่าย วัตถุดิบ (Payment)";
            Load_form(new Sub_Fpayment());

            Msg = "Access Menu Payment Setting!";
            Log_OldValue = "-";
            Log_NewValue = "-";
            Save_MenuAccessLog();
        }

        private void btn_approved_Click(object sender, EventArgs e)
        {
            //อนุมัติ/แจ้งเตือน
            lbl_menu.Text = "งานตั้งค่างานอนุมัติ/แจ้งเตือน (Approval & Alert)";
            Load_form(new Sub_Fapproval());

            Msg = "Access Menu Approval & Alert Setting!";
            Log_OldValue = "-";
            Log_NewValue = "-";
            Save_MenuAccessLog();
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            lbl_menu.Text = "ประวัติการเข้าใช้งานโปรแกรม (Log data Entry)";
            Load_form(new Sub_Flog());

            Msg = "Access Menu Log Entry!";
            Log_OldValue = "-";
            Log_NewValue = "-";
            Save_MenuAccessLog();
        }


        private void Save_MenuAccessLog()
        {
            Class_Log CL = new Class_Log();
            CL.tbname = Msg;
            CL.oldvalue = Log_OldValue;
            CL.newvalue = Log_NewValue;
            CL.Save_log();
        }
      
    }
}
     