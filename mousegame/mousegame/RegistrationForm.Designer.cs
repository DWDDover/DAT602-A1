namespace mousegame
{
    partial class RegistrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            passwordTextbox = new TextBox();
            passwordLabel = new Label();
            usernameTextbox = new TextBox();
            usernameLabel = new Label();
            titleLabel = new Label();
            cancelBtn = new Button();
            registerBtn = new Button();
            SuspendLayout();
            // 
            // passwordTextbox
            // 
            passwordTextbox.Location = new Point(271, 242);
            passwordTextbox.Name = "passwordTextbox";
            passwordTextbox.PasswordChar = '*';
            passwordTextbox.Size = new Size(337, 23);
            passwordTextbox.TabIndex = 9;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(177, 245);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(60, 15);
            passwordLabel.TabIndex = 8;
            passwordLabel.Text = "Password:";
            // 
            // usernameTextbox
            // 
            usernameTextbox.Location = new Point(271, 167);
            usernameTextbox.Name = "usernameTextbox";
            usernameTextbox.Size = new Size(337, 23);
            usernameTextbox.TabIndex = 7;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(177, 170);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(63, 15);
            usernameLabel.TabIndex = 6;
            usernameLabel.Text = "Username:";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 28F);
            titleLabel.Location = new Point(329, 53);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(153, 51);
            titleLabel.TabIndex = 5;
            titleLabel.Text = "Sign Up";
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(442, 375);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(133, 37);
            cancelBtn.TabIndex = 11;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // registerBtn
            // 
            registerBtn.Location = new Point(233, 375);
            registerBtn.Name = "registerBtn";
            registerBtn.Size = new Size(133, 37);
            registerBtn.TabIndex = 10;
            registerBtn.Text = "Register";
            registerBtn.UseVisualStyleBackColor = true;
            registerBtn.Click += registerBtn_Click;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cancelBtn);
            Controls.Add(registerBtn);
            Controls.Add(passwordTextbox);
            Controls.Add(passwordLabel);
            Controls.Add(usernameTextbox);
            Controls.Add(usernameLabel);
            Controls.Add(titleLabel);
            Name = "RegistrationForm";
            Text = "RegistrationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox passwordTextbox;
        private Label passwordLabel;
        private TextBox usernameTextbox;
        private Label usernameLabel;
        private Label titleLabel;
        private Button cancelBtn;
        private Button registerBtn;
    }
}