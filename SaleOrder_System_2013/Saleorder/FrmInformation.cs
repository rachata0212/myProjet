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
    public partial class FrmInformation : Form
    {
        public FrmInformation()
        {
            InitializeComponent();
        }
        public int xposition;
        public int yposition;
        public string idtran = "";
        public int idtypeinfor = 0;

        private void FrmInformation_Load(object sender, EventArgs e)
        {
            this.Location = new Point(xposition, yposition);
            if (idtypeinfor == 0)//pur to sale
            {
                lblinformation.Text = "��������´�����ū��� -> ��� �Ţ���: " + idtran.Trim();
                //lblpurhcase.Text = "�����Ż��������� -> ��ѧ";
                loadpurchase(); loadsale();
            }
            if (idtypeinfor == 1)//purchase
            {
                lblinformation.Text = "��������´�����ū����Ţ���: " + idtran.Trim();                
                this.ClientSize = new System.Drawing.Size(313, 216);
                loadsale();
            }
            if (idtypeinfor == 2)//sale
            {
                lblinformation.Text = "��������´�����Ţ���Ţ���: " + idtran.Trim();
                lblpurhcase.Text = "�����ŵ鹷ҧ";
                //this.Size.Width=;
                this.ClientSize = new System.Drawing.Size(313, 216);
                loadpurchase();
            }
        }

        private void loadpurchase()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string strPur = ""; string sql1 = ""; string strSale = "";

            if (idtypeinfor == 0)//pur to sale
            {
                sql1 = "SELECT idpur,datepur,comsup,compur,comtran,proname,carname,serailcar,telcontact FROM vpurchase WHERE idtran = '" + idtran.Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();
                DR1.Read();
                {
                    strPur += "���ʫ���: " + DR1["idpur"].ToString() + "\r\n";
                    strPur += "�ѹ������: " + DR1["datepur"].ToString() + "\r\n";
                    strPur += "����˹���: " + DR1["comsup"].ToString() + "\r\n";
                    strPur += "������: " + DR1["compur"].ToString() + "\r\n";
                    strPur += "��颹��: " + DR1["comtran"].ToString() + "\r\n";
                    strPur += "�Թ���: " + DR1["proname"].ToString() + "\r\n";
                    strPur += "��Դ/�����ö: " + DR1["carname"].ToString() + "\r\n";
                    strPur += "����¹: " + DR1["serailcar"].ToString() + "\r\n";
                    strPur += "������: " + DR1["telcontact"].ToString() + "\r\n";
                }
                DR1.Close();
            }
            if (idtypeinfor == 1)//sale �����Ż���
            {
                string sql = "SELECT idtran FROM tbpurchase WHERE idpur = '" + idtran.Trim() + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();
                DR.Read();
                {
                    idtran = DR["idtran"].ToString().Trim();
                }
                DR.Close();

                //sql1 = "SELECT idorder,orderdate,comcus,proname,carname,remark1 FROM vsaleorder WHERE idtran = '" + idtran.Trim() + "'";
                //SqlCommand CM1 = new SqlCommand(sql1, CN);
                //SqlDataReader DR1 = CM1.ExecuteReader();
                //DR1.Read();
                //{
                //    strSale += "���ʢ��: " + DR1["idorder"].ToString() + "\r\n";
                //    strSale += "�ѹ����ѺOrder: " + DR1["orderdate"].ToString() + "\r\n";
                //    strSale += "������: " + DR1["comcus"].ToString() + "\r\n";
                //    strSale += "�Թ���: " + DR1["proname"].ToString() + "\r\n";
                //    strSale += "��Դ/������ö: " + DR1["carname"].ToString() + "\r\n";
                //    strSale += "�����˵�: " + DR1["remark1"].ToString() + "\r\n";
                //}
                //DR1.Close();
            }
            txtpurchase.Text = strPur;
        }

        private void loadsale()
        {
            SqlConnection CN = new SqlConnection();
            CN.ConnectionString = Program.urldb;
            CN.Open();
            string strSale = ""; string sql1 = ""; string strPur = "";

            if (idtypeinfor == 0)//pur to sale
            {
                sql1 = "SELECT idorder,orderdate,comcus,proname,carname,remark1 FROM vsaleorder WHERE idtran = '" + idtran.Trim() + "'";
                SqlCommand CM1 = new SqlCommand(sql1, CN);
                SqlDataReader DR1 = CM1.ExecuteReader();
                DR1.Read();
                {
                    strSale += "���ʢ��: " + DR1["idorder"].ToString() + "\r\n";
                    strSale += "�ѹ����ѺOrder: " + DR1["orderdate"].ToString() + "\r\n";
                    strSale += "������: " + DR1["comcus"].ToString() + "\r\n";
                    strSale += "�Թ���: " + DR1["proname"].ToString() + "\r\n";
                    strSale += "��Դ/������ö: " + DR1["carname"].ToString() + "\r\n";
                    strSale += "�����˵�: " + DR1["remark1"].ToString() + "\r\n";
                }
                DR1.Close();

                txtorder.Text = strSale;                
            }
            if (idtypeinfor == 1)//�٢����Ż��·ҧ�ҡ����
            {
                int countitems = 0;

                string sql = "SELECT idtran FROM tbpurchase WHERE idpur = '" + idtran.Trim() + "'";
                SqlCommand CM = new SqlCommand(sql, CN);
                SqlDataReader DR = CM.ExecuteReader();
                DR.Read();
                {
                    idtran = DR["idtran"].ToString().Trim();
                }
                DR.Close();

                sql1 = "SELECT count(idorder)as coutitem FROM vsaleorder WHERE idtran = '" + idtran.Trim() + "'";
                SqlCommand CM0 = new SqlCommand(sql1, CN);
                SqlDataReader DR0 = CM0.ExecuteReader();
                DR0.Read();
                {
                    countitems = Convert.ToInt16(DR0["coutitem"].ToString());
                }
                DR0.Close();

                if (countitems == 1)
                {
                    sql1 = "SELECT idtran,idorder,orderdate,comcus,dateWbf,weigthsup,dateWcus,weigthsup,weigthcus,weigthsupdfsale,moisture,remark1 FROM vWFsTCrp WHERE idtran = '" + idtran.Trim() + "'";
                    SqlCommand CM1 = new SqlCommand(sql1, CN);
                    SqlDataReader DR1 = CM1.ExecuteReader();
                    DR1.Read();
                    {
                        strSale += "�Ţ��袹��: " + DR1["idtran"].ToString() + "\r\n";
                        strSale += "�Ţ�����: " + DR1["idorder"].ToString() + "   �ѹ����Ѻ���: " + DR1["orderdate"].ToString() + "\r\n";
                        strSale += "����ѷ ������: " + DR1["comcus"].ToString() + "\r\n";
                        strSale += "�ѹ����͡�鹷ҧ: " + DR1["dateWbf"].ToString() + "\r\n";
                        strSale += "�ѹ���֧���·ҧ: " + DR1["dateWcus"].ToString() + "\r\n";
                        strSale += "��.�鹷ҧ: " + DR1["weigthsup"].ToString() + "   ��.���·ҧ: " + DR1["weigthcus"].ToString() + "\r\n";
                        strSale += "��.��ǧ��ҧ: " + DR1["weigthsupdfsale"].ToString() + "\r\n";
                        strSale += "�������: " + DR1["moisture"].ToString() + "\r\n";
                        strSale += "�����˵�: " + DR1["remark1"].ToString() + "\r\n";
                    }
                    DR1.Close();
                    lblpurhcase.Text = "�����Ż��·ҧ �������觵ç (���� -> ���)";
                }

                else if (countitems != 1)
                {
                    sql1 = "SELECT idtran,idtranauto,bname,comtran,compur,serailcar,dateWbf,dateWaf,weigthbf,weigthaf,weigthnet,weigthsup,weigthsupdfsale,moisture,kkperweigth,jobtrack FROM vWTrckinRP WHERE idtran = '" + idtran.Trim() + "'";
                    SqlCommand CM2 = new SqlCommand(sql1, CN);
                    SqlDataReader DR2 = CM2.ExecuteReader();
                    DR2.Read();
                    {
                        strSale += "�Ţ��袹��: " + DR2["idtran"].ToString() + "     �Ţ��������: " + DR2["idtranauto"].ToString() + "\r\n";
                        strSale += "�Ң��Ѻ�Թ���: " + DR2["bname"].ToString() + "\r\n";                       
                        strSale += "����ѷ ����: " + DR2["comtran"].ToString() + "\r\n";                      
                        strSale += "����¹ö: " + DR2["serailcar"].ToString() + "\r\n";
                        strSale += "�ѹ��������: " + DR2["dateWbf"].ToString() + "\r\n";
                        strSale += "�ѹ������͡: " + DR2["dateWaf"].ToString() + "\r\n";
                        strSale += "��.������: " + DR2["weigthbf"].ToString() + "   ��.����͡: " + DR2["weigthaf"].ToString() + "\r\n";
                        strSale += "��.�ط��: " + DR2["weigthnet"].ToString() + "   ��.�ç�����: " + DR2["weigthsup"].ToString() + " \r\n";
                        strSale += "��.��ǹ��ҧ: " + DR2["weigthsupdfsale"].ToString() + "\r\n";
                        strSale += "��������Ѻ���: " + DR2["moisture"].ToString() + "\r\n";
                        strSale += "��./���ŵǧ: " + DR2["kkperweigth"].ToString() + "\r\n";
                        strSale += "ʶҹЧҹ: " + DR2["jobtrack"].ToString() + "\r\n";
                    }
                    DR2.Close();
                    lblpurhcase.Text = "�����Ż��·ҧ �������Ѻ��Ҥ�ѧ (���� -> ��ѧ)";
                }

                txtpurchase.Text = strSale;
            }          
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}