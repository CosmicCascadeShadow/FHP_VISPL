using FHP_DL;
using FHP_Res.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_BL
{
    public class UserAuthentication
    {
        public bool ValidateUser(UserModel user)
        {
            UserRepository userRepository = new UserRepository();
            List<UserModel> allUsers = userRepository.GetAllUsers();
            if (allUsers == null)
            {
                return false;
            }
            UserModel validatedUser = allUsers.Where(u => u.Id.ToLower() == user.Id.ToLower() && u.Password == user.Password).FirstOrDefault();
            if (validatedUser != null)
            {
                user.Role = validatedUser.Role;
                user.Password = "";
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
