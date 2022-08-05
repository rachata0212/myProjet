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

namespace Interface_Lab
{
    public partial class F_Setting : Form
    {
        public F_Setting()
        {
            InitializeComponent();
        }

        string Status_diskplay = "";
        string Config_line1 = "";
        
        private void F_Setting_Load(object sender, EventArgs e)
        {
            txt_scalefileDll.Text = Program.ScaleName;
            txt_scaleNo.Text = Program.ScaleNo.ToString();
            txt_ScaleName.Text = Program.ScaleName;
            cbo_comport.Text = Program.PortName;
            cbo_baudrate.Text = Program.BaudRate.ToString();
            cbo_databit.Text = Program.DataBit.ToString();
            cbo_parity.Text = Program.Parity;
            cbo_stopbit.Text = Program.StopBit.ToString();
            txt_startCharator.Text = Program.StartSelect_Char.ToString();
            txt_endCharator.Text = Program.EndSelect_Chare.ToString();

            string filename = Application.StartupPath + "\\config.dll";


            if (System.IO.File.Exists(filename))
            {
                System.IO.StreamReader StrRer = new System.IO.StreamReader(filename);

                List<string> listStr = new List<string>();

                while (!StrRer.EndOfStream)
                {
                    listStr.Add(StrRer.ReadLine());
                }

                Config_line1= listStr[0].ToString();
                Status_diskplay = listStr[1].ToString();

                StrRer.Close();
            }


            if (Screen.AllScreens.Count() == 2 && Status_diskplay == "Monitor 2 :True")
            {
                chk_monitor.Checked = true;
                chk_monitor.Enabled = true;
                txt_monitor1.Text = "Monitor 1";
                txt_monitor2.Text = "Monitor 2";
            }

            else if (Screen.AllScreens.Count() == 2)
            {
                chk_monitor.Enabled = true;
                txt_monitor1.Text = "Monitor 1";
                txt_monitor2.Text = "Monitor 2";
            }
            
            else
            {
                txt_monitor1.Text = "Monitor 1";
            }
        }

        private void btn_checkmonitor_Click(object sender, EventArgs e)
        {           
            MessageBox.Show("จำนวนจอเปิดใช้งานตอนนี้: "+ Screen.AllScreens.Count().ToString() + " จอ","Check Monitor",MessageBoxButtons.OK,MessageBoxIcon.Information);          
        }


       
        private void chk_monitor_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_monitor.Checked == true & Screen.AllScreens.Count() == 2)
                {

                txt_monitor1.Enabled = true;
                txt_monitor2.Enabled = true;
                txt_monitor2.Text = "Monitor 2";
            }

           else if (chk_monitor.Checked == false & Screen.AllScreens.Count() == 2)
            {
                txt_monitor1.Enabled = false;
                txt_monitor2.Enabled = false;
                txt_monitor2.Text = "Monitor 2";
            }

            else

            {
                txt_monitor1.Enabled = false; txt_monitor2.Enabled = true; txt_monitor2.Clear(); }
                 
        }


        private void btn_savemonitor_Click(object sender, EventArgs e)
        {
            if (chk_monitor.Checked == true)
            {
                string path = Application.StartupPath + "\\config.dll";
                string[] lines = { Config_line1, "Monitor 2 :True" };
                File.WriteAllLines(path, lines);
            }

            else
            {
                string path = Application.StartupPath + "\\config.dll";
                string[] lines = { Config_line1, "Monitor 2 :False" };
                File.WriteAllLines(path, lines);
            }
        }
    }
}
