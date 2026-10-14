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
        public void KillGame(int gameId)
        {
            using (var command = new MySqlCommand("sp_kill_game", mySqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_game_id", gameId);
                mySqlConnection.Open();
                command.ExecuteNonQuery();
                mySqlConnection.Close();
            }
        }

        public List<GameInfo> GetAllGames()
        {
            var games = new List<GameInfo>();

            using (var command = new MySqlCommand("GetAllGames", mySqlConnection))
            {

                command.CommandType = CommandType.StoredProcedure;

                mySqlConnection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tile = new GameInfo
                        {
                            GameId = (int)reader["game_id"],
                            Name = (string)reader["name"],
                            PlayerCount = Convert.ToInt32(reader["player_count"])
                        };
                        games.Add(tile);
                    }
                }

                mySqlConnection.Close();
            }

            return games;
        }
    }
}