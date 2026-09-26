using BusinessLayer;
using projectDVLD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectDVLD.Tests.Controls
{
    public partial class ctrlSceduleTest : UserControl
    {
        enum enMode { Add = 0, Update = 1 }
        enMode Mode = enMode.Add;
        private int _LocalDrivingLicenseAppID = -1;
        public enum enCreationMode { FirstTimeSchedule=0,RetakeTestSchedule=1}
        private enCreationMode _CreationMode= enCreationMode.FirstTimeSchedule;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        private clsTestAppointment _TestAppointment;
        private int _TestAppointmentID = -1;

        public clsTestType.enTestType TestTypeID
        {
            get { return _TestTypeID; }
            set
            {
                _TestTypeID = value;
                switch(_TestTypeID)
                {
                    case clsTestType.enTestType.VisionTest:
                        pbTestTypeImage.Image = Resources.Vision_512;
                        gpTestType.Text = "Vision Test";
                        break;
                    case clsTestType.enTestType.WrittenTest:
                        pbTestTypeImage.Image = Resources.Written_Test_512;
                        gpTestType.Text = "Written Test";
                        break;
                        case clsTestType.enTestType.StreetTest:
                        pbTestTypeImage.Image = Resources.driving_test_512;
                        gpTestType.Text = "Street Test";
                        break;
                }
            }
        }

        public ctrlSceduleTest()
        {
            InitializeComponent();
        }
        public void LoadInfo(int localDrivingLicenseAppID,int AppointmentID=-1)
        {
            if (AppointmentID == -1)
                Mode = enMode.Add;
            else
                Mode = enMode.Update;

                _LocalDrivingLicenseAppID = localDrivingLicenseAppID;
            _TestAppointmentID=AppointmentID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingApplicationID(localDrivingLicenseAppID);
            lblFees.Text=clsTestType.Find(TestTypeID).TestTypeFees.ToString();
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseAppID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            if (_LocalDrivingLicenseApplication.DoesAttendTestType(_TestTypeID))
                _CreationMode = enCreationMode.RetakeTestSchedule;
            else
                _CreationMode = enCreationMode.FirstTimeSchedule;
            
            if(_CreationMode==enCreationMode.RetakeTestSchedule)
            {
                gpTestType.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = "N/A";
                lblRetakeAppFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RetakeTest).ApplicationFees.ToString();
            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lblTitle.Text = "Schedule Test";
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";
            }
            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblFullName.Text = _LocalDrivingLicenseApplication.FullName;

            lblTrial.Text=_LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();

            if(Mode==enMode.Add)
            {
                lblFees.Text=clsTestType.Find(_TestTypeID).TestTypeFees.ToString();
                dtpTestDate.MinDate = DateTime.Now;
                lblRetakeTestAppID.Text = "N/A";
               
                _TestAppointment = new clsTestAppointment();
            }
            else
            {
                if (!_LoadTestAppointmentData())
                    return;
            }
            lblTotalFees.Text=(Convert.ToSingle(lblFees.Text)+Convert.ToSingle(lblRetakeAppFees.Text)).ToString();
            if (!_HandleActiveTestAppointmentConstraint())
                return;

            if(!_HandleAppointmentLockedConstraint()) return;

            if(!_HandlePrviousTestConstraint()) return;


        }
        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (Mode == enMode.Add && clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_LocalDrivingLicenseAppID, _TestTypeID))
            {
                lblUserMessage.Text = "Person Already have an active appointment for this test";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }

            return true;
        }

        private bool _LoadTestAppointmentData()
        {
            _TestAppointment=clsTestAppointment.Find(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _TestAppointmentID.ToString(),
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            if (_TestAppointment.AppointmentDate < DateTime.Now)
            {
                dtpTestDate.MinDate = _TestAppointment.AppointmentDate;
                dtpTestDate.Value = _TestAppointment.AppointmentDate;
            }
            else
            {
                // 2. إذا كان الموعد مستقبليًا، نضبط القيمة أولاً ثم نحدد MinDate
                dtpTestDate.Value = _TestAppointment.AppointmentDate;
                dtpTestDate.MinDate = DateTime.Now;
            }
            if (_TestAppointment.RetakeTestApplicationID==-1)
            {
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID .Text= "N/A";
            }
            else
            {
                lblRetakeAppFees.Text=_TestAppointment.RetakeTestAppInfo.PaidFees.ToString() ;
              
                lblRetakeTestAppID.Text=_TestAppointment.RetakeTestApplicationID.ToString();
                gpTestType.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
            }
            return true;
        }
      
        private bool _HandleAppointmentLockedConstraint()
        {
            if(_TestAppointment.IsLocked)
            {
                lblUserMessage.Enabled = true;
                lblUserMessage.Text = "Person already sat for the test, appointment loacked.";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }
            else
                lblUserMessage.Visible = false;
            return true;
        }

        private bool _HandlePrviousTestConstraint()
        {
            switch (TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    lblUserMessage.Visible = false;
                    return true;
                case clsTestType.enTestType.WrittenTest:
                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest))
                    {

                        lblUserMessage.Text = "Cannot Sechule, vision Test should be passed first";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;
                    }
                    return true;
                case clsTestType.enTestType.StreetTest:
                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest))
                    {
                        lblUserMessage.Text = "Cannot Sechule, Written Test should be passed first";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;
                    }
                    return true;
            }
            return true;

        }

        private bool _HandleRetakeApplication()
        {
            if(Mode==enMode.Add &&_CreationMode==enCreationMode.RetakeTestSchedule)
            {
                clsApplications Application=new clsApplications();

                Application.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                Application.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
                Application.ApplicationDate=DateTime.Now;
                Application.ApplicationTypeID = (int)clsApplications.enApplicationType.RetakeTest;
                Application.LastStatusDate=DateTime.Now;
                Application.PaidFees = clsApplicationTypes.Find((int)clsApplications.enApplicationType.RetakeTest).ApplicationFees;
                Application.CreatedByUserID = clsGOLBAL.user.UserID;

                if (!Application.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = Application.ApplicationID;

            }
            return true;
        }
        private void ctrlSceduleTest_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeApplication())
                return;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.PaidFees=Convert.ToSingle(lblFees.Text);
            _TestAppointment.CreatedByUserID=clsGOLBAL.user.UserID;

            if (_TestAppointment.Save())
            {
                Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


    }
}
