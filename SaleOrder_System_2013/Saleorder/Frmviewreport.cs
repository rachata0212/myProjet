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
using System.Data.SqlClient;
using System.Configuration;

namespace SaleOrder
{
    public partial class Frmviewreport : Form
    {
        public Frmviewreport()
        {
            InitializeComponent();
        }

        public string rpname; RegistryKey r;
        public int startdate = 0;
        public int startmount = 0;
        public int startyear = 0;
        public int enddate = 0;
        public int endmount = 0;
        public int endyear = 0;


        public string cationname = "";   //ใช้โชว์ชื่อรายงาน
        public string filterby = "";    //ค้นหาจาก ชื่อข้อมูล
        public string valuename = "";   //ชื่อฟิลด์ที่ต้องการค้นหา
        public int idbranch = 0;        //สาขาที่ต้องดู
        public string idqua = "";


        private void Frmviewreport_Load(object sender, EventArgs e)
        {
            //try
            //{
            string path = "Saleorder";
            r = Registry.CurrentUser.OpenSubKey(path); //เรียกใช้งาน OpenSubKey เพื่อทำให้สามารถเข้าถึง 
            string servername = Convert.ToString(r.GetValue("ServerName"));
            string databasename = Convert.ToString(r.GetValue("DatabaseName"));
            string userid = Convert.ToString(r.GetValue("UserID"));
            string password = Convert.ToString(r.GetValue("Password"));

           // crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            

            if (rpname == "rppurtosale")
            {
                crtpurtosale rpptc = new crtpurtosale();
                ConnectionInfo con = new ConnectionInfo();
                con.IntegratedSecurity = false;
                con.ServerName = servername;
                con.DatabaseName = databasename;
                con.UserID = userid;
                con.Password = password;
                TableLogOnInfo Tinfo = new TableLogOnInfo();
                foreach (Table T in rpptc.Database.Tables)
                {
                    Tinfo = T.LogOnInfo;
                    Tinfo.ConnectionInfo = con;
                    T.ApplyLogOnInfo(Tinfo);
                }

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vppurtosale.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) and {vppurtosale.remark} = 'ปิดงาน'";
            }

            if (rpname == "rppurtosalfilbycom")
            {
                crtpurtosalefilbycompur rpptc = new crtpurtosalefilbycompur();
                ConnectionInfo con = new ConnectionInfo();
                con.IntegratedSecurity = false;
                con.ServerName = servername;
                con.DatabaseName = databasename;
                con.UserID = userid;
                con.Password = password;
                TableLogOnInfo Tinfo = new TableLogOnInfo();
                foreach (Table T in rpptc.Database.Tables)
                {
                    Tinfo = T.LogOnInfo;
                    Tinfo.ConnectionInfo = con;
                    T.ApplyLogOnInfo(Tinfo);
                }

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vppurtosale.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) and {vppurtosale.remark} = 'ปิดงาน'";
            }

            if (rpname == "rppurtosalfilbybranch")
            {
                crtpurtosalefilbybranch rpptc = new crtpurtosalefilbybranch();
                ConnectionInfo con = new ConnectionInfo();
                con.IntegratedSecurity = false;
                con.ServerName = servername;
                con.DatabaseName = databasename;
                con.UserID = userid;
                con.Password = password;
                TableLogOnInfo Tinfo = new TableLogOnInfo();
                foreach (Table T in rpptc.Database.Tables)
                {
                    Tinfo = T.LogOnInfo;
                    Tinfo.ConnectionInfo = con;
                    T.ApplyLogOnInfo(Tinfo);
                }

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vppurtosale.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) and {vppurtosale.remark} = 'ปิดงาน'";
            }


            if (rpname == "rppurchasepersonal")
            {
                //crtpurpersonal rpptc = new crtpurpersonal();
                //ConnectionInfo con = new ConnectionInfo();
                //con.IntegratedSecurity = false;
                //con.ServerName = servername;
                //con.DatabaseName = databasename;
                //con.UserID = userid;
                //con.Password = password;
                //TableLogOnInfo Tinfo = new TableLogOnInfo();
                //foreach (Table T in rpptc.Database.Tables)
                //{
                //    Tinfo = T.LogOnInfo;
                //    Tinfo.ConnectionInfo = con;
                //    T.ApplyLogOnInfo(Tinfo);
                //}

                //crystalReportViewer1.ReportSource = rpptc;
                //crystalReportViewer1.SelectionFormula = "{vrppurchasefilby.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) and {vrppurchasefilby.remark} = 'ปิดงาน'";
            }

            if (rpname == "rppurchasepersonalfilbycom")
            {
                crtpurfilbycompur rpptc = new crtpurfilbycompur();
                ConnectionInfo con = new ConnectionInfo();
                con.IntegratedSecurity = false;
                con.ServerName = servername;
                con.DatabaseName = databasename;
                con.UserID = userid;
                con.Password = password;
                TableLogOnInfo Tinfo = new TableLogOnInfo();
                foreach (Table T in rpptc.Database.Tables)
                {
                    Tinfo = T.LogOnInfo;
                    Tinfo.ConnectionInfo = con;
                    T.ApplyLogOnInfo(Tinfo);
                }

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vrppurchasefilby.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) and {vrppurchasefilby.remark} = 'ปิดงาน'";
            }

            //{vrppurchasefilby.remark} = "ปิดงาน"

            if (rpname == "rppurchasepersonalfilbybranch")
            {
                crtpurfilbybranch rpptc = new crtpurfilbybranch();
                ConnectionInfo con = new ConnectionInfo();
                con.IntegratedSecurity = false;
                con.ServerName = servername;
                con.DatabaseName = databasename;
                con.UserID = userid;
                con.Password = password;
                TableLogOnInfo Tinfo = new TableLogOnInfo();
                foreach (Table T in rpptc.Database.Tables)
                {
                    Tinfo = T.LogOnInfo;
                    Tinfo.ConnectionInfo = con;
                    T.ApplyLogOnInfo(Tinfo);
                }

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vrppurchasefilby.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) and {vrppurchasefilby.remark} = 'ปิดงาน'";
            }

            if (rpname == "rpsalepersonal")
            {
                crtsale rpptc = new crtsale();
                ConnectionInfo con = new ConnectionInfo();
                con.IntegratedSecurity = false;
                con.ServerName = servername;
                con.DatabaseName = databasename;
                con.UserID = userid;
                con.Password = password;
                TableLogOnInfo Tinfo = new TableLogOnInfo();
                foreach (Table T in rpptc.Database.Tables)
                {
                    Tinfo = T.LogOnInfo;
                    Tinfo.ConnectionInfo = con;
                    T.ApplyLogOnInfo(Tinfo);
                }

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vrpsale.orderdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) ";
            }

            if (rpname == "rptruckinfilbycom")/////////////////////////////////////////////////////////////////////////////////
            {
                crtuckinfilbycom rpptc = new crtuckinfilbycom();
                ConnectionInfo con = new ConnectionInfo();
                con.IntegratedSecurity = false;
                con.ServerName = servername;
                con.DatabaseName = databasename;
                con.UserID = userid;
                con.Password = password;
                TableLogOnInfo Tinfo = new TableLogOnInfo();
                foreach (Table T in rpptc.Database.Tables)
                {
                    Tinfo = T.LogOnInfo;
                    Tinfo.ConnectionInfo = con;
                    T.ApplyLogOnInfo(Tinfo);
                }

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWeigthTruckin.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)AND {vWeigthTruckin.idbranch} = " + Program.idbranch + " ";
            }

            if (rpname == "rptruckinfilbybranch")
            {
                crtuckinfilbybrach rpptc = new crtuckinfilbybrach();
                ConnectionCrystonReportWrpptc(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.SelectionFormula = "{vWeigthTruckin.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)AND {vWeigthTruckin.idbranch} = " + Program.idbranch + " ";
            }


            if (rpname == "rptruckoutfilbycom")
            {
                crtuckoutfilbycom rpptc = new crtuckoutfilbycom();
                ConnectionInfo con = new ConnectionInfo();
                con.IntegratedSecurity = false;
                con.ServerName = servername;
                con.DatabaseName = databasename;
                con.UserID = userid;
                con.Password = password;
                TableLogOnInfo Tinfo = new TableLogOnInfo();
                foreach (Table T in rpptc.Database.Tables)
                {
                    Tinfo = T.LogOnInfo;
                    Tinfo.ConnectionInfo = con;
                    T.ApplyLogOnInfo(Tinfo);
                }

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWeigthTruckout.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)AND {vWeigthTruckout.idbranch} = " + Program.idbranch + " ";
            }

            if (rpname == "rptruckoutfilbybranch")
            {
                crtuckoutfilbybranch rpptc = new crtuckoutfilbybranch();
                ConnectionInfo con = new ConnectionInfo();
                con.IntegratedSecurity = false;
                con.ServerName = servername;
                con.DatabaseName = databasename;
                con.UserID = userid;
                con.Password = password;
                TableLogOnInfo Tinfo = new TableLogOnInfo();
                foreach (Table T in rpptc.Database.Tables)
                {
                    Tinfo = T.LogOnInfo;
                    Tinfo.ConnectionInfo = con;
                    T.ApplyLogOnInfo(Tinfo);
                }

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWeigthTruckout.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)AND {vWeigthTruckout.idbranch} = " + Program.idbranch + "";
            }

            if (rpname == "rprateoil")
            {
                crprateoil rpptc = new crprateoil();
                ConnectionInfo con = new ConnectionInfo();
                con.IntegratedSecurity = false;
                con.ServerName = servername;
                con.DatabaseName = databasename;
                con.UserID = userid;
                con.Password = password;
                TableLogOnInfo Tinfo = new TableLogOnInfo();
                foreach (Table T in rpptc.Database.Tables)
                {
                    Tinfo = T.LogOnInfo;
                    Tinfo.ConnectionInfo = con;
                    T.ApplyLogOnInfo(Tinfo);
                }

                crystalReportViewer1.ReportSource = rpptc;

                crystalReportViewer1.SelectionFormula = "{vrateoil.daterefil} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) ";
            }

            if (rpname == "crpratetruckempAll")
            {
                crpratetruckemp rpptc = new crpratetruckemp();
                ConnectionInfo con = new ConnectionInfo();
                con.IntegratedSecurity = false;
                con.ServerName = servername;
                con.DatabaseName = databasename;
                con.UserID = userid;
                con.Password = password;
                TableLogOnInfo Tinfo = new TableLogOnInfo();
                foreach (Table T in rpptc.Database.Tables)
                {
                    Tinfo = T.LogOnInfo;
                    Tinfo.ConnectionInfo = con;
                    T.ApplyLogOnInfo(Tinfo);
                }

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vrpratecostemp.rfdateorder} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpratetruckempFilter")
            {
                crpratetruckemp rpptc = new crpratetruckemp();
                ConnectionInfo con = new ConnectionInfo();
                con.IntegratedSecurity = false;
                con.ServerName = servername;
                con.DatabaseName = databasename;
                con.UserID = userid;
                con.Password = password;
                TableLogOnInfo Tinfo = new TableLogOnInfo();
                foreach (Table T in rpptc.Database.Tables)
                {
                    Tinfo = T.LogOnInfo;
                    Tinfo.ConnectionInfo = con;
                    T.ApplyLogOnInfo(Tinfo);
                }

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vrpratecostemp.rfdateorder} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vrpratecostemp.idemp} = '" + filterby + "'";
            }


            //{vrateoil.daterefil} = DateTime (0, 0, 0, 00, 00, 00)

            if (rpname == "rpsalecancle")
            {
                crvsalecancle rpsalecancle = new crvsalecancle();
                ConnectionInfo con = new ConnectionInfo();
                con.IntegratedSecurity = false;
                con.ServerName = servername;
                con.DatabaseName = databasename;
                con.UserID = userid;
                con.Password = password;
                TableLogOnInfo Tinfo = new TableLogOnInfo();
                foreach (Table T in rpsalecancle.Database.Tables)
                {
                    Tinfo = T.LogOnInfo;
                    Tinfo.ConnectionInfo = con;
                    T.ApplyLogOnInfo(Tinfo);
                }
                crystalReportViewer1.ReportSource = rpsalecancle;
            }

            if (rpname == "rppurchasecancle")
            {
                crvpurcancle rppurchase = new crvpurcancle();
                ConnectionInfo con = new ConnectionInfo();
                con.IntegratedSecurity = false;
                con.ServerName = servername;
                con.DatabaseName = databasename;
                con.UserID = userid;
                con.Password = password;
                TableLogOnInfo Tinfo = new TableLogOnInfo();
                foreach (Table T in rppurchase.Database.Tables)
                {
                    Tinfo = T.LogOnInfo;
                    Tinfo.ConnectionInfo = con;
                    T.ApplyLogOnInfo(Tinfo);
                }
                crystalReportViewer1.ReportSource = rppurchase;
            }

            if (rpname == "rpquatation")
            {
                crvquatation rpptc = new crvquatation();
                ConnectionInfo con = new ConnectionInfo();
                con.IntegratedSecurity = false;
                con.ServerName = servername;
                con.DatabaseName = databasename;
                con.UserID = userid;
                con.Password = password;
                TableLogOnInfo Tinfo = new TableLogOnInfo();
                foreach (Table T in rpptc.Database.Tables)
                {
                    Tinfo = T.LogOnInfo;
                    Tinfo.ConnectionInfo = con;
                    T.ApplyLogOnInfo(Tinfo);
                }

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vpaddressqua.idqua} = '" + idqua + "'";
                // this.WindowState = MaximumSize;
            }

            if (rpname == "crpTruckinAll")//report by brach   ********************************************
            {
                Crpbranchtruckin rpptc = new Crpbranchtruckin();
                ShowReportbyBranchTruckin(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";

            }

            if (rpname == "crpTruckinAllBranchBydatepur")//report by brach      **********************
            {
                Crpbranchtruckin rpptc = new Crpbranchtruckin();
                ShowReportbyBranchTruckin(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.datePur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) ";
            }

            if (rpname == "crpTruckinAllBranchBydatewbf")//report by brach      **********************
            {
                Crpbranchtruckin rpptc = new Crpbranchtruckin();
                ShowReportbyBranchTruckin(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) ";
            }


            if (rpname == "crpTruckinbyBranchbydatepur")//report by brach      **********************
            {
                Crpbranchtruckin rpptc = new Crpbranchtruckin();
                ShowReportbyBranchTruckin(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.datePur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckinRP.idbranch} = " + idbranch + "";
            }

            if (rpname == "crpTruckinbyBranchbydatewbf")//report by brach      **********************
            {
                Crpbranchtruckin rpptc = new Crpbranchtruckin();
                ShowReportbyBranchTruckin(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckinRP.idbranch} = " + idbranch + "";
            }


            if (rpname == "crpTruckinFiltter")//report by brach      **********************
            {
                Crpbranchtruckin rpptc = new Crpbranchtruckin();
                ShowReportbyBranchTruckin(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckinRP." + valuename + "} = '" + filterby + "'";
            }

            if (rpname == "crpTruckinFiltterbyBranch")//report by brach      **********************
            {
                Crpbranchtruckin rpptc = new Crpbranchtruckin();
                ShowReportbyBranchTruckin(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckinRP.idbranch} = " + idbranch + " AND {vWTrckinRP." + valuename + "} = '" + filterby + "'";
            }

            if (rpname == "crpTruckinFiltterbygraphday")//report by brach      **********************
            {
                crpbranchtruckinbydayGraph rpptc = new crpbranchtruckinbydayGraph();
                ShowReportTruckinDayGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckinRP." + valuename + "} = '" + filterby + "'";
            }

            if (rpname == "crpTruckinFiltterbygraphweek")//report by brach      **********************
            {
                crpbranchtruckinbyweekGraph rpptc = new crpbranchtruckinbyweekGraph();
                ShowReportTruckinWeekGraph(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckinRP." + valuename + "} = '" + filterby + "'";
            }

            if (rpname == "crpTruckinFiltterbygraphmont")//report by brach      **********************
            {
                crpbranchtruckinbymontGraph rpptc = new crpbranchtruckinbymontGraph();
                ShowReportTruckinMontGraph(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckinRP." + valuename + "} = '" + filterby + "'";
            }


            if (rpname == "crpTruckinFiltterbyBranchgraphday")//report by brach      **********************
            {
                crpbranchtruckinbydayGraph rpptc = new crpbranchtruckinbydayGraph();
                ShowReportTruckinDayGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckinRP.idbranch} = " + idbranch + " AND {vWTrckinRP." + valuename + "} = '" + filterby + "'";
            }

            if (rpname == "crpTruckinFiltterbyBranchgraphweek")//report by brach      **********************
            {
                crpbranchtruckinbyweekGraph rpptc = new crpbranchtruckinbyweekGraph();
                ShowReportTruckinWeekGraph(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckinRP.idbranch} = " + idbranch + " AND {vWTrckinRP." + valuename + "} = '" + filterby + "'";
            }

            if (rpname == "crpTruckinFiltterbyBranchgraphmont")//report by brach      **********************
            {
                crpbranchtruckinbymontGraph rpptc = new crpbranchtruckinbymontGraph();
                ShowReportTruckinMontGraph(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckinRP.idbranch} = " + idbranch + " AND {vWTrckinRP." + valuename + "} = '" + filterby + "'";
            }

            if (rpname == "crpTruckoutDayGraphorderdate")//report sale      ***************************************
            {
                crpbranchtruckoutbydayGraph rpptc = new crpbranchtruckoutbydayGraph();
                ShowReportTruckoutDayGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.orderdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpTruckoutDayGraphdateWbf")//report sale      ***************************************
            {
                crpbranchtruckoutbydayGraph rpptc = new crpbranchtruckoutbydayGraph();
                ShowReportTruckoutDayGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpTruckoutDayGraphdateWcus")//report sale      ***************************************
            {
                crpbranchtruckoutbydayGraph rpptc = new crpbranchtruckoutbydayGraph();
                ShowReportTruckoutDayGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.dateWcus} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpTruckoutWeekGraphorderdate")//report sale      ***************************************
            {
                crpbranchtruckoutbyweekGraph rpptc = new crpbranchtruckoutbyweekGraph();
                ShowReportTruckoutWeekGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.orderdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpTruckoutWeekGraphdateWbf")//report sale      ***************************************
            {
                crpbranchtruckoutbyweekGraph rpptc = new crpbranchtruckoutbyweekGraph();
                ShowReportTruckoutWeekGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpTruckoutWeekGraphdateWcus")//report sale      ***************************************
            {
                crpbranchtruckoutbyweekGraph rpptc = new crpbranchtruckoutbyweekGraph();
                ShowReportTruckoutWeekGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.dateWcus} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpTruckoutMontGraphorderdate")//report sale      ***************************************
            {
                crpbranchtruckoutbymontGraph rpptc = new crpbranchtruckoutbymontGraph();
                ShowReportTruckoutMontGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.orderdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }


            if (rpname == "crpTruckoutMontGraphdateWbf")//report sale      ***************************************
            {
                crpbranchtruckoutbymontGraph rpptc = new crpbranchtruckoutbymontGraph();
                ShowReportTruckoutMontGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpTruckoutMontGraphdateWcus")//report sale      ***************************************
            {
                crpbranchtruckoutbymontGraph rpptc = new crpbranchtruckoutbymontGraph();
                ShowReportTruckoutMontGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.dateWcus} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpTruckoutFillterDayGraphorderdate")//report sale      ***************************************
            {
                crpbranchtruckoutbydayGraph rpptc = new crpbranchtruckoutbydayGraph();
                ShowReportTruckoutDayGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.orderdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckoutRP." + valuename + "} = '" + filterby + "' ";
            }


            if (rpname == "crpTruckoutFillterWeekGraphorderdate")//report sale      ***************************************
            {
                crpbranchtruckoutbyweekGraph rpptc = new crpbranchtruckoutbyweekGraph();
                ShowReportTruckoutWeekGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.orderdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)AND {vWTrckoutRP." + valuename + "} = '" + filterby + "'";
            }
            
            if (rpname == "crpTruckoutFillterMontGraphorderdate")//report sale      ***************************************
            {
                crpbranchtruckoutbymontGraph rpptc = new crpbranchtruckoutbymontGraph();
                ShowReportTruckoutMontGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.orderdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckoutRP." + valuename + "} = '" + filterby + "'";
            }

            if (rpname == "crpTruckoutFillterDayGraphorderdateBranch")//report sale      ***************************************
            {
                crpbranchtruckoutbydayGraph rpptc = new crpbranchtruckoutbydayGraph();
                ShowReportTruckoutDayGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.orderdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckoutRP." + valuename + "} = '" + filterby + "'AND {vWTrckoutRP.idbranch} = " + idbranch + "";
            }
            
            if (rpname == "crpTruckoutFillterWeekGraphorderdateBranch")//report sale      ***************************************
            {
                crpbranchtruckoutbyweekGraph rpptc = new crpbranchtruckoutbyweekGraph();
                ShowReportTruckoutWeekGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.orderdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)AND {vWTrckoutRP." + valuename + "} = '" + filterby + "'AND {vWTrckoutRP.idbranch} = " + idbranch + "";
            }


            if (rpname == "crpTruckoutFillterMontGraphorderdateBranch")//report sale      ***************************************
            {
                crpbranchtruckoutbymontGraph rpptc = new crpbranchtruckoutbymontGraph();
                ShowReportTruckoutMontGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.orderdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckoutRP." + valuename + "} = '" + filterby + "'AND {vWTrckoutRP.idbranch} = " + idbranch + "";
            }


            if (rpname == "crpTruckoutDayGraphBranchorderdate")//report sale      ***************************************
            {
                crpbranchtruckoutbydayGraph rpptc = new crpbranchtruckoutbydayGraph();
                ShowReportTruckoutDayGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.orderdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckoutRP.idbranch} = " + idbranch + "";
            }

            if (rpname == "crpTruckoutDayGraphBranchdateWbf")//report sale      ***************************************
            {
                crpbranchtruckoutbydayGraph rpptc = new crpbranchtruckoutbydayGraph();
                ShowReportTruckoutDayGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckoutRP.idbranch} = " + idbranch + "";
            }

            if (rpname == "crpTruckoutDayGraphBranchdateWcus")//report sale      ***************************************
            {
                crpbranchtruckoutbydayGraph rpptc = new crpbranchtruckoutbydayGraph();
                ShowReportTruckoutDayGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.dateWcus} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckoutRP.idbranch} = " + idbranch + "";
            }


            if (rpname == "crpTruckoutWeekGraphBranchorderdate")//report sale      ***************************************
            {
                crpbranchtruckoutbyweekGraph rpptc = new crpbranchtruckoutbyweekGraph();
                ShowReportTruckoutWeekGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.orderdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckoutRP.idbranch} = " + idbranch + "";
            }

            if (rpname == "crpTruckoutWeekGraphBranchdateWbf")//report sale      ***************************************
            {
                crpbranchtruckoutbyweekGraph rpptc = new crpbranchtruckoutbyweekGraph();
                ShowReportTruckoutWeekGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckoutRP.idbranch} = " + idbranch + "";
            }

            if (rpname == "crpTruckoutWeekGraphBranchdateWcus")//report sale      ***************************************
            {
                crpbranchtruckoutbyweekGraph rpptc = new crpbranchtruckoutbyweekGraph();
                ShowReportTruckoutWeekGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.dateWcus} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckoutRP.idbranch} = " + idbranch + "";
            }

            if (rpname == "crpTruckoutMontGraphBranchorderdate")//report sale      ***************************************
            {
                crpbranchtruckoutbymontGraph rpptc = new crpbranchtruckoutbymontGraph();
                ShowReportTruckoutMontGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.orderdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)  AND {vWTrckoutRP.idbranch} = " + idbranch + "";
            }

            if (rpname == "crpTruckoutMontGraphBranchdateWbf")//report sale      ***************************************
            {
                crpbranchtruckoutbymontGraph rpptc = new crpbranchtruckoutbymontGraph();
                ShowReportTruckoutMontGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)  AND {vWTrckoutRP.idbranch} = " + idbranch + "";
            }

            if (rpname == "crpTruckoutMontGraphBranchdateWcus")//report sale      ***************************************
            {
                crpbranchtruckoutbymontGraph rpptc = new crpbranchtruckoutbymontGraph();
                ShowReportTruckoutMontGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.dateWcus} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)  AND {vWTrckoutRP.idbranch} = " + idbranch + "";
            }


            if (rpname == "crpTruckoutAllbyorderdate")//report by branch   ******************************
            {
                Crpbranchtruckout rpptc = new Crpbranchtruckout();
                ShowReportbyBranchTruckOut(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.orderdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) ";
            }

            if (rpname == "crpTruckoutAllbydateWbf")//report by branch   ******************************
            {
                Crpbranchtruckout rpptc = new Crpbranchtruckout();
                ShowReportbyBranchTruckOut(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) ";
            }

            if (rpname == "crpTruckoutAllbydateWcus")//report by branch   ******************************
            {
                Crpbranchtruckout rpptc = new Crpbranchtruckout();
                ShowReportbyBranchTruckOut(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.dateWcus} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) ";
            }

            if (rpname == "crpTruckoutAllbyorderdateBranch")//report by branch   ******************************
            {
                Crpbranchtruckout rpptc = new Crpbranchtruckout();
                ShowReportbyBranchTruckOut(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.orderdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckoutRP.idbranch} = " + idbranch + "";
            }//{vWTrckoutRP.idbranch} <> 0


            if (rpname == "crpTruckoutAllbydateWbfBranch")//report by branch   ******************************
            {
                Crpbranchtruckout rpptc = new Crpbranchtruckout();
                ShowReportbyBranchTruckOut(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckoutRP.idbranch} = " + idbranch + "";
            }


            if (rpname == "crpTruckoutAllbydateWcusBranch")//report by branch   ******************************
            {
                Crpbranchtruckout rpptc = new Crpbranchtruckout();
                ShowReportbyBranchTruckOut(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.dateWcus} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckoutRP.idbranch} = " + idbranch + "";
            }

            if (rpname == "crpTruckoutBranch")//report by brach   *****************************
            {
                Crpbranchtruckout rpptc = new Crpbranchtruckout();
                ShowReportbyBranchTruckOut(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckoutRP.idbranch} = " + idbranch + "";

            }

            if (rpname == "crpTruckinDayGraphbydatepur")//report truckin      ***************************************
            {
                crpbranchtruckinbydayGraph rpptc = new crpbranchtruckinbydayGraph();
                ShowReportTruckinDayGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.datePur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpTruckinDayGraphbydatepurBrach")//report truckin      ***************************************
            {
                crpbranchtruckinbydayGraph rpptc = new crpbranchtruckinbydayGraph();
                ShowReportTruckinDayGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.datePur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckinRP.idbranch} = " + idbranch + "";
            }

            if (rpname == "crpTruckinDayGraphbydatewbf")//report truckin      ***************************************
            {
                crpbranchtruckinbydayGraph rpptc = new crpbranchtruckinbydayGraph();
                ShowReportTruckinDayGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }


            if (rpname == "crpTruckinDayGraphbydatewbfBranch")//report truckin      ***************************************
            {
                crpbranchtruckinbydayGraph rpptc = new crpbranchtruckinbydayGraph();
                ShowReportTruckinDayGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckinRP.idbranch} = " + idbranch + "";
            }


            if (rpname == "crpTruckinWeekGraphbydatepur")//report truckin      ***************************************
            {
                crpbranchtruckinbyweekGraph rpptc = new crpbranchtruckinbyweekGraph();
                ShowReportTruckinWeekGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.datePur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpTruckinWeekGraphbydatepurBranch")//report truckin      ***************************************
            {
                crpbranchtruckinbyweekGraph rpptc = new crpbranchtruckinbyweekGraph();
                ShowReportTruckinWeekGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.datePur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckinRP.idbranch} = " + idbranch + "";
            }

            if (rpname == "crpTruckinWeekGraphbydatewbf")//report truckin      ***************************************
            {
                crpbranchtruckinbyweekGraph rpptc = new crpbranchtruckinbyweekGraph();
                ShowReportTruckinWeekGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpTruckinWeekGraphbydatewbfBranch")//report truckin      ***************************************
            {
                crpbranchtruckinbyweekGraph rpptc = new crpbranchtruckinbyweekGraph();
                ShowReportTruckinWeekGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckinRP.idbranch} = " + idbranch + "";
            }

            if (rpname == "crpTruckinMontGraphbydatepur")//report truckin      ***************************************
            {
                crpbranchtruckinbymontGraph rpptc = new crpbranchtruckinbymontGraph();
                ShowReportTruckinMontGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.datePur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpTruckinMontGraphbydatepurBranch")//report truckin      ***************************************
            {
                crpbranchtruckinbymontGraph rpptc = new crpbranchtruckinbymontGraph();
                ShowReportTruckinMontGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.datePur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckinRP.idbranch} = " + idbranch + "";
            }

            if (rpname == "crpTruckinMontGraphbydatewbf")//report truckin      ***************************************
            {
                crpbranchtruckinbymontGraph rpptc = new crpbranchtruckinbymontGraph();
                ShowReportTruckinMontGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpTruckinMontGraphbydatewbfBranch")//report truckin      ***************************************
            {
                crpbranchtruckinbymontGraph rpptc = new crpbranchtruckinbymontGraph();
                ShowReportTruckinMontGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckinRP.idbranch} = " + idbranch + "";
            }
            
            if (rpname == "crpTruckoutFiltterallbranch")//report by truckout   *****************************
            {
                Crpbranchtruckout rpptc = new Crpbranchtruckout();
                ShowReportbyBranchTruckOut(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckoutRP." + valuename + "} = '" + filterby + "'";

            }

            if (rpname == "crpTruckoutFiltterbranch")//report by truckout   *****************************
            {
                Crpbranchtruckout rpptc = new Crpbranchtruckout();
                ShowReportbyBranchTruckOut(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.SelectionFormula = "{vWTrckoutRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckoutRP." + valuename + "} = '" + filterby + "'AND {vWTrckoutRP.idbranch} = " + idbranch + "";

            }

            if (rpname == "crpPurchasequick")//report Purchase      ***************************************
            {
                crppur_chidmain rpptc = new crppur_chidmain();
                ShowReportPurchaseQuick(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWPurRP.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + startyear + "," + startmount + "," + startdate + ", 00, 00, 00)";
            }

            if (rpname == "crpPurchaseAll")//report Purchase      ***************************************
            {
                crppurchase rpptc = new crppurchase();
                ShowReportPurchase(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWPurRP.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpPurchaseAllDesign")//report Purchase      ***************************************
            {
                crppurchasedesign rpptc = new crppurchasedesign();
                //CrystalReport3 rpptc = new CrystalReport3();
                ShowReportPurchaseDesign(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWPurRP.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crppursumweigth")//report Purchase      ***************************************
            {
                crppursumweigth rpptc = new crppursumweigth();
                //CrystalReport3 rpptc = new CrystalReport3();
                ShowReportPurSumweight(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vpursumweigth.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "Crpphysicalpur")//report Purchase QC      ***************************************
            {
                LoadQcanalys();
            }


            if (rpname == "Crpphysicalsale")//report Purchase QC      ***************************************
            {
                LoadQcanalys();
            }
            
            if (rpname == "crppurordertranbysup")//report Purchase sum by sup      ***************************************
            {
                crppurchaseordertran rpptc = new crppurchaseordertran();
                //CrystalReport3 rpptc = new CrystalReport3();
                ShowReportPurorderbysup(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vrppurchase.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpPurchaseAllDesignSuccessbydatepur")//report Purchase      ***************************************
            {
                crppurchasedesignsuccess rpptc = new crppurchasedesignsuccess();
                ShowReportPurchaseDesignsuccess(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpPurchaseAllDesignSuccessbydateresive")//report Purchase      ***************************************
            {
                crppurchasedesignsuccess rpptc = new crppurchasedesignsuccess();
                ShowReportPurchaseDesignsuccess(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpPurchaseAllDesignSuccessbydatepurBranch")//report Purchase      ***************************************
            {
                crppurchasedesignsuccess rpptc = new crppurchasedesignsuccess();
                ShowReportPurchaseDesignsuccess(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckinRP.idbranch} = " + idbranch + "";
            }

            if (rpname == "crpPurchaseAllDesignSuccessbydateresiveBranch")//report Purchase      ***************************************
            {
                crppurchasedesignsuccess rpptc = new crppurchasedesignsuccess();
                ShowReportPurchaseDesignsuccess(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWTrckinRP.dateWbf} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWTrckinRP.idbranch} = " + idbranch + "";
            }

            if (rpname == "crpPurchaseDayGraph")//report Purchase      ***************************************
            {
                crppurbydayGraph rpptc = new crppurbydayGraph();
                ShowReportPurchaseDayGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWPurRP.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpPurchaseWeekGraph")//report Purchase      ***************************************
            {
                crppurbyweekGraph rpptc = new crppurbyweekGraph();
                ShowReportPurchaseWeekGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWPurRP.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpPurchaseMontGraph")//report Purchase      ***************************************
            {
                crppurbymontGraph rpptc = new crppurbymontGraph();
                ShowReportPurchaseMontGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWPurRP.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpPurchaseFiltter")//report Purchase      ******************************************
            {
                crppurchase rpptc = new crppurchase();
                ShowReportPurchase(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWPurRP.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWPurRP." + valuename + "} = '" + filterby + "'";
            }

            if (rpname == "crpSalequick")//report Sale   ***********************************
            {
                crpsale_chidmain rpptc = new crpsale_chidmain();
                ShowReportSale_childmain(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vsaleorder.orderdate} in DateTime(" + startyear + "," + startmount + "," + startdate + ",00,00,00) to DateTime (" + startyear + "," + startmount + "," + startdate + ",00,00,00)";

            }

            if (rpname == "crpSaleAll")//report Sale   ***********************************
            {
                crpsale rpptc = new crpsale();
                ShowReportSale(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vsaleorder.orderdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vsaleorder.idstatus} <> 7";
            }

            if (rpname == "crpSaleDayGraph")//report sale      ***************************************
            {
                crpsalebydayGraph rpptc = new crpsalebydayGraph();
                ShowReportSaleDayGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWSaleRP.orderdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpSaleDayGraph")//report sale      ***************************************
            {
                crpsalebydayGraph rpptc = new crpsalebydayGraph();
                ShowReportSaleDayGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWSaleRP.orderdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }


            if (rpname == "crpSaleWeekGraph")//report sale      ***************************************
            {
                crpsalebyweekGraph rpptc = new crpsalebyweekGraph();
                ShowReportSaleWeekGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWSaleRP.orderdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";

            }

            if (rpname == "crpSaleMontGraph")//report sale      ***************************************
            {
                crpsalebymontGraph rpptc = new crpsalebymontGraph();
                ShowReportSaleMontGraph(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWSaleRP.orderdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";

            }

            if (rpname == "crpSaleFiltter")//report Sale    *********************************
            {
                crpsale rpptc = new crpsale();
                ShowReportSale(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWSaleRP.orderdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND  {vWSaleRP." + valuename + "} = '" + filterby + "'";
            }

            if (rpname == "crpStockAllnow")//report Sale    *********************************
            {
                crpstock rpptc = new crpstock();
                ShowReportStocknow(servername, databasename, userid, password, rpptc);
            }

            if (rpname == "crpStockFiltternow")//report Sale    *********************************
            {
                crpstock rpptc = new crpstock();
                ShowReportStocknow(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.SelectionFormula = "{vproductinstock.idbranch} = " + idbranch + "";
            }

            if (rpname == "crpStockAllold")//report Sale    *********************************
            {
                crpstocksumday rpptc = new crpstocksumday();
                ShowReportStockold(servername, databasename, userid, password, rpptc);
            }

            if (rpname == "crpStockFiltterold")//report Sale    *********************************
            {
                crpstocksumday rpptc = new crpstocksumday();
                ShowReportStockold(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.SelectionFormula = "{vproductstock.stockdate} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + startyear + "," + startmount + "," + startdate + ", 00, 00, 00) AND {vproductstock.idbranch}  = " + idbranch + "";
            }

            if (rpname == "crpStockAllhisday")//report Sale    *********************************
            {
                crpstockday rpptc = new crpstockday();
                ShowReportStockhistory(servername, databasename, userid, password, rpptc);
            }

            if (rpname == "crpStockFiltterhisday")//report Sale    *********************************
            {
                crpstockday rpptc = new crpstockday();
                ShowReportStockhistory(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.SelectionFormula = "{vhistockday.datehis} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vhistockday.idbranch}  = " + idbranch + "";
            }


            if (rpname == "crpPurtoSaleAll")//report FS    
            {
                crppurtosaletrucknopass rpptc = new crppurtosaletrucknopass();
                ShowReportPurtoSaleNopass(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.SelectionFormula = "{vWFsTCrp.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            }

            if (rpname == "crpPurtoSaleFilbyOrderdateTrucknopass")//report FS    ************************************
            {
                crppurtosaletrucknopass rpptc = new crppurtosaletrucknopass();
                ShowReportPurtoSaleNopass(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.SelectionFormula = "{vWFsTCrp.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND ISNULL({vWFsTCrp.idbranch})";

                //{vWFsTCrp." + valuename + "}  = '" + filterby + "'
            }

            if (rpname == "crpPurtoSaleFilbyOrderdateTruckpass")//report FS    ************************************
            {
                crppurtosaletruckpass rpptc = new crppurtosaletruckpass();
                ShowReportPurtoSalePass(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.SelectionFormula = "{vWFsTCrp.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWFsTCrp.idbranch}  = " + filterby + "";
            }

            if (rpname == "crpPurtoSaleFilbySenddatenopass")//report FS   ************************************
            {
                crppurtosaletrucknopass rpptc = new crppurtosaletrucknopass();
                ShowReportPurtoSaleNopass(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.SelectionFormula = "{vWFsTCrp.dateWcus} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)AND ISNULL({vWFsTCrp.idbranch}) ";
            }

            if (rpname == "crpPurtoSaleFilbySenddatepass")//report FS   ************************************
            {
                crppurtosaletruckpass rpptc = new crppurtosaletruckpass();
                ShowReportPurtoSalePass(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.SelectionFormula = "{vWFsTCrp.dateWcus} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND {vWFsTCrp.idbranch}  = " + filterby + " ";
            }

            if (rpname == "crpPurtoSaleFilby")//report sale      ***************************************
            {
                crppurtosaletrucknopass rpptc = new crppurtosaletrucknopass();
                ShowReportPurtoSaleNopass(servername, databasename, userid, password, rpptc);
                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vWFsTCrp.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND  {vWFsTCrp." + valuename + "}  = '" + filterby + "'";
            }


            //if (rpname == "crpPurtoSaleSumSale")//report FS    ************************************
            //{
            //    crppurtosalefilbycomsale rpptc = new crppurtosalefilbycomsale();
            //    ShowReportPurtosaleSumSale(servername, databasename, userid, password, rpptc);
            //    crystalReportViewer1.SelectionFormula = "{vFsTcFortrasport.datepur} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00)";
            //}

            //{vtranreplyFsTc.dateWbf}
            if (rpname == "rprateoilfillserail")//report sale      ***************************************
            {
                crprateoil rpptc = new crprateoil();
                ShowReportRateoilFilbyserail(servername, databasename, userid, password, rpptc);

                crystalReportViewer1.ReportSource = rpptc;
                crystalReportViewer1.SelectionFormula = "{vrateoil.daterefil} in DateTime (" + startyear + "," + startmount + "," + startdate + ",00, 00, 00) to DateTime (" + endyear + "," + endmount + "," + enddate + ", 00, 00, 00) AND  {vrateoil.truckserail} = '" + filterby + "'";


            }

            //}{vrateoil.truckserail} 
            //catch (Exception ex)
            //{ MessageBox.Show(ex.Message); }        
        }

        private void ShowReportPhysicalProPur(string servername, string databasename, string userid, string password, Crpphysicalpur rpptc)//รายงาน qc purchase
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ShowReportRateoilFilbyserail(string servername, string databasename, string userid, string password, crprateoil rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ShowReportPurtosaleSumSale(string servername, string databasename, string userid, string password, crppurtosalefilbycomsale rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ShowReportPurtosaleSumPurchase(string servername, string databasename, string userid, string password, crppurtosalefilbycompur rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ShowReportPurtoSaleNopass(string servername, string databasename, string userid, string password, crppurtosaletrucknopass rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }
            rpptc.SetParameterValue("caption", cationname);
            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ShowReportPurtoSalePass(string servername, string databasename, string userid, string password, crppurtosaletruckpass rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }
            rpptc.SetParameterValue("caption", cationname);
            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ShowReportStocknow(string servername, string databasename, string userid, string password, crpstock rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ShowReportStockold(string servername, string databasename, string userid, string password, crpstocksumday rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ShowReportStockhistory(string servername, string databasename, string userid, string password, crpstockday rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }

            rpptc.SetParameterValue("sttdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
            crystalReportViewer1.ReportSource = rpptc;

        }

        private void ShowReportSale(string servername, string databasename, string userid, string password, crpsale rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }

            rpptc.SetParameterValue("caption", cationname);
            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
        }

        private void ShowReportSale_childmain(string servername, string databasename, string userid, string password, crpsale_chidmain rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }
        }

        private void ShowReportPurchaseQuick(string servername, string databasename, string userid, string password, crppur_chidmain rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }


            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
        }

        private void ShowReportPurchase(string servername, string databasename, string userid, string password, crppurchase rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }

            rpptc.SetParameterValue("caption", cationname);
            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
        }

        private void ShowReportPurchaseDesign(string servername, string databasename, string userid, string password, crppurchasedesign rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }

            rpptc.SetParameterValue("caption", cationname);
            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
        }

        private void ShowReportPurSumweight(string servername, string databasename, string userid, string password, crppursumweigth rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }

            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
        }

        private void ShowReportPurorderbysup(string servername, string databasename, string userid, string password, crppurchaseordertran rpptc)//รายงานแบบแจกแจงขนส่ง
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }

            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
        }

        private void ShowReportPurchaseDesignsuccess(string servername, string databasename, string userid, string password, crppurchasedesignsuccess rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }

            rpptc.SetParameterValue("caption", cationname);
            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
        }

        private void ShowReportPurchaseDayGraph(string servername, string databasename, string userid, string password, crppurbydayGraph rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }
            rpptc.SetParameterValue("caption", cationname);
            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ShowReportPurchaseWeekGraph(string servername, string databasename, string userid, string password, crppurbyweekGraph rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }
            rpptc.SetParameterValue("caption", cationname);
            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ShowReportPurchaseMontGraph(string servername, string databasename, string userid, string password, crppurbymontGraph rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }
            rpptc.SetParameterValue("caption", cationname);
            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ShowReportSaleDayGraph(string servername, string databasename, string userid, string password, crpsalebydayGraph rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }
            rpptc.SetParameterValue("caption", cationname);
            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ShowReportSaleWeekGraph(string servername, string databasename, string userid, string password, crpsalebyweekGraph rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }
            rpptc.SetParameterValue("caption", cationname);
            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ShowReportSaleMontGraph(string servername, string databasename, string userid, string password, crpsalebymontGraph rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }
            rpptc.SetParameterValue("caption", cationname);
            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ShowReportbyBranchTruckin(string servername, string databasename, string userid, string password, Crpbranchtruckin rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }

            rpptc.SetParameterValue("caption", cationname);
            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ShowReportTruckinDayGraph(string servername, string databasename, string userid, string password, crpbranchtruckinbydayGraph rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }
            rpptc.SetParameterValue("caption", cationname);
            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ShowReportTruckinWeekGraph(string servername, string databasename, string userid, string password, crpbranchtruckinbyweekGraph rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }
            rpptc.SetParameterValue("caption", cationname);
            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ShowReportTruckinMontGraph(string servername, string databasename, string userid, string password, crpbranchtruckinbymontGraph rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }
            rpptc.SetParameterValue("caption", cationname);
            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ShowReportbyBranchTruckinbyserail(string servername, string databasename, string userid, string password, Crpbranchgtruckinsortbyserail rpbsel)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpbsel.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }

            rpbsel.SetParameterValue("cation", cationname);
            rpbsel.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpbsel.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
            crystalReportViewer1.ReportSource = rpbsel;
        }

        private void ShowReportbyBranchTruckoutbyserail(string servername, string databasename, string userid, string password, Crpbranchgtruckoutsortbyserail rpbsel)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpbsel.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }

            rpbsel.SetParameterValue("cation", cationname);
            rpbsel.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpbsel.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
            crystalReportViewer1.ReportSource = rpbsel;
        }

        private void ShowReportbyBranchTruckOut(string servername, string databasename, string userid, string password, Crpbranchtruckout rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }

            rpptc.SetParameterValue("cation", cationname);
            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ShowReportTruckoutDayGraph(string servername, string databasename, string userid, string password, crpbranchtruckoutbydayGraph rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }
            rpptc.SetParameterValue("caption", cationname);
            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ShowReportTruckoutWeekGraph(string servername, string databasename, string userid, string password, crpbranchtruckoutbyweekGraph rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }
            rpptc.SetParameterValue("caption", cationname);
            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ShowReportTruckoutMontGraph(string servername, string databasename, string userid, string password, crpbranchtruckoutbymontGraph rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }
            rpptc.SetParameterValue("caption", cationname);
            rpptc.SetParameterValue("stdate", startdate + "/" + startmount + "/" + startyear);
            rpptc.SetParameterValue("eddate", enddate + "/" + endmount + "/" + endyear);
            crystalReportViewer1.ReportSource = rpptc;
        }

        private void ConnectionCrystonReportWrpptc(string servername, string databasename, string userid, string password, crtuckinfilbybrach rpptc)
        {
            ConnectionInfo con = new ConnectionInfo();
            con.IntegratedSecurity = false;
            con.ServerName = servername;
            con.DatabaseName = databasename;
            con.UserID = userid;
            con.Password = password;
            TableLogOnInfo Tinfo = new TableLogOnInfo();
            foreach (Table T in rpptc.Database.Tables)
            {
                Tinfo = T.LogOnInfo;
                Tinfo.ConnectionInfo = con;
                T.ApplyLogOnInfo(Tinfo);
            }

            crystalReportViewer1.ReportSource = rpptc;
        }

        private void LoadQcanalys()
        {
            DataSet dsImg = new DataSet(); // ผ่านข้อมูลให้ Crystal Report
            SqlDataReader sdr;// อ่านข้อมูลจาก sql base

            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); string sql = ""; DataTable dt = new DataTable();

            if (rpname == "Crpphysicalpur")
            {
                sql = "select * from vphysicalpurchaseRP Where  (datepur BETWEEN '" + startmount + "/" + startdate + "/" + startyear + "' AND '" + endmount + "/" + enddate + "/" + endyear + "') order by idpur ";
                dt = new DataTable("crtphysicalpurchase");
                dt.Columns.Add(new DataColumn("idtran", typeof(string)));
                dt.Columns.Add(new DataColumn("idpur", typeof(string)));
                dt.Columns.Add(new DataColumn("datepur", typeof(string)));
                dt.Columns.Add(new DataColumn("comsup", typeof(string)));
                dt.Columns.Add(new DataColumn("weigthsup", typeof(decimal)));               
            }

            if (rpname == "Crpphysicalsale")
            {
                sql = "select * from vphysicalsaleRP Where  (orderdate BETWEEN '" + startmount + "/" + startdate + "/" + startyear + "' AND '" + endmount + "/" + enddate + "/" + endyear + "') order by idorder ";
                dt = new DataTable("crtphysicalsale");
                dt.Columns.Add(new DataColumn("idtran", typeof(string)));
                dt.Columns.Add(new DataColumn("idorder", typeof(string)));
                dt.Columns.Add(new DataColumn("orderdate", typeof(string)));
                dt.Columns.Add(new DataColumn("comcus", typeof(string)));
                dt.Columns.Add(new DataColumn("weigthcus", typeof(decimal)));                
            }

            //สร้าง temp table Add column ตาม DataSet       
            dt.Columns.Add(new DataColumn("comtran", typeof(string)));
            dt.Columns.Add(new DataColumn("carname", typeof(string)));
            dt.Columns.Add(new DataColumn("serailcar", typeof(string)));
            dt.Columns.Add(new DataColumn("proname", typeof(string)));
            dt.Columns.Add(new DataColumn("weigthnet", typeof(decimal)));
            dt.Columns.Add(new DataColumn("weigthsupdfsale", typeof(decimal)));
            dt.Columns.Add(new DataColumn("moisture", typeof(string)));
            dt.Columns.Add(new DataColumn("kkperweigth", typeof(string)));
            dt.Columns.Add(new DataColumn("namesize", typeof(string)));
            dt.Columns.Add(new DataColumn("namecolor", typeof(string)));
            dt.Columns.Add(new DataColumn("namephysical", typeof(string)));
            dt.Columns.Add(new DataColumn("namedebased", typeof(string)));
            dt.Columns.Add(new DataColumn("comment", typeof(string)));
            //dt.Columns.Add(new DataColumn("comment", typeof(string)));
            dt.Columns.Add(new DataColumn("urlimage", typeof(string)));
            dt.Columns.Add(new DataColumn("image", typeof(System.Byte[]))); // DataType ของ Photo เป็น System.Byte[]
            dsImg.Tables.Add(dt);// Add table เข้าไปใน DataSet 

            SqlDataAdapter da = new SqlDataAdapter(sql, CN);
            sdr = da.SelectCommand.ExecuteReader();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    //   string urlimage = Application.StartupPath + "\\" + sdr["urlimage"].ToString();
                    string urlimage = sdr["urlimage"].ToString();

                    FileStream FilStr = new FileStream(urlimage, FileMode.Open);// เปิด file แบบ Stream เพื่ออ่านเป็น Binary
                    BinaryReader BinRed = new BinaryReader(FilStr);
                    DataRow dr = dt.NewRow();

                    if (rpname == "Crpphysicalpur")
                    {
                        dr = dsImg.Tables["crtphysicalpurchase"].NewRow(); //เพิ่ม Rows ใหม่                         
                        dr["idpur"] = sdr["idpur"];
                        dr["datepur"] = sdr["datepur"];
                        dr["comsup"] = sdr["comsup"];
                        dr["weigthsup"] = sdr["weigthsup"];                       
                    }

                    if (rpname == "Crpphysicalsale")
                    {
                        dr = dsImg.Tables["crtphysicalsale"].NewRow(); //เพิ่ม Rows ใหม่                         
                        dr["idorder"] = sdr["idorder"];
                        dr["orderdate"] = sdr["orderdate"];
                        dr["comcus"] = sdr["comcus"];
                        dr["weigthcus"] = sdr["weigthcus"];                        
                    }

                    // Add ข้อมูลที่อ่านจาก SQL Base ใส่เข้าไปแต่ละ Rows ของ Temp Table

                    dr["idtran"] = sdr["idtran"];
                    dr["comtran"] = sdr["comtran"];
                    dr["carname"] = sdr["carname"];
                    dr["serailcar"] = sdr["serailcar"];
                    dr["proname"] = sdr["proname"];
                    dr["weigthnet"] = sdr["weigthnet"];
                    dr["weigthsupdfsale"] = sdr["weigthsupdfsale"];
                    dr["moisture"] = sdr["moisture"];
                    dr["kkperweigth"] = sdr["kkperweigth"];
                    dr["namesize"] = sdr["namesize"];
                    dr["namecolor"] = sdr["namecolor"];
                    dr["namephysical"] = sdr["namephysical"];
                    dr["namedebased"] = sdr["namedebased"];
                    dr["comment"] = sdr["comment"];
                    dr["urlimage"] = sdr["urlimage"];
                    // Column Photo ใส่ข้อมูล  Binary
                    dr["image"] = BinRed.ReadBytes((int)BinRed.BaseStream.Length);

                    if (rpname == "Crpphysicalpur")
                    {
                        dsImg.Tables["crtphysicalpurchase"].Rows.Add(dr); //Add Row เข้าไปใน Temp Table
                    }
                    if (rpname == "Crpphysicalsale")
                    {
                        dsImg.Tables["crtphysicalsale"].Rows.Add(dr); //Add Row เข้าไปใน Temp Table
                    }
                    // คืน memory ให้ OS
                    FilStr.Close(); //ปิด FileStream
                    BinRed.Close(); //ปิด BinaryReader
                }

                // คืน memory ให้ OS
                sdr.Close();
                CN.Close();

               
                if (rpname == "Crpphysicalpur")
                { 
                    Crpphysicalpur crp = new Crpphysicalpur();
                    crp.SetDataSource(dsImg.Tables["crtphysicalpurchase"]);
                    crystalReportViewer1.ReportSource = crp; 
                }
                if (rpname == "Crpphysicalsale")
                { 
                   Crpphysicalsale crp=new Crpphysicalsale();
                    crp.SetDataSource(dsImg.Tables["crtphysicalsale"]);
                crystalReportViewer1.ReportSource = crp;; 
                }
               
                crystalReportViewer1.Refresh();

            }
        }

    }
}