using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace mousegame
{
    public partial class NewGameForm : Form
    {
        private readonly int _userId;
        public NewGameForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(gameNameTextbox.Text))
            {
                MessageBox.Show("Game name cannot be empty.");
                return;
            }
            var dao = new GameDAO();
            NewGameResult result = dao.newGame(_userId, gameNameTextbox.Text);
            if (result.GameId == -1 || result.Status != "success")
            {
                MessageBox.Show(result.Message);
                return;
            }
            else
            {
                GameForm gameForm = new GameForm(_userId, result.GameId);
                gameForm.Show();
                this.Hide();
            }

        }
    }
}
