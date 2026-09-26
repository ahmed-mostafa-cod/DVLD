using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectDVLD.Users
{
    public partial class frmShowDetailsUser : Form
    {
        private int _UserID;
        public frmShowDetailsUser(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;

        }

        private void frmShowDetails_Load(object sender, EventArgs e)
        {

            ctrlUserInformation1.LoadUserInformation(_UserID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
