using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace mousegame
{
    public partial class JoinGameForm : Form
    {
        private readonly int _userId;
        private readonly int _admin;
        public JoinGameForm(int userId, int Admin)
        {
            InitializeComponent();
            _userId = userId;
            _admin = Admin;
        }

        private void JoinGameForm_Load(object sender, EventArgs e)
        {
            AdminDAO dao = new AdminDAO();
            List<GameInfo> games = dao.GetAllGames();
            gameGrid.DataSource = games;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void joinBtn_Click(object sender, EventArgs e)
        {
            int gameId = Convert.ToInt32(gameGrid.CurrentRow.Cells[0].Value);
            GameForm gameForm = new GameForm(_userId, gameId, _admin);
            gameForm.Show();
            GameDAO dao = new GameDAO();
            dao.AddPlayer(_userId, gameId);
            this.Close();
        }
    }
}
