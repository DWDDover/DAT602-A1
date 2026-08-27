using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace mousegame
{
    class AdminDAO : DatabaseAccessObject
    {
        public string GetAllGames()
        {
            var result = new StringBuilder();

            using (var command = new MySqlCommand("GetAllGames", mySqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                mySqlConnection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.AppendLine("Game ID: " + reader["game_id"] + " Game name: " + reader["name"] + " Player Count: " + reader["player_count"]);
                    }
                }

                mySqlConnection.Close();
            }

            return result.ToString();
        }
    }
}