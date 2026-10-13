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
        private readonly LoginResult _loginResult;
        public MainForm(LoginResult loginResult)
        {
            InitializeComponent();
            _loginResult = loginResult;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (_loginResult.Admin == 1)
            {
                manageGamesBtn.Visible = true;
                manageUsersBtn.Visible = true;
                adminToolsLabel.Visible = true;
            }
            else
            {
                manageGamesBtn.Visible = false;
                manageUsersBtn.Visible = false;
                adminToolsLabel.Visible = false;
            }
            int userId = _loginResult.UserId ?? 0;
        }

        private void manageGamesBtn_Click(object sender, EventArgs e)
        {
            var dao = new AdminDAO();
            string summary = dao.GetAllGames();
            MessageBox.Show(summary, "Games");
        }

        private void joinGameBtn_Click(object sender, EventArgs e)
        {
            var joinGameForm = new JoinGameForm();
            joinGameForm.Show();
        }
    }
}
