using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectDVLD.Users
{
    public partial class frmAddUpdateUser : Form
    {
        enum enMode { Add=0, Update=1 }
        enMode Mode = enMode.Add;
        private clsUser _User;
        private int UserID = -1;
        
        
        
      
        
        public frmAddUpdateUser()
        {
            InitializeComponent();

            Mode = enMode.Add;
            
        }
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
            Mode = enMode.Update;
           


        }
        private void _ResetDefaultValues()
        {
            if(Mode==enMode.Add)
            {
                lblAddUpdateUser.Text = "Add New User";
                this.Text = "Add New User";
                _User = new clsUser();
                tpLogin.Enabled = false;
                ctrlPersonCardWithFilter2.FilterFocus();
            }
            else
            {
                lblAddUpdateUser.Text = "Update User";
                this.Text = "Update User";
                tpLogin.Enabled = true;
                btnSave.Enabled = true;
            }
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chkIsActive.Checked = true;
        }
        private void _LoadData()
        {
            _User = clsUser.FindByUserID(UserID);
            ctrlPersonCardWithFilter2.FilterEnabled=false;


            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _User, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }
            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            chkIsActive.Checked = _User.IsActive;
            ctrlPersonCardWithFilter2.LoadPersonInfo(_User.PersonID);

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpLogin.Enabled = true;

                tcUserInfo.SelectedTab = tcUserInfo.TabPages[1];
                return;

            }

            if (ctrlPersonCardWithFilter2.PersonID != -1)
            {

                if (clsUser.IsUserExistForPersonID(ctrlPersonCardWithFilter2.PersonID))
                {

                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFilter2.FilterFocus();
                }

                else
                {
                    btnSave.Enabled = true;
                    tpLogin.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages[1];
                }
            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter2.FilterFocus();

            }


        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if(Mode == enMode.Update)
                _LoadData();
        }
        
        private void ctrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            _User.IsActive = chkIsActive.Checked;
            _User.PersonID = ctrlPersonCardWithFilter2.PersonID;
            
            _User.UserName=txtUserName.Text.Trim();
            
                _User.Password = txtPassword.Text.Trim();
            
            
            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                Mode = enMode.Update;
                lblAddUpdateUser.Text = "Update Person";
                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel= true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
                txtConfirmPassword.Focus();

            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
            
                
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }
            
            if(Mode ==enMode.Add)
            {
                if(clsUser.IsUserExists(txtUserName.Text.Trim()))
                {
                    e.Cancel=true;
                    errorProvider1.SetError(txtUserName, "User name is used another user");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                }
            }
            else
            {
                if(_User.UserName != txtUserName.Text.Trim())
                {
                    if (clsUser.IsUserExists(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, null);
                    }
                    ;
                }
            }
            
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
            ;
        }

        private void frmAddUpdateUser_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter2.FilterFocus();
        }
    }
}
