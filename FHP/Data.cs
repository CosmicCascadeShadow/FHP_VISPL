using FHP_Res;
using FHP_Res.Entity;
using FHP_VO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FHP
{
    public partial class DataView : Form
    {
        public List<Trainee> traineeList;
        private Trainee trainee;
        private int currentIndex;
        public DataView(long id, VO valueObject)
        {
            traineeList = valueObject.TraineeList;
            InitializeComponent();
            this.Text = valueObject.uiText.ReadOnlyScreen["Title"];

            lb_serialNumber.Text = valueObject.uiText.UpsertScreen["SerialNumber"];
            lb_prefix.Text = valueObject.uiText.UpsertScreen["Prefix"];
            lb_fname.Text = valueObject.uiText.UpsertScreen["FName"];
            lb_mname.Text = valueObject.uiText.UpsertScreen["MName"];
            lb_lname.Text = valueObject.uiText.UpsertScreen["LName"];
            lb_education.Text = valueObject.uiText.UpsertScreen["Education"];
            lb_joinningDate.Text = valueObject.uiText.UpsertScreen["JoiningDate"];
            lb_currentCompany.Text = valueObject.uiText.UpsertScreen["CurrentCompany"];
            lb_currentAddress.Text = valueObject.uiText.UpsertScreen["CurrentAddress"];
            lb_DOB.Text = valueObject.uiText.UpsertScreen["DateOfBirth"];

            firstDataBtn.Text = valueObject.uiText.ReadOnlyScreen["FirstBtn"];
            lastDataBtn.Text = valueObject.uiText.ReadOnlyScreen["LastBtn"];
            previousDataBtn.Text = valueObject.uiText.ReadOnlyScreen["PreviousBtn"];
            nextDataBtn.Text = valueObject.uiText.ReadOnlyScreen["NextBtn"];


            trainee = traineeList.FirstOrDefault(t => t.SerialNumber == id);
            currentIndex = traineeList.IndexOf(trainee);
            textBox_prefix.Enabled = false;
            textBox_fname.Enabled = false;
            textBox_middleName.Enabled = false;
            textBox_lastName.Enabled = false;
            textBox_education.Enabled = false;
            textBox_joiningdate.Enabled = false;
            textBox_address.Enabled = false;
            textBox_currentCompany.Enabled = false;
            textBox_dob.Enabled = false;
            textBox_serialNumber.Enabled = false;
            FillTraineeData(trainee);

            // -------------- handling buttons
            if (currentIndex == 0)
            {
                previousDataBtn.Enabled = false;
            }
            else if (currentIndex == traineeList.Count - 1)
            {
                nextDataBtn.Enabled = false;
            }

            if (currentIndex == 0 && traineeList.Count == 1)
            {
                nextDataBtn.Enabled = false;
            }
        }
        private void firstDataBtn_Click(object sender, EventArgs e)
        {
            currentIndex = 0;
            trainee = traineeList[currentIndex];
            FillTraineeData(trainee);
            previousDataBtn.Enabled = false;
            nextDataBtn.Enabled = true;
        }
        private void lastDataBtn_Click(object sender, EventArgs e)
        {
            currentIndex = traineeList.Count - 1;
            trainee = traineeList[currentIndex];
            FillTraineeData(trainee);
            nextDataBtn.Enabled = false;
            previousDataBtn.Enabled = true;
        }
        private void previousDataBtn_Click(object sender, EventArgs e)
        {
            currentIndex = currentIndex - 1;
            trainee = traineeList[currentIndex];
            FillTraineeData(trainee);
            if (currentIndex == 0)
            {
                previousDataBtn.Enabled = false;
                if (traineeList.Count > 1)
                {
                    nextDataBtn.Enabled = true;
                }
            }

        }
        private void nextDataBtn_Click(object sender, EventArgs e)
        {
            currentIndex = currentIndex + 1;
            trainee = traineeList[currentIndex];
            FillTraineeData(trainee);
            if (currentIndex == traineeList.Count - 1)
            {
                nextDataBtn.Enabled = false;
                if (traineeList.Count > 1)
                {
                    previousDataBtn.Enabled = true;
                }
            }
        }
        public void FillTraineeData(Trainee trainee)
        {
            textBox_serialNumber.Text = trainee.SerialNumber.ToString();
            textBox_prefix.Text = trainee.Prefix;
            textBox_fname.Text = trainee.FirstName;
            textBox_middleName.Text = trainee.MiddleName;
            textBox_lastName.Text = trainee.LastName;
            textBox_education.Text = StaticData.GetEnumValueAtIndex<StaticData.QualificationEnum>(trainee.Education);
            textBox_joiningdate.Text = trainee.JoiningDate.ToString("dd-MM-yyyy");
            textBox_address.Text = trainee.CurrentAddress;
            if (trainee.DateOfBirth != DateTime.MinValue)
            {
                textBox_dob.Text = trainee.DateOfBirth.ToString("dd-MM-yyyy");
            }
            textBox_currentCompany.Text = trainee.CurrentCompany;
        }

        private void DataView_Load(object sender, EventArgs e)
        {

        }
    }
}
