using MySqlConnector;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace mousegame
{
    class LoginDAO : DatabaseAccessObject
    {
        public string GetAllUsersSummary()
        {
            var result = new StringBuilder();

            using (var command = new MySqlCommand("GetAllUsers", mySqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                mySqlConnection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.AppendLine(reader["username"] + " - " + reader["high_score"]);
                    }
                }

                mySqlConnection.Close();
            }

            return result.ToString();
        }
        public LoginResult Login(string p_username, string p_password)
        {
            var result = new LoginResult();
            using (var command = new MySqlCommand("sp_login", mySqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_username", p_username);
                command.Parameters.AddWithValue("@p_password", p_password);
                mySqlConnection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result.Status = (string)reader["status"];
                        result.UserId = reader["user_id"] == DBNull.Value ? null : (int?)reader["user_id"];
                        result.Admin = reader["admin"] == DBNull.Value ? null : (int?)reader["admin"];
                    }
                }

                mySqlConnection.Close();
            }

            return result;
        }
        public string Register(string p_username, string p_password)
        {
            using (var command = new MySqlCommand("sp_registration", mySqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_username", p_username);
                command.Parameters.AddWithValue("@p_password", p_password);

                mySqlConnection.Open();
                var status = command.ExecuteScalar();
                mySqlConnection.Close();

                return Convert.ToString(status);
            }
        }
    }
}
