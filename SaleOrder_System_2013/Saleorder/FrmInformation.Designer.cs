namespace SaleOrder
{
    partial class FrmInformation
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
            this.btnclose = new System.Windows.Forms.Button();
            this.txtpurchase = new System.Windows.Forms.TextBox();
            this.lblpurhcase = new System.Windows.Forms.Label();
            this.lblsale = new System.Windows.Forms.Label();
            this.txtorder = new System.Windows.Forms.TextBox();
            this.lblinformation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnclose
            // 
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnclose.ForeColor = System.Drawing.Color.Red;
            this.btnclose.Location = new System.Drawing.Point(277, 3);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(29, 23);
            this.btnclose.TabIndex = 0;
            this.btnclose.Text = "X";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // txtpurchase
            // 
            this.txtpurchase.Location = new System.Drawing.Point(6, 44);
            this.txtpurchase.Multiline = true;
            this.txtpurchase.Name = "txtpurchase";
            this.txtpurchase.ReadOnly = true;
            this.txtpurchase.Size = new System.Drawing.Size(300, 164);
            this.txtpurchase.TabIndex = 1;
            // 
            // lblpurhcase
            // 
            this.lblpurhcase.AutoSize = true;
            this.lblpurhcase.Location = new System.Drawing.Point(3, 28);
            this.lblpurhcase.Name = "lblpurhcase";
            this.lblpurhcase.Size = new System.Drawing.Size(45, 13);
            this.lblpurhcase.TabIndex = 2;
            this.lblpurhcase.Text = "ข้อมูลซื้อ";
            // 
            // lblsale
            // 
            this.lblsale.AutoSize = true;
            this.lblsale.Location = new System.Drawing.Point(3, 213);
            this.lblsale.Name = "lblsale";
            this.lblsale.Size = new System.Drawing.Size(50, 13);
            this.lblsale.TabIndex = 4;
            this.lblsale.Text = "ข้อมูลขาย";
            // 
            // txtorder
            // 
            this.txtorder.Location = new System.Drawing.Point(6, 228);
            this.txtorder.Multiline = true;
            this.txtorder.Name = "txtorder";
            this.txtorder.ReadOnly = true;
            this.txtorder.Size = new System.Drawing.Size(300, 111);
            this.txtorder.TabIndex = 3;
            // 
            // lblinformation
            // 
            this.lblinformation.AutoSize = true;
            this.lblinformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblinformation.Location = new System.Drawing.Point(3, 6);
            this.lblinformation.Name = "lblinformation";
            this.lblinformation.Size = new System.Drawing.Size(85, 16);
            this.lblinformation.TabIndex = 5;
            this.lblinformation.Text = "รายละเอียดข้อมูล";
            // 
            // FrmInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 350);
            this.Controls.Add(this.lblinformation);
            this.Controls.Add(this.lblsale);
            this.Controls.Add(this.txtorder);
            this.Controls.Add(this.lblpurhcase);
            this.Controls.Add(this.txtpurchase);
            this.Controls.Add(this.btnclose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInformation";
            this.Text = "FrmInformation";
            this.Load += new System.EventHandler(this.FrmInformation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.TextBox txtpurchase;
        private System.Windows.Forms.Label lblpurhcase;
        private System.Windows.Forms.Label lblsale;
        private System.Windows.Forms.TextBox txtorder;
        private System.Windows.Forms.Label lblinformation;
    }
}