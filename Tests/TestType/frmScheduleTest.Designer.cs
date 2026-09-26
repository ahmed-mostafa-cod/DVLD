namespace projectDVLD.Tests.TestType
{
    partial class frmScheduleTest
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
            this.ctrlSceduleTest1 = new projectDVLD.Tests.Controls.ctrlSceduleTest();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlSceduleTest1
            // 
            this.ctrlSceduleTest1.Location = new System.Drawing.Point(12, 12);
            this.ctrlSceduleTest1.Name = "ctrlSceduleTest1";
            this.ctrlSceduleTest1.Size = new System.Drawing.Size(590, 709);
            this.ctrlSceduleTest1.TabIndex = 0;
            this.ctrlSceduleTest1.TestTypeID = BusinessLayer.clsTestType.enTestType.VisionTest;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnClose.Image = global::projectDVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(463, 736);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 44);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 786);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlSceduleTest1);
            this.Name = "frmScheduleTest";
            this.Text = "frmAddNewAppoinment";
            this.Load += new System.EventHandler(this.frmScheduleTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlSceduleTest ctrlSceduleTest1;
        private System.Windows.Forms.Button btnClose;
    }
}