using FHP_DL.Interfaces;
using FHP_Res;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_DL
{
    internal class clsFHPSQLUIText: IUITextRepository
    {
        private readonly string connectionString;
        private string filePath = Environment.CurrentDirectory + @"\Resources\appConfig.ini";
        public clsFHPSQLUIText()
        {
            IniFilesHandle iniFile = new IniFilesHandle(filePath);
            connectionString = iniFile.IniReadValue("Db", "ConnectionString");
        }
        public List<string[]> GetUiText(string messageTable)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string query = $"select * from {messageTable}";
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string[]> messagesList = new List<string[]>();
                        while (reader.Read())
                        {
                            messagesList.Add(new string[] { reader["short_name"].ToString(), reader["long_name"].ToString() });
                        }
                        return messagesList;
                    }
                }
            }
        }
    }
}
