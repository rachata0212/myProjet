using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SaleOrder
{
    public partial class Frmselect_printtruck : Form
    {
        public Frmselect_printtruck()
        {
            InitializeComponent();
        }

        public string idtran = "";
        private void Frmselect_printtruck_Load(object sender, EventArgs e)
        {

        }

        private void btnprinttosup_Click(object sender, EventArgs e)
        {
            Frmreporttruck frpt = new Frmreporttruck();
            frpt.idtran = idtran;
            frpt.typetruck = "truckouttocusaf";
            frpt.ShowDialog(); 
        }

        private void btnprinttotran_Click(object sender, EventArgs e)
        {  
            Frmreporttruck frpt = new Frmreporttruck();
            frpt.idtran = idtran;
            frpt.typetruck = "truckouttocusbf";
            frpt.ShowDialog();  
        }       
    }
}