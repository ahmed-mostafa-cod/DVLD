namespace projectDVLD.Licenses_Local_and_International.LocalLicenses.Controls
{
    partial class ctrlDriverLicenses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabeControl = new System.Windows.Forms.TabControl();
            this.tpPage1 = new System.Windows.Forms.TabPage();
            this.tpPage2 = new System.Windows.Forms.TabPage();
            this.dgvLocalDrivingLicenses = new System.Windows.Forms.DataGridView();
            this.dgvInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLocalCountRecord = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblInternationalCountRecord = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmsLocalLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsInternationalLicense = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tabeControl.SuspendLayout();
            this.tpPage1.SuspendLayout();
            this.tpPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).BeginInit();
            this.cmsLocalLicenses.SuspendLayout();
            this.cmsInternationalLicense.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabeControl);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1078, 387);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // tabeControl
            // 
            this.tabeControl.Controls.Add(this.tpPage1);
            this.tabeControl.Controls.Add(this.tpPage2);
            this.tabeControl.Location = new System.Drawing.Point(0, 41);
            this.tabeControl.Name = "tabeControl";
            this.tabeControl.SelectedIndex = 0;
            this.tabeControl.Size = new System.Drawing.Size(1075, 343);
            this.tabeControl.TabIndex = 0;
            // 
            // tpPage1
            // 
            this.tpPage1.Controls.Add(this.lblLocalCountRecord);
            this.tpPage1.Controls.Add(this.label2);
            this.tpPage1.Controls.Add(this.label1);
            this.tpPage1.Controls.Add(this.dgvLocalDrivingLicenses);
            this.tpPage1.Location = new System.Drawing.Point(4, 30);
            this.tpPage1.Name = "tpPage1";
            this.tpPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tpPage1.Size = new System.Drawing.Size(1067, 309);
            this.tpPage1.TabIndex = 0;
            this.tpPage1.Text = "Local";
            this.tpPage1.UseVisualStyleBackColor = true;
            // 
            // tpPage2
            // 
            this.tpPage2.Controls.Add(this.lblInternationalCountRecord);
            this.tpPage2.Controls.Add(this.label5);
            this.tpPage2.Controls.Add(this.label3);
            this.tpPage2.Controls.Add(this.dgvInternationalLicenses);
            this.tpPage2.Location = new System.Drawing.Point(4, 30);
            this.tpPage2.Name = "tpPage2";
            this.tpPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tpPage2.Size = new System.Drawing.Size(1067, 309);
            this.tpPage2.TabIndex = 1;
            this.tpPage2.Text = "International";
            this.tpPage2.UseVisualStyleBackColor = true;
            // 
            // dgvLocalDrivingLicenses
            // 
            this.dgvLocalDrivingLicenses.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicenses.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDrivingLicenses.ContextMenuStrip = this.cmsLocalLicenses;
            this.dgvLocalDrivingLicenses.Location = new System.Drawing.Point(30, 50);
            this.dgvLocalDrivingLicenses.Name = "dgvLocalDrivingLicenses";
            this.dgvLocalDrivingLicenses.ReadOnly = true;
            this.dgvLocalDrivingLicenses.RowHeadersWidth = 51;
            this.dgvLocalDrivingLicenses.RowTemplate.Height = 26;
            this.dgvLocalDrivingLicenses.Size = new System.Drawing.Size(1031, 181);
            this.dgvLocalDrivingLicenses.TabIndex = 0;
            // 
            // dgvInternationalLicenses
            // 
            this.dgvInternationalLicenses.AllowUserToAddRows = false;
            this.dgvInternationalLicenses.AllowUserToDeleteRows = false;
            this.dgvInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenses.ContextMenuStrip = this.cmsInternationalLicense;
            this.dgvInternationalLicenses.Location = new System.Drawing.Point(25, 65);
            this.dgvInternationalLicenses.Name = "dgvInternationalLicenses";
            this.dgvInternationalLicenses.ReadOnly = true;
            this.dgvInternationalLicenses.RowHeadersWidth = 51;
            this.dgvInternationalLicenses.RowTemplate.Height = 26;
            this.dgvInternationalLicenses.Size = new System.Drawing.Size(1039, 163);
            this.dgvInternationalLicenses.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label1.Location = new System.Drawing.Point(24, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local Licenses History:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label2.Location = new System.Drawing.Point(25, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "# Records:";
            // 
            // lblLocalCountRecord
            // 
            this.lblLocalCountRecord.AutoSize = true;
            this.lblLocalCountRecord.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblLocalCountRecord.Location = new System.Drawing.Point(162, 257);
            this.lblLocalCountRecord.Name = "lblLocalCountRecord";
            this.lblLocalCountRecord.Size = new System.Drawing.Size(37, 24);
            this.lblLocalCountRecord.TabIndex = 3;
            this.lblLocalCountRecord.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label3.Location = new System.Drawing.Point(19, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(374, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "International Licenses History:";
            // 
            // lblInternationalCountRecord
            // 
            this.lblInternationalCountRecord.AutoSize = true;
            this.lblInternationalCountRecord.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblInternationalCountRecord.Location = new System.Drawing.Point(157, 265);
            this.lblInternationalCountRecord.Name = "lblInternationalCountRecord";
            this.lblInternationalCountRecord.Size = new System.Drawing.Size(37, 24);
            this.lblInternationalCountRecord.TabIndex = 5;
            this.lblInternationalCountRecord.Text = "???";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label5.Location = new System.Drawing.Point(20, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "# Records:";
            // 
            // cmsLocalLicenses
            // 
            this.cmsLocalLicenses.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmsLocalLicenses.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.cmsLocalLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseToolStripMenuItem});
            this.cmsLocalLicenses.Name = "cmsLocalLicenses";
            this.cmsLocalLicenses.Size = new System.Drawing.Size(224, 50);
            // 
            // cmsInternationalLicense
            // 
            this.cmsInternationalLicense.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmsInternationalLicense.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.cmsInternationalLicense.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseToolStripMenuItem1});
            this.cmsInternationalLicense.Name = "contextMenuStrip2";
            this.cmsInternationalLicense.Size = new System.Drawing.Size(235, 78);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::projectDVLD.Properties.Resources.Driver_License_481;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(234, 46);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // showLicenseToolStripMenuItem1
            // 
            this.showLicenseToolStripMenuItem1.Image = global::projectDVLD.Properties.Resources.Driver_License_481;
            this.showLicenseToolStripMenuItem1.Name = "showLicenseToolStripMenuItem1";
            this.showLicenseToolStripMenuItem1.Size = new System.Drawing.Size(234, 46);
            this.showLicenseToolStripMenuItem1.Text = "Show License";
            this.showLicenseToolStripMenuItem1.Click += new System.EventHandler(this.showLicenseToolStripMenuItem1_Click);
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(1087, 390);
            this.Load += new System.EventHandler(this.ctrlDriverLicenses_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabeControl.ResumeLayout(false);
            this.tpPage1.ResumeLayout(false);
            this.tpPage1.PerformLayout();
            this.tpPage2.ResumeLayout(false);
            this.tpPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).EndInit();
            this.cmsLocalLicenses.ResumeLayout(false);
            this.cmsInternationalLicense.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabeControl;
        private System.Windows.Forms.TabPage tpPage1;
        private System.Windows.Forms.TabPage tpPage2;
        private System.Windows.Forms.DataGridView dgvLocalDrivingLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvInternationalLicenses;
        private System.Windows.Forms.Label lblLocalCountRecord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInternationalCountRecord;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip cmsLocalLicenses;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalLicense;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem1;
    }
}
