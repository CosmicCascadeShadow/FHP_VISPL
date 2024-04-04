using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace FHP_Res
{
    public class DisplayText
    {
        public Dictionary<string, string> ReadOnlyScreen = new Dictionary<string, string>();
        public Dictionary<string, string> AboutUsScreen = new Dictionary<string, string>();
        public Dictionary<string, string> UserManagementScreen = new Dictionary<string, string>();
        public Dictionary<string, string> Messages = new Dictionary<string, string>();                     
        public Dictionary<string, string> UpsertScreen = new Dictionary<string, string>();                          
        public Dictionary<string, string> HomeScreen = new Dictionary<string, string>();                                
    }
}
