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

namespace projectDVLD.Applications.ManageTest
{
    public partial class frmEditTestType : Form
    {
        private clsTestType.enTestType _TestTypeID;
        private clsTestType _TestType;
        public frmEditTestType(clsTestType.enTestType ID)
        {
            InitializeComponent();
            _TestTypeID = ID;

        }
        private void _LoadDate()
        { 
            _TestType =clsTestType.Find(_TestTypeID);
            if (_TestType == null)
            {
                MessageBox.Show("The test type is not found in system please concact with customer services", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblID.Text = ((int)_TestType.ID).ToString();
            txtTitle.Text = _TestType.TestTypeTitle;
            txtDescripation.Text = _TestType.TestTypeDescription;
            txtFees.Text=_TestType.TestTypeFees.ToString();
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
            _TestType.TestTypeTitle = txtTitle.Text.Trim();
            _TestType.TestTypeDescription=txtDescripation.Text.Trim();
            _TestType.TestTypeFees=Convert.ToSingle(txtFees.Text.Trim());
            if (_TestType.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _LoadDate();
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

        private void txtDescripation_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescripation.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescripation, "Please write the  test Descripation");
                txtDescripation.Focus();
            }
            else
                errorProvider1.SetError(txtDescripation, "");
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Please write the  test fees");
                txtFees.Focus();
            }
            else
                errorProvider1.SetError(txtFees, "");
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // إلغاء الضغطة ومنع كتابة الحرف
            }
        }
    }
}
