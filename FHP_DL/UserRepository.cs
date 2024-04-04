using FHP_Res;
using FHP_Res.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_DL
{
    public class UserRepository:IUserRepository
    {
        //  private string filePath = Environment.CurrentDirectory + @"\Resources\appConfig.ini";
        private string filePath = @"D:\.Net Development\FHP_VERTEX\Build" + @"\Resources\appConfig.ini";
        string currentDb;
        IUserRepository dataHandler;
        public UserRepository()
        {
            IniFilesHandle iniFile = new IniFilesHandle(filePath);
            currentDb = iniFile.IniReadValue("Db", "SelectedDb");
            if (currentDb == "file")
            {
                dataHandler = new clsFHPFileUserDL();
            }
            else if (currentDb == "sql")
            {
                dataHandler = new clsFHPSqlUserDL();
            }
        }
        public bool Add(UserModel user)
        {
            return dataHandler.Add(user);
        }
        public List<UserModel> GetAllUsers()
        {
            return dataHandler.GetAllUsers();
        }
    }
}
