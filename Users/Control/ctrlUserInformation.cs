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

namespace projectDVLD.Users.Control
{
    public partial class ctrlUserInformation : UserControl
    {
        private int _UserID;
        public static clsUser User;
        public int UserID
        {
            get { return _UserID; }
        }
        public ctrlUserInformation()
        {
            InitializeComponent();
        }
        public void LoadUserInformation(int UserID)
        {
            this._UserID = UserID;
            User = clsUser.FindByUserID(UserID);

            if (User == null)
            {
              _ResetPersonInfo();

                MessageBox.Show("No Person with UserID = " + UserID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           _FillUserInfo();
        }
        private void _FillUserInfo()
        {

            ctrlPersonCard1.LoadPersonInfo(User.PersonID);
            lblUserID.Text = User.UserID.ToString();
            lblUserName.Text = User.UserName.ToString();

            if (User.IsActive)
            {

                lblISActive.Text = "Yes";
            }
            else
                lblISActive.Text = "No";

        }

        private void _ResetPersonInfo()
        {

            ctrlPersonCard1.ResetPersonInfo();
            lblUserID.Text = "[???]";
            lblUserName.Text = "[???]";
            lblISActive.Text= "[???]";
        }
        private void ctrlUserInformation_Load(object sender, EventArgs e)
        {

        }
    }
}
