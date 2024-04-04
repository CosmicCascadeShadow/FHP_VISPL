namespace FHP
{
    partial class Register
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
            this.lb_id = new System.Windows.Forms.Label();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.lb_password = new System.Windows.Forms.Label();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.lb_role = new System.Windows.Forms.Label();
            this.cb_role = new System.Windows.Forms.ComboBox();
            this.btn_register = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_id
            // 
            this.lb_id.AutoSize = true;
            this.lb_id.Location = new System.Drawing.Point(32, 95);
            this.lb_id.Name = "lb_id";
            this.lb_id.Size = new System.Drawing.Size(67, 16);
            this.lb_id.TabIndex = 0;
            this.lb_id.Text = "username";
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(125, 89);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(239, 22);
            this.tb_id.TabIndex = 1;
            // 
            // lb_password
            // 
            this.lb_password.AutoSize = true;
            this.lb_password.Location = new System.Drawing.Point(32, 154);
            this.lb_password.Name = "lb_password";
            this.lb_password.Size = new System.Drawing.Size(67, 16);
            this.lb_password.TabIndex = 2;
            this.lb_password.Text = "Password";
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(125, 148);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(239, 22);
            this.tb_password.TabIndex = 3;
            // 
            // lb_role
            // 
            this.lb_role.AutoSize = true;
            this.lb_role.Location = new System.Drawing.Point(63, 44);
            this.lb_role.Name = "lb_role";
            this.lb_role.Size = new System.Drawing.Size(36, 16);
            this.lb_role.TabIndex = 4;
            this.lb_role.Text = "Role";
            // 
            // cb_role
            // 
            this.cb_role.FormattingEnabled = true;
            this.cb_role.Location = new System.Drawing.Point(125, 36);
            this.cb_role.Name = "cb_role";
            this.cb_role.Size = new System.Drawing.Size(239, 24);
            this.cb_role.TabIndex = 5;
            // 
            // btn_register
            // 
            this.btn_register.Location = new System.Drawing.Point(153, 208);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(126, 44);
            this.btn_register.TabIndex = 6;
            this.btn_register.Text = "Login";
            this.btn_register.UseVisualStyleBackColor = true;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 269);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.cb_role);
            this.Controls.Add(this.lb_role);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.lb_password);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.lb_id);
            this.MaximumSize = new System.Drawing.Size(490, 316);
            this.MinimumSize = new System.Drawing.Size(490, 316);
            this.Name = "Register";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_id;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Label lb_password;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label lb_role;
        private System.Windows.Forms.ComboBox cb_role;
        private System.Windows.Forms.Button btn_register;
    }
}