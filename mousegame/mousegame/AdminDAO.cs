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

        public List<UserInfo> GetAllUsers()
        {
            var users = new List<UserInfo>();
            using (var command = new MySqlCommand("sp_GetAllUsers", mySqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                mySqlConnection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new UserInfo
                        {
                            UserId = (int)reader["user_id"],
                            Username = (string)reader["username"],
                            Locked = (int)reader["locked"]
                        };
                        users.Add(user);
                    }
                }
                mySqlConnection.Close();
            }
            return users;
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
        public void UpdateUser(int userId, string username)
        {
            using (var command = new MySqlCommand("sp_update_user", mySqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_user_id", userId);
                command.Parameters.AddWithValue("@p_username", username);
                mySqlConnection.Open();
                command.ExecuteNonQuery();
                mySqlConnection.Close();
            }
        }
    }
}