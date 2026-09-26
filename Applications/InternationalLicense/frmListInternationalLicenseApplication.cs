using BusinessLayer;
using projectDVLD.Licenses_Local_and_International.International_License;
using projectDVLD.Licenses_Local_and_International.LocalLicenses;
using projectDVLD.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectDVLD.Applications.InternationalLicense
{
    public partial class frmListInternationalLicenseApplication : Form
    {
        private DataTable _dtListAllInternationalLicense;
        public frmListInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmListInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            _dtListAllInternationalLicense=clsInternationalLicense.GetAllInternationalLicenses();
            dgvInternationalLicenses.DataSource= _dtListAllInternationalLicense;
            lblInternationalLicensesRecords.Text=dgvInternationalLicenses.Rows.Count.ToString();
            cbFilterBy.SelectedIndex = 0;
            if (dgvInternationalLicenses.Rows.Count > 0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicenses.Columns[0].Width = 160;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 150;

                dgvInternationalLicenses.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenses.Columns[2].Width = 130;

                dgvInternationalLicenses.Columns[3].HeaderText = "L.License ID";
                dgvInternationalLicenses.Columns[3].Width = 130;

                dgvInternationalLicenses.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[4].Width = 180;

                dgvInternationalLicenses.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[5].Width = 180;

                dgvInternationalLicenses.Columns[6].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[6].Width = 120;

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.Focus();
                cbIsReleased.SelectedIndex = 0;
            }

            else

            {

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsReleased.Visible = false;

                if (cbFilterBy.Text == "None")
                {
                    txtFilterValue.Enabled = false;
                    //_dtDetainedLicenses.DefaultView.RowFilter = "";
                    //lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();

                }
                else
                    txtFilterValue.Enabled = true;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch(cbFilterBy.Text)
            {
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                case "Application ID":
                    FilterColumn = "ApplicationID";
                    break;
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;
                case "Local License ID":
                    FilterColumn = "LocalLicenseID";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }
            if(txtFilterValue.Text.Trim()==""||FilterColumn=="None")
            {
                _dtListAllInternationalLicense.DefaultView.RowFilter = "";
                lblInternationalLicensesRecords.Text=dgvInternationalLicenses.Rows.Count.ToString();
                return;

            }
            _dtListAllInternationalLicense.DefaultView.RowFilter=string.Format("[{0}] = {1}",FilterColumn,txtFilterValue.Text.Trim());
            lblInternationalLicensesRecords.Text=dgvInternationalLicenses.Rows.Count.ToString() ;


        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbIsReleased_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (cbIsReleased.Text)
            {
                case "All":
                    _dtListAllInternationalLicense.DefaultView.RowFilter = "";
                    break;

                case "Yes":
                    
                    _dtListAllInternationalLicense.DefaultView.RowFilter = "IsActive = true";
                    break;

                case "No":
                 
                    _dtListAllInternationalLicense.DefaultView.RowFilter = "IsActive = false";
                    break;
            }

            
            lblInternationalLicensesRecords.Text = _dtListAllInternationalLicense.DefaultView.Count.ToString();
        }

        private void btnNewApplication_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicense frm=new frmNewInternationalLicense();
            frm.ShowDialog();
            frmListInternationalLicenseApplication_Load(null,null);
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsApplications applications = clsApplications.FindBaseApplication((int)dgvInternationalLicenses.CurrentRow.Cells[1].Value);
            if (applications != null)
            {
                frmShowPersonInfo frm = new frmShowPersonInfo(applications.ApplicantPersonID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error the Person is not found", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicense frm=new frmShowInternationalLicense((int)dgvInternationalLicenses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsApplications applications = clsApplications.FindBaseApplication((int)dgvInternationalLicenses.CurrentRow.Cells[1].Value);
            if (applications != null)
            {
                frmLicenseHistory frm = new frmLicenseHistory(applications.ApplicantPersonID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error the Person is not found", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
    
}
