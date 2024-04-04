using FHP_DL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_DL
{
    internal class clsFHPFileUIText: IUITextRepository
    {
        private string filePath = Environment.CurrentDirectory + @"\Resources\UIResources.ini";
        public List<string[]> GetUiText(string sectionName)
        {
            List<string[]> keyValuePairs = new List<string[]>();
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                bool insideSection = false;

                foreach (string line in lines)
                {
                    if (line.Trim().StartsWith($"[{sectionName}]"))
                    {
                        insideSection = true;
                        continue;
                    }
                    if (insideSection)
                    {
                        string[] parts = line.Split('=');
                        if (parts.Length == 2)
                        {
                            string key = parts[0].Trim();
                            string value = parts[1].Trim();
                            keyValuePairs.Add(new string[] { key, value });
                        }
                        else if (line.Trim().StartsWith("["))
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return keyValuePairs;
        }
    }
}
