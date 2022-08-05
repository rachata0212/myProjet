using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SaleOrder
{
    public partial class FrmOrderSelect : Form
    {
        public FrmOrderSelect()
        {
            InitializeComponent();
        }

        public string idselect = ""; public string nameselect = "";
        DataSet ds4 = new DataSet(); dtssaleorder dssearch4 = new dtssaleorder();
        DataSet ds5 = new DataSet(); dtssaleorder dssearch5 = new dtssaleorder();
        DataSet ds6 = new DataSet(); dtssaleorder dssearch6 = new dtssaleorder();
        DataSet ds7 = new DataSet(); dtssaleorder dssearch7 = new dtssaleorder();
        DataSet ds8 = new DataSet(); dtssaleorder dssearch8 = new dtssaleorder();
        public int idpro = 0;
        public int idcargroup = 0;
        public string idsearch = "0";

        private void FrmOrderSelect_Load(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); string sql;            
           
            //ต้องค้นหาสลับกัน
            ///
            //
            if (nameselect == "Sale")
            {
                LoadIDSearchMatch();
                dtgsaletranstatus.Visible = true; dtgsaletranstatus.Dock = DockStyle.Fill;                 
                ////load grid sale
                 sql = CheckUpdateDTGsaleorder(CN);
            }
            if (nameselect == "Pur")
            {
                LoadIDSearchMatch();
               dtgpurtranstatus.Visible = true; dtgpurtranstatus.Dock = DockStyle.Fill;
                ////load grid pur
               sql = CheckUpdateDTGpurchaseorder(CN);
            }

            if (nameselect == "Recoverypur")
            {
                dtgrecoverpur.Visible = true; dtgrecoverpur.Dock = DockStyle.Fill;
                ////load grid cancle pur
                sql = CheckCanclepurchase(CN);
            }

            if (nameselect == "Recoverysale")
            {
                dtgrecoversale.Visible = true; dtgrecoversale.Dock = DockStyle.Fill;
                ////load grid cancle sale
                sql = CheckCanclesale(CN);
            }

            if (nameselect == "Recoverypurtosale")
            {
                dtgrecoveryptos.Visible = true; dtgrecoveryptos.Dock = DockStyle.Fill;
                ////load grid cancle pur to sale
                sql = CheckCanclepurtosale(CN);                
            }            
        }

        private void LoadIDSearchMatch()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open(); string sql = "";

            if (nameselect == "Sale")
            { sql = "select * from vpurchase  where idtran='" + idsearch.Trim() + "'"; }
            if (nameselect == "Pur")
            { sql = "select * from vsaleorder where idtran='" + idsearch.Trim() + "'"; }

            SqlCommand CM1 = new SqlCommand(sql, CN);
            SqlDataReader DR1 = CM1.ExecuteReader();

            DR1.Read();
            {
                idpro = Convert.ToInt16(DR1["idpro"].ToString().Trim());
                idcargroup = Convert.ToInt16(DR1["idcargroup"].ToString().Trim());
            }
            DR1.Close();
        }

        private string CheckCanclepurtosale(SqlConnection CN)
        {
            ds6.Clear(); dssearch8.Clear();
            dtgrecoveryptos.DataSource = dssearch8;
            string sql = "select * from vcanclepurtosale";
            SqlDataAdapter da8 = new SqlDataAdapter(sql, CN);
            da8.Fill(ds8, "vpurtosalecancle");
            dtgrecoveryptos.DataSource = ds8.Tables["vpurtosalecancle"];
            idselect = "0";
            return sql;
        }

        private string CheckCanclepurchase(SqlConnection CN)
        {
            ds6.Clear(); dssearch6.Clear();
            dtgrecoverpur.DataSource = dssearch6;
            string sql = "select * from vcanclepurchase";
            SqlDataAdapter da6 = new SqlDataAdapter(sql, CN);
            da6.Fill(ds6, "vpurcancle");
            dtgrecoverpur.DataSource = ds6.Tables["vpurcancle"];
            idselect = "0";
            return sql;
        }

        private string CheckCanclesale(SqlConnection CN)
        {
            ds7.Clear(); dssearch7.Clear();
            dtgrecoversale.DataSource = dssearch7;
            string sql = "select * from vcanclesaleorder";
            SqlDataAdapter da7 = new SqlDataAdapter(sql, CN);
            da7.Fill(ds7, "vsalecancle");
            dtgrecoversale.DataSource = ds7.Tables["vsalecancle"];
            idselect = "0";
            return sql;
        }
         
        private string CheckUpdateDTGpurchaseorder(SqlConnection CN)
        {
            ds4.Clear(); dssearch4.Clear();
            dtgpurtranstatus.DataSource = dssearch4;
            string sql = "select * from vpurchase  WHERE idstatus = 3 AND idpro =" + idpro + " And idcargroup=" + idcargroup + " AND idtran is null";
            SqlDataAdapter da4 = new SqlDataAdapter(sql, CN);
            da4.Fill(ds4, "vpuror");
            dtgpurtranstatus.DataSource = ds4.Tables["vpuror"]; dtgpurtranstatus.Visible = true;
            idselect = "0";          
            return sql;
        }

        private string CheckUpdateDTGsaleorder(SqlConnection CN)
        {
            ds5.Clear(); dssearch5.Clear();
            dtgsaletranstatus.DataSource = dssearch5;
            string sql = "select * from vsaleorder  WHERE idstatus = 3 AND idpro =" + idpro + " And idcargroup=" + idcargroup + " AND idtran is null";
            SqlDataAdapter da5 = new SqlDataAdapter(sql, CN);
            da5.Fill(ds5, "vordert");
            dtgsaletranstatus.DataSource = ds5.Tables["vordert"]; dtgsaletranstatus.Visible = true;
            idselect = "0";          
            return sql;
        }

        private void dtgpurtranstatus_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idselect = dtgpurtranstatus[0, e.RowIndex].Value.ToString();
            this.Close();
        }

        private void dtgsaletranstatus_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;          
                idselect = dtgsaletranstatus[0, e.RowIndex].Value.ToString();
                this.Close();
        }

        private void dtgrecoverpur_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idselect = dtgrecoverpur[0, e.RowIndex].Value.ToString();
            this.Close();
        }

        private void dtgrecoversale_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idselect = dtgrecoversale[0, e.RowIndex].Value.ToString();
            this.Close();
        }

        private void dtgrecoveryptos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            idselect = dtgrecoveryptos[0, e.RowIndex].Value.ToString();
            this.Close();
        }


    }
}