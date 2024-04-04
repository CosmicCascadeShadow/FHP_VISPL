using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_DL.Interfaces
{
    internal interface IUITextRepository
    {
        List<string[]> GetUiText(string sectionName);
    }
}
