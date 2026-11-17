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
        private int _admin;

        public GameForm(int userId, int gameId, int Admin)
        {
            this._userId = userId;
            this._gameId = gameId;
            this._admin = Admin;
            InitializeComponent();
            inventoryGrid.CellClick += inventoryGrid_CellClick;
            gameNameLabel.Text = GameName(gameId);
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            var dao = new GameDAO();
            if (_admin == 1)
            {
                moveCatBtn.Visible = true;
                placeCheeseBtn.Visible = true;
                mousetrapBtn.Visible = true;
            }
            else
            {
                moveCatBtn.Visible = false;
                placeCheeseBtn.Visible = false;
                mousetrapBtn.Visible = false;
            }
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
            List<Message> messages = dao.GetMessages(_gameId);
            chatListBox.DataSource = messages;
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

        private void inventoryGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (inventoryGrid.Rows[e.RowIndex].DataBoundItem is InventoryItem item)
            {
                boardControl1.SelectMousetrap(item.ItemId);
            }
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            gameTick.Stop();
            GameDAO dao = new GameDAO();
            Result result = dao.RemovePlayer(_userId, _gameId);

            if (result.Status == "success")
            {
                System.Diagnostics.Debug.WriteLine($"{result.Status}: {result.Message}");
            }
            else
            {
                MessageBox.Show($"{result.Status}: {result.Message}");
            }
        }

        private void gameTick_Tick(object sender, EventArgs e)
        {
            boardControl1.UpdateBoard();
            UpdateForm();
        }

        private void moveCatBtn_Click(object sender, EventArgs e)
        {
            GameDAO dao = new GameDAO();
            Result result = dao.MoveCat(_gameId);
            if (result.Status == "success")
            {
                System.Diagnostics.Debug.WriteLine($"{result.Status}: {result.Message}");
            }
            else
            {
                MessageBox.Show($"{result.Status}: {result.Message}");
            }

            boardControl1.UpdateBoard();
        }

        private void placeCheeseBtn_Click(object sender, EventArgs e)
        {
            GameDAO dao = new GameDAO();
            Result result = dao.PlaceCheese(_gameId);
            if (result.Status == "success")
            {
                System.Diagnostics.Debug.WriteLine($"{result.Status}: {result.Message}");
            }
            else
            {
                MessageBox.Show($"{result.Status}: {result.Message}");
            }

            boardControl1.UpdateBoard();
        }

        private void mousetrapBtn_Click(object sender, EventArgs e)
        {
            GameDAO dao = new GameDAO();
            Result result = dao.PlaceTrap(_gameId);
            if (result.Status == "success")
            {
                System.Diagnostics.Debug.WriteLine($"{result.Status}: {result.Message}");
            }
            else
            {
                MessageBox.Show($"{result.Status}: {result.Message}");
            }

            boardControl1.UpdateBoard();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sendMessageButton_Click(object sender, EventArgs e)
        {
            GameDAO dao = new GameDAO();
            Result result = dao.SendMessage(_userId, _gameId, chatTextBox.Text);
            if (result.Status == "success")
            {
                System.Diagnostics.Debug.WriteLine($"{result.Status}: {result.Message}");
            }
            else
            {
                MessageBox.Show($"{result.Status}: {result.Message}");
            }
        }
    }
}
