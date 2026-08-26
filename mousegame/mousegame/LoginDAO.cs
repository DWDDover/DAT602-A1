using MySqlConnector;
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
    }
}
