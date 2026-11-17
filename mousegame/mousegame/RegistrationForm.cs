using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace mousegame
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            var dao = new LoginDAO();
            string result = dao.Register(usernameTextbox.Text, passwordTextbox.Text);
            if (result == "success")
            {
                MessageBox.Show("Account created successfully");
                this.Hide();
            }
            else
            {
                passwordTextbox.Clear();
                MessageBox.Show(result);
            }
        }
    }
}
