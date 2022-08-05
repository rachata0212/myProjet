namespace Truck_Analytics
{
    partial class F_Report
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.QRCodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportData = new Truck_Analytics.ReportData();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dS_Salexsd1 = new Truck_Analytics.DS_Salexsd();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.QRCodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_Salexsd1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // QRCodeBindingSource
            // 
            this.QRCodeBindingSource.DataMember = "QRCode";
            this.QRCodeBindingSource.DataSource = this.ReportData;
            // 
            // ReportData
            // 
            this.ReportData.DataSetName = "ReportData";
            this.ReportData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.DocumentMapWidth = 19;
            reportDataSource1.Name = "ReportData";
            reportDataSource1.Value = this.QRCodeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportViewer1.Name = "reportViewer1";
            //this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(941, 554);
            this.reportViewer1.TabIndex = 3;
            // 
            // dS_Salexsd1
            // 
            this.dS_Salexsd1.DataSetName = "DS_Salexsd";
            this.dS_Salexsd1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "QR_Sale";
            this.bindingSource1.DataSource = this.dS_Salexsd1;
            // 
            // F_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 554);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "F_Report";
            this.Text = "F_Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.F_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QRCodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_Salexsd1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Diagnostics.EventLog eventLog1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource QRCodeBindingSource;
        private ReportData ReportData;
        private DS_Salexsd dS_Salexsd1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}