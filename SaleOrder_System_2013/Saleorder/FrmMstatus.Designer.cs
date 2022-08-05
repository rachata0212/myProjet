namespace SaleOrder
{
    partial class FrmMstatus
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
            this.bdtranreplyFsTc = new System.Windows.Forms.BindingSource(this.components);
            this.dtssaleorder = new SaleOrder.dtssaleorder();
            this.bdjobholetruckin = new System.Windows.Forms.BindingSource(this.components);
            this.bdpurordertran = new System.Windows.Forms.BindingSource(this.components);
            this.bdsaleorder = new System.Windows.Forms.BindingSource(this.components);
            this.bdjobholetruckout = new System.Windows.Forms.BindingSource(this.components);
            this.bdhistorytruckin = new System.Windows.Forms.BindingSource(this.components);
            this.bdhistorytruckOut = new System.Windows.Forms.BindingSource(this.components);
            this.dbonholdtruckinBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bdtranreplyFsTc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtssaleorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdjobholetruckin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdpurordertran)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsaleorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdjobholetruckout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdhistorytruckin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdhistorytruckOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbonholdtruckinBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bdtranreplyFsTc
            // 
            this.bdtranreplyFsTc.DataMember = "dttranreplyFsTc";
            this.bdtranreplyFsTc.DataSource = this.dtssaleorder;
            // 
            // dtssaleorder
            // 
            this.dtssaleorder.DataSetName = "dtssaleorder";
            this.dtssaleorder.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdjobholetruckin
            // 
            this.bdjobholetruckin.DataMember = "dbonholdtruckin";
            this.bdjobholetruckin.DataSource = this.dtssaleorder;
            // 
            // bdpurordertran
            // 
            this.bdpurordertran.DataMember = "dtspurcheordertran";
            this.bdpurordertran.DataSource = this.dtssaleorder;
            // 
            // bdsaleorder
            // 
            this.bdsaleorder.DataMember = "dtsaleorder";
            this.bdsaleorder.DataSource = this.dtssaleorder;
            // 
            // bdjobholetruckout
            // 
            this.bdjobholetruckout.DataMember = "dbonholetruckout";
            this.bdjobholetruckout.DataSource = this.dtssaleorder;
            // 
            // bdhistorytruckin
            // 
            this.bdhistorytruckin.DataMember = "dtghistorytruckin";
            this.bdhistorytruckin.DataSource = this.dtssaleorder;
            // 
            // bdhistorytruckOut
            // 
            this.bdhistorytruckOut.DataMember = "dtghistorytruckout";
            this.bdhistorytruckOut.DataSource = this.dtssaleorder;
            // 
            // dbonholdtruckinBindingSource
            // 
            this.dbonholdtruckinBindingSource.DataMember = "dbonholdtruckin";
            this.dbonholdtruckinBindingSource.DataSource = this.dtssaleorder;
            // 
            // FrmMstatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 500);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMstatus";
            this.Text = "FrmMstatus";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.bdtranreplyFsTc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtssaleorder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdjobholetruckin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdpurordertran)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsaleorder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdjobholetruckout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdhistorytruckin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdhistorytruckOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbonholdtruckinBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bdtranreplyFsTc;
        private dtssaleorder dtssaleorder;
        private System.Windows.Forms.BindingSource bdjobholetruckin;
        private System.Windows.Forms.BindingSource bdpurordertran;
        private System.Windows.Forms.BindingSource bdsaleorder;
        private System.Windows.Forms.BindingSource bdjobholetruckout;
        private System.Windows.Forms.BindingSource bdhistorytruckin;
        private System.Windows.Forms.BindingSource bdhistorytruckOut;
        private System.Windows.Forms.BindingSource dbonholdtruckinBindingSource;
    }
}