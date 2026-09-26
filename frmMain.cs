using projectDVLD.Applications.ApplicationTypes;
using projectDVLD.Applications.Licenses.Local_Driving_License;
using projectDVLD.Applications.Licenses.Local_License;
using projectDVLD.Applications.ManageTest;
using projectDVLD.DetainLicenses;
using projectDVLD.Drivers;
using projectDVLD.Login;
using projectDVLD.People;
using projectDVLD.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectDVLD
{
    public partial class frmMain : Form
    {
        frmLogin _femLogin;
        public frmMain(frmLogin login)
        {
            InitializeComponent();
            _femLogin = login;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            People.frmListPeople frm = new People.frmListPeople();
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGOLBAL.user = null;
            _femLogin.Show();
            this.Close();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListUser frm = new frmListUser();
            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowDetailsUser frm = new frmShowDetailsUser(clsGOLBAL.user.UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm=new frmChangePassword(clsGOLBAL.user.UserID);
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListManageTest frm=new frmListManageTest();
            frm.ShowDialog();

        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListApplicationType frm = new frmListApplicationType();
            frm.ShowDialog();
        }

        private void newDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
          Applications. Licenses.Local_License.frmAddUpdateLocalLicenseApplication frm=new Applications.Licenses.Local_License.frmAddUpdateLocalLicenseApplication();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicesnseApplications frm=new frmListLocalDrivingLicesnseApplications();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDrivers frm=new frmListDrivers();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicesnseApplications frm = new frmListLocalDrivingLicesnseApplications();
            frm.ShowDialog();
        }

        private void renewDrivindLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Applications.RenewLocalLicense.frmRenewLocalDrivingLicenseApplication frm = new Applications.RenewLocalLicense.frmRenewLocalDrivingLicenseApplication();
                frm.ShowDialog();
        }

        private void replacementForToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Applications.Replace_Lost_or_Damage.frmReplacementOrDamaged frm=new Applications.Replace_Lost_or_Damage.frmReplacementOrDamaged();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Applications.InternationalLicense.frmListInternationalLicenseApplication frm=new Applications.InternationalLicense.frmListInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void interToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Applications.InternationalLicense.frmNewInternationalLicense frm = new Applications.InternationalLicense.frmNewInternationalLicense();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetainLicenses.frmListDetainedLicenses frm=new DetainLicenses.frmListDetainedLicenses();
            frm.ShowDialog();
        }

        private void detainLicensesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DetainLicenses.frmDetainLicenseApplication frm=new DetainLicenses.frmDetainLicenseApplication();
            frm.ShowDialog();
        }

        private void releaseDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainLicense frm=new frmReleaseDetainLicense();
            frm.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainLicense frm = new frmReleaseDetainLicense();
            frm.ShowDialog();
        }
    }
}
