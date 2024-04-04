using FHP_Res.Entity;
using FHP_Res;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_DL
{
    internal class clsFHPFileTraineeDL: ITraineeRepository
    {
        private readonly string directoryPath;
        private readonly string fileName;
        //private string filePath = Environment.CurrentDirectory + @"\Resources\appConfig.ini";
        private string filePath = @"D:\.Net Development\FHP_VERTEX\Build" + @"\Resources\appConfig.ini";
        public clsFHPFileTraineeDL()
        {
            IniFilesHandle iniFile = new IniFilesHandle(filePath);
            directoryPath = iniFile.IniReadValue("FileInformation", "TraineefileDbDirectory");
            fileName = iniFile.IniReadValue("FileInformation", "TraineefileDbName");
        }
        public bool Add(Trainee trainee)
        {

            if (Directory.Exists(directoryPath))
            {
                if (!File.Exists(Path.Combine(directoryPath, fileName)))
                {
                    File.Create(Path.Combine(directoryPath, fileName)).Close();

                }
                using (BinaryWriter writer = new BinaryWriter(File.Open(Path.Combine(directoryPath, fileName), FileMode.Append)))
                {
                    writer.Write(trainee.SerialNumber);
                    writer.Write(trainee.Prefix);
                    writer.Write(trainee.FirstName);
                    writer.Write(trainee.MiddleName);
                    writer.Write(trainee.LastName);
                    writer.Write(trainee.EducationId);
                    writer.Write(trainee.JoiningDate.ToBinary());
                    writer.Write(trainee.CurrentCompany);
                    writer.Write(trainee.CurrentAddress);
                    writer.Write(trainee.DateOfBirth.ToBinary());
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Trainee> GetAllTrainee()
        {
            if (File.Exists(Path.Combine(directoryPath, fileName)))
            {
                List<Trainee> allTrainee = new List<Trainee>();
                using (BinaryReader reader = new BinaryReader(File.OpenRead(Path.Combine(directoryPath, fileName))))
                {
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        // ----------- getting all the trainee from the file
                        Trainee trainee = new Trainee();
                        trainee.SerialNumber = reader.ReadInt64();
                        trainee.Prefix = reader.ReadString();
                        trainee.FirstName = reader.ReadString();
                        trainee.MiddleName = reader.ReadString();
                        trainee.LastName = reader.ReadString();
                        trainee.EducationId = reader.ReadByte();
                        trainee.JoiningDate = DateTime.FromBinary(reader.ReadInt64());
                        trainee.CurrentCompany = reader.ReadString();
                        trainee.CurrentAddress = reader.ReadString();
                        trainee.DateOfBirth = DateTime.FromBinary(reader.ReadInt64());
                        allTrainee.Add(trainee);
                    }
                }
                return allTrainee;
            }
            else
            {
                // ------------------ re-initiallizing the serial number
                // Properties.Settings.Default.CurrentSerialNumber = 1;
                //Properties.Settings.Default.Save();
                return null;
            }
        }
        public bool Delete(Trainee trainee)
        {

            List<Trainee> trainees = GetAllTrainee();
            trainees.Remove(trainees.Where(t => t.SerialNumber == trainee.SerialNumber).FirstOrDefault());
            File.Delete(Path.Combine(directoryPath, fileName));
            foreach (Trainee traineeToWrite in trainees)
            {
                Add(traineeToWrite);
            }
            return true;
        }
        public bool Update(Trainee trainee)
        {

            List<Trainee> trainees = GetAllTrainee();
            Trainee existingTrainee = trainees.Where(t => t.SerialNumber == trainee.SerialNumber).FirstOrDefault();
            if (existingTrainee != null)
            {
                existingTrainee.Prefix = trainee.Prefix;
                existingTrainee.FirstName = trainee.FirstName;
                existingTrainee.MiddleName = trainee.MiddleName;
                existingTrainee.LastName = trainee.LastName;
                existingTrainee.Education = trainee.Education;
                existingTrainee.JoiningDate = trainee.JoiningDate;
                existingTrainee.CurrentCompany = trainee.CurrentCompany;
                existingTrainee.CurrentAddress = trainee.CurrentAddress;
                existingTrainee.DateOfBirth = trainee.DateOfBirth;
            }
            File.Delete(Path.Combine(directoryPath, fileName));
            foreach (Trainee traineeToWrite in trainees)
            {
                Add(traineeToWrite);
            }
            return true;
        }

    }
}
