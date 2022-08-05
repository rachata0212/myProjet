using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Data.SqlClient;

namespace Gui_PI
{
    public partial class F_Mainpage : Form
    {
        public F_Mainpage()
        {
            InitializeComponent();
        }

        int STS_edit = 0;
        private void btn_setData_Click(object sender, EventArgs e)
        {
            F_Setup FS = new F_Setup();
            FS.ShowDialog();
        }

        private void btn_imputData_Click(object sender, EventArgs e)
        {
            F_InputData FIP = new F_InputData();
            FIP.STS_edit = STS_edit;
            FIP.ShowDialog();
        }

        private void btn_setup_Click(object sender, EventArgs e)
        {
            F_Setting FTT = new F_Setting();
            FTT.ShowDialog();
        }

        private string GetIPAddress()
        {
            StringBuilder sb = new StringBuilder();
            String strHostName = string.Empty;
            strHostName = Dns.GetHostName();
            //sb.Append("The Local Machine Host Name: " + strHostName);
            //sb.AppendLine();
            IPHostEntry ipHostEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] address = ipHostEntry.AddressList;
            sb.Append(address[1].ToString());
            sb.AppendLine();
            return sb.ToString();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult answer;
            answer = MessageBox.Show("คุณต้องการออกจากโปรแกรมใช่หรือไม่? ", "กรุณายืนยัน", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (answer == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void F_Mainpage_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            Load_ConnecDB();

            F_Login flg = new F_Login();
            flg.ShowDialog();

            if (Program.user_id != "" && flg.IDUser_Enable == 1)
            {
                //check permission     
                //this.WindowState = FormWindowState.Normal;

                Program.MachineName = Environment.MachineName.ToString();
                Program.LocalIpAddress = GetIPAddress();
                Check_Permission();
                this.WindowState = FormWindowState.Normal;
            }

            else
            {
                Application.Exit();
            }
        }

        private void Check_Permission()
        {
            SqlConnection con = new SqlConnection(Program.pahtdb);
            con.ConnectionString = Program.pahtdb;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
            string sql3 = "Select [U_Setup],[U_InsertData],[U_Setting],[U_EditData] FROM [dbo].[TB_User]  Where [U_ID] ='" + Program.user_id + "'";
            SqlCommand CM3 = new SqlCommand(sql3, con);
            SqlDataReader DR3 = CM3.ExecuteReader();
            DR3.Read();
            {
                if (DR3["U_Setup"].ToString().Trim() == "True")
                {
                    btn_settingData.Enabled = true; lbl_setData.Enabled = true;
                }

                if (DR3["U_InsertData"].ToString().Trim() == "True")
                {
                    btn_saveData.Enabled = true;lbl_saveData.Enabled = true;
                }
                
                if (DR3["U_Setting"].ToString().Trim() == "True")
                {
                    btn_setupProgram.Enabled = true;lbl_setProgram.Enabled = true;
                }

                if (DR3["U_EditData"].ToString().Trim() == "True")
                {
                    STS_edit = 1;
                }
                else { STS_edit = 0; }

            }
            DR3.Close();
            con.Close();
        }
        private void Load_ConnecDB()
        {

            StreamReader sw = new StreamReader(Application.StartupPath + "\\cnDB.dll");
            string connecpovider = sw.ReadToEnd();

            try
            {
                Program.CN = new SqlConnection();
                Program.CN.ConnectionString = connecpovider;
                Program.pahtdb = connecpovider;
            }
            catch
            {
                //MessageBox.Show("Is Not Connection to Database..", "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();

                DialogResult answer;
                answer = MessageBox.Show("Database Navision Is't Connect!! Pls. check CN1.dll in Debug Folder!! ", "Connection to Databas Failed", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (answer == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }



    }
}
