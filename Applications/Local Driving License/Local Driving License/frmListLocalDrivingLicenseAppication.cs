using BusinessLayer;
using projectDVLD.Applications.Licenses.Local_Driving_License;
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
    public partial class frmListLocalDrivingLicesnseApplications : Form
    {
        DataTable _dtAllAplication;
        public frmListLocalDrivingLicesnseApplications()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewLocalDriving_Click(object sender, EventArgs e)
        {
            Licenses.Local_License.frmAddUpdateLocalLicenseApplication frm = new Licenses.Local_License.frmAddUpdateLocalLicenseApplication();
            frm.ShowDialog();
        }

        private void frmListLocalDrivingLicenseAppication_Load(object sender, EventArgs e)
        {
            _dtAllAplication = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLienseApplications();
            dgvLocalDrivingLicenseApplication.DataSource = _dtAllAplication;
            lblRecordCount.Text=dgvLocalDrivingLicenseApplication.Rows.Count.ToString(); 
            if(dgvLocalDrivingLicenseApplication.Rows.Count > 0 )
            {
                dgvLocalDrivingLicenseApplication.Columns[0].HeaderText = "L.D.L.AppID";
                dgvLocalDrivingLicenseApplication.Columns[0].Width = 100;

                dgvLocalDrivingLicenseApplication.Columns[1].HeaderText = "Driving Class";
                dgvLocalDrivingLicenseApplication.Columns[1].Width = 250;

                dgvLocalDrivingLicenseApplication.Columns[2].HeaderText = "National No";
                dgvLocalDrivingLicenseApplication.Columns[2].Width = 100;

                dgvLocalDrivingLicenseApplication.Columns[3].HeaderText = "Full Name";
                dgvLocalDrivingLicenseApplication.Columns[3].Width = 300;

                dgvLocalDrivingLicenseApplication.Columns[4].HeaderText = "Application Date";
                dgvLocalDrivingLicenseApplication.Columns[4].Width = 200;

                dgvLocalDrivingLicenseApplication.Columns[5].HeaderText = "Passed Tests";
                dgvLocalDrivingLicenseApplication.Columns[5].Width = 100;

                dgvLocalDrivingLicenseApplication.Columns[6].HeaderText = "Status";
                dgvLocalDrivingLicenseApplication.Columns[6].Width = 100;
            }
            cbFilterLocalDrivindLicense.SelectedIndex= 0;

        }

        private void cbFilterLocalDrivindLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterLocalDrivindLicense.SelectedIndex == 0)
            {
                txtFilterLocalDrivingLicense.Visible = false;
            }
            else
                txtFilterLocalDrivingLicense.Visible=true;

        }

        private void txtFilterLocalDrivingLicense_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterLocalDrivindLicense.Text)
            {
                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Status":
                    FilterColumn = "Status";
                    break;
                default:
                   FilterColumn= "None";
                    break;
            }
            if(txtFilterLocalDrivingLicense.Text.Trim()==""||FilterColumn=="None")
            {
                _dtAllAplication.DefaultView.RowFilter = "";
                lblRecordCount.Text=dgvLocalDrivingLicenseApplication.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "LocalDrivingLicenseApplicationID")
                _dtAllAplication.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterLocalDrivingLicense.Text.Trim());
            else
                _dtAllAplication.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterLocalDrivingLicense.Text.Trim());

            lblRecordCount.Text=dgvLocalDrivingLicenseApplication.Rows.Count.ToString();

        }

        private void txtFilterLocalDrivingLicense_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterLocalDrivindLicense.Text== "L.D.L.AppID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingApplicationID(LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.Cancel())
                {
                    MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refresh the form again.
                    frmListLocalDrivingLicenseAppication_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not cancel applicatoin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to Delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingApplicationID(LocalDrivingLicenseApplicationID);
            if (LocalDrivingLicenseApplication != null)
            {
                if(LocalDrivingLicenseApplication.Delete())
                {
                    MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refresh the form again.
                    frmListLocalDrivingLicenseAppication_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not Delete applicatoin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value;

            frmAddUpdateLocalLicenseApplication frm =
                         new frmAddUpdateLocalLicenseApplication(LocalDrivingLicenseApplicationID);
            frm.ShowDialog();

            frmListLocalDrivingLicenseAppication_Load(null, null);
        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingApplicationID(LocalDrivingLicenseApplicationID);
            int TotalPassedTests = (int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[5].Value;

            bool LicenseExists = localDrivingLicenseApplication.IsLicenseIssued();
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (TotalPassedTests == 3) && !LicenseExists;
            showLicenseToolStripMenuItem.Enabled = LicenseExists;
            editApplicationToolStripMenuItem.Enabled = !LicenseExists &&(localDrivingLicenseApplication.ApplicationStatus==clsLocalDrivingLicenseApplication.enApplicationStatus.New);
            sechduleTestsToolStripMenuItem.Enabled= !LicenseExists;

            cancelApplicationToolStripMenuItem.Enabled = (localDrivingLicenseApplication.ApplicationStatus == clsLocalDrivingLicenseApplication.enApplicationStatus.New);
            deleteApplicationToolStripMenuItem.Enabled = (localDrivingLicenseApplication.ApplicationStatus == clsLocalDrivingLicenseApplication.enApplicationStatus.New);
            bool PassedVisionTest = localDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest);
            bool PassedWritenTest = localDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest);
            bool PassedStreetTest=localDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.StreetTest);
            sechduleTestsToolStripMenuItem.Enabled = (!PassedVisionTest || !PassedWritenTest || !PassedStreetTest) && (localDrivingLicenseApplication.ApplicationStatus == clsApplications.enApplicationStatus.New);


            if(sechduleTestsToolStripMenuItem.Enabled)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = !PassedVisionTest;
                scheduleWrittenTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWritenTest;
                scheduleStreetTestToolStripMenuItem.Enabled = !PassedStreetTest && PassedWritenTest && PassedVisionTest;
            }

        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tests.TestType.frmListAppoinmentTest frm = new Tests.TestType.frmListAppoinmentTest((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value, clsTestType.enTestType.VisionTest);
            frm.ShowDialog();
            frmListLocalDrivingLicenseAppication_Load(null, null);
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tests.TestType.frmListAppoinmentTest frm = new Tests.TestType.frmListAppoinmentTest((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value, clsTestType.enTestType.WrittenTest);
            frm.ShowDialog();
            frmListLocalDrivingLicenseAppication_Load(null, null);
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tests.TestType.frmListAppoinmentTest frm = new Tests.TestType.frmListAppoinmentTest((int)dgvLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value, clsTestType.enTestType.StreetTest);
            frm.ShowDialog();
            frmListLocalDrivingLicenseAppication_Load(null, null);
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
