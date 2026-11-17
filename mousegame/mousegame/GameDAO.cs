using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace mousegame
{
    class GameDAO : DatabaseAccessObject
    {
        public List<TileInfo> GetTilesForGame(int gameId)
        {
            var tiles = new List<TileInfo>();
            try
            {
                using (var command = new MySqlCommand("GetTilesForGame", mySqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_game", gameId);

                    mySqlConnection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tile = new TileInfo
                            {
                                TileId = (int)reader["tile_id"],
                                Row = (int)reader["row"],
                                Col = (int)reader["col"]
                            };
                            tiles.Add(tile);
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
            return tiles;
        }

        public Result MoveCat(int gameId)
        {
            Result result = new Result();
            try
            {
                using (var command = new MySqlCommand("sp_move_cat", mySqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_game_id", gameId);
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

        public Result PlaceCheese(int gameId)
        {
            Result result = new Result();
            try
            {
                using (var command = new MySqlCommand("sp_place_cheese", mySqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_game_id", gameId);
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

        public List<InventoryItem> GetInventory(int userId, int gameId)
        {
            var inventory = new List<InventoryItem>();
            try
            {
                using (var command = new MySqlCommand("sp_inventory", mySqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_user_id", userId);
                    command.Parameters.AddWithValue("p_game_id", gameId);
                    mySqlConnection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new InventoryItem
                            {
                                ItemId = (int)reader["mousetrap_id"],
                                ItemName = (string)reader["item"],
                            };
                            inventory.Add(item);
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
            return inventory;
        }

        public List<Item> GetGameState(int gameId)
        {
            var items = new List<Item>();
            try
            {
                using (var command = new MySqlCommand("sp_gamestate", mySqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_game_id", gameId);
                    mySqlConnection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new Item
                            {
                                TileId = (int)reader["tile_id"],
                                Kind = (string)reader["kind"],
                                RefId = reader.GetInt32(reader.GetOrdinal("ref_id")) as int?
                            };
                            items.Add(item);
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
            return items;
        }

        public NewGameResult newGame(int userId, string gameName)
        {
            try
            {
                NewGameResult result = new NewGameResult();
                using (var command = new MySqlCommand("sp_newgame", mySqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_gamehost_id", userId);
                    command.Parameters.AddWithValue("p_gamename", gameName);
                    mySqlConnection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result.Status = (string)reader["status"];
                            result.Message = (string)reader["message"];
                            result.GameId = Convert.ToInt32(reader["new_game_id"]);
                        }
                    }
                }
                return result;
            }
            catch (MySqlException)
            {
                return new NewGameResult
                {
                    GameId = -1,
                    Status = "error",
                    Message = "Unable to connect to the database. Please try again later."
                };
            }
            catch (Exception)
            {
                return new NewGameResult
                {
                    GameId = -1,
                    Status = "error",
                    Message = "An unexpected error occurred."
                };
            }
            finally
            {
                if (mySqlConnection.State != ConnectionState.Closed)
                {
                    mySqlConnection.Close();
                }
            }
        }

        public string GetGameName(int gameId)
        {
            string gameName = null;
            try
            {
                using (var command = new MySqlCommand("sp_gamename", mySqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_game_id", gameId);
                    mySqlConnection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            gameName = (string)reader["game_name"];
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
            return gameName;
        }

        public Result PlaceTrap(int gameId)
        {
            Result result = new Result();
            try
            {
                using (var command = new MySqlCommand("sp_place_trap", mySqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_game_id", gameId);
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

        public Result ActivateTrap(int userId, int gameId, int tileId, int mousetrapId)
        {
            Result result = new Result();
            try
            {
                using (var command = new MySqlCommand("sp_activate_trap", mySqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_user_id", userId);
                    command.Parameters.AddWithValue("p_game_id", gameId);
                    command.Parameters.AddWithValue("p_tile_id", tileId);
                    command.Parameters.AddWithValue("p_mousetrap_id", mousetrapId);
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

        public Result MovePlayer(int userId, int gameId, int tileId)
        {
            Result result = new Result();
            try
            {
                using (var command = new MySqlCommand("sp_move_player", mySqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_user_id", userId);
                    command.Parameters.AddWithValue("p_game_id", gameId);
                    command.Parameters.AddWithValue("p_tile_id", tileId);
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

        public List<PlayerInfo> GetPlayers(int gameId)
        {
            var players = new List<PlayerInfo>();
            try
            {
                using (var command = new MySqlCommand("sp_players", mySqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_game_id", gameId);
                    mySqlConnection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            players.Add(new PlayerInfo
                            {
                                UserId = Convert.ToInt32(reader["user_id"]),
                                Username = reader["username"].ToString(),
                                Score = Convert.ToInt32(reader["score"])
                            });
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
            return players;
        }

        public void AddPlayer(int userId, int gameId)
        {
            try
            {
                using (var command = new MySqlCommand("sp_add_player", mySqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_user_id", userId);
                    command.Parameters.AddWithValue("p_game_id", gameId);
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
        public void RemovePlayer(int userId, int gameId)
        {
            try
            {
                using (var command = new MySqlCommand("sp_remove_player", mySqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_user_id", userId);
                    command.Parameters.AddWithValue("p_game_id", gameId);
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