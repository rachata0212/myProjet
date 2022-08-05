namespace SaleOrder
{
    partial class Frmqickview
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
            this.btnprintpurchase = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpstartdate = new System.Windows.Forms.DateTimePicker();
            this.btnprintsale = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnprintpurchase
            // 
            this.btnprintpurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnprintpurchase.Location = new System.Drawing.Point(9, 34);
            this.btnprintpurchase.Name = "btnprintpurchase";
            this.btnprintpurchase.Size = new System.Drawing.Size(103, 60);
            this.btnprintpurchase.TabIndex = 0;
            this.btnprintpurchase.Text = "สรุปซื้อต่อวัน";
            this.btnprintpurchase.UseVisualStyleBackColor = true;
            this.btnprintpurchase.Click += new System.EventHandler(this.btnprintpurchase_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "เลือกวันที่พิมพ์";
            // 
            // dtpstartdate
            // 
            this.dtpstartdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpstartdate.Location = new System.Drawing.Point(87, 6);
            this.dtpstartdate.Name = "dtpstartdate";
            this.dtpstartdate.Size = new System.Drawing.Size(134, 22);
            this.dtpstartdate.TabIndex = 2;
            // 
            // btnprintsale
            // 
            this.btnprintsale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnprintsale.Location = new System.Drawing.Point(118, 34);
            this.btnprintsale.Name = "btnprintsale";
            this.btnprintsale.Size = new System.Drawing.Size(103, 60);
            this.btnprintsale.TabIndex = 3;
            this.btnprintsale.Text = "สรุปขายต่อวัน";
            this.btnprintsale.UseVisualStyleBackColor = true;
            this.btnprintsale.Click += new System.EventHandler(this.btnprintsale_Click);
            // 
            // Frmqickview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 105);
            this.Controls.Add(this.btnprintsale);
            this.Controls.Add(this.dtpstartdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnprintpurchase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmqickview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frmqickview";
            this.Load += new System.EventHandler(this.Frmqickview_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnprintpurchase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpstartdate;
        private System.Windows.Forms.Button btnprintsale;
    }
}