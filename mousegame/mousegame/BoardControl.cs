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
        private int userId;
        private int gameId;
        private int? selectedMousetrapId;

        public void SetGame(int userId, int gameId)
        {
            this.userId = userId;
            this.gameId = gameId;
        }

        public void SelectMousetrap(int mousetrapId)
        {
            selectedMousetrapId = mousetrapId;
        }

        private readonly Dictionary<int, PictureBox> tileBoxes = new Dictionary<int, PictureBox>();

        private readonly Image[] mouseImages =
        {
            Properties.Resources.grey,
            Properties.Resources.darkblue,
            Properties.Resources.green,
            Properties.Resources.lightblue,
            Properties.Resources.lightgreen,
            Properties.Resources.maroon,
            Properties.Resources.orange,
            Properties.Resources.pink,
            Properties.Resources.purple,
            Properties.Resources.yellow
        };

        private Image catImage = Properties.Resources.cat;
        private Image cheeseImage = Properties.Resources.cheese;

        private Image trapImage = Properties.Resources.trap;
        private Image trapActivatedImage = Properties.Resources.trapactivated;

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
            tileBoxes.Clear();
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
                tileBoxes[tile.TileId] = box;
            }
        }

        public void UpdateBoard()
        {
            GameDAO dao = new GameDAO();
            var gameItems = dao.GetGameState(gameId);
            // Clear existing images
            foreach (var box in tileBoxes.Values)
            {
                box.Image = null;
            }
            foreach (var item in gameItems)
            {
                if (tileBoxes.ContainsKey(item.TileId))
                {
                    var box = tileBoxes[item.TileId];
                    switch (item.Kind)
                    {
                        case "cheese": box.Image = cheeseImage; break;
                        case "mousetrap": box.Image = trapImage; break;
                        case "mousetrapactivated": box.Image = trapActivatedImage; break;
                        case "mouse": box.Image = GetMouseImage(item.RefId); break;
                        case "cat": box.Image = catImage; break;
                    }
                }
            }
        }

        private Image GetMouseImage(int? mouseUserId)
        {
            if (!mouseUserId.HasValue || mouseUserId.Value == userId)
            {
                return mouseImages[0];
            }

            int colourIndex = Math.Abs(mouseUserId.Value) % (mouseImages.Length - 1) + 1;
            return mouseImages[colourIndex];
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            var clickedBox = (PictureBox)sender;
            int tileId = (int)clickedBox.Tag;
            GameDAO dao = new GameDAO();

            Result result;

            if (selectedMousetrapId.HasValue)
            {
                result = dao.ActivateTrap(userId, gameId, tileId, selectedMousetrapId.Value);

                if (result.Status == "success")
                {
                    selectedMousetrapId = null;
                }
                else
                {
                    MessageBox.Show($"{result.Status}: {result.Message}");
                }
            }
            else
            {
                result = dao.MovePlayer(userId, gameId, tileId);
            }

            System.Diagnostics.Debug.WriteLine($"{result.Status}: {result.Message}");
            UpdateBoard();
        }
    }
}
