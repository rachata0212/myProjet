namespace Gui_PI
{
    partial class F_Mainpage
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_setData = new System.Windows.Forms.Label();
            this.lbl_saveData = new System.Windows.Forms.Label();
            this.lbl_setProgram = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_setupProgram = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_saveData = new System.Windows.Forms.Button();
            this.btn_settingData = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(212, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "ระบบบันทึกข้อมูลเครื่องจักรการผลิต";
            // 
            // lbl_setData
            // 
            this.lbl_setData.AutoSize = true;
            this.lbl_setData.Enabled = false;
            this.lbl_setData.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_setData.Location = new System.Drawing.Point(252, 424);
            this.lbl_setData.Name = "lbl_setData";
            this.lbl_setData.Size = new System.Drawing.Size(111, 29);
            this.lbl_setData.TabIndex = 6;
            this.lbl_setData.Text = "ตั้งค่าข้อมูล";
            // 
            // lbl_saveData
            // 
            this.lbl_saveData.AutoSize = true;
            this.lbl_saveData.Enabled = false;
            this.lbl_saveData.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_saveData.Location = new System.Drawing.Point(71, 424);
            this.lbl_saveData.Name = "lbl_saveData";
            this.lbl_saveData.Size = new System.Drawing.Size(122, 29);
            this.lbl_saveData.TabIndex = 7;
            this.lbl_saveData.Text = "บันทึกข้อมูล";
            // 
            // lbl_setProgram
            // 
            this.lbl_setProgram.AutoSize = true;
            this.lbl_setProgram.Enabled = false;
            this.lbl_setProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_setProgram.Location = new System.Drawing.Point(407, 424);
            this.lbl_setProgram.Name = "lbl_setProgram";
            this.lbl_setProgram.Size = new System.Drawing.Size(152, 29);
            this.lbl_setProgram.TabIndex = 8;
            this.lbl_setProgram.Text = "ตั้งค่าโปรแกรม";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(590, 424);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 29);
            this.label5.TabIndex = 9;
            this.label5.Text = "ออกโปรแกรม";
            // 
            // btn_setupProgram
            // 
            this.btn_setupProgram.BackgroundImage = global::Gui_PI.Properties.Resources.setup;
            this.btn_setupProgram.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_setupProgram.Enabled = false;
            this.btn_setupProgram.Location = new System.Drawing.Point(442, 316);
            this.btn_setupProgram.Name = "btn_setupProgram";
            this.btn_setupProgram.Size = new System.Drawing.Size(84, 84);
            this.btn_setupProgram.TabIndex = 5;
            this.btn_setupProgram.UseVisualStyleBackColor = true;
            this.btn_setupProgram.Click += new System.EventHandler(this.btn_setup_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackgroundImage = global::Gui_PI.Properties.Resources.images;
            this.btn_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_exit.Location = new System.Drawing.Point(620, 316);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(84, 84);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_saveData
            // 
            this.btn_saveData.BackgroundImage = global::Gui_PI.Properties.Resources._2763055;
            this.btn_saveData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_saveData.Enabled = false;
            this.btn_saveData.Location = new System.Drawing.Point(90, 316);
            this.btn_saveData.Name = "btn_saveData";
            this.btn_saveData.Size = new System.Drawing.Size(84, 84);
            this.btn_saveData.TabIndex = 3;
            this.btn_saveData.UseVisualStyleBackColor = true;
            this.btn_saveData.Click += new System.EventHandler(this.btn_imputData_Click);
            // 
            // btn_settingData
            // 
            this.btn_settingData.BackgroundImage = global::Gui_PI.Properties.Resources.gear_integration_flat_icon_vector_7952106;
            this.btn_settingData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_settingData.Enabled = false;
            this.btn_settingData.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_settingData.Location = new System.Drawing.Point(266, 316);
            this.btn_settingData.Name = "btn_settingData";
            this.btn_settingData.Size = new System.Drawing.Size(84, 84);
            this.btn_settingData.TabIndex = 2;
            this.btn_settingData.UseVisualStyleBackColor = true;
            this.btn_settingData.Click += new System.EventHandler(this.btn_setData_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gui_PI.Properties.Resources.jil_web_images__03;
            this.pictureBox1.Location = new System.Drawing.Point(155, 87);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(491, 196);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(716, 496);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Build. 1.0.0.1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(12, 496);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "© 2021 Sapthip Co., Ltd. All rights reserved";
            // 
            // F_Mainpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 522);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_setProgram);
            this.Controls.Add(this.lbl_saveData);
            this.Controls.Add(this.lbl_setData);
            this.Controls.Add(this.btn_setupProgram);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_saveData);
            this.Controls.Add(this.btn_settingData);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_Mainpage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Interface Data to PIZ Systems.";
            this.Load += new System.EventHandler(this.F_Mainpage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_settingData;
        private System.Windows.Forms.Button btn_saveData;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_setupProgram;
        private System.Windows.Forms.Label lbl_setData;
        private System.Windows.Forms.Label lbl_saveData;
        private System.Windows.Forms.Label lbl_setProgram;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
    }
}