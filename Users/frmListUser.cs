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

namespace projectDVLD.Users
{
    public partial class frmListUser : Form
    {
        private static DataTable _GetAllUser = clsUser.GetAllUser();
        
        private void _RefreshListUserLoad()
        {
            _GetAllUser = clsUser.GetAllUser();
            lblRecordUser.Text=dgvListUser.Rows.Count.ToString();
        }

        public frmListUser()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this .Close();
        }

        private void frmListUser_Load(object sender, EventArgs e)
        {
            _GetAllUser=clsUser.GetAllUser();
            dgvListUser.DataSource = _GetAllUser;

            lblRecordUser.Text=dgvListUser.Rows.Count.ToString() ;
            cbFilterByUser.SelectedIndex = 0 ;
            if (dgvListUser.Rows.Count > 0)
            {
                dgvListUser.Columns[0].HeaderText = "User ID";
                dgvListUser.Columns[0].Width = 110;

                dgvListUser.Columns[1].HeaderText = "Person ID";
                dgvListUser.Columns[1].Width = 100;

                dgvListUser.Columns[2].HeaderText = "Full Name";
                dgvListUser.Columns[2].Width = 300;

                dgvListUser.Columns[3].HeaderText = "User Name";
                dgvListUser.Columns[3].Width = 200;

                dgvListUser.Columns[4].HeaderText = "Is Active";
                dgvListUser.Columns[4].Width = 110;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch(cbFilterByUser.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "User Name":
                    FilterColumn = "UserName";
                    break;
                case "Is Active":
                    FilterColumn = "IsActive";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

           

            if (txtFilterUser.Text==""||FilterColumn=="None")
            {
                _GetAllUser.DefaultView.RowFilter = "";
                lblRecordUser.Text = dgvListUser.Rows.Count.ToString();
                return;
            }

            if(FilterColumn =="PersonID"||FilterColumn =="UserID")
            {
                _GetAllUser.DefaultView.RowFilter=string.Format("[{0}] = {1}",FilterColumn, txtFilterUser.Text.Trim());
            }
           
            else
                _GetAllUser.DefaultView.RowFilter=string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterUser.Text.Trim());

            lblRecordUser.Text=dgvListUser.Rows.Count.ToString();

        }

        private void cbFilterByUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterUser.Visible = (cbFilterByUser.Text != "None") && (cbFilterByUser.Text != "Is Active");
            if (cbFilterByUser.Text == "Is Active")
            {
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
                return; // الخروج فوراً دون الحاجة لفحص التكست بوكس
            }
            if (txtFilterUser.Visible)
            {
                txtFilterUser.Text = "";
                txtFilterUser.Focus();
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbIsActive.Text)
            {
                case "Yes":
                    _GetAllUser.DefaultView.RowFilter = "[IsActive] = true";
                    break;

                case "No":
                    _GetAllUser.DefaultView.RowFilter = "[IsActive] = false";
                    break;

                default: // "All"
                    _GetAllUser.DefaultView.RowFilter = "";
                    break;
            }
            lblRecordUser.Text=dgvListUser.Rows.Count.ToString() ;
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmShowDetailsUser frm=new frmShowDetailsUser((int)dgvListUser.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
            frmListUser_Load(null, null);
           
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm=new frmAddUpdateUser((int)dgvListUser.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListUser_Load(null, null);
          
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm= new frmAddUpdateUser();
            frm.ShowDialog();
            frmListUser_Load(null, null);
            
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm=new frmChangePassword((int)dgvListUser.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID=(int)dgvListUser.CurrentRow.Cells [0].Value;

            if (UserID == clsGOLBAL.user.UserID)
            {
                MessageBox.Show("User is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clsUser.Delete(UserID))
            {

                MessageBox.Show("User has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmListUser_Load(null, null);
            }

            else
                MessageBox.Show("User is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void dgvListUser_DoubleClick(object sender, EventArgs e)
        {
            frmShowDetailsUser frm=new frmShowDetailsUser((int)dgvListUser.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void txtFilterUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterByUser.Text=="Person ID"||cbFilterByUser.Text =="User ID")
                e.Handled=!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar);
        }
    }
}
