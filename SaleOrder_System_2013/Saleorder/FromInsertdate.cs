using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SaleOrder
{
    public partial class FromInsertdate : Form
    {
        public FromInsertdate()
        {
            InitializeComponent();
        }

        public string idtran = ""; string valuedate = ""; public string status = "0";
        private void FromInsertdate_Load(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            Checkdate();
            //MessageBox.Show(valuedate.ToString());
        }

        private void Checkdate()
        {
            string date = monthCalendar1.SelectionStart.Day.ToString();
            string month = monthCalendar1.SelectionStart.Month.ToString();
            string year = monthCalendar1.SelectionStart.Year.ToString();
            valuedate = month + "/" + date + "/" + year;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); Checkdate();

            if (status == "0")
            {
                string sql1 = "update tbweigth set dateWaf= '" + valuedate + "' Where idtran= '" + idtran + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                CM1.ExecuteNonQuery();             
                this.Close();
                status = "1";
            }

            if (status == "2")
            {
                string sql1 = "update tbweigth set dateWaf= '" + valuedate + "' Where idtran= '" + idtran + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                CM1.ExecuteNonQuery();
                this.Close();
                status = "1";
            }

            CN.Close();
            
        }
    }
}