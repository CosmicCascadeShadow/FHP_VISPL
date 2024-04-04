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
    internal class clsFHPSqlUserDL : IUserRepository
    {
        private readonly string connectionString;
        // private string filePath = Environment.CurrentDirectory + @"\Resources\appConfig.ini";
        private string filePath = @"D:\.Net Development\FHP_VERTEX\Build\Resources\appConfig.ini";
        public clsFHPSqlUserDL()
        {
            IniFilesHandle iniFile = new IniFilesHandle(filePath);
            connectionString = iniFile.IniReadValue("Db", "ConnectionString");
        }
        public bool Add(UserModel user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO users  
                         VALUES (@loginId, @password, @role)";

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@loginId", user.Id);
                    command.Parameters.AddWithValue("@password", user.Password);
                    command.Parameters.AddWithValue("@role", user.Role);
                    try
                    {
                        sqlConnection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
        }
        public List<UserModel> GetAllUsers()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM users";
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
                        List<UserModel> users = new List<UserModel>();
                        while (reader.Read())
                        {
                            UserModel user = new UserModel();
                            user.Id = reader["loginId"].ToString();
                            user.Password = reader["password"].ToString();
                            user.Role = Convert.ToByte(reader["role"]);
                            users.Add(user);
                        }
                        return users;
                    }
                }
            }
        }
    }
}
