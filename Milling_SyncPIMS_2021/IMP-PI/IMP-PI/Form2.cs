using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

namespace IMP_PI
{
    public partial class Form2 : Form
    {
    
        public Form2()
        {
            InitializeComponent();
           
        }

        int Type_day;  //line 1
        int Unit_day;  //line 2
        string Time_sync;  //line 3
        string Sourc_DB;
        int id_No = 0;
        int id_Dup = 0;

        private void Form2_Load(object sender, EventArgs e)
        {
            Load_DLLconfig();
            Load_ProductMatch();
        }


        private void btn_browsfile_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Database MS-Access files (*.mdb)|*.mdb";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txt_locationfile.Text = openFileDialog.FileName;
            }
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void Load_Data()
        {
            try
            {

                string strDSN = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + txt_locationfile.Text.Trim() + "";
                string strSQL = "SELECT Top 100 SEQ,ID,Gcode,GName,CCode,CName,BatWGT,PreWgt,FreeWgt,BatNum,TotWgt,AccWgt,BalWgt,WDate FROM Prod2 Order by ID ASC";
                // create Objects of ADOConnection and ADOCommand    
                OleDbConnection myConn = new OleDbConnection(strDSN);
                OleDbDataAdapter myCmd = new OleDbDataAdapter(strSQL, myConn);
                myConn.Open();
                DataSet dtSet = new DataSet();
                myCmd.Fill(dtSet, "Dev");
                DataTable dTable = dtSet.Tables[0];
                dtg_sourceDatabase.DataSource = dtSet.Tables["Dev"].DefaultView;
                myConn.Close();

                dtg_sourceDatabase.Columns[0].Width = 70;
                dtg_sourceDatabase.Columns[5].Width = 160;
                dtg_sourceDatabase.Columns[11].Width = 100;
                dtg_sourceDatabase.Columns[13].Width = 100;

                this.dtg_sourceDatabase.Columns[0].DefaultCellStyle.BackColor = Color.LightBlue;
                this.dtg_sourceDatabase.Columns[1].DefaultCellStyle.BackColor = Color.LightBlue;
                this.dtg_sourceDatabase.Columns[3].DefaultCellStyle.BackColor = Color.LightBlue;
                this.dtg_sourceDatabase.Columns[11].DefaultCellStyle.BackColor = Color.LightBlue;
                this.dtg_sourceDatabase.Columns[13].DefaultCellStyle.BackColor = Color.LightBlue;

            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }



        }

        private void btn_savedb_Click(object sender, EventArgs e)
        {
            Save_DLLconfig();
        }


        private void Load_DLLconfig()
        {
            try
            {

                string filename = Application.StartupPath + "\\config.dll";

                if (System.IO.File.Exists(filename))
                {
                    System.IO.StreamReader StrRer = new System.IO.StreamReader(filename);

                    List<string> listStr = new List<string>();

                    while (!StrRer.EndOfStream)
                    {
                        listStr.Add(StrRer.ReadLine());
                    }

                    txt_locationfile.Text = listStr[0].ToString();

                    Type_day = Convert.ToInt16(listStr[1].ToString());
                    if (Type_day == 0) { rdo_bf.Checked = true; }
                    if (Type_day == 1) { rdo_af.Checked = true; }

                    Unit_day = Convert.ToInt16(listStr[2].ToString());
                    cbo_unitday.Text = Unit_day.ToString();

                    Time_sync = listStr[3].ToString();
                    if (Time_sync == "00") { rdo_00.Checked = true; }
                    if (Time_sync == "01") { rdo_01.Checked = true; }
                    if (Time_sync == "02") { rdo_02.Checked = true; }
                    if (Time_sync == "03") { rdo_03.Checked = true; }
                    if (Time_sync == "04") { rdo_04.Checked = true; }
                    if (Time_sync == "05") { rdo_05.Checked = true; }
                    if (Time_sync == "06") { rdo_06.Checked = true; }
                    if (Time_sync == "07") { rdo_07.Checked = true; }
                    if (Time_sync == "08") { rdo_08.Checked = true; }
                    if (Time_sync == "09") { rdo_09.Checked = true; }
                    if (Time_sync == "10") { rdo_10.Checked = true; }
                    if (Time_sync == "11") { rdo_11.Checked = true; }
                    if (Time_sync == "12") { rdo_12.Checked = true; }
                    if (Time_sync == "13") { rdo_13.Checked = true; }
                    if (Time_sync == "14") { rdo_14.Checked = true; }
                    if (Time_sync == "15") { rdo_15.Checked = true; }
                    if (Time_sync == "16") { rdo_16.Checked = true; }
                    if (Time_sync == "17") { rdo_17.Checked = true; }
                    if (Time_sync == "18") { rdo_18.Checked = true; }
                    if (Time_sync == "19") { rdo_19.Checked = true; }
                    if (Time_sync == "20") { rdo_20.Checked = true; }
                    if (Time_sync == "21") { rdo_21.Checked = true; }
                    if (Time_sync == "22") { rdo_22.Checked = true; }
                    if (Time_sync == "23") { rdo_23.Checked = true; }
                    else { Time_sync = "24"; }

                    StrRer.Close();
                }
            }
            catch { }
        }

        private void Load_ProductMatch()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.cn_dbConfig);
                con.ConnectionString = Program.cn_dbConfig;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                //prot_form
                //dtg_Rectime.DataSource = null;
                string sql1 = "Select * From [TB_ProductMilling]";               

                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "g_rectime");
                dtg_productMatch.DataSource = ds1.Tables["g_rectime"];
                con.Close();

                dtg_productMatch.Columns[0].Width = 80;
                dtg_productMatch.ClearSelection();
            }
            catch { }
        }

        private void btn_savetimesync_Click(object sender, EventArgs e)
        {
            Save_DLLconfig();
        }


        private void Save_DLLconfig()
        {
            Sourc_DB = txt_locationfile.Text.Trim();

            if (rdo_bf.Checked == true) { Type_day = 0; }
            if (rdo_af.Checked == true) { Type_day = 1; }
            Unit_day = Convert.ToInt16(cbo_unitday.Text);

            if (rdo_00.Checked == true) { Time_sync = "00"; }
            if (rdo_01.Checked == true) { Time_sync = "01"; }
            if (rdo_02.Checked == true) { Time_sync = "02"; }
            if (rdo_03.Checked == true) { Time_sync = "03"; }
            if (rdo_04.Checked == true) { Time_sync = "04"; }
            if (rdo_05.Checked == true) { Time_sync = "05"; }
            if (rdo_06.Checked == true) { Time_sync = "06"; }
            if (rdo_07.Checked == true) { Time_sync = "07"; }
            if (rdo_08.Checked == true) { Time_sync = "08"; }
            if (rdo_09.Checked == true) { Time_sync = "09"; }
            if (rdo_10.Checked == true) { Time_sync = "10"; }
            if (rdo_11.Checked == true) { Time_sync = "11"; }
            if (rdo_12.Checked == true) { Time_sync = "12"; }
            if (rdo_13.Checked == true) { Time_sync = "13"; }
            if (rdo_14.Checked == true) { Time_sync = "14"; }
            if (rdo_15.Checked == true) { Time_sync = "15"; }
            if (rdo_16.Checked == true) { Time_sync = "16"; }
            if (rdo_17.Checked == true) { Time_sync = "17"; }
            if (rdo_18.Checked == true) { Time_sync = "18"; }
            if (rdo_19.Checked == true) { Time_sync = "19"; }
            if (rdo_20.Checked == true) { Time_sync = "20"; }
            if (rdo_21.Checked == true) { Time_sync = "21"; }
            if (rdo_22.Checked == true) { Time_sync = "22"; }
            if (rdo_23.Checked == true) { Time_sync = "23"; }


            string path = Application.StartupPath + "\\config.dll";
            //save to index line
            string[] lines = {Sourc_DB,Type_day.ToString(),Unit_day.ToString(),Time_sync.ToString()};
            File.WriteAllLines(path, lines);

            MessageBox.Show("Save path database complted!", "Save Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(Program.cn_dbConfig);
                con.ConnectionString = Program.cn_dbConfig;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
            try
            {
                Check_DataDuplicate();
                string sql = "";

                if (id_Dup == 0)
                {
                    if (chk_new.Checked == true)
                    {
                        sql = "Insert Into [TB_ProductMilling] ([IDPro_Milling],[IDPro_PIMS],[Pro_Name],[Remark]) Values('" + txt_idmilling.Text.Trim() + "', '" + txt_idpims.Text.Trim() + "', '" + txt_pdName.Text.Trim() + "', '" + txt_remark.Text.Trim() + "')";
                    }
                }
                
                if (chk_new.Checked == false)
                {
                    sql = "Update [TB_ProductMilling] Set [IDPro_Milling]='" + txt_idmilling.Text.Trim() + "',[IDPro_PIMS]= '" + txt_idpims.Text.Trim() + "',[Pro_Name]= '" + txt_pdName.Text.Trim() + "',[Remark]= '" + txt_remark.Text.Trim() + "' ";
                }

                //else
                //{
                //    MessageBox.Show("คุณใส่ข้อมูลซ้ำรหัสสินค้าซ้ำ กรุณาตรวจสอบข้อมูลอีกครั้ง", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                
                con.Open();
                SqlCommand CM2 = new SqlCommand(sql, con);
                SqlDataReader DR2 = CM2.ExecuteReader();
                con.Close();
                MessageBox.Show("บันทึกข้อมูลสำเร็จ", "รายงานการบันทึก", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_ProductMatch();
                CLS_Object();                               

            }
            catch
            {
                MessageBox.Show("คุณใส่ข้อมูลไม่ถูกต้อง กรุณาตรวจสอบข้อมูลอีกครั้ง", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }

        }

        private void Check_DataDuplicate()
        {
            SqlConnection con = new SqlConnection(Program.cn_dbConfig);
            con.ConnectionString = Program.cn_dbConfig;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            con.Open();
            string sql = "Select Count([IDPro_Milling]) AS 'ID_Dup' FROM [dbo].[TB_ProductMilling]  Where [IDPro_Milling] ='" + txt_idmilling.Text.Trim() + "' ";
            SqlCommand CM = new SqlCommand(sql, con);
            SqlDataReader DR = CM.ExecuteReader();

            DR.Read();
            {
                id_Dup =Convert.ToInt16(DR["ID_Dup"].ToString());
            }
            DR.Close();
            con.Close();
        }



        private void CLS_Object()
        {
            id_No = 0;
            id_Dup = 0;
            txt_idmilling.Clear();
            txt_idpims.Clear();
            txt_pdName.Clear();
            txt_remark.Clear();
            btn_saveMatch.BackColor = Color.Black;
            btn_saveMatch.ForeColor = Color.White;
        }

        private void dtg_productMatch_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id_No = Convert.ToInt16(dtg_productMatch.Rows[e.RowIndex].Cells[0].Value.ToString());
                txt_idmilling.Text = dtg_productMatch.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_idpims.Text = dtg_productMatch.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_pdName.Text = dtg_productMatch.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_remark.Text = dtg_productMatch.Rows[e.RowIndex].Cells[4].Value.ToString();

                btn_saveMatch.BackColor = Color.LightGreen; btn_saveMatch.ForeColor = Color.Black;
            }
        }

        private void chk_new_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_new.Checked == true)
            { CLS_Object(); btn_saveMatch.BackColor = Color.LightGreen;btn_saveMatch.ForeColor = Color.Black; }

            else {

                if (txt_idmilling.Text == "")
                { btn_saveMatch.BackColor = Color.Black;btn_saveMatch.ForeColor = Color.White; }
            }
        }

        private void txt_idmilling_TextChanged(object sender, EventArgs e)
        {
            if (txt_idmilling.Text != "")
            { btn_saveMatch.BackColor = Color.Green; btn_saveMatch.ForeColor = Color.Black; }
            else { btn_saveMatch.BackColor = Color.Black; btn_saveMatch.ForeColor = Color.White; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(Program.cn_dbConfig);
            con1.ConnectionString = Program.cn_dbConfig;
            SqlDataAdapter dtAdapter1 = new SqlDataAdapter();

            SqlConnection con2 = new SqlConnection(Program.cn_sysncPI);
            con2.ConnectionString = Program.cn_sysncPI;
            SqlDataAdapter dtAdapter2 = new SqlDataAdapter();

            int Last_ID_Milling = 0;
            string ID_ProDis = "";
            int Tag_no = 0;
            string Status_Name = "Save Completed";

            con2.Open();
            string sql0 = "Select Max([ID_Milling]) AS Last_ID_Milling FROM [DBInterface_PI].[dbo].[TB_LogMilling] ";
            SqlCommand CM0 = new SqlCommand(sql0, con2);
            SqlDataReader DR0 = CM0.ExecuteReader();
            DR0.Read();
            {
                Last_ID_Milling = Convert.ToInt16(DR0["Last_ID_Milling"].ToString().Trim());
            }
            DR0.Close();
            con2.Close();


            Load_Data();


            for (int i = 0; i < dtg_sourceDatabase.RowCount; i++)
            {
                if (Last_ID_Milling < Convert.ToInt16(dtg_sourceDatabase.Rows[i].Cells[1].Value.ToString()))
                {
                    con1.Open();
                    string sql1 = "Select [IDPro_PIMS]  FROM [dbo].[TB_ProductMilling]  Where [IDPro_Milling]='" + dtg_sourceDatabase.Rows[i].Cells[2].Value.ToString().Trim() + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, con1);
                    SqlDataReader DR1 = CM1.ExecuteReader();
                    DR1.Read();
                    {
                        ID_ProDis = DR1["IDPro_PIMS"].ToString().Trim();
                    }
                    DR1.Close();
                    con1.Close();

                    //Select Tag No from Data PI setup                
                    con2.Open();
                    string sql2 = "Select [Tag_no] FROM [dbo].[V_TagRecordSetup]  Where [Tag_Name]='" + ID_ProDis.Trim() + "'";
                    SqlCommand CM2 = new SqlCommand(sql2, con2);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    DR2.Read();
                    {
                        Tag_no = Convert.ToInt16(DR2["Tag_no"].ToString().Trim());
                    }
                    DR2.Close();
                    con2.Close();

                    DateTime date1 = Convert.ToDateTime(dtg_sourceDatabase.Rows[i].Cells[13].Value.ToString().Trim());
                    string date2 = date1.ToString("MM-dd-yyyy") + ' ' + date1.ToString("08:00:00");


                    if (dtg_sourceDatabase.Rows[i].Cells[11].Value.ToString().Trim() != "0")
                    {
                        //Save Data to PIMS
                        con2.Open();
                        string sql3 = "Insert Into [TB_DataTransection] ([Tag_no],[DT_Value],[DT_TimeStamp],[DT_Time],[DT_Status]) Values(" + Tag_no + ", '" + dtg_sourceDatabase.Rows[i].Cells[11].Value.ToString().Trim() + "', '" + date2 + "','" + Time_sync.ToString() + ":00" + "',1)";

                        SqlCommand CM3 = new SqlCommand(sql3, con2);
                        SqlDataReader DR3 = CM3.ExecuteReader();
                        con2.Close();

                        //Save Log
                        con2.Open();
                        string sql4 = "Insert Into [TB_LogMilling] ([Datetime_Save],[SEQ_Milling],[ID_Milling],[Name_Pro],[ID_ProSource],[Gweith_Source],[ID_ProDis],[Gweight_Dis],[Status_Name]) Values('" + date2 + "', " + dtg_sourceDatabase.Rows[i].Cells[0].Value.ToString().Trim() + ", " + dtg_sourceDatabase.Rows[i].Cells[1].Value.ToString().Trim() + ", '" + dtg_sourceDatabase.Rows[i].Cells[3].Value.ToString().Trim() + "', '" + dtg_sourceDatabase.Rows[i].Cells[2].Value.ToString().Trim() + "', " + dtg_sourceDatabase.Rows[i].Cells[11].Value.ToString().Trim() + ", '" + ID_ProDis.Trim() + "', " + dtg_sourceDatabase.Rows[i].Cells[11].Value.ToString().Trim() + ",'" + Status_Name + "')";

                        SqlCommand CM4 = new SqlCommand(sql4, con2);
                        SqlDataReader DR4 = CM4.ExecuteReader();
                        con2.Close();
                    }

                }           

            }


            MessageBox.Show("Update Data Completed!"," Information Message",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }
    }
}
