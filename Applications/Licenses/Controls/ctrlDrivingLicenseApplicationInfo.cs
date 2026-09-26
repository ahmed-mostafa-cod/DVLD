using BusinessLayer;
using projectDVLD.Licenses_Local_and_International.LocalLicenses;
using projectDVLD.People;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace projectDVLD.Applications.Licenses.Controls
{
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private int _LocalDrivingLicenseApplicationID = -1;
        private int _LicenseID = -1;

        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }

        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplicationInfo
        {
            get { return _LocalDrivingLicenseApplication; }
        }

        public int ApplicationID
        {
            get
            {
                return (_LocalDrivingLicenseApplication != null) ? _LocalDrivingLicenseApplication.ApplicationID : -1;
            }
        }

        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingApplicationID(LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();
                MessageBox.Show("No Application with LocalDrivingLicenseApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseApplicationInfo();
        }

        public void LoadApplicationInfoByApplicationID(int ApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByApplicationID(ApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseApplicationInfo();
        }

        private void _FillLocalDrivingLicenseApplicationInfo()
        {
            _LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();

            // Enable license link if license exists
            llShowLicenseInfo.Enabled = (_LicenseID != -1);

            lblDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedForLicense.Text = clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID)?.ClassName ?? "[N/A]";
            lblPassedTest.Text = _LocalDrivingLicenseApplication.GetPassedTestCount().ToString() + "/3";

            ctrlApplicationBasicInfo2.LoadApplicationInfo(_LocalDrivingLicenseApplication.ApplicationID);
        }

        private void _ResetLocalDrivingLicenseApplicationInfo()
        {
            _LocalDrivingLicenseApplicationID = -1;
            _LicenseID = -1;

            ctrlApplicationBasicInfo1.ResetApplicationInfo();
            lblDLAppID.Text = "[????]";
            lblAppliedForLicense.Text = "[????]";
            lblPassedTest.Text = "0/3";
            llShowLicenseInfo.Enabled = false;
        }

        private void llShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_LicenseID);
            frm.ShowDialog();
        }

        private void ctrlDrivingLicenseApplicationInfo2_Load(object sender, EventArgs e)
        {
            // Prevent execution during design mode in Visual Studio
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;
        }

        private void ctrlApplicationBasicInfo2_Load(object sender, EventArgs e)
        {

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_LicenseID);
            frm.ShowDialog();
        }
    }
}