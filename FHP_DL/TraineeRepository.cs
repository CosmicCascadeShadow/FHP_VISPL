using FHP_Res;
using FHP_Res.Entity;
using System;
using System.Collections.Generic;

namespace FHP_DL
{
    public class TraineeRepository
    {
       // private string filePath = Environment.CurrentDirectory + @"\Resources\appConfig.ini";
        private string filePath = @"D:\.Net Development\FHP_VERTEX\Build" + @"\Resources\appConfig.ini";
        private string currentDb;
        ITraineeRepository dataHandler;
        public TraineeRepository()
        {
            IniFilesHandle iniFile = new IniFilesHandle(filePath);
            currentDb = iniFile.IniReadValue("Db", "SelectedDb");
            if (currentDb == "file")
            {
                dataHandler = new clsFHPFileTraineeDL();
            }
            else if (currentDb=="sql")
            {
                dataHandler= new clsFHPSqlTraineeDL();
            }
        }
        public bool Add(Trainee trainee)
        {
            return dataHandler.Add(trainee);
        }
        public List<Trainee> GetAllTrainee()
        {
            List<Trainee> trainees = dataHandler.GetAllTrainee();
            return trainees;
        }
        public bool Delete(Trainee trainee)
        {
            return dataHandler.Delete(trainee);
        }
        public bool Update(Trainee trainee)
        {
            return dataHandler.Update(trainee);
        }
    }
}
