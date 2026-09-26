using BusinessLayer;
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

namespace projectDVLD.DetainLicenses
{
    public partial class frmListDetainedLicenses : Form
    {
        DataTable dtDetainLicense;
        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            dtDetainLicense=clsDetainLicense.GetAllDetainedLicenses();
            cbFilterBy.SelectedIndex = 0;
            dgvDetainedLicenses.DataSource = dtDetainLicense;
            lblTotalRecords.Text=dgvDetainedLicenses.Rows.Count.ToString();
            if(dgvDetainedLicenses.Rows.Count > 0 )
            {
                dgvDetainedLicenses.Columns[0].HeaderText = "D.ID";
                dgvDetainedLicenses.Columns[0].Width = 80;

                dgvDetainedLicenses.Columns[1].HeaderText = "L.ID";
                dgvDetainedLicenses.Columns[1].Width = 80;

                dgvDetainedLicenses.Columns[2].HeaderText = "D.Date";
                dgvDetainedLicenses.Columns[2].Width = 170;

                dgvDetainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[3].Width = 90;

                dgvDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[4].Width = 90;

                dgvDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns[5].Width = 170;

                dgvDetainedLicenses.Columns[6].HeaderText = "N.N";
                dgvDetainedLicenses.Columns[6].Width = 80;

                dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[7].Width = 250;

                dgvDetainedLicenses.Columns[8].HeaderText = "Release App.ID";
                dgvDetainedLicenses.Columns[8].Width = 150;
            }
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm= new frmDetainLicenseApplication();
            frm.ShowDialog();
            frmListDetainedLicenses_Load(null, null);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.Text== "Is Released")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = true;
                return;
            }
            else if(cbFilterBy.Text=="None")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = false;
                return;
            }
            else
            {
                txtFilterValue.Visible= true;
                cbIsReleased.Visible = false;
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch(cbFilterBy.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;
                case "Is Released":
                    FilterColumn = "IsReleased";
                     break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }
            if (txtFilterValue.Text.Trim() == "" || FilterColumn=="None")
            {
                dtDetainLicense.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
                return;    
            }

            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
                dtDetainLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                dtDetainLicense.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text== "Release Application ID"||cbFilterBy.Text=="Detain ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            switch(cbIsReleased.Text)
            {
                case "All":
                    dtDetainLicense.DefaultView.RowFilter = "";
                    break;
                case "Yes":
                    dtDetainLicense.DefaultView.RowFilter = "IsReleased = true";
                    break;
                case "No":
                    dtDetainLicense.DefaultView.RowFilter = "IsReleased = false";
                    break;
            }
            lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsPerson Person = clsPerson.Find((string)dgvDetainedLicenses.CurrentRow.Cells[6].Value);
            frmShowPersonInfo frm =new frmShowPersonInfo(Person.PersonID);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Licenses_Local_and_International.LocalLicenses.frmLicenseInfo frm = new Licenses_Local_and_International.LocalLicenses.frmLicenseInfo(
               (int) dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsPerson Person = clsPerson.Find((string)dgvDetainedLicenses.CurrentRow.Cells[6].Value);
            Licenses_Local_and_International.LocalLicenses.frmLicenseHistory frm = new Licenses_Local_and_International.LocalLicenses.frmLicenseHistory(
                Person.PersonID);
            frm.ShowDialog();
        }

        private void cmsDetained_Opening(object sender, CancelEventArgs e)
        {
            releaseDetainedLicenseToolStripMenuItem.Enabled = !(bool)dgvDetainedLicenses.CurrentRow.Cells[3].Value;
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainLicense frm= new frmReleaseDetainLicense((int)dgvDetainedLicenses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListDetainedLicenses_Load(null, null);
        }

        private void btnReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainLicense frm = new frmReleaseDetainLicense();
            frm.ShowDialog();
            frmListDetainedLicenses_Load(null, null);
        }
    }
}
