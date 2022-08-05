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
    public partial class F_User : Form
    {
        public F_User()
        {
            InitializeComponent();
        }


       string Msg = "";
       string Log_NewValue = "";
       string Log_OldValue = "-";

        private void F_User_Load(object sender, EventArgs e)
        {
            Load_User();
            Load_LeadUser();
            Load_Department();
        }
                      
        int id_user = 0;
        private void Load_User()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            DataSet ds = new DataSet();
            string sql = "SELECT [UserID] AS 'รหัส' ,[User_AD] AS 'ชื่อเข้าระบบ',[FullUserName] AS 'ชื่อ-นามสกุล' ,[Email] AS 'อีเมล์' ,[Lead_Name] AS 'หัวหน้าอนุมัติ',[Status_Active] AS 'สถานะ',[Lead_No] FROM [dbo].[V_User]";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds, "v_user");
            dtg_User.DataSource = ds.Tables["v_user"];
            con.Close();

            dtg_User.Columns[0].Width = 100;
            dtg_User.Columns[1].Width = 120;
            dtg_User.Columns[2].Width = 200;
            dtg_User.Columns[3].Width = 200;
            dtg_User.Columns[5].Width = 100;
            dtg_User.Columns[6].Width = 0;
        }

        private void btn_savePermission_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            int Status_Active = 0;

            if (chk_Status_Active.Checked == true)
            {
                Status_Active = 1;
            }

            if (chk_addDatapermission.Checked == true)  // insert
            {
                con.Open();
                string sql = "Insert Into  [dbo].[TB_Users] ([User_AD],[FullUserName],[Email],[Lead_Approved],[ID_Dept],[Status_Active]) Values('" + txt_userAD.Text.Trim() + "', '" + txt_name_surname.Text.Trim() + "', '" + txt_email.Text.Trim() + "', " + cb_leadApproved.SelectedValue.ToString() + "," + cb_dept.SelectedValue.ToString() + "," + Status_Active + ")";

                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();

                Msg = "New User Profile!";
                Log_NewValue = "User AD: " + txt_userAD.Text.Trim();
            }

            else // update
            {
                con.Open();
                string sql = "Update  [dbo].[TB_Users] SET [User_AD]='" + txt_userAD.Text.Trim() + "',[FullUserName]= '" + txt_name_surname.Text.Trim() + "',[Email]= '" + txt_email.Text.Trim() + "',[Lead_Approved]=" + cb_leadApproved.SelectedValue.ToString() + ",[ID_Dept] =" + cb_dept.SelectedValue.ToString() + ",[Status_Active]=" + Status_Active + " WHERE [UserID]=" + id_user + "";

                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();

                Msg = "Update User Profile!";
                Log_NewValue = "User AD: " + txt_userAD.Text.Trim();
            }

        
            Class_Log CL = new Class_Log();
            CL.tbname = Msg;
            CL.oldvalue = Log_OldValue;
            CL.newvalue = Log_NewValue;
            CL.Save_log();


            Load_User();
            Clear_data();

        }

        private void dtg_User_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                chk_addDatapermission.Checked = false;
                id_user = Convert.ToInt16(dtg_User.Rows[e.RowIndex].Cells[0].Value.ToString());
                txt_userAD.Text = dtg_User.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_name_surname.Text = dtg_User.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_email.Text = dtg_User.Rows[e.RowIndex].Cells[3].Value.ToString();
                cb_leadApproved.SelectedValue= dtg_User.Rows[e.RowIndex].Cells[6].Value.ToString();

                if (dtg_User.Rows[e.RowIndex].Cells[6].Value == "True")
                { chk_Status_Active.Checked = true; }
                else { chk_Status_Active.Checked = true;  }

            }
        }

        private void Load_LeadUser()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand(" Select [UserID],[FullUserName]  From  [dbo].[TB_Users]", con);
            DataSet ds = new DataSet();
            //ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            //Load product tab weight scale Setup
            cb_leadApproved.DataSource = ds.Tables[0];
            cb_leadApproved.DisplayMember = "FullUserName";
            cb_leadApproved.ValueMember = "UserID";
        }

        private void Load_Department()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand(" Select [ID_Dept],[Name_Dept]  From  [dbo].[TB_Department]", con);
            DataSet ds = new DataSet();
            //ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            //Load product tab weight scale Setup
            cb_dept.DataSource = ds.Tables[0];
            cb_dept.DisplayMember = "Name_Dept";
            cb_dept.ValueMember = "ID_Dept";
        }


        private void btn_findUserAD_Click(object sender, EventArgs e)
        {
            F_UserAD fud = new F_UserAD();
            fud.ShowDialog();

            txt_userAD.Text = fud.id_user;
            txt_email.Text = fud.email_user;
            txt_name_surname.Focus();
        }

        private void chk_addDatapermission_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_addDatapermission.Checked == true)
            { btn_findUserAD.Enabled = true; }
            else { btn_findUserAD.Enabled = false; }
        }

        private void Clear_data()
        {
            txt_email.Clear();
            txt_name_surname.Clear();
            txt_userAD.Clear();
            id_user = 0;
            chk_addDatapermission.Checked = false;

        }
    }
}
