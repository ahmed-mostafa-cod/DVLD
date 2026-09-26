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
    public partial class frmListApplicationType : Form
    {

        private int _ApplicationID=-1;
        clsApplicationTypes _Application;

        DataTable _dtAllApplicationTypes=clsApplicationTypes.GetAllApplicationType();
        public frmListApplicationType()
        {
            InitializeComponent();
            
        }

        private void frmListApplicationType_Load(object sender, EventArgs e)
        {
             _dtAllApplicationTypes = clsApplicationTypes.GetAllApplicationType();
            dgvApplicationTypes.DataSource = _dtAllApplicationTypes;
            lblCountRecourd.Text=dgvApplicationTypes.Rows.Count.ToString();
            if(dgvApplicationTypes.Rows.Count > 0 )
            {
                dgvApplicationTypes.Columns[0].HeaderText = "ID";
                dgvApplicationTypes.Columns[0].Width = 120;

                dgvApplicationTypes.Columns[1].HeaderText = "Title";
                dgvApplicationTypes.Columns[1].Width = 300;

                dgvApplicationTypes.Columns[2].HeaderText = "Fees";
                dgvApplicationTypes.Columns[2].Width = 120;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationType frm=new frmEditApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListApplicationType_Load(null, null);
        }
    }
}
