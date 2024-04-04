using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_Res.Entity
{
    public class UserModel
    {
        public String Id { get; set; }
        public String Password { get; set; }

        public byte Role {  get; set; }
    }
}
