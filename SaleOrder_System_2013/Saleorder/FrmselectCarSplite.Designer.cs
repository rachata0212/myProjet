namespace SaleOrder
{
    partial class FrmselectCarSplite
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
            this.label13 = new System.Windows.Forms.Label();
            this.txtnamecar = new System.Windows.Forms.TextBox();
            this.btncar = new System.Windows.Forms.Button();
            this.txtidcar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label13.Location = new System.Drawing.Point(12, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 18);
            this.label13.TabIndex = 36;
            this.label13.Text = "ชนิดรถ/ประเภท";
            // 
            // txtnamecar
            // 
            this.txtnamecar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtnamecar.Location = new System.Drawing.Point(154, 37);
            this.txtnamecar.Name = "txtnamecar";
            this.txtnamecar.ReadOnly = true;
            this.txtnamecar.Size = new System.Drawing.Size(231, 24);
            this.txtnamecar.TabIndex = 39;
            // 
            // btncar
            // 
            this.btncar.BackColor = System.Drawing.Color.Khaki;
            this.btncar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btncar.ForeColor = System.Drawing.Color.Red;
            this.btncar.Location = new System.Drawing.Point(391, 37);
            this.btncar.Name = "btncar";
            this.btncar.Size = new System.Drawing.Size(37, 24);
            this.btncar.TabIndex = 38;
            this.btncar.Text = ".....";
            this.btncar.UseVisualStyleBackColor = false;
            this.btncar.Click += new System.EventHandler(this.btncar_Click);
            // 
            // txtidcar
            // 
            this.txtidcar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtidcar.Location = new System.Drawing.Point(115, 37);
            this.txtidcar.Name = "txtidcar";
            this.txtidcar.ReadOnly = true;
            this.txtidcar.Size = new System.Drawing.Size(38, 24);
            this.txtidcar.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 18);
            this.label1.TabIndex = 40;
            this.label1.Text = "เลือกประเภทรถที่ต้องการเปลี่ยน ณ รายการ Order ปัจจุบัน";
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnsave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnsave.Location = new System.Drawing.Point(296, 67);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(66, 33);
            this.btnsave.TabIndex = 42;
            this.btnsave.Text = "SAVE";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnexit
            // 
            this.btnexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnexit.ForeColor = System.Drawing.Color.Red;
            this.btnexit.Location = new System.Drawing.Point(368, 67);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(58, 33);
            this.btnexit.TabIndex = 41;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // FrmselectCarSplite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 112);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtnamecar);
            this.Controls.Add(this.btncar);
            this.Controls.Add(this.txtidcar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmselectCarSplite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmselectCarSplite";
            this.Load += new System.EventHandler(this.FrmselectCarSplite_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtnamecar;
        private System.Windows.Forms.Button btncar;
        private System.Windows.Forms.TextBox txtidcar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnexit;
    }
}