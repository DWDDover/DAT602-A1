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
            boardControl1.SetGame(_userId, _gameId);
            boardControl1.LoadBoard(tiles);
            boardControl1.UpdateBoard();
            UpdateForm();
            gameTick.Start();
        }

        private void UpdateForm()
        {
            GameDAO dao = new GameDAO();
            List<PlayerInfo> players = dao.GetPlayers(_gameId);
            playersDataGrid.DataSource = players;
            score.Text = $"Score: {players.Find(p => p.UserId == _userId)?.Score ?? 0}";
            List<InventoryItem> inventory = dao.GetInventory(_userId, _gameId);
            inventoryGrid.DataSource = inventory;
            //get player score
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
            gameTick.Stop();
            GameDAO dao = new GameDAO();
            dao.RemovePlayer(_userId, _gameId);
        }

        private void gameTick_Tick(object sender, EventArgs e)
        {
            boardControl1.UpdateBoard();
            UpdateForm();
        }

        private void moveCatBtn_Click(object sender, EventArgs e)
        {
            GameDAO dao = new GameDAO();
            dao.MoveCat(_gameId);
            boardControl1.UpdateBoard();
        }

        private void placeCheeseBtn_Click(object sender, EventArgs e)
        {
            GameDAO dao = new GameDAO();
            dao.PlaceCheese(_gameId);
            boardControl1.UpdateBoard();
        }

        private void mousetrapBtn_Click(object sender, EventArgs e)
        {
            GameDAO dao = new GameDAO();
            dao.PlaceTrap(_gameId);
            boardControl1.UpdateBoard();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
