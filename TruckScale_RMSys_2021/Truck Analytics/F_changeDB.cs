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
    public partial class F_changeDB : Form
    {
        public F_changeDB()
        {
            InitializeComponent();
        }

        public string DB_Name = "SapthipNewDB";

        private void F_changeDB_Load(object sender, EventArgs e)
        {
            Load_SelectDatabase();
        }

        private void Load_SelectDatabase()
        {
            // Open connection to the database
            //SqlConnection connection = new SqlConnection("Data Source=192.168.111.228; Integrated Security=true");
            SqlConnection connection = new SqlConnection(Program.pathdb_Weight);


            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "Select name From sys.sysdatabases Where dbid=6 or dbid=7";

            var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
            var dataset = new DataSet();
            adapter.Fill(dataset);
            DataTable dtDatabases = dataset.Tables[0];

            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                cbo_DBName.Items.Add(dataset.Tables[0].Rows[i][0].ToString());
                connection.Close();
            }

            cbo_DBName.SelectedIndex = 0;
           
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            DB_Name = cbo_DBName.Text;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbo_DBName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_DBName.Text.Trim() == "SapthipNewDB")
            {
                cbo_DBName.BackColor = Color.LightGreen;
            }
            else { cbo_DBName.BackColor = Color.LightSalmon; }
        }
    }
}
