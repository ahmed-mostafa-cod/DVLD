namespace projectDVLD.Tests.TestType
{
    partial class frmListAppoinmentTest
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
            this.ctrlDrivingLicenseApplicationInfo1 = new projectDVLD.Applications.Licenses.Controls.ctrlDrivingLicenseApplicationInfo();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCountRecourd = new System.Windows.Forms.Label();
            this.lblTestType = new System.Windows.Forms.Label();
            this.dgvAppointmentTest = new System.Windows.Forms.DataGridView();
            this.cmsTest = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlDrivingLicenseApplicationInfo2 = new projectDVLD.Applications.Licenses.Controls.ctrlDrivingLicenseApplicationInfo();
            this.btnAddNewAppointment = new System.Windows.Forms.Button();
            this.pbTestType = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentTest)).BeginInit();
            this.cmsTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlDrivingLicenseApplicationInfo1
            // 
            this.ctrlDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(12, 253);
            this.ctrlDrivingLicenseApplicationInfo1.Name = "ctrlDrivingLicenseApplicationInfo1";
            this.ctrlDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(1106, 403);
            this.ctrlDrivingLicenseApplicationInfo1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label1.Location = new System.Drawing.Point(6, 912);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "# Records:";
            // 
            // lblCountRecourd
            // 
            this.lblCountRecourd.AutoSize = true;
            this.lblCountRecourd.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblCountRecourd.Location = new System.Drawing.Point(133, 917);
            this.lblCountRecourd.Name = "lblCountRecourd";
            this.lblCountRecourd.Size = new System.Drawing.Size(37, 24);
            this.lblCountRecourd.TabIndex = 2;
            this.lblCountRecourd.Text = "???";
            // 
            // lblTestType
            // 
            this.lblTestType.AutoSize = true;
            this.lblTestType.Font = new System.Drawing.Font("Tahoma", 22F);
            this.lblTestType.ForeColor = System.Drawing.Color.Red;
            this.lblTestType.Location = new System.Drawing.Point(303, 194);
            this.lblTestType.Name = "lblTestType";
            this.lblTestType.Size = new System.Drawing.Size(433, 45);
            this.lblTestType.TabIndex = 4;
            this.lblTestType.Text = "Vision Test Appointments";
            // 
            // dgvAppointmentTest
            // 
            this.dgvAppointmentTest.AllowUserToAddRows = false;
            this.dgvAppointmentTest.AllowUserToDeleteRows = false;
            this.dgvAppointmentTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointmentTest.ContextMenuStrip = this.cmsTest;
            this.dgvAppointmentTest.Location = new System.Drawing.Point(11, 713);
            this.dgvAppointmentTest.Name = "dgvAppointmentTest";
            this.dgvAppointmentTest.ReadOnly = true;
            this.dgvAppointmentTest.RowHeadersWidth = 51;
            this.dgvAppointmentTest.RowTemplate.Height = 26;
            this.dgvAppointmentTest.Size = new System.Drawing.Size(1107, 176);
            this.dgvAppointmentTest.TabIndex = 6;
            // 
            // cmsTest
            // 
            this.cmsTest.Font = new System.Drawing.Font("Segoe UI Black", 12F);
            this.cmsTest.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.cmsTest.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.cmsTest.Name = "contextMenuStrip1";
            this.cmsTest.Size = new System.Drawing.Size(204, 96);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::projectDVLD.Properties.Resources.edit_32;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(203, 46);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = global::projectDVLD.Properties.Resources.Test_32;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(203, 46);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label2.Location = new System.Drawing.Point(12, 669);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Appointments:";
            // 
            // ctrlDrivingLicenseApplicationInfo2
            // 
            this.ctrlDrivingLicenseApplicationInfo2.Location = new System.Drawing.Point(11, 242);
            this.ctrlDrivingLicenseApplicationInfo2.Name = "ctrlDrivingLicenseApplicationInfo2";
            this.ctrlDrivingLicenseApplicationInfo2.Size = new System.Drawing.Size(1106, 403);
            this.ctrlDrivingLicenseApplicationInfo2.TabIndex = 9;
            this.ctrlDrivingLicenseApplicationInfo2.Load += new System.EventHandler(this.ctrlDrivingLicenseApplicationInfo2_Load);
            // 
            // btnAddNewAppointment
            // 
            this.btnAddNewAppointment.Image = global::projectDVLD.Properties.Resources.AddAppointment_321;
            this.btnAddNewAppointment.Location = new System.Drawing.Point(1051, 668);
            this.btnAddNewAppointment.Name = "btnAddNewAppointment";
            this.btnAddNewAppointment.Size = new System.Drawing.Size(56, 39);
            this.btnAddNewAppointment.TabIndex = 8;
            this.btnAddNewAppointment.UseVisualStyleBackColor = true;
            this.btnAddNewAppointment.Click += new System.EventHandler(this.btnAddNewAppointment_Click);
            // 
            // pbTestType
            // 
            this.pbTestType.Image = global::projectDVLD.Properties.Resources.Vision_512;
            this.pbTestType.Location = new System.Drawing.Point(378, 2);
            this.pbTestType.Name = "pbTestType";
            this.pbTestType.Size = new System.Drawing.Size(250, 179);
            this.pbTestType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestType.TabIndex = 5;
            this.pbTestType.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnClose.Image = global::projectDVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(986, 917);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 43);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmListAppoinmentTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 1014);
            this.Controls.Add(this.ctrlDrivingLicenseApplicationInfo2);
            this.Controls.Add(this.btnAddNewAppointment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvAppointmentTest);
            this.Controls.Add(this.pbTestType);
            this.Controls.Add(this.lblTestType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblCountRecourd);
            this.Controls.Add(this.label1);
            this.Name = "frmListAppoinmentTest";
            this.Text = "frmListAppoinmentTest";
            this.Load += new System.EventHandler(this.frmListAppoinmentTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentTest)).EndInit();
            this.cmsTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Applications.Licenses.Controls.ctrlDrivingLicenseApplicationInfo ctrlDrivingLicenseApplicationInfo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCountRecourd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTestType;
        private System.Windows.Forms.PictureBox pbTestType;
        private System.Windows.Forms.DataGridView dgvAppointmentTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNewAppointment;
        private Applications.Licenses.Controls.ctrlDrivingLicenseApplicationInfo ctrlDrivingLicenseApplicationInfo2;
        private System.Windows.Forms.ContextMenuStrip cmsTest;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}