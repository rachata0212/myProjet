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
    public partial class F_Payhistory : Form
    {
        public F_Payhistory()
        {
            InitializeComponent();
        }

        private void F_Payhistory_Load(object sender, EventArgs e)
        {
            Load_Date();
            Load_History();
        }
               

        private void Load_History()
        {
            SqlConnection con = new SqlConnection(Program.pathdb14_TruckScale);
            con.ConnectionString = Program.pathdb14_TruckScale;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();
         
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM [dbo].[Save_Log]";    
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds, "v_history");
            dtg_history.DataSource = ds.Tables["v_history"];            
            con.Close();                          

        }

        private void Load_Date()
        {
            SqlConnection con = new SqlConnection(Program.pathdb14_TruckScale);
            con.ConnectionString = Program.pathdb14_TruckScale;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT DISTINCT [Date_Log] FROM  [dbo].[Save_Log]", con);    
            DataSet ds = new DataSet();
            //ds.Clear();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                cb_selectdate.DisplayMember = "Date_Log";
                cb_selectdate.ValueMember = "Date_Log";
                cb_selectdate.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }


        }

        private void cb_selectdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtg_history.RowCount != 0)
            {
                SqlConnection con = new SqlConnection(Program.pathdb14_TruckScale);
                con.ConnectionString = Program.pathdb14_TruckScale;
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                con.Open();

                dtg_history.DataSource = null;
                DateTime dt_select = Convert.ToDateTime(cb_selectdate.Text);

                //FORMAT([Quantity], '###,###,###') AS 'Quantity'
                DataSet ds = new DataSet();
                string sql = "SELECT * FROM [dbo].[Save_Log] WHERE [Date_Log]='" + dt_select.ToString("yyyy-MM-dd") + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "v_history");
                dtg_history.DataSource = ds.Tables["v_history"];
                con.Close();
            }
        }
    }
}
