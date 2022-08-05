using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;



namespace SaleOrder
{
    public partial class Frmresetpwdbyemail : Form
    {
        public Frmresetpwdbyemail()
        {
            InitializeComponent();
        }

        public string uid = "";
        public int idsuccess = 0;

        private void btncancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("mail.hybridenergy.co.th");
                mail.From = new MailAddress(makemail.Text.Trim());
                mail.To.Add("admin@hybridenergy.co.th");
                mail.Subject = "Reset Password User SaleOrder System.";
                mail.Body = "Your Have Reset Password User: " + uid + " Tel No: " + maketel.Text.Trim() + " DateTime: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                SmtpServer.Port = 25;
               // SmtpServer.Credentials = new System.Net.NetworkCredential("admin@hybridenergy.co.th", "hbadmin"); ไม่ต้องมีก็ได้
                SmtpServer.EnableSsl = false;
                SmtpServer.Send(mail);

                idsuccess = 1;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}