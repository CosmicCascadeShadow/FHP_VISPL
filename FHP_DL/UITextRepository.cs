using FHP_DL.Interfaces;
using FHP_Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_DL
{
    public class UITextRepository
    {
        private string filePath = Environment.CurrentDirectory + @"\Resources\appConfig.ini";
        private string currentDb;
        IUITextRepository uiTextRepository;
        public UITextRepository()
        {
            IniFilesHandle iniFile = new IniFilesHandle(filePath);
            currentDb = iniFile.IniReadValue("Db", "SelectedDb");
            if (currentDb == "file")
            {
                uiTextRepository = new clsFHPFileUIText();
            }
            else if (currentDb == "sql")
            {
                uiTextRepository = new clsFHPSQLUIText();
            }
        }
        public List<string[]> GetUiText(string sectionName)
        {
            return uiTextRepository.GetUiText(sectionName);
        }
    }
}
