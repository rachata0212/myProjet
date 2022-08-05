using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using Microsoft.Win32;

namespace SaleOrder
{
    public partial class Frmreporttruck : Form
    {
        public Frmreporttruck()
        {
            InitializeComponent();
        }

        RegistryKey r; public string idtran = ""; public string typetruck = "";
        private void Frmreporttruck_Load(object sender, EventArgs e)
        {  
            try
            {

            string path = "SaleOrder";
            r = Registry.CurrentUser.OpenSubKey(path); //เรียกใช้งาน OpenSubKey เพื่อทำให้สามารถเข้าถึง 
            string servername = Convert.ToString(r.GetValue("ServerName"));
            string databasename = Convert.ToString(r.GetValue("DatabaseName"));
            string userid = Convert.ToString(r.GetValue("UserID"));
            string password = Convert.ToString(r.GetValue("Password"));

            if (typetruck == "truckin")//เรียกข้อมูลชั่งเข้า
            {                
                crtruckin crtin = new crtruckin();
                ConnectionInfo con = new ConnectionInfo();
                con.IntegratedSecurity = false;
                con.ServerName = servername;
                con.DatabaseName = databasename;
                con.UserID = userid;
                con.Password = password;
                TableLogOnInfo Tinfo = new TableLogOnInfo();
                foreach (Table T in crtin.Database.Tables)
                {
                    Tinfo = T.LogOnInfo;
                    Tinfo.ConnectionInfo = con;
                    T.ApplyLogOnInfo(Tinfo);
                }

                crystalReportViewer1.ReportSource = crtin;
                crystalReportViewer1.SelectionFormula = "{vWeigthTruckin.idtran}= '" + idtran.Trim() + "'";
            }

            if (typetruck == "truckout")//เรียกข้อมูลชั่งออก
            {
                crtruckout crtin = new crtruckout();
                ConnectionInfo con = new ConnectionInfo();
                con.IntegratedSecurity = false;
                con.ServerName = servername;
                con.DatabaseName = databasename;
                con.UserID = userid;
                con.Password = password;
                TableLogOnInfo Tinfo = new TableLogOnInfo();
                foreach (Table T in crtin.Database.Tables)
                {
                    Tinfo = T.LogOnInfo;
                    Tinfo.ConnectionInfo = con;
                    T.ApplyLogOnInfo(Tinfo);
                }

                crystalReportViewer1.ReportSource = crtin;
                crystalReportViewer1.SelectionFormula = "{vWeigthTruckout.idtran}= '" + idtran.Trim() + "'";                         

            }

            if (typetruck == "truckouttocusbf")//เรียกข้อมูลชั่งออก
            {
                crtruckouttocusbf crtbf = new crtruckouttocusbf();
                ConnectionInfo con = new ConnectionInfo();
                con.IntegratedSecurity = false;
                con.ServerName = servername;
                con.DatabaseName = databasename;
                con.UserID = userid;
                con.Password = password;
                TableLogOnInfo Tinfo = new TableLogOnInfo();
                foreach (Table T in crtbf.Database.Tables)
                {
                    Tinfo = T.LogOnInfo;
                    Tinfo.ConnectionInfo = con;
                    T.ApplyLogOnInfo(Tinfo);
                }

                crystalReportViewer1.ReportSource = crtbf;
                crystalReportViewer1.SelectionFormula = "{vWtruckFsTc.idtran}= '" + idtran.Trim() + "'";
            }

            if (typetruck == "truckouttocusaf")//เรียกข้อมูลชั่งออก
            {
                crtruckouttocusaf crtin = new crtruckouttocusaf();
                ConnectionInfo con = new ConnectionInfo();
                con.IntegratedSecurity = false;
                con.ServerName = servername;
                con.DatabaseName = databasename;
                con.UserID = userid;
                con.Password = password;
                TableLogOnInfo Tinfo = new TableLogOnInfo();
                foreach (Table T in crtin.Database.Tables)
                {
                    Tinfo = T.LogOnInfo;
                    Tinfo.ConnectionInfo = con;
                    T.ApplyLogOnInfo(Tinfo);
                }

                crystalReportViewer1.ReportSource = crtin;
                crystalReportViewer1.SelectionFormula = "{vWtruckFsTc.idtran}= '" + idtran.Trim() + "'";
            }       

        }

        catch (Exception ex)
        { MessageBox.Show(ex.Message); }


        }
    }
}