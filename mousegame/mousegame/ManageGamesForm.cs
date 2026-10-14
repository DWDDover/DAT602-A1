using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace mousegame
{
    public partial class ManageGamesForm : Form
    {
        public ManageGamesForm()
        {
            InitializeComponent();
        }

        private void ManageGamesForm_Load(object sender, EventArgs e)
        {
            AdminDAO dao = new AdminDAO();
            List<GameInfo> games = dao.GetAllGames();
            gameGrid.DataSource = games;
        }

        private void UpdateDisplay()
        {
            AdminDAO dao = new AdminDAO();
            List<GameInfo> games = dao.GetAllGames();
            gameGrid.DataSource = games;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void killBtn_Click(object sender, EventArgs e)
        {
            int gameId = Convert.ToInt32(gameGrid.CurrentRow.Cells[0].Value);
            AdminDAO dao = new AdminDAO();
            dao.KillGame(gameId);
            UpdateDisplay();
        }
    }
}
