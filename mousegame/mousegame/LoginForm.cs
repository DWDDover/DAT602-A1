namespace mousegame
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            var dao = new LoginDAO();
            LoginResult result = dao.Login(usernameTextbox.Text, passwordTextbox.Text);
            if (result.Status == "success")
            {
                var mainForm = new MainForm(result);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                passwordTextbox.Clear();
                MessageBox.Show(result.Status);
            }
        }
    }
}
