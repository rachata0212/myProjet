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
    public partial class F_SelectData : Form
    {
        public F_SelectData()
        {
            InitializeComponent();
        }

        public string ID_Product = "";
        public string Sort_Product = "";
        public string Select_Product = "";
        public string Data_Sel = "";
        private void F_SelectData_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            //con.ConnectionString = Program.pathdb_Weight;

            using (SqlConnection con = new SqlConnection(Program.pathdb_Weight))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT [ProductID], [ProductName] FROM [dbo].[TB_Products] WHERE [StatusActive] =1 ", con))
                {
                    //Fill the DataTable with records from Table.
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    //Assign DataTable as DataSource.
                    chkl_data.DataSource = dt;
                    chkl_data.DisplayMember = "ProductName";
                    chkl_data.ValueMember = "ProductID";
                }
            }


        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();

            string message = "";
            int c_count = 1;
            foreach (object item in chkl_data.CheckedItems)
            {
                DataRowView row = item as DataRowView;
                message += "ProductName: " + row["ProductName"];
                message += Environment.NewLine;
                message += "ProductID: " + row["ProductID"];
                message += Environment.NewLine;
                message += Environment.NewLine;

                ID_Product += row["ProductID"];
                Sort_Product += "ProductID ='" + row["ProductID"] + "'";
                Select_Product += row["ProductName"];

                if (chkl_data.CheckedItems.Count > 1 && chkl_data.CheckedItems.Count != c_count)
                {
                    Select_Product += ",";
                    Sort_Product += " OR ";
                    c_count++;
                }
            }   
        }

        private void chkl_data_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void chk_all_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chkl_data.Items.Count; i++)
            {
                chkl_data.SetItemChecked(i, chk_all.Checked);
            }          
        }
    }
}
