using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Data;
using System.Globalization;


namespace LTTS
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bind_date_select();

            if (!this.IsPostBack)
            {
                DataTable dt1 = new DataTable();
                dt1.Columns.AddRange(new DataColumn[3] { new DataColumn("NO"), new DataColumn("Color Status"), new DataColumn("Color") });
                dt1.Rows.Add(1, "Normal", "");
                dt1.Rows.Add(2, "Warning", "");
                dt1.Rows.Add(3, "Danger", "");
                GridView1.DataSource = dt1;
                GridView1.DataBind();

                DataTable dt2 = new DataTable();
                dt2.Columns.AddRange(new DataColumn[3] { new DataColumn("NO"), new DataColumn("Status detail"), new DataColumn("Remark") });
                dt2.Rows.Add(0, "Open order", "Create order in MS-Navision");
                dt2.Rows.Add(1, "Confirm Order", "Confirm order to mapping truck");
                dt2.Rows.Add(2, "Check In", "Truck Check in on Weight in");
                dt2.Rows.Add(3, "Weight in", "Weight truck In");
                dt2.Rows.Add(4, "Weight out", "Weight trouck Out");
                dt2.Rows.Add(5, "Check out", "Truck Check out on Weight out");
                GridView2.DataSource = dt2;
                GridView2.DataBind();

                DataTable dt3 = new DataTable();
                dt3.Columns.AddRange(new DataColumn[2] { new DataColumn("NO"), new DataColumn("Truck detail") });
                dt3.Rows.Add(1, "Single Truck");
                dt3.Rows.Add(2, "Double Truck");
                dt3.Rows.Add(3, "Single Open Truck");
                dt3.Rows.Add(4, "Double Open Truck");
                dt3.Rows.Add(5, "Customer to Recive");
                GridView3.DataSource = dt3;
                GridView3.DataBind();

                lbldate.Text = DateTime.Now.ToShortDateString();
                
                lblTimer1.Text = DateTime.Now.ToString("T");

                if (!ScriptManager1.IsInAsyncPostBack)
                {                    
                   Session["timeout"] =DateTime.Now.AddSeconds(20).ToString();
                }
                              
            }

            
            Session["select_date"] = DateTime.Today.ToString("dd");    
            Get_Orderlist();
            lblitemscount.Text = "Total: " + dtgdashboard.Rows.Count.ToString() + " Items";
            GetData_time();

            

        }
            
        private void Get_Orderlist()
        {
           // string dates = Convert.ToString(Session["Select_Value"]);
            //string dates = Convert.ToString(DateTime.Now.Date);
            string dates = DateTime.Today.ToString("dd");   
            string convert = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + dates;

            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = "server=192.168.1.14;initial catalog=UMS LIVE;uid=sa; pwd=1234;";
            DataSet ds3 = new DataSet();
            string sql = "SELECT [Order No_],[Customer Name], [Description],[Truck Type],[Confirm Truck No_],[Status],[FG Comment],[Weight Ticket No_],[Item No_] FROM [dbo].[UMSPCL_View_TTS] WHERE ([Expected Shipment Date] BETWEEN '" + convert + " 00:00:00.000' AND '" + convert + " 00:00:00.000' AND [Cancel] =0) ";

            SqlDataAdapter da = new SqlDataAdapter(sql, CN);
            da.Fill(ds3, "Load_data");
            dtgdashboard.DataSource = ds3.Tables["Load_data"];
            dtgdashboard.DataBind();
            CN.Close();

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (i == 0)
                {
                    GridView1.Rows[i].Cells[2].BackColor = System.Drawing.Color.Green;
                }
                if (i == 1)
                {
                    GridView1.Rows[i].Cells[2].BackColor = System.Drawing.Color.Yellow;
                }
                if (i == 2) GridView1.Rows[i].Cells[2].BackColor = System.Drawing.Color.Red;

            }

            insert_columns();
        }

        protected void dtgdashboard_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i > e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].CssClass = "columnscss";
                }
            }
        }

        private void bind_date_select()
        {
            for (int i = 1; i <= 31; i++)
            {
                ddl_dateplans.Items.Add(i.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
            }
        }

        protected void tmrUpdate_Tick(object sender, EventArgs e)
        {
            lblTimer1.Text = DateTime.Now.ToString("T"); 
        }

        private void insert_columns()
        {

            DataTable dt4 = new DataTable();
            dt4.Columns.AddRange(new DataColumn[13] { new DataColumn("Order No"), new DataColumn("Customer Name"), new DataColumn("Description"), new DataColumn("Truck No"), new DataColumn("ETA-NL"), new DataColumn("ATA-NL"), new DataColumn("ETD-NL"), new DataColumn("ETA-Cus"), new DataColumn("ATA-Cus"), new DataColumn("Finish Good Comment"), new DataColumn("Item No"), new DataColumn("Truck"), new DataColumn("Status") });

            for (int i = 0; i < dtgdashboard.Rows.Count; i++)
            {
                //--Example
                //-- dt4.Rows.Add(1, "Normal");  
                //string input = dtgdashboard.Rows[i].Cells[1].Text;
                //string cuscut = cuscut = input.Substring(0, 50);   
                string TruckNo = dtgdashboard.Rows[i].Cells[3].Text;
                string FGComment = dtgdashboard.Rows[i].Cells[4].Text;

                if (dtgdashboard.Rows[i].Cells[3].Text == "&nbsp;")
                { TruckNo = "-"; }

                if (dtgdashboard.Rows[i].Cells[4].Text == "&nbsp;")
                { FGComment = "-"; }

                dt4.Rows.Add(dtgdashboard.Rows[i].Cells[0].Text, dtgdashboard.Rows[i].Cells[1].Text, dtgdashboard.Rows[i].Cells[2].Text, TruckNo, "10:00:00", "-", "-", "-", "-", FGComment, dtgdashboard.Rows[i].Cells[8].Text, dtgdashboard.Rows[i].Cells[5].Text, dtgdashboard.Rows[i].Cells[6].Text);

            }

            dtgcreate_value.DataSource = dt4;
            dtgcreate_value.DataBind();
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Attributes["width"] = "40px"; e.Row.Cells[0].Style.Add("text-Align", "center");
            e.Row.Cells[1].Attributes["width"] = "120px";
            e.Row.Cells[2].Attributes["width"] = "220px";
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Attributes["width"] = "40px"; e.Row.Cells[0].Style.Add("text-Align", "center");
            e.Row.Cells[1].Attributes["width"] = "180px";
        }

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Attributes["width"] = "80px";
            e.Row.Cells[0].Style.Add("text-Align", "center");
            e.Row.Cells[1].Attributes["width"] = "400px";
            e.Row.Cells[3].Attributes["width"] = "80px";
            e.Row.Cells[4].Style.Add("text-Align", "center");
            e.Row.Cells[5].Style.Add("text-Align", "center");
            e.Row.Cells[6].Style.Add("text-Align", "center");
            e.Row.Cells[7].Style.Add("text-Align", "center");
            e.Row.Cells[7].Style.Add("text-Align", "center");
            e.Row.Cells[8].Style.Add("text-Align", "center");
            e.Row.Cells[9].Attributes["width"] = "200px";
            e.Row.Cells[11].Style.Add("text-Align", "center");
            e.Row.Cells[12].Style.Add("text-Align", "center");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[2].BackColor == System.Drawing.Color.Empty)
                {
                    //  e.Row.Cells[2].BackColor = System.Drawing.Color.Yellow;

                    if (e.Row.Cells[6].Text == "-")
                    {
                        TableCell mm_cell = e.Row.Cells[4];
                        string Date_Refresh = ddl_dateplans.Text+ " " + mm_cell.Text;

                        DateTime date_mm = Convert.ToDateTime(Date_Refresh);    
                        int hh_check = Convert.ToInt16(date_mm.ToString("hh"));
                        int mm_check = Convert.ToInt16(date_mm.ToString("mm"));
                        int ss_check = Convert.ToInt16(date_mm.ToString("ss"));

                        DateTime startTime = DateTime.Now;
                        DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hh_check, mm_check, ss_check);
                        TimeSpan span = endTime.Subtract(startTime);

                        if (span.Minutes <= 0)  // red
                        {
                            e.Row.Cells[1].BackColor = System.Drawing.Color.Green; e.Row.Cells[1].ForeColor = System.Drawing.Color.Black;
                        }

                        else if (span.Minutes >= 1 && span.Minutes >= 15)
                        {
                            e.Row.Cells[1].BackColor = System.Drawing.Color.Yellow; e.Row.Cells[1].ForeColor = System.Drawing.Color.Black;
                        }

                        else if (span.Minutes < 15)
                        {
                            e.Row.Cells[1].BackColor = System.Drawing.Color.Red; e.Row.Cells[1].ForeColor = System.Drawing.Color.Black;
                        }
                        
                     //  Console.WriteLine("Time Difference (minutes): " + span.Minutes);

                            }                    

                }
                //TableCell cell = e.Row.Cells[1];
                //int quantity = int.Parse(cell.Text);
                //if (quantity == 0)
                //{
                //   // cell.BackColor =
                //}
                //if (quantity > 0 && quantity <= 50)
                //{
                //   // cell.BackColor = Color.Yellow;
                //}
                //if (quantity > 50 && quantity <= 100)
                //{
                // //   cell.BackColor = Color.Orange;
                //}
            }
















        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Attributes["width"] = "120px";
            e.Row.Cells[2].Attributes["width"] = "220px";
        }


        private void GetData_time()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = "server=192.168.1.14;initial catalog=UMS LIVE;uid=sa; pwd=1234;";
            DataSet ds = new DataSet();
            CN.Open();

            //string dates = Convert.ToString(ddl_dateplans.SelectedIndex + 1);
            string dates = DateTime.Today.ToString("dd"); 
            string convert = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + dates;
                       
            for (int i = 0; i < dtgcreate_value.Rows.Count; i++)
            {
                if (dtgdashboard.Rows[i].Cells[7].Text.ToString().Trim() != "&nbsp;" )
                {
                    string sql = "SELECT [Weight In Time],[Weight Out Time] FROM [บมจ_ยูนิค ไมนิ่ง เซอร์วิสเซส$Logistics Entry] WHERE ([Expected Shipment Date] BETWEEN '" + convert + " 00:00:00.000' AND '" + convert + " 00:00:00.000' AND [Weight Ticket No_]= '" + dtgdashboard.Rows[i].Cells[7].Text.ToString().Trim() + "' ) ";
                    SqlCommand CM = new SqlCommand(sql, CN);
                    SqlDataReader DR = CM.ExecuteReader();

                    DR.Read();
                    {
                        try
                        {
                            if (DR["Weight In Time"].ToString().Trim() != "1/1/2296 0:00:00")
                            {
                                // dtgcreate_value.Rows[i].Cells[5].Text = DR["Weight In Time"].ToString().Trim();
                                DateTime myDateTime = Convert.ToDateTime(DR["Weight In Time"].ToString().Trim());
                                string Convert_to = myDateTime.ToString("hh");
                                if (Convert_to == "12")
                                {
                                    dtgcreate_value.Rows[i].Cells[5].Text = "07:" + myDateTime.ToString("mm:ss");
                                }
                                else
                                {
                                    int plushoure = 7 + Convert.ToInt16(myDateTime.ToString("hh"));
                                    dtgcreate_value.Rows[i].Cells[5].Text = plushoure.ToString() + ":" + myDateTime.ToString("mm:ss");
                                }
                            }

                            else { dtgcreate_value.Rows[i].Cells[5].Text = "-"; }


                            if (DR["Weight Out Time"].ToString().Trim() != "1/1/2296 0:00:00")
                            {
                                //dtgcreate_value.Rows[i].Cells[6].Text = DR["Weight Out Time"].ToString().Trim(); 
                                DateTime myDateTime = Convert.ToDateTime(DR["Weight Out Time"].ToString().Trim());
                                string Convert_to = myDateTime.ToString("hh");

                                if (Convert_to == "12")
                                {
                                    dtgcreate_value.Rows[i].Cells[6].Text = "07:" + myDateTime.ToString("mm:ss");
                                }


                                else
                                {
                                    int plushoure = 7 + Convert.ToInt16(myDateTime.ToString("hh"));
                                    dtgcreate_value.Rows[i].Cells[6].Text = plushoure.ToString() + ":" + myDateTime.ToString("mm:ss");
                                }
                            }

                        }

                        catch { }

                    }
                    
                    DR.Close();                            
                }

                else
                {
                    dtgcreate_value.Rows[i].Cells[5].Text = "-";
                    dtgcreate_value.Rows[i].Cells[6].Text = "-";               
                }
            }    

            CN.Close();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (0 > DateTime.Compare(DateTime.Now,
          DateTime.Parse(Session["timeout"].ToString())))
                {
                    lblTimer2.Text = ((Int32)DateTime.Parse(Session["timeout"].ToString()).Subtract(DateTime.Now).TotalSeconds).ToString();
                }

                else
                {
                    if (lblTimer2.Text == "0")
                    {
                        Session["timeout"] = DateTime.Now.AddSeconds(Convert.ToInt16(ddl_refresh.SelectedValue.ToString())).ToString();

                        if (this.IsPostBack)
                        {
                            //Get_Orderlist();
                            //lblitemscount.Text = "Total: " + dtgdashboard.Rows.Count.ToString() + " Items";
                            //GetData_time();
                          //  Response.Redirect(Request.Path);
                            Response.Redirect(Request.RawUrl, false);
                        }
                    }
                }
            }
            catch { }
        }

        protected void ddl_refresh_SelectedIndexChanged(object sender, EventArgs e)
        {         
            Session["timeout"] = DateTime.Now.AddSeconds(Convert.ToInt16(ddl_refresh.SelectedValue.ToString())).ToString(); 
        }

        protected void ddl_dateplans_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_Orderlist();
            lblitemscount.Text = "Total: " + dtgdashboard.Rows.Count.ToString() + " Items";
            GetData_time();
        }

        protected void btnrefresh_Click(object sender, EventArgs e)
        {
            Get_Orderlist();
            lblitemscount.Text = "Total: " + dtgdashboard.Rows.Count.ToString() + " Items";
            GetData_time();
        }

       

    
             
        


    }
}