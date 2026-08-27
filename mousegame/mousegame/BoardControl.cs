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
        public BoardControl()
        {
            InitializeComponent();
        }

        public void LoadBoard(List<TileInfo> tiles)
        {
            int tileSize = 40;

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

        private void Tile_Click(object sender, EventArgs e)
        {
            var clickedBox = (PictureBox)sender;
            int tileId = (int)clickedBox.Tag;

            MessageBox.Show($"Clicked tile with tile_id {tileId}");
        }
    }
}
