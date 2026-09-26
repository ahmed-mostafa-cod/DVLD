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

namespace projectDVLD.Login
{
    public partial class frmLogin : Form
    {
        private clsUser User;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "";
            string Password = "";
            if (clsGOLBAL.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
            {
                chkRememberMe.Checked = false;
            }
        }

        private void frmLogin_Resize(object sender, EventArgs e)
        {
            panel1.Width=this.ClientSize.Width/2;
           
            panel2.Width=this.ClientSize.Width/2;
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User = clsUser.FindByUserNameAndPassword(txtUserName.Text.Trim(),txtPassword.Text.Trim());
            if(User !=null)
            {

                if(chkRememberMe.Checked)
                {
                    clsGOLBAL.RemmemberUserNameAndPassword(txtUserName.Text.Trim() ,txtPassword.Text.Trim());

                }
                else
                {
                    clsGOLBAL.RemmemberUserNameAndPassword("", "");
                }
                if(!User.IsActive)
                {
                    txtUserName.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                clsGOLBAL.user= User;
                    this.Hide();

                frmMain frm = new frmMain(this);
                frm.ShowDialog();
               
            }
            else
            {
                MessageBox.Show("Invalid Username/Password.", "Wrong Credentials", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
