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
        private readonly int _admin;
        public NewGameForm(int userId, int Admin)
        {
            InitializeComponent();
            _userId = userId;
            _admin = Admin;
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
                GameForm gameForm = new GameForm(_userId, result.GameId, _admin);
                gameForm.Show();
                System.Diagnostics.Debug.WriteLine($"{result.Status}: {result.Message} with ID: {result.GameId}");
                this.Hide();
            }

        }
    }
}
