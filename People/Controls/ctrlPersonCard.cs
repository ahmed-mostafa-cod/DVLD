using BusinessLayer;
using projectDVLD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectDVLD.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        private int _PersonID = -1;
        clsPerson _Person;
        
        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPerson SelectedPersonInfo
            { get { return _Person; } }
        public ctrlPersonCard()
        {
            InitializeComponent();
            
        }

        public void LoadPersonInfo(int personID)
        {
            this._PersonID = personID;
            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with Person ID = " +_PersonID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            _FillPersonInfo();

        }
        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with NationalNo = " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        private void _LoadPersonImage()
        {
            if (_Person.Gendor == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image=Resources.Female_512;

            string ImagePath = "";
            ImagePath=_Person.ImagePath;

            if(ImagePath !="")
                if(File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void _FillPersonInfo()
        {
         llEditPerson.Visible = true;
            _PersonID = _Person.PersonID;
            lblPersonID.Text = _PersonID.ToString();
            lblNationalNo.Text = _Person.NationalNo;
            lblFullName.Text = _Person.FullName;
            lblGendor.Text = _Person.Gendor == 0 ? "Male" : "Female";
            lblEmail.Text = _Person.Email;
            lblCountry.Text = _Person.CountryInfo.CountryName;
            lblPhone.Text = _Person.Phone;
            lblDateOfBirth.Text=_Person.DateOfBirth.ToShortDateString();
            lblAddress.Text = _Person.Address;
            _LoadPersonImage();
        }
        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblFullName.Text = "[????]";
            pbGendor.Image = Resources.Man_32;
            lblGendor.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            pbPersonImage.Image = Resources.Male_512;

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       
            

        private void llEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llEditPerson.Visible = true;
            Form frm = new frmAddUpdatePerson(_PersonID);
            frm.ShowDialog();
            LoadPersonInfo(_PersonID);
        }

        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {

        }
    }
}
