using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web;
using System.Web.UI;

namespace SaleOrder
{
    public partial class FrmselectOption : Form
    {
        public FrmselectOption()
        {
            InitializeComponent();
        }

        public int idoption; 
        public string idvalue;
        public int idbranch;
        int idcheck = 0;
        string filename = ""; 
        string viewfile = "";
        string typefile = "";
        DataSet dts = new DataSet();
        string oldfilepath = "";
        int countcheck = 0;
        int idcar = 0 ;

        private void btnclose_Click(object sender, EventArgs e)
        {            
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open(); string sql = "";

                CheckFile();// checktypetuck();
              //  string path = @"C:\MapsFile\" + filename;
                string oldfilename = Path.GetFileName(oldfilepath);
                 string path = @"\\172.10.1.2\MapsFileHB\" + filename + "";

                try
                {
                    if (countcheck == 0)
                    {
                        sql = "insert into tbmaps (idcom,filepath,filestype) values ('" + idvalue + "','" + path + "','" + typefile + "')";
                        SqlCommand CM = new SqlCommand(sql, CN);
                        CM.ExecuteNonQuery(); 
                        
                        File.Copy(txtpath.Text, path);
                        File.Copy(txtpath.Text, path, true);
                        this.Close();
                    }

                   else if (filename != oldfilename && countcheck !=0)
                    {
                        DialogResult answer;
                        answer = MessageBox.Show("คุณต้องการปรับปรุงข้อมูลใช่หรือไม่ !", "กรุณายืนยัน !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (answer == DialogResult.OK)
                        {
                            File.Delete(oldfilepath);
                            File.Copy(txtpath.Text, path);
                            File.Copy(txtpath.Text, path, true);


                            sql = "update tbmaps set filepath= '" + path + "',filestype= '" + typefile + "' Where idcom= '" + idvalue + "'";

                            SqlCommand CM = new SqlCommand(sql, CN);
                            CM.ExecuteNonQuery(); 
                            this.Close();
                        }
                    }                    
                }

                catch (Exception ex)
                {
                    if (txtpath.Text != "")
                    {
                        File.Copy(txtpath.Text, path);
                        File.Copy(txtpath.Text, path, true);

                        sql = "update tbmaps set filepath= '" + path + "',filestype= '" + typefile + "' Where idcom= '" + idvalue + "'";

                        SqlCommand CM = new SqlCommand(sql, CN);
                        CM.ExecuteNonQuery();
                        this.Close();
                    }                       
            }

            if (cbselecttypecom.Text != "")
            {
                string sql1 = "update tbbrach set idmaxsizetruck= " + cbselecttypecom.SelectedValue.ToString() + " Where idbranch= " + idbranch + "";
                SqlCommand CM = new SqlCommand(sql1, CN);
                CM.ExecuteNonQuery(); CN.Close();
            }
            this.Close();   
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            if (txtpath.Text != "")
            { System.Diagnostics.Process.Start(txtpath.Text); }
        }

        private void btnsearchfile_Click(object sender, EventArgs e)
        {
            // openFile.Filter = "Select File Maps |*.jpg | All Files | *.* ";
            openFileDialog1.Filter = "Select Files (Filetpye pdf)|*.pdf|(Filetpye bmp)|*.bmp |(Filetpye jpg)|*.jpg |(Filetpye gif)|*.gif | All Files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            { txtpath.Text = openFileDialog1.FileName; }           
        }

        private void FrmselectOption_Load(object sender, EventArgs e)
        {
            if (idoption == 1)
            { LoadURLMaps(); Loadtypetruck(); checktypetuck(); }
        }

        private void CheckFile()
        {
            string p = txtpath.Text;
            typefile = Path.GetExtension(p);
            filename = Path.GetFileName(p);
        }

        private void Loadtypetruck()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            string sql1 = "select * from tbcar ";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(dts, "loadtypegtruck");
            cbselecttypecom.DataSource = dts.Tables["loadtypegtruck"];
            cbselecttypecom.DisplayMember = "carname";
            cbselecttypecom.ValueMember = "idcar";
        }

        private void LoadURLMaps()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
           

            string sql2 = "select count(idcom)as countcheck from tbmaps where idcom = '" + idvalue + "'";
            SqlCommand CM2 = new SqlCommand(sql2, CN);
            SqlDataReader DR2 = CM2.ExecuteReader();

            DR2.Read();
            {
                countcheck = Convert.ToInt16(DR2["countcheck"].ToString());
            }
            DR2.Close();

            
            if (countcheck != 0)
            {
                string sql1 = "select * from tbmaps where idcom = '" + idvalue + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    if (DR1["filepath"].ToString() != "") {
                        txtpath.Text = DR1["filepath"].ToString(); 
                        oldfilepath = txtpath.Text.Trim(); }
                }
                DR1.Close();
                CN.Close();
            }
        }

        private void UpdateMaxsizeTruck()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql = "update tbbrach set idmaxsizetruck= " + cbselecttypecom.SelectedValue.ToString() + " Where idbranch= " + idbranch + "";

            SqlCommand CM = new SqlCommand(sql, CN);
            CM.ExecuteNonQuery(); CN.Close();
            this.Close();

        }
        private void checktypetuck()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();


            string sql2 = "select idcar,carname from vbranch where idbranch = " + idbranch + "";
            SqlCommand CM2 = new SqlCommand(sql2, CN);
            SqlDataReader DR2 = CM2.ExecuteReader();

            DR2.Read();
            {
                idcar = Convert.ToInt16(DR2["idcar"].ToString());
                cbselecttypecom.Text = DR2["carname"].ToString();
            }
            DR2.Close();
        
        }
        

        private void cbselecttypecom_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(cbselecttypecom.SelectedIndex > 0)
           
            //try
            //{
            //    idcar = Convert.ToInt16(cbselecttypecom.SelectedValue.ToString());
            //}
            //catch { }


            if (idcar != 0 && cbselecttypecom.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                idcar = Convert.ToInt16(cbselecttypecom.SelectedValue.ToString());
                //MessageBox.Show(cbselecttypecom.SelectedValue.ToString());
            
            }
            
        }












    }
}