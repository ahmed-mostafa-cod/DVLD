using BusinessLayer;
using projectDVLD.Licenses_Local_and_International.LocalLicenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectDVLD.Applications.Replace_Lost_or_Damage
{
    public partial class frmReplacementOrDamaged : Form
    {
        private int _NewLicense = -1;
        public frmReplacementOrDamaged()
        {
            InitializeComponent();
        }

        private void frmReplacementOrDamaged_Load(object sender, EventArgs e)
        {
            rbDamagedLicense.Checked=true;
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblCreatedByUser.Text = clsGOLBAL.user.UserName;
           
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;
            llShowLicenseHistory.Enabled = (SelectedLicenseID != -1);
            if (SelectedLicenseID == -1)
            {
                return;
            }
            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            if (rbDamagedLicense.Checked)
                lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.ReplaceDamagedDrivingLicense).ApplicationFees.ToString();
            else
                lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplications.enApplicationType.ReplaceLostDrivingLicense).ApplicationFees.ToString();

            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " + ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate.ToString("dd/MMM/yyyy")
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;
            }

            //check the license is not Expired.
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;
            }
            btnIssueReplacement.Enabled = true;
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to Replace the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicense.enIssueReason issueReason = (rbDamagedLicense.Checked) ? clsLicense.enIssueReason.DamagedReplacement :
            clsLicense.enIssueReason.LostReplacement;

                clsLicense NewLicense=ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Replace(issueReason,clsGOLBAL.user.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Replace the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            lblApplicationID.Text=NewLicense.ApplicationID.ToString();
            lblRreplacedLicenseID.Text=NewLicense.LicenseID.ToString();
            _NewLicense=NewLicense.LicenseID;
            ctrlDriverLicenseInfoWithFilter1.Enabled = false;
            btnIssueReplacement.Enabled=false;
            llShowLicenseInfo.Enabled = true;
            gpReplacement.Enabled = false;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm=new frmLicenseInfo(_NewLicense);
            frm.ShowDialog();
        }

        private void frmReplacementOrDamaged_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Replacement for Damaged License";
            this.Text = label1.Text;
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Replacement for Lost License";
            this.Text = label1.Text;
        }
    }
}
