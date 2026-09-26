using BusinessLayer;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace projectDVLD.Applications.Licenses.Local_License
{
    public partial class frmAddUpdateLocalLicenseApplication : Form
    {
        enum enMode { Add=0, Update=1 };
        enMode Mode = enMode.Add;
       

        clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication;
        private int LocalDrivingLicenseApplicationID = -1;
        private int SeletedPersonID;
        public frmAddUpdateLocalLicenseApplication()
        {
            InitializeComponent();
            Mode = enMode.Add;
        }

        public frmAddUpdateLocalLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            this.LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            Mode = enMode.Update;
        }
        private void  _ResetDefaultValues()
         {
            _FillComboBox();
           
            
                
               


            if (Mode == enMode.Add)
            {
                lblTitle.Text = "New Driving License Application";
                this.Text = "New Driving License";
                LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                btnSave.Enabled = false;
                tpPage2.Enabled = false;
                ctrlPersonCardWithFilter2.FilterFocus();
                lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.NewDrivingLicense).ApplicationFees.ToString();
                lblDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedByUser.Text = clsGOLBAL.user.UserName;
                cbLicenseClasses.SelectedIndex = 2;
            }
            else
            {
                lblTitle.Text = "Update Local Driving License";
                this.Text = "Update License";
                btnSave.Enabled = true;
                tpPage2.Enabled = true;

            }
               
          
        }

        private void _LoadDate()
        {
            ctrlPersonCardWithFilter2.FilterEnabled = false;
            LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingApplicationID(LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(LocalDrivingLicenseApplication.ApplicantPersonID);
            lblLocalApplicationID.Text = LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDate.Text = LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            cbLicenseClasses.SelectedIndex = cbLicenseClasses.FindString(clsLicenseClass.Find(LocalDrivingLicenseApplication.LicenseClassID).ClassName);
            lblApplicationFees.Text = LocalDrivingLicenseApplication.PaidFees.ToString();
            
            lblCreatedByUser.Text = clsUser.FindByUserID(LocalDrivingLicenseApplication.CreatedByUserID).UserName;

        }
        private void _FillComboBox()
        {
            DataTable dt=clsLicenseClass.GetAllLicenseClasses();
            foreach (DataRow dr in dt.Rows)
            {
                cbLicenseClasses.Items.Add(dr["ClassName"]);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

           if(Mode==enMode.Update)
            {

                tpPage2.Enabled = true;
                btnSave.Enabled = true;
                tcLocalLicense.SelectedTab = tcLocalLicense.TabPages[1];
                return;
            }
           if(ctrlPersonCardWithFilter2.PersonID!=-1)
            {
                if(clsPerson.isPersonExist(ctrlPersonCardWithFilter2.PersonID))
                {
                  
                    tpPage2.Enabled = true;
                    btnSave.Enabled = true;
                    tcLocalLicense.SelectedTab = tcLocalLicense.TabPages[1];
                  
                }
                else
                {
                    MessageBox.Show("The Person is not found in System, Please check in the person Person first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFilter2.FilterFocus();
                    return;

                }
            }
           else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter2.FilterFocus();
            }
           
        }

        private void frmNewLocalLicense_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (Mode == enMode.Update)
                _LoadDate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           int LicenseClass=clsLicenseClass.Find(cbLicenseClasses.Text).LicenseClassID;

            int IsActive = clsApplications.GetActiveApplicationIDForLicenseClass(SeletedPersonID, clsApplications.enApplicationType.NewDrivingLicense, LicenseClass);
            if(IsActive != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + IsActive, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClasses.Focus();
                return;
            }
            LocalDrivingLicenseApplication.ApplicantPersonID = ctrlPersonCardWithFilter2.PersonID;
            LocalDrivingLicenseApplication.ApplicationDate=DateTime.Now;
            LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            LocalDrivingLicenseApplication.ApplicationStatus = clsApplications.enApplicationStatus.New;
            LocalDrivingLicenseApplication.LastStatusDate=DateTime.Now;
            LocalDrivingLicenseApplication.PaidFees=Convert.ToSingle(lblApplicationFees.Text);
            LocalDrivingLicenseApplication.CreatedByUserID = clsGOLBAL.user.UserID;
            LocalDrivingLicenseApplication.LicenseClassID = LicenseClass;

            if (LocalDrivingLicenseApplication.Save()) {
                lblLocalApplicationID.Text = LocalDrivingLicenseApplication.ApplicationID.ToString();
                Mode = enMode.Update;
                lblTitle.Text = "Update Local Driving License Application";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
        
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ctrlPersonCardWithFilter2_OnPersonSelected(int obj)
        {

            SeletedPersonID = obj;
        }

        private void frmNewLocalLicense_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter2.FilterFocus();
        }
    }
}
