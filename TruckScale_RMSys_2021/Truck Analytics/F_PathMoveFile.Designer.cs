namespace Truck_Analytics
{
    partial class F_PathMoveFile
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
            this.btn_source = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_source = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_desination = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_desination = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btn_source
            // 
            this.btn_source.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_source.Location = new System.Drawing.Point(449, 32);
            this.btn_source.Name = "btn_source";
            this.btn_source.Size = new System.Drawing.Size(75, 26);
            this.btn_source.TabIndex = 0;
            this.btn_source.Text = "ค้นหา";
            this.btn_source.UseVisualStyleBackColor = true;
            this.btn_source.Click += new System.EventHandler(this.btn_source_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "ไฟล์ข้อมูลต้นทาง (อ่าน)";
            // 
            // txt_source
            // 
            this.txt_source.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_source.Location = new System.Drawing.Point(25, 32);
            this.txt_source.Name = "txt_source";
            this.txt_source.ReadOnly = true;
            this.txt_source.Size = new System.Drawing.Size(416, 26);
            this.txt_source.TabIndex = 2;
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_save.Location = new System.Drawing.Point(199, 138);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(90, 26);
            this.btn_save.TabIndex = 3;
            this.btn_save.Text = "บันทึก";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_desination
            // 
            this.txt_desination.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_desination.Location = new System.Drawing.Point(25, 95);
            this.txt_desination.Name = "txt_desination";
            this.txt_desination.ReadOnly = true;
            this.txt_desination.Size = new System.Drawing.Size(418, 26);
            this.txt_desination.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(25, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "ไฟล์ข้อมูลปลายทาง (ย้าย)";
            // 
            // btn_desination
            // 
            this.btn_desination.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_desination.Location = new System.Drawing.Point(449, 95);
            this.btn_desination.Name = "btn_desination";
            this.btn_desination.Size = new System.Drawing.Size(75, 26);
            this.btn_desination.TabIndex = 4;
            this.btn_desination.Text = "ค้นหา";
            this.btn_desination.UseVisualStyleBackColor = true;
            this.btn_desination.Click += new System.EventHandler(this.btn_desination_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_cancel.Location = new System.Drawing.Point(295, 138);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(90, 26);
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.Text = "ยกเลิก";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // F_PathMoveFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 181);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.txt_desination);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_desination);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_source);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_source);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "F_PathMoveFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F_PathMoveFile";
            this.Load += new System.EventHandler(this.F_PathMoveFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_source;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_source;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox txt_desination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_desination;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}