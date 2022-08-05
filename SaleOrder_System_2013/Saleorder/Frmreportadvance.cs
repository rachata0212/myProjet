using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SaleOrder
{
    public partial class Frmreportadvance : Form
    {
        public Frmreportadvance()
        {
            InitializeComponent();
        }

        string stdaterp = "";
        string eddaterp = "";


        private void dtpdate_ValueChanged(object sender, EventArgs e)
        {
            if (rdostdate.Checked == true)
            {
                lblstdate.Text = rdostdate.Text + ": " + dtpdate.Value.ToShortDateString();            
            }
            if (rdeddate.Checked == true)
            {
                lbleddate.Text = rdeddate.Text + ": " + dtpdate.Value.ToShortDateString(); 
            }








        }
    }
}