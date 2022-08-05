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
    public partial class F_SelectAlert : Form
    {
        public F_SelectAlert()
        {
            InitializeComponent();
        }

        public int Type_Lab = 0;
        public int ID_Lab = 0;
        public string data_info="";
        public int ID_AlertRP = 0;
        private void F_SelectOption_Load(object sender, EventArgs e)
        {
            txt_dt_info.Text = data_info;

            Load_DTGUser_Report();
            Check_EnableStatus();

        }

        private void Check_EnableStatus()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            for (int i = 0; i < dtg_setup.RowCount; i++)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                else { con.Open(); }

                if (Type_Lab == 1)
                {
                    dtg_setup.Rows[i].Cells[4].Value = false;
                    dtg_setup.Rows[i].Cells[5].Value = false;
                }

                if (Type_Lab == 2)
                {
                    dtg_setup.Rows[i].Cells[3].Value = false;
                    dtg_setup.Rows[i].Cells[4].Value = false;
                }
                
               
                con.Open();
                string sql4 = "SELECT [Alert_Sts],[App_Sts],[ID_ALRP] FROM [dbo].[TB_AlertRP_Detail] WHERE [ID_ALRP] = " + ID_AlertRP + " AND [ID_Value]=" + dtg_setup.Rows[i].Cells[0].Value.ToString() + "";
                SqlCommand CM4 = new SqlCommand(sql4, con);
                SqlDataReader DR4 = CM4.ExecuteReader();

                DR4.Read();
                {
                    try
                    {
                        if (Type_Lab == 1)
                        {
                            if (DR4["Alert_Sts"].ToString() == "True")
                            {
                                dtg_setup.Rows[i].Cells[4].Value = true;
                            }

                            if (DR4["App_Sts"].ToString() == "True")
                            {
                                dtg_setup.Rows[i].Cells[5].Value = true; ;
                            }                           
                          
                        }

                        if (Type_Lab == 2)
                        {
                            if (DR4["Alert_Sts"].ToString() == "True")
                            {
                                dtg_setup.Rows[i].Cells[3].Value = true;
                            }

                            if (DR4["App_Sts"].ToString() == "True")
                            {
                                dtg_setup.Rows[i].Cells[4].Value = true; ;
                            }
                        }


                    }
                    catch { }
                }
                DR4.Close();
                //con.Close();
            }                     

            con.Close();

        }

        private void Load_DTGUser_Report()
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                con.ConnectionString = Program.pathdb_Weight;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                dtg_setup.Columns.Clear();
                dtg_setup.DataSource = null;

                string sql1 = "";

                if (Type_Lab == 1)  // type การบันทึกแบบใช้เครื่องมือ                         

                {
                    sql1 = "SELECT [LOGID] AS 'รหัส' ,[Min] AS 'ค่าเริ่มต้น' ,[Max] AS 'ค่าสิ้นสุด',[Rate] AS 'ค่าที่นำไปคิด'  FROM [dbo].[TB_ValueLab] WHERE [LabID]=" + ID_Lab + "AND [DeductActive] =1 AND [Alert_Lab]=1 ";
                }

                if (Type_Lab == 2)  //การบันทึกแบบกายภาพ                                

                {
                    sql1 = "SELECT [ValueVisualNo] AS 'รหัส' ,[ValueName] AS 'ค่าที่แสดงวิเคราะห์' ,[Value1] AS 'ค่าที่นำไปคิด'   FROM [dbo].[TB_Valuevisual] Where [LabID]=" + ID_Lab + "AND [VisualActive] =1 AND [Alert_VS]=1 ";
                }

                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "report");
                dtg_setup.DataSource = ds1.Tables["report"];
                con.Close();
                               
                DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
                dgvCmb.ValueType = typeof(bool);
                dgvCmb.Name = "Chk_Alert";
                dgvCmb.HeaderText = "เปิดการเตือน";
                dtg_setup.Columns.Add(dgvCmb);                              
     
                DataGridViewCheckBoxColumn Col_CheckAlert = new DataGridViewCheckBoxColumn();
                Col_CheckAlert.ValueType = typeof(bool);
                Col_CheckAlert.Name = "Chk_App";
                Col_CheckAlert.HeaderText = "เปิดการอนุมัติ";
                dtg_setup.Columns.Add(Col_CheckAlert);



                dtg_setup.Columns[0].Width = 60;
                dtg_setup.Columns[0].ReadOnly = true;

                if (Type_Lab == 1)
                {
                    dtg_setup.Columns[1].Width = 100;
                    dtg_setup.Columns[2].Width = 100;
                    dtg_setup.Columns[3].Width = 140;
                    dtg_setup.Columns[1].ReadOnly = true;
                    dtg_setup.Columns[2].ReadOnly = true;
                    dtg_setup.Columns[3].ReadOnly = true;
                                                
                    dtg_setup.Columns[4].DefaultCellStyle.BackColor = Color.LemonChiffon;
                    dtg_setup.Columns[5].DefaultCellStyle.BackColor = Color.Salmon;
                 

                    this.dtg_setup.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (Type_Lab == 2)
                {
                    dtg_setup.Columns[1].Width = 160;
                    //dtg_setup.Columns[2].Width = 120;
                    dtg_setup.Columns[1].ReadOnly = true;
                    dtg_setup.Columns[2].ReadOnly = true;

                    dtg_setup.Columns[2].Width = 120;              
                    dtg_setup.Columns[2].DefaultCellStyle.BackColor = Color.LemonChiffon;
                    dtg_setup.Columns[3].DefaultCellStyle.BackColor = Color.Salmon;
                    dtg_setup.Columns[4].DefaultCellStyle.BackColor = Color.Salmon;

                    this.dtg_setup.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                }

            }
            catch { }


        }

        private void dtg_setup_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (Type_Lab == 1 && e.ColumnIndex == 5 && dtg_setup.Rows[e.RowIndex].Cells[5].Value.ToString() != "")
                //{
                //    int x = Convert.ToInt16(dtg_setup.Rows[e.RowIndex].Cells[5].Value.ToString());
                if (Type_Lab==2 && e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5 )
                {

                    SqlConnection con = new SqlConnection(Program.pathdb_Weight);
                    con.ConnectionString = Program.pathdb_Weight;
                    SqlDataAdapter dtAdapter = new SqlDataAdapter();
                    con.Open();
                    int CountCheck = 0;
                    string sql1 = "SELECT Count([ID_ALRP])AS 'Record' FROM [dbo].[TB_AlertRP_Detail] WHERE [ID_ALRP] = " + ID_AlertRP + " AND [ID_Value]=" + dtg_setup.Rows[e.RowIndex].Cells[0].Value.ToString() + " ";

                    SqlCommand CM1 = new SqlCommand(sql1, con);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    {
                        CountCheck = Convert.ToInt16(DR1["Record"].ToString());
                    }
                    DR1.Close();
                    con.Close();

                    int Alert_Sts = 0;
                    int App_Sts = 0;
                    //    int StS_mail = 0;
                    //    int StS_line = 0;
                    //    if (chk_alert.Checked == true) { StS_Alert = 1; }
                    //    if (chk_enableMailservice.Checked == true) { StS_mail = 1; }
                    //    if (chk_enableLineservice.Checked == true) { StS_line = 1; }

                    if (Type_Lab == 1)
                    {
                        if (dtg_setup.Rows[e.RowIndex].Cells[4].Value.ToString() == "True")
                        {
                            Alert_Sts = 1;
                        }
                        if (dtg_setup.Rows[e.RowIndex].Cells[5].Value.ToString() == "True")
                        {
                            App_Sts = 1;
                        }
                    }

                    if (Type_Lab == 2)
                    {
                        if (dtg_setup.Rows[e.RowIndex].Cells[3].Value.ToString() == "True")
                        {
                            Alert_Sts = 1;
                        }
                        if (dtg_setup.Rows[e.RowIndex].Cells[4].Value.ToString() == "True")
                        {
                            App_Sts = 1;
                        }
                    }

                    if (CountCheck == 0)  //Insert
                    {
                        

                        con.Open();
                        string sql2 = "Insert Into [dbo].[TB_AlertRP_Detail] ([ID_ALRP],[ID_Value],[Alert_Sts],[App_Sts],[ID_Frm_TypeLab]) Values(" + ID_AlertRP + ",'" + dtg_setup.Rows[e.RowIndex].Cells[0].Value.ToString() + "'," + Alert_Sts + "," + App_Sts + "," + Type_Lab + ")";

                        SqlCommand CM2 = new SqlCommand(sql2, con);
                        SqlDataReader DR2 = CM2.ExecuteReader();
                        con.Close();

                        //        //Select Max ID from Table Alert == X
                        //        con.Open();
                        //        string sql3 = "SELECT Max([ID_AL]) AS 'New_ID'  FROM [dbo].[TB_Alert] ";
                        //        SqlCommand CM3 = new SqlCommand(sql3, con);
                        //        SqlDataReader DR3 = CM3.ExecuteReader();

                        //        DR3.Read();
                        //        {
                        //            New_ID = Convert.ToInt16(DR3["New_ID"].ToString().Trim());
                        //        }
                        //        DR3.Close();
                        //        con.Close();

                        //        con.Open();
                        //        string sql4 = "Insert Into [dbo].[TB_AlertDetail] ([ID_AL],[ID_ALtype],[ID_ALdStatus]) Values(" + New_ID + ",1, " + StS_mail + ")";
                        //        SqlCommand CM4 = new SqlCommand(sql4, con);
                        //        SqlDataReader DR4 = CM4.ExecuteReader();
                        //        con.Close();

                        //        con.Open();
                        //        string sql5 = "Insert Into [dbo].[TB_AlertDetail] ([ID_AL],[ID_ALtype],[ID_ALdStatus]) Values(" + New_ID + ",2, " + StS_line + ")";
                        //        SqlCommand CM5 = new SqlCommand(sql5, con);
                        //        SqlDataReader DR5 = CM5.ExecuteReader();
                        //        con.Close();
                        //    }


                        //    else   // Update config
                        //    {
                        //        con.Open();
                        //        string sql6 = "SELECT [ID_AL] AS 'New_ID'  FROM [dbo].[TB_Alert] WHERE   [ID_Menu] = " + cb_menuAlert.SelectedValue.ToString() + " AND [ProductID]='" + cb_product_Alert.SelectedValue.ToString() + "' AND [LabID] = " + cb_typeLabAlert.SelectedValue.ToString() + "";
                        //        SqlCommand CM6 = new SqlCommand(sql6, con);
                        //        SqlDataReader DR6 = CM6.ExecuteReader();

                        //        DR6.Read();
                        //        {
                        //            New_ID = Convert.ToInt16(DR6["New_ID"].ToString().Trim());
                        //        }
                        //        DR6.Close();
                        //        con.Close();

                        //        con.Open();
                        //        string sql2 = "Update [dbo].[TB_Alert] Set [ID_ALStatus] =" + StS_Alert + " WHERE [ID_AL] = " + New_ID + "";
                        //        SqlCommand CM2 = new SqlCommand(sql2, con);
                        //        SqlDataReader DR2 = CM2.ExecuteReader();
                        //        con.Close();


                        //        con.Open();
                        //        string sql3 = "Update [dbo].[TB_AlertDetail]  Set [ID_ALdStatus] = " + StS_mail + " WHeRE [ID_AL]=" + New_ID + " AND [ID_ALtype]=1";
                        //        SqlCommand CM3 = new SqlCommand(sql3, con);
                        //        SqlDataReader DR3 = CM3.ExecuteReader();
                        //        con.Close();

                        //        con.Open();
                        //        string sql4 = "Update [dbo].[TB_AlertDetail]  Set [ID_ALdStatus] = " + StS_line + " WHeRE [ID_AL]=" + New_ID + " AND [ID_ALtype]=2";
                        //        SqlCommand CM4 = new SqlCommand(sql4, con);
                        //        SqlDataReader DR4 = CM4.ExecuteReader();
                        //        con.Close();

                        //    }

                        //    btn_saveAlert.Enabled = false;
                        //    dtg_alert_User.Enabled = true;
                        //    dtg_alert_approval.Enabled = true;


                        //}
                    }

                    else
                    {
                        con.Open();
                        string sql2 = "Update [dbo].[TB_AlertRP_Detail] Set [Alert_Sts] = " + Alert_Sts + ",[App_Sts]= " + App_Sts + ",[ID_Frm_TypeLab]=" + Type_Lab + "  WHERE [ID_ALRP] =" + ID_AlertRP + " AND [ID_Value]=" + dtg_setup.Rows[e.RowIndex].Cells[0].Value.ToString() + "";

                        SqlCommand CM2 = new SqlCommand(sql2, con);
                        SqlDataReader DR2 = CM2.ExecuteReader();
                        con.Close();

                    }
                }
            }
            catch
            {
                  
            }


        }
    }
}
