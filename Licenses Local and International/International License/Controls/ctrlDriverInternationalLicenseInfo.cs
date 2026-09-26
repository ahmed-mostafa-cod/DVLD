using BusinessLayer;
using projectDVLD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectDVLD.Licenses_Local_and_International.International_License.Controls
{
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {
        private int _InternationalLicenseID = -1;


       
        private clsInternationalLicense _InternationalLicense;

        public clsInternationalLicense SelectedInternationalSelectedInfo
        {
            get {  return _InternationalLicense; }
        }
        public int InternationalLicenseID
        {
            get { return _InternationalLicenseID; }
        }
      
        public void LoadInfo(int InternationalLicenseID)
        {
            _InternationalLicenseID=InternationalLicenseID;
            _InternationalLicense =clsInternationalLicense.Find(_InternationalLicenseID);
            if (_InternationalLicense == null)
            {
                MessageBox.Show("Could not find Internationa License ID = " + _InternationalLicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _InternationalLicenseID = -1;
                return;
            }
            _FillData();

        }

        private void _FillData()
        {
            lblFullName.Text = _InternationalLicense.ApplicationFullName();
            lblInternationalLicenseID.Text=_InternationalLicenseID.ToString();
            lblNationalNo.Text=_InternationalLicense.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text=(_InternationalLicense.DriverInfo.PersonInfo.Gendor==0)?"Male":"Female";
            lblIsActive.Text = (_InternationalLicense.IsActive == true) ? "True" : "False";
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToString("dd/MMM/yyyy");
            lblApplicationID.Text= _InternationalLicense.ApplicationID.ToString();
            lblDateOfBirth.Text = _InternationalLicense.DriverInfo.PersonInfo.DateOfBirth.ToString("dd/MMM/yyyy");
            lblDriverID.Text=_InternationalLicense.DriverID.ToString();
            lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToString("dd/MMM/yyyy");
            lblLocalLicenseID.Text=_InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            HandleImage();
        }
        private void HandleImage()
        {
            if (_InternationalLicense.DriverInfo.PersonInfo.Gendor == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;
            string ImagePath = _InternationalLicense.DriverInfo.PersonInfo.ImagePath;
            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                {
                    pbPersonImage.Load(ImagePath);
                }
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }
    }
}
