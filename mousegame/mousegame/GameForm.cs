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
        private int _userId;
        private int _gameId;

        public GameForm(int userId, int gameId)
        {
            this._userId = userId;
            this._gameId = gameId;
            InitializeComponent();
            gameNameLabel.Text = GameName(gameId);
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            var dao = new GameDAO();
            var tiles = dao.GetTilesForGame(_gameId);
            boardControl1.LoadBoard(tiles);
        }

        private string GameName(int gameId)
        {
            var dao = new GameDAO();
            return dao.GetGameName(gameId);
        }

        private void inventoryLabel_Click(object sender, EventArgs e)
        {

        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GameDAO dao = new GameDAO();
            dao.RemovePlayer(_userId, _gameId);
        }
    }
}
