using Microsoft.VisualBasic.ApplicationServices;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace mousegame
{
    public partial class ManageUsersForm : Form
    {
        public ManageUsersForm()
        {
            InitializeComponent();
        }

        private void ManageUsersForm_Load(object sender, EventArgs e)
        {
            AdminDAO dao = new AdminDAO();
            List<UserInfo> users = dao.GetAllUsers();
            userGrid.DataSource = users;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            AdminDAO dao = new AdminDAO();
            UserInfo user = (UserInfo)userGrid.CurrentRow.DataBoundItem;
            EditUserForm editUserForm = new EditUserForm(user);
            editUserForm.Show();
        }

        private void unlockBtn_Click(object sender, EventArgs e)
        {
            AdminDAO dao = new AdminDAO();
            UserInfo user = (UserInfo)userGrid.CurrentRow.DataBoundItem;
            dao.UnlockUser(user.UserId);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            AdminDAO dao = new AdminDAO();
            UserInfo user = (UserInfo)userGrid.CurrentRow.DataBoundItem;
            dao.DeleteUser(user.UserId);
            List<UserInfo> users = dao.GetAllUsers();
            userGrid.DataSource = users;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
        }
    }
}
