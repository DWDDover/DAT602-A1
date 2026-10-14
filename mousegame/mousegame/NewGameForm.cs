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
            int newGameId = dao.newGame(_userId, gameNameTextbox.Text);
            GameForm gameForm = new GameForm(_userId, newGameId);
            gameForm.Show();
            this.Hide();
        }
    }
}
