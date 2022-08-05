using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace SaleOrder
{
    public partial class FrmTruckscale : Form
    {
        public FrmTruckscale()
        {
            InitializeComponent();
        }

        SerialPort sport = new SerialPort();
        int counts = 0; DataSet ds = new DataSet();
        private void cbobranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (cbobranch.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string sql = "SELECT COUNT(idbranch) AS counts FROM tbsettruckscale WHERE idbranch = " + cbobranch.SelectedValue.ToString() + "";
                SqlCommand CM = new SqlCommand(sql, CN);

                SqlDataReader DR = CM.ExecuteReader();

                DR.Read();
                { counts = Convert.ToInt16(DR["counts"].ToString().Trim()); }
                DR.Close();

                if (counts != 0)
                {
                    string sql1 = "SELECT * FROM tbsettruckscale WHERE idbranch = " + cbobranch.SelectedValue.ToString() + "";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    SqlDataReader DR1 = CM1.ExecuteReader();

                    DR1.Read();
                    {
                        cboportno.Text = DR1["Portno"].ToString().Trim();
                        cbobaudrate.Text = DR1["BaudRate"].ToString().Trim();
                        cbodatabit.Text = DR1["DataBit"].ToString().Trim();
                        cboparity.Text = DR1["Parity"].ToString().Trim();
                        cbostopbit.Text = DR1["StopBit"].ToString().Trim();
                        cbostkeychar.Text = DR1["StKeychar"].ToString().Trim();
                        cbounitkeyrecive.Text = DR1["UnitKeyRecive"].ToString().Trim();
                        cblineindex.Text = DR1["Selectline"].ToString().Trim();
                    }
                    DR1.Close();

                    string sql2 = "select * from tbsettruckscale where idbranch='" + cbobranch.SelectedValue.ToString() + "'";
                    SqlCommand CM2 = new SqlCommand(sql2, CN);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    DR2.Read();
                    {
                        Program.comport = DR2["Portno"].ToString().Trim();
                        Program.baudrate = DR2["BaudRate"].ToString().Trim();
                        Program.databit = Convert.ToInt16(DR2["DataBit"].ToString().Trim());
                        Program.parity = DR2["Parity"].ToString().Trim();
                        Program.stopbit = DR2["StopBit"].ToString().Trim();
                        Program.stkeychar = Convert.ToInt16(DR2["StKeychar"].ToString().Trim());
                        Program.UnitKeyRecive = Convert.ToInt16(DR2["UnitKeyRecive"].ToString().Trim());
                        Program.Selectline = Convert.ToInt16(DR2["Selectline"].ToString().Trim());
                    }
                    DR2.Close();
                }

                else { ClearAllCombox(); }
            }
            CN.Close();
        }

        private void FrmTruckscale_Load(object sender, EventArgs e)
        {
            AddComboconfig();
            Loadbranch();
        }

        private void AddComboconfig()
        {
            //Comport NO
            cboportno.Items.Add("COM1");
            cboportno.Items.Add("COM2");
            cboportno.Items.Add("COM3");
            cboportno.Items.Add("COM4");
            cboportno.Items.Add("COM5");
            cboportno.Items.Add("COM6");
            cboportno.Items.Add("COM7");
            cboportno.Items.Add("COM8");
            cboportno.Items.Add("COM9");
            cboportno.Items.Add("COM10");
            cboportno.Items.Add("COM11");
            cboportno.Items.Add("COM12");
            cboportno.Items.Add("COM13");
            cboportno.Items.Add("COM14");
            cboportno.Items.Add("COM15");
            cboportno.Items.Add("COM16");
            cboportno.Items.Add("COM17");
            cboportno.Items.Add("COM18");
            cboportno.Items.Add("COM19");
            cboportno.Items.Add("COM20");

            //BaudRat or Bitrate
            cbobaudrate.Items.Add("110");
            cbobaudrate.Items.Add("300");
            cbobaudrate.Items.Add("1200");
            cbobaudrate.Items.Add("2400");
            cbobaudrate.Items.Add("4800");
            cbobaudrate.Items.Add("9600");
            cbobaudrate.Items.Add("19200");
            cbobaudrate.Items.Add("38400");
            cbobaudrate.Items.Add("57600");
            cbobaudrate.Items.Add("115200");
            cbobaudrate.Items.Add("230400");
            cbobaudrate.Items.Add("460800");
            cbobaudrate.Items.Add("921600");

            //Data Bit
            cbodatabit.Items.Add("5");
            cbodatabit.Items.Add("6");
            cbodatabit.Items.Add("7");
            cbodatabit.Items.Add("8");

            //Parity
            cboparity.Items.Add("None");
            cboparity.Items.Add("Even");
            cboparity.Items.Add("Odd");
            cboparity.Items.Add("Mark");
            cboparity.Items.Add("Space");

            //stop bit
            cbostopbit.Items.Add("1");
            cbostopbit.Items.Add("1.5");
            cbostopbit.Items.Add("2");

            //เริ่มการรับข้อมูลตั้งแต่อักษรตัวที่
            cbostkeychar.Items.Add("1");
            cbostkeychar.Items.Add("2");
            cbostkeychar.Items.Add("3");
            cbostkeychar.Items.Add("4");
            cbostkeychar.Items.Add("5");
            cbostkeychar.Items.Add("6");
            cbostkeychar.Items.Add("7");
            cbostkeychar.Items.Add("8");
            cbostkeychar.Items.Add("9");
            cbostkeychar.Items.Add("10");

            //จำนวนการรับข้อมูล กี่ตัว
            cbounitkeyrecive.Items.Add("1");
            cbounitkeyrecive.Items.Add("2");
            cbounitkeyrecive.Items.Add("3");
            cbounitkeyrecive.Items.Add("4");
            cbounitkeyrecive.Items.Add("5");
            cbounitkeyrecive.Items.Add("6");
            cbounitkeyrecive.Items.Add("7");
            cbounitkeyrecive.Items.Add("8");
            cbounitkeyrecive.Items.Add("9");
            cbounitkeyrecive.Items.Add("10");

            //select line
            cblineindex.Items.Add("1");
            cblineindex.Items.Add("2");
            cblineindex.Items.Add("3");
            cblineindex.Items.Add("4");
            cblineindex.Items.Add("5");
            cblineindex.Items.Add("6");
            cblineindex.Items.Add("7");
            cblineindex.Items.Add("8");
            cblineindex.Items.Add("9");
            cblineindex.Items.Add("10");
        }

        private void Loadbranch()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string sql1 = "select idbranch,bname from vautokeychar ";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, CN);
            da1.Fill(ds, "loadbranch");
            cbobranch.DataSource = ds.Tables["loadbranch"];
            cbobranch.DisplayMember = "bname";
            cbobranch.ValueMember = "idbranch";
            cbobranch.Text = "";
            CN.Close();
        }

        private void ClearAllCombox()
        {
            cbobaudrate.Text = "";
            cbobranch.Text = "";
            cbodatabit.Text = "";
            cbounitkeyrecive.Text = "";
            cboparity.Text = "";
            cboportno.Text = "";
            cbostkeychar.Text = "";
            cbostopbit.Text = "";
            cblineindex.Text = "";        
        }

        private void btnsaveedit_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();

            if (counts == 0)//Add New
            {
                string sql = "insert into tbsettruckscale(idbranch,Portno,BaudRate,DataBit,Parity,StopBit,StKeychar,UnitKeyRecive,Selectline) values (" + cbobranch.SelectedValue.ToString() + ",'" + cboportno.Text + "','" + cbobaudrate.Text + "'," + cbodatabit.Text + ",'" + cboparity.Text + "','" + cbostopbit.Text + "'," + cbostkeychar.Text + "," + cbounitkeyrecive.Text + "," + cblineindex.Text + ")";

                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();

                MessageBox.Show("บันทึกข้อมูลสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAllCombox();

            }

            else  //Edit
            {
                string sql = "update tbsettruckscale set Portno='" + cboportno.Text + "',BaudRate='" + cbobaudrate.Text + "',DataBit='" + cbodatabit.Text + "',Parity='" + cboparity.Text + "',StopBit='" + cbostopbit.Text + "',StKeychar='" + cbostkeychar.Text + "',UnitKeyRecive='" + cbounitkeyrecive.Text + "',Selectline='" + cblineindex.Text + "' Where idbranch= " + cbobranch.SelectedValue.ToString() + "";
                SqlCommand CM = new SqlCommand(sql, CN);
                CM.ExecuteNonQuery();

                MessageBox.Show("แก้ไขข้อมูลสำเร็จ !", "รายงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearAllCombox();
            }
            CN.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectToSerail();
        }

        private void ConnectToSerail()
        {
            try
            {
                sport.PortName = Program.comport;
                sport.BaudRate = int.Parse(Program.baudrate);
                sport.Parity = (Parity)Enum.Parse(typeof(Parity), Program.parity);
                sport.DataBits = Program.databit;
                sport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), Program.stopbit);
                sport.Handshake = Handshake.None;
                sport.DataReceived += OnSerialDataReceived;
                sport.ReadTimeout = 800;
                sport.WriteTimeout = 800;
                sport.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Comport Access Denie ! " + ex.Message + "", "Comport Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OnSerialDataReceived(object sender, SerialDataReceivedEventArgs args)
        {
            if (sport.IsOpen)
            { 
                Thread.Sleep(800);
                string data = sport.ReadExisting();
                this.BeginInvoke(new MethodInvoker(delegate() { richTextBox1.Text = data.Trim(); }));
                sport.Close();

                RichTextBox.CheckForIllegalCrossThreadCalls = false;              
                for (int i = 0; i < richTextBox1.Lines.Length; i++)
                {
                    if (Program.Selectline == i)
                    {
                        textBox1.Text = richTextBox1.Lines[i].Trim();
                    }
                }

                textBox1.SelectionStart = Program.stkeychar;
                textBox1.SelectionLength = Program.UnitKeyRecive;
                textBox2.Text = textBox1.SelectedText.Trim();
            }
        }
    }
}