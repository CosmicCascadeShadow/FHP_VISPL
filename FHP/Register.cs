using FHP_DL;
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
using static FHP_Res.StaticData;

namespace FHP
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            cb_role.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_role.Items.Add("select role");

            Roles[] roles = (Roles[])Enum.GetValues(typeof(Roles));

            foreach (Roles role in roles)
            {
                cb_role.Items.Add(role);
            }
            cb_role.SelectedIndex = 0;

        }
        private void btn_register_Click(object sender, EventArgs e)
        {
            UserModel user = new UserModel();
            user.Id = tb_id.Text;
            user.Password = tb_password.Text;
            if(string.IsNullOrEmpty(user.Id))
            {
                MessageBox.Show("User id can't be blank");
                return;
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                MessageBox.Show("Password can't be black");
                return;
            }
            if (cb_role.SelectedIndex == 0)
            {
                MessageBox.Show("Please select the role");
                return;
            }
            user.Role = (byte)cb_role.SelectedIndex;
            UserRepository userRepository = new UserRepository();
            if (userRepository.Add(user))
            {
                MessageBox.Show("Registered successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Registeration failed");
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
