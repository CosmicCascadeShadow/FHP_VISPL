namespace FHP
{
    partial class FHP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FHP));
            this.allTrainee = new System.Windows.Forms.DataGridView();
            this.table_serial_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table_prefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table_firstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table_middlename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table_last_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table_education = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table_joining_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table_current_company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table_current_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table_date_of_birth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lb_heading = new System.Windows.Forms.Label();
            this.lb_currentUser = new System.Windows.Forms.Label();
            this.logout_btn = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.allTrainee)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // allTrainee
            // 
            this.allTrainee.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.allTrainee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.allTrainee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allTrainee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.table_serial_no,
            this.table_prefix,
            this.table_firstname,
            this.table_middlename,
            this.table_last_name,
            this.table_education,
            this.table_joining_date,
            this.table_current_company,
            this.table_current_address,
            this.table_date_of_birth});
            this.allTrainee.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.allTrainee.Location = new System.Drawing.Point(31, 131);
            this.allTrainee.Name = "allTrainee";
            this.allTrainee.RowHeadersWidth = 51;
            this.allTrainee.RowTemplate.Height = 24;
            this.allTrainee.Size = new System.Drawing.Size(1538, 345);
            this.allTrainee.TabIndex = 1;
            this.allTrainee.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.allTrainee_CellPainting);
            this.allTrainee.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.allTrainee_RowHeaderMouseDoubleClick);
            this.allTrainee.SelectionChanged += new System.EventHandler(this.allTrainee_SelectionChanged);
            // 
            // table_serial_no
            // 
            this.table_serial_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.table_serial_no.HeaderText = "";
            this.table_serial_no.MinimumWidth = 6;
            this.table_serial_no.Name = "table_serial_no";
            this.table_serial_no.ReadOnly = true;
            this.table_serial_no.Width = 24;
            // 
            // table_prefix
            // 
            this.table_prefix.HeaderText = "";
            this.table_prefix.MinimumWidth = 6;
            this.table_prefix.Name = "table_prefix";
            this.table_prefix.Width = 70;
            // 
            // table_firstname
            // 
            this.table_firstname.HeaderText = "";
            this.table_firstname.MinimumWidth = 6;
            this.table_firstname.Name = "table_firstname";
            this.table_firstname.ReadOnly = true;
            this.table_firstname.Width = 125;
            // 
            // table_middlename
            // 
            this.table_middlename.HeaderText = "";
            this.table_middlename.MinimumWidth = 6;
            this.table_middlename.Name = "table_middlename";
            this.table_middlename.Width = 125;
            // 
            // table_last_name
            // 
            this.table_last_name.HeaderText = "";
            this.table_last_name.MinimumWidth = 6;
            this.table_last_name.Name = "table_last_name";
            this.table_last_name.Width = 125;
            // 
            // table_education
            // 
            this.table_education.HeaderText = "";
            this.table_education.MinimumWidth = 6;
            this.table_education.Name = "table_education";
            this.table_education.ReadOnly = true;
            this.table_education.Width = 125;
            // 
            // table_joining_date
            // 
            this.table_joining_date.HeaderText = "";
            this.table_joining_date.MinimumWidth = 6;
            this.table_joining_date.Name = "table_joining_date";
            this.table_joining_date.Width = 125;
            // 
            // table_current_company
            // 
            this.table_current_company.HeaderText = "";
            this.table_current_company.MinimumWidth = 6;
            this.table_current_company.Name = "table_current_company";
            this.table_current_company.Width = 125;
            // 
            // table_current_address
            // 
            this.table_current_address.HeaderText = "";
            this.table_current_address.MinimumWidth = 6;
            this.table_current_address.Name = "table_current_address";
            this.table_current_address.Width = 125;
            // 
            // table_date_of_birth
            // 
            this.table_date_of_birth.HeaderText = "";
            this.table_date_of_birth.MinimumWidth = 6;
            this.table_date_of_birth.Name = "table_date_of_birth";
            this.table_date_of_birth.Width = 125;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.clearSearchToolStripMenuItem,
            this.aboutUsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1643, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
            this.newToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10, 6, 20, 6);
            this.editToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // clearSearchToolStripMenuItem
            // 
            this.clearSearchToolStripMenuItem.Name = "clearSearchToolStripMenuItem";
            this.clearSearchToolStripMenuItem.Size = new System.Drawing.Size(14, 20);
            this.clearSearchToolStripMenuItem.Click += new System.EventHandler(this.clearSearchToolStripMenuItem_Click);
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(14, 20);
            this.aboutUsToolStripMenuItem.Click += new System.EventHandler(this.aboutUsToolStripMenuItem_Click);
            // 
            // lb_heading
            // 
            this.lb_heading.AutoSize = true;
            this.lb_heading.Location = new System.Drawing.Point(9, 60);
            this.lb_heading.Name = "lb_heading";
            this.lb_heading.Size = new System.Drawing.Size(0, 16);
            this.lb_heading.TabIndex = 5;
            // 
            // lb_currentUser
            // 
            this.lb_currentUser.AutoSize = true;
            this.lb_currentUser.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lb_currentUser.Location = new System.Drawing.Point(1211, 9);
            this.lb_currentUser.Name = "lb_currentUser";
            this.lb_currentUser.Size = new System.Drawing.Size(44, 16);
            this.lb_currentUser.TabIndex = 6;
            this.lb_currentUser.Text = "label1";
            // 
            // logout_btn
            // 
            this.logout_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.logout_btn.Location = new System.Drawing.Point(1322, 0);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(108, 23);
            this.logout_btn.TabIndex = 7;
            this.logout_btn.Text = "LOGOUT";
            this.logout_btn.UseVisualStyleBackColor = false;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.AutoSize = false;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textFileToolStripMenuItem,
            this.sQLToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.Size = new System.Drawing.Size(233, 80);
            // 
            // textFileToolStripMenuItem
            // 
            this.textFileToolStripMenuItem.Name = "textFileToolStripMenuItem";
            this.textFileToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.textFileToolStripMenuItem.Text = "Text File";
            // 
            // sQLToolStripMenuItem
            // 
            this.sQLToolStripMenuItem.Name = "sQLToolStripMenuItem";
            this.sQLToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.sQLToolStripMenuItem.Text = "SQL";
            // 
            // FHP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1643, 488);
            this.Controls.Add(this.logout_btn);
            this.Controls.Add(this.lb_currentUser);
            this.Controls.Add(this.lb_heading);
            this.Controls.Add(this.allTrainee);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FHP";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.allTrainee)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView allTrainee;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label lb_heading;
        private System.Windows.Forms.ToolStripMenuItem clearSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn table_serial_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn table_prefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn table_firstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn table_middlename;
        private System.Windows.Forms.DataGridViewTextBoxColumn table_last_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn table_education;
        private System.Windows.Forms.DataGridViewTextBoxColumn table_joining_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn table_current_company;
        private System.Windows.Forms.DataGridViewTextBoxColumn table_current_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn table_date_of_birth;
        private System.Windows.Forms.Label lb_currentUser;
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem textFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLToolStripMenuItem;
    }
}

