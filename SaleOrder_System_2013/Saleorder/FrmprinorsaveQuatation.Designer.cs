namespace SaleOrder
{
    partial class FrmprinorsaveQuatation
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
            this.btnok = new System.Windows.Forms.Button();
            this.rdoprint = new System.Windows.Forms.RadioButton();
            this.rdosaveandclose = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnok
            // 
            this.btnok.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnok.Location = new System.Drawing.Point(51, 88);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 27);
            this.btnok.TabIndex = 0;
            this.btnok.Text = "ตกลง";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // rdoprint
            // 
            this.rdoprint.AutoSize = true;
            this.rdoprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdoprint.Location = new System.Drawing.Point(30, 32);
            this.rdoprint.Name = "rdoprint";
            this.rdoprint.Size = new System.Drawing.Size(126, 22);
            this.rdoprint.TabIndex = 2;
            this.rdoprint.TabStop = true;
            this.rdoprint.Text = "พิมพ์ใบเสนอราคา";
            this.rdoprint.UseVisualStyleBackColor = true;
            // 
            // rdosaveandclose
            // 
            this.rdosaveandclose.AutoSize = true;
            this.rdosaveandclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdosaveandclose.Location = new System.Drawing.Point(30, 60);
            this.rdosaveandclose.Name = "rdosaveandclose";
            this.rdosaveandclose.Size = new System.Drawing.Size(122, 22);
            this.rdosaveandclose.TabIndex = 3;
            this.rdosaveandclose.TabStop = true;
            this.rdosaveandclose.Text = "บันทึกและปิดงาน";
            this.rdosaveandclose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(56, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "---เลือก---";
            // 
            // FrmprinorsaveQuatation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(175, 127);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdosaveandclose);
            this.Controls.Add(this.rdoprint);
            this.Controls.Add(this.btnok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmprinorsaveQuatation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Save OR Print";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.RadioButton rdoprint;
        private System.Windows.Forms.RadioButton rdosaveandclose;
        private System.Windows.Forms.Label label1;
    }
}