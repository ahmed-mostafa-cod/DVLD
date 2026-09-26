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

namespace projectDVLD.Applications.ApplicationTypes
{
    public partial class frmEditApplicationType : Form
    {
        private int _ApplicationID = -1;
        clsApplicationTypes _ApplicationType;
        public frmEditApplicationType(int ApplictationID)
        {
            InitializeComponent();
            this._ApplicationID = ApplictationID;
        }
        private void _LoadData()
        {
            _ApplicationType = clsApplicationTypes.Find(_ApplicationID);
            if( _ApplicationType == null )
            {
                MessageBox.Show("The Application is not found in system please concact with boss", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblID.Text=_ApplicationType.ApplicationTypeID.ToString();
            txtTitle.Text = _ApplicationType.ApplicationTitle;
            txtFees.Text=_ApplicationType.ApplicationFees.ToString();
        }
        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _ApplicationType.ApplicationTitle = txtTitle.Text.Trim();
            _ApplicationType.ApplicationFees=Convert.ToSingle(txtFees.Text.Trim());

            if(_ApplicationType.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Please write the first test title");
                txtTitle.Focus();
            }
            else
                errorProvider1.SetError(txtTitle, "");
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // إلغاء الضغطة ومنع كتابة الحرف
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Please write the first test fees");
                txtFees.Focus();
            }
            else
                errorProvider1.SetError(txtFees, "");
        }
    }
}
