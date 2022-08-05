using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SaleOrder
{
    public partial class Frmqickview : Form
    {
        public Frmqickview()
        {
            InitializeComponent();
        }

        string dtsum;     

        private void RageSTToED_datePrint(Frmviewreport frrp)
        {
            frrp.startdate = Convert.ToInt16(dtpstartdate.Value.Day.ToString());
            frrp.startmount = Convert.ToInt16(dtpstartdate.Value.Month.ToString());
            frrp.startyear = Convert.ToInt16(dtpstartdate.Value.Year.ToString());          
        }

        private void Frmqickview_Load(object sender, EventArgs e)
        {

        }

        private void btnprintpurchase_Click(object sender, EventArgs e)
        {            
            Frmviewreport frrp = new Frmviewreport();
            frrp.rpname = "crpPurchasequick";
            RageSTToED_datePrint(frrp);
            frrp.ShowDialog();
        }

        private void btnprintsale_Click(object sender, EventArgs e)
        {
            Frmviewreport frrp = new Frmviewreport();
            frrp.rpname = "crpSalequick";
            RageSTToED_datePrint(frrp);
            frrp.ShowDialog();
        }
    }
}