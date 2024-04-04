using FHP_Res;
using FHP_Res.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_DL
{
    public class QualificationSQLDL
    {
        private readonly string connectionString;
        private string filePath = @"D:\.Net Development\FHP_VERTEX\Build\Resources\appConfig.ini";
        public QualificationSQLDL()
        {
            IniFilesHandle iniFile = new IniFilesHandle(filePath);
            connectionString = iniFile.IniReadValue("Db", "ConnectionString");
        }
        public List<Qualification> GetAllQualifications()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string query = "select * from Qualification";
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    // --------------- checking whether the db is present or not
                    try
                    {
                        sqlConnection.Open();
                    }
                    // ------------- will create the db
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        return null;
                    }
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Qualification> qualifications = new List<Qualification>();
                        while (reader.Read())
                        {
                            Qualification qualification = new Qualification();
                            qualification.id = Convert.ToByte(reader["id"]);
                            qualification.short_name = reader["short_name"].ToString();
                            qualification.long_name = reader["long_name"].ToString();
                            qualifications.Add(qualification);
                        }
                        return qualifications;
                    }
                }
            }
        }
    }
}
