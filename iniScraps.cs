using System;

public class Class1
{
	public Class1()
	{
        //  IniFile ini = new IniFile(Path.Combine(basePath, "ConfigFile.ini"));
        //ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
        //configFileMap.ExeConfigFilename = filePath;

        //Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

        //// Accessing values from sections
        //directoryPath = config.AppSettings.Settings["TraineefileDbDirectory"].Value;
        //fileName = config.AppSettings.Settings["TraineefileDbName"].Value;


        // var iniParser = new IniDataParser();
        //IniData parsedData = iniParser.pa(filePath);
        //directoryPath = parsedData["FileInformation"]["TraineefileDbDirectory"];
        //fileName = parsedData["FileInformation"]["TraineefileDbName"];

        //var data = new IniData();
        //data["FileInformation"]["TraineefileDbDirectory"] = @"D:\.Net Development\FHP_VISPL\FHP\bin\Debug";
        //data["FileInformation"]["TraineefileDbName"] = @"traineeData.bin";
        //var parser = new IniDataParser();
        //using (StreamWriter writer = new StreamWriter(filePath))
        //{
        //    foreach (var section in data.Sections)
        //    {
        //        writer.WriteLine($"[{section.SectionName}]");
        //        foreach (var key in section.Keys)
        //        {
        //            writer.WriteLine($"{key.KeyName}={key.Value}");
        //        }
        //        writer.WriteLine();
        //    }
        //}
    }
}
