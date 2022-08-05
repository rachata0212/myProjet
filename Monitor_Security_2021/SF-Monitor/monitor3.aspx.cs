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
    public partial class monitor3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                calendar.SelectedDate = DateTime.Now;
                Load_SearchDAta();
                Load_Count();
                Load_Index();
                Load_LastLogon();
            }

            //else
            //{
            //    Load_Index();
            //    Load_LastLogon();
            //}
        }

     
            string connectionstring = @"data source=192.168.111.225;initial catalog=Tigerscan;uid=sa; pwd=0eP+1e-03_;";

        private void Load_Count()
        {

            //DateTime dt_af = new DateTime();
            int count = 0;

            for (int x = 0; x < gv_result.Rows.Count; x++)
            {
                count = 0;

                for (int i = 0; i < gv_test.Rows.Count; i++)
                {
                    if (gv_result.Rows[x].Cells[1].Text.Trim() == gv_test.Rows[i].Cells[0].Text.Trim())
                    {
                        count += 1;
                    }
                }

                gv_result.Rows[x].Cells[9].Text = count.ToString();  //Add Count Check IN                               

                //Check Status Mode
                int ST = Convert.ToInt16(gv_result.Rows[x].Cells[9].Text = count.ToString());
                if (ST % 2 == 0)
                {
                    gv_result.Rows[x].Cells[10].Text = "O";
                    gv_result.Rows[x].Cells[10].ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    gv_result.Rows[x].Cells[10].Text = "I";
                    gv_result.Rows[x].Cells[10].ForeColor = System.Drawing.Color.Green;
                }

                //add Indext
                gv_result.Rows[x].Cells[0].Text = Convert.ToString(x + 1);
            }
        }


        private void Load_SearchDAta()
        {
            lbl_area1.Text = "3";
            lbl_area2.Text = "3";

            SqlConnection CN1 = new SqlConnection();
            CN1.ConnectionString = "server=192.168.111.225;initial catalog=Tigerscan;uid=sa; pwd=0eP+1e-03_;";
            CN1.Open();

            //sqlCon.Open();                

            string sql1 = "SELECT [PersonCardID],[Date] AS Dates,[Time] AS Times  FROM [Tigerscan].[dbo].[rpt_Sapthip]  where [Date]='" + calendar.SelectedDate.ToString("dd/MM/yyyy") + "'   and [MachCode]=3 ";

            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "chk_in");
            gv_test.DataSource = ds1.Tables["chk_in"];
            gv_test.DataBind();
           
            //CN1.Close();


            //sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT DISTINCT [PersonCardID],[Date],[Name],[SurName],[Department],[Group],[Position_],[Unit]  FROM [Tigerscan].[dbo].[rpt_Sapthip] Where [Date] = '" + calendar.SelectedDate.ToString("dd/MM/yyyy") + "'  AND [MachCode]=3 ", CN1);

            DataTable dt = new DataTable();

            sqlDa.Fill(dt);
            gv_result.DataSource = dt;
            gv_result.DataBind();
            CN1.Close();


        }
     

        protected void calendar_SelectionChanged(object sender, EventArgs e)
        {
            lbl_date.Text = calendar.SelectedDate.ToShortDateString();
            calendar.Visible = false;
           
            Load_SearchDAta();
            Load_Count();
            Load_Index();
            Load_LastLogon();
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
            calendar.Visible = true;
        }
               

        private void Load_Index()
        {           
          //  DateTime Time = new DateTime();
            int count_person = 0;
            try
            {
                for (int i = 0; i < gv_result.Rows.Count; i++)
                { 
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


        private void Load_LastLogon()
        {
            for (int x = 0; x < gv_result.Rows.Count; x++)
            {
                // Check Last time IN
                string sql = "SELECT Max([TIME] ) AS maxtimeIn from [dbo].[rpt_Sapthip] where  [Date]='" + calendar.SelectedDate.ToShortDateString() + "' and  [MachCode]=3 aND  [InOutMode]='I' and [PersonCardID] = '" + gv_result.Rows[x].Cells[1].Text.Trim() + "'";

                SqlConnection Conn = new SqlConnection(connectionstring);
                SqlCommand Comm1 = new SqlCommand(sql, Conn);
                Conn.Open();
                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    gv_result.Rows[x].Cells[8].Text = DR1.GetValue(0).ToString();
                }
                Conn.Close();
            }

        }

    }
}