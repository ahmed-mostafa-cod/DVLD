using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectDVLD.Licenses_Local_and_International.LocalLicenses.Controls
{
    public partial class ctrlDriverLicenses : UserControl
    {
        DataTable dtLocalLicenses;
        DataTable dtInternationalLicense;
        private int _DriverID;
        private clsDriver _Driver;
        public void LoadInfo(int DriverID)
        {
            _DriverID=DriverID;
            _Driver=clsDriver.FindByDriverID(DriverID);

           
            if (_Driver == null)
            {
                MessageBox.Show("Error The Driver not Found ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();


        }

        public void LoadInfoByPersonID(int PersonID)
        {

            _Driver = clsDriver.FindByPersonID(PersonID);
            if (_Driver != null)
            {
                _DriverID = clsDriver.FindByPersonID(PersonID).DriverID;
            }

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();
        }
        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }
    
        private void _LoadLocalLicenseInfo()
        {
            dtLocalLicenses = clsLicense.GetDriverLicenses(_DriverID);

            dgvLocalDrivingLicenses.DataSource = dtLocalLicenses;
            lblLocalCountRecord.Text = dgvLocalDrivingLicenses.Rows.Count.ToString();
            if (dgvLocalDrivingLicenses.Rows.Count > 0)
            {
                dgvLocalDrivingLicenses.Columns[0].HeaderText = "Licenses ID";
                dgvLocalDrivingLicenses.Columns[0].Width = 90;

                dgvLocalDrivingLicenses.Columns[1].HeaderText = "App.ID";
                dgvLocalDrivingLicenses.Columns[1].Width = 90;

                dgvLocalDrivingLicenses.Columns[2].HeaderText = "Class Name";
                dgvLocalDrivingLicenses.Columns[2].Width = 230;

                dgvLocalDrivingLicenses.Columns[3].HeaderText = "Issue Date";
                dgvLocalDrivingLicenses.Columns[3].Width = 180;

                dgvLocalDrivingLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvLocalDrivingLicenses.Columns[4].Width = 180;

                dgvLocalDrivingLicenses.Columns[5].HeaderText = "Is Active";
                dgvLocalDrivingLicenses.Columns[5].Width = 100;

            }
        }
        private void _LoadInternationalLicenseInfo()
        {
            dtInternationalLicense = clsInternationalLicense.GetDriverInternationalLicenses(_DriverID);
            dgvInternationalLicenses.DataSource = dtInternationalLicense;
            lblInternationalCountRecord.Text = dgvInternationalLicenses.Rows.Count.ToString();

            if (dgvInternationalLicenses.Rows.Count > 0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicenses.Columns[0].Width = 120;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 110;

                dgvInternationalLicenses.Columns[2].HeaderText = "L.LicenseID";
                dgvInternationalLicenses.Columns[2].Width = 120;

                dgvInternationalLicenses.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[3].Width = 200;

                dgvInternationalLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[4].Width = 200;

                dgvInternationalLicenses.Columns[5].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[0].Width = 100;
            }
        }
        public void Clear()
        {
           dtLocalLicenses.Clear();
            dtInternationalLicense.Clear();

        }

        private void ctrlDriverLicenses_Load(object sender, EventArgs e)
        {
          
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseInfo frm=new frmLicenseInfo((int)dgvLocalDrivingLicenses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
