namespace SaleOrder
{
    partial class Frmselect_printtruck
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
            this.btnprinttosup = new System.Windows.Forms.Button();
            this.btnprinttotran = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnprinttosup
            // 
            this.btnprinttosup.Location = new System.Drawing.Point(17, 47);
            this.btnprinttosup.Name = "btnprinttosup";
            this.btnprinttosup.Size = new System.Drawing.Size(75, 63);
            this.btnprinttosup.TabIndex = 13;
            this.btnprinttosup.Text = "พิมพ์น้ำหนักลูกค้า";
            this.btnprinttosup.UseVisualStyleBackColor = true;
            this.btnprinttosup.Click += new System.EventHandler(this.btnprinttosup_Click);
            // 
            // btnprinttotran
            // 
            this.btnprinttotran.Location = new System.Drawing.Point(98, 47);
            this.btnprinttotran.Name = "btnprinttotran";
            this.btnprinttotran.Size = new System.Drawing.Size(75, 63);
            this.btnprinttotran.TabIndex = 14;
            this.btnprinttotran.Text = "พิมพ์น้ำหนักขนส่ง";
            this.btnprinttotran.UseVisualStyleBackColor = true;
            this.btnprinttotran.Click += new System.EventHandler(this.btnprinttotran_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "เลือกพิพม์ใบน้ำหนัก";
            // 
            // Frmselect_printtruck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 124);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnprinttotran);
            this.Controls.Add(this.btnprinttosup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmselect_printtruck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Print";
            this.Load += new System.EventHandler(this.Frmselect_printtruck_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnprinttosup;
        private System.Windows.Forms.Button btnprinttotran;
        private System.Windows.Forms.Label label1;
    }
}