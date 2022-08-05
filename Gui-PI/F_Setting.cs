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

namespace Gui_PI
{
    public partial class F_Setting : Form
    {
        public F_Setting()
        {
            InitializeComponent();
        }

        int Count_Uid = 0;

        private void F_Setting_Load(object sender, EventArgs e)
        {
            Load_User();
        }

        private void Load_User()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            //prot_form
            dtg_user.DataSource = null;
            string sql1 = "SELECT [U_No] AS 'ลำดับ',[U_ID] AS 'ไอดีเข้าระบบ', [U_FullName] AS 'ชื่อ-นามสกุล',[U_Status] AS 'เปิดใช้งาน',[U_Setup] AS 'ตั้งค่าข้อมูล',[U_InsertData] AS 'บันทึกข้อมูล',[U_EditData] AS 'แก้ไขข้อมูล',[U_Setting] AS 'ตั้งค่าโปรแกรม' FROM [dbo].[TB_User] ";

            SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "g_user");
            dtg_user.DataSource = ds1.Tables["g_user"];

            dtg_user.Columns[0].Width = 80;
            dtg_user.Columns[1].Width = 120;
            dtg_user.Columns[2].Width = 180;

            dtg_user.Columns[0].ReadOnly = true;
            dtg_user.Columns[1].ReadOnly = true;
            Set_BGcolor();
        }

        private void btn_findUserAD_Click(object sender, EventArgs e)
        {
            F_UserAD FAD = new F_UserAD();
            FAD.ShowDialog();
            txt_userAD.Text = FAD.id_user.Trim();
        }

        private void btn_savePermission_Click(object sender, EventArgs e)
        {
            Check_SaveDuplicate();

            if (Count_Uid == 0)
            {
                Save_Recoad();
            }

            else { MessageBox.Show("ไอดีผู้ใช้นี้ได้ถูกบันทึกไปแล้ว","บันทึกข้อมูลผิดพลาด!!",MessageBoxButtons.OK,MessageBoxIcon.Error); txt_userAD.Clear(); }
            Load_User();
        }

        private void Check_SaveDuplicate()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            string sql3 = "Select Count([U_ID]) AS 'ID_Dup' FROM [dbo].[TB_User]  Where [U_ID] ='" + txt_userAD.Text.Trim() + "'";
            SqlCommand CM3 = new SqlCommand(sql3, con);
            SqlDataReader DR3 = CM3.ExecuteReader();
            DR3.Read();
            {
                Count_Uid =Convert.ToInt16(DR3["ID_Dup"].ToString());  
            }
            DR3.Close();
            con.Close();
        }

        private void Save_Recoad()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            //con.Open();
            string sql2 = "Insert Into [TB_User] ([U_ID],[U_FullName]) Values('" + txt_userAD.Text.Trim() + "', '" + txt_name_surname.Text.Trim() + "')";

            con.Open();
            SqlCommand CM2 = new SqlCommand(sql2, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();


        }

        int e_index = 0;
        int c_index = 0;
        private void Update_Recoad()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            //con.Open();

            string Value = "";
            int s_bit = 0;

            if (c_index == 2) //update name&sur
            {
                Value = "[U_FullName] ='"+ dtg_user.Rows[e_index].Cells[2].Value.ToString()+"'";
            }

            if (c_index == 3) //update status
            {
                if (dtg_user.Rows[e_index].Cells[3].Value.ToString() == "True") { s_bit = 1; }
                Value = "[U_Status] =" + s_bit.ToString();
            }

            if (c_index == 4) //update setup data
            {
                if (dtg_user.Rows[e_index].Cells[4].Value.ToString() == "True") { s_bit = 1; }
                Value = "[U_Setup] =" + s_bit.ToString();
            }

            if (c_index == 5) //update insert data
            {
                if (dtg_user.Rows[e_index].Cells[5].Value.ToString() == "True") { s_bit = 1; }
                Value = "[U_InsertData] =" + s_bit.ToString();
            }
            
            if (c_index == 6) //update setting programs
            {
                if (dtg_user.Rows[e_index].Cells[6].Value.ToString() == "True") { s_bit = 1; }
                Value = "[U_EditData] =" + s_bit.ToString();
            }

            if (c_index == 7) //update setting programs
            {
                if (dtg_user.Rows[e_index].Cells[7].Value.ToString() == "True") { s_bit = 1; }
                Value = "[U_Setting] =" + s_bit.ToString();
            }

            string sql2 = "Update [TB_User]  Set "+ Value + " Where [U_No]=" + dtg_user.Rows[e_index].Cells[0].Value.ToString() + "";

            con.Open();
            SqlCommand CM2 = new SqlCommand(sql2, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();

            Set_BGcolor();
        }

        private void Set_BGcolor()
        {
            for (int i = 0; i < dtg_user.RowCount; i++)
            {
                if (dtg_user.Rows[i].Cells[3].Value.ToString() == "True")
                {
                    dtg_user.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                }
                else { dtg_user.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke; }

                if (dtg_user.Rows[i].Cells[4].Value.ToString() == "True")
                {
                    dtg_user.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                }
                else { dtg_user.Rows[i].Cells[4].Style.BackColor = Color.WhiteSmoke; }

                if (dtg_user.Rows[i].Cells[5].Value.ToString() == "True")
                {
                    dtg_user.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                }
                else { dtg_user.Rows[i].Cells[5].Style.BackColor = Color.WhiteSmoke; }

                if (dtg_user.Rows[i].Cells[6].Value.ToString() == "True")
                {
                    dtg_user.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                }
                else { dtg_user.Rows[i].Cells[6].Style.BackColor = Color.WhiteSmoke; }
            }


        }

        private void dtg_user_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            e_index = e.RowIndex;
            c_index = e.ColumnIndex;
            Update_Recoad();
        }
    }
}
