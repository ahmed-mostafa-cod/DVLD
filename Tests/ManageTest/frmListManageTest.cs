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
    public partial class frmListManageTest : Form
    {
        DataTable _dtAllTestType=clsTestType.GetAllTestTypes();
        public frmListManageTest()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListManageTest_Load(object sender, EventArgs e)
        {
            _dtAllTestType = clsTestType.GetAllTestTypes();
            dgvListTestType.DataSource = _dtAllTestType;
            lblCountRecord.Text=dgvListTestType.Rows.Count.ToString();
            if (dgvListTestType.Rows.Count > 0)
            {
                dgvListTestType.Columns[0].HeaderText = "ID";
                dgvListTestType.Columns[0].Width = 110;

                dgvListTestType.Columns[1].HeaderText = "Title";
                dgvListTestType.Columns[1].Width = 200;

                dgvListTestType.Columns[2].HeaderText= "Description";
                dgvListTestType.Columns[2].Width = 600;

                dgvListTestType.Columns[3].HeaderText = "Fees";
                dgvListTestType.Columns[3].Width = 100;

            }
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestType frm=new frmEditTestType((clsTestType.enTestType)dgvListTestType.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListManageTest_Load(null, null);
        }
    }
}
