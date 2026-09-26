using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectDVLD.Tests.TestType
{
    public partial class frmScheduleTest : Form
    {
        private int LocalDrivingLicenseApplicationID = -1;
        private clsTestType.enTestType _TestType;
        private int _AppointmentID = -1;
        public frmScheduleTest(int LocalDrivigLicenseApplcationID, clsTestType.enTestType TestTypeID, int AppointmentID=-1)
        {
            InitializeComponent();
            this._TestType = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivigLicenseApplcationID;

            this._AppointmentID = AppointmentID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlSceduleTest1.TestTypeID = this._TestType;
            ctrlSceduleTest1.LoadInfo(LocalDrivingLicenseApplicationID, this._AppointmentID);
        }
    }
}
