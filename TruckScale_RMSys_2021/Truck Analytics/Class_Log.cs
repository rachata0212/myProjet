using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Truck_Analytics
{
    class Class_Log
    {
        // Attibute
        private string logdate = Program.Date_Now + ' ' + Program.Time_Now;
        private string uname = Program.user_login;
        private string macname = Program.MachineName;
        private string ipaddress = Program.LocalIpAddress;

        public string tbname;
        public string oldvalue;
        public string newvalue;
        
        


        public void GetData(string tb_name, string old_value, string new_value, string mac_name, string ip_address)
        {
            this.tbname = tb_name;
            this.oldvalue = old_value;
            this.newvalue = new_value;
            this.macname = mac_name;
            this.ipaddress = ip_address;
        }

        public void Save_log()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            //SqlDataAdapter dtAdapter = new SqlDataAdapter();

            con.Open();
            string sql = "Insert Into [TB_Log] ([LogDateTime],[Username],[TableName],[OldValue],[NewValue],[MachineName],[LocalIpAddress]) Values('" + logdate + "', '" + uname + "', '" + tbname + "','" + oldvalue + "', '" + newvalue + "', '" + macname + "', '" + ipaddress + "')";
            SqlCommand CM2 = new SqlCommand(sql, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();
        }

    }
















}
