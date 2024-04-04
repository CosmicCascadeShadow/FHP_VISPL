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
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FHP
{
    public partial class FHP : Form
    {
        FHP_VO.VO valueObject;
        public FHP(VO valueObject)
        {
            InitializeComponent();
            //  logout_btn.Visible = false;
            //lb_currentUser.Visible = false;
            if (valueObject.signinUser.Role == 3)
            {
                newToolStripMenuItem.Enabled = false;
            }

            this.valueObject = valueObject;
            this.Text = valueObject.uiText.HomeScreen["Title"];

            newToolStripMenuItem.Text = valueObject.uiText.HomeScreen["MenuNewBtn"];
            editToolStripMenuItem.Text = valueObject.uiText.HomeScreen["MenuEditBtn"];
            deleteToolStripMenuItem.Text = valueObject.uiText.HomeScreen["MenuDeleteBtn"];
            clearSearchToolStripMenuItem.Text = valueObject.uiText.HomeScreen["ClearSearch"];
            aboutUsToolStripMenuItem.Text = valueObject.uiText.HomeScreen["AboutUs"];
            lb_heading.Text = valueObject.uiText.HomeScreen["HeadingText"];

            table_serial_no.HeaderText = valueObject.uiText.HomeScreen["SerialNumber"];
            table_prefix.HeaderText = valueObject.uiText.HomeScreen["Prefix"];
            table_firstname.HeaderText = valueObject.uiText.HomeScreen["FName"];
            table_middlename.HeaderText = valueObject.uiText.HomeScreen["MName"];
            table_last_name.HeaderText = valueObject.uiText.HomeScreen["LName"];
            table_education.HeaderText = valueObject.uiText.HomeScreen["Education"];
            table_joining_date.HeaderText = valueObject.uiText.HomeScreen["JoiningDate"];
            table_current_company.HeaderText = valueObject.uiText.HomeScreen["CurrentAddress"];
            table_current_address.HeaderText = valueObject.uiText.HomeScreen["CurrentCompany"];
            table_date_of_birth.HeaderText = valueObject.uiText.HomeScreen["DateOfBirth"];

            lb_currentUser.Text = valueObject.signinUser.Id + $"({valueObject.signinUser.Role})";

            allTrainee.RowTemplate.Height = 40;

            allTrainee.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            allTrainee.RowHeadersWidth = 40;

            // ----------------- handling if the maximize button is clicked
            //allTrainee.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            //allTrainee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ------------ styling the Welcome heading, Greeting
            lb_heading.Font = new Font(lb_heading.Font, FontStyle.Bold);
            lb_heading.Font = new Font(lb_heading.Font.FontFamily, 16.0f);
            lb_heading.ForeColor = Color.Blue;
            if (valueObject.TraineeList.Count==0)
            {
                Properties.Settings.Default.CurrentSerialNumber =1;
            }
            else
            {
                Properties.Settings.Default.CurrentSerialNumber = (byte)(valueObject.TraineeList[valueObject.TraineeList.Count-1].SerialNumber+1);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // -------- by default the update and delete btn will be disabled
            editToolStripMenuItem.Enabled = false;
            deleteToolStripMenuItem.Enabled = false;

            // ------------ redering the entity infromation
            RenderTraineeInformation();
        }

        // --------------- handling the add, edit, and delete button visiblity
        private void allTrainee_SelectionChanged(object sender, EventArgs e)
        {
            if (valueObject.signinUser.Role == 3)
            {
                return;
            }
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView != null && dataGridView.SelectedRows.Count > 0)
            {
                // ----- check whether the selected row is empty or not 
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                long? id = null;
                if (selectedRow.Cells["table_serial_no"].Value == null)
                {
                    editToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = false;
                    newToolStripMenuItem.Enabled = true;
                    return;
                }
                if (long.TryParse(selectedRow.Cells["table_serial_no"].Value.ToString(), out long parsedId))
                {
                    id = parsedId;
                }
                // ---------------- if the non empty row is selected
                if (id != null && id != 0)
                {
                    editToolStripMenuItem.Enabled = true;
                    deleteToolStripMenuItem.Enabled = true;
                    newToolStripMenuItem.Enabled = false;
                }
            }
        }


        // -------------- handling the row header double click
        private void allTrainee_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow selectedRow = allTrainee.SelectedRows[0];
            // ------------ if the first row header is double clicked, which contains all the filters then we will not open the read-only view
            if (Convert.ToInt32(selectedRow.Cells["table_serial_no"].RowIndex.ToString()) != 0)
            {
                long id = long.Parse(selectedRow.Cells["table_serial_no"].Value.ToString());
                Trainee trainee = valueObject.TraineeList.FirstOrDefault(t => t.SerialNumber == id);
                DataView dataView = new DataView(id, valueObject);
                dataView.ShowDialog();
            }
        }

        // ------------ rendering all trainees data to the grid
        public void RenderTraineeInformation()
        {
            if (valueObject.TraineeList == null || valueObject.TraineeList.Count == 0)
            {
                Properties.Settings.Default.CurrentSerialNumber = 1;
            }
            allTrainee.Rows.Add();
            allTrainee.Rows[0].Height = 20;
            allTrainee.Rows[0].Frozen = true;

            for (int i = 0; i < allTrainee.Columns.Count; i++)
            {
                // -------------------- filter textbox
                System.Windows.Forms.TextBox filterTextBox = new System.Windows.Forms.TextBox();
                filterTextBox.Multiline = true;
                Rectangle cellRectangle = allTrainee.GetCellDisplayRectangle(i, 0, false);
                filterTextBox.Size = new Size(allTrainee.Columns[i].Width - 25, allTrainee.Rows[0].Height);
                filterTextBox.Location = new Point(cellRectangle.X + 3, cellRectangle.Y + allTrainee.DefaultCellStyle.Padding.Top);
                allTrainee.Controls.Add(filterTextBox);

                // ----------------- filter clear btn
                System.Windows.Forms.Button filterClearBtn = new System.Windows.Forms.Button();
                filterClearBtn.Text = "x";
                filterClearBtn.FlatStyle = FlatStyle.Standard;
                filterClearBtn.Size = new Size(20, allTrainee.Rows[0].Height);
                filterClearBtn.Location = new Point(filterTextBox.Right + 3, cellRectangle.Y + allTrainee.DefaultCellStyle.Padding.Top);
                filterClearBtn.Visible = false;
                allTrainee.Controls.Add(filterClearBtn);
                filterTextBox.TextChanged += (sender, e) =>
                {
                    System.Windows.Forms.TextBox textbox = sender as System.Windows.Forms.TextBox;
                    if (!(textbox.Text.Length <= 3))
                    {
                        HandleSearch search = new HandleSearch();
                        AddSearchRecord(search.Filter(valueObject.TraineeList, AllFilters()));
                    }
                };
                allTrainee.Scroll += (sender, e) =>
                {
                    filterTextBox.Location = new Point(cellRectangle.X + 3 - allTrainee.HorizontalScrollingOffset, cellRectangle.Y + allTrainee.DefaultCellStyle.Padding.Top);
                    filterClearBtn.Location = new Point(filterTextBox.Right + 3, cellRectangle.Y + allTrainee.DefaultCellStyle.Padding.Top);
                };

                filterClearBtn.Enter += (sender, e) =>
                {
                    System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;
                    allTrainee.Controls[allTrainee.Controls.IndexOf(btn) - 1].Text = String.Empty;
                    HandleSearch search = new HandleSearch();
                    AddSearchRecord(search.Filter(valueObject.TraineeList, AllFilters()));
                };

            }

            allTrainee.RowCount = 2;
            if (valueObject.TraineeList != null)
            {
                for (int traineeNumber = 0; traineeNumber < valueObject.TraineeList.Count; traineeNumber++)
                {
                    allTrainee.Rows.Add();
                    allTrainee.Rows[traineeNumber + 1].Cells[0].Value = valueObject.TraineeList[traineeNumber].SerialNumber;
                    allTrainee.Rows[traineeNumber + 1].Cells[1].Value = valueObject.TraineeList[traineeNumber].Prefix;
                    allTrainee.Rows[traineeNumber + 1].Cells[2].Value = valueObject.TraineeList[traineeNumber].FirstName;
                    allTrainee.Rows[traineeNumber + 1].Cells[3].Value = valueObject.TraineeList[traineeNumber].MiddleName;
                    allTrainee.Rows[traineeNumber + 1].Cells[4].Value = valueObject.TraineeList[traineeNumber].LastName;
                    allTrainee.Rows[traineeNumber + 1].Cells[5].Value = StaticData.GetQualificationDescriptionAtIndex(Convert.ToByte(valueObject.TraineeList[traineeNumber].Education - 1));

                    allTrainee.Rows[traineeNumber + 1].Cells[6].Value = valueObject.TraineeList[traineeNumber].JoiningDate.ToString("dd-MM-yyyy");

                    allTrainee.Rows[traineeNumber + 1].Cells[7].Value = valueObject.TraineeList[traineeNumber].CurrentCompany;
                    allTrainee.Rows[traineeNumber + 1].Cells[8].Value = valueObject.TraineeList[traineeNumber].CurrentAddress;
                    if (valueObject.TraineeList[traineeNumber].DateOfBirth != DateTime.MinValue)
                    {
                        allTrainee.Rows[traineeNumber + 1].Cells[9].Value = valueObject.TraineeList[traineeNumber].DateOfBirth.ToString("dd-MM-yyyy");
                    }
                }
            }
        }

        private List<string> AllFilters()
        {
            List<string> filterQuery = new List<string>();
            foreach (Control control in allTrainee.Controls)
            {
                if (control is System.Windows.Forms.TextBox textBox)
                {
                    filterQuery.Add(textBox.Text);
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        allTrainee.Controls[allTrainee.Controls.IndexOf(control) + 1].Visible = false;
                    }
                    else
                    {
                        allTrainee.Controls[allTrainee.Controls.IndexOf(control) + 1].Visible = true;
                    }
                }
            }
            return filterQuery;
        }
        private void AddSearchRecord(List<Trainee> tr)
        {
            allTrainee.RowCount = 2;
            if (tr != null)
            {
                for (int traineeNumber = 0; traineeNumber < tr.Count; traineeNumber++)
                {
                    allTrainee.Rows.Add();
                    allTrainee.Rows[traineeNumber + 1].Cells[0].Value = tr[traineeNumber].SerialNumber;
                    allTrainee.Rows[traineeNumber + 1].Cells[1].Value = tr[traineeNumber].Prefix;
                    allTrainee.Rows[traineeNumber + 1].Cells[2].Value = tr[traineeNumber].FirstName;
                    allTrainee.Rows[traineeNumber + 1].Cells[3].Value = tr[traineeNumber].MiddleName;
                    allTrainee.Rows[traineeNumber + 1].Cells[4].Value = tr[traineeNumber].LastName;
                    allTrainee.Rows[traineeNumber + 1].Cells[5].Value = StaticData.GetQualificationDescriptionAtIndex(Convert.ToByte(tr[traineeNumber].Education - 1));
                    allTrainee.Rows[traineeNumber + 1].Cells[6].Value = tr[traineeNumber].JoiningDate.ToString("dd-MM-yyyy");
                    allTrainee.Rows[traineeNumber + 1].Cells[7].Value = tr[traineeNumber].CurrentCompany;
                    allTrainee.Rows[traineeNumber + 1].Cells[8].Value = tr[traineeNumber].CurrentAddress;
                    allTrainee.Rows[traineeNumber + 1].Cells[9].Value = tr[traineeNumber].DateOfBirth.ToString("dd-MM-yyyy");
                }
            }
        }
        private void UpdateFilterBoxPosition(Control filterTextBox, int columnIndex)
        {
            Rectangle cellRect = allTrainee.GetCellDisplayRectangle(columnIndex, -1, false);
            filterTextBox.Location = new Point(cellRect.X + 3, cellRect.Y + 2);
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpsertView upsertViewDialog = new UpsertView(valueObject);
            valueObject.EditMode = VOResource.EditMode.Add;
            upsertViewDialog.ShowDialog();
            RenderTraineeInformation();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = allTrainee.SelectedRows[0];
            long id = long.Parse(selectedRow.Cells["table_serial_no"].Value.ToString());
            Trainee trainee = valueObject.TraineeList.FirstOrDefault(t => t.SerialNumber == id);
            valueObject.EditMode = VOResource.EditMode.Edit;
            valueObject.Trainee = trainee;
            UpsertView upsertViewDialog = new UpsertView(valueObject);
            upsertViewDialog.ShowDialog();
            RenderTraineeInformation();
        }

        // ------------------- if delete button is clicked
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // -------------- taking confirmation from the user and then after deleting the entity
            DialogResult result = MessageBox.Show(valueObject.uiText.Messages["DeleteConfirmation"], "Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                // -------------- will delete the trainee record
                DataGridViewRow selectedRow = allTrainee.SelectedRows[0];
                long id = long.Parse(selectedRow.Cells["table_serial_no"].Value.ToString());
                Trainee trainee = valueObject.TraineeList.FirstOrDefault(t => t.SerialNumber == id);
                valueObject.Trainee = trainee;
                valueObject.IsDelete = true;
                EntityHandler entityHandler = new EntityHandler();
                if (entityHandler.Handle(valueObject))
                {
                    MessageBox.Show(valueObject.uiText.Messages["DeleteSuccess"]);
                    deleteToolStripMenuItem.Enabled = false;
                    editToolStripMenuItem.Enabled = false;
                    newToolStripMenuItem.Enabled = true;
                    RenderTraineeInformation();
                }
                else
                {
                    MessageBox.Show(valueObject.uiText.Messages["DeleteError"]);
                }
            }
            else
            {
                return;
            }
        }

        private void allTrainee_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == allTrainee.RowCount - 1 && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Set the cell border style
                e.Graphics.FillRectangle(new SolidBrush(Color.LightGreen), e.CellBounds);
                using (Pen p = new Pen(Color.White, 1))
                {
                    e.Graphics.DrawRectangle(p, e.CellBounds);
                }


                e.PaintContent(e.ClipBounds);
                e.Handled = true;
            }

            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                // Set the cell border style for the header row
                e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), e.CellBounds);
                using (Pen p = new Pen(Color.White, 1))
                {
                    e.Graphics.DrawRectangle(p, e.CellBounds);
                }
                e.PaintContent(e.ClipBounds);
                e.Handled = true;
            }

            if (e.ColumnIndex == -1)
            {

                e.Graphics.FillRectangle(new SolidBrush(Color.Plum), e.CellBounds);
                using (Pen p = new Pen(Color.White, 1))
                {
                    e.Graphics.DrawRectangle(p, e.CellBounds);
                }

                e.PaintContent(e.ClipBounds);
                e.Handled = true;
            }
        }

        // ------------- if clear-search button is clicked
        private void clearSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearFilters();
            AddSearchRecord(valueObject.TraineeList);
        }
        private void ClearFilters()
        {
            foreach (Control control in allTrainee.Controls)
            {
                if (control is System.Windows.Forms.TextBox textBox)
                {
                    textBox.Clear();
                }
            }
        }

        // ------------- if about-us is clicked
        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutUs aboutUs = new AboutUs();
            // ------------ we will design the about us section here 
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            label.Text = "about us";
            aboutUs.Controls.Add(label);
            aboutUs.Show();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}



