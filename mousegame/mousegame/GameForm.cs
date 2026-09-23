using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace mousegame
{
    public partial class GameForm : Form
    {
        private int gameId;

        public GameForm(int gameId)
        {
            this.gameId = gameId;
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            var dao = new GameDAO();
            var tiles = dao.GetTilesForGame(gameId);
            boardControl1.LoadBoard(tiles);
        }
    }
}
