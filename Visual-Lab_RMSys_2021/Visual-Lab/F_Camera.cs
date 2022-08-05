using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using DarrenLee.Media;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Threading;


namespace Visual_Lab
{
    public partial class F_Camera : Form
    {
        public F_Camera()
        {
            InitializeComponent();

            Getinfo();
            myCamera.OnFrameArrived += MyCamera_OnFrameArrived;
        }


        public int id_status = 0;
        public string QR_code = "";
        public string simple_code = "";
        public int pic_no = 0;
        public string picName_return = "";
        string merge_text = "-";
        public int id_camera = 0;
        int Camera_Index = 0;
        int Resolution_Index = 0;

        public int Sts_Img1 = 0;
        public int Sts_Img2 = 0;
        public int Sts_Img3 = 0;
        public int Sts_Img4 = 0;

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        Camera myCamera = new Camera();

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void F_Camera_Load(object sender, EventArgs e)
        {

            string filename = Application.StartupPath + "\\config.dll";

            if (System.IO.File.Exists(filename))
            {
                System.IO.StreamReader StrRer = new System.IO.StreamReader(filename);

                List<string> listStr = new List<string>();

                while (!StrRer.EndOfStream)
                {
                    listStr.Add(StrRer.ReadLine());
                }

                Camera_Index = Convert.ToInt16(listStr[0].ToString());
                Resolution_Index = Convert.ToInt16(listStr[1].ToString());
                StrRer.Close();

            }

            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                cb_camera.Items.Add(filterInfo.Name);   

            if (id_camera == 1)
            {
                panel1.Visible = true;
                cb_camera.Enabled = true;
                cb_resolution.Enabled = true;
                btn_save.Enabled = true;
            }

        }

        private void MyCamera_OnFrameArrived(object source, FrameArrivedEventArgs e)
        {
            Image img = e.GetFrame();
            img.RotateFlip(RotateFlipType.Rotate180FlipY);
            pictureBox1.Image = img;
        }


        private void Getinfo()
        {
            var cameraResolution = myCamera.GetSupportedResolutions();
            foreach (var r in cameraResolution)
                cb_resolution.Items.Add(r);
        }

        private void F_Camera_FormClosing(object sender, FormClosingEventArgs e)
        {
            myCamera.Stop();
            //captureDevice.Stop();
            //timer1.Enabled = false;
            //try
            //{
            //    if (captureDevice.IsRunning == true)
            //    {
            //        captureDevice.Stop();
            //        myCamera.Stop();
            //        captureDevice.Stop();
            //        timer1.Enabled = false;
            //    }
            //}
            //catch { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image != null)
                {
                    BarcodeReader barcodeReader = new BarcodeReader();
                    Result result = barcodeReader.Decode((Bitmap)pictureBox1.Image);
                    if (result != null)
                    {
                        QR_code = result.ToString();
                        timer1.Stop();
                        pictureBox1.Visible = false;

                        myCamera.Stop();
                        captureDevice.Stop();
                        timer1.Enabled = false;
                        this.Close();
                    }

                }
            }
            catch
            {

                myCamera.Stop();
                captureDevice.Stop();
                timer1.Enabled = false;
            }
        }

        private void cb_resolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCamera.Start(cb_resolution.SelectedIndex);
        }

        private void cb_camera_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCamera.ChangeCamera(cb_camera.SelectedIndex);
        }


        //int switch1 = 0;
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            /// if chek srever   divice camera runing
            /// 
            //try
            //{
            //if (!captureDevice.IsRunning == false)
            //{

            if (pic_no == 1 && btn_imag1.BackColor == Color.Yellow)
            {
                Program.img1_paht = Application.StartupPath + @"\pic_temp\" + label1.Text;
                myCamera.Capture(Program.img1_paht);
                btn_imag1.BackColor = Color.LightGreen;
                Sts_Img1 = 1;
                btn_imag2.Enabled = true;
            }
            if (pic_no == 2 && btn_imag2.BackColor == Color.Yellow)
            {
                Program.img2_paht = Application.StartupPath + @"\pic_temp\" + label1.Text;
                myCamera.Capture(Program.img2_paht);
                btn_imag2.BackColor = Color.LightGreen;
                Sts_Img2 = 1;
                btn_imag3.Enabled = true;
            }

            if (pic_no == 3 && btn_imag3.BackColor == Color.Yellow)
            {
                Program.img3_paht = Application.StartupPath + @"\pic_temp\" + label1.Text;
                myCamera.Capture(Program.img3_paht);
                btn_imag3.BackColor = Color.LightGreen;
                Sts_Img3 = 1;
                btn_imag4.Enabled = true;
            }

            if (pic_no == 4 && btn_imag4.BackColor == Color.Yellow)
            {
                Program.img4_paht = Application.StartupPath + @"\pic_temp\" + label1.Text;
                myCamera.Capture(Program.img4_paht);
                btn_imag4.BackColor = Color.LightGreen;
                Sts_Img4 = 1;
            }

            myCamera.Stop();
            //Enable_Button();





            //if (btn_imag1.BackColor == Color.LightGreen)
            //{
            //    btn_imag1.BackColor = Color.Yellow;
            //    myCamera.Start();
            //}




            //picName_return = simple_code + merge_text;
            //captureDevice.Stop();

            //MessageBox.Show("การบันทึกภาพสำเร็จ", "การบันทึกภาพ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}

            //    else
            //    {

            //filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //foreach (FilterInfo filterInfo in filterInfoCollection)
            //    cb_camera.Items.Add(filterInfo.Name);
            //cb_camera.SelectedIndex = Camera_Index;

            //label1.Text = simple_code + merge_text;
            //captureDevice = new VideoCaptureDevice(filterInfoCollection[Camera_Index].MonikerString);
            //captureDevice.NewFrame += CaptureDevice_NewFrame;
            //captureDevice.Start();
            //myCamera.Start();
            //    }
            //}
            //catch
            //{
            //filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //foreach (FilterInfo filterInfo in filterInfoCollection)
            //    cb_camera.Items.Add(filterInfo.Name);
            //cb_camera.SelectedIndex = Camera_Index;

            //    label1.Text = simple_code + merge_text;
            //    captureDevice = new VideoCaptureDevice(filterInfoCollection[Camera_Index].MonikerString);
            //    captureDevice.NewFrame += CaptureDevice_NewFrame;
            //    captureDevice.Start();
            //    myCamera.Start();
            //}
        }

        private void F_Camera_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                panel1.Visible = true;
                cb_camera.Enabled = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                panel1.Visible = false;
                cb_camera.Enabled = false;
            }
        }

        private void cb_resolution_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                panel1.Visible = false;
                cb_camera.Enabled = false;
            }
        }

        private void cb_camera_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                panel1.Visible = false;
                cb_camera.Enabled = false;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\config.dll";
            string[] lines = { cb_camera.SelectedIndex.ToString(), cb_resolution.SelectedIndex.ToString() };
            File.WriteAllLines(path, lines);

        }

        private void Enable_Camera()
        {
            timer1.Enabled = true;
            myCamera.Start();
            cb_camera.SelectedIndex = Camera_Index;
            cb_resolution.SelectedIndex = Resolution_Index;
            myCamera.ChangeCamera(cb_camera.SelectedIndex);
            myCamera.Start(cb_resolution.SelectedIndex);
        }

        private void Disable_Button()
        {
            btn_imag1.Enabled = false;
            btn_imag2.Enabled = false;
            btn_imag3.Enabled = false;
            btn_imag4.Enabled = false;
        }

        private void Enable_Button()
        {
            btn_imag1.Enabled = true;
            btn_imag2.Enabled = true;
            btn_imag3.Enabled = true;
            btn_imag4.Enabled = true;
            chk_edit.Checked = false;
        }

        private void btn_imag1_Click(object sender, EventArgs e)
        {
            try
            {
                pic_no = 1;
                label1.Text = simple_code + merge_text + pic_no.ToString();

                if (btn_imag1.BackColor == Color.Silver || chk_edit.Checked == true)
                {
                    btn_imag1.BackColor = Color.Yellow;
                    Enable_Camera();
                    Disable_Button();
                }

                if (btn_imag1.BackColor == Color.LightGreen && chk_edit.Checked == false)
                {
                    string path_image = Application.StartupPath + @"\pic_temp\" + label1.Text.Trim() + ".JPG";
                    pictureBox1.Image = new Bitmap(path_image);       
                    
                }
            }
            catch { }

        }

        private void btn_imag2_Click(object sender, EventArgs e)
        {
            try
            {
                pic_no = 2;
                label1.Text = simple_code + merge_text + pic_no.ToString();

                if (btn_imag2.BackColor == Color.Silver || chk_edit.Checked == true)
                {
                    btn_imag2.BackColor = Color.Yellow;
                    Enable_Camera();
                    Disable_Button();
                }

                if (btn_imag2.BackColor == Color.LightGreen && chk_edit.Checked == false)
                {
                    string path_image = Application.StartupPath + @"\pic_temp\" + label1.Text.Trim() + ".JPG";
                    pictureBox1.Image = new Bitmap(path_image);                  
                }
            }
            catch { }

        }

        private void btn_imag3_Click(object sender, EventArgs e)
        {
            try
            {
                pic_no = 3;
                label1.Text = simple_code + merge_text + pic_no.ToString();

                if (btn_imag3.BackColor == Color.Silver || chk_edit.Checked == true)
                {
                    btn_imag3.BackColor = Color.Yellow;
                    Enable_Camera();
                    Disable_Button();
                }

                if (btn_imag3.BackColor == Color.LightGreen && chk_edit.Checked == false)
                {
                    string path_image = Application.StartupPath + @"\pic_temp\" + label1.Text.Trim() + ".JPG";
                    pictureBox1.Image = new Bitmap(path_image);                  
                }
            }
            catch { }
        }

        private void btn_imag4_Click(object sender, EventArgs e)
        {
            try
            {
                pic_no = 4;
                label1.Text = simple_code + merge_text + pic_no.ToString();

                if (btn_imag4.BackColor == Color.Silver || chk_edit.Checked == true)
                {
                    btn_imag4.BackColor = Color.Yellow;
                    Enable_Camera();
                    Disable_Button();
                }

                if (btn_imag4.BackColor == Color.LightGreen && chk_edit.Checked == false)
                {
                    string path_image = Application.StartupPath + @"\pic_temp\" + label1.Text.Trim() + ".JPG";
                    pictureBox1.Image = new Bitmap(path_image);              
                }
            }
            catch { }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
