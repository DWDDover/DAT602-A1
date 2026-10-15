using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace mousegame
{
    class GameDAO : DatabaseAccessObject
    {
        public List<TileInfo> GetTilesForGame(int gameId)
        {
            var tiles = new List<TileInfo>();

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

                mySqlConnection.Close();
            }

            return tiles;
        }

        public void MoveCat(int gameId)
        {
            using (var command = new MySqlCommand("sp_move_cat", mySqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("p_game_id", gameId);
                mySqlConnection.Open();
                command.ExecuteNonQuery();
                mySqlConnection.Close();
            }
        }

        public void PlaceCheese(int gameId)
        {
            using (var command = new MySqlCommand("sp_place_cheese", mySqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("p_game_id", gameId);
                mySqlConnection.Open();
                command.ExecuteNonQuery();
                mySqlConnection.Close();
            }
        }

        public List<InventoryItem> GetInventory(int userId, int gameId)
        {
            var inventory = new List<InventoryItem>();
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
                mySqlConnection.Close();
            }
            return inventory;
        }

        public List<Item> GetGameState(int gameId)
        {
            var items = new List<Item>();
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
                mySqlConnection.Close();
            }
            return items;
        }

        public int newGame(int userId, string gameName)
        {
            int newGameId = -1;
            using (var command = new MySqlCommand("sp_newgame", mySqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("p_gamehost_id", userId);
                command.Parameters.AddWithValue("p_gamename", gameName);
                mySqlConnection.Open();
                newGameId = Convert.ToInt32(command.ExecuteScalar());
                mySqlConnection.Close();
            }
            return newGameId;
        }

        public string GetGameName(int gameId)
        {
            string gameName = null;
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
                mySqlConnection.Close();
            }
            return gameName;
        }

        public void PlaceTrap(int gameId)
        {
            using (var command = new MySqlCommand("sp_place_trap", mySqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("p_game_id", gameId);
                mySqlConnection.Open();
                command.ExecuteNonQuery();
                mySqlConnection.Close();
            }
        }
        public void MovePlayer(int userId, int gameId, int tileId)
        {
            using (var command = new MySqlCommand("sp_move_player", mySqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("p_user_id", userId);
                command.Parameters.AddWithValue("p_game_id", gameId);
                command.Parameters.AddWithValue("p_tile_id", tileId);
                mySqlConnection.Open();
                command.ExecuteNonQuery();
                mySqlConnection.Close();
            }
        }

        public List<PlayerInfo> GetPlayers(int gameId)
        {
            var players = new List<PlayerInfo>();
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
                mySqlConnection.Close();
            }
            return players;
        }

        public void AddPlayer(int userId, int gameId)
        {
            using (var command = new MySqlCommand("sp_add_player", mySqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("p_user_id", userId);
                command.Parameters.AddWithValue("p_game_id", gameId);
                mySqlConnection.Open();
                command.ExecuteNonQuery();
                mySqlConnection.Close();
            }
        }
        public void RemovePlayer(int userId, int gameId)
        {
            using (var command = new MySqlCommand("sp_remove_player", mySqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("p_user_id", userId);
                command.Parameters.AddWithValue("p_game_id", gameId);
                mySqlConnection.Open();
                command.ExecuteNonQuery();
                mySqlConnection.Close();
            }
        }
    }
}