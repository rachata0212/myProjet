using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Truck_Analytics
{
    public partial class Sub_Flink : Form
    {
        public Sub_Flink()
        {
            InitializeComponent();
        }

        private void Sub_Flink_Load(object sender, EventArgs e)
        {
            string cn_dbTruck = "";
            string cn_dbTemp = "";
            string cn_dbNav = "";

            StreamReader cn = new StreamReader(Application.StartupPath + "\\cndb.dll");
            cn_dbTruck = cn.ReadToEnd();

            StreamReader cn1 = new StreamReader(Application.StartupPath + "\\cn14_Truck.dll");
            cn_dbTemp = cn1.ReadToEnd();

            StreamReader cn2 = new StreamReader(Application.StartupPath + "\\cn14_Nav.dll");
            cn_dbNav = cn2.ReadToEnd();

            //----------------------   Connection config to Database Truckscale
            int indexST_dbTruck = cn_dbTruck.IndexOf("source=");
            int indexED_dbTruck = cn_dbTruck.IndexOf(";user");
            txt_db_truck.Text = cn_dbTruck.Substring(indexST_dbTruck + 7, (indexED_dbTruck- indexST_dbTruck) -7 );

            txt_inicat_truck.Text = Program.DB_Name;  //Db load on Login

            int indexST_UserTruck = cn_dbTruck.IndexOf("user id=");
            int indexED_UserTruck = cn_dbTruck.IndexOf(";password");          
            txt_user_truck.Text = cn_dbTruck.Substring(indexST_UserTruck + 8, (indexED_UserTruck - indexST_UserTruck) - 8);

            int indexST_PwdTruck = cn_dbTruck.IndexOf("password=");
            int indexED_PwdTruck = cn_dbTruck.IndexOf(";connect");
            txt_pwd_truck.Text = cn_dbTruck.Substring(indexST_PwdTruck + 9, (indexED_PwdTruck - indexST_PwdTruck) -9 );

            int indexST_TimeTruck = cn_dbTruck.IndexOf("Timeout=");
            int indexED_TimeTruck = cn_dbTruck.IndexOf("Timeout=");
            txt_cntime_truck.Text = cn_dbTruck.Substring(indexST_TimeTruck + 8 , (indexED_TimeTruck - indexST_TimeTruck)+ 2);


            //--------------------------  Connection config to Database Temp Trucksale Navision
            int indexST_dbTemp = cn_dbTemp.IndexOf("source=");
            int indexED_dbTemp = cn_dbTemp.IndexOf(";initial");
            txt_db_temp.Text = cn_dbTemp.Substring(indexST_dbTemp + 7,(indexED_dbTemp- indexST_dbTemp) -7);

            int indexST_dbNameTemp = cn_dbTemp.IndexOf("catalog=");
            int indexED_dbNameTemp = cn_dbTemp.IndexOf(";user");
            txt_inicat_temp.Text = cn_dbTemp.Substring(indexST_dbNameTemp + 8, (indexED_dbNameTemp- indexST_dbNameTemp) - 8);
            
            int indexST_UserTemp = cn_dbTemp.IndexOf("user id=");
            int indexED_UserTemp = cn_dbTemp.IndexOf(";password");
            txt_user_temp.Text = cn_dbTemp.Substring(indexST_UserTemp + 8, (indexED_UserTemp - indexST_UserTemp) - 8);

            int indexST_PwdTemp = cn_dbTemp.IndexOf("password=");
            int indexED_PwdTemp = cn_dbTemp.IndexOf(";connect");
            txt_pwd_temp.Text = cn_dbTemp.Substring(indexST_PwdTemp + 9, (indexED_PwdTemp - indexST_PwdTemp) - 9);

            int indexST_TimeTemp = cn_dbTemp.IndexOf("Timeout=");
            int indexED_TimeTemp = cn_dbTemp.IndexOf("Timeout=");
            txt_cntime_temp.Text = cn_dbTemp.Substring(indexST_TimeTemp + 8, (indexED_TimeTemp - indexST_TimeTemp) + 2);


            //--------------------------  Connection config to Database Trucksale Navision
            int indexST_dbNAV = cn_dbNav.IndexOf("source=");
            int indexED_dbNAV = cn_dbNav.IndexOf(";initial");
            txt_db_nav.Text = cn_dbNav.Substring(indexST_dbNAV + 7, (indexED_dbNAV - indexST_dbNAV) - 7);

            int indexST_dbNameNAV = cn_dbNav.IndexOf("catalog=");
            int indexED_dbNameNAV = cn_dbNav.IndexOf(";user");
            txt_inicat_nav.Text = cn_dbNav.Substring(indexST_dbNameNAV + 8, (indexED_dbNameNAV - indexST_dbNameNAV) - 8);

            int indexST_UserNAV = cn_dbNav.IndexOf("user id=");
            int indexED_UserNAV = cn_dbNav.IndexOf(";password");
            txt_user_nav.Text = cn_dbNav.Substring(indexST_UserNAV + 8, (indexED_UserNAV - indexST_UserNAV) - 8);

            int indexST_PwdNAV = cn_dbNav.IndexOf("password=");
            int indexED_PwdNAV = cn_dbNav.IndexOf(";connect");
            txt_pwd_nav.Text = cn_dbNav.Substring(indexST_PwdNAV + 9, (indexED_PwdNAV - indexST_PwdNAV) - 9);

            int indexST_TimeNAV = cn_dbNav.IndexOf("Timeout=");
            int indexED_TimeNAV = cn_dbNav.IndexOf("Timeout=");
            txt_cntime_nav.Text = cn_dbNav.Substring(indexST_TimeNAV + 8, (indexED_TimeNAV - indexST_TimeNAV) + 2);
                                                                              

            string config = Application.StartupPath + "\\config.dll";
            if (System.IO.File.Exists(config))
            {
                System.IO.StreamReader StrRer = new System.IO.StreamReader(config);

                List<string> listStr = new List<string>();

                while (!StrRer.EndOfStream)
                {
                    listStr.Add(StrRer.ReadLine());
                }
                cbo_database.Text = listStr[4].ToString();

                StrRer.Close();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            //--save Interface Database



            //--- Save cndb.dll



            //--- Save cn14_Truck.dll

            


            //--- Save cn14_NAV.dll
        }
    }
}
