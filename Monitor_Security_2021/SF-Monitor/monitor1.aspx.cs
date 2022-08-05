using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace SF_Monitor
{
    public partial class monitor1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                calendar.SelectedDate = DateTime.Now;
                Load_Data();
                Load_SearchDAta();
                Loop_Index();
            }

        }


        string connectionstring = @"data source=xx.xx.xx.xx;initial catalog=Tigerscan;uid=sa; pwd=0eP+1e-03_;";

        private void Load_Data()
        {
            lbl_area1.Text = "1";
            lbl_area2.Text = "1";
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = "server=xx.xx.xx.xx;initial catalog=Tigerscan;uid=sa; pwd=0eP+1e-03_;";
            CN.Open();

            //sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT DISTINCT [PersonCardID],[Date]  FROM [Tigerscan].[dbo].[rpt_Monitor] Where [Date] = '" + calendar.SelectedDate.ToString("dd/MM/yyyy") + "'  AND [MachCode]=1 ", CN);

            DataTable dt = new DataTable();
            try
            {
                sqlDa.Fill(dt);
                gv_test0.DataSource = dt;
                gv_test0.DataBind();
                CN.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CN.Close();
                CN.Dispose();
            }

            //CN.Open();
            //  dr.Close();

        }


        private void Load_SearchDAta()
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.AddRange(new DataColumn[3] { new DataColumn("PersonCardID"), new DataColumn("TimeIn"), new DataColumn("TimeOuts") });

            string result1 = "";
            string result2 = "";
            string result3 = "";

            DateTime t1 = new DateTime();
            DateTime t2 = new DateTime();

            for (int i = 0; i < gv_test0.Rows.Count; i++)
            {
                string sql = "SELECT DISTINCT[PersonCardID], (select Max([TIME] ) as maxtimeIn from [dbo].[rpt_Sapthip] where  [Date]='" + gv_test0.Rows[i].Cells[1].Text.Trim() + "' and  [MachCode]=1 aND  [InOutMode]='I' and [PersonCardID] = '" + gv_test0.Rows[i].Cells[0].Text.Trim() + "' ) AS TimeIn, (select Max([TIME] ) as maxtimeIn from [dbo].[rpt_Sapthip] where  [Date]='" + gv_test0.Rows[i].Cells[1].Text.Trim() + "' and [MachCode]=1 and [InOutMode]='O' and [PersonCardID] = '" + gv_test0.Rows[i].Cells[0].Text.Trim() + "' ) AS TimeOuts  FROM [Tigerscan].[dbo].[rpt_Sapthip]  where [Date]='" + gv_test0.Rows[i].Cells[1].Text.Trim() + "'   and [MachCode]=1 and [PersonCardID] = '" + gv_test0.Rows[i].Cells[0].Text.Trim() + "'";

                SqlConnection Conn = new SqlConnection(connectionstring);
                SqlCommand Comm1 = new SqlCommand(sql, Conn);
                Conn.Open();
                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    result1 = DR1.GetValue(0).ToString();
                    result2 = DR1.GetValue(1).ToString();
                    result3 = DR1.GetValue(2).ToString();
                }
                Conn.Close();

                if (result2 != "" && result3 != "")
                {
                    t1 = Convert.ToDateTime(result2);
                    t2 = Convert.ToDateTime(result3);

                    System.DateTime dt_bf = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt16(t1.ToString("HH")), Convert.ToInt16(t1.ToString("mm")), 0);

                    System.DateTime dt_af = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt16(t2.ToString("HH")), Convert.ToInt16(t2.ToString("mm")), 0);

                    if (dt_bf > dt_af)
                    { result3 = ""; }
                }


                dt1.Rows.Add(result1, result2, result3);
            }

            gv_test.DataSource = dt1;
            gv_test.DataBind();


            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[10] { new DataColumn("NO"), new DataColumn("PersonCardID"), new DataColumn("Name"), new DataColumn("SurName"), new DataColumn("Department"), new DataColumn("Groups"), new DataColumn("Positions"), new DataColumn("Unit"), new DataColumn("TimeIn"), new DataColumn("UseTime") });

            string PersonCardID = "";
            string Name = "";
            string SurName = "";
            string Group = "";
            string department = "";
            string Position_ = "";
            string Unit = "";
            string Time = "";

            for (int i = 0; i < gv_test.Rows.Count; i++)
            {
                if (gv_test.Rows[i].Cells[2].Text.Trim() == "&nbsp;")
                {
                    string sql = "SELECT [PersonCardID],[Name],[SurName] ,[Group],[department],[Position_],[Unit],[TIME] FROM [Tigerscan].[dbo].[rpt_Sapthip] Where PersonCardID='" + gv_test.Rows[i].Cells[0].Text.Trim() + "'";

                    SqlConnection Conn = new SqlConnection(connectionstring);
                    SqlCommand Comm1 = new SqlCommand(sql, Conn);
                    Conn.Open();
                    SqlDataReader DR1 = Comm1.ExecuteReader();
                    if (DR1.Read())
                    {
                        PersonCardID = DR1.GetValue(0).ToString();
                        Name = DR1.GetValue(1).ToString();
                        SurName = DR1.GetValue(2).ToString();
                        Group = DR1.GetValue(3).ToString();
                        department = DR1.GetValue(4).ToString();
                        Position_ = DR1.GetValue(5).ToString();
                        Unit = DR1.GetValue(6).ToString();
                        Time = gv_test.Rows[i].Cells[1].Text.Trim();
                    }
                    Conn.Close();

                    dt.Rows.Add("", PersonCardID, Name, SurName, Group, department, Position_, Unit, Time, "");

                }

                //index += 1;
            }

            gv_result.DataSource = dt;
            gv_result.DataBind();



            try
            {
                //////sqlDa.Fill(dt);
                //////gv_test.DataSource = dt;
                //////gv_test.DataBind();
                //////CN.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //////CN.Close();
                //////CN.Dispose();
            }


        }
      
        private void Loop_Index()
        {
            DateTime Date = new DateTime();
            Date = Convert.ToDateTime(calendar.SelectedDate.ToShortDateString());

            DateTime Time = new DateTime();
            int count_person = 0;
            try
            {
                for (int i = 0; i < gv_result.Rows.Count; i++)
                {

                    //T1 = Convert.ToDateTime(DR1.GetValue(0).ToString());
                    //gv_monitor.Rows[i].Cells[7].Text = T1.ToString("HH:mm:ss");
                    Time = Convert.ToDateTime(gv_result.Rows[i].Cells[8].Text);

                    System.DateTime date1 = new System.DateTime(Convert.ToInt16(Date.ToString("yyyy")), Convert.ToInt16(Date.ToString("MM")), Convert.ToInt16(Date.ToString("dd")), Convert.ToInt16(Time.ToString("HH")), Convert.ToInt16(Time.ToString("mm")), 0);

                    System.DateTime date2 = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);

                    System.TimeSpan diftime = date2 - date1;
                    gv_result.Rows[i].Cells[9].Text = diftime.ToString();
                    gv_result.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                   // count_person += Convert.ToInt16(gv_result.Rows[i].Cells[7].Text);

                    if (gv_result.Rows[i].Cells[7].Text.Trim() != "&nbsp;")
                    {
                        count_person += Convert.ToInt16(gv_result.Rows[i].Cells[7].Text);
                    }
                }
            }
            catch { }

            lbl_date.Text = calendar.SelectedDate.ToString("dd/MM/yyyy");
            lbl_time.Text = "เวลา:" + DateTime.Now.ToString("HH:mm:ss");
            lbl_total.Text = "จำนวน: " + gv_result.Rows.Count.ToString() + " ข้อมูล จำนวนบุคคล: " + count_person.ToString() + " คน";
        }
        
        protected void calendar_SelectionChanged(object sender, EventArgs e)
        {
            lbl_date.Text = calendar.SelectedDate.ToShortDateString();
            calendar.Visible = false;
            Load_Data();
            Load_SearchDAta();
            Loop_Index();
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            calendar.Visible = true;
        }

        protected void ddl_location_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Data();
            Load_SearchDAta();
            Loop_Index();
        }

    }
}