using FHP_Res;
using FHP_Res.Entity;
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
    public partial class UserAuthentication : Form
    {
        public UserAuthentication()
        {
            InitializeComponent();           
            ld_id.Text = "User Id";
            lb_password.Text = "Password";
            btn_login.Text = "Login";
            btn_register.Text = "Register";
            tb_password.UseSystemPasswordChar = true;
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            UserModel user = new UserModel();
            user.Id = tb_id.Text;
            user.Password = tb_password.Text;
            FHP_BL.UserAuthentication authentication = new FHP_BL.UserAuthentication();

            // ----------------- user is authenticated
            if (authentication.ValidateUser(user))
            {
                FHP_VO.VO valueObject = new FHP_VO.VO();
                valueObject.signinUser = user;
                FHP fHP = new FHP(valueObject);
                fHP.Show();
            }
            else
            {
                MessageBox.Show("Invalid user");
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }
    }
}
