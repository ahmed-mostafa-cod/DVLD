using BusinessLayer;
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

namespace projectDVLD.Drivers
{
    public partial class frmListDrivers : Form
    {
        DataTable dtListDrivers;
        public frmListDrivers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            dtListDrivers=clsDriver.GetAllDrivers();
            dgvListDrivers.DataSource = dtListDrivers;
            lblCountRecord.Text=dgvListDrivers.Rows.Count.ToString();
            cbFilter.SelectedIndex = 0;

            if (dgvListDrivers.Rows.Count > 0)
            {
                dgvListDrivers.Columns[0].HeaderText = "Driver ID";
                dgvListDrivers.Columns[0].Width= 100;

                dgvListDrivers.Columns[1].HeaderText = "Person ID";
                dgvListDrivers.Columns[1].Width= 100;

                dgvListDrivers.Columns[2].HeaderText = "National No.";
                dgvListDrivers.Columns[2].Width= 100;

                dgvListDrivers.Columns[3].HeaderText = "Full Name";
                dgvListDrivers.Columns[3].Width = 300;

                dgvListDrivers.Columns[4].HeaderText = "Date";
                dgvListDrivers.Columns[4].Width = 200;

                dgvListDrivers.Columns[5].HeaderText = "Active Licenses";
                dgvListDrivers.Columns[5].Width = 100;
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text == "None")
            {
                txtFilter.Visible = false;
            }
            else
            {
                txtFilter.Focus();
                txtFilter.Visible = true;
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch(cbFilter.Text)
            {
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Date":
                    FilterColumn = "Date";
                    break;
                case "Active Licenses":
                    FilterColumn = "ActiveLicenses";
                    break;
                default:
                    FilterColumn = "None";
                    break;
                    
            }
            if(txtFilter.Text.Trim()==""||FilterColumn=="None")
            {
                dtListDrivers.DefaultView.RowFilter = "";
                lblCountRecord.Text=dgvListDrivers.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "DriverID" || FilterColumn == "PersonID" || FilterColumn == "ActiveLicenses")
            {
                dtListDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            }
            else
                dtListDrivers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());

            lblCountRecord.Text=dgvListDrivers.Rows.Count.ToString() ;
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilter.Text=="Driver ID"||cbFilter.Text =="Person ID"||cbFilter.Text=="Active Licenses")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvListDrivers.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory((int)dgvListDrivers.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }
    }
}
