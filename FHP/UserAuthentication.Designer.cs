namespace FHP
{
    partial class UserAuthentication
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
            this.ld_id = new System.Windows.Forms.Label();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.lb_password = new System.Windows.Forms.Label();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_register = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ld_id
            // 
            this.ld_id.AutoSize = true;
            this.ld_id.Location = new System.Drawing.Point(54, 61);
            this.ld_id.Name = "ld_id";
            this.ld_id.Size = new System.Drawing.Size(44, 16);
            this.ld_id.TabIndex = 0;
            this.ld_id.Text = "label1";
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(123, 61);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(293, 22);
            this.tb_id.TabIndex = 1;
            // 
            // lb_password
            // 
            this.lb_password.AutoSize = true;
            this.lb_password.Location = new System.Drawing.Point(54, 144);
            this.lb_password.Name = "lb_password";
            this.lb_password.Size = new System.Drawing.Size(44, 16);
            this.lb_password.TabIndex = 2;
            this.lb_password.Text = "label1";
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(123, 138);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(293, 22);
            this.tb_password.TabIndex = 3;
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(135, 201);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(97, 36);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "button1";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_register
            // 
            this.btn_register.Location = new System.Drawing.Point(250, 201);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(105, 36);
            this.btn_register.TabIndex = 5;
            this.btn_register.Text = "button1";
            this.btn_register.UseVisualStyleBackColor = true;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // UserAuthentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 284);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.lb_password);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.ld_id);
            this.MaximumSize = new System.Drawing.Size(502, 331);
            this.MinimumSize = new System.Drawing.Size(502, 331);
            this.Name = "UserAuthentication";
            this.Text = "UserAuthentication";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ld_id;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Label lb_password;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_register;
    }
}