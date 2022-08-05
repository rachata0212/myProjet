namespace SaleOrder
{
    partial class Frmselectproduct
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
            this.cbselectpro = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnweigtnsave = new System.Windows.Forms.Button();
            this.btncancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbselectpro
            // 
            this.cbselectpro.BackColor = System.Drawing.Color.PapayaWhip;
            this.cbselectpro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbselectpro.FormattingEnabled = true;
            this.cbselectpro.Location = new System.Drawing.Point(89, 10);
            this.cbselectpro.Name = "cbselectpro";
            this.cbselectpro.Size = new System.Drawing.Size(177, 26);
            this.cbselectpro.TabIndex = 69;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label16.ForeColor = System.Drawing.Color.DimGray;
            this.label16.Location = new System.Drawing.Point(12, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 18);
            this.label16.TabIndex = 21;
            this.label16.Text = "ชนิดสินค้า";
            // 
            // btnweigtnsave
            // 
            this.btnweigtnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnweigtnsave.ForeColor = System.Drawing.Color.Blue;
            this.btnweigtnsave.Location = new System.Drawing.Point(49, 46);
            this.btnweigtnsave.Name = "btnweigtnsave";
            this.btnweigtnsave.Size = new System.Drawing.Size(80, 31);
            this.btnweigtnsave.TabIndex = 70;
            this.btnweigtnsave.Text = "บันทึก";
            this.btnweigtnsave.UseVisualStyleBackColor = true;
            this.btnweigtnsave.Click += new System.EventHandler(this.btnweigtnsave_Click);
            // 
            // btncancle
            // 
            this.btncancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btncancle.ForeColor = System.Drawing.Color.Red;
            this.btncancle.Location = new System.Drawing.Point(135, 46);
            this.btncancle.Name = "btncancle";
            this.btncancle.Size = new System.Drawing.Size(80, 31);
            this.btncancle.TabIndex = 71;
            this.btncancle.Text = "ยกเลิก";
            this.btncancle.UseVisualStyleBackColor = true;
            this.btncancle.Click += new System.EventHandler(this.btncancle_Click);
            // 
            // Frmselectproduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 85);
            this.Controls.Add(this.btncancle);
            this.Controls.Add(this.btnweigtnsave);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cbselectpro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmselectproduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Product";
            this.Load += new System.EventHandler(this.Frmselectproduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbselectpro;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnweigtnsave;
        private System.Windows.Forms.Button btncancle;
    }
}