using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace mousegame
{
    public partial class EditUserForm : Form
    {
        private readonly UserInfo _user;
        internal EditUserForm(UserInfo user)
        {
            InitializeComponent();
            _user = user;
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            usernameTextbox.Text = _user.Username;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            AdminDAO dao = new AdminDAO();
            dao.UpdateUser(_user.UserId, usernameTextbox.Text);
            this.Close();
        }
    }
}
