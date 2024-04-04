using FHP_BL;
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
using static FHP_Res.StaticData;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FHP
{
    public partial class UpsertView : Form
    {
        VO valueObject;
        public UpsertView(VO _valueObject)
        {
            valueObject = _valueObject;
            if (valueObject.EditMode == VOResource.EditMode.Add)
            {
                this.Text = valueObject.uiText.UpsertScreen["CreateTitle"];
            }
            else if (valueObject.EditMode == VOResource.EditMode.Edit)
            {
                this.Text = valueObject.uiText.UpsertScreen["UpdateTitle"];
            }
            InitializeComponent();
            // --------------------------- getting and assigning the display text
            lb_serialNumber.Text = valueObject.uiText.UpsertScreen["SerialNumber"];
            lb_prefix.Text = valueObject.uiText.UpsertScreen["Prefix"];
            lb_fname.Text = valueObject.uiText.UpsertScreen["FName"];
            lb_middleName.Text = valueObject.uiText.UpsertScreen["MName"];
            lb_lastName.Text = valueObject.uiText.UpsertScreen["LName"];
            lb_education.Text = valueObject.uiText.UpsertScreen["Education"];
            lb_joiningDate.Text = valueObject.uiText.UpsertScreen["JoiningDate"];
            lb_currentCompany.Text = valueObject.uiText.UpsertScreen["CurrentCompany"];
            lb_currentAddress.Text = valueObject.uiText.UpsertScreen["CurrentAddress"];
            lb_DOB.Text = valueObject.uiText.UpsertScreen["DateOfBirth"];

            addBtn_upsert.Text = valueObject.uiText.UpsertScreen["AddBtn"];
            clearBtn_upsert.Text = valueObject.uiText.UpsertScreen["ClearBtn"];
            editBtn_upsert.Text = valueObject.uiText.UpsertScreen["UpdateBtn"];
        }

        private void addView_Load(object sender, EventArgs e)
        {
            comboBox_education.Items.Add(valueObject.uiText.UpsertScreen["SelectQualification"]);
            foreach (QualificationEnum value in Enum.GetValues(typeof(QualificationEnum)))
            {
                var descriptionAttribute = (DescriptionAttribute[])value.GetType().GetField(value.ToString())
                                                               .GetCustomAttributes(typeof(DescriptionAttribute), false);
                string description = descriptionAttribute.Length > 0 ? descriptionAttribute[0].Description : value.ToString();
                comboBox_education.Items.Add(description);
            }
            if (valueObject.EditMode == VOResource.EditMode.Add)
            {
                editBtn_upsert.Enabled = false;
                comboBox_education.SelectedIndex = 0;
                textBox_serialNumber.Text = Properties.Settings.Default.CurrentSerialNumber.ToString();
                dateTimePicker_DOB.CustomFormat = " ";
                dateTimePicker_DOB.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                addBtn_upsert.Enabled = false;
                editBtn_upsert.Enabled = true;

                // ------------------ populating the trainee data
                textBox_serialNumber.Text = valueObject.Trainee.SerialNumber.ToString();
                textBox_prefix.Text = valueObject.Trainee.Prefix;
                textBox_fname.Text = valueObject.Trainee.FirstName;
                textBox_mname.Text = valueObject.Trainee.MiddleName;
                textBox_lname.Text = valueObject.Trainee.LastName;
                if (valueObject.signinUser.Role == 4)
                {
                    comboBox_education.Enabled = false;
                }
                comboBox_education.SelectedIndex = valueObject.Trainee.Education;
                dateTimePicker_joiningDate.Value = valueObject.Trainee.JoiningDate;
                textBox_currentCompany.Text = valueObject.Trainee.CurrentCompany;
                textBox_currentAddress.Text = valueObject.Trainee.CurrentAddress;
                if (valueObject.Trainee.DateOfBirth != DateTime.MinValue)
                {
                    dateTimePicker_DOB.Value = valueObject.Trainee.DateOfBirth;
                }
                else
                {
                    dateTimePicker_DOB.CustomFormat = " ";
                    dateTimePicker_DOB.Format = DateTimePickerFormat.Custom;
                }
            }
        }
        private void addBtn_upsert_Click(object sender, EventArgs e)
        {
            // --------------- if all the required fields are provided
            Trainee trainee = new Trainee();

            // --------------- getting serial number from the setting
            trainee.SerialNumber = Properties.Settings.Default.CurrentSerialNumber;
            Properties.Settings.Default.CurrentSerialNumber++;
            Properties.Settings.Default.Save();

            trainee.Prefix = textBox_prefix.Text;
            trainee.FirstName = textBox_fname.Text;
            trainee.MiddleName = textBox_mname.Text;
            trainee.LastName = textBox_lname.Text;
            trainee.Education = (byte)comboBox_education.SelectedIndex;
            trainee.JoiningDate = dateTimePicker_joiningDate.Value.Date;
            trainee.CurrentCompany = textBox_currentCompany.Text;
            trainee.CurrentAddress = textBox_currentAddress.Text;
            // --------------------- if the DOB == Date.now(), we will not add this
            if (dateTimePicker_DOB.Value.Date != DateTime.Now.Date)
            {
                trainee.DateOfBirth = dateTimePicker_DOB.Value.Date;
            }

            // ---------- adding the trainee data to the file
            valueObject.Trainee = trainee;
            EntityHandler entityHandler = new EntityHandler();
            if (entityHandler.Handle(valueObject))
            {
                MessageBox.Show(valueObject.uiText.Messages["AddSuccess"]);
                this.Close();
            }
            else
            {
                DisplayValidationMessage(valueObject);
            }
        }
        // -------------- we will display the first validation message only
        public void DisplayValidationMessage(VO valueObject)
        {
            foreach (var property in valueObject.ValidationMessage)
            {
                foreach (var validationRule in property.Value)
                {
                    MessageBox.Show(validationRule.Value);
                    if (property.Key == "first name")
                    {
                        textBox_fname.Focus();
                    }
                    else if (property.Key == "current company")
                    {
                        textBox_currentCompany.Focus();
                    }
                    else if (property.Key== "education")
                    {
                        comboBox_education.Focus();
                    }
                    valueObject.ValidationMessage = new Dictionary<string, Dictionary<string, string>>();
                    foreach (var item in VOResource.ValidationMessageDict)
                    {
                        valueObject.ValidationMessage.Add(item.Key, new Dictionary<string, string>(item.Value));
                    }
                    return;
                }
            }
        }
        private void clearBtn_upsert_Click(object sender, EventArgs e)
        {
            // ----- when clear btn is clicked all the input data will be erased
            DialogResult result = MessageBox.Show(valueObject.uiText.UpsertScreen["ClearConfirmation"], "Confirmation", MessageBoxButtons.OKCancel);
            // ---- if okay is clicked then we will erase the data 
            if (result == DialogResult.OK)
            {
                textBox_serialNumber.Text = Properties.Settings.Default.CurrentSerialNumber.ToString();
                textBox_prefix.Text = String.Empty;
                textBox_fname.Text = String.Empty;
                textBox_mname.Text = String.Empty;
                textBox_lname.Text = String.Empty;
                comboBox_education.SelectedIndex = 0;
                dateTimePicker_joiningDate.Value = DateTime.Now;
                textBox_currentCompany.Text = String.Empty;
                textBox_currentAddress.Text = String.Empty;
                dateTimePicker_DOB.Value = DateTime.Now;
                editBtn_upsert.Enabled = false;
                addBtn_upsert.Enabled = true;
                return;
            }
        }

        private void editBtn_upsert_Click(object sender, EventArgs e)
        {
            Trainee trainee = new Trainee();
            trainee.SerialNumber = long.Parse(textBox_serialNumber.Text);
            trainee.Prefix = textBox_prefix.Text;
            trainee.FirstName = textBox_fname.Text;
            trainee.MiddleName = textBox_mname.Text;
            trainee.LastName = textBox_lname.Text;
            trainee.Education = (byte)comboBox_education.SelectedIndex;
            trainee.JoiningDate = dateTimePicker_joiningDate.Value.Date;
            trainee.CurrentCompany = textBox_currentCompany.Text;
            trainee.CurrentAddress = textBox_currentAddress.Text;
            trainee.DateOfBirth = dateTimePicker_DOB.Value.Date;
            valueObject.Trainee = trainee;
            valueObject.EditMode = VOResource.EditMode.Edit;
            EntityHandler entityHandler = new EntityHandler();
            if (entityHandler.Handle(valueObject))
            {
                MessageBox.Show(valueObject.uiText.Messages["UpdateSuccess"]);
                this.Close();
            }
            else
            {
                DisplayValidationMessage(valueObject);
            }
        }
        private void dateTimePicker_joiningDate_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_joiningDate.CustomFormat = "dd-MM-yyyy";
            dateTimePicker_joiningDate.Format = DateTimePickerFormat.Custom;
        }

        private void dateTimePicker_DOB_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_DOB.CustomFormat = "dd-MM-yyyy";
            dateTimePicker_DOB.Format = DateTimePickerFormat.Custom;
        }
    }
}
