namespace mousegame
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            titleLabel = new Label();
            usernameLabel = new Label();
            usernameTextbox = new TextBox();
            passwordLabel = new Label();
            passwordTextbox = new TextBox();
            loginBtn = new Button();
            signupBtn = new Button();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 28F);
            titleLabel.Location = new Point(252, 48);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(264, 51);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "MOUSE GAME";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(158, 166);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(63, 15);
            usernameLabel.TabIndex = 1;
            usernameLabel.Text = "Username:";
            // 
            // usernameTextbox
            // 
            usernameTextbox.Location = new Point(252, 163);
            usernameTextbox.Name = "usernameTextbox";
            usernameTextbox.Size = new Size(337, 23);
            usernameTextbox.TabIndex = 2;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(158, 241);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(60, 15);
            passwordLabel.TabIndex = 3;
            passwordLabel.Text = "Password:";
            // 
            // passwordTextbox
            // 
            passwordTextbox.Location = new Point(252, 238);
            passwordTextbox.Name = "passwordTextbox";
            passwordTextbox.PasswordChar = '*';
            passwordTextbox.Size = new Size(337, 23);
            passwordTextbox.TabIndex = 4;
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(220, 350);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(133, 37);
            loginBtn.TabIndex = 5;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // signupBtn
            // 
            signupBtn.Location = new Point(429, 350);
            signupBtn.Name = "signupBtn";
            signupBtn.Size = new Size(133, 37);
            signupBtn.TabIndex = 6;
            signupBtn.Text = "Sign Up";
            signupBtn.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(signupBtn);
            Controls.Add(loginBtn);
            Controls.Add(passwordTextbox);
            Controls.Add(passwordLabel);
            Controls.Add(usernameTextbox);
            Controls.Add(usernameLabel);
            Controls.Add(titleLabel);
            Name = "LoginForm";
            Text = "Login Form";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label usernameLabel;
        private TextBox usernameTextbox;
        private Label passwordLabel;
        private TextBox passwordTextbox;
        private Button loginBtn;
        private Button signupBtn;
    }
}
