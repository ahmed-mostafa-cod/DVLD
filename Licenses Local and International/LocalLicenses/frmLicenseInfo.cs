using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectDVLD.Licenses_Local_and_International.LocalLicenses
{
    public partial class frmLicenseInfo : Form
    {
        private int _LicenseID = -1;

        public frmLicenseInfo(int LicenseID)
        {
            InitializeComponent();
             _LicenseID=LicenseID; 
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfo1.LoadInfo(_LicenseID);
        }
    }
}
