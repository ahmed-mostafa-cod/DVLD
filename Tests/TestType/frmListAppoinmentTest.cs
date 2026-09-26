using BusinessLayer;
using projectDVLD.Properties;
using System;
using System.Data;
using System.Windows.Forms;

namespace projectDVLD.Tests.TestType
{
    public partial class frmListAppoinmentTest : Form
    {
        private DataTable _dtAppointment;
        private int _LocalDrivingLicenseApplicationID = -1;
       clsTestType.enTestType TestTypeID = clsTestType.enTestType.VisionTest;


        public clsTestType.enTestType TestType
        {
            get
            {
                return TestTypeID;
            }
            set
            {
                TestTypeID=value;
                switch (TestTypeID)
                {

                    case clsTestType.enTestType.VisionTest:
                        pbTestType.Image = Resources.Vision_512;
                        lblTestType.Text = "Vision Test";
                        this.Text=lblTestType.Text;
                        break;
                    case clsTestType.enTestType.WrittenTest:
                        pbTestType.Image = Resources.Written_Test_512;
                        lblTestType.Text = "Written Test";
                        this.Text=lblTestType.Text;
                        break;

                    case clsTestType.enTestType.StreetTest:
                        pbTestType.Image = Resources.driving_test_512;
                        lblTestType.Text = "Street Test";
                        this.Text=lblTestType.Text;
                        break;
                }
            }
        }
        public frmListAppoinmentTest(int LocalDrivingLicenseApplicationID,clsTestType.enTestType TestType)
        {
            InitializeComponent();
            this._LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            this.TestType= TestType;

            ctrlDrivingLicenseApplicationInfo2.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingApplicationID(_LocalDrivingLicenseApplicationID);

            if (localDrivingLicenseApplication.IsThereAnActiveScheduledTest(TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTest LastTest = localDrivingLicenseApplication.GetLastTestPerTestType(TestType);

            if(LastTest ==null)
            {
                frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, TestTypeID);
                frm.ShowDialog();
                frmListAppoinmentTest_Load(null, null);
            }

            //if(LastTest.TestResult==true)
            //{
            //    MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            frmScheduleTest frm2 = new frmScheduleTest(_LocalDrivingLicenseApplicationID, TestTypeID);
            frm2.ShowDialog();
            frmListAppoinmentTest_Load(null, null);
        }

        private void frmListAppoinmentTest_Load(object sender, EventArgs e)
        {
            _dtAppointment = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, TestTypeID);
            dgvAppointmentTest.DataSource = _dtAppointment;
            lblCountRecourd.Text=dgvAppointmentTest.Rows.Count.ToString();

            

            if (dgvAppointmentTest.Rows.Count > 0)
            {
                dgvAppointmentTest.Columns[0].HeaderText = "Appointment ID";
                dgvAppointmentTest.Columns[0].Width = 150;

                dgvAppointmentTest.Columns[1].HeaderText = "Appointment Date";
                dgvAppointmentTest.Columns[1].Width = 200;

                dgvAppointmentTest.Columns[2].HeaderText = "Paid Fees";
                dgvAppointmentTest.Columns[2].Width = 150;

                dgvAppointmentTest.Columns[3].HeaderText = "Is Locked";
                dgvAppointmentTest.Columns[3].Width = 120;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsTestAppointment TestAppointment = clsTestAppointment.Find((int)dgvAppointmentTest.CurrentRow.Cells[0].Value);

            if( TestAppointment.IsLocked )
            {
                MessageBox.Show("The Person Is Locked Test Appointment Please Choose the new Appointment ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, TestTypeID, (int)dgvAppointmentTest.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmListAppoinmentTest_Load(null, null); 
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest frm = new frmTakeTest((int)dgvAppointmentTest.CurrentRow.Cells[0].Value, TestTypeID);
            frm.ShowDialog();
            frmListAppoinmentTest_Load(null, null);
        }

        private void ctrlDrivingLicenseApplicationInfo2_Load(object sender, EventArgs e)
        {

        }
    }
}
