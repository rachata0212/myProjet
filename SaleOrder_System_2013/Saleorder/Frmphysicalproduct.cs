using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Diagnostics;

namespace SaleOrder
{
     

    public partial class Frmphysicalproduct : Form
    {
        public Frmphysicalproduct()
        {
            InitializeComponent();
        }

        public string idtran = "";
        public string idrequest = "";
        public int idorder = 0;
        public int idstatus = 0;
        int idsize = 0;
        int idcolor = 0;
        int iddebased = 0;
        int idphysical = 0;
        string OldurlImg = "";       
        string NewurlImg = "";
        string FilenameImg = "";
        string TypefileImg = "";
        string datelog = DateTime.Now.Day.ToString();
        string monthlog = DateTime.Now.Month.ToString();
        string yearlog = DateTime.Now.Year.ToString();
        string msnfrom = "";
        int idtypelog = 0;
        string idremark = "";

        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet ds4 = new DataSet();

        private void Frmphysicalproduct_Load(object sender, EventArgs e)
        {
            LoadDataphysical();
            LoadViewinformation();
            CheckStatusObject();
        }

        private void CheckStatusObject()
        {
            if (idstatus == 1) //insert
            {
                pninserturlimage.Dock = DockStyle.Bottom;
                //picproduct.Dock = DockStyle.Fill;
                pninserturlimage.Visible = true;
                //picproduct.Visible = true;
            }
            if (idstatus == 2 || idstatus == 3)//look view
            {
                txtcommentqc.ReadOnly = true;
                picproduct.Dock = DockStyle.Fill;
                picproduct.Visible = true;
                btnsaveedit.Enabled = false;

                idtypelog = 7;
                msnfrom = this.Name.ToString();
                Savelogevent();               
            }
        }

        private void LoadDataphysical()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); string sql1 = ""; string sql2 = "";

            if (idorder == 1)//order purchase
            {
                if (idstatus == 1)//status insert
                {
                    sql1 = "SELECT * from vphysicalpurchase  WHERE idtran = '" + idtran.Trim() + "'";
                }

                if (idstatus == 2 || idstatus == 3) //status viewers
                {
                    if (idstatus == 2)
                    {
                        string sql = "SELECT idtran from tbpurchase  WHERE idpur = '" + idrequest.Trim() + "'";
                        SqlCommand CM = new SqlCommand(sql, CN);
                        SqlDataReader DR1 = CM.ExecuteReader();
                        DR1.Read();
                        { idtran = DR1["idtran"].ToString().Trim(); }
                        DR1.Close();

                        sql1 = "SELECT * from vphysicalpurchase  WHERE idpur = '" + idrequest.Trim() + "'";
                    }
                    if (idstatus == 3) //status viewers
                    { sql1 = "SELECT * from vphysicalpurchase  WHERE idtran = '" + idtran.Trim() + "'"; }

                    sql2 = "SELECT * from tbphysicalproduct  WHERE idtran = '" + idtran.Trim() + "'";

                }
            }

            if (idorder == 2)//sale order
            {
                if (idstatus == 1)//inseret
                {
                    sql1 = "SELECT * from vphysicalsale  WHERE idtran = '" + idtran.Trim() + "'";
                }

                if (idstatus == 2 || idstatus == 3) //status viewers
                {
                    if (idstatus == 2)
                    {
                        string sql = "SELECT idtran from tborder  WHERE idorder = '" + idrequest.Trim() + "'";
                        SqlCommand CM = new SqlCommand(sql, CN);
                        SqlDataReader DR1 = CM.ExecuteReader();
                        DR1.Read();
                        { idtran = DR1["idtran"].ToString().Trim(); }
                        DR1.Close();

                        sql1 = "SELECT * from vphysicalsale  WHERE idorder = '" + idrequest.Trim() + "'";
                    }
                    if (idstatus == 3) //status viewers
                    { sql1 = "SELECT * from vphysicalsale  WHERE idtran = '" + idtran.Trim() + "'"; }
                    
                    sql2 = "SELECT * from tbphysicalproduct  WHERE idtran = '" + idtran.Trim() + "'";
                }
            }


            if (sql1 != "")
            {
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                SqlDataReader DR = CM1.ExecuteReader();
                DR.Read();
                {
                    lblidtran.Text = "ID:" + DR["idtran"].ToString().Trim();
                    lblproduct.Text = "ชื่อสินค้า: " + DR["proname"].ToString().Trim();
                    lbltruckno.Text = "ทะเบียนรถ: " + DR["serailcar"].ToString().Trim();
                    idremark = DR["idtran"].ToString().Trim();

                    if (idorder == 1)
                    {
                        lblorderdate.Text = "วันที่สั่งซื้อ: " + DR["datepur"].ToString().Trim();
                        lblsuporcus.Text = "ชื่อโรงปาล์ม/ผู้จำหน่าย: " + DR["comsup"].ToString().Trim();
                    }
                    if (idorder == 2)
                    {
                        lblorderdate.Text = "วันที่ขาย: " + DR["orderdate"].ToString().Trim();
                        lblsuporcus.Text = "ชื่อลูกค้า/ผู้ซื้อ :" + DR["comcus"].ToString().Trim();
                    }

                    lbltransportor.Text = "ชื่อขนส่ง :" + DR["comtran"].ToString().Trim();
                    lblmointure.Text = "ความชื้น :" + DR["moisture"].ToString().Trim();
                    lblwperkk.Text = "ปริมาตร/กิโลตวง :" + DR["kkperweigth"].ToString().Trim();
                }
                DR.Close();
            }

            if (sql2 != "")
            {
                int idcountid = 0;
                string sql3 = "Select count(idtran)as idcountid From tbphysicalproduct where idtran  = '" + idtran.Trim() + "'  ";
                SqlCommand CM2 = new SqlCommand(sql3, CN);
                SqlDataReader DR2 = CM2.ExecuteReader();
                DR2.Read();
                { idcountid = Convert.ToInt16(DR2["idcountid"].ToString().Trim()); }
                DR2.Close();

                if (idcountid != 0)
                {
                    SqlCommand CM3 = new SqlCommand(sql2, CN);
                    SqlDataReader DR3 = CM3.ExecuteReader();
                    DR3.Read();
                    {
                        idsize = Convert.ToInt16(DR3["idsize"].ToString().Trim());
                        idcolor = Convert.ToInt16(DR3["idcolor"].ToString().Trim());
                        idphysical = Convert.ToInt16(DR3["idphysical"].ToString().Trim());
                        iddebased = Convert.ToInt16(DR3["iddebased"].ToString().Trim());
                        txtcommentqc.Text = DR3["comment"].ToString().Trim();
                        OldurlImg = DR3["urlimage"].ToString().Trim();
                    }
                    DR3.Close();
                }

                else { MessageBox.Show("Error!!"); }

                LoadImage();
            }
        }

        private void LoadViewinformation()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql0 = "";
            string sql1 = "";
            string sql2 = "";
            string sql3 = "";
            string sql4 = "";
            int countid = 0;

            if (idorder == 1)
            { sql0 = "SELECT Count(idfrom)as countid  FROM tbtransport WHERE idfrom = '" + idtran.Trim() + "'"; }
            if (idorder == 2)
            { sql0 = "SELECT Count(idto)as countid  FROM tbtransport WHERE idto = '" + idtran.Trim() + "'"; }

            if (sql0 != "")
            {
                SqlCommand CM0 = new SqlCommand(sql0, CN);
                SqlDataReader DR0 = CM0.ExecuteReader();
                DR0.Read();
                { countid = Convert.ToInt16(DR0["countid"].ToString().Trim()); }
                DR0.Close();
            }

            if (idstatus == 1)//insert
            {
                sql1 = "select idsize,namesize from tbsizeplam";
                sql2 = "select idcolor,namecolor from tbcolor";
                sql3 = "select idphysical,namephysical from tbphysical";
                sql4 = "select iddebased,namedebased from tbdebased";
            }

            if (idstatus == 2 || idstatus == 3)//view
            {
                sql1 = "select idsize,namesize from tbsizeplam where idsize=" + idsize + "";
                sql2 = "select idcolor,namecolor from tbcolor where idcolor=" + idcolor + "";
                sql3 = "select idphysical,namephysical from tbphysical where idphysical=" + idphysical + "";
                sql4 = "select iddebased,namedebased from tbdebased where iddebased=" + iddebased + "";
            }

            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(ds1, "sizeplam");
            cbsize.DataSource = ds1.Tables["sizeplam"];
            cbsize.DisplayMember = "namesize";
            cbsize.ValueMember = "idsize";

            SqlDataAdapter da2 = new SqlDataAdapter(sql2, CN);
            da2.Fill(ds2, "procolor");
            cbcolor.DataSource = ds2.Tables["procolor"];
            cbcolor.DisplayMember = "namecolor";
            cbcolor.ValueMember = "idcolor";

            SqlDataAdapter da3 = new SqlDataAdapter(sql3, CN);
            da3.Fill(ds3, "physical");
            cbphysical.DataSource = ds3.Tables["physical"];
            cbphysical.DisplayMember = "namephysical";
            cbphysical.ValueMember = "idphysical";

            SqlDataAdapter da4 = new SqlDataAdapter(sql4, CN);
            da4.Fill(ds4, "sizeplam");
            cbdebased.DataSource = ds4.Tables["sizeplam"];
            cbdebased.DisplayMember = "namedebased";
            cbdebased.ValueMember = "iddebased";

            CN.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnbrows_Click(object sender, EventArgs e)
        {
           // openFileDialog1.Filter = "Select Files (Filetpye jpg|*.jpg |Filetpye Bmp|*.bmp |Filetpye Gif| *.gif | All Files (|*.*";
            openFileDialog1.Filter = "Jpeg(*.jpg)|*.jpg|Gif(*.gif)|*.gif|Emf(*.emf)|*.emf|Bmp(*.bmp)|*.bmp|Png(*.png)|*.png";
            //Gif(*.gif)|*.gif|Jpeg(*.jpg)|*.jpg|Emf(*.emf)|*.emf|Bmp(*.bmp)|*.bmp|Png(*.png)|*.png

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txturlimage.Text = openFileDialog1.FileName;
                OldurlImg = txturlimage.Text.Trim();
                picproduct.Visible = true; picproduct.Dock = DockStyle.Fill;
                LoadImage();
            }      
        }    

        private void LoadImage()
        {

            /*/concept 
             * step
             * 1. Load file to picture box
             * 2. resize image (Width = 470, Height = 350)
             * 3. rename from ole file name to new file name
             * 4. save image name to diretory folder image
             * 
                          
             */
            picproduct.ImageLocation = OldurlImg;
            this.picproduct.Size = new System.Drawing.Size(470, 350);
            this.picproduct.SizeMode = PictureBoxSizeMode.StretchImage;               
                
           // picproduct.Image.Save(urlpic);

            string p = txturlimage.Text;
            FilenameImg = Path.GetFileName(p);
            TypefileImg = Path.GetExtension(p);                    

        }

        private void Savelogevent()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string selectdatelog = monthlog + "/" + datelog + "/" + yearlog;

            string sql1 = "insert into tblog(logname,datein,timein,idtypelog,idemp,remark) values('" + msnfrom + "','" + selectdatelog + "','" + DateTime.Now.ToLongTimeString() + "'," + idtypelog + ",'" + Program.empID + "','" + idremark + "')";
            SqlCommand CM1 = new SqlCommand(sql1, CN);
            CM1.ExecuteNonQuery();
        }

        private void btnsaveedit_Click(object sender, EventArgs e)
        {

            //NewurlImg = @"C:\imagetest\" + idtran.Trim()+".jpg" + "";
            NewurlImg = @"\\172.10.1.2\QCPicProduct\" + idtran.Trim() + ".jpg" + "";
            InsertData();

            File.Copy(OldurlImg, NewurlImg, true);

            msnfrom = this.Name.ToString();
            idtypelog = 1;//insert
            Savelogevent();
        }
                
        private void InsertData()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); string sql = ""; 

            if (idstatus == 1)//insert
            {
                try
                {

                    sql = "insert into tbphysicalproduct (idtran,comment,urlimage,idsize,idcolor,idphysical,iddebased) values ('" + idtran + "','" + txtcommentqc.Text + "','" + NewurlImg + "'," + cbsize.SelectedValue.ToString() + "," + cbcolor.SelectedValue.ToString() + "," + cbphysical.SelectedValue.ToString() + "," + cbdebased.SelectedValue.ToString() + ")";
                   
                    SqlCommand CM = new SqlCommand(sql, CN);
                    CM.ExecuteNonQuery();
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "Complease!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                    //DialogResult answer;
                    //answer = MessageBox.Show("ไฟล์ภาพชื่อนี้มีอยู่แล้ว ถ้าคุณต้องการบันทึกทับภาพใช่หรือไม่ !(แนะนำให้ตั้งตามเลขที่ order)", "ไฟล์ภาพซ้ำ !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    //if (answer == DialogResult.OK)
                    //{
                    //    File.Delete(path);
                    //    File.Copy(txturlimage.Text, path);
                    //    File.Copy(txturlimage.Text, path, true);

                    //    SqlCommand CM = new SqlCommand(sql, CN);
                    //    CM.ExecuteNonQuery();
                    //    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "Complease!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    this.Close();
                    //}                 
                }
            }

            //else //update

            //if (idcheck != 0)
            //{      //    File.Delete(viewfile);   //}      
            //{ sql = "update tbmaps set filepath= '" + path + "',filestype= '" + typefile + "' Where idauto= " + id + ""; }



        }

        private void Frmphysicalproduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            msnfrom = this.Name.ToString();
            idtypelog = 6;//Close
            Savelogevent();
        }

        // ---------------------------------------

        
    }
}