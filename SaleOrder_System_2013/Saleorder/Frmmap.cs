using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;
using System.Web;
using System.Web.UI;


namespace SaleOrder
{
    public partial class Frmmap : Form 
    {
        public Frmmap()
        {
            InitializeComponent();
        }


        string id = ""; string typefile = ""; DataSet dscbbranch = new DataSet(); DataSet dssearch = new DataSet(); DataSet ds = new DataSet(); int idcheck = 0; string filename = ""; string viewfile = "";

        private void btnsearchcom_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            Frmserch fs = new Frmserch();
            fs.sname = "sallcom";
            fs.ShowDialog();
            id = fs.returnid;

            if (id != "0")
            {
                string sql = "select idcom,cname,provice from vcompany where idcom='" + id + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();

                DR.Read();
                {
                    txtcompanyname.Text = DR["cname"].ToString().Trim();
                    txtprovice.Text = DR["provice"].ToString().Trim(); 
                }
                DR.Close();
            }

            if (txtcompanyname.Text != "")
            { btnsave.Enabled = true; }
        }

        private void btnsearchfile_Click(object sender, EventArgs e)
        {
           // openFile.Filter = "Select File Maps |*.jpg | All Files | *.* ";
            openFileDialog1.Filter = "Select Files (Filetpye pdf)|*.pdf|(Filetpye bmp)|*.bmp |(Filetpye jpg)|*.jpg |(Filetpye gif)|*.gif | All Files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            { txtpath.Text = openFileDialog1.FileName;            }
            if (txtpath.Text != "")
            { btnsearchcom.Enabled = true; }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtpath.Text != "" && txtcompanyname.Text != "")
            {
                SqlConnection CN = new SqlConnection();
                CN.ConnectionString = Program.urldb;
                CN.Open(); string sql = "";

                CheckFile();
                //string path = @"C:\MapsFile\" + filename;
                string path = @"\\172.10.1.2\MapsFileHB\" + filename + "";

                if (idcheck == 0)
                { sql = "insert into tbmaps (idcom,filepath,filestype) values ('" + id + "','" + path + "','" + typefile + "')"; }
                else
                { sql = "update tbmaps set filepath= '" + path + "',filestype= '" + typefile + "' Where idauto= " + id + ""; }
                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();

                try
                {
                    if (idcheck != 0)
                    {
                        File.Delete(viewfile);
                    }
                    //// Copy the file.
                    File.Copy(txtpath.Text, path);                   
                    File.Copy(txtpath.Text, path, true);
                }

                catch (Exception ex)
                { MessageBox.Show("Error ! Copyfile" + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "Complease!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGridMaps();
            }
        }
           
        private void CheckFile()
        {
            string p = txtpath.Text;
            typefile = Path.GetExtension(p);
            filename = Path.GetFileName(p);          
        }
        
        private void Frmmap_Load(object sender, EventArgs e)
        {
            LoadGridMaps();
        }

        private void LoadGridMaps()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            ds.Clear(); dssearch.Clear();

            dtgviewfile.DataSource = dssearch;
            string sql = "select * from vmapcompany";//ต่อด้วยเช็คแผนกพนักงานเพื่อค้นหาบริษัทที่แผนกใครแผนกมัน
            SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
            da1.Fill(ds, "maps");
            dtgviewfile.DataSource = ds.Tables["maps"];
            txtcompanyname.Clear();
            txtpath.Clear();
            txtprovice.Clear();
            txtsearch.Clear();
            id = "";
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void disablebutton()
        {
            txtcompanyname.Clear();
            txtpath.Clear();
            txtprovice.Clear();
            btnsave.Enabled = false;
            btnsearchcom.Enabled = false;
        }

        private void dtgviewfile_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            btnsave.Enabled = true;
            btnsearchfile.Enabled = true;
            id =dtgviewfile[0, e.RowIndex].Value.ToString().Trim();
            txtcompanyname.Text = dtgviewfile[2, e.RowIndex].Value.ToString().Trim();
            txtprovice.Text = dtgviewfile[3, e.RowIndex].Value.ToString().Trim();
            idcheck = 1;           

            string sql2 = "select filepath from tbmaps where idauto='" + dtgviewfile[0, e.RowIndex].Value.ToString().Trim() + "'";
            SqlCommand CM2 = new SqlCommand(sql2, CN);
            SqlDataReader DR2 = CM2.ExecuteReader();

            DR2.Read();
            { viewfile = DR2["filepath"].ToString(); }
            DR2.Close();
            cbnew.Checked = false;
        }

       

        private void btnview_Click(object sender, EventArgs e)
        {
            if (txtpath.Text != "")
            { System.Diagnostics.Process.Start(txtpath.Text); }
        }

        private void dtgviewfile_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            { System.Diagnostics.Process.Start(viewfile); }
            catch (Exception ex)
            { MessageBox.Show("ไม่พบไฟล์ที่คุณต้องการเปิด", "ผิดพลาด !", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cbnew_CheckedChanged(object sender, EventArgs e)
        {
            if (cbnew.Checked == true)
            { idcheck = 0; txtcompanyname.Clear(); txtprovice.Clear(); id = ""; }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
           
             SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            ds.Clear(); dssearch.Clear();

            dtgviewfile.DataSource = dssearch;
            string sql = " select * from vmapcompany where cname like '%" + txtsearch.Text.Trim() + "%'";
            SqlDataAdapter da1 = new SqlDataAdapter(sql, CN);
            da1.Fill(ds, "maps");
            dtgviewfile.DataSource = ds.Tables["maps"];   
        }

        



    }
}