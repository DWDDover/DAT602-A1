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
            string summary = dao.GetAllUsersSummary();
            MessageBox.Show(summary, "Users");
            var gameForm = new GameForm();
            gameForm.Show();
        }
    }
}
