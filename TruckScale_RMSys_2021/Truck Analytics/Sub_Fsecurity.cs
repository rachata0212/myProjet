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
    public partial class Sub_Fsecurity : Form
    {
        public Sub_Fsecurity()
        {
            InitializeComponent();
        }

        // Log
        string Msg = "";
        string Log_OldValue = "-";
        string Log_NewValue = "-";
        int id_change = 0;

        int id_menu = 0;
        int id_per = 0;
        int e_rowIndex = -1;
        int e_colIndex = -1;


        private void btn_finduserADpermission_Click(object sender, EventArgs e)
        {
            //F_Search fdt = new F_Search();
            //fdt.id_findType = 8;
            //fdt.ShowDialog();
            //txt_idUserpermission.Text = fdt.id_value;
            //lbl_nameUserpermission.Text = fdt.name_value;
            //cb_menu.Focus();
        }

        private void Sub_Fsecurity_Load(object sender, EventArgs e)
        {

            //Load_DTGPermission();
            Load_User();
        }

        private void Load_User()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT [UserID],Trim(Convert(char,[UserID])) + ': '+ Trim([FullUserName]) AS 'FullUserName' FROM  [dbo].[TB_Users] Order by [UserID]", con);
                DataSet ds = new DataSet();
                //ds.Clear();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                //Load product tab weight scale Setup
                cbo_user.DataSource = ds.Tables[0];
                cbo_user.DisplayMember = "FullUserName";
                cbo_user.ValueMember = "UserID";
                con.Close();

                cbo_user.Text = "-- Select User --";
            }
            catch { }
        }

        private void Load_Menu()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();
                SqlCommand cmd = new SqlCommand("Select [ID_Menu],Trim(Convert(char,[ID_Menu])) + ': '+ Trim([Name_Menu]) AS 'Name_Menu'  From  [dbo].[TB_Menu] WHERE [ID_Menutype]= " + cb_menutype.SelectedValue.ToString().Trim() + "", con);
                DataSet ds = new DataSet();
                //ds.Clear();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                //Load product tab weight scale Setup
                cb_menu.DataSource = ds.Tables[0];
                cb_menu.DisplayMember = "Name_Menu";
                cb_menu.ValueMember = "ID_Menu";
                con.Close();
            }
            catch { }
        }

        private void Load_Menutype()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT [ID_Menutype],Trim(Convert(char,[ID_Menutype])) + ': '+ Trim([Name_Type]) AS 'Name_Type'  FROM [SapthipNewDB].[dbo].[TB_MenuType] ", con);
            DataSet ds = new DataSet();
            //ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            //Load product tab weight scale Setup
            cb_menutype.DataSource = ds.Tables[0];
            cb_menutype.DisplayMember = "Name_Type";
            cb_menutype.ValueMember = "ID_Menutype";
            con.Close();
        }


        private void cb_filterUser_CheckedChanged(object sender, EventArgs e)
        {
            Load_DTGPermission();
        }

        private void btn_addUser_Click(object sender, EventArgs e)
        {
            F_User Fus = new F_User();
            Fus.ShowDialog();

            Load_DTGPermission();
        }

        private void btn_savePermission_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                string sql = "";

                if (chk_add.Checked == true)  // insert
                {
                    con.Open();
                    sql = "Insert Into  [dbo].[TB_PermissionMenu] ([UserID],[ID_Menu]) Values(" + cbo_user.SelectedValue.ToString() + "," + cb_menu.SelectedValue.ToString() + ")";

                    SqlCommand CM2 = new SqlCommand(sql, con);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    con.Close();
                }


                Msg = "Insert Permission on Menu!";
                Log_NewValue = "UserID = " + cbo_user.Text.Trim() +
                    "," + "ID_Menu = " + cb_menu.SelectedValue.ToString();

                Log_OldValue = "-";
                Class_Log CL = new Class_Log();
                CL.tbname = Msg;
                CL.oldvalue = Log_OldValue;
                CL.newvalue = Log_NewValue;
                CL.Save_log();

                Load_DTGPermission();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Load_DTGPermission()
        {
            try
            {
                int id_user = Convert.ToInt16(cbo_user.SelectedValue.ToString());

                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();

                if (con.State == ConnectionState.Open)
                { con.Close(); }

                if (tb_menuType.SelectedIndex == 0)
                {
                    try
                    {
                        con.Open();
                        dtg_menu.DataSource = null;
                        string sql1 = "SELECT [ID_Per] AS 'รหัส',[Name_Menu] AS 'เมนูที่เข้าใช้',[Status_Use] AS 'เปิดใช้งาน',[ID_Menu],[UserID] FROM  [dbo].[V_Permission] WHERE  [UserID] = " + id_user + " AND [ID_Menutype] = 1";

                        //string sql1 = "SELECT [ID_Per] AS 'รหัส',[Name_Menu] AS 'เมนูที่เข้าใช้',[Name_Type]  AS 'ประเภท',[Status_Use] AS 'เปิดใช้งาน',[Adddata_Per] AS 'เพิ่ม',[Editdata_Per] AS 'แก้ไข',[Canceldata_Per] AS 'ยกเลิก',[Viewdata_Per] AS 'ดู',[Printdata_Per] AS 'พิมพ์',[Configdata_Per] AS 'ตั้งค่า',[Approvdata_per] AS 'การอนุมัติ',[ID_Menu],[UserID] FROM  [dbo].[V_Permission] WHERE  [UserID] = " + id_user + " AND [ID_Menutype] = 1";

                        SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1, "g_menu");
                        dtg_menu.DataSource = ds1.Tables["g_menu"];
                        con.Close();
                    }
                    catch { dtg_menu.DataSource = null; }
                }
                
                if (tb_menuType.SelectedIndex == 1)
                {
                    try
                    {
                        con.Open();
                        dtg_setting.DataSource = null;
                        string sql2 = "SELECT [ID_Per] AS 'รหัส',[Name_Menu] AS 'เมนูที่เข้าใช้',[Status_Use] AS 'เปิดใช้งาน',[Adddata_Per] AS 'เพิ่ม',[Editdata_Per] AS 'แก้ไข',[Canceldata_Per] AS 'ยกเลิก',[Viewdata_Per] AS 'ดู',[Printdata_Per] AS 'พิมพ์',[Configdata_Per] AS 'ตั้งค่า',[Approvdata_per] AS 'การอนุมัติ',[ID_Menu],[UserID] FROM  [dbo].[V_Permission] WHERE  [UserID] = " + id_user + " AND [ID_Menutype] = 2";

                        SqlDataAdapter da2 = new SqlDataAdapter(sql2, con);
                        DataSet ds2 = new DataSet();
                        da2.Fill(ds2, "g_setting");
                        dtg_setting.DataSource = ds2.Tables["g_setting"];
                        con.Close();
                    }
                    catch { dtg_setting.DataSource = null; }
                }
                
                if (tb_menuType.SelectedIndex == 2)
                {
                    try
                    {
                        con.Open();
                        dtg_subsetting.DataSource = null;
                        string sql2 = "SELECT [ID_Per] AS 'รหัส',[Name_Menu] AS 'เมนูที่เข้าใช้',[Status_Use] AS 'เปิดใช้งาน',[ID_Menu],[UserID] FROM  [dbo].[V_Permission] WHERE  [UserID] = " + id_user + " AND [ID_Menutype] = 6";

                        //string sql2 = "SELECT [ID_Per] AS 'รหัส',[Name_Menu] AS 'เมนูที่เข้าใช้',[Name_Type]  AS 'ประเภท',[Status_Use] AS 'เปิดใช้งาน',[Adddata_Per] AS 'เพิ่ม',[Editdata_Per] AS 'แก้ไข',[Canceldata_Per] AS 'ยกเลิก',[Viewdata_Per] AS 'ดู',[Printdata_Per] AS 'พิมพ์',[Configdata_Per] AS 'ตั้งค่า',[Approvdata_per] AS 'การอนุมัติ',[ID_Menu],[UserID] FROM  [dbo].[V_Permission] WHERE  [UserID] = " + id_user + " AND [ID_Menutype] = 6";

                        SqlDataAdapter da2 = new SqlDataAdapter(sql2, con);
                        DataSet ds2 = new DataSet();
                        da2.Fill(ds2, "g_subsetting");
                        dtg_subsetting.DataSource = ds2.Tables["g_subsetting"];
                        con.Close();
                    }
                    catch { dtg_subsetting.DataSource = null; }
                }

                if (tb_menuType.SelectedIndex == 3)
                {
                    try
                    {
                        con.Open();
                        dtg_process.DataSource = null;
                        string sql3 = "SELECT [ID_Per] AS 'รหัส',[Name_Menu] AS 'เมนูที่เข้าใช้',[Status_Use] AS 'เปิดใช้งาน',[Adddata_Per] AS 'เพิ่ม',[Editdata_Per] AS 'แก้ไข',[Canceldata_Per] AS 'ยกเลิก',[Viewdata_Per] AS 'ดู',[Printdata_Per] AS 'พิมพ์',[Configdata_Per] AS 'ตั้งค่า',[Approvdata_per] AS 'การอนุมัติ',[ID_Menu],[UserID] FROM  [dbo].[V_Permission] WHERE  [UserID] = " + id_user + " AND [ID_Menutype] = 3";

                        SqlDataAdapter da3 = new SqlDataAdapter(sql3, con);
                        DataSet ds3 = new DataSet();
                        da3.Fill(ds3, "g_process");
                        dtg_process.DataSource = ds3.Tables["g_process"];
                        con.Close();
                    }
                    catch { dtg_process.DataSource = null; }

                }

                if (tb_menuType.SelectedIndex == 4)
                {
                    try
                    {
                        con.Open();
                        dtg_report.DataSource = null;
                        //string sql4 = "SELECT [ID_Per] AS 'รหัส',[Name_Menu] AS 'เมนูที่เข้าใช้',[Name_Type]  AS 'ประเภท',[Status_Use] AS 'เปิดใช้งาน',[Adddata_Per] AS 'เพิ่ม',[Editdata_Per] AS 'แก้ไข',[Canceldata_Per] AS 'ยกเลิก',[Viewdata_Per] AS 'ดู',[Printdata_Per] AS 'พิมพ์',[Configdata_Per] AS 'ตั้งค่า',[Approvdata_per] AS 'การอนุมัติ',[ID_Menu],[UserID] FROM  [dbo].[V_Permission] WHERE  [UserID] = " + id_user + " AND [ID_Menutype] = 4";
                        string sql4 = "SELECT [ID_Per] AS 'รหัส',[Name_Menu] AS 'เมนูที่เข้าใช้',[Status_Use] AS 'เปิดใช้งาน',[ID_Menu],[UserID] FROM  [dbo].[V_Permission] WHERE  [UserID] = " + id_user + " AND [ID_Menutype] = 4";

                        SqlDataAdapter da4 = new SqlDataAdapter(sql4, con);
                        DataSet ds4 = new DataSet();
                        da4.Fill(ds4, "g_report");
                        dtg_report.DataSource = ds4.Tables["g_report"];
                        con.Close();
                    }

                    catch { dtg_report.DataSource = null; }
                }


                Change_color();
            }
            catch { }

        }

        private void Change_color()
        {
            if (tb_menuType.SelectedIndex == 0)
            {
                // Status DTG Menu
                for (int i = 0; i < dtg_menu.RowCount; i++)
                {
                    if (dtg_menu.Rows[i].Cells[2].Value.ToString() == "True")
                    {
                        this.dtg_menu.Rows[i].Cells[2].Style.BackColor = Color.LightGreen;
                    }
                }

                if (dtg_menu.RowCount != 0)
                {
                    dtg_menu.Columns[0].Width = 80;
                    //dtg_menu.Columns[1].Width = 270;
                    dtg_menu.Columns[2].Width = 150;
                   
                    dtg_menu.Columns[3].Visible = false;
                    dtg_menu.Columns[4].Visible = false;
                    dtg_menu.ClearSelection();
                }
                else { dtg_menu.DataSource = null; }
            }

            if (tb_menuType.SelectedIndex == 1)
            {
                // Status DTG Setting
                for (int i = 0; i < dtg_setting.RowCount; i++)
                {
                    if (dtg_setting.Rows[i].Cells[2].Value.ToString() == "True")
                    {
                        this.dtg_setting.Rows[i].Cells[2].Style.BackColor = Color.LightGreen;
                    }

                    if (dtg_setting.Rows[i].Cells[3].Value.ToString() == "True")
                    {
                        this.dtg_setting.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                    }

                    if (dtg_setting.Rows[i].Cells[4].Value.ToString() == "True")
                    {
                        this.dtg_setting.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                    }

                    if (dtg_setting.Rows[i].Cells[5].Value.ToString() == "True")
                    {
                        this.dtg_setting.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                    }

                    if (dtg_setting.Rows[i].Cells[6].Value.ToString() == "True")
                    {
                        this.dtg_setting.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                    }

                    if (dtg_setting.Rows[i].Cells[7].Value.ToString() == "True")
                    {
                        this.dtg_setting.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                    }

                    if (dtg_setting.Rows[i].Cells[8].Value.ToString() == "True")
                    {
                        this.dtg_setting.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                    }

                    if (dtg_setting.Rows[i].Cells[9].Value.ToString() == "True")
                    {
                        this.dtg_setting.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                    }

                    if (dtg_setting.Rows[i].Cells[10].Value.ToString() == "True")
                    {
                        this.dtg_setting.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                    }                   
                }

                if (dtg_setting.RowCount != 0)
                {
                    dtg_setting.Columns[0].Width = 80;
                    dtg_setting.Columns[1].Width = 270;
                    dtg_setting.Columns[2].Width = 150;
                    dtg_setting.Columns[3].Width = 100;
                    dtg_setting.Columns[9].Width = 100;
                    dtg_setting.Columns[10].Visible = false;
                    dtg_setting.Columns[11].Visible = false;

                    dtg_setting.ClearSelection();
                }
                else { dtg_setting.DataSource = null; }
            }

            if (tb_menuType.SelectedIndex == 2)
            {
                // Status DTG Setting
                for (int i = 0; i < dtg_subsetting.RowCount; i++)
                {
                    if (dtg_subsetting.Rows[i].Cells[2].Value.ToString() == "True")
                    {
                        this.dtg_subsetting.Rows[i].Cells[2].Style.BackColor = Color.LightGreen;
                    }
                }

                if (dtg_subsetting.RowCount != 0)
                {
                    dtg_subsetting.Columns[0].Width = 80;
                    //dtg_subsetting.Columns[1].Width = 270;
                    dtg_subsetting.Columns[2].Width = 150;
              
                    dtg_subsetting.Columns[3].Visible = false;
                    dtg_subsetting.Columns[4].Visible = false;

                    dtg_subsetting.ClearSelection();
                }
                else { dtg_subsetting.DataSource = null; }
            }

            if (tb_menuType.SelectedIndex == 3)
            {
                // Status DTG Process
                for (int i = 0; i < dtg_process.RowCount; i++)
                {

                    if (dtg_process.Rows[i].Cells[2].Value.ToString() == "True")
                    {
                        this.dtg_process.Rows[i].Cells[2].Style.BackColor = Color.LightGreen;
                    }

                    if (dtg_process.Rows[i].Cells[3].Value.ToString() == "True")
                    {
                        this.dtg_process.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                    }

                    if (dtg_process.Rows[i].Cells[4].Value.ToString() == "True")
                    {
                        this.dtg_process.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                    }

                    if (dtg_process.Rows[i].Cells[5].Value.ToString() == "True")
                    {
                        this.dtg_process.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                    }

                    if (dtg_process.Rows[i].Cells[6].Value.ToString() == "True")
                    {
                        this.dtg_process.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                    }

                    if (dtg_process.Rows[i].Cells[7].Value.ToString() == "True")
                    {
                        this.dtg_process.Rows[i].Cells[7].Style.BackColor = Color.LightGreen;
                    }

                    if (dtg_process.Rows[i].Cells[8].Value.ToString() == "True")
                    {
                        this.dtg_process.Rows[i].Cells[8].Style.BackColor = Color.LightGreen;
                    }

                    if (dtg_process.Rows[i].Cells[9].Value.ToString() == "True")
                    {
                        this.dtg_process.Rows[i].Cells[9].Style.BackColor = Color.LightGreen;
                    }

                    if (dtg_process.Rows[i].Cells[10].Value.ToString() == "True")
                    {
                        this.dtg_process.Rows[i].Cells[10].Style.BackColor = Color.LightGreen;
                    }
                  
                }

                if (dtg_process.RowCount != 0)
                {
                    dtg_process.Columns[0].Width = 80;
                    dtg_process.Columns[1].Width = 270;
                    dtg_process.Columns[2].Width = 150;
                    dtg_process.Columns[3].Width = 100;
                    dtg_process.Columns[9].Width = 100;
                    dtg_process.Columns[10].Visible = false;
                    dtg_process.Columns[11].Visible = false;

                    dtg_process.ClearSelection();
                }

                else { dtg_process.DataSource = null; }
            }

            if (tb_menuType.SelectedIndex == 4)
            {
                // Status DTG Report
                for (int i = 0; i < dtg_report.RowCount; i++)
                {
                    if (dtg_report.Rows[i].Cells[2].Value.ToString() == "True")
                    {
                        this.dtg_report.Rows[i].Cells[2].Style.BackColor = Color.LightGreen;
                    }
                }

                if (dtg_report.RowCount != 0)
                {
                    dtg_report.Columns[0].Width = 80;
                    //dtg_report.Columns[1].Width = 270;
                    dtg_report.Columns[2].Width = 150;
                  
                    dtg_report.Columns[3].Visible = false;
                    dtg_report.Columns[4].Visible = false;             

                    dtg_report.ClearSelection();
                }

                else { dtg_report.DataSource = null; }
            }           

        }
     
             
        private void cbo_user_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DTGPermission();
        }

        private void chk_add_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_add.Checked == true)
            {
                gb_new.Enabled = true;
                Load_Menutype();
            }
            else { gb_new.Enabled = false; }
        }

        private void cb_menutype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chk_add.Checked == true)
            {
                Load_Menu();
            }
        }

        private void cb_menu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tb_menuType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DTGPermission();
        }

        private void dtg_menu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                id_change = Convert.ToInt16(dtg_menu.Rows[e.RowIndex].Cells[0].Value.ToString());
                cb_menu.SelectedValue = dtg_menu.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void Update_DataUser()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            int Status_Change = 0;
            String MenuName = "";

            if (tb_menuType.SelectedIndex == 0 )
            {
                if (dtg_menu.Rows[e_rowIndex].Cells[e_colIndex].Value.ToString() == "True") { Status_Change = 1; }
            }

            if (tb_menuType.SelectedIndex == 1)
            {
                if (dtg_setting.Rows[e_rowIndex].Cells[e_colIndex].Value.ToString() == "True") { Status_Change = 1; }
            }

            if (tb_menuType.SelectedIndex == 2)
            {
                if (dtg_subsetting.Rows[e_rowIndex].Cells[e_colIndex].Value.ToString() == "True") { Status_Change = 1; }
            }

            if (tb_menuType.SelectedIndex == 3)
            {
                if (dtg_process.Rows[e_rowIndex].Cells[e_colIndex].Value.ToString() == "True") { Status_Change = 1; }
            }

            if (tb_menuType.SelectedIndex == 4)
            {
                if (dtg_report.Rows[e_rowIndex].Cells[e_colIndex].Value.ToString() == "True") { Status_Change = 1; }
            }
                            
         
                if (e_colIndex == 2)
                {
                    MenuName = "[Status_Use]";
                }
                if (e_colIndex == 3)
                {
                    MenuName = "[Adddata_Per]";
                }

                if (e_colIndex == 4)
                {
                    MenuName = "[Editdata_Per]";
                }

                if (e_colIndex == 5)
                {
                    MenuName = "[Canceldata_Per]";
                }

                if (e_colIndex == 6)
                {
                    MenuName = "[Viewdata_Per]";
                }

                if (e_colIndex == 7)
                {
                    MenuName = "[Printdata_Per]";
                }

                if (e_colIndex == 8)
                {
                    MenuName = "[Configdata_Per]";
                }

                if (e_colIndex == 9)
                {
                    MenuName = "[Approvdata_per]";
                }
            

            con.Open();
            string sql = "Update  [dbo].[TB_PermissionMenu] SET " + MenuName + "=" + Status_Change + " WHERE [ID_Menu] =" + id_menu + " AND [ID_Per]=" + id_per + "";

            SqlCommand CM2 = new SqlCommand(sql, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();

            Msg = "Update Permission on Menu!";
            Log_OldValue = MenuName + " = " + Status_Change.ToString().Trim() +
                    "," + "WHERE ID_Menu = " + id_menu + " and ID_Pur = " + id_per;

            Log_NewValue = "-";
            Class_Log CL = new Class_Log();
            CL.tbname = Msg;
            CL.oldvalue = Log_OldValue;
            CL.newvalue = Log_NewValue;
            CL.Save_log();

            Load_DTGPermission();
        }

        private void dtg_menu_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            e_rowIndex = e.RowIndex;
            e_colIndex = e.ColumnIndex;
            id_menu = Convert.ToInt32(dtg_menu.Rows[e.RowIndex].Cells[3].Value.ToString().Trim());
            id_per = Convert.ToInt32(dtg_menu.Rows[e.RowIndex].Cells[0].Value.ToString());

            Update_DataUser();
        }

        private void dtg_setting_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            e_rowIndex = e.RowIndex;
            e_colIndex = e.ColumnIndex;
            id_menu = Convert.ToInt32(dtg_setting.Rows[e.RowIndex].Cells[10].Value.ToString().Trim());
            id_per = Convert.ToInt32(dtg_setting.Rows[e.RowIndex].Cells[0].Value.ToString());

            Update_DataUser();
        }

        private void dtg_process_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            e_rowIndex = e.RowIndex;
            e_colIndex = e.ColumnIndex;
            id_menu = Convert.ToInt32(dtg_process.Rows[e.RowIndex].Cells[10].Value.ToString().Trim());
            id_per = Convert.ToInt32(dtg_process.Rows[e.RowIndex].Cells[0].Value.ToString());

            Update_DataUser();
        }

        private void dtg_report_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            e_rowIndex = e.RowIndex;
            e_colIndex = e.ColumnIndex;
            id_menu = Convert.ToInt32(dtg_report.Rows[e.RowIndex].Cells[3].Value.ToString().Trim());
            id_per = Convert.ToInt32(dtg_report.Rows[e.RowIndex].Cells[0].Value.ToString());

            Update_DataUser();
        }

        private void dtg_subsetting_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            e_rowIndex = e.RowIndex;
            e_colIndex = e.ColumnIndex;
            id_menu = Convert.ToInt32(dtg_subsetting.Rows[e.RowIndex].Cells[3].Value.ToString().Trim());
            id_per = Convert.ToInt32(dtg_subsetting.Rows[e.RowIndex].Cells[0].Value.ToString());

            Update_DataUser();
        }
    }
}
