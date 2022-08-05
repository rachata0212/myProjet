namespace SaleOrder
{
    partial class Frmrateoil
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cbtruckserail = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdrivemp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtgrate = new System.Windows.Forms.DataGridView();
            this.idnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daterefilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mileageNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kilometeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitliterefilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceperliteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.averateperkmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pricetotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idautoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdrate = new System.Windows.Forms.BindingSource(this.components);
            this.dTrat = new SaleOrder.DTrat();
            this.dtpstreport = new System.Windows.Forms.DateTimePicker();
            this.btnclose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.lblcount = new System.Windows.Forms.Label();
            this.btnrecode = new System.Windows.Forms.Button();
            this.btnaddtruck = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtsurname = new System.Windows.Forms.TextBox();
            this.txtremark = new System.Windows.Forms.TextBox();
            this.txtratename = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnreport = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpsjobmont = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpedreport = new System.Windows.Forms.DateTimePicker();
            this.cbnew = new System.Windows.Forms.CheckBox();
            this.timewarning = new System.Windows.Forms.Timer(this.components);
            this.txtwarning = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnsavedatabase = new System.Windows.Forms.Button();
            this.cbviewall = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTrat)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(396, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "ตารางบันทึกการตรวจเช็คการใช้น้ำมัน";
            // 
            // cbtruckserail
            // 
            this.cbtruckserail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbtruckserail.FormattingEnabled = true;
            this.cbtruckserail.Location = new System.Drawing.Point(111, 56);
            this.cbtruckserail.Name = "cbtruckserail";
            this.cbtruckserail.Size = new System.Drawing.Size(177, 26);
            this.cbtruckserail.TabIndex = 1;
            this.cbtruckserail.Text = "11-2222/33-4444";
            this.cbtruckserail.SelectedIndexChanged += new System.EventHandler(this.cbtruckserail_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "พนักงานขับรถ:";
            // 
            // txtdrivemp
            // 
            this.txtdrivemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdrivemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtdrivemp.Location = new System.Drawing.Point(111, 87);
            this.txtdrivemp.Name = "txtdrivemp";
            this.txtdrivemp.ReadOnly = true;
            this.txtdrivemp.Size = new System.Drawing.Size(177, 24);
            this.txtdrivemp.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "เลือกทะเบียน:";
            // 
            // dtgrate
            // 
            this.dtgrate.AllowUserToAddRows = false;
            this.dtgrate.AllowUserToDeleteRows = false;
            this.dtgrate.AutoGenerateColumns = false;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgrate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dtgrate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idnoDataGridViewTextBoxColumn,
            this.daterefilDataGridViewTextBoxColumn,
            this.mileageNoDataGridViewTextBoxColumn,
            this.kilometeDataGridViewTextBoxColumn,
            this.unitliterefilDataGridViewTextBoxColumn,
            this.priceperliteDataGridViewTextBoxColumn,
            this.averateperkmDataGridViewTextBoxColumn,
            this.pricetotalDataGridViewTextBoxColumn,
            this.remarkDataGridViewTextBoxColumn,
            this.idautoDataGridViewTextBoxColumn});
            this.dtgrate.DataSource = this.bdrate;
            this.dtgrate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrate.Location = new System.Drawing.Point(0, 0);
            this.dtgrate.Name = "dtgrate";
            this.dtgrate.ReadOnly = true;
            this.dtgrate.RowHeadersWidth = 15;
            this.dtgrate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrate.Size = new System.Drawing.Size(903, 511);
            this.dtgrate.TabIndex = 5;
            this.dtgrate.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgrate_CellMouseDoubleClick);
            // 
            // idnoDataGridViewTextBoxColumn
            // 
            this.idnoDataGridViewTextBoxColumn.DataPropertyName = "idno";
            this.idnoDataGridViewTextBoxColumn.HeaderText = "iNo";
            this.idnoDataGridViewTextBoxColumn.Name = "idnoDataGridViewTextBoxColumn";
            this.idnoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idnoDataGridViewTextBoxColumn.Width = 60;
            // 
            // daterefilDataGridViewTextBoxColumn
            // 
            this.daterefilDataGridViewTextBoxColumn.DataPropertyName = "daterefil";
            this.daterefilDataGridViewTextBoxColumn.HeaderText = "วันที่เติม";
            this.daterefilDataGridViewTextBoxColumn.Name = "daterefilDataGridViewTextBoxColumn";
            this.daterefilDataGridViewTextBoxColumn.ReadOnly = true;
            this.daterefilDataGridViewTextBoxColumn.Width = 80;
            // 
            // mileageNoDataGridViewTextBoxColumn
            // 
            this.mileageNoDataGridViewTextBoxColumn.DataPropertyName = "mileageNo";
            this.mileageNoDataGridViewTextBoxColumn.HeaderText = "เลขไมล์";
            this.mileageNoDataGridViewTextBoxColumn.Name = "mileageNoDataGridViewTextBoxColumn";
            this.mileageNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.mileageNoDataGridViewTextBoxColumn.Width = 90;
            // 
            // kilometeDataGridViewTextBoxColumn
            // 
            this.kilometeDataGridViewTextBoxColumn.DataPropertyName = "kilomete";
            dataGridViewCellStyle26.Format = "N0";
            dataGridViewCellStyle26.NullValue = "0";
            this.kilometeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle26;
            this.kilometeDataGridViewTextBoxColumn.HeaderText = "ระยะทาง/เวลา";
            this.kilometeDataGridViewTextBoxColumn.Name = "kilometeDataGridViewTextBoxColumn";
            this.kilometeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unitliterefilDataGridViewTextBoxColumn
            // 
            this.unitliterefilDataGridViewTextBoxColumn.DataPropertyName = "unitliterefil";
            dataGridViewCellStyle27.Format = "N2";
            dataGridViewCellStyle27.NullValue = "0";
            this.unitliterefilDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle27;
            this.unitliterefilDataGridViewTextBoxColumn.HeaderText = "จำนวนลิตร";
            this.unitliterefilDataGridViewTextBoxColumn.Name = "unitliterefilDataGridViewTextBoxColumn";
            this.unitliterefilDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitliterefilDataGridViewTextBoxColumn.Width = 85;
            // 
            // priceperliteDataGridViewTextBoxColumn
            // 
            this.priceperliteDataGridViewTextBoxColumn.DataPropertyName = "priceperlite";
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle28.Format = "N2";
            dataGridViewCellStyle28.NullValue = "0";
            this.priceperliteDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle28;
            this.priceperliteDataGridViewTextBoxColumn.HeaderText = "ราคา/ลิตร";
            this.priceperliteDataGridViewTextBoxColumn.Name = "priceperliteDataGridViewTextBoxColumn";
            this.priceperliteDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceperliteDataGridViewTextBoxColumn.Width = 90;
            // 
            // averateperkmDataGridViewTextBoxColumn
            // 
            this.averateperkmDataGridViewTextBoxColumn.DataPropertyName = "averateperkm";
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.Format = "N2";
            dataGridViewCellStyle29.NullValue = "0";
            this.averateperkmDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle29;
            this.averateperkmDataGridViewTextBoxColumn.HeaderText = "เฉลี่ย กม./ชม.";
            this.averateperkmDataGridViewTextBoxColumn.Name = "averateperkmDataGridViewTextBoxColumn";
            this.averateperkmDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pricetotalDataGridViewTextBoxColumn
            // 
            this.pricetotalDataGridViewTextBoxColumn.DataPropertyName = "pricetotal";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.Format = "N0";
            dataGridViewCellStyle30.NullValue = "0";
            this.pricetotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle30;
            this.pricetotalDataGridViewTextBoxColumn.HeaderText = "ราคารวม";
            this.pricetotalDataGridViewTextBoxColumn.Name = "pricetotalDataGridViewTextBoxColumn";
            this.pricetotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // remarkDataGridViewTextBoxColumn
            // 
            this.remarkDataGridViewTextBoxColumn.DataPropertyName = "remark";
            this.remarkDataGridViewTextBoxColumn.HeaderText = "หมาเหตุ";
            this.remarkDataGridViewTextBoxColumn.Name = "remarkDataGridViewTextBoxColumn";
            this.remarkDataGridViewTextBoxColumn.ReadOnly = true;
            this.remarkDataGridViewTextBoxColumn.Width = 200;
            // 
            // idautoDataGridViewTextBoxColumn
            // 
            this.idautoDataGridViewTextBoxColumn.DataPropertyName = "idauto";
            this.idautoDataGridViewTextBoxColumn.HeaderText = "R.id";
            this.idautoDataGridViewTextBoxColumn.Name = "idautoDataGridViewTextBoxColumn";
            this.idautoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idautoDataGridViewTextBoxColumn.Width = 60;
            // 
            // bdrate
            // 
            this.bdrate.DataMember = "dtrateoil";
            this.bdrate.DataSource = this.dTrat;
            // 
            // dTrat
            // 
            this.dTrat.DataSetName = "DTrat";
            this.dTrat.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtpstreport
            // 
            this.dtpstreport.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpstreport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpstreport.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpstreport.Location = new System.Drawing.Point(697, 118);
            this.dtpstreport.Name = "dtpstreport";
            this.dtpstreport.Size = new System.Drawing.Size(106, 24);
            this.dtpstreport.TabIndex = 7;
            // 
            // btnclose
            // 
            this.btnclose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnclose.ForeColor = System.Drawing.Color.Red;
            this.btnclose.Location = new System.Drawing.Point(810, 0);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(93, 27);
            this.btnclose.TabIndex = 11;
            this.btnclose.Text = "ปิด";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lblcount);
            this.panel1.Controls.Add(this.btnclose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 661);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 27);
            this.panel1.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.Location = new System.Drawing.Point(124, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 18);
            this.label11.TabIndex = 22;
            // 
            // lblcount
            // 
            this.lblcount.AutoSize = true;
            this.lblcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblcount.Location = new System.Drawing.Point(3, 4);
            this.lblcount.Name = "lblcount";
            this.lblcount.Size = new System.Drawing.Size(0, 18);
            this.lblcount.TabIndex = 21;
            // 
            // btnrecode
            // 
            this.btnrecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnrecode.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnrecode.Location = new System.Drawing.Point(809, 52);
            this.btnrecode.Name = "btnrecode";
            this.btnrecode.Size = new System.Drawing.Size(91, 28);
            this.btnrecode.TabIndex = 6;
            this.btnrecode.Text = "บันทึกน้ำมัน";
            this.btnrecode.UseVisualStyleBackColor = true;
            this.btnrecode.Click += new System.EventHandler(this.btnrecode_Click);
            // 
            // btnaddtruck
            // 
            this.btnaddtruck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnaddtruck.ForeColor = System.Drawing.Color.Maroon;
            this.btnaddtruck.Location = new System.Drawing.Point(809, 20);
            this.btnaddtruck.Name = "btnaddtruck";
            this.btnaddtruck.Size = new System.Drawing.Size(91, 28);
            this.btnaddtruck.TabIndex = 13;
            this.btnaddtruck.Text = "ตั้งค่า";
            this.btnaddtruck.UseVisualStyleBackColor = true;
            this.btnaddtruck.Click += new System.EventHandler(this.btnaddtruck_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(295, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "นามสกุล:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(295, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "หมายเหตุ:";
            // 
            // txtsurname
            // 
            this.txtsurname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtsurname.Location = new System.Drawing.Point(356, 87);
            this.txtsurname.Name = "txtsurname";
            this.txtsurname.ReadOnly = true;
            this.txtsurname.Size = new System.Drawing.Size(175, 24);
            this.txtsurname.TabIndex = 16;
            // 
            // txtremark
            // 
            this.txtremark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtremark.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtremark.Location = new System.Drawing.Point(356, 118);
            this.txtremark.Name = "txtremark";
            this.txtremark.ReadOnly = true;
            this.txtremark.Size = new System.Drawing.Size(175, 24);
            this.txtremark.TabIndex = 17;
            this.txtremark.Text = "อาจใส่เป็นเบอร์รถ";
            // 
            // txtratename
            // 
            this.txtratename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtratename.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtratename.Location = new System.Drawing.Point(111, 118);
            this.txtratename.Name = "txtratename";
            this.txtratename.ReadOnly = true;
            this.txtratename.Size = new System.Drawing.Size(177, 24);
            this.txtratename.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(15, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 18);
            this.label7.TabIndex = 18;
            this.label7.Text = "การคิดแบบ:";
            // 
            // btnreport
            // 
            this.btnreport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnreport.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnreport.Location = new System.Drawing.Point(809, 116);
            this.btnreport.Name = "btnreport";
            this.btnreport.Size = new System.Drawing.Size(91, 28);
            this.btnreport.TabIndex = 20;
            this.btnreport.Text = "ออกรายงาน";
            this.btnreport.UseVisualStyleBackColor = true;
            this.btnreport.Click += new System.EventHandler(this.btnreport_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgrate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(903, 511);
            this.panel2.TabIndex = 21;
            // 
            // dtpsjobmont
            // 
            this.dtpsjobmont.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpsjobmont.CustomFormat = "MM/yyyy";
            this.dtpsjobmont.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpsjobmont.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpsjobmont.Location = new System.Drawing.Point(356, 57);
            this.dtpsjobmont.Name = "dtpsjobmont";
            this.dtpsjobmont.Size = new System.Drawing.Size(106, 24);
            this.dtpsjobmont.TabIndex = 22;
            this.dtpsjobmont.ValueChanged += new System.EventHandler(this.dtpsjobmont_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(290, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 18);
            this.label8.TabIndex = 23;
            this.label8.Text = "เลือกเดือน:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(648, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "สิ้นสุด:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(660, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 18);
            this.label9.TabIndex = 24;
            this.label9.Text = "เริ่ม:";
            // 
            // dtpedreport
            // 
            this.dtpedreport.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpedreport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpedreport.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpedreport.Location = new System.Drawing.Point(697, 90);
            this.dtpedreport.Name = "dtpedreport";
            this.dtpedreport.Size = new System.Drawing.Size(106, 24);
            this.dtpedreport.TabIndex = 25;
            // 
            // cbnew
            // 
            this.cbnew.AutoSize = true;
            this.cbnew.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbnew.Location = new System.Drawing.Point(714, 58);
            this.cbnew.Name = "cbnew";
            this.cbnew.Size = new System.Drawing.Size(88, 17);
            this.cbnew.TabIndex = 30;
            this.cbnew.Text = "บันทึกรถใหม่";
            this.cbnew.UseVisualStyleBackColor = true;
            this.cbnew.CheckedChanged += new System.EventHandler(this.cbnew_CheckedChanged);
            // 
            // timewarning
            // 
            this.timewarning.Interval = 1000;
            this.timewarning.Tick += new System.EventHandler(this.timewarning_Tick);
            // 
            // txtwarning
            // 
            this.txtwarning.BackColor = System.Drawing.Color.Red;
            this.txtwarning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtwarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtwarning.Location = new System.Drawing.Point(67, 5);
            this.txtwarning.Name = "txtwarning";
            this.txtwarning.ReadOnly = true;
            this.txtwarning.Size = new System.Drawing.Size(59, 22);
            this.txtwarning.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.Location = new System.Drawing.Point(6, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 18);
            this.label10.TabIndex = 31;
            this.label10.Text = "warning:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtwarning);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(674, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(132, 31);
            this.panel3.TabIndex = 33;
            this.panel3.Visible = false;
            // 
            // btnsavedatabase
            // 
            this.btnsavedatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsavedatabase.ForeColor = System.Drawing.Color.Red;
            this.btnsavedatabase.Location = new System.Drawing.Point(809, 83);
            this.btnsavedatabase.Name = "btnsavedatabase";
            this.btnsavedatabase.Size = new System.Drawing.Size(91, 30);
            this.btnsavedatabase.TabIndex = 34;
            this.btnsavedatabase.Text = "บันทึกฐานข้อมูล";
            this.btnsavedatabase.UseVisualStyleBackColor = true;
            this.btnsavedatabase.Click += new System.EventHandler(this.btnsavedatabase_Click);
            // 
            // cbviewall
            // 
            this.cbviewall.AutoSize = true;
            this.cbviewall.Location = new System.Drawing.Point(471, 61);
            this.cbviewall.Name = "cbviewall";
            this.cbviewall.Size = new System.Drawing.Size(60, 17);
            this.cbviewall.TabIndex = 35;
            this.cbviewall.Text = "ViewAll";
            this.cbviewall.UseVisualStyleBackColor = true;
            this.cbviewall.CheckedChanged += new System.EventHandler(this.cbviewall_CheckedChanged);
            // 
            // Frmrateoil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 688);
            this.Controls.Add(this.cbviewall);
            this.Controls.Add(this.btnsavedatabase);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.cbtruckserail);
            this.Controls.Add(this.cbnew);
            this.Controls.Add(this.dtpedreport);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpsjobmont);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnreport);
            this.Controls.Add(this.txtratename);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtremark);
            this.Controls.Add(this.txtsurname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnaddtruck);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtpstreport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnrecode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtdrivemp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmrateoil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "บันทึกส่งเรทน้ำมัน";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frmrateoil_FormClosing);
            this.Load += new System.EventHandler(this.Frmrateoil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTrat)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbtruckserail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdrivemp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dtgrate;
        private System.Windows.Forms.BindingSource bdrate;
        private DTrat dTrat;
        private System.Windows.Forms.DateTimePicker dtpstreport;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnrecode;
        private System.Windows.Forms.Button btnaddtruck;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtsurname;
        private System.Windows.Forms.TextBox txtremark;
        private System.Windows.Forms.TextBox txtratename;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnreport;
        private System.Windows.Forms.Label lblcount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpsjobmont;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpedreport;
        private System.Windows.Forms.CheckBox cbnew;
        private System.Windows.Forms.Timer timewarning;
        private System.Windows.Forms.TextBox txtwarning;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnsavedatabase;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn idnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn daterefilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mileageNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kilometeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitliterefilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceperliteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn averateperkmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pricetotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idautoDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox cbviewall;
    }
}