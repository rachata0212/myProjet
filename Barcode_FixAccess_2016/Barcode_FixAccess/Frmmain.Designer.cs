namespace Barcode_FixAccess
{
    partial class Frmmain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbshowopsearch = new System.Windows.Forms.CheckBox();
            this.btnprintpreview = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.gbonline = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbdatabaseselect = new System.Windows.Forms.ComboBox();
            this.btnsetconnect = new System.Windows.Forms.Button();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbunitrows = new System.Windows.Forms.ComboBox();
            this.btnconnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdooffice = new System.Windows.Forms.RadioButton();
            this.rdoonline = new System.Windows.Forms.RadioButton();
            this.gboffline = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtimportfile = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.dtgselect = new System.Windows.Forms.DataGridView();
            this.dtgsearch = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblitemselect = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblitemssearch = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.cbbyfixcode = new System.Windows.Forms.CheckBox();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.cbbranchselect = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbdeptselect = new System.Windows.Forms.ComboBox();
            this.btnselect = new System.Windows.Forms.Button();
            this.cbboxdept = new System.Windows.Forms.CheckBox();
            this.btndeselect = new System.Windows.Forms.Button();
            this.cbboxkbranch = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.gbonline.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gboffline.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgselect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgsearch)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1259, 127);
            this.panel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.groupBox2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(845, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(130, 127);
            this.panel6.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbshowopsearch);
            this.groupBox2.Controls.Add(this.btnprintpreview);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(113, 112);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = ":: Print poperties ::";
            // 
            // cbshowopsearch
            // 
            this.cbshowopsearch.AutoSize = true;
            this.cbshowopsearch.Location = new System.Drawing.Point(15, 23);
            this.cbshowopsearch.Name = "cbshowopsearch";
            this.cbshowopsearch.Size = new System.Drawing.Size(94, 17);
            this.cbshowopsearch.TabIndex = 29;
            this.cbshowopsearch.Text = "Search-Option";
            this.cbshowopsearch.UseVisualStyleBackColor = true;
            this.cbshowopsearch.CheckedChanged += new System.EventHandler(this.cbshowopsearch_CheckedChanged);
            // 
            // btnprintpreview
            // 
            this.btnprintpreview.Enabled = false;
            this.btnprintpreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnprintpreview.ForeColor = System.Drawing.Color.Blue;
            this.btnprintpreview.Location = new System.Drawing.Point(12, 47);
            this.btnprintpreview.Name = "btnprintpreview";
            this.btnprintpreview.Size = new System.Drawing.Size(88, 58);
            this.btnprintpreview.TabIndex = 25;
            this.btnprintpreview.Text = "Print Preview";
            this.btnprintpreview.UseVisualStyleBackColor = true;
            this.btnprintpreview.Click += new System.EventHandler(this.btnprintpreview_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.gbonline);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(430, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(415, 127);
            this.panel5.TabIndex = 25;
            // 
            // gbonline
            // 
            this.gbonline.Controls.Add(this.label6);
            this.gbonline.Controls.Add(this.label4);
            this.gbonline.Controls.Add(this.cbdatabaseselect);
            this.gbonline.Controls.Add(this.btnsetconnect);
            this.gbonline.Controls.Add(this.btnrefresh);
            this.gbonline.Controls.Add(this.label1);
            this.gbonline.Controls.Add(this.cbunitrows);
            this.gbonline.Controls.Add(this.btnconnect);
            this.gbonline.Controls.Add(this.label2);
            this.gbonline.Controls.Add(this.label5);
            this.gbonline.Location = new System.Drawing.Point(3, 3);
            this.gbonline.Name = "gbonline";
            this.gbonline.Size = new System.Drawing.Size(410, 112);
            this.gbonline.TabIndex = 21;
            this.gbonline.TabStop = false;
            this.gbonline.Text = ":: Mode Online ::";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(275, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "rows";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(13, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "Select Data:";
            // 
            // cbdatabaseselect
            // 
            this.cbdatabaseselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbdatabaseselect.FormattingEnabled = true;
            this.cbdatabaseselect.Location = new System.Drawing.Point(103, 46);
            this.cbdatabaseselect.Name = "cbdatabaseselect";
            this.cbdatabaseselect.Size = new System.Drawing.Size(300, 24);
            this.cbdatabaseselect.TabIndex = 11;
            this.cbdatabaseselect.SelectedIndexChanged += new System.EventHandler(this.cbdatabaseselect_SelectedIndexChanged);
            // 
            // btnsetconnect
            // 
            this.btnsetconnect.Enabled = false;
            this.btnsetconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsetconnect.Location = new System.Drawing.Point(359, 14);
            this.btnsetconnect.Name = "btnsetconnect";
            this.btnsetconnect.Size = new System.Drawing.Size(44, 27);
            this.btnsetconnect.TabIndex = 21;
            this.btnsetconnect.Text = "Set";
            this.btnsetconnect.UseVisualStyleBackColor = true;
            // 
            // btnrefresh
            // 
            this.btnrefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnrefresh.Location = new System.Drawing.Point(318, 79);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(85, 23);
            this.btnrefresh.TabIndex = 19;
            this.btnrefresh.Text = "Get data";
            this.btnrefresh.UseVisualStyleBackColor = true;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(13, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Get Company:";
            // 
            // cbunitrows
            // 
            this.cbunitrows.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbunitrows.FormattingEnabled = true;
            this.cbunitrows.Items.AddRange(new object[] {
            "       500",
            "    1,000",
            "> 1,000"});
            this.cbunitrows.Location = new System.Drawing.Point(136, 78);
            this.cbunitrows.Name = "cbunitrows";
            this.cbunitrows.Size = new System.Drawing.Size(137, 24);
            this.cbunitrows.TabIndex = 11;
            this.cbunitrows.Text = " -- Select  --";
            this.cbunitrows.SelectedIndexChanged += new System.EventHandler(this.cbunitrows_SelectedIndexChanged);
            // 
            // btnconnect
            // 
            this.btnconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnconnect.Location = new System.Drawing.Point(210, 14);
            this.btnconnect.Name = "btnconnect";
            this.btnconnect.Size = new System.Drawing.Size(143, 27);
            this.btnconnect.TabIndex = 19;
            this.btnconnect.Text = "Connection to Server";
            this.btnconnect.UseVisualStyleBackColor = true;
            this.btnconnect.Click += new System.EventHandler(this.btnconnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(13, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Select rows number:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(13, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "___________________________";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.gboffline);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(430, 127);
            this.panel4.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdooffice);
            this.groupBox1.Controls.Add(this.rdoonline);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 46);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = ":: Select Mode ::";
            // 
            // rdooffice
            // 
            this.rdooffice.AutoSize = true;
            this.rdooffice.Location = new System.Drawing.Point(220, 22);
            this.rdooffice.Name = "rdooffice";
            this.rdooffice.Size = new System.Drawing.Size(138, 17);
            this.rdooffice.TabIndex = 1;
            this.rdooffice.TabStop = true;
            this.rdooffice.Text = "Offline [From Import File]";
            this.rdooffice.UseVisualStyleBackColor = true;
            this.rdooffice.CheckedChanged += new System.EventHandler(this.rdooffice_CheckedChanged);
            // 
            // rdoonline
            // 
            this.rdoonline.AutoSize = true;
            this.rdoonline.Location = new System.Drawing.Point(16, 22);
            this.rdoonline.Name = "rdoonline";
            this.rdoonline.Size = new System.Drawing.Size(180, 17);
            this.rdoonline.TabIndex = 0;
            this.rdoonline.TabStop = true;
            this.rdoonline.Text = "Online [From Database Navision]";
            this.rdoonline.UseVisualStyleBackColor = true;
            this.rdoonline.CheckedChanged += new System.EventHandler(this.rdoonline_CheckedChanged);
            // 
            // gboffline
            // 
            this.gboffline.Controls.Add(this.label3);
            this.gboffline.Controls.Add(this.txtimportfile);
            this.gboffline.Controls.Add(this.button1);
            this.gboffline.Enabled = false;
            this.gboffline.Location = new System.Drawing.Point(3, 53);
            this.gboffline.Name = "gboffline";
            this.gboffline.Size = new System.Drawing.Size(425, 62);
            this.gboffline.TabIndex = 22;
            this.gboffline.TabStop = false;
            this.gboffline.Text = ":: Mode Offline ::";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(11, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "Source data from:";
            // 
            // txtimportfile
            // 
            this.txtimportfile.Enabled = false;
            this.txtimportfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtimportfile.Location = new System.Drawing.Point(14, 34);
            this.txtimportfile.Name = "txtimportfile";
            this.txtimportfile.Size = new System.Drawing.Size(313, 22);
            this.txtimportfile.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.Location = new System.Drawing.Point(333, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Browse....";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.crystalReportViewer1);
            this.panel2.Controls.Add(this.dtgselect);
            this.panel2.Controls.Add(this.dtgsearch);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 152);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1259, 300);
            this.panel2.TabIndex = 2;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(455, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(804, 275);
            this.crystalReportViewer1.TabIndex = 6;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.Visible = false;
            // 
            // dtgselect
            // 
            this.dtgselect.AllowUserToAddRows = false;
            this.dtgselect.AllowUserToDeleteRows = false;
            this.dtgselect.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dtgselect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgselect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgselect.Location = new System.Drawing.Point(455, 0);
            this.dtgselect.Name = "dtgselect";
            this.dtgselect.ReadOnly = true;
            this.dtgselect.RowHeadersWidth = 11;
            this.dtgselect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgselect.Size = new System.Drawing.Size(804, 275);
            this.dtgselect.TabIndex = 5;
            this.dtgselect.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgselect_CellClick);
            this.dtgselect.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgselect_CellDoubleClick);
            // 
            // dtgsearch
            // 
            this.dtgsearch.AllowUserToAddRows = false;
            this.dtgsearch.AllowUserToDeleteRows = false;
            this.dtgsearch.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dtgsearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgsearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtgsearch.Location = new System.Drawing.Point(0, 0);
            this.dtgsearch.Name = "dtgsearch";
            this.dtgsearch.ReadOnly = true;
            this.dtgsearch.RowHeadersWidth = 11;
            this.dtgsearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgsearch.Size = new System.Drawing.Size(455, 275);
            this.dtgsearch.TabIndex = 4;
            this.dtgsearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgsearch_CellClick);
            this.dtgsearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgsearch_CellDoubleClick);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 275);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1259, 25);
            this.panel7.TabIndex = 4;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.lblitemselect);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(455, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(804, 25);
            this.panel9.TabIndex = 1;
            // 
            // lblitemselect
            // 
            this.lblitemselect.AutoSize = true;
            this.lblitemselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblitemselect.Location = new System.Drawing.Point(6, 3);
            this.lblitemselect.Name = "lblitemselect";
            this.lblitemselect.Size = new System.Drawing.Size(40, 16);
            this.lblitemselect.TabIndex = 1;
            this.lblitemselect.Text = "Items";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lblitemssearch);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(455, 25);
            this.panel8.TabIndex = 0;
            // 
            // lblitemssearch
            // 
            this.lblitemssearch.AutoSize = true;
            this.lblitemssearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblitemssearch.Location = new System.Drawing.Point(3, 3);
            this.lblitemssearch.Name = "lblitemssearch";
            this.lblitemssearch.Size = new System.Drawing.Size(40, 16);
            this.lblitemssearch.TabIndex = 0;
            this.lblitemssearch.Text = "Items";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.cbbyfixcode);
            this.panel3.Controls.Add(this.txtsearch);
            this.panel3.Controls.Add(this.cbbranchselect);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.cbdeptselect);
            this.panel3.Controls.Add(this.btnselect);
            this.panel3.Controls.Add(this.cbboxdept);
            this.panel3.Controls.Add(this.btndeselect);
            this.panel3.Controls.Add(this.cbboxkbranch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 127);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1259, 25);
            this.panel3.TabIndex = 3;
            this.panel3.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(780, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "|:|";
            // 
            // cbbyfixcode
            // 
            this.cbbyfixcode.AutoSize = true;
            this.cbbyfixcode.Location = new System.Drawing.Point(484, 4);
            this.cbbyfixcode.Name = "cbbyfixcode";
            this.cbbyfixcode.Size = new System.Drawing.Size(81, 17);
            this.cbbyfixcode.TabIndex = 28;
            this.cbbyfixcode.Text = "By Fix-code";
            this.cbbyfixcode.UseVisualStyleBackColor = true;
            this.cbbyfixcode.CheckedChanged += new System.EventHandler(this.cbbyfixcode_CheckedChanged);
            // 
            // txtsearch
            // 
            this.txtsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtsearch.Location = new System.Drawing.Point(563, 2);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(214, 21);
            this.txtsearch.TabIndex = 2;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // cbbranchselect
            // 
            this.cbbranchselect.Enabled = false;
            this.cbbranchselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbbranchselect.FormattingEnabled = true;
            this.cbbranchselect.Location = new System.Drawing.Point(65, 1);
            this.cbbranchselect.Name = "cbbranchselect";
            this.cbbranchselect.Size = new System.Drawing.Size(92, 23);
            this.cbbranchselect.TabIndex = 25;
            this.cbbranchselect.SelectedIndexChanged += new System.EventHandler(this.cbbranchselect_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(396, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Search Items:";
            // 
            // cbdeptselect
            // 
            this.cbdeptselect.Enabled = false;
            this.cbdeptselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbdeptselect.FormattingEnabled = true;
            this.cbdeptselect.Location = new System.Drawing.Point(218, 1);
            this.cbdeptselect.Name = "cbdeptselect";
            this.cbdeptselect.Size = new System.Drawing.Size(172, 23);
            this.cbdeptselect.TabIndex = 27;
            this.cbdeptselect.SelectedIndexChanged += new System.EventHandler(this.cbdeptselect_SelectedIndexChanged);
            // 
            // btnselect
            // 
            this.btnselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnselect.ForeColor = System.Drawing.Color.Blue;
            this.btnselect.Location = new System.Drawing.Point(831, 1);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(33, 23);
            this.btnselect.TabIndex = 4;
            this.btnselect.Text = "I->";
            this.btnselect.UseVisualStyleBackColor = true;
            this.btnselect.Click += new System.EventHandler(this.btnselect_Click);
            // 
            // cbboxdept
            // 
            this.cbboxdept.AutoSize = true;
            this.cbboxdept.Location = new System.Drawing.Point(170, 4);
            this.cbboxdept.Name = "cbboxdept";
            this.cbboxdept.Size = new System.Drawing.Size(52, 17);
            this.cbboxdept.TabIndex = 26;
            this.cbboxdept.Text = "Dept:";
            this.cbboxdept.UseVisualStyleBackColor = true;
            this.cbboxdept.CheckedChanged += new System.EventHandler(this.cbboxdept_CheckedChanged);
            // 
            // btndeselect
            // 
            this.btndeselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btndeselect.ForeColor = System.Drawing.Color.Red;
            this.btndeselect.Location = new System.Drawing.Point(797, 1);
            this.btndeselect.Name = "btndeselect";
            this.btndeselect.Size = new System.Drawing.Size(33, 23);
            this.btndeselect.TabIndex = 5;
            this.btndeselect.Text = "<-I";
            this.btndeselect.UseVisualStyleBackColor = true;
            this.btndeselect.Click += new System.EventHandler(this.btndeselect_Click);
            // 
            // cbboxkbranch
            // 
            this.cbboxkbranch.AutoSize = true;
            this.cbboxkbranch.Location = new System.Drawing.Point(5, 4);
            this.cbboxkbranch.Name = "cbboxkbranch";
            this.cbboxkbranch.Size = new System.Drawing.Size(63, 17);
            this.cbboxkbranch.TabIndex = 6;
            this.cbboxkbranch.Text = "Branch:";
            this.cbboxkbranch.UseVisualStyleBackColor = true;
            this.cbboxkbranch.CheckedChanged += new System.EventHandler(this.cbboxkbranch_CheckedChanged);
            // 
            // Frmmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 452);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "Frmmain";
            this.Text = "l:l:l Barcode-System l:l:l";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmmain_Load);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.gbonline.ResumeLayout(false);
            this.gbonline.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboffline.ResumeLayout(false);
            this.gboffline.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgselect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgsearch)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gboffline;
        private System.Windows.Forms.Button btnconnect;
        private System.Windows.Forms.ComboBox cbdatabaseselect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbonline;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdooffice;
        private System.Windows.Forms.RadioButton rdoonline;
        private System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtimportfile;
        private System.Windows.Forms.ComboBox cbunitrows;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnsetconnect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dtgsearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Button btndeselect;
        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.CheckBox cbboxkbranch;
        private System.Windows.Forms.ComboBox cbbranchselect;
        private System.Windows.Forms.ComboBox cbdeptselect;
        private System.Windows.Forms.CheckBox cbboxdept;
        private System.Windows.Forms.DataGridView dtgselect;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblitemselect;
        private System.Windows.Forms.Label lblitemssearch;
        private System.Windows.Forms.CheckBox cbbyfixcode;
        private System.Windows.Forms.Button btnprintpreview;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.CheckBox cbshowopsearch;
        private System.Windows.Forms.Label label8;
    }
}

