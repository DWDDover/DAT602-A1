using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace mousegame
{
    public partial class BoardControl : UserControl
    {
        private readonly int userId;
        private readonly int gameId;

        public BoardControl()
        {
            InitializeComponent();
        }

        public BoardControl(int userId, int gameId)
        {
            InitializeComponent();
            this.userId = userId;
            this.gameId = gameId;
        }

        public void LoadBoard(List<TileInfo> tiles)
        {
            int tileSize = 50;

            foreach (var tile in tiles)
            {
                var box = new PictureBox();
                box.Size = new Size(tileSize, tileSize);
                box.Location = new Point(tile.Col * tileSize, tile.Row * tileSize);
                box.BorderStyle = BorderStyle.FixedSingle;
                box.Tag = tile.TileId;
                box.Click += Tile_Click;

                this.Controls.Add(box);
            }
        }

        public void UpdateBoard()
        {
            // Logic to update the board based on game state
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            var clickedBox = (PictureBox)sender;
            int tileId = (int)clickedBox.Tag;
            GameDAO dao = new GameDAO();

            dao.MovePlayer(userId, gameId, tileId);
        }
    }
}
