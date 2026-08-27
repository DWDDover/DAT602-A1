using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace mousegame
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void manageGamesBtn_Click(object sender, EventArgs e)
        {
            var dao = new AdminDAO();
            string summary = dao.GetAllGames();
            MessageBox.Show(summary, "Games");
        }

        private void joinGameBtn_Click(object sender, EventArgs e)
        {
            var gameForm = new GameForm();
            gameForm.Show();
        }
    }
}
