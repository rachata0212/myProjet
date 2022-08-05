using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace SaleOrder
{
    public partial class Frmserch : Form
    {
        public Frmserch()
        {
            InitializeComponent();
        }


        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //public int empid = ""; int convertvalue = 0;
        public string returnid = "0"; public string sname = "";
        dtssaleorder dssearch = new dtssaleorder(); DataSet ds = new DataSet();

        private void Frmserch_Load(object sender, EventArgs e)
        {
            ds.Clear();
            dssearch.Clear();
            string sql;
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); txtvalue.Focus();

            if (sname == "sempcom")
            {
                dtgscom.DataSource = dssearch;

                sql = "select * from vempcom";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "scom");
                dtgscom.DataSource = ds.Tables["scom"];
                txtcount.Text = dtgscom.RowCount.ToString();
                lblmsn.Text = "ค้นหาบริษัท";
                dtgscom.Visible = true; dtgscom.Dock = DockStyle.Fill;
                dtgscom.BringToFront();
            }  

            if (sname == "sdep")
            {               
                dtgsdep.DataSource = dssearch;
               
                sql = "select * from vdepartment";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "sdep");
                dtgsdep.DataSource = ds.Tables["sdep"];
                txtcount.Text = dtgsdep.RowCount.ToString();
                lblmsn.Text = "ค้นหาแผนกพนักงาน";
                dtgsdep.Visible = true; dtgsdep.Dock = DockStyle.Fill;
                dtgsdep.BringToFront();
            }          

            if (sname == "stypeemp")
            {              
                dtgstypeemp.DataSource = dssearch;
                
                sql = "select * from vemptype ";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "stypeemp");
                dtgstypeemp.DataSource = ds.Tables["stypeemp"];
                txtcount.Text = dtgstypeemp.RowCount.ToString();
                lblmsn.Text = "ค้นหาประเภทพนักงาน";
                dtgstypeemp.Visible = true; dtgstypeemp.Dock = DockStyle.Fill;
                dtgstypeemp.BringToFront();
            }

            if (sname == "ssupcom")
            {                
                dtgscom.DataSource = dssearch;

                sql = "select * from vcompany where idtypecom = 2 or idtypecom = 4 ";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "scomsup");
                dtgscom.DataSource = ds.Tables["scomsup"];
                txtcount.Text = dtgscom.RowCount.ToString();
                lblmsn.Text = "ค้นหาบริษัทผู้จำหน่าย";
                dtgscom.Visible = true; dtgscom.Dock = DockStyle.Fill;
                dtgscom.BringToFront();
            }

            if (sname == "spurcom")
            {
                dtgscom.DataSource = dssearch;

                sql = "select idcom,cname,bname from vcompany where idtypecom = 4 ";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "scompur");
                dtgscom.DataSource = ds.Tables["scompur"];
                txtcount.Text = dtgscom.RowCount.ToString();
                lblmsn.Text = "ค้นหาบริษัทซื้อ";
                dtgscom.Visible = true; dtgscom.Dock = DockStyle.Fill;
                dtgscom.BringToFront(); 
            }

            if (sname == "ssendcom")
            {
                dtgscom.DataSource = dssearch;

                sql = "select * from vcompany where idtypecom = 3 or idtypecom = 4";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "scomtran");
                dtgscom.DataSource = ds.Tables["scomtran"];
                txtcount.Text = dtgscom.RowCount.ToString();
                lblmsn.Text = "ค้นหาบริษัทขนส่ง";
                dtgscom.Visible = true; dtgscom.Dock = DockStyle.Fill;
                dtgscom.BringToFront();
            }

            if (sname == "sallcom")
            {
                dtgscom.DataSource = dssearch;

                sql = "select * from vcompany";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "scomtran");
                dtgscom.DataSource = ds.Tables["scomtran"];
                txtcount.Text = dtgscom.RowCount.ToString();
                lblmsn.Text = "ค้นหาบริษัททั้งหมด";
                dtgscom.Visible = true; dtgscom.Dock = DockStyle.Fill;
                dtgscom.BringToFront();
            }

            if (sname == "scar")
            {
                dtgscar.DataSource = dssearch;
                sql = "select * from vcar ";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "scar");
                dtgscar.DataSource = ds.Tables["scar"];
                txtcount.Text = dtgscar.RowCount.ToString();
                lblmsn.Text = "ค้นหาบริษัทขนส่ง";
                dtgscar.Visible = true; dtgscar.Dock = DockStyle.Fill;
                dtgscar.BringToFront();
            }

            if (sname == "spropur")
            {
                dtgpropur.DataSource = dssearch;

                sql = "select * from tbproduct";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "spropur");
                dtgpropur.DataSource = ds.Tables["spropur"];
                txtcount.Text = dtgpropur.RowCount.ToString();
                lblmsn.Text = "ค้นหาสินค้า";
                dtgpropur.Visible = true; dtgpropur.Dock = DockStyle.Fill;
                dtgpropur.BringToFront();
            }

            if (sname == "spro")
            {
                dtgspro.DataSource = dssearch;

                sql = "select * from vproduct ";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "spro");
                dtgspro.DataSource = ds.Tables["spro"];
                txtcount.Text = dtgspro.RowCount.ToString();
                lblmsn.Text = "ค้นหาสินค้า";
                dtgspro.Visible = true; dtgspro.Dock = DockStyle.Fill;
                dtgspro.BringToFront();
            }

            if (sname == "sempsale")
            {
                dtgsempsale.DataSource = dssearch;

                sql = "select * from vempsale ";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "sempsale");
                dtgsempsale.DataSource = ds.Tables["sempsale"];
                txtcount.Text = dtgsempsale.RowCount.ToString();
                lblmsn.Text = "ค้นหาพนักงานขาย";
                dtgsempsale.Visible = true; dtgsempsale.Dock = DockStyle.Fill;
                dtgsempsale.BringToFront();
            }

            if (sname == "sempployee")
            {
                dtgsempsale.DataSource = dssearch;
                sql = "select * from vemployee ";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "semp");
                dtgsempsale.DataSource = ds.Tables["semp"];
                txtcount.Text = dtgsempsale.RowCount.ToString();
                lblmsn.Text = "ค้นหาพนักงาน";
                dtgsempsale.Visible = true; dtgsempsale.Dock = DockStyle.Fill;
                dtgsempsale.BringToFront();
            }

            if (sname == "sempdriver")
            {
                dtgsempsale.DataSource = dssearch;

                sql = "select * from vemployee where idposition = 13 OR idposition = 18 ";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "semp");
                dtgsempsale.DataSource = ds.Tables["semp"];
                txtcount.Text = dtgsempsale.RowCount.ToString();
                lblmsn.Text = "ค้นหาพนักงานขับรถ";
                dtgsempsale.Visible = true; dtgsempsale.Dock = DockStyle.Fill;
                dtgsempsale.BringToFront();
            }


            if (sname == "scomcus")
            {
                dtgscom.DataSource = dssearch;

                sql = "select * from vcompany where idtypecom = 1 or idtypecom = 4";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "scomcus");
                dtgscom.DataSource = ds.Tables["scomcus"];
                txtcount.Text = dtgscom.RowCount.ToString();
                lblmsn.Text = "ค้นหาบริษัทลูกค้า";
                dtgscom.Visible = true; dtgscom.Dock = DockStyle.Fill;
                dtgscom.BringToFront();
            }

            if (sname == "sbranch")
            {              
                    dtgbranch.DataSource = dssearch;
                    sql = "select * from tbbrach order by idbranch desc";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "sbranch");
                    dtgbranch.DataSource = ds.Tables["sbranch"];
                    txtcount.Text = dtgbranch.RowCount.ToString();
                    lblmsn.Text = "ค้นหาสาขา";
                    dtgbranch.Visible = true; dtgbranch.Dock = DockStyle.Fill;
                    dtgbranch.BringToFront();
            }
            
            if (sname == "stypecom")
            {
                dtgtypecom.DataSource = dssearch;

                sql = "select * from tbtypecom ";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "stypecom");
                dtgtypecom.DataSource = ds.Tables["stypecom"];
                txtcount.Text = dtgtypecom.RowCount.ToString();
                lblmsn.Text = "ค้นหาประเภทบริษัท";
                dtgtypecom.Visible = true; dtgtypecom.Dock = DockStyle.Fill;
                dtgtypecom.BringToFront();
            }

            if (sname == "ssubpro")
            {
                dtgsubpro.DataSource = dssearch;

                sql = "select * from vsupproduct order by namesup";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "vtypepro");
                dtgsubpro.DataSource = ds.Tables["vtypepro"];
                txtcount.Text = dtgsubpro.RowCount.ToString();
                lblmsn.Text = "ค้นหาสินค้าย่อย";
                dtgsubpro.Visible = true; dtgsubpro.Dock = DockStyle.Fill;
                dtgsubpro.BringToFront();               
            }

            if (sname == "sposition")
            {
                dtgsubpro.DataSource = dssearch;
                sql = "select * from vposition order by idposition";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "vposition");
                dtgsposition.DataSource = ds.Tables["vposition"];
                txtcount.Text = dtgsposition.RowCount.ToString();
                lblmsn.Text = "ค้นหาสินค้าย่อย";
                dtgsposition.Visible = true; dtgsposition.Dock = DockStyle.Fill;
                dtgsposition.BringToFront();
            }

            if (sname == "scomcostrate")
            {
                dtgscom.DataSource = dssearch;

                sql = "select idcom,cname,bname from vcompany";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "scomsup");
                dtgscom.DataSource = ds.Tables["scomsup"];
                txtcount.Text = dtgscom.RowCount.ToString();
                lblmsn.Text = "ค้นหาบริษัทในการกำหนดระยะทาง";
                dtgscom.Visible = true; dtgscom.Dock = DockStyle.Fill;
                dtgscom.BringToFront();
            }

            if (sname == "scomcusquatation")
            {
                dtgcomcusquatation.DataSource = dssearch;

                sql = "select idcom,cname,bname from vcompany";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "comquatation");
                dtgcomcusquatation.DataSource = ds.Tables["comquatation"];
                txtcount.Text = dtgcomcusquatation.RowCount.ToString();
                lblmsn.Text = "ค้นหาบริษัทในการกำหนดระยะทาง";
                dtgcomcusquatation.Visible = true; dtgcomcusquatation.Dock = DockStyle.Fill;
                dtgcomcusquatation.BringToFront();
            }

            if (sname == "svbranch")
            {
                dtgvbranch.DataSource = dssearch;

                sql = "select idbranch,cname,bname,provice from vbranch where idtypecom = 2 order by idbranch";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "vbranch");
                dtgvbranch.DataSource = ds.Tables["vbranch"];
                txtcount.Text = dtgvbranch.RowCount.ToString();
                lblmsn.Text = "ค้นหาบริษัทโรงปาล์ม";
                dtgvbranch.Visible = true; dtgvbranch.Dock = DockStyle.Fill;
                dtgvbranch.BringToFront();
            }

            if (sname == "sareapurchase")
            {
                dtgareapurchase.DataSource = dssearch;
                sql = "select * from tbareapriceplam";
                SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                da1.Fill(ds, "areapur");
                dtgareapurchase.DataSource = ds.Tables["areapur"];
                txtcount.Text = dtgareapurchase.RowCount.ToString();
                lblmsn.Text = "ค้นหาโซนพื้นที่การซื้อ";
                dtgareapurchase.Visible = true; dtgareapurchase.Dock = DockStyle.Fill;
                dtgareapurchase.BringToFront();
            }
            CN.Close();
        }

        private void dtgsdep_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtid.Text = dtgsdep[0, e.RowIndex].Value.ToString();
            txtdetail.Text = dtgsdep[1, e.RowIndex].Value.ToString();
            returnid = Convert.ToString(dtgsdep[0, e.RowIndex].Value.ToString().Trim());
        }

        private void dtgsdep_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            {
                returnid = Convert.ToString(dtgsdep[0, e.RowIndex].Value.ToString().Trim());
                this.Close();
            }
        }       

        private void dtgscom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            {
                returnid = Convert.ToString(dtgscom[0, e.RowIndex].Value.ToString().Trim());
                this.Close();
            }
        }

        private void dtgscom_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtid.Text = dtgscom[0, e.RowIndex].Value.ToString();
            txtdetail.Text = dtgscom[1, e.RowIndex].Value.ToString();
            returnid = Convert.ToString(dtgscom[0, e.RowIndex].Value.ToString().Trim());
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("ผิดพลาด !", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtvalue_TextChanged(object sender, EventArgs e)
        {
            ds.Clear();
            dssearch.Clear();
            string sql;
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (sname == "scom")  // Search Company
            {
                if (rdioid.Checked == true)
                {
                    dtgscom.DataSource = dssearch;
                    sql = "select * from vcompany  where idcom like '%" + txtvalue.Text.Trim() + "%'";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "scom");
                    dtgscom.DataSource = ds.Tables["scom"];
                    txtcount.Text = dtgscom.RowCount.ToString();
                }

                else if (rdioname.Checked == true)
                {
                    dtgscom.DataSource = dssearch;

                    sql = "select * from vcompany  where cname like '%" + txtvalue.Text.Trim() + "%'";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "scom");
                    dtgscom.DataSource = ds.Tables["scom"];
                    txtcount.Text = dtgscom.RowCount.ToString();
                }
            }
            //////////////----
            if (sname == "ssupcom")  // Search Company
            {
                if (rdioid.Checked == true)
                {
                    dtgscom.DataSource = dssearch;

                    sql = "select * from vcompany  where idcom like '%" + txtvalue.Text.Trim() + "%'AND idtypecom = 2";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "ssupcom");
                    dtgscom.DataSource = ds.Tables["ssupcom"];
                    txtcount.Text = dtgscom.RowCount.ToString();
                }

                else if (rdioname.Checked == true)
                {
                    dtgscom.DataSource = dssearch;

                    sql = "select * from vcompany  where cname like '%" + txtvalue.Text.Trim() + "%' AND idtypecom = 2";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "ssupcom");
                    dtgscom.DataSource = ds.Tables["ssupcom"];
                    txtcount.Text = dtgscom.RowCount.ToString();
                }
            }

            if (sname == "spurcom")  // Search com purchase
            {
                if (rdioid.Checked == true)
                {
                    dtgscom.DataSource = dssearch;

                    sql = "select * from vcompany  where idcom like '%" + txtvalue.Text.Trim() + "%'AND idcom = 'C003' or idcom='C004' or idcom='C173'or idcom='C174'or idcom='C175'or idcom='C206'";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "spurcom");
                    dtgscom.DataSource = ds.Tables["spurcom"];
                    txtcount.Text = dtgscom.RowCount.ToString();
                }

                else if (rdioname.Checked == true)
                {
                    dtgscom.DataSource = dssearch;

                    sql = "select * from vcompany  where cname like '%" + txtvalue.Text.Trim() + "%'AND idcom = 'C003' or idcom='C004'or idcom='C173'or idcom='C174'or idcom='C175'or idcom='C206'";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "spurcom");
                    dtgscom.DataSource = ds.Tables["spurcom"];
                    txtcount.Text = dtgscom.RowCount.ToString();
                }
            }

            if (sname == "ssendcom")  // Search Transport Company
            {
                if (rdioid.Checked == true)
                {
                    dtgscom.DataSource = dssearch;

                    sql = "select * from vcompany  where idcom like '%" + txtvalue.Text.Trim() + "%'AND idtypecom =3";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "ssendcom");
                    dtgscom.DataSource = ds.Tables["ssendcom"];
                    txtcount.Text = dtgscom.RowCount.ToString();
                }

                else if (rdioname.Checked == true)
                {
                    dtgscom.DataSource = dssearch;

                    sql = "select * from vcompany  where cname like '%" + txtvalue.Text.Trim() + "%'AND idtypecom =3";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "ssendcom");
                    dtgscom.DataSource = ds.Tables["ssendcom"];
                    txtcount.Text = dtgscom.RowCount.ToString();
                }
            }

            else if (sname == "stypeemp")  //search typeEmployee
            {
                dtgstypeemp.DataSource = dssearch;
                if (rdioid.Checked == true)
                {
                    sql = "select * from tbemptype  where idemptype like '%" + txtvalue.Text.Trim() + "%'";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "stypeemp");
                    dtgstypeemp.DataSource = ds.Tables["stypeemp"];
                    txtcount.Text = dtgstypeemp.RowCount.ToString();
                }

                else if (rdioname.Checked == true)
                {
                    sql = "select * from tbemptype  where nametype like '%" + txtvalue.Text.Trim() + "%'";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "stypeemp");
                    dtgstypeemp.DataSource = ds.Tables["stypeemp"];
                    txtcount.Text = dtgstypeemp.RowCount.ToString();
                }
            }

            if (sname == "sdep")   //Search Department
            {
                dtgsdep.DataSource = dssearch;
                if (rdioid.Checked == true)
                {
                    sql = "select * from vdepartment where iddep like '%" + txtvalue.Text.Trim() + "%'";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "sdep");
                    dtgsdep.DataSource = ds.Tables["sdep"];
                    txtcount.Text = dtgsdep.RowCount.ToString();
                }

                else if (rdioname.Checked == true)
                {
                    sql = "select * from vdepartment where depname like '%" + txtvalue.Text.Trim() + "%'";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "sdep");
                    dtgsdep.DataSource = ds.Tables["sdep"];
                    txtcount.Text = dtgsdep.RowCount.ToString();
                }
            }

            if (sname == "scar")
            {
                dtgscar.DataSource = dssearch;
                if (rdioid.Checked == true)
                {
                    sql = "select * from tbcar where idcar like '%" + txtvalue.Text.Trim() + "%'";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "scar");
                    dtgscar.DataSource = ds.Tables["scar"];
                    txtcount.Text = dtgscar.RowCount.ToString();
                }
                else if (rdioname.Checked == true)
                {
                    sql = "select * from tbcar where carname like '%" + txtvalue.Text.Trim() + "%'";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "scar");
                    dtgscar.DataSource = ds.Tables["scar"];
                    txtcount.Text = dtgscar.RowCount.ToString();
                }
            }

            if (sname == "spro")
            {
                dtgspro.DataSource = dssearch;
                if (rdioid.Checked == true)
                {
                    sql = "select * from vproduct where idpro like '%" + txtvalue.Text.Trim() + "%'";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "spro");
                    dtgspro.DataSource = ds.Tables["spro"];
                    txtcount.Text = dtgspro.RowCount.ToString();
                }
                else if (rdioname.Checked == true)
                {
                    sql = "select * from vproduct where proname like '%" + txtvalue.Text.Trim() + "%'";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "spro");
                    dtgspro.DataSource = ds.Tables["spro"];
                    txtcount.Text = dtgspro.RowCount.ToString();
                }
            }

            if (sname == "spropur")
            {
                dtgpropur.DataSource = dssearch;

                if (rdioid.Checked == true)
                {
                    sql = "select * from tbproduct where idpro like '%" + txtvalue.Text.Trim() + "%'";
                    //sql = "select * from tbproduct";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "spropur");
                    dtgpropur.DataSource = ds.Tables["spropur"];
                    txtcount.Text = dtgpropur.RowCount.ToString();
                }

                else if (rdioname.Checked == true)
                {

                    sql = "select * from tbproduct where proname like '%" + txtvalue.Text.Trim() + "%'";
                    //sql = "select * from tbproduct";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "spropur");
                    dtgpropur.DataSource = ds.Tables["spropur"];
                    txtcount.Text = dtgpropur.RowCount.ToString();
                }
            }

            if (sname == "sempsale")
            {
                dtgsempsale.DataSource = dssearch;
                if (rdioid.Checked == true)
                {
                    sql = "select * from vempsale where idemp like '%" + txtvalue.Text.Trim() + "%'";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "sempsale");
                    dtgsempsale.DataSource = ds.Tables["sempsale"];
                    txtcount.Text = dtgsempsale.RowCount.ToString();
                }
                else if (rdioname.Checked == true)
                {
                    sql = "select * from vempsale where empname like '%" + txtvalue.Text.Trim() + "%'";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "sempsale");
                    dtgsempsale.DataSource = ds.Tables["sempsale"];
                    txtcount.Text = dtgsempsale.RowCount.ToString();
                }
            }

            if (sname == "scomcus")
            {
                dtgscom.DataSource = dssearch;
                if (rdioid.Checked == true)
                {
                    sql = "select * from vcompany where idcom like '%" + txtvalue.Text.Trim() + "%'AND idtypecom =1";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "scomcus");
                    dtgscom.DataSource = ds.Tables["scomcus"];
                    txtcount.Text = dtgscom.RowCount.ToString();
                }
                else if (rdioname.Checked == true)
                {
                    sql = "select * from vcompany where cname like '%" + txtvalue.Text.Trim() + "%'AND idtypecom =1";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "scomcus");
                    dtgscom.DataSource = ds.Tables["scomcus"];
                    txtcount.Text = dtgscom.RowCount.ToString();
                }
            }

            if (sname == "scomcostrate")
            {
                dtgscom.DataSource = dssearch;
                if (rdioid.Checked == true)
                {
                    sql = "select * from vcompany where idcom like '%" + txtvalue.Text.Trim() + "%'AND idtypecom =1";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "scomcostrate");
                    dtgscom.DataSource = ds.Tables["scomcostrate"];
                    txtcount.Text = dtgscom.RowCount.ToString();
                }
                else if (rdioname.Checked == true)
                {
                    sql = "select * from vcompany where cname like '%" + txtvalue.Text.Trim() + "%'AND idtypecom =1";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
                    da1.Fill(ds, "scomcostrate");
                    dtgscom.DataSource = ds.Tables["scomcostrate"];
                    txtcount.Text = dtgscom.RowCount.ToString();
                }
            }
            CN.Close();
        }

        private void dtgstypeemp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            {
                returnid = Convert.ToString(dtgstypeemp[0, e.RowIndex].Value.ToString().Trim());
                this.Close();
            }
        }

        private void dtgstypeemp_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtid.Text = dtgstypeemp[0, e.RowIndex].Value.ToString();
            txtdetail.Text = dtgstypeemp[1, e.RowIndex].Value.ToString();
            returnid = Convert.ToString(dtgstypeemp[0, e.RowIndex].Value.ToString().Trim());
        }

        private void dtgscom_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                txtid.Text = dtgscom[0, e.RowIndex].Value.ToString();
                txtdetail.Text = dtgscom[1, e.RowIndex].Value.ToString();
                returnid = Convert.ToString(dtgscom[0, e.RowIndex].Value.ToString().Trim());
            }
            catch (Exception ex)
            { MessageBox.Show("Error!" + ex.Message); }
        }

        private void dtgscom_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            {
                returnid = Convert.ToString(dtgscom[0, e.RowIndex].Value.ToString().Trim());
                this.Close();
            }
        }

        private void dtgscar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            returnid = Convert.ToString(dtgscar[0, e.RowIndex].Value.ToString());
            this.Close();
        }

        private void dtgscar_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtid.Text = dtgscar[0, e.RowIndex].Value.ToString();
            txtdetail.Text = dtgscar[1, e.RowIndex].Value.ToString();
            returnid = Convert.ToString(dtgscar[0, e.RowIndex].Value.ToString().Trim());
        }

        private void dtgspro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            returnid = Convert.ToString(dtgspro[0, e.RowIndex].Value.ToString());
            this.Close();
        }      

        private void dtgsempsale_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtid.Text = dtgsempsale[0, e.RowIndex].Value.ToString();
            txtdetail.Text = dtgsempsale[1, e.RowIndex].Value.ToString();
            returnid = Convert.ToString(dtgsempsale[0, e.RowIndex].Value.ToString().Trim());
        }

        private void dtgsempsale_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            returnid = Convert.ToString(dtgsempsale[0, e.RowIndex].Value.ToString());
            this.Close();
        }

        private void dtgspro_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtid.Text = dtgspro[0, e.RowIndex].Value.ToString();
            txtdetail.Text = dtgspro[1, e.RowIndex].Value.ToString();
            returnid = Convert.ToString(dtgspro[0, e.RowIndex].Value.ToString().Trim());
        }

        private void dtgtypecom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            returnid = Convert.ToString(dtgtypecom[0, e.RowIndex].Value.ToString());
            this.Close();
        }

        private void dtgbranch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            returnid = Convert.ToString(dtgbranch[0, e.RowIndex].Value.ToString());
            this.Close();
        }

        private void Frmserch_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.CN.Close();
        }      

        private void dtgpropur_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;          
            returnid = Convert.ToString(dtgpropur[0, e.RowIndex].Value.ToString().Trim());
            this.Close();
        }

        private void dtgpropur_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtid.Text = Convert.ToString(dtgpropur[0, e.RowIndex].Value.ToString());
            txtdetail.Text = dtgpropur[1, e.RowIndex].Value.ToString();
            returnid = Convert.ToString(dtgpropur[0, e.RowIndex].Value.ToString().Trim());
        }

        private void dtgsubpro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            {
                returnid = Convert.ToString(dtgsubpro[0, e.RowIndex].Value.ToString().Trim());
                this.Close();
            }
        }        

        private void txtvalue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (sname == "scom")  // Search Company
                {
                    dtgscom.Focus();
                }

                if (sname == "ssupcom")  // Search Company
                {

                    dtgscom.Focus();
                }

                if (sname == "spurcom")  // Search com purchase
                {

                    dtgscom.Focus();
                }

                if (sname == "ssendcom")  // Search Transport Company
                {
                    dtgscom.Focus();
                }

                else if (sname == "stypeemp")  //search typeEmployee
                {

                    dtgstypeemp.Focus();
                }

                if (sname == "sdep")   //Search Department
                {
                    dtgsdep.Focus();
                }

                if (sname == "scar")
                {
                    dtgscar.Focus();
                }

                if (sname == "spro" )
                {
                    dtgspro.Focus();
                }

                if (sname == "spropur")
                {
                    dtgpropur.Focus();
                }

                if (sname == "sempsale")
                {
                    dtgsempsale.Focus();
                }

                if (sname == "scomcus")
                {
                    dtgscom.Focus();
                }

                if (sname == "sposition")
                {
                    dtgsposition.Focus();
                }
            }
        }

        private void dtgscom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (dtgscom.RowCount == 1)
                { returnid = dtgscom.Rows[dtgscom.CurrentCell.RowIndex].Cells[0].Value.ToString(); }
                else
                { returnid = dtgscom.Rows[dtgscom.CurrentCell.RowIndex - 1].Cells[0].Value.ToString(); }
                this.Close();
            }
        }

        private void dtgpropur_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (dtgpropur.RowCount == 1)
                { returnid = dtgpropur.Rows[dtgpropur.CurrentCell.RowIndex].Cells[0].Value.ToString(); }
                else
                { returnid = dtgpropur.Rows[dtgpropur.CurrentCell.RowIndex - 1].Cells[0].Value.ToString(); }
                this.Close();
            }
        }

        private void dtgbranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (dtgbranch.RowCount == 1)
                { returnid = dtgbranch.Rows[dtgbranch.CurrentCell.RowIndex].Cells[0].Value.ToString(); }
                else
                { returnid = dtgbranch.Rows[dtgbranch.CurrentCell.RowIndex - 1].Cells[0].Value.ToString(); }
                this.Close();
            }
        }

        private void dtgsempsale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (dtgsempsale.RowCount == 1)
                { returnid = dtgsempsale.Rows[dtgsempsale.CurrentCell.RowIndex].Cells[0].Value.ToString(); }
                else
                { returnid = dtgsempsale.Rows[dtgsempsale.CurrentCell.RowIndex - 1].Cells[0].Value.ToString(); }
                this.Close();
            }
        }

        private void dtgtypecom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (dtgtypecom.RowCount == 1)
                { returnid = dtgtypecom.Rows[dtgtypecom.CurrentCell.RowIndex].Cells[0].Value.ToString(); }
                else
                { returnid = dtgtypecom.Rows[dtgtypecom.CurrentCell.RowIndex - 1].Cells[0].Value.ToString(); }
                this.Close();
            }
        }

        private void dtgstypeemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (dtgstypeemp.RowCount == 1)
                { returnid = dtgstypeemp.Rows[dtgstypeemp.CurrentCell.RowIndex].Cells[0].Value.ToString(); }
                else
                { returnid = dtgstypeemp.Rows[dtgstypeemp.CurrentCell.RowIndex - 1].Cells[0].Value.ToString(); }
                this.Close();
            }
        }

        private void dtgspro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (dtgspro.RowCount == 1)
                { returnid = dtgspro.Rows[dtgspro.CurrentCell.RowIndex].Cells[0].Value.ToString(); }
                else
                { returnid = dtgspro.Rows[dtgspro.CurrentCell.RowIndex - 1].Cells[0].Value.ToString(); }
                this.Close();
            }
        }

        private void dtgscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (dtgscar.RowCount == 1)
                { returnid = dtgscar.Rows[dtgscar.CurrentCell.RowIndex].Cells[0].Value.ToString(); }
                else
                { returnid = dtgscar.Rows[dtgscar.CurrentCell.RowIndex - 1].Cells[0].Value.ToString(); }
                this.Close();
            }
        }

        private void dtgsdep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (dtgsdep.RowCount == 1)
                { returnid = dtgsdep.Rows[dtgsdep.CurrentCell.RowIndex].Cells[0].Value.ToString(); }
                else
                { returnid = dtgsdep.Rows[dtgsdep.CurrentCell.RowIndex - 1].Cells[0].Value.ToString(); }
                this.Close();
            }
        }

        private void dtgsubpro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (dtgsubpro.RowCount == 1)
                { returnid = dtgsubpro.Rows[dtgsubpro.CurrentCell.RowIndex].Cells[0].Value.ToString(); }
                else
                { returnid = dtgsubpro.Rows[dtgsubpro.CurrentCell.RowIndex - 1].Cells[0].Value.ToString(); }
                this.Close();
            }
        }

        private void dtgsposition_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            returnid = Convert.ToString(dtgsposition[0, e.RowIndex].Value.ToString());
            this.Close();
        }

        private void dtgsposition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (dtgsposition.RowCount == 1)
                { returnid = dtgsposition.Rows[dtgsposition.CurrentCell.RowIndex].Cells[0].Value.ToString(); }
                else
                { returnid = dtgsposition.Rows[dtgsposition.CurrentCell.RowIndex - 1].Cells[0].Value.ToString(); }
                this.Close();
            }
        }

        private void dtgsposition_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                txtid.Text = dtgsposition[0, e.RowIndex].Value.ToString();
                txtdetail.Text = dtgsposition[1, e.RowIndex].Value.ToString();
                returnid = Convert.ToString(dtgsposition[0, e.RowIndex].Value.ToString().Trim());
            }
            catch (Exception ex)
            { MessageBox.Show("Error!" + ex.Message); }
        }

        private void dtgvbranch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            returnid = Convert.ToString(dtgvbranch[0, e.RowIndex].Value.ToString());
            this.Close();
        }

        private void dtgvbranch_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                txtid.Text = dtgvbranch[0, e.RowIndex].Value.ToString();
                txtdetail.Text = dtgvbranch[1, e.RowIndex].Value.ToString();
                returnid = Convert.ToString(dtgvbranch[0, e.RowIndex].Value.ToString().Trim());
            }
            catch (Exception ex)
            { MessageBox.Show("Error!" + ex.Message); }
        }

        private void dtgvbranch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (dtgvbranch.RowCount == 1)
                { returnid = dtgvbranch.Rows[dtgvbranch.CurrentCell.RowIndex].Cells[0].Value.ToString(); }
                else
                { returnid = dtgvbranch.Rows[dtgvbranch.CurrentCell.RowIndex - 1].Cells[0].Value.ToString(); }
                this.Close();
            }
        }

        private void dtgareapurchase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            returnid = Convert.ToString(dtgareapurchase[0, e.RowIndex].Value.ToString());
            this.Close();
        }

        private void dtgareapurchase_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                txtid.Text = dtgareapurchase[0, e.RowIndex].Value.ToString();
                txtdetail.Text = dtgareapurchase[1, e.RowIndex].Value.ToString();
                returnid = Convert.ToString(dtgareapurchase[0, e.RowIndex].Value.ToString().Trim());
            }
            catch (Exception ex)
            { MessageBox.Show("Error!" + ex.Message); }
        }

        private void dtgareapurchase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (dtgareapurchase.RowCount == 1)
                { returnid = dtgareapurchase.Rows[dtgareapurchase.CurrentCell.RowIndex].Cells[0].Value.ToString(); }
                else
                { returnid = dtgareapurchase.Rows[dtgareapurchase.CurrentCell.RowIndex - 1].Cells[0].Value.ToString(); }
                this.Close();
            }
        }       
    }
}