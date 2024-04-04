using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_Res
{
    public class VOResource
    {
        public enum EditMode { Add, Edit, Lock}
        public static Dictionary<string, Dictionary<string, string>> ValidationMessageDict = new Dictionary<string, Dictionary<string, string>>
        {
             { "serial number", new Dictionary<string, string>() },
             { "prefix", new Dictionary<string, string>() },
             { "first name", new Dictionary<string, string>() },
             { "middle name", new Dictionary<string, string>() },
             { "last name", new Dictionary<string, string>() },
             { "education", new Dictionary<string, string>() },
             { "joining date", new Dictionary<string, string>() },
             { "current company", new Dictionary<string, string>() },
             { "current address", new Dictionary<string, string>() },
             { "date of birth", new Dictionary<string, string>() }
        };
    }
}
