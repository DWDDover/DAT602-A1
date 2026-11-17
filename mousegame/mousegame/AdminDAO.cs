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
        public Result KillGame(int gameId)
        {
            Result result = new Result();
            try
            {
                using (var command = new MySqlCommand("sp_kill_game", mySqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_game_id", gameId);
                    mySqlConnection.Open();
                    using(var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            {
                                result.Status = (string)reader["status"];
                                result.Message = (string)reader["message"];
                            };
                        }
                    }
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {
                result.Status = "error";
                result.Message = "Unable to connect to the database. Please try again later.";
            }
            catch (Exception)
            {
                result.Status = "error";
                result.Message = "An unexpected error occurred.";
            }
            finally
            {
                if (mySqlConnection.State != ConnectionState.Closed)
                {
                    mySqlConnection.Close();
                }
            }
            return result;
        }

        public List<UserInfo> GetAllUsers()
        {
            var users = new List<UserInfo>();
            try
            {
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
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Unable to connect to the database. Please try again later.");
            }
            catch (Exception)
            {
                MessageBox.Show("An unexpected error occurred.");
            }
            finally
            {
                if (mySqlConnection.State != ConnectionState.Closed)
                {
                    mySqlConnection.Close();
                }
            }
            return users;
        }

        public List<GameInfo> GetAllGames()
        {
            var games = new List<GameInfo>();
            try
            {
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
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Unable to connect to the database. Please try again later.");
            }
            catch (Exception)
            {
                MessageBox.Show("An unexpected error occurred.");
            }
            finally
            {
                if (mySqlConnection.State != ConnectionState.Closed)
                {
                    mySqlConnection.Close();
                }
            }
            return games;
        }
        public Result UpdateUser(int userId, string username)
        {
            Result result = new Result();
            try
            {
                using (var command = new MySqlCommand("sp_update_user", mySqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_user_id", userId);
                    command.Parameters.AddWithValue("@p_username", username);
                    mySqlConnection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result.Status = (string)reader["status"];
                            result.Message = (string)reader["message"];
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                result.Status = "error";
                result.Message = "Unable to connect to the database. Please try again later.";
            }
            catch (Exception)
            {
                result.Status = "error";
                result.Message = "An unexpected error occurred.";
            }
            finally
            {
                if (mySqlConnection.State != ConnectionState.Closed)
                {
                    mySqlConnection.Close();
                }
            }
            return result;
        }
        public Result UnlockUser(int userId)
        {
            Result result = new Result();
            try
            {
                using (var command = new MySqlCommand("sp_unlock_user", mySqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_user_id", userId);
                    mySqlConnection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result.Status = (string)reader["status"];
                            result.Message = (string)reader["message"];
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                result.Status = "error";
                result.Message = "Unable to connect to the database. Please try again later.";
            }
            catch (Exception)
            {
                result.Status = "error";
                result.Message = "An unexpected error occurred.";
            }
            finally
            {
                if (mySqlConnection.State != ConnectionState.Closed)
                {
                    mySqlConnection.Close();
                }
            }
            return result;
        }
        public void DeleteUser(int userId)
        {
            try
            {
                using (var command = new MySqlCommand("sp_delete_user", mySqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_user_id", userId);
                    mySqlConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Unable to connect to the database. Please try again later.");
            }
            catch (Exception)
            {
                MessageBox.Show("An unexpected error occurred.");
            }
            finally
            {
                if (mySqlConnection.State != ConnectionState.Closed)
                {
                    mySqlConnection.Close();
                }
            }
        }
    }
}