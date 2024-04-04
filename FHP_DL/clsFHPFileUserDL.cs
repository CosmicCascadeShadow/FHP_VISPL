using FHP_Res;
using FHP_Res.Entity;
using System;
using System.Collections.Generic;
using System.IO;

namespace FHP_DL
{
    internal class clsFHPFileUserDL: IUserRepository
    {
        private readonly string directoryPath;
        private readonly string fileName;
        private string filePath = Environment.CurrentDirectory + @"\Resources\appConfig.ini";
        public clsFHPFileUserDL()
        {
            IniFilesHandle iniFile = new IniFilesHandle(filePath);
            directoryPath = iniFile.IniReadValue("FileInformation", "UsersFileDbDirectory");
            fileName = iniFile.IniReadValue("FileInformation", "UsersFileDbName");
        }
        // ----------------- adding the user to the file
        public bool Add(UserModel user)
        {
            if (Directory.Exists(directoryPath))
            {
                if (!File.Exists(Path.Combine(directoryPath, fileName)))
                {
                    File.Create(Path.Combine(directoryPath, fileName)).Close();

                }
                using (BinaryWriter writer = new BinaryWriter(File.Open(Path.Combine(directoryPath, fileName), FileMode.Append)))
                {
                    writer.Write(user.Id);
                    writer.Write(user.Password);
                    writer.Write(user.Role);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        // ------------------- getting all the users from the file 
        public List<UserModel> GetAllUsers()
        {
            if (File.Exists(Path.Combine(directoryPath, fileName)))
            {
                List<UserModel> allUsers = new List<UserModel>();
                using (BinaryReader reader = new BinaryReader(File.OpenRead(Path.Combine(directoryPath, fileName))))
                {
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        UserModel user = new UserModel();
                        user.Id = reader.ReadString();
                        user.Password = reader.ReadString();
                        user.Role = reader.ReadByte();
                        allUsers.Add(user);
                    }
                }
                return allUsers;
            }
            else
            {
                return null;
            }
        }
    }
}
