namespace SaleOrder
{
    partial class FrmSaleOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpicker = new System.Windows.Forms.DateTimePicker();
            this.btnsale = new System.Windows.Forms.Button();
            this.txtnamessale = new System.Windows.Forms.TextBox();
            this.dtpeqa = new System.Windows.Forms.DateTimePicker();
            this.dtpstdqa = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtqano = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtidsale = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtremark = new System.Windows.Forms.TextBox();
            this.txtaddressordersale = new System.Windows.Forms.TextBox();
            this.btnordersale = new System.Windows.Forms.Button();
            this.txtnameordersale = new System.Windows.Forms.TextBox();
            this.txtidcomsale = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtnamepro = new System.Windows.Forms.TextBox();
            this.txtnamecar = new System.Windows.Forms.TextBox();
            this.btnpro = new System.Windows.Forms.Button();
            this.btncar = new System.Windows.Forms.Button();
            this.txtidpro = new System.Windows.Forms.TextBox();
            this.txtidcar = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cbtimerecivecus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtnamepur = new System.Windows.Forms.TextBox();
            this.txtaddresspur = new System.Windows.Forms.TextBox();
            this.txtidpur = new System.Windows.Forms.TextBox();
            this.btnpur = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.txtidorder = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtoldid = new System.Windows.Forms.TextBox();
            this.txtlastsave = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbounitorder = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpicker);
            this.groupBox1.Controls.Add(this.btnsale);
            this.groupBox1.Controls.Add(this.txtnamessale);
            this.groupBox1.Controls.Add(this.dtpeqa);
            this.groupBox1.Controls.Add(this.dtpstdqa);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtqano);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtidsale);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtremark);
            this.groupBox1.Controls.Add(this.txtaddressordersale);
            this.groupBox1.Controls.Add(this.btnordersale);
            this.groupBox1.Controls.Add(this.txtnameordersale);
            this.groupBox1.Controls.Add(this.txtidcomsale);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 313);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ข้อมูลผู้ขาย";
            // 
            // dtpicker
            // 
            this.dtpicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpicker.Location = new System.Drawing.Point(305, 14);
            this.dtpicker.Name = "dtpicker";
            this.dtpicker.Size = new System.Drawing.Size(117, 24);
            this.dtpicker.TabIndex = 22;
            this.dtpicker.ValueChanged += new System.EventHandler(this.dtpicker_ValueChanged);
            // 
            // btnsale
            // 
            this.btnsale.BackColor = System.Drawing.Color.Khaki;
            this.btnsale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsale.ForeColor = System.Drawing.Color.Red;
            this.btnsale.Location = new System.Drawing.Point(385, 135);
            this.btnsale.Name = "btnsale";
            this.btnsale.Size = new System.Drawing.Size(37, 24);
            this.btnsale.TabIndex = 20;
            this.btnsale.Text = ".....";
            this.btnsale.UseVisualStyleBackColor = false;
            this.btnsale.Click += new System.EventHandler(this.btnsale_Click);
            // 
            // txtnamessale
            // 
            this.txtnamessale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtnamessale.Location = new System.Drawing.Point(130, 135);
            this.txtnamessale.Name = "txtnamessale";
            this.txtnamessale.ReadOnly = true;
            this.txtnamessale.Size = new System.Drawing.Size(249, 24);
            this.txtnamessale.TabIndex = 21;
            // 
            // dtpeqa
            // 
            this.dtpeqa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpeqa.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpeqa.Location = new System.Drawing.Point(287, 210);
            this.dtpeqa.Name = "dtpeqa";
            this.dtpeqa.Size = new System.Drawing.Size(135, 24);
            this.dtpeqa.TabIndex = 15;
            // 
            // dtpstdqa
            // 
            this.dtpstdqa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpstdqa.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpstdqa.Location = new System.Drawing.Point(65, 210);
            this.dtpstdqa.Name = "dtpstdqa";
            this.dtpstdqa.Size = new System.Drawing.Size(132, 24);
            this.dtpstdqa.TabIndex = 14;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label19.Location = new System.Drawing.Point(234, 210);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 18);
            this.label19.TabIndex = 14;
            this.label19.Text = "ถึงวันที่";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label18.Location = new System.Drawing.Point(6, 210);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 18);
            this.label18.TabIndex = 13;
            this.label18.Text = "เริ่มวันที่";
            // 
            // txtqano
            // 
            this.txtqano.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtqano.Location = new System.Drawing.Point(178, 174);
            this.txtqano.Name = "txtqano";
            this.txtqano.Size = new System.Drawing.Size(244, 24);
            this.txtqano.TabIndex = 12;
            this.txtqano.Text = "-";
            this.txtqano.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtqano_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.Location = new System.Drawing.Point(6, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(166, 18);
            this.label10.TabIndex = 10;
            this.label10.Text = "หมายเหตุ (อ้างอิง QA เลขที่)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.Location = new System.Drawing.Point(6, 240);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 18);
            this.label12.TabIndex = 19;
            this.label12.Text = "หมายเหตุ";
            // 
            // txtidsale
            // 
            this.txtidsale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtidsale.Location = new System.Drawing.Point(60, 135);
            this.txtidsale.Name = "txtidsale";
            this.txtidsale.ReadOnly = true;
            this.txtidsale.Size = new System.Drawing.Size(64, 24);
            this.txtidsale.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(6, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "ชื่อผู้ขาย";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(6, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "ที่อยู่";
            // 
            // txtremark
            // 
            this.txtremark.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtremark.Location = new System.Drawing.Point(67, 240);
            this.txtremark.Multiline = true;
            this.txtremark.Name = "txtremark";
            this.txtremark.Size = new System.Drawing.Size(355, 62);
            this.txtremark.TabIndex = 18;
            this.txtremark.Text = "-";
            this.txtremark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtremark_KeyPress);
            // 
            // txtaddressordersale
            // 
            this.txtaddressordersale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtaddressordersale.Location = new System.Drawing.Point(45, 75);
            this.txtaddressordersale.Multiline = true;
            this.txtaddressordersale.Name = "txtaddressordersale";
            this.txtaddressordersale.ReadOnly = true;
            this.txtaddressordersale.Size = new System.Drawing.Size(377, 53);
            this.txtaddressordersale.TabIndex = 6;
            // 
            // btnordersale
            // 
            this.btnordersale.BackColor = System.Drawing.Color.Khaki;
            this.btnordersale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnordersale.ForeColor = System.Drawing.Color.Red;
            this.btnordersale.Location = new System.Drawing.Point(385, 44);
            this.btnordersale.Name = "btnordersale";
            this.btnordersale.Size = new System.Drawing.Size(37, 24);
            this.btnordersale.TabIndex = 2;
            this.btnordersale.Text = ".....";
            this.btnordersale.UseVisualStyleBackColor = false;
            this.btnordersale.Click += new System.EventHandler(this.btnordersale_Click);
            // 
            // txtnameordersale
            // 
            this.txtnameordersale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtnameordersale.Location = new System.Drawing.Point(130, 42);
            this.txtnameordersale.Name = "txtnameordersale";
            this.txtnameordersale.ReadOnly = true;
            this.txtnameordersale.Size = new System.Drawing.Size(249, 24);
            this.txtnameordersale.TabIndex = 5;
            // 
            // txtidcomsale
            // 
            this.txtidcomsale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtidcomsale.Location = new System.Drawing.Point(60, 42);
            this.txtidcomsale.Name = "txtidcomsale";
            this.txtidcomsale.ReadOnly = true;
            this.txtidcomsale.Size = new System.Drawing.Size(64, 24);
            this.txtidcomsale.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "บ.ผู้ขาย";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(238, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "ประจำวันที่";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(719, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "บันทึกสั่งจ่ายสินค้า";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.txtnamepro);
            this.groupBox4.Controls.Add(this.txtnamecar);
            this.groupBox4.Controls.Add(this.btnpro);
            this.groupBox4.Controls.Add(this.btncar);
            this.groupBox4.Controls.Add(this.txtidpro);
            this.groupBox4.Controls.Add(this.txtidcar);
            this.groupBox4.Location = new System.Drawing.Point(451, 197);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(436, 90);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ข้อมูลรถขนส่งและสินค้า";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label14.Location = new System.Drawing.Point(6, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 18);
            this.label14.TabIndex = 21;
            this.label14.Text = "ชนิดสินค้า";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label13.Location = new System.Drawing.Point(6, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(154, 18);
            this.label13.TabIndex = 32;
            this.label13.Text = "ชนิดรถ/ประเภท/จำนวนล้อ";
            // 
            // txtnamepro
            // 
            this.txtnamepro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtnamepro.Location = new System.Drawing.Point(114, 19);
            this.txtnamepro.Name = "txtnamepro";
            this.txtnamepro.ReadOnly = true;
            this.txtnamepro.Size = new System.Drawing.Size(265, 24);
            this.txtnamepro.TabIndex = 24;
            // 
            // txtnamecar
            // 
            this.txtnamecar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtnamecar.Location = new System.Drawing.Point(199, 48);
            this.txtnamecar.Name = "txtnamecar";
            this.txtnamecar.ReadOnly = true;
            this.txtnamecar.Size = new System.Drawing.Size(180, 24);
            this.txtnamecar.TabIndex = 35;
            // 
            // btnpro
            // 
            this.btnpro.BackColor = System.Drawing.Color.Khaki;
            this.btnpro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnpro.ForeColor = System.Drawing.Color.Red;
            this.btnpro.Location = new System.Drawing.Point(385, 19);
            this.btnpro.Name = "btnpro";
            this.btnpro.Size = new System.Drawing.Size(37, 24);
            this.btnpro.TabIndex = 23;
            this.btnpro.Text = ".....";
            this.btnpro.UseVisualStyleBackColor = false;
            this.btnpro.Click += new System.EventHandler(this.btnpro_Click);
            // 
            // btncar
            // 
            this.btncar.BackColor = System.Drawing.Color.Khaki;
            this.btncar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btncar.ForeColor = System.Drawing.Color.Red;
            this.btncar.Location = new System.Drawing.Point(385, 48);
            this.btncar.Name = "btncar";
            this.btncar.Size = new System.Drawing.Size(37, 24);
            this.btncar.TabIndex = 34;
            this.btncar.Text = ".....";
            this.btncar.UseVisualStyleBackColor = false;
            this.btncar.Click += new System.EventHandler(this.btncar_Click);
            // 
            // txtidpro
            // 
            this.txtidpro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtidpro.Location = new System.Drawing.Point(77, 19);
            this.txtidpro.Name = "txtidpro";
            this.txtidpro.ReadOnly = true;
            this.txtidpro.Size = new System.Drawing.Size(38, 24);
            this.txtidpro.TabIndex = 22;
            // 
            // txtidcar
            // 
            this.txtidcar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtidcar.Location = new System.Drawing.Point(162, 48);
            this.txtidcar.Name = "txtidcar";
            this.txtidcar.ReadOnly = true;
            this.txtidcar.Size = new System.Drawing.Size(38, 24);
            this.txtidcar.TabIndex = 33;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.cbtimerecivecus);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtnamepur);
            this.groupBox3.Controls.Add(this.txtaddresspur);
            this.groupBox3.Controls.Add(this.txtidpur);
            this.groupBox3.Controls.Add(this.btnpur);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(454, 37);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(436, 154);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ข้อมูลผู้รับซื้อ(ลูกค้า)";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label21.Location = new System.Drawing.Point(126, 18);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(165, 18);
            this.label21.TabIndex = 17;
            this.label21.Text = "ช่วงเวลาที่สามารถลงสินค้าได้";
            // 
            // cbtimerecivecus
            // 
            this.cbtimerecivecus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbtimerecivecus.FormattingEnabled = true;
            this.cbtimerecivecus.Location = new System.Drawing.Point(294, 15);
            this.cbtimerecivecus.Name = "cbtimerecivecus";
            this.cbtimerecivecus.Size = new System.Drawing.Size(128, 24);
            this.cbtimerecivecus.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(6, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 18);
            this.label7.TabIndex = 11;
            this.label7.Text = "ที่อยู่";
            // 
            // txtnamepur
            // 
            this.txtnamepur.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtnamepur.Location = new System.Drawing.Point(157, 47);
            this.txtnamepur.Name = "txtnamepur";
            this.txtnamepur.ReadOnly = true;
            this.txtnamepur.Size = new System.Drawing.Size(222, 24);
            this.txtnamepur.TabIndex = 13;
            // 
            // txtaddresspur
            // 
            this.txtaddresspur.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtaddresspur.Location = new System.Drawing.Point(45, 81);
            this.txtaddresspur.Multiline = true;
            this.txtaddresspur.Name = "txtaddresspur";
            this.txtaddresspur.ReadOnly = true;
            this.txtaddresspur.Size = new System.Drawing.Size(377, 63);
            this.txtaddresspur.TabIndex = 10;
            // 
            // txtidpur
            // 
            this.txtidpur.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtidpur.Location = new System.Drawing.Point(83, 47);
            this.txtidpur.Name = "txtidpur";
            this.txtidpur.ReadOnly = true;
            this.txtidpur.Size = new System.Drawing.Size(68, 24);
            this.txtidpur.TabIndex = 10;
            // 
            // btnpur
            // 
            this.btnpur.BackColor = System.Drawing.Color.Khaki;
            this.btnpur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnpur.ForeColor = System.Drawing.Color.Red;
            this.btnpur.Location = new System.Drawing.Point(385, 45);
            this.btnpur.Name = "btnpur";
            this.btnpur.Size = new System.Drawing.Size(37, 24);
            this.btnpur.TabIndex = 11;
            this.btnpur.Text = ".....";
            this.btnpur.UseVisualStyleBackColor = false;
            this.btnpur.Click += new System.EventHandler(this.btnpur_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(6, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "บ.ผู้รับซื้อ";
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnsave.Location = new System.Drawing.Point(679, 305);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(127, 42);
            this.btnsave.TabIndex = 29;
            this.btnsave.Text = "SAVE && Edit";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnexit
            // 
            this.btnexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnexit.ForeColor = System.Drawing.Color.Red;
            this.btnexit.Location = new System.Drawing.Point(812, 305);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(75, 42);
            this.btnexit.TabIndex = 28;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // txtidorder
            // 
            this.txtidorder.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtidorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtidorder.Location = new System.Drawing.Point(67, 14);
            this.txtidorder.Name = "txtidorder";
            this.txtidorder.ReadOnly = true;
            this.txtidorder.Size = new System.Drawing.Size(91, 24);
            this.txtidorder.TabIndex = 20;
            this.txtidorder.Text = "SYYMMDDXX";
            this.txtidorder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(13, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 18);
            this.label9.TabIndex = 14;
            this.label9.Text = "สั่งจ่ายที่:";
            // 
            // txtoldid
            // 
            this.txtoldid.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtoldid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtoldid.Location = new System.Drawing.Point(451, 293);
            this.txtoldid.Name = "txtoldid";
            this.txtoldid.ReadOnly = true;
            this.txtoldid.Size = new System.Drawing.Size(115, 24);
            this.txtoldid.TabIndex = 30;
            this.txtoldid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtoldid.Visible = false;
            // 
            // txtlastsave
            // 
            this.txtlastsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtlastsave.Location = new System.Drawing.Point(451, 323);
            this.txtlastsave.Name = "txtlastsave";
            this.txtlastsave.ReadOnly = true;
            this.txtlastsave.Size = new System.Drawing.Size(115, 24);
            this.txtlastsave.TabIndex = 32;
            this.txtlastsave.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtlastsave.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label20.Location = new System.Drawing.Point(268, 17);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(92, 18);
            this.label20.TabIndex = 31;
            this.label20.Text = "จำนวนการจ่าย:";
            // 
            // cbounitorder
            // 
            this.cbounitorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbounitorder.FormattingEnabled = true;
            this.cbounitorder.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbounitorder.Location = new System.Drawing.Point(359, 14);
            this.cbounitorder.Name = "cbounitorder";
            this.cbounitorder.Size = new System.Drawing.Size(32, 24);
            this.cbounitorder.TabIndex = 33;
            this.cbounitorder.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(391, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 18);
            this.label8.TabIndex = 34;
            this.label8.Text = "รายการ";
            // 
            // FrmSaleOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 359);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbounitorder);
            this.Controls.Add(this.txtlastsave);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtoldid);
            this.Controls.Add(this.txtidorder);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSaleOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SaleOrder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSaleOrder_FormClosed);
            this.Load += new System.EventHandler(this.FrmSaleOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpeqa;
        private System.Windows.Forms.DateTimePicker dtpstdqa;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtqano;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtaddressordersale;
        private System.Windows.Forms.Button btnordersale;
        private System.Windows.Forms.TextBox txtnameordersale;
        private System.Windows.Forms.TextBox txtidcomsale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtnamepro;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnpro;
        private System.Windows.Forms.TextBox txtidpro;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtnamepur;
        private System.Windows.Forms.TextBox txtaddresspur;
        private System.Windows.Forms.TextBox txtidpur;
        private System.Windows.Forms.Button btnpur;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtnamecar;
        private System.Windows.Forms.Button btncar;
        private System.Windows.Forms.TextBox txtidcar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.TextBox txtremark;
        private System.Windows.Forms.TextBox txtidorder;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtidsale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnsale;
        private System.Windows.Forms.TextBox txtnamessale;
        private System.Windows.Forms.DateTimePicker dtpicker;
        private System.Windows.Forms.TextBox txtoldid;
        private System.Windows.Forms.TextBox txtlastsave;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cbtimerecivecus;
        private System.Windows.Forms.ComboBox cbounitorder;
        private System.Windows.Forms.Label label8;
    }
}