using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Truck_Analytics
{
    public partial class F_Density : Form
    {
        public F_Density()
        {
            InitializeComponent();
        }

        public string TicketCodeIn = "";
        public double Netweight = 0;
        public double Value_Density = 0;  //ค่า Den จากตารางที่ตั้งค่าไว้
        public double Loss_Density = 0; //ค่าที่ยอมรับ
        public int Status_check = 0;  //ค่าที่ต้อง return กลับ
        public double Qty_Product; //น้ำหนัก เริ่มต้น
        public string Vendor_Code = "";
        public int STS_Edit = 0;
        //---------------------------

        //หาค่าจำนวนสินค้า
        double Qty_result_LO = 0;

        // หาค่าต่าง จะผลที่ได้ กับค่าที่ตั้งไว้
        double Value_Dif_LO = 0;

        //หาค่า Density
        double Den_result_LO = 0;

        //หาค่าจำนวนสินค้า
        double Qty_result_Load = 0;

        // หาค่าต่าง จะผลที่ได้ กับค่าที่ตั้งไว้
        double Value_Dif_Load = 0;

        //หาค่า Density
        double Den_result_Load = 0;

        double Value_Density_load = 0;

        // New branch
        int ID_Branch = 0;


        // SAve log
        string Msg = "";
        string Log_NewValue = "";
        string Log_OldValue = "";

        private void F_Density_Load(object sender, EventArgs e)
        {
            txt_Netweight.Text = Netweight.ToString("##,###");
            txt_Den_LO.Text = Value_Density.ToString();
            txt_ErrAcp_LO.Text = Loss_Density.ToString();
            txt_ErrAcp_Load.Text = Loss_Density.ToString();
            txt_Qtyproduct.Text = Qty_Product.ToString("##,###");
            Cal_Dendif_LO();
            Load_Branch();
            Load_Degree();
            //btn_accept.Focus();
        }

        private void Save_NewBranch()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            //con.Open();

            try
            {
                con.Open();
                string sql3 = "Insert Into [TB_Branch] ([BranchName],[BranchAddress],[VenCus_ID])  Values ('ไม่ระบุ','','" + Vendor_Code + "')";
                SqlCommand CM3 = new SqlCommand(sql3, con);
                SqlDataReader DR3 = CM3.ExecuteReader();
                con.Close();

                con.Open();
                string sql1 = "SELECT [BranchID] FROM [dbo].[TB_Branch] WHERE [VenCus_ID]= '" + Vendor_Code + "' ";
                SqlCommand CM1 = new SqlCommand(sql1, con);
                SqlDataReader DR1 = CM1.ExecuteReader();

                DR1.Read();
                {
                    ID_Branch = Convert.ToInt16(DR1["BranchID"].ToString());                  
                }
                DR1.Close();
                con.Close();
            }

            catch
            { con.Close(); }
        }



        private void Load_Branch()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [BranchID],[BranchName] FROM [dbo].[V_Branch_Density] Where  [CustomerID] = '" + Vendor_Code + "'", con);

            DataSet ds = new DataSet();
            //ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            //Load product tab weight scale Setup
            cb_branch.DataSource = ds.Tables[0];
            cb_branch.DisplayMember = "BranchName";
            cb_branch.ValueMember = "BranchID";
            con.Close();

            if (cb_branch.Text == "")
            {
                chk_newBranch.Checked = true; cb_branch.Text = "ไม่ระบุ"; chk_newBranch.Enabled = true;
            }
        }

        private void Load_Degree()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT [Degree_ID],[Degree_Value] FROM [dbo].[TB_Degree] ", con);

            DataSet ds = new DataSet();
            //ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            //Load product tab weight scale Setup
            cb_degree.DataSource = ds.Tables[0];
            cb_degree.DisplayMember = "Degree_Value";
            cb_degree.ValueMember = "Degree_ID";
            con.Close();

        }

        private void btn_accept_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("คุณต้องการบันทึกข้อมูลใช่หรือไม่?",
   "ยืนยันข้อมูลการคำนวณค่าความหนาแน่นสินค้าตามปริมาตร",
   MessageBoxButtons.YesNo);

            if (result1 == DialogResult.Yes)
            {
                //MessageBox.Show("You answered yes, yes and no.");

                if (ptb_true.Visible == true)
                {
                    Save_DensityRecord();
                    Status_check = 1;
                    this.Close();
                }

                if (ptb_false.Visible == true)
                {
                    // ขอรหัสผ่าน จากผู้มีสิทธฺิ์อนุมัติ  และส่งอีเมล์
                    F_Password fpd = new F_Password();
                    fpd.id_request = 4;
                    fpd.ShowDialog();

                    if (fpd.sts_pwd == 1)
                    {
                        Save_DensityRecord();
                        Status_check = 1;
                        this.Close();
                    }
                }
            }
        }


        private void Cal_Dendif_LO()
        {
            try
            {
                Value_Density = Convert.ToDouble(txt_Den_LO.Text);
                Qty_result_LO = Convert.ToDouble(Netweight / Value_Density);  //หาจำนวนลิตร
                txt_Qty_LO.Text = Qty_result_LO.ToString("##,###");

                Value_Dif_LO = Qty_result_LO - Qty_Product;  //ส่วนต่าง
                lbl_Valuedif_LO.Text = Value_Dif_LO.ToString("F");

                Den_result_LO = (Value_Dif_LO / Qty_Product) * 100;   //% ร้อยล่ะ
                lbl_avg_LO.Text = Den_result_LO.ToString("F");

                double x = Loss_Density - (Loss_Density * 2);   //หาค่าลบ
                double z = Loss_Density;   //หาค่าบวก
                                

                // ให้เช็ค่า เบี่ยงเบน บวก ลบ ว่ารับได้เท่าไหร่
                if (Den_result_LO > x && Den_result_LO < z)
                {
                    ptb_true.Visible = true;
                    lbl_msglab.Text = "ผลสอบทวนผ่าน";
                    lbl_msglab.ForeColor = Color.Green;
                    btn_accept.Text = "บันทึก";
                    //btn_accept.Focus();
                }

                else
                {
                    ptb_false.Visible = true;
                    lbl_msglab.Text = "ผลสอบทวนไม่ผ่าน";
                    lbl_msglab.ForeColor = Color.Red;
                    btn_accept.Text = "ขอรหัสการอนุมัติ";
                    //btn_accept.Focus();

                }
            }
            catch
            {
                lbl_Valuedif_LO.Text = ""; lbl_avg_LO.Text = "";
            }

        }


        private void Save_DensityRecord()
        {
            SqlConnection con = new SqlConnection(Program.pathdb_Weight);
            con.ConnectionString = Program.pathdb_Weight;
            SqlDataAdapter dtAdapter = new SqlDataAdapter();

            if (chk_newBranch.Checked == false)
            {
                ID_Branch = Convert.ToInt16(cb_branch.SelectedValue.ToString());
            }

            else
            {
                //insert & Load New branch
                Save_NewBranch();

            }

            int Sealaudit_Only = 0;
            if (chk_SealAll.Checked == true) { Sealaudit_Only = 1; }

            int Seal_Point1 = 0;
            int Seal_Point2 = 0;
            int Seal_Point3 = 0;
            int Seal_Point4 = 0;
            int Seal_Point5 = 0;
            int Seal_Point6 = 0;
            int Seal_Point7 = 0;
            int Seal_Point8 = 0;
            int Seal_Point9 = 0;
            int Seal_Point10 = 0;
            int Seal_Point11 = 0;
            int Seal_Point12 = 0;
            int Seal_Point13 = 0;
            int Seal_Point14 = 0;
            int Seal_Point15 = 0;

            if (chk_a1point.Checked == true) { Seal_Point1 = 1; }
            if (chk_a2point.Checked == true) { Seal_Point2 = 1; }
            if (chk_a3point.Checked == true) { Seal_Point3 = 1; }
            if (chk_a4point.Checked == true) { Seal_Point4 = 1; }
            if (chk_a5point.Checked == true) { Seal_Point5 = 1; }
            if (chk_a6point.Checked == true) { Seal_Point6 = 1; }
            if (chk_a7point.Checked == true) { Seal_Point7 = 1; }
            if (chk_a8point.Checked == true) { Seal_Point8 = 1; }
            if (chk_a9point.Checked == true) { Seal_Point9 = 1; }
            if (chk_a10point.Checked == true) { Seal_Point10 = 1; }
            if (chk_a11point.Checked == true) { Seal_Point11 = 1; }
            if (chk_a12point.Checked == true) { Seal_Point12 = 1; }
            if (chk_a13point.Checked == true) { Seal_Point13 = 1; }
            if (chk_a14point.Checked == true) { Seal_Point14 = 1; }
            if (chk_a15point.Checked == true) { Seal_Point15 = 1; }

            int delta = DayOfWeek.Monday - DateTime.Now.DayOfWeek;
            DateTime monday = DateTime.Now.AddDays(delta == 1 ? -6 : delta);
            string date = monday.ToString("yyyy-MM-dd") + " 00:00:00";          

            con.Open();
            string sql6 = "SELECT Count([TicketCodeIn]) AS 'T_Count' FROM [dbo].[TB_DensityRecord] WHERE [TicketCodeIn]= '" + TicketCodeIn + "'";
            SqlCommand CM6 = new SqlCommand(sql6, con);
            SqlDataReader DR6 = CM6.ExecuteReader();

            DR6.Read();
            {
                STS_Edit = Convert.ToInt16(DR6["T_Count"].ToString().Trim());
            }
            DR6.Close();
            con.Close();


            string sql = "";

            if (STS_Edit == 0)
            {
                sql = "Insert Into [TB_DensityRecord] ([TicketCodeIn],[DateRecordDen],[Qty_ProSTD],[Qty_Product],[LabDensity],[ValueDensity],[DeffDensity],[Qty_Product_Load],[LabDensity_Load],[ValueDensity_Load],[DeffDensity_Load],[Sealaudit_Only],[Seal_Point1],[Seal_Point2],[Seal_Point3],[Seal_Point4],[Seal_Point5],[Seal_Point6],[Seal_Point7],[Seal_Point8],[Seal_Point9],[Seal_Point10],[Seal_Point11],[Seal_Point12],[Seal_Point13],[Seal_Point14],[Seal_Point15],[BranchID],[Degree_ID]) Values('" + TicketCodeIn + "','" + date + "'," + Qty_Product + ", " + Qty_result_LO.ToString("#") + ", " + Value_Density + "," + Value_Dif_LO.ToString("F") + ", " + Den_result_LO.ToString("F") + ", " + Qty_result_Load.ToString("#") + ", " + Value_Density_load + "," + Value_Dif_Load.ToString("F") + ", " + Den_result_Load.ToString("F") + "," + Sealaudit_Only + "," + Seal_Point1 + "," + Seal_Point2 + "," + Seal_Point3 + "," + Seal_Point4 + "," + Seal_Point5 + "," + Seal_Point6 + "," + Seal_Point7 + "," + Seal_Point8 + "," + Seal_Point9 + "," + Seal_Point10 + "," + Seal_Point11 + "," + Seal_Point12 + "," + Seal_Point13 + "," + Seal_Point14 + "," + Seal_Point15 + "," + ID_Branch + "," + cb_degree.SelectedValue.ToString() + ")";

                Msg = "Insert Data in DensityRecord!";            
            }

            if (STS_Edit == 1)
            {
                sql = "Update [TB_DensityRecord]  Set [DateRecordDen] ='" + date + "',[Qty_ProSTD] = " + Qty_Product + ",[Qty_Product]=" + Qty_result_LO.ToString("#") + ",[LabDensity]= " + Value_Density + ",[ValueDensity] =" + Value_Dif_LO.ToString("F") + ",[DeffDensity]=" + Den_result_LO.ToString("F") + ", [Qty_Product_Load]=" + Qty_result_Load.ToString("#") + ",[LabDensity_Load]= " + Value_Density_load + ",[ValueDensity_Load]=" + Value_Dif_Load.ToString("F") + ",[DeffDensity_Load]=" + Den_result_Load.ToString("F") + ",[Sealaudit_Only]=" + Sealaudit_Only + ",[Seal_Point1]=" + Seal_Point1 + ",[Seal_Point2]= " + Seal_Point2 + ",[Seal_Point3]=" + Seal_Point3 + ",[Seal_Point4]=" + Seal_Point4 + ",[Seal_Point5]=" + Seal_Point5 + ",[Seal_Point6]=" + Seal_Point6 + ",[Seal_Point7]=" + Seal_Point7 + ",[Seal_Point8]=" + Seal_Point8 + ",[Seal_Point9]=" + Seal_Point9 + ",[Seal_Point10]=" + Seal_Point10 + ",[Seal_Point11]=" + Seal_Point11 + ",[Seal_Point12]=" + Seal_Point12 + ",[Seal_Point13]=" + Seal_Point13 + ",[Seal_Point14]=" + Seal_Point14 + ",[Seal_Point15]=" + Seal_Point15 + ",[BranchID]=" + ID_Branch + ",[Degree_ID]=" + cb_degree.SelectedValue.ToString() + "  WHERE [TicketCodeIn] = '" + TicketCodeIn + "'";

                Msg = "Update Data in DensityRecord!"; 
            }

            con.Open();
            SqlCommand CM2 = new SqlCommand(sql, con);
            SqlDataReader DR2 = CM2.ExecuteReader();
            con.Close();


            Log_NewValue = "DateRecordDen =" + date +
            "," + "Qty_ProSTD = " + Qty_Product +
            "," + "LabDensity = " + Value_Density.ToString() +
            "," + "ValueDensity = " + Value_Dif_LO.ToString() +
            "," + "DeffDensity = " + Den_result_LO.ToString() +
            "," + "Qty_Product_Load = " + Den_result_Load.ToString() +
            "," + "Sealaudit_Only = " + Sealaudit_Only +         
            "," + "BranchID =" + ID_Branch.ToString() +
            "," + "Degree_ID =" + cb_degree.SelectedValue.ToString();            

            Log_OldValue = "-";
            Class_Log CL = new Class_Log();
            CL.tbname = Msg;
            CL.oldvalue = Log_OldValue;
            CL.newvalue = Log_NewValue;
            CL.Save_log();

        }

        private void chk_all5point_CheckedChanged(object sender, EventArgs e)
        {
            Check_5Point();

            chk_all7point.Checked = false;
            chk_all8point.Checked = false;
            chk_all11point.Checked = false;
            chk_all13point.Checked = false;
            chk_all15point.Checked = false;
        }

        private void Check_5Point()
        {
            if (chk_all5point.Checked == true)
            {
                if (chk_SealAll.Checked == true)
                {
                    chk_s1point.Checked = false;
                    chk_s2point.Checked = false;
                    chk_s3point.Checked = false;
                    chk_s4point.Checked = false;
                    chk_s5point.Checked = false;

                    chk_s1point.BackColor = Color.OliveDrab;
                    chk_s2point.BackColor = Color.OliveDrab;
                    chk_s3point.BackColor = Color.OliveDrab;
                    chk_s4point.BackColor = Color.OliveDrab;
                    chk_s5point.BackColor = Color.OliveDrab;

                    chk_a1point.Checked = true;
                    chk_a2point.Checked = true;
                    chk_a3point.Checked = true;
                    chk_a4point.Checked = true;
                    chk_a5point.Checked = true;

                    chk_a1point.BackColor = Color.White;
                    chk_a2point.BackColor = Color.White;
                    chk_a3point.BackColor = Color.White;
                    chk_a4point.BackColor = Color.White;
                    chk_a5point.BackColor = Color.White;
                }

                else
                {
                    chk_s1point.Checked = true;
                    chk_s2point.Checked = true;
                    chk_s3point.Checked = true;
                    chk_s4point.Checked = true;
                    chk_s5point.Checked = true;

                    chk_s1point.BackColor = Color.White;
                    chk_s2point.BackColor = Color.White;
                    chk_s3point.BackColor = Color.White;
                    chk_s4point.BackColor = Color.White;
                    chk_s5point.BackColor = Color.White;

                    chk_a1point.Checked = true;
                    chk_a2point.Checked = true;
                    chk_a3point.Checked = true;
                    chk_a4point.Checked = true;
                    chk_a5point.Checked = true;

                    chk_a1point.BackColor = Color.White;
                    chk_a2point.BackColor = Color.White;
                    chk_a3point.BackColor = Color.White;
                    chk_a4point.BackColor = Color.White;
                    chk_a5point.BackColor = Color.White;
                }

            }

            if (chk_all5point.Checked == false)
            {
                chk_s1point.Checked = false;
                chk_s2point.Checked = false;
                chk_s3point.Checked = false;
                chk_s4point.Checked = false;
                chk_s5point.Checked = false;

                //OliveDrab

                chk_s1point.BackColor = Color.OliveDrab;
                chk_s2point.BackColor = Color.OliveDrab;
                chk_s3point.BackColor = Color.OliveDrab;
                chk_s4point.BackColor = Color.OliveDrab;
                chk_s5point.BackColor = Color.OliveDrab;

                chk_a1point.Checked = false;
                chk_a2point.Checked = false;
                chk_a3point.Checked = false;
                chk_a4point.Checked = false;
                chk_a5point.Checked = false;


                //RoyalBlue

                chk_a1point.BackColor = Color.RoyalBlue;
                chk_a2point.BackColor = Color.RoyalBlue;
                chk_a3point.BackColor = Color.RoyalBlue;
                chk_a4point.BackColor = Color.RoyalBlue;
                chk_a5point.BackColor = Color.RoyalBlue;

            }

        }

        private void Check_7Point()
        {
            if (chk_all7point.Checked == true)
            {
                if (chk_SealAll.Checked == false)
                {
                    chk_s1point.Checked = true;
                    chk_s2point.Checked = true;
                    chk_s3point.Checked = true;
                    chk_s4point.Checked = true;
                    chk_s5point.Checked = true;
                    chk_s6point.Checked = true;
                    chk_s7point.Checked = true;

                    chk_s1point.BackColor = Color.White;
                    chk_s2point.BackColor = Color.White;
                    chk_s3point.BackColor = Color.White;
                    chk_s4point.BackColor = Color.White;
                    chk_s5point.BackColor = Color.White;
                    chk_s6point.BackColor = Color.White;
                    chk_s7point.BackColor = Color.White;

                }

                chk_a1point.Checked = true;
                chk_a2point.Checked = true;
                chk_a3point.Checked = true;
                chk_a4point.Checked = true;
                chk_a5point.Checked = true;
                chk_a6point.Checked = true;
                chk_a7point.Checked = true;

                chk_a1point.BackColor = Color.White;
                chk_a2point.BackColor = Color.White;
                chk_a3point.BackColor = Color.White;
                chk_a4point.BackColor = Color.White;
                chk_a5point.BackColor = Color.White;
                chk_a6point.BackColor = Color.White;
                chk_a7point.BackColor = Color.White;
            }

            if (chk_all7point.Checked == false)
            {
                chk_s1point.Checked = false;
                chk_s2point.Checked = false;
                chk_s3point.Checked = false;
                chk_s4point.Checked = false;
                chk_s5point.Checked = false;
                chk_s6point.Checked = false;
                chk_s7point.Checked = false;

                chk_a1point.Checked = false;
                chk_a2point.Checked = false;
                chk_a3point.Checked = false;
                chk_a4point.Checked = false;
                chk_a5point.Checked = false;
                chk_a6point.Checked = false;
                chk_a7point.Checked = false;


                chk_s1point.BackColor = Color.OliveDrab;
                chk_s2point.BackColor = Color.OliveDrab;
                chk_s3point.BackColor = Color.OliveDrab;
                chk_s4point.BackColor = Color.OliveDrab;
                chk_s5point.BackColor = Color.OliveDrab;
                chk_s6point.BackColor = Color.OliveDrab;
                chk_s7point.BackColor = Color.OliveDrab;

                chk_a1point.BackColor = Color.RoyalBlue;
                chk_a2point.BackColor = Color.RoyalBlue;
                chk_a3point.BackColor = Color.RoyalBlue;
                chk_a4point.BackColor = Color.RoyalBlue;
                chk_a5point.BackColor = Color.RoyalBlue;
                chk_a6point.BackColor = Color.RoyalBlue;
                chk_a7point.BackColor = Color.RoyalBlue;
            }

        }

        private void Check_8Point()
        {
            if (chk_all8point.Checked == true)
            {
                if (chk_SealAll.Checked == false)
                {
                    chk_s1point.Checked = true;
                    chk_s2point.Checked = true;
                    chk_s3point.Checked = true;
                    chk_s4point.Checked = true;
                    chk_s5point.Checked = true;
                    chk_s6point.Checked = true;
                    chk_s7point.Checked = true;
                    chk_s8point.Checked = true;

                    chk_s1point.BackColor = Color.White;
                    chk_s2point.BackColor = Color.White;
                    chk_s3point.BackColor = Color.White;
                    chk_s4point.BackColor = Color.White;
                    chk_s5point.BackColor = Color.White;
                    chk_s6point.BackColor = Color.White;
                    chk_s7point.BackColor = Color.White;
                    chk_s8point.BackColor = Color.White;

                }

                chk_a1point.Checked = true;
                chk_a2point.Checked = true;
                chk_a3point.Checked = true;
                chk_a4point.Checked = true;
                chk_a5point.Checked = true;
                chk_a6point.Checked = true;
                chk_a7point.Checked = true;
                chk_a8point.Checked = true;

                chk_a1point.BackColor = Color.White;
                chk_a2point.BackColor = Color.White;
                chk_a3point.BackColor = Color.White;
                chk_a4point.BackColor = Color.White;
                chk_a5point.BackColor = Color.White;
                chk_a6point.BackColor = Color.White;
                chk_a7point.BackColor = Color.White;
                chk_a8point.BackColor = Color.White;
            }

            if (chk_all8point.Checked == false)
            {
                chk_s1point.Checked = false;
                chk_s2point.Checked = false;
                chk_s3point.Checked = false;
                chk_s4point.Checked = false;
                chk_s5point.Checked = false;
                chk_s6point.Checked = false;
                chk_s7point.Checked = false;
                chk_s8point.Checked = false;

                chk_a1point.Checked = false;
                chk_a2point.Checked = false;
                chk_a3point.Checked = false;
                chk_a4point.Checked = false;
                chk_a5point.Checked = false;
                chk_a6point.Checked = false;
                chk_a7point.Checked = false;
                chk_a8point.Checked = false;

                chk_s1point.BackColor = Color.OliveDrab;
                chk_s2point.BackColor = Color.OliveDrab;
                chk_s3point.BackColor = Color.OliveDrab;
                chk_s4point.BackColor = Color.OliveDrab;
                chk_s5point.BackColor = Color.OliveDrab;
                chk_s6point.BackColor = Color.OliveDrab;
                chk_s7point.BackColor = Color.OliveDrab;
                chk_s8point.BackColor = Color.OliveDrab;

                chk_a1point.BackColor = Color.RoyalBlue;
                chk_a2point.BackColor = Color.RoyalBlue;
                chk_a3point.BackColor = Color.RoyalBlue;
                chk_a4point.BackColor = Color.RoyalBlue;
                chk_a5point.BackColor = Color.RoyalBlue;
                chk_a6point.BackColor = Color.RoyalBlue;
                chk_a7point.BackColor = Color.RoyalBlue;
                chk_a8point.BackColor = Color.RoyalBlue;
            }

        }

        private void Check_11Point()
        {
            if (chk_all11point.Checked == true)
            {
                if (chk_SealAll.Checked == false)
                {
                    chk_s1point.Checked = true;
                    chk_s2point.Checked = true;
                    chk_s3point.Checked = true;
                    chk_s4point.Checked = true;
                    chk_s5point.Checked = true;
                    chk_s6point.Checked = true;
                    chk_s7point.Checked = true;
                    chk_s8point.Checked = true;
                    chk_s9point.Checked = true;
                    chk_s10point.Checked = true;
                    chk_s11point.Checked = true;

                    chk_s1point.BackColor = Color.White;
                    chk_s2point.BackColor = Color.White;
                    chk_s3point.BackColor = Color.White;
                    chk_s4point.BackColor = Color.White;
                    chk_s5point.BackColor = Color.White;
                    chk_s6point.BackColor = Color.White;
                    chk_s7point.BackColor = Color.White;
                    chk_s8point.BackColor = Color.White;
                    chk_s9point.BackColor = Color.White;
                    chk_s10point.BackColor = Color.White;
                    chk_s11point.BackColor = Color.White;

                }

                chk_a1point.Checked = true;
                chk_a2point.Checked = true;
                chk_a3point.Checked = true;
                chk_a4point.Checked = true;
                chk_a5point.Checked = true;
                chk_a6point.Checked = true;
                chk_a7point.Checked = true;
                chk_a8point.Checked = true;
                chk_a9point.Checked = true;
                chk_a10point.Checked = true;
                chk_a11point.Checked = true;

                chk_a1point.BackColor = Color.White;
                chk_a2point.BackColor = Color.White;
                chk_a3point.BackColor = Color.White;
                chk_a4point.BackColor = Color.White;
                chk_a5point.BackColor = Color.White;
                chk_a6point.BackColor = Color.White;
                chk_a7point.BackColor = Color.White;
                chk_a8point.BackColor = Color.White;
                chk_a9point.BackColor = Color.White;
                chk_a10point.BackColor = Color.White;
                chk_a11point.BackColor = Color.White;
            }

            if (chk_all11point.Checked == false)
            {
                chk_s1point.Checked = false;
                chk_s2point.Checked = false;
                chk_s3point.Checked = false;
                chk_s4point.Checked = false;
                chk_s5point.Checked = false;
                chk_s6point.Checked = false;
                chk_s7point.Checked = false;
                chk_s8point.Checked = false;
                chk_s9point.Checked = false;
                chk_s10point.Checked = false;
                chk_s11point.Checked = false;

                chk_a1point.Checked = false;
                chk_a2point.Checked = false;
                chk_a3point.Checked = false;
                chk_a4point.Checked = false;
                chk_a5point.Checked = false;
                chk_a6point.Checked = false;
                chk_a7point.Checked = false;
                chk_a8point.Checked = false;
                chk_a9point.Checked = false;
                chk_a10point.Checked = false;
                chk_a11point.Checked = false;


                chk_s1point.BackColor = Color.OliveDrab;
                chk_s2point.BackColor = Color.OliveDrab;
                chk_s3point.BackColor = Color.OliveDrab;
                chk_s4point.BackColor = Color.OliveDrab;
                chk_s5point.BackColor = Color.OliveDrab;
                chk_s6point.BackColor = Color.OliveDrab;
                chk_s7point.BackColor = Color.OliveDrab;
                chk_s8point.BackColor = Color.OliveDrab;
                chk_s9point.BackColor = Color.OliveDrab;
                chk_s10point.BackColor = Color.OliveDrab;
                chk_s11point.BackColor = Color.OliveDrab;

                chk_a1point.BackColor = Color.RoyalBlue;
                chk_a2point.BackColor = Color.RoyalBlue;
                chk_a3point.BackColor = Color.RoyalBlue;
                chk_a4point.BackColor = Color.RoyalBlue;
                chk_a5point.BackColor = Color.RoyalBlue;
                chk_a6point.BackColor = Color.RoyalBlue;
                chk_a7point.BackColor = Color.RoyalBlue;
                chk_a8point.BackColor = Color.RoyalBlue;
                chk_a9point.BackColor = Color.RoyalBlue;
                chk_a10point.BackColor = Color.RoyalBlue;
                chk_a11point.BackColor = Color.RoyalBlue;
            }

        }

        private void Check_13Point()
        {
            if (chk_all13point.Checked == true)
            {
                if (chk_SealAll.Checked == false)
                {
                    chk_s1point.Checked = true;
                    chk_s2point.Checked = true;
                    chk_s3point.Checked = true;
                    chk_s4point.Checked = true;
                    chk_s5point.Checked = true;
                    chk_s6point.Checked = true;
                    chk_s7point.Checked = true;
                    chk_s8point.Checked = true;
                    chk_s9point.Checked = true;
                    chk_s10point.Checked = true;
                    chk_s11point.Checked = true;
                    chk_s12point.Checked = true;
                    chk_s13point.Checked = true;

                    chk_s1point.BackColor = Color.White;
                    chk_s2point.BackColor = Color.White;
                    chk_s3point.BackColor = Color.White;
                    chk_s4point.BackColor = Color.White;
                    chk_s5point.BackColor = Color.White;
                    chk_s6point.BackColor = Color.White;
                    chk_s7point.BackColor = Color.White;
                    chk_s8point.BackColor = Color.White;
                    chk_s9point.BackColor = Color.White;
                    chk_s10point.BackColor = Color.White;
                    chk_s11point.BackColor = Color.White;
                    chk_s12point.BackColor = Color.White;
                    chk_s13point.BackColor = Color.White;

                }

                chk_a1point.Checked = true;
                chk_a2point.Checked = true;
                chk_a3point.Checked = true;
                chk_a4point.Checked = true;
                chk_a5point.Checked = true;
                chk_a6point.Checked = true;
                chk_a7point.Checked = true;
                chk_a8point.Checked = true;
                chk_a9point.Checked = true;
                chk_a10point.Checked = true;
                chk_a11point.Checked = true;
                chk_a12point.Checked = true;
                chk_a13point.Checked = true;

                chk_a1point.BackColor = Color.White;
                chk_a2point.BackColor = Color.White;
                chk_a3point.BackColor = Color.White;
                chk_a4point.BackColor = Color.White;
                chk_a5point.BackColor = Color.White;
                chk_a6point.BackColor = Color.White;
                chk_a7point.BackColor = Color.White;
                chk_a8point.BackColor = Color.White;
                chk_a9point.BackColor = Color.White;
                chk_a10point.BackColor = Color.White;
                chk_a11point.BackColor = Color.White;
                chk_a12point.BackColor = Color.White;
                chk_a13point.BackColor = Color.White;
            }

            if (chk_all13point.Checked == false)
            {
                chk_s1point.Checked = false;
                chk_s2point.Checked = false;
                chk_s3point.Checked = false;
                chk_s4point.Checked = false;
                chk_s5point.Checked = false;
                chk_s6point.Checked = false;
                chk_s7point.Checked = false;
                chk_s8point.Checked = false;
                chk_s9point.Checked = false;
                chk_s10point.Checked = false;
                chk_s11point.Checked = false;
                chk_s12point.Checked = false;
                chk_s13point.Checked = false;

                chk_a1point.Checked = false;
                chk_a2point.Checked = false;
                chk_a3point.Checked = false;
                chk_a4point.Checked = false;
                chk_a5point.Checked = false;
                chk_a6point.Checked = false;
                chk_a7point.Checked = false;
                chk_a8point.Checked = false;
                chk_a9point.Checked = false;
                chk_a10point.Checked = false;
                chk_a11point.Checked = false;
                chk_a12point.Checked = false;
                chk_a13point.Checked = false;

                chk_s1point.BackColor = Color.OliveDrab;
                chk_s2point.BackColor = Color.OliveDrab;
                chk_s3point.BackColor = Color.OliveDrab;
                chk_s4point.BackColor = Color.OliveDrab;
                chk_s5point.BackColor = Color.OliveDrab;
                chk_s6point.BackColor = Color.OliveDrab;
                chk_s7point.BackColor = Color.OliveDrab;
                chk_s8point.BackColor = Color.OliveDrab;
                chk_s9point.BackColor = Color.OliveDrab;
                chk_s10point.BackColor = Color.OliveDrab;
                chk_s11point.BackColor = Color.OliveDrab;
                chk_s12point.BackColor = Color.OliveDrab;
                chk_s13point.BackColor = Color.OliveDrab;

                chk_a1point.BackColor = Color.RoyalBlue;
                chk_a2point.BackColor = Color.RoyalBlue;
                chk_a3point.BackColor = Color.RoyalBlue;
                chk_a4point.BackColor = Color.RoyalBlue;
                chk_a5point.BackColor = Color.RoyalBlue;
                chk_a6point.BackColor = Color.RoyalBlue;
                chk_a7point.BackColor = Color.RoyalBlue;
                chk_a8point.BackColor = Color.RoyalBlue;
                chk_a9point.BackColor = Color.RoyalBlue;
                chk_a10point.BackColor = Color.RoyalBlue;
                chk_a11point.BackColor = Color.RoyalBlue;
                chk_a12point.BackColor = Color.RoyalBlue;
                chk_a13point.BackColor = Color.RoyalBlue;
            }
        }

        private void Check_15Point()
        {
            if (chk_all15point.Checked == true)
            {
                if (chk_SealAll.Checked == false)
                {
                    chk_s1point.Checked = true;
                    chk_s2point.Checked = true;
                    chk_s3point.Checked = true;
                    chk_s4point.Checked = true;
                    chk_s5point.Checked = true;
                    chk_s6point.Checked = true;
                    chk_s7point.Checked = true;
                    chk_s8point.Checked = true;
                    chk_s9point.Checked = true;
                    chk_s10point.Checked = true;
                    chk_s11point.Checked = true;
                    chk_s12point.Checked = true;
                    chk_s13point.Checked = true;
                    chk_s14point.Checked = true;
                    chk_s15point.Checked = true;

                    chk_s1point.BackColor = Color.White;
                    chk_s2point.BackColor = Color.White;
                    chk_s3point.BackColor = Color.White;
                    chk_s4point.BackColor = Color.White;
                    chk_s5point.BackColor = Color.White;
                    chk_s6point.BackColor = Color.White;
                    chk_s7point.BackColor = Color.White;
                    chk_s8point.BackColor = Color.White;
                    chk_s9point.BackColor = Color.White;
                    chk_s10point.BackColor = Color.White;
                    chk_s11point.BackColor = Color.White;
                    chk_s12point.BackColor = Color.White;
                    chk_s13point.BackColor = Color.White;
                    chk_s14point.BackColor = Color.White;
                    chk_s15point.BackColor = Color.White;

                }

                chk_a1point.Checked = true;
                chk_a2point.Checked = true;
                chk_a3point.Checked = true;
                chk_a4point.Checked = true;
                chk_a5point.Checked = true;
                chk_a6point.Checked = true;
                chk_a7point.Checked = true;
                chk_a8point.Checked = true;
                chk_a9point.Checked = true;
                chk_a10point.Checked = true;
                chk_a11point.Checked = true;
                chk_a12point.Checked = true;
                chk_a13point.Checked = true;
                chk_a14point.Checked = true;
                chk_a15point.Checked = true;

                chk_a1point.BackColor = Color.White;
                chk_a2point.BackColor = Color.White;
                chk_a3point.BackColor = Color.White;
                chk_a4point.BackColor = Color.White;
                chk_a5point.BackColor = Color.White;
                chk_a6point.BackColor = Color.White;
                chk_a7point.BackColor = Color.White;
                chk_a8point.BackColor = Color.White;
                chk_a9point.BackColor = Color.White;
                chk_a10point.BackColor = Color.White;
                chk_a11point.BackColor = Color.White;
                chk_a12point.BackColor = Color.White;
                chk_a13point.BackColor = Color.White;
                chk_a14point.BackColor = Color.White;
                chk_a15point.BackColor = Color.White;
            }

            if (chk_all15point.Checked == false)
            {
                chk_s1point.Checked = false;
                chk_s2point.Checked = false;
                chk_s3point.Checked = false;
                chk_s4point.Checked = false;
                chk_s5point.Checked = false;
                chk_s6point.Checked = false;
                chk_s7point.Checked = false;
                chk_s8point.Checked = false;
                chk_s9point.Checked = false;
                chk_s10point.Checked = false;
                chk_s11point.Checked = false;
                chk_s12point.Checked = false;
                chk_s13point.Checked = false;
                chk_s14point.Checked = false;
                chk_s15point.Checked = false;

                chk_a1point.Checked = false;
                chk_a2point.Checked = false;
                chk_a3point.Checked = false;
                chk_a4point.Checked = false;
                chk_a5point.Checked = false;
                chk_a6point.Checked = false;
                chk_a7point.Checked = false;
                chk_a8point.Checked = false;
                chk_a9point.Checked = false;
                chk_a10point.Checked = false;
                chk_a11point.Checked = false;
                chk_a12point.Checked = false;
                chk_a13point.Checked = false;
                chk_a14point.Checked = false;
                chk_a15point.Checked = false;

                chk_s1point.BackColor = Color.OliveDrab;
                chk_s2point.BackColor = Color.OliveDrab;
                chk_s3point.BackColor = Color.OliveDrab;
                chk_s4point.BackColor = Color.OliveDrab;
                chk_s5point.BackColor = Color.OliveDrab;
                chk_s6point.BackColor = Color.OliveDrab;
                chk_s7point.BackColor = Color.OliveDrab;
                chk_s8point.BackColor = Color.OliveDrab;
                chk_s9point.BackColor = Color.OliveDrab;
                chk_s10point.BackColor = Color.OliveDrab;
                chk_s11point.BackColor = Color.OliveDrab;
                chk_s12point.BackColor = Color.OliveDrab;
                chk_s13point.BackColor = Color.OliveDrab;
                chk_s14point.BackColor = Color.OliveDrab;
                chk_s15point.BackColor = Color.OliveDrab;

                chk_a1point.BackColor = Color.RoyalBlue;
                chk_a2point.BackColor = Color.RoyalBlue;
                chk_a3point.BackColor = Color.RoyalBlue;
                chk_a4point.BackColor = Color.RoyalBlue;
                chk_a5point.BackColor = Color.RoyalBlue;
                chk_a6point.BackColor = Color.RoyalBlue;
                chk_a7point.BackColor = Color.RoyalBlue;
                chk_a8point.BackColor = Color.RoyalBlue;
                chk_a9point.BackColor = Color.RoyalBlue;
                chk_a10point.BackColor = Color.RoyalBlue;
                chk_a11point.BackColor = Color.RoyalBlue;
                chk_a12point.BackColor = Color.RoyalBlue;
                chk_a13point.BackColor = Color.RoyalBlue;
                chk_a14point.BackColor = Color.RoyalBlue;
                chk_a15point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_all7point_CheckedChanged(object sender, EventArgs e)
        {
            Check_7Point();

            chk_all5point.Checked = false;
            chk_all8point.Checked = false;
            chk_all11point.Checked = false;
            chk_all13point.Checked = false;
            chk_all15point.Checked = false;
        }

        private void chk_all8point_CheckedChanged(object sender, EventArgs e)
        {
            Check_8Point();

            chk_all5point.Checked = false;
            chk_all7point.Checked = false;
            chk_all11point.Checked = false;
            chk_all13point.Checked = false;
            chk_all15point.Checked = false;
        }

        private void chk_all11point_CheckedChanged(object sender, EventArgs e)
        {
            Check_11Point();

            chk_all7point.Checked = false;
            chk_all8point.Checked = false;
            chk_all5point.Checked = false;
            chk_all13point.Checked = false;
            chk_all15point.Checked = false;
        }

        private void chk_all13point_CheckedChanged(object sender, EventArgs e)
        {
            Check_13Point();

            chk_all7point.Checked = false;
            chk_all8point.Checked = false;
            chk_all11point.Checked = false;
            chk_all5point.Checked = false;
            chk_all15point.Checked = false;
        }

        private void chk_all15point_CheckedChanged(object sender, EventArgs e)
        {
            Check_15Point();

            chk_all7point.Checked = false;
            chk_all8point.Checked = false;
            chk_all11point.Checked = false;
            chk_all13point.Checked = false;
            chk_all5point.Checked = false;
        }

        private void chk_s1point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_s1point.Checked == true)
            {
                chk_s1point.BackColor = Color.White; chk_a1point.Checked = true; chk_a1point.BackColor = Color.White;
            }

            if (chk_s1point.Checked == false)
            {

                chk_a1point.Checked = false; chk_s1point.BackColor = Color.OliveDrab; chk_a1point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_s2point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_s2point.Checked == true)
            {
                chk_a2point.Checked = true; chk_s2point.BackColor = Color.White; chk_a2point.BackColor = Color.White;
            }

            if (chk_s2point.Checked == false)
            {
                chk_a2point.Checked = false; chk_s2point.BackColor = Color.OliveDrab; chk_a2point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_s3point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_s3point.Checked == true)
            {
                chk_a3point.Checked = true; chk_s3point.BackColor = Color.White; chk_a3point.BackColor = Color.White;
            }

            if (chk_s3point.Checked == false)
            {
                chk_a3point.Checked = false; chk_s3point.BackColor = Color.OliveDrab; chk_a3point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_s4point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_s4point.Checked == true)
            {
                chk_a4point.Checked = true; chk_s4point.BackColor = Color.White; chk_a4point.BackColor = Color.White;
            }

            if (chk_s4point.Checked == false)
            {
                chk_a4point.Checked = false; chk_s4point.BackColor = Color.OliveDrab; chk_a4point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_s5point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_s5point.Checked == true)
            {
                chk_a5point.Checked = true; chk_s5point.BackColor = Color.White; chk_a5point.BackColor = Color.White;
            }

            if (chk_s5point.Checked == false)
            {
                chk_a5point.Checked = false; chk_s5point.BackColor = Color.OliveDrab; chk_a5point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_s6point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_s6point.Checked == true)
            {
                chk_a6point.Checked = true; chk_s6point.BackColor = Color.White; chk_a6point.BackColor = Color.White;
            }

            if (chk_s6point.Checked == false)
            {
                chk_a6point.Checked = false; chk_s6point.BackColor = Color.OliveDrab; chk_a6point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_s7point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_s7point.Checked == true)
            {
                chk_a7point.Checked = true; chk_s7point.BackColor = Color.White; chk_a7point.BackColor = Color.White;
            }

            if (chk_s7point.Checked == false)
            {
                chk_a7point.Checked = false; chk_s7point.BackColor = Color.OliveDrab; chk_a7point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_s8point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_s8point.Checked == true)
            {
                chk_a8point.Checked = true; chk_s8point.BackColor = Color.White; chk_a8point.BackColor = Color.White;
            }

            if (chk_s8point.Checked == false)
            {
                chk_a8point.Checked = false; chk_s8point.BackColor = Color.OliveDrab; chk_a8point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_s9point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_s9point.Checked == true)
            {
                chk_a9point.Checked = true; chk_s9point.BackColor = Color.White; chk_a9point.BackColor = Color.White;
            }

            if (chk_s9point.Checked == false)
            {
                chk_a9point.Checked = false; chk_s9point.BackColor = Color.OliveDrab; chk_a9point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_s10point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_s10point.Checked == true)
            {
                chk_a10point.Checked = true; chk_s10point.BackColor = Color.White; chk_a10point.BackColor = Color.White;
            }

            if (chk_s10point.Checked == false)
            {
                chk_a10point.Checked = false; chk_s10point.BackColor = Color.OliveDrab; chk_a10point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_s11point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_s11point.Checked == true)
            {
                chk_a11point.Checked = true; chk_s11point.BackColor = Color.White; chk_a11point.BackColor = Color.White;
            }

            if (chk_s11point.Checked == false)
            {
                chk_a11point.Checked = false; chk_s11point.BackColor = Color.OliveDrab; chk_a11point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_s12point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_s12point.Checked == true)
            {            
                    chk_a12point.Checked = true; chk_s12point.BackColor = Color.White; chk_a12point.BackColor = Color.White;             
            }

            if (chk_s12point.Checked == false)
            {
                chk_a12point.Checked = false; chk_s12point.BackColor = Color.OliveDrab; chk_a12point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_s13point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_s13point.Checked == true)
            {
                chk_a13point.Checked = true; chk_s13point.BackColor = Color.White; chk_a13point.BackColor = Color.White;
            }

            if (chk_s13point.Checked == false)
            {
                chk_a13point.Checked = false; chk_s13point.BackColor = Color.OliveDrab; chk_a13point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_s14point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_s14point.Checked == true)
            {
                chk_a14point.Checked = true; chk_s14point.BackColor = Color.White; chk_a14point.BackColor = Color.White;
            }

            if (chk_s14point.Checked == false)
            {
                chk_a14point.Checked = false; chk_s14point.BackColor = Color.OliveDrab; chk_a14point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_s15point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_s15point.Checked == true)
            {
                chk_a15point.Checked = true; chk_s15point.BackColor = Color.White; chk_a15point.BackColor = Color.White;
            }

            if (chk_s15point.Checked == false)
            {
                chk_a15point.Checked = false; chk_s15point.BackColor = Color.OliveDrab; chk_a15point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_a1point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_a1point.Checked == true)
            {
                if (chk_SealAll.Checked == false)
                {
                    chk_s1point.Checked = true; chk_s1point.BackColor = Color.White; chk_a1point.BackColor = Color.White;
                }

                else
                {
                    chk_a1point.BackColor = Color.White;
                }
            }

            if (chk_a1point.Checked == false )
            {
                chk_s1point.Checked = false; chk_s1point.BackColor = Color.OliveDrab; chk_a1point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_a2point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_a2point.Checked == true)
            {
                if (chk_SealAll.Checked == false)
                {
                    chk_s2point.Checked = true; chk_s2point.BackColor = Color.White; chk_a2point.BackColor = Color.White;
                }
                else
                {
                    chk_a2point.BackColor = Color.White;
                }
            }

            if (chk_a2point.Checked == false)
            {
                chk_s2point.Checked = false; chk_s2point.BackColor = Color.OliveDrab; chk_a2point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_a3point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_a3point.Checked == true)
            {
                if (chk_SealAll.Checked == false)
                {
                    chk_s3point.Checked = true; chk_s3point.BackColor = Color.White; chk_a3point.BackColor = Color.White;
                }
                else
                {
                    chk_a3point.BackColor = Color.White;
                }
            }

            if (chk_a3point.Checked == false )
            {
                chk_s3point.Checked = false; chk_s3point.BackColor = Color.OliveDrab; chk_a3point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_a4point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_a4point.Checked == true)
            {
                if (chk_SealAll.Checked == false)
                {
                    chk_s4point.Checked = true; chk_s4point.BackColor = Color.White; chk_a4point.BackColor = Color.White;
                }
                else
                {
                    chk_a4point.BackColor = Color.White;
                }
            }

            if (chk_a4point.Checked == false )
            {
                chk_s4point.Checked = false; chk_s4point.BackColor = Color.OliveDrab; chk_a4point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_a5point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_a5point.Checked == true)
            {
                if (chk_SealAll.Checked == false)
                {
                    chk_s5point.Checked = true; chk_s5point.BackColor = Color.White; chk_a5point.BackColor = Color.White;
                }
                else
                {
                    chk_a5point.BackColor = Color.White;
                }
            }

            if (chk_a5point.Checked == false )
            {
                chk_s5point.Checked = false; chk_s5point.BackColor = Color.OliveDrab; chk_a5point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_a6point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_a6point.Checked == true)
            {
                if (chk_SealAll.Checked == false)
                {
                    chk_s6point.Checked = true; chk_s6point.BackColor = Color.White; chk_a6point.BackColor = Color.White;
                }
                else
                {
                    chk_a6point.BackColor = Color.White;
                }
            }

            if (chk_a6point.Checked == false)
            {
                chk_s6point.Checked = false; chk_s6point.BackColor = Color.OliveDrab; chk_a6point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_a7point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_a7point.Checked == true)
            {
                if (chk_SealAll.Checked == false)
                {
                    chk_s7point.Checked = true; chk_s7point.BackColor = Color.White; chk_a7point.BackColor = Color.White;
                }
                else
                {
                    chk_a7point.BackColor = Color.White;
                }
            }

            if (chk_a7point.Checked == false )
            {
                chk_s7point.Checked = false; chk_s7point.BackColor = Color.OliveDrab; chk_a7point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_a8point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_a8point.Checked == true)
            {
                if (chk_SealAll.Checked == false)
                {
                    chk_s8point.Checked = true; chk_s8point.BackColor = Color.White; chk_a8point.BackColor = Color.White;
                }
                else
                {
                    chk_a8point.BackColor = Color.White;
                }
            }

            if (chk_a8point.Checked == false)
            {
                chk_s8point.Checked = false; chk_s8point.BackColor = Color.OliveDrab; chk_a8point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_a9point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_a9point.Checked == true)
            {
                if (chk_SealAll.Checked == false)
                {
                    chk_s9point.Checked = true; chk_s9point.BackColor = Color.White; chk_a9point.BackColor = Color.White;
                }
                else
                {
                    chk_a9point.BackColor = Color.White;
                }
            }

            if (chk_a9point.Checked == false )
            {
                chk_s9point.Checked = false; chk_s9point.BackColor = Color.OliveDrab; chk_a9point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_a10point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_a10point.Checked == true)
            {
                if (chk_SealAll.Checked == false)
                {
                    chk_s10point.Checked = true; chk_s10point.BackColor = Color.White; chk_a10point.BackColor = Color.White;
                }
                else
                {
                    chk_a10point.BackColor = Color.White;
                }
            }

            if (chk_a10point.Checked == false )
            {
                chk_s10point.Checked = false; chk_s10point.BackColor = Color.OliveDrab; chk_a10point.BackColor = Color.RoyalBlue;
            }
        }

        private void chk_a11point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_a11point.Checked == true)
            {
                if (chk_SealAll.Checked == false)
                {
                    chk_s11point.Checked = true; chk_s11point.BackColor = Color.White; chk_a11point.BackColor = Color.White;
                }
                else
                {
                    chk_a11point.BackColor = Color.White;
                }
            }

            if (chk_a11point.Checked == false )
            {
                chk_s11point.Checked = false; chk_s11point.BackColor = Color.OliveDrab; chk_a11point.BackColor = Color.RoyalBlue;
            }
        }

       

        private void chk_a12point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_a12point.Checked == true)
            {
                if (chk_SealAll.Checked == false)
                {
                    chk_s12point.Checked = true; chk_s12point.BackColor = Color.White; chk_a12point.BackColor = Color.White;
                }
                else
                {
                    chk_a12point.BackColor = Color.White;
                }
            }

            if (chk_a12point.Checked == false)
            {
                chk_s12point.Checked = false; chk_s12point.BackColor = Color.OliveDrab; chk_a12point.BackColor = Color.RoyalBlue;
            }
        }


        private void chk_a13point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_a13point.Checked == true)
            {
                if (chk_SealAll.Checked == false)
                {
                    chk_s13point.Checked = true; chk_s13point.BackColor = Color.White; chk_a13point.BackColor = Color.White;
                }
                else
                {
                    chk_a13point.BackColor = Color.White;
                }
            }

            if (chk_a13point.Checked == false)
            {
                chk_s13point.Checked = false; chk_s13point.BackColor = Color.OliveDrab; chk_a13point.BackColor = Color.RoyalBlue;
            }
        }


        private void chk_a14point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_a14point.Checked == true)
            {
                if (chk_SealAll.Checked == false)
                {
                    chk_s14point.Checked = true; chk_s14point.BackColor = Color.White; chk_a14point.BackColor = Color.White;
                }
                else
                {
                    chk_a14point.BackColor = Color.White;
                }
            }

            if (chk_a14point.Checked == false )
            {
                chk_s14point.Checked = false; chk_s14point.BackColor = Color.OliveDrab; chk_a14point.BackColor = Color.RoyalBlue;
            }
        }


        private void chk_a15point_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_a15point.Checked == true)
            {
                if (chk_SealAll.Checked == false)
                {
                    chk_s15point.Checked = true; chk_s15point.BackColor = Color.White; chk_a15point.BackColor = Color.White;
                }
                else
                {
                    chk_a15point.BackColor = Color.White;
                }
            }

            if (chk_a15point.Checked == false)
            {
                chk_s15point.Checked = false; chk_s15point.BackColor = Color.OliveDrab; chk_a15point.BackColor = Color.RoyalBlue;
            }
        }

        private void txt_Den_Load_TextChanged(object sender, EventArgs e)
        {
            try

            {

                Value_Density_load = Convert.ToDouble(txt_Den_Load.Text);
                //Qty_result_Load = 0;

                Qty_result_Load = Convert.ToDouble(Netweight / Value_Density_load);  //หาจำนวนลิตร
                txt_Qty_Load.Text = Qty_result_Load.ToString("##,###");


                Value_Dif_Load = Qty_result_Load - Qty_Product;//ส่วนต่าง  
                lbl__Valuedif_Load.Text = Value_Dif_Load.ToString("F");
                //lbl__Valuedif_Load.Text= Value_Dif_Load.ToString("F");

                //String.Format("{0:#.##;-#.##}", (Double.Parse("200.549") * -1));                   
                //Den_result_Load = 0;
                Den_result_Load = (Value_Dif_Load / Qty_Product) * 100;   //% ร้อยล่ะ
                lbl_avg_Load.Text = Den_result_Load.ToString("F");
                //lbl_avg_Load.Text = Den_result_Load.ToString("F");

            }
            catch {

                txt_Qty_Load.Clear();
                lbl__Valuedif_Load.Text = "";
                lbl_avg_Load.Text = "";


            }
        }


        private void txt_Qtyproduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_Qtyproduct.Text != "")
                {
                    Qty_Product = Convert.ToDouble(txt_Qtyproduct.Text);
                    Cal_Dendif_LO();

                    txt_Den_LO.BackColor = Color.LightGreen;
                    txt_ErrAcp_LO.BackColor = Color.LightGreen;
                }
            }
            catch { }
        }

        private void txt_Den_LO_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cal_Dendif_LO();
            }
            catch { }
        }

        private void txt_ErrAcp_LO_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cal_Dendif_LO();
                txt_ErrAcp_Load.Text = txt_ErrAcp_LO.Text;
            }
            catch { }
        }

        private void chk_SealAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_SealAll.Checked == true)
            {
                groupBox5.Enabled = false;

                chk_s1point.Checked = false;
                chk_s2point.Checked = false;
                chk_s3point.Checked = false;
                chk_s4point.Checked = false;
                chk_s5point.Checked = false;
                chk_s6point.Checked = false;
                chk_s7point.Checked = false;
                chk_s8point.Checked = false;
                chk_s9point.Checked = false;
                chk_s10point.Checked = false;
                chk_s11point.Checked = false;
                chk_s12point.Checked = false;
                chk_s13point.Checked = false;
                chk_s14point.Checked = false;
                chk_s15point.Checked = false;

                chk_s1point.BackColor = Color.OliveDrab;
                chk_s2point.BackColor = Color.OliveDrab;
                chk_s3point.BackColor = Color.OliveDrab;
                chk_s4point.BackColor = Color.OliveDrab;
                chk_s5point.BackColor = Color.OliveDrab;
                chk_s6point.BackColor = Color.OliveDrab;
                chk_s7point.BackColor = Color.OliveDrab;
                chk_s8point.BackColor = Color.OliveDrab;
                chk_s9point.BackColor = Color.OliveDrab;
                chk_s10point.BackColor = Color.OliveDrab;
                chk_s11point.BackColor = Color.OliveDrab;
                chk_s12point.BackColor = Color.OliveDrab;
                chk_s13point.BackColor = Color.OliveDrab;
                chk_s14point.BackColor = Color.OliveDrab;
                chk_s15point.BackColor = Color.OliveDrab;



            }
            else
            {
                groupBox5.Enabled = true;

            }

            if (chk_all5point.Checked == true)
            {
                Check_5Point();
            }
            if (chk_all7point.Checked == true)
            {
                Check_7Point();
            }
            if (chk_all8point.Checked == true)
            {
                Check_8Point();
            }
            if (chk_all11point.Checked == true)
            {
                Check_11Point();
            }
            if (chk_all13point.Checked == true)
            {
                Check_13Point();
            }
            if (chk_all15point.Checked == true)
            {
                Check_15Point();
            }
        }

               

    }
}
