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
    }
}